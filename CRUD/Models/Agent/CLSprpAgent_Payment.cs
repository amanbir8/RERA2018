using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models.Master;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Agent
{
    public class CLSprpAgent_Payment
    {
        public long AgentPayment_IndexID { get; set; }
        public Nullable<long> AgentPayment_ID { get; set; }
        public Nullable<long> Agent_ID { get; set; }

        [Required]
        [Display(Name = "Payment Type")]
        public Nullable<int> AgentPayment_TitleCode { get; set; }

        [Required]
        [Display(Name = "Payment Type Title")]
        public string AgentPayment_TitleName { get; set; }

        [Required]
        [Display(Name = "Fee Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999.99)]
        public decimal Registration_Fee { get; set; }

        [Required]
        [Display(Name = "Composite web-portal Fee (in rupees)")] //"Annual web-portal Convenience Fee (in rupees)")]
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
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Required]
        [Display(Name = "DD/Bankers Cheque Number")]
        [Range(0, 999999999999999999, ErrorMessage = "Invalid Number; Maximum Length is 18")]
        public long DD_BankersCheque_Number { get; set; }

        [Required]
        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999.99)]
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
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        //Renewal Payment Linkage Flag
        public int Payment_StatusCode { get; set; }
        public string Payment_StatusName { get; set; }


        public List<CLSprpAgent_Payment> AgentPayment { get; set; }
        public CLSprpAgent_Payment()
        {
            AgentPayment = new List<CLSprpAgent_Payment>();
        }

        public List<ClsPrp_Master_BankDetails> BankMaster { get; set; }
        public List<ClsPrp_Master_PaymentType> PayFeeMaster { get; set; }
    }
}