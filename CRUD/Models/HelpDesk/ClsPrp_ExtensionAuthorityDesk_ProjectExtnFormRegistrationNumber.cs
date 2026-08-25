using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber
    {
        public long Project_ExtnRegd_DiaryNumber_IndexID { get; set; }
        public long Project_ExtnRegd_DiaryNumber_ID { get; set; }
        public long RelatedProjectRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RelatedProjectRegDiaryNumber_Name { get; set; }
        public string RelatedProjectRegDiaryNumber_NameYear { get; set; }
        public long RelatedProjectRegDiaryNumber_tbl_IndexID { get; set; }
        public DateTime? RelatedProjectRegDiaryNumber_CreatedDate { get; set; }
        public long RelatedPromoter_ID { get; set; }
        public long RelatedProject_ID { get; set; }
        public string User_ID { get; set; }
        public long RelatedExtnRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RelatedExtnRegDiaryNumber_Name { get; set; }
        public string RelatedExtnRegDiaryNumber_NameYear { get; set; }
        public long RelatedExtnRegDiaryNumber_tbl_IndexID { get; set; }
        public DateTime? RelatedExtnRegDiaryNumber_CreatedDate { get; set; }

        public string IsAlreadyRegistration { get; set; }

        [Display(Name = "Existing RERA Registration Number (If Yes)")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ExistingRegistration { get; set; }


        public int PromoterType { get; set; }
        [Display(Name = "Promoter Name")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z().,&''-'-\s]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string PromoterName { get; set; }
        public string PromoterWebLink { get; set; }
        public string PromoterAuthSignFormB { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z().,&''-'-\s]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
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

        [Display(Name = "Project Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string ProjectWebLink { get; set; }

        [Required(ErrorMessage = "The Authorized Person's First Name field is required.")]
        [Display(Name = "Authorized Person First Name")]
        [StringLength(90)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string AuthorizedPerson_FirstName { get; set; }

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


        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ExtnRegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Extension of Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtnRegistrationIssueDate { get; set; }
        [Required]
        [Display(Name = "Extension of Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtnRegistrationRegUptoDate { get; set; }

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
        

        [Display(Name = "Project Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectApplicationDate { get; set; }
        [Display(Name = "Form-E Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectExtensionApplicationDate { get; set; }
                
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        
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

        public string ProjectRERAcert_FilePath { get; set; }
        public string ProjectRERAcert_FileName { get; set; }
        public string ProjectRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectRERAcert_IssueDate { get; set; }
        

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Extension Form Diary Number")]
        public string zipProjectExtnForm_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipProject_RERAregistrationNumber { get; set; }

        [Display(Name = "Diary Number")]
        public string zipCompletion_DiaryNumber { get; set; }

        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> prpongoing { get; set; }
        public ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber()
        {
            prpongoing = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber>();
        }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
    }
}