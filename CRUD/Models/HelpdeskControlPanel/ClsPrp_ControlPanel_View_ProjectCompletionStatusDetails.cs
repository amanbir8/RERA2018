using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.HelpDesk;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails
    {
        public long ProjectCompletionEventAction_ID { get; set; }

        [Required]
        [Display(Name = "Action Operation Type")]
        public long EventAction_Type { get; set; }

        public string EventAction_IdentifiedBy { get; set; }

        [Display(Name = "Last Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }

        [Display(Name = "Promoter Diary Number")]
        public string Promoter_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "PCC Diary Number")]
        public string Completion_DiaryNumber { get; set; }

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



        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectLastModifiedOn { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsExtensionRegistration { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? RERAnumberExtensionRegUptoDate { get; set; }



        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Required]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Display(Name = "Project Address District")]
        public string DName { get; set; }


        [Display(Name = "Reference Number")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string PCC_ReferenceName { get; set; }

        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PCC_ReferenceDate { get; set; }

               
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails>();
        }

        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_AuthorityDesk_ProjectEvent_Master> prpEventMaster { get; set; }
    }
}