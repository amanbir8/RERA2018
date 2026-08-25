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


namespace CRUD.Controllers.Project
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class ProjectConfirmController : Controller
    {
        string UID;
        string UserNam;
        [HttpGet]
        public ActionResult ProjectConfirm()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            //Int64 Application_ID = 10001;
            Int64 Project_id = 0;
            ClsPrp_Project_Master smodel = new ClsPrp_Project_Master();
            ClsMethodProject objdis = new ClsMethodProject();

            Int64 PromoterApplicationId = 0;            
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }         

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            TempData["status"] = ""; TempData["submitvalue"] = ""; TempData["message11"] = "";

            TempData["status1"] = ""; TempData["status2"] = ""; TempData["status3"] = ""; TempData["status4"] = ""; TempData["status5"] = ""; TempData["status6"] = "";
            TempData["status7"] = ""; TempData["status8"] = ""; TempData["status9"] = "";

            TempData["submitvalue1"] = ""; TempData["submitvalue2"] = ""; TempData["submitvalue3"] = ""; TempData["submitvalue4"] = ""; TempData["submitvalue5"] = ""; TempData["submitvalue6"] = "";
            TempData["submitvalue7"] = ""; TempData["submitvalue8"] = ""; TempData["submitvalue9"] = "";

            TempData["message1"] = ""; TempData["message2"] = ""; TempData["message3"] = ""; TempData["message4"] = ""; TempData["message5"] = ""; TempData["message6"] = "";
            TempData["message7"] = ""; TempData["message8"] = ""; TempData["message9"] = "";
            TempData["ProjectRegDiaryNumber_Name"] = "";
            TempData["ProjectlitigationViewFlag"] = "YES";

            if ((Session["Project_id"] == null))
            {
                TempData["Agree"] = "intialize";
                ////TempData["status"] = "Pending";
                ////TempData.Keep();
                ////TempData["submitvalue"] = "Select Project";
                ////TempData.Keep();
            }

            else
            {
                TempData["Agree"] = "intialize";
                //Check Isdraft value From Diary Number table
                #region
                Get_Isdraftvalue_FromDiaryNumber();
                #endregion
                //Check count in Promoter profile
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectRegistration_ID = Convert.ToInt32(Session["Project_id"].ToString());

                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();
                
                //Check count in project Registration
                #region
                Int32 Profile = model.projectReg(Project_id);

                //string submitvalue = "submitvalue";
                //string status = "projectReg";
                if (Profile == 0)
                {
                    TempData["status"] = "Complete";
                    TempData.Keep();
                    TempData["submitvalue"] = "Confirm Project Registration";
                    TempData.Keep();
                }
                else if (Profile == 1)
                {
                    TempData["status"] = "Complete";
                    TempData.Keep();
                    TempData["submitvalue"] = "Already Confirmed Project Registration";
                    TempData.Keep();
                }
                else
                {
                    TempData["status"] = "Pending";
                    TempData.Keep();
                    TempData["submitvalue"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in Other Litigations Detail
                #region
                Int32 litigations = model.Litigations(Project_id);

                //string submitvalue1 = "submitLitigations";
                //string status1 = "Litigations";

                if (litigations == 0)
                {
                    TempData["status1"] = "Complete";
                    TempData["submitvalue1"] = "Confirm Litigations Details";
                    TempData.Keep();
                }
                else if (litigations == 1)
                {
                    TempData["status1"] = "Complete";
                    TempData["submitvalue1"] = "Already Confirmed Litigations Detail";
                    TempData.Keep();
                }
                else
                {
                    TempData["status1"] = "Pending";
                    TempData["submitvalue1"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check ViewFlag Litigations Detail
                #region
                string litigationViewFlag = model.ProjectLitigationViewFlag(Project_id);
                TempData["ProjectlitigationViewFlag"] = litigationViewFlag;
                TempData.Keep();                
                #endregion

                //Check count in LandDetails
                #region
                Int32 LandDetails = model.LandDetails(Project_id);

                string submitvalue2 = "submitLandDetails";
                string status2 = "LandDetails";

                if (LandDetails == 0)
                {
                    TempData["status2"] = "Complete";
                    TempData["submitvalue2"] = "Confirm Land Details";
                    TempData.Keep();
                }
                else if (LandDetails == 1)
                {
                    TempData["status2"] = "Complete";
                    TempData["submitvalue2"] = "Already Confirmed Land Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status2"] = "Pending";
                    TempData["submitvalue2"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in ApprovalDetails
                #region
                Int32 ApprovalDetails = model.ApprovalDetails(Project_id);

                //string submitvalue3 = "submitApprovalDetails";
                //string status3 = "Approval";

                if (ApprovalDetails == 0)
                {
                    TempData["status3"] = "Complete";
                    TempData["submitvalue3"] = "Confirm Approval Details";
                    TempData.Keep();
                }
                else if (ApprovalDetails == 1)
                {
                    TempData["status3"] = "Complete";
                    TempData["submitvalue3"] = "Already Confirmed Approval Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status3"] = "Pending";
                    TempData["submitvalue3"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in Documents
                #region
                Int32 KhasraAreaDetails = model.KhasraAreaDetails(Project_id);

                //string submitvalue5 = "submitKhasraAreaDetails";
                //string status5 = "KhasraAreaDetails";

                if (KhasraAreaDetails == 0)
                {
                    TempData["status5"] = "Complete";
                    TempData["submitvalue5"] = "Confirm KhasraArea Detail";
                    TempData.Keep();
                }
                else if (KhasraAreaDetails == 1)
                {
                    TempData["status5"] = "Complete";
                    TempData["submitvalue5"] = "Already Confirmed KhasraArea Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status5"] = "Pending";
                    TempData["submitvalue5"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in Payment
                #region
                Int32 Payment = model.Payment(Project_id);

                string submitvalue6 = "submitPayment";
                string status6 = "Payment";

                if (Payment == 0)
                {
                    TempData["status6"] = "Complete";
                    TempData["submitvalue6"] = "Confirm Payment Detail";
                    TempData.Keep();
                }
                else if (Payment == 1)
                {
                    TempData["status6"] = "Complete";
                    TempData["submitvalue6"] = "Already Confirmed Payment Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status6"] = "Pending";
                    TempData["submitvalue6"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in SpecialBankAccountDetails
                #region
                Int32 SpecialBankAccountDetails = model.SpecialBankAccountDetails(Project_id);

                string submitvalue7 = "submitPayment";
                string status7 = "Payment";

                if (SpecialBankAccountDetails == 0)
                {
                    TempData["status7"] = "Complete";
                    TempData["submitvalue7"] = "Confirm SpecialBankAccount Details";
                    TempData.Keep();
                }
                else if (SpecialBankAccountDetails == 1)
                {
                    TempData["status7"] = "Complete";
                    TempData["submitvalue7"] = "Already Confirmed SpecialBankAccount Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status7"] = "Pending";
                    TempData["submitvalue7"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in Documents
                #region
                Int32 Documents = model.Documents(Project_id);

                //string submitvalue8 = "submitPayment";
                //string status8 = "Payment";

                if (Documents == 0)
                {
                    TempData["status8"] = "Complete";
                    TempData["submitvalue8"] = "Confirm Documents Detail";
                    TempData.Keep();
                }
                else if (Documents == 1)
                {
                    TempData["status8"] = "Complete";
                    TempData["submitvalue8"] = "Already Confirmed Documents Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status8"] = "Pending";
                    TempData["submitvalue8"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in Quater  tbl_RERA_Project_Quater_RegDiaryNumber
                #region
                Int32 Quater_Project = model.Method_Quater_Project(Project_id);

                //string submitvalue8 = "submitPayment";
                //string status8 = "Payment";

                if (Quater_Project == 0)
                {
                    TempData["status9"] = "Complete";
                    TempData["submitvalue9"] = "View Quaterly Update Details";
                    TempData.Keep();
                }
                else if (Quater_Project == 1)
                {
                    TempData["status9"] = "Complete";
                    TempData["submitvalue9"] = "View Quaterly Project Update Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status9"] = "Pending";
                    TempData["submitvalue9"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check agree detail
                #region 

                Int32 var_agree = model.ProjectAgreeDetails(Project_id);
                TempData["Agree"] = "Pending";
                if (var_agree == 1)//means record exists in all table , so Enable the agree button.
                {
                    TempData["Agree"] = "Done";
                    TempData.Keep();
                }
                #endregion


            }
            return View(smodel);
        }
        public void Get_Isdraftvalue_FromDiaryNumber()
        {
            Int64 Project_id=0;
            Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Agent Profile
            /// </summary>
            /// <returns></returns>


            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Project_id);
            TempData["IsdraftValue"] = IsdraftValue;

            //return View("AgentView");
            //return RedirectToAction("AgentView");




            #endregion

        }
        [HttpPost]
        public ActionResult ProjectRegistration()
        {
            Int64 Project_id = 10001;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            { 
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();
                TempData["SelectProject"] = Project_id;
                #region
                /// <summary>
                ///  Confirmation of  Project Profile
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateRegistration(Project_id);
                if (chkvalue)
                {
                    TempData["message11"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message11"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("ProjectConfirm");
            // return RedirectToAction("ProjectConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult Litigations()
        {

            Int64 Project_id = 0;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();
                TempData["SelectProject"] = Project_id;
                #region
                /// <summary>
                ///  Confirmation of  Litigations 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateLitigations(Project_id);
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
                
            }
            return View("ProjectConfirm");
            #endregion
        }

        [HttpPost]
        public ActionResult Land()
        {
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();
                TempData["SelectProject"] = Project_id;
                #region
                /// <summary>
                ///  Confirmation of  Land 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateLandDetails(Project_id);
                if (chkvalue)
                {
                    TempData["message2"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message2"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
                //return View("AgentView");
            }
            return View("ProjectConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult Approval()
        {
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();
                TempData["SelectProject"] = Project_id;
                #region
                /// <summary>
                ///  Confirmation of  Land 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateApprovalDetails(Project_id);
                if (chkvalue)
                {
                    TempData["message3"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message3"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("ProjectConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult KhasraAreaDetails()
        {
             
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                TempData["SelectProject"] = Project_id;
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();

                #region
                /// <summary>
                ///  Confirmation of  Land 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateKhasraAreaDetails(Project_id);
                if (chkvalue)
                {
                    TempData["message5"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message5"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("ProjectConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult Payment()
        {
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();
                TempData["SelectProject"] = Project_id;
                #region
                /// <summary>
                ///  Confirmation of  Payment 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdatePayment(Project_id);
                if (chkvalue)
                {
                    TempData["message6"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message6"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("ProjectConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult SpecialBankAccountDetails()
        {
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                TempData["SelectProject"] = Project_id;
                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();

                #region
                /// <summary>
                ///  Confirmation of  SpecialBankAccountDetails 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateSpecialBankAccountDetails(Project_id);
                if (chkvalue)
                {
                    TempData["message7"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message7"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("ProjectConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult Documents()
        {
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if ((Session["Project_id"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                 



                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                 
                TempData["SelectProject"] = Project_id;

                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();

                #region
                /// <summary>
                ///  Confirmation of   Documents 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateDocuments(Project_id);
                if (chkvalue)
                {
                    TempData["message8"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message8"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return View("ProjectConfirm");

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
            Int64 Project_id = 1039;
            ////if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("OptionViewAgent", "Agent");
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}
            if (Session["Project_id"] == null)
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                //Get Project_id, year and quater after postback
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                

                ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();

                /// <summary>
                ///  i agreee click
                /// </summary>
                /// <returns></returns>


                #region
                Int64 PromoterApplicationId = 0;
                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                    }
                }

                string Profile = model.UpdateAgreeDetails(PromoterApplicationId, Project_id, UID, UserNam);

                if (Profile == "0")
                {
                    TempData["ProjectRegDiaryNumber_Name"] = "Please Confrim Project Updates (Quaterly) or Promoter Profile First";
                }
                else if (Profile != null)
                {
                    TempData["ProjectRegDiaryNumber_Name"] = "Your Application successfully Submitted.Thanks  with diary number : " + Profile + " keep it for future reference";
                    await UserManager.SendEmailAsync(UID, "RERA, Punjab - Application Submitted for Project Registration", "<b>Dear " + UserNam + "</b>,<br /><br /> Your application for registration of project with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />Kindly submit the hard copy of the application form along with the uploaded documents within 7 days of submission of online application with RERA, Punjab. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                }
                else
                {
                    TempData["ProjectRegDiaryNumber_Name"] = "Sorry,Your Application is pending";
                }
                #endregion
                // return RedirectToAction("ProjectConfirm");
                return View("ProjectConfirm");

            }
            // return RedirectToAction("ProjectConfirm");
            return View("ProjectConfirm");
        }

        [HttpPost]
        public ActionResult ProjectQuater()
        {

            return RedirectToAction("ProjectConfirmQuater", "ProjectQuater");
        }


        [HttpPost]
        public ActionResult dropdownlist(ClsPrp_Project_Master smodel,FormCollection frm)
        {
            if (smodel.ProjectRegistration_ID != 0)
            {
                    Session["Project_id"] = smodel.ProjectRegistration_ID;
            }
            else
            {
                Session["Project_id"] = null;
            
             }

            ////string abc = string.Empty;
            ////abc = frm["DropDownList1"];

            return RedirectToAction("ProjectConfirm",smodel);

        }
    }
}