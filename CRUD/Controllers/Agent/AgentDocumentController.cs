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

namespace CRUD.Controllers.AgentDocuments
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentDocumentController : Controller
    {
        // GET: AgentDocument
        [HttpGet]
        public ActionResult AgentDoc()
        {
            Int64 Agent_IDfromSession = 0;            
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
            Agent_IDfromSession = Application_id;

            Clsprp_Master_Agent_Documents clsprp = new Clsprp_Master_Agent_Documents();
            ClsMethod_Master_Agent_Documents objdoc = new ClsMethod_Master_Agent_Documents();
            ClsMethod_Agent_Documents objAgentDoc = new ClsMethod_Agent_Documents();
            Clsprp_Agent_Documents clsprpPrmDoc = new Clsprp_Agent_Documents();
            List<Clsprp_Agent_Documents> clsprpPrmDocList = new List<Clsprp_Agent_Documents>();

            clsprpPrmDoc.AgentDoc_IssueDate = DateTime.Now;

            clsprpPrmDocList = objAgentDoc.Display_Agent_Documents_AgentId(Agent_IDfromSession);

            clsprpPrmDoc.AgentDocs = objAgentDoc.Display_Agent_Documents_AgentId(Agent_IDfromSession);

            //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Agent_Documents();
            clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Agent_DocumentsByAgentID(Agent_IDfromSession);

            foreach (var item in clsprpPrmDoc.MasterDocs)
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
            #region
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion
            return View("~/Views/Agent/AgentDoc.cshtml", clsprpPrmDoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FormUpload(HttpPostedFileBase uploadedFile, Clsprp_Agent_Documents smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Agent_Documents clsprp = new Clsprp_Master_Agent_Documents();
                    ClsMethod_Master_Agent_Documents objdoc = new ClsMethod_Master_Agent_Documents();
                    Clsprp_Agent_Documents clsprpPrmDoc = new Clsprp_Agent_Documents();
                    ClsMethod_Agent_Documents objAgentDoc = new ClsMethod_Agent_Documents();

                    Int32 IndexId = smodel.AgentDoc_InfoCode;
                    Int64 AgentId = 0;
                    Int64 Application_id = 0;
                    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                    {
                        if (Session["ApplicationId"].ToString() != "0")
                        {
                            Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        }
                    }
                    AgentId = Application_id;
                    //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Agent_Documents();

                    #region Read Master Data By Document Type
                    clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Agent_DocumentsByAgentID(AgentId);

                    Tuple<Int64, Int64> tupleSumCntFile = (objAgentDoc.Display_Agent_Documents_ByDocCodeInfoAgentID(AgentId, IndexId));

                    //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Agent_Documents(IndexId);

                    foreach (var item in clsprpPrmDoc.MasterDocs)
                    {
                        if (item.AgentDocMaster_InfoCode == IndexId)
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
                    var path = "";
                    var pathindb = "";
                    var savefileName = "";
                    string extensionPhotoIdentityDocument = string.Empty;
                    int byteCountPhotoIdentityDocument = 0;
                    string masterGetPhotoIdentityDocument = string.Empty;
                    Int32 extensionPutPhotoIdentityDocument = 0;
                    Int32 masterPutPhotoIdentityDocument = 0;
                    string masterAgentDoc_SetFilePath = "readwriteAgent";
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
                            if (clsprp.AgentDoc_SetFilePath.ToString() != string.Empty || clsprp.AgentDoc_SetFilePath.ToString() != null)
                            {
                                masterAgentDoc_SetFilePath = clsprp.AgentDoc_SetFilePath.ToString();
                            }
                            pathindb = masterAgentDoc_SetFilePath + "\\" + Convert.ToString(AgentId) + "\\";
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
                                            savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.AgentDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                            var pathsavefile = Path.Combine(path, savefileName);
                                            PhotoIdentityDocument.SaveAs(pathsavefile);

                                            var pathsavedb = Path.Combine(pathindb, savefileName);

                                            Int64 inAgent_ID = AgentId;
                                            string inAgentDoc_FilePath = pathsavedb;
                                            string inAgentDoc_FileName = savefileName;
                                            string inAgentDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inAgentDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inAgentDoc_IsGroup = Convert.ToInt32(clsprp.IsMandatory);

                                            bool varRet = SaveAgentDocument(smodel, inAgent_ID, inAgentDoc_FilePath, inAgentDoc_FileName, inAgentDoc_FileSize, inAgentDoc_FileFormat, inAgentDoc_IsGroup);

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

        private bool SaveAgentDocument(Clsprp_Agent_Documents smodel, Int64 z_Agent_ID, String z_AgentDoc_FilePath, String z_AgentDoc_FileName, String z_AgentDoc_FileSize, String z_AgentDoc_FileFormat, Int32 z_AgentDoc_IsGroup)
        {
            Int64 Agent_ID = 0;
            Agent_ID = z_Agent_ID;
            string AgentDoc_FilePath = String.IsNullOrEmpty(z_AgentDoc_FilePath) ? string.Empty : z_AgentDoc_FilePath;
            string AgentDoc_FileName = String.IsNullOrEmpty(z_AgentDoc_FileName) ? string.Empty : z_AgentDoc_FileName;
            string AgentDoc_FileSize = String.IsNullOrEmpty(z_AgentDoc_FileSize) ? string.Empty : z_AgentDoc_FileSize;
            string AgentDoc_FileFormat = String.IsNullOrEmpty(z_AgentDoc_FileFormat) ? string.Empty : z_AgentDoc_FileFormat;
            Int32 AgentDoc_IsGroup = z_AgentDoc_IsGroup;
            bool varRET = false;

            ////if (Session["Project_id"] != null)
            ////{
            ////    Agent_ID = Convert.ToInt64(Session["Project_id"].ToString());
            ////    smodel.Agent_ID = Agent_ID;
            ////}
            ////else
            ////{
            ////    RedirectToAction("IndexAgent", "Home");
            ////}

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Agent_Documents savedb = new ClsMethod_Agent_Documents();
                    if (savedb.Add_Agent_Documents(smodel, Agent_ID, AgentDoc_FilePath, AgentDoc_FileName, AgentDoc_FileSize, AgentDoc_FileFormat, AgentDoc_IsGroup))
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

        public JsonResult GetAgentDocumentMasterByDocId(string DocId)
        {
            int Id = 0;
            if (DocId != "")
                Id = Convert.ToInt32(DocId);
                        
            ClsMethod_Master_Agent_Documents objDoc = new ClsMethod_Master_Agent_Documents();
            var Subdiv = objDoc.Display_Master_Agent_Documents(Id);

            return Json(Subdiv);
        }

        //GET: Delete
        public ActionResult Delete_AgentDoc(Int64? inAgentDoc_IndexID, Int64? inAgentDoc_ID, Int64? inAgent_ID)
        {
            try
            {
                ClsMethod_Agent_Documents sdb = new ClsMethod_Agent_Documents();
                if (sdb.Delete_Agent_Documents(inAgentDoc_IndexID, inAgentDoc_ID, inAgent_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("AgentDoc");
            }
            catch
            {
                return RedirectToAction("AgentDoc");
            }
        }

        public void Get_Isdraftvalue_FromDiaryNumber(Int64 Application_id)
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