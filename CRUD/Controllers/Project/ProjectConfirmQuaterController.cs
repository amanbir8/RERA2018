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
    public class ProjectQuaterController : Controller
    {
        string UID;
        string UserNam;
        Int64 Project_id = 0;
        string Quater = string.Empty;
        string Year = string.Empty;

        //Project Registration Mode
        #region
        [HttpPost]
        public ActionResult dropdownlist(ClsPrp_Project_Master smodel, FormCollection frm)
        {
            try
            {
                /// Get years
                ViewBag.Years = GetYears();
                //For showing selected year
                TempData["CurrentYears"] = frm["DropDownlistyear"]; TempData.Keep();
                //For showing selected Quater
                TempData["Quater"] = frm["DropDownlistQUATER"]; TempData.Keep();

                if (smodel.ProjectRegistration_ID != 0)
                {
                    Session["Project_id"] = smodel.ProjectRegistration_ID;
                    Session["DropDownlistyear"] = frm["DropDownlistyear"];
                    Session["DropDownlistQUATER"] = frm["DropDownlistQUATER"];
                }
                else
                {
                    Session["Project_id"] = null;
                }

                //movement between QUP case and Registration case
                if (frm["DropDownlistQUATER"].ToString() != "Registration Process")
                {
                    return RedirectToAction("ProjectQUpdateConfirmQuater", smodel);
                }
                else
                {
                    return RedirectToAction("ProjectConfirmQuater", smodel);
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                return RedirectToAction("ProjectConfirmQuater", smodel);
            }
        }

        [HttpGet]
        public ActionResult ProjectConfirmQuater()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            //Int64 ApplicationID = 10001;

            //Int64 Project_id = 0;
            //string Quater = string.Empty;
            //string Year = string.Empty;

            //Get Years and Quater
            ViewBag.Years = GetYears();
            ViewBag.Quater = GetQuater();


            ClsPrp_Project_Master smodel = new ClsPrp_Project_Master();
            ClsMethodProject objdis = new ClsMethodProject();

            //Get Projects in dropdownlist by applicationID
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

            TempData["status1"] = ""; TempData["status2"] = ""; TempData["status3"] = ""; TempData["status4"] = ""; TempData["status5"] = ""; TempData["status6"] = ""; TempData["status7"] = ""; TempData["status8"] = ""; TempData["status9"] = "";

            TempData["submitvalue1"] = ""; TempData["submitvalue2"] = ""; TempData["submitvalue3"] = ""; TempData["submitvalue4"] = ""; TempData["submitvalue5"] = ""; TempData["submitvalue6"] = ""; TempData["submitvalue7"] = ""; TempData["submitvalue8"] = ""; TempData["submitvalue9"] = "";

            TempData["message1"] = ""; TempData["message2"] = ""; TempData["message3"] = ""; TempData["message4"] = ""; TempData["message5"] = ""; TempData["message6"] = ""; TempData["message7"] = ""; TempData["message8"] = ""; TempData["message9"] = "";

            TempData["ProjectQuaterRegDiaryNumber_Name"] = "";


            if ((Session["Project_id"] == null))
            {
                TempData["Agree"] = "intialize";


            }
            else
            {
                //Check Isdraft value From Diary Number table
                #region
                Get_Isdraftvalue_FromDiaryNumber();
                #endregion
                //Get Project_id, year and quater after postback
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

                if(Session["DropDownlistyear"] == null)
                {
                    Session["DropDownlistyear"] = "0";
                }

                if (Session["DropDownlistQUATER"] == null)
                {
                    Session["DropDownlistQUATER"] = "0";
                }

                Year = Session["DropDownlistyear"].ToString();                
                Quater = Session["DropDownlistQUATER"].ToString();

                //To rebind project id after postback
                smodel.ProjectRegistration_ID = Convert.ToInt32(Session["Project_id"].ToString());

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

               
                //For showing selected year after postback
                TempData["CurrentYears"] = Session["DropDownlistyear"].ToString();
                //For showing selected Quater after postback
                TempData["CurrentQuater"] = Session["DropDownlistQUATER"].ToString();
                TempData.Keep();

                //Check count in Construction Detail
                #region
                Int32 Profile = model.Construction(Project_id, Quater, Year);

                //string submitvalue = "submitvalue";
                //string status = "projectReg";
                if (Profile == 0)
                {
                    TempData["status"] = "Complete";
                    TempData.Keep();
                    TempData["submitvalue"] = "Confirm Construction Detail";
                    TempData.Keep();
                }
                else if (Profile == 1)
                {
                    TempData["status"] = "Complete";
                    TempData.Keep();
                    TempData["submitvalue"] = "Already Confirmed Construction Detail";
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

                //Check count in Other Inventory Detail
                #region
                Int32 Inventory = model.Inventory(Project_id, Quater, Year);

                //string submitvalue1 = "submitLitigations";
                //string status1 = "Litigations";

                if (Inventory == 0)
                {
                    TempData["status1"] = "Complete";
                    TempData["submitvalue1"] = "Confirm Inventory Detail";
                    TempData.Keep();
                }
                else if (Inventory == 1)
                {
                    TempData["status1"] = "Complete";
                    TempData["submitvalue1"] = "Already Confirmed Inventory Detail";
                    TempData.Keep();
                }
                else
                {
                    TempData["status1"] = "Pending";
                    TempData["submitvalue1"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in Internal Facilities
                #region
                Int32 Facilities = model.Facilities(Project_id, Quater, Year);

                //string submitvalue2 = "submitLandDetails";
                //string status2 = "LandDetails";

                if (Facilities == 0)
                {
                    TempData["status2"] = "Complete";
                    TempData["submitvalue2"] = "Confirm Facilities Details";
                    TempData.Keep();
                }
                else if (Facilities == 1)
                {
                    TempData["status2"] = "Complete";
                    TempData["submitvalue2"] = "Already Confirmed Facilities Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status2"] = "Pending";
                    TempData["submitvalue2"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in ParkingDetails
                #region
                Int32 ParkingDetails = model.ParkingDetails(Project_id, Quater, Year);

                //string submitvalue3 = "submitApprovalDetails";
                //string status3 = "Approval";

                if (ParkingDetails == 0)
                {
                    TempData["status3"] = "Complete";
                    TempData["submitvalue3"] = "Confirm Parking Details";
                    TempData.Keep();
                }
                else if (ParkingDetails == 1)
                {
                    TempData["status3"] = "Complete";
                    TempData["submitvalue3"] = "Already Confirmed Parking Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status3"] = "Pending";
                    TempData["submitvalue3"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in ProfessionalDetails
                #region
                Int32 ProfessionalDetails = model.ProfessionalDetails(Project_id, Quater, Year);

                //string submitvalue5 = "submitKhasraAreaDetails";
                //string status5 = "KhasraAreaDetails";

                if (ProfessionalDetails == 0)
                {
                    TempData["status5"] = "Complete";
                    TempData["submitvalue5"] = "Confirm Professional Detail";
                    TempData.Keep();
                }
                else if (ProfessionalDetails == 1)
                {
                    TempData["status5"] = "Complete";
                    TempData["submitvalue5"] = "Already Confirmed Professional Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status5"] = "Pending";
                    TempData["submitvalue5"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in External Facilities
                #region
                Int32 ExternalFacilities = model.ExternalFacilities(Project_id, Quater, Year);

                //string submitvalue2 = "submitLandDetails";
                //string status2 = "LandDetails";

                if (ExternalFacilities == 0)
                {
                    TempData["status6"] = "Complete";
                    TempData["submitvalue6"] = "Confirm External Facilities Details";
                    TempData.Keep();
                }
                else if (ExternalFacilities == 1)
                {
                    TempData["status6"] = "Complete";
                    TempData["submitvalue6"] = "Already Confirmed External Facilities Details";
                    TempData.Keep();
                }
                else
                {
                    TempData["status6"] = "Pending";
                    TempData["submitvalue6"] = "Pending";
                    TempData.Keep();
                }
                #endregion

                //Check count in photograph
                #region
                Int32 photograph = model.photograph(Project_id, Quater, Year);

                //string submitvalue8 = "submitPayment";
                //string status8 = "Payment";

                if (photograph == 0)
                {
                    TempData["status9"] = "Complete";
                    TempData["submitvalue9"] = "Confirm photograph Detail";
                    TempData.Keep();
                }
                else if (photograph == 1)
                {
                    TempData["status9"] = "Complete";
                    TempData["submitvalue9"] = "Already Confirmed photograph Details";
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
                 
                Int32 var_agree = model.ProjectQuaterAgreeDetails(Project_id, Quater, Year);
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
             
            ClsMethodProjectQuater model = new ClsMethodProjectQuater();

            #region
            /// <summary>
            ///  Confirmation of  Agent Profile
            /// </summary>
            /// <returns></returns>
            //Get Project_id, year and quater after postback
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();


                Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Project_id, Quater, Year);
                TempData["IsdraftValue"] = IsdraftValue;
            }
            //return View("AgentView");
            //return RedirectToAction("ProjectConfirmQuater");




            #endregion

        }

        [HttpPost]
        public ActionResult Construction()
        {

            //Int64 Project_id = 0;
            //string Quater = string.Empty;
            //string Year = string.Empty;

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
            if ((Session["Project_id"] == null)||(Session["DropDownlistyear"] == null)||(Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();


                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of  Project Profile
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateConstruction(Project_id, Quater, Year);
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
            //return View("AgentView");
            return RedirectToAction("ProjectConfirmQuater");

            #endregion
        }

        [HttpPost]
        public ActionResult Inventory()
        {
            //string Quater = string.Empty;
            //string Year = string.Empty;
            //Int64 Project_id = 1039;
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
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
            }

            else
            {//Get Project_id, year and quater after postback
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of  Inventory 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateInventory(Project_id, Quater, Year);
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
            return RedirectToAction("ProjectConfirmQuater");
            #endregion
        }

        [HttpPost]
        public ActionResult Facilities()
        {
            //string Quater = string.Empty;
            //string Year = string.Empty;
            //Int64 Project_id = 1039;
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
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of  facility 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateFacilities(Project_id, Quater, Year);
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
            return RedirectToAction("ProjectConfirmQuater");

            #endregion
        }

        [HttpPost]
        public ActionResult ParkingDetails()
        {
            //string Quater = string.Empty;
            //string Year = string.Empty;
            //Int64 Project_id = 1039;
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
            
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of  ParkingDetails 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateParkingDetails(Project_id, Quater, Year);
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
            return RedirectToAction("ProjectConfirmQuater");

            #endregion
        }

        [HttpPost]
        public ActionResult ProfessionalDetails()
        {
            //string Quater = string.Empty;
            //string Year = string.Empty;
            //Int64 Project_id = 1039;
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
            if ((Session["Project_id"]  == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of  Land 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateProfessionalDetails(Project_id, Quater, Year);
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
            return RedirectToAction("ProjectConfirmQuater");

            #endregion
        }

        [HttpPost]
        public ActionResult ExternalFacilities()
        {
            //string Quater = string.Empty;
            //string Year = string.Empty;
            //Int64 Project_id = 1039;
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
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of External facility 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.UpdateExternalFacilities(Project_id, Quater, Year);
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
                //return View("AgentView");
            }
            return RedirectToAction("ProjectConfirmQuater");

            #endregion
        }

        [HttpPost]
        public ActionResult photograph()
        {
            //Int64 Project_id = 1039;
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
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

                #region
                /// <summary>
                ///  Confirmation of   photograph 
                /// </summary>
                /// <returns></returns>


                bool chkvalue = model.Updatephotograph(Project_id, Quater, Year);
                if (chkvalue)
                {
                    TempData["message9"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["message9"] = "Sorry,No record found! Please try again";
                    TempData.Keep();
                }
            }
            return RedirectToAction("ProjectConfirmQuater");

            #endregion
        }

        [HttpPost]
        public ActionResult Btn_Agree()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            //Int64 Project_id = 1039;
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
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
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
                Year = Session["DropDownlistyear"].ToString();
                Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater model = new ClsMethodProjectQuater();

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

                string Profile = model.UpdateQuaterAgreeDetails(PromoterApplicationId,Project_id, Quater, Year, UID, UserNam);


                if (Profile != null)
                    TempData["ProjectQuaterRegDiaryNumber_Name"] = "Your Application successfully Submitted.Thanks ";// with diary number : " + Profile + " keep it for future reference ";
                else
                    TempData["ProjectQuaterRegDiaryNumber_Name"] = "Sorry,Your Application is pending";
                #endregion
                

                //Get Years and Quater
                ViewBag.Years = GetYears();
                ViewBag.Quater = GetQuater();

                //Get Projects in dropdownlist by applicationID
                ClsPrp_Project_Master smodel = new ClsPrp_Project_Master();
                ClsMethodProject objdis = new ClsMethodProject();                               
                TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
                TempData.Keep();

                //return RedirectToAction("ProjectConfirmQuater");
                return View("ProjectConfirmQuater");
                
            }
            return RedirectToAction("ProjectConfirmQuater");
        }
        #endregion

        private static List<SelectListItem> GetQuater()
        {
            var listItems2 = new List<SelectListItem>
            {
                //new SelectListItem {  Text = "..." , Value="Select"  },
                new SelectListItem {  Text = "Registration Process" , Value="Registration Process"  },
                //new SelectListItem {  Text = "First Quarter" , Value="First Quarter"  },
                //new SelectListItem {  Text = "Second Quarter" , Value="Second Quarter"  },
                //new SelectListItem {  Text = "Third Quarter" , Value="Third Quarter"  },
                //new SelectListItem {  Text = "Fourth Quarter" , Value="Fourth Quarter"  },
                new SelectListItem {  Text = "First Quarter (January-March)" , Value="FirstQTR"  },
                new SelectListItem {  Text = "Second Quarter (April-June)" , Value="SecondQTR"  },
                new SelectListItem {  Text = "Third Quarter (July-September)" , Value="ThirdQTR"  },
                new SelectListItem {  Text = "Fourth Quarter (October-December)" , Value="FourthQTR"  },
            };
            return listItems2;
        }
        private static List<SelectListItem> GetYears()
        {
            List<SelectListItem> Years = new List<SelectListItem>();

            for (Int32 i = 2017; i <= 2030; i++)
            {
                Years.Add(new SelectListItem
                {
                    Text = Convert.ToString(i),
                    Value = Convert.ToString(i)
                });
            }

            return Years.ToList();
        }

        //QUP Mode
        #region
        [HttpPost]
        public ActionResult dropdownlistQuarterlyUpdateProject(ClsPrp_Project_Master smodel, FormCollection frm)
        {
            try
            {
                /// Get years
                ViewBag.Years = GetYears();
                //For showing selected year
                TempData["CurrentYears"] = frm["DropDownlistyear"]; TempData.Keep();
                //For showing selected Quater
                TempData["Quater"] = frm["DropDownlistQUATER"]; TempData.Keep();                

                if (smodel.ProjectRegistration_ID != 0)
                {
                    Session["Project_id"] = smodel.ProjectRegistration_ID;
                    Session["DropDownlistyear"] = frm["DropDownlistyear"];
                    Session["DropDownlistQUATER"] = frm["DropDownlistQUATER"];
                }
                else
                {
                    Session["Project_id"] = null;
                }

                //movement between QUP case and Registration case
                if (frm["DropDownlistQUATER"].ToString() != "Registration Process")
                {
                    return RedirectToAction("ProjectQUpdateConfirmQuater", smodel);
                }
                else
                {
                    return RedirectToAction("ProjectConfirmQuater", smodel);
                }
            }
            catch(Exception ex)
            {
                string str = ex.ToString();
                return RedirectToAction("ProjectQUpdateConfirmQuater", smodel);
            }           
        }

        [HttpGet]
        public ActionResult ProjectQUpdateConfirmQuater()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;

            //Get Years and Quater
            ViewBag.Years = GetYears();
            ViewBag.Quater = GetQuater();


            ClsPrp_Project_Master smodel = new ClsPrp_Project_Master();
            ClsMethodProject objdis = new ClsMethodProject();

            //Get Projects in dropdownlist by applicationID
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

            TempData["statusQU1"] = ""; TempData["statusQU2"] = ""; TempData["statusQU3"] = ""; TempData["statusQU4"] = ""; TempData["statusQU5"] = ""; TempData["statusQU6"] = "";
            TempData["submitvalueQU1"] = ""; TempData["submitvalueQU2"] = ""; TempData["submitvalueQU3"] = ""; TempData["submitvalueQU4"] = ""; TempData["submitvalueQU5"] = ""; TempData["submitvalueQU6"] = "";
            TempData["trackflagQU1"] = ""; TempData["trackflagQU2"] = ""; TempData["trackflagQU3"] = ""; TempData["trackflagQU4"] = ""; TempData["trackflagQU5"] = ""; TempData["trackflagQU6"] = "";
            TempData["messageQU1"] = ""; TempData["messageQU2"] = ""; TempData["messageQU3"] = ""; TempData["messageQU4"] = ""; TempData["messageQU5"] = ""; TempData["messageQU6"] = "";

            TempData["QUProjectRegDiaryNumber_Name"] = "";


            if ((Session["Project_id"] == null))
            {
                TempData["AgreeQU"] = "intialize";
            }
            else
            {
                #region IsDraft Flag and Year-Quarter list

                Int64 QUpdateProjectID = 0;
                string QUpdateQuaterName = string.Empty;
                Int32 QUpdateYear = 0;

                //Check Isdraft value From Diary Number table
                Int32 chkValueReturn = Get_QUpdateProject_getQUValue_FromDiaryNumber();
                TempData["IsdraftQUpdateValue"] = chkValueReturn;

                //Get Project_id, year and quater after postback
                QUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());

                if (Session["DropDownlistyear"] == null)
                {
                    Session["DropDownlistyear"] = "0";
                }

                if (Session["DropDownlistQUATER"] == null)
                {
                    Session["DropDownlistQUATER"] = "0";
                }

                QUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                //To rebind project-id, elected year & Quater after postback
                smodel.ProjectRegistration_ID = Convert.ToInt32(Session["Project_id"].ToString());
                TempData["CurrentYears"] = Session["DropDownlistyear"].ToString(); TempData.Keep();
                TempData["CurrentQuater"] = Session["DropDownlistQUATER"].ToString(); TempData.Keep();

                #endregion

                ClsMethodProjectQuater_QUpdateProject objQUproject = new ClsMethodProjectQuater_QUpdateProject();

                //Check QUpdate count in Inventory and Construction Details
                #region
                Int32 InventoryQUP = objQUproject.QUpdateProjectInventoryConstruction(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);

                //-- 1 Pending
                //-- 2 Complete
                //-- 3 Confirmed
                //-- 4 Closed
                //-- 5 Optional
                //-- 6 No_Record_Found
                
                switch (InventoryQUP)
                {
                    case 1:
                        {
                            TempData["statusQU1"] = "Pending"; TempData.Keep();
                            TempData["submitvalueQU1"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU1"] = "1"; TempData.Keep();
                            break;
                        }
                    case 2:
                        {
                            TempData["statusQU1"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU1"] = "Confirm Inventory Detail"; TempData.Keep();
                            TempData["trackflagQU1"] = "2"; TempData.Keep();
                            break;
                        }
                    case 3:
                        {
                            TempData["statusQU1"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU1"] = "Already Confirmed Inventory Detail"; TempData.Keep();
                            TempData["trackflagQU1"] = "3"; TempData.Keep();
                            break;
                        }
                    case 4:
                        {
                            TempData["statusQU1"] = "Closed"; TempData.Keep();
                            TempData["submitvalueQU1"] = "Registration Closed"; TempData.Keep();
                            TempData["trackflagQU1"] = "4"; TempData.Keep();
                            break;
                        }
                    case 5:
                        {
                            TempData["statusQU1"] = "Optional"; TempData.Keep();
                            TempData["submitvalueQU1"] = "Inventory Detail (Optional)"; TempData.Keep();
                            TempData["trackflagQU1"] = "5"; TempData.Keep();
                            break;
                        }
                    case 6:
                        {
                            TempData["statusQU1"] = "No Records Found"; TempData.Keep();
                            TempData["submitvalueQU1"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU1"] = "6"; TempData.Keep();
                            break;
                        }
                }
                #endregion

                //Check QUpdate count in Parking Details
                #region
                Int32 ParkingQUP = objQUproject.QUpdateProjectParkingDetails(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);

                switch (ParkingQUP)
                {
                    case 1:
                        {
                            TempData["statusQU2"] = "Pending"; TempData.Keep();
                            TempData["submitvalueQU2"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU2"] = "1"; TempData.Keep();
                            break;
                        }
                    case 2:
                        {
                            TempData["statusQU2"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU2"] = "Confirm Parking Detail"; TempData.Keep();
                            TempData["trackflagQU2"] = "2"; TempData.Keep();
                            break;
                        }
                    case 3:
                        {
                            TempData["statusQU2"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU2"] = "Already Confirmed Parking Detail"; TempData.Keep();
                            TempData["trackflagQU2"] = "3"; TempData.Keep();
                            break;
                        }
                    case 4:
                        {
                            TempData["statusQU2"] = "Closed"; TempData.Keep();
                            TempData["submitvalueQU2"] = "Registration Closed"; TempData.Keep();
                            TempData["trackflagQU2"] = "4"; TempData.Keep();
                            break;
                        }
                    case 5:
                        {
                            TempData["statusQU2"] = "Optional"; TempData.Keep();
                            TempData["submitvalueQU2"] = "Parking Detail (Optional)"; TempData.Keep();
                            TempData["trackflagQU2"] = "5"; TempData.Keep();
                            break;
                        }
                    case 6:
                        {
                            TempData["statusQU2"] = "No Records Found"; TempData.Keep();
                            TempData["submitvalueQU2"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU2"] = "6"; TempData.Keep();
                            break;
                        }
                }
                #endregion

                //Check QUpdate count in Status of Construction Photographs Details
                #region
                Int32 PhotographsQUP = objQUproject.QUpdateProjectPhotographStatus(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);

                switch (PhotographsQUP)
                {
                    case 1:
                        {
                            TempData["statusQU3"] = "Pending"; TempData.Keep();
                            TempData["submitvalueQU3"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU3"] = "1"; TempData.Keep();
                            break;
                        }
                    case 2:
                        {
                            TempData["statusQU3"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU3"] = "Confirm Photographs Detail"; TempData.Keep();
                            TempData["trackflagQU3"] = "2"; TempData.Keep();
                            break;
                        }
                    case 3:
                        {
                            TempData["statusQU3"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU3"] = "Already Confirmed Photographs Detail"; TempData.Keep();
                            TempData["trackflagQU3"] = "3"; TempData.Keep();
                            break;
                        }
                    case 4:
                        {
                            TempData["statusQU3"] = "Closed"; TempData.Keep();
                            TempData["submitvalueQU3"] = "Registration Closed"; TempData.Keep();
                            TempData["trackflagQU3"] = "4"; TempData.Keep();
                            break;
                        }
                    case 5:
                        {
                            TempData["statusQU3"] = "Optional"; TempData.Keep();
                            TempData["submitvalueQU3"] = "Photographs Detail (Optional)"; TempData.Keep();
                            TempData["trackflagQU3"] = "5"; TempData.Keep();
                            break;
                        }
                    case 6:
                        {
                            TempData["statusQU3"] = "No Records Found"; TempData.Keep();
                            TempData["submitvalueQU3"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU3"] = "6"; TempData.Keep();
                            break;
                        }
                }
                #endregion

                //Check QUpdate count in Internal Facilities Details
                #region
                Int32 InternalFacsQUP = objQUproject.QUpdateProjectInternalFacilities(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);

                switch (InternalFacsQUP)
                {
                    case 1:
                        {
                            TempData["statusQU4"] = "Pending"; TempData.Keep();
                            TempData["submitvalueQU4"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU4"] = "1"; TempData.Keep();
                            break;
                        }
                    case 2:
                        {
                            TempData["statusQU4"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU4"] = "Confirm Internal Facilities Detail"; TempData.Keep();
                            TempData["trackflagQU4"] = "2"; TempData.Keep();
                            break;
                        }
                    case 3:
                        {
                            TempData["statusQU4"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU4"] = "Already Confirmed Internal Facilities Detail"; TempData.Keep();
                            TempData["trackflagQU4"] = "3"; TempData.Keep();
                            break;
                        }
                    case 4:
                        {
                            TempData["statusQU4"] = "Closed"; TempData.Keep();
                            TempData["submitvalueQU4"] = "Registration Closed"; TempData.Keep();
                            TempData["trackflagQU4"] = "4"; TempData.Keep();
                            break;
                        }
                    case 5:
                        {
                            TempData["statusQU4"] = "Optional"; TempData.Keep();
                            TempData["submitvalueQU4"] = "Internal Facilities Detail (Optional)"; TempData.Keep();
                            TempData["trackflagQU4"] = "5"; TempData.Keep();
                            break;
                        }
                    case 6:
                        {
                            TempData["statusQU4"] = "No Records Found"; TempData.Keep();
                            TempData["submitvalueQU4"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU4"] = "6"; TempData.Keep();
                            break;
                        }
                }
                #endregion

                //Check QUpdate count in External Facilities Details
                #region
                Int32 ExternalFacsQUP = objQUproject.QUpdateProjectExternalFacilities(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);

                switch (ExternalFacsQUP)
                {
                    case 1:
                        {
                            TempData["statusQU5"] = "Pending"; TempData.Keep();
                            TempData["submitvalueQU5"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU5"] = "1"; TempData.Keep();
                            break;
                        }
                    case 2:
                        {
                            TempData["statusQU5"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU5"] = "Confirm External Facilities Detail"; TempData.Keep();
                            TempData["trackflagQU5"] = "2"; TempData.Keep();
                            break;
                        }
                    case 3:
                        {
                            TempData["statusQU5"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU5"] = "Already Confirmed External Facilities Detail"; TempData.Keep();
                            TempData["trackflagQU5"] = "3"; TempData.Keep();
                            break;
                        }
                    case 4:
                        {
                            TempData["statusQU5"] = "Closed"; TempData.Keep();
                            TempData["submitvalueQU5"] = "Registration Closed"; TempData.Keep();
                            TempData["trackflagQU5"] = "4"; TempData.Keep();
                            break;
                        }
                    case 5:
                        {
                            TempData["statusQU5"] = "Optional"; TempData.Keep();
                            TempData["submitvalueQU5"] = "External Facilities Detail (Optional)"; TempData.Keep();
                            TempData["trackflagQU5"] = "5"; TempData.Keep();
                            break;
                        }
                    case 6:
                        {
                            TempData["statusQU5"] = "No Records Found"; TempData.Keep();
                            TempData["submitvalueQU5"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU5"] = "6"; TempData.Keep();
                            break;
                        }
                }
                #endregion

                //Check QUpdate count in Approvals Details
                #region
                Int32 ApprovalsQUP = objQUproject.QUpdateProjectApprovals(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);

                switch (ApprovalsQUP)
                {
                    case 1:
                        {
                            TempData["statusQU6"] = "Pending"; TempData.Keep();
                            TempData["submitvalueQU6"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU6"] = "1"; TempData.Keep();
                            break;
                        }
                    case 2:
                        {
                            TempData["statusQU6"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU6"] = "Confirm Approvals Detail"; TempData.Keep();
                            TempData["trackflagQU6"] = "2"; TempData.Keep();
                            break;
                        }
                    case 3:
                        {
                            TempData["statusQU6"] = "Complete"; TempData.Keep();
                            TempData["submitvalueQU6"] = "Already Confirmed Approvals Detail"; TempData.Keep();
                            TempData["trackflagQU6"] = "3"; TempData.Keep();
                            break;
                        }
                    case 4:
                        {
                            TempData["statusQU6"] = "Closed"; TempData.Keep();
                            TempData["submitvalueQU6"] = "Registration Closed"; TempData.Keep();
                            TempData["trackflagQU6"] = "4"; TempData.Keep();
                            break;
                        }
                    case 5:
                        {
                            TempData["statusQU6"] = "Optional"; TempData.Keep();
                            TempData["submitvalueQU6"] = "Approvals Detail (Optional)"; TempData.Keep();
                            TempData["trackflagQU6"] = "5"; TempData.Keep();
                            break;
                        }
                    case 6:
                        {
                            TempData["statusQU6"] = "No Records Found"; TempData.Keep();
                            TempData["submitvalueQU6"] = "Pending"; TempData.Keep();
                            TempData["trackflagQU6"] = "6"; TempData.Keep();
                            break;
                        }
                }
                #endregion

                //Check agree detail
                #region 

                Int32 var_agree = objQUproject.QUpdateProjectQuaterAgreeDetails(QUpdateProjectID, QUpdateYear, QUpdateQuaterName);
                TempData["AgreeQU"] = "Pending";
                if (var_agree == 1)//means record exists in all table , so Enable the agree button.
                {
                    TempData["AgreeQU"] = "Done";
                    TempData.Keep();
                }
                #endregion
            }
            return View(smodel);
        }

        public Int32 Get_QUpdateProject_getQUValue_FromDiaryNumber()
        {
            Int32 returnQUpdateDNoValue = 0;            
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                returnQUpdateDNoValue = 1;
            }
            else
            {
                Int64 Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 Year = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string Quater = Session["DropDownlistQUATER"].ToString();

                ClsMethodProjectQuater_QUpdateProject ObjCls = new ClsMethodProjectQuater_QUpdateProject();
                Int32 IsdraftValue = ObjCls.GetQUValue_FromDiaryNumber(Project_id, Year, Quater);
                if (IsdraftValue == 1 || IsdraftValue == 5 || IsdraftValue == 6)
                {
                    returnQUpdateDNoValue = 1;
                }
                else if (IsdraftValue == 9)
                {
                    returnQUpdateDNoValue = 9;
                }
                else
                {
                    returnQUpdateDNoValue = 2;
                }
            }            
            return returnQUpdateDNoValue;
        }


        [HttpPost]
        public ActionResult QUpdateInventoryConstruction()
        {
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["messageQU1"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();
                
                #region Confirmation of QUpdateInventoryConstruction
                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();

                bool chkvalue = ObjQUpdatesCls.UpdateQUpdateProjectInventoryConstruction(pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName);
                if (chkvalue)
                {
                    TempData["messageQU1"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageQU1"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
                #endregion
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
        }

        [HttpPost]
        public ActionResult QUpdateParking()
        {
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["messageQU2"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                #region Confirmation of QUpdateParking
                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();

                bool chkvalue = ObjQUpdatesCls.UpdateQUpdateProjectParkingDetails(pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName);
                if (chkvalue)
                {
                    TempData["messageQU2"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageQU2"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
                #endregion
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
        }

        [HttpPost]
        public ActionResult QUpdateStatusConstructionPhotographs()
        {
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["messageQU3"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                #region Confirmation of QUpdateStatusConstructionPhotographs
                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();

                bool chkvalue = ObjQUpdatesCls.UpdateQUpdatePhotographStatusGeoTagging(pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName);
                if (chkvalue)
                {
                    TempData["messageQU3"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageQU3"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
                #endregion
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
        }

        [HttpPost]
        public ActionResult QUpdateInternalFacilities()
        {
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["messageQU4"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                #region Confirmation of QUpdateInternalFacilities
                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();

                bool chkvalue = ObjQUpdatesCls.UpdateQUpdateInternalFacilities(pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName);
                if (chkvalue)
                {
                    TempData["messageQU4"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageQU4"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
                #endregion
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
        }

        [HttpPost]
        public ActionResult QUpdateExternalFacilities()
        {
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["messageQU5"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                #region Confirmation of QUpdateExternalFacilities
                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();

                bool chkvalue = ObjQUpdatesCls.UpdateQUpdateExternalFacilities(pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName);
                if (chkvalue)
                {
                    TempData["messageQU5"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageQU5"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
                #endregion
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
        }

        [HttpPost]
        public ActionResult QUpdateApprovals()
        {
            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["messageQU6"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                #region Confirmation of QUpdateApprovals
                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();

                bool chkvalue = ObjQUpdatesCls.UpdateQUpdateApprovals(pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName);
                if (chkvalue)
                {
                    TempData["messageQU6"] = "Confirmed Successfully";
                    TempData.Keep();
                }
                else
                {
                    TempData["messageQU6"] = "Sorry, No record found! Please try again";
                    TempData.Keep();
                }
                #endregion
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
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
        //public ActionResult Btn_QUpdateAgree()
        public async Task<ActionResult> Btn_QUpdateAgree()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;

            if ((Session["Project_id"] == null) || (Session["DropDownlistyear"] == null) || (Session["DropDownlistQUATER"] == null))
            {
                TempData["QUProjectRegDiaryNumber_Name"] = "Invalid selected values of project or year or quarter name! Please try again";
                TempData.Keep();
            }
            else
            {
                //Get Project_id, year and quater after postback
                Int64 pQUpdateProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 pQUpdateYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                string pQUpdateQuaterName = Session["DropDownlistQUATER"].ToString();

                #region Submit_IAgreeQUP

                Int64 PromoterApplicationId = 0;
                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                    }
                }

                ClsMethodProjectQuater_QUpdateProject ObjQUpdatesCls = new ClsMethodProjectQuater_QUpdateProject();
                string Profile = ObjQUpdatesCls.UpdateQUpdateQuaterAgreeDetails(PromoterApplicationId, pQUpdateProjectID, pQUpdateYear, pQUpdateQuaterName, UID, UserNam);

                if(Profile != null)
                {
                    if (Profile == "0")
                    {
                        TempData["QUProjectRegDiaryNumber_Name"] = "Please Confrim Project and its Updates (Quaterly) or Promoter Profile First";
                    }
                    else if(Profile == "Error")
                    {
                        TempData["QUProjectRegDiaryNumber_Name"] = "Invalid! Submission Error! Please try again.";
                    }
                    else
                    {
                        TempData["QUProjectRegDiaryNumber_Name"] = "Your Application successfully Submitted with Diary Number: " + Profile + " keep it for future reference. Thanks";
                        await UserManager.SendEmailAsync(UID, "RERA, Punjab - Application Submitted for Quarterly Updates of Registered Project", "<b>Dear " + UserNam + "</b>,<br /><br /> Your application for quarterly project updates of registered project with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />If you’ve got any questions you’re welcome to contact us at www.rera.punjab.gov.in, We do appreciate the time that you invested in this quarterly updates of registered project. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                    }
                }                    
                else
                    TempData["QUProjectRegDiaryNumber_Name"] = "Sorry, Your Application is pending! Please try again.";
                #endregion
                
                //Get Years and Quater
                ViewBag.Years = GetYears();
                ViewBag.Quater = GetQuater();

                //Get Projects in dropdownlist by applicationID
                ClsPrp_Project_Master smodel = new ClsPrp_Project_Master();
                ClsMethodProject objdis = new ClsMethodProject();

                TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
                TempData.Keep();
                return View("ProjectQUpdateConfirmQuater");
            }
            return RedirectToAction("ProjectQUpdateConfirmQuater");
        }
        #endregion
    }
}