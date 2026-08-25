using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.classProjectExtensionPayment
{
    public class ClsPrp_ProjectExtensionPayment
    {
        public long ProjectPayment_IndexID { get; set; }
        public long ProjectPayment_ID { get; set; }

        [Display(Name = "Project Name")]
        public long ProjectPaymentRelated_ProjectRegistration_ID { get; set; }
        public long ProjectPaymentRelated_Promoter_ID { get; set; }

        public long Related_ProjectExtension_ID { get; set; }
        public int Related_ProjectExtension_SequenceID { get; set; }
        public int Related_ProjectExtension_Year { get; set; }

        [Display(Name = "Payment Type")]
        public int ProjectPayment_TitleCode { get; set; }

        [Display(Name = "Payment Type Title")]
        public string ProjectPayment_TitleName { get; set; }

        [Display(Name = "Fee Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal Registration_Fee { get; set; }

        [Display(Name = "Annual web-portal Convenience Fee (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal Other_Fee { get; set; }

        [Display(Name = "Payment Mode")]
        public string Payment_Mode { get; set; }

        [Display(Name = "Date of Payment for Registration Fees")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Payment_RegistrationFee { get; set; }

        [Display(Name = "Bank Charges (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal Bank_Charges { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Display(Name = "Branch Name")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Display(Name = "DD/Bankers Cheque Number")]
        public long DD_BankersCheque_Number { get; set; }

        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        public decimal DD_BankersCheque_Amount { get; set; }

        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FileName { get; set; }

        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FilePath { get; set; }

        [Display(Name = "Remarks (if Any)")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Branch Address")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_ProjectExtensionPayment> ProjectExtensionPayment { get; set; }
        public ClsPrp_ProjectExtensionPayment()
        {
            ProjectExtensionPayment = new List<ClsPrp_ProjectExtensionPayment>();
        }
    }
}