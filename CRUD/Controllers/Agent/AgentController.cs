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
using System.Configuration;

namespace CRUD.Controllers.Agent
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentController : Controller
    {
        string Image_FileName = string.Empty;
        string PAN_Doc_Address = string.Empty;
        string FileName = string.Empty;
        string FilePath = string.Empty;
        
        #region Option Selection
        [HttpGet]
        public ActionResult OptionViewAgent()
        {
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    if (Session["User_Type"].ToString() != "0")
                    {
                        string strRetvalue = string.Empty;
                        if (Session["User_Type"].ToString() == "1")
                        {
                            //if Individual Case
                            strRetvalue = "RegIndAgent";
                        }
                        else if (Session["User_Type"].ToString() == "2")
                        {
                            //if Other than Individual Case
                            strRetvalue = "RegAgentOtherThanIndivual";
                        }
                        return RedirectToAction(strRetvalue);
                    }
                    else
                    {
                        return RedirectToAction("SessionExpire", "Account");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            //return View();
        }

        [HttpPost]
        public ActionResult OptionViewAgent(FormCollection frm)
        {
            string abc = string.Empty;
            abc = frm["rdbAgent"];
            if (abc == "1")
                return RedirectToAction("RegIndAgent");

            else
                return RedirectToAction("RegAgentOtherThanIndivual");

            //return View();
        }
        #endregion Option Selection

        #region Agent Profile
        [HttpGet]
        public ActionResult Detail()
        {
           // Int64 Agent_ID=0;
            Clsprp_Agent clspro = new Clsprp_Agent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            CLSMethod_Agent sdb = new CLSMethod_Agent();


            clspro.districtMaster = objdis.dropdownlist_display1();
           

                return View(clspro);
            //}
            //return View();
        }
       
        [HttpPost]
        public ActionResult Detail(Int64 Agent_ID)
        {
            Agent_ID = 0;
            Clsprp_Agent aa = new Clsprp_Agent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            CLSMethod_Agent sdb = new CLSMethod_Agent();
            aa.Agent = sdb.DisplayAgentDetail(Agent_ID);


            foreach (var item in aa.Agent)
            {
                aa.Agent_Type = item.Agent_Type;
                aa.IsAlready_RERANumber = item.IsAlready_RERANumber;
                aa.Existing_RERANumber = item.Existing_RERANumber;
                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_MiddleName = item.Agent_MiddleName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Father_FirstName = item.Father_FirstName;
                aa.Father_MiddleName = item.Father_MiddleName;
                aa.Father_LastName = item.Father_LastName;
                aa.Occupation = item.Occupation;
                aa.Image_FileName = item.Image_FileName;
                aa.Image_FilePath = item.Image_FilePath;
                aa.P_AddressLine1 = item.P_AddressLine1;
                aa.P_AddressLine2 = item.P_AddressLine2;
                aa.P_AddressStateCode = item.P_AddressStateCode;
                aa.P_AddressDistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressPIN = item.P_AddressPIN;
                aa.Organization_Name = item.Organization_Name;
                aa.Organization_TypeCode = item.Organization_TypeCode;
                aa.Organization_MainObjects = item.Organization_MainObjects;
                //aa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                //aa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                //aa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                //aa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                //aa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                aa.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aa.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aa.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                aa.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressPIN = item.BComm_AddressPIN;
                aa.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                aa.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                aa.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                aa.MobileNumber = item.MobileNumber;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.PhoneNumber_Number = item.PhoneNumber_Number;
                aa.EmailAddress = item.EmailAddress;
                aa.PAN_Number = item.PAN_Number;
                aa.Aadhaar_Number = item.Aadhaar_Number;
                aa.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                aa.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;



            }


            ViewBag.submitvalue = "Cancel";



            return View("RegIndAgent", aa);
        }
        
        //----------
        [HttpGet]
        public ActionResult RegIndAgent()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
                //else
                //{
                  //  return RedirectToAction("OptionViewAgent", "Agent");
                //}
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            Clsprp_Agent aa = new Clsprp_Agent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            CLSMethod_Agent sdb = new CLSMethod_Agent();

            aa.Agent = sdb.DisplayAgentDetail(Application_id);

            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();
            aa.SubdivMaster = objdis.dropdownlist_diplaySubdivForAgent();

            if (aa.Agent.Count >= 1)
            {
                TempData["submitvalue"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }

            aa.MobileNumber = Convert.ToInt64(Session["Mobile_Number"]);
            aa.EmailAddress = Session["Email_Address"].ToString();

            foreach (var item in aa.Agent)
            {
                aa.Agent_ID = item.Agent_ID;
                aa.Agent_Type = item.Agent_Type;
                aa.IsAlready_RERANumber = item.IsAlready_RERANumber;
                aa.Existing_RERANumber = item.Existing_RERANumber;
                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_MiddleName = item.Agent_MiddleName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Father_FirstName = item.Father_FirstName;
                aa.Father_MiddleName = item.Father_MiddleName;
                aa.Father_LastName = item.Father_LastName;
                aa.Occupation = item.Occupation;
                aa.Image_FileName = item.Image_FileName;
                aa.Image_FilePath = item.Image_FilePath;
                aa.P_AddressLine1 = item.P_AddressLine1;
                aa.P_AddressLine2 = item.P_AddressLine2;
                aa.P_AddressStateCode = item.P_AddressStateCode;
                aa.P_AddressDistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressPIN = item.P_AddressPIN;
                aa.Organization_Name = item.Organization_Name;
                aa.Organization_TypeCode = item.Organization_TypeCode;
                aa.Organization_MainObjects = item.Organization_MainObjects;
                //aa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                //aa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                //aa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                //aa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                //aa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                aa.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aa.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aa.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                aa.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressPIN = item.BComm_AddressPIN;
                aa.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                aa.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                aa.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                aa.MobileNumber = item.MobileNumber;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.PhoneNumber_Number = item.PhoneNumber_Number;
                aa.EmailAddress = item.EmailAddress;
                aa.PAN_Number = item.PAN_Number;
                aa.Aadhaar_Number = item.Aadhaar_Number;
                aa.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                aa.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                aa.B_Column = item.B_Column;
                aa.C_Column = item.C_Column;

                aa.IsDraft = item.IsDraft;
                aa.IsActive = item.IsActive;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion

            return View("RegIndAgent", aa);            
        }

        // POST: Save Agent Profile
        [HttpPost]
        public ActionResult RegIndAgent(Clsprp_Agent smodel)
        {
            //Int64 Application_id = 0;
            //if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        Application_id = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //    else
            //    {
            //        return RedirectToAction("OptionViewAgent", "Agent");
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("SessionExpire", "Account");
            //}

            CLSMethod_Agent sdb = new CLSMethod_Agent();
            Clsprp_Agent clspro = new Clsprp_Agent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
           
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
                            string masterAgentDoc_SetFilePath = "readwritedataAgent";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.Image_FilePath))
                            {
                                pathindb = smodel.Image_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(UID) + "\\";
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
                                fileName = "AgentInd_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                            }
                            //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
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
                            // ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
                            sdb.UpdateAgentDetail(smodel, FileName, FilePath, UID, UserNam);
                            TempData["message"] = "Agent Details updated Successfully";

                            Session["ApplicationId"] = smodel.Agent_ID;
                            Session["User_Type"] = 1;
                            Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0);

                            ModelState.Clear();
                        }

                        return RedirectToAction("RegIndAgent");
                    }
                    else
                    {

                        return RedirectToAction("RegIndAgent");
                    }
                }
                catch (Exception ex)
                {
                    return View("RegIndAgent");
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
                            string masterAgentDoc_SetFilePath = "readwritedataAgent";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(UID) + "\\";
                            pathAgentdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathAgentdata))
                            {
                                Directory.CreateDirectory(pathAgentdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "AgentInd_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
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
                //}
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

                            Int64 Appid = sdb.AddAgentDetail(smodel, FileName, FilePath, UID, UserNam);
                            if (Appid > 0)
                            {
                                ViewBag.ApplicationId = Appid;
                                ViewBag.Message = "Your Data is Successfully Submitted";

                                Session["ApplicationId"] = Appid;
                                Session["User_Type"] = 1;
                                Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0);


                                smodel.Agent_ID = Convert.ToInt64(Session["ApplicationId"]);

                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("RegIndAgent");
                    }
                    else
                    {
                        //return View("Create_ParentEntity",);
                        return RedirectToAction("RegIndAgent");
                    }
                }
                catch (Exception ex)
                {
                    return View("RegIndAgent");
                }
            }            
        }
        #endregion Agent Profile

        #region Agent_OtherThan_Profile
        [HttpGet]
        public ActionResult RegAgentOtherThanIndivual()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
                //else
                //{
                  //  return RedirectToAction("OptionViewAgent", "Agent");
                //}
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            CLsprpOtherThanIndivualAgent aa = new CLsprpOtherThanIndivualAgent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            CLsMethodOtherThanIndivualAgent sdb = new CLsMethodOtherThanIndivualAgent();

            CLsMethodOtherThanIndivualAgent aaa = new CLsMethodOtherThanIndivualAgent();
            aa.AgentOtherThanInd = sdb.DisplayAgentOtherThanIndDetail(Application_id);

            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.SubdivMaster = objdis.dropdownlist_diplaySubdivForAgent();

            if (aa.AgentOtherThanInd.Count >= 1)
            {
                TempData["submitvalue"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }

            aa.MobileNumber = Convert.ToInt64(Session["Mobile_Number"]);
            aa.EmailAddress = Session["Email_Address"].ToString();

            foreach (var item in aa.AgentOtherThanInd)
            {
                aa.Agent_ID = item.Agent_ID;
                aa.Agent_Type = item.Agent_Type;
                aa.IsAlready_RERANumber = item.IsAlready_RERANumber;
                aa.Existing_RERANumber = item.Existing_RERANumber;
                //aa.Agent_FirstName = item.Agent_FirstName;
                //aa.Agent_MiddleName = item.Agent_MiddleName;
                //aa.Agent_LastName = item.Agent_LastName;
                //aa.Father_FirstName = item.Father_FirstName;
                //aa.Father_MiddleName = item.Father_MiddleName;
                //aa.Father_LastName = item.Father_LastName;
                aa.Occupation = item.Occupation;
                //aa.Image_FileName = item.Image_FileName;
                //aa.Image_FilePath = item.Image_FilePath;
                //aa.P_AddressLine1 = item.P_AddressLine1;
                //aa.P_AddressLine2 = item.P_AddressLine2;
                //aa.P_AddressStateCode = item.P_AddressStateCode;
                //aa.P_AddressDistrictCode = item.P_AddressDistrictCode;
                //aa.P_AddressPIN = item.P_AddressPIN;
                aa.Organization_Name = item.Organization_Name;
                aa.Organization_TypeCode = item.Organization_TypeCode;
                aa.Organization_MainObjects = item.Organization_MainObjects;
                aa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                aa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                aa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                aa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                aa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                aa.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aa.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aa.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                aa.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressPIN = item.BComm_AddressPIN;
                aa.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                aa.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                aa.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                aa.MobileNumber = item.MobileNumber;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.PhoneNumber_Number = item.PhoneNumber_Number;
                aa.EmailAddress = item.EmailAddress;
                aa.PAN_Number = item.PAN_Number;
                aa.Aadhaar_Number = item.Aadhaar_Number;
                aa.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                aa.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;

                aa.B_Column = item.B_Column;
                aa.C_Column = item.C_Column;

                aa.IsDraft = item.IsDraft;
                aa.IsActive = item.IsActive;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion

            return View("RegAgentOtherThanIndivual", aa);
        }

        // POST: Save Agent Profile
        [HttpPost]
        public ActionResult RegAgentOtherThanIndivual(CLsprpOtherThanIndivualAgent smodel)
        {
           // Int64 Application_id = 0; //agent id
            ////Int64 Application_id = 110028;
            ////if (Session["ApplicationId"] != null)
            ////{
            ////    Application_id = Convert.ToInt64(Session["ApplicationId"].ToString());
            ////}
            ////else
            ////{
            ////    RedirectToAction("Home", "About");
            ////}


            CLsMethodOtherThanIndivualAgent sdb = new CLsMethodOtherThanIndivualAgent();
            CLsprpOtherThanIndivualAgent clspro = new CLsprpOtherThanIndivualAgent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            string error = string.Empty;
            //int errorstate = 0;
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
                        //CLSMethodRERA_Agent_Payment sdbupdate = new CLSMethodRERA_Agent_Payment();
                        sdb.UpdateAgenOtherThanIndtDetail(smodel, FileName, FilePath, UID, UserNam);
                        ViewBag.Message = "Agent  Details updated Successfully";

                        Session["ApplicationId"] = smodel.Agent_ID;
                        Session["User_Type"] = 2;
                        Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0); 

                        return View("RegAgentOtherThanIndivual", clspro);
                        // return RedirectToAction("RegAgentOtherThanIndivual");
                    }
                    else
                    {
                        #region SAVE code                      
                        
                        Int64 Appid = sdb.AddAgentOtherThanIndDetail(smodel, FileName, FilePath, UID, UserNam);
                        if (Appid > 0)
                        {
                            ViewBag.ApplicationId = Appid;
                            ViewBag.Message = "Your Data is Successfully Submitted";

                            Session["ApplicationId"] = Appid;                            
                            Session["User_Type"] = 2;
                            Session["User_ParentEntityFlag"] = ((smodel.IsOtherStateUT_RERAregistration.ToString()) != "N" ? 1 : 0); //smodel.IsOtherStateUT_RERAregistration;

                            smodel.Agent_ID = Convert.ToInt64(Session["ApplicationId"]);

                            ModelState.Clear();
                        }
                        
                        // return View(clspro);
                        return View("RegAgentOtherThanIndivual", clspro);
                        //return RedirectToAction("RegAgentOtherThanIndivual");
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                String e = ex.Message;
            }
            return View();

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        clspro.districtMaster = objdis.dropdownlist_display1();
            //        if (errorstate == 0)
            //        {
            //            if (ModelState.IsValid)
            //            {

            //                if (sdb.AddAgentOtherThanIndDetail(smodel, FileName, FilePath))
            //                {
            //                    ViewBag.Message = "Agent Details Added Successfully";
            //                    ModelState.Clear();
            //                }
            //            }
            //        }
            //        return View(clspro);
            //    }
            //    catch (Exception ex)
            //    {
            //        String e = ex.Message;
            //        return View();
            //    }

        }
        #endregion Agent_OtherThan_Profile

        #region Existing Agent
        // GET:Existing Agent
        public ActionResult RegExistingAgent()
        {
            ClsprpAgent_ExisitingRera clspro = new ClsprpAgent_ExisitingRera();
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            //clspro.districtMaster= objdis.dropdownlist_display1();
            return View(clspro);
        }
        // POST: Save Existing Agent
        [HttpPost]
        public ActionResult RegExistingAgent(ClsprpAgent_ExisitingRera smodel)
        {
            ClsMethodAgent_ExisitingRera sdb = new ClsMethodAgent_ExisitingRera();
            ClsprpAgent_ExisitingRera clspro = new ClsprpAgent_ExisitingRera();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            string error = string.Empty;
            int errorstate = 0;
            try
            {
               // clspro.districtMaster = objdis.dropdownlist_display1();
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {

                        if (sdb.AddReraAgentExisiting(smodel))
                        {
                            ViewBag.Message = "Agent Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                }
                return View(clspro);
            }
            catch (Exception ex)
            {
                String e = ex.Message;
                return View();
            }
        }
        #endregion Existing Agent

        #region Agent_OtherMemberDetail
        [HttpPost]
        public ActionResult Details_Agent_mem()
        {
            return RedirectToAction("Create_Agent_mem");

        }       
        //GET: Details
        public ActionResult Details_Agent_mem(Int64 Application_id, Int64 Agent_OtherMemberDetails_ID)
        {            
            ClsMethodRera_Agent_OtherMemberDetail sdb = new ClsMethodRera_Agent_OtherMemberDetail();
            ClsprpRera_Agent_OtherMemberDetail aa = new ClsprpRera_Agent_OtherMemberDetail();
            aa.Agent_OtherMember = sdb.DisplayAgentOthermemberDetailByMemberID(Application_id, Agent_OtherMemberDetails_ID);
            foreach (var item in aa.Agent_OtherMember)
            {
                aa.Designation = item.Designation;
                aa.OtherMember_Name = item.OtherMember_Name;
                aa.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                aa.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                aa.OtherMember_Aadhaar_Number = item.OtherMember_Aadhaar_Number;
                aa.OfficeComm_AddressLine1 = item.OfficeComm_AddressLine1;
                aa.OfficeComm_AddressLine2 = item.OfficeComm_AddressLine2;
                aa.OfficeComm_AddressStateCode = item.OfficeComm_AddressStateCode;
                aa.OfficeComm_AddressDistrictCode = item.OfficeComm_AddressDistrictCode;
                aa.OfficeComm_AddressPIN = item.OfficeComm_AddressPIN;
                aa.MobileNumber = item.MobileNumber;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.PhoneNumber_Number = item.PhoneNumber_Number;
                aa.EmailAddress = item.EmailAddress;
                aa.Image_FileName = item.Image_FileName;
                aa.Image_FilePath = item.Image_FilePath;
            }
            ViewBag.submitvalue = "Cancel";
            return View("Create_Agent_mem", aa);
        }


        // GET: Create
        public ActionResult Create_Agent_mem()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    if (Session["User_Type"].ToString() != "2")
                    {
                        //In when Other than Individual - Organization Member NIL
                        return RedirectToAction("Create_Agent_memNA", "Agent");
                    }
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
            ClsMethodRera_Agent_OtherMemberDetail sdb = new ClsMethodRera_Agent_OtherMemberDetail();
            ClsprpRera_Agent_OtherMemberDetail aa = new ClsprpRera_Agent_OtherMemberDetail();

            aa.Agent_OtherMember = sdb.DisplayAgentOthermemberDetail(Application_id);

            TempData["submitvalue"] = "Save";
            TempData.Keep();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster= objdis.State_list();

            foreach (var item in aa.Agent_OtherMember)
            {
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
            }
            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion
            return View("Create_Agent_mem", aa);
        }
        // POST: Create
        [HttpPost]
        public ActionResult Create_Agent_mem(ClsprpRera_Agent_OtherMemberDetail smodel)
        {
            Int64 Application_id = 0;            
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
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

            ClsMethodRera_Agent_OtherMemberDetail sdb = new ClsMethodRera_Agent_OtherMemberDetail();
            ClsprpRera_Agent_OtherMemberDetail aa = new ClsprpRera_Agent_OtherMemberDetail();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            // aa.districtMaster = objdis.dropdownlist_display1();

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
                            string masterAgentDoc_SetFilePath = "readwritedataAgent";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.Image_FilePath))
                            {
                                pathindb = smodel.Image_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
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
                                fileName = "AgentMem_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                            }
                            //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
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
                            aa.districtMaster = objdis.dropdownlist_display1();
                            aa.stateMaster = objdis.State_list();

                            sdb.UpdateReraOtherMember(smodel, Application_id, FileName, FilePath);
                            TempData["Message"] = "Your Data is Successfully updated";
                            //@ViewData["result"]= "Details updated Successfully";
                            ModelState.Clear();                            
                        }
                        return RedirectToAction("Create_Agent_mem");
                    }
                    else
                    {
                        return RedirectToAction("Create_Agent_mem");
                    }
                }
                catch (Exception ex)
                {
                    string strrtn = ex.ToString();
                    return View("Create_Agent_mem");
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
                            string masterAgentDoc_SetFilePath = "readwritedataAgent";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
                            pathAgentdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathAgentdata))
                            {
                                Directory.CreateDirectory(pathAgentdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "AgentMem_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
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
                //}
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
                            aa.districtMaster = objdis.dropdownlist_display1();
                            aa.stateMaster = objdis.State_list();
                            if (sdb.AddReraOtherMember(smodel, Application_id, FileName, FilePath))
                            {
                                TempData["Message"] = "Your Data is Successfully Submitted";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("Create_Agent_mem");
                    }
                    else
                    {
                        return RedirectToAction("Create_Agent_mem");
                    }
                }
                catch (Exception ex)
                {
                    string strrtn = ex.ToString();
                    return View("Create_Agent_mem");
                }
            }
        }
        
        // GET: Edit
        public ActionResult Edit_Agent_mem(Int64 Application_id,   Int64 Agent_OtherMemberDetails_ID)
        {
            ClsMethodRera_Agent_OtherMemberDetail sdb = new ClsMethodRera_Agent_OtherMemberDetail();
            ClsprpRera_Agent_OtherMemberDetail aa = new ClsprpRera_Agent_OtherMemberDetail();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.Agent_OtherMember = sdb.DisplayAgentOthermemberDetailByMemberID(Application_id, Agent_OtherMemberDetails_ID);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            foreach (var item in aa.Agent_OtherMember)
            {
                aa.Designation = item.Designation;
                aa.OtherMember_Name = item.OtherMember_Name;
                aa.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                aa.OtherMember_PAN_Number = item.OtherMember_PAN_Number;
                aa.OtherMember_Aadhaar_Number = item.OtherMember_Aadhaar_Number;
                aa.OfficeComm_AddressLine1 = item.OfficeComm_AddressLine1;
                aa.OfficeComm_AddressLine2 = item.OfficeComm_AddressLine2;
                aa.OfficeComm_AddressStateCode = item.OfficeComm_AddressStateCode;
                aa.OfficeComm_AddressDistrictCode = item.OfficeComm_AddressDistrictCode;
                aa.OfficeComm_AddressPIN = item.OfficeComm_AddressPIN;
                aa.MobileNumber = item.MobileNumber;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.PhoneNumber_Number = item.PhoneNumber_Number;
                aa.EmailAddress = item.EmailAddress;
                aa.Image_FileName = item.Image_FileName;
                aa.Image_FilePath = item.Image_FilePath;
                aa.OfficeComm_AddressDistrictCode = item.OfficeComm_AddressDistrictCode;

                aa.IsDraft = item.IsDraft;
                aa.IsActive = item.IsActive;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                //Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                //Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
            }
            TempData["submitvalue"] = "Update";
            TempData.Keep();

            return View("Create_Agent_mem", aa);
        }
        // POST: Edit
        [HttpPost]
        public ActionResult Edit_Agent_mem(ClsprpRera_Agent_OtherMemberDetail smodel)
        {
            ClsMethodRera_Agent_OtherMemberDetail sdb = new ClsMethodRera_Agent_OtherMemberDetail();
            try
            {                
                return RedirectToAction("Create_Agent_mem");
            }
            catch (Exception ex)
            {
                string strrtn = ex.ToString();
                return View("Create_Agent_mem");
            }
        }
        
        // GET: Delete
        public ActionResult Delete_Agent_mem(Int64 Application_id, Int64 Agent_OtherMemberDetails_ID)
        {
            ClsMethodRera_Agent_OtherMemberDetail sdb = new ClsMethodRera_Agent_OtherMemberDetail();
            try
            {                
                if (sdb.Delete_AgentOthermemberDetail(Application_id, Agent_OtherMemberDetails_ID))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Create_Agent_mem");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Agent_OtherStateUT_regRERAdetails
        [HttpPost]
        public ActionResult Details_Agent_OtherStateUT()
        {
            return RedirectToAction("Create_Agent_OtherStateUT");
        }

        [HttpGet]
        public ActionResult Details_Agent_OtherStateUT(Int64 Application_id, Int64 Agent_OtherMemberDetails_ID)
        {
            // Application_id = 110027;
            ClsMethodAgentOtherStateUT sdb = new ClsMethodAgentOtherStateUT();
            ClsprpRERA_Agent_OtherStateUT_regRERAdetails aa = new ClsprpRERA_Agent_OtherStateUT_regRERAdetails();
            aa.Agent_OtherStateUTMember = sdb.DisplayAgentOtherStateUTDetailByOthermemberID(Application_id, Agent_OtherMemberDetails_ID);
            foreach (var item in aa.Agent_OtherStateUTMember)
            {
                aa.Agent_OtherStateUT_regRERA_ID = item.Agent_OtherStateUT_regRERA_ID;
                aa.Agent_ID = item.Agent_ID;
                aa.StateCode = item.StateCode;
                aa.RERAregistration_Number = item.RERAregistration_Number;
                aa.RERAregistration_IssueDate = item.RERAregistration_IssueDate;
                aa.RERAregistration_ExpiryDate = item.RERAregistration_ExpiryDate;
                aa.ImageRERAcert_FileName = item.ImageRERAcert_FileName;
                aa.ImageRERAcert_FilePath = item.ImageRERAcert_FilePath;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                //aa.IsActive = item.IsActive;
                //aa.IsDraft = item.IsDraft;

                //Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                //        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),


            }

            //ViewBag.submitvalue = "Cancel";
            TempData["submitvalue"] = "Cancel";
            TempData.Keep();


            return View("Create_Agent_OtherStateUT", aa);

        }


        [HttpGet]
        public ActionResult Create_Agent_OtherStateUT()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    if (Session["User_ParentEntityFlag"].ToString() != "1")
                    {
                        //In when Not Other State UT registrations
                        return RedirectToAction("Create_Agent_OtherStateUTNA", "Agent");
                    }
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
            ClsMethodAgentOtherStateUT sdb = new ClsMethodAgentOtherStateUT();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsprpRERA_Agent_OtherStateUT_regRERAdetails aa = new ClsprpRERA_Agent_OtherStateUT_regRERAdetails();

            aa.Agent_OtherStateUTMember = sdb.DisplayOtherStateUTAgentDetail(Application_id);

            aa.stateMaster = objdis.State_list();
            ViewBag.list1 = aa.stateMaster;

            foreach (var item in aa.Agent_OtherStateUTMember)
            {
                //    aa.Agent_OtherStateUT_regRERA_ID = item.Agent_OtherStateUT_regRERA_ID;
                //    aa.Agent_ID = item.Agent_ID;
                //    aa.StateCode = item.StateCode;
                //    aa.RERAregistration_Number = item.RERAregistration_Number;
                //    aa.RERAregistration_IssueDate = item.RERAregistration_IssueDate;
                //    aa.RERAregistration_ExpiryDate = item.RERAregistration_ExpiryDate;
                //    aa.ImageRERAcert_FileName = item.ImageRERAcert_FileName;
                //    aa.ImageRERAcert_FilePath = item.ImageRERAcert_FilePath;
                //    // aa.Remarks_IfAny = item.Remarks_IfAny;
                //    //aa.IsActive = item.IsActive;
                //aa.IsDraft = item.IsDraft;

                //    //Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                //    //        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),                

                var existingAgentOtherUT = aa.Agent_OtherStateUTMember.FirstOrDefault(asm => asm.StateCode == item.StateCode);
                if (existingAgentOtherUT != null)
                {
                    //update existing object with values
                    existingAgentOtherUT.StateName_OtherUT = objdis.State_Name(item.StateCode);
                }
            }
            TempData["submitvalue"] = "Save";
            TempData.Keep();

            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion
            return View("Create_Agent_OtherStateUT", aa);
        }
        [HttpPost]
        public ActionResult Create_Agent_OtherStateUT(ClsprpRERA_Agent_OtherStateUT_regRERAdetails smodel)
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
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

            ClsMethodAgentOtherStateUT sdb = new ClsMethodAgentOtherStateUT();
            ClsprpRERA_Agent_OtherStateUT_regRERAdetails aa = new ClsprpRERA_Agent_OtherStateUT_regRERAdetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            // aa.districtMaster = objdis.dropdownlist_display1();

            aa.stateMaster = objdis.State_list();

            String ext = String.Empty;
            string FilePathExt = string.Empty;
            string error = string.Empty;


            #region
            //////////////int errorstate = 0;
            //////////////if (TempData["submitvalue"].ToString() == "Update")
            //////////////{

            //////////////    #region PhotoCertificate Update with Path
            //////////////    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            //////////////    {
            //////////////        var files = Request.Files[0];
            //////////////        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            //////////////        ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            //////////////        if (allowedExtensions.Contains(ext)) //check what type of extension  
            //////////////        {
            //////////////            int size = files.ContentLength;
            //////////////            if (size <= 512000)
            //////////////            {

            //////////////                #region Declare Variables
            //////////////                var pathAgentdata = "";
            //////////////                var pathindb = "";
            //////////////                string masterAgentDoc_SetFilePath = "readwritedataAgent";
            //////////////                #endregion

            //////////////                #region UpdateFile Path Creation 
            //////////////                if (!String.IsNullOrEmpty(smodel.ImageRERAcert_FilePath))
            //////////////                {
            //////////////                    pathindb = smodel.ImageRERAcert_FilePath.ToString();
            //////////////                }
            //////////////                else
            //////////////                {
            //////////////                    pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
            //////////////                }
            //////////////                pathAgentdata = Server.MapPath("~/" + pathindb);

            //////////////                if (!Directory.Exists(pathAgentdata))
            //////////////                {
            //////////////                    Directory.CreateDirectory(pathAgentdata);
            //////////////                }
            //////////////                #endregion

            //////////////                var fileName = string.Empty;
            //////////////                if (!String.IsNullOrEmpty(smodel.ImageRERAcert_FileName))
            //////////////                {
            //////////////                    fileName = smodel.ImageRERAcert_FileName.ToString();
            //////////////                }
            //////////////                else
            //////////////                {
            //////////////                    fileName = "AOrera_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
            //////////////                }
            //////////////                //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
            //////////////                var path = Path.Combine(pathAgentdata, fileName);
            //////////////                files.SaveAs(path);
            //////////////                FileName = fileName;
            //////////////                FilePath = pathindb;

            //////////////            }
            //////////////            else
            //////////////            {
            //////////////                TempData["notice"] = "Photo Size Should be less than 512KB";
            //////////////                error = "Photo Size Should be less than 512KB";
            //////////////                errorstate = 1;
            //////////////            }
            //////////////        }
            //////////////        else
            //////////////        {
            //////////////            TempData["notice"] = "Photo format should be .jpg";
            //////////////            error = "Photo format should be .jpg";
            //////////////            errorstate = 1;
            //////////////        }
            //////////////    }
            //////////////    else
            //////////////    {
            //////////////        TempData["notice"] = "Kindly Upload Photograph";
            //////////////        error = "Kindly Upload Photograph";
            //////////////        errorstate = 1;

            //////////////        //update with same photograph
            //////////////        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
            //////////////        {
            //////////////            errorstate = 0;
            //////////////        }
            //////////////    }                
            //////////////    #endregion

            //////////////    try
            //////////////    {
            //////////////        if (errorstate == 0)
            //////////////        {
            //////////////            if (FileName == "")
            //////////////            {
            //////////////                FileName = smodel.ImageRERAcert_FileName;
            //////////////                ext = smodel.ImageRERAcert_FileName;
            //////////////                FilePath = smodel.ImageRERAcert_FilePath;
            //////////////            }

            //////////////            if (ModelState.IsValid)
            //////////////            {                            
            //////////////                // ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
            //////////////                sdb.UpdateOtherStateUTAgentDetail(smodel, Application_id, FileName, FilePath);
            //////////////                TempData["message"] = "Details updated Successfully";

            //////////////                ModelState.Clear();
            //////////////            }

            //////////////            return RedirectToAction("Create_Agent_OtherStateUT");
            //////////////        }
            //////////////        else
            //////////////        {

            //////////////            return RedirectToAction("Create_Agent_OtherStateUT");
            //////////////        }
            //////////////    }
            //////////////    catch (Exception ex)
            //////////////    {
            //////////////        return View("Create_Agent_OtherStateUT");
            //////////////    }
            //////////////}
            //////////////else
            //////////////{
            //////////////    #region PhotoCertificate Save with Path
            //////////////    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            //////////////    {
            //////////////        var files = Request.Files[0];
            //////////////        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            //////////////        ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            //////////////        if (allowedExtensions.Contains(ext)) //check what type of extension  
            //////////////        {
            //////////////            int size = files.ContentLength;
            //////////////            if (size <= 512000)
            //////////////            {

            //////////////                #region Declare Variables
            //////////////                var pathAgentdata = "";
            //////////////                var pathindb = "";
            //////////////                string masterAgentDoc_SetFilePath = "readwritedataAgent";
            //////////////                #endregion

            //////////////                #region SaveFile Path Creation
            //////////////                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
            //////////////                pathAgentdata = Server.MapPath("~/" + pathindb);

            //////////////                if (!Directory.Exists(pathAgentdata))
            //////////////                {
            //////////////                    Directory.CreateDirectory(pathAgentdata);
            //////////////                }
            //////////////                #endregion

            //////////////                var fileName = string.Empty;
            //////////////                fileName = "AOrera_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
            //////////////                var path = Path.Combine(pathAgentdata, fileName);
            //////////////                files.SaveAs(path);
            //////////////                FileName = fileName;
            //////////////                FilePath = pathindb;

            //////////////            }
            //////////////            else
            //////////////            {
            //////////////                TempData["notice"] = "Photo Size Should be less than 512KB";
            //////////////                error = "Photo Size Should be less than 512KB";
            //////////////                errorstate = 1;
            //////////////            }
            //////////////        }
            //////////////        else
            //////////////        {
            //////////////            TempData["notice"] = "Photo format should be .jpg";
            //////////////            error = "Photo format should be .jpg";
            //////////////            errorstate = 1;
            //////////////        }
            //////////////    }
            //////////////    else
            //////////////    {
            //////////////        TempData["notice"] = "Kindly Upload Photograph";
            //////////////        error = "Kindly Upload Photograph";
            //////////////        errorstate = 1;
            //////////////    }
            //////////////    //}
            //////////////    #endregion

            //////////////    try
            //////////////    {
            //////////////        if (errorstate == 0)
            //////////////        {
            //////////////            if (FileName == "")
            //////////////            {
            //////////////                FileName = smodel.ImageRERAcert_FileName;
            //////////////                ext = smodel.ImageRERAcert_FileName;
            //////////////                FilePath = smodel.ImageRERAcert_FilePath;
            //////////////            }

            //////////////            if (ModelState.IsValid)
            //////////////            {                            
            //////////////                if (sdb.AddOtherStateUTAgentDetail(smodel, Application_id, FileName, FilePath))
            //////////////                {
            //////////////                    // ViewBag.ApplicationId = Appid;
            //////////////                    ViewBag.Message = "Your Data is Successfully Submitted";
            //////////////                    ModelState.Clear();
            //////////////                }
            //////////////            }
            //////////////            return RedirectToAction("Create_Agent_OtherStateUT");
            //////////////        }
            //////////////        else
            //////////////        {
            //////////////            //return View("Create_ParentEntity",);
            //////////////            return RedirectToAction("Create_Agent_OtherStateUT");
            //////////////        }
            //////////////    }
            //////////////    catch (Exception ex)
            //////////////    {
            //////////////        return View("Create_Agent_OtherStateUT");
            //////////////    }                
            //////////////}
            #endregion


            try
            {
                if (ModelState.IsValid)
                {
                    if (sdb.AddOtherStateUTAgentDetail(smodel, Application_id, FileName, FilePath))
                    {
                        // ViewBag.ApplicationId = Appid;
                        ViewBag.Message = "Your Data is Successfully Submitted";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Create_Agent_OtherStateUT");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
                return View("Create_Agent_OtherStateUT");
            }
        }

        [HttpGet]
        public ActionResult Edit_Agent_OtherStateUT(Int64 Agent_OtherStateUT_regRERA_IndexID,Int64 Agent_ID)
        {
            ClsMethodAgentOtherStateUT sdb = new ClsMethodAgentOtherStateUT();
            ClsprpRERA_Agent_OtherStateUT_regRERAdetails aa = new ClsprpRERA_Agent_OtherStateUT_regRERAdetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.Agent_OtherStateUTMember = sdb.DisplayAgentOtherStateUTDetailByOthermemberID(Agent_OtherStateUT_regRERA_IndexID, Agent_ID);

            aa.stateMaster = objdis.State_list();
            ViewBag.list1 = aa.stateMaster;

            foreach (var item in aa.Agent_OtherStateUTMember)
            {
                aa.Agent_OtherStateUT_regRERA_ID = item.Agent_OtherStateUT_regRERA_ID;
                aa.Agent_ID = item.Agent_ID;
                aa.StateCode = item.StateCode;
                aa.RERAregistration_Number = item.RERAregistration_Number;
                aa.RERAregistration_IssueDate = item.RERAregistration_IssueDate;
                aa.RERAregistration_ExpiryDate = item.RERAregistration_ExpiryDate;
                aa.ImageRERAcert_FileName = item.ImageRERAcert_FileName;
                aa.ImageRERAcert_FilePath = item.ImageRERAcert_FilePath;
               // aa.Remarks_IfAny = item.Remarks_IfAny;
                //aa.IsActive = item.IsActive;

                aa.IsDraft = item.IsDraft;
                aa.IsActive = item.IsActive;                
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            
            return View("Create_Agent_OtherStateUT", aa);
        }        
        [HttpPost]
        public ActionResult Edit_Agent_OtherStateUT(ClsprpRERA_Agent_OtherStateUT_regRERAdetails smodel)
        {
            try
            {
                Int64 Application_id = 0;
                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    }                   
                }                

                if (ModelState.IsValid)
                {
                    ClsMethodAgentOtherStateUT sdb = new ClsMethodAgentOtherStateUT();
                    sdb.UpdateOtherStateUTAgentDetail(smodel, Application_id, FileName, FilePath);
                    TempData["message"] = "Details updated Successfully";

                    ModelState.Clear();
                }
                return RedirectToAction("Create_Agent_OtherStateUT");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.ToString();
                return View("Create_Agent_OtherStateUT");
            }
        }

        // GET: Delete
        public ActionResult Delete_Agent_OtherStateUT(Int64 Agent_OtherStateUT_regRERA_ID, Int64 Agent_OtherStateUT_regRERA_IndexID, Int64 Agent_ID)
        {
            try
            {
                ClsMethodAgentOtherStateUT sdb = new ClsMethodAgentOtherStateUT();
                if (sdb.Delete_AgentOthermemberDetail(Agent_ID, Agent_OtherStateUT_regRERA_IndexID))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Create_Agent_OtherStateUT");
            }
            catch
            {
                return View();
            }
        }
        #endregion Agent_OtherStateUT_regRERAdetails

        #region Agent_Payment
        [HttpGet]
        public ActionResult RegAgent()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
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
            CLSMethodAgent_Payment sdb = new CLSMethodAgent_Payment();
            CLSprpAgent_Payment aa = new CLSprpAgent_Payment();
            aa.AgentPayment = sdb.DisplayAgentDetail(Application_id);

            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            foreach (var item in aa.AgentPayment)
            {
                //    aa.AgentPayment_ID = item.AgentPayment_ID;
                //    aa.Agent_ID = item.Agent_ID;
                //    aa.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                //    aa.AgentPayment_TitleName = item.AgentPayment_TitleName;
                //    aa.Registration_Fee = item.Registration_Fee;
                //    aa.Other_Fee = item.Other_Fee;
                //    aa.Payment_Mode = item.Payment_Mode;
                //    aa.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                //    aa.Bank_Charges = item.Bank_Charges;
                //    aa.Bank_Name = item.Bank_Name;
                //    aa.Branch_Name = item.Branch_Name;
                //    aa.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                //    aa.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                //    aa.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                //    aa.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;
                //    aa.IsDraft = item.IsDraft;
            }
            //ViewBag.submitvalue = "Cancel";

            //To stop/disable SAVE (New Agent Payment) on Nov 01,2018
            //aa.IsDraft = 1;

            TempData["submitvalue"] = "Save";
            TempData.Keep();

            //Check Isdraft value From Diary Number table
            #region
            Get_Isdraftvalue_FromDiaryNumber();
            #endregion

            Int32 AgentPayment_statusValue = 0;
            string UserNam = User.Identity.Name;
            string UserID = User.Identity.GetUserId();
            string RegNumber = string.Empty;
            string stateNam = string.Empty; //"Punjab";

            stateNam = ConfigurationManager.AppSettings["reraEnabledState"].ToString();
            AgentPayment_statusValue = sdb.Validate_AgentFeePayment(Application_id, 0, UserID, RegNumber, stateNam);

            if (AgentPayment_statusValue == 101 || AgentPayment_statusValue == 104)
            {
                if (aa.AgentPayment.Count > 0)
                {
                    foreach (var item in aa.AgentPayment)
                    {
                        var existingAgentPayment = aa.AgentPayment.FirstOrDefault(ap => ap.Payment_StatusCode == item.Payment_StatusCode);
                        if (existingAgentPayment != null)
                        {
                            //update existing object with values
                            existingAgentPayment.Payment_StatusCode = AgentPayment_statusValue;
                            existingAgentPayment.Payment_StatusName = "Not Applicable, with reference to the information provided directly by the sign-in user (" + UserNam + ") or the Agent, Please contact help desks for assistance.";
                        }                        
                    }
                    if (aa.AgentPayment.Count > 1)
                    {
                        var uniqueItems = aa.AgentPayment
                                    .GroupBy(item => item.Payment_StatusCode) //group by 'Payment_StatusCode'
                                    .Select(group => group.First()) //select first item from each group
                                    .ToList();

                        aa.AgentPayment.Clear();
                        aa.AgentPayment = uniqueItems;
                    }
                    aa.Payment_StatusCode = AgentPayment_statusValue;
                    aa.Payment_StatusName = "Not Applicable, with reference to the information provided directly by the sign-in user (" + UserNam + ") or the Agent, Please contact help desks for assistance.";
                }
                else
                {
                    CLSprpAgent_Payment aaInner = new CLSprpAgent_Payment();
                    aaInner.Payment_StatusCode = AgentPayment_statusValue;
                    aaInner.Payment_StatusName = "Not Applicable, with reference to the information provided directly by the sign-in user (" + UserNam + ") or the Agent, Please contact help desks for assistance.";
                    aa.AgentPayment.Add(aaInner);
                }
                return View("RegAgent_PaymentNA", aa);                
            }
            return View("RegAgent", aa);
        }

        [HttpGet]
        public ActionResult RegAgent_PaymentNA()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
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
            CLSMethodAgent_Payment sdb = new CLSMethodAgent_Payment();
            CLSprpAgent_Payment aa = new CLSprpAgent_Payment();

            return View("RegAgent_PaymentNA", aa);
        }

        //save pyment
        [HttpPost]
        public ActionResult RegAgent(CLSprpAgent_Payment smodel)
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
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

            CLSMethodAgent_Payment sdb = new CLSMethodAgent_Payment();
            CLSprpAgent_Payment clspro = new CLSprpAgent_Payment();
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
           
            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            clspro.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            clspro.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            String ext = String.Empty;
            string FilePath = string.Empty;
            string error = string.Empty;
            int errorstate = 0;

            if (smodel.Payment_Mode != "Online Payment")
            {
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
                                string masterAgentDoc_SetFilePath = "readwritedataAgent";
                                #endregion

                                #region UpdateFile Path Creation 
                                if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FilePath))
                                {
                                    pathindb = smodel.ImageDDorBankersCheque_FilePath.ToString();
                                }
                                else
                                {
                                    pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
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
                                    fileName = "APayment_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                                }
                                //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
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
                                FileName = smodel.ImageDDorBankersCheque_FileName;
                                ext = smodel.ImageDDorBankersCheque_FileName;
                                FilePath = smodel.ImageDDorBankersCheque_FilePath;
                            }

                            if (ModelState.IsValid)
                            {
                                // ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
                                sdb.AgentUpdateFeePaymentDetail(smodel, Application_id, FileName, FilePath);
                                TempData["message"] = "Details updated Successfully";
                                ModelState.Clear();
                            }
                            return RedirectToAction("RegAgent");
                        }
                        else
                        {
                            return RedirectToAction("RegAgent");
                        }
                    }
                    catch (Exception ex)
                    {
                        return View("RegAgent");
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
                                string masterAgentDoc_SetFilePath = "readwritedataAgent";
                                #endregion

                                #region SaveFile Path Creation
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
                                //pathAgentdata = Server.MapPath("../ pathindb/");
                                pathAgentdata = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(pathAgentdata))
                                {
                                    Directory.CreateDirectory(pathAgentdata);
                                }
                                #endregion

                                var fileName = string.Empty;
                                fileName = "AgentPayment_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
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

                    try
                    {
                        if (errorstate == 0)
                        {
                            if (FileName == "")
                            {
                                FileName = smodel.ImageDDorBankersCheque_FileName;
                                ext = smodel.ImageDDorBankersCheque_FileName;
                                FilePath = smodel.ImageDDorBankersCheque_FilePath;
                            }
                            //To stop/disable SAVE (New Agent Payment) on Nov 01,2018
                            //////if (ModelState.IsValid)
                            //////{
                            //////    if (sdb.AgentFeePaymentDetail(smodel, Application_id, FileName, FilePath))
                            //////    {
                            //////        // ViewBag.ApplicationId = Appid;
                            //////        ViewBag.Message = "Your Data is Successfully Submitted";
                            //////        ModelState.Clear();
                            //////    }
                            //////}
                            //////return RedirectToAction("RegAgent");

                            TempData["OnlinePayMessageShow"] = "The online payment will be accepted Only.";
                            return RedirectToAction("RegAgent");
                        }
                        else
                        {
                            //return View("Create_ParentEntity",);
                            return RedirectToAction("RegAgent");
                        }
                    }
                    catch (Exception ex)
                    {
                        return View("RegAgent");
                    }
                }
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
                            sdb.AgentUpdateFeePaymentDetail(smodel, Application_id, FileName, FilePath);
                            TempData["message"] = "Details updated Successfully";
                            ModelState.Clear();
                        }
                        return RedirectToAction("RegAgent");
                    }
                    else
                    {
                        if (true) //ModelState.IsValid
                        {
                            if (sdb.AgentFeePaymentDetail(smodel, Application_id, FileName, FilePath))
                            {
                                // ViewBag.ApplicationId = Appid;
                                ViewBag.Message = "Your Data is Successfully Submitted";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("RegAgent");
                    }
                }
                catch (Exception ex)
                {
                    return View("RegAgent");
                }
            }
            return View("RegAgent");
        }

        [HttpGet]
        // GET: Agent Payment Detail
        public ActionResult Edit_AgentPayment(Int64 AgentPayment_ID, Int64 Indexid, Int64 Application_id)
        {
            CLSMethodAgent_Payment sdb = new CLSMethodAgent_Payment();
            CLSprpAgent_Payment aa = new CLSprpAgent_Payment();
            aa.AgentPayment = sdb.DisplayAgentDetail(Application_id, AgentPayment_ID);

            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            foreach (var item in aa.AgentPayment)
            {
                aa.AgentPayment_IndexID = item.AgentPayment_IndexID;
                aa.AgentPayment_ID = item.AgentPayment_ID;
                aa.Agent_ID = item.Agent_ID;
                aa.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                aa.AgentPayment_TitleName = item.AgentPayment_TitleName;
                aa.Registration_Fee = item.Registration_Fee;
                aa.Other_Fee = item.Other_Fee;
                aa.Payment_Mode = item.Payment_Mode;
                aa.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aa.Bank_Charges = item.Bank_Charges;
                aa.Bank_Name = item.Bank_Name;
                aa.Branch_Name = item.Branch_Name;
                aa.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aa.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                aa.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                aa.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
            TempData["OnlinePayMessageShow"] = string.Empty;
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            //ViewBag.submitvalue = "Update";
            return View("RegAgent", aa);

        }

        [HttpPost]
        public ActionResult Edit_AgentPayment(Int64 AgentPayment_ID, Int64 Indexid, Int64 Application_id, CLSprpAgent_Payment smodel)
        {
            //string Application_id = "110030";
            //CLSMethodRERA_Agent_Payment sdb = new CLSMethodRERA_Agent_Payment();
            //CLSprpRERA_Agent_Payment clspro = new CLSprpRERA_Agent_Payment();
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            string error = string.Empty;
            //int errorstate = 0;
            try
            {
                CLSMethodAgent_Payment sdb = new CLSMethodAgent_Payment();                
                sdb.AgentUpdateFeePaymentDetail(smodel, Application_id, FileName, FilePath);
                return RedirectToAction("RegAgent");
            }

            catch (Exception ex)
            {
                String e = ex.Message;
                return View();
            }
        }

        // GET: Delete
        public ActionResult Delete_AgentPayment(Int64 AgentPayment_ID, Int64 AgentPayment_IndexID, Int64 Agent_ID)
        {            
            try
            {
                CLSMethodAgent_Payment sdb = new CLSMethodAgent_Payment();
                if (sdb.Delete_AgentFeePayment(AgentPayment_IndexID, Agent_ID))
                {
                    TempData["message"] = "Agent Payment Details Deleted Successfully";
                }
                return RedirectToAction("RegAgent");
            }
            catch
            {
                return View();
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


            UserDetails aa = new UserDetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            var Subdiv = objdis.dropdownlist_diplaySubdivForAgent(Id);

            return Json(Subdiv);
        }
        #endregion State_District

        public JsonResult GetReraExistingNumber(string RERA_RegNumber)
        {
            ClsMethodAgent_ExisitingRera objdis = new ClsMethodAgent_ExisitingRera();            
            var states = objdis.Fill_Existing_detail(RERA_RegNumber);
            return Json(states);
        }

        public JsonResult GetReraExistingNumberByID(string RERA_RegNumber, int typeAgent, int resetFlag)
        {
            ClsMethodAgent_ExisitingRera objdis = new ClsMethodAgent_ExisitingRera();

            string UserID = User.Identity.GetUserId();
            string stateNam = string.Empty; //"Punjab";
            Int32 typeofagent = 0; //Type of Agent (1:IND/2:OTI)
            Int32 resetFlagValue = 0; //Other State Entry Flag (1:Enanble/2:Disable)
            resetFlagValue = resetFlag;
            typeofagent = typeAgent;
            stateNam = ConfigurationManager.AppSettings["reraEnabledState"].ToString();
            var states = objdis.Fill_Existing_detail_ByID(RERA_RegNumber, stateNam, typeofagent, resetFlagValue, UserID);
            return Json(states);
        }

        /// Table 19 Check Lists
        #region
        /// Real Estate Agent Check Lists
        // Get:
        [HttpGet]
        public ActionResult Create_AgentCheckList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create_AgentStepByStepGuide()
        {
            return View();
        }
        #endregion

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

        /// Agent Dashboard Details
        #region
        
        [HttpGet]
        public ActionResult AgentDashboard()
        {
            Int64 Application_id = 0;
            string varUserRole = string.Empty;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }                
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsMethod_Agent_DiaryNumberAgentDashbaord sdb = new ClsMethod_Agent_DiaryNumberAgentDashbaord();
            ClsPrp_Agent_DiaryNumberAgentDashbaord aa = new ClsPrp_Agent_DiaryNumberAgentDashbaord();
            
            varUserRole = getUserRole();
            aa.prpongoing = sdb.Display_Agent_Dashboard_RegDiaryNumberByAgentID(Application_id, varUserRole);

            return View("AgentDashboard", aa);
        }

        [HttpGet]
        public ActionResult AgentDashboardRenewalRegistration()
        {
            ClsMethod_Agent_DiaryNumberAgentDashbaord sdb = new ClsMethod_Agent_DiaryNumberAgentDashbaord();
            ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord aa = new ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord();

            Int64 dbrna_AgentID = 0;
            Int32 dbrna_TypeOfAgent = 0;
            Int64 dbrna_RenewalAgentID = 0;
            Int32 dbrna_RenewalSequenceID = 0;
            Int32 dbrna_RenewalAgentYear = 0;
            string dbrna_Error = string.Empty;

            try
            {
                string dbrna_UID = User.Identity.GetUserId();
                string dbrna_UserNam = User.Identity.Name;
                string dbrna_userRole = getUserRole();

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        dbrna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        dbrna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (dbrna_AgentID != 0 && dbrna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                dbrna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                dbrna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                dbrna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                        else
                        {
                            //NA Case :- Error (Session Expires/Empty)
                            dbrna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        dbrna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
                #endregion               

                aa.prpongoing = sdb.Display_Agent_Dashboard_RenewalRegistrationDiaryNumberByAgentID(dbrna_AgentID, dbrna_TypeOfAgent, dbrna_RenewalAgentID, dbrna_RenewalSequenceID, dbrna_RenewalAgentYear, dbrna_userRole);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return View("AgentDashboardRenewalRegistration", aa);
        }

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
        public JsonResult GetRenewalAgentChecklistNotAcceptedByAgentId(Int64? AgentId, Int64? RenewalAgentId, Int32? RenewalAgentSequenceId, Int32? RenewalAgentYearId)
        {
            string varStrRet = string.Empty;
            if (AgentId != 0)
            {
                long Id = 0;
                long RenewalId = 0;
                int RenewalSeqId = 0;
                int RenewalYearId = 0;

                Id = Convert.ToInt64(AgentId);
                RenewalId = Convert.ToInt64(RenewalAgentId);
                RenewalSeqId = Convert.ToInt32(RenewalAgentSequenceId);
                RenewalYearId = Convert.ToInt32(RenewalAgentYearId);

                string pUserRole = string.Empty;
                pUserRole = getUserRole();

                Models.HelpDeskAgent.ClsMethod_RenewalAgent_Helpdesk objCode = new Models.HelpDeskAgent.ClsMethod_RenewalAgent_Helpdesk();
                Models.HelpDeskAgent.ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new Models.HelpDeskAgent.ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();

                aa.prpongoing = objCode.Display_DashboardDesk_RenewalAgent_CheckList_NoAccept_DetailsByCode(Id, RenewalId, RenewalSeqId, RenewalYearId, pUserRole);

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

        [HttpGet]
        public ActionResult Agent_InfoApplicationStatusView(Int64 AgentId)
        {
            ClsMethod_Agent_DiaryNumberAgentDashbaord sdb = new ClsMethod_Agent_DiaryNumberAgentDashbaord();
            ClsPrp_Agent_DiaryNumberAgentDashbaord prpObj = new ClsPrp_Agent_DiaryNumberAgentDashbaord();

            string userRole = string.Empty;
            userRole = getUserRole();
            prpObj.prpongoing = sdb.Display_Agent_Dashboard_RegDiaryNumberByAgentID(AgentId, userRole);

            foreach (var item in prpObj.prpongoing)
            {
                prpObj.AgentRegDiaryNumber_IndexID = item.AgentRegDiaryNumber_IndexID;
                prpObj.AgentRegDiaryNumber_ID = item.AgentRegDiaryNumber_ID;
                prpObj.AgentRegDiaryNumber_Name = item.AgentRegDiaryNumber_Name;
                prpObj.AgentRegDiaryNumber_NameYear = item.AgentRegDiaryNumber_NameYear;

                prpObj.Agent_ID = item.Agent_ID;
                prpObj.UserID = item.UserID;

                prpObj.othermemdetailCount = item.othermemdetailCount;
                prpObj.documentuploadCount = item.documentuploadCount;
                prpObj.UTOtherStateRERACount = item.UTOtherStateRERACount;
                prpObj.PaymentCount = item.PaymentCount;
                prpObj.AgentDocumentCount = item.AgentDocumentCount;
                prpObj.Remarks_IfAny = item.Remarks_IfAny;
                prpObj.CurrentEventcode = item.CurrentEventcode;
                prpObj.EventCodeDetails_indexID = item.EventCodeDetails_indexID;

                prpObj.IsActive = item.IsActive;
                prpObj.IsDraft = item.IsDraft;
                prpObj.IsDraftHelpDesk = item.IsDraftHelpDesk;
                prpObj.IsDraftEvaluation = item.IsDraftEvaluation;
                prpObj.IsDraftSecMember = item.IsDraftSecMember;
                prpObj.IsDraftMember = item.IsDraftMember;

                prpObj.CreatedBy = item.CreatedBy;
                prpObj.CreatedOn = item.CreatedOn;
                prpObj.ModifyBy = item.ModifyBy;
                prpObj.ModifyOn = item.ModifyOn;

                prpObj.Agent_Name = item.Agent_Name;
                prpObj.Agent_RERAregistrationNumber = item.Agent_RERAregistrationNumber;

                prpObj.EventAction_Type = item.EventAction_Type;
                prpObj.EventAction_TypeName = item.EventAction_TypeName;
                prpObj.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                prpObj.EventAction_Aggregate = item.EventAction_Aggregate;
                prpObj.Target_ResolutionDate = item.Target_ResolutionDate;
                prpObj.EventRemarks_IfAny = item.EventRemarks_IfAny;
                prpObj.EventAction_Summary = item.EventAction_Summary;

                prpObj.RenewalAgentRegDiaryNumber_ID = item.RenewalAgentRegDiaryNumber_ID;
                prpObj.RenewalAgentRegDiaryNumber_Name = item.RenewalAgentRegDiaryNumber_Name;
                prpObj.RenewalAgentRegDiaryNumber_NameYear = item.RenewalAgentRegDiaryNumber_NameYear;
                prpObj.Registration_Number_Code = item.Registration_Number_Code;
                prpObj.Registration_Number_EventTypeID = item.Registration_Number_EventTypeID;
                prpObj.Registration_Number_SeqOrder = item.Registration_Number_SeqOrder;

                prpObj.Registration_Number_ReferenceID = item.Registration_Number_ReferenceID;
                prpObj.Registration_Number_ReferenceNumber = item.Registration_Number_ReferenceNumber;
                prpObj.Registration_Number_ReferenceDate = item.Registration_Number_ReferenceDate;
                prpObj.Registration_Number_IsLatestRenewal_Flag = item.Registration_Number_IsLatestRenewal_Flag;

                prpObj.RERA_Registration_Number = item.RERA_Registration_Number;
                prpObj.RERA_Registration_IssueDate = item.RERA_Registration_IssueDate;
                prpObj.RERA_Registration_ValidUptoDate = item.RERA_Registration_ValidUptoDate;
                prpObj.LastRenewal_Registration_IssueDate = item.LastRenewal_Registration_IssueDate;
                prpObj.LastRenewal_Registration_ValidUptoDate = item.LastRenewal_Registration_ValidUptoDate;
                prpObj.Registration_Number_Flag = item.Registration_Number_Flag;
                prpObj.Registration_Number_Status = item.Registration_Number_Status;
            }
            if (prpObj.prpongoing.Count > 0)
            {
                if (prpObj.EventAction_Type == "220007")
                {
                    prpObj.AppAgentCheckListContent = sdb.Display_Agent_Dashboard_AgentCheckList_NoAccept_DetailsByCode(AgentId, userRole);
                }
            }
            return View("Agent_InfoApplicationStatusView", prpObj);
        }

        [HttpGet]
        public ActionResult RenewalAgent_InfoApplicationStatusView(Int64 AgentId, Int64 RenewalAgentId, Int32 RenewalAgentSequenceId, Int32 RenewalAgentYearId)
        {
            ClsMethod_Agent_DiaryNumberAgentDashbaord sdb = new ClsMethod_Agent_DiaryNumberAgentDashbaord();
            ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord prpObj = new ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord();

            string userRole = string.Empty;
            userRole = getUserRole();
            prpObj.prpongoing = sdb.Display_Agent_Dashboard_RenewalRegistrationDiaryNumber_DetailsByID(AgentId, RenewalAgentId, RenewalAgentSequenceId, RenewalAgentYearId, userRole);

            foreach (var item in prpObj.prpongoing)
            {
                prpObj.RenewalAgent_RegDiaryNumber_IndexID = item.RenewalAgent_RegDiaryNumber_IndexID;
                prpObj.RenewalAgent_RegDiaryNumber_ID = item.RenewalAgent_RegDiaryNumber_ID;
                prpObj.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                prpObj.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                prpObj.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                prpObj.Related_Agent_ID = item.Related_Agent_ID;
                prpObj.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                prpObj.Related_Agent_Type = item.Related_Agent_Type;
                prpObj.Related_UserID = item.Related_UserID;
                prpObj.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                prpObj.Related_RERAnumberIssueDate = item.Related_RERAnumberIssueDate;
                prpObj.Related_RERAnumberRegUptoDate = item.Related_RERAnumberRegUptoDate;

                prpObj.AgentRegDiaryNumber_IndexID = item.AgentRegDiaryNumber_IndexID;
                prpObj.AgentRegDiaryNumber_ID = item.AgentRegDiaryNumber_ID;
                prpObj.AgentRegDiaryNumber_Name = item.AgentRegDiaryNumber_Name;
                prpObj.AgentRegDiaryNumber_NameYear = item.AgentRegDiaryNumber_NameYear;
                prpObj.Agent_ID = item.Agent_ID;
                prpObj.UserID = item.UserID;

                prpObj.othermemdetailCount = item.othermemdetailCount;
                prpObj.documentuploadCount = item.documentuploadCount;
                prpObj.UTOtherStateRERACount = item.UTOtherStateRERACount;
                prpObj.PaymentCount = item.PaymentCount;
                prpObj.AgentDocumentCount = item.AgentDocumentCount;
                prpObj.Remarks_IfAny = item.Remarks_IfAny;
                prpObj.CurrentEventcode = item.CurrentEventcode;
                prpObj.EventCodeDetails_indexID = item.EventCodeDetails_indexID;

                prpObj.IsActive = item.IsActive;
                prpObj.IsDraft = item.IsDraft;
                prpObj.IsDraftHelpDesk = item.IsDraftHelpDesk;
                prpObj.IsDraftEvaluation = item.IsDraftEvaluation;
                prpObj.IsDraftSecMember = item.IsDraftSecMember;
                prpObj.IsDraftMember = item.IsDraftMember;
                prpObj.IsActiveProvider = item.IsActiveProvider;
                prpObj.IsLock = item.IsLock;
                prpObj.IsPublicView = item.IsPublicView;

                prpObj.CreatedBy = item.CreatedBy;
                prpObj.CreatedOn = item.CreatedOn;
                prpObj.ModifyBy = item.ModifyBy;
                prpObj.ModifyOn = item.ModifyOn;

                prpObj.Agent_Name = item.Agent_Name;
                prpObj.Agent_RERAregistrationNumber = item.Agent_RERAregistrationNumber;

                prpObj.EventAction_Type = item.EventAction_Type;
                prpObj.EventAction_TypeName = item.EventAction_TypeName;
                prpObj.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                prpObj.EventAction_Aggregate = item.EventAction_Aggregate;
                prpObj.Target_ResolutionDate = item.Target_ResolutionDate;
                prpObj.EventRemarks_IfAny = item.EventRemarks_IfAny;
                prpObj.EventAction_Summary = item.EventAction_Summary;

                prpObj.RenewalAgentRegDiaryNumber_ID = item.RenewalAgentRegDiaryNumber_ID;
                prpObj.RenewalAgentRegDiaryNumber_Name = item.RenewalAgentRegDiaryNumber_Name;
                prpObj.RenewalAgentRegDiaryNumber_NameYear = item.RenewalAgentRegDiaryNumber_NameYear;
                prpObj.Registration_Number_Code = item.Registration_Number_Code;
                prpObj.Registration_Number_EventTypeID = item.Registration_Number_EventTypeID;
                prpObj.Registration_Number_SeqOrder = item.Registration_Number_SeqOrder;

                prpObj.Registration_Number_ReferenceID = item.Registration_Number_ReferenceID;
                prpObj.Registration_Number_ReferenceNumber = item.Registration_Number_ReferenceNumber;
                prpObj.Registration_Number_ReferenceDate = item.Registration_Number_ReferenceDate;
                prpObj.Registration_Number_IsLatestRenewal_Flag = item.Registration_Number_IsLatestRenewal_Flag;

                prpObj.RERA_Registration_Number = item.RERA_Registration_Number;
                prpObj.RERA_Registration_IssueDate = item.RERA_Registration_IssueDate;
                prpObj.RERA_Registration_ValidUptoDate = item.RERA_Registration_ValidUptoDate;
                prpObj.LastRenewal_Registration_IssueDate = item.LastRenewal_Registration_IssueDate;
                prpObj.LastRenewal_Registration_ValidUptoDate = item.LastRenewal_Registration_ValidUptoDate;
                prpObj.Registration_Number_Flag = item.Registration_Number_Flag;
                prpObj.Registration_Number_Status = item.Registration_Number_Status;
            }
            if (prpObj.prpongoing.Count > 0)
            {
                if (prpObj.EventAction_Type == "290007")
                {
                    prpObj.AppRnAgentCheckListContent = sdb.Display_Agent_Dashboard_RenewalAgent_CheckList_NoAccept_DetailsByCode(AgentId, RenewalAgentId, RenewalAgentSequenceId, RenewalAgentYearId, userRole);
                }
            }
            return View("RenewalAgent_InfoApplicationStatusView", prpObj);
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

        /// Alert - NA views
        #region
        ///Alert - NA Agent Members
        public ActionResult Create_Agent_memNA()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }                
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            return View();
        }

        ///Alert - NA Agent Other State UT
        public ActionResult Create_Agent_OtherStateUTNA()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            return View();
        }
        #endregion

        #region Agent_Print
        [HttpGet]
        public ActionResult PrintView()
        {
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
    }
}
