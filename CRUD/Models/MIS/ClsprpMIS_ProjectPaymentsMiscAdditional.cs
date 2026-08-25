using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsprpMIS_ProjectPaymentsMiscAdditional
    {
        // Project General
        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }

        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Project Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectName { get; set; }

        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }

        [Display(Name = "Promoter's Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }

        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Promoter Type")]
        public string PromoterType { get; set; }


        //Project Payment Submission
        public long ProjectPaymentMiscFee_IndexID { get; set; }
        public long ProjectPaymentMiscFee_ID { get; set; }

        [Display(Name = "Project Name")]
        public long ProjectPaymentRelated_ProjectRegistration_ID { get; set; }
        public long ProjectPaymentRelated_Promoter_ID { get; set; }

        [Display(Name = "Payment Type")]
        public int ProjectPayment_TitleCode { get; set; }

        [Display(Name = "Payment Type Title")]
        public string ProjectPayment_TitleName { get; set; }

        public string RelatedRERAregNumber_Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RelatedRERAregNumber_ValidUptoDate { get; set; }

        [Display(Name = "Year of Payable Fee")]
        public int RelatedAnnualYear { get; set; }
        [Display(Name = "Session Year of Payable Fee")]
        public string RelatedSessionYear_Name { get; set; }

        [Display(Name = "Fee Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal Registration_Fee { get; set; }

        [Display(Name = "Annual web-portal Convenience Fee (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal Other_Fee { get; set; }

        [Display(Name = "Payment Mode")]
        public string Payment_Mode { get; set; }

        [Display(Name = "Date of Payment for Registration Fees")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Payment_RegistrationFee { get; set; }

        [Display(Name = "Bank Charges (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal Bank_Charges { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Display(Name = "Branch Name")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Display(Name = "DD/Bankers Cheque Number")]
        public long DD_BankersCheque_Number { get; set; }

        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal DD_BankersCheque_Amount { get; set; }

        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FileName { get; set; }

        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FilePath { get; set; }


        // Project PaymentGateway
        public long PaymentRefNumberMiscProjectPm_IndexID { get; set; }
        [Display(Name = "PRN")]
        public long PaymentRefNumberMiscProjectPm_ID { get; set; }

        public long RelatedProject_ID { get; set; }
        public long RelatedPromoter_ID { get; set; }
        public string RelatedProject_Code { get; set; }
        public string RelatedPromoter_Code { get; set; }

        public long RelatedPayment_ID { get; set; }
        public long RelatedPayment_IndexID { get; set; }

        [Display(Name = "Payment Type (Additional Fee)")]
        public string MiscFeeProject_Flag { get; set; }
        [Display(Name = "Payment Type Code")]
        public long MiscFeeProject_Code { get; set; }
        public string User_ID { get; set; }
            
        [Display(Name = "Project Potential Zone")]
        public string ProjectPmZoneType { get; set; }

        public string PromoterType_IO { get; set; }
        public string User_Name { get; set; }

        [Display(Name = "Status")]
        public string MiscFeeProject_BriefSummary { get; set; }
        public int IsPaymentSuccessComplete { get; set; }
        public DateTime PaymentSuccessDate { get; set; }
        public string FailureSuccessSummary { get; set; }

        [Display(Name = "Transaction ID")]
        public string PG_Transaction_ID { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PG_Date { get; set; }

        [Display(Name = "Payment Gateway ID")]
        public long? PG_PayU_ID { get; set; }

        [Required]
        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount { get; set; }

        [Display(Name = "Status")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Status { get; set; }

        [Required]
        [Display(Name = "Payment Information")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Product_Info { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Customer_Name { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Last_Name { get; set; }

        [Display(Name = "Customer Email")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Customer_Email { get; set; }

        [Display(Name = "Customer Mobile")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Customer_Phone { get; set; }

        [Display(Name = "Customer IP Address")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Customer_IP_Address { get; set; }

        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_City { get; set; }

        [Display(Name = "Merchant Name")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Merchant_Name { get; set; }

        [Display(Name = "Bank Name")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Bank_Name { get; set; }

        [Display(Name = "Payment Gateway")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Payment_Gateway { get; set; }

        [Display(Name = "Bank Reference Number")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Bank_Reference_No { get; set; }

        [Display(Name = "International Domestic")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_International_Domestic { get; set; }

        [Display(Name = "Payment Type")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Payment_Type { get; set; }

        [Display(Name = "Error Code")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Error_Code { get; set; }


        [Display(Name = "Error Message")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Error_Message { get; set; }

        [Display(Name = "Name On Card")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string PG_Name_on_Card { get; set; }

        [Display(Name = "Card Number")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Card_Number { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Address_Line2 { get; set; }

        [Display(Name = "State")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_State { get; set; }

        [Display(Name = "Country")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Country { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_ZipCode { get; set; }


        [Display(Name = "Shipping First Name")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string PG_Shipping_Firstname { get; set; }

        [Display(Name = "Shipping Last Name")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string PG_Shipping_Lastname { get; set; }

        [Display(Name = "Shipping Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Shipping_Address1 { get; set; }

        [Display(Name = "Shipping Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Shipping_Address2 { get; set; }

        [Display(Name = "Shipping City")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Shipping_City { get; set; }

        [Display(Name = "Shipping State")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Shipping_State { get; set; }

        [Display(Name = "Shipping Country")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Shipping_Country { get; set; }

        [Display(Name = "Shipping Zip Code")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Shipping_Zipcode { get; set; }

        [Display(Name = "Shipping Phone")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Shipping_Phone { get; set; }


        [Display(Name = "Transaction Fee (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Transaction_Fee { get; set; }

        [Display(Name = "Discount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal? PG_Discount { get; set; }

        [Display(Name = "Additional Charges (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Additional_Charges { get; set; }

        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount_INR { get; set; }

        [Display(Name = "UDF 1")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_UDF_1 { get; set; }

        [Display(Name = "UDF 2")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_UDF_2 { get; set; }

        [Display(Name = "UDF 3")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_UDF_3 { get; set; }

        [Display(Name = "UDF 4")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_UDF_4 { get; set; }

        [Display(Name = "UDF 5")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_UDF_5 { get; set; }

        [Display(Name = "Device Info")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Device_Info { get; set; }

        [Display(Name = "Hash Key")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        public string PG_HashKey { get; set; }

        [Display(Name = "Service Provider")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_ServiceProvider { get; set; }

        [Display(Name = "Remarks, If Any")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        // Payment Search Option
        [Display(Name = "Search Option")]
        public string Application_SearchOptionFlag { get; set; }
        [Display(Name = "Range Option")]
        public string Application_SearchRangeFlag { get; set; }
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


        public List<ClsprpMIS_ProjectPaymentsMiscAdditional> prpongoing { get; set; }
        public ClsprpMIS_ProjectPaymentsMiscAdditional()
        {
            prpongoing = new List<ClsprpMIS_ProjectPaymentsMiscAdditional>();
        }
    }
}