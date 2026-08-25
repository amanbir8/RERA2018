using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Master;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_Payment
    {
        public long ProjectPayment_IndexID { get; set; }
        public long ProjectPayment_ID { get; set; }
       
        [Display(Name = "Project Name")]
        public long ProjectPaymentRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Payment Type")]
        public int ProjectPayment_TitleCode { get; set; }

        [Required]
        [Display(Name = "Payment Type Title")]
        public string ProjectPayment_TitleName { get; set; }

        [Required]
        [Display(Name = "Fee Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0.00, 999999999.99)]
        public decimal Registration_Fee { get; set; }

        [Required]
        [Display(Name = "Composite web-portal Fee (in rupees)")]//"Annual web-portal Convenience Fee (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0.00, 999999999.99)]
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
        [Range(0.00, 999999999.99)]
        public decimal Bank_Charges { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Required]
        [Display(Name = "DD/Bankers Cheque Number")]
        [Range(1, 999999999999999999, ErrorMessage = "Invalid Number; Maximum Length is 18")]
        public long DD_BankersCheque_Number { get; set; }

        [Required]
        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0.01, 999999999.99)]
        public decimal DD_BankersCheque_Amount { get; set; }

        public string ImageDDorBankersCheque_FileName { get; set; }
    
        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FilePath { get; set; }

        [Display(Name = "Remarks (if Any)")]
        public string Remarks_IfAny { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Branch Address")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string A_column { get; set; }

        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_Project_Payment> prpongoing { get; set; }
        public ClsPrp_Project_Payment()
        {
            prpongoing = new List<ClsPrp_Project_Payment>();

        }
        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }

        public List<ClsPrp_Master_BankDetails> BankMaster { get; set; }

        public List<ClsPrp_Master_PaymentType> PayFeeMaster { get; set; }
    }
}