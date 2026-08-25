using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_UserManagerRegistration
    {
        public long UserManagerAuthority_IndexID { get; set; }
        public long UserManagerAuthority_ID { get; set; }

        //A
        public string rolesId { get; set; }

        [Required(ErrorMessage = "Role Description is required.")]
        [Display(Name = "Role Description")]
        public string rolesName { get; set; }

        //B
        public string usersId { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string usersEmail { get; set; }

        [Required(ErrorMessage = "Email Confirmed (Yes/No) is required.")]
        [Display(Name = "Email Confirmed (Yes/No)?")]
        public int usersEmailConfirmed { get; set; }

        public string usersPasswordHash { get; set; }
        public string usersSecurityStamp { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone/Mobile Number")]
        public string usersPhoneNumber { get; set; }

        [Required(ErrorMessage = "Phone Number Confirmed (Yes/No) is required.")]
        [Display(Name = "Phone Number Confirmed (Yes/No)?")]
        [Range(0, 1)]
        public int usersPhoneNumberConfirmed { get; set; }

        [Required(ErrorMessage = "Two-Factor Authentication (Yes/No) is required.")]
        [Display(Name = "Two-Factor Authentication (Yes/No)?")]
        [Range(0, 1)]
        public int usersTwoFactorEnabled { get; set; }

        [Required]
        [Display(Name = "Locked Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? usersLockoutEndDateUtc { get; set; }

        [Required(ErrorMessage = "Locked Enable (Yes/No) is required.")]
        [Display(Name = "Locked Enable?")]
        public int usersLockoutEnabled { get; set; }

        public int usersAccessFailedCount { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string usersUserName { get; set; }

        //C
        [Display(Name = "User ID")]
        public string userrolesUserId { get; set; }

        [Display(Name = "Role ID")]
        public string userrolesRoleId { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public string RoleAccessFlag { get; set; }

        [Required]
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }

        [Required]
        [Display(Name = "Employee ID/ Number")]
        [StringLength(25, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9]{1,25}$", ErrorMessage = "Special characters are not allowed. Maximum length is 25")]
        [System.Web.Mvc.Remote("CheckEmployeeNumber", "HelpdeskControlPanel", ErrorMessage = "Employee ID already exist, Try another")]
        public string Input_EmployeeProfileID { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(150, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Input_EmployeeName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_.@]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        [System.Web.Mvc.Remote("CheckUserName", "HelpdeskControlPanel", ErrorMessage = "Username already exist, Try another")]
        public string Input_UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Input_Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Input_Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Input_ConfirmPassword { get; set; }


        public List<ClsPrp_ControlPanel_View_UserManagerRegistration> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_UserManagerRegistration()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_UserManagerRegistration>();
        }
    }
}