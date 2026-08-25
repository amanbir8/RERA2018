using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectSpecialBankAccountDetails
    {
        public long SpecialBankAccount_IndexID { get; set; }
        public long SpecialBankAccount_ID { get; set; }

        [Display(Name = "Project Name")]
        public long SpecialBankAccountRelated_ProjectRegistration_ID { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Display(Name = "Branch Name")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Branch_Name { get; set; }

        [Display(Name = "Bank Account Number")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Bank_AccountNumber { get; set; }

        [Display(Name = "Bank IFSC Code")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Bank_IFSC_Code { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Bank_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Bank_AddressLine2 { get; set; }

        [Display(Name = "State")]
        public int Bank_AddressStateCode { get; set; }

        [Display(Name = "District")]
        public int Bank_AddressDistrictCode { get; set; }

        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string Bank_AddressPIN { get; set; }

        public string ImageCancelledCheque_FileName { get; set; }

        [Display(Name = "Cancelled Cheque")]
        public string ImageCancelledCheque_FilePath { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Acount Holder Name")]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string A_column { get; set; }

        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        //Additional : Special Bank Account  
        [Display(Name = "Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }        

        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

             
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }
        //Additional : Special Bank Account

        //Properties : Special Bank Account        
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_FormDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ToDate { get; set; }

        [Display(Name = "Is Annexure?")]
        public int IsConditionAnnexure { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }

        [Display(Name = "Is Registration/History?")]
        public string IsRegistrationHistory { get; set; }
        //Properties : Special Bank Account

        //Search : Special Bank Account        
        [Display(Name = "Search Option")]
        public string Application_SearchOptionFlag { get; set; }
        [Display(Name = "Search Option")]
        public string Application_SearchOptionDateFlag { get; set; }
        [Display(Name = "Range Option")]
        public string Application_SearchRangeFlag { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName_Input { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }
        //Search : Special Bank Account

        public List<ClsprpMIS_ProjectSpecialBankAccountDetails> prpongoing { get; set; }
        public ClsprpMIS_ProjectSpecialBankAccountDetails()
        {
            prpongoing = new List<ClsprpMIS_ProjectSpecialBankAccountDetails>();
        }

        public List<ClsPrp_Master_BankDetails> BankMaster { get; set; }
    }
}