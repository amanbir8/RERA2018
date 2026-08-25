using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using System.Web.Mvc;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintFormN_Registration
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
        [Display(Name = "Name of Applicant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ID of Applicant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_EmailAddress { get; set; }

        [Required]
        [Display(Name = "Mobile Number of Applicant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Applicant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? Complainant_LandlineFaxNumber { get; set; }

        [Display(Name = "Aadhaar Number of Applicant")]        
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
        [StringLength(90, MinimumLength = 17, ErrorMessage = "Invalid RERA Number or Invalid length of RERA Number.")]        
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

        [Required]
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
        [Display(Name = "Jurisdiction of the Adjudicating Officer (Declaration)")]
        public string IsAgreeDeclaration_JurisdictionRERAPunjab { get; set; }



        [Required]
        [AllowHtml]
        [Display(Name = "Facts of Case [Give a concise statement of facts and grounds of claim against the promoter.]")]
        [StringLength(21000, MinimumLength = 2)]
        public string FactsCase_Statement { get; set; }

        ////(Facts of the Case - Option)
        [Required]
        [Display(Name = "Facts of the Case [Text/PDF]")]
        public string FactsCase_OptionsYesNo { get; set; }

        //[Required]
        [Display(Name = "File Name")]
        public string FactsCase_FileName { get; set; }
        [Display(Name = "File Type")]
        public string FactsCase_FileType { get; set; }
        //[Required]
        [Display(Name = "Number of Pages")]
        public Int32 FactsCase_NumberOfPages { get; set; }
        [Display(Name = "File Size")]
        public string FactsCase_FileSize { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name = "Compensation(s) Sought")]
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

        public string InterimOrderRelief_Statement { get; set; }

        [Required]
        [Display(Name = "Claim not pending by any other Court, etc. or has not been decided by any other Court, etc. (Declaration)")]
        public string IsAgreeDeclaration_ComplaintNotPendingCourtAuthority { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Location of the Real Estate Project to which the complaint relates (Un-Registered Project)")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
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

        [Required]
        [Display(Name = "Registered Project/Un-Registered Project")]
        public string D_column { get; set; }

        // Start // Un-Registered Projects Column        
        [Display(Name = "Reference document(s) information of the Real Estate Project to which the complaint relates (Un-Registered Project)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [RegularExpression(@"^[0-9a-zA-Z''-'-.()\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string E_column { get; set; }

        [Display(Name = "CLU")]
        public string IsYes_columnCLU { get; set; }

        [Display(Name = "License to develop Colony")]
        public string IsYes_columnLTDC { get; set; }

        [Display(Name = "Regularization Certificate")]
        public string IsYes_columnRegCert { get; set; }

        [Display(Name = "District (Project Address)")]
        public string columnDistrictCode { get; set; }

        [Display(Name = "Sub-Division (Project Address)")]
        public string columnSubDivisionCode { get; set; }

        [Display(Name = "Extra Ref Doc(s)")]
        public string columnExtraReferenceNumber { get; set; }

        [Display(Name = "Agreement to Sell")]
        public string IsYes_columnAgreementSale { get; set; }

        [Display(Name = "Allotment Letter")]
        public string IsYes_columnAllotmentLetter { get; set; }

        [Display(Name = "LOI")]
        public string IsYes_columnLOI { get; set; }

        [Display(Name = "Column A Extra")]
        public string IsYes_columnExtraA { get; set; }
        // End // Un-Registered Projects Column

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public List<ClsPrp_ComplaintFormN_Registration> ComplaintFormNstepI { get; set; }
        public ClsPrp_ComplaintFormN_Registration()
        {
            ComplaintFormNstepI = new List<ClsPrp_ComplaintFormN_Registration>();
        }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }        
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<ClsPrp_DistrictMaster> districtPunjabMaster { get; set; }
        public List<ClsPrp_SubdivMaster> SubdivMaster { get; set; }

        public List<ClsPrp_ComplaintFormMN_Addmore_Complainant> Addtional_Complainant { get; set; }
        public List<ClsPrp_ComplaintFormMN_Addmore_Respondent> Addtional_Respondent { get; set; }

        public List<Clsprp_ComplaintFormN_FactsCaseDocument> FactsCase_Documents { get; set; }

        public List<ClsPrp_ComplaintProfile> Complainant_UserProfile { get; set; }
    }
}