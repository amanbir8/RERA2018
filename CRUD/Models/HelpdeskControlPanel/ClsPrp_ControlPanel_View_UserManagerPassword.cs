using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_UserManagerPassword
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

        [Display(Name = "Default Password?")]
        public int users_IsDefaultPassword { get; set; }

        [Required(ErrorMessage = "Default Password is required")]
        [Display(Name = "Default Password")]
        [DataType(DataType.Password)]
        public string users_Default_Password { get; set; }

        [Required(ErrorMessage = "Old Password is required")]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string users_Old_Password { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string users_New_Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("users_New_Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string users_Confirm_Password { get; set; }


        public List<ClsPrp_ControlPanel_View_UserManagerPassword> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_UserManagerPassword()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_UserManagerPassword>();
        }
    }
}