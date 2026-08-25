using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsprpMIS_EpayComplaintFormM_ExportToExcel
    {
        public DateTime? PaymentSuccessDate { get; set; }
        public long? Complaint_ID { get; set; }
        public string Complaint_Type { get; set; }
        public string Complaint_Number { get; set; }
        public string Complainant_Name { get; set; }
        public string ComplaintAgainst_Code { get; set; }
        public string ComplaintAgainst_Name { get; set; }
        public long? ComplaintProject_ID { get; set; }
        public string ComplaintAdvocate_Code { get; set; }
        public string ComplaintAdvocate_Name { get; set; }

        public string RERAnumberRegistration { get; set; }
        public DateTime RERAnumberIssueDate { get; set; }
        public DateTime RERAnumberRegUptoDate { get; set; }

        public string PartyName { get; set; }
        public int PaymentReferenceID { get; set; }
        public string PaymentReferenceName { get; set; }

        public string BenchName { get; set; }
        public string BenchOrderNumber { get; set; }

        public decimal Payment_Amount { get; set; }
        public string Payment_AmountWords { get; set; }
        public DateTime Payment_FilingDate { get; set; }

        public string Payment_AccountHead { get; set; }
        public string Payment_AccountHead_Flag { get; set; }

        public string Bank_Name { get; set; }
        public decimal? Bank_Charges { get; set; }

        public string Payment_EmailAddress { get; set; }
        public long Payment_MobileNumber { get; set; }

        public string Remarks_IfAny { get; set; }
        public int Payment_IAgree { get; set; }

        public string Payment_Status { get; set; }
        public string Payment_ErrorMessage { get; set; }

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

        public List<ClsprpMIS_EpayComplaintFormM_ExportToExcel> prpongoing { get; set; }
        public ClsprpMIS_EpayComplaintFormM_ExportToExcel()
        {
            prpongoing = new List<ClsprpMIS_EpayComplaintFormM_ExportToExcel>();
        }
    }
}
