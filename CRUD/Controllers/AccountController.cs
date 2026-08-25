using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CRUD.Models;
using CaptchaMvc.HtmlHelpers;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Data.Entity.Validation;
using System.Security.Cryptography.X509Certificates;
using CRUD.Models.UserAccess;
using CaptchaMvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.Net.Http;

namespace CRUD.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        //ApplicationDbContext context;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/ResetConfirmEmail
        [AllowAnonymous]
        public ActionResult ResetConfirmEmail()
        {
            //ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            return View();
        }

        //
        // GET: /Account/SessionExpire
        [AllowAnonymous]
        public ActionResult SessionExpire()
        {
            //Session Abandon for LOGOUT - start
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            //Session Abandon for LOGOUT - end
            return View();
        }


        //
        // GET: /Account/Error Page 404
        [AllowAnonymous]
        public ActionResult Error404()
        {
            //Session Abandon for LOGOUT - start
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            //Session Abandon for LOGOUT - end
            return View();
        }


        //
        // GET: /Account/Register - UserName Remote Validator
        [AllowAnonymous]
        public JsonResult CheckUserName(string UserName)
        {
            ClsMethod_UserAccess.ClassMain objclsMain = new ClsMethod_UserAccess.ClassMain();
            bool isValid_UserName = objclsMain.AlreadyExistUserName(UserName);//false;// aadharcard.validateVerhoeff(Aadharid);
            if (!isValid_UserName)
            {
                return Json("Username already exist, Try another", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> Login(LoginRequest model)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7227/");

        //        var json = JsonConvert.SerializeObject(model);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await client.PostAsync("api/auth/login", content);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            ModelState.AddModelError("", "Invalid login");
        //            return View(model);
        //        }

        //        var result = await response.Content.ReadAsStringAsync();
        //        var apiResponse = JsonConvert.DeserializeObject<ApiLoginResponse>(result);
        //        Session["JWToken"] = apiResponse.Token;

        //        //-   return RedirectToAction("Dashboard");
        //    }

        //}

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
                var iv = Encoding.UTF8.GetBytes("8080808080808080");

                var encrypted = Convert.FromBase64String(model.Password);
                var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
                var password = string.Format(decriptedFromJavascript);
                var user = await UserManager.FindAsync(model.UserName, password);

                //var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    if (user.EmailConfirmed == true)
                    {
                        //return RedirectToLocal(returnUrl);
                        //return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error! Confirm Email Address.");
                        //return RedirectToLocal(returnUrl);
                        return RedirectToAction("ResetConfirmEmail");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }

                string varCapcha_input = model.Input_CaptchaText.ToString();
                string varCapcha = string.Empty;
                if (Session["ValueGateEntryCaptchaVerify"] != null)
                {
                    varCapcha = Session["ValueGateEntryCaptchaVerify"].ToString();
                }
                if (varCapcha.ToUpper() == varCapcha_input.ToString())
                {
                    //start: verification capcha text
                    Session["ValueGateEntryCaptchaVerify"] = null;

                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, change to shouldLockout: true

                    //var user = db.Users.Where(u => u.Email.Equals(model.Email)).Single(); // where db is ApplicationDbContext instance
                    //var result = await SignInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, shouldLockout: false);

                    //var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
                    var result = await SignInManager.PasswordSignInAsync(model.UserName, password, model.RememberMe, shouldLockout: false);

                    //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:

                            ClsPrp_UserAccessType objclsprpUA = new ClsPrp_UserAccessType();
                            ClsMethod_UserAccess.ClassMain objclsMain = new ClsMethod_UserAccess.ClassMain();

                            string UID = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
                            Int32 UserRoleNam = 0;// User.Identity.Name;

                            UserRoleNam = getUserRoleByUserID(UID);

                            try
                            {

                                objclsprpUA = objclsMain.DisplayUserAccess(UID, UserRoleNam);

                                Session["ApplicationId"] = objclsprpUA.Application_id;
                                Session["User_Id"] = objclsprpUA.User_id;
                                Session["User_Type"] = objclsprpUA.User_Type;
                                Session["User_ParentEntityFlag"] = objclsprpUA.User_ParentEntityFlag;
                                Session["User_TrackRecordFlag"] = objclsprpUA.User_TrackRecordFlag;
                                Session["Mobile_Number"] = user.PhoneNumber;// objclsprpUA.MobileNumber;
                                Session["Email_Address"] = user.Email; //objclsprpUA.EmailID;
                               // Session["U_ID"] = UID;  // added extra for my own login/logout event testing case --------------------------------------------
                            }
                            catch (Exception)
                            {
                                //ViewBag["messageException"] = ex.ToString();
                                Session["ApplicationId"] = null;
                                Session["User_Id"] = null;
                                Session["User_Type"] = null;
                                Session["User_ParentEntityFlag"] = null;
                                Session["User_TrackRecordFlag"] = null;
                                Session["Mobile_Number"] = null;
                                Session["Email_Address"] = null;
                            }
                            ActivityLogger.LogActivity(UID, UserRoleNam);
                            return RedirectToLocal(returnUrl);
                        case SignInStatus.LockedOut:
                            return View("Lockout");
                        case SignInStatus.RequiresVerification:

                            ClsPrp_UserAccessType objclsprpUAo = new ClsPrp_UserAccessType();
                            ClsMethod_UserAccess.ClassMain objclsMaino = new ClsMethod_UserAccess.ClassMain();

                            string UIDo = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
                            Int32 UserRoleNamo = 0;// User.Identity.Name;

                            UserRoleNamo = getUserRoleByUserID(UIDo);

                            try
                            {
                                objclsprpUA = objclsMaino.DisplayUserAccess(UIDo, UserRoleNamo);

                                Session["ApplicationId"] = objclsprpUA.Application_id;
                                Session["User_Id"] = objclsprpUA.User_id;
                                Session["User_Type"] = objclsprpUA.User_Type;
                                Session["User_ParentEntityFlag"] = objclsprpUA.User_ParentEntityFlag;
                                Session["User_TrackRecordFlag"] = objclsprpUA.User_TrackRecordFlag;
                                Session["Mobile_Number"] = user.PhoneNumber;// objclsprpUA.MobileNumber;
                                Session["Email_Address"] = user.Email; //objclsprpUA.EmailID;
                            }
                            catch (Exception)
                            {
                                //ViewBag["messageException"] = ex.ToString();
                                Session["ApplicationId"] = null;
                                Session["User_Id"] = null;
                                Session["User_Type"] = null;
                                Session["User_ParentEntityFlag"] = null;
                                Session["User_TrackRecordFlag"] = null;
                                Session["Mobile_Number"] = null;
                                Session["Email_Address"] = null;
                            }
                            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                        case SignInStatus.Failure:
                        default:
                            ModelState.AddModelError("", "Invalid login attempt.");
                            return View(model);
                    }
                    //end: verification capcha text
                }
                else
                {
                    varCapcha_input = string.Empty;
                    varCapcha = string.Empty;
                    ModelState.AddModelError("", "Error! Invalid Capcha Text.");
                    return View(model);
                }
            }
        }

        private int getUserRoleByUserID(string uid)
        {
            Int32 UserRoleNam = 1;

            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = userManager.GetRoles(uid);// User.Identity.GetUserId());

            switch (roles[0].ToString())
            {
                case "Promoter":
                    UserRoleNam = 9021;
                    break;
                case "RealEstateAgent":
                    UserRoleNam = 9022;
                    break;
                case "Complainant":
                    UserRoleNam = 9023;
                    break;
            }
            //if (System.Web.Security.Roles.IsUserInRole(User.Identity.Name, "Administrator"))
            //{

            //}          

            //if (User.IsInRole("RealEstateAgent"))//"5cab7404-0136-4e22-87ef-9cdaca6016e5", "RealEstateAgent"))
            //{
            //    UserRoleNam = 2;
            //}
            //else if (User.IsInRole("Promoter"))//"'19845cf7-c32d-4d4d-8f71-b19078b5bf6c', 'Promoter'"))
            //{
            //    UserRoleNam = 1;
            //}
            //else if (User.IsInRole("Complainant"))//"'53c2bc00-c000-4666-a30d-61b4151b5133', 'Complainant'"))
            //{
            //    UserRoleNam = 3;
            //}
            return UserRoleNam;
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            //ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                // When Capcha is Valid
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //Assign Role to user Here   
                        await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);

                        ////If Check and Login towards User ID and Password Authentication
                        ////await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        await UserManager.SendEmailAsync(user.Id, "RERA, Punjab - Account Activation Link", "<b>Dear " + model.UserName + "</b>,<br /><br /> Thank you for signing up with Punjab RERA. Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here (Activation Link)</a> <br /><br /><br />This link is valid for 24 hours. If you fail to click on this link within 24 hours, you would need to signup again. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");

                        //Ends Here
                        return RedirectToAction("ResetConfirmEmail", "Account");
                    }
                    AddErrors(result);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                // When Capcha is Valid
                if (ModelState.IsValid)
                {
                    string varUserName = model.UserName;

                    var user = await UserManager.FindByNameAsync(model.UserName);//model.Email
                    if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        return View("ForgotPasswordConfirmation");
                    }

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "RERA, Punjab - Password Reset Link", "<b>Dear " + User.Identity.Name + "</b>,<br /><br />As per your request, we have sent you the password reset link. Click on the following link to reset your password: <a href=\"" + callbackUrl + "\"> (Password Reset Link)</a>  <br /><br /> This link is valid for 24 hours.<br /><br /><b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = await UserManager.FindByNameAsync(model.UserName);//model.Email model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                AddErrors(result);
            }
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    //Session Abandon for LOGOUT - start
        //    Session.Clear();
        //    Session.RemoveAll();
        //    Session.Abandon();
        //    //Session Abandon for LOGOUT - end
        //    ActivityLogger.LogLogout(User.Identity.GetUserId());
        //    return RedirectToAction("Login", "Account");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var userId = User.Identity.GetUserId();

            if (!string.IsNullOrEmpty(userId))
            {
                ActivityLogger.LogLogout(userId);
            }

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //Session Abandon for LOGOUT - start
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            //Session Abandon for LOGOUT - end
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult FileView_webapplicationImageCpacha()
        {
            try
            {
                Bitmap objBitmap = new Bitmap(100, 38);
                Graphics objGraphics = Graphics.FromImage(objBitmap);
                objGraphics.Clear(Color.White);
                objGraphics.SmoothingMode = SmoothingMode.HighQuality;
                objGraphics.InterpolationMode = InterpolationMode.High;
                objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Random objRandom = new Random();
                objGraphics.DrawLine(Pens.Black, objRandom.Next(0, 50), objRandom.Next(10, 30), objRandom.Next(0, 200), objRandom.Next(0, 50));
                objGraphics.DrawRectangle(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(0, 20), objRandom.Next(50, 80), objRandom.Next(0, 20));
                objGraphics.DrawLine(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(10, 50), objRandom.Next(100, 200), objRandom.Next(0, 80));
                Brush objBrush =
                    default(Brush);
                //create background style  
                HatchStyle[] aHatchStyles = new HatchStyle[]
                {
                    HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical, HatchStyle.DashedHorizontal,
                    HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
                    HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
                };
                //create rectangular area  
                RectangleF oRectangleF = new RectangleF(0, 0, objBitmap.Width, objBitmap.Height); //(300, 300)
                objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.White);
                objGraphics.FillRectangle(objBrush, oRectangleF);
                //Generate the image for captcha  
                string captchaText = string.Format("{0:X}", objRandom.Next(1000000, 9999999));
                //add the captcha value in session  
                Session["ValueGateEntryCaptchaVerify"] = captchaText.ToLower();
                Font objFont = new Font("Courier New", 15, FontStyle.Bold);
                //Draw the image for captcha  
                objGraphics.DrawString(captchaText, objFont, Brushes.Black, 5, 10);

                MemoryStream stream = new MemoryStream();
                objBitmap.Save(stream, ImageFormat.Png);
                FileContentResult imageByteData = null;
                imageByteData = this.File(stream.GetBuffer(), "image/png");

                objBitmap.Dispose();
                objGraphics.Dispose();
                objBrush.Dispose();
                stream.Dispose();

                return File(imageByteData.FileContents, imageByteData.ContentType);
            }
            catch (Exception ex)
            {
                string varStr = ex.ToString();
                ex = null;
                MemoryStream stream = new MemoryStream();

                byte[] imageByteData = null;
                imageByteData = stream.ToArray();

                stream.Dispose();

                return File(imageByteData, "image/png");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult FileBase64_webapplicationImageCpacha()
        {
            try
            {
                Bitmap objBitmap = new Bitmap(100, 38);
                Graphics objGraphics = Graphics.FromImage(objBitmap);
                objGraphics.Clear(Color.White);
                objGraphics.SmoothingMode = SmoothingMode.HighQuality;
                objGraphics.InterpolationMode = InterpolationMode.High;
                objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Random objRandom = new Random();
                objGraphics.DrawLine(Pens.Black, objRandom.Next(0, 50), objRandom.Next(10, 30), objRandom.Next(0, 200), objRandom.Next(0, 50));
                objGraphics.DrawRectangle(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(0, 20), objRandom.Next(50, 80), objRandom.Next(0, 20));
                objGraphics.DrawLine(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(10, 50), objRandom.Next(100, 200), objRandom.Next(0, 80));
                Brush objBrush =
                    default(Brush);
                //create background style  
                HatchStyle[] aHatchStyles = new HatchStyle[]
                {
                    HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical,
                    HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
                    HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
                };
                //create rectangular area  
                RectangleF oRectangleF = new RectangleF(0, 0, objBitmap.Width, objBitmap.Height); //(300, 300)
                objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.White);
                objGraphics.FillRectangle(objBrush, oRectangleF);
                //Generate the image for captcha  
                string captchaText = string.Format("{0:X}", objRandom.Next(1000000, 9999999));
                //add the captcha value in session  
                Session["ValueGateEntryCaptchaVerify"] = captchaText.ToLower();
                Font objFont = new Font("Courier New", 15, FontStyle.Bold);
                //Draw the image for captcha  
                objGraphics.DrawString(captchaText, objFont, Brushes.Black, 5, 10);

                MemoryStream stream = new MemoryStream();
                objBitmap.Save(stream, ImageFormat.Png);
                byte[] imageByteData = null;
                imageByteData = stream.ToArray();
                string Base64String = "data:image/png;base64," + Convert.ToBase64String(imageByteData, 0, imageByteData.Length);

                objBitmap.Dispose();
                objGraphics.Dispose();
                objBrush.Dispose();
                stream.Dispose();

                return Content(Base64String);
            }
            catch (Exception ex)
            {
                string varStr = ex.ToString();
                ex = null;
                MemoryStream stream = new MemoryStream();
                byte[] imageByteData = null;
                imageByteData = stream.ToArray();
                string Base64String = "data:image/png;base64," + Convert.ToBase64String(imageByteData, 0, imageByteData.Length);
                stream.Dispose();
                return Content(Base64String);
            }
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("IndexDefault", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        #region Dex Code Pwd
        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.  
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold  
            // the decrypted text.  
            string plaintext = null;

            // Create an RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings  
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption.  
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream  
                                // and place them in a string.  
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }

        #endregion


        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult AutoLogout(string userId)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(userId))
        //        {
        //            ActivityLogger.LogLogout(userId);
        //        }
        //    }
        //    catch { }

        //    return new HttpStatusCodeResult(200);
        //}

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AutoLogout(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId) && User != null && User.Identity != null && User.Identity.IsAuthenticated)
                {
                    userId = User.Identity.GetUserId();
                }

                if (!string.IsNullOrEmpty(userId))
                {
                    ActivityLogger.LogLogout(userId);
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return new HttpStatusCodeResult(200);
        }


    }
}