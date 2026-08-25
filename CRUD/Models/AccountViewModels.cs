using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]        
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        //[EmailAddress]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_ .@']{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "Captcha")]
        [StringLength(20, MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z0-9_ .@']{1,20}$", ErrorMessage = "Special characters are not allowed. Maximum length is 20")]
        public string Input_CaptchaText { get; set; }

        //public string ReturnUrl { get; set; }


    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_.@]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        [System.Web.Mvc.Remote("CheckUserName", "Account", ErrorMessage = "Username already exist, Try another")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]        
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_ .@']{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        //[EmailAddress]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_ .@']{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}
