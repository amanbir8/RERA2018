using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class Clsprp_AuthorityDesk_PromoterCoPromoterDetails
    {
        public long CoPromoter_IndexID { get; set; }
        public long CoPromoter_ApplicationID { get; set; }

        [Required(ErrorMessage = "The Type of Promoter field is required.")]
        [Display(Name = "Type of Promoter")]
        public int CoPromoterType_Flag { get; set; }

        [Display(Name = "Joint-Promoter's Name")]
        public string Org_Title { get; set; }
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        [Display(Name = "Name of Organization")]
        public string Org_Name { get; set; }
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        [Display(Name = "Main Objects of Organization")]
        public string OTI_Org_Objects { get; set; }

        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string Registered_Address_Org_Line1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string Registered_Address_Org_Line2 { get; set; }
        [Display(Name = "State")]
        public int Registered_Address_Org_State { get; set; }
        [Display(Name = "District")]
        public int Registered_Address_Org_District { get; set; }
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string Registered_Address_Org_Pin_Code { get; set; }
        [Display(Name = "District & State")]
        public string Registered_Address_Org_DistrictState_Name { get; set; }


        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Middle Name")]
        public string Middle_Name { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Gender")]
        public string Individual_Gender { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Father's First Name")]
        public string Fath_First_Name { get; set; }
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Father's Middle Name")]
        public string Fath_Middle_Name { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Father's Last Name")]
        public string Fath_Last_Name { get; set; }
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        [Display(Name = "Main Objects of Organization")]
        public string Ind_Org_Objects { get; set; }

        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string Permanent_Address_Prm_Line1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string Permanent_Address_Prm_Line2 { get; set; }
        [Display(Name = "State")]
        public int Permanent_Address_Prm_State { get; set; }
        [Display(Name = "District")]
        public int Permanent_Address_Prm_District { get; set; }
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string Permanent_Address_Prm_Pin_Code { get; set; }
        [Display(Name = "District & State")]
        public string Permanent_Address_Prm_DistrictState_Name { get; set; }

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

        [Required(ErrorMessage = "The Authorized Person Address field is required.")]
        [Display(Name = "Is Authorized Person Address (yes/no)?")]
        public int IsAuthorizedPersonAddress { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Address Line 2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }
        [Display(Name = "District & State")]
        public int AuthorizedPerson_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public int AuthorizedPerson_AddressDistrictCode { get; set; }
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        [Display(Name = "Pin Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }
        [Display(Name = "District & State")]
        public string AuthorizedPerson_AddressDistrictState_Name { get; set; }


        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        [Display(Name = "Joint-Promoter's Occupation")]
        public string CoPromoter_Occupation { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        [Display(Name = "Joint-Promoter's WebLink")]
        public string CoPromoter_WebLink { get; set; }

        [Required(ErrorMessage = "The PAN Number field is required.")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        [Display(Name = "Joint-Promoter's PAN Number")]
        public string CoPromoter_PAN_Number { get; set; }

        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number of Joint-Promoter")]
        [Display(Name = "Joint-Promoter's Aadhaar Number")]
        public long CoPromoter_Aadhaar_Number { get; set; }

        [Required(ErrorMessage = "The Experience of Joint-Promoter field is required.")]
        [Display(Name = "Experience of Joint-Promoter (yes/no)?")]
        public string IsExperience { get; set; }
        [Range(0, 500)]
        [Display(Name = "Years of Experience of Joint-Promoter in Real Estate Development")]
        public int Past_Experience_InYear { get; set; }
        [Required(ErrorMessage = "The Litigation related to Project of Joint-Promoter field is required.")]
        [Display(Name = "Litigation related to Project of Joint-Promoter (yes/no)?")]
        public string IsLitigation_RelatedProject { get; set; }
        [Range(0, 500)]
        [Display(Name = "Number of Litigation related to Project of Joint-Promoter")]
        public int Past_Litigations_InNumber { get; set; }
        [Required(ErrorMessage = "The Organization Members of Joint-Promoter field is required.")]
        [Display(Name = "Organization Members of Joint-Promoter (yes/no)?")]
        public string IsOrganizationMembers { get; set; }
        [Required(ErrorMessage = "The Parent Entity of Joint-Promoter field is required.")]
        [Display(Name = "Parent Entity of Joint-Promoter (yes/no)?")]
        public string IsOrganizationParent_Entity { get; set; }

        [Display(Name = "Is upload photograph (yes/no)?")]
        public int IsUploadPhotograph { get; set; }
        [Display(Name = "Upload Photograph")]
        public string CoPromoterImage_FilePath { get; set; }
        [Display(Name = "Photograph")]
        public string CoPromoterImage_FileName { get; set; }

        public long Related_Project_ID { get; set; }
        public string Related_Used_ID { get; set; }
        public long Related_Promoter_Application_ID { get; set; }

        public long Link_RegDiaryNumber_ID { get; set; }
        [Required(ErrorMessage = "The Reference Diary Number field is required.")]
        [Display(Name = "Reference Diary Number, If Any")]
        [StringLength(90, MinimumLength = 11)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Link_RegDiaryNumber_Name { get; set; }
        public string Link_RegDiaryNumber_NameYear { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string RemarksIfAny { get; set; }

        public string Column_A { get; set; }
        public string Column_B { get; set; }
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



        public long CoPromoter_RegDiaryNumber_IndexID { get; set; }
        public long CoPromoter_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Joint-Promoter's Diary Number")]
        public string CoPromoter_RegDiaryNumber_Name { get; set; }
        public string CoPromoter_RegDiaryNumber_NameYear { get; set; }
        public long Related_CoPromoter_ApplicationID { get; set; }
        public int Related_CoPromoterType_Flag { get; set; }
        public string UserID { get; set; }
        public long LinkTo_Related_Promoter_ID { get; set; }
        public long LinkTo_Related_Project_ID { get; set; }
        public string LinkTo_Related_RegistrationNumber { get; set; }
        public long LinkTo_RegDiaryNumber_Promoter_ID { get; set; }
        public long LinkTo_RegDiaryNumber_ID { get; set; }
        public string LinkTo_RegDiaryNumber_Name { get; set; }
        public string LinkTo_RegDiaryNumber_NameYear { get; set; }
        public int OrgMemberCount { get; set; }
        public int ParentEntityCount { get; set; }
        public int LitigationsCount { get; set; }
        public int DocumentsCount { get; set; }
        public int PaymentDetailsCount { get; set; }
        public int TrackRecordDetailsCount { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Remarks_IfAny { get; set; }

        public long Link_IndexID { get; set; }
        public long Link_ApplicationID { get; set; }
        public int IsBriefSummaryDraft { get; set; }
        public int IsBriefSummaryLock { get; set; }        

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }


        public int IsDraftCoPromoters { get; set; }

        public List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails> prpCoPromoters { get; set; }
        public Clsprp_AuthorityDesk_PromoterCoPromoterDetails()
        {
            prpCoPromoters = new List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails>();
        }
        public List<Promoter.ClsPrp_StateMaster> stateMaster { get; set; }
        public List<Promoter.ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<Clsprp_AuthorityDesk_PromoterDocuments> promoterDoc { get; set; }
    }
}