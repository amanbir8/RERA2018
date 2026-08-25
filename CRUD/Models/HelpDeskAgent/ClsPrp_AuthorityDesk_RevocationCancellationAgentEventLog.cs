using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog
    {
        public long AgentRevokeEventAction_ID { get; set; }
        [Required]
        [Display(Name = "Action Operation Type")]
        public long EventAction_Type { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Last Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public long Related_Agent_ID { get; set; }
        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalAgent_Year { get; set; }
        [Display(Name = "Diary Number")]
        public string Agent_DiaryNumber { get; set; }
        [Display(Name = "Diary Number (Renewal of Registration)")]
        public string LatestRenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Revoke Diary Number")]
        public string Revoke_DiaryNumber { get; set; }
        public string RERA_RegistrationNumber { get; set; }
        public string EventAction_Summary { get; set; }
        public string EventAction_Description { get; set; }
        public string EventAction_Category { get; set; }
        [Display(Name = "Application Status")]
        public string EventAction_Aggregate { get; set; }
        public string EventAction_Relationship { get; set; }
        [Display(Name = "Assigned To")]
        public string AssignedTo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Target_ResolutionDate { get; set; }
        public string Target_ResolutionSummary { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Actual_ResolutionDate { get; set; }
        public int IsBefore_TargetResolution { get; set; }
        public string ProgressStatus { get; set; }
        [Display(Name = "Remarks, If Any")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(2400)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,2400}$", ErrorMessage = "Special characters are not allowed. Maximum length is 2400.")]
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Agent Name")]
        public string AgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AgentLastModifiedOn { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string AgentRegistrationNumberName { get; set; }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog>();
        }
        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> EventMaster { get; set; }
    }
}