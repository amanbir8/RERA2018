using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_MIS_ProjectRERAnumberDetails
    {
        public long Project_RERAnumber_DiaryNumber_IndexID { get; set; }
        public long Project_RERAnumber_DiaryNumber_ID { get; set; }

        public long ProjectRegDiaryNumber_ID { get; set; }
        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }

        public string ProjectRegDiaryNumber_NameYear { get; set; }
        public long ProjectRegDiaryNumber_tbl_IndexID { get; set; }
        public DateTime? ProjectRegDiaryNumber_CreatedDate { get; set; }

        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public string User_ID { get; set; }

        public long PromoterRegDiaryNumber_ID { get; set; }
        [Display(Name = "Promoter's Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }
        public string PromoterRegDiaryNumber_NameYear { get; set; }
        public long PromoterRegDiaryNumber_tbl_IndexID { get; set; }
        public DateTime? PromoterRegDiaryNumber_CreatedDate { get; set; }

        public long ProjectQuarterlyRegDiaryNumber_ID { get; set; }
        public string ProjectQuarterly_QuarterName { get; set; }
        public long ProjectQuarterly_QuarterYear { get; set; }
        public long ProjectQuarterlyRegDiaryNumber_tbl_IndexID { get; set; }
        public DateTime? ProjectQuarterly_CreatedDate { get; set; }

        public string IsAlreadyRegistration { get; set; }

        [Display(Name = "Existing RERA Registration Number (If Yes)")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ExistingRegistration { get; set; }

        public int PromoterType { get; set; }
        public string PromoterName { get; set; }
        public string PromoterWebLink { get; set; }
        public string PromoterAuthSignFormB { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Address Line1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string ProjectAddressLine1 { get; set; }

        [Display(Name = "Project Address Line2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string ProjectAddressLine2 { get; set; }

        [Required(ErrorMessage = "The Project Address District field is required.")]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Required(ErrorMessage = "The Project Address State field is required.")]
        [Display(Name = "Project Address State")]
        public string ProjectAddressState { get; set; }

        [Required(ErrorMessage = "The Project Address Sub-Division field is required.")]
        [Display(Name = "Project Address Sub-Division")]
        public string ProjectAddressSubDivision { get; set; }

        [Required]
        [Display(Name = "Project Address PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string ProjectAddressPIN { get; set; }

        [Required]
        [Display(Name = "Project Potential Zone")]
        public string ProjectPotentialZone { get; set; }

        [Required]
        [Display(Name = "Project Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string ProjectWebLink { get; set; }

        [Required(ErrorMessage = "The Authorized Person's First Name field is required.")]
        [Display(Name = "Authorized Person First Name")]
        [StringLength(90)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string AuthorizedPerson_FirstName { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Last Name field is required.")]
        [Display(Name = "Last Name")]
        [StringLength(90)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string AuthorizedPerson_LastName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedPerson_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedPerson_AddressLine2 { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Address District field is required.")]
        [Display(Name = "Address District")]
        public string AuthorizedPerson_District { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Address State field is required.")]
        [Display(Name = "Address State")]
        public string AuthorizedPerson_State { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string AuthorizedPerson_PIN { get; set; }

        [Required]
        [Display(Name = "Authorized Person Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AuthorizedPerson_Email { get; set; }

        [Required]
        [Display(Name = "Authorized Person Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string AuthorizedPerson_Mobile { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        [Required]
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        [Required]
        public int IsPublicView { get; set; }
        public int IsCertificateIssued { get; set; }
        public int IsExtensionIssued { get; set; }
        public int IsWithdrawn { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }


        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }


        public string ProjectRERAcert_FilePath { get; set; }
        public string ProjectRERAcert_FileName { get; set; }       
        public string ProjectRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectRERAcert_IssueDate { get; set; }

        //START - Search Parameters For MIS Report
        public String ApplicationDate { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_ToDate { get; set; }

        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        [Display(Name = "Search Option")]
        public string Application_SearchOptionFlag { get; set; }
        [Display(Name = "Range Option")]
        public string Application_SearchRangeFlag { get; set; }

        [Display(Name = "Type Option")]
        public string Application_SearchTypeFlag { get; set; }

        [Display(Name = "Month Option")]
        public string Application_SearchMonthFlag { get; set; }

        //END - Search Parameters For MIS Report

        public List<ClsPrp_MIS_ProjectRERAnumberDetails> prpongoing { get; set; }
        public ClsPrp_MIS_ProjectRERAnumberDetails()
        {
            prpongoing = new List<ClsPrp_MIS_ProjectRERAnumberDetails>();
        }
    }
}