using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_ExistingRERA
    {
        public long ProjectExistingRERA_ID { get; set; }
        public string RERAregistration_Number { get; set; }
        public Nullable<System.DateTime> RERAregistration_IssueDate { get; set; }
        public Nullable<System.DateTime> RERAregistration_ExpiryDate { get; set; }
        public Nullable<System.DateTime> Date_of_Issue { get; set; }
        public string PromoterName { get; set; }
        public string ProjectName { get; set; }
        public string RERARegistrationNumber { get; set; }
        public string TypeofProject { get; set; }
        public string DistrictName { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}