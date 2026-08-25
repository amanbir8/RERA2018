using CRUD.Models.Complaint;
using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ComplaintExecution
{
    public class ClsPrp_ExecutionApplication
    {
        public long ExecutionForm_IndexId { get; set; }
        public long ExecutionForm_ID { get; set; }
        public string ExecutionForm_Code { get; set; }
        public long Related_ComplaintFormMId { get; set; }
        public int Related_FormExe_SequenceID { get; set; }
        public int Related_FormExe_Year { get; set; }
        public long Profile_Id { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType { get; set; }

        public int IsComplaintComplete { get; set; }
        public int IsDocumentsComplete { get; set; }
        public int IsVerificationComplete { get; set; }
        public int IsPaymentComplete { get; set; }
        [Display(Name = "File Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ComplaintVerificationDate { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string Applicant_FirstName { get; set; }
        public string Applicant_MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string Applicant_LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Applicant_EmailAddress { get; set; }
        [Required(ErrorMessage = "AddressLine1 is required")]
        public string Applicant_AddressLine1 { get; set; }
        public string Applicant_AddressLine2 { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string Applicant_StateCode { get; set; }
        [Required(ErrorMessage = "District is required")]
        public string Applicant_AddressDistrictCode { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
        public string Applicant_AddressPin { get; set; }

        //[Required(ErrorMessage = "Complaint Number is required")]
        //public long? Complaint_Number { get; set; }
        [Required(ErrorMessage = "Complaint Number is required")]
        public string Complaint_Number { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string Complainant_FirstName { get; set; }
        public string Complainant_MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string Complainant_LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_EmailAddress { get; set; }
        [Required]
        [Display(Name = "Mobile Number of Complainant")]
        [RegularExpression(@"^(\+91)?[0-9]{10}$", ErrorMessage = "Invalid Mobile Number.")]
        public string Complainant_MobileNumber { get; set; }
        [Display(Name = "Landline Number or Fax Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public int? Complainant_LandlineFaxNumber { get; set; }
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
        [RegularExpression(@"^(\+91)?[0-9]{10}$", ErrorMessage = "Invalid Mobile Number.")]
        public long? AuthorizedRepresentativeCounsel_MobileNumber { get; set; }
        [Display(Name = "Landline Number or Fax Number of Authorized Representative/ Counsel")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? AuthorizedRepresentativeCounsel_LandlineFaxNumber { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        public string Respondent_FirstName { get; set; }
        public string Respondent_MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string Respondent_LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email ID of Respondent")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Respondent_EmailAddress { get; set; }
        [Required]
        [Display(Name = "Mobile Number of Respondent")]
        [RegularExpression(@"^(\+91)?[0-9]{10}$", ErrorMessage = "Invalid Mobile Number.")]
        public string Respondent_MobileNumber { get; set; }
        [Display(Name = "Landline Number or Fax Number of Respondent")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public int? Respondent_LandlineFaxNumber { get; set; }
        [Display(Name = "Aadhaar Number of Respondent")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public long? Respondent_AadhaarNumber { get; set; }
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





        [Required(ErrorMessage = "Date of Order is required")]
        [DataType(DataType.Date)]
        public DateTime? Date_of_Order { get; set; }
        [Required(ErrorMessage = "Bench Name is required")]
        public string Bench_Name { get; set; }
        [Required(ErrorMessage = "Compliance from date is required")]
        [DataType(DataType.Date)]
        public DateTime? Compliance_FromDate { get; set; }
        [Required(ErrorMessage = "Compliance to date is required")]
        [DataType(DataType.Date)]
        public DateTime? Compliance_ToDate { get; set; }
        [Required(ErrorMessage = "Appeal Information is required")]
        public string Appeal_Information { get; set; }
        [Required(ErrorMessage = "Payment Details is required")]
        public string Payment_AdjustmentDetails { get; set; }
        [Required(ErrorMessage = "Complainace Status is required")]
        public string Compliance_Status { get; set; }
        public string Compliance_Document { get; set; }
        [Required(ErrorMessage = "Previous Execution Details is required")]
        public string Previous_ExecutionDetails { get; set; }
        [Required]
        [Display(Name = "Principal amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0.01, 9999999.99)] public decimal? Principal_Amount { get; set; }
        [Required]
        [Display(Name = "Interest amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal? Interest_Amount { get; set; }
        [Required]
        [Display(Name = "Cost amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal? Cost_Amount { get; set; }
        [Required]
        [Display(Name = "Total amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal? Total_Amount { get; set; }
        [Required(ErrorMessage = "Mode of Assistance is required")]
        public string Mode_of_AssistanceRequired { get; set; }
        [Required(ErrorMessage = "Property Details is required")]
        public string Property_Details { get; set; }
        [Required(ErrorMessage = "Respondent’s Bank Account Details is required")]
        public string Respondent_BankDetails { get; set; }
        [Required(ErrorMessage = "Other Relevant Details is required")]
        public string Other_RelevantDetails { get; set; }
        [Required(ErrorMessage = "Declaration is required")]
        public Boolean Declaration_Signed { get; set; }

        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsPublicView { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifyBy { get; set; }


        public string Applicant_MobileNumber { get; set; }        

        public List<ClsPrp_ExecutionApplication> ExecutionFormstepI { get; set; }
        public List<ClsPrp_ExecutionApplication> ExecutionFormstepIPreFetch { get; set; }
        public ClsPrp_ExecutionApplication()
        {
            ExecutionFormstepI = new List<ClsPrp_ExecutionApplication>();
        }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        //public List<ClsPrp_Master_HearingBenchDetails> benchMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<ClsPrp_DistrictMaster> districtPunjabMaster { get; set; }
        public List<ClsPrp_SubdivMaster> SubdivMaster { get; set; }

        public List<ClsPrp_ComplaintProfile> Complainant_UserProfile { get; set; }
       // public List<ClsPrp_Master_HearingBenchDetails> prpongoing { get; set; }

    }
}