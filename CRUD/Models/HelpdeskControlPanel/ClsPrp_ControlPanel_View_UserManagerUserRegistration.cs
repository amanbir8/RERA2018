using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_UserManagerUserRegistration
    {
        public long mUserManagerAuthority_IndexID { get; set; }
        public long mUserManagerAuthority_ID { get; set; }

        //A
        public string mrolesId { get; set; }

        [Display(Name = "Role Description")]
        public string mrolesName { get; set; }

        //B
        public string musersId { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string musersEmail { get; set; }

        [Display(Name = "Email Confirmed (Yes/No)?")]
        public int musersEmailConfirmed { get; set; }

        public string musersPasswordHash { get; set; }
        public string musersSecurityStamp { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone/Mobile Number")]
        public string musersPhoneNumber { get; set; }

        [Display(Name = "Phone Number Confirmed (Yes/No)?")]
        [Range(0, 1)]
        public int musersPhoneNumberConfirmed { get; set; }

        [Display(Name = "Two-Factor Authentication (Yes/No)?")]
        [Range(0, 1)]
        public int musersTwoFactorEnabled { get; set; }

        [Display(Name = "Locked Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? musersLockoutEndDateUtc { get; set; }

        [Display(Name = "Locked Enable?")]
        public int musersLockoutEnabled { get; set; }

        public int musersAccessFailedCount { get; set; }

        [Display(Name = "User Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string musersUserName { get; set; }

        //C
        [Display(Name = "User ID")]
        public string muserrolesUserId { get; set; }

        [Display(Name = "Role ID")]
        public string muserrolesRoleId { get; set; }

        public string mA_column { get; set; }
        public string mB_column { get; set; }

        public int mIsActive { get; set; }
        public int mIsDraft { get; set; }
        public string mCreatedBy { get; set; }
        public DateTime mCreatedOn { get; set; }
        public string mModifyBy { get; set; }
        public DateTime mModifyOn { get; set; }

        public string mRoleAccessFlag { get; set; }


        [Required]
        [Display(Name = "User Description")]
        public int InputEntry_UserTypeFlag { get; set; }
        [Required]
        [Display(Name = "Reference Type/ Mode")]
        public int InputEntry_ApplicationModeFlag { get; set; }
        [Required]
        [Display(Name = "Reference Type/ Mode")]
        public int InputEntry_ComplaintModeFlag { get; set; }
        [Required]
        [Display(Name = "Reference Number")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "Maximum length is 150")]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string InputEntry_ReferenceNumber { get; set; }


        public List<ClsPrp_ControlPanel_View_UserManagerUserRegistration> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_UserManagerUserRegistration()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_UserManagerUserRegistration>();
        }
    }
}