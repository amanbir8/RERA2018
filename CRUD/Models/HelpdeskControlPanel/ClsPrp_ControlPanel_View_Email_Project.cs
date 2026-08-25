using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_Email_Project
    {
        public long AdditionalProjectEmail_IndexID { get; set; }
        public long AdditionalProjectEmail_ID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public string User_ID { get; set; }

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
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Required]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Display(Name = "Project Address District")]
        public string DName { get; set; }

        [Required]
        [Display(Name = "Type of Project")]
        public string ProjectType { get; set; }

        [Required]
        [Display(Name = "Contact Person/ Employee Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[()0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string AE_ContactName { get; set; }

        [Required]
        [Display(Name = "Designation, If Any")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string AE_Designation { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string AE_ReferenceName { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AE_ReferenceDate { get; set; }

        [Display(Name = "Type of Email")]
        public string AE_EmailType { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AE_EmailAddress { get; set; }

        [Display(Name = "Remarks If Any")]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string RemarksIfAny { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        [Display(Name = "Is Locked (Yes/No)?")]
        public int IsLock { get; set; }
        public int IsApproval { get; set; }
        [Display(Name = "Is Verified Number?")]
        public int IsVerified { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }

        public List<ClsPrp_ControlPanel_View_Email_Project> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_Email_Project()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_Email_Project>();
        }

        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
    }
}