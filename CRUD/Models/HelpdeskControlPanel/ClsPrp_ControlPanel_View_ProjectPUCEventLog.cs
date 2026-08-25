using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.HelpDesk;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCEventLog
    {
        public long ProjectEventActionPUC_ID { get; set; }

        [Required]
        [Display(Name = "Action Operation Type")]
        public long EventAction_Type { get; set; }

        public string EventAction_IdentifiedBy { get; set; }

        [Display(Name = "Last Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        public long RelatedApplicationPUC_ID { get; set; }
        public string Promoter_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "PUC Diary Number")]
        public string PUC_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        public string PUC_ReferencePUC_Name { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PUC_ReferencePUC_Date { get; set; }
        
        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
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

        [Display(Name = "Change Request For")]
        public string prmPUC_RequestCategoryName { get; set; }

        [Display(Name = "Change Request For")]
        public long prmPUC_RequestCategoryID { get; set; }
                     
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectPUCEventLog> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCEventLog()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCEventLog>();
        }
    }
}