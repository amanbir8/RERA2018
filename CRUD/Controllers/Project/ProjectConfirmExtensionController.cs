using CRUD.Models.PromoterProject;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.IO;
using System.Web.Routing;

namespace CRUD.Controllers.Project
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class ProjectConfirmExtensionController : Controller
    {
        string UID;
        string UserNam;

        [HttpPost]
        public ActionResult DropdownlistProjectExtensionReviewConfirmDetails(FormCollection frm, ClsPrp_Project_MasterExtensionName smodel)
        {
            TempData["SelectedItem"] = frm["ProjectRegistration_ID"]; TempData.Keep();
            if (smodel.ProjectRegistration_ID != 0)
            {
                Session["Project_id"] = smodel.ProjectRegistration_ID;
            }
            else
            {
                Session["Project_id"] = null;
            }
            Session["url"] = Request.UrlReferrer;
            //return Redirect(Session["url"].ToString());
            return RedirectToAction("Create_ProjectExtentionReviewConfirmDetails", smodel);
        }

        [HttpGet]
        public ActionResult Create_ProjectExtentionReviewConfirmDetails()
        {
            Int64 Project_id = 0;
            ClsPrp_Project_MasterExtensionName smodel = new ClsPrp_Project_MasterExtensionName();
            ClsMethodProject objdis = new ClsMethodProject();

            ClsMethodProjectExtensionFormConfirm modelconfirm = new ClsMethodProjectExtensionFormConfirm();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProjectExtentionReviewConfirmDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());


            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId_ExtensionForm(PromoterApplicationId, 0);
            TempData.Keep();

            //TempData["statusFormEconfirm"] = "";
            //TempData["submitvalueFormEconfirm"] = "";
            //TempData["messageFormEconfirm"] = "";

            TempData["statusFormEpart1"] = ""; TempData["statusFormEpart2"] = "";
            TempData["submitvalueFormEpart1"] = ""; TempData["submitvalueFormEpart2"] = "";
            TempData["submitvalueFormEpartFLAG1"] = ""; TempData["submitvalueFormEpartFLAG2"] = "";
            TempData["messageFormEpart1"] = ""; TempData["messageFormEpart2"] = ""; 

            TempData["ProjectFormExtensionRegDiaryNumber_Name"] = "";
            TempData["AgreeFormEconfirm"] = "intialize";

            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;

            if ((Session["Project_id"] != null))
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectRegistration_ID = Project_id;

                //Check Isdraft value From Diary Number table                
                Get_ProjectExtensionFormE_Isdraftvalue_FromDiaryNumber(Project_id);               
                         
                //Check count in E-Form and Documents
                #region
                Int32 Documents = modelconfirm.ExtensionFormDocuments(Project_id);

                if (Documents == 0)
                {
                    TempData["statusFormEpart1"] = "Complete";
                    TempData["submitvalueFormEpart1"] = "Confirm Extension (Step-I) Details";
                    TempData["submitvalueFormEpartFLAG1"] = "ReviewConfirmPending";
                    TempData.Keep();
                }
                else if (Documents == 1)
                {
                    TempData["statusFormEpart1"] = "Complete";
                    TempData["submitvalueFormEpart1"] = "Extension Form Confirmed";
                    TempData["submitvalueFormEpartFLAG1"] = "ReviewConfirmComplete";
                    TempData.Keep();
                }
                else
                {
                    TempData["statusFormEpart1"] = "Pending";
                    TempData["submitvalueFormEpart1"] = "Pending (No Records Found)";
                    TempData["submitvalueFormEpartFLAG1"] = "ReviewConfirmZero";
                    TempData.Keep();
                }
                #endregion

                //Check count in Payment
                #region
                Int32 Payment = modelconfirm.ExtensionFormPayment(Project_id);

                if (Payment == 0)
                {
                    TempData["statusFormEpart2"] = "Complete";
                    TempData["submitvalueFormEpart2"] = "Confirm Payment (Step-II) Details";
                    TempData["submitvalueFormEpartFLAG2"] = "ReviewConfirmPending";
                    TempData.Keep();
                }
                else if (Payment == 1)
                {
                    TempData["statusFormEpart2"] = "Complete";
                    TempData["submitvalueFormEpart2"] = "Payment Confirmed";
                    TempData["submitvalueFormEpartFLAG2"] = "ReviewConfirmComplete";
                    TempData.Keep();
                }
                else
                {
                    TempData["statusFormEpart2"] = "Pending";
                    TempData["submitvalueFormEpart2"] = "Pending (No Records Found)";
                    TempData["submitvalueFormEpartFLAG2"] = "ReviewConfirmZero";
                    TempData.Keep();
                }
                #endregion

                //Check agree detail
                #region 

                Int32 var_agree = modelconfirm.ProjectExtensionFormAgreeDetails(Project_id);
                TempData["AgreeFormEconfirm"] = "Pending";
                //means record exists in all table , so Enable the agree button.
                if (var_agree == 1)
                {
                    TempData["AgreeFormEconfirm"] = "Done";
                    TempData.Keep();
                }
                #endregion
            }
            return View(smodel);
        }

        public void Get_ProjectExtensionFormE_Isdraftvalue_FromDiaryNumber(Int64 Project_id)
        {
            ClsMethodProjectExtensionFormConfirm modelconfirm = new ClsMethodProjectExtensionFormConfirm();
            Int32 IsdraftValue = modelconfirm.Isdraftvalue_ProjectExtensionForm_FromDiaryNumber(Project_id);
            TempData["ProjectExtensionFormIsdraftValue"] = IsdraftValue;
        }

        [HttpPost]
        public ActionResult ProjectExtentionFormAndDocuments()
        {
            Int64 Project_id = 0;
            if ((Session["Project_id"] != null))
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                TempData["SelectProject"] = Project_id;

                ClsMethodProjectExtensionFormConfirm modelobj = new ClsMethodProjectExtensionFormConfirm(); 
                bool chkvalue = modelobj.UpdateExtensionFormDocuments(Project_id);
                if (chkvalue)
                {
                    TempData["messageFormEpart1"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageFormEpart1"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("Create_ProjectExtentionReviewConfirmDetails");
        }

        [HttpPost]
        public ActionResult ProjectExtentionPayment()
        {
            Int64 Project_id = 0;
            if ((Session["Project_id"] != null))
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                TempData["SelectProject"] = Project_id;

                ClsMethodProjectExtensionFormConfirm modelobj = new ClsMethodProjectExtensionFormConfirm();              
                bool chkvalue = modelobj.UpdateExtensionFormPayment(Project_id);
                if (chkvalue)
                {
                    TempData["messageFormEpart2"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageFormEpart2"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("Create_ProjectExtentionReviewConfirmDetails");
        }
        
        private ApplicationUserManager _userManager;

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

        [HttpPost]
        public ActionResult BtnAgree_ProjectExtensionForm() //async Task<ActionResult> Btn_Agree()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            Int64 Project_id = 0;
            
            if (Session["Project_id"] != null)
            {
                //Get Project_id, year and quater after postback
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

                ClsMethodProjectExtensionFormConfirm modelobj = new ClsMethodProjectExtensionFormConfirm();

                #region
                Int64 PromoterApplicationId = 0;
                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                    }
                }

                string Profile = modelobj.UpdateProjectExtensionFormAgreeDetails(PromoterApplicationId, Project_id, UID, UserNam);

                if (Profile == "0")
                {
                    TempData["ProjectFormExtensionRegDiaryNumber_Name"] = "Invalid Request! Try Again.";
                }
                else if (Profile != null)
                {
                    TempData["ProjectFormExtensionRegDiaryNumber_Name"] = "Your Form-E/ Project Extension Application successfully submitted. Thanks with diary number : " + Profile + " keep it for future reference";
                    //await UserManager.SendEmailAsync(UID, "RERA, Punjab - Application Submitted for Project Registration", "<b>Dear " + UserNam + "</b>,<br /><br /> Your application for registration of project with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />Kindly submit the hard copy of the application form along with the uploaded documents within 7 days of submission of online application with RERA, Punjab. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                }
                else
                {
                    TempData["ProjectFormExtensionRegDiaryNumber_Name"] = "Sorry, Your Application is pending";
                }
                #endregion

                return View("Create_ProjectExtentionReviewConfirmDetails");
            }
            return View("Create_ProjectExtentionReviewConfirmDetails");
        }
    }
}