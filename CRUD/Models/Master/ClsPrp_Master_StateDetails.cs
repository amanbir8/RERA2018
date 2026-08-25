using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CRUD.Models.Master
{
    public  class ClsPrp_Master_StateDetails
    {
        public int State_IndexID { get; set; }
        public int State_Code { get; set; }
        public string State_Name { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}
