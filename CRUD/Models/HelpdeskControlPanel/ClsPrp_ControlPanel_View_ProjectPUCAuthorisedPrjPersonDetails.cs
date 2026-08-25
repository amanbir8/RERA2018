using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails
    {
        public long ProjectPUC_AuthorisedPrjPerson_IndexID { get; set; }
        public long ProjectPUC_AuthorisedPrjPerson_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        public long RelatedApplicationPUC_ID { get; set; }

        public string User_ID { get; set; }

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

        [Display(Name = "Change Request For")]
        public string PUC_RequestCategoryName { get; set; }

        [Display(Name = "Change Request For")]
        public long PUC_RequestCategoryID { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsExtensionRegistration { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? RERAnumberExtensionRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string ProjectDiaryNumber { get; set; }

        [Display(Name = "Extension of Registration Diary Number")]
        public string ExtensionRegdDiaryNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Required]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }
        
        [Display(Name = "Project Address District")]
        public string DName { get; set; }

        [Required]
        [Display(Name = "Type of Project")]
        public string ProjectType { get; set; }


        //Properties : Authorised Person (Project)
        public long ProjectRegistrationAdditional_IndexID { get; set; }
        public long ProjectRegistrationAdditional_ID { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_FormDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ToDate { get; set; }
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ApprovedDate { get; set; }

        [Display(Name = "Is Annexure?")]
        public int IsConditionAnnexure { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }
        public int IsApproved { get; set; }
        public int IsMemberApproved { get; set; }

        //Properties : Reference Doc of Authorised Person (Project)
        [Required]
        [Display(Name = "Reference Document Title")]               
        public string PUC_Doc_ReferenceTitle { get; set; }

        [Display(Name = "Reference Document Number")]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z ()&.,-/]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string PUC_Doc_ReferenceNumber { get; set; }

        [Required]
        [Display(Name = "Authorized Person PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string PUC_AuthorizedPerson_PAN_Number { get; set; }

        [Display(Name = "Authorized Person Aadhaar Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number")]
        public string PUC_AuthorizedPerson_Aadhaar_Number { get; set; }

        [Required]
        [Display(Name = "Reference Details, If Any")]
        [StringLength(200, MinimumLength = 4)]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[0-9a-zA-Z ()&.,-/]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string PUC_ReferenceDetailsIfAny { get; set; }

        //Properties [Start] : Authorised Person (Project)
        [Display(Name = "Project Registration Index ID")]
        public long ProjectRegistration_IndexID { get; set; }

        [Display(Name = "Project Registration ID")]
        public long ProjectRegistration_ID { get; set; }

        [Display(Name = "Project Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z ()&.,-/]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Project_Name { get; set; }

        //Project Facts
        [Required]
        [Display(Name = "Project Status")]
        public string Project_Status { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Project Start Date")]
        public DateTime? ProjectStart_Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Proposed/ Expected Date of Project Completion as specified in Form B")]
        public DateTime? ProjectCompletion_ProposedDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Original Date of Project Completion")]
        public DateTime? ProjectCompletion_OriginalDate { get; set; }

        [Required]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Duration for which Project Registration will be Provided")]
        public string ProjectRegistrationProvided_Duration { get; set; }

        [Display(Name = "Reason for Delay in Project if Any?")]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectDelayReason_IfAny { get; set; }        

        //Project Address
        [Required]
        [Display(Name = "Project Address Line1")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Project_AddressLine1 { get; set; }

        [Display(Name = "Project Address Line2")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Project_AddressLine2 { get; set; }

        [Required(ErrorMessage = "The Project Address State field is required.")]
        [Display(Name = "Project Address State Code")]
        public int Project_AddressStateCode { get; set; }

        [Required(ErrorMessage = "The Project Address District field is required.")]
        [Display(Name = "Project Address District Code")]
        public int Project_AddressDistrictCode { get; set; }

        [Required(ErrorMessage = "The Project Address Sub-Division field is required.")]
        [Display(Name = "Project AddressSub Division Code")]
        public int Project_AddressSubDivisionCode { get; set; }

        [Required]
        [Display(Name = "Project Address PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string Project_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Project Potential Zone")]
        public int Project_PotentialZoneCode { get; set; }

        [Required]
        [Display(Name = "Project Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string ProjectWebsite_WebLink { get; set; }

        //Project Authorised Person
        [Required(ErrorMessage = "The Authorized Person's First Name field is required.")]
        [Display(Name = "Authorized Person First Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorizedPerson_FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorizedPerson_MiddleName { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Last Name field is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorizedPerson_LastName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedPerson_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedPerson_AddressLine2 { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Address State field is required.")]
        [Display(Name = "Select Address State")]
        public int AuthorizedPerson_AddressStateCode { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Address District field is required.")]
        [Display(Name = "Select Address District")]
        public int AuthorizedPerson_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Authorized Person Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AuthorizedPerson_EmailAddress { get; set; }

        [Required]
        [Display(Name = "Authorized Person Mobile Phone")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        
        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        //Other - Project Facts
        [Required(ErrorMessage = "The proforma for Agreement of Sale (Yes/No) field is required.")]
        [Display(Name = "Is ProForma AOS RERA format AnnexureA")]
        public string IsProForma_AOS_RERAformat_AnnexureA { get; set; }

        [Display(Name = "Is ProForma AOS RERA format No IsApproved")]
        public string IsProForma_AOS_RERAformat_No_IsApproved { get; set; }

        [Required(ErrorMessage = "The Project falls under Mega Project category (Yes/No) field is required.")]
        [Display(Name = "Is Project Mega Project Category")]
        public string IsProject_MegaProjectCategory { get; set; }

        [Required(ErrorMessage = "The Any litigation(s) related to the Project (Yes/No) field is required.")]
        [Display(Name = "Is Litigation Related Project")]
        public string IsLitigation_RelatedProject { get; set; }

        [Required]
        [Display(Name = "Project Cost (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal A_column { get; set; }

        //Others
        [Required(ErrorMessage = "The any regularization certificate issued related to the project (Yes/No) field is required.")]
        [Display(Name = "Is Regularization Certificate Issued?")]
        public string IsYes_RegularizationCertificate { get; set; }

        [Display(Name = "Is Others (If Any)?")]
        public string IsYes_columnExtra { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Regularization certificate /document details which relates to the project")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [RegularExpression(@"^[0-9a-zA-Z''-'-.()\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string RegularizationCertificateInformation { get; set; }

        //Active
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }
        //Properties [End] : Authorised Person (Project)


        public string mFlagPUC_YesNo { get; set; }
        public string mFlagPUC_OpenClosed { get; set; }
        public string mFlagPUC_ApprovedNotApproved { get; set; }

        public string mA_column { get; set; }
        public string mB_column { get; set; }
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


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        public long zipRelated_PUC_ID { get; set; }
        public long zipRelated_CategoryACR_ID { get; set; }
        public string zipRelated_CategoryACR_Name { get; set; }
        [Display(Name = "Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        [Display(Name = "PUC Diary Number")]
        public string zipReference_DiaryNumber { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipProjectRegistrationNumberName { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails>();
        }
       
        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_StateMaster> prpstateMaster { get; set; }
        public List<ClsPrp_SubdivMaster> prpsubdivMaster { get; set; }
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpchangerequestcategoryMaster { get; set; }

    }
}