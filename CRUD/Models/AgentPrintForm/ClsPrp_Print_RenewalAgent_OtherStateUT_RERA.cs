using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsPrp_Print_RenewalAgent_OtherStateUT_RERA
    {
        public long RenewalAgent_OtherStateUT_RERA_IndexID { get; set; }
        public long RenewalAgent_OtherStateUT_RERA_ID { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalOrderSequence { get; set; }
        public int Related_RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public DateTime? Related_RERAnumberIssueDate { get; set; }
        public DateTime? Related_RERAnumberRegUptoDate { get; set; }
        public long Related_Agent_OtherStateUT_RERA_ID { get; set; }

        [Display(Name = "State Name")]
        public string StateCode { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAregistration_Number { get; set; }

        [Display(Name = "RERA Registration IssueDate")]
        [Required]        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_IssueDate { get; set; }

        [Display(Name = "RERA Registration ExpiryDate")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_ExpiryDate { get; set; }

        public string ImageRERAcert_FileName { get; set; }
        public string ImageRERAcert_FilePath { get; set; }

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
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }
        [Display(Name = "Registration Number")]
        public string zapAgent_RegistrationNumber { get; set; }


        public List<ClsPrp_Print_RenewalAgent_OtherStateUT_RERA> Agent_OtherStateUTMember { get; set; }
        public ClsPrp_Print_RenewalAgent_OtherStateUT_RERA()
        {
            Agent_OtherStateUTMember = new List<ClsPrp_Print_RenewalAgent_OtherStateUT_RERA>();
        }        
    }
}