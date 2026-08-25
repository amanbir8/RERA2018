using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Master
{
    public class ClsPrp_Master_ApplicationFee
    {
        public int Fee_IndexID { get; set; }
        public int Fee_TitleCode { get; set; }
        public string Fee_TitleName { get; set; }
        public string Payment_Mode { get; set; }
        public decimal Registration_Fee { get; set; }
        public decimal Other_Fee { get; set; }
        public decimal Bank_Charges { get; set; }
        public int Fee_ValidCode { get; set; }
        public int Fee_ValidType { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}
