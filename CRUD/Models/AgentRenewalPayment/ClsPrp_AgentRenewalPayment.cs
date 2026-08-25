using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.classAgentRenewalPayment
{
    public class ClsPrp_AgentRenewalPayment
    {
        public long RenewalAgent_FeePayment_IndexID { get; set; }
        public long RenewalAgent_FeePayment_ID { get; set; }

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
        public long Related_AgentPayment_ID { get; set; }

        [Display(Name = "Payment Type")]
        public Nullable<int> AgentPayment_TitleCode { get; set; }

        [Display(Name = "Payment Type Title")]
        public string AgentPayment_TitleName { get; set; }

        [Display(Name = "Fee Amount (in rupees)")]
        public decimal Registration_Fee { get; set; }

        [Display(Name = "Annual web-portal Convenience Fee (in rupees)")]
        public decimal Other_Fee { get; set; }

        [Display(Name = "Payment Mode")]
        public string Payment_Mode { get; set; }

        [Display(Name = "Date of Payment for Registration Fees")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Payment_RegistrationFee { get; set; }

        [Display(Name = "Bank Charges (in rupees)")]
        public Nullable<decimal> Bank_Charges { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Display(Name = "Branch Name")]
        public string Branch_Name { get; set; }

        [Display(Name = "DD/Bankers Cheque Number")]
        public long DD_BankersCheque_Number { get; set; }

        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
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

        public List<ClsPrp_AgentRenewalPayment> AgentRenewalPayment { get; set; }
        public ClsPrp_AgentRenewalPayment()
        {
            AgentRenewalPayment = new List<ClsPrp_AgentRenewalPayment>();
        }
    }
}