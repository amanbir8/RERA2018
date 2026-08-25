using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.HelpDesk;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCstatusDetails
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


        public long dPUC_RegDiaryNumber_IndexID { get; set; }
        public long dPUC_RegDiaryNumber_ID { get; set; }
        public string dPUC_RegDiaryNumber_Name { get; set; }
        public string dPUC_RegDiaryNumber_NameYear { get; set; }
        public string dUserID { get; set; }
        public long dRelatedPromoter_ID { get; set; }
        public long dRelatedProject_ID { get; set; }
        public long dRelatedApplicationPUC_ID { get; set; }

        [Display(Name = "Change Request For")]
        public string dPUC_RequestCategoryName { get; set; }

        [Display(Name = "Change Request For")]
        public long dPUC_RequestCategoryID { get; set; }

        public string dRERA_RegistrationNumber { get; set; }
        public string dPUC_ReferencePUC_Name { get; set; }
        public int dPUC_ReferencePUC_Year { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dPUC_ReferencePUC_Date { get; set; }

        public int dPaymentDetailsCount { get; set; }
        public int dChangeRequestCount { get; set; }
        public string dIsRegistration { get; set; }
        public long dCurrentEventCcode { get; set; }
        public long dEventCodeDetails_indexID { get; set; }

        public int dRequestOrderSequence { get; set; }

        public string dExtra1 { get; set; }
        public string dExtra2 { get; set; }
        public string dExtra3 { get; set; }
        public string dExtra4 { get; set; }
        public string dRemarks_IfAny { get; set; }

        public int dIsActive { get; set; }
        public int dIsActiveProvider { get; set; }
        public int dIsDraft { get; set; }
        public int dIsDraftHelpDesk { get; set; }
        public int dIsDraftEvaluation { get; set; }
        public int dIsDraftSecMember { get; set; }
        public int dIsDraftMember { get; set; }


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

               
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }


        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceRegistrationProject_Input { get; set; }

        [Required]
        [Display(Name = "PUC Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceRegistrationPUC_Input { get; set; }

        [Required]
        [Display(Name = "Reference PUC Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceNumber_Input { get; set; }

        [Display(Name = "Reference PUC Date")]      
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReferenceNumberDate_Input { get; set; }

        [Required]
        [Display(Name = "Search By")]
        public int ReferenceNumberFlag_Input { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectPUCstatusDetails> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCstatusDetails()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCstatusDetails>();
        }

        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_AuthorityDesk_ProjectEvent_Master> prpEventMaster { get; set; }
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpchangerequestcategoryMaster { get; set; }
    }
}