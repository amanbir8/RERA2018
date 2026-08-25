using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ProjectTypeRegistration
    {
        public long     ProjectType_Registration_IndexID { get; set; }
        public long     ProjectType_Registration_ID { get; set; }
        public long     ProjectTypeRelated_ProjectRegistration_ID { get; set; }
        public string   ProjectType_Code { get; set; }
        public string   ProjectType_Name { get; set; }
        public string   ProjectType_SubType_Code { get; set; }
        public string   ProjectType_SubType_Name { get; set; }
        public int      IsActive { get; set; }
        public int      IsDraft { get; set; }
        public string   CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string   ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}