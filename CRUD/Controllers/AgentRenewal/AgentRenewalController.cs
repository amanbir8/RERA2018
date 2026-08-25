using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models.Agent;
using System.IO;
using CRUD.Models;
using CRUD.Models.Promoter;
using CRUD.Models.Master;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using CRUD.Models.PromoterProject;
using CRUD.Models.AgentRenewal;

namespace CRUD.Controllers.AgentRenewal
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentRenewalController : Controller
    {
        string Image_FileName = string.Empty;
        string PAN_Doc_Address = string.Empty;
        string FileName = string.Empty;
        string FilePath = string.Empty;

        #region Agent_Renewal Selection Option 
        [HttpGet]
        public ActionResult AgentRenewal_RegistrationOptionView()
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_IndexID = 0;
            Int64 User_KeyID = 0;
            //Int32 varReturnCode = 0;
            string UserName = string.Empty;

            string User_RegNumber = string.Empty;
            DateTime User_RegFromDate = DateTime.Now;
            DateTime User_RegToDate = DateTime.Now;

            Int32 User_AgentID_Flag = 0;
            Int32 User_RenewalAgentID_Flag = 0;
            Int32 User_AgentRegistered_Flag = 0;
            Int32 User_RenewalRegistered_Flag = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string User_Error = string.Empty;

            Clsprp_AgentRenewal_VerifyPreviousRegistration prpAgent = new Clsprp_AgentRenewal_VerifyPreviousRegistration();
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
                    if (User_AgentID == 0 && User_TypeOfAgent == 0)
                    {
                        //Algo for "ZERO"
                        return RedirectToAction("AgentRenewal_SearchPreviousRegistration");
                    }
                    else
                    {
                        //Algo for "HAS VALUE"
                        if (User_AgentID != 0 && User_TypeOfAgent != 0)
                        {
                            User_KeyID = 2;
                            prpAgent.AgentRenewal = objDB.Display_AgentRenewal_VerifyRegistrationNumberByID(User_RegNumber, User_RegFromDate, User_RegToDate, User_IndexID, User_KeyID, User_AgentID, User_TypeOfAgent, UserName);
                            foreach (var item in prpAgent.AgentRenewal)
                            {
                                prpAgent.AgentRenewal_VerifyPreviousRegistration_IndexID = item.AgentRenewal_VerifyPreviousRegistration_IndexID;
                                prpAgent.AgentRenewal_VerifyPreviousRegistration_ID = item.AgentRenewal_VerifyPreviousRegistration_ID;

                                // Registration Number
                                prpAgent.RERAnumberRegistration = item.RERAnumberRegistration;
                                prpAgent.RERAnumberIssueDate = item.RERAnumberIssueDate;
                                prpAgent.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                                // Agent ID
                                prpAgent.Agent_ID = item.Agent_ID;
                                prpAgent.UserID = item.UserID;
                                prpAgent.UserName = item.UserName;
                                //prpAgent.UserRole = item.Agent_ID;

                                prpAgent.Agent_RegDiaryNumber_Name = item.Agent_RegDiaryNumber_Name;
                                prpAgent.Agent_RegDiaryNumber_Year = item.Agent_RegDiaryNumber_Year;
                                prpAgent.Agent_RegDiaryNumber_Application_Date = item.Agent_RegDiaryNumber_Application_Date;

                                prpAgent.Agent_LDR_RERAnumber_DiaryNumber_ID = item.Agent_LDR_RERAnumber_DiaryNumber_ID;
                                prpAgent.Is_YesNo_AgentRegistered_Flag = item.Is_YesNo_AgentRegistered_Flag;

                                // Agent Description
                                prpAgent.Agent_Name = item.Agent_Name;
                                prpAgent.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                                prpAgent.Agent_Type = item.Agent_Type;

                                prpAgent.Agent_PlaceOfBussiness_AddressLine1 = item.Agent_PlaceOfBussiness_AddressLine1;
                                prpAgent.Agent_PlaceOfBussiness_AddressLine2 = item.Agent_PlaceOfBussiness_AddressLine2;
                                prpAgent.Agent_PlaceOfBussiness_District = item.Agent_PlaceOfBussiness_District;
                                prpAgent.Agent_PlaceOfBussiness_State = item.Agent_PlaceOfBussiness_State;
                                prpAgent.Agent_PlaceOfBussiness_PIN = item.Agent_PlaceOfBussiness_PIN;

                                prpAgent.Agent_Email_Address = item.Agent_Email_Address;
                                prpAgent.Agent_Mobile_PhoneNumber = item.Agent_Mobile_PhoneNumber;
                                prpAgent.Is_YesNo_AgentDescription_Flag = item.Is_YesNo_AgentDescription_Flag;

                                // Agent Renewal ID
                                prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                                prpAgent.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                                prpAgent.Renewal_OrderSequence = item.Renewal_OrderSequence;
                                prpAgent.Renewal_OrderSequence_Name = item.Renewal_OrderSequence_Name;
                                prpAgent.Related_RenewalAgentRegDiaryNumber_Name = item.Related_RenewalAgentRegDiaryNumber_Name;
                                prpAgent.Related_RenewalAgentRegDiaryNumber_Year = item.Related_RenewalAgentRegDiaryNumber_Year;
                                prpAgent.Related_RenewalAgentRegDiaryNumber_Application_Date = item.Related_RenewalAgentRegDiaryNumber_Application_Date;

                                prpAgent.RenewalAgentRegistrationNumber = item.RenewalAgentRegistrationNumber;
                                prpAgent.RenewalAgentRegistrationIssueDate = item.RenewalAgentRegistrationIssueDate;
                                prpAgent.RenewalAgentRegistrationRegUptoDate = item.RenewalAgentRegistrationRegUptoDate;

                                prpAgent.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID = item.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID;
                                prpAgent.Is_YesNo_ActiveProvider_Flag = item.Is_YesNo_ActiveProvider_Flag;
                                prpAgent.Is_YesNo_RenewalAgentRegistered_Flag = item.Is_YesNo_RenewalAgentRegistered_Flag;

                                // Offline Agent Registered Number
                                prpAgent.OfflineAgentRegistrationNumber = item.OfflineAgentRegistrationNumber;
                                prpAgent.OfflineAgentRegistrationIssueDate = item.OfflineAgentRegistrationIssueDate;
                                prpAgent.OfflineAgentRegistrationRegUptoDate = item.OfflineAgentRegistrationRegUptoDate;

                                prpAgent.ProfileNewCreated_Agent_ID = item.ProfileNewCreated_Agent_ID;
                                prpAgent.Is_YesNo_ProfileNewCreated_Flag = item.Is_YesNo_ProfileNewCreated_Flag;
                                prpAgent.Is_YesNo_OfflineAgentRegistered_Flag = item.Is_YesNo_OfflineAgentRegistered_Flag;

                                // Agent Renewal Permission Flag
                                prpAgent.Is_YesNo_AgentRenewalPermission_Flag = item.Is_YesNo_AgentRenewalPermission_Flag;
                                prpAgent.Is_YesNo_ValidforAgentRenewal_Flag = item.Is_YesNo_ValidforAgentRenewal_Flag;

                                prpAgent.A_column = item.A_column;
                                prpAgent.B_column = item.B_column;
                                prpAgent.C_column = item.C_column;

                                prpAgent.IsActive = item.IsActive;
                                prpAgent.IsDraft = item.IsDraft;
                                prpAgent.IsLock = item.IsLock;
                                prpAgent.IsPublicView = item.IsPublicView;
                                prpAgent.CreatedBy = item.CreatedBy;
                                prpAgent.CreatedOn = item.CreatedOn;
                                prpAgent.ModifyBy = item.ModifyBy;
                                prpAgent.ModifyOn = item.ModifyOn;
                            }
                            //Extract Flag Movement Algo
                            if (prpAgent.AgentRenewal.Count > 0)
                            {
                                User_AgentID_Flag = (prpAgent.Agent_ID > 0) ? 1 : 0;
                                User_AgentRegistered_Flag = prpAgent.Is_YesNo_AgentRegistered_Flag;
                                User_RenewalAgentID_Flag = prpAgent.Is_YesNo_ActiveProvider_Flag;
                                User_RenewalRegistered_Flag = prpAgent.Is_YesNo_RenewalAgentRegistered_Flag;
                            }
                        }
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
                //Algo Flow                
                if (User_AgentID_Flag != 0)
                {
                    if (User_RenewalRegistered_Flag == 0 && User_AgentRegistered_Flag == 0 && User_RenewalAgentID_Flag == 0)
                    {
                        //Offline Case :- Search RERA Number 
                        return RedirectToAction("AgentRenewal_SearchPreviousRegistration");
                    }
                    if (User_RenewalRegistered_Flag == 0 && User_AgentRegistered_Flag == 0 && User_RenewalAgentID_Flag == 1)
                    {
                        //Offline Case :- Edit/Update/Modify/Submit - Application Form
                        if (User_AgentID != 0 && User_TypeOfAgent != 0)
                        {
                            Session["ApplicationId"] = Convert.ToInt64(User_AgentID);
                            Session["User_Type"] = Convert.ToInt32(User_TypeOfAgent); //Ind Case: "1" //OTInd Case: "2"
                            if (prpAgent.Is_YesNo_ActiveProvider_Flag == 1)
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

                                if (Convert.ToInt32(User_TypeOfAgent) == 1)
                                {
                                    //Offline Case :- Individual Profile 
                                    return RedirectToAction("AgentRenewal_IndividualProfile");
                                }
                                if (Convert.ToInt32(User_TypeOfAgent) == 2)
                                {
                                    //Offline Case :- OtherThanIndividual Profile 
                                    return RedirectToAction("AgentRenewal_OTIProfile");
                                }
                            }
                            else
                            {
                                //NA Case :- Error (Mapping error between renewal_ID)
                                User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                            }
                        }
                    }
                    if (User_RenewalRegistered_Flag == 0 && User_AgentRegistered_Flag == 1 && User_RenewalAgentID_Flag == 0)
                    {
                        //Online Case :- Verify RERA Number 
                        return RedirectToAction("AgentRenewal_VerifyPreviousRegistration");
                    }
                    if (User_RenewalRegistered_Flag == 0 && User_AgentRegistered_Flag == 1 && User_RenewalAgentID_Flag == 1)
                    {
                        //Online Case :- Edit/Update/Modify/Submit - Application Form
                        if (User_AgentID != 0 && User_TypeOfAgent != 0)
                        {
                            Session["ApplicationId"] = Convert.ToInt64(User_AgentID);
                            Session["User_Type"] = Convert.ToInt32(User_TypeOfAgent); //Ind Case: "1" //OTInd Case: "2"
                            if (prpAgent.Is_YesNo_ActiveProvider_Flag == 1)
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

                                if (Convert.ToInt32(User_TypeOfAgent) == 1)
                                {
                                    //Offline Case :- Individual Profile 
                                    return RedirectToAction("AgentRenewal_IndividualProfile");
                                }
                                if (Convert.ToInt32(User_TypeOfAgent) == 2)
                                {
                                    //Offline Case :- OtherThanIndividual Profile 
                                    return RedirectToAction("AgentRenewal_OTIProfile");
                                }
                            }
                            else
                            {
                                //NA Case :- Error (Mapping error between renewal_ID)
                                User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                            }
                        }
                    }
                    if (User_RenewalRegistered_Flag == 1 && User_AgentRegistered_Flag == 0 && User_RenewalAgentID_Flag == 0)
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                    if (User_RenewalRegistered_Flag == 1 && User_AgentRegistered_Flag == 0 && User_RenewalAgentID_Flag == 1)
                    {
                        //Offline Case :- Verify RERA Number (offline registered, but online already renewal case)
                        // ----- START -----
                        // presently logic working @VerifyPreviousRegistration form
                        // -->if not valid for renewal of rgistration, then open locked profile
                        // -->if valid for renewal of registration, then open I Agree option from verify form
                        // output reduc the 2nd time db layer access, but also open directly locked profile without showing message
                        // ----- END -------
                        return RedirectToAction("AgentRenewal_VerifyPreviousRegistration");
                    }
                    if (User_RenewalRegistered_Flag == 1 && User_AgentRegistered_Flag == 1 && User_RenewalAgentID_Flag == 0)
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                    if (User_RenewalRegistered_Flag == 1 && User_AgentRegistered_Flag == 1 && User_RenewalAgentID_Flag == 1)
                    {
                        //Online Case :- Verify RERA Number (online already renewal case)
                        // ----- START -----
                        // presently logic working @VerifyPreviousRegistration form
                        // -->if not valid for renewal of rgistration, then open locked profile
                        // -->if valid for renewal of registration, then open I Agree option from verify form
                        // output reduc the 2nd time db layer access, but also open directly locked profile without showing message
                        // ----- END -------
                        return RedirectToAction("AgentRenewal_VerifyPreviousRegistration");
                    }
                }
                prpAgent.A_column = User_Error.ToString();
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }
            return View("AgentRenewal_RegistrationOptionView", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_VerifyPreviousRegistration()
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_IndexID = 0;
            Int64 User_KeyID = 0;
            //Int32 varReturnCode = 0;
            string UserName = string.Empty;

            string User_RegNumber = string.Empty;
            DateTime User_RegFromDate = DateTime.Now;
            DateTime User_RegToDate = DateTime.Now;

            Clsprp_AgentRenewal_VerifyPreviousRegistration prpAgent = new Clsprp_AgentRenewal_VerifyPreviousRegistration();
            ClsMethod_AgentRenewal_VerifyRegistrationNumber objDB = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();

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
                if (User_AgentID == 0 && User_TypeOfAgent == 0)
                {
                    //Algo for "ZERO"
                    return RedirectToAction("AgentRenewal_SearchPreviousRegistration");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            try
            {
                User_KeyID = 3;
                prpAgent.AgentRenewal = objDB.Display_AgentRenewal_VerifyRegistrationNumberByID(User_RegNumber, User_RegFromDate, User_RegToDate, User_IndexID, User_KeyID, User_AgentID, User_TypeOfAgent, UserName);
                foreach (var item in prpAgent.AgentRenewal)
                {
                    prpAgent.AgentRenewal_VerifyPreviousRegistration_IndexID = item.AgentRenewal_VerifyPreviousRegistration_IndexID;
                    prpAgent.AgentRenewal_VerifyPreviousRegistration_ID = item.AgentRenewal_VerifyPreviousRegistration_ID;

                    // Registration Number
                    prpAgent.RERAnumberRegistration = item.RERAnumberRegistration;
                    prpAgent.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    prpAgent.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                    // Agent ID
                    prpAgent.Agent_ID = item.Agent_ID;
                    prpAgent.UserID = item.UserID;
                    prpAgent.UserName = item.UserName;
                    //prpAgent.UserRole = item.Agent_ID;

                    prpAgent.Agent_RegDiaryNumber_Name = item.Agent_RegDiaryNumber_Name;
                    prpAgent.Agent_RegDiaryNumber_Year = item.Agent_RegDiaryNumber_Year;
                    prpAgent.Agent_RegDiaryNumber_Application_Date = item.Agent_RegDiaryNumber_Application_Date;

                    prpAgent.Agent_LDR_RERAnumber_DiaryNumber_ID = item.Agent_LDR_RERAnumber_DiaryNumber_ID;
                    prpAgent.Is_YesNo_AgentRegistered_Flag = item.Is_YesNo_AgentRegistered_Flag;

                    // Agent Description
                    prpAgent.Agent_Name = item.Agent_Name;
                    prpAgent.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                    prpAgent.Agent_Type = item.Agent_Type;

                    prpAgent.Agent_PlaceOfBussiness_AddressLine1 = item.Agent_PlaceOfBussiness_AddressLine1;
                    prpAgent.Agent_PlaceOfBussiness_AddressLine2 = item.Agent_PlaceOfBussiness_AddressLine2;
                    prpAgent.Agent_PlaceOfBussiness_District = item.Agent_PlaceOfBussiness_District;
                    prpAgent.Agent_PlaceOfBussiness_State = item.Agent_PlaceOfBussiness_State;
                    prpAgent.Agent_PlaceOfBussiness_PIN = item.Agent_PlaceOfBussiness_PIN;

                    prpAgent.Agent_Email_Address = item.Agent_Email_Address;
                    prpAgent.Agent_Mobile_PhoneNumber = item.Agent_Mobile_PhoneNumber;
                    prpAgent.Is_YesNo_AgentDescription_Flag = item.Is_YesNo_AgentDescription_Flag;

                    // Agent Renewal ID
                    prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                    prpAgent.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                    prpAgent.Renewal_OrderSequence = item.Renewal_OrderSequence;
                    prpAgent.Renewal_OrderSequence_Name = item.Renewal_OrderSequence_Name;
                    prpAgent.Related_RenewalAgentRegDiaryNumber_Name = item.Related_RenewalAgentRegDiaryNumber_Name;
                    prpAgent.Related_RenewalAgentRegDiaryNumber_Year = item.Related_RenewalAgentRegDiaryNumber_Year;
                    prpAgent.Related_RenewalAgentRegDiaryNumber_Application_Date = item.Related_RenewalAgentRegDiaryNumber_Application_Date;

                    prpAgent.RenewalAgentRegistrationNumber = item.RenewalAgentRegistrationNumber;
                    prpAgent.RenewalAgentRegistrationIssueDate = item.RenewalAgentRegistrationIssueDate;
                    prpAgent.RenewalAgentRegistrationRegUptoDate = item.RenewalAgentRegistrationRegUptoDate;

                    prpAgent.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID = item.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID;
                    prpAgent.Is_YesNo_ActiveProvider_Flag = item.Is_YesNo_ActiveProvider_Flag;
                    prpAgent.Is_YesNo_RenewalAgentRegistered_Flag = item.Is_YesNo_RenewalAgentRegistered_Flag;

                    // Offline Agent Registered Number
                    prpAgent.OfflineAgentRegistrationNumber = item.OfflineAgentRegistrationNumber;
                    prpAgent.OfflineAgentRegistrationIssueDate = item.OfflineAgentRegistrationIssueDate;
                    prpAgent.OfflineAgentRegistrationRegUptoDate = item.OfflineAgentRegistrationRegUptoDate;

                    prpAgent.ProfileNewCreated_Agent_ID = item.ProfileNewCreated_Agent_ID;
                    prpAgent.Is_YesNo_ProfileNewCreated_Flag = item.Is_YesNo_ProfileNewCreated_Flag;
                    prpAgent.Is_YesNo_OfflineAgentRegistered_Flag = item.Is_YesNo_OfflineAgentRegistered_Flag;
                    
                    // Agent Renewal Permission Flag
                    prpAgent.Is_YesNo_AgentRenewalPermission_Flag = item.Is_YesNo_AgentRenewalPermission_Flag;
                    prpAgent.Is_YesNo_ValidforAgentRenewal_Flag = item.Is_YesNo_ValidforAgentRenewal_Flag;

                    prpAgent.A_column = item.A_column;
                    prpAgent.B_column = item.B_column;
                    prpAgent.C_column = item.C_column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }
            return View("AgentRenewal_VerifyPreviousRegistration", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_VerifyPreviousRegistration(Clsprp_AgentRenewal_VerifyPreviousRegistration smodel)
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            string User_Error = string.Empty;

            try
            {
                ModelState.Remove("UserID");
                ModelState.Remove("RenewalAgentRegistrationNumber");
                ModelState.Remove("RenewalAgentRegistrationIssueDate");
                ModelState.Remove("RenewalAgentRegistrationRegUptoDate");
                ModelState.Remove("OfflineAgentRegistrationNumber");
                ModelState.Remove("OfflineAgentRegistrationIssueDate");
                ModelState.Remove("OfflineAgentRegistrationRegUptoDate");
                ModelState.Remove("Agent_Mobile_PhoneNumber");
                ModelState.Remove("Is_YesNo_AgentRenewalPermission_Flag");

                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    smodel.Is_YesNo_AgentRenewalPermission_Flag = 1;

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

                        //Algo View Registered Agent Profile after Approval
                        if (User_AgentID != 0 && User_TypeOfAgent != 0)
                        {
                            Session["ApplicationId"] = Convert.ToInt64(User_AgentID);
                            Session["User_Type"] = Convert.ToInt32(User_TypeOfAgent); //Ind Case: "1" //OTInd Case: "2"
                            
                            Session["RenewalAgentId"] = Convert.ToInt64(smodel.Related_RenewalAgent_ID);
                            Session["RenewalSequenceId"] = Convert.ToInt32(smodel.Renewal_OrderSequence);
                            Session["RenewalAgentYear"] = Convert.ToInt32(smodel.Related_RenewalAgent_Year);

                            if (Convert.ToInt32(User_TypeOfAgent) == 1)
                            {
                                //Offline Case :- Individual Profile 
                                return RedirectToAction("AgentRenewal_IndividualProfile", "AgentRenewal");
                            }
                            if (Convert.ToInt32(User_TypeOfAgent) == 2)
                            {
                                //Offline Case :- OtherThanIndividual Profile 
                                return RedirectToAction("AgentRenewal_OTIProfile", "AgentRenewal");
                            }                            
                        }
                    }
                    else
                    {
                        return RedirectToAction("SessionExpire", "Account");
                    }
                    TempData["message"] = "Record Updated Successfully!";
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        [HttpPost]
        public ActionResult AgentRenewal_AddVerifyPreviousRegistration(Clsprp_AgentRenewal_VerifyPreviousRegistration smodel)
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            string User_Error = string.Empty;

            try
            {
                ModelState.Remove("UserID");
                ModelState.Remove("RenewalAgentRegistrationNumber");
                ModelState.Remove("RenewalAgentRegistrationIssueDate");
                ModelState.Remove("RenewalAgentRegistrationRegUptoDate");
                ModelState.Remove("OfflineAgentRegistrationNumber");
                ModelState.Remove("OfflineAgentRegistrationIssueDate");
                ModelState.Remove("OfflineAgentRegistrationRegUptoDate");
                ModelState.Remove("Agent_Mobile_PhoneNumber");
                ModelState.Remove("Is_YesNo_AgentRenewalPermission_Flag");
                
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;
                    string User_RegistrationMode = "WebPortal Registered Agent";
                    string User_Remarks = string.Empty;
                    smodel.Is_YesNo_AgentRenewalPermission_Flag = 1;
                    bool varRet = false;

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
                    }
                    else
                    {
                        return Json(new { result = "RedirectErr", redirectToUrl = Url.Action("SessionExpire", "Account") }, JsonRequestBehavior.AllowGet);
                    }

                    ClsMethod_AgentRenewal_VerifyRegistrationNumber sdb = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();
                    varRet = sdb.Add_AgentRenewal_AddVerifyPreviousRegistration_HistoryLogs(smodel, User_TypeOfAgent, User_RegistrationMode, User_Remarks, UID, UserNam);
                    if (varRet)
                    {
                        //Algo (Add New Registeration for Renewal Agent)
                        if (User_AgentID != 0 && User_TypeOfAgent != 0)
                        {
                            Session["ApplicationId"] = Convert.ToInt64(User_AgentID);
                            Session["User_Type"] = Convert.ToInt32(User_TypeOfAgent); //Ind Case: "1" //OTInd Case: "2"

                            Session["RenewalAgentId"] = Convert.ToInt64(0);
                            Session["RenewalSequenceId"] = Convert.ToInt32(0);
                            Session["RenewalAgentYear"] = Convert.ToInt32(0);

                            if (Convert.ToInt32(User_TypeOfAgent) == 1)
                            {
                                //Offline Case :- Individual Profile 
                                return Json(new { result = "Redirect", redirectToUrl = Url.Action("AgentRenewal_IndividualProfile", "AgentRenewal") }, JsonRequestBehavior.AllowGet);
                            }
                            if (Convert.ToInt32(User_TypeOfAgent) == 2)
                            {
                                //Offline Case :- OtherThanIndividual Profile 
                                return Json(new { result = "Redirect", redirectToUrl = Url.Action("AgentRenewal_OTIProfile", "AgentRenewal") }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        TempData["message"] = "Record Submitted Successfully!";
                    }                    
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        [HttpGet]
        public ActionResult AgentRenewal_SearchPreviousRegistration()
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_IndexID = 0;
            Int64 User_KeyID = 0;
            string UserName = string.Empty;

            string User_RegNumber = string.Empty;
            DateTime User_RegFromDate = DateTime.Now;
            DateTime User_RegToDate = DateTime.Now;

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
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Clsprp_AgentRenewal_VerifyPreviousRegistration prpAgent = new Clsprp_AgentRenewal_VerifyPreviousRegistration();
            ClsMethod_AgentRenewal_VerifyRegistrationNumber objDB = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();

            try
            {
                prpAgent.AgentRenewal = objDB.Display_AgentRenewal_VerifyRegistrationNumberByID(User_RegNumber, User_RegFromDate, User_RegToDate, User_IndexID, User_KeyID, User_AgentID, User_TypeOfAgent, UserName);
                foreach (var item in prpAgent.AgentRenewal)
                {
                    prpAgent.AgentRenewal_VerifyPreviousRegistration_IndexID = item.AgentRenewal_VerifyPreviousRegistration_IndexID;
                    prpAgent.AgentRenewal_VerifyPreviousRegistration_ID = item.AgentRenewal_VerifyPreviousRegistration_ID;

                    // Registration Number
                    prpAgent.RERAnumberRegistration = item.RERAnumberRegistration;
                    prpAgent.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    prpAgent.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                    // Agent ID
                    prpAgent.Agent_ID = item.Agent_ID;
                    prpAgent.UserID = item.UserID;
                    prpAgent.UserName = item.UserName;
                    //prpAgent.UserRole = item.Agent_ID;

                    prpAgent.Agent_RegDiaryNumber_Name = item.Agent_RegDiaryNumber_Name;
                    prpAgent.Agent_RegDiaryNumber_Year = item.Agent_RegDiaryNumber_Year;
                    prpAgent.Agent_RegDiaryNumber_Application_Date = item.Agent_RegDiaryNumber_Application_Date;

                    prpAgent.Agent_LDR_RERAnumber_DiaryNumber_ID = item.Agent_LDR_RERAnumber_DiaryNumber_ID;
                    prpAgent.Is_YesNo_AgentRegistered_Flag = item.Is_YesNo_AgentRegistered_Flag;

                    // Agent Description
                    prpAgent.Agent_Name = item.Agent_Name;
                    prpAgent.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                    prpAgent.Agent_Type = item.Agent_Type;

                    prpAgent.Agent_PlaceOfBussiness_AddressLine1 = item.Agent_PlaceOfBussiness_AddressLine1;
                    prpAgent.Agent_PlaceOfBussiness_AddressLine2 = item.Agent_PlaceOfBussiness_AddressLine2;
                    prpAgent.Agent_PlaceOfBussiness_District = item.Agent_PlaceOfBussiness_District;
                    prpAgent.Agent_PlaceOfBussiness_State = item.Agent_PlaceOfBussiness_State;
                    prpAgent.Agent_PlaceOfBussiness_PIN = item.Agent_PlaceOfBussiness_PIN;

                    prpAgent.Agent_Email_Address = item.Agent_Email_Address;
                    prpAgent.Agent_Mobile_PhoneNumber = item.Agent_Mobile_PhoneNumber;
                    prpAgent.Is_YesNo_AgentDescription_Flag = item.Is_YesNo_AgentDescription_Flag;

                    // Agent Renewal ID
                    prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                    prpAgent.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                    prpAgent.Renewal_OrderSequence = item.Renewal_OrderSequence;
                    prpAgent.Renewal_OrderSequence_Name = item.Renewal_OrderSequence_Name;
                    prpAgent.Related_RenewalAgentRegDiaryNumber_Name = item.Related_RenewalAgentRegDiaryNumber_Name;
                    prpAgent.Related_RenewalAgentRegDiaryNumber_Year = item.Related_RenewalAgentRegDiaryNumber_Year;
                    prpAgent.Related_RenewalAgentRegDiaryNumber_Application_Date = item.Related_RenewalAgentRegDiaryNumber_Application_Date;

                    prpAgent.RenewalAgentRegistrationNumber = item.RERAnumberRegistration; //item.RenewalAgentRegistrationNumber;
                    prpAgent.RenewalAgentRegistrationIssueDate = item.RenewalAgentRegistrationIssueDate;
                    prpAgent.RenewalAgentRegistrationRegUptoDate = item.RenewalAgentRegistrationRegUptoDate;

                    prpAgent.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID = item.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID;
                    prpAgent.Is_YesNo_ActiveProvider_Flag = item.Is_YesNo_ActiveProvider_Flag;
                    prpAgent.Is_YesNo_RenewalAgentRegistered_Flag = item.Is_YesNo_RenewalAgentRegistered_Flag;

                    // Offline Agent Registered Number
                    prpAgent.OfflineAgentRegistrationNumber = item.OfflineAgentRegistrationNumber;
                    prpAgent.OfflineAgentRegistrationIssueDate = item.OfflineAgentRegistrationIssueDate;
                    prpAgent.OfflineAgentRegistrationRegUptoDate = item.OfflineAgentRegistrationRegUptoDate;

                    prpAgent.ProfileNewCreated_Agent_ID = item.ProfileNewCreated_Agent_ID;
                    prpAgent.Is_YesNo_ProfileNewCreated_Flag = item.Is_YesNo_ProfileNewCreated_Flag;
                    prpAgent.Is_YesNo_OfflineAgentRegistered_Flag = item.Is_YesNo_OfflineAgentRegistered_Flag;

                    // Agent Renewal Permission Flag
                    prpAgent.Is_YesNo_AgentRenewalPermission_Flag = item.Is_YesNo_AgentRenewalPermission_Flag;
                    prpAgent.Is_YesNo_ValidforAgentRenewal_Flag = item.Is_YesNo_ValidforAgentRenewal_Flag;

                    prpAgent.A_column = item.A_column;
                    prpAgent.B_column = item.B_column;
                    prpAgent.C_column = item.C_column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }
            return View("AgentRenewal_SearchPreviousRegistration", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_SearchPreviousRegistration(Clsprp_AgentRenewal_VerifyPreviousRegistration smodel)
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_IndexID = 0;
            Int64 User_KeyID = 0;

            Clsprp_AgentRenewal_VerifyPreviousRegistration prpAgent = new Clsprp_AgentRenewal_VerifyPreviousRegistration();
            ClsMethod_AgentRenewal_VerifyRegistrationNumber sdb = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();

            try
            {
                ModelState.Remove("Agent_ID");
                ModelState.Remove("UserID");
                ModelState.Remove("Agent_Mobile_PhoneNumber");                
                ModelState.Remove("Is_YesNo_AgentRegistered_Flag");
                ModelState.Remove("Is_YesNo_AgentDescription_Flag");

                ModelState.Remove("Related_RenewalAgent_ID");
                ModelState.Remove("Related_RenewalAgent_Year");
                ModelState.Remove("Renewal_OrderSequence");
                ModelState.Remove("RenewalAgentRegistrationNumber");
                ModelState.Remove("RenewalAgentRegistrationIssueDate");
                ModelState.Remove("RenewalAgentRegistrationRegUptoDate");
                ModelState.Remove("Is_YesNo_ActiveProvider_Flag");
                ModelState.Remove("Is_YesNo_RenewalAgentRegistered_Flag");

                ModelState.Remove("OfflineAgentRegistrationNumber");
                ModelState.Remove("OfflineAgentRegistrationIssueDate");
                ModelState.Remove("OfflineAgentRegistrationRegUptoDate");
                ModelState.Remove("Is_YesNo_OfflineAgentRegistered_Flag");

                ModelState.Remove("Is_YesNo_AgentRenewalPermission_Flag");
                ModelState.Remove("Is_YesNo_ValidforAgentRenewal_Flag");

                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    string User_RegNumber = string.Empty;
                    DateTime User_RegFromDate = DateTime.Now;
                    DateTime User_RegToDate = DateTime.Now;
                    //Search Offline Registration Number
                    User_KeyID = 1;
                    User_RegNumber = smodel.RERAnumberRegistration;
                    User_RegFromDate = (DateTime)smodel.RERAnumberIssueDate;
                    User_RegToDate = (DateTime)smodel.RERAnumberRegUptoDate;

                    prpAgent.AgentRenewal = sdb.Display_AgentRenewal_VerifyRegistrationNumberByID(User_RegNumber, User_RegFromDate, User_RegToDate, User_IndexID, User_KeyID, User_AgentID, User_TypeOfAgent, UserNam);
                    foreach (var item in prpAgent.AgentRenewal)
                    {
                        prpAgent.AgentRenewal_VerifyPreviousRegistration_IndexID = item.AgentRenewal_VerifyPreviousRegistration_IndexID;
                        prpAgent.AgentRenewal_VerifyPreviousRegistration_ID = item.AgentRenewal_VerifyPreviousRegistration_ID;

                        // Registration Number
                        prpAgent.RERAnumberRegistration = item.RERAnumberRegistration;
                        prpAgent.RERAnumberIssueDate = item.RERAnumberIssueDate;
                        prpAgent.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                        // Agent ID
                        prpAgent.Agent_ID = item.Agent_ID;
                        prpAgent.UserID = item.UserID;
                        prpAgent.UserName = item.UserName;
                        //prpAgent.UserRole = item.Agent_ID;

                        prpAgent.Agent_RegDiaryNumber_Name = item.Agent_RegDiaryNumber_Name;
                        prpAgent.Agent_RegDiaryNumber_Year = item.Agent_RegDiaryNumber_Year;
                        prpAgent.Agent_RegDiaryNumber_Application_Date = item.Agent_RegDiaryNumber_Application_Date;

                        prpAgent.Agent_LDR_RERAnumber_DiaryNumber_ID = item.Agent_LDR_RERAnumber_DiaryNumber_ID;
                        prpAgent.Is_YesNo_AgentRegistered_Flag = item.Is_YesNo_AgentRegistered_Flag;

                        // Agent Description
                        prpAgent.Agent_Name = item.Agent_Name;
                        prpAgent.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                        prpAgent.Agent_Type = item.Agent_Type;

                        prpAgent.Agent_PlaceOfBussiness_AddressLine1 = item.Agent_PlaceOfBussiness_AddressLine1;
                        prpAgent.Agent_PlaceOfBussiness_AddressLine2 = item.Agent_PlaceOfBussiness_AddressLine2;
                        prpAgent.Agent_PlaceOfBussiness_District = item.Agent_PlaceOfBussiness_District;
                        prpAgent.Agent_PlaceOfBussiness_State = item.Agent_PlaceOfBussiness_State;
                        prpAgent.Agent_PlaceOfBussiness_PIN = item.Agent_PlaceOfBussiness_PIN;

                        prpAgent.Agent_Email_Address = item.Agent_Email_Address;
                        prpAgent.Agent_Mobile_PhoneNumber = item.Agent_Mobile_PhoneNumber;
                        prpAgent.Is_YesNo_AgentDescription_Flag = item.Is_YesNo_AgentDescription_Flag;

                        // Agent Renewal ID
                        prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                        prpAgent.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                        prpAgent.Renewal_OrderSequence = item.Renewal_OrderSequence;
                        prpAgent.Renewal_OrderSequence_Name = item.Renewal_OrderSequence_Name;
                        prpAgent.Related_RenewalAgentRegDiaryNumber_Name = item.Related_RenewalAgentRegDiaryNumber_Name;
                        prpAgent.Related_RenewalAgentRegDiaryNumber_Year = item.Related_RenewalAgentRegDiaryNumber_Year;
                        prpAgent.Related_RenewalAgentRegDiaryNumber_Application_Date = item.Related_RenewalAgentRegDiaryNumber_Application_Date;

                        prpAgent.RenewalAgentRegistrationNumber = item.RenewalAgentRegistrationNumber;
                        prpAgent.RenewalAgentRegistrationIssueDate = item.RenewalAgentRegistrationIssueDate;
                        prpAgent.RenewalAgentRegistrationRegUptoDate = item.RenewalAgentRegistrationRegUptoDate;

                        prpAgent.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID = item.Agent_LDR_RenewalRERAnumber_DiaryNumber_ID;
                        prpAgent.Is_YesNo_ActiveProvider_Flag = item.Is_YesNo_ActiveProvider_Flag;
                        prpAgent.Is_YesNo_RenewalAgentRegistered_Flag = item.Is_YesNo_RenewalAgentRegistered_Flag;

                        // Offline Agent Registered Number
                        prpAgent.OfflineAgentRegistrationNumber = item.OfflineAgentRegistrationNumber;
                        prpAgent.OfflineAgentRegistrationIssueDate = item.OfflineAgentRegistrationIssueDate;
                        prpAgent.OfflineAgentRegistrationRegUptoDate = item.OfflineAgentRegistrationRegUptoDate;

                        prpAgent.ProfileNewCreated_Agent_ID = item.ProfileNewCreated_Agent_ID;
                        prpAgent.Is_YesNo_ProfileNewCreated_Flag = item.Is_YesNo_ProfileNewCreated_Flag;
                        prpAgent.Is_YesNo_OfflineAgentRegistered_Flag = item.Is_YesNo_OfflineAgentRegistered_Flag;

                        // Agent Renewal Permission Flag
                        prpAgent.Is_YesNo_AgentRenewalPermission_Flag = item.Is_YesNo_AgentRenewalPermission_Flag;
                        prpAgent.Is_YesNo_ValidforAgentRenewal_Flag = item.Is_YesNo_ValidforAgentRenewal_Flag;

                        prpAgent.A_column = item.A_column;
                        prpAgent.B_column = item.B_column;
                        prpAgent.C_column = item.C_column;

                        prpAgent.IsActive = item.IsActive;
                        prpAgent.IsDraft = item.IsDraft;
                        prpAgent.IsLock = item.IsLock;
                        prpAgent.IsPublicView = item.IsPublicView;
                        prpAgent.CreatedBy = item.CreatedBy;
                        prpAgent.CreatedOn = item.CreatedOn;
                        prpAgent.ModifyBy = item.ModifyBy;
                        prpAgent.ModifyOn = item.ModifyOn;
                    }

                    TempData["message"] = "Record founds!";
                }
                return View("AgentRenewal_SearchPreviousRegistration", prpAgent);
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        [HttpPost]
        public ActionResult AgentRenewal_AddSearchPreviousRegistration(Clsprp_AgentRenewal_VerifyPreviousRegistration smodel)
        {
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            string User_Error = string.Empty;

            try
            {
                ModelState.Remove("UserID");
                ModelState.Remove("RenewalAgentRegistrationNumber");
                ModelState.Remove("RenewalAgentRegistrationIssueDate");
                ModelState.Remove("RenewalAgentRegistrationRegUptoDate");
                ModelState.Remove("OfflineAgentRegistrationNumber");
                ModelState.Remove("OfflineAgentRegistrationIssueDate");
                ModelState.Remove("OfflineAgentRegistrationRegUptoDate");
                ModelState.Remove("Agent_Mobile_PhoneNumber");
                ModelState.Remove("Is_YesNo_AgentRenewalPermission_Flag");
                
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;
                    string User_RegistrationMode = "Offline Registered Agent";
                    string User_Remarks = string.Empty;
                    smodel.Is_YesNo_AgentRenewalPermission_Flag = 1;
                    bool varRet = false;

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
                    }
                    else
                    {
                        return Json(new { result = "RedirectErr", redirectToUrl = Url.Action("SessionExpire", "Account") }, JsonRequestBehavior.AllowGet);
                    }

                    ClsMethod_AgentRenewal_VerifyRegistrationNumber sdb = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();
                    varRet = sdb.Add_AgentRenewal_AddVerifyPreviousRegistration_HistoryLogs(smodel, User_TypeOfAgent, User_RegistrationMode, User_Remarks, UID, UserNam);
                    if (varRet)
                    {
                        //Algo (Add New Registeration for Renewal Agent)
                        if (User_AgentID != 0 && User_TypeOfAgent != 0)
                        {
                            Session["ApplicationId"] = Convert.ToInt64(User_AgentID);
                            Session["User_Type"] = Convert.ToInt32(User_TypeOfAgent); //Ind Case: "1" //OTInd Case: "2"

                            Session["RenewalAgentId"] = Convert.ToInt64(0);
                            Session["RenewalSequenceId"] = Convert.ToInt32(0);
                            Session["RenewalAgentYear"] = Convert.ToInt32(0);

                            if (Convert.ToInt32(User_TypeOfAgent) == 1)
                            {
                                //Offline Case :- Individual Profile 
                                return Json(new { result = "Redirect", redirectToUrl = Url.Action("AgentRenewal_IndividualProfile", "AgentRenewal") }, JsonRequestBehavior.AllowGet);
                            }
                            if (Convert.ToInt32(User_TypeOfAgent) == 2)
                            {
                                //Offline Case :- OtherThanIndividual Profile 
                                return Json(new { result = "Redirect", redirectToUrl = Url.Action("AgentRenewal_OTIProfile", "AgentRenewal") }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        TempData["message"] = "Record Submitted Successfully!";
                    }
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        [HttpGet]
        public ActionResult AgentRenewal_ListPreviousRegistration(Int64 qagentid, Int32 ptypeagent, Int64 prenewalagentid, Int32 prenewalagentseq, Int32 prenewalagentyr, string pkeyflag, string pkeysubflag)
        {
            Int64 prmAgent_ID = 0;
            Int32 prmTypeOfAgent_ID = 0;
            Int64 prmRenewalAgent_ID = 0;
            Int32 prmRenewalAgent_Sequence = 0;
            Int32 prmRenewalAgent_Year = 0;
            string UserName = string.Empty;
            string prmRERARefNumber = string.Empty;
            Int32 prmKey_ID = 0;
            Int32 prmKey_SubID = 0;
            string getKeyFlag = string.Empty;
            string getKeySubFlag = string.Empty;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    prmAgent_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    //Ind Case: "1" //OTInd Case: "2" 
                    prmTypeOfAgent_ID = Convert.ToInt32(Session["User_Type"]);
                }
            }
            else
            {
                prmAgent_ID = Convert.ToInt64(qagentid);
                prmTypeOfAgent_ID = Convert.ToInt32(ptypeagent);
                getKeyFlag = pkeyflag.ToString();
                getKeySubFlag = pkeysubflag.ToString();
            }

            Clsprp_AgentRenewal_ListPreviousRegistrations objprp = new Clsprp_AgentRenewal_ListPreviousRegistrations();
            ClsMethod_AgentRenewal_VerifyRegistrationNumber sdb = new ClsMethod_AgentRenewal_VerifyRegistrationNumber();

            try
            {
                objprp.AgentRenewalList = sdb.Display_AgentRenewal_ListPreviousRegistrationByID(prmAgent_ID, prmTypeOfAgent_ID, prmRenewalAgent_ID, prmRenewalAgent_Sequence, prmRenewalAgent_Year, prmRERARefNumber, prmKey_ID, prmKey_SubID, UserName);

                foreach (var item in objprp.AgentRenewalList)
                {
                    objprp.AgentRenewal_ListPreviousRegistration_IndexID = item.AgentRenewal_ListPreviousRegistration_IndexID;
                    objprp.AgentRenewal_ListPreviousRegistration_ID = item.AgentRenewal_ListPreviousRegistration_ID;
                    objprp.RERAnumberRegistration = item.RERAnumberRegistration;
                    objprp.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    objprp.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                    objprp.Agent_ID = item.Agent_ID;
                    objprp.AgentType_ID = item.AgentType_ID;
                    objprp.UserID = item.UserID;
                    objprp.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                    objprp.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                    objprp.Renewal_OrderSequence = item.Renewal_OrderSequence;
                    objprp.Renewal_OrderSequence_Name = item.Renewal_OrderSequence_Name;

                    objprp.Agent_Name = item.Agent_Name;
                    objprp.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                    objprp.Agent_Type = item.Agent_Type;
                    objprp.RegDiaryNumber_Name = item.RegDiaryNumber_Name;
                    objprp.RegDiaryNumber_Application_Date = item.RegDiaryNumber_Application_Date;

                    objprp.Is_YesNo_OfflineAgentRegistered_Flag = item.Is_YesNo_OfflineAgentRegistered_Flag;
                    objprp.Is_YesNo_AgentRegistered_Flag = item.Is_YesNo_AgentRegistered_Flag;
                    objprp.Is_YesNo_RenewalAgentID_Flag = item.Is_YesNo_RenewalAgentID_Flag;
                    objprp.Is_YesNo_RenewalAgentRegistered_Flag = item.Is_YesNo_RenewalAgentRegistered_Flag;
                    objprp.Is_YesNo_ValidforAgentRenewal_Flag = item.Is_YesNo_ValidforAgentRenewal_Flag;

                    objprp.A_column = item.A_column;
                    objprp.B_column = item.B_column;
                    objprp.IsActive = item.IsActive;
                    objprp.IsDraft = item.IsDraft;
                    objprp.IsLock = item.IsLock;
                    objprp.IsPublicView = item.IsPublicView;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View("AgentRenewal_ListPreviousRegistration", objprp);
        }
        #endregion

        #region Agent_Renewal Individual Profile
        [HttpGet]
        public ActionResult AgentRenewal_IndividualProfile()
        {
            #region extract-Params
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserName = string.Empty;
            string UserID = string.Empty;
            string User_Error = string.Empty;

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
                        return RedirectToAction("SessionExpire", "Account");
                    }
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

            Clsprp_AgentRenewal_IndividualProfile prpAgent = new Clsprp_AgentRenewal_IndividualProfile();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_Profile sdb = new ClsMethod_AgentRenewal_Profile();

            try
            {
                UserID = User.Identity.GetUserId();
                prpAgent.AgentRenewal_IndProfile = sdb.AgentRenewal_Display_IndividualProfile_AgentDetailByID(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                prpAgent.districtMaster = objdis.dropdownlist_display1();
                prpAgent.stateMaster = objdis.State_list();
                prpAgent.SubdivMaster = objdis.dropdownlist_diplaySubdivForAgent();                

                prpAgent.MobileNumber = Convert.ToInt64(Session["Mobile_Number"]);
                prpAgent.EmailAddress = Session["Email_Address"].ToString();

                foreach (var item in prpAgent.AgentRenewal_IndProfile)
                {
                    prpAgent.RenewalAgent_IndexID = item.RenewalAgent_IndexID;
                    prpAgent.RenewalAgent_ID = item.RenewalAgent_ID;
                    prpAgent.RenewalOrderSequence = item.RenewalOrderSequence;
                    prpAgent.RelatedRenewalAgent_Year = item.RelatedRenewalAgent_Year;
                    prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                    prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                    prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                    prpAgent.Related_UserID = item.Related_UserID;
                    prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                    prpAgent.Related_RERAnumberIssueDate = item.Related_RERAnumberIssueDate;
                    prpAgent.Related_RERAnumberRegUptoDate = item.Related_RERAnumberRegUptoDate;
                    prpAgent.Agent_Type = item.Agent_Type;

                    prpAgent.IsAlready_RERANumber = item.IsAlready_RERANumber;
                    prpAgent.Existing_RERANumber = item.Existing_RERANumber;
                    prpAgent.Mode_RegistrationNumber = item.Mode_RegistrationNumber;

                    prpAgent.Agent_FirstName = item.Agent_FirstName;
                    prpAgent.Agent_MiddleName = item.Agent_MiddleName;
                    prpAgent.Agent_LastName = item.Agent_LastName;
                    prpAgent.Father_FirstName = item.Father_FirstName;
                    prpAgent.Father_MiddleName = item.Father_MiddleName;
                    prpAgent.Father_LastName = item.Father_LastName;
                    prpAgent.Occupation = item.Occupation;
                    prpAgent.Image_FileName = item.Image_FileName;
                    prpAgent.Image_FilePath = item.Image_FilePath;

                    prpAgent.P_AddressLine1 = item.P_AddressLine1;
                    prpAgent.P_AddressLine2 = item.P_AddressLine2;
                    prpAgent.P_AddressStateCode = item.P_AddressStateCode;
                    prpAgent.P_AddressDistrictCode = item.P_AddressDistrictCode;
                    prpAgent.P_AddressPIN = item.P_AddressPIN;

                    prpAgent.Organization_Name = item.Organization_Name;
                    prpAgent.Organization_TypeCode = item.Organization_TypeCode;
                    prpAgent.Organization_MainObjects = item.Organization_MainObjects;

                    prpAgent.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    prpAgent.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    prpAgent.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    prpAgent.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    prpAgent.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                    prpAgent.BusinessPlace_AddressSubDivisionCode = item.BusinessPlace_AddressSubDivisionCode;
                    prpAgent.BusinessPlace_AddressSubDivisionName = item.BusinessPlace_AddressSubDivisionName;

                    prpAgent.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                    prpAgent.BComm_AddressLine1 = item.BComm_AddressLine1;
                    prpAgent.BComm_AddressLine2 = item.BComm_AddressLine2;
                    prpAgent.BComm_AddressStateCode = item.BComm_AddressStateCode;
                    prpAgent.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    prpAgent.BComm_AddressPIN = item.BComm_AddressPIN;

                    prpAgent.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                    prpAgent.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    prpAgent.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                    prpAgent.MobileNumber = item.MobileNumber;
                    prpAgent.PhoneNumber_STD = item.PhoneNumber_STD;
                    prpAgent.PhoneNumber_Number = item.PhoneNumber_Number;
                    prpAgent.EmailAddress = item.EmailAddress;
                    prpAgent.PAN_Number = item.PAN_Number;
                    prpAgent.Aadhaar_Number = item.Aadhaar_Number;

                    prpAgent.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                    prpAgent.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                    prpAgent.A_Column = item.A_Column;
                    prpAgent.B_Column = item.B_Column;
                    prpAgent.C_Column = item.C_Column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsActiveProvider = item.IsActiveProvider;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.IsConditional = item.IsConditional;

                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }

            if (prpAgent.AgentRenewal_IndProfile.Count >= 1)
            {
                if (prpAgent.IsConditional == 11)
                {
                    TempData["submitvalue"] = "Update"; TempData.Keep();
                }
                else
                {
                    TempData["submitvalue"] = "Save"; TempData.Keep();
                }                
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_IndividualProfile", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_IndividualProfile(Clsprp_AgentRenewal_IndividualProfile smodel)
        {
            Clsprp_AgentRenewal_IndividualProfile clspro = new Clsprp_AgentRenewal_IndividualProfile();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_Profile sdb = new ClsMethod_AgentRenewal_Profile();

            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            clspro.stateMaster = objdis.State_list();
            clspro.districtMaster = objdis.dropdownlist_display1();
            clspro.SubdivMaster = objdis.dropdownlist_diplaySubdivForAgent();
            String ext = String.Empty;
            string FilePath = string.Empty;

            string error = string.Empty;
            int errorstate = 0;
            if (TempData["submitvalue"].ToString() == "Update")
            {
                #region PhotoCertificate Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 512000)
                        {
                            #region Declare Variables
                            var pathAgentdata = "";
                            var pathindb = "";
                            string masterAgentDoc_SetFilePath = "readwriteAgentRenewal";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.Image_FilePath))
                            {
                                pathindb = smodel.Image_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(smodel.Related_Agent_ID) + "\\";
                            }
                            pathAgentdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathAgentdata))
                            {
                                Directory.CreateDirectory(pathAgentdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.Image_FileName))
                            {
                                fileName = smodel.Image_FileName.ToString();
                            }
                            else
                            {
                                fileName = "RnAgentInd_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }                            
                            var path = Path.Combine(pathAgentdata, fileName);
                            files.SaveAs(path);
                            FileName = fileName;
                            FilePath = pathindb;
                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 512KB";
                            error = "Photo Size Should be less than 512KB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg";
                        error = "Photo format should be .jpg";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Photograph";
                    error = "Kindly Upload Photograph";
                    errorstate = 1;

                    //update with same photograph
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }
                }
                #endregion

                try
                {
                    if (errorstate == 0)
                    {
                        if (FileName == "")
                        {
                            FileName = smodel.Image_FileName;
                            ext = smodel.Image_FileName;
                            FilePath = smodel.Image_FilePath;
                        }

                        if (ModelState.IsValid)
                        {
                            if (sdb.Update_AgentRenewal_IndividualProfileDetail(smodel, FileName, FilePath, UID, UserNam))
                            {
                                TempData["message"] = "Agent Details updated Successfully";

                                Session["ApplicationId"] = Convert.ToInt64(smodel.Related_Agent_ID);
                                Session["User_Type"] = Convert.ToInt32(1); //Ind Case: "1" //OTInd Case: "2"

                                Session["RenewalAgentId"] = Convert.ToInt64(smodel.RenewalAgent_ID);
                                Session["RenewalSequenceId"] = Convert.ToInt32(smodel.RenewalOrderSequence);
                                Session["RenewalAgentYear"] = Convert.ToInt32(smodel.RelatedRenewalAgent_Year);
                                Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0);
                            }
                            ModelState.Clear();
                        }

                        #region Check Isdraft value From Diary-Table
                        RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                        #endregion
                        return RedirectToAction("AgentRenewal_IndividualProfile");
                    }
                    else
                    {
                        #region Check Isdraft value From Diary-Table
                        RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                        #endregion
                        return RedirectToAction("AgentRenewal_IndividualProfile");
                    }
                }
                catch (Exception ex)
                {
                    string str = ex.ToString();
                    return View("AgentRenewal_IndividualProfile", clspro);
                }
            }
            else
            {
                #region PhotoCertificate Save with Path              
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 512000)
                        {
                            #region Declare Variables
                            var pathAgentdata = "";
                            var pathindb = "";
                            string masterAgentDoc_SetFilePath = "readwriteAgentRenewal";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(smodel.Related_Agent_ID) + "\\";
                            pathAgentdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathAgentdata))
                            {
                                Directory.CreateDirectory(pathAgentdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "RnAgentInd_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                            var path = Path.Combine(pathAgentdata, fileName);
                            files.SaveAs(path);
                            FileName = fileName;
                            FilePath = pathindb;
                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 512KB";
                            error = "Photo Size Should be less than 512KB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg";
                        error = "Photo format should be .jpg";
                        errorstate = 1;
                    }
                }
                else
                {
                    if (errorstate == 0)
                    {
                        // move existing Agent file to renewal Agent
                        #region Declare Variables
                        var outputDirectory = string.Empty;
                        var pathindb = string.Empty;
                        string masterAgentDoc_SetFilePath = "readwriteAgentRenewal";
                        var file_extn = string.Empty;
                        var file_Name = string.Empty;
                        string sourcePath = string.Empty;// "path_to_source_file";
                        string sourceFile = string.Empty;
                        #endregion

                        #region Move File Path Creation
                        if (!String.IsNullOrEmpty(smodel.Image_FilePath))
                        {
                            sourcePath = smodel.Image_FilePath.ToString();
                        }
                        var sourcePath_pathAgentdata = Server.MapPath("~/" + sourcePath);
                        if (Directory.Exists(sourcePath_pathAgentdata))
                        {                            
                            if (!String.IsNullOrEmpty(smodel.Image_FileName))
                            {
                                sourceFile = smodel.Image_FileName.ToString();
                            }

                            var source_PathFile = Path.Combine(sourcePath_pathAgentdata, sourceFile);
                            if (System.IO.File.Exists(source_PathFile))
                            {                             
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(smodel.Related_Agent_ID) + "\\";
                                outputDirectory = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(outputDirectory))
                                {
                                    Directory.CreateDirectory(outputDirectory);
                                }

                                file_extn = Path.GetExtension(sourceFile);
                                file_Name = "RnAgentInd_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + file_extn;

                                //if (System.IO.File.Exists(destinationPath))
                                //{
                                //    System.IO.File.Delete(destinationPath);
                                //}
                                // File.Move

                                System.IO.File.Copy(source_PathFile, Path.Combine(outputDirectory, file_Name));

                                FileName = file_Name;
                                FilePath = pathindb;
                            }
                            else
                            {
                                TempData["notice"] = "Kindly Upload Photograph";
                                error = "Kindly Upload Photograph";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Kindly Upload Photograph";
                            error = "Kindly Upload Photograph";
                            errorstate = 1;
                        }
                        #endregion
                    }
                    else
                    {
                        TempData["notice"] = "Kindly Upload Photograph";
                        error = "Kindly Upload Photograph";
                        errorstate = 1;
                    }
                }
                #endregion

                try
                {
                    if (errorstate == 0)
                    {
                        if (FileName == "")
                        {
                            FileName = smodel.Image_FileName;
                            ext = smodel.Image_FileName;
                            FilePath = smodel.Image_FilePath;
                        }

                        if (ModelState.IsValid)
                        {
                            //(RenewalAppID-RenewalSeqID-RenewalYear)
                            Tuple<Int64, Int32, Int32> tupleIDnSEQnYrFile = sdb.Add_AgentRenewal_IndividualProfileDetail(smodel, FileName, FilePath, UID, UserNam);
                            if (tupleIDnSEQnYrFile.Item1 > 0)
                            {
                                ViewBag.ApplicationId = tupleIDnSEQnYrFile.Item1;
                                ViewBag.Message = "Your Data is Successfully Submitted";

                                Session["ApplicationId"] = Convert.ToInt64(smodel.Related_Agent_ID);
                                Session["User_Type"] = Convert.ToInt32(1); //Ind Case: "1" //OTInd Case: "2"

                                Session["RenewalAgentId"] = Convert.ToInt64(tupleIDnSEQnYrFile.Item1);
                                Session["RenewalSequenceId"] = Convert.ToInt32(tupleIDnSEQnYrFile.Item2);
                                Session["RenewalAgentYear"] = Convert.ToInt32(tupleIDnSEQnYrFile.Item3);
                                Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0);

                                smodel.Related_Agent_ID = Convert.ToInt64(Session["ApplicationId"]);
                                smodel.Related_Agent_Type = Convert.ToInt32(Session["User_Type"]);
                                smodel.RenewalAgent_ID = Convert.ToInt64(Session["RenewalAgentId"]);
                                smodel.RenewalOrderSequence = Convert.ToInt32(Session["RenewalSequenceId"]);
                                smodel.RelatedRenewalAgent_Year = Convert.ToInt32(Session["RenewalAgentYear"]);

                                ModelState.Clear();
                            }
                        }
                        #region Check Isdraft value From Diary-Table
                        RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                        #endregion
                        return RedirectToAction("AgentRenewal_IndividualProfile");
                    }
                    else
                    {
                        #region Check Isdraft value From Diary-Table
                        RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                        #endregion
                        return RedirectToAction("AgentRenewal_IndividualProfile");
                    }
                }
                catch (Exception ex)
                {
                    string str = ex.ToString();
                    return View("AgentRenewal_IndividualProfile", clspro);
                }
            }
        }
        #endregion

        #region Agent_Renewal OtherThanIndividual Profile
        [HttpGet]
        public ActionResult AgentRenewal_OTIProfile()
        {
            #region extract-Params
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserName = string.Empty;
            string UserID = string.Empty;
            string User_Error = string.Empty;

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
                        return RedirectToAction("SessionExpire", "Account");
                    }
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

            Clsprp_AgentRenewal_OtherThanIndividualProfile prpAgent = new Clsprp_AgentRenewal_OtherThanIndividualProfile();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_Profile sdb = new ClsMethod_AgentRenewal_Profile();

            try
            {
                UserID = User.Identity.GetUserId();
                prpAgent.AgentRenewal_OTIndProfile = sdb.AgentRenewal_Display_OTIndProfile_AgentDetailByID(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                prpAgent.districtMaster = objdis.dropdownlist_display1();
                prpAgent.stateMaster = objdis.State_list();
                prpAgent.SubdivMaster = objdis.dropdownlist_diplaySubdivForAgent();                

                prpAgent.MobileNumber = Convert.ToInt64(Session["Mobile_Number"]);
                prpAgent.EmailAddress = Session["Email_Address"].ToString();

                foreach (var item in prpAgent.AgentRenewal_OTIndProfile)
                {
                    prpAgent.RenewalAgent_IndexID = item.RenewalAgent_IndexID;
                    prpAgent.RenewalAgent_ID = item.RenewalAgent_ID;
                    prpAgent.RenewalOrderSequence = item.RenewalOrderSequence;
                    prpAgent.RelatedRenewalAgent_Year = item.RelatedRenewalAgent_Year;
                    prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                    prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                    prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                    prpAgent.Related_UserID = item.Related_UserID;
                    prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                    prpAgent.Related_RERAnumberIssueDate = item.Related_RERAnumberIssueDate;
                    prpAgent.Related_RERAnumberRegUptoDate = item.Related_RERAnumberRegUptoDate;
                    prpAgent.Agent_Type = item.Agent_Type;

                    prpAgent.IsAlready_RERANumber = item.IsAlready_RERANumber;
                    prpAgent.Existing_RERANumber = item.Existing_RERANumber;
                    prpAgent.Mode_RegistrationNumber = item.Mode_RegistrationNumber;

                    prpAgent.Organization_Name = item.Organization_Name;
                    prpAgent.Organization_TypeCode = item.Organization_TypeCode;
                    prpAgent.Organization_PAN_Number = item.Organization_PAN_Number;
                    prpAgent.Organization_MainObjects = item.Organization_MainObjects;

                    prpAgent.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    prpAgent.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    prpAgent.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                    prpAgent.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                    prpAgent.RegOffice_AddressPIN = item.RegOffice_AddressPIN;

                    prpAgent.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    prpAgent.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    prpAgent.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    prpAgent.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    prpAgent.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                    prpAgent.BusinessPlace_AddressSubDivisionCode = item.BusinessPlace_AddressSubDivisionCode;
                    prpAgent.BusinessPlace_AddressSubDivisionName = item.BusinessPlace_AddressSubDivisionName;

                    prpAgent.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                    prpAgent.BComm_AddressLine1 = item.BComm_AddressLine1;
                    prpAgent.BComm_AddressLine2 = item.BComm_AddressLine2;
                    prpAgent.BComm_AddressStateCode = item.BComm_AddressStateCode;
                    prpAgent.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    prpAgent.BComm_AddressPIN = item.BComm_AddressPIN;

                    prpAgent.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                    prpAgent.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    prpAgent.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                    prpAgent.MobileNumber = item.MobileNumber;
                    prpAgent.PhoneNumber_STD = item.PhoneNumber_STD;
                    prpAgent.PhoneNumber_Number = item.PhoneNumber_Number;
                    prpAgent.EmailAddress = item.EmailAddress;
                    prpAgent.PAN_Number = item.PAN_Number;
                    prpAgent.Aadhaar_Number = item.Aadhaar_Number;

                    prpAgent.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                    prpAgent.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                    prpAgent.A_Column = item.A_Column;
                    prpAgent.B_Column = item.B_Column;
                    prpAgent.C_Column = item.C_Column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsActiveProvider = item.IsActiveProvider;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.IsConditional = item.IsConditional;

                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }

            if (prpAgent.AgentRenewal_OTIndProfile.Count >= 1)
            {
                if (prpAgent.IsConditional == 11)
                {
                    TempData["submitvalue"] = "Update"; TempData.Keep();
                }
                else
                {
                    TempData["submitvalue"] = "Save"; TempData.Keep();
                }
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OTIProfile", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_OTIProfile(Clsprp_AgentRenewal_OtherThanIndividualProfile smodel)
        {
            Clsprp_AgentRenewal_OtherThanIndividualProfile clspro = new Clsprp_AgentRenewal_OtherThanIndividualProfile();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_Profile sdb = new ClsMethod_AgentRenewal_Profile();

            string error = string.Empty;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            clspro.stateMaster = objdis.State_list();
            clspro.districtMaster = objdis.dropdownlist_display1();
            clspro.SubdivMaster = objdis.dropdownlist_diplaySubdivForAgent();

            try
            {
                if (ModelState.IsValid)
                {
                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        if (sdb.Update_AgentRenewal_OtherThanIndividualProfileDetail(smodel, UID, UserNam))
                        {
                            ViewBag.Message = "Agent  Details updated Successfully";

                            Session["ApplicationId"] = Convert.ToInt64(smodel.Related_Agent_ID);
                            Session["User_Type"] = Convert.ToInt32(2); //Ind Case: "1" //OTInd Case: "2"

                            Session["RenewalAgentId"] = Convert.ToInt64(smodel.RenewalAgent_ID);
                            Session["RenewalSequenceId"] = Convert.ToInt32(smodel.RenewalOrderSequence);
                            Session["RenewalAgentYear"] = Convert.ToInt32(smodel.RelatedRenewalAgent_Year);
                            Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0);
                        }
                        ModelState.Clear();

                        #region Check Isdraft value From Diary-Table
                        RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                        #endregion
                        return RedirectToAction("AgentRenewal_OTIProfile");
                    }
                    else
                    {
                        #region SAVE code                      
                        //(RenewalAppID-RenewalSeqID-RenewalYear)
                        Tuple<Int64, Int32, Int32> tupleIDnSEQnYrFile = sdb.Add_AgentRenewal_OtherThanIndividualProfileDetail(smodel, UID, UserNam);
                        if (tupleIDnSEQnYrFile.Item1 > 0)
                        {
                            ViewBag.ApplicationId = tupleIDnSEQnYrFile.Item1;
                            ViewBag.Message = "Your Data is Successfully Submitted";

                            Session["ApplicationId"] = Convert.ToInt64(smodel.Related_Agent_ID);
                            Session["User_Type"] = Convert.ToInt32(2); //Ind Case: "1" //OTInd Case: "2"

                            Session["RenewalAgentId"] = Convert.ToInt64(tupleIDnSEQnYrFile.Item1);
                            Session["RenewalSequenceId"] = Convert.ToInt32(tupleIDnSEQnYrFile.Item2);
                            Session["RenewalAgentYear"] = Convert.ToInt32(tupleIDnSEQnYrFile.Item3);
                            Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0);

                            smodel.Related_Agent_ID = Convert.ToInt64(Session["ApplicationId"]);
                            smodel.Related_Agent_Type = Convert.ToInt32(Session["User_Type"]);
                            smodel.RenewalAgent_ID = Convert.ToInt64(Session["RenewalAgentId"]);
                            smodel.RenewalOrderSequence = Convert.ToInt32(Session["RenewalSequenceId"]);
                            smodel.RelatedRenewalAgent_Year = Convert.ToInt32(Session["RenewalAgentYear"]);

                            ModelState.Clear();
                        }

                        #region Check Isdraft value From Diary-Table
                        RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                        #endregion
                        return RedirectToAction("AgentRenewal_OTIProfile");
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                String e = ex.Message;
            }

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OTIProfile", clspro);
        }
        #endregion

        #region Agent_Renewal OtherMemberDetail
        [HttpGet]
        public ActionResult AgentRenewal_IO_OTIProfile_OrgMemberDetail()
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
                        User_KeyID = 1; //members
                        ynOtherMember = "Y";
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
                            if (prpAgent.Is_YesNo_RenewalAgent_OtherMembers == 1)
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
                                return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
                            }
                            else
                            {
                                //NA Case :- Error (organization member(s) : NIL)
                                User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form submitted without corrected options ('Yes'/'No') of organization member(s) OR have not any organization member(s) (e.g. Chairman, Partner, Director or Other Authorized Signatory). Please sign-in with corrected options of application form of real-estate agent.";
                            }
                        }
                        else
                        {
                            //NA Case :- Error (organization member(s) : Not Applicable)
                            User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form for other organization member(s). Please sign-in with registered real-estate agent with the Authority.";
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
            return View("AgentRenewal_IO_OTIProfile_OrgMemberDetail", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_OTIProfile_OrgMemberDetail()
        {
            Clsprp_AgentRenewal_OtherMemberDetail prpAgent = new Clsprp_AgentRenewal_OtherMemberDetail();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherMemberDetail sdb = new ClsMethod_AgentRenewal_OtherMemberDetail();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
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

                        //Extract records
                        UserID = User.Identity.GetUserId();
                        prpAgent.AgentRenewal_OtherMember = sdb.AgentRenewal_Display_OtherMember_AgentDetailByID(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                        foreach (var item in prpAgent.AgentRenewal_OtherMember)
                        {
                            prpAgent.RenewalAgent_OtherMember_IndexID = item.RenewalAgent_OtherMember_IndexID;
                            prpAgent.RenewalAgent_OtherMember_ID = item.RenewalAgent_OtherMember_ID;

                            prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                            prpAgent.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                            prpAgent.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                            prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                            prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                            prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                            prpAgent.Related_UserID = item.Related_UserID;
                            prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                            prpAgent.Related_Agent_OtherMemberDetails_ID = item.Related_Agent_OtherMemberDetails_ID;

                            prpAgent.IsActive = item.IsActive;
                            prpAgent.IsActiveProvider = item.IsActiveProvider;
                            prpAgent.IsDraft = item.IsDraft;
                            prpAgent.IsLock = item.IsLock;
                            prpAgent.IsPublicView = item.IsPublicView;
                            prpAgent.IsConditional = item.IsConditional;
                        }
                        prpAgent.Related_Agent_Type = User_TypeOfAgent;
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
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

            TempData["submitvalue"] = "Save"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OTIProfile_OrgMemberDetail", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_OTIProfile_OrgMemberDetail(Clsprp_AgentRenewal_OtherMemberDetail smodel)
        {
            Clsprp_AgentRenewal_OtherMemberDetail prpAgent = new Clsprp_AgentRenewal_OtherMemberDetail();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherMemberDetail sdb = new ClsMethod_AgentRenewal_OtherMemberDetail();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            string ext = string.Empty;
            string FileName = string.Empty;
            string FilePath = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
                prpAgent.districtMaster = objdis.dropdownlist_display1();

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
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }

                #region Save and Update
                string error = string.Empty;
                int errorstate = 0;
                if (TempData["submitvalue"].ToString() == "Update")
                {
                    #region PhotoCertificate Update with Path
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                    {
                        var files = Request.Files[0];
                        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                        ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            int size = files.ContentLength;
                            if (size <= 512000)
                            {
                                #region Declare Variables
                                var pathAgentdata = string.Empty;
                                var pathindb = string.Empty;
                                string masterAgentDoc_SetFilePath = "readwriteAgentRnldata";
                                #endregion
                                #region UpdateFile Path Creation 
                                if (!String.IsNullOrEmpty(smodel.Image_FilePath))
                                {
                                    pathindb = smodel.Image_FilePath.ToString();
                                }
                                else
                                {
                                    pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(User_RenewalAgentID) + "\\";
                                }
                                pathAgentdata = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(pathAgentdata))
                                {
                                    Directory.CreateDirectory(pathAgentdata);
                                }
                                #endregion

                                var fileName = string.Empty;
                                if (!String.IsNullOrEmpty(smodel.Image_FileName))
                                {
                                    fileName = smodel.Image_FileName.ToString();
                                }
                                else
                                {
                                    fileName = "RnAgentMem_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                }
                                var path = Path.Combine(pathAgentdata, fileName);
                                files.SaveAs(path);
                                FileName = fileName;
                                FilePath = pathindb;
                            }
                            else
                            {
                                TempData["notice"] = "Photo Size Should be less than 512KB";
                                error = "Photo Size Should be less than 512KB";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Photo format should be .jpg";
                            error = "Photo format should be .jpg";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Kindly Upload Photograph";
                        error = "Kindly Upload Photograph";
                        errorstate = 1;

                        //update with same photograph
                        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                        {
                            errorstate = 0;
                        }
                    }
                    #endregion                                        
                    if (errorstate == 0)
                    {
                        if (FileName == "")
                        {
                            FileName = smodel.Image_FileName;
                            ext = smodel.Image_FileName;
                            FilePath = smodel.Image_FilePath;
                        }

                        if (ModelState.IsValid)
                        {
                            UserID = User.Identity.GetUserId();
                            UserName = User.Identity.Name;
                            prpAgent.Related_Agent_Type = User_TypeOfAgent;
                            if (sdb.Update_AgentRenewal_OtherMember_AgentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                            {
                                TempData["message"] = "Details updated Successfully";
                            }
                            ModelState.Clear();
                        }
                        return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
                    }
                    else
                    {
                        return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
                    }
                }
                else
                {
                    #region PhotoCertificate Save with Path
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                    {
                        var files = Request.Files[0];
                        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                        ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            int size = files.ContentLength;
                            if (size <= 512000)
                            {
                                #region Declare Variables
                                var pathAgentdata = string.Empty;
                                var pathindb = string.Empty;
                                string masterAgentDoc_SetFilePath = "readwriteAgentRnldata";
                                #endregion
                                #region SaveFile Path Creation
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(User_RenewalAgentID) + "\\";
                                pathAgentdata = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(pathAgentdata))
                                {
                                    Directory.CreateDirectory(pathAgentdata);
                                }
                                #endregion
                                var fileName = string.Empty;
                                fileName = "RnAgentMem_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                var path = Path.Combine(pathAgentdata, fileName);
                                files.SaveAs(path);
                                FileName = fileName;
                                FilePath = pathindb;
                            }
                            else
                            {
                                TempData["notice"] = "Photo Size Should be less than 512KB";
                                error = "Photo Size Should be less than 512KB";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Photo format should be .jpg";
                            error = "Photo format should be .jpg";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Kindly Upload Photograph";
                        error = "Kindly Upload Photograph";
                        errorstate = 1;
                    }
                    #endregion
                    if (errorstate == 0)
                    {
                        if (FileName == "")
                        {
                            FileName = smodel.Image_FileName;
                            ext = smodel.Image_FileName;
                            FilePath = smodel.Image_FilePath;
                        }
                        if (ModelState.IsValid)
                        {
                            UserID = User.Identity.GetUserId();
                            UserName = User.Identity.Name;
                            prpAgent.Related_Agent_Type = User_TypeOfAgent;
                            if (sdb.Add_AgentRenewal_OtherMember_AgentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                            {
                                TempData["Message"] = "Details submitted Successfully";                                
                            }
                            ModelState.Clear();
                        }
                        return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
                    }
                    else
                    {
                        return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
                    }                    
                }
                #endregion
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }

            TempData["submitvalue"] = "Save"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OTIProfile_OrgMemberDetail", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_EditOTIProfile_OrgMemberDetail(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID)
        {
            Clsprp_AgentRenewal_OtherMemberDetail prpAgent = new Clsprp_AgentRenewal_OtherMemberDetail();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherMemberDetail sdb = new ClsMethod_AgentRenewal_OtherMemberDetail();

            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
                prpAgent.districtMaster = objdis.dropdownlist_display1();

                User_AgentID = KeyID;
                User_RenewalAgentID = RnKeyID;
                User_IndexID = IndexID;
                User_ExtractID = OtherID;

                //Extract records
                UserID = User.Identity.GetUserId();
                prpAgent.AgentRenewal_OtherMember = sdb.AgentRenewal_ExtractRecord_OtherMember_AgentDetailByID(User_IndexID, User_ExtractID, User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                foreach (var item in prpAgent.AgentRenewal_OtherMember)
                {
                    prpAgent.RenewalAgent_OtherMember_IndexID = item.RenewalAgent_OtherMember_IndexID;
                    prpAgent.RenewalAgent_OtherMember_ID = item.RenewalAgent_OtherMember_ID;

                    prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                    prpAgent.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                    prpAgent.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                    prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                    prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                    prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                    prpAgent.Related_UserID = item.Related_UserID;
                    prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                    prpAgent.Related_Agent_OtherMemberDetails_ID = item.Related_Agent_OtherMemberDetails_ID;

                    prpAgent.Designation = item.Designation;
                    prpAgent.OtherMember_Name = item.OtherMember_Name;
                    prpAgent.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                    prpAgent.OtherMember_Aadhaar_Number = item.OtherMember_Aadhaar_Number;

                    prpAgent.OfficeComm_AddressLine1 = item.OfficeComm_AddressLine1;
                    prpAgent.OfficeComm_AddressLine2 = item.OfficeComm_AddressLine2;
                    prpAgent.OfficeComm_AddressStateCode = item.OfficeComm_AddressStateCode;
                    prpAgent.OfficeComm_AddressDistrictCode = item.OfficeComm_AddressDistrictCode;
                    prpAgent.OfficeComm_AddressPIN = item.OfficeComm_AddressPIN;

                    prpAgent.MobileNumber = item.MobileNumber;
                    prpAgent.PhoneNumber_STD = item.PhoneNumber_STD;
                    prpAgent.PhoneNumber_Number = item.PhoneNumber_Number;
                    prpAgent.EmailAddress = item.EmailAddress;

                    prpAgent.Image_FileName = item.Image_FileName;
                    prpAgent.Image_FilePath = item.Image_FilePath;
                    prpAgent.Image_FileSize = item.Image_FileSize;
                    prpAgent.Image_FileType = item.Image_FileType;

                    prpAgent.A_column = item.A_column;
                    prpAgent.B_column = item.B_column;
                    prpAgent.C_column = item.C_column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsActiveProvider = item.IsActiveProvider;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.IsConditional = item.IsConditional;

                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }

            TempData["submitvalue"] = "Update"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OTIProfile_OrgMemberDetail", prpAgent);
        }

        public ActionResult AgentRenewal_DeleteOTIProfile_OrgMemberDetail(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID)
        {
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_RenewalAgentID = 0;
            Int64 User_AgentID = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                User_IndexID = IndexID;
                User_ExtractID = OtherID;
                User_RenewalAgentID = RnKeyID;
                User_AgentID = KeyID;
                UserID = User.Identity.GetUserId();
                UserName = User.Identity.Name;

                ClsMethod_AgentRenewal_OtherMemberDetail sdb = new ClsMethod_AgentRenewal_OtherMemberDetail();
                if (sdb.Delete_AgentRenewal_OtherMemberDetail_byID(User_IndexID, User_ExtractID, User_RenewalAgentID, User_AgentID, UserID))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
                return RedirectToAction("AgentRenewal_OTIProfile_OrgMemberDetail");
            }
        }
        #endregion

        #region Agent_Renewal OtherStateUT_RERAdetail
        [HttpGet]
        public ActionResult AgentRenewal_IO_OtherStateUT_RERAdetail()
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
                        User_KeyID = 3;//stateUT-rera
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
                            if (prpAgent.Is_YesNo_RenewalAgent_OtherStateUTnumber == 1)
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
                                return RedirectToAction("AgentRenewal_OtherStateUT_RERAdetail");
                            }
                            else
                            {
                                //NA Case :- Error (Other-StateUT RERA_Number : NIL)
                                User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form submitted without corrected options ('Yes'/'No') of other state/UT registration number OR have not any other state/UT(s) registration number. Please sign-in with corrected options of application form of real-estate agent.";
                            }
                        }
                        else
                        {
                            //NA Case :- Error (Other-StateUT RERA_Number : Not Applicable)
                            User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form for other state/UT registration number. Please sign-in with registered real-estate agent with the Authority.";
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
            return View("AgentRenewal_IO_OtherStateUT_RERAdetail", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_OtherStateUT_RERAdetail()
        {
            Clsprp_AgentRenewal_OtherStateUT_RERAdetails prpAgent = new Clsprp_AgentRenewal_OtherStateUT_RERAdetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherStateUTRegistration sdb = new ClsMethod_AgentRenewal_OtherStateUTRegistration();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
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

                        //Extract records
                        UserID = User.Identity.GetUserId();
                        prpAgent.AgentRenewal_OtherStateUT = sdb.AgentRenewal_Display_OtherStateUTRERA_AgentDetailByID(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                        foreach (var item in prpAgent.AgentRenewal_OtherStateUT)
                        {
                            prpAgent.RenewalAgent_ID = item.RenewalAgent_ID;
                            prpAgent.RenewalOrderSequence = item.RenewalOrderSequence;
                            prpAgent.RelatedRenewalAgent_Year = item.RelatedRenewalAgent_Year;
                            prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                            prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                            prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                            prpAgent.Related_UserID = item.Related_UserID;
                            prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                            prpAgent.Related_Agent_OtherStateUT_regRERA_ID = item.Related_Agent_OtherStateUT_regRERA_ID;

                            prpAgent.IsActive = item.IsActive;
                            prpAgent.IsActiveProvider = item.IsActiveProvider;
                            prpAgent.IsDraft = item.IsDraft;
                            prpAgent.IsLock = item.IsLock;
                            prpAgent.IsPublicView = item.IsPublicView;
                            prpAgent.IsConditional = item.IsConditional;
                        }
                        prpAgent.Related_Agent_Type = User_TypeOfAgent;
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
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

            TempData["submitvalue"] = "Save"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OtherStateUT_RERAdetail", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_OtherStateUT_RERAdetail(Clsprp_AgentRenewal_OtherStateUT_RERAdetails smodel)
        {
            Clsprp_AgentRenewal_OtherStateUT_RERAdetails prpAgent = new Clsprp_AgentRenewal_OtherStateUT_RERAdetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherStateUTRegistration sdb = new ClsMethod_AgentRenewal_OtherStateUTRegistration();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            string FileName = string.Empty;
            string FilePath = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
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
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }

                if (ModelState.IsValid)
                {
                    UserID = User.Identity.GetUserId();
                    UserName = User.Identity.Name;
                    prpAgent.Related_Agent_Type = User_TypeOfAgent;
                    if (sdb.Add_AgentRenewal_OtherStateUTRERA_AgentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                    {
                        ViewBag.Message = "Your Data is Successfully Submitted";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("AgentRenewal_OtherStateUT_RERAdetail");
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }

            TempData["submitvalue"] = "Save"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OtherStateUT_RERAdetail", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_EditOtherStateUT_RERAdetail(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID)
        {
            Clsprp_AgentRenewal_OtherStateUT_RERAdetails prpAgent = new Clsprp_AgentRenewal_OtherStateUT_RERAdetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherStateUTRegistration sdb = new ClsMethod_AgentRenewal_OtherStateUTRegistration();

            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
                
                User_AgentID = KeyID;
                User_RenewalAgentID = RnKeyID;
                User_IndexID = IndexID;
                User_ExtractID = OtherID;

                //Extract records
                UserID = User.Identity.GetUserId();
                prpAgent.AgentRenewal_OtherStateUT = sdb.AgentRenewal_ExtractRecord_OtherStateUTRERA_AgentDetailByID(User_IndexID, User_ExtractID, User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                foreach (var item in prpAgent.AgentRenewal_OtherStateUT)
                {
                    prpAgent.AgentRenewal_OtherStateUT_regRERA_IndexID = item.AgentRenewal_OtherStateUT_regRERA_IndexID;
                    prpAgent.AgentRenewal_OtherStateUT_regRERA_ID = item.AgentRenewal_OtherStateUT_regRERA_ID;

                    prpAgent.RenewalAgent_ID = item.RenewalAgent_ID;
                    prpAgent.RenewalOrderSequence = item.RenewalOrderSequence;
                    prpAgent.RelatedRenewalAgent_Year = item.RelatedRenewalAgent_Year;
                    prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                    prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                    prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                    prpAgent.Related_UserID = item.Related_UserID;
                    prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                    prpAgent.Related_Agent_OtherStateUT_regRERA_ID = item.Related_Agent_OtherStateUT_regRERA_ID;

                    prpAgent.StateCode = item.StateCode;
                    prpAgent.State_Name = item.State_Name;
                    prpAgent.RERAregistration_Number = item.RERAregistration_Number;
                    prpAgent.RERAregistration_IssueDate = item.RERAregistration_IssueDate;
                    prpAgent.RERAregistration_ExpiryDate = item.RERAregistration_ExpiryDate;

                    prpAgent.ImageRERAcert_FileName = item.ImageRERAcert_FileName;
                    prpAgent.ImageRERAcert_FilePath = item.ImageRERAcert_FilePath;
                    prpAgent.ImageRERAcert_FileSize = item.ImageRERAcert_FileSize;
                    prpAgent.ImageRERAcert_FileType = item.ImageRERAcert_FileType;

                    prpAgent.Remarks_IfAny = item.Remarks_IfAny;
                    prpAgent.A_Column = item.A_Column;
                    prpAgent.B_Column = item.B_Column;
                    prpAgent.C_Column = item.C_Column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsActiveProvider = item.IsActiveProvider;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.IsConditional = item.IsConditional;

                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }               
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }

            TempData["submitvalue"] = "Update"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OtherStateUT_RERAdetail", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_EditOtherStateUT_RERAdetail(Clsprp_AgentRenewal_OtherStateUT_RERAdetails smodel)
        {
            Clsprp_AgentRenewal_OtherStateUT_RERAdetails prpAgent = new Clsprp_AgentRenewal_OtherStateUT_RERAdetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AgentRenewal_OtherStateUTRegistration sdb = new ClsMethod_AgentRenewal_OtherStateUTRegistration();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.stateMaster = objdis.State_list();
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
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }

                if (ModelState.IsValid)
                {
                    UserID = User.Identity.GetUserId();
                    UserName = User.Identity.Name;
                    if (sdb.Update_AgentRenewal_OtherStateUTRERA_AgentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                    {
                        TempData["message"] = "Details updated Successfully";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("AgentRenewal_OtherStateUT_RERAdetail");
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
                TempData["message"] = ex.ToString();
            }

            TempData["submitvalue"] = "Save"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_OtherStateUT_RERAdetail", prpAgent);
        }

        public ActionResult AgentRenewal_DeleteOtherStateUT_RERAdetail(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID)
        { 
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_RenewalAgentID = 0;
            Int64 User_AgentID = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                User_IndexID = IndexID;
                User_ExtractID = OtherID;
                User_RenewalAgentID = RnKeyID; 
                User_AgentID = KeyID;
                UserID = User.Identity.GetUserId();
                UserName = User.Identity.Name;

                ClsMethod_AgentRenewal_OtherStateUTRegistration sdb = new ClsMethod_AgentRenewal_OtherStateUTRegistration();
                if (sdb.Delete_AgentRenewal_OtherStateUTRERADetail_byID(User_IndexID, User_ExtractID, User_RenewalAgentID, User_AgentID, UserID))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("AgentRenewal_OtherStateUT_RERAdetail");
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
                return RedirectToAction("AgentRenewal_OtherStateUT_RERAdetail");
            }
        }
        #endregion

        #region Agent_Renewal ApplicationPayment
        [HttpGet]
        public ActionResult AgentRenewal_IO_ApplicationPayment()
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
                        User_KeyID = 4; //payments                     
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
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                        else
                        {
                            //NA Case :- Error (Other-StateUT RERA_Number : Not Applicable)
                            User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form for payment of registration or any other fee. Please sign-in with registered real-estate agent with the Authority.";
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
            return View("AgentRenewal_IO_ApplicationPayment", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_ApplicationPayment()
        {
            Clsprp_AgentRenewal_Payment prpAgent = new Clsprp_AgentRenewal_Payment();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            ClsMethod_AgentRenewal_FeePayments sdb = new ClsMethod_AgentRenewal_FeePayments();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.BankMaster = Bmaster.Display_Master_BankDetails();
                prpAgent.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

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
                    //Algo Cases
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

                        //Extract records
                        UserID = User.Identity.GetUserId();
                        prpAgent.ARFeePayment = sdb.Display_AgentRenewal_FeePaymentDetail(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                        foreach (var item in prpAgent.ARFeePayment)
                        {
                            prpAgent.RenewalAgent_FeePayment_IndexID = item.RenewalAgent_FeePayment_IndexID;
                            prpAgent.RenewalAgent_FeePayment_ID = item.RenewalAgent_FeePayment_ID;
                            prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                            prpAgent.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                            prpAgent.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                            prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                            prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                            prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                            prpAgent.Related_UserID = item.Related_UserID;
                            prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                            prpAgent.Related_AgentPayment_ID = item.Related_AgentPayment_ID;

                            prpAgent.IsActive = item.IsActive;
                            prpAgent.IsActiveProvider = item.IsActiveProvider;
                            prpAgent.IsDraft = item.IsDraft;
                            prpAgent.IsLock = item.IsLock;
                            prpAgent.IsPublicView = item.IsPublicView;
                            prpAgent.IsConditional = item.IsConditional;
                        }
                        prpAgent.Related_Agent_Type = User_TypeOfAgent;
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
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

            TempData["submitvalue"] = "Save"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_ApplicationPayment", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_ApplicationPayment(Clsprp_AgentRenewal_Payment smodel)
        {
            Clsprp_AgentRenewal_Payment prpAgent = new Clsprp_AgentRenewal_Payment();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            ClsMethod_AgentRenewal_FeePayments sdb = new ClsMethod_AgentRenewal_FeePayments();

            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            string ext = string.Empty;
            string FileName = string.Empty;
            string FilePath = string.Empty;

            try
            {
                prpAgent.BankMaster = Bmaster.Display_Master_BankDetails();
                prpAgent.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

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
                    }
                    else
                    {
                        //NA Case :- Error (Mapping error between renewal_ID)
                        User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }

                if (smodel.Payment_Mode != "Online Payment")
                {
                    TempData["OnlinePayMessageShow"] = "The online payment will be accepted Only.";
                    #region Save and Update
                    string error = string.Empty;
                    int errorstate = 0;
                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        #region PhotoCertificate Update with Path
                        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                        {
                            var files = Request.Files[0];
                            var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                            ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                int size = files.ContentLength;
                                if (size <= 512000)
                                {
                                    #region Declare Variables
                                    var pathAgentdata = string.Empty;
                                    var pathindb = string.Empty;
                                    string masterAgentDoc_SetFilePath = "readwriteAgentRnldata";
                                    #endregion
                                    #region UpdateFile Path Creation 
                                    if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FilePath))
                                    {
                                        pathindb = smodel.ImageDDorBankersCheque_FilePath.ToString();
                                    }
                                    else
                                    {
                                        pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(User_RenewalAgentID) + "\\";
                                    }
                                    pathAgentdata = Server.MapPath("~/" + pathindb);

                                    if (!Directory.Exists(pathAgentdata))
                                    {
                                        Directory.CreateDirectory(pathAgentdata);
                                    }
                                    #endregion

                                    var fileName = string.Empty;
                                    if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FileName))
                                    {
                                        fileName = smodel.ImageDDorBankersCheque_FileName.ToString();
                                    }
                                    else
                                    {
                                        fileName = "RnAgentFee_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                    }
                                    var path = Path.Combine(pathAgentdata, fileName);
                                    files.SaveAs(path);
                                    FileName = fileName;
                                    FilePath = pathindb;
                                }
                                else
                                {
                                    TempData["notice"] = "Scan Copy Size Should be less than 512KB";
                                    error = "Scan Copy Size Should be less than 512KB";
                                    errorstate = 1;
                                }
                            }
                            else
                            {
                                TempData["notice"] = "Scan Copy format should be .jpg";
                                error = "Scan Copy format should be .jpg";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Kindly Upload Scan Copy";
                            error = "Kindly Upload Scan Copy";
                            errorstate = 1;

                            //update with same photograph
                            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                            {
                                errorstate = 0;
                            }
                        }
                        #endregion
                        if (errorstate == 0)
                        {
                            if (FileName == "")
                            {
                                FileName = smodel.ImageDDorBankersCheque_FileName;
                                ext = smodel.ImageDDorBankersCheque_FileName;
                                FilePath = smodel.ImageDDorBankersCheque_FilePath;
                            }

                            if (ModelState.IsValid)
                            {
                                UserID = User.Identity.GetUserId();
                                UserName = User.Identity.Name;
                                prpAgent.Related_Agent_Type = User_TypeOfAgent;
                                if (sdb.Update_AgentRenewal_FeePaymentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                                {
                                    TempData["message"] = "Details updated Successfully";
                                }
                                ModelState.Clear();
                            }

                            #region Check Isdraft value From Diary-Table
                            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                            #endregion
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                        else
                        {
                            #region Check Isdraft value From Diary-Table
                            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                            #endregion
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                    }
                    else
                    {
                        #region PhotoCertificate Save with Path
                        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                        {
                            var files = Request.Files[0];
                            var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                            ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                int size = files.ContentLength;
                                if (size <= 512000)
                                {
                                    #region Declare Variables
                                    var pathAgentdata = string.Empty;
                                    var pathindb = string.Empty;
                                    string masterAgentDoc_SetFilePath = "readwriteAgentRnldata";
                                    #endregion
                                    #region SaveFile Path Creation
                                    pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(User_RenewalAgentID) + "\\";
                                    pathAgentdata = Server.MapPath("~/" + pathindb);

                                    if (!Directory.Exists(pathAgentdata))
                                    {
                                        Directory.CreateDirectory(pathAgentdata);
                                    }
                                    #endregion
                                    var fileName = string.Empty;
                                    fileName = "RnAgentFee_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                    var path = Path.Combine(pathAgentdata, fileName);
                                    files.SaveAs(path);
                                    FileName = fileName;
                                    FilePath = pathindb;
                                }
                                else
                                {
                                    TempData["notice"] = "Scan Copy Size Should be less than 512KB";
                                    error = "Scan Copy Size Should be less than 512KB";
                                    errorstate = 1;
                                }
                            }
                            else
                            {
                                TempData["notice"] = "Scan Copy format should be .jpg";
                                error = "Scan Copy format should be .jpg";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Kindly Upload Scan Copy";
                            error = "Kindly Upload Scan Copy";
                            errorstate = 1;
                        }
                        #endregion
                        if (errorstate == 0)
                        {
                            if (FileName == "")
                            {
                                FileName = smodel.ImageDDorBankersCheque_FileName;
                                ext = smodel.ImageDDorBankersCheque_FileName;
                                FilePath = smodel.ImageDDorBankersCheque_FilePath;
                            }
                            //To stop/disable SAVE (New Agent Payment) on Nov 01,2018 for (Form-J)
                            //if (ModelState.IsValid)
                            //{
                            //    UserID = User.Identity.GetUserId();
                            //    UserName = User.Identity.Name;
                            //    prpAgent.Related_Agent_Type = User_TypeOfAgent;
                            //    if (sdb.Add_AgentRenewal_FeePaymentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                            //    {
                            //        TempData["Message"] = "Details submitted Successfully";
                            //    }
                            //    ModelState.Clear();
                            //}
                            TempData["OnlinePayMessageShow"] = "The online payment will be accepted Only.";
                            #region Check Isdraft value From Diary-Table
                            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                            #endregion
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                        else
                        {
                            #region Check Isdraft value From Diary-Table
                            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                            #endregion
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                    }
                    #endregion                    
                }
                else if (smodel.Payment_Mode == "Online Payment")
                {
                    FileName = string.Empty;
                    ext = string.Empty;
                    FilePath = string.Empty;

                    smodel.Bank_Charges = Convert.ToDecimal(0.00);
                    smodel.Date_of_Payment_RegistrationFee = new DateTime(0001, 1, 1);
                    smodel.Bank_Name = string.Empty;
                    smodel.Branch_Name = string.Empty;
                    smodel.DD_BankersCheque_Number = 0;
                    smodel.DD_BankersCheque_Amount = Convert.ToDecimal(smodel.Registration_Fee + smodel.Other_Fee);
                    smodel.ImageDDorBankersCheque_FileName = string.Empty;
                    smodel.ImageDDorBankersCheque_FilePath = string.Empty;

                    try
                    {
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            if (true) //ModelState.IsValid
                            {
                                UserID = User.Identity.GetUserId();
                                UserName = User.Identity.Name;
                                prpAgent.Related_Agent_Type = User_TypeOfAgent;
                                if (sdb.Update_AgentRenewal_FeePaymentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                                {
                                    TempData["message"] = "Details updated Successfully";
                                }
                                ModelState.Clear();
                            }

                            #region Check Isdraft value From Diary-Table
                            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                            #endregion
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                        else
                        {
                            if (true) //ModelState.IsValid
                            {
                                UserID = User.Identity.GetUserId();
                                UserName = User.Identity.Name;
                                prpAgent.Related_Agent_Type = User_TypeOfAgent;
                                if (sdb.Add_AgentRenewal_FeePaymentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                                {
                                    TempData["Message"] = "Details submitted Successfully";
                                }
                                ModelState.Clear();
                            }

                            #region Check Isdraft value From Diary-Table
                            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                            #endregion
                            return RedirectToAction("AgentRenewal_ApplicationPayment");
                        }
                    }
                    catch (Exception ex)
                    {
                        string exIvariable = ex.ToString();
                        return View("AgentRenewal_ApplicationPayment");
                    }
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();                
            }

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_ApplicationPayment", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_EditApplicationPayment(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID)
        {
            Clsprp_AgentRenewal_Payment prpAgent = new Clsprp_AgentRenewal_Payment();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            ClsMethod_AgentRenewal_FeePayments sdb = new ClsMethod_AgentRenewal_FeePayments();

            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                prpAgent.BankMaster = Bmaster.Display_Master_BankDetails();
                prpAgent.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

                User_AgentID = KeyID;
                User_RenewalAgentID = RnKeyID;
                User_IndexID = IndexID;
                User_ExtractID = OtherID;

                //Extract records
                UserID = User.Identity.GetUserId();
                prpAgent.ARFeePayment = sdb.AgentRenewal_ExtractRecord_FeePaymentByID(User_IndexID, User_ExtractID, User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                foreach (var item in prpAgent.ARFeePayment)
                {
                    prpAgent.RenewalAgent_FeePayment_IndexID = item.RenewalAgent_FeePayment_IndexID;
                    prpAgent.RenewalAgent_FeePayment_ID = item.RenewalAgent_FeePayment_ID;

                    prpAgent.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                    prpAgent.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                    prpAgent.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                    prpAgent.Related_Agent_ID = item.Related_Agent_ID;
                    prpAgent.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                    prpAgent.Related_Agent_Type = item.Related_Agent_Type;
                    prpAgent.Related_UserID = item.Related_UserID;
                    prpAgent.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                    prpAgent.Related_AgentPayment_ID = item.Related_AgentPayment_ID;

                    prpAgent.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                    prpAgent.AgentPayment_TitleName = item.AgentPayment_TitleName;
                    prpAgent.Registration_Fee = item.Registration_Fee;
                    prpAgent.Other_Fee = item.Other_Fee;
                    prpAgent.Payment_Mode = item.Payment_Mode;
                    prpAgent.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    prpAgent.Bank_Charges = item.Bank_Charges;
                    prpAgent.Bank_Name = item.Bank_Name;
                    prpAgent.Branch_Name = item.Branch_Name;
                    prpAgent.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    prpAgent.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    prpAgent.FeePayment_ByFeeCalculator_Amount = item.FeePayment_ByFeeCalculator_Amount;
                    prpAgent.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                    prpAgent.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;

                    prpAgent.A_column = item.A_column;
                    prpAgent.B_column = item.B_column;
                    prpAgent.C_column = item.C_column;

                    prpAgent.IsActive = item.IsActive;
                    prpAgent.IsActiveProvider = item.IsActiveProvider;
                    prpAgent.IsDraft = item.IsDraft;
                    prpAgent.IsLock = item.IsLock;
                    prpAgent.IsPublicView = item.IsPublicView;
                    prpAgent.IsConditional = item.IsConditional;

                    prpAgent.CreatedBy = item.CreatedBy;
                    prpAgent.CreatedOn = item.CreatedOn;
                    prpAgent.ModifyBy = item.ModifyBy;
                    prpAgent.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
            }
            TempData["OnlinePayMessageShow"] = string.Empty;
            TempData["submitvalue"] = "Update"; TempData.Keep();

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("AgentRenewal_ApplicationPayment", prpAgent);
        }

        [HttpPost]
        public ActionResult AgentRenewal_EditApplicationPayment(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID, Clsprp_AgentRenewal_Payment smodel)
        {
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_AgentID = 0;
            Int32 User_TypeOfAgent = 0;
            Int64 User_RenewalAgentID = 0;
            Int32 User_RenewalSequenceID = 0;
            Int32 User_RenewalAgentYear = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                User_AgentID = KeyID;
                User_RenewalAgentID = RnKeyID;
                User_IndexID = IndexID;
                User_ExtractID = OtherID;

                UserID = User.Identity.GetUserId();
                UserName = User.Identity.Name;
                smodel.Related_Agent_Type = User_TypeOfAgent;

                ClsMethod_AgentRenewal_FeePayments sdb = new ClsMethod_AgentRenewal_FeePayments();                
                if (sdb.Update_AgentRenewal_FeePaymentDetail(smodel, User_AgentID, User_RenewalAgentID, User_RenewalSequenceID, User_RenewalAgentYear, FileName, FilePath, UserID, UserName))
                {
                    TempData["message"] = "Details updated Successfully";
                }
                ModelState.Clear();

                #region Check Isdraft value From Diary-Table
                RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
                #endregion
                return RedirectToAction("AgentRenewal_ApplicationPayment");
            }

            catch (Exception ex)
            {
                String e = ex.Message;
                return View();
            }
        }

        public ActionResult AgentRenewal_DeleteApplicationPayment(Int64 IndexID, Int64 OtherID, Int64 KeyID, Int64 RnKeyID)
        {
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_RenewalAgentID = 0;
            Int64 User_AgentID = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            string User_Error = string.Empty;

            try
            {
                User_IndexID = IndexID;
                User_ExtractID = OtherID;
                User_RenewalAgentID = RnKeyID;
                User_AgentID = KeyID;
                UserID = User.Identity.GetUserId();
                UserName = User.Identity.Name;

                ClsMethod_AgentRenewal_FeePayments sdb = new ClsMethod_AgentRenewal_FeePayments();
                if (sdb.Delete_AgentRenewal_FeePaymentByID(User_IndexID, User_ExtractID, User_RenewalAgentID, User_AgentID, UserID))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("AgentRenewal_ApplicationPayment");
            }
            catch (Exception ex)
            {
                string exvariable = ex.ToString();
                return RedirectToAction("AgentRenewal_ApplicationPayment");
            }
        }
        #endregion

        #region State_District
        public JsonResult GetState()
        {
            UserDetails aa = new UserDetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            return Json(aa, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrictByStateId(string stateid)
        {
            int Id = 0;
            if (stateid != "")
                Id = Convert.ToInt32(stateid);

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            var states = objdis.dropdownlist_display1(Id);
            return Json(states);
        }

        public JsonResult GetAgentSubdivisionByDistId(string Distid)
        {
            int Id = 0;
            if (Distid != "")
                Id = Convert.ToInt32(Distid);

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            var Subdiv = objdis.dropdownlist_diplaySubdivForAgent(Id);
            return Json(Subdiv);
        }
        #endregion State_District

        public void RenewalAgent_GetIsdraftvalue_FromDiaryNumber()
        {
            string dn_UserNam = User.Identity.Name;
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
            Int32 IsdraftValue = modelextract.Extract_AgentRenewal_Isdraftvalue_FromDiaryNumber(dn_AgentID, dn_TypeOfAgent, dn_RenewalAgentID, dn_RenewalSequenceID, dn_RenewalAgentYear, extractFlag, dn_UserNam);
            TempData["RnAgent_IsdraftValue"] = IsdraftValue;
        }

        public JsonResult GetReraExistingNumber(string RERA_RegNumber)
        {
            ClsMethodAgent_ExisitingRera objdis = new ClsMethodAgent_ExisitingRera();
            var states = objdis.Fill_Existing_detail(RERA_RegNumber);

            return Json(states);
        }

        private string SaveFileDatePrefix()
        {
            string varSetDate = string.Empty;
            var fileyear = DateTime.Now.Year;
            var filemonth = string.Empty;
            var fileday = string.Empty;
            if (DateTime.Now.Month < 10)
                filemonth = "0" + Convert.ToString(DateTime.Now.Month);
            else
                filemonth = Convert.ToString(DateTime.Now.Month);
            if (DateTime.Now.Day < 10)
                fileday = "0" + Convert.ToString(DateTime.Now.Day);
            else
                fileday = Convert.ToString(DateTime.Now.Day);
            varSetDate = fileyear.ToString() + filemonth + fileday;
            return varSetDate;
        }

        //start EXTRA
        #region Agent Dashboard Details
        [HttpGet]
        public JsonResult GetChecklistNotAcceptedByAgentId(Int64? AgentId)
        {
            string varStrRet = string.Empty;
            if (AgentId != 0)
            {
                int Id = 0;
                Id = Convert.ToInt32(AgentId);

                string pUserRole = string.Empty;
                pUserRole = getUserRole();

                Models.HelpDeskAgent.ClsMethod_Agent_Helpdesk objCode = new Models.HelpDeskAgent.ClsMethod_Agent_Helpdesk();
                Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog();
                //var Subdiv =
                aa.prpongoing = objCode.Display_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode(Id, pUserRole);

                Int32 vlenStart = 0;
                Int32 vlen = aa.prpongoing.Count();
                Int32 snoCnt = 0;
                foreach (var item in aa.prpongoing)
                {
                    snoCnt = snoCnt + 1;
                    if (vlenStart == vlen - 1)
                    {
                        // last
                        varStrRet += "(" + snoCnt + ".) " + item.CriteriaSubCode + " (" + item.Remarks_IfAny + ") </br>";
                    }
                    else
                    {
                        varStrRet += "(" + snoCnt + ".) " + item.CriteriaSubCode + " (" + item.Remarks_IfAny + "), </br>";
                    }
                    vlenStart++;
                    //aa.CriteriaSubCode = item.CriteriaSubCode;
                    //aa.Remarks_IfAny = item.Remarks_IfAny;
                    //aa.IsChecklistValueOk = item.IsChecklistValueOk;               
                }
            }
            return Json(varStrRet, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetRenewalAgentChecklistNotAcceptedByAgentId(Int64? AgentId, Int64? RenewalAgentId)
        {
            string varStrRet = string.Empty;
            if (AgentId != 0)
            {
                int Id = 0;
                long RenewalId = 0;
                Id = Convert.ToInt32(AgentId);
                RenewalId = Convert.ToInt64(RenewalAgentId);

                string pUserRole = string.Empty;
                pUserRole = getUserRole();

                Models.HelpDeskAgent.ClsMethod_Agent_Helpdesk objCode = new Models.HelpDeskAgent.ClsMethod_Agent_Helpdesk();
                Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog();
                aa.prpongoing = objCode.Display_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode(Id, pUserRole);

                Int32 vlenStart = 0;
                Int32 vlen = aa.prpongoing.Count();
                Int32 snoCnt = 0;
                foreach (var item in aa.prpongoing)
                {
                    snoCnt = snoCnt + 1;
                    if (vlenStart == vlen - 1)
                    {
                        // last
                        varStrRet += "(" + snoCnt + ".) " + item.CriteriaSubCode + " (" + item.Remarks_IfAny + ") </br>";
                    }
                    else
                    {
                        varStrRet += "(" + snoCnt + ".) " + item.CriteriaSubCode + " (" + item.Remarks_IfAny + "), </br>";
                    }
                    vlenStart++;              
                }
            }
            return Json(varStrRet, JsonRequestBehavior.AllowGet);
        }

        private string getUserRole()
        {
            string varRet = string.Empty;
            if (User.IsInRole("Promoter"))
                varRet = "19845cf7-c32d-4d4d-8f71-b19078b5bf6c";
            if (User.IsInRole("RealEstateAgent"))
                varRet = "5cab7404-0136-4e22-87ef-9cdaca6016e5";
            if (User.IsInRole("Complainant"))
                varRet = "53c2bc00-c000-4666-a30d-61b4151b5133";
            if (User.IsInRole("HelpDesk"))
                varRet = "7b9d725a-b33c-4aba-934a-bee1ec13f684";
            if (User.IsInRole("SecretaryRERA"))
                varRet = "15ac7786-a35e-46a3-ae19-8befd003dcfd";
            if (User.IsInRole("ManagerDesk"))
                varRet = "e583ee7f-aaa3-49bd-afc8-79c877afe591";
            if (User.IsInRole("Administrator"))
                varRet = "66d13a1a-ef3a-4eb3-b88c-95b06f451c74";
            if (User.IsInRole("LegalAdvisorDesk"))
                varRet = "7330c9a0-4296-4ddf-a421-0d0c491adf2d";
            if (User.IsInRole("PStoMembers"))
                varRet = "97eba4f1-7be4-4ba2-848d-8ad65a317455";
            if (User.IsInRole("Programmer"))
                varRet = "319a2b07-788f-4f90-9cda-3bca6ed81d3c";
            if (User.IsInRole("Authority"))
                varRet = "21f8f78b-5d55-4138-a503-57fcace0800e";
            return varRet;
        }

        #endregion

        #region Agent_Print
        [HttpGet]
        public ActionResult PrintView()
        {
            //if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        if (Session["User_Type"].ToString() != "0")
            //        {
            //            string strRetvalue = string.Empty;
            //            if (Session["User_Type"].ToString() == "1")
            //            {
            //                //if Individual Case
            //                strRetvalue = "RegIndAgent";
            //            }
            //            else if (Session["User_Type"].ToString() == "2")
            //            {
            //                //if Other than Individual Case
            //                strRetvalue = "RegAgentOtherThanIndivual";
            //            }
            //            return RedirectToAction(strRetvalue);
            //        }
            //        else
            //        {
            //            return RedirectToAction("SessionExpire", "Account");
            //        }
            //    }
            //    else
            //    {
            //        return View();
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("SessionExpire", "Account");
            //}
            //return View();
            Session["User_Type"] = "1";
            string strRetvalue = string.Empty;
            if (Session["User_Type"].ToString() == "1")
            {
                //if Individual Case
                strRetvalue = "AgentIndPrintForm";
            }
            else if (Session["User_Type"].ToString() == "2")
            {
                //if Other than Individual Case
                strRetvalue = "AgentOthIndPrintForm";
            }
            return RedirectToAction(strRetvalue);



        }

        public ActionResult AgentIndPrintForm1()
        {
            Int64 Application_id = 5050;

            //Int64 AgentID = 0;
            //userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                Application_id = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            CLSAgent_Multiple_Model aa = new CLSAgent_Multiple_Model();

            CLSAgent_Multiple_Model sdb = new CLSAgent_Multiple_Model();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            //aa.stateMaster = objdis.State_list();
            //aa.districtMaster = objdis.dropdownlist_display1();

            Clsprp_Agent clspro = new Clsprp_Agent();

            aa.Agent = sdb.DisplayAgentDetail(Application_id);

            foreach (var item in aa.Agent)
            {
                statecode = item.P_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

            }

            aa.Agent_OtherStateUTMember = sdb.DisplayOtherStateUTAgentDetail(Application_id);



            //  return new RazorPDF.PdfActionResult(View("AgentIndPrintForm", aa));
            //      return new RazorPDF.PdfActionResult(aa,"AgentIndPrintForm");
            //   return View("AgentIndPrintForm1", aa);
            // return new RazorPDF.PdfActionResult(View("AgentIndPrintForm1", aa));
            //var report = new ViewAsPdf(aa);
            //return report;
            return View("AgentIndPrintForm", aa);
        }





        public ActionResult AgentIndPrintForm()
        {
            Int64 Application_id = 5050;
            //Int64 AgentID = 0;
            //userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                Application_id = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            CLSAgent_Multiple_Model aa = new CLSAgent_Multiple_Model();

            CLSAgent_Multiple_Model sdb = new CLSAgent_Multiple_Model();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            //aa.stateMaster = objdis.State_list();
            //aa.districtMaster = objdis.dropdownlist_display1();

            Clsprp_Agent clspro = new Clsprp_Agent();

            aa.Agent = sdb.DisplayAgentDetail(Application_id);

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            foreach (var item in aa.Agent)
            {
                statecode = item.P_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                //aa.Agent_ID = item.Agent_ID;
                //aa.Agent_Type = item.Agent_Type;
                //aa.IsAlready_RERANumber = item.IsAlready_RERANumber;
                //aa.Existing_RERANumber = item.Existing_RERANumber;
                //aa.Agent_FirstName = item.Agent_FirstName;
                //aa.Agent_MiddleName = item.Agent_MiddleName;
                //aa.Agent_LastName = item.Agent_LastName;
                //aa.Father_FirstName = item.Father_FirstName;
                //aa.Father_MiddleName = item.Father_MiddleName;
                //aa.Father_LastName = item.Father_LastName;
                //aa.Occupation = item.Occupation;
                //aa.Image_FileName = item.Image_FileName;
                //aa.Image_FilePath = item.Image_FilePath;
                //aa.P_AddressLine1 = item.P_AddressLine1;
                //aa.P_AddressLine2 = item.P_AddressLine2;
                //aa.P_AddressStateCode = item.P_AddressStateCode;
                //aa.P_AddressDistrictCode = item.P_AddressDistrictCode;
                //aa.P_AddressPIN = item.P_AddressPIN;
                //aa.Organization_Name = item.Organization_Name;
                //aa.Organization_TypeCode = item.Organization_TypeCode;
                //aa.Organization_MainObjects = item.Organization_MainObjects;
                ////aa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                ////aa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                ////aa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                ////aa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                ////aa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                //aa.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                //aa.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                //aa.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                //aa.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                //aa.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                //aa.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                //aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                //aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                //aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                //aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                //aa.BComm_AddressPIN = item.BComm_AddressPIN;
                //aa.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                //aa.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                //aa.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                //aa.MobileNumber = item.MobileNumber;
                //aa.PhoneNumber_STD = item.PhoneNumber_STD;
                //aa.PhoneNumber_Number = item.PhoneNumber_Number;
                //aa.EmailAddress = item.EmailAddress;
                //aa.PAN_Number = item.PAN_Number;
                //aa.Aadhaar_Number = item.Aadhaar_Number;
                //aa.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                //aa.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                //aa.IsDraft = item.IsDraft;
                //aa.IsActive = item.IsActive;
                //aa.CreatedBy = item.CreatedBy;
                //aa.CreatedOn = item.CreatedOn;
                //aa.ModifyBy = item.ModifyBy;
                //aa.ModifyOn = item.ModifyOn;

            }

            aa.Agent_OtherStateUTMember = sdb.DisplayOtherStateUTAgentDetail(Application_id);

            int? StateCode;
            if (aa.Agent_OtherStateUTMember != null)
            {
                foreach (var item in aa.Agent_OtherStateUTMember)
                {
                    //aa.Agent_OtherStateUT_regRERA_ID = item.Agent_OtherStateUT_regRERA_ID;
                    //aa.Agent_ID = item.Agent_ID;
                    StateCode = item.StateCode;
                    aa.P_AddressState = objdis.State_Name(StateCode);
                    //aa.RERAregistration_Number = item.RERAregistration_Number;
                    //aa.RERAregistration_IssueDate = item.RERAregistration_IssueDate;
                    //aa.RERAregistration_ExpiryDate = item.RERAregistration_ExpiryDate;
                    //aa.ImageRERAcert_FileName = item.ImageRERAcert_FileName;
                    //aa.ImageRERAcert_FilePath = item.ImageRERAcert_FilePath;
                    //aa.Remarks_IfAny = item.Remarks_IfAny;
                    //aa.IsActive = item.IsActive;
                    //aa.IsDraft = item.IsDraft;

                    //Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                    //        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),


                }
            }
            aa.AgentPayment = sdb.DisplayAgentDetailPayment(Application_id);
            if (aa.AgentPayment != null)
            {
                foreach (var item in aa.AgentPayment)
                {

                    //aa.AgentPayment_IndexID = item.AgentPayment_IndexID;
                    //aa.AgentPayment_ID = item.AgentPayment_ID;
                    //aa.Agent_ID = item.Agent_ID;
                    //aa.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                    //aa.AgentPayment_TitleName = item.AgentPayment_TitleName;
                    //aa.Registration_Fee = item.Registration_Fee;
                    //aa.Other_Fee = item.Other_Fee;
                    //aa.Payment_Mode = item.Payment_Mode;
                    //aa.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    //aa.Bank_Charges = item.Bank_Charges;
                    //aa.Bank_Name = item.Bank_Name;
                    //aa.Branch_Name = item.Branch_Name;
                    //aa.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    //aa.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    //aa.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                    //aa.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;

                    //aa.IsActive = item.IsActive;
                    //aa.IsDraft = item.IsDraft;
                    //aa.CreatedBy = item.CreatedBy;
                    //aa.CreatedOn = item.CreatedOn;
                    //aa.ModifyBy = item.ModifyBy;
                    //aa.ModifyOn = item.ModifyOn;
                }
            }
             return View("AgentIndPrintForm", aa);


            //return new RazorPDF.PdfActionResult(View("AgentIndPrintForm", aa));

        }
        public ActionResult AgentOthIndPrintForm()
        {
            Int64 Application_id = 5048;

            //Int64 AgentID = 0;
            //userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                Application_id = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
            }

            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? RegOffice_AddressStateCode;
            int? RegOffice_AddressDistrictCode;
            //int? BComm_AddressStateCode;
            //int? BComm_AddressDistrictCode;
            CLSAgent_Multiple_Model aa = new CLSAgent_Multiple_Model();

            CLSAgent_Multiple_Model sdb = new CLSAgent_Multiple_Model();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();






            //aa.stateMaster = objdis.State_list();
            //aa.districtMaster = objdis.dropdownlist_display1();

            aa.AgentOtherThanInd = sdb.DisplayAgentOtherThanIndDetail(Application_id);
            aa.Agent_OtherMember = sdb.DisplayAgentOthermemberDetail(Application_id);

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            foreach (var item in aa.AgentOtherThanInd)
            {
                //statecode = item.P_AddressStateCode;
                //aa.P_AddressState = objdis.State_Name(statecode);
                //DistrictCode = item.P_AddressDistrictCode;
                RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                aa.RegOffice_AddressState = objdis.State_Name(RegOffice_AddressStateCode);

                RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                aa.RegOffice_AddressDistrict = objdis.State_Name(RegOffice_AddressStateCode);

                aa.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                //aa.Agent_ID = item.Agent_ID;
                //aa.Agent_Type = item.Agent_Type;
                //aa.IsAlready_RERANumber = item.IsAlready_RERANumber;
                //aa.Existing_RERANumber = item.Existing_RERANumber;
                //aa.Agent_FirstName = item.Agent_FirstName;
                //aa.Agent_MiddleName = item.Agent_MiddleName;
                //aa.Agent_LastName = item.Agent_LastName;
                //aa.Father_FirstName = item.Father_FirstName;
                //aa.Father_MiddleName = item.Father_MiddleName;
                //aa.Father_LastName = item.Father_LastName;
                //aa.Occupation = item.Occupation;
                //aa.Image_FileName = item.Image_FileName;
                //aa.Image_FilePath = item.Image_FilePath;
                //aa.P_AddressLine1 = item.P_AddressLine1;
                //aa.P_AddressLine2 = item.P_AddressLine2;
                //aa.P_AddressStateCode = item.P_AddressStateCode;
                //aa.P_AddressDistrictCode = item.P_AddressDistrictCode;
                //aa.P_AddressPIN = item.P_AddressPIN;
                //aa.Organization_Name = item.Organization_Name;
                //aa.Organization_TypeCode = item.Organization_TypeCode;
                //aa.Organization_MainObjects = item.Organization_MainObjects;
                //aa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                //aa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                //aa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                //aa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                //aa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                //aa.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                //aa.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                //aa.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                //aa.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                //aa.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                //aa.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                //aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                //aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                //aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                //aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                //aa.BComm_AddressPIN = item.BComm_AddressPIN;
                //aa.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                //aa.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                //aa.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                //aa.MobileNumber = item.MobileNumber;
                //aa.PhoneNumber_STD = item.PhoneNumber_STD;
                //aa.PhoneNumber_Number = item.PhoneNumber_Number;
                //aa.EmailAddress = item.EmailAddress;
                //aa.PAN_Number = item.PAN_Number;
                //aa.Aadhaar_Number = item.Aadhaar_Number;
                //aa.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                //aa.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                //aa.IsDraft = item.IsDraft;
                //aa.IsActive = item.IsActive;
                //aa.CreatedBy = item.CreatedBy;
                //aa.CreatedOn = item.CreatedOn;
                //aa.ModifyBy = item.ModifyBy;
                //aa.ModifyOn = item.ModifyOn;

            }
            foreach (var item in aa.Agent_OtherMember)
            {
                BusinessPlace_AddressStateCode = item.OfficeComm_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.OfficeComm_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);



                //aa.Designation = item.Designation;
                //aa.OtherMember_Name = item.OtherMember_Name;
                //aa.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                //aa.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                //aa.OtherMember_Aadhaar_Number = item.OtherMember_Aadhaar_Number;
                //aa.OfficeComm_AddressLine1 = item.OfficeComm_AddressLine1;
                //aa.OfficeComm_AddressLine2 = item.OfficeComm_AddressLine2;
                //aa.OfficeComm_AddressStateCode = item.OfficeComm_AddressStateCode;
                //aa.OfficeComm_AddressDistrictCode = item.OfficeComm_AddressDistrictCode;
                //aa.OfficeComm_AddressPIN = item.OfficeComm_AddressPIN;
                //aa.MobileNumber = item.MobileNumber;
                //aa.PhoneNumber_STD = item.PhoneNumber_STD;
                //aa.PhoneNumber_Number = item.PhoneNumber_Number;
                //aa.EmailAddress = item.EmailAddress;
                //aa.Image_FileName = item.Image_FileName;
                //aa.Image_FilePath = item.Image_FilePath;




            }

            aa.Agent_OtherStateUTMember = sdb.DisplayOtherStateUTAgentDetail(Application_id);

            int? StateCode;
            if (aa.Agent_OtherStateUTMember != null)
            {
                foreach (var item in aa.Agent_OtherStateUTMember)
                {
                    //aa.Agent_OtherStateUT_regRERA_ID = item.Agent_OtherStateUT_regRERA_ID;
                    //aa.Agent_ID = item.Agent_ID;
                    StateCode = item.StateCode;
                    aa.P_AddressState = objdis.State_Name(StateCode);
                    //aa.RERAregistration_Number = item.RERAregistration_Number;
                    //aa.RERAregistration_IssueDate = item.RERAregistration_IssueDate;
                    //aa.RERAregistration_ExpiryDate = item.RERAregistration_ExpiryDate;
                    //aa.ImageRERAcert_FileName = item.ImageRERAcert_FileName;
                    //aa.ImageRERAcert_FilePath = item.ImageRERAcert_FilePath;
                    //aa.Remarks_IfAny = item.Remarks_IfAny;
                    //aa.IsActive = item.IsActive;
                    //aa.IsDraft = item.IsDraft;

                    //Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                    //        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),


                }
            }
            aa.AgentPayment = sdb.DisplayAgentDetailPayment(Application_id);
            if (aa.AgentPayment != null)
            {
                foreach (var item in aa.AgentPayment)
                {

                    //aa.AgentPayment_IndexID = item.AgentPayment_IndexID;
                    //aa.AgentPayment_ID = item.AgentPayment_ID;
                    //aa.Agent_ID = item.Agent_ID;
                    //aa.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                    //aa.AgentPayment_TitleName = item.AgentPayment_TitleName;
                    //aa.Registration_Fee = item.Registration_Fee;
                    //aa.Other_Fee = item.Other_Fee;
                    //aa.Payment_Mode = item.Payment_Mode;
                    //aa.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    //aa.Bank_Charges = item.Bank_Charges;
                    //aa.Bank_Name = item.Bank_Name;
                    //aa.Branch_Name = item.Branch_Name;
                    //aa.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    //aa.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    //aa.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                    //aa.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;

                    //aa.IsActive = item.IsActive;
                    //aa.IsDraft = item.IsDraft;
                    //aa.CreatedBy = item.CreatedBy;
                    //aa.CreatedOn = item.CreatedOn;
                    //aa.ModifyBy = item.ModifyBy;
                    //aa.ModifyOn = item.ModifyOn;
                }
            }
            return View("AgentOthIndPrintForm", aa);


        }




        #endregion

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
           
            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Application_ID);
            TempData["AgentIsdraftValue"] = IsdraftValue;
 

        }
        //end EXTRA
    }
}
