using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsprpMIS_AgentPayment
    {
        [Display(Name = "Real-Estate Agent's Diary Number")]
        public string Agent_Diary_Number { get; set; }

        [Display(Name = "Agent's Name")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RealEstate_Agent_Name { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Email { get; set; }

        [Display(Name = "Mobile or Phone Number")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Phone { get; set; }        

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Payment_Success_Date { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Payment Gateway ID")]
        public long? PG_PayU_ID { get; set; }

        [Display(Name = "Payment Description")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Payment_Description { get; set; }

        [Display(Name = "Transaction ID")]
        public string PG_Transaction_ID { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PG_Date { get; set; }

        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Status { get; set; }

        [Display(Name = "PRN")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_PaymentRef_Number { get; set; }

        ////public long PaymentRefNumberAgent_IndexID { get; set; }
        ////public long PaymentRefNumberAgent_ID { get; set; }
        ////public long RelatedAgent_ID { get; set; }
        ////public string RelatedAgent_Code { get; set; }
        ////public long RelatedPayment_ID { get; set; }
        ////public string User_ID { get; set; }

        ////public string AgentType_IO { get; set; }
        ////public string User_Name { get; set; }

        // public int IsPaymentSuccessComplete { get; set; }
        // public string FailureSuccessSummary { get; set; }

        //[Display(Name = "Customer Name")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_Customer_Name { get; set; }

        //[Display(Name = "Last Name")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string PG_Last_Name { get; set; }        

        //[Display(Name = "Customer IP Address")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_Customer_IP_Address { get; set; }

        //[Display(Name = "City")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_City { get; set; }

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

        //[Display(Name = "International Domestic")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_International_Domestic { get; set; }

        [Display(Name = "Payment Type")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Payment_Type { get; set; }

        //[Display(Name = "Error Code")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_Error_Code { get; set; }


        //[Display(Name = "Error Message")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_Error_Message { get; set; }

        //[Display(Name = "Name On Card")]
        //[StringLength(90, ErrorMessage = "Maximum length is 90")]
        //public string PG_Name_on_Card { get; set; }

        //[Display(Name = "Card Number")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_Card_Number { get; set; }

        //[Display(Name = "Address Line 1")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string PG_Address_Line1 { get; set; }

        //[Display(Name = "Address Line 2")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string PG_Address_Line2 { get; set; }

        //[Display(Name = "State")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_State { get; set; }

        //[Display(Name = "Country")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_Country { get; set; }

        //[Display(Name = "Zip Code")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_ZipCode { get; set; }        

        //[Display(Name = "Customer Name Last Name")]
        //[StringLength(90, ErrorMessage = "Maximum length is 90")]
        //public string Customer_Last_Name { get; set; }

        //[Display(Name = "Shipping Address Line 1")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string Customer__Address1 { get; set; }

        //[Display(Name = "Shipping Address Line 2")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string Customer__Address2 { get; set; }

        //[Display(Name = "Shipping City")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string Customer__City { get; set; }

        //[Display(Name = "Shipping State")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string Customer__State { get; set; }

        //[Display(Name = "Shipping Country")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string Customer__Country { get; set; }

        //[Display(Name = "Shipping Zip Code")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string Customer__Zipcode { get; set; }

        //[Display(Name = "Shipping Phone")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string Customer__Phone { get; set; }


        [Display(Name = "Transaction Fee (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Transaction_Fee { get; set; }

        //[Display(Name = "Discount (INR)")]
        //[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        //[Range(0, 9999999999999999.99)]
        //public decimal? PG_Discount { get; set; }

        [Display(Name = "Additional Charges (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Additional_Charges { get; set; }

        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount_INR { get; set; }

        //[Display(Name = "UDF 1")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_UDF_1 { get; set; }

        //[Display(Name = "UDF 2")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_UDF_2 { get; set; }

        //[Display(Name = "UDF 3")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_UDF_3 { get; set; }

        //[Display(Name = "UDF 4")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_UDF_4 { get; set; }

        //[Display(Name = "UDF 5")]
        //[StringLength(150, ErrorMessage = "Maximum length is 150")]
        //public string PG_UDF_5 { get; set; }

        //[Display(Name = "Device Info")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_Device_Info { get; set; }

        //[Display(Name = "Hash Key")]
        //[StringLength(350, ErrorMessage = "Maximum length is 350")]
        //public string PG_HashKey { get; set; }

        //[Display(Name = "Service Provider")]
        //[StringLength(50, ErrorMessage = "Maximum length is 50")]
        //public string PG_ServiceProvider { get; set; }

        //[Display(Name = "Remarks, If Any")]
        //[StringLength(350, ErrorMessage = "Maximum length is 350")]
        //public string Remarks_IfAny { get; set; }

        //public string A_column { get; set; }
        //public string B_column { get; set; }
        //public string C_column { get; set; }

        //public int IsActive { get; set; }
        //public int IsDraft { get; set; }
        //public int IsLock { get; set; }
        //public int IsPublicView { get; set; }

        //public string CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string ModifyBy { get; set; }
        //public DateTime ModifyOn { get; set; }        

        public List<ClsprpMIS_AgentPayment> prpongoing { get; set; }
        public ClsprpMIS_AgentPayment()
        {
            prpongoing = new List<ClsprpMIS_AgentPayment>();
        }
    }
}