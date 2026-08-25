using CRUD.Models.Promoter;
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
using CRUD.Models.JointPromoter;

namespace CRUD.Controllers.Promoter
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class PromoterConfirmController : Controller
    {
        #region Pre-requisite Settings
        string UID;
        string UserNam;

        string rcp_UID = string.Empty;
        string rcp_UserNam = string.Empty;
        Int64 rcp_PromoterID = 0;
        Int32 rcp_TypeOfPromoter = 0;
        Int64 rcp_JointPromoterID = 0;
        Int32 rcp_JointPromoterType = 0;
        string rcp_JointPromoterName = string.Empty;
        string rcp_Error = string.Empty;

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
        #endregion

        //Review and Confirm Promoter Profile
        #region Promoter Profile Detail
        [HttpGet]
        public ActionResult PromoterConfirm()
        {
            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["message1"] = ""; TempData["message2"] = ""; TempData["message3"] = ""; TempData["message4"] = ""; TempData["message5"] = ""; TempData["message6"] = ""; TempData["messageJPrm"] = "";
            TempData["PromoterProfile"] = ""; TempData["submitvalue"] = ""; TempData["OtherMemberDetail"] = ""; TempData["submitOtherMemeber"] = "";
            TempData["OtherParentEntity"] = ""; TempData["submitParentEntity"] = ""; TempData["OtherExperince"] = ""; TempData["submitExperince"] = "";
            TempData["OtherLitigations"] = ""; TempData["submitLitigations"] = ""; TempData["OtherDocuments"] = ""; TempData["submitDocuments"] = "";
            TempData["OtherJointPromoters"] = ""; TempData["submitJointPromoters"] = "";

            TempData["PromoterRegDiaryNumber_Name"] = "";

            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion
            //Check count in Promoter profile
            #region
            Int32 Profile = model.Profilecount(Application_ID);

            string submitvalue = "submitvalue";
            string status = "PromoterProfile";
            if (Profile == 0)
            {
                TempData[status] = "Complete";
                TempData[submitvalue] = "Confirm Promoter Profile";
                TempData.Keep();
            }
            else if (Profile == 1)
            {
                TempData[status] = "Complete";
                TempData[submitvalue] = "Already Confirmed Promoter Profile";
                TempData.Keep();
            }
            else
            {
                TempData[status] = "Pending";
                TempData[submitvalue] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Other Member Detail
            #region
            Int32 OtherMemberDetail = model.OtherMemberDetail(Application_ID);

            string submitvalue1 = "submitOtherMemeber";
            string status1 = "OtherMemberDetail";

            if (OtherMemberDetail == 0)
            {
                TempData[status1] = "Complete";
                TempData[submitvalue1] = "Confirm Other Member Detail";
                TempData.Keep();
            }
            else if (OtherMemberDetail == 1)
            {
                TempData[status1] = "Complete";
                TempData[submitvalue1] = "Already Confirmed Other Member Detail";
                TempData.Keep();
            }
            else
            {
                TempData[status1] = "Pending";
                TempData[submitvalue1] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Parent Entity
            #region
            Int32 ParentEntity = model.ParentEntity(Application_ID);

            string submitvalue2 = "submitParentEntity";
            string status2 = "OtherParentEntity";

            if (ParentEntity == 0)
            {
                TempData[status2] = "Complete";
                TempData[submitvalue2] = "Confirm Parent Entity Detail";
                TempData.Keep();
            }
            else if (ParentEntity == 1)
            {
                TempData[status2] = "Complete";
                TempData[submitvalue2] = "Already Confirmed Parent Entity Detail";
                TempData.Keep();
            }
            else
            {
                TempData[status2] = "Pending";
                TempData[submitvalue2] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Experience Completed OnGoing
            #region
            Int32 Experince = model.Experience_Completed_OnGoing(Application_ID);

            string submitvalue3 = "submitExperince";
            string status3 = "OtherExperince";

            if (Experince == 0)
            {
                TempData[status3] = "Complete";
                TempData[submitvalue3] = "Confirm Past Experince Detail";
                TempData.Keep();
            }
            else if (Experince == 1)
            {
                TempData[status3] = "Complete";
                TempData[submitvalue3] = "Already Confirmed Past Experince Detail";
                TempData.Keep();
            }
            else
            {
                TempData[status3] = "Pending";
                TempData[submitvalue3] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Litigations
            #region
            Int32 Litigations = model.Litigations(Application_ID);

            //check experince is yes? and litigation is yes against that project? and Enable litigation action link 
            Session["User_Litigations"] = model.Litigationsifany_Application_ID(Application_ID);

            string submitvalue4 = "submitLitigations";
            string status4 = "OtherLitigations";

            if (Litigations == 0)
            {
                TempData[status4] = "Complete";
                TempData[submitvalue4] = "Confirm All Litigations Detail";
                TempData.Keep();
            }
            else if (Litigations == 1)
            {
                TempData[status4] = "Complete";
                TempData[submitvalue4] = "Already Confirmed Litigations Detail";
                TempData.Keep();
            }
            else
            {
                TempData[status4] = "Pending";
                TempData[submitvalue4] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Documents
            #region
            Int32 documents = model.Documents(Application_ID);

            string submitvalue5 = "submitDocuments";
            string status5 = "OtherDocuments";

            if (documents == 0)
            {
                TempData[status5] = "Complete";
                TempData[submitvalue5] = "Confirm All Documents Detail";
                TempData.Keep();
            }
            else if (documents == 1)
            {
                TempData[status5] = "Complete";
                TempData[submitvalue5] = "Already Confirmed Documents Detail";
                TempData.Keep();
            }
            else
            {
                TempData[status5] = "Pending";
                TempData[submitvalue5] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check count in Joint-Promoters
            #region
            Tuple<string, Int32> JointPromoters = model.JointPromoterDetails_TrackRecordLitigations_ByID(Application_ID, UID, UserNam);

            Session["User_JointPromoter"] = "N";
            Session["User_JointPromoter"] = JointPromoters.Item1.ToString();

            string submitvalue6 = "submitJointPromoters";
            string status6 = "OtherJointPromoters";

            if (JointPromoters.Item2 == 1)
            {
                TempData[status6] = "Complete";
                TempData[submitvalue6] = "Verify Joint-Promoter Detail";
                TempData.Keep();
            }
            else if (JointPromoters.Item2 == 2)
            {
                TempData[status6] = "Pending";
                TempData[submitvalue6] = "Pending";
                TempData.Keep();
            }
            else
            {
                TempData[status6] = "Pending";
                TempData[submitvalue6] = "Pending";
                TempData.Keep();
            }
            #endregion

            //Check agree detail
            #region 
            //Application_ID = 1085;
            ////if (Session["ApplicationId"] != null)
            ////{
            ////    if (Session["ApplicationId"].ToString() != "0")
            ////    {
            ////        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
            ////    }
            ////}
            ////else
            ////{
            ////    return RedirectToAction("SessionExpire", "Account");
            ////}

            Int32 var_agree = model.AgreeDetails(Application_ID);
            TempData["Agree"] = "Pending";
            if (var_agree == 1)//means record exists in all table , so Enable the agree button.
            {
                TempData["Agree"] = "Done";
                TempData.Keep();
            }
            #endregion

            return View();
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
            }
            
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region

            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Application_ID);
            TempData["IsdraftValue"] = IsdraftValue;

            //return View("AgentView");
            //return RedirectToAction("AgentView");
            #endregion

        }
        [HttpPost]
        public ActionResult PromoterProfileConfirm()
        {
            //Int64 Application_ID = 5001;

            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Promoter Profile
            /// </summary>
            /// <returns></returns>



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
            return RedirectToAction("PromoterConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult OtherMemberDetail()
        {
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Promoter Profile
            /// </summary>
            /// <returns></returns>


            bool chkvalue = model.Updateother(Application_ID);
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
            return RedirectToAction("PromoterConfirm");

            #endregion
        }

        [HttpPost]
        public ActionResult ParentEntity()
        {
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Promoter Profile
            /// </summary>
            /// <returns></returns>


            bool chkvalue = model.UpdateParentEntitiy(Application_ID);
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
            //return View("AgentView");
            return RedirectToAction("PromoterConfirm");
            #endregion
        }

        [HttpPost]
        public ActionResult submitExperince()
        {
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Promoter Profile
            /// </summary>
            /// <returns></returns>


            bool chkvalue = model.UpdateExperince(Application_ID);
            if (chkvalue)
            {
                TempData["message4"] = "Confirmed Successfully";
                TempData.Keep();
            }
            else
            {
                TempData["message4"] = "Sorry,No record found! Please try again";
                TempData.Keep();
            }
            //return View("AgentView");
            return RedirectToAction("PromoterConfirm");
            #endregion
        }

        [HttpPost]
        public ActionResult LitigationsDetails()
        {
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Promoter Profile
            /// </summary>
            /// <returns></returns>


            bool chkvalue = model.UpdateLitigations(Application_ID);
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
            //return View("AgentView");
            return RedirectToAction("PromoterConfirm");
            #endregion
        }

        [HttpPost]
        public ActionResult DocumentsDetails()
        {
            Int64 Application_ID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  Confirmation of  Promoter Profile
            /// </summary>
            /// <returns></returns>


            bool chkvalue = model.UpdateDocumentsDetails(Application_ID);
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
            return RedirectToAction("PromoterConfirm");
            #endregion
        }

        [HttpPost]
        public ActionResult JointPromotersDetails()
        {
            TempData["messageJPrm"] = "Joint Promoters, If Any! Please try again";
            TempData.Keep();

            return RedirectToAction("JointPromoter_ReviewConfirmDetail", "PromoterConfirm");
        }

        [HttpPost]
        public ActionResult Btn_Agree()
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
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

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
                TempData["PromoterRegDiaryNumber_Name"] = "Your Application successfully Submitted with diary number : " + Profile + " keep it for future reference ";
            else
                TempData["PromoterRegDiaryNumber_Name"] = "Sorry,Your Application is pending";
            #endregion
            // return RedirectToAction("PromoterConfirm");
            return View("PromoterConfirm");

        }
        #endregion

        //Review and Confirm Joint-Promoter Profile
        #region Joint-Promoter Profile Detail
        [HttpGet]
        public ActionResult JointPromoter_ReviewConfirmDetail()
        {           
            string userRole = string.Empty;
            var userID = User.Identity.GetUserId();

            Int64 Application_ID = 0;
            Int32 Application_Type = 0;
            Int64 JointPromoterID = 0;
            Int32 JointPromoterType = 0;
            string JointPromoter_displayName = string.Empty;
            string RegistrationNumber = string.Empty;
            string User_Error = string.Empty;

            ClsPrp_JointPromoter_Confirm_ReviewMaster prpReviewJPrm = new ClsPrp_JointPromoter_Confirm_ReviewMaster();
            ClsMethod_JointPromoter_ReviewMaster objdis = new ClsMethod_JointPromoter_ReviewMaster();
            ClsMethod_JointPromoter_ReviewConfirm objRC = new ClsMethod_JointPromoter_ReviewConfirm();

            #region Set All-Parms

            UID = User.Identity.GetUserId();
            UserNam = User.Identity.Name;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_ID = Convert.ToInt64(Session["ApplicationId"]);                    
                }
                if (Session["User_Type"].ToString() != "0")
                {                    
                    Application_Type = Convert.ToInt32(Session["User_Type"]);
                }                
                // ALGO - check and verify
                if (Application_ID != 0 && Application_Type != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null && Session["jointpromoter_Name"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            JointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            JointPromoterType = Convert.ToInt32(Session["jointpromoter_Type"]);                            
                        }
                        if (Session["jointpromoter_Name"].ToString() != "0")
                        {                            
                            JointPromoter_displayName = Convert.ToString(Session["jointpromoter_Name"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    // NA Case :- Error (Mapping error between renewal_ID)
                    // return RedirectToAction("JointPromoterNA", "PromoterConfirm");
                    User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            #region movement- JointPromoter Detail
            try
            {                
                ClsMethod_JointPromoter_ReviewConfirm sdbYN = new ClsMethod_JointPromoter_ReviewConfirm();
                Tuple<string, Int32> JointPromoterYN = sdbYN.JointPromoter_YN_TrackRecordLitigations_ByID(Application_ID, Application_Type, UID, UserNam);
                if (JointPromoterYN.Item1 == "N" && JointPromoterYN.Item2 == 0)
                {
                    return RedirectToAction("JointPromoterNA", "PromoterConfirm");
                }
            }
            catch (Exception ex)
            {
                string retYN = ex.ToString();
            }
            #endregion

            Int64 Flag = 0;
            prpReviewJPrm.JointPromoter_list = objdis.FillDropdown_JointPromoterDetails_ByAppId(Application_ID, Application_Type, RegistrationNumber, Flag, UserNam);
            TempData["ReviewJPrmMasterlist"] = prpReviewJPrm.JointPromoter_list; TempData.Keep();

            foreach (var item in prpReviewJPrm.JointPromoter_list)
            {
                prpReviewJPrm.Related_JointPromoter_ID = item.Related_JointPromoter_ID;
                prpReviewJPrm.Related_JointPromoter_Type = item.Related_JointPromoter_Type;
                //prpReviewJPrm.Related_JointPromoter_DiaryNumber = String.Concat(item.Related_JointPromoter_Name, " (" , item.Related_JointPromoter_DiaryNumber, ")");
                prpReviewJPrm.Related_JointPromoter_DiaryNumber = item.Related_JointPromoter_DiaryNumber;
                prpReviewJPrm.Related_JointPromoter_Name = item.Related_JointPromoter_Name;
                prpReviewJPrm.Related_RegistrationNumber = item.Related_RegistrationNumber;

                prpReviewJPrm.Related_Promoter_DiaryNumber = item.Related_Promoter_DiaryNumber;
                prpReviewJPrm.Related_Promoter_ID = item.Related_Promoter_ID;
                prpReviewJPrm.Related_Promoter_Type = item.Related_Promoter_Type;
                prpReviewJPrm.Related_Promoter_Name = item.Related_Promoter_Name;

                prpReviewJPrm.Registration_OtherMember_YN_Flag = item.Registration_OtherMember_YN_Flag;
                prpReviewJPrm.Registration_OtherParentEntity_YN_Flag = item.Registration_OtherParentEntity_YN_Flag;
                prpReviewJPrm.Registration_OtherExperience_YN_Flag = item.Registration_OtherExperience_YN_Flag;
                prpReviewJPrm.Registration_OtherLitigations_YN_Flag = item.Registration_OtherLitigations_YN_Flag;

                prpReviewJPrm.A_Column = item.A_Column;
                prpReviewJPrm.B_Column = item.B_Column;
                prpReviewJPrm.C_Column = item.C_Column;

                prpReviewJPrm.IsActive = item.IsActive;
                prpReviewJPrm.IsDraft = item.IsDraft;
                prpReviewJPrm.IsLock = item.IsLock;
                prpReviewJPrm.IsFlag = item.IsFlag;
                prpReviewJPrm.IsPublicView = item.IsPublicView;
                prpReviewJPrm.IsConditional = item.IsConditional;
                prpReviewJPrm.IsDraftMember = item.IsDraftMember;
            }

            if (prpReviewJPrm.JointPromoter_list.Count <= 0)
            {
                Session["jointpromoter_Id"] = Convert.ToInt64("0");
                Session["jointpromoter_Type"] = Convert.ToInt32("0");
                Session["jointpromoter_Name"] = Convert.ToString("NA");
            }         

            if (Session["jointpromoter_Id"] == null && Session["jointpromoter_Type"] == null)
            {
                Session["jointpromoter_Id"] = Convert.ToInt64("0");
                Session["jointpromoter_Type"] = Convert.ToInt32("0");
            }

            if (Session["jointpromoter_Name"] == null)
            {
                Session["jointpromoter_Name"] = Convert.ToString("NA");
            }

            if (Session["ReviewOtherExperience_YN_Flag"] == null && Session["ReviewOtherLitigations_YN_Flag"] == null)
            {
                Session["ReviewOtherExperience_YN_Flag"] = Convert.ToString("N");
                Session["ReviewOtherLitigations_YN_Flag"] = Convert.ToString("N");
            }
            #endregion

            #region Temp-Data Parms
            TempData["statusFlag_JointPromoterProfile"] = string.Empty;
            TempData["submitvalueFlag_JointPromoterProfile"] = string.Empty;
            TempData["status_JointPromoterProfile"] = string.Empty;
            TempData["message_JointPromoterProfile"] = string.Empty;
            TempData["submitvalue_JointPromoterProfile"] = string.Empty;

            TempData["statusFlag_JointPromoterLitigations"] = string.Empty;
            TempData["submitvalueFlag_JointPromoterLitigations"] = string.Empty;
            TempData["status_JointPromoterLitigations"] = string.Empty;
            TempData["message_JointPromoterLitigations"] = string.Empty;
            TempData["submitvalue_JointPromoterLitigations"] = string.Empty;


            TempData["JointPromoterAgree"] = string.Empty;
            TempData["JointPromoter_RegDiaryNumber_Name"] = string.Empty;

            TempData["JointPromoter_displayName"] = string.Empty;
            TempData["JointPromoter_displayType"] = string.Empty;
            #endregion

            if (Session["jointpromoter_Id"] == null || Session["jointpromoter_Type"] == null || Session["ApplicationId"] == null || Session["User_Type"] == null)
            {
                TempData["JointPromoterAgree"] = "intialize";
            }
            else
            {
                //For showing selected review reference record after postback
                TempData["SelectedReviewJPrmListValue"] = JointPromoterID.ToString(); TempData.Keep();
                prpReviewJPrm.Related_JointPromoter_ID = Convert.ToInt64(JointPromoterID);

                TempData["JointPromoter_displayName"] = Convert.ToString(Session["jointpromoter_Name"]);
                TempData["JointPromoter_displayType"] = Convert.ToInt32(Session["jointpromoter_Type"]) == 2 ? "Other Than Individual" : "Individual";
                TempData.Keep();

                Int32 countFlag = 0;
                if (Convert.ToInt64(JointPromoterID) > 0)
                {
                    countFlag = 1;
                }

                //START (Extract-Status-Count)
                #region Check count in Joint-Promoter Profile
                //TypeProfile/statusFlag/submitFlag
                Tuple<Int32, Int32, Int32> JointPromoter_Profile = objRC.JointPromoter_Count_Profile(Application_ID, Application_Type, JointPromoterID, JointPromoterType, countFlag, UserNam);

                //list-Joint-Promoter Profile Count
                if (JointPromoter_Profile.Item1 == 1 || JointPromoter_Profile.Item1 == 2)
                {
                    TempData["message_JointPromoterProfile"] = string.Empty;
                    if (JointPromoter_Profile.Item2 == 1)
                    {
                        TempData["statusFlag_JointPromoterProfile"] = "Complete";
                        TempData["status_JointPromoterProfile"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_JointPromoterProfile"] = "Pending";
                        TempData["status_JointPromoterProfile"] = "Pending";
                        TempData.Keep();
                    }

                    if (JointPromoter_Profile.Item3 == 2)
                    {
                        TempData["submitvalueFlag_JointPromoterProfile"] = "Complete";
                        TempData["submitvalue_JointPromoterProfile"] = "Confirm Joint-Promoter Profile";
                        TempData.Keep();
                    }
                    else if (JointPromoter_Profile.Item3 == 1)
                    {
                        TempData["submitvalueFlag_JointPromoterProfile"] = "Confirmed";
                        TempData["submitvalue_JointPromoterProfile"] = "Already Confirmed Joint-Promoter Profile";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_JointPromoterProfile"] = "Pending";
                        TempData["submitvalue_JointPromoterProfile"] = "Pending";
                        TempData.Keep();
                    }
                }
                #endregion

                #region Check count in list-TrackRecord-Litigations
                //TypeExperienceYN/TypeLitigationsYN/statusFlag/submitFlag
                Tuple<Int32, Int32, Int32, Int32> TrackRecord_Litigations = objRC.JointPromoter_Count_TrackRecordLitigations(Application_ID, Application_Type, JointPromoterID, JointPromoterType, countFlag, UserNam);

                //list-TrackRecord-Litigations Count
                if (TrackRecord_Litigations.Item1 == 1 || TrackRecord_Litigations.Item2 == 1)
                {
                    TempData["message_JointPromoterLitigations"] = string.Empty;
                    if (TrackRecord_Litigations.Item3 == 1)
                    {
                        TempData["statusFlag_JointPromoterLitigations"] = "Complete";
                        TempData["status_JointPromoterLitigations"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_JointPromoterLitigations"] = "Pending";
                        TempData["status_JointPromoterLitigations"] = "Pending";
                        TempData.Keep();
                    }

                    if (TrackRecord_Litigations.Item4 == 2)
                    {
                        TempData["submitvalueFlag_JointPromoterLitigations"] = "Complete";
                        TempData["submitvalue_JointPromoterLitigations"] = "Confirm Joint-Promoter Litigation(s)";
                        TempData.Keep();
                    }
                    else if (TrackRecord_Litigations.Item4 == 1)
                    {
                        TempData["submitvalueFlag_JointPromoterLitigations"] = "Confirmed";
                        TempData["submitvalue_JointPromoterLitigations"] = "Already Confirmed Other Litigation(s)";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_JointPromoterLitigations"] = "Pending";
                        TempData["submitvalue_JointPromoterLitigations"] = "Pending";
                        TempData.Keep();
                    }
                }
                #endregion
                //END (Extract-Status-Count)

                //Check agree detail
                #region Joint-Promoter (Agree)

                Int32 varJPRM_agree = objRC.JointPromoter_Count_AgreeDetails(Application_ID, Application_Type, JointPromoterID, JointPromoterType, countFlag, UserNam);                
                TempData["JointPromoterAgree"] = "Pending";
                if (varJPRM_agree == 1)//means record exists in all table , so Enable the agree button.
                {
                    TempData["JointPromoterAgree"] = "Done";
                    TempData.Keep();
                }
                #endregion

            }

            ////check experince is yes? and litigation is yes against that project? and Enable litigation action link 
            //Session["User_JointPromoter_Litigations"] = model.Litigationsifany_Application_ID(Application_ID);

            //Check Isdraft value From Diary Number table
            //Get_Isdraftvalue_FromDiaryNumber();
            Get_JointPromoter_Isdraftvalue_FromDiaryNumber();

            return View("JointPromoter_ReviewConfirmDetail", prpReviewJPrm);
        }

        [HttpPost]
        public ActionResult JointPromoter_Option_ReviewConfirmDetail(ClsPrp_JointPromoter_Confirm_ReviewMaster smodel, FormCollection collection)
        {
            Int64 Application_ID = 0;
            Int32 Application_Type = 0;
            Int64 JointPromoterID = 0;
            Int32 JointPromoterType = 0;
            string JointPromoterName = "NA";
            string User_OtherMember_YN_Flag = "N";
            string User_OtherParentEntity_YN_Flag = "N";
            string User_OtherExperience_YN_Flag = "N";
            string User_OtherLitigations_YN_Flag = "N";            
            string User_Error = string.Empty;
            string UserName = string.Empty;

            var userID = User.Identity.GetUserId();
            UserName = User.Identity.Name;

            ClsPrp_JointPromoter_ExtractDetails_ReviewMaster prpgetObj = new ClsPrp_JointPromoter_ExtractDetails_ReviewMaster();
            ClsMethod_JointPromoter_ReviewMaster objdis = new ClsMethod_JointPromoter_ReviewMaster();

            try
            {
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        Application_ID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        Application_Type = Convert.ToInt32(Session["User_Type"]);
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    //return RedirectToAction("SessionExpire", "Account");
                    User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";                    
                }

                if (smodel.Related_JointPromoter_ID != 0)
                {
                    Int32 Flag = 0;
                    JointPromoterID = smodel.Related_JointPromoter_ID;
                    JointPromoterType = smodel.Related_JointPromoter_Type;
                    if (Application_ID != 0 && Application_Type != 0)
                    {
                        prpgetObj.JointPromoter_extractlist = objdis.FillDropdown_ExtarctDetails_RenewalAgent_ByAppId(Application_ID, Application_Type, JointPromoterID, JointPromoterType, Flag, UserName);
                        if (prpgetObj.JointPromoter_extractlist.Count > 0)
                        {
                            JointPromoterID = Convert.ToInt32(prpgetObj.JointPromoter_extractlist[0].Related_JointPromoter_ID);
                            JointPromoterType = Convert.ToInt32(prpgetObj.JointPromoter_extractlist[0].Related_JointPromoter_Type);
                            JointPromoterName = Convert.ToString(prpgetObj.JointPromoter_extractlist[0].Related_JointPromoter_Name);
                            User_OtherMember_YN_Flag = Convert.ToString(prpgetObj.JointPromoter_extractlist[0].Registration_OtherMember_YN_Flag);
                            User_OtherParentEntity_YN_Flag = Convert.ToString(prpgetObj.JointPromoter_extractlist[0].Registration_OtherParentEntity_YN_Flag);
                            User_OtherExperience_YN_Flag = Convert.ToString(prpgetObj.JointPromoter_extractlist[0].Registration_OtherExperience_YN_Flag);
                            User_OtherLitigations_YN_Flag = Convert.ToString(prpgetObj.JointPromoter_extractlist[0].Registration_OtherLitigations_YN_Flag);
                        }
                    }
                    Session["jointpromoter_Id"] = Convert.ToInt64(JointPromoterID);
                    Session["jointpromoter_Type"] = Convert.ToInt32(JointPromoterType);
                    Session["jointpromoter_Name"] = Convert.ToString(JointPromoterName);

                    Session["ReviewOtherExperience_YN_Flag"] = Convert.ToString(User_OtherExperience_YN_Flag);
                    Session["ReviewOtherLitigations_YN_Flag"] = Convert.ToString(User_OtherLitigations_YN_Flag);
                }
                else
                {
                    Session["jointpromoter_Id"] = null;
                    Session["jointpromoter_Type"] = null;
                    Session["jointpromoter_Name"] = null;

                    Session["ReviewOtherExperience_YN_Flag"] = Convert.ToString("N");
                    Session["ReviewOtherLitigations_YN_Flag"] = Convert.ToString("N");
                }
                return RedirectToAction("JointPromoter_ReviewConfirmDetail", prpgetObj);
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                return RedirectToAction("JointPromoter_ReviewConfirmDetail", prpgetObj);
            }
        }


        #region Review-Confirm-Actions
        [HttpPost]
        public ActionResult ReviewConfirm_JointPromoterProfile(ClsPrp_JointPromoter_Confirm_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_PromoterID = 0;
            rcp_TypeOfPromoter = 0;
            rcp_JointPromoterID = 0;
            rcp_JointPromoterType = 0;
            rcp_JointPromoterName = "NA";
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_PromoterID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfPromoter = Convert.ToInt32(Session["User_Type"]);
                }
                // ALGO - check and verify
                if (rcp_PromoterID != 0 && rcp_TypeOfPromoter != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null && Session["jointpromoter_Name"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            rcp_JointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            rcp_JointPromoterType = Convert.ToInt32(Session["jointpromoter_Type"]);
                        }
                        if (Session["jointpromoter_Name"].ToString() != "0")
                        {
                            rcp_JointPromoterName = Convert.ToString(Session["jointpromoter_Name"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    return RedirectToAction("JointPromoterNA", "PromoterConfirm");
                    //return RedirectToAction("SessionExpire", "Account");
                    //rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string IndOTIndProfile = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_JointPromoter_ReviewConfirm modelDB = new ClsMethod_JointPromoter_ReviewConfirm();
            #region Update Profile
            try
            {
                // Individual Profile
                if (rcp_JointPromoterType == 1)
                {
                    IndOTIndProfile = TempData["statusFlag_JointPromoterProfile"].ToString();
                    TempData.Keep();
                    if (IndOTIndProfile == "Complete")
                    {
                        string valueother = TempData["submitvalueFlag_JointPromoterProfile"].ToString();
                        TempData.Keep();

                        if (valueother == "Complete")
                        { 
                            bool chkvalue = modelDB.Update_JointPromoter_IndOTIndProfile(rcp_PromoterID, rcp_TypeOfPromoter, rcp_JointPromoterID, rcp_JointPromoterType, setFlag, rcp_UserNam);
                            if (chkvalue)
                            {
                                TempData["message_JointPromoterProfile"] = "Confirmed Successfully";
                            }
                            else
                            {
                                TempData["message_JointPromoterProfile"] = "Sorry, No record found! Please try again";
                            }
                            return RedirectToAction("JointPromoter_ReviewConfirmDetail");
                        }
                    }
                }
                // OtherThanIndividual Profile
                if (rcp_JointPromoterType == 2)
                {
                    IndOTIndProfile = TempData["statusFlag_JointPromoterProfile"].ToString();
                    TempData.Keep();
                    if (IndOTIndProfile == "Complete")
                    {
                        string valueother = TempData["submitvalueFlag_JointPromoterProfile"].ToString();
                        TempData.Keep();

                        if (valueother == "Complete")
                        {
                            bool chkvalue = modelDB.Update_JointPromoter_IndOTIndProfile(rcp_PromoterID, rcp_TypeOfPromoter, rcp_JointPromoterID, rcp_JointPromoterType, setFlag, rcp_UserNam);
                            if (chkvalue)
                            {
                                TempData["message_JointPromoterProfile"] = "Confirmed Successfully";
                            }
                            else
                            {
                                TempData["message_JointPromoterProfile"] = "Sorry, No record found! Please try again";
                            }
                            return RedirectToAction("JointPromoter_ReviewConfirmDetail");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("JointPromoter_ReviewConfirmDetail");
        }

        [HttpPost]
        public ActionResult ReviewConfirm_JointPromoterLitigations(ClsPrp_JointPromoter_Confirm_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_PromoterID = 0;
            rcp_TypeOfPromoter = 0;
            rcp_JointPromoterID = 0;
            rcp_JointPromoterType = 0;
            rcp_JointPromoterName = "NA";
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_PromoterID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfPromoter = Convert.ToInt32(Session["User_Type"]);
                }
                // ALGO - check and verify
                if (rcp_PromoterID != 0 && rcp_TypeOfPromoter != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null && Session["jointpromoter_Name"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            rcp_JointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            rcp_JointPromoterType = Convert.ToInt32(Session["jointpromoter_Type"]);
                        }
                        if (Session["jointpromoter_Name"].ToString() != "0")
                        {
                            rcp_JointPromoterName = Convert.ToString(Session["jointpromoter_Name"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    return RedirectToAction("JointPromoterNA", "PromoterConfirm");
                    //return RedirectToAction("SessionExpire", "Account");
                    //rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string OtherMember = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_JointPromoter_ReviewConfirm modelDB = new ClsMethod_JointPromoter_ReviewConfirm();
            #region Update TrackRecord-Litigations
            try
            {
                OtherMember = TempData["statusFlag_JointPromoterLitigations"].ToString();
                TempData.Keep();
                if (OtherMember == "Complete")
                {
                    string valueother = TempData["submitvalueFlag_JointPromoterLitigations"].ToString();
                    TempData.Keep();

                    if (valueother == "Complete")
                    {
                        bool chkvalue = modelDB.Update_JointPromoter_TrackRecordLitigations(rcp_PromoterID, rcp_TypeOfPromoter, rcp_JointPromoterID, rcp_JointPromoterType, setFlag, rcp_UserNam);
                        if (chkvalue)
                        {
                            TempData["message_JointPromoterLitigations"] = "Confirmed Successfully";
                        }
                        else
                        {
                            TempData["message_JointPromoterLitigations"] = "Sorry, No record found! Please try again";
                        }
                        return RedirectToAction("JointPromoter_ReviewConfirmDetail");
                    }
                }
            }
            catch (Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("JointPromoter_ReviewConfirmDetail");
        }
        #endregion

        [HttpPost]
        public ActionResult BtnJointPromoter_ReviewConfirm_SubmitAgree(ClsPrp_JointPromoter_Confirm_ReviewMaster smodel) //async Task<ActionResult>
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_PromoterID = 0;
            rcp_TypeOfPromoter = 0;
            rcp_JointPromoterID = 0;
            rcp_JointPromoterType = 0;
            rcp_JointPromoterName = "NA";
            rcp_Error = string.Empty;

            string _JointPromoterDiaryNumber = string.Empty;
            string _PromoterDiaryNumber = string.Empty;
            string _PromoterName = string.Empty;
            Int32 _OtherMember_YN_Flag = 0;
            Int32 _OtherParentEntity_YN_Flag = 0;
            Int32 _OtherExperience_YN_Flag = 0;
            Int32 _OtherLitigations_YN_Flag = 0;
            string Profile = null;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_PromoterID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfPromoter = Convert.ToInt32(Session["User_Type"]);
                }
                // ALGO - check and verify
                if (rcp_PromoterID != 0 && rcp_TypeOfPromoter != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null && Session["jointpromoter_Name"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            rcp_JointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            rcp_JointPromoterType = Convert.ToInt32(Session["jointpromoter_Type"]);
                        }
                        if (Session["jointpromoter_Name"].ToString() != "0")
                        {
                            rcp_JointPromoterName = Convert.ToString(Session["jointpromoter_Name"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    return RedirectToAction("JointPromoterNA", "PromoterConfirm");
                    //return RedirectToAction("SessionExpire", "Account");
                    //rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion
            try
            {
                Int32 vFlag = 0;
                string vRegistrationNumber = string.Empty;
                string vRegistrationRemarks = string.Empty;

                _JointPromoterDiaryNumber = String.IsNullOrEmpty(smodel.Related_JointPromoter_DiaryNumber) ? string.Empty : smodel.Related_JointPromoter_DiaryNumber.ToString();
                _PromoterName = String.IsNullOrEmpty(smodel.Related_Promoter_Name) ? string.Empty : smodel.Related_Promoter_Name.ToString();
                _OtherMember_YN_Flag = String.IsNullOrEmpty(smodel.Registration_OtherMember_YN_Flag) ? 0 : Convert.ToInt32(smodel.Registration_OtherMember_YN_Flag.ToString());
                _OtherParentEntity_YN_Flag = String.IsNullOrEmpty(smodel.Registration_OtherParentEntity_YN_Flag) ? 0 : Convert.ToInt32(smodel.Registration_OtherParentEntity_YN_Flag.ToString());
                _OtherExperience_YN_Flag = String.IsNullOrEmpty(smodel.Registration_OtherExperience_YN_Flag) ? 0 : Convert.ToInt32(smodel.Registration_OtherExperience_YN_Flag.ToString());
                _OtherLitigations_YN_Flag = String.IsNullOrEmpty(smodel.Registration_OtherLitigations_YN_Flag) ? 0 : Convert.ToInt32(smodel.Registration_OtherLitigations_YN_Flag.ToString());              
                
                ClsMethod_JointPromoter_ReviewConfirm modelSave = new ClsMethod_JointPromoter_ReviewConfirm();                
                Profile = modelSave.Update_JointPromoter_AgreeDetails(rcp_JointPromoterID, rcp_JointPromoterType, _JointPromoterDiaryNumber, rcp_JointPromoterName, vRegistrationNumber, _PromoterDiaryNumber, rcp_PromoterID, rcp_TypeOfPromoter, _PromoterName, _OtherMember_YN_Flag, _OtherParentEntity_YN_Flag, _OtherExperience_YN_Flag, _OtherLitigations_YN_Flag, vRegistrationRemarks, vFlag, rcp_UID, rcp_UserNam);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }

            if (Profile != null)
            {
                //Test Case //rcp_UID = "4d2bafc5-1aad-4921-967b-8eb9a9be9a83";
                TempData["JointPromoter_RegDiaryNumber_Name"] = "Your Application successfully Submitted with diary number : " + Profile + " keep it for future reference ";
                //await UserManager.SendEmailAsync(rcp_UID, "RERA, Punjab - Application Submitted for Renewal of Registration (Real-estate Agent)", "<b>Dear " + rcp_UserNam + "</b>,<br /><br />Your application for renewal of registration (Form-J) of <b>Real Estate Agent</b> with Application ID <b>" + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />Applicants are advised to visit the web-portal (RERA, Punjab) regularly for updates. Kindly keep the hard copy of the application form along with the uploaded documents for future reference. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
            }
            else
            {
                TempData["JointPromoter_RegDiaryNumber_Name"] = "Sorry,Your Application is pending";
            }

            return View("JointPromoter_ReviewConfirmDetail");
        }

        [HttpGet]
        public ActionResult JointPromoterNA()
        {
            return View("JointPromoterNA");
        }

        public void Get_JointPromoter_Isdraftvalue_FromDiaryNumber()
        {
            Int64 _Promoter_ID = 0;
            Int32 _Promoter_Type = 0;
            Int64 _JointPromoter_ID = 0;
            Int32 _JointPromoter_Type = 0;

            #region All-Setters
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    _Promoter_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    _Promoter_Type = Convert.ToInt32(Session["User_Type"]);
                }
                // ALGO - check and verify
                if (_Promoter_ID != 0 && _Promoter_Type != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            _JointPromoter_ID = Convert.ToInt64(Session["jointpromoter_Id"]);
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            _JointPromoter_Type = Convert.ToInt32(Session["jointpromoter_Type"]);
                        }
                    }
                }
            }
            #endregion

            ClsMethod_JointPromoter_ReviewConfirm modelVerify = new ClsMethod_JointPromoter_ReviewConfirm();

            Int32 IsdraftValue = modelVerify.JointPromoter_Isdraftvalue_FromDiaryNumber(_Promoter_ID, _Promoter_Type, _JointPromoter_ID, _JointPromoter_Type);
            TempData["JointPromoter_IsdraftValue"] = IsdraftValue;

        }
        #endregion

    }
}