using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormN_LogCommunication
    {
        public long CommUserLog_IndexID { get; set; }
        public long Complaint_ID { get; set; }

        [Display(Name = "Complaint Diary Number")]
        public string Complaint_DiaryNumber { get; set; }

        [Display(Name = "Notice Title")]
        public string CommunicationTitleName { get; set; }

        [Display(Name = "Date & Time")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SignInDate { get; set; }

        [Display(Name = "Activity")]
        public string CommunicationActivity { get; set; }

        [Display(Name = "Destination/ Source Address")]
        public string DestinationEmailAddress { get; set; }

        public string SourceHostName { get; set; }
        public string SourceIP { get; set; }
        public string Activity { get; set; }

        [Display(Name = "Activity Description")]
        public string ActivityDescription { get; set; }

        [Display(Name = "RERA Number")]
        public string RERAnumber { get; set; }

        [Display(Name = "Complaint Aganist")]
        public string ComplaintAganistName { get; set; }

        [Display(Name = "User/ Prepared By")]
        public string UserName { get; set; }

        [Display(Name = "Hearing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HearingDate { get; set; }
        [Display(Name = "Hearing Time")]        
        public string HearingTime { get; set; }
        [Display(Name = "Hearing Bench")]
        public string HearingBench { get; set; }        

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }

        public int IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }


        public long zapRelated_Complaint_ID { get; set; }
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "RERA Number")]
        public string zapComplainantRERAnumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }


        public List<ClsPrp_AuthDesk_FormN_LogCommunication> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormN_LogCommunication()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormN_LogCommunication>();
        } 
               
    }
}