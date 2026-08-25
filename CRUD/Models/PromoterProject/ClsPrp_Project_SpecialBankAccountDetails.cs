using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Master;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_SpecialBankAccountDetails
    {
        public long SpecialBankAccount_IndexID { get; set; }
        public long SpecialBankAccount_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long SpecialBankAccountRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Required]
        [Display(Name = "Bank Account Number")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Bank_AccountNumber { get; set; }

        [Required]
        [Display(Name = "Bank IFSC Code")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Bank_IFSC_Code { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Bank_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Bank_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public int Bank_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public int Bank_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string Bank_AddressPIN { get; set; }

        public string ImageCancelledCheque_FileName { get; set; }

        [Display(Name = "Cancelled Cheque")]
        public string ImageCancelledCheque_FilePath { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }

        [Required]
        [Display(Name = "Acount Holder Name")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string A_column { get; set; }

        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_Project_SpecialBankAccountDetails> prpongoing { get; set; }
        public ClsPrp_Project_SpecialBankAccountDetails()
        {
            prpongoing = new List<ClsPrp_Project_SpecialBankAccountDetails>();

        }

        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }

        public List<ClsPrp_Master_BankDetails> BankMaster { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}