using CRUD.Models.Document;
using CRUD.Models.HelpDesk;
using CRUD.Models.HelpDeskAgent;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using CRUD.Models.HelpdeskComplaint;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;
using CRUD.Models.HelpdeskAdmin;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;


using PdfiumViewer;
using Tesseract;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace CRUD.Controllers.HelpdeskAdmin
{
    [Authorize]
    [Authorize(Roles = "SecretaryRERA, Programmer, Authority, ManagerDesk, PStoMembers, LegalAdvisorDesk")]
    public class HelpdeskAdminController : Controller
    {

        #region member Facts and Figure

        // Get: Display 
        [HttpGet]
        public ActionResult WebindexInfoFactsFigureDetails()
        {
            ClsPrp_AdminDesk_FactsFigure objprp = new ClsPrp_AdminDesk_FactsFigure();
            ClsMethod_AdminDesk_FactsFigure sdb = new ClsMethod_AdminDesk_FactsFigure();
            Int64 pIndex_ID = 0;
            objprp.prpFactsFigure = sdb.Display_AdminDesk_FactsFigureDetails(pIndex_ID);
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoFactsFigureDetails", objprp);
        }

        // Post: Save 
        [HttpPost]
        public ActionResult WebindexInfoFactsFigureDetails(ClsPrp_AdminDesk_FactsFigure smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_FactsFigure sdb = new ClsMethod_AdminDesk_FactsFigure();
                    if (sdb.Add_AdminDesk_FactsFigureDetails(smodel, UserNam))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("WebindexInfoFactsFigureDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        // Get: Update 
        [HttpGet]
        public ActionResult Edit_windexInfoFactsFigureDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_FactsFigure objprp = new ClsPrp_AdminDesk_FactsFigure();
            ClsMethod_AdminDesk_FactsFigure sdb = new ClsMethod_AdminDesk_FactsFigure();

            objprp.prpFactsFigure = sdb.Display_AdminDesk_FactsFigureDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpFactsFigure)
            {
                objprp.FactsFigure_IndexID = item.FactsFigure_IndexID;
                objprp.FactsFigure_ID = item.FactsFigure_ID;
                objprp.FactsFigure_LanguageFlag = item.FactsFigure_LanguageFlag;

                objprp.Number_RegisteredProjects = item.Number_RegisteredProjects;
                objprp.Number_RegisteredAgents = item.Number_RegisteredAgents;
                objprp.Number_DisposedComplaints = item.Number_DisposedComplaints;
                objprp.Number_PendingProjects = item.Number_PendingProjects;

                objprp.Title_RegisteredProjects = item.Title_RegisteredProjects;
                objprp.Title_RegisteredAgents = item.Title_RegisteredAgents;
                objprp.Title_DisposedComplaints = item.Title_DisposedComplaints;
                objprp.Title_PendingProjects = item.Title_PendingProjects;
                objprp.CulturePunjabi_Title_RegisteredProjects = item.CulturePunjabi_Title_RegisteredProjects;
                objprp.CulturePunjabi_Title_RegisteredAgents = item.CulturePunjabi_Title_RegisteredAgents;
                objprp.CulturePunjabi_Title_DisposedComplaints = item.CulturePunjabi_Title_DisposedComplaints;
                objprp.CulturePunjabi_Title_PendingProjects = item.CulturePunjabi_Title_PendingProjects;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.IsActive = item.IsActive;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("WebindexInfoFactsFigureDetails", objprp);
        }

        // Post: Update 
        [HttpPost]
        public ActionResult Edit_windexInfoFactsFigureDetails(ClsPrp_AdminDesk_FactsFigure smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_FactsFigure sdb = new ClsMethod_AdminDesk_FactsFigure();
                    sdb.Update_AdminDesk_FactsFigureDetails(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("WebindexInfoFactsFigureDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        // Get: Delete 
        public ActionResult Delete_windexInfoFactsFigureDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_FactsFigure sdb = new ClsMethod_AdminDesk_FactsFigure();
                if (sdb.Delete_AdminDesk_FactsFigureDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoFactsFigureDetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region member SpotLight

        [HttpGet]
        public ActionResult WebindexInfoSpotLightDetails()
        {
            ClsPrp_AdminDesk_SpotLight objprp = new ClsPrp_AdminDesk_SpotLight();
            ClsMethod_AdminDesk_SpotLight sdb = new ClsMethod_AdminDesk_SpotLight();

            Int64 pIndex_ID = 0;
            objprp.prpSpotLight = sdb.Display_AdminDesk_SpotLightDetails(pIndex_ID);
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoSpotLightDetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexInfoSpotLightDetails(ClsPrp_AdminDesk_SpotLight smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_SpotLight sdb = new ClsMethod_AdminDesk_SpotLight();
                    if (sdb.Add_AdminDesk_SpotLightDetails(smodel, UserNam))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("WebindexInfoSpotLightDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit_windexInfoSpotLightDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_SpotLight objprp = new ClsPrp_AdminDesk_SpotLight();
            ClsMethod_AdminDesk_SpotLight sdb = new ClsMethod_AdminDesk_SpotLight();

            objprp.prpSpotLight = sdb.Display_AdminDesk_SpotLightDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpSpotLight)
            {
                objprp.SpotLight_IndexID = item.SpotLight_IndexID;
                objprp.SpotLight_ID = item.SpotLight_ID;
                objprp.SpotLight_LanguageFlag = item.SpotLight_LanguageFlag;
                objprp.SpotLight_PriorityFlag = item.SpotLight_PriorityFlag;
                objprp.SpotLight_IssueDate = item.SpotLight_IssueDate;
                objprp.SpotLight_ReferenceNumber = item.SpotLight_ReferenceNumber;
                objprp.SpotLight_Category = item.SpotLight_Category;
                objprp.SpotLight_Title = item.SpotLight_Title;
                objprp.CulturePunjabi_SpotLight_Category = item.CulturePunjabi_SpotLight_Category;
                objprp.CulturePunjabi_SpotLight_Title = item.CulturePunjabi_SpotLight_Title;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.IsActive = item.IsActive;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("WebindexInfoSpotLightDetails", objprp);
        }

        [HttpPost]
        public ActionResult Edit_windexInfoSpotLightDetails(ClsPrp_AdminDesk_SpotLight smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_SpotLight sdb = new ClsMethod_AdminDesk_SpotLight();
                    sdb.Update_AdminDesk_SpotLightDetails(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("WebindexInfoSpotLightDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        public ActionResult Delete_windexInfoSpotLightDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_SpotLight sdb = new ClsMethod_AdminDesk_SpotLight();
                if (sdb.Delete_AdminDesk_SpotLightDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoSpotLightDetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region member Latest News
        [HttpGet]
        public ActionResult WebindexInfoLatestNewsDetails()
        {
            ClsPrp_AdminDesk_LatestNews objprp = new ClsPrp_AdminDesk_LatestNews();
            ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();

            Int64 pIndex_ID = 0;
            objprp.prpLatestNews = sdb.Display_AdminDesk_latestnewsDetails(pIndex_ID);
            TempData["submitvalueInfoLatestNews"] = "Save"; TempData.Keep();
            return View("WebindexInfoLatestNewsDetails", objprp);
        }

        [HttpGet]
        public ActionResult Edit_windexInfoLatestNewsDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_LatestNews objprp = new ClsPrp_AdminDesk_LatestNews();
            ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();

            objprp.prpLatestNews = sdb.Display_AdminDesk_latestnewsDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpLatestNews)
            {
                objprp.LatestNews_IndexID = item.LatestNews_IndexID;
                objprp.LatestNews_ID = item.LatestNews_ID;

                objprp.LatestNews_LanguageFlag = item.LatestNews_LanguageFlag;
                objprp.LatestNews_PriorityFlag = item.LatestNews_PriorityFlag;
                objprp.LatestNews_IssueDate = item.LatestNews_IssueDate;
                objprp.LatestNews_ReferenceNumber = item.LatestNews_ReferenceNumber;

                objprp.LatestNews_Category = item.LatestNews_Category;
                objprp.LatestNews_Title = item.LatestNews_Title;
                objprp.LatestNews_Description = item.LatestNews_Description;
                objprp.LatestNews_RelatedTo_IfAny = item.LatestNews_RelatedTo_IfAny;

                objprp.CulturePunjabi_LatestNews_Category = item.CulturePunjabi_LatestNews_Category;
                objprp.CulturePunjabi_LatestNews_Title = item.CulturePunjabi_LatestNews_Title;
                objprp.CulturePunjabi_LatestNews_Description = item.CulturePunjabi_LatestNews_Description;
                objprp.CulturePunjabi_LatestNews_RelatedTo_IfAny = item.CulturePunjabi_LatestNews_RelatedTo_IfAny;

                objprp.IsHyperlinkorFileDirectoryPath = item.IsHyperlinkorFileDirectoryPath;
                objprp.LatestNews_BaseUrl = item.LatestNews_BaseUrl;
                objprp.LatestNews_Url = item.LatestNews_Url;
                objprp.LatestNews_ExtraUrl = item.LatestNews_ExtraUrl;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.IsActive = item.IsActive;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueInfoLatestNews"] = "Update";
            TempData.Keep();
            return View("WebindexInfoLatestNewsDetails", objprp);
        }

        public ActionResult Delete_windexInfoLatestNewsDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();
                if (sdb.Delete_AdminDesk_latestnewsDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoLatestNewsDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WebindexInfoLatestNewsDetails(ClsPrp_AdminDesk_LatestNews smodel)
        {
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            // File Upload (save or update PDF file)
            if (smodel.IsHyperlinkorFileDirectoryPath == 0)
            {
                //Save & Update
                #region
                if (TempData["submitvalueInfoLatestNews"].ToString() == "Update")
                {
                    #region Document Update with Path
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                    {
                        var files = Request.Files[0];
                        var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                        ext = Path.GetExtension(files.FileName);
                        if (allowedExtensions.Contains(ext))
                        {
                            int size = files.ContentLength;
                            if (size <= 2048000) // 1MB
                            {

                                #region Declare Variables
                                var pathwebapplicationdata = string.Empty;
                                var pathindb = string.Empty;
                                string webapplicationDoc_SetFilePath = "rwPDF/LatestNews";
                                string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                                FileName_BasicUrl = "~/"; // Server Config Basic Url
                                #endregion

                                #region UpdateFile Path Creation 
                                if (!String.IsNullOrEmpty(smodel.LatestNews_Url))
                                {
                                    pathindb = smodel.LatestNews_Url.ToString();
                                }
                                else
                                {
                                    pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                                }
                                pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                                if (!Directory.Exists(pathwebapplicationdata))
                                {
                                    Directory.CreateDirectory(pathwebapplicationdata);
                                }
                                #endregion

                                var fileName = string.Empty;
                                if (!String.IsNullOrEmpty(smodel.LatestNews_ExtraUrl))
                                {
                                    fileName = smodel.LatestNews_ExtraUrl.ToString();
                                }
                                else
                                {
                                    fileName = SaveFileDatePrefix() + "LatestNews" + Guid.NewGuid().ToString() + ext;
                                }

                                var path = Path.Combine(pathwebapplicationdata, fileName);
                                files.SaveAs(path);
                                FileName_Address = fileName;
                                FileName_Path = pathindb;
                                FileName_Ext = ext;
                            }
                            else
                            {
                                TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                                error = "Document size should be less than 2MB (Two MB).";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                            error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid upload document.";
                        error = "Bad request! Invalid upload document.";
                        errorstate = 1;

                        //update with same document
                        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                        {
                            errorstate = 0;
                        }

                    }
                    #endregion
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.LatestNews_ExtraUrl; //file name
                                // FileName_Ext = smodel.ViewJugdement_FileType; //file type
                                FileName_Path = smodel.LatestNews_Url; //file path
                                FileName_BasicUrl = smodel.LatestNews_BaseUrl; //basic url
                            }
                            try
                            {
                                ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();
                                sdb.Update_AdminDesk_latestnewsDetails(smodel, FileName_BasicUrl, FileName_Path, FileName_Address, UserNam);
                                TempData["message"] = "Details updated successfully";
                            }
                            catch (Exception ex)
                            {
                                string strRet = ex.ToString();
                                TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                                return View();
                            }
                        }
                        return RedirectToAction("WebindexInfoLatestNewsDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoLatestNewsDetails");
                    }
                }
                else
                {
                    #region PhotoCertificate Save with Path
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                    {
                        var files = Request.Files[0];
                        var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                        ext = Path.GetExtension(files.FileName);
                        if (allowedExtensions.Contains(ext))
                        {
                            int size = files.ContentLength;
                            if (size <= 2048000)
                            {

                                #region Declare Variables
                                var pathwebapplicationdata = string.Empty;
                                var pathindb = string.Empty;
                                string webapplicationDoc_SetFilePath = "rwPDF/LatestNews";
                                string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                                FileName_BasicUrl = "~/"; // Server Config Basic Url
                                #endregion

                                #region SaveFile Path Creation
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                                pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                                if (!Directory.Exists(pathwebapplicationdata))
                                {
                                    Directory.CreateDirectory(pathwebapplicationdata);
                                }
                                #endregion

                                var fileName = string.Empty;
                                fileName = SaveFileDatePrefix() + "LatestNews" + Guid.NewGuid().ToString() + ext;

                                var path = Path.Combine(pathwebapplicationdata, fileName);
                                files.SaveAs(path);
                                FileName_Address = fileName;
                                FileName_Path = pathindb;
                                FileName_Ext = ext;
                            }
                            else
                            {
                                TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                                error = "Document size should be less than 2MB (Two MB).";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                            error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid upload document.";
                        error = "Bad request! Invalid upload document.";
                        errorstate = 1;
                    }
                    #endregion
                    try
                    {
                        if (errorstate == 0)
                        {
                            if (ModelState.IsValid)
                            {
                                if (FileName_Address == string.Empty)
                                {
                                    FileName_Address = smodel.LatestNews_ExtraUrl; //file name
                                                                                   // FileName_Ext = smodel.ViewJugdement_FileType; //file type
                                    FileName_Path = smodel.LatestNews_Url; //file path
                                    FileName_BasicUrl = smodel.LatestNews_BaseUrl; //basic url
                                }
                                ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();
                                if (sdb.Add_AdminDesk_latestnewsDetails(smodel, FileName_BasicUrl, FileName_Path, FileName_Address, UserNam))
                                {
                                    TempData["message"] = " Details Added Successfully";
                                    ModelState.Clear();
                                }
                            }
                            return RedirectToAction("WebindexInfoLatestNewsDetails");
                        }
                        else
                        {
                            return RedirectToAction("WebindexInfoLatestNewsDetails");
                        }
                    }
                    catch (Exception ex)
                    {
                        string strRet = ex.ToString();
                        TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                        return View();
                    }
                }
                #endregion
            }
            // Save or update Path Hyperlink 
            else
            {
                if (TempData["submitvalueInfoLatestNews"].ToString() == "Update")
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();
                            sdb.Update_AdminDesk_latestnewsByLinkDetails(smodel, UserNam);
                            TempData["message"] = "Record Updated Successfully!";
                        }
                        return RedirectToAction("WebindexInfoLatestNewsDetails");
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        TempData["message"] = "Bad Request, Try Again!";
                        return View();
                    }
                }
                else
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            ClsMethod_AdminDesk_LatestNews sdb = new ClsMethod_AdminDesk_LatestNews();
                            if (sdb.Add_AdminDesk_latestnewsByLinkDetails(smodel, UserNam))
                            {
                                TempData["message"] = "Record Inserted Successfully!";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoLatestNewsDetails");
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        TempData["message"] = "Bad Request, Try Again!";
                        return View();
                    }
                }
            }
            //TempData["message"] = "Bad request! Invalid updation.";
            //return View();
        }
        #endregion


        #region member OrderJugdement ByAO
        [HttpGet]
        public ActionResult WebindexInfoOrderJudgementByAODetails()
        {
            ClsPrp_AdminDesk_OrderJudgementByAO objprp = new ClsPrp_AdminDesk_OrderJudgementByAO();
            ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();

            Int64 pIndex_ID = 0;
            objprp.prpOrderJudgementByAO = sdb.Display_AdminDesk_OrderJudgementByAODetails(pIndex_ID);
            TempData["submitvalueOJByAO"] = "Save"; TempData.Keep();
            return View("WebindexInfoOrderJudgementByAODetails", objprp);
        }

        [HttpGet]
        public ActionResult Edit_windexInfoOrderJudgementByAODetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_OrderJudgementByAO objprp = new ClsPrp_AdminDesk_OrderJudgementByAO();
            ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();

            objprp.prpOrderJudgementByAO = sdb.Display_AdminDesk_OrderJudgementByAODetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpOrderJudgementByAO)
            {
                objprp.OrderJudgementByAO_IndexID = item.OrderJudgementByAO_IndexID;
                objprp.OrderJudgementByAO_ID = item.OrderJudgementByAO_ID;

                objprp.SerialOrderNumber = item.SerialOrderNumber;
                objprp.ApplicationNumber = item.ApplicationNumber;
                objprp.ApplicantName = item.ApplicantName;
                objprp.RespondentName = item.RespondentName;
                objprp.Date_of_Decision = item.Date_of_Decision;

                objprp.ViewJugdementAO_BaseUrl = item.ViewJugdementAO_BaseUrl;
                objprp.ViewJugdementAO_FilePath = item.ViewJugdementAO_FilePath;
                objprp.ViewJugdementAO_FileName = item.ViewJugdementAO_FileName;
                objprp.ViewJugdementAO_FileType = item.ViewJugdementAO_FileType;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueOJByAO"] = "Update";
            TempData.Keep();
            return View("WebindexInfoOrderJudgementByAODetails", objprp);
        }

        public ActionResult Delete_windexInfoOrderJudgementByAODetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();
                if (sdb.Delete_AdminDesk_OrderJudgementByAODetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoOrderJudgementByAODetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WebindexInfoOrderJudgementByAODetails(ClsPrp_AdminDesk_OrderJudgementByAO smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueOJByAO"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersJudgementsByAO";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ViewJugdementAO_FilePath))
                            {
                                pathindb = smodel.ViewJugdementAO_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ViewJugdementAO_FileName))
                            {
                                fileName = smodel.ViewJugdementAO_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "OJbyAO" + Guid.NewGuid().ToString() + ext; //+ smodel.ViewJugdementAO_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.ViewJugdementAO_FileName;
                            FileName_Ext = smodel.ViewJugdementAO_FileType;
                            FileName_Path = smodel.ViewJugdementAO_FilePath;
                            FileName_BasicUrl = smodel.ViewJugdementAO_BaseUrl;
                        }
                        try
                        {
                            ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();
                            sdb.Update_AdminDesk_OrderJudgementByAODetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexInfoOrderJudgementByAODetails");
                }
                else
                {
                    return RedirectToAction("WebindexInfoOrderJudgementByAODetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersJudgementsByAO";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "OJbyAO" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.ViewJugdementAO_FileName;
                                FileName_Ext = smodel.ViewJugdementAO_FileType;
                                FileName_Path = smodel.ViewJugdementAO_FilePath;
                                FileName_BasicUrl = smodel.ViewJugdementAO_BaseUrl;
                            }
                            ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();
                            if (sdb.Add_AdminDesk_OrderJudgementByAODetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoOrderJudgementByAODetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoOrderJudgementByAODetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }
        #endregion


        #region member OrderJugdement ByAuthority
        [HttpGet]
        public ActionResult WebindexInfoOrderJudgementByAuthorityDetails()
        {
            ClsPrp_AdminDesk_OrderJudgementByAuthority objprp = new ClsPrp_AdminDesk_OrderJudgementByAuthority();
            ClsMethod_AdminDesk_OrderJudgementByAuthority sdb = new ClsMethod_AdminDesk_OrderJudgementByAuthority();

            Int64 pIndex_ID = 0;
            objprp.prpOrderJudgementByAuthority = sdb.Display_AdminDesk_OrderJudgementByAuthorityDetails(pIndex_ID);
            TempData["submitvalueOJByAuthority"] = "Save"; TempData.Keep();
            return View("WebindexInfoOrderJudgementByAuthorityDetails", objprp);
        }

        [HttpGet]
        public ActionResult Edit_windexInfoOrderJudgementByAuthorityDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_OrderJudgementByAuthority objprp = new ClsPrp_AdminDesk_OrderJudgementByAuthority();
            ClsMethod_AdminDesk_OrderJudgementByAuthority sdb = new ClsMethod_AdminDesk_OrderJudgementByAuthority();

            objprp.prpOrderJudgementByAuthority = sdb.Display_AdminDesk_OrderJudgementByAuthorityDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpOrderJudgementByAuthority)
            {
                objprp.OrderJudgementByAuthority_IndexID = item.OrderJudgementByAuthority_IndexID;
                objprp.OrderJudgementByAuthority_ID = item.OrderJudgementByAuthority_ID;

                objprp.SerialOrderNumber = item.SerialOrderNumber;
                objprp.ComplaintNumber = item.ComplaintNumber;
                objprp.ComplainantName = item.ComplainantName;
                objprp.RespondentName = item.RespondentName;
                objprp.Date_of_Decision = item.Date_of_Decision;

                objprp.ViewJugdement_BaseUrl = item.ViewJugdement_BaseUrl;
                objprp.ViewJugdement_FilePath = item.ViewJugdement_FilePath;
                objprp.ViewJugdement_FileName = item.ViewJugdement_FileName;
                objprp.ViewJugdement_FileType = item.ViewJugdement_FileType;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueOJByAuthority"] = "Update";
            TempData.Keep();
            return View("WebindexInfoOrderJudgementByAuthorityDetails", objprp);
        }

        public ActionResult Delete_windexInfoOrderJudgementByAuthorityDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_OrderJudgementByAuthority sdb = new ClsMethod_AdminDesk_OrderJudgementByAuthority();
                if (sdb.Delete_AdminDesk_OrderJudgementByAuthorityDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoOrderJudgementByAuthorityDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WebindexInfoOrderJudgementByAuthorityDetails(ClsPrp_AdminDesk_OrderJudgementByAuthority smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueOJByAuthority"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersJudgements";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ViewJugdement_FilePath))
                            {
                                pathindb = smodel.ViewJugdement_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ViewJugdement_FileName))
                            {
                                fileName = smodel.ViewJugdement_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "OJbyAuth" + Guid.NewGuid().ToString() + ext; //+ smodel.ViewJugdement_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.ViewJugdement_FileName;
                            FileName_Ext = smodel.ViewJugdement_FileType;
                            FileName_Path = smodel.ViewJugdement_FilePath;
                            FileName_BasicUrl = smodel.ViewJugdement_BaseUrl;
                        }
                        try
                        {
                            ClsMethod_AdminDesk_OrderJudgementByAuthority sdb = new ClsMethod_AdminDesk_OrderJudgementByAuthority();
                            sdb.Update_AdminDesk_OrderJudgementByAuthorityDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexInfoOrderJudgementByAuthorityDetails");
                }
                else
                {
                    return RedirectToAction("WebindexInfoOrderJudgementByAuthorityDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersJudgements";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "OJbyAuth" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.ViewJugdement_FileName;
                                FileName_Ext = smodel.ViewJugdement_FileType;
                                FileName_Path = smodel.ViewJugdement_FilePath;
                                FileName_BasicUrl = smodel.ViewJugdement_BaseUrl;
                            }
                            ClsMethod_AdminDesk_OrderJudgementByAuthority sdb = new ClsMethod_AdminDesk_OrderJudgementByAuthority();
                            if (sdb.Add_AdminDesk_OrderJudgementByAuthorityDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoOrderJudgementByAuthorityDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoOrderJudgementByAuthorityDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }
        #endregion


        #region OrderJugdement ByAppellateTribunal

        [HttpGet]
        public ActionResult WebindexInfoOrderJudgementByATDetails()
        {
            ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal objprp = new ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            Int64 pIndex_ID = 0;
            objprp.prpongoing = sdb.Display_AdminDesk_OrderJudgementByATDetails(pIndex_ID);
            TempData["submitvalueOJByAT"] = "Save";
            TempData.Keep("submitvalueOJByAT");
            return View("WebindexInfoOrderJudgementByATDetails", objprp);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetBenchNames()
        {
            ClsMethod_AdminDesk_CircularPublicNotices objdis = new ClsMethod_AdminDesk_CircularPublicNotices();
            var benches = objdis.Display_Rera_TyeOfOrderDropdown();
            var result = benches.Where(b => b.IsActive == 1).Select(b => new
            {
                b.typeofOrder_ID,
                b.typeofOrderName
            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult WebindexInfoOrderJudgementByATDetails(ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            var data = TempData["submitvalueOJByAT"].ToString();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueOJByAT"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersJudgementsByAT";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.AppealOrderDoc_FilePath))
                            {
                                pathindb = smodel.AppealOrderDoc_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.AppealOrderDoc_FileName))
                            {
                                fileName = smodel.AppealOrderDoc_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "OJbyAT" + Guid.NewGuid().ToString() + ext; //+ smodel.ViewJugdementAO_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.AppealOrderDoc_FileName;
                            FileName_Ext = smodel.AppealOrderDoc_FileFormat;
                            FileName_Path = smodel.AppealOrderDoc_FilePath;
                            FileName_BasicUrl = smodel.ViewJugdement_BaseUrl;
                        }
                        try
                        {
                            smodel.ModifyOn = DateTime.Now;
                            smodel.CreatedOn = DateTime.Now;
                            smodel.User_ID = UID;
                            smodel.AppealOrderDoc_IssueDate = DateTime.Now;
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            sdb.Update_AdminDesk_OrderJudgementByATDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexInfoOrderJudgementByATDetails");
                }
                else
                {
                    return RedirectToAction("WebindexInfoOrderJudgementByATDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersJudgementsByAT";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "OJbyAT" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (!ModelState.IsValid)
                        {
                            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();
                        }
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.AppealOrderDoc_FileName;
                                FileName_Ext = smodel.AppealOrderDoc_FileFormat;
                                FileName_Path = smodel.AppealOrderDoc_FilePath;
                                FileName_BasicUrl = smodel.ViewJugdement_BaseUrl;
                            }
                            smodel.User_ID = UID;
                            smodel.AppealOrderDoc_IssueDate = DateTime.Now;
                            smodel.ModifyOn = DateTime.Now;
                            smodel.CreatedOn = DateTime.Now;
                            //ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            if (sdb.Add_AdminDesk_OrderJudgementByATDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoOrderJudgementByATDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoOrderJudgementByATDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }

        [HttpGet]
        public ActionResult Edit_windexInfoOrderJudgementByATDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal objprp = new ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            objprp.prpongoing = sdb.Display_AdminDesk_OrderJudgementByATDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpongoing)
            {
                objprp.AppellateTribunalOrder_IndexID = item.AppellateTribunalOrder_IndexID;
                objprp.AppellateTribunalOrder_ID = item.AppellateTribunalOrder_ID;
                objprp.Related_ComplaintID = item.Related_ComplaintID;
                objprp.Related_DiaryNumber = item.Related_DiaryNumber;
                objprp.Related_ComplaintType_MN = item.Related_ComplaintType_MN;
                objprp.Related_Complaint_OrderRefNumber = item.Related_Complaint_OrderRefNumber;
                objprp.Related_Complaint_OrderDate = item.Related_Complaint_OrderDate;
                objprp.SerialOrderNumber = item.SerialOrderNumber;
                objprp.ComplaintNumber = item.ComplaintNumber;
                objprp.ComplainantName = item.ComplainantName;
                objprp.RespondentName = item.RespondentName;
                objprp.Date_of_Decision = item.Date_of_Decision;
                objprp.Appeal_RefNumber = item.Appeal_RefNumber;
                objprp.Appeal_FilingDate = item.Appeal_FilingDate;
                objprp.Appeal_InstitutionDate = item.Appeal_InstitutionDate;
                objprp.Related_PreHearingDate_IndexID = item.Related_PreHearingDate_IndexID;
                objprp.Related_PreHearingDate_ID = item.Related_PreHearingDate_ID;
                objprp.Related_PreHearingDate = item.Related_PreHearingDate;
                objprp.Related_PreHearingTime = item.Related_PreHearingTime;
                objprp.User_ID = item.User_ID;
                objprp.HearingBenchCode = item.HearingBenchCode;
                objprp.HearingBenchName = item.HearingBenchName;
                objprp.HearingBenchType = item.HearingBenchType;

                
                objprp.AppealOrderDoc_InfoCode = item.AppealOrderDoc_InfoCode;
                objprp.AppealOrderDoc_InfoName = item.AppealOrderDoc_InfoName;
                objprp.AppealOrderDoc_ReferenceNumber = item.AppealOrderDoc_ReferenceNumber;
                objprp.AppealOrderDoc_IssueDate = item.AppealOrderDoc_IssueDate;
                objprp.AppealOrderDoc_FileSize = item.AppealOrderDoc_FileSize;
                objprp.AppealOrderDoc_FileFormat = item.AppealOrderDoc_FileFormat;
                objprp.AppealOrderDoc_FilePath = item.AppealOrderDoc_FilePath;
                objprp.AppealOrderDoc_FileName = item.AppealOrderDoc_FileName;
                objprp.AppealOrderDoc_IsGroup = item.AppealOrderDoc_IsGroup;

                
                objprp.Upload_SerialNumber = item.Upload_SerialNumber;
                objprp.Upload_PageStartNumber = item.Upload_PageStartNumber;
                objprp.Upload_PageEndNumber = item.Upload_PageEndNumber;

               
                objprp.Remarks_IfAny = item.Remarks_IfAny;
                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;
                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsLock = item.IsLock;
                objprp.IsPublicView = item.IsPublicView;
                objprp.IsFlag = item.IsFlag;
                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
                objprp.Related_TypeofOrder = item.Related_TypeofOrder;
            }

            TempData["submitvalueOJByAT"] = "Update";
            TempData.Keep();
            return View("WebindexInfoOrderJudgementByATDetails", objprp);
        }

        public ActionResult Delete_windexInfoOrderJudgementByATDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                //ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();
                ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                if (sdb.Delete_AdminDesk_OrderJudgementByATDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoOrderJudgementByATDetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region OrderJugdement in EXECUTION By AppellateTribunal

        [HttpGet]
        public ActionResult WebindexInfoOrderJudgementInExecutionByATDetails()
        {
            ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal objprp = new ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            Int64 pIndex_ID = 0;
            objprp.prpongoing = sdb.Display_AdminDesk_OrderJudgementInExecutionByATDetails(pIndex_ID);
            TempData["submitvalueOJInexecutionByAT"] = "Save";
            TempData.Keep("submitvalueOJInexecutionByAT");
            return View("WebindexInfoOrderJudgementInExecutionByATDetails", objprp);
        }


        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetTypeofOrders()
        {
            ClsMethod_AdminDesk_CircularPublicNotices objdis = new ClsMethod_AdminDesk_CircularPublicNotices();
            var orders = objdis.Display_Rera_TyeOfOrderDropdown();
            var result = orders.Where(b => b.IsActive == 1).Select(b => new
            {
                b.typeofOrder_ID,
                b.typeofOrderName
            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult WebindexInfoOrderJudgementInExecutionByATDetails(ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            var submitdatat = TempData["submitvalueOJInexecutionByAT"].ToString();
            string UserNam = User.Identity.Name;
            if (TempData["submitvalueOJInexecutionByAT"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersExecutionByPbREAT";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ExecutionOrderDoc_FilePath))
                            {
                                pathindb = smodel.ExecutionOrderDoc_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ExecutionOrderDoc_FileName))
                            {
                                fileName = smodel.ExecutionOrderDoc_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "OJInExecutionbyAT" + Guid.NewGuid().ToString() + ext; //+ smodel.ViewJugdementAO_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.ExecutionOrderDoc_FileName;
                            FileName_Ext = smodel.ExecutionOrderDoc_FileFormat;
                            FileName_Path = smodel.ExecutionOrderDoc_FilePath;
                            FileName_BasicUrl = smodel.ViewJugdement_BaseUrl;
                        }
                        try
                        {
                            smodel.ModifyOn = DateTime.Now;
                            smodel.CreatedOn = DateTime.Now;
                            smodel.User_ID = UID;
                            smodel.ExecutionOrderDoc_IssueDate = DateTime.Now;
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            sdb.Update_AdminDesk_OrderJudgementInExecutionByATDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexInfoOrderJudgementInExecutionByATDetails");
                }
                else
                {
                    return RedirectToAction("WebindexInfoOrderJudgementInExecutionByATDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwdataOrdersExecutionByPbREAT";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "OJInExecutionbyAT" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (!ModelState.IsValid)
                        {
                            var errors = ModelState
                                            .Where(x => x.Value.Errors.Count > 0).ToList();
                        }
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.ExecutionOrderDoc_FileName;
                                FileName_Ext = smodel.ExecutionOrderDoc_FileFormat;
                                FileName_Path = smodel.ExecutionOrderDoc_FilePath;
                                FileName_BasicUrl = smodel.ViewJugdement_BaseUrl;
                            }
                            smodel.User_ID = UID;
                            smodel.ExecutionOrderDoc_IssueDate = DateTime.Now;
                            smodel.ModifyOn = DateTime.Now;
                            smodel.CreatedOn = DateTime.Now;
                            //ClsMethod_AdminDesk_OrderJudgementByAO sdb = new ClsMethod_AdminDesk_OrderJudgementByAO();
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            if (sdb.Add_AdminDesk_OrderJudgementInExecutionByATDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoOrderJudgementInExecutionByATDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoOrderJudgementInExecutionByATDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }

        public ActionResult Delete_windexInfoOrderJudgementInExecutionByATDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                if (sdb.Delete_AdminDesk_OrderJudgementInExecutionByATDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoOrderJudgementInExecutionByATDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit_windexInfoOrderJudgementInExecutionByATDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal objprp = new ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            objprp.prpongoing = sdb.Display_AdminDesk_OrderJudgementInExecutionByATDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpongoing)
            {
                objprp.AppellateTribunalOrderExecution_IndexID = item.AppellateTribunalOrderExecution_IndexID;
                objprp.AppellateTribunalOrderExecution_ID = item.AppellateTribunalOrderExecution_ID;
                objprp.Related_ComplaintID = item.Related_ComplaintID;
                objprp.Related_DiaryNumber = item.Related_DiaryNumber;
                objprp.Related_ComplaintType_MN = item.Related_ComplaintType_MN;
                objprp.Related_Appeal_RefNumber = item.Related_Appeal_RefNumber;
                objprp.Related_Appeal_OrderDate = item.Related_Appeal_OrderDate;
                objprp.SerialOrderNumber = item.SerialOrderNumber;
                objprp.ComplaintNumber = item.ComplaintNumber;
                objprp.ComplainantName = item.ComplainantName;
                objprp.RespondentName = item.RespondentName;
                objprp.Date_of_Decision = item.Date_of_Decision;
                objprp.Execution_RefNumber = item.Execution_RefNumber;
                objprp.Execution_FilingDate = item.Execution_FilingDate;
                objprp.Execution_InstitutionDate = item.Execution_InstitutionDate;
                objprp.Related_PreHearingDate_IndexID = item.Related_PreHearingDate_IndexID;
                objprp.Related_PreHearingDate_ID = item.Related_PreHearingDate_ID;
                objprp.Related_PreHearingDate = item.Related_PreHearingDate;
                objprp.Related_PreHearingTime = item.Related_PreHearingTime;
                objprp.User_ID = item.User_ID;
                objprp.HearingBenchCode = item.HearingBenchCode;
                objprp.HearingBenchName = item.HearingBenchName;
                objprp.HearingBenchType = item.HearingBenchType;

                objprp.ExecutionOrderDoc_InfoCode = item.ExecutionOrderDoc_InfoCode;
                objprp.ExecutionOrderDoc_InfoName = item.ExecutionOrderDoc_InfoName;
                objprp.ExecutionOrderDoc_ReferenceNumber = item.ExecutionOrderDoc_ReferenceNumber;
                objprp.ExecutionOrderDoc_IssueDate = item.ExecutionOrderDoc_IssueDate;
                objprp.ExecutionOrderDoc_FileSize = item.ExecutionOrderDoc_FileSize;
                objprp.ExecutionOrderDoc_FileFormat = item.ExecutionOrderDoc_FileFormat;
                objprp.ExecutionOrderDoc_FilePath = item.ExecutionOrderDoc_FilePath;
                objprp.ExecutionOrderDoc_FileName = item.ExecutionOrderDoc_FileName;
                objprp.ExecutionOrderDoc_IsGroup = item.ExecutionOrderDoc_IsGroup;

                objprp.Upload_SerialNumber = item.Upload_SerialNumber;
                objprp.Upload_PageStartNumber = item.Upload_PageStartNumber;
                objprp.Upload_PageEndNumber = item.Upload_PageEndNumber;

                objprp.Remarks_IfAny = item.Remarks_IfAny;
                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsLock = item.IsLock;
                objprp.IsPublicView = item.IsPublicView;
                objprp.IsFlag = item.IsFlag;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;

                objprp.Related_TypeofOrder = item.Related_TypeofOrder;
            };
            TempData["submitvalueOJInexecutionByAT"] = "Update";
            TempData.Keep();
            return View("WebindexInfoOrderJudgementInExecutionByATDetails", objprp);
        }


        #region AUTO FILL
        [HttpPost]
        public JsonResult ExtractOrderJudgementDetails(HttpPostedFileBase pdfFile)
        {
            if (pdfFile == null || pdfFile.ContentLength == 0)
                return Json(new { success = false, message = "No file uploaded." });

            var ext = Path.GetExtension(pdfFile.FileName);
            if (!new[] { ".pdf", ".PDF", ".Pdf" }.Contains(ext))
                return Json(new { success = false, message = "Only PDF files are supported." });

            string tempPdfPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".pdf");
            pdfFile.SaveAs(tempPdfPath);

            try
            {
                string rawText = ExtractTextFromScannedPdf(tempPdfPath);
                var parsed = ParseOrderJudgementFields(rawText);

                return Json(new
                {
                    success = true,
                    data = parsed,
                    rawTextPreview = rawText.Length > 500 ? rawText.Substring(0, 500) : rawText
                });


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Could not read document: " + ex.Message });
            }
            finally
            {
                if (System.IO.File.Exists(tempPdfPath))
                    System.IO.File.Delete(tempPdfPath);
            }
        }

        private string ExtractTextFromScannedPdf(string pdfPath)
        {
            var sb = new StringBuilder();
            string tessdataPath = Server.MapPath("~/tessdata");

            using (var pdfDoc = PdfDocument.Load(pdfPath))
            using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
            {
                int pageCount = Math.Min(pdfDoc.PageCount, 2);
                for (int i = 0; i < pageCount; i++)
                {
                    using (var bmp = (Bitmap)pdfDoc.Render(i, 1600, 2200, 300, 300, false))
                    using (var ms = new MemoryStream())
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        using (var pix = Pix.LoadFromMemory(ms.ToArray()))
                        using (var page = engine.Process(pix))
                        {
                            sb.AppendLine(page.GetText());
                        }
                    }
                }
            }
            return sb.ToString();
        }

        private object ParseOrderJudgementFields(string text)
        {
            string complainant = null, respondent = null, execRef = null, appealRef = null, dateOfDecision = null;

            // Complainant name — Tesseract's column-reading order varies per scan, so anchor on the
            // first non-empty line rather than trying to bridge text before "V/s" (which broke when
            // "Present:" or other text landed between the name and the V/s marker).
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0)
                complainant = CleanWhitespace(lines[0]);

            // Respondent — everything between "V/s" and the start of the reference-number block.
            // Allow "EX/A0/" as well as "EX/AO/" since Tesseract frequently misreads O as 0 here.
            var respondentMatch = Regex.Match(text, @"V\s*/\s*s\s*(.+?)(?=EX\s*/|EX\s*A[O0]|AdC\s*No)",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            if (respondentMatch.Success)
                respondent = CleanWhitespace(respondentMatch.Groups[1].Value);

            // Execution reference, e.g. "EX/AO/45/2024" — allow digits in the second segment
            // to tolerate the common OCR misread of "AO" as "A0".
            var execMatch = Regex.Match(text, @"([A-Z]{2,4}\s*/\s*[A-Z0-9]{1,4}\s*/\s*\d+\s*/\s*\d{4})\s*in",
                RegexOptions.IgnoreCase);
            if (execMatch.Success)
            {
                execRef = Regex.Replace(execMatch.Groups[1].Value, @"\s+", "").ToUpper();
                execRef = execRef.Replace("A0", "AO"); // normalize OCR misread specific to this doc series
            }

            // Appeal reference, e.g. "AdC No. 1084/2019"
            var appealMatch = Regex.Match(text, @"AdC\s*No\.?\s*(\d+\s*/\s*\d{4})", RegexOptions.IgnoreCase);
            if (appealMatch.Success)
                appealRef = Regex.Replace(appealMatch.Groups[1].Value, @"\s+", "");

            // Decision date — standalone dd.mm.yyyy line, typically the last date in the document
            // (the body may mention an earlier "adjourned to" date first; the signature date comes last)
            var dateMatches = Regex.Matches(text, @"\b(\d{2}\.\d{2}\.\d{4})\b");
            if (dateMatches.Count > 0)
                dateOfDecision = dateMatches[dateMatches.Count - 1].Value;

            return new
            {
                complainantName = complainant,
                respondentName = respondent,
                executionRefNumber = execRef,
                appealRefNumber = appealRef,
                dateOfDecision = dateOfDecision
            };
        }

        private string CleanWhitespace(string s) => Regex.Replace(s ?? "", @"\s+", " ").Trim();
        #endregion



        #endregion


        #region member Circulars and PublicNotices By REAT
        [HttpGet]
        public ActionResult WebindexInfoCircularPublicNoticesByREATdetails()
        {
            ClsPrp_AdminDesk_ReatCircularPublicNotice objprp = new ClsPrp_AdminDesk_ReatCircularPublicNotice();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
            Int64 pIndex_ID = 0;
            objprp.prpreatCircularPublicNotice = sdb.Display_AdminDesk_ReatCircularPublicNoticesDetails(pIndex_ID);
            TempData["submitvalueReatCircularPublicNotices"] = "Save";
            TempData.Keep("submitvalueReatCircularPublicNotices");
            return View("WebindexInfoCircularPublicNoticesByREATdetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexInfoCircularPublicNoticesByREATdetails(ClsPrp_AdminDesk_ReatCircularPublicNotice smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueReatCircularPublicNotices"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/Circulars";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.Circular_FilePath))
                            {
                                pathindb = smodel.Circular_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.Circular_FileName))
                            {
                                fileName = smodel.Circular_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "CPN" + Guid.NewGuid().ToString() + ext; //+ smodel.Circular_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.Circular_FileName;
                            FileName_Ext = smodel.Circular_FileType;
                            FileName_Path = smodel.Circular_FilePath;
                            FileName_BasicUrl = smodel.Circular_BaseUrl;
                        }
                        try
                        {
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            sdb.Update_AdminDesk_ReatCircularPublicNoticesDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexInfoCircularPublicNoticesByREATdetails");
                }
                else
                {
                    return RedirectToAction("WebindexInfoCircularPublicNoticesByREATdetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/Circulars";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "CPN" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.Circular_FileName;
                                FileName_Ext = smodel.Circular_FileType;
                                FileName_Path = smodel.Circular_FilePath;
                                FileName_BasicUrl = smodel.Circular_BaseUrl;
                            }
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            if (sdb.Add_AdminDesk_ReatCircularPublicNoticesDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoCircularPublicNoticesByREATdetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoCircularPublicNoticesByREATdetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }

        [HttpGet]
        public ActionResult Edit_windexInfoReatCircularPublicNoticesDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_ReatCircularPublicNotice objprp = new ClsPrp_AdminDesk_ReatCircularPublicNotice();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            objprp.prpreatCircularPublicNotice = sdb.Display_AdminDesk_ReatCircularPublicNoticesDetailsByID(pIndexID, pKeyID);
            foreach (var item in objprp.prpreatCircularPublicNotice)
            {
                objprp.CircularPublicNotice_IndexID = item.CircularPublicNotice_IndexID;
                objprp.CircularPublicNotice_ID = item.CircularPublicNotice_ID;
                objprp.CircularPublicNotice_LanguageFlag = item.CircularPublicNotice_LanguageFlag;

                objprp.Circular_Number = item.Circular_Number;
                objprp.Circular_IssueDate = item.Circular_IssueDate;
                objprp.Circular_Category = item.Circular_Category;
                objprp.Circular_Title = item.Circular_Title;
                objprp.CulturePunjabi_Circular_Category = item.CulturePunjabi_Circular_Category;
                objprp.CulturePunjabi_Circular_Title = item.CulturePunjabi_Circular_Title;

                objprp.Circular_BaseUrl = item.Circular_BaseUrl;
                objprp.Circular_FilePath = item.Circular_FilePath;
                objprp.Circular_FileName = item.Circular_FileName;
                objprp.Circular_FileType = item.Circular_FileType;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.IsActive = item.IsActive;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueReatCircularPublicNotices"] = "Update";
            TempData.Keep();
            return View("WebindexInfoCircularPublicNoticesByREATdetails", objprp);
        }

        public ActionResult Delete_windexInfoReatCircularPublicNoticesDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                if (sdb.Delete_AdminDesk_ReatCircularPublicNoticesDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoCircularPublicNoticesByREATdetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region member Circular and PublicNotices
        [HttpGet]
        public ActionResult WebindexInfoCircularPublicNoticesDetails()
        {
            ClsPrp_AdminDesk_CircularPublicNotice objprp = new ClsPrp_AdminDesk_CircularPublicNotice();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            Int64 pIndex_ID = 0;
            objprp.prpCircularPublicNotice = sdb.Display_AdminDesk_CircularPublicNoticesDetails(pIndex_ID);
            TempData["submitvalueCircularPublicNotices"] = "Save"; TempData.Keep();
            return View("WebindexInfoCircularPublicNoticesDetails", objprp);
        }

        [HttpGet]
        public ActionResult Edit_windexInfoCircularPublicNoticesDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_CircularPublicNotice objprp = new ClsPrp_AdminDesk_CircularPublicNotice();
            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();

            objprp.prpCircularPublicNotice = sdb.Display_AdminDesk_CircularPublicNoticesDetailsByID(pIndexID, pKeyID);
            foreach (var item in objprp.prpCircularPublicNotice)
            {
                objprp.CircularPublicNotice_IndexID = item.CircularPublicNotice_IndexID;
                objprp.CircularPublicNotice_ID = item.CircularPublicNotice_ID;
                objprp.CircularPublicNotice_LanguageFlag = item.CircularPublicNotice_LanguageFlag;

                objprp.Circular_Number = item.Circular_Number;
                objprp.Circular_IssueDate = item.Circular_IssueDate;
                objprp.Circular_Category = item.Circular_Category;
                objprp.Circular_Title = item.Circular_Title;
                objprp.CulturePunjabi_Circular_Category = item.CulturePunjabi_Circular_Category;
                objprp.CulturePunjabi_Circular_Title = item.CulturePunjabi_Circular_Title;

                objprp.Circular_BaseUrl = item.Circular_BaseUrl;
                objprp.Circular_FilePath = item.Circular_FilePath;
                objprp.Circular_FileName = item.Circular_FileName;
                objprp.Circular_FileType = item.Circular_FileType;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.IsActive = item.IsActive;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueCircularPublicNotices"] = "Update";
            TempData.Keep();
            return View("WebindexInfoCircularPublicNoticesDetails", objprp);
        }

        public ActionResult Delete_windexInfoCircularPublicNoticesDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                if (sdb.Delete_AdminDesk_CircularPublicNoticesDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoCircularPublicNoticesDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WebindexInfoCircularPublicNoticesDetails(ClsPrp_AdminDesk_CircularPublicNotice smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueCircularPublicNotices"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/Circulars";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.Circular_FilePath))
                            {
                                pathindb = smodel.Circular_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.Circular_FileName))
                            {
                                fileName = smodel.Circular_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "CPN" + Guid.NewGuid().ToString() + ext; //+ smodel.Circular_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.Circular_FileName;
                            FileName_Ext = smodel.Circular_FileType;
                            FileName_Path = smodel.Circular_FilePath;
                            FileName_BasicUrl = smodel.Circular_BaseUrl;
                        }
                        try
                        {
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            sdb.Update_AdminDesk_CircularPublicNoticesDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexInfoCircularPublicNoticesDetails");
                }
                else
                {
                    return RedirectToAction("WebindexInfoCircularPublicNoticesDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/Circulars";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "CPN" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.Circular_FileName;
                                FileName_Ext = smodel.Circular_FileType;
                                FileName_Path = smodel.Circular_FilePath;
                                FileName_BasicUrl = smodel.Circular_BaseUrl;
                            }
                            ClsMethod_AdminDesk_CircularPublicNotices sdb = new ClsMethod_AdminDesk_CircularPublicNotices();
                            if (sdb.Add_AdminDesk_CircularPublicNoticesDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexInfoCircularPublicNoticesDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexInfoCircularPublicNoticesDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }
        #endregion







        #region member Notice Section FiveNine (Not-Use)
        [HttpGet]
        public ActionResult WebindexInfoNoticeSectionFiveNineDetails()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNine objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNine();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            objprp.prpNoticeSectionFiveNine = sdb.Display_AdminDesk_NoticeSectionFiveNineDetails(pIndex_ID);
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSectionFiveNineDetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexInfoNoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNine smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    if (sdb.Add_AdminDesk_NoticeSectionFiveNineDetails(smodel, UserNam))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("WebindexInfoNoticeSectionFiveNineDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit_windexInfoNoticeSectionFiveNineDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNine objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNine();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            objprp.prpNoticeSectionFiveNine = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpNoticeSectionFiveNine)
            {
                objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
                objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;
                objprp.SerialOrderNumber = item.SerialOrderNumber;

                objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
                objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
                objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
                objprp.NoticeDate = item.NoticeDate;
                objprp.PromoterName = item.PromoterName;
                objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
                objprp.ProjectName = item.ProjectName;
                objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;
                objprp.CurrentStatusDate = item.CurrentStatusDate;
                objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;
                objprp.OrderDate = item.OrderDate;
                objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
                objprp.RemarksIfAny = item.RemarksIfAny;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("WebindexInfoNoticeSectionFiveNineDetails", objprp);
        }

        [HttpPost]
        public ActionResult Edit_windexInfoNoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNine smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    sdb.Update_AdminDesk_NoticeSectionFiveNineDetails(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("WebindexInfoNoticeSectionFiveNineDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        public ActionResult Delete_windexInfoNoticeSectionFiveNineDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                if (sdb.Delete_AdminDesk_NoticeSectionFiveNineDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexInfoNoticeSectionFiveNineDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region member Notice Section FiveNine - User Programmer
        [HttpGet]
        public ActionResult ComplaintsNoticeSectionFiveNineDetails()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            Int64 pIndex_ID = 0;
            string userRole = string.Empty;
            Int32 Flag_CodeId = 0;
            userRole = getUserRole();

            objprp.CurrentStatusDate = DateTime.Now;
            objprp.NoticeDate = DateTime.Now;
            objprp.IsPersonalHearing = 0;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLA(pIndex_ID);
            objprp.PreHearingBenchMaster = sdb.Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(userRole);
            objprp.EventMaster = sdb.Display_Master_AdminDesk_EventActionsByUserID(userRole, 0);
            objprp.eCourtUnderSectionMaster = sdb.Display_Master_Complaint_UnderSectionList_ByID(Flag_CodeId, userRole);

            objprp.districtMaster = objdis.dropdownlist_display1();
            objprp.stateMaster = objdis.State_list();
            objprp.subdivisondistrictMaster = objdis.dropdownlist_diplaySubdiv();

            objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";

            //foreach (var item in objprp.prpNoticeSectionFiveNineByLA)
            //{
            //    objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
            //    objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;

            //    objprp.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
            //    objprp.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
            //    objprp.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
            //    objprp.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
            //    objprp.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
            //    objprp.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
            //    objprp.SerialOrderNumber = item.SerialOrderNumber;

            //    objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
            //    objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
            //    objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
            //    objprp.NoticeDate = item.NoticeDate;
            //    objprp.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
            //    objprp.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;

            //    objprp.PromoterName = item.PromoterName;
            //    objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
            //    objprp.ProjectName = item.ProjectName;
            //    objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

            //    objprp.Complainant_Name = item.Complainant_Name;
            //    objprp.Complainant_EmailAddress = item.Complainant_EmailAddress;
            //    objprp.Complainant_MobileNumber = item.Complainant_MobileNumber;
            //    objprp.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
            //    objprp.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

            //    objprp.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
            //    objprp.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
            //    objprp.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
            //    objprp.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
            //    objprp.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

            //    objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
            //    objprp.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
            //    objprp.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
            //    objprp.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
            //    objprp.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
            //    objprp.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

            //    objprp.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
            //    objprp.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
            //    objprp.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
            //    objprp.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

            //    objprp.CurrentStatusDate = item.CurrentStatusDate;
            //    objprp.CurrentStatusTitle = item.CurrentStatusTitle;
            //    objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;

            //    objprp.IsPersonalHearing = item.IsPersonalHearing;
            //    objprp.HearingBenchCode = item.HearingBenchCode;
            //    objprp.HearingBenchName = item.HearingBenchName;
            //    objprp.FixedFor = item.FixedFor;
            //    objprp.OrderDate = item.OrderDate;
            //    objprp.OrderTime = item.OrderTime;
            //    objprp.OrderDateStatusTitle = item.OrderDateStatusTitle;
            //    objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
            //    objprp.RemarksIfAny = item.RemarksIfAny;

            //    objprp.A_column = item.A_column;
            //    objprp.B_column = item.B_column;
            //    objprp.C_column = item.C_column;
            //    objprp.D_column = item.D_column;
            //    objprp.E_column = item.E_column;

            //    objprp.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
            //    objprp.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
            //    objprp.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
            //    objprp.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;
            //    objprp.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
            //    objprp.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
            //    objprp.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
            //    objprp.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

            //    objprp.IsActive = item.IsActive;
            //    objprp.IsDraft = item.IsDraft;
            //    objprp.IsDraftMember = item.IsDraftMember;
            //    objprp.IsPublicView = item.IsPublicView;
            //    objprp.CreatedBy = item.CreatedBy;
            //    objprp.CreatedOn = item.CreatedOn;
            //    objprp.ModifyBy = item.ModifyBy;
            //    objprp.ModifyOn = item.ModifyOn;
            //}
            Session["modelComplaintNoticeSectionFormByCPMIS"] = objprp.prpNoticeSectionFiveNineByLA;

            TempData["submitvalue"] = "Save"; TempData.Keep();
            TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
            return View("ComplaintsNoticeSectionFiveNineDetails", objprp);
        }

        //Get Document Information As Json
        public JsonResult GetNoticeSectionFiveNineMasterByEventId(string EventId)
        {
            int Id = 0;
            if (EventId != "")
                Id = Convert.ToInt32(EventId);

            ClsMethod_AdminDesk_NoticeSectionFiveNine objDoc = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            var Subdiv = objDoc.Display_AdminDesk_CurrentStatusEventDescription_MasterDetailsByCode(Id);

            return Json(Subdiv);
        }

        [HttpPost]
        public ActionResult ComplaintsNoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    if (sdb.Add_AdminDesk_NoticeSectionFiveNineDetailsByLA(smodel, UserNam))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetails");
            }
        }

        [HttpGet]
        public ActionResult Edit_ComplaintsNoticeSectionFiveNineDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.CurrentStatusDate = DateTime.Now;
            objprp.NoticeDate = DateTime.Now;
            objprp.IsPersonalHearing = 0;
            string userRole = string.Empty;
            Int32 Flag_CodeId = 0;
            userRole = getUserRole();
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(pIndexID, pKeyID);
            objprp.PreHearingBenchMaster = sdb.Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(userRole);
            objprp.EventMaster = sdb.Display_Master_AdminDesk_EventActionsByUserID(userRole, 0);
            objprp.eCourtUnderSectionMaster = sdb.Display_Master_Complaint_UnderSectionList_ByID(Flag_CodeId, userRole);

            objprp.districtMaster = objdis.dropdownlist_display1();
            objprp.stateMaster = objdis.State_list();
            objprp.subdivisondistrictMaster = objdis.dropdownlist_diplaySubdiv();

            foreach (var item in objprp.prpNoticeSectionFiveNineByLA)
            {
                objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
                objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;

                objprp.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
                objprp.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
                objprp.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
                objprp.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
                objprp.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
                objprp.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
                objprp.SerialOrderNumber = item.SerialOrderNumber;

                objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
                objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
                objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
                objprp.NoticeDate = item.NoticeDate;
                objprp.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
                objprp.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;

                objprp.PromoterName = item.PromoterName;
                objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
                objprp.ProjectName = item.ProjectName;
                objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

                objprp.Complainant_Name = item.Complainant_Name;
                objprp.Complainant_EmailAddress = item.Complainant_EmailAddress;
                objprp.Complainant_MobileNumber = item.Complainant_MobileNumber;
                objprp.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                objprp.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                objprp.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                objprp.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                objprp.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                objprp.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                objprp.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

                objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
                objprp.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                objprp.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                objprp.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                objprp.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                objprp.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                objprp.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
                objprp.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
                objprp.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
                objprp.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

                objprp.CurrentStatusDate = item.CurrentStatusDate;
                objprp.CurrentStatusTitle = item.CurrentStatusTitle;
                objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;

                objprp.IsPersonalHearing = item.IsPersonalHearing;
                objprp.HearingBenchCode = item.HearingBenchCode;
                objprp.HearingBenchName = item.HearingBenchName;
                objprp.FixedFor = item.FixedFor;
                objprp.OrderDate = item.OrderDate;
                objprp.OrderTime = item.OrderTime;
                objprp.OrderDateStatusTitle = item.OrderDateStatusTitle;
                objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
                objprp.RemarksIfAny = item.RemarksIfAny;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;
                objprp.D_column = item.D_column;
                objprp.E_column = item.E_column;

                objprp.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
                objprp.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
                objprp.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
                objprp.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;
                objprp.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
                objprp.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
                objprp.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
                objprp.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;
                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }
            Session["modelComplaintNoticeSectionFormByCPMIS"] = objprp.prpNoticeSectionFiveNineByLA;

            TempData["submitvalue"] = "Update"; TempData.Keep();
            TempData["returnUrlFNByPRvalue"] = "ExtractComplaintsNoticeSection"; TempData.Keep();
            return View("ComplaintsNoticeSectionFiveNineDetails", objprp);
        }

        [HttpPost]
        public ActionResult Edit_ComplaintsNoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    sdb.Update_AdminDesk_NoticeSectionFiveNineDetailsByLA(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetails");
            }
        }

        public ActionResult Delete_ComplaintsNoticeSectionFiveNineDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                if (sdb.Delete_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetails");
            }
            catch
            {
                TempData["returnUrlFNByPRvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetails");
            }
        }

        public void ComplaintNoticeSectionFormByCP_ExportToExcel()
        {
            var objXlslist = Session["modelComplaintNoticeSectionFormByCPMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Notice/File Number";
            workSheet.Cells[1, 3].Value = "Date of Institution";
            workSheet.Cells[1, 4].Value = "Mode Of Complaint";
            workSheet.Cells[1, 5].Value = "District/Town Name";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Promoter Name";

            workSheet.Cells[1, 8].Value = "Name of Complainant";
            workSheet.Cells[1, 9].Value = "Email Address of Complainant";
            workSheet.Cells[1, 10].Value = "Mobile Number of Complainant";
            workSheet.Cells[1, 11].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 12].Value = "Email ID of Authorized Representative/ Counsel";
            workSheet.Cells[1, 13].Value = "Mobile Number of Authorized Representative/ Counsel";
            workSheet.Cells[1, 14].Value = "Remarks, if Any";

            workSheet.Cells[1, 15].Value = "Hearing Date/ Order Date";
            workSheet.Cells[1, 16].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 17].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Fixed For";
            workSheet.Cells[1, 20].Value = "Business On Date";
            workSheet.Cells[1, 21].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Notice_ModeOfComplaint;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.PromoterName;

                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.AuthorizedCounsel_EmailAddress;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.AuthorizedCounsel_MobileNumber;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderTime;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = QRcodeItem.CurrentEvent_IdentifiedAggregateName;
                workSheet.Cells[recordIndex, 20].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = QRcodeItem.OrderDateWithRemarksIfAny;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();

            workSheet.Cells["A1:U1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:U1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 21])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofComplaintNoticeForm_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region member Notice Section FiveNine - All Lists - User Programmer
        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineInProcessCasesDetailsPV()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_InProcess_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNinePVInProcessCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineInProcessCasesDetailsPV", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineClosedCasesDetailsPV()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_FileClosed_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNinePVClosedCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineClosedCasesDetailsPV", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineInBoxCasesDetailsPV()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            pIndexKey_ID = getUserKey();
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_InBox_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNinePVInBoxCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineInBoxCasesDetailsPV", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineNonMaintainableCasesDetailsPV()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NonMaintainable_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNinePVNonMaintainableCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineNonMaintainableCasesDetailsPV", objprp);
        }

        #region Export to Excel
        public void FiveNineInProcessCasesPV_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNinePVInProcessCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofInProcessCasesPVUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineClosedCasesPV_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNinePVClosedCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofClosedCasesPVUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineInBoxCasesPV_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNinePVInBoxCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofInBoxNewCasesPVUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineNonMaintainableCasesPV_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNinePVNonMaintainableCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofNonMaintainableCasesPVUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion
        #endregion

        #region member Notice Section FiveNine - DETAIL - User Programmer
        [HttpGet]
        public ActionResult ComplaintsNoticeSecFiveNinePV(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.CurrentStatusDate = DateTime.Now;
            string userRole = string.Empty;
            Int32 Flag_CodeId = 0;
            userRole = getUserRole();
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(pIndexID, pKeyID);
            objprp.PreHearingBenchMaster = sdb.Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(userRole);
            objprp.EventMaster = sdb.Display_Master_AdminDesk_EventActionsByUserID(userRole, 0);
            objprp.eCourtUnderSectionMaster = sdb.Display_Master_Complaint_UnderSectionList_ByID(Flag_CodeId, userRole);

            objprp.districtMaster = objdis.dropdownlist_display1();
            objprp.stateMaster = objdis.State_list();
            objprp.subdivisondistrictMaster = objdis.dropdownlist_diplaySubdiv();

            objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";

            foreach (var item in objprp.prpNoticeSectionFiveNineByLA)
            {
                objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
                objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;

                objprp.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
                objprp.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
                objprp.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
                objprp.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
                objprp.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
                objprp.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
                objprp.SerialOrderNumber = item.SerialOrderNumber;

                objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
                objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
                objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
                objprp.NoticeDate = item.NoticeDate;
                objprp.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
                objprp.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;

                objprp.PromoterName = item.PromoterName;
                objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
                objprp.ProjectName = item.ProjectName;
                objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

                objprp.Complainant_Name = item.Complainant_Name;
                objprp.Complainant_EmailAddress = item.Complainant_EmailAddress;
                objprp.Complainant_MobileNumber = item.Complainant_MobileNumber;
                objprp.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                objprp.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                objprp.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                objprp.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                objprp.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                objprp.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                objprp.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

                objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
                objprp.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                objprp.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                objprp.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                objprp.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                objprp.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                objprp.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
                objprp.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
                objprp.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
                objprp.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

                objprp.CurrentStatusDate = item.CurrentStatusDate;
                objprp.CurrentStatusTitle = item.CurrentStatusTitle;
                objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;

                objprp.IsPersonalHearing = item.IsPersonalHearing;
                objprp.HearingBenchCode = item.HearingBenchCode;
                objprp.HearingBenchName = item.HearingBenchName;
                objprp.FixedFor = item.FixedFor;
                objprp.OrderDate = item.OrderDate;
                objprp.OrderTime = item.OrderTime;
                objprp.OrderDateStatusTitle = item.OrderDateStatusTitle;
                objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
                objprp.RemarksIfAny = item.RemarksIfAny;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;
                objprp.D_column = item.D_column;
                objprp.E_column = item.E_column;

                objprp.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
                objprp.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
                objprp.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
                objprp.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;
                objprp.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
                objprp.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
                objprp.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
                objprp.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;
                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("ComplaintsNoticeSecFiveNinePV", objprp);
        }

        [HttpPost]
        public ActionResult ComplaintsNoticeSecFiveNinePV(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    //smodel.IsPublicView = 0; // update by User Programmer
                    sdb.Update_AdminDesk_NoticeSectionFiveNineDetailsByLA(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                //return RedirectToAction("ComplaintsNoticeSecFiveNine");
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                //return View();
                //return RedirectToAction("ComplaintsNoticeSecFiveNine");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        #endregion

        #region member Notice Section FiveNine - PS/LA
        [HttpGet]
        public ActionResult ComplaintsNoticeSectionFiveNineDetailsByPS()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            Int64 pIndex_ID = 0;
            string userRole = string.Empty;
            Int32 Flag_CodeId = 0;
            userRole = getUserRole();

            objprp.CurrentStatusDate = DateTime.Now;
            objprp.NoticeDate = DateTime.Now;
            objprp.IsPersonalHearing = 0;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLA(pIndex_ID);
            objprp.PreHearingBenchMaster = sdb.Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(userRole);
            objprp.EventMaster = sdb.Display_Master_AdminDesk_EventActionsByUserID(userRole, 0);
            objprp.eCourtUnderSectionMaster = sdb.Display_Master_Complaint_UnderSectionList_ByID(Flag_CodeId, userRole);

            objprp.districtMaster = objdis.dropdownlist_display1();
            objprp.stateMaster = objdis.State_list();
            objprp.subdivisondistrictMaster = objdis.dropdownlist_diplaySubdiv();

            objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";

            //foreach (var item in objprp.prpNoticeSectionFiveNineByLA)
            //{
            //    objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
            //    objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;

            //    objprp.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
            //    objprp.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
            //    objprp.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
            //    objprp.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
            //    objprp.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
            //    objprp.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
            //    objprp.SerialOrderNumber = item.SerialOrderNumber;

            //    objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
            //    objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
            //    objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
            //    objprp.NoticeDate = item.NoticeDate;
            //    objprp.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
            //    objprp.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;

            //    objprp.PromoterName = item.PromoterName;
            //    objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
            //    objprp.ProjectName = item.ProjectName;
            //    objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

            //    objprp.Complainant_Name = item.Complainant_Name;
            //    objprp.Complainant_EmailAddress = item.Complainant_EmailAddress;
            //    objprp.Complainant_MobileNumber = item.Complainant_MobileNumber;
            //    objprp.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
            //    objprp.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

            //    objprp.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
            //    objprp.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
            //    objprp.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
            //    objprp.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
            //    objprp.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

            //    objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
            //    objprp.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
            //    objprp.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
            //    objprp.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
            //    objprp.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
            //    objprp.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

            //    objprp.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
            //    objprp.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
            //    objprp.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
            //    objprp.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

            //    objprp.CurrentStatusDate = item.CurrentStatusDate;
            //    objprp.CurrentStatusTitle = item.CurrentStatusTitle;
            //    objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;

            //    objprp.IsPersonalHearing = item.IsPersonalHearing;
            //    objprp.HearingBenchCode = item.HearingBenchCode;
            //    objprp.HearingBenchName = item.HearingBenchName;
            //    objprp.FixedFor = item.FixedFor;
            //    objprp.OrderDate = item.OrderDate;
            //    objprp.OrderTime = item.OrderTime;
            //    objprp.OrderDateStatusTitle = item.OrderDateStatusTitle;
            //    objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
            //    objprp.RemarksIfAny = item.RemarksIfAny;

            //    objprp.A_column = item.A_column;
            //    objprp.B_column = item.B_column;
            //    objprp.C_column = item.C_column;
            //    objprp.D_column = item.D_column;
            //    objprp.E_column = item.E_column;

            //    objprp.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
            //    objprp.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
            //    objprp.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
            //    objprp.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;
            //    objprp.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
            //    objprp.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
            //    objprp.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
            //    objprp.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

            //    objprp.IsActive = item.IsActive;
            //    objprp.IsDraft = item.IsDraft;
            //    objprp.IsDraftMember = item.IsDraftMember;
            //    objprp.IsPublicView = item.IsPublicView;
            //    objprp.CreatedBy = item.CreatedBy;
            //    objprp.CreatedOn = item.CreatedOn;
            //    objprp.ModifyBy = item.ModifyBy;
            //    objprp.ModifyOn = item.ModifyOn;
            //}
            Session["modelComplaintNoticeSectionFormMIS"] = objprp.prpNoticeSectionFiveNineByLA;

            TempData["submitvalue"] = "Save"; TempData.Keep();
            TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
            return View("ComplaintsNoticeSectionFiveNineDetailsByPS", objprp);
        }

        [HttpPost]
        public ActionResult ComplaintsNoticeSectionFiveNineDetailsByPS(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    smodel.IsPublicView = 0;
                    if (sdb.Add_AdminDesk_NoticeSectionFiveNineDetailsByLA(smodel, UserNam))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetailsByPS");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetailsByPS");
            }
        }

        [HttpGet]
        public ActionResult Edit_ComplaintsNoticeSectionFiveNineDetailsByPS(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.CurrentStatusDate = DateTime.Now;
            objprp.NoticeDate = DateTime.Now;
            objprp.IsPersonalHearing = 0;
            string userRole = string.Empty;
            Int32 Flag_CodeId = 0;
            userRole = getUserRole();
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(pIndexID, pKeyID);
            objprp.PreHearingBenchMaster = sdb.Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(userRole);
            objprp.EventMaster = sdb.Display_Master_AdminDesk_EventActionsByUserID(userRole, 0);
            objprp.eCourtUnderSectionMaster = sdb.Display_Master_Complaint_UnderSectionList_ByID(Flag_CodeId, userRole);

            objprp.districtMaster = objdis.dropdownlist_display1();
            objprp.stateMaster = objdis.State_list();
            objprp.subdivisondistrictMaster = objdis.dropdownlist_diplaySubdiv();

            foreach (var item in objprp.prpNoticeSectionFiveNineByLA)
            {
                objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
                objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;

                objprp.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
                objprp.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
                objprp.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
                objprp.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
                objprp.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
                objprp.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
                objprp.SerialOrderNumber = item.SerialOrderNumber;

                objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
                objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
                objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
                objprp.NoticeDate = item.NoticeDate;
                objprp.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
                objprp.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;

                objprp.PromoterName = item.PromoterName;
                objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
                objprp.ProjectName = item.ProjectName;
                objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

                objprp.Complainant_Name = item.Complainant_Name;
                objprp.Complainant_EmailAddress = item.Complainant_EmailAddress;
                objprp.Complainant_MobileNumber = item.Complainant_MobileNumber;
                objprp.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                objprp.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                objprp.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                objprp.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                objprp.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                objprp.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                objprp.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

                objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
                objprp.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                objprp.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                objprp.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                objprp.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                objprp.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                objprp.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
                objprp.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
                objprp.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
                objprp.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

                objprp.CurrentStatusDate = item.CurrentStatusDate;
                objprp.CurrentStatusTitle = item.CurrentStatusTitle;
                objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;

                objprp.IsPersonalHearing = item.IsPersonalHearing;
                objprp.HearingBenchCode = item.HearingBenchCode;
                objprp.HearingBenchName = item.HearingBenchName;
                objprp.FixedFor = item.FixedFor;
                objprp.OrderDate = item.OrderDate;
                objprp.OrderTime = item.OrderTime;
                objprp.OrderDateStatusTitle = item.OrderDateStatusTitle;
                objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
                objprp.RemarksIfAny = item.RemarksIfAny;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;
                objprp.D_column = item.D_column;
                objprp.E_column = item.E_column;

                objprp.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
                objprp.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
                objprp.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
                objprp.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;
                objprp.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
                objprp.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
                objprp.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
                objprp.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;
                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }
            Session["modelComplaintNoticeSectionFormMIS"] = objprp.prpNoticeSectionFiveNineByLA;

            TempData["submitvalue"] = "Update"; TempData.Keep();
            TempData["returnUrlFNByPSvalue"] = "ExtractComplaintsNoticeSection"; TempData.Keep();
            return View("ComplaintsNoticeSectionFiveNineDetailsByPS", objprp);
        }

        [HttpPost]
        public ActionResult Edit_ComplaintsNoticeSectionFiveNineDetailsByPS(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    smodel.IsPublicView = 0;
                    sdb.Update_AdminDesk_NoticeSectionFiveNineDetailsByLA(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetailsByPS");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetailsByPS");
            }
        }

        public ActionResult Delete_ComplaintsNoticeSectionFiveNineDetailsByPS(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                if (sdb.Delete_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetailsByPS");
            }
            catch
            {
                TempData["returnUrlFNByPSvalue"] = "ComplaintsNoticeSection"; TempData.Keep();
                return RedirectToAction("ComplaintsNoticeSectionFiveNineDetailsByPS");
            }
        }

        public void ComplaintNoticeSectionForm_ExportToExcel()
        {
            var objXlslist = Session["modelComplaintNoticeSectionFormMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Notice/File Number";
            workSheet.Cells[1, 3].Value = "Date of Institution";
            workSheet.Cells[1, 4].Value = "Mode Of Complaint";
            workSheet.Cells[1, 5].Value = "District/Town Name";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Promoter Name";

            workSheet.Cells[1, 8].Value = "Name of Complainant";
            workSheet.Cells[1, 9].Value = "Email Address of Complainant";
            workSheet.Cells[1, 10].Value = "Mobile Number of Complainant";
            workSheet.Cells[1, 11].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 12].Value = "Email ID of Authorized Representative/ Counsel";
            workSheet.Cells[1, 13].Value = "Mobile Number of Authorized Representative/ Counsel";
            workSheet.Cells[1, 14].Value = "Remarks, if Any";

            workSheet.Cells[1, 15].Value = "Hearing Date/ Order Date";
            workSheet.Cells[1, 16].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 17].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Fixed For";
            workSheet.Cells[1, 20].Value = "Business On Date";
            workSheet.Cells[1, 21].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Notice_ModeOfComplaint;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.PromoterName;

                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.AuthorizedCounsel_EmailAddress;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.AuthorizedCounsel_MobileNumber;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderTime;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = QRcodeItem.CurrentEvent_IdentifiedAggregateName;
                workSheet.Cells[recordIndex, 20].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = QRcodeItem.OrderDateWithRemarksIfAny;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();

            workSheet.Cells["A1:U1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:U1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 21])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofComplaintNoticeForm_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region member Notice Section FiveNine - All Lists - PS/LA
        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineInProcessCasesDetails()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_InProcess_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNineInProcessCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineInProcessCasesDetails", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineClosedCasesDetails()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_FileClosed_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNineClosedCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineClosedCasesDetails", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineInBoxCasesDetails()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            pIndexKey_ID = getUserKey();
            pUser_ID = getUserRole();
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_InBox_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNineInBoxCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineInBoxCasesDetails", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineNonMaintainableCasesDetails()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NonMaintainable_NoticeSectionFiveNineDetailsByLA(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNineNonMaintainableCasesMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineNonMaintainableCasesDetails", objprp);
        }

        [HttpGet]
        public ActionResult WebindexInfoNoticeSecFiveNineCasesHearingRecords()
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();

            Int64 pIndex_ID = 0;
            Int64 pIndexKey_ID = 0;
            string pUser_ID = string.Empty;
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_HearingRecords_NoticeSectionFiveNineDetails(pUser_ID, pIndex_ID, pIndexKey_ID);
            Session["modelFiveNineHearingRecordsMIS"] = objprp.prpNoticeSectionFiveNineByLA;
            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("WebindexInfoNoticeSecFiveNineCasesHearingRecords", objprp);
        }

        #region Export to Excel
        public void FiveNineInProcessCases_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNineInProcessCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofInProcessCasesUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineClosedCases_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNineClosedCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofClosedCasesUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineInBoxCases_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNineInBoxCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofInBoxNewCasesUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineNonMaintainableCases_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNineNonMaintainableCasesMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofNonMaintainableCasesUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void FiveNineCasesHearingRecord_ExportToExcel()
        {
            var objXlslist = Session["modelFiveNineHearingRecordsMIS"] as List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Reference Number";
            workSheet.Cells[1, 4].Value = "Date of Institution";
            workSheet.Cells[1, 5].Value = "Mode Of Complaint Receipt";
            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District/Town Name";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Promoter Address";
            workSheet.Cells[1, 11].Value = "Mobile/Phone Number of Promoter";
            workSheet.Cells[1, 12].Value = "Email of Promoter";
            workSheet.Cells[1, 13].Value = "Name of Complainant";
            workSheet.Cells[1, 14].Value = "Mobile/Phone Number of Complainant";
            workSheet.Cells[1, 15].Value = "Email of Complainant";
            workSheet.Cells[1, 16].Value = "Name of Authorized Representative/ Counsel";
            workSheet.Cells[1, 17].Value = "Type of Hearing Option";
            workSheet.Cells[1, 18].Value = "Hearing Bench";
            workSheet.Cells[1, 19].Value = "Next Hearing Date Fixed";
            workSheet.Cells[1, 20].Value = "Next Hearing Time Fixed";
            workSheet.Cells[1, 21].Value = "Under Section";
            workSheet.Cells[1, 22].Value = "Fixed For/ Status";
            workSheet.Cells[1, 23].Value = "Business On Date/ Date Fixed for Proceeding";
            workSheet.Cells[1, 24].Value = "Remarks, if Any (Hearing Bench)";
            workSheet.Cells[1, 25].Value = "Last Updated On";
            workSheet.Cells[1, 26].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.NoticesSectionFiveNine_IDName;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.NoticeFile_NumberDetails;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.NoticeDate.HasValue ? QRcodeItem.NoticeDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = (QRcodeItem.Notice_ModeOfComplaint != "Other") ? QRcodeItem.Notice_ModeOfComplaint : QRcodeItem.Notice_ModeOfComplaint + " (" + QRcodeItem.Notice_ModeOfComplaintSpecifyOthers + ")";
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.ProjectName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.ProjectNameWithAddressDetails;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.DistrictTown_InfoName;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.PromoterName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PromoterNameWithAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.A_column;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.B_column;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Complainant_MobileNumber;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.Complainant_EmailAddress;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.AuthorizedCounsel_Name;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.OrderDateStatusTitle;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.HearingBenchName;
                workSheet.Cells[recordIndex, 19].Value = (QRcodeItem.OrderDateStatusTitle != "None of them") ? (QRcodeItem.OrderDate.HasValue ? QRcodeItem.OrderDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = (QRcodeItem.OrderDateStatusTitle == "Hearing Date") ? QRcodeItem.OrderTime : string.Empty;
                workSheet.Cells[recordIndex, 21].Value = string.Empty;
                workSheet.Cells[recordIndex, 22].Value = QRcodeItem.CurrentStatusTitle;
                workSheet.Cells[recordIndex, 23].Value = QRcodeItem.CurrentStatusDate.HasValue ? QRcodeItem.CurrentStatusDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 24].Value = QRcodeItem.OrderDateWithRemarksIfAny;
                workSheet.Cells[recordIndex, 25].Value = QRcodeItem.CreatedOn.HasValue ? QRcodeItem.CreatedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 26].Value = QRcodeItem.CurrentStatusWithRemarks;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();
            workSheet.Column(23).AutoFit();
            workSheet.Column(24).AutoFit();
            workSheet.Column(25).AutoFit();
            workSheet.Column(26).AutoFit();

            workSheet.Cells["A1:Z1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 26])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofHearingRecordCasesUnderSection_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion
        #endregion

        #region member Notice Section FiveNine - DETAIL - PS/LA
        [HttpGet]
        public ActionResult ComplaintsNoticeSecFiveNine(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.CurrentStatusDate = DateTime.Now;
            string userRole = string.Empty;
            Int32 Flag_CodeId = 0;
            userRole = getUserRole();
            objprp.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(pIndexID, pKeyID);
            objprp.PreHearingBenchMaster = sdb.Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(userRole);
            objprp.EventMaster = sdb.Display_Master_AdminDesk_EventActionsByUserID(userRole, 0);
            objprp.eCourtUnderSectionMaster = sdb.Display_Master_Complaint_UnderSectionList_ByID(Flag_CodeId, userRole);

            objprp.districtMaster = objdis.dropdownlist_display1();
            objprp.stateMaster = objdis.State_list();
            objprp.subdivisondistrictMaster = objdis.dropdownlist_diplaySubdiv();

            objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";

            foreach (var item in objprp.prpNoticeSectionFiveNineByLA)
            {
                objprp.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
                objprp.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;

                objprp.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
                objprp.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
                objprp.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
                objprp.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
                objprp.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
                objprp.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
                objprp.SerialOrderNumber = item.SerialOrderNumber;

                objprp.DistrictTown_InfoName = item.DistrictTown_InfoName;
                objprp.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
                objprp.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;
                objprp.NoticeDate = item.NoticeDate;
                objprp.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
                objprp.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;

                objprp.PromoterName = item.PromoterName;
                objprp.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
                objprp.ProjectName = item.ProjectName;
                objprp.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

                objprp.Complainant_Name = item.Complainant_Name;
                objprp.Complainant_EmailAddress = item.Complainant_EmailAddress;
                objprp.Complainant_MobileNumber = item.Complainant_MobileNumber;
                objprp.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                objprp.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                objprp.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                objprp.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                objprp.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                objprp.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                objprp.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

                objprp.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
                objprp.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                objprp.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                objprp.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                objprp.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                objprp.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                objprp.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
                objprp.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
                objprp.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
                objprp.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

                objprp.CurrentStatusDate = item.CurrentStatusDate;
                objprp.CurrentStatusTitle = item.CurrentStatusTitle;
                objprp.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;

                objprp.IsPersonalHearing = item.IsPersonalHearing;
                objprp.HearingBenchCode = item.HearingBenchCode;
                objprp.HearingBenchName = item.HearingBenchName;
                objprp.FixedFor = item.FixedFor;
                objprp.OrderDate = item.OrderDate;
                objprp.OrderTime = item.OrderTime;
                objprp.OrderDateStatusTitle = item.OrderDateStatusTitle;
                objprp.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
                objprp.RemarksIfAny = item.RemarksIfAny;

                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;
                objprp.D_column = item.D_column;
                objprp.E_column = item.E_column;

                objprp.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
                objprp.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
                objprp.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
                objprp.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;
                objprp.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
                objprp.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
                objprp.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
                objprp.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;
                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("ComplaintsNoticeSecFiveNine", objprp);
        }

        [HttpPost]
        public ActionResult ComplaintsNoticeSecFiveNine(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    smodel.IsPublicView = 0;
                    sdb.Update_AdminDesk_NoticeSectionFiveNineDetailsByLA(smodel, UserNam);
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
        #endregion

        #region member Notice Section FiveNine - EVENT ACTION and LOG
        [HttpGet]
        public ActionResult NoticeSecFiveNineInfoEventDeskLog(Int64 noticeFiveNineID)
        {
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails aa = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails();
            string userRole = string.Empty;
            aa.prpNoticeSectionFiveNineFileLog = sdb.Display_NoticeSectionFiveNineDetailsByLA_DeskEventLogDetails(noticeFiveNineID, userRole);
            //aa.CurrentStatusEventDetails = sdb.Display_NoticeSectionFiveNineDetailsByLA_CurrentStatusEventLogDetails(noticeFiveNineID, userRole);
            return View("NoticeSecFiveNineInfoEventDeskLog", aa);
        }

        [HttpGet]
        public ActionResult NoticeSecFiveNineInfoEventInsert(Int64 noticeFiveNineID)
        {
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails aa = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails();
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA objget = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA();

            string userRole = string.Empty;
            Int64 userKey = 0;
            Int64 FineNineID = 0;
            userRole = getUserRole();
            FineNineID = (noticeFiveNineID.ToString() != null) ? Convert.ToInt64(noticeFiveNineID) : 0;
            userKey = getUserKey();
            //to bind List master
            aa.DeskEventMaster = sdb.Display_Master_AdminDesk_DeskActionsByUserID(userRole, userKey);

            objget.prpNoticeSectionFiveNineByLA = sdb.Display_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(0, FineNineID);

            aa.Related_NoticesSectionFiveNine_ID = FineNineID;
            foreach (var item in objget.prpNoticeSectionFiveNineByLA)
            {
                aa.Related_NoticeFile_NumberDetails = item.NoticesSectionFiveNine_IDName; // NoticeFile_NumberDetails;
                aa.ProgressStatus = item.ProjectName;
            }

            TempData["EventSubmitMessage"] = "";
            return View("NoticeSecFiveNineInfoEventInsert", aa);
        }

        [HttpPost]
        public ActionResult NoticeSecFiveNineInfoEventInsert(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails smodel)
        {
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails aa = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails();
            try
            {
                TempData["EventSubmitMessage"] = "";
                if (ModelState.IsValid)
                {
                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    string pUserRole = string.Empty;
                    Int64 pUserKey = 0;
                    pUserRole = getUserRole();
                    pUserKey = getUserKey();
                    string pUser_WhoIdentified = User.Identity.Name;

                    smodel.EventAction_IdentifiedBy = pUser_WhoIdentified;
                    smodel.EventAction_IdentifiedOn = DateTime.Now;


                    if (sdb.Add_NoticeSectionFiveNineDetailsByLA_InfoDeskEvent(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();
                        TempData["EventSubmitMessage"] = "Application Performa successfully Submitted.";
                    }
                    //to bind subCheckList master
                    aa.DeskEventMaster = sdb.Display_Master_AdminDesk_DeskActionsByUserID(pUserRole, pUserKey);
                    aa.Related_NoticesSectionFiveNine_ID = smodel.Related_NoticesSectionFiveNine_ID;
                }
                //return View("NoticeSecFiveNineInfoEventInsert", aa);
                //return View();
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                string varEx = ex.ToString();
                TempData["EventSubmitMessage"] = "Sorry, Application Performa is pending";
                //return View("NoticeSecFiveNineInfoEventInsert", aa);
                //return View();
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public JsonResult GetDeskEventDescriptionMasterByCode(string EventCode)
        {
            int Id = 0;
            if (EventCode != "")
                Id = Convert.ToInt32(EventCode);

            string pUserRole = string.Empty;
            pUserRole = getUserRole();

            ClsMethod_AdminDesk_NoticeSectionFiveNine objCode = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            var Subdiv = objCode.Display_AdminDesk_DeskEventDescription_MasterDetailsByCode(Id, pUserRole);

            return Json(Subdiv);
        }
        #endregion

        #region member Notice Section FiveNine - Hearing Date
        [HttpPost]
        public ActionResult HearingDetailAdd_NoticeSecFiveNine(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel)
        {
            try
            {
                Int32 varIsPersonalHearing = 0;
                varIsPersonalHearing = smodel.IsPersonalHearing;
                switch (varIsPersonalHearing)
                {
                    case 0: // NA
                        ModelState.Remove("HearingBenchCode");
                        ModelState.Remove("FixedFor");
                        ModelState.Remove("OrderDate");
                        ModelState.Remove("OrderTime");
                        break;
                    case 2: // Order Case
                        ModelState.Remove("OrderTime");
                        break;
                }
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                    smodel.CurrentEvent_IdentifiedBy = UserNam;
                    smodel.CurrentEvent_IdentifiedOn = DateTime.Now;
                    smodel.IsPublicView = 0;
                    sdb.Add_AdminDesk_HearingDate_NoticeSectionFiveNineDetails(smodel, UserNam);
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

        [HttpGet]
        public ActionResult NoticeSecFiveNineInfo_HearingDetail(Int64 pFiveNineID, string pKeyFlag)
        {
            ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
            ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_HearingDetails objprp = new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_HearingDetails();
            Int64 prmFiveNineID = 0;
            string prmFiveNineKeyID = string.Empty;
            string userRole = string.Empty;
            try
            {
                prmFiveNineID = pFiveNineID;
                prmFiveNineKeyID = pKeyFlag;
                objprp.prpNoticeFiveNineHearingDetail = sdb.Display_HearingDate_NoticeSectionFiveNineDetails_ByID(prmFiveNineID, prmFiveNineKeyID, userRole);

                foreach (var item in objprp.prpNoticeFiveNineHearingDetail)
                {
                    objprp.BenchHearingDate_IndexID = item.BenchHearingDate_IndexID;
                    objprp.BenchHearingDate_ID = item.BenchHearingDate_ID;
                    objprp.Related_ComplaintNoticesSectionFiveNine_ID = item.Related_ComplaintNoticesSectionFiveNine_ID;

                    objprp.Related_ComplaintNoticesSectionFiveNine_Code = item.Related_ComplaintNoticesSectionFiveNine_Code;
                    objprp.TypeOfComplaint = item.TypeOfComplaint;
                    objprp.TypeOfHearing = item.TypeOfHearing;
                    objprp.TypeOfComplaintHearing = item.TypeOfComplaintHearing;
                    objprp.Bench_HearingDate = item.Bench_HearingDate;
                    objprp.Bench_HearingTime = item.Bench_HearingTime;

                    objprp.HearingBench_ID = item.HearingBench_ID;
                    objprp.HearingBench_Name = item.HearingBench_Name;
                    objprp.HearingBench_FixedFor_ID = item.HearingBench_FixedFor_ID;
                    objprp.HearingBench_FixedFor_Name = item.HearingBench_FixedFor_Name;
                    objprp.HearingReplyDays = item.HearingReplyDays;
                    objprp.HearingBench_BussinesOnDate_ProceedingDate = item.HearingBench_BussinesOnDate_ProceedingDate;
                    objprp.HearingStatus = item.HearingStatus;
                    objprp.Remarks_IfAny = item.Remarks_IfAny;

                    objprp.A_column = item.A_column;
                    objprp.B_column = item.B_column;
                    objprp.C_column = item.C_column;
                    objprp.D_column = item.D_column;
                    objprp.E_column = Convert.ToString(getUserKey());

                    objprp.IsActive = item.IsActive;
                    objprp.IsDraft = item.IsDraft;
                    objprp.IsLock = item.IsLock;
                    objprp.IsPublicView = item.IsPublicView;
                    objprp.CreatedBy = item.CreatedBy;
                    objprp.CreatedOn = item.CreatedOn;
                    objprp.ModifyBy = item.ModifyBy;
                    objprp.ModifyOn = item.ModifyOn;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View("NoticeSecFiveNineInfo_HearingDetail", objprp);
        }

        [HttpGet]
        public JsonResult Delete_NoticeFiveNine_HearingDetailByPS(Int64 inFNIndexID, Int64 inFNID, Int64 inFNHearingID, string inFNHearingCode)
        {
            bool status = false;
            try
            {
                Int64 mIndexID = inFNIndexID;
                Int64 mKeyID = inFNID;
                Int64 mHearingID = inFNHearingID;
                string mHearingCode = inFNHearingCode;
                string mUserID = string.Empty;

                ClsMethod_AdminDesk_NoticeSectionFiveNine sdb = new ClsMethod_AdminDesk_NoticeSectionFiveNine();
                bool varCheckRecord = sdb.Delete_AdminDesk_HearingDate_NoticeSectionFiveNineByID(mIndexID, mKeyID, mHearingID, mHearingCode, mUserID);
                if (varCheckRecord)
                {
                    TempData["message"] = " Details deleted Successfully";
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region member CauseList

        #region Section 59
        [HttpGet]
        public ActionResult WebindexCauseListForFiveNineDetails()
        {
            ClsPrp_AdminDesk_CauseListForFiveNine objprp = new ClsPrp_AdminDesk_CauseListForFiveNine();
            ClsMethod_AdminDesk_CauseListForFiveNine sdb = new ClsMethod_AdminDesk_CauseListForFiveNine();

            Int64 pIndex_ID = 0;
            objprp.prpCauseListForFiveNine = sdb.Display_AdminDesk_CauseListForFiveNineDetails(pIndex_ID);

            TempData["submitvalueCauseListForFiveNineDetails"] = "Save"; TempData.Keep();
            return View("WebindexCauseListForFiveNineDetails", objprp);
        }

        [HttpGet]
        public ActionResult Edit_WebindexCauseListForFiveNineDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_CauseListForFiveNine objprp = new ClsPrp_AdminDesk_CauseListForFiveNine();
            ClsMethod_AdminDesk_CauseListForFiveNine sdb = new ClsMethod_AdminDesk_CauseListForFiveNine();

            objprp.prpCauseListForFiveNine = sdb.Display_AdminDesk_CauseListForFiveNineByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpCauseListForFiveNine)
            {
                objprp.CauseListSectionFiveNine_IndexID = item.CauseListSectionFiveNine_IndexID;
                objprp.CauseListSectionFiveNine_ID = item.CauseListSectionFiveNine_ID;
                objprp.CauseListDate = item.CauseListDate;
                objprp.CauseListDay = item.CauseListDay;

                objprp.ViewCauseListFiveNine_BaseUrl = item.ViewCauseListFiveNine_BaseUrl;
                objprp.ViewCauseListFiveNine_FilePath = item.ViewCauseListFiveNine_FilePath;
                objprp.ViewCauseListFiveNine_FileName = item.ViewCauseListFiveNine_FileName;
                objprp.ViewCauseListFiveNine_FileType = item.ViewCauseListFiveNine_FileType;

                objprp.RemarksIfAny = item.RemarksIfAny;
                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueCauseListForFiveNineDetails"] = "Update";
            TempData.Keep();
            return View("WebindexCauseListForFiveNineDetails", objprp);
        }

        public ActionResult Delete_WebindexCauseListForFiveNineDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_CauseListForFiveNine sdb = new ClsMethod_AdminDesk_CauseListForFiveNine();
                if (sdb.Delete_AdminDesk_CauseListForFiveNineByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexCauseListForFiveNineDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WebindexCauseListForFiveNineDetails(ClsPrp_AdminDesk_CauseListForFiveNine smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueCauseListForFiveNineDetails"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {
                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/CasueListFiveNine";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ViewCauseListFiveNine_FilePath))
                            {
                                pathindb = smodel.ViewCauseListFiveNine_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ViewCauseListFiveNine_FileName))
                            {
                                fileName = smodel.ViewCauseListFiveNine_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "FiveNine" + Guid.NewGuid().ToString() + ext;//+ smodel.ViewCauseListFiveNine_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion

                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.ViewCauseListFiveNine_FileName;
                            FileName_Ext = smodel.ViewCauseListFiveNine_FileType;
                            FileName_Path = smodel.ViewCauseListFiveNine_FilePath;
                            FileName_BasicUrl = smodel.ViewCauseListFiveNine_BaseUrl;
                        }
                        try
                        {
                            ClsMethod_AdminDesk_CauseListForFiveNine sdb = new ClsMethod_AdminDesk_CauseListForFiveNine();
                            sdb.Update_AdminDesk_CauseListForFiveNineDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexCauseListForFiveNineDetails");
                }
                else
                {
                    return RedirectToAction("WebindexCauseListForFiveNineDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/CasueListFiveNine";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "FiveNine" + Guid.NewGuid().ToString() + ext;//+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.ViewCauseListFiveNine_FileName;
                                FileName_Ext = smodel.ViewCauseListFiveNine_FileType;
                                FileName_Path = smodel.ViewCauseListFiveNine_FilePath;
                                FileName_BasicUrl = smodel.ViewCauseListFiveNine_BaseUrl;
                            }
                            ClsMethod_AdminDesk_CauseListForFiveNine sdb = new ClsMethod_AdminDesk_CauseListForFiveNine();
                            if (sdb.Add_AdminDesk_CauseListForFiveNineDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexCauseListForFiveNineDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexCauseListForFiveNineDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }
        #endregion

        #region Section 31   
        [HttpGet]
        public ActionResult WebindexCauseListForThreeOneDetails()
        {
            ClsPrp_AdminDesk_CauseListForThreeOne objprp = new ClsPrp_AdminDesk_CauseListForThreeOne();
            ClsMethod_AdminDesk_CauseListForThreeOne sdb = new ClsMethod_AdminDesk_CauseListForThreeOne();

            Int64 pIndex_ID = 0;
            objprp.prpCauseListForThreeOne = sdb.Display_AdminDesk_CauseListForThreeOneDetails(pIndex_ID);

            TempData["WebindexCauseListForThreeOneDetails"] = "Save"; TempData.Keep();
            return View("WebindexCauseListForThreeOneDetails", objprp);
        }

        [HttpGet]
        public ActionResult Edit_WebindexCauseListForThreeOneDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_CauseListForThreeOne objprp = new ClsPrp_AdminDesk_CauseListForThreeOne();
            ClsMethod_AdminDesk_CauseListForThreeOne sdb = new ClsMethod_AdminDesk_CauseListForThreeOne();

            objprp.prpCauseListForThreeOne = sdb.Display_AdminDesk_CauseListForThreeOneDetailsByID(pIndexID, pKeyID);

            foreach (var item in objprp.prpCauseListForThreeOne)
            {
                objprp.CauseListFormMN_IndexID = item.CauseListFormMN_IndexID;
                objprp.CauseListFormMN_ID = item.CauseListFormMN_ID;
                objprp.CauseListDate = item.CauseListDate;
                objprp.CauseListDay = item.CauseListDay;

                objprp.ViewCauseListFormMN_BaseUrl = item.ViewCauseListFormMN_BaseUrl;
                objprp.ViewCauseListFormMN_FilePath = item.ViewCauseListFormMN_FilePath;
                objprp.ViewCauseListFormMN_FileName = item.ViewCauseListFormMN_FileName;
                objprp.ViewCauseListFormMN_FileType = item.ViewCauseListFormMN_FileType;

                objprp.RemarksIfAny = item.RemarksIfAny;
                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["WebindexCauseListForThreeOneDetails"] = "Update";
            TempData.Keep();
            return View("WebindexCauseListForThreeOneDetails", objprp);
        }

        public ActionResult Delete_WebindexCauseListForThreeOneDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_CauseListForThreeOne sdb = new ClsMethod_AdminDesk_CauseListForThreeOne();
                if (sdb.Delete_AdminDesk_CauseListForThreeOneByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexCauseListForThreeOneDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WebindexCauseListForThreeOneDetails(ClsPrp_AdminDesk_CauseListForThreeOne smodel)
        {
            //Save & Update
            #region
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["WebindexCauseListForThreeOneDetails"].ToString() == "Update")
            {
                #region Document Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000) // 1MB
                        {
                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/CasueListThreeOne";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ViewCauseListFormMN_FilePath))
                            {
                                pathindb = smodel.ViewCauseListFormMN_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            }
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ViewCauseListFormMN_FileName))
                            {
                                fileName = smodel.ViewCauseListFormMN_FileName.ToString();
                            }
                            else
                            {
                                fileName = SaveFileDatePrefix() + "ThreeOne" + Guid.NewGuid().ToString() + ext; //+ smodel.ViewCauseListFormMN_FileName.ToString()
                            }

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion

                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (FileName_Address == string.Empty)
                        {
                            FileName_Address = smodel.ViewCauseListFormMN_FileName;
                            FileName_Ext = smodel.ViewCauseListFormMN_FileType;
                            FileName_Path = smodel.ViewCauseListFormMN_FilePath;
                            FileName_BasicUrl = smodel.ViewCauseListFormMN_BaseUrl;
                        }
                        try
                        {
                            ClsMethod_AdminDesk_CauseListForThreeOne sdb = new ClsMethod_AdminDesk_CauseListForThreeOne();
                            sdb.Update_AdminDesk_CauseListForThreeOneDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam);
                            TempData["message"] = "Details updated successfully";
                        }
                        catch (Exception ex)
                        {
                            string strRet = ex.ToString();
                            TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                            return View();
                        }
                    }
                    return RedirectToAction("WebindexCauseListForThreeOneDetails");
                }
                else
                {
                    return RedirectToAction("WebindexCauseListForThreeOneDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 2048000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/CasueListThreeOne";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "ThreeOne" + Guid.NewGuid().ToString() + ext; //+ Path.GetFileNameWithoutExtension(files.FileName).ToString()

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);
                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 2MB (Two MB).";
                            error = "Document size should be less than 2MB (Two MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.ViewCauseListFormMN_FileName;
                                FileName_Ext = smodel.ViewCauseListFormMN_FileType;
                                FileName_Path = smodel.ViewCauseListFormMN_FilePath;
                                FileName_BasicUrl = smodel.ViewCauseListFormMN_BaseUrl;
                            }
                            ClsMethod_AdminDesk_CauseListForThreeOne sdb = new ClsMethod_AdminDesk_CauseListForThreeOne();
                            if (sdb.Add_AdminDesk_CauseListForThreeOneDetails(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("WebindexCauseListForThreeOneDetails");
                    }
                    else
                    {
                        return RedirectToAction("WebindexCauseListForThreeOneDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion
        }
        #endregion

        #region Weekly Content
        [HttpGet]
        public ActionResult WebindexCauseListForWeeklyContentDetails()
        {
            ClsPrp_AdminDesk_CauseListForWeeklyCalender objprp = new ClsPrp_AdminDesk_CauseListForWeeklyCalender();
            ClsMethod_AdminDesk_CauselistWeeklyCalender sdb = new ClsMethod_AdminDesk_CauselistWeeklyCalender();

            Int64 pIndex_ID = 0;
            objprp.prpCauseListForWeeklyCalender = sdb.Display_AdminDesk_CauseListForWeeklyCalenderDetails(pIndex_ID);
            TempData["submitvalueCauseListForWeeklyCalender"] = "Save"; TempData.Keep();
            return View("WebindexCauseListForWeeklyContentDetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexCauseListForWeeklyContentDetails(ClsPrp_AdminDesk_CauseListForWeeklyCalender smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_CauselistWeeklyCalender sdb = new ClsMethod_AdminDesk_CauselistWeeklyCalender();
                    if (sdb.Add_AdminDesk_CauseListForWeeklyCalenderDetails(smodel, UserNam))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("WebindexCauseListForWeeklyContentDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit_windexCauseListForWeeklyContentDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_AdminDesk_CauseListForWeeklyCalender objprp = new ClsPrp_AdminDesk_CauseListForWeeklyCalender();
            ClsMethod_AdminDesk_CauselistWeeklyCalender sdb = new ClsMethod_AdminDesk_CauselistWeeklyCalender();

            objprp.prpCauseListForWeeklyCalender = sdb.Display_AdminDesk_CauseListForWeeklyCalenderByID(pIndexID, pKeyID);
            foreach (var item in objprp.prpCauseListForWeeklyCalender)
            {
                objprp.CauseListWeeklyCalender_IndexID = item.CauseListWeeklyCalender_IndexID;
                objprp.CauseListWeeklyCalender_ID = item.CauseListWeeklyCalender_ID;

                objprp.CasueListOneFlag = item.CasueListOneFlag;
                objprp.CauseListOneDate = item.CauseListOneDate;
                objprp.CauseListOneDay = item.CauseListOneDay;
                objprp.CasueListTwoFlag = item.CasueListTwoFlag;
                objprp.CauseListTwoDate = item.CauseListTwoDate;
                objprp.CauseListTwoDay = item.CauseListTwoDay;

                objprp.CasueListThreeFlag = item.CasueListThreeFlag;
                objprp.CauseListThreeDate = item.CauseListThreeDate;
                objprp.CauseListThreeDay = item.CauseListThreeDay;
                objprp.CasueListFourFlag = item.CasueListFourFlag;
                objprp.CauseListFourDate = item.CauseListFourDate;
                objprp.CauseListFourDay = item.CauseListFourDay;

                objprp.CasueListFiveFlag = item.CasueListFiveFlag;
                objprp.CauseListFiveDate = item.CauseListFiveDate;
                objprp.CauseListFiveDay = item.CauseListFiveDay;

                objprp.RemarksIfAny = item.RemarksIfAny;
                objprp.A_column = item.A_column;
                objprp.B_column = item.B_column;
                objprp.C_column = item.C_column;

                objprp.IsActive = item.IsActive;
                objprp.IsDraft = item.IsDraft;
                objprp.IsDraftMember = item.IsDraftMember;
                objprp.IsPublicView = item.IsPublicView;

                objprp.CreatedBy = item.CreatedBy;
                objprp.CreatedOn = item.CreatedOn;
                objprp.ModifyBy = item.ModifyBy;
                objprp.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueCauseListForWeeklyCalender"] = "Update";
            TempData.Keep();
            return View("WebindexCauseListForWeeklyContentDetails", objprp);
        }

        [HttpPost]
        public ActionResult Edit_windexCauseListForWeeklyContentDetails(ClsPrp_AdminDesk_CauseListForWeeklyCalender smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;

                    ClsMethod_AdminDesk_CauselistWeeklyCalender sdb = new ClsMethod_AdminDesk_CauselistWeeklyCalender();
                    sdb.Update_AdminDesk_CauseListForWeeklyCalenderDetails(smodel, UserNam);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("WebindexCauseListForWeeklyContentDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        public ActionResult Delete_windexCauseListForWeeklyContentDetails(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsMethod_AdminDesk_CauselistWeeklyCalender sdb = new ClsMethod_AdminDesk_CauselistWeeklyCalender();
                if (sdb.Delete_AdminDesk_CauseListForWeeklyCalenderByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Details deleted Successfully";
                }
                return RedirectToAction("WebindexCauseListForWeeklyContentDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #endregion

        #region member upload PDF files
        [HttpGet]
        public ActionResult WebindexListRegisteredProjectsDetails()
        {
            ClsPrp_AdminDesk_UploadFilePDF objprp = new ClsPrp_AdminDesk_UploadFilePDF();
            ClsMethod_AdminDesk_UploadFilePDF sdb = new ClsMethod_AdminDesk_UploadFilePDF();

            Int64 pIndex_ID = 0;
            objprp.prpUploadFilePDF = sdb.Display_AdminDesk_ProjectsUploadListDetails(pIndex_ID);
            TempData["submitvalueProjectUploadList"] = "Save"; TempData.Keep();
            return View("WebindexListRegisteredProjectsDetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexListRegisteredProjectsDetails(ClsPrp_AdminDesk_UploadFilePDF smodel)
        {
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            //Save & Update
            #region
            if (TempData["submitvalueProjectUploadList"].ToString() == "Save")
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 5120000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/RegisteredProject";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url

                            var completePathwebapplicationdata = string.Empty;
                            var completePathindb = string.Empty;
                            var completeFileNameindb = string.Empty;
                            string webapplicationDoc_SetFileCompletePath = "rwPDF/registeredprojectslist";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "RegProject" + Guid.NewGuid().ToString() + ext;

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);

                            // Registered Projects for HTML Directory Details
                            // Delete File if Already Exists
                            completePathindb = webapplicationDoc_SetFileCompletePath + "\\";
                            completeFileNameindb = "List_of_Registered_Projects.pdf";
                            completePathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + completePathindb + completeFileNameindb);

                            if (System.IO.File.Exists(completePathwebapplicationdata))
                            {
                                System.IO.File.Delete(completePathwebapplicationdata);
                            }
                            // Copy File 
                            System.IO.File.Copy(path, completePathwebapplicationdata);

                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 5MB (Five MB).";
                            error = "Document size should be less than 5MB (Five MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.UploadFilePDF_FileName;
                                FileName_Ext = smodel.UploadFilePDF_FileType;
                                FileName_Path = smodel.UploadFilePDF_FilePath;
                                FileName_BasicUrl = smodel.UploadFilePDF_BaseUrl;
                            }
                            smodel.FileReferenceName = "";
                            smodel.FileReferenceType = "List of Registered Projects";
                            ClsMethod_AdminDesk_UploadFilePDF sdb = new ClsMethod_AdminDesk_UploadFilePDF();
                            if (sdb.Add_AdminDesk_ProjectsUploadList(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("WebindexListRegisteredProjectsDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion

            return RedirectToAction("WebindexListRegisteredProjectsDetails");
        }

        [HttpGet]
        public ActionResult WebindexListRegisteredAgentsDetails()
        {
            ClsPrp_AdminDesk_UploadFilePDF objprp = new ClsPrp_AdminDesk_UploadFilePDF();
            ClsMethod_AdminDesk_UploadFilePDF sdb = new ClsMethod_AdminDesk_UploadFilePDF();

            Int64 pIndex_ID = 0;
            objprp.prpUploadFilePDF = sdb.Display_AdminDesk_AgentsUploadListDetails(pIndex_ID);
            TempData["submitvalueAgentUploadList"] = "Save"; TempData.Keep();
            return View("WebindexListRegisteredAgentsDetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexListRegisteredAgentsDetails(ClsPrp_AdminDesk_UploadFilePDF smodel)
        {
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            //Save & Update
            #region
            if (TempData["submitvalueAgentUploadList"].ToString() == "Save")
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 5120000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/RegisteredAgent";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url

                            var completePathwebapplicationdata = string.Empty;
                            var completePathindb = string.Empty;
                            var completeFileNameindb = string.Empty;
                            string webapplicationDoc_SetFileCompletePath = "rwPDF/registeredagentslist";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "RegAgent" + Guid.NewGuid().ToString() + ext;

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);

                            // Registered Projects for HTML Directory Details
                            // Delete File if Already Exists
                            completePathindb = webapplicationDoc_SetFileCompletePath + "\\";
                            completeFileNameindb = "List_of_Registered_RealEstateAgents.pdf";
                            completePathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + completePathindb + completeFileNameindb);

                            if (System.IO.File.Exists(completePathwebapplicationdata))
                            {
                                System.IO.File.Delete(completePathwebapplicationdata);
                            }
                            // Copy File 
                            System.IO.File.Copy(path, completePathwebapplicationdata);

                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 5MB (Five MB).";
                            error = "Document size should be less than 5MB (Five MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.UploadFilePDF_FileName;
                                FileName_Ext = smodel.UploadFilePDF_FileType;
                                FileName_Path = smodel.UploadFilePDF_FilePath;
                                FileName_BasicUrl = smodel.UploadFilePDF_BaseUrl;
                            }
                            smodel.FileReferenceName = "";
                            smodel.FileReferenceType = "List of Registered Real-Estate Agents";
                            ClsMethod_AdminDesk_UploadFilePDF sdb = new ClsMethod_AdminDesk_UploadFilePDF();
                            if (sdb.Add_AdminDesk_AgentsUploadList(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("WebindexListRegisteredAgentsDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion

            return RedirectToAction("WebindexListRegisteredAgentsDetails");
        }

        [HttpGet]
        public ActionResult WebindexListPendingProjectsDetails()
        {
            ClsPrp_AdminDesk_UploadFilePDF objprp = new ClsPrp_AdminDesk_UploadFilePDF();
            ClsMethod_AdminDesk_UploadFilePDF sdb = new ClsMethod_AdminDesk_UploadFilePDF();

            Int64 pIndex_ID = 0;
            objprp.prpUploadFilePDF = sdb.Display_AdminDesk_PendingProjectsUploadListDetails(pIndex_ID);
            TempData["submitvaluePendingProjectUploadList"] = "Save"; TempData.Keep();
            return View("WebindexListPendingProjectsDetails", objprp);
        }

        [HttpPost]
        public ActionResult WebindexListPendingProjectsDetails(ClsPrp_AdminDesk_UploadFilePDF smodel)
        {
            string FileName_Address = string.Empty;
            String ext = String.Empty;
            string FileName_Path = string.Empty;
            string FileName_BasicUrl = string.Empty;
            string FileName_Ext = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            //Save & Update
            #region
            if (TempData["submitvaluePendingProjectUploadList"].ToString() == "Save")
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        int size = files.ContentLength;
                        if (size <= 5120000)
                        {

                            #region Declare Variables
                            var pathwebapplicationdata = string.Empty;
                            var pathindb = string.Empty;
                            string webapplicationDoc_SetFilePath = "rwPDF/PendingProject";
                            string webapplicationBasicDocPathUrl = "~/"; // Server Config Basic Url
                            FileName_BasicUrl = "~/"; // Server Config Basic Url

                            var completePathwebapplicationdata = string.Empty;
                            var completePathindb = string.Empty;
                            var completeFileNameindb = string.Empty;
                            string webapplicationDoc_SetFileCompletePath = "rwPDF/pendingprojectslist";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = webapplicationDoc_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\";
                            pathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + pathindb);

                            if (!Directory.Exists(pathwebapplicationdata))
                            {
                                Directory.CreateDirectory(pathwebapplicationdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = SaveFileDatePrefix() + "PendingProject" + Guid.NewGuid().ToString() + ext;

                            var path = Path.Combine(pathwebapplicationdata, fileName);
                            files.SaveAs(path);

                            // Pending Projects for HTML Directory Details
                            // Delete File if Already Exists
                            completePathindb = webapplicationDoc_SetFileCompletePath + "\\";
                            completeFileNameindb = "List_of_PendingFiles_Projects.pdf";
                            completePathwebapplicationdata = Server.MapPath(webapplicationBasicDocPathUrl + completePathindb + completeFileNameindb);

                            if (System.IO.File.Exists(completePathwebapplicationdata))
                            {
                                System.IO.File.Delete(completePathwebapplicationdata);
                            }
                            // Copy File 
                            System.IO.File.Copy(path, completePathwebapplicationdata);

                            FileName_Address = fileName;
                            FileName_Path = pathindb;
                            FileName_Ext = ext;
                        }
                        else
                        {
                            TempData["notice"] = "Document size should be less than 5MB (Five MB).";
                            error = "Document size should be less than 5MB (Five MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        error = "Bad request! Invalid document format (should be .PDF or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (FileName_Address == string.Empty)
                            {
                                FileName_Address = smodel.UploadFilePDF_FileName;
                                FileName_Ext = smodel.UploadFilePDF_FileType;
                                FileName_Path = smodel.UploadFilePDF_FilePath;
                                FileName_BasicUrl = smodel.UploadFilePDF_BaseUrl;
                            }
                            smodel.FileReferenceName = "";
                            smodel.FileReferenceType = "List of Pending Project Files";
                            ClsMethod_AdminDesk_UploadFilePDF sdb = new ClsMethod_AdminDesk_UploadFilePDF();
                            if (sdb.Add_AdminDesk_PendingProjectsUploadList(smodel, FileName_Address, FileName_Path, FileName_Ext, FileName_BasicUrl, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("WebindexListPendingProjectsDetails");
                    }
                }
                catch (Exception ex)
                {
                    string strRet = ex.ToString();
                    TempData["message"] = "Bad request! Invalid updation. (" + strRet + ")";
                    return View();
                }
            }
            #endregion

            return RedirectToAction("WebindexListPendingProjectsDetails");
        }
        #endregion

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

        private Int64 getUserKey()
        {
            // 7801: Programmer
            // 7804: Legal Advisor
            // 7802: PS to Members
            // 7803: Authority
            // 7807: Complaint Closed
            // 7808: Notice Filed or uploaded

            Int64 varRet = 0;
            if (User.IsInRole("Promoter"))
                varRet = 0;
            if (User.IsInRole("RealEstateAgent"))
                varRet = 0;
            if (User.IsInRole("Complainant"))
                varRet = 0;
            if (User.IsInRole("HelpDesk"))
                varRet = 0;
            if (User.IsInRole("SecretaryRERA"))
                varRet = 7803;
            if (User.IsInRole("ManagerDesk"))
                varRet = 0;
            if (User.IsInRole("Administrator"))
                varRet = 0;
            if (User.IsInRole("LegalAdvisorDesk"))
                varRet = 7804;
            if (User.IsInRole("PStoMembers"))
                varRet = 7802;
            if (User.IsInRole("Programmer"))
                varRet = 7801;
            if (User.IsInRole("Authority"))
                varRet = 7803;
            return varRet;
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

        private string getSourceIPaddress()
        {
            //string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            try
            {
                string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress))
                {
                    ipAddress = Request.ServerVariables["REMOTE_ADDR"];
                    if (string.IsNullOrEmpty(ipAddress))
                    {
                        ipAddress = Request.UserHostAddress;
                    }
                }
                return ipAddress;
            }
            catch (Exception)
            {
                // Always return all zeroes for any failure
                return "0.0.0.0";
            }
        }

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

        #endregion
    }
}