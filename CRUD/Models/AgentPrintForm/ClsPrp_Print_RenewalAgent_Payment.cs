using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsPrp_Print_RenewalAgent_Payment
    {
        public long RenewalAgent_Payment_IndexID { get; set; }
        public long RenewalAgent_Payment_ID { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalOrderSequence { get; set; }
        public int Related_RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public DateTime? Related_RERAnumberIssueDate { get; set; }
        public DateTime? Related_RERAnumberRegUptoDate { get; set; }
        public long Related_Agent_Payment_ID { get; set; }

        [Required]
        [Display(Name = "Payment Type")]
        public Nullable<int> AgentPayment_TitleCode { get; set; }

        [Required]
        [Display(Name = "Payment Type Title")]
        public string AgentPayment_TitleName { get; set; }

        [Required]
        [Display(Name = "Fee Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0.01, 9999999.99)]
        public decimal Registration_Fee { get; set; }

        [Required]
        [Display(Name = "Other Fee (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999.99)]
        public decimal Other_Fee { get; set; }

        [Required]
        [Display(Name = "Payment Mode")]
        public string Payment_Mode { get; set; }

        [Required]
        [Display(Name = "Date of Payment for Registration Fees")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Payment_RegistrationFee { get; set; }

        [Required]
        [Display(Name = "Bank Charges (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999.99)]
        public Nullable<decimal> Bank_Charges { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        [RegularExpression(@"^[a-zA-Z''-',.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Required]
        [Display(Name = "DD/Bankers Cheque Number")]
        [Range(1, 999999999999999999, ErrorMessage = "Invalid Number; Maximum Length is 18")]
        public long DD_BankersCheque_Number { get; set; }

        [Required]
        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0.01, 9999999.99)]
        public decimal DD_BankersCheque_Amount { get; set; }

        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FileName { get; set; }

        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FilePath { get; set; }

        [Display(Name = "Remarks (if Any)")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public long zapRelated_Agent_ID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }
        [Display(Name = "Registration Number")]
        public string zapAgent_RegistrationNumber { get; set; }

        public List<ClsPrp_Print_RenewalAgent_Payment> AgentRenewalPayment { get; set; }
        public ClsPrp_Print_RenewalAgent_Payment()
        {
            AgentRenewalPayment = new List<ClsPrp_Print_RenewalAgent_Payment>();
        }

        public List<ClsPrp_Print_RenewalAgent_PaymentIntegration> AgentRenewalPaymentWithTranasactions { get; set; }
    }
}