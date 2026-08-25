using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CRUD.Models.Agent;

namespace CRUD.Models.ClassComplaintPayment
{
    public class PaymentIntegrationModel
    {
        [Display(Name = "Application Id")]
        public string ApplicationId { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public string amount { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Product Information")]
        public string prodInfo { get; set; }
        [Required]
        [Display(Name = "Success URL")]
        public string surl { get; set; }
        [Required]
        [Display(Name = "Failure URL")]
        public string furl { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string email { get; set; }

        public Int32 unitid { get; set; }

        public string userid { get; set; }

        public List<CLsprpOtherThanIndivualAgent> AgentOtherThanInd { get; set; }

    }
}