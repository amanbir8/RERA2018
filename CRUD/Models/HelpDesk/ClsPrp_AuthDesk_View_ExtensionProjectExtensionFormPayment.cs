using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Master;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormPayment
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
        [Range(0.01, 9999999.99)]
        public decimal Registration_Fee { get; set; }

        [Display(Name = "Annual web-portal Convenience Fee (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999.99)]
        public decimal Other_Fee { get; set; }

        [Required]
        [Display(Name = "Payment Mode")]
        public string Payment_Mode { get; set; }

        [Required]
        [Display(Name = "Date of Payment for Extension Fees")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Payment_RegistrationFee { get; set; }

        [Display(Name = "Bank Charges (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999.99)]
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
        [Range(0.01, 9999999.99)]
        public decimal DD_BankersCheque_Amount { get; set; }

        public string ImageDDorBankersCheque_FileName { get; set; }
    
        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FilePath { get; set; }

        [Display(Name = "Remarks (if Any)")]
        public string Remarks_IfAny { get; set; }

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
        
        public int IsDraftAllpayments { get; set; }

        public long zipExtensionFormRelated_Promoter_ID { get; set; }
        public long zipExtensionFormRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipExtensionFormProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipExtensionFormProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipExtensionFormProjectLastModifiedOn { get; set; }




        public List<ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormPayment> prpongoing { get; set; }
        public ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormPayment()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormPayment>();

        }

        public List<ClsPrp_AuthDesk_View_ExtensionFormPaymentIntegration> ExtensionFormPaymentWithTranasactions { get; set; }

        public List<ClsPrp_Master_BankDetails> BankMaster { get; set; }
        public List<ClsPrp_Master_PaymentType> PayFeeMaster { get; set; }
        public List<Clsprp_AuthDesk_View_ProjectDocuments> ProjectDocumentsList { get; set; }
    }
}