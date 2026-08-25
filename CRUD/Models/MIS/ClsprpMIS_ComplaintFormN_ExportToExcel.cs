using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsprpMIS_ComplaintFormN_ExportToExcel
    {
        [Display(Name = "Application Diary Number")]
        public string Application_Diary_Number { get; set; }

        [Display(Name = "Name of the Applicant")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string Applicant_Name { get; set; }

        [Display(Name = "Respondant's Name")]
        public string Respondant_Name { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string PG_Complainant_Email { get; set; }

        [Display(Name = "Mobile or Phone Number")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Complainant_Phone { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Payment_Success_Date { get; set; }

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

        [Display(Name = "Payment Type")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Payment_Type { get; set; }


        [Display(Name = "Transaction Fee (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Transaction_Fee { get; set; }


        [Display(Name = "Additional Charges (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Additional_Charges { get; set; }

        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount_INR { get; set; }


        public List<ClsprpMIS_ComplaintFormN_ExportToExcel> prpongoing { get; set; }
        public ClsprpMIS_ComplaintFormN_ExportToExcel()
        {
            prpongoing = new List<ClsprpMIS_ComplaintFormN_ExportToExcel>();
        }
    }
}
