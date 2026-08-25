using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using CRUD.Models.Document;
using System.IO;
using System.Text.RegularExpressions;
using CRUD.Models.Promoter;
using System.Data;
using CRUD.Models.Agent;
using Apitron.PDF.Rasterizer;
using Apitron.PDF.Rasterizer.Configuration;
using System.Threading.Tasks;

namespace CRUD.Controllers.Documents
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class PromoterDocumentController : Controller
    {
        // GET: PromoterDocument
        [HttpGet]
        public ActionResult PromoterDoc()
        {
            Int64 Promoter_IDfromSession = 0;            
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            Promoter_IDfromSession = Application_id;

            Clsprp_Master_Promoter_Documents clsprp = new Clsprp_Master_Promoter_Documents();
            ClsMethod_Master_Promoter_Documents objdoc = new ClsMethod_Master_Promoter_Documents();
            ClsMethod_Promoter_Documents objPromoterDoc = new ClsMethod_Promoter_Documents();
            Clsprp_Promoter_Documents clsprpPrmDoc = new Clsprp_Promoter_Documents();
            List<Clsprp_Promoter_Documents> clsprpPrmDocList = new List<Clsprp_Promoter_Documents>();

            clsprpPrmDoc.PromoterDoc_IssueDate = DateTime.Now;

            clsprpPrmDocList = objPromoterDoc.Display_Promoter_Documents_PromoterId(Promoter_IDfromSession);

            clsprpPrmDoc.PromoterDocs = objPromoterDoc.Display_Promoter_Documents_PromoterId(Promoter_IDfromSession);

            //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_Documents();
            clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_DocumentsByPromoterID(Promoter_IDfromSession);

            foreach (var item in clsprpPrmDoc.MasterDocs)
            {
                clsprp.PromoterDocMaster_IndexID = item.PromoterDocMaster_IndexID;
                clsprp.PromoterDocMaster_InfoCode = item.PromoterDocMaster_InfoCode;
                clsprp.PromoterDocMaster_InfoName = item.PromoterDocMaster_InfoName;
                clsprp.PromoterDoc_SetFileSize = item.PromoterDoc_SetFileSize;
                clsprp.PromoterDoc_SetFileFormat = item.PromoterDoc_SetFileFormat;
                clsprp.PromoterDoc_SetFilePath = item.PromoterDoc_SetFilePath;
                clsprp.PromoterDoc_ValidCode = item.PromoterDoc_ValidCode;
                clsprp.PromoterDoc_ValidSubCode = item.PromoterDoc_ValidSubCode;
                clsprp.PromoterDoc_ValidTinySubCode = item.PromoterDoc_ValidTinySubCode;
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
            return View("~/Views/Promoter/PromoterDoc.cshtml", clsprpPrmDoc);
        }

        //       [HttpPost]

        //    public JsonResult FormUpload(HttpPostedFileBase uploadedFile)
        //    {
        //        if (uploadedFile != null && uploadedFile.ContentLength > 0)
        //        {
        //            byte[] FileByteArray = new byte[uploadedFile.ContentLength];
        //            uploadedFile.InputStream.Read(FileByteArray, 0, uploadedFile.ContentLength);
        //            Attachment newAttchment = new Attachment();
        //            newAttchment.FileName = uploadedFile.FileName;
        //            newAttchment.FileType = uploadedFile.ContentType;
        //            newAttchment.FileContent = FileByteArray;
        //            OperationResult operationResult = attachmentManager.SaveAttachment(newAttchment);
        //            if (operationResult.Success)
        //            {
        //                string HTMLString = CaptureHelper.RenderViewToString
        //                ("_AttachmentItem", newAttchment, this.ControllerContext);
        //                return Json(new
        //                {
        //                    statusCode = 200,
        //                    status = operationResult.Message,
        //                    NewRow = HTMLString
        //                }, JsonRequestBehavior.AllowGet);

        //            }
        //        else
        //        {
        //            return Json(new
        //            {
        //                statusCode = 400,
        //                status = operationResult.Message,
        //                file = uploadedFile.FileName
        //            }, JsonRequestBehavior.AllowGet);

        //        }
        //    }
        //        return Json(new
        //        {
        //            statusCode = 400,
        //            status = "Bad Request! Upload Failed",
        //            file = string.Empty
        //}, JsonRequestBehavior.AllowGet);
        //    }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult FormUpload(HttpPostedFileBase uploadedFile, Clsprp_Promoter_Documents smodel) //JsonResult ActionResult
        //{
        //    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Clsprp_Master_Promoter_Documents clsprp = new Clsprp_Master_Promoter_Documents();
        //            ClsMethod_Master_Promoter_Documents objdoc = new ClsMethod_Master_Promoter_Documents();
        //            Clsprp_Promoter_Documents clsprpPrmDoc = new Clsprp_Promoter_Documents();
        //            ClsMethod_Promoter_Documents objPromoterDoc = new ClsMethod_Promoter_Documents();

        //            Int32 IndexId = smodel.PromoterDoc_InfoCode;
        //            Int64 PromoterId = 0;
        //            Int64 Application_id = 0;
        //            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //            {
        //                if (Session["ApplicationId"].ToString() != "0")
        //                {
        //                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
        //                }
        //            }
        //            PromoterId = Application_id;
        //            //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_Documents();

        //            #region Read Master Data By Document Type
        //            clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_DocumentsByPromoterID(PromoterId);

        //            Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_Promoter_Documents_ByDocCodeInfoPromoterID(PromoterId, IndexId));

        //            //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_Documents(IndexId);

        //            foreach (var item in clsprpPrmDoc.MasterDocs)
        //            {
        //                if (item.PromoterDocMaster_InfoCode == IndexId)
        //                {
        //                    clsprp.PromoterDocMaster_IndexID = item.PromoterDocMaster_IndexID;
        //                    clsprp.PromoterDocMaster_InfoCode = item.PromoterDocMaster_InfoCode;
        //                    clsprp.PromoterDocMaster_InfoName = item.PromoterDocMaster_InfoName;
        //                    clsprp.PromoterDoc_SetFileSize = item.PromoterDoc_SetFileSize;
        //                    clsprp.PromoterDoc_SetFileFormat = item.PromoterDoc_SetFileFormat;
        //                    clsprp.PromoterDoc_SetFilePath = item.PromoterDoc_SetFilePath;
        //                    clsprp.PromoterDoc_ValidCode = item.PromoterDoc_ValidCode;
        //                    clsprp.PromoterDoc_ValidSubCode = item.PromoterDoc_ValidSubCode;
        //                    clsprp.PromoterDoc_ValidTinySubCode = item.PromoterDoc_ValidTinySubCode;
        //                    clsprp.IsGroup = item.IsGroup;
        //                    clsprp.IsMandatory = item.IsMandatory;
        //                    clsprp.A_column = item.A_column;
        //                    clsprp.B_column = item.B_column;
        //                    clsprp.C_column = item.C_column;
        //                    clsprp.IsActive = item.IsActive;
        //                    clsprp.CreatedBy = item.CreatedBy;
        //                    clsprp.CreatedOn = item.CreatedOn;
        //                    clsprp.ModifyBy = item.ModifyBy;
        //                    clsprp.ModifyOn = item.ModifyOn;
        //                }
        //            }
        //            #endregion

        //            #region Declare Variables
        //            var path = "";
        //            var pathindb = "";
        //            var savefileName = "";
        //            string extensionPhotoIdentityDocument = string.Empty;
        //            int byteCountPhotoIdentityDocument = 0;
        //            string masterGetPhotoIdentityDocument = string.Empty;
        //            Int32 extensionPutPhotoIdentityDocument = 0;
        //            Int32 masterPutPhotoIdentityDocument = 0;
        //            string masterPromoterDoc_SetFilePath = "readwritePromoter";
        //            bool IsValidFileType = false;
        //            #endregion

        //            //Bad Request - No Doc
        //            if (Request.Files.Count > 0)
        //            {
        //                var PhotoIdentityDocument = Request.Files[0];

        //                //Bad Request - No Doc OR No Size
        //                if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
        //                {
        //                    #region SaveFile Path Creation
        //                    if (clsprp.PromoterDoc_SetFilePath.ToString() != string.Empty || clsprp.PromoterDoc_SetFilePath.ToString() != null)
        //                    {
        //                        masterPromoterDoc_SetFilePath = clsprp.PromoterDoc_SetFilePath.ToString();
        //                    }
        //                    pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(PromoterId) + "\\";
        //                    path = Server.MapPath("~/" + pathindb);

        //                    if (!Directory.Exists(path))
        //                    {
        //                        Directory.CreateDirectory(path);
        //                    }
        //                    #endregion

        //                    #region Master File Type Check
        //                    //Upload File Type
        //                    extensionPhotoIdentityDocument = Path.GetExtension(PhotoIdentityDocument.FileName);
        //                    switch (extensionPhotoIdentityDocument)
        //                    {
        //                        case ".JPEG":
        //                        case ".jpeg":
        //                        case ".JPG":
        //                        case ".jpg":
        //                        case ".PNG":
        //                        case ".png":
        //                            {
        //                                //Image Type
        //                                extensionPutPhotoIdentityDocument = 102;
        //                                break;
        //                            }
        //                        case ".PDF":
        //                        case ".pdf":
        //                            {
        //                                //PDF Type
        //                                extensionPutPhotoIdentityDocument = 103;
        //                                break;
        //                            }
        //                    }

        //                    //Master File Type
        //                    masterGetPhotoIdentityDocument = Convert.ToString(clsprp.PromoterDoc_SetFileFormat);
        //                    switch (masterGetPhotoIdentityDocument)
        //                    {
        //                        case "JPEG/JPG/PDF":
        //                            {
        //                                //Both Image and PDF Type
        //                                masterPutPhotoIdentityDocument = 101;
        //                                break;
        //                            }
        //                        case "JPEG/JPG":
        //                        case "JPEG":
        //                        case "JPG":
        //                            {
        //                                //Image Type
        //                                masterPutPhotoIdentityDocument = 102;
        //                                break;
        //                            }
        //                        case "PDF":
        //                            {
        //                                //PDF Type
        //                                masterPutPhotoIdentityDocument = 103;
        //                                break;
        //                            }
        //                    }
        //                    if (masterPutPhotoIdentityDocument == 101)
        //                    {
        //                        if (extensionPutPhotoIdentityDocument == 102 || extensionPutPhotoIdentityDocument == 103)
        //                        {
        //                            IsValidFileType = true;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (extensionPutPhotoIdentityDocument == masterPutPhotoIdentityDocument)
        //                        {
        //                            IsValidFileType = true;
        //                        }
        //                    }
        //                    #endregion

        //                    //Check Number of Files Uploaded
        //                    if (tupleSumCntFile.Item2 < Convert.ToInt32(clsprp.IsGroup))
        //                    {
        //                        //if ((extensionPhotoIdentityDocument == ".JPG") || (extensionPhotoIdentityDocument == ".jpg") || (extensionPhotoIdentityDocument == ".jpeg") || (extensionPhotoIdentityDocument == ".gif") || (extensionPhotoIdentityDocument == ".png")) //))//
        //                        if (IsValidFileType)
        //                        {
        //                            if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.PromoterDoc_SetFileSize))
        //                            {
        //                                byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

        //                                if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.PromoterDoc_SetFileSize))
        //                                {
        //                                    savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.PromoterDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
        //                                    var pathsavefile = Path.Combine(path, savefileName);
        //                                    PhotoIdentityDocument.SaveAs(pathsavefile);

        //                                    var pathsavedb = Path.Combine(pathindb, savefileName);

        //                                    Int64 inPromoter_ID = PromoterId;
        //                                    string inPromoterDoc_FilePath = pathsavedb;
        //                                    string inPromoterDoc_FileName = savefileName;
        //                                    string inPromoterDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
        //                                    string inPromoterDoc_FileFormat = extensionPhotoIdentityDocument;
        //                                    Int32 inPromoterDoc_IsGroup = Convert.ToInt32(clsprp.IsMandatory);

        //                                    bool varRet = SavePromoterDocument(smodel, inPromoter_ID, inPromoterDoc_FilePath, inPromoterDoc_FileName, inPromoterDoc_FileSize, inPromoterDoc_FileFormat, inPromoterDoc_IsGroup);

        //                                    if (varRet != false)
        //                                    {
        //                                        return Json(new
        //                                        {
        //                                            //Data = "Complete",
        //                                            statusCode = 101,
        //                                            status = "Complete",
        //                                            remarks = "Successfully uplaoded"
        //                                        }, JsonRequestBehavior.AllowGet);
        //                                    }
        //                                    else
        //                                    {
        //                                        return Json(new
        //                                        {
        //                                            //Data = "Bad Request! Upload Failed",
        //                                            statusCode = 105,
        //                                            status = "Bad Request! Upload Failed",
        //                                            remarks = "Not Saved! Upload Failed "
        //                                        }, JsonRequestBehavior.AllowGet);
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    decimal varSetFileSize = 0;
        //                                    string varOutSetFileSize = string.Empty;
        //                                    varSetFileSize = Convert.ToInt32(clsprp.PromoterDoc_SetFileSize);

        //                                    if (varSetFileSize > 1048576)
        //                                    {
        //                                        varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1048576) / 100 + " MB";
        //                                    }
        //                                    else if (varSetFileSize > 1024)
        //                                    {
        //                                        varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1024) / 100 + " KB";
        //                                    }
        //                                    else
        //                                    {
        //                                        varOutSetFileSize = varSetFileSize + " Bytes";
        //                                    }

        //                                    return Json(new
        //                                    {
        //                                        //Data = "Size less, File Name: " + uploadedFile.FileName,
        //                                        statusCode = 103,
        //                                        status = "File size should be less than " + varOutSetFileSize,
        //                                        remarks = uploadedFile.FileName
        //                                    }, JsonRequestBehavior.AllowGet);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                decimal varSetGroupFileSize = 0;
        //                                string varOutSetGroupFileSize = string.Empty;

        //                                varSetGroupFileSize = Convert.ToInt64(tupleSumCntFile.Item1);

        //                                if (varSetGroupFileSize > 1048576)
        //                                {
        //                                    varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1048576) / 100 + " MB";
        //                                }
        //                                else if (varSetGroupFileSize > 1024)
        //                                {
        //                                    varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1024) / 100 + " KB";
        //                                }
        //                                else
        //                                {
        //                                    varOutSetGroupFileSize = varSetGroupFileSize + " Bytes";
        //                                }


        //                                return Json(new
        //                                {
        //                                    //Data = "Size less, File Name: " + uploadedFile.FileName,
        //                                    statusCode = 107,
        //                                    status = "Maximum number of uploaded files size limit reached.",
        //                                    remarks = uploadedFile.FileName
        //                                }, JsonRequestBehavior.AllowGet);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            return Json(new
        //                            {
        //                                //Data = "Format not match, File Name: " + uploadedFile.FileName,
        //                                statusCode = 104,
        //                                status = "File format not matched.",
        //                                remarks = uploadedFile.FileName
        //                            }, JsonRequestBehavior.AllowGet);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return Json(new
        //                        {
        //                            //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
        //                            statusCode = 106,
        //                            status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(clsprp.IsGroup) + " files.)",
        //                            remarks = uploadedFile.FileName
        //                        }, JsonRequestBehavior.AllowGet);
        //                    }
        //                }
        //                else
        //                {
        //                    return Json(new
        //                    {
        //                        //Data = "Bad Request! Upload Failed",
        //                        statusCode = 102,
        //                        status = "Bad Request! Upload Failed",
        //                        remarks = string.Empty
        //                    }, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                return Json(new
        //                {
        //                    //Data = "Bad Request! Upload Failed",
        //                    statusCode = 102,
        //                    status = "Bad Request! Upload Failed",
        //                    remarks = string.Empty
        //                }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new
        //            {
        //                //Data = "Bad Request! Upload Failed",
        //                statusCode = 102,
        //                status = "Mandatory field(s) required! Upload Failed",
        //                remarks = string.Empty
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(new
        //        {
        //            //Data = "Bad Request! Upload Failed",
        //            statusCode = 102,
        //            status = "Bad Request! Upload Failed",
        //            remarks = string.Empty
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}





        /////////////                   AI Addition on document upload           //////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> FormUpload(HttpPostedFileBase uploadedFile, Clsprp_Promoter_Documents smodel) //JsonResult ActionResult
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Promoter_Documents clsprp = new Clsprp_Master_Promoter_Documents();
                    ClsMethod_Master_Promoter_Documents objdoc = new ClsMethod_Master_Promoter_Documents();
                    Clsprp_Promoter_Documents clsprpPrmDoc = new Clsprp_Promoter_Documents();
                    ClsMethod_Promoter_Documents objPromoterDoc = new ClsMethod_Promoter_Documents();

                    string expectedDocName = Request["SelectedDocumentName"];
                    Int32 IndexId = smodel.PromoterDoc_InfoCode;
                    Int64 PromoterId = 0;
                    Int64 Application_id = 0;
                    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                    {
                        if (Session["ApplicationId"].ToString() != "0")
                        {
                            Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        }
                    }
                    PromoterId = Application_id;
                    //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_Documents();

                    #region Read Master Data By Document Type
                    clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_DocumentsByPromoterID(PromoterId);

                    Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_Promoter_Documents_ByDocCodeInfoPromoterID(PromoterId, IndexId));

                    //clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Promoter_Documents(IndexId);

                    foreach (var item in clsprpPrmDoc.MasterDocs)
                    {
                        if (item.PromoterDocMaster_InfoCode == IndexId)
                        {
                            clsprp.PromoterDocMaster_IndexID = item.PromoterDocMaster_IndexID;
                            clsprp.PromoterDocMaster_InfoCode = item.PromoterDocMaster_InfoCode;
                            clsprp.PromoterDocMaster_InfoName = item.PromoterDocMaster_InfoName;
                            clsprp.PromoterDoc_SetFileSize = item.PromoterDoc_SetFileSize;
                            clsprp.PromoterDoc_SetFileFormat = item.PromoterDoc_SetFileFormat;
                            clsprp.PromoterDoc_SetFilePath = item.PromoterDoc_SetFilePath;
                            clsprp.PromoterDoc_ValidCode = item.PromoterDoc_ValidCode;
                            clsprp.PromoterDoc_ValidSubCode = item.PromoterDoc_ValidSubCode;
                            clsprp.PromoterDoc_ValidTinySubCode = item.PromoterDoc_ValidTinySubCode;
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
                    string masterPromoterDoc_SetFilePath = "readwritePromoter";
                    bool IsValidFileType = false;
                    #endregion

                    //Bad Request - No Doc
                    if (Request.Files.Count > 0)
                    {
                        var PhotoIdentityDocument = Request.Files[0];

                        //Bad Request - No Doc OR No Size
                        if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                        {
                            //byte[] fileBytes;
                            //using (var ms = new MemoryStream())
                            //{
                            //    PhotoIdentityDocument.InputStream.Position = 0;
                            //    PhotoIdentityDocument.InputStream.CopyTo(ms);
                            //    fileBytes = ms.ToArray();
                            //}
                            byte[] fileBytes;
                            string mimeType = string.Empty;
                            string extension = Path.GetExtension(PhotoIdentityDocument.FileName).ToLowerInvariant();

                            using (var ms = new MemoryStream())
                            {
                                PhotoIdentityDocument.InputStream.Position = 0;
                                PhotoIdentityDocument.InputStream.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }

                            // Detect MIME type
                            switch (extension)
                            {
                                case ".jpg":
                                case ".jpeg":
                                case ".png":
                                    mimeType = "image/jpeg";
                                    break;
                                case ".pdf":
                                    mimeType = "application/pdf";
                                    break;
                                default:
                                    mimeType = "application/octet-stream";
                                    break;
                            }

                            // Convert PDF to image if needed
                            if (extension == ".pdf")
                            {
                                try
                                {
                                    using (var pdfStream = new MemoryStream(fileBytes))
                                    {
                                        var document = new Document(pdfStream);
                                        var page = document.Pages[0];

                                        var renderingSettings = new RenderingSettings();
                                        using (var bitmap = page.Render(150, 150, renderingSettings))
                                        {
                                            using (var msOut = new MemoryStream())
                                            {
                                                bitmap.Save(msOut, System.Drawing.Imaging.ImageFormat.Jpeg);
                                                fileBytes = msOut.ToArray();
                                                mimeType = "image/jpeg";
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    return Json(new
                                    {
                                        statusCode = 109,
                                        status = "PDF conversion failed",
                                        remarks = ex.Message
                                    }, JsonRequestBehavior.AllowGet);
                                }
                            }

                                var verdict = await OpenAiVision.ClassifyDocumentAsync(fileBytes, "image/jpeg", expectedDocName);

                            if (!(verdict.IsMatch && verdict.Confidence >= 0.60))
                            {
                                return Json(new
                                {
                                    statusCode = 108,
                                    status = $"Uploaded document does not match the selected type ({expectedDocName}), reason-{verdict.Reason}.",
                                    remarks = $"AI reason: {verdict.Reason}"
                                }, JsonRequestBehavior.AllowGet);
                            }

                            #region SaveFile Path Creation
                            if (clsprp.PromoterDoc_SetFilePath.ToString() != string.Empty || clsprp.PromoterDoc_SetFilePath.ToString() != null)
                            {
                                masterPromoterDoc_SetFilePath = clsprp.PromoterDoc_SetFilePath.ToString();
                            }
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(PromoterId) + "\\";
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
                            masterGetPhotoIdentityDocument = Convert.ToString(clsprp.PromoterDoc_SetFileFormat);
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
                                    if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.PromoterDoc_SetFileSize))
                                    {
                                        byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                        if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.PromoterDoc_SetFileSize))
                                        {
                                            savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.PromoterDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                            var pathsavefile = Path.Combine(path, savefileName);
                                            PhotoIdentityDocument.SaveAs(pathsavefile);

                                            var pathsavedb = Path.Combine(pathindb, savefileName);

                                            Int64 inPromoter_ID = PromoterId;
                                            string inPromoterDoc_FilePath = pathsavedb;
                                            string inPromoterDoc_FileName = savefileName;
                                            string inPromoterDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inPromoterDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inPromoterDoc_IsGroup = Convert.ToInt32(clsprp.IsMandatory);

                                            bool varRet = SavePromoterDocument(smodel, inPromoter_ID, inPromoterDoc_FilePath, inPromoterDoc_FileName, inPromoterDoc_FileSize, inPromoterDoc_FileFormat, inPromoterDoc_IsGroup);

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
                                            varSetFileSize = Convert.ToInt32(clsprp.PromoterDoc_SetFileSize);

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
                                            status = "Maximum number of uploaded files size limit reached.",
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

        private bool SavePromoterDocument(Clsprp_Promoter_Documents smodel, Int64 z_Promoter_ID, String z_PromoterDoc_FilePath, String z_PromoterDoc_FileName, String z_PromoterDoc_FileSize, String z_PromoterDoc_FileFormat, Int32 z_PromoterDoc_IsGroup)
        {
            Int64 Promoter_ID = 0;
            Promoter_ID = z_Promoter_ID;
            string PromoterDoc_FilePath = String.IsNullOrEmpty(z_PromoterDoc_FilePath) ? string.Empty : z_PromoterDoc_FilePath;
            string PromoterDoc_FileName = String.IsNullOrEmpty(z_PromoterDoc_FileName) ? string.Empty : z_PromoterDoc_FileName;
            string PromoterDoc_FileSize = String.IsNullOrEmpty(z_PromoterDoc_FileSize) ? string.Empty : z_PromoterDoc_FileSize;
            string PromoterDoc_FileFormat = String.IsNullOrEmpty(z_PromoterDoc_FileFormat) ? string.Empty : z_PromoterDoc_FileFormat;
            Int32 PromoterDoc_IsGroup = z_PromoterDoc_IsGroup;
            bool varRET = false;

            ////if (Session["Project_id"] != null)
            ////{
            ////    Promoter_ID = Convert.ToInt64(Session["Project_id"].ToString());
            ////    smodel.Promoter_ID = Promoter_ID;
            ////}
            ////else
            ////{
            ////    RedirectToAction("IndexPromoter", "Home");
            ////}

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Promoter_Documents savedb = new ClsMethod_Promoter_Documents();
                    if (savedb.Add_Promoter_Documents(smodel, Promoter_ID, PromoterDoc_FilePath, PromoterDoc_FileName, PromoterDoc_FileSize, PromoterDoc_FileFormat, PromoterDoc_IsGroup))
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

        //Get Document Information As Json
        public JsonResult GetPromoterDocumentMasterByDocId(string DocId)
        {
            int Id = 0;
            if (DocId != "")
                Id = Convert.ToInt32(DocId);
                        
            ClsMethod_Master_Promoter_Documents objDoc = new ClsMethod_Master_Promoter_Documents();
            var Subdiv = objDoc.Display_Master_Promoter_Documents(Id);

            return Json(Subdiv);
        }


        //Get Document Uploaded List As Json
        public string GetPromoterDocumentUploadedList_ByPromoterId(string parmPromoterId)
        {
            long Id = 0;
            if (parmPromoterId != "")
                Id = Convert.ToInt64(parmPromoterId);
            
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            Id = Application_id;


            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id") });

            try
            {
                ClsMethod_Promoter_Documents objDoc = new ClsMethod_Promoter_Documents();
                List<Clsprp_Promoter_DocumentsUploadedList> objgetprp = new List<Clsprp_Promoter_DocumentsUploadedList>();
                objgetprp = objDoc.Display_Promoter_DocumentsUploadedList_PromoterId(Id);

                if (objgetprp.Count > 0)
                {
                    foreach (Clsprp_Promoter_DocumentsUploadedList a in objgetprp)
                    {
                        dt.Rows.Add(a.PromoterDoc_InfoCode);
                    }
                }
                else
                {
                    dt.Rows.Add(0);
                }
            }
            catch (Exception ex)
            {
                string varEx = ex.ToString();
                dt.Rows.Add(0);
            }

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return serializer.Serialize(rows);
        }


        //GET: Delete
        public ActionResult Delete_PromoterDoc(Int64? inPromoterDoc_IndexID, Int64? inPromoterDoc_ID, Int64? inPromoter_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Promoter_Documents sdb = new ClsMethod_Promoter_Documents();
                if (sdb.Delete_Promoter_Documents(inPromoterDoc_IndexID, inPromoterDoc_ID, inPromoter_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("PromoterDoc");
            }
            catch
            {
                return RedirectToAction("PromoterDoc");
            }
        }
        #region
        /// <summary>
        /// To check the isdraft value to disable the save /submit button
        /// </summary>
        public void Get_Isdraftvalue_FromDiaryNumber(Int64 Application_id)
        {
            //Int64 Project_id = 0;
            //Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  disable save button
            /// </summary>
            /// <returns></returns>


            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Application_id);
            TempData["PromoterIsdraftValue"] = IsdraftValue;

            //return View("AgentView");
            //return RedirectToAction("AgentView");




            #endregion

        }

        #endregion
    }
}