using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber
    {

        public long ComplaintFormN_IndexID { get; set; }
        public long ComplaintFormN_ID { get; set; }
        public string ComplaintFormN_Code { get; set; }

        public long Profile_ID { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }

        public int IsComplaintComplete { get; set; }
        public int IsPaymentComplete { get; set; }
        public int IsDocumentsComplete { get; set; }

        public int IsVerificationComplete { get; set; }
        public DateTime ComplaintVerificationDate { get; set; }



        [Required]
        [Display(Name = "Name of Complainant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_EmailAddress { get; set; }

        [Required]
        [Display(Name = "Mobile Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? Complainant_LandlineFaxNumber { get; set; }

        [Display(Name = "Aadhaar Number of Complainant")]        
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public long? Complainant_AadhaarNumber { get; set; }



        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResComplainant_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Address State")]
        public Nullable<int> OfficeResComplainant_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "Address District")]
        public Nullable<int> OfficeResComplainant_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string OfficeResComplainant_AddressPIN { get; set; }

        

        public string IsOfficeResComplainantAddress_SameAsServiceNoticeAddress { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ServiceNoticesComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ServiceNoticesComplainant_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Address State")]
        public Nullable<int> ServiceNoticesComplainant_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "Address District")]
        public Nullable<int> ServiceNoticesComplainant_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string ServiceNoticesComplainant_AddressPIN { get; set; }



        [Display(Name = "Name of Authorized Representative/ Counsel")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedRepresentativeCounsel_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Authorized Representative/ Counsel")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedRepresentativeCounsel_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Authorized Representative/ Counsel")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? AuthorizedRepresentativeCounsel_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Authorized Representative/ Counsel")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? AuthorizedRepresentativeCounsel_LandlineFaxNumber { get; set; }



        [Required]
        [Display(Name = "Complaint Against")]
        public string RelatesComplaint_ComplaintAgainstType { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number of Project/ Agent to which the Complaint relates")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RelatesComplaint_ProjectAgent_RERA_RegNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name of the Real Estate Project/ Agent to which the Complaint relates")]
        [StringLength(450, ErrorMessage = "Maximum length is 450")]
        public string RelatesComplaint_ProjectAgent_Name { get; set; }

        
        [Required]
        [Display(Name = "Name of Respondent")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Respondent_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Respondent")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Respondent_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Respondent")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Respondent_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Respondent")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? Respondent_LandlineFaxNumber { get; set; }



        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResRespondent_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResRespondent_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Address State")]
        public Nullable<int> OfficeResRespondent_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "Address District")]
        public Nullable<int> OfficeResRespondent_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string OfficeResRespondent_AddressPIN { get; set; }



        public string IsOfficeResRespondentAddress_SameAsServiceNoticeAddress { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ServiceNoticesRespondent_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ServiceNoticesRespondent_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Address State")]
        public Nullable<int> ServiceNoticesRespondent_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "Address District")]
        public Nullable<int> ServiceNoticesRespondent_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string ServiceNoticesRespondent_AddressPIN { get; set; }
        


        [Required]
        [Display(Name = "Jurisdiction of the Real Estate Regulatory Authority, Punjab (Declaration)")]
        public string IsAgreeDeclaration_JurisdictionRERAPunjab { get; set; }



        [Required]
        [AllowHtml]
        [Display(Name = "Facts of Complaint [Mention a concise statement of facts and grounds for complaint.]")]
        [StringLength(21000, MinimumLength = 2)]
        public string FactsCase_Statement { get; set; }



        [Required]
        [AllowHtml]
        [Display(Name = "Relief(s) Sought")]
        [StringLength(6000, MinimumLength = 2)]        
        public string ReliefSought_Statement { get; set; }


        [Display(Name = "Total value of Flat/Plot/Apartment (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal? ReliefSought_TotalValueINR_FlatPlotApartment { get; set; }

        [Display(Name = "Total Amount paid till date (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal? ReliefSought_TotalAmountPaid_tilldateINR { get; set; }

        [Display(Name = "Date of possession as per agrreement for sale/allotment letter etc.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReliefSought_PossessionDate { get; set; }

        [Display(Name = "Actual date of possession, If delivered")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReliefSought_ActualPossessionDate_IfDelivered { get; set; }

        

        [Required]
        [AllowHtml]
        [Display(Name = "Pending final decision of the complaint the complainant seeks issue of the following interim order [Give here the nature of the interim order prayed for with reasons.]")]
        [StringLength(21000, MinimumLength = 2)]
        public string InterimOrderRelief_Statement { get; set; }

        [Required]
        [Display(Name = "Complaint not pending with any other Court, etc. or has not been decided by any other Court/ Authority, etc. (Declaration)")]
        public string IsAgreeDeclaration_ComplaintNotPendingCourtAuthority { get; set; }

        public string Remarks_IfAny { get; set; }

        [Display(Name = "Date of Allotment Letter")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? A_column { get; set; }

        [Display(Name = "Date of Agreement to Sale, If any")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? B_column { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Flat/ Apartment/ Plot Number (Booked with complete Address of associated property)")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        public string C_column { get; set; }

        public string D_column { get; set; }
        public string E_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public long zapRelated_Complaint_ID { get; set; }
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "RERA Number")]
        public string zapComplainantRERAnumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }


        public string OfficeResComplainant_AddressStateCodeName { get; set; }
        public string OfficeResComplainant_AddressDistrictCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressStateCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressDistrictCodeName { get; set; }
        public string OfficeResRespondent_AddressStateCodeName { get; set; }
        public string OfficeResRespondent_AddressDistrictCodeName { get; set; }
        public string ServiceNoticesRespondent_AddressStateCodeName { get; set; }
        public string ServiceNoticesRespondent_AddressDistrictCodeName { get; set; }


        public long yComplaintRegDiaryNumber_IndexID { get; set; }
        public long yComplaintRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string yComplaintRegDiaryNumber_Name { get; set; }
        public int yComplaintRegDiaryNumber_NameYear { get; set; }
        public long yFormN_RelatedComplaint_ID { get; set; }
        public string yFormN_RelatedComplaint_Code { get; set; }
        public long yProfile_ID { get; set; }
        public string yUser_ID { get; set; }
        public string yComplaintType_MN { get; set; }
        public int yIsComplaintComplete { get; set; }
        public int yIsPaymentComplete { get; set; }
        public string yPaymentTransactionID { get; set; }
        public DateTime? yPaymentTransactionDate { get; set; }
        public int yIsDocumentsComplete { get; set; }
        public int yDocumentUploadCount { get; set; }
        public int yIsVerificationComplete { get; set; }
        public DateTime? yComplaintVerificationDate { get; set; }
        public long yCurrentEventcode { get; set; }
        public long yEventCodeDetails_indexID { get; set; }
        public string yRemarks_IfAny { get; set; }
        public string yA_column { get; set; }
        public string yB_column { get; set; }
        public string yC_column { get; set; }
        public int yIsActive { get; set; }
        public int yIsDraft { get; set; }
        public int yIsLock { get; set; }
        public int yIsPublicView { get; set; }
        public int yIsDraftHelpDesk { get; set; }
        public int yIsDraftEvaluation { get; set; }
        public int yIsDraftSecMember { get; set; }
        public int yIsDraftMember { get; set; }
        public string yCreatedBy { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? yCreatedOn { get; set; }
        public string yModifyBy { get; set; }
        public DateTime? yModifyOn { get; set; }

        [Display(Name = "Name of Complainant")]
        public string yComplainant_Name { get; set; }
        [Display(Name = "Mobile Number of Complainant")]
        public long yComplainant_MobileNumber { get; set; }
        [Display(Name = "Complaint Against")]
        public string yRelatesComplaint_ComplaintAgainstType { get; set; }
        [Display(Name = "Name of Respondent")]
        public string yRespondent_Name { get; set; }

        public string yEventAction_Type { get; set; }
        public string yEventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? yEventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string yEventAction_Aggregate { get; set; }
        public DateTime? yTarget_ResolutionDate { get; set; }
        public string yEventRemarks_IfAny { get; set; }
        public string yEventAction_Summary { get; set; }


        public List<ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber> prpComplaintFormN { get; set; }
        public ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber()
        {
            prpComplaintFormN = new List<ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber>();
        }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }        
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }        
    }
}