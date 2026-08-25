using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Complaint;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsPrp_Print_Formexecution_Fee
    {

        public long PaymentComplaint_IndexID { get; set; }
        public long PaymentComplaint_ID { get; set; }
        public long PaymentComplaint_RelatedComplainant_ID { get; set; }
        public string PaymentComplaint_RelatedComplainant_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }

        public string ComplaintType_MN { get; set; }
        public string User_Name { get; set; }
        public string Complaint_BriefSummary { get; set; }
        public int IsPaymentSuccessComplete { get; set; }
        public DateTime PaymentSuccessDate { get; set; }
        public string FailureSuccessSummary { get; set; }       


        public string PG_Transaction_ID { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PG_Date { get; set; }

        public long? PG_PayU_ID { get; set; }

        [Display(Name = "Amount (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount { get; set; }

        [Display(Name = "Status")]        
        public string PG_Status { get; set; }

        [Display(Name = "Product Information")]        
        public string PG_Product_Info { get; set; }

        [Display(Name = "Customer Name")]        
        public string PG_Customer_Name { get; set; }

        [Display(Name = "Last Name")]        
        public string PG_Last_Name { get; set; }

        [Display(Name = "Customer Email")]        
        public string PG_Customer_Email { get; set; }

        [Display(Name = "Customer Mobile")]        
        public string PG_Customer_Phone { get; set; }

        [Display(Name = "Customer IP Address")]        
        public string PG_Customer_IP_Address { get; set; }

        [Display(Name = "City")]        
        public string PG_City { get; set; }

        [Display(Name = "Merchant Name")]        
        public string PG_Merchant_Name { get; set; }

        [Display(Name = "Bank Name")]        
        public string PG_Bank_Name { get; set; }

        [Display(Name = "Payment Gateway")]        
        public string PG_Payment_Gateway { get; set; }

        [Display(Name = "Bank Reference Number")]        
        public string PG_Bank_Reference_No { get; set; }

        [Display(Name = "International Domestic")]        
        public string PG_International_Domestic { get; set; }

        [Display(Name = "Payment Type")]        
        public string PG_Payment_Type { get; set; }

        [Display(Name = "Error Code")]        
        public string PG_Error_Code { get; set; }

        [Display(Name = "Error Message")]        
        public string PG_Error_Message { get; set; }

        [Display(Name = "Name On Card")]        
        public string PG_Name_on_Card { get; set; }

        [Display(Name = "Card Number")]        
        public string PG_Card_Number { get; set; }

        [Display(Name = "Address Line 1")]        
        public string PG_Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]        
        public string PG_Address_Line2 { get; set; }

        [Display(Name = "State")]        
        public string PG_State { get; set; }

        [Display(Name = "Country")]        
        public string PG_Country { get; set; }

        [Display(Name = "Zip Code")]        
        public string PG_ZipCode { get; set; }

        [Display(Name = "Shipping First Name")]        
        public string PG_Shipping_Firstname { get; set; }

        [Display(Name = "Shipping Last Name")]        
        public string PG_Shipping_Lastname { get; set; }

        [Display(Name = "Shipping Address Line 1")]        
        public string PG_Shipping_Address1 { get; set; }

        [Display(Name = "Shipping Address Line 2")]        
        public string PG_Shipping_Address2 { get; set; }

        [Display(Name = "Shipping City")]        
        public string PG_Shipping_City { get; set; }

        [Display(Name = "Shipping State")]        
        public string PG_Shipping_State { get; set; }

        [Display(Name = "Shipping Country")]        
        public string PG_Shipping_Country { get; set; }

        [Display(Name = "Shipping Zip Code")]        
        public string PG_Shipping_Zipcode { get; set; }

        [Display(Name = "Shipping Phone")]        
        public string PG_Shipping_Phone { get; set; }

        
        [Display(Name = "Transaction Fee (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal PG_Transaction_Fee { get; set; }

        [Display(Name = "Discount (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal? PG_Discount { get; set; }

        [Display(Name = "Additional Charges (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal PG_Additional_Charges { get; set; }

        [Display(Name = "Amount (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount_INR { get; set; }

        [Display(Name = "UDF 1")]        
        public string PG_UDF_1 { get; set; }

        [Display(Name = "UDF 2")]        
        public string PG_UDF_2 { get; set; }

        [Display(Name = "UDF 3")]        
        public string PG_UDF_3 { get; set; }

        [Display(Name = "UDF 4")]        
        public string PG_UDF_4 { get; set; }

        [Display(Name = "UDF 5")]        
        public string PG_UDF_5 { get; set; }

        [Display(Name = "Device Info")]        
        public string PG_Device_Info { get; set; }

        [Display(Name = "Hash Key")]        
        public string PG_HashKey { get; set; }

        [Display(Name = "Service Provider")]        
        public string PG_ServiceProvider { get; set; }

        [Display(Name = "Remarks, If Any")]        
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

        public List<ClsPrp_Print_Formexecution_Fee> prpComplaintFormexecution_Fee { get; set; }
        public ClsPrp_Print_Formexecution_Fee()
        {
            prpComplaintFormexecution_Fee = new List<ClsPrp_Print_Formexecution_Fee>();
        }        
    }
}