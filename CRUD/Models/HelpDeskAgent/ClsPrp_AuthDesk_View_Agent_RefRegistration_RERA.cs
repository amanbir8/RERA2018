using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA
    {
        public long Agent_RefRegistration_regRERA_IndexID { get; set; }
        public long Agent_RefRegistration_regRERA_ID { get; set; }

        public long RenewalAgent_ID { get; set; }
        public int RenewalOrderSequence { get; set; }
        public int RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public long Related_Agent_RefRegistrations_RERA_ID { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAregistration_Number { get; set; }

        [Display(Name = "Registration Issue Date")]
        [Required]        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_IssueDate { get; set; }

        [Display(Name = "Registration Valid Upto Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_ExpiryDate { get; set; }

        [Display(Name = "Diary Number")]
        public string Agent_Reference_DiaryNumber { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_Reference_ApplicationDate { get; set; }

        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }

        [Display(Name = "Type of Agent")]
        public string Agent_Type { get; set; }

        [Display(Name = "Certificate/Document")]
        public string ImageRERAcert_FileName { get; set; }
        public string ImageRERAcert_FilePath { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }        


        public long zapRelated_Agent_ID { get; set; }
        public int zapRelated_AgentType_ID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }

        public List<ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA> Agent_RefRegistrationsRERA { get; set; }
        public ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA()
        {
            Agent_RefRegistrationsRERA = new List<ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA>();
        }        
    }
}