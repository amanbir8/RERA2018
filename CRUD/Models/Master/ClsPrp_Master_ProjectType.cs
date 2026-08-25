using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CRUD.Models.Master
{ 
    
    public class ClsPrp_Master_ProjectType
    {
        public int PromoterProjectType_IndexID { get; set; }
        public int PromoterProject_TypeCode { get; set; }
        public string PromoterProject_TypeName { get; set; }
        public int UserType_ValidCode { get; set; }
        public int PromoterProjectType_ValidCode { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}
