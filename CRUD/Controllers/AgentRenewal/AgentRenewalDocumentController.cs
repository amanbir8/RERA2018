using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models.AgentDocument;
using CRUD.Models;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using CRUD.Models.PromoterProject;
using CRUD.Models.AgentRenewal;
using Microsoft.AspNet.Identity;

namespace CRUD.Controllers.AgentRenewalDocument
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentRenewalDocumentController : Controller
    {
        #region Agent_Renewal Document Details
        [HttpGet]
        public ActionResult AgentRenewal_IO_Documentdetail()
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
                        User_KeyID = 2;//documents
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
                            return RedirectToAction("AgentRenewal_Documentdetail", "AgentRenewalDocument");
                        }
                        else
                        {
                            //NA Case :- Error (Other-StateUT RERA_Number : Not Applicable)
                            User_Error = "Not Applicable! The renewal of registration (Real-estate Agent) application form for document uploads. Please sign-in with registered real-estate agent with the Authority.";
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
            return View("~/Views/AgentRenewal/AgentRenewal_IO_Documentdetail.cshtml", prpAgent);
        }

        [HttpGet]
        public ActionResult AgentRenewal_Documentdetail()
        {          
            ClsMethod_AgentRenewal_Documents objRnAgentDoc = new ClsMethod_AgentRenewal_Documents();
            Clsprp_AgentRenewal_Documents clsprpRnADoc = new Clsprp_AgentRenewal_Documents();
            List<Clsprp_AgentRenewal_Documents> clsprpRnADocList = new List<Clsprp_AgentRenewal_Documents>();

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
                
                Clsprp_Master_Agent_Documents clsprp = new Clsprp_Master_Agent_Documents();
                ClsMethod_Master_Agent_Documents objdoc = new ClsMethod_Master_Agent_Documents();                

                UserID = User.Identity.GetUserId();
                UserName = User.Identity.Name;
                clsprpRnADoc.AgentDoc_IssueDate = DateTime.Now;
                clsprpRnADocList = objRnAgentDoc.AgentRenewal_Display_DocumentsDetail_ByID(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);
                clsprpRnADoc.AgentRenewal_Document = objRnAgentDoc.AgentRenewal_Display_DocumentsDetail_ByID(User_AgentID, User_TypeOfAgent, User_RenewalAgentID, User_RenewalAgentYear, User_RenewalSequenceID, UserID);

                clsprpRnADoc.MasterDocs = objdoc.Display_Master_Agent_DocumentsByAgentID(User_AgentID);
                foreach (var item in clsprpRnADoc.MasterDocs)
                {
                    clsprp.AgentDocMaster_IndexID = item.AgentDocMaster_IndexID;
                    clsprp.AgentDocMaster_InfoCode = item.AgentDocMaster_InfoCode;
                    clsprp.AgentDocMaster_InfoName = item.AgentDocMaster_InfoName;
                    clsprp.AgentDoc_SetFileSize = item.AgentDoc_SetFileSize;
                    clsprp.AgentDoc_SetFileFormat = item.AgentDoc_SetFileFormat;
                    clsprp.AgentDoc_SetFilePath = item.AgentDoc_SetFilePath;
                    clsprp.AgentDoc_ValidCode = item.AgentDoc_ValidCode;
                    clsprp.AgentDoc_ValidSubCode = item.AgentDoc_ValidSubCode;
                    clsprp.AgentDoc_ValidTinySubCode = item.AgentDoc_ValidTinySubCode;
                    clsprp.IsGroup = item.IsGroup;
                    clsprp.IsMandatory = item.IsMandatory;
                    clsprp.A_column = item.A_column;
                    clsprp.B_column = item.B_column;
                    clsprp.C_column = item.C_column;
                    clsprp.IsActive = item.IsActive;
                    clsprp.CreatedBy = item.CreatedBy;
                    clsprp.CreatedOn = item.CreatedOn;
                    clsprp.ModifyBy = item.ModifyBy;
                    clsprp.ModifyOn = item.ModifyOn;
                }
                clsprpRnADoc.Related_Agent_Type = User_TypeOfAgent;
            }
            catch (Exception ex)
            {
                User_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                string exvariable = ex.ToString();
            }

            #region Check Isdraft value From Diary-Table
            RenewalAgent_GetIsdraftvalue_FromDiaryNumber();
            #endregion
            return View("~/Views/AgentRenewal/AgentRenewal_Documentdetail.cshtml", clsprpRnADoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AgentRenewal_FormUpload(HttpPostedFileBase uploadedFile, Clsprp_AgentRenewal_Documents smodel)
        {
            try
            {
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    if (ModelState.IsValid)
                    {
                        Clsprp_Master_Agent_Documents clsprp = new Clsprp_Master_Agent_Documents();
                        ClsMethod_Master_Agent_Documents objdoc = new ClsMethod_Master_Agent_Documents();

                        Clsprp_AgentRenewal_Documents clsprpRnADoc = new Clsprp_AgentRenewal_Documents();
                        ClsMethod_AgentRenewal_Documents objRnAgentDoc = new ClsMethod_AgentRenewal_Documents();

                        #region Parms Renewal-Agent
                        Int32 md_IndexId = smodel.AgentDoc_InfoCode;
                        Int64 md_AgentID = 0;
                        Int32 md_TypeOfAgent = 0;
                        Int64 md_RenewalAgentID = 0;
                        Int32 md_RenewalSequenceID = 0;
                        Int32 md_RenewalAgentYear = 0;
                        string UserID = string.Empty;
                        string UserName = string.Empty;
                        string UserError = string.Empty;

                        if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                        {
                            if (Session["ApplicationId"].ToString() != "0")
                            {
                                md_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                            }
                            if (Session["User_Type"].ToString() != "0")
                            {
                                md_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                            }
                            if (md_AgentID != 0 && md_TypeOfAgent != 0)
                            {
                                if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                                {
                                    if (Session["RenewalAgentId"].ToString() != "0")
                                    {
                                        md_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                                    }
                                    if (Session["RenewalSequenceId"].ToString() != "0")
                                    {
                                        md_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                                    }
                                    if (Session["RenewalAgentYear"].ToString() != "0")
                                    {
                                        md_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                                    }
                                }
                            }
                            else
                            {
                                // NA - No records found                        
                                UserError = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                            }
                        }
                        else
                        {
                            // NA - No records found as Session Expires
                            UserError = "Error! Session Expires. Please sign-in with registered real-estate agent.";
                        }
                        #endregion
                        #region Read Master Data By Document Type
                        clsprpRnADoc.MasterDocs = objdoc.Display_Master_Agent_DocumentsByAgentID(md_AgentID);

                        UserID = User.Identity.GetUserId();
                        UserName = User.Identity.Name;

                        Tuple<Int64, Int64> tupleSumCntFile = objRnAgentDoc.AgentRenewal_Display_Documents_ByDocCodeInfoAgentID(md_AgentID, md_TypeOfAgent, md_RenewalAgentID, md_RenewalAgentYear, md_RenewalSequenceID, md_IndexId, UserID);
                        foreach (var item in clsprpRnADoc.MasterDocs)
                        {
                            if (item.AgentDocMaster_InfoCode == md_IndexId)
                            {
                                clsprp.AgentDocMaster_IndexID = item.AgentDocMaster_IndexID;
                                clsprp.AgentDocMaster_InfoCode = item.AgentDocMaster_InfoCode;
                                clsprp.AgentDocMaster_InfoName = item.AgentDocMaster_InfoName;
                                clsprp.AgentDoc_SetFileSize = item.AgentDoc_SetFileSize;
                                clsprp.AgentDoc_SetFileFormat = item.AgentDoc_SetFileFormat;
                                clsprp.AgentDoc_SetFilePath = item.AgentDoc_SetFilePath;
                                clsprp.AgentDoc_ValidCode = item.AgentDoc_ValidCode;
                                clsprp.AgentDoc_ValidSubCode = item.AgentDoc_ValidSubCode;
                                clsprp.AgentDoc_ValidTinySubCode = item.AgentDoc_ValidTinySubCode;
                                clsprp.IsGroup = item.IsGroup;
                                clsprp.IsMandatory = item.IsMandatory;
                                clsprp.A_column = item.A_column;
                                clsprp.B_column = item.B_column;
                                clsprp.C_column = item.C_column;
                                clsprp.IsActive = item.IsActive;
                                clsprp.CreatedBy = item.CreatedBy;
                                clsprp.CreatedOn = item.CreatedOn;
                                clsprp.ModifyBy = item.ModifyBy;
                                clsprp.ModifyOn = item.ModifyOn;
                            }
                        }
                        #endregion
                        #region Declare Variables
                        var path = string.Empty;
                        var pathindb = string.Empty;
                        var savefileName = string.Empty;
                        string extensionPhotoIdentityDocument = string.Empty;
                        int byteCountPhotoIdentityDocument = 0;
                        string masterGetPhotoIdentityDocument = string.Empty;
                        Int32 extensionPutPhotoIdentityDocument = 0;
                        Int32 masterPutPhotoIdentityDocument = 0;
                        string masterAgentDoc_SetFilePath = "readwriteRnAgentFMJ";
                        bool IsValidFileType = false;
                        #endregion

                        //Bad Request - No Doc
                        if (Request.Files.Count > 0)
                        {
                            var PhotoIdentityDocument = Request.Files[0];

                            //Bad Request - No Doc OR No Size
                            if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                            {
                                #region SaveFile Path Creation
                                if (clsprp.B_column.ToString() != string.Empty || clsprp.B_column.ToString() != null)
                                {
                                    masterAgentDoc_SetFilePath = clsprp.B_column.ToString();
                                }
                                pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(md_RenewalAgentID) + "\\";
                                path = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                #endregion
                                #region Master File Type Check
                                //Upload File Type
                                extensionPhotoIdentityDocument = Path.GetExtension(PhotoIdentityDocument.FileName);
                                switch (extensionPhotoIdentityDocument)
                                {
                                    case ".JPEG":
                                    case ".jpeg":
                                    case ".JPG":
                                    case ".jpg":
                                    case ".PNG":
                                    case ".png":
                                        {
                                            //Image Type
                                            extensionPutPhotoIdentityDocument = 102;
                                            break;
                                        }
                                    case ".PDF":
                                    case ".pdf":
                                        {
                                            //PDF Type
                                            extensionPutPhotoIdentityDocument = 103;
                                            break;
                                        }
                                }

                                //Master File Type
                                masterGetPhotoIdentityDocument = Convert.ToString(clsprp.AgentDoc_SetFileFormat);
                                switch (masterGetPhotoIdentityDocument)
                                {
                                    case "JPEG/JPG/PDF":
                                        {
                                            //Both Image and PDF Type
                                            masterPutPhotoIdentityDocument = 101;
                                            break;
                                        }
                                    case "JPEG/JPG":
                                    case "JPEG":
                                    case "JPG":
                                        {
                                            //Image Type
                                            masterPutPhotoIdentityDocument = 102;
                                            break;
                                        }
                                    case "PDF":
                                        {
                                            //PDF Type
                                            masterPutPhotoIdentityDocument = 103;
                                            break;
                                        }
                                }
                                if (masterPutPhotoIdentityDocument == 101)
                                {
                                    if (extensionPutPhotoIdentityDocument == 102 || extensionPutPhotoIdentityDocument == 103)
                                    {
                                        IsValidFileType = true;
                                    }
                                }
                                else
                                {
                                    if (extensionPutPhotoIdentityDocument == masterPutPhotoIdentityDocument)
                                    {
                                        IsValidFileType = true;
                                    }
                                }
                                #endregion

                                //Check Number of Files Uploaded
                                if (tupleSumCntFile.Item2 < Convert.ToInt32(clsprp.IsGroup))
                                {
                                    //if ((extensionPhotoIdentityDocument == ".JPG") || (extensionPhotoIdentityDocument == ".jpg") || (extensionPhotoIdentityDocument == ".jpeg") || (extensionPhotoIdentityDocument == ".gif") || (extensionPhotoIdentityDocument == ".png")) //))//
                                    if (IsValidFileType)
                                    {
                                        if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.AgentDoc_SetFileSize))
                                        {
                                            byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                            if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.AgentDoc_SetFileSize))
                                            {
                                                string filedocname = clsprp.AgentDocMaster_InfoName.ToString();
                                                if (clsprp.AgentDocMaster_InfoName.Length >= 60)
                                                {
                                                    filedocname = "DocFormJ_";
                                                }
                                                savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(filedocname) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                                var pathsavefile = Path.Combine(path, savefileName);
                                                PhotoIdentityDocument.SaveAs(pathsavefile);

                                                var pathsavedb = Path.Combine(pathindb, savefileName);

                                                Int64 inAgent_ID = md_AgentID;
                                                Int32 inTypeOfAgent = md_TypeOfAgent;
                                                Int64 inRenewalAgentID = md_RenewalAgentID;
                                                Int32 inRenewalSequenceID = md_RenewalSequenceID;
                                                Int32 inRenewalAgentYear = md_RenewalAgentYear;
                                                string inAgentDoc_FilePath = pathsavedb;
                                                string inAgentDoc_FileName = savefileName;
                                                string inAgentDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                                string inAgentDoc_FileFormat = extensionPhotoIdentityDocument;
                                                Int32 inAgentDoc_IsGroup = Convert.ToInt32(clsprp.IsMandatory);

                                                bool varRet = SaveRenewalAgentDocument(smodel, inAgent_ID, inTypeOfAgent, inRenewalAgentID, inRenewalSequenceID, inRenewalAgentYear, inAgentDoc_FilePath, inAgentDoc_FileName, inAgentDoc_FileSize, inAgentDoc_FileFormat, inAgentDoc_IsGroup);
                                                if (varRet != false)
                                                {
                                                    return Json(new
                                                    {
                                                        //Data = "Complete",
                                                        statusCode = 101,
                                                        status = "Complete",
                                                        remarks = "Successfully uplaoded"
                                                    }, JsonRequestBehavior.AllowGet);
                                                }
                                                else
                                                {
                                                    return Json(new
                                                    {
                                                        //Data = "Bad Request! Upload Failed",
                                                        statusCode = 105,
                                                        status = "Bad Request! Upload Failed",
                                                        remarks = "Not Saved! Upload Failed "
                                                    }, JsonRequestBehavior.AllowGet);
                                                }
                                            }
                                            else
                                            {
                                                decimal varSetFileSize = 0;
                                                string varOutSetFileSize = string.Empty;
                                                varSetFileSize = Convert.ToInt32(clsprp.AgentDoc_SetFileSize);

                                                if (varSetFileSize > 1048576)
                                                {
                                                    varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1048576) / 100 + " MB";
                                                }
                                                else if (varSetFileSize > 1024)
                                                {
                                                    varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1024) / 100 + " KB";
                                                }
                                                else
                                                {
                                                    varOutSetFileSize = varSetFileSize + " Bytes";
                                                }

                                                return Json(new
                                                {
                                                    //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                    statusCode = 103,
                                                    status = "File size should be less than " + varOutSetFileSize,
                                                    remarks = uploadedFile.FileName
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                        }
                                        else
                                        {
                                            decimal varSetGroupFileSize = 0;
                                            string varOutSetGroupFileSize = string.Empty;

                                            varSetGroupFileSize = Convert.ToInt64(tupleSumCntFile.Item1);

                                            if (varSetGroupFileSize > 1048576)
                                            {
                                                varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1048576) / 100 + " MB";
                                            }
                                            else if (varSetGroupFileSize > 1024)
                                            {
                                                varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1024) / 100 + " KB";
                                            }
                                            else
                                            {
                                                varOutSetGroupFileSize = varSetGroupFileSize + " Bytes";
                                            }


                                            return Json(new
                                            {
                                                //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                statusCode = 107,
                                                status = "Maximum number of uploaded files size limit reached.(Maximum " + varOutSetGroupFileSize + " files.)",
                                                remarks = uploadedFile.FileName
                                            }, JsonRequestBehavior.AllowGet);
                                        }
                                    }
                                    else
                                    {
                                        return Json(new
                                        {
                                            //Data = "Format not match, File Name: " + uploadedFile.FileName,
                                            statusCode = 104,
                                            status = "File format not matched.",
                                            remarks = uploadedFile.FileName
                                        }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                else
                                {
                                    return Json(new
                                    {
                                        //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
                                        statusCode = 106,
                                        status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(clsprp.IsGroup) + " files.)",
                                        remarks = uploadedFile.FileName
                                    }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(new
                                {
                                    //Data = "Bad Request! Upload Failed",
                                    statusCode = 102,
                                    status = "Bad Request! Upload Failed",
                                    remarks = string.Empty
                                }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Bad Request! Upload Failed",
                                statusCode = 102,
                                status = "Bad Request! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            //Data = "Bad Request! Upload Failed",
                            statusCode = 102,
                            status = "Mandatory field(s) required! Upload Failed",
                            remarks = string.Empty
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        //Data = "Bad Request! Upload Failed",
                        statusCode = 102,
                        status = "Bad Request! Upload Failed",
                        remarks = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string strEx = ex.ToString();

                return Json(new
                {
                    //Data = "Bad Request! Upload Failed",
                    statusCode = 102,
                    status = "Error! Upload Failed",
                    remarks = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAgentDocumentMasterByDocId(string DocId)
        {
            int Id = 0;
            if (DocId != "")
                Id = Convert.ToInt32(DocId);

            ClsMethod_Master_Agent_Documents objDoc = new ClsMethod_Master_Agent_Documents();
            var Subdiv = objDoc.Display_Master_Agent_Documents(Id);

            return Json(Subdiv);
        }

        public ActionResult AgentRenewal_DeleteDocumentdetail(Int64? inDocIndexID, Int64? inDocID, Int64? inAgentID, Int64? inRenewalAgentID)
        {
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_RenewalAgentID = 0;
            Int64 User_AgentID = 0;
            string UserID = string.Empty;
            string UserName = string.Empty;
            try
            {
                User_IndexID = Convert.ToInt64(inDocIndexID);
                User_ExtractID = Convert.ToInt64(inDocID);
                User_RenewalAgentID = Convert.ToInt64(inRenewalAgentID); 
                User_AgentID = Convert.ToInt64(inAgentID);
                UserID = User.Identity.GetUserId();
                UserName = User.Identity.Name;

                ClsMethod_AgentRenewal_Documents sdb = new ClsMethod_AgentRenewal_Documents();
                if (sdb.Delete_AgentRenewal_DocumentsDetail_byID(User_IndexID, User_ExtractID, User_RenewalAgentID, User_AgentID, UserID))
                {
                    TempData["message"] = " Details deleted Successfully";                    
                }
                return RedirectToAction("AgentRenewal_Documentdetail");
            }
            catch(Exception ex)
            {
                string strEx = ex.ToString();
                return RedirectToAction("AgentRenewal_Documentdetail");
            }
        }
        #endregion

        #region Agent_Renewal AddnFunctions
        private bool SaveRenewalAgentDocument(Clsprp_AgentRenewal_Documents smodel, Int64 z_AgentID, Int32 z_TypeAgentID, Int64 z_RenewalAgentID, Int32 z_RnAgentSeqID, Int32 z_RnAgentYear, String z_AgentDoc_FilePath, String z_AgentDoc_FileName, String z_AgentDoc_FileSize, String z_AgentDoc_FileFormat, Int32 z_AgentDoc_IsGroup)
        {
            Int64 Agent_ID = 0;
            Int32 TypeOfAgent = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalSequenceID = 0;
            Int32 RenewalAgentYear = 0;
            bool varRET = false;

            try
            {
                Agent_ID = z_AgentID;
                TypeOfAgent = z_TypeAgentID;
                RenewalAgentID = z_RenewalAgentID;
                RenewalSequenceID = z_RnAgentSeqID;
                RenewalAgentYear = z_RnAgentYear;

                string AgentDoc_FilePath = String.IsNullOrEmpty(z_AgentDoc_FilePath) ? string.Empty : z_AgentDoc_FilePath;
                string AgentDoc_FileName = String.IsNullOrEmpty(z_AgentDoc_FileName) ? string.Empty : z_AgentDoc_FileName;
                string AgentDoc_FileSize = String.IsNullOrEmpty(z_AgentDoc_FileSize) ? string.Empty : z_AgentDoc_FileSize;
                string AgentDoc_FileFormat = String.IsNullOrEmpty(z_AgentDoc_FileFormat) ? string.Empty : z_AgentDoc_FileFormat;
                Int32 AgentDoc_IsGroup = z_AgentDoc_IsGroup;

                string UserID = User.Identity.GetUserId();
                string UserName = User.Identity.Name;
                
                if (ModelState.IsValid)
                {
                    smodel.Related_Agent_Type = TypeOfAgent;
                    ClsMethod_AgentRenewal_Documents savedb = new ClsMethod_AgentRenewal_Documents();
                    if (savedb.Add_AgentRenewal_DocumentsDetail(smodel, Agent_ID, RenewalAgentID, RenewalSequenceID, RenewalAgentYear, AgentDoc_FilePath, AgentDoc_FileName, AgentDoc_FileSize, AgentDoc_FileFormat, AgentDoc_IsGroup, UserID, UserName))
                    {
                        varRET = true;
                        ModelState.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }

        private string RegexRemove(string varSTR)
        {
            string oSTR = string.Empty;            
            string pattern = "\\s+";
            string replacement = "_";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
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
        #endregion
    }
}