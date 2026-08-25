using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_JointPromoter_SearchOptionDetails
    {
        public long SearchOption_RelatedProjectID { get; set; }
        [Display(Name = "Project Name")]
        public string SearchOption_RelatedProjectName { get; set; }

        public long SearchOption_RelatedPromoterID { get; set; }
        [Display(Name = "Promoter Name")]
        public string SearchOption_RelatedPromoterName { get; set; }

        public long SearchOption_RelatedDistrictID { get; set; }
        [Display(Name = "District Name")]
        public string SearchOption_RelatedDistrictName { get; set; }

        [Display(Name = "Registration Number")]
        public string SearchOption_RelatedRegistrationNumber { get; set; }


        // Link and Mapping Parms - START
        [Display(Name = "Joint-Promoter Name")]
        public long mCoPromoter_ApplicationID { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public int mCoPromoterType_Flag { get; set; }
        [Display(Name = "Joint-Promoter Diary Number")]
        public string mCoPromoter_RegDiaryNumber_Name { get; set; }
        public long mCoPromoter_Reference_ID { get; set; }
        

        [Display(Name = "RERA Registration Number")]
        public string mLinkTo_Project_RegistrationNumber { get; set; }

        public long mLinkTo_Reference_ProjectID { get; set; }
        [Display(Name = "Project Name")]
        public string mLinkTo_Reference_ProjectName { get; set; }

        public long mLinkTo_Reference_PromoterID { get; set; }
        [Display(Name = "Promoter Name")]
        public string mLinkTo_Reference_PromoterName { get; set; }

        public long mLinkTo_Reference_DistrictID { get; set; }
        [Display(Name = "District Name")]
        public string mLinkTo_Reference_DistrictName { get; set; }
        // Link and Mapping Parms


        // CoPromoter Registration Parms - START
        public long CoPromoter_IndexID { get; set; }

        [Display(Name = "Joint-Promoter Name")]
        public long CoPromoter_ApplicationID { get; set; }

        [Required(ErrorMessage = "The Type of Joint-Promoter field is required.")]
        [Display(Name = "Type of Joint-Promoter")]
        public int CoPromoterType_Flag { get; set; }

        //OTI Case
        public string Org_Title { get; set; }
        [Required(ErrorMessage = "The name of organization field is required.")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        [Display(Name = "Name of Organization")]
        public string Org_Name { get; set; }
        [Required(ErrorMessage = "The type of organization field is required.")]
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "The main objects of organization field is required.")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        [Display(Name = "Main Objects of Organization")]
        public string OTI_Org_Objects { get; set; }

        //IND Case
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "The joint-promoter name field is required.")]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Joint-Promoter's Name")]
        public string First_Name { get; set; }
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Middle Name")]
        public string Middle_Name { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "The joint-promoter name field is required.")]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "The gender of the joint-promoter field is required.")]
        [Display(Name = "Gender")]
        public string Individual_Gender { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "The father's name field is required.")]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Father's Name")]
        public string Fath_First_Name { get; set; }
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Father's Middle Name")]
        public string Fath_Middle_Name { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "The father's name field is required.")]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Father's Last Name")]
        public string Fath_Last_Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "The main objects of promoter field is required.")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        [Display(Name = "Main Objects of Joint-Promoter")]
        public string Ind_Org_Objects { get; set; }

        //Registered Address
        [Required(ErrorMessage = "The address line 1 field is required.")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string Registered_Address_Org_Line1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string Registered_Address_Org_Line2 { get; set; }
        [Required(ErrorMessage = "The state field is required.")]
        [Display(Name = "State")]
        public int Registered_Address_Org_State { get; set; }
        [Required(ErrorMessage = "The district field is required.")]
        [Display(Name = "District")]
        public int Registered_Address_Org_District { get; set; }
        [Required(ErrorMessage = "The pin code field is required.")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string Registered_Address_Org_Pin_Code { get; set; }
        [Display(Name = "District & State")]
        public string Registered_Address_Org_DistrictState_Name { get; set; }

        //Permanent Address
        [Required(ErrorMessage = "The address line 1 field is required.")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string Permanent_Address_Prm_Line1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string Permanent_Address_Prm_Line2 { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "The state field is required.")]
        public int Permanent_Address_Prm_State { get; set; }
        [Display(Name = "District")]
        [Required(ErrorMessage = "The district field is required.")]
        public int Permanent_Address_Prm_District { get; set; }
        [Required(ErrorMessage = "The pin code field is required.")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string Permanent_Address_Prm_Pin_Code { get; set; }
        [Display(Name = "District & State")]
        public string Permanent_Address_Prm_DistrictState_Name { get; set; }

        //Communication Address
        [Required(ErrorMessage = "The Address Line 1 field is required.")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string Communication_AddressLine1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string Communication_AddressLine2 { get; set; }
        [Required(ErrorMessage = "The State field is required.")]
        [Display(Name = "District & State")]
        public int Communication_AddressStateCode { get; set; }
        [Required(ErrorMessage = "The District field is required.")]
        [Display(Name = "District")]
        public int Communication_AddressDistrictCode { get; set; }
        [Required(ErrorMessage = "The Pin Code field is required.")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string Communication_AddressPIN { get; set; }
        [Display(Name = "District & State")]
        public string Communication_Address_DistrictState_Name { get; set; }

        //Authorized Person details
        [Required(ErrorMessage = "The Authorized Person's Name field is required.")]
        [Display(Name = "Name of Authorised Signatory")]
        public string AuthorizedPerson_Name { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Mobile Number field is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        [Display(Name = "Mobile No. of Authorised Signatory")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        [Display(Name = "STD Code")]
        public long AuthorizedPerson_LandlineNumber_STD { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Landline Number field is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number")]
        [Display(Name = "Landline Number of Authorised Signatory")]
        public long AuthorizedPerson_LandlineNumber { get; set; }

        [Required(ErrorMessage = "The Authorized Person's Email field is required.")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [Display(Name = "Email of Authorised Signatory")]
        public string AuthorizedPerson_EmailAddress { get; set; }

        //Authorized Person Address
        [Required(ErrorMessage = "The Authorized Person Address field is required.")]
        [Display(Name = "Is Authorized Person Address (yes/no)?")]
        public int IsAuthorizedPersonAddress { get; set; }
        [Required(ErrorMessage = "Address Line 1 is required.")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }
        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public int AuthorizedPerson_AddressStateCode { get; set; }
        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public int AuthorizedPerson_AddressDistrictCode { get; set; }
        [Required(ErrorMessage = "Pin Code is required.")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }
        [Display(Name = "District & State")]
        public string AuthorizedPerson_AddressDistrictState_Name { get; set; }

        //Other Parms
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Joint-Promoter Occupation")]
        public string CoPromoter_Occupation { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        [Display(Name = "Joint-Promoter's WebLink")]
        public string CoPromoter_WebLink { get; set; }

        [Required(ErrorMessage = "The PAN Number field is required.")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        [Display(Name = "Joint-Promoter's PAN Number")]
        public string CoPromoter_PAN_Number { get; set; }

        [Required(ErrorMessage = "The Aadhaar Number field is required.")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number of Promoter")]
        [Display(Name = "Joint-Promoter's Aadhaar Number")]
        public long CoPromoter_Aadhaar_Number { get; set; }

        [Required(ErrorMessage = "The Experience of Joint-Promoter field is required.")]
        [Display(Name = "Experience of Joint-Promoter (Yes/No)?")]
        public string IsExperience { get; set; }
        [Range(0, 500)]
        [Display(Name = "Years of Experience of Joint-Promoter in Real Estate Development (in Years)")]
        public int Past_Experience_InYear { get; set; }
        [Required(ErrorMessage = "The Litigation related to Project of Joint-Promoter field is required.")]
        [Display(Name = "Litigation related to Project of Joint-Promoter (Yes/No)?")]
        public string IsLitigation_RelatedProject { get; set; }
        [Range(0, 500)]
        [Display(Name = "Number of Litigation related to Project of Joint-Promoter")]
        public int Past_Litigations_InNumber { get; set; }
        [Required(ErrorMessage = "The Organization Members of Joint-Promoter field is required.")]
        [Display(Name = "Organization Members of Promoter (Yes/No)?")]
        public string IsOrganizationMembers { get; set; }
        [Required(ErrorMessage = "The Parent Entity of Joint-Promoter field is required.")]
        [Display(Name = "Parent Entity of Promoter (Yes/No)?")]
        public string IsOrganizationParent_Entity { get; set; }

        [Display(Name = "Is upload photograph (yes/no)?")]
        public int IsUploadPhotograph { get; set; }
        [Display(Name = "Upload Photograph")]
        public string CoPromoterImage_FilePath { get; set; }
        [Display(Name = "Photograph")]
        public string CoPromoterImage_FileName { get; set; }

        //Related Reference ID
        //Dropdown value - Related_ProjectID - START
        public long Related_Project_ID { get; set; }
        public string Related_Used_ID { get; set; }
        public long Related_Promoter_Application_ID { get; set; }

        //Another Primary Promoter ID
        public long Link_RegDiaryNumber_ID { get; set; }
        [Required(ErrorMessage = "The Reference Diary Number field is required.")]
        [Display(Name = "Reference Diary Number, If Any")]
        [StringLength(90, MinimumLength = 11)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Link_RegDiaryNumber_Name { get; set; }
        public string Link_RegDiaryNumber_NameYear { get; set; }
        [Display(Name = "IND Image Yes/No")]
        public string Column_A { get; set; }
        [Display(Name = "Promoter ID (Primary Promoter-ApplicationID)")]
        public string Column_B { get; set; }
        //END

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string RemarksIfAny { get; set; }
        
        public string Column_C { get; set; }
        public string Column_D { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string Created_By { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_On { get; set; }
        public string Modify_By { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Modified_On { get; set; }
        // CoPromoter Registration Parms


        // CoPromoter DiaryNumber Parms - START
        public long nCoPromoter_RegDiaryNumber_IndexID { get; set; }
        public long nCoPromoter_RegDiaryNumber_ID { get; set; }

        [Display(Name = "Joint-Promoter Diary Number")]
        public string nCoPromoter_RegDiaryNumber_Name { get; set; }
        public string nCoPromoter_RegDiaryNumber_NameYear { get; set; }
        
        //Joint-Promoter ID
        public long nRelated_CoPromoter_ApplicationID { get; set; }
        public int nRelated_CoPromoterType_Flag { get; set; }
        public string nUserID { get; set; }

        //Related ID 
        public long nLinkTo_Related_Promoter_ID { get; set; }
        public long nLinkTo_Related_Project_ID { get; set; }
        public string nLinkTo_Related_RegistrationNumber { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string nExtra1 { get; set; }
        [Display(Name = "Project Diary Number")]
        public string nExtra2 { get; set; }

        //Another Primary Promoter ID
        public long nLinkTo_RegDiaryNumber_Promoter_ID { get; set; }
        public long nLinkTo_RegDiaryNumber_ID { get; set; }
        public string nLinkTo_RegDiaryNumber_Name { get; set; }
        public string nLinkTo_RegDiaryNumber_NameYear { get; set; }

        //extra
        public int nOrgMemberCount { get; set; }
        public int nParentEntityCount { get; set; }
        public int nLitigationsCount { get; set; }
        public int nDocumentsCount { get; set; }
        public int nPaymentDetailsCount { get; set; }
        public int nTrackRecordDetailsCount { get; set; }
        
        public string nExtra3 { get; set; }
        public string nRemarks_IfAny { get; set; }

        public int nIsActive { get; set; }
        public int nIsDraft { get; set; }
        public int nIsLock { get; set; }
        public int nIsDraftHelpDesk { get; set; }
        public int nIsDraftEvaluation { get; set; }
        public int nIsDraftSecMember { get; set; }
        public int nIsDraftMember { get; set; }

        public string nCreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? nCreatedOn { get; set; }
        public string nModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? nModifyOn { get; set; }
        // CoPromoter DiaryNumber Parms

        // Other Flag
        public int IsBriefSummaryDraft { get; set; }
        public int IsBriefSummaryLock { get; set; }
        public int IsDraftCoPromoters { get; set; }

        [Display(Name = "Name of Joint-Promoter")]
        public string JointPromoter_Name { get; set; }
        [Display(Name = "District of Joint-Promoter")]
        public string JointPromoter_District { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public string JointPromoter_Type { get; set; }


        public List<ClsPrp_JointPromoter_SearchOptionDetails> prpsearchpromoter { get; set; }
        public ClsPrp_JointPromoter_SearchOptionDetails()
        {
            prpsearchpromoter = new List<ClsPrp_JointPromoter_SearchOptionDetails>();
        }

        //public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
        public List<Promoter.ClsPrp_StateMaster> stateMaster { get; set; }
        public List<Promoter.ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}