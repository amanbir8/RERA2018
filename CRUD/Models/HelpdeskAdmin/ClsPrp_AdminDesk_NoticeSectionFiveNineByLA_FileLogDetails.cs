using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails
    {
        public long SectionFiveNine_EventAction_ID { get; set; }
        [Required]
        [Display(Name = "Action Operation Type")]
        public long EventAction_Type { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Last Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Required]
        [Display(Name = "Notice Section 59 ID")]
        public long Related_NoticesSectionFiveNine_ID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Notice/File Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Related_NoticeFile_NumberDetails { get; set; }

        public string EventAction_Description { get; set; }
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
        [StringLength(1000)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,1000}$", ErrorMessage = "Special characters are not allowed. Maximum length is 1000")]
        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails> prpNoticeSectionFiveNineFileLog { get; set; }
        public ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails()
        {
            prpNoticeSectionFiveNineFileLog = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails>();
        }

        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails> DeskEventMaster { get; set; }
        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> CurrentStatusEventDetails { get; set; }
    }
}