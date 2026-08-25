using CRUD.Models.PromoterProject;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;


namespace CRUD.Controllers.AgentView
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentViewController : Controller
    {
        string UID;
        string UserNam;
        // GET: AgentView
        [HttpGet]
        public ActionResult AgentView()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            TempData["Agree"] = null;
            TempData["IsdraftValue"] = null;
            ClsMethodAgentView model = new ClsMethodAgentView();
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }


            TempData["AgentRegDiaryNumber_Name"] = "";




            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion

            //Check count in agent profile
            #region
            Int32 Profile = model.Profilecount(Application_ID);

            if (Profile == 0)
            {
                TempData["AgentProfile"] = "Complete";
                TempData["submitvalue"] = "Confirm Agent Profile";
                TempData.Keep();
            }
            else if (Profile == 1)
            {
                TempData["AgentProfile"] = "Complete";
                TempData["submitvalue"] = "Already Confirmed Agent Profile";
                TempData.Keep();
            }
            else
            {
                TempData["AgentProfile"] = "Pending";
                TempData["submitvalue"] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Other Member Detail
            #region
            Int32 OtherMemberDetail = model.OtherMemberDetail(Application_ID);

            if (OtherMemberDetail == 0)
            {
                TempData["OtherMemberDetail"] = "Complete";
                TempData["submitOtherMemeber"] = "Confirm Other Member Detail";
                TempData.Keep();
            }
            else if (OtherMemberDetail == 1)
            {
                TempData["OtherMemberDetail"] = "Complete";
                TempData["submitOtherMemeber"] = "Already Confirmed Other Member Detail";
                TempData.Keep();
            }
            else
            {
                TempData["OtherMemberDetail"] = "Pending";
                TempData["submitOtherMemeber"] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Document Upload
            #region
            Int32 DocumentUpload = model.DocumentUpload(Application_ID);

            if (DocumentUpload == 0)
            {
                TempData["DocumentUpload"] = "Complete";
                TempData["submitDocumentUpload"] = "Confirm Document Upload";
                TempData.Keep();
            }
            else if (DocumentUpload == 1)
            {
                TempData["DocumentUpload"] = "Complete";
                TempData["submitDocumentUpload"] = "Already Confirmed Document Upload";
                TempData.Keep();
            }
            else
            {
                TempData["DocumentUpload"] = "Pending";
                TempData["submitDocumentUpload"] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Other State
            #region
            Int32 OtherState = model.OtherState(Application_ID);

            if (OtherState == 0)
            {
                TempData["OtherState"] = "Complete";
                TempData["submitOtherState"] = "Confirm Other State Detail";
                TempData.Keep();
            }
            else if (OtherState == 1)
            {
                TempData["OtherState"] = "Complete";
                TempData["submitOtherState"] = "Already Confirmed Other State Detail";
                TempData.Keep();
            }
            else
            {
                TempData["OtherState"] = "Pending";
                TempData["submitOtherState"] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Payment Details
            #region
            Int32 PaymentDetails = model.PaymentDetails(Application_ID);

            if (PaymentDetails == 0)
            {
                TempData["PaymentDetails"] = "Complete";
                TempData["submitPaymentDetails"] = "Confirm Payment Details";
                TempData.Keep();
            }
            else if (PaymentDetails == 1)
            {
                TempData["PaymentDetails"] = "Complete";
                TempData["submitPaymentDetails"] = "Already Confirmed Payment Details";
                TempData.Keep();
            }
            else
            {
                TempData["PaymentDetails"] = "Pending";
                TempData["submitPaymentDetails"] = "Pending";
                TempData.Keep();
            }

            #endregion
            //Check agree detail
            #region 
            // Application_ID = 5026;
            Int32 var_agree = model.AgreeDetails(Application_ID);
            TempData["Agree"] = "Pending";
            if (var_agree == 1)//means record exists in all table , so Enable the agree button.
            {
                TempData["Agree"] = "Done";
                TempData.Keep();
            }
            #endregion
            return View();


            //TempData["submitvalue"] = "Confirm Agent Profile";
            //TempData["submitOtherMemeber"] = "Confirm Other Member Detail";
            //TempData["submitDocumentUpload"] = "Confirm Document Upload";
            //TempData["submitOtherState"] = "Confirm Other State Detail";
            //TempData["submitPaymentDetails"] = "Confirm Payment Details";
        }

        public void Get_Isdraftvalue_FromDiaryNumber()
        {
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                //else
                //{
                //    return RedirectToAction("OptionViewAgent", "Agent");
                //}
            }
            //else
            //{
            //    return RedirectToAction("SessionExpire", "Account");
            //}
            ClsMethodAgentView model = new ClsMethodAgentView();

            #region
            /// <summary>
            ///  Confirmation of  Agent Profile
            /// </summary>
            /// <returns></returns>


            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Application_ID);
            TempData["IsdraftValue"] = IsdraftValue;

            //return View("AgentView");
            //return RedirectToAction("AgentView");             
            #endregion

        }

        [HttpPost]
        public ActionResult AgentProfile()
        {
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodAgentView model = new ClsMethodAgentView();

            #region
            /// <summary>
            ///  Confirmation of  Agent Profile
            /// </summary>
            /// <returns></returns>

            if (TempData["AgentProfile"].ToString() == "Complete")
            {
                TempData.Keep();
                if (TempData["submitvalue"].ToString() == "Confirm Agent Profile")
                {
                    bool chkvalue = model.Update(Application_ID);
                    if (chkvalue)
                    {
                        TempData["message1"] = "Confirmed Successfully";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["message1"] = "Sorry,No record found! Please try again";
                        TempData.Keep();
                    }
                    //return View("AgentView");
                    return RedirectToAction("AgentView");
                }
            }

            return RedirectToAction("AgentView");
            // return View("AgentView");
            #endregion
        }

        [HttpPost]
        public ActionResult OtherMemberDetail()
        {
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodAgentView model = new ClsMethodAgentView();
            #region
            /// <summary>
            ///  Confirmation of Other Member Detail
            /// </summary>
            /// <returns></returns>
            string OtherMemberDetail = TempData["OtherMemberDetail"].ToString();
            TempData.Keep();
            if (OtherMemberDetail == "Complete")
            {
                string valueother = TempData["submitOtherMemeber"].ToString();
                TempData.Keep();

                if (valueother == "Confirm Other Member Detail")
                {
                    bool chkvalue = model.Updateother(Application_ID);
                    if (chkvalue)
                        TempData["message2"] = "Confirmed Successfully";
                    else
                        TempData["message2"] = "Sorry,No record found! Please try again";
                    // return View("AgentView");
                    return RedirectToAction("AgentView");
                }
            }

            // return View("AgentView");
            return RedirectToAction("AgentView");
            #endregion
        }

        [HttpPost]
        public ActionResult DocumentUpload()
        {
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodAgentView model = new ClsMethodAgentView();
            #region
            /// <summary>
            ///  Confirmation of Document Upload
            /// </summary>
            /// <returns></returns>
            // string DocumentUpload = TempData["DocumentUpload"].ToString();
            //TempData.Keep();

            if (TempData["DocumentUpload"].ToString() == "Complete")
            {
                //string valueDocumentUpload = TempData["submitDocumentUpload"].ToString();
                //TempData.Keep();
                if (TempData["submitDocumentUpload"].ToString() == "Confirm Document Upload")
                {
                    bool chkvalue = model.UpdateDocumentUpload(Application_ID);
                    if (chkvalue)
                        TempData["message3"] = "Confirmed Successfully";
                    else
                        TempData["message3"] = "Sorry,No record found! Please try again";
                    //return View("AgentView");
                    return RedirectToAction("AgentView");

                }
            }
            return RedirectToAction("AgentView");
            //return View("AgentView");
            #endregion
        }

        [HttpPost]
        public ActionResult OtherState()
        {
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodAgentView model = new ClsMethodAgentView();
            #region
            /// <summary>
            ///  Confirmation of OtherState
            /// </summary>
            /// <returns></returns>

            string valueOtherState = TempData["submitOtherState"].ToString();
            TempData.Keep();
            if (valueOtherState == "Confirm Other State Detail")
            {
                bool chkvalue = model.UpdateOtherState(Application_ID);
                if (chkvalue)
                    TempData["message4"] = "Confirmed Successfully";
                else
                    TempData["message4"] = "Sorry,No record found! Please try again";
                //return View("AgentView");
                return RedirectToAction("AgentView");
            }
            //return View("AgentView");
            return RedirectToAction("AgentView");
            #endregion


        }

        [HttpPost]
        public ActionResult PaymentDetails()
        {
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodAgentView model = new ClsMethodAgentView();
            #region
            /// <summary>
            ///  Confirmation of Payment Details
            /// </summary>
            /// <returns></returns>

            //////string valuePaymentDetails = TempData["submitPaymentDetails"].ToString();
            //////TempData.Keep();
            if (TempData["submitPaymentDetails"].ToString() == "Confirm Payment Details")
            {
                ////bool chkvalue = model.UpdatePaymentDetails(Application_ID);
                if (model.UpdatePaymentDetails(Application_ID))
                    TempData["message5"] = "Confirmed Successfully";
                else
                    TempData["message5"] = "Sorry,No record found! Please try again";
                //return View("AgentView");
                return RedirectToAction("AgentView");
            }
            //return View("AgentView");
            return RedirectToAction("AgentView");
            #endregion



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
        public async Task<ActionResult> Btn_Agree()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            //Int64 Application_ID = 5001;
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionViewAgent", "Agent");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodAgentView model = new ClsMethodAgentView();

            /// <summary>
            ///  i agreee click
            /// </summary>
            /// <returns></returns>


            #region

            string Profile = model.UpdateAgreeDetails(Application_ID, UID, UserNam);

            //if (Profile == 1)//means record exists in all table , so Enable the agree button.
            //{
            //    TempData["Agree"] = "Done";
            //    TempData.Keep();
            //}
            if (Profile != null)
            {
                TempData["AgentRegDiaryNumber_Name"] = "Your Application successfully Submitted with diary number : " + Profile + " keep it for future reference ";
                await UserManager.SendEmailAsync(UID, "RERA, Punjab - Application Submitted for Agent Registration", "<b>Dear " + UserNam + "</b>,<br /><br />Your application for registration of <b>Real Estate Agent</b> with Application ID <b>" + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />Applicants are advised to visit the web-portal (RERA, Punjab) regularly for updates. Kindly keep the hard copy of the application form along with the uploaded documents for future reference. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
            }
            else
            {
                TempData["AgentRegDiaryNumber_Name"] = "Sorry,Your Application is pending";
            }
            #endregion
            //return RedirectToAction("AgentView");
            return View("AgentView");

        }
    }
}