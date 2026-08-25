using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormN_SMTPsentlog
    {

        public long SentemailUserLogID { get; set; }
        public string ComplaintDiaryNumber { get; set; }
        public long ComplaintID { get; set; }

        [Display(Name = "SignInDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SignInDate { get; set; }

        public string UserName { get; set; }
        public string DestinationEmailAddress { get; set; }
        public string SourceHostName { get; set; }
        public string SourceIP { get; set; }
        public string Activity { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }


        public List<ClsPrp_AuthDesk_FormN_SMTPsentlog> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormN_SMTPsentlog()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormN_SMTPsentlog>();
        }
               
    }
}