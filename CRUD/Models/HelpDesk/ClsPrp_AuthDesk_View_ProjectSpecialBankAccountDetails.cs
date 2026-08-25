using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails
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
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Bank_AccountNumber { get; set; }

        [Required]
        [Display(Name = "Bank IFSC Code")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
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
        public string Bank_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public string Bank_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string Bank_AddressPIN { get; set; }

        public string ImageCancelledCheque_FileName { get; set; }

        [Display(Name = "Cancelled Cheque")]
        public string ImageCancelledCheque_FilePath { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Account Holder Name")]
        public string A_column { get; set; }

        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        //Properties [ACR]: Special Bank Account
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_FormDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ToDate { get; set; }
        //Properties [ACR]: Special Bank Account

        //Properties [Verify]: Special Bank Account
        [Display(Name = "Diary Number")]
        public string prmProject_DiaryNumber { get; set; }
        [Display(Name = "Registration Number")]
        public string prmRERA_RegistrationNumber { get; set; }
        [Display(Name = "Project Name")]
        public string prmProject_Name { get; set; }

        [Display(Name = "Bank Account Number")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string prmSpecialBankAccountNumber_Input { get; set; }
        [Display(Name = "Bank IFSC Code")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string prmBankIFSCcode_Input { get; set; }
        [Display(Name = "Search Option")]
        public int prmSearchOption_Input { get; set; }
        [Display(Name = "Search For")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string prmPatternMatchBankAccountNumber_Input { get; set; }
        //Properties [Verify]: Special Bank Account


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }


        public List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> prpongoing { get; set; }
        public ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails>();

        }
        public List<Clsprp_AuthDesk_View_ProjectDocuments> ProjectDocumentsList { get; set; }

        //public List<ClsPrp_StateMaster> stateMaster { get; set; }
        //public List<ClsPrp_Project_Master> ProjectMaster { get; set; }

        //public List<ClsPrp_Master_BankDetails> BankMaster { get; set; }

        //public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}