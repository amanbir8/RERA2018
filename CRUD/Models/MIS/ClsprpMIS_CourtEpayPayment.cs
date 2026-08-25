using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsprpMIS_CourtEpayPayment
    {
        public long PaymentRegistration_ID { get; set; }
        public long Payment_epayTxnID { get; set; }
        public string Payment_epayTxnNumber { get; set; }
        public int Payment_epayTxnYear { get; set; }
        public string Payment_epayChallanNumber { get; set; }
        public string Payment_epayBankNumber { get; set; }

        public int IsTransaction { get; set; }
        public int IsChallan { get; set; }
        public int IsBankGateway { get; set; }
        public int IsVerified { get; set; }

        public DateTime TransactionDate { get; set; }
        public DateTime ChallanDate { get; set; }
        public DateTime BankGatewayDate { get; set; }
        public DateTime VerifiedDate { get; set; }

        public int Payment_GroupID { get; set; }
        public string Payment_GroupName { get; set; }
        public int PaymentForCode { get; set; }
        public string PaymentForName { get; set; }

        public string ReferenceChoiceCode { get; set; }
        public string ReferenceChoiceName { get; set; }
        public string ReferenceChoiceValue { get; set; }

        //public long? Project_ID { get; set; }
        //public long? Promoter_ID { get; set; }
        //public long? ExtensionProject_ID { get; set; }
        //public int? TypeOfProject { get; set; }
        //public string Project_Name { get; set; }
        //public string Promoter_Name { get; set; }

        //public int? ProjectAddress_DistrictCode { get; set; }
        //public string ProjectAddress_DistrictName { get; set; }

        //public long? Agent_ID { get; set; }
        //public long? RenewalAgent_ID { get; set; }
        //public string Agent_Name { get; set; }
        //public int? Agent_TypeID { get; set; }
        //public string Agent_TypeName { get; set; }
        //public int? AgentAddress_DistrictCode { get; set; }
        //public string AgentAddress_DistrictName { get; set; }

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

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }

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




        [Display(Name = "Payment Gateway ID")]
        public long? PG_PayU_ID { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PG_Date { get; set; }

        [Required]
        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal PG_Amount { get; set; }

        [Display(Name = "Status")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_Status { get; set; }

        [Display(Name = "PRN")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string PG_PaymentRef_Number { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Payment_Success_Date { get; set; }

        public string PG_Product_Info { get; set; }
        [Display(Name = "Transaction ID")]
        public string PG_Transaction_ID { get; set; }

        [Display(Name = "Merchant Name")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string PG_Merchant_Name { get; set; }

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

        public List<ClsprpMIS_CourtEpayPayment> prpongoing { get; set; }
        public ClsprpMIS_CourtEpayPayment()
        {
            prpongoing = new List<ClsprpMIS_CourtEpayPayment>();
        }
    }
}