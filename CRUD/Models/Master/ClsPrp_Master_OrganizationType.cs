using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CRUD.Models.Master
{ 
    
    public  class ClsPrp_Master_OrganizationType
    {
        public int OrgType_IndexID { get; set; }
        public int Org_TypeCode { get; set; }
        public string Org_TypeName { get; set; }
        public int OrgType_ValidCode { get; set; }
        public int OrgType_ValidType { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}
