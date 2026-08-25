using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CRUD.Models.Master
{
   
    public class ClsPrp_Master_ProjectLandType
    {
        public int PromoterProjectLandType_IndexID { get; set; }
        public int PromoterProjectLand_TypeCode { get; set; }
        public string PromoterProjectLand_TypeName { get; set; }
        public int UserType_ValidCode { get; set; }
        public int PromoterProjectLandType_ValidCode { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}
