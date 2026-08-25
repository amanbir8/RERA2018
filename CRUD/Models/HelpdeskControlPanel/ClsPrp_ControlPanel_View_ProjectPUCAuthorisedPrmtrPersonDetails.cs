using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrmtrPersonDetails
    {
        public long ProjectPUC_AuthorisedPrmtrPerson_IndexID { get; set; }
        public long ProjectPUC_AuthorisedPrmtrPerson_ID { get; set; }

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


        //Properties : Authorised Person (Promoter)
        public long PromoterRegistrationAdditional_IndexID { get; set; }
        public long PromoterRegistrationAdditional_ID { get; set; }

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

        //Properties : Reference Doc of Authorised Person (Promoter)
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

        //Properties [Start] : Authorised Person (Promoter)
        public Int64 Id { get; set; }
        public Int64 Application_id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string First_Name { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Middle_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Last_Name { get; set; }


        [Required]
        [Display(Name = "Father First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_First_Name { get; set; }
        [Display(Name = "Father Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_Middle_Name { get; set; }
        [Required]
        [Display(Name = "Father Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_Last_Name { get; set; }
        

        [Display(Name = "Name of Organization")]
        public string Org_Name { get; set; }
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }
        [Display(Name = "Main Objects of Organization")]
        public string Org_Objects { get; set; }
        

        [Display(Name = "Occupation")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Occupation { get; set; }

        //Office Address (Both Ind/OTI)
        [Required(ErrorMessage = "Official Address of Organization is required.")]
        [Display(Name = "Address Line 1")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line2 { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Int64 Pin_Code { get; set; }


        //Registered Address (Case OTI Only)
        [Required(ErrorMessage = "Registered Address of Organization is required.")]
        [Display(Name = "Address Line 1")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Org_Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [DataType(DataType.MultilineText)]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Org_Address_Line2 { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string Org_State { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public string Org_District { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Int64 Org_Pin_Code { get; set; }
  

        //Details of Authorised signatory, who will sign form B
        [Required(ErrorMessage = "Authorised Signatory's First Name is required.")]
        [Display(Name = "Authorised Signatory's First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string AuthorisedPerson_FirstName { get; set; }

        [Display(Name = "Authorised Signatory's Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string AuthorisedPerson_MiddleName { get; set; }

        [Required(ErrorMessage = "Authorised Signatory's Last Name is required.")]
        [Display(Name = "Authorised Signatory's Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string AuthorisedPerson_LastName { get; set; }


        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile No. of Authorised Signatory")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public Int64 Mobile_no { get; set; }

        [Display(Name = "Landline Number of Authorised Signatory")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number")]
        public Nullable<Int64> Phone_No { get; set; }

        [Display(Name = "STD Code")]
        public Nullable<Int64> Phone_No_STD { get; set; }

        [Required(ErrorMessage = "Email of Authorised Signatory is required.")]
        [Display(Name = "Email of Authorised Signatory")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "WebLink of Promoter/Parent Website ")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string WebLink_Promoter_website { get; set; }


        //Details of Promoter (When Ind: Ind PAN Number and Aadhaar Number /When OTI: Company PAN Number)
        [Required(ErrorMessage = "PAN Number is required.")]
        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string PAN_No { get; set; }

        [Display(Name = "Aadhaar Number of Promoter")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number of Promoter")]
        public Int64 Aadhaar { get; set; }


        //Flag Details of Promoter
        [Display(Name = "Past Experience(Y/N)?")]
        public string Experience { get; set; }

        [Display(Name = "Organization Members(Y/N)?")]
        public string IsOtherOrganizationMembers { get; set; }

        [Display(Name = "Number of Completed Projects in Last Five Years")]
        public Int32 Ind_Org_CompltdProj_FiveYrs { get; set; }

        [Display(Name = "Type of Promoter(Ind/OTI)")]
        public int Flag { get; set; }

        public string Last_FiveYr_Exp { get; set; }
        public string Ongoing_Exp { get; set; }

        [Display(Name = "Organization Parent Entity(Y/N)?")]
        public string Org_Parent_Entity { get; set; }

        public string IsLitigation_RelatedProject { get; set; }

        [Display(Name = "User ID")]
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }


        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modified_On { get; set; }
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


        public List<ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrmtrPersonDetails> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrmtrPersonDetails()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrmtrPersonDetails>();
        }
       
        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_StateMaster> prpstateMaster { get; set; }
        public List<ClsPrp_SubdivMaster> prpsubdivMaster { get; set; }
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpchangerequestcategoryMaster { get; set; }

    }
}