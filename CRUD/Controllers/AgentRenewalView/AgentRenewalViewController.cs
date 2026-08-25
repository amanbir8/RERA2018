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
using CRUD.Models.AgentRenewal;

namespace CRUD.Controllers.AgentRenewalView
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentRenewalViewController : Controller
    {

        #region Pre-requisite Settings
        string rcp_UID = string.Empty;
        string rcp_UserNam = string.Empty;
        Int64 rcp_AgentID = 0;
        Int32 rcp_TypeOfAgent = 0;
        Int64 rcp_RenewalAgentID = 0;
        Int32 rcp_RenewalSequenceID = 0;
        Int32 rcp_RenewalAgentYear = 0;
        string rcp_Related_RERAnumberRegistration = string.Empty;
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

        #region Agent_Renewal ReviewConfirm_Detail
        [HttpGet]
        public ActionResult AgentRenewal_IO_ReviewConfirmDetail()
        {
            #region extract-Params
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;

            Int32 User_KeyID = 0;
            string ynOtherMember = "N";
            string ynOtherRERA = "N";
            string UserName = string.Empty;
            string User_Error = string.Empty;

            Clsprp_AgentRenewal_StepPreviousRegistration prpAgent = new Clsprp_AgentRenewal_StepPreviousRegistration();
            ClsMethod_AgentRenewal_VerifyRegistrationNumber objDB = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();

            try
            {
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        User_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        //Ind Case: "1" //OTInd Case: "2" 
                        User_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    //Algo New_Registration/Modify/Update/Yet_to_be_Registered_Case
                    if (User_AgentID != 0 && User_TypeOfAgent != 0)
                    {
                        User_KeyID = 5; //review-confirm
                        ynOtherMember = "Y";
                        ynOtherRERA = "Y";
                        prpAgent.AgentStepRenewal = objDB.Display_AgentRenewal_StepPreviousRegistrationByID(User_AgentID, User_TypeOfAgent, User_KeyID, ynOtherMember, ynOtherRERA, UserName);
                        foreach (var item in prpAgent.AgentStepRenewal)
                        {
                            prpAgent.AgentRenewal_StepPreviousRegistration_IndexID = item.AgentRenewal_StepPreviousRegistration_IndexID;
                            prpAgent.AgentRenewal_StepPreviousRegistration_ID = item.AgentRenewal_StepPreviousRegistration_ID;

                            // Registration Number
                            prpAgent.RERAnumberRegistration = item.RERAnumberRegistration;

                            // Agent ID
                            prpAgent.Agent_ID = item.Agent_ID;
                            prpAgent.Agent_Type = item.Agent_Type;
                            prpAgent.Is_YesNo_AgentID_Flag = item.Is_YesNo_AgentID_Flag;

                            // Agent Renewal ID
                            prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                            prpAgent.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                            prpAgent.Renewal_OrderSequence = item.Renewal_OrderSequence;
                            prpAgent.Renewal_OrderSequence_Name = item.Renewal_OrderSequence_Name;
                            prpAgent.Is_YesNo_RenewalAgentID_Flag = item.Is_YesNo_RenewalAgentID_Flag;
                            prpAgent.Is_YesNo_RenewalAgentRegistered_Flag = item.Is_YesNo_RenewalAgentRegistered_Flag;

                            prpAgent.Is_YesNo_RenewalAgent_OtherMembers = item.Is_YesNo_RenewalAgent_OtherMembers;
                            prpAgent.Is_YesNo_RenewalAgent_OtherStateUTnumber = item.Is_YesNo_RenewalAgent_OtherStateUTnumber;

                            // Agent Renewal Permission Flag
                            prpAgent.Is_YesNo_ValidforAgentRenewal_Flag = item.Is_YesNo_ValidforAgentRenewal_Flag;

                            prpAgent.A_column = item.A_column;
                            prpAgent.B_column = item.B_column;
                            prpAgent.IsLock = item.IsLock;
                            prpAgent.IsPublicView = item.IsPublicView;
                        }

                        if (prpAgent.Is_YesNo_ValidforAgentRenewal_Flag == 21)
                        {
                            if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                            {
                                if (Session["RenewalAgentId"].ToString() != "0")
                                {
                                    User_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                                }
                                if (Session["RenewalSequenceId"].ToString() != "0")
                                {
                                    User_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                                }
                                if (Session["RenewalAgentYear"].ToString() != "0")
                                {
                                    User_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                                }
                            }
                            else
                            {
                                Session["RenewalAgentId"] = Convert.ToInt64(prpAgent.Related_RenewalAgent_ID);
                                Session["RenewalSequenceId"] = Convert.ToInt32(prpAgent.Renewal_OrderSequence);
                                Session["RenewalAgentYear"] = Convert.ToInt32(prpAgent.Related_RenewalAgent_Year);
                            }
                            //additional extract-Params
                            Session["RenewalOTIOrgMembers"] = Convert.ToInt32(prpAgent.Is_YesNo_RenewalAgent_OtherMembers);
                            Session["RenewalOtherRERA"] = Convert.ToInt32(prpAgent.Is_YesNo_RenewalAgent_OtherStateUTnumber);

                            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                        }
                        else
                        {
                            //NA Case :- Error (organization member(s) : Not Applicable)
                            User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form submission pending at web-portal. Please sign-in with registered real-estate agent with the Authority.";
                        }                        
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                    prpAgent.B_column = User_Error.ToString();
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }
            #endregion
            return View("AgentRenewal_IO_ReviewConfirmDetail", prpAgent);
        }

        [HttpPost]
        public ActionResult ReviewOption_ReviewConfirmDetail(Clsprp_AgentRenewal_ReviewMaster smodel, FormCollection collection)
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string User_OtherMember_YN_Flag = "N";
            string User_OtherRERA_YN_Flag = "N";
            string UserName = string.Empty;
            string User_Error = string.Empty;

            Clsprp_AgentRenewal_ExtractDetails_ReviewMaster prpgetObj = new Clsprp_AgentRenewal_ExtractDetails_ReviewMaster();
            ClsMethod_AgentRenewal_ReviewMaster objdis = new ClsMethod_AgentRenewal_ReviewMaster();

            try
            {
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        User_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        User_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }                                       
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }

                if (smodel.Related_AgentRenewal_ID != 0)
                {
                    Int32 Flag = 0;
                    User_RenewalAgentID = smodel.Related_AgentRenewal_ID;
                    if (User_AgentID != 0 && User_TypeOfAgent != 0)
                    {
                        prpgetObj.AgentRenewal_extractlist = objdis.FillDropdown_ExtarctDetails_RenewalAgent_ByAppId(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, Flag);
                        if (prpgetObj.AgentRenewal_extractlist.Count > 0)
                        {
                            User_RenewalSequenceID = Convert.ToInt32(prpgetObj.AgentRenewal_extractlist[0].Related_AgentRenewal_SequenceID);
                            User_RenewalAgentYear = Convert.ToInt32(prpgetObj.AgentRenewal_extractlist[0].Related_AgentRenewal_Year);
                            User_OtherMember_YN_Flag = Convert.ToString(prpgetObj.AgentRenewal_extractlist[0].Registration_OtherMember_YN_Flag);
                            User_OtherRERA_YN_Flag = Convert.ToString(prpgetObj.AgentRenewal_extractlist[0].Registration_OtherRERA_YN_Flag);
                        }
                    }
                    Session["RenewalAgentId"] = Convert.ToInt64(User_RenewalAgentID);
                    Session["RenewalSequenceId"] = Convert.ToInt32(User_RenewalSequenceID);
                    Session["RenewalAgentYear"] = Convert.ToInt32(User_RenewalAgentYear);
                    Session["ReviewOtherMember_YN_Flag"] = Convert.ToString(User_OtherMember_YN_Flag);
                    Session["ReviewOtherRERA_YN_Flag"] = Convert.ToString(User_OtherRERA_YN_Flag);
                }
                else
                {
                    Session["RenewalAgentId"] = null;
                    Session["RenewalSequenceId"] = null;
                    Session["RenewalAgentYear"] = null;
                    Session["ReviewOtherMember_YN_Flag"] = Convert.ToString("N");
                    Session["ReviewOtherRERA_YN_Flag"] = Convert.ToString("N");
                }
                return RedirectToAction("AgentRenewal_ReviewConfirmDetail", smodel);
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                return RedirectToAction("AgentRenewal_ReviewConfirmDetail", smodel);
            }
        }

        [HttpGet]
        public ActionResult AgentRenewal_ReviewConfirmDetail()
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string User_Error = string.Empty;

            Clsprp_AgentRenewal_ReviewMaster prpReviewRnA = new Clsprp_AgentRenewal_ReviewMaster();
            ClsMethod_AgentRenewal_ReviewMaster objdis = new ClsMethod_AgentRenewal_ReviewMaster();
            ClsMethod_ReviewConfirm_AgentRenewal_Registration objRC = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    User_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    User_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                //Algo New_Registration/Modify/Update/Yet_to_be_Registered_Case
                if (User_AgentID != 0 && User_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            User_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            User_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            User_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    //NA Case :- Error (Mapping error between renewal_ID)
                    User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
            }

            Int64 Flag = 0;
            prpReviewRnA.AgentRenewal_list = objdis.FillDropdown_RenewalAgentDetails_ByAppId(User_AgentID, User_TypeOfAgent, rcp_Related_RERAnumberRegistration, Flag);
            TempData["ReviewMasterlist"] = prpReviewRnA.AgentRenewal_list; TempData.Keep();

            foreach (var item in prpReviewRnA.AgentRenewal_list)
            {
                //    prpReviewRnA.Related_AgentRenewal_ID = item.Related_AgentRenewal_ID;
                //    prpReviewRnA.Related_AgentRenewal_SequenceID = item.Related_AgentRenewal_SequenceID;
                //    prpReviewRnA.Related_AgentRenewal_Year = item.Related_AgentRenewal_Year;
                //    prpReviewRnA.SequenceID_Name = item.SequenceID_Name;
                //    prpReviewRnA.Reference_Agent_DiaryNumber = item.Reference_Agent_DiaryNumber;
                prpReviewRnA.Registration_Number = item.Registration_Number;                
                prpReviewRnA.Related_Agent_ID = item.Related_Agent_ID;
                prpReviewRnA.Related_Agent_Type = item.Related_Agent_Type;
                prpReviewRnA.Registration_OtherMember_YN_Flag = item.Registration_OtherMember_YN_Flag;
                prpReviewRnA.Registration_OtherRERA_YN_Flag = item.Registration_OtherRERA_YN_Flag;

                prpReviewRnA.IsActive = item.IsActive;
                prpReviewRnA.IsActiveProvider = item.IsActiveProvider;
                prpReviewRnA.IsDraft = item.IsDraft;
                prpReviewRnA.IsLock = item.IsLock;
                prpReviewRnA.IsPublicView = item.IsPublicView;
                prpReviewRnA.IsConditional = item.IsConditional;
                prpReviewRnA.IsDraftMember = item.IsDraftMember;
            }
            if (Session["ReviewOtherMember_YN_Flag"] == null && Session["ReviewOtherRERA_YN_Flag"] == null)
            {
                if (prpReviewRnA.AgentRenewal_list.Count > 0)
                {
                    Session["ReviewOtherMember_YN_Flag"] = Convert.ToString(prpReviewRnA.Registration_OtherMember_YN_Flag);
                    Session["ReviewOtherRERA_YN_Flag"] = Convert.ToString(prpReviewRnA.Registration_OtherRERA_YN_Flag);
                }
                else
                {
                    Session["ReviewOtherMember_YN_Flag"] = Convert.ToString("N");
                    Session["ReviewOtherRERA_YN_Flag"] = Convert.ToString("N");
                }
            }
            #endregion

            #region Temp-Data Parms
            TempData["statusFlag_IndividualProfile"] = string.Empty;
            TempData["submitvalueFlag_IndividualProfile"] = string.Empty;
            TempData["status_IndividualProfile"] = string.Empty;
            TempData["message_IndividualProfile"] = string.Empty;
            TempData["submitvalue_IndividualProfile"] = string.Empty;

            TempData["statusFlag_OTIProfile"] = string.Empty;
            TempData["submitvalueFlag_OTIProfile"] = string.Empty;
            TempData["status_OTIProfile"] = string.Empty;
            TempData["message_OTIProfile"] = string.Empty;
            TempData["submitvalue_OTIProfile"] = string.Empty;

            TempData["statusFlag_OtherMember"] = string.Empty;
            TempData["submitvalueFlag_OtherMember"] = string.Empty;
            TempData["status_OtherMember"] = string.Empty;
            TempData["message_OtherMember"] = string.Empty;
            TempData["submitvalue_OtherMember"] = string.Empty;

            TempData["statusFlag_Document"] = string.Empty;
            TempData["submitvalueFlag_Document"] = string.Empty;
            TempData["status_Document"] = string.Empty;
            TempData["message_Document"] = string.Empty;
            TempData["submitvalue_Document"] = string.Empty;

            TempData["statusFlag_OtherRERA"] = string.Empty;
            TempData["submitvalueFlag_OtherRERA"] = string.Empty;
            TempData["status_OtherRERA"] = string.Empty;
            TempData["message_OtherRERA"] = string.Empty;
            TempData["submitvalue_OtherRERA"] = string.Empty;

            TempData["statusFlag_FeePayment"] = string.Empty;
            TempData["submitvalueFlag_FeePayment"] = string.Empty;
            TempData["status_FeePayment"] = string.Empty;
            TempData["message_FeePayment"] = string.Empty;
            TempData["submitvalue_FeePayment"] = string.Empty;


            TempData["RnAgentAgree"] = string.Empty;
            TempData["RenewalAgent_RegDiaryNumber_Name"] = string.Empty;
            #endregion

            if ((Session["RenewalAgentId"] == null || Session["RenewalSequenceId"] == null || Session["RenewalAgentYear"] == null))
            {
                TempData["RnAgentAgree"] = "intialize";
            }
            else
            {                
                //For showing selected review reference record after postback
                TempData["SelectedReviewListValue"] = User_RenewalAgentID.ToString(); TempData.Keep();
                prpReviewRnA.Related_AgentRenewal_ID = Convert.ToInt64(User_RenewalAgentID);

                Int32 countFlag = 0;
                if(Convert.ToInt64(User_RenewalAgentID)>0)
                {
                    countFlag = 1;
                }
                //START (Extract-Status-Count)
                #region Check count in Agent-Profile
                //TypeProfile/statusFlag/submitFlag
                Tuple <Int32, Int32, Int32> IndOTIndProfile = objRC.AgentRenewal_Count_IndOTIndProfile(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, countFlag, rcp_UserNam);
                
                //Profile Individual Count
                if (IndOTIndProfile.Item1 == 1)
                {
                    TempData["message_IndividualProfile"] = string.Empty;
                    if (IndOTIndProfile.Item2 == 1)
                    {
                        TempData["statusFlag_IndividualProfile"] = "Complete";
                        TempData["status_IndividualProfile"] = "Complete";
                        TempData.Keep();
                    }                    
                    else
                    {
                        TempData["statusFlag_IndividualProfile"] = "Pending";
                        TempData["status_IndividualProfile"] = "Pending";
                        TempData.Keep();
                    }

                    if (IndOTIndProfile.Item3 == 2)
                    {
                        TempData["submitvalueFlag_IndividualProfile"] = "Complete";
                        TempData["submitvalue_IndividualProfile"] = "Confirm Agent Profile";
                        TempData.Keep();
                    }
                    else if (IndOTIndProfile.Item3 == 1)
                    {
                        TempData["submitvalueFlag_IndividualProfile"] = "Confirmed";
                        TempData["submitvalue_IndividualProfile"] = "Already Confirmed Agent Profile";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_IndividualProfile"] = "Pending";
                        TempData["submitvalue_IndividualProfile"] = "Pending";
                        TempData.Keep();
                    }
                }
                //Profile OtherThanIndividual Count
                if (IndOTIndProfile.Item1 == 2)
                {
                    TempData["message_OTIProfile"] = string.Empty;
                    if (IndOTIndProfile.Item2 == 1)
                    {
                        TempData["statusFlag_OTIProfile"] = "Complete";
                        TempData["status_OTIProfile"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_OTIProfile"] = "Pending";
                        TempData["status_OTIProfile"] = "Pending";
                        TempData.Keep();
                    }

                    if (IndOTIndProfile.Item3 == 2)
                    {
                        TempData["submitvalueFlag_OTIProfile"] = "Complete";
                        TempData["submitvalue_OTIProfile"] = "Confirm Agent Profile";
                        TempData.Keep();
                    }
                    else if (IndOTIndProfile.Item3 == 1)
                    {
                        TempData["submitvalueFlag_OTIProfile"] = "Confirmed";
                        TempData["submitvalue_OTIProfile"] = "Already Confirmed Agent Profile";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_OTIProfile"] = "Pending";
                        TempData["submitvalue_OTIProfile"] = "Pending";
                        TempData.Keep();
                    }
                }
                #endregion

                #region Check count in Other-Organization-Members
                //TypeMembers/statusFlag/submitFlag
                Tuple<Int32, Int32, Int32> OtherMembers = objRC.AgentRenewal_Count_OtherOrganizationMembers(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, countFlag, rcp_UserNam);

                //Other-Organization-Members Count
                if (OtherMembers.Item1 == 1)
                {
                    TempData["message_OtherMember"] = string.Empty;
                    if (OtherMembers.Item2 == 1)
                    {
                        TempData["statusFlag_OtherMember"] = "Complete";
                        TempData["status_OtherMember"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_OtherMember"] = "Pending";
                        TempData["status_OtherMember"] = "Pending";
                        TempData.Keep();
                    }

                    if (OtherMembers.Item3 == 2)
                    {
                        TempData["submitvalueFlag_OtherMember"] = "Complete";
                        TempData["submitvalue_OtherMember"] = "Confirm Other Member(s)";
                        TempData.Keep();
                    }
                    else if (OtherMembers.Item3 == 1)
                    {
                        TempData["submitvalueFlag_OtherMember"] = "Confirmed";
                        TempData["submitvalue_OtherMember"] = "Already Confirmed Other Member(s)";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_OtherMember"] = "Pending";
                        TempData["submitvalue_OtherMember"] = "Pending";
                        TempData.Keep();
                    }
                }                
                #endregion

                #region Check count in list-Documents
                //TypeProfile/statusFlag/submitFlag
                Tuple<Int32, Int32, Int32> Documents = objRC.AgentRenewal_Count_Documents(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, countFlag, rcp_UserNam);

                //list-Documents Count
                if (Documents.Item1 == 1 || Documents.Item1 == 2)
                {
                    TempData["message_Document"] = string.Empty;
                    if (Documents.Item2 == 1)
                    {
                        TempData["statusFlag_Document"] = "Complete";
                        TempData["status_Document"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_Document"] = "Pending";
                        TempData["status_Document"] = "Pending";
                        TempData.Keep();
                    }

                    if (Documents.Item3 == 2)
                    {
                        TempData["submitvalueFlag_Document"] = "Complete";
                        TempData["submitvalue_Document"] = "Confirm Agent Document(s)";
                        TempData.Keep();
                    }
                    else if (Documents.Item3 == 1)
                    {
                        TempData["submitvalueFlag_Document"] = "Confirmed";
                        TempData["submitvalue_Document"] = "Already Confirmed Agent Document(s)";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_Document"] = "Pending";
                        TempData["submitvalue_Document"] = "Pending";
                        TempData.Keep();
                    }
                }
                #endregion

                #region Check count in Other-StateUT-RERA
                //TypeOtherRERA/statusFlag/submitFlag
                Tuple<Int32, Int32, Int32> OtherRERA = objRC.AgentRenewal_Count_OtherStateUTRERA(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, countFlag, rcp_UserNam);

                //Other-StateUT-RERA Count
                if (OtherRERA.Item1 == 1)
                {
                    TempData["message_OtherRERA"] = string.Empty;
                    if (OtherRERA.Item2 == 1)
                    {
                        TempData["statusFlag_OtherRERA"] = "Complete";
                        TempData["status_OtherRERA"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_OtherRERA"] = "Pending";
                        TempData["status_OtherRERA"] = "Pending";
                        TempData.Keep();
                    }

                    if (OtherRERA.Item3 == 2)
                    {
                        TempData["submitvalueFlag_OtherRERA"] = "Complete";
                        TempData["submitvalue_OtherRERA"] = "Confirm Other State/UT Registration(s)";
                        TempData.Keep();
                    }
                    else if (OtherRERA.Item3 == 1)
                    {
                        TempData["submitvalueFlag_OtherRERA"] = "Confirmed";
                        TempData["submitvalue_OtherRERA"] = "Already Confirmed Other State/UT Registration(s)";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_OtherRERA"] = "Pending";
                        TempData["submitvalue_OtherRERA"] = "Pending";
                        TempData.Keep();
                    }
                }                
                #endregion

                #region Check count in Registration-Fee-Payment
                //TypeProfile/statusFlag/submitFlag
                Tuple<Int32, Int32, Int32> FeePayment = objRC.AgentRenewal_Count_RegistrationFeePayment(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, countFlag, rcp_UserNam);

                //Registration-Fee-Payment Count
                if (FeePayment.Item1 == 1 || FeePayment.Item1 == 2)
                {
                    TempData["message_FeePayment"] = string.Empty;
                    if (FeePayment.Item2 == 1)
                    {
                        TempData["statusFlag_FeePayment"] = "Complete";
                        TempData["status_FeePayment"] = "Complete";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["statusFlag_FeePayment"] = "Pending";
                        TempData["status_FeePayment"] = "Pending";
                        TempData.Keep();
                    }

                    if (FeePayment.Item3 == 2)
                    {
                        TempData["submitvalueFlag_FeePayment"] = "Complete";
                        TempData["submitvalue_FeePayment"] = "Confirm Registration Fee/Payment";
                        TempData.Keep();
                    }
                    else if (FeePayment.Item3 == 1)
                    {
                        TempData["submitvalueFlag_FeePayment"] = "Confirmed";
                        TempData["submitvalue_FeePayment"] = "Already Confirmed Registration Fee/Payment";
                        TempData.Keep();
                    }
                    else
                    {
                        TempData["submitvalueFlag_FeePayment"] = "Pending";
                        TempData["submitvalue_FeePayment"] = "Pending";
                        TempData.Keep();
                    }
                }                
                #endregion
                //END (Extract-Status-Count)

                //Check agree detail
                #region Renewal-Agent (Agree)
                Int32 var_agree = objRC.AgentRenewal_Count_AgreeDetails(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, countFlag, rcp_UserNam);
                TempData["RnAgentAgree"] = "Pending";
                if (var_agree == 1)//means record exists in all table , so Enable the agree button.
                {
                    TempData["RnAgentAgree"] = "Done";
                    TempData.Keep();
                }
                #endregion
            }

            //Check Isdraft value From Diary Number table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();

            return View("AgentRenewal_ReviewConfirmDetail", prpReviewRnA);
        }
        #endregion

        #region Review-Confirm-Actions
        [HttpPost]
        public ActionResult ReviewConfirmRnAgent_IndOTIndProfile(Clsprp_AgentRenewal_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_AgentID = 0;
            rcp_TypeOfAgent = 0;
            rcp_RenewalAgentID = 0;
            rcp_RenewalSequenceID = 0;
            rcp_RenewalAgentYear = 0;
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                if (rcp_AgentID != 0 && rcp_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            rcp_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            rcp_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            rcp_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string IndOTIndProfile = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_ReviewConfirm_AgentRenewal_Registration modelDB = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
            #region Update Profile
            try
            {
                // Individual Profile
                if (rcp_TypeOfAgent == 1)
                {
                    IndOTIndProfile = TempData["statusFlag_IndividualProfile"].ToString();
                    TempData.Keep();
                    if (IndOTIndProfile == "Complete")
                    {
                        string valueother = TempData["submitvalueFlag_IndividualProfile"].ToString();
                        TempData.Keep();

                        if (valueother == "Complete")
                        {
                            bool chkvalue = modelDB.Update_AR_IndOTIndProfile(rcp_AgentID, rcp_TypeOfAgent, rcp_RenewalAgentID, rcp_RenewalSequenceID, rcp_RenewalAgentYear, setFlag, rcp_UserNam);
                            if (chkvalue)
                            {
                                TempData["message_IndividualProfile"] = "Confirmed Successfully";
                            }
                            else
                            {
                                TempData["message_IndividualProfile"] = "Sorry, No record found! Please try again";
                            }
                            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                        }
                    }
                }
                // OtherThanIndividual Profile
                if (rcp_TypeOfAgent == 2)
                {
                    IndOTIndProfile = TempData["statusFlag_OTIProfile"].ToString();
                    TempData.Keep();
                    if (IndOTIndProfile == "Complete")
                    {
                        string valueother = TempData["submitvalueFlag_OTIProfile"].ToString();
                        TempData.Keep();

                        if (valueother == "Complete")
                        {
                            bool chkvalue = modelDB.Update_AR_IndOTIndProfile(rcp_AgentID, rcp_TypeOfAgent, rcp_RenewalAgentID, rcp_RenewalSequenceID, rcp_RenewalAgentYear, setFlag, rcp_UserNam);
                            if (chkvalue)
                            {
                                TempData["message_OTIProfile"] = "Confirmed Successfully";
                            }
                            else
                            {
                                TempData["message_OTIProfile"] = "Sorry, No record found! Please try again";
                            }
                            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
        }

        [HttpPost]
        public ActionResult ReviewConfirmRnAgent_OtherMembers(Clsprp_AgentRenewal_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_AgentID = 0;
            rcp_TypeOfAgent = 0;
            rcp_RenewalAgentID = 0;
            rcp_RenewalSequenceID = 0;
            rcp_RenewalAgentYear = 0;
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                if (rcp_AgentID != 0 && rcp_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            rcp_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            rcp_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            rcp_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string OtherMember = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_ReviewConfirm_AgentRenewal_Registration modelDB = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
            #region Update Other-Member
            try
            {
                OtherMember = TempData["statusFlag_OtherMember"].ToString();
                TempData.Keep();
                if (OtherMember == "Complete")
                {
                    string valueother = TempData["submitvalueFlag_OtherMember"].ToString();
                    TempData.Keep();

                    if (valueother == "Complete")
                    {
                        bool chkvalue = modelDB.Update_AR_OtherMember(rcp_AgentID, rcp_TypeOfAgent, rcp_RenewalAgentID, rcp_RenewalSequenceID, rcp_RenewalAgentYear, setFlag, rcp_UserNam);
                        if (chkvalue)
                        {
                            TempData["message_OtherMember"] = "Confirmed Successfully";
                        }
                        else
                        {
                            TempData["message_OtherMember"] = "Sorry, No record found! Please try again";
                        }
                        return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                    }
                }
            }
            catch(Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
        }

        [HttpPost]
        public ActionResult ReviewConfirmRnAgent_Documents(Clsprp_AgentRenewal_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_AgentID = 0;
            rcp_TypeOfAgent = 0;
            rcp_RenewalAgentID = 0;
            rcp_RenewalSequenceID = 0;
            rcp_RenewalAgentYear = 0;
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                if (rcp_AgentID != 0 && rcp_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            rcp_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            rcp_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            rcp_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string Document = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_ReviewConfirm_AgentRenewal_Registration modelDB = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
            #region Update Other-Member
            try
            {
                Document = TempData["statusFlag_Document"].ToString();
                TempData.Keep();
                if (Document == "Complete")
                {
                    string valueother = TempData["submitvalueFlag_Document"].ToString();
                    TempData.Keep();

                    if (valueother == "Complete")
                    {
                        bool chkvalue = modelDB.Update_AR_Document(rcp_AgentID, rcp_TypeOfAgent, rcp_RenewalAgentID, rcp_RenewalSequenceID, rcp_RenewalAgentYear, setFlag, rcp_UserNam);
                        if (chkvalue)
                        {
                            TempData["message_Document"] = "Confirmed Successfully";
                        }
                        else
                        {
                            TempData["message_Document"] = "Sorry, No record found! Please try again";
                        }
                        return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                    }
                }
            }
            catch (Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
        }

        [HttpPost]
        public ActionResult ReviewConfirmRnAgent_OtherRERA(Clsprp_AgentRenewal_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_AgentID = 0;
            rcp_TypeOfAgent = 0;
            rcp_RenewalAgentID = 0;
            rcp_RenewalSequenceID = 0;
            rcp_RenewalAgentYear = 0;
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                if (rcp_AgentID != 0 && rcp_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            rcp_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            rcp_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            rcp_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string OtherRERA = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_ReviewConfirm_AgentRenewal_Registration modelDB = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
            #region Update Other-State-RERA
            try
            {
                OtherRERA = TempData["statusFlag_OtherRERA"].ToString();
                TempData.Keep();
                if (OtherRERA == "Complete")
                {
                    string valueother = TempData["submitvalueFlag_OtherRERA"].ToString();
                    TempData.Keep();

                    if (valueother == "Complete")
                    {
                        bool chkvalue = modelDB.Update_AR_OtherStateRERA(rcp_AgentID, rcp_TypeOfAgent, rcp_RenewalAgentID, rcp_RenewalSequenceID, rcp_RenewalAgentYear, setFlag, rcp_UserNam);
                        if (chkvalue)
                        {
                            TempData["message_OtherRERA"] = "Confirmed Successfully";
                        }
                        else
                        {
                            TempData["message_OtherRERA"] = "Sorry, No record found! Please try again";
                        }
                        return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                    }
                }
            }
            catch (Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
        }

        [HttpPost]
        public ActionResult ReviewConfirmRnAgent_FeePayment(Clsprp_AgentRenewal_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;
            rcp_AgentID = 0;
            rcp_TypeOfAgent = 0;
            rcp_RenewalAgentID = 0;
            rcp_RenewalSequenceID = 0;
            rcp_RenewalAgentYear = 0;
            rcp_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rcp_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rcp_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                if (rcp_AgentID != 0 && rcp_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            rcp_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            rcp_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            rcp_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rcp_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            string FeePayment = string.Empty;
            Int32 setFlag = 0;
            ClsMethod_ReviewConfirm_AgentRenewal_Registration modelDB = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
            #region Update Fee-Payment
            try
            {
                FeePayment = TempData["statusFlag_FeePayment"].ToString();
                TempData.Keep();
                if (FeePayment == "Complete")
                {
                    string valueother = TempData["submitvalueFlag_FeePayment"].ToString();
                    TempData.Keep();

                    if (valueother == "Complete")
                    {
                        bool chkvalue = modelDB.Update_AR_PaymentFee(rcp_AgentID, rcp_TypeOfAgent, rcp_RenewalAgentID, rcp_RenewalSequenceID, rcp_RenewalAgentYear, setFlag, rcp_UserNam);
                        if (chkvalue)
                        {
                            TempData["message_FeePayment"] = "Confirmed Successfully";
                        }
                        else
                        {
                            TempData["message_FeePayment"] = "Sorry, No record found! Please try again";
                        }
                        return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
                    }
                }
            }
            catch (Exception ex)
            {
                string strmsg = ex.ToString();
            }
            #endregion
            return RedirectToAction("AgentRenewal_ReviewConfirmDetail");
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult> BtnRnAgent_SubmitAgree(Clsprp_AgentRenewal_ReviewMaster smodel)
        {
            rcp_UID = User.Identity.GetUserId();
            rcp_UserNam = User.Identity.Name;

            Int64 rna_AgentID = 0;
            Int32 rna_TypeOfAgent = 0;
            Int64 rna_RenewalAgentID = 0;
            Int32 rna_RenewalSequenceID = 0;
            Int32 rna_RenewalAgentYear = 0;
            string rna_Error = string.Empty;
            string Profile = null;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                //Algo New_Registration/Modify/Update/Yet_to_be_Registered_Case
                if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");                    
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");                
            }
            #endregion
            try
            {
                string vRegistrationNumber = string.Empty;
                string vRegistrationRemarks = string.Empty;
                string vAgentDiaryNumber = string.Empty;
                Int32 vFlag = 0;
                vRegistrationNumber = String.IsNullOrEmpty(smodel.Registration_Number) ? string.Empty : smodel.Registration_Number.ToString();
                ClsMethod_ReviewConfirm_AgentRenewal_Registration modelSave = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
                Profile = modelSave.Update_AgentRenewalAgreeDetails(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, vAgentDiaryNumber, vRegistrationNumber, vRegistrationRemarks, vFlag, rcp_UID, rcp_UserNam);
            }
            catch(Exception ex)
            {
                string strex = ex.ToString();
            }

            if (Profile != null)
            {
                //Test Case //rcp_UID = "4d2bafc5-1aad-4921-967b-8eb9a9be9a83";
                TempData["RenewalAgent_RegDiaryNumber_Name"] = "Your Application successfully Submitted with diary number : " + Profile + " keep it for future reference ";
                await UserManager.SendEmailAsync(rcp_UID, "RERA, Punjab - Application Submitted for Renewal of Registration (Real-estate Agent)", "<b>Dear " + rcp_UserNam + "</b>,<br /><br />Your application for renewal of registration (Form-J) of <b>Real Estate Agent</b> with Application ID <b>" + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />Applicants are advised to visit the web-portal (RERA, Punjab) regularly for updates. Kindly keep the hard copy of the application form along with the uploaded documents for future reference. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
            }
            else
            {
                TempData["RenewalAgent_RegDiaryNumber_Name"] = "Sorry,Your Application is pending";
            }

            return View("AgentRenewal_ReviewConfirmDetail");
        }

        public void RenewalAgent_GetIsdraftvalue_FromDiaryNumber()
        {
            rcp_UserNam = User.Identity.Name;
            Int64 dn_AgentID = 0;
            Int32 dn_TypeOfAgent = 0;
            Int64 dn_RenewalAgentID = 0;
            Int32 dn_RenewalSequenceID = 0;
            Int32 dn_RenewalAgentYear = 0;
            Int32 extractFlag = 0;
            string dn_Error = string.Empty;

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    dn_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    dn_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                }
                if (dn_AgentID != 0 && dn_TypeOfAgent != 0)
                {
                    if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                    {
                        if (Session["RenewalAgentId"].ToString() != "0")
                        {
                            dn_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                        }
                        if (Session["RenewalSequenceId"].ToString() != "0")
                        {
                            dn_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                        }
                        if (Session["RenewalAgentYear"].ToString() != "0")
                        {
                            dn_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                        }
                    }
                }
            }
            #endregion

            ClsMethod_ReviewConfirm_AgentRenewal_Registration modelextract = new ClsMethod_ReviewConfirm_AgentRenewal_Registration();
            Int32 IsdraftValue = modelextract.Extract_AgentRenewal_Isdraftvalue_FromDiaryNumber(dn_AgentID, dn_TypeOfAgent, dn_RenewalAgentID, dn_RenewalSequenceID, dn_RenewalAgentYear, extractFlag, rcp_UserNam);
            TempData["RnAgent_IsdraftValue"] = IsdraftValue;
        }

    }
}