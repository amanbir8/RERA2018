using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCSpecialBankAccount
    {
        public long ProjectPUC_SpecialBankAccount_IndexID { get; set; }
        public long ProjectPUC_SpecialBankAccount_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        public long RelatedApplicationPUC_ID { get; set; }

        public string User_ID { get; set; }

        [Required]
        [Display(Name = "PUC Diary Number")]
        public string PUC_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        public string PUC_ReferencePUC_Name { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PUC_ReferencePUC_Date { get; set; }

        [Display(Name = "Change Request For")]
        public string PUC_RequestCategoryName { get; set; }

        [Display(Name = "Change Request For")]
        public long PUC_RequestCategoryID { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsExtensionRegistration { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? RERAnumberExtensionRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string ProjectDiaryNumber { get; set; }

        [Display(Name = "Extension of Registration Diary Number")]
        public string ExtensionRegdDiaryNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Required]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }
        
        [Display(Name = "Project Address District")]
        public string DName { get; set; }

        [Required]
        [Display(Name = "Type of Project")]
        public string ProjectType { get; set; }


        //Properties : Special Bank Account
        public long SpecialBankAccountAdditional_IndexID { get; set; }
        public long SpecialBankAccountAdditional_ID { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_FormDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ToDate { get; set; }
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ApprovedDate { get; set; }

        [Display(Name = "Is Annexure?")]
        public int IsConditionAnnexure { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }
        public int IsApproved { get; set; }
        public int IsMemberApproved { get; set; }

        //Properties [Start] : Special Bank Account
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
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
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

        [Display(Name = "Remarks, If Any")]
        public string Remarks_IfAny { get; set; }

        [Required]
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
        //Properties [End] : Special Bank Account

        public string mFlagPUC_YesNo { get; set; }
        public string mFlagPUC_OpenClosed { get; set; }
        public string mFlagPUC_ApprovedNotApproved { get; set; }

        public string mA_column { get; set; }
        public string mB_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceRegistrationProject_Input { get; set; }

        [Required]
        [Display(Name = "PUC Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceRegistrationPUC_Input { get; set; }

        [Required]
        [Display(Name = "Reference PUC Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceNumber_Input { get; set; }

        [Display(Name = "Reference PUC Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReferenceNumberDate_Input { get; set; }

        [Required]
        [Display(Name = "Search By")]
        public int ReferenceNumberFlag_Input { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        public long zipRelated_PUC_ID { get; set; }
        public long zipRelated_CategoryACR_ID { get; set; }
        public string zipRelated_CategoryACR_Name { get; set; }
        [Display(Name = "Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        [Display(Name = "PUC Diary Number")]
        public string zipReference_DiaryNumber { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipProjectRegistrationNumberName { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectPUCSpecialBankAccount> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCSpecialBankAccount()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCSpecialBankAccount>();
        }
       
        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_StateMaster> prpstateMaster { get; set; }
        public List<ClsPrp_Master_BankDetails> prpBankMaster { get; set; }
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpchangerequestcategoryMaster { get; set; }

    }
}