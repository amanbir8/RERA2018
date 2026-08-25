using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthorityDesk_FormMiscEventLog
    {
        public long ComplaintMISC_EventAction_ID { get; set; }
        [Required]
        [Display(Name = "Action Operation Type")]
        public long EventAction_Type { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Last Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public long Related_ComplaintorApplication_ID { get; set; }        
        [Display(Name = "Complaint Diary Number")]
        public string Related_RegDiaryNumber { get; set; }
        
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
        
        public string ProgressStatus { get; set; }
        [Display(Name = "Remarks, If Any")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(1500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,1500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 1500")]
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public long zapRelated_Complaint_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }

        public List<ClsPrp_AuthorityDesk_FormMiscEventLog> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_FormMiscEventLog()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_FormMiscEventLog>();

        }

        public List<ClsPrp_AuthorityDesk_ComplaintEvent_Master> EventMaster { get; set; }
    }
}