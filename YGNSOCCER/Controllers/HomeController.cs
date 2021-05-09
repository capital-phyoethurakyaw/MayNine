using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;

namespace YGNSOCCER.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult M_Floor()
        {

            ViewBag.Message = "Your M_Floor page.";
            return View();
        }
        public JsonResult SelectAll_Floor()
        {
            var ContextFloor = new DB.SOCCERDAYEntities2();
            var Floor = new DB.M_Floor();
            var result = (from r in ContextFloor.M_Floor 
                         select r).ToList();
            //  ViewBag.Country = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult M_Floor(YGNSOCCER.Models.Common Common)
        {

         //   ViewBag.Message = " M_Floor page.";

            if (!String.IsNullOrWhiteSpace(Common.Floor))
            {
                var ContextFloor = new DB.SOCCERDAYEntities2();
                var Floor = new DB.M_Floor()
                {
                    F_Type = Common.Floor,
                };
                
                ContextFloor.M_Floor.Add(Floor);
                ContextFloor.SaveChanges();
            }
            
            return View();
        }
        [HttpPost]
        public  ActionResult FuckYou(string a)
        {
            return Json(new
            {
                msg = "Successfully added " +a
            });
        }

        //public ActionResult Township()
        //{
        //    return View();
        //}
        
        public ActionResult Township(string Sorting_Order, string Search_Data, string Filter_Value,int? PageSize ,int? Page_No)
        {
            //var ContextFloor = new DB.SOCCERDAYEntities2();
            //var Floor = new DB.M_Floor();
            //var result = (from r in ContextFloor.M_Floor
            //              select r).ToList();
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
            var dbContext = new DB.SOCCERDAYEntities2();
            //var students = (from stu in dbContext.M_Transportation select stu);
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var students =( from stu in dbContext.M_TownShp select stu).ToList();

            //  students = students.Where(stu => stu.T_Type.ToUpper().Contains(Search_Data.ToUpper()));

            //switch (Sorting_Order)
            //{
            //    case "Name_Description":
            //        students = students.OrderByDescending(stu => stu.T_Type);
            //        break;
            //    //case "Date_Enroll":
            //    //    students = students.OrderBy(stu => stu.EnrollmentDate);
            //    //    break;
            //    //case "Date_Description":
            //    //    students = students.OrderByDescending(stu => stu.EnrollmentDate);
            //    //    break;
            //    default:
            //        students = students.OrderBy(stu => stu.T_Type);
            //        break;
            //}
            ViewBag.PageSize = new List<SelectListItem>()
         {
             new SelectListItem() { Value="5", Text= "5" },
             new SelectListItem() { Value="10", Text= "10" },
             new SelectListItem() { Value="15", Text= "15" },
             new SelectListItem() { Value="25", Text= "25" },
             new SelectListItem() { Value="50", Text= "50" },
         };
            string strDDLValue = Request.Form["PageSize"] ?? "5";
            int Size_Of_Page = PageSize ?? 5 ;
            ViewBag.Psize = Size_Of_Page;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult Pyament()
        {
            var dbContext = new DB.SOCCERDAYEntities2();
            var students = (from stu in dbContext.M_Payment select stu).ToList();
            return View();
        }

        [HttpGet]
        public string Pyament_()
        {
            var dbContext = new DB.SOCCERDAYEntities2();
            var students = (from stu in dbContext.M_Payment  select  stu  ).ToList();
            return DataTableToJSONWithJSONNet(students);
        }
        public string DataTableToJSONWithJSONNet(List<DB.M_Payment> table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }




    }
}