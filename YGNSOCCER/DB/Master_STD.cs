//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YGNSOCCER.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Master_STD
    {
        public int STD_CD { get; set; }
        public Nullable<int> STD_OPT_CD { get; set; }
        public string STD_Name { get; set; }
        public Nullable<bool> STD_Owner { get; set; }
        public System.Data.Entity.Spatial.DbGeography STD_Map { get; set; }
        public byte[] STD_Photos { get; set; }
        public Nullable<int> STD_Transportation_CD { get; set; }
        public Nullable<int> STD_Offers_CD { get; set; }
        public Nullable<decimal> STD_Fees { get; set; }
        public Nullable<decimal> STD_Discount { get; set; }
        public string STD_FloorType_CD { get; set; }
        public Nullable<int> STD_Roof_CD { get; set; }
        public Nullable<byte> STD_RatingLevel { get; set; }
        public string STD_PhoneNo { get; set; }
        public Nullable<int> STD_TownShip_CD { get; set; }
        public string STD_Comment { get; set; }
        public Nullable<int> STD_PayMentType_CD { get; set; }
        public string STD_LocationAddress { get; set; }
        public string STD_FBAddress { get; set; }
        public string STD_WebSiteAddress { get; set; }
        public string STD_EmailAddress { get; set; }
        public Nullable<bool> STD_IsDeleted { get; set; }
        public string STD_InsertOPTCD { get; set; }
        public Nullable<System.DateTime> STD_InsertOPTDateTime { get; set; }
        public string STD_Update_OPTCD { get; set; }
        public Nullable<System.DateTime> STD_Update_OPTDateTime { get; set; }
    }
}