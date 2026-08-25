using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.UserAccess
{
    public class ClsPrp_UserAccessType
    {
        public string User_id { get; set; }
        public Int64 Application_id { get; set; }
        public int User_Type { get; set; }
        public int User_ParentEntityFlag { get; set; }
        public int User_TrackRecordFlag { get; set; }
        public Int64 MobileNumber { get; set; }
        public string EmailID { get; set; }     
    }
    public class ClsPrp_UserAccessTypeAgent
    {
        public string User_id { get; set; }
        public Int64 Application_id { get; set; }
        public int User_Type { get; set; }
        public Int64 MobileNumber { get; set; }
        public string EmailID { get; set; }
    }
}