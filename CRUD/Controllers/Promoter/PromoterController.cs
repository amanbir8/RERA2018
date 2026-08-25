using System;
using System.Linq;
using System.Web.Mvc;
using CRUD.Models.Promoter;
using CRUD.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using CRUD.Models.UserAccess;
using System.Collections.Generic;
using CRUD.Models.PromoterProject;
using System.Web.Configuration;
using CRUD.Models.JointPromoter;
using CRUD.Models.Agent;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class PromoterController : Controller
    {
        /// Variable declaration        
        #region 
        string Photo_Address = string.Empty;
        string PAN_Doc_Address = string.Empty;
        string update_Photo_Address = string.Empty;
        string update_PAN_Doc_Address = string.Empty;
        string PANaddress = string.Empty;
        string OrgCertaddress = string.Empty;
        string Image_FileName = string.Empty;
        #endregion

        /// OptionView
        #region
        /// <summary>
        /// OptionView
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OptionView()
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
                            strRetvalue = "RegIndProEdit";
                        }
                        else if (Session["User_Type"].ToString() == "2")
                        {
                            //if Other than Individual Case
                            strRetvalue = "RegOrgExpEdit";
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
        }
        //public ActionResult OptionView()
        //{
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        string strRetvalue = string.Empty;
        //        if (Session["User_Type"].ToString() == "1")
        //        {
        //            //if Individual Case
        //            strRetvalue = "RegIndProEdit";
        //        }
        //        else if (Session["User_Type"].ToString() == "2")
        //        {
        //            //if Other than Individual Case
        //            strRetvalue = "RegOrgExpEdit";
        //        }
        //        return RedirectToAction(strRetvalue);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult OptionView(FormCollection frm)
        {
            string abc=string.Empty;
            abc = frm["rdbPromoter"];

            //Session["ApplicationId"] = string.Empty;

            if (abc == "1")
                return RedirectToAction("RegIndPro");
            
            else
                return RedirectToAction("RegOrgExp");
            
            //return View();
        }
        #endregion

        /// Individual prompoter
        #region 
        // GET:Create Promoter Individual
        public ActionResult RegIndPro()
        {
            Clsprp_Promoter clspro = new Clsprp_Promoter();

           // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
           //  clspro.districtMaster = objdis.dropdownlist_display1();

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            clspro.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            clspro.districtMaster = objdis.dropdownlist_display1();

            clspro.Mobile_no = Convert.ToInt64(Session["Mobile_Number"]);//clspro.Phone_No = Convert.ToInt64(Session["Phone_no"].ToString());
            clspro.Email = Session["Email_Address"].ToString();//"h@c.b";//clspro.Email = Session["Email"].ToString();

           

            return View(clspro);
        }

        // POST: Save Promoter Individual
        [HttpPost]
        public ActionResult RegIndPro(Clsprp_Promoter smodel)
        {
            ClsMethod_Promoter sdb = new ClsMethod_Promoter();
            Clsprp_Promoter clspro = new Clsprp_Promoter();

            String ext = String.Empty;
            string FilePathExt = string.Empty;

            string error = string.Empty;
            int errorstate = 0;
            string varUserID = User.Identity.GetUserId();

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
                        var pathpromoterdata = "";
                        var pathindb = "";
                        string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
                        #endregion

                        #region SaveFile Path Creation
                        pathindb = masterPromoterDoc_SetFilePath + "\\" + varUserID + "\\"; //Convert.ToString("Image") + "\\";
                        pathpromoterdata = Server.MapPath("~/" + pathindb);

                        if (!Directory.Exists(pathpromoterdata))
                        {
                            Directory.CreateDirectory(pathpromoterdata);
                        }
                        #endregion

                        var fileName = string.Empty;
                        fileName = "Photo_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                        var path = Path.Combine(pathpromoterdata, fileName);
                        files.SaveAs(path);
                        Photo_Address = fileName;
                        FilePathExt = pathindb;

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

                ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
                clspro.stateMaster = objdis1.State_list();

                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
                clspro.districtMaster = objdis.dropdownlist_display1();
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;

                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        Int64 Appid = sdb.AddIndPro(smodel, Photo_Address, PAN_Doc_Address, UID, UserNam, FilePathExt);
                        if (Appid > 0)
                        {
                            ViewBag.ApplicationId = Appid;
                            ViewBag.Message = "Your Data is Successfully Submitted";

                            Session["ApplicationId"] = Appid;
                            Session["User_Type"] = 1;
                            Session["User_TrackRecordFlag"] = ((smodel.Experience.ToString()) != "N" ? 1 : 0);

                            smodel.Application_id = Convert.ToInt64(Appid);

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

        //          OPENAI ADDITION FOR PHOTO UPLOAD CHECK        //

        //[HttpPost]
        //public async Task<ActionResult> RegIndPro(Clsprp_Promoter smodel)
        //{
        //    ClsMethod_Promoter sdb = new ClsMethod_Promoter();
        //    Clsprp_Promoter clspro = new Clsprp_Promoter();

        //    string ext = string.Empty;
        //    string FilePathExt = string.Empty;
        //    string error = string.Empty;
        //    int errorstate = 0;
        //    string varUserID = User.Identity.GetUserId();

        //    string Photo_Address = null;   // ensure these exist in scope
        //    string PAN_Doc_Address = null; // keep for your AddIndPro call

        //    #region Photo Save with Path (with AI validation first)

        //    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
        //    {
        //        var files = Request.Files[0];
        //        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
        //        ext = Path.GetExtension(files.FileName);

        //        if (allowedExtensions.Contains(ext))
        //        {
        //            int size = files.ContentLength;
        //            if (size <= 512000)
        //            {
        //                // Read bytes (we will save only if AI passes)
        //                byte[] fileBytes;
        //                using (var ms = new MemoryStream())
        //                {
        //                    files.InputStream.Position = 0;
        //                    files.InputStream.CopyTo(ms);
        //                    fileBytes = ms.ToArray();
        //                }

        //                // AI: Photograph vs Document
        //                var verdict = await OpenAiVision.ClassifyAsync(fileBytes, "image/jpeg");

        //                if (!(verdict.IsPhotograph && verdict.Confidence >= 0.70))
        //                {
        //                    TempData["notice"] = "Please upload a real-world photograph (not a document/screenshot). " +
        //                                         $"Reason: {verdict.Reason}";
        //                    error = "Invalid image type (not a photograph).";
        //                    errorstate = 1;
        //                }
        //                else
        //                {
        //                    // Passed AI check -> save to disk
        //                    string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
        //                    string pathindb = masterPromoterDoc_SetFilePath + "\\" + varUserID + "\\";
        //                    string pathpromoterdata = Server.MapPath("~/" + pathindb);

        //                    if (!Directory.Exists(pathpromoterdata))
        //                        Directory.CreateDirectory(pathpromoterdata);

        //                    string fileName = "Photo_" + SaveFileDatePrefix() + Guid.NewGuid() + ext;
        //                    System.IO.File.WriteAllBytes(Path.Combine(pathpromoterdata, fileName), fileBytes);

        //                    Photo_Address = fileName;
        //                    FilePathExt = pathindb;
        //                }
        //            }
        //            else
        //            {
        //                TempData["notice"] = "Photo Size Should be less than 512KB";
        //                error = "Photo Size Should be less than 512KB";
        //                errorstate = 1;
        //            }
        //        }
        //        else
        //        {
        //            TempData["notice"] = "Photo format should be .jpg";
        //            error = "Photo format should be .jpg";
        //            errorstate = 1;
        //        }
        //    }
        //    else
        //    {
        //        TempData["notice"] = "Kindly Upload Photograph";
        //        error = "Kindly Upload Photograph";
        //        errorstate = 1;
        //    }

        //    #endregion

        //    try
        //    {
        //        // your existing dropdown/init work
        //        ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
        //        clspro.stateMaster = objdis1.State_list();

        //        ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //        clspro.districtMaster = objdis.dropdownlist_display1();

        //        string UID = User.Identity.GetUserId();
        //        string UserNam = User.Identity.Name;

        //        if (errorstate == 0)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                long Appid = sdb.AddIndPro(smodel, Photo_Address, PAN_Doc_Address, UID, UserNam, FilePathExt);
        //                if (Appid > 0)
        //                {
        //                    ViewBag.ApplicationId = Appid;
        //                    ViewBag.Message = "Your Data is Successfully Submitted";

        //                    Session["ApplicationId"] = Appid;
        //                    Session["User_Type"] = 1;
        //                    Session["User_TrackRecordFlag"] = ((smodel.Experience.ToString()) != "N" ? 1 : 0);

        //                    smodel.Application_id = Convert.ToInt64(Appid);
        //                    ModelState.Clear();
        //                }
        //            }
        //        }
        //        return View(clspro);
        //    }
        //    catch (Exception ex)
        //    {
        //        // log ex.Message if needed
        //        return View(clspro);
        //    }
        //}



        // GET
        public ActionResult RegIndProEdit(long? Application_id)
        {
            //Int64 Application_id = 0;
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
            
            Clsprp_Promoter objprp = new Clsprp_Promoter();
            ClsMethod_Promoter objDB = new ClsMethod_Promoter(); //calling class DBdata
           
            objprp = objDB.DisplayIndPro(Convert.ToInt64(Application_id));

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            objprp.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
           
            objprp.districtMaster = objdis.dropdownlist_display1(Convert.ToInt32(objprp.State));
            ////ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ////objprp.districtMaster = objdis.dropdownlist_display1();


            return View(objprp);

        }

        // POST:Update Promoter Individual
        [HttpPost]
        public ActionResult RegIndProEdit(Clsprp_Promoter smodel)
        {
            Clsprp_Promoter objprp = new Clsprp_Promoter();
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //objprp.districtMaster = objdis.dropdownlist_display1();
            ClsMethod_Promoter sdb = new ClsMethod_Promoter();

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            objprp.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            objprp.districtMaster = objdis.dropdownlist_display1();            

            //------------------------- sohi code

            //string error = string.Empty;
            //int errorstate = 0;

            //if (ModelState.IsValid)
            //{
            //    if (Request.Files.Count == 1 && Request.Files[0].ContentLength != 0) //if (Request.Files.Count == 1 )//&& Request.Files[1].ContentLength != 0)
            //    {
            //        for (int i = 0; i < Request.Files.Count; i++)
            //        {
            //            var files = Request.Files[i];
            //            var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            //            var ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            //            if (allowedExtensions.Contains(ext)) //check what type of extension  
            //            {
            //                int size = files.ContentLength;
            //                if (size <= 512000)
            //                {
            //                    var fileName = string.Empty;
            //                    if (i == 0)
            //                    {
            //                        fileName = "Photo_" + i + smodel.First_Name + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);

            //                    }
            //                    else
            //                    {
            //                        fileName = "PAN_" + i + smodel.First_Name + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
            //                    }
            //                    var path = Path.Combine(Server.MapPath("~/readwritedata"), fileName);
            //                    files.SaveAs(path);
            //                    if (i == 0)
            //                    { Photo_Address = fileName; }
            //                    else
            //                    { PAN_Doc_Address = fileName; }
            //                }
            //                else
            //                {
            //                    TempData["notice"] = "Photo Size Should be less than 512KB";
            //                    error = "Photo Size Should be less than 512KB";
            //                    errorstate = 1;
            //                }
            //            }
            //            else
            //            {
            //                TempData["notice"] = "Photo format should be .jpg";
            //                error = "Photo format should be .jpg";
            //                errorstate = 1;
            //            }
            //        }
            //    }
            //}

            //------------------------- sohi code ends

            String ext = String.Empty;
            string FilePathExt = string.Empty;

            string error = string.Empty;
            int errorstate = 0;

            string varUserID = User.Identity.GetUserId();

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
                        var pathpromoterdata = "";
                        var pathindb = "";
                        string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
                        #endregion

                        #region UpdateFile Path Creation 
                        if (!String.IsNullOrEmpty(smodel.Image_FileName))
                        {
                            pathindb = smodel.Image_FileName.ToString();
                        }
                        else
                        {
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + varUserID + "\\";
                        }
                        pathpromoterdata = Server.MapPath("~/" + pathindb);

                        if (!Directory.Exists(pathpromoterdata))
                        {
                            Directory.CreateDirectory(pathpromoterdata);
                        }
                        #endregion

                        var fileName = string.Empty;
                        if (!String.IsNullOrEmpty(smodel.Photo_Address))
                        {
                            fileName = smodel.Photo_Address.ToString();
                        }
                        else
                        {
                            fileName = "Photo_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                        }
                        //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
                        var path = Path.Combine(pathpromoterdata, fileName);
                        files.SaveAs(path);
                        Photo_Address = fileName;
                        FilePathExt = pathindb;

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
            //}
            #endregion


            try
            {
                if (Photo_Address == "")
                {
                    Photo_Address = smodel.Photo_Address;
                    FilePathExt = smodel.Image_FileName.ToString();
                }

                //if (PAN_Doc_Address == "") { PAN_Doc_Address = smodel.PAN_Doc_Address; }
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;

                if (errorstate == 0)
                {
                    sdb.UpdateDetails(smodel, Photo_Address, "NA", UID, UserNam, FilePathExt);//,Application_id);

                    Session["User_Type"] = smodel.Flag;
                    Session["User_TrackRecordFlag"] = ((smodel.Experience.ToString()) != "N" ? 1 : 0);

                    ModelState.Clear();
                }
                return View(objprp);
                //return RedirectToAction("RegIndPro");
            }
            catch (Exception ex)
            {
                String e = ex.Message;
                return View();
            }
        }
        #endregion

        ///  Other than Individual prompoter
        #region  
        // GET: Create Promoter Organization Experienced
        public ActionResult RegOrgExp()
        {
            ClsPrp_OrgExp clspro = new ClsPrp_OrgExp();
            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            // clspro.districtMaster = objdis.dropdownlist_display1();

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            clspro.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            clspro.districtMaster = objdis.dropdownlist_display1();

            //clspro.Mobile_no = 7879879;//clspro.Phone_No = Convert.ToInt64(Session["Phone_no"].ToString());
            //clspro.Email = "h@c.b";//clspro.Email = Session["Email"].ToString();
            clspro.Mobile_no = Convert.ToInt64(Session["Mobile_Number"]);//clspro.Phone_No = Convert.ToInt64(Session["Phone_no"].ToString());
            clspro.Email = Session["Email_Address"].ToString();//"h@c.b";//clspro.Email = Session["Email"].ToString();

            return View(clspro);
        }

        // POST: Save Promoter Organization Experienced
        [HttpPost]
        public ActionResult RegOrgExp(ClsPrp_OrgExp smodel)
        {
            ClsMethod_OrgExp sdb = new ClsMethod_OrgExp();
            ClsPrp_OrgExp clspro = new ClsPrp_OrgExp();
            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            clspro.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            clspro.districtMaster = objdis.dropdownlist_display1();

            #region //------------------------- sohi code

            string error = string.Empty;
            int errorstate = 0;
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 1 && Request.Files[1].ContentLength != 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var files = Request.Files[i];
                        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                        var ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            int size = files.ContentLength;
                            if (size <= 512000)
                            {
                                var fileName = string.Empty;
                                if (i == 0)
                                {
                                    fileName = "PAN_" + i + smodel.Org_Name + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);

                                }
                                else
                                {
                                    fileName = "OrgCert_" + i + smodel.Org_Name + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
                                }
                                var path = Path.Combine(Server.MapPath("~/readwritedata"), fileName);
                                files.SaveAs(path);
                                if (i == 0)
                                { PANaddress = fileName; }
                                else
                                { OrgCertaddress = fileName; }
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
                }
                else
                {
                    TempData["notice"] = "Please upload photo";
                    error = "Please upload photo";
                    errorstate = 1;
                }
            }

            #endregion

            try
            {
                // clspro.districtMaster = objdis.dropdownlist_display1();
                //string UID = Session["UID"].ToString();

                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;

                //if (errorstate == 0)
                //{
                if (ModelState.IsValid)
                {
                    Int64 Appid = sdb.AddOrgExp(smodel, PANaddress, OrgCertaddress, Image_FileName, UID, UserNam);
                    if (Appid > 0)
                    {
                        ViewBag.ApplicationId = Appid;
                        ViewBag.Message = "Your Data is Successfully Submitted";
                        Session["ApplicationId"] = Appid;
                        Session["User_Type"] = 2;
                        Session["User_ParentEntityFlag"] = ((smodel.Org_Parent_Entity.ToString()) !="N"? 1 : 0);
                        Session["User_TrackRecordFlag"] = ((smodel.Experience.ToString()) != "N" ? 1 : 0); 

                        smodel.Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        ModelState.Clear();
                    }
                }
                //}
                return View(clspro);
            }
            catch (Exception ex)
            {
                String e = ex.Message;
                return View();
            }
        }

        // POST:Update-Display Organization Experienced
        public ActionResult RegOrgExpEdit(long? Application_id)
        {
            //Int64 Application_id = 0;
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

            ClsPrp_OrgExp objprp = new ClsPrp_OrgExp();
            ClsMethod_OrgExp objDB = new ClsMethod_OrgExp(); //calling class DBdata
           // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp = objDB.DisplayOrgExp(Convert.ToInt64(Application_id));
            // objprp.districtMaster = objdis.dropdownlist_display1();
            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            objprp.stateMaster = objdis1.State_list();


            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            objprp.districtMaster = objdis.dropdownlist_display1(Convert.ToInt32(objprp.State));
            ClsMethodDistrictMaster objdis2 = new ClsMethodDistrictMaster();
            objprp.districtMaster1 = objdis2.dropdownlist_display1(Convert.ToInt32(objprp.Org_State));

            return View(objprp);
        }

        // POST:Update Organization Experienced
        [HttpPost]
        public ActionResult RegOrgExpEdit(ClsPrp_OrgExp smodel)
        {
            //Int64 Application_id = Convert.ToInt64(Session["ApplicationId"]);
            //Int64 Application_id = 1046;
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
            ClsPrp_OrgExp objprp = new ClsPrp_OrgExp();
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //objprp.districtMaster = objdis.dropdownlist_display1();
            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            objprp.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            objprp.districtMaster = objdis.dropdownlist_display1();
            
            objprp.districtMaster1 = objdis.dropdownlist_display1();
            ClsMethod_OrgExp sdb = new ClsMethod_OrgExp();

            #region //------------------------- sohi code

            string error = string.Empty;
            int errorstate = 0;
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 1 && Request.Files[1].ContentLength != 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var files = Request.Files[i];
                        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                        var ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            int size = files.ContentLength;
                            if (size <= 512000)
                            {
                                var fileName = string.Empty;
                                if (i == 0)
                                {
                                    fileName = "PAN_" + i + smodel.Org_Name + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);

                                }
                                else
                                {
                                    fileName = "OrgCert_" + i + smodel.Org_Name + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
                                }
                                var path = Path.Combine(Server.MapPath("~/readwritedata"), fileName);
                                files.SaveAs(path);
                                if (i == 0)
                                { PANaddress = fileName; }
                                else
                                { OrgCertaddress = fileName; }
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
                }
            }

            #endregion

            try
            {
                if (PANaddress == "") { PANaddress = smodel.PAN_Doc_Address; }
                if (OrgCertaddress == "") { OrgCertaddress = smodel.Org_Reg_Certificate; }

                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;

                //if (errorstate == 0)
                //{
                sdb.EditOrgExp(smodel, PANaddress, OrgCertaddress, Image_FileName, Convert.ToInt64(Application_id), UID, UserNam);//, Application_id))
                {
                    ViewBag.Message = "Successfull";
                    Session["ApplicationId"] = Convert.ToInt64(Application_id);
                    Session["User_Type"] = smodel.Flag;
                    Session["User_ParentEntityFlag"] = ((smodel.Org_Parent_Entity.ToString()) != "N" ? 1 : 0);
                    Session["User_TrackRecordFlag"] = ((smodel.Experience.ToString()) != "N" ? 1 : 0);
                }
                ModelState.Clear();
                //}
                return View(objprp);
            }
            catch (Exception ex)
            {
                String e = ex.Message;
                return View();
            }
        }
        #endregion

        /// Details and Profile of On-Going and Completed Projects in Past Five Years 
        #region
        /// <summary>
        /// Details and Profile of On-Going and Completed Projects in Past Five Years 
        /// </summary>
        /// <returns></returns>
        /// 


        [HttpPost]
        public ActionResult Details_FiveYears()
        {
            return RedirectToAction("Create_FiveYears");

        }

        //GET: Details/5
        public ActionResult Details_FiveYears(ClsPrp_ParentEntityDetail smodel)
        { 
           // Application_id = "110027";
            ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
            ClsPrp_OngoingProjectLFiveYears aa = new ClsPrp_OngoingProjectLFiveYears();
            aa.prpongoing = sdb.DisplaybyID_ongoingProject(smodel.Application_ID, smodel.ID);
            foreach (var item in aa.prpongoing)
            {
                aa.Projectname = item.Projectname;
                aa.ProjectType = item.ProjectType;
                aa.ProjectStatus = item.ProjectStatus;
                aa.AreaConUProject = item.AreaConUProject;
                aa.ProjectStartDate = item.ProjectStartDate;
                aa.OCDateProject = item.OCDateProject;
                aa.ACDProject = item.ACDProject;
                aa.RExtentofDelayProject = item.RExtentofDelayProject;
                aa.TypeLandofProject = item.TypeLandofProject;
                aa.LitgToProject = item.LitgToProject;
                aa.DetailPaymentPendingProject = item.DetailPaymentPendingProject;
                aa.NameofAuthorityForumwhereCasisPendingresolved = item.DetailPaymentPendingProject;
                aa.CaseTitle = item.CaseTitle;
                aa.CaseNumber = item.CaseNumber;
            }


            ViewBag.submitvalue = "Cancel";



            return View("Create_FiveYears", aa);

        }

        // GET: Create
        public ActionResult Create_FiveYears()
        {
            //Int64 Application_id = 110029;
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    if (Session["User_TrackRecordFlag"].ToString() != "1")
                    {
                        //In Not Track Record
                        return RedirectToAction("Create_FiveYearsNA", "Promoter");
                    }
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

            ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
            ClsPrp_OngoingProjectLFiveYears aa = new ClsPrp_OngoingProjectLFiveYears();
            aa.prpongoing = sdb.DisplaybyID_ongoingProject(Application_id);

            #region
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion

            ViewBag.submitvalue = "Save";
            return View("Create_FiveYears", aa);
           

            //clspro.districtMaster = objdis.dropdownlist_display1();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create_FiveYears(ClsPrp_OngoingProjectLFiveYears smodel)
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            try
            {
                if (ModelState.IsValid)
                {                    
                        ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
                        if (sdb.AddOnGoingProject(smodel, Application_id))
                        {
                            TempData["message"] = "Project Details Added Successfully";
                            ModelState.Clear();
                        }                    
                
                }
                // return View("Create");
                return RedirectToAction("Create_FiveYears");
            }
            catch (Exception ex)
            {
                return View();
            }                       
        }

        // GET: Edit/5
        public ActionResult Edit_FiveYears(ClsPrp_ParentEntityDetail smodel)
        {
           //  Application_id = "110029";
            ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
            ClsPrp_OngoingProjectLFiveYears aa = new ClsPrp_OngoingProjectLFiveYears();
            aa.prpongoing = sdb.DisplaybyID_ongoingProject(smodel.Application_ID, smodel.ID);
            foreach (var item in aa.prpongoing)
            {
                aa.Promoter_Experience_ID = item.Promoter_Experience_ID;
                aa.Id = item.Id;
                aa.Application_id = item.Id;
                aa.Projectname = item.Projectname;
                aa.ProjectType = item.ProjectType;
                aa.ProjectStatus = item.ProjectStatus;
                aa.AreaConUProject = item.AreaConUProject;
                aa.ProjectStartDate = item.ProjectStartDate;
                aa.OCDateProject = item.OCDateProject;
                aa.ACDProject = item.ACDProject;
                aa.RExtentofDelayProject = item.RExtentofDelayProject;
                aa.TypeLandofProject = item.TypeLandofProject;
                aa.LitgToProject = item.LitgToProject;
                aa.IsPaymentDetailsPending_RelatedLand = item.IsPaymentDetailsPending_RelatedLand;
                aa.DetailPaymentPendingProject = item.DetailPaymentPendingProject;
                aa.NameofAuthorityForumwhereCasisPendingresolved = item.DetailPaymentPendingProject;
                aa.CaseTitle = item.CaseTitle;
                aa.CaseNumber = item.CaseNumber;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.Created_By = item.Created_By;
                aa.Created_On = item.Created_On;
                aa.Modify_By = item.Modify_By;
                aa.Modified_On = item.Modified_On;

            }


            ViewBag.submitvalue = "Update";
            return View("Create_FiveYears", aa);

        }

        // POST: Edit/5
        [HttpPost]
        public ActionResult Edit_FiveYears(ClsPrp_OngoingProjectLFiveYears smodel)
        {
            //string Application_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
                    sdb.UpdateOnGoingProject(smodel);
                    TempData["message"] = "Project Details updated Successfully";
                }
                return RedirectToAction("Create_FiveYears");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Delete/5 
        //public ActionResult Delete_FiveYears(Int64 Application_id, int Id)
        public ActionResult Delete_FiveYears(ClsPrp_OngoingProjectLFiveYears smodel)    
        {
           // Application_id = "110027";
            try
            {
                ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
                if (sdb.Delete_OngoingProject(smodel.Application_id, smodel.Id))
                {
                    TempData["message"] = "Project Details Deleted Successfully";
                   // ViewBag.AlertMsg = "Project Details Deleted Successfully";
                }
                return RedirectToAction("Create_FiveYears");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        ///  Chairman, Partner, Director or Other Authorized Signatory Details
        #region
        /// <summary>
        ///  Chairman, Partner, Director or Other Authorized Signatory Details
        /// </summary>
        /// <returns></returns>
        /// 


        [HttpPost]
        public ActionResult Details_Mem()
        {
            return RedirectToAction("Create_Mem");

        }

        //GET: Details/5  
        public ActionResult Details_Mem(ClsPrp_OrgMemDetail smodel)
        {
            // Application_id = "110027";
            ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
            ClsPrp_OrgMemDetail aa = new ClsPrp_OrgMemDetail();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.districtMaster = objdis.dropdownlist_display1();
            aa.prpMem = sdb.DisplaybyID_MemProject(smodel.Application_id,smodel.Id);
            foreach (var item in aa.prpMem)
            {
                aa.Designation = item.Designation;
                aa.Member_Names = item.Member_Names;
                aa.PAN_No = item.PAN_No;
                aa.Aadhar_No = item.Aadhar_No;
                aa.Address_Line1 = item.Address_Line1;
                aa.Address_Line2 = item.Address_Line2;
                aa.State = item.State;
                aa.District = item.District;
                aa.Pin_Code = item.Pin_Code;
                aa.Mobile_no = item.Mobile_no;
                aa.Phone_No = item.Phone_No;
                aa.Email = item.Email;
                aa.Photo_Address = item.Photo_Address;
                aa.Image_FileName = item.Image_FileName;
            }


            ViewBag.submitvalue = "Cancel";



            return View("Create_Mem", aa);

        }

        // GET: Create
        public ActionResult Create_Mem()
        {
            //Int64 Application_id = 110029;
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);

                    if (Session["User_Type"].ToString() == "1")
                    {
                        //if Individual Case
                        return RedirectToAction("Create_ParentEntityNA", "Promoter");
                    }
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
            TempData["submitvalue"] = "Save";
            TempData.Keep();
            ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
            ClsPrp_OrgMemDetail aa = new ClsPrp_OrgMemDetail();

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.districtMaster = objdis.dropdownlist_display1();

            #region
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion

            aa.prpMem = sdb.Display_MemProject(Application_id); 
            return View("Create_Mem", aa);
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create_Mem(ClsPrp_OrgMemDetail smodel)
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            String ext = String.Empty;
            string FilePathExt = string.Empty;

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
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.Image_FileName))
                            {
                                pathindb = smodel.Image_FileName.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.Photo_Address))
                            {
                                fileName = smodel.Photo_Address.ToString();
                            }
                            else
                            {
                                fileName = "OtherOrgMember_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                            }
                            //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

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

                if (Photo_Address == "")
                {
                    Photo_Address = smodel.Photo_Address;
                    ext = smodel.Image_FileName;
                }

                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
                            sdb.Update_MemProject(smodel);//, smodel.Application_id, smodel.Id, smodel.Promoter_OtherMemberDetails_ID);
                            TempData["message"] = "Project Details updated Successfully";

                            ModelState.Clear();
                        }

                        return RedirectToAction("Create_Mem");
                    }
                    else
                    {
                        //return View("Create_ParentEntity");
                        return RedirectToAction("Create_Mem");
                    }
                }
                catch (Exception ex)
                {
                    return View("Create_Mem");
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
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "OtherOrgMember_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

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
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.Photo_Address;
                            ext = smodel.Image_FileName;
                            FilePathExt = smodel.Image_FileName;
                        }
                        if (ModelState.IsValid)
                        {
                            ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
                            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
                            ClsPrp_OrgMemDetail aa = new ClsPrp_OrgMemDetail();
                            aa.districtMaster = objdis.dropdownlist_display1();
                            if (sdb.AddOrg_MemProject(smodel, Application_id, Photo_Address, FilePathExt))
                            {
                                TempData["message"] = "Project Details Added Successfully";
                                
                                ModelState.Clear();
                            }
                            return RedirectToAction("Create_Mem");
                        }
                        else
                        {                            
                            return RedirectToAction("Create_Mem");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return View("Create_Mem");
                }
            }
            return View("Create_Mem");
        }

        // GET: Edit/5
        [HttpGet]
        public ActionResult Edit_Mem(Int64 Application_id, int Id)
        {
            //  Application_id = "110029";
            ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
            ClsPrp_OrgMemDetail aa = new ClsPrp_OrgMemDetail();
           // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis1.State_list();

            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //aa.districtMaster = objdis.dropdownlist_display1();
            //// aa.districtMaster = objdis.dropdownlist_display1();

            aa.prpMem = sdb.DisplaybyID_MemProject(Application_id, Id); //(Application_id, Id);
            foreach (var item in aa.prpMem)
            {
                aa.Promoter_OtherMemberDetails_ID = item.Promoter_OtherMemberDetails_ID;
                aa.Designation = item.Designation;
                aa.Member_Names = item.Member_Names;
                aa.PAN_No = item.PAN_No;
                aa.Aadhar_No = item.Aadhar_No;
                aa.Address_Line1 = item.Address_Line1;
                aa.Address_Line2 = item.Address_Line2;
                aa.State = item.State;
                aa.District = item.District;
                aa.Pin_Code = item.Pin_Code;
                aa.Mobile_no = item.Mobile_no;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.Phone_No = item.Phone_No;
                aa.Email = item.Email;
                aa.Photo_Address = item.Photo_Address;
                aa.Image_FileName = item.Image_FileName;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.Created_By = item.Created_By;
                aa.CreatedOn = item.CreatedOn;
                aa.Modify_By = item.Modify_By;
                aa.ModifyOn = item.ModifyOn;

            }
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.districtMaster = objdis.dropdownlist_display1(Convert.ToInt32(aa.State));

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            //ViewBag.submitvalue = "Update";
            
            return View("Create_Mem", aa);

        }
        
        // POST: Edit/5     
        [HttpPost]
        public ActionResult Edit_Mem(ClsPrp_OrgMemDetail smodel)
        {
            //string Application_id = "110030";
            try
            {
                ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
                sdb.Update_MemProject(smodel);//, smodel.Application_id, smodel.Id, smodel.Promoter_OtherMemberDetails_ID);
                return RedirectToAction("Create_Mem");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Delete/5
        public ActionResult Delete_Mem(ClsPrp_ParentEntityDetail smodel)//Int64 Application_id, int Id)
        {
            // Application_id = "110027";
            try
            {
                ClsMethod_OrgMemDetail sdb = new ClsMethod_OrgMemDetail();
                if (sdb.Delete_MemProject(smodel.Application_ID, smodel.ID)) //(Application_id, Id))
                {
                    TempData["message"] = "Project Details deleted Successfully";

                   // ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Create_Mem");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        #endregion

        ///  Detail of Promoter Litigations(If Any)
        #region
        /// <summary>
        ///  Detail of Promoter Litigations(If Any)
        /// </summary>
        /// <returns></returns>
        ///
        // GET: Create

        [HttpPost]
        public ActionResult Details_Litigations()
        {
            return RedirectToAction("Create_Litigations");

        }

        //GET: Details/5
        public ActionResult Details_Litigations(ClsPrp_ParentEntityDetail smodel)
        {
            // Application_id = "110027";
            ClsMethod_Promoter_Litigations sdb = new ClsMethod_Promoter_Litigations();
            ClsPrp_Promoter_Litigations aa = new ClsPrp_Promoter_Litigations();
            aa.prpongoing = sdb.DisplayLitigationn(smodel.Application_ID, smodel.ID);
            foreach (var item in aa.prpongoing)
            {
                aa.LitigationsRelated_ProjectName = item.LitigationsRelated_ProjectName;
                aa.Case_Title =  item.Case_Title;
                aa.Case_Number = item.Case_Number;
                aa.Authority_ForumName_CasePendingResolved = item.Authority_ForumName_CasePendingResolved;
               
            }


            ViewBag.submitvalue = "Cancel";



            return View("Create_Litigations", aa);

        }

        // GET: Create
        public ActionResult Create_Litigations()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    if (Session["User_TrackRecordFlag"].ToString() != "1")
                    {
                        //In Not Track Record
                        return RedirectToAction("Create_LitigationsNA", "Promoter");
                    }
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
            ClsMethod_Promoter_Litigations sdb = new ClsMethod_Promoter_Litigations();
            ClsPrp_Promoter_Litigations aa = new ClsPrp_Promoter_Litigations();
            aa.prpongoing = sdb.DisplayLitigationn(Application_id);

            ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();            

            aa.Prp_Project_Name = clsfive.ListofProjects(Application_id);
            #region
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion
            ViewBag.submitvalue = "Save";
            return View("Create_Litigations", aa);
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create_Litigations(ClsPrp_Promoter_Litigations smodel)
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Promoter_Litigations sdb = new ClsMethod_Promoter_Litigations();
                    if (sdb.AddLitigationsDetail(smodel, Application_id))
                    {
                        TempData["message"] = "Litigation Details Added Successfully";
                       // ViewBag.Message = "Litigation Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_Litigations");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: Edit/5
        [HttpGet]
        public ActionResult Edit_Litigations(ClsPrp_ParentEntityDetail smodel)
        {
            //  Application_id = "110029";
            ClsMethod_Promoter_Litigations sdb = new ClsMethod_Promoter_Litigations();
            ClsPrp_Promoter_Litigations aa = new ClsPrp_Promoter_Litigations();
            aa.prpongoing = sdb.DisplayLitigationn(smodel.Application_ID, smodel.ID);

            ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Application_ID);

            foreach (var item in aa.prpongoing)
            {
                aa.Promoter_ID = item.Promoter_ID;
                aa.Promoter_Litigation_ID = item.Promoter_Litigation_ID;
                aa.Promoter_Litigations_IndexID= item.Promoter_Litigations_IndexID;
                aa.LitigationsRelated_ProjectName = item.LitigationsRelated_ProjectName;
                aa.Case_Title = item.Case_Title;
                aa.Case_Number = item.Case_Number;
                aa.Authority_ForumName_CasePendingResolved = item.Authority_ForumName_CasePendingResolved;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                //aa.Flag = item.Flag;
                aa.Created_By = item.Created_By;
                aa.Created_On = item.Created_On;
                aa.Modify_By = item.Modify_By;
                aa.Modified_On = item.Modified_On;

            }


            ViewBag.submitvalue = "Update";
            return View("Create_Litigations", aa);

        }

        // POST: Edit/5
        [HttpPost]
        public ActionResult Edit_Litigations(Int64 Id, Int64? Promoter_Experience_ID, Int64 Application_id, ClsPrp_Promoter_Litigations smodel)
        {
            //string Application_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Promoter_Litigations sdb = new ClsMethod_Promoter_Litigations();
                    sdb.UpdateLitigationsDetail(smodel);//, Application_id, Id, Promoter_Experience_ID);
                    TempData["message"] = "Litigation Details updated Successfully";
                }
                return RedirectToAction("Create_Litigations");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Delete/5
        public ActionResult Delete_Litigations(ClsPrp_ParentEntityDetail smodel)
        {
            // Application_id = "110027";
            try
            {
                ClsMethod_Promoter_Litigations sdb = new ClsMethod_Promoter_Litigations();
                if (sdb.Delete_Litigation(smodel.Application_ID,smodel.ID))
                {
                    TempData["message"] = "Litigation Details deleted Successfully";
                    //ViewBag.AlertMsg = "Litigation Details Deleted Successfully";
                }
                return RedirectToAction("Create_Litigations");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        ///Details of Promoter Parent Entity/ Entities 
        #region         
        public JsonResult GetState()
        {
            UserDetails aa = new UserDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();

            return Json(aa, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrictByStateId(string stateid)
        {
            int Id=0;
            if (stateid!="")
                Id = Convert.ToInt32(stateid);
             
        
            UserDetails aa = new UserDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            var states = objdis.dropdownlist_display1(Id);

            return Json(states);
        }


        //POST: NOT IN USE
        [HttpPost]
        public ActionResult Details_ParentEntity()
        {
            return RedirectToAction("Create_ParentEntity");

        }
        //GET: NOT IN USE
        //public ActionResult Details_ParentEntity(Int64 Application_id, Int64 Id)
        public ActionResult Details_ParentEntity(ClsPrp_ParentEntityDetail smodel)
        {
            // Application_id = 110027;
            ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
            ClsPrp_ParentEntityDetail aa = new ClsPrp_ParentEntityDetail();

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.districtMaster = objdis.dropdownlist_display1();



            aa.Prpparententity = sdb.DisplayDetailByIDApplicationID(smodel.Application_ID,smodel.ID);
            foreach (var item in aa.Prpparententity)
            {
                aa.Promoter_IsPastExperience = item.Promoter_IsPastExperience;
                aa.Name_of_Parent_Entity = item.Name_of_Parent_Entity;
                aa.Type_of_Enterprise = item.Type_of_Enterprise;
                aa.Main_Objects_of_Parent_Entity = item.Main_Objects_of_Parent_Entity;
                aa.RegisteredAddress = item.RegisteredAddress;
                aa.Address_Line2 = item.Address_Line2;

                aa.State = item.State;
                aa.District = item.District;
                aa.Pin_Code = item.Pin_Code;
                aa.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab = item.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab;
                aa.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State = item.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State;
                aa.Upload_Company_Registration_Certificate_of_Parent_Entity = item.Upload_Company_Registration_Certificate_of_Parent_Entity;
                aa.CompanyRegCert_Image_FileName = item.CompanyRegCert_Image_FileName;        
         
             
            }


           // ViewBag.submitvalue = "Cancel";
            ////TempData["submitvalue"] = "Cancel";
            ////TempData.Keep();

            return View("Create_ParentEntity", aa);

        }

        // GET: Create
        public ActionResult Create_ParentEntity()
        {
            Int64 Application_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);

                    if (Session["User_ParentEntityFlag"].ToString() != "1")
                    {
                        //In Not Parent Entity
                        return RedirectToAction("Create_ParentEntityNA", "Promoter");
                    }

                    if (Session["User_Type"].ToString() == "1")
                    {
                        //if Individual Case
                        return RedirectToAction("Create_ParentEntityNA", "Promoter");
                    }

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
            TempData["submitvalue"] = "Save";
            TempData.Keep();
            //Int64 Application_id = 110028;
            ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
            ClsPrp_ParentEntityDetail aa = new ClsPrp_ParentEntityDetail();
            

            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis1.State_list();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.districtMaster = objdis.dropdownlist_display1();

            aa.Prpparententity = sdb.DisplayDetailByApplicationID(Application_id);

            #region
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion
            return View("Create_ParentEntity", aa);
        }
        // POST: Create
        [HttpPost]
        public ActionResult Create_ParentEntity(ClsPrp_ParentEntityDetail smodel)
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            String ext = String.Empty;
            string FilePathExt = string.Empty;
                      

            string error = string.Empty;

            #region Cert Upload Code
            //////////int errorstate = 0;

            ////////////if (TempData["submitvalue"].ToString() == "Update")
            ////////////{

            ////////////    #region PhotoCertificate Update with Path
            ////////////    ////////if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            ////////////    ////////{
            ////////////    ////////    var files = Request.Files[0];
            ////////////    ////////    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            ////////////    ////////    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            ////////////    ////////    if (allowedExtensions.Contains(ext)) //check what type of extension  
            ////////////    ////////    {
            ////////////    ////////        int size = files.ContentLength;
            ////////////    ////////        if (size <= 512000)
            ////////////    ////////        {

            ////////////    ////////            #region Declare Variables
            ////////////    ////////            var pathpromoterdata = "";
            ////////////    ////////            var pathindb = "";
            ////////////    ////////            string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
            ////////////    ////////            #endregion

            ////////////    ////////            #region UpdateFile Path Creation 
            ////////////    ////////            if (!String.IsNullOrEmpty(smodel.CompanyRegCert_Image_FileName))
            ////////////    ////////            {
            ////////////    ////////                pathindb = smodel.CompanyRegCert_Image_FileName.ToString();
            ////////////    ////////            }
            ////////////    ////////            else
            ////////////    ////////            {
            ////////////    ////////                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
            ////////////    ////////            }
            ////////////    ////////            pathpromoterdata = Server.MapPath("~/" + pathindb);

            ////////////    ////////            if (!Directory.Exists(pathpromoterdata))
            ////////////    ////////            {
            ////////////    ////////                Directory.CreateDirectory(pathpromoterdata);
            ////////////    ////////            }
            ////////////    ////////            #endregion

            ////////////    ////////            var fileName = string.Empty;
            ////////////    ////////            if (!String.IsNullOrEmpty(smodel.Upload_Company_Registration_Certificate_of_Parent_Entity))
            ////////////    ////////            {
            ////////////    ////////                fileName = smodel.Upload_Company_Registration_Certificate_of_Parent_Entity.ToString();
            ////////////    ////////            }
            ////////////    ////////            else
            ////////////    ////////            {
            ////////////    ////////                fileName = "ParentEntity_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
            ////////////    ////////            }
            ////////////    ////////                //"Photo_ParentEntity_" + DateTime.Today.Date.DayOfYear.ToString() + Path.GetFileName(files.FileName);
            ////////////    ////////            var path = Path.Combine(pathpromoterdata, fileName);
            ////////////    ////////            files.SaveAs(path);
            ////////////    ////////            Photo_Address = fileName;
            ////////////    ////////            FilePathExt = pathindb;

            ////////////    ////////        }
            ////////////    ////////        else
            ////////////    ////////        {
            ////////////    ////////            TempData["notice"] = "Photo Size Should be less than 512KB";
            ////////////    ////////            error = "Photo Size Should be less than 512KB";
            ////////////    ////////            errorstate = 1;
            ////////////    ////////        }
            ////////////    ////////    }
            ////////////    ////////    else
            ////////////    ////////    {
            ////////////    ////////        TempData["notice"] = "Photo format should be .jpg";
            ////////////    ////////        error = "Photo format should be .jpg";
            ////////////    ////////        errorstate = 1;
            ////////////    ////////    }
            ////////////    ////////}
            ////////////    ////////else
            ////////////    ////////{
            ////////////    ////////    TempData["notice"] = "Kindly Upload Photograph";
            ////////////    ////////    error = "Kindly Upload Photograph";
            ////////////    ////////    errorstate = 1;

            ////////////    ////////    //update with same photograph
            ////////////    ////////    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
            ////////////    ////////    {
            ////////////    ////////        errorstate = 0;
            ////////////    ////////    }

            ////////////    ////////}
            ////////////    //////////}
            ////////////    #endregion

            ////////////    try
            ////////////    {
            ////////////        ////////if (errorstate == 0)
            ////////////        ////////{
            ////////////        if (ModelState.IsValid)
            ////////////        {
            ////////////            ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
            ////////////            sdb.UpdateParent_EntityMember(smodel);
            ////////////            TempData["message"] = "ParentEntity Details updated Successfully";

            ////////////            ModelState.Clear();
            ////////////        }

            ////////////        return RedirectToAction("Create_ParentEntity");
            ////////////        ////////}
            ////////////        ////////else
            ////////////        ////////{
            ////////////        ////////    //return View("Create_ParentEntity");
            ////////////        ////////    return RedirectToAction("Create_ParentEntity");
            ////////////        ////////}
            ////////////    }
            ////////////    catch (Exception ex)
            ////////////    {
            ////////////        return View("Create_ParentEntity");
            ////////////    }
            ////////////}
            ////////////else
            ////////////{
            ////////////    #region PhotoCertificate Save with Path
            ////////////    //////////if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            ////////////    //////////{
            ////////////    //////////    var files = Request.Files[0];
            ////////////    //////////    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            ////////////    //////////    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            ////////////    //////////    if (allowedExtensions.Contains(ext)) //check what type of extension  
            ////////////    //////////    {
            ////////////    //////////        int size = files.ContentLength;
            ////////////    //////////        if (size <= 512000)
            ////////////    //////////        {

            ////////////    //////////            #region Declare Variables
            ////////////    //////////            var pathpromoterdata = "";
            ////////////    //////////            var pathindb = "";
            ////////////    //////////            string masterPromoterDoc_SetFilePath = "readwritedataPromoter";
            ////////////    //////////            #endregion

            ////////////    //////////            #region SaveFile Path Creation
            ////////////    //////////            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
            ////////////    //////////            pathpromoterdata = Server.MapPath("~/" + pathindb);

            ////////////    //////////            if (!Directory.Exists(pathpromoterdata))
            ////////////    //////////            {
            ////////////    //////////                Directory.CreateDirectory(pathpromoterdata);
            ////////////    //////////            }
            ////////////    //////////            #endregion

            ////////////    //////////            var fileName = string.Empty;
            ////////////    //////////            fileName = "ParentEntity_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;// + Path.GetFileName(files.FileName);
            ////////////    //////////            var path = Path.Combine(pathpromoterdata, fileName);
            ////////////    //////////            files.SaveAs(path);
            ////////////    //////////            Photo_Address = fileName;
            ////////////    //////////            FilePathExt = pathindb;

            ////////////    //////////        }
            ////////////    //////////        else
            ////////////    //////////        {
            ////////////    //////////            TempData["notice"] = "Photo Size Should be less than 512KB";
            ////////////    //////////            error = "Photo Size Should be less than 512KB";
            ////////////    //////////            errorstate = 1;
            ////////////    //////////        }
            ////////////    //////////    }
            ////////////    //////////    else
            ////////////    //////////    {
            ////////////    //////////        TempData["notice"] = "Photo format should be .jpg";
            ////////////    //////////        error = "Photo format should be .jpg";
            ////////////    //////////        errorstate = 1;
            ////////////    //////////    }
            ////////////    //////////}
            ////////////    //////////else
            ////////////    //////////{
            ////////////    //////////    TempData["notice"] = "Kindly Upload Photograph";
            ////////////    //////////    error = "Kindly Upload Photograph";
            ////////////    //////////    errorstate = 1;
            ////////////    //////////}
            ////////////    ////////////}
            ////////////    #endregion

            ////////////    //////try
            ////////////    //////{
            ////////////    //////    //////////if (errorstate == 0)
            ////////////    //////    //////////{
            ////////////    //////    //////////    if (Photo_Address == "")
            ////////////    //////    //////////    {
            ////////////    //////    //////////        Photo_Address = smodel.Upload_Company_Registration_Certificate_of_Parent_Entity;
            ////////////    //////    //////////        ext = smodel.CompanyRegCert_Image_FileName;
            ////////////    //////    //////////        FilePathExt = smodel.CompanyRegCert_Image_FileName;
            ////////////    //////    //////////    }
            ////////////    //////    if (ModelState.IsValid)
            ////////////    //////    {

            ////////////    //////        ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
            ////////////    //////        if (sdb.AddParent_EntityMember(smodel, Application_id, Photo_Address, FilePathExt))
            ////////////    //////        {
            ////////////    //////            TempData["message"] = "Parent Entity Details Added Successfully";

            ////////////    //////            ModelState.Clear();
            ////////////    //////        }
            ////////////    //////    }
            ////////////    //////    return RedirectToAction("Create_ParentEntity");
            ////////////    //////    //////////}
            ////////////    //////    //////////else
            ////////////    //////    //////////{
            ////////////    //////    //////////    //return View("Create_ParentEntity",);
            ////////////    //////    //////////    return RedirectToAction("Create_ParentEntity");
            ////////////    //////    //////////}
            ////////////    //////}
            ////////////    //////catch (Exception ex)
            ////////////    //////{
            ////////////    //////    return View("Create_ParentEntity");
            ////////////    //////}
            //////////////////////}
            #endregion

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
                    if (sdb.AddParent_EntityMember(smodel, Application_id, Photo_Address, FilePathExt))
                    {
                        TempData["message"] = "Parent Entity Details Added Successfully";

                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Create_ParentEntity");                
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.ToString();
                return View("Create_ParentEntity");
            }
        }
        // GET: Edit/5
        public ActionResult Edit_ParentEntity(Int64 Application_id, Int64 Id)
        {
            // Application_id = 110029;
            ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
            ClsPrp_ParentEntityDetail aa = new ClsPrp_ParentEntityDetail();
            ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis1.State_list();

           
            aa.Prpparententity = sdb.DisplayDetailByIDApplicationID(Application_id, Id);


            foreach (var item in aa.Prpparententity)
            {
                aa.PromoterParentEntity_ID = item.PromoterParentEntity_ID;
                aa.Promoter_IsPastExperience = item.Promoter_IsPastExperience;
                aa.Name_of_Parent_Entity = item.Name_of_Parent_Entity;
                aa.Type_of_Enterprise = item.Type_of_Enterprise;
                aa.Main_Objects_of_Parent_Entity = item.Main_Objects_of_Parent_Entity;
                aa.RegisteredAddress = item.RegisteredAddress;
                aa.Address_Line2 = item.Address_Line2;

                aa.State = item.State;
                aa.District = item.District;
                aa.Pin_Code = item.Pin_Code;
                aa.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab = item.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab;
                aa.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State = item.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State;
                aa.Upload_Company_Registration_Certificate_of_Parent_Entity = item.Upload_Company_Registration_Certificate_of_Parent_Entity;
                aa.CompanyRegCert_Image_FileName = item.CompanyRegCert_Image_FileName;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.districtMaster = objdis.dropdownlist_display1(Convert.ToInt32(aa.State));

            TempData["submitvalue"] = "Update";
            TempData.Keep();
          //ViewBag.submitvalue = "Update";
            return View("Create_ParentEntity", aa);

        }
        [HttpPost]  
        public ActionResult Edit_ParentEntity(ClsPrp_ParentEntityDetail smodel)//,Int64 Id, Int64? PromoterParentEntity_ID, Int64 Application_id)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
                    sdb.UpdateParent_EntityMember(smodel);
                    TempData["message"] = "ParentEntity Details updated Successfully";

                    ModelState.Clear();
                }
                return RedirectToAction("Create_ParentEntity");                
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.ToString();
                return View("Create_ParentEntity");
            }
        }
        // GET: Delete/5
        public ActionResult Delete_ParentEntity(ClsPrp_ParentEntityDetail smodel)
        {
            // Application_id = "110027";
            try
            {
                ClsMethod_ParentEntityDetail sdb = new ClsMethod_ParentEntityDetail();
                if (sdb.Delete_ParentEntityDetail(smodel.Application_ID,smodel.ID))
                {
                    TempData["message"] = "Parent Entity Details Deleted Successfully";
                   // ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Create_ParentEntity");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        ///Details of 2 views 
        #region 
        public ActionResult DisplayFiveYrProjects()//long? Application_id)
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Clsprp_Promoter_FiveYr_OngoingProjcts objprp = new Clsprp_Promoter_FiveYr_OngoingProjcts();
            ClsMethod_Promoter_FiveYr_OngoingProjcts objDB = new ClsMethod_Promoter_FiveYr_OngoingProjcts(); //calling class DBdata
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.FiveYr_OngoingProjcts = objDB.DisplayFiveYrProj(Convert.ToInt64(Application_id));
            foreach (var item in objprp.FiveYr_OngoingProjcts)
            {
                objprp.Ind_Org_CompltdProj_FiveYrs = item.Ind_Org_CompltdProj_FiveYrs;
                objprp.Ind_Org_TotalArea_Constructed = item.Ind_Org_TotalArea_Constructed;
            }
            return View("DisplayFiveYrProjects", objprp);

        }

        public ActionResult DisplayOnGngProjects()//long? Application_id)
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            Clsprp_Promoter_FiveYr_OngoingProjcts objprp = new Clsprp_Promoter_FiveYr_OngoingProjcts();
            ClsMethod_Promoter_FiveYr_OngoingProjcts objDB = new ClsMethod_Promoter_FiveYr_OngoingProjcts(); //calling class DBdata
            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.FiveYr_OngoingProjcts = objDB.DisplayOngoingProj(Convert.ToInt64(Application_id));
            foreach (var item in objprp.FiveYr_OngoingProjcts)
            {
                objprp.Ind_Org_OngoingProjects = item.Ind_Org_OngoingProjects;
                objprp.Ind_Org_AreaToBe_Constructed = item.Ind_Org_AreaToBe_Constructed;
            }
            return View("DisplayOnGngProjects", objprp);

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

        /// GET: UserPAN card Remote Validator
        ///[AllowAnonymous]
        public JsonResult CheckPromoterPANcard(string PAN_No)
        {
            //if (Application_id != 0)
            //{
                ClsMethod_Promoter objclsMain = new ClsMethod_Promoter();
                bool isValid_UserName = objclsMain.AlreadyExistPANcardnumber(PAN_No);//false;// aadharcard.validateVerhoeff(Aadharid);
                if (!isValid_UserName)
                {
                    return Json("PAN number already exist, Try another", JsonRequestBehavior.AllowGet);
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            //}
            //return Json(true, JsonRequestBehavior.AllowGet);
        }

        ///NA Details Views
        #region
        ///Alert - NA Track Record
        public ActionResult Create_FiveYearsNA()
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
                        
            return View("Create_FiveYearsNA");
        }

        ///Alert - NA Promoter's Project Litigations
        public ActionResult Create_LitigationsNA()
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            return View("Create_LitigationsNA");
        }

        ///Alert - NA Promoter's Parent Entity
        public ActionResult Create_ParentEntityNA()
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            return View("Create_ParentEntityNA");
        }
        #endregion

        ///NA Promoter Dashboard Details
        #region
        ///Get  Promoter Dashboard
        public ActionResult PromoterDashboard()
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
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }


            ClsMethod_Project_DiaryNumberPromoterDashbaord sdb = new ClsMethod_Project_DiaryNumberPromoterDashbaord();
            ClsPrp_Project_DiaryNumberPromoterDashbaord aa = new ClsPrp_Project_DiaryNumberPromoterDashbaord();

            aa.prpongoing = sdb.Display_Project_RegDiaryNumberByPromoterID(Application_id, "");

            return View("PromoterDashboard", aa);

        }

        /// GET: Checklist Not Accepted
        [HttpGet]
        public JsonResult GetChecklistNotAcceptedByProjectId(Int64? projectId)
        {
            string varStrRet = string.Empty;
            if (projectId != 0)
            {
                int Id = 0;
                Id = Convert.ToInt32(projectId);

                string pUserRole = string.Empty;
                pUserRole = getUserRole();

                Models.HelpDesk.ClsMethod_Helpdesk objCode = new Models.HelpDesk.ClsMethod_Helpdesk();
                Models.HelpDesk.ClsPrp_AuthorityDesk_ProjectSubCheckListLog aa = new Models.HelpDesk.ClsPrp_AuthorityDesk_ProjectSubCheckListLog();
                //var Subdiv =
                aa.prpongoing = objCode.Display_AuthorityDesk_CheckList_NoAccept_DetailsByCode(Id, pUserRole);
                
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

        [HttpGet]
        public ActionResult ProjectInfoApplicationForExtensionStatusView(Int64 projectId, Int64 projectpromoterId)
        {
            ClsMethod_Project_DiaryNumberPromoterDashbaord sdb = new ClsMethod_Project_DiaryNumberPromoterDashbaord();
            ClsPrp_Project_DiaryNumberPromoterDashbaord aa = new ClsPrp_Project_DiaryNumberPromoterDashbaord();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_Project_ApplicationForExtension_RegDiaryNumberByID(projectId, projectpromoterId, userRole);
            

            foreach (var item in aa.prpongoing)
            {
                aa.Project_RegDiaryNumber_IndexID = item.Project_RegDiaryNumber_IndexID;
                aa.Project_RegDiaryNumber_ID = item.Project_RegDiaryNumber_ID;
                aa.PromoterRegDiaryNumber_Name = item.PromoterRegDiaryNumber_Name;
                aa.PromoterRegDiaryNumber_NameYear = item.PromoterRegDiaryNumber_NameYear;
                aa.UserID = item.UserID;
                aa.Promoter_ID = item.Promoter_ID;
                aa.Project_ID = item.Project_ID;
                aa.LandDetailsCount = item.LandDetailsCount;
                aa.KhasraAreaDetailsCount = item.KhasraAreaDetailsCount;
                aa.LitigationsCount = item.LitigationsCount;
                aa.ApprovalDetailsCount = item.ApprovalDetailsCount;
                aa.PaymentDetailsCount = item.PaymentDetailsCount;
                aa.SpecialBankAccountDetailsCount = item.SpecialBankAccountDetailsCount;
                aa.ProjectDocumentCount = item.ProjectDocumentCount;
                aa.IsRegistration = item.IsRegistration;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.Project_Name = item.Project_Name;
                aa.Project_AddressDistrictName = item.Project_AddressDistrictName;
                aa.Project_RERAregistrationNumber = item.Project_RERAregistrationNumber;

                aa.EventAction_Type = item.EventAction_Type;
                aa.EventAction_TypeName = item.EventAction_TypeName;
                aa.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                aa.EventAction_Aggregate = item.EventAction_Aggregate;
                aa.Target_ResolutionDate = item.Target_ResolutionDate;
                aa.EventRemarks_IfAny = item.EventRemarks_IfAny;
                aa.EventAction_Summary = item.EventAction_Summary;
            }
            if (aa.prpongoing.Count > 0)
            {
                if (aa.EventAction_Type == "150007")
                {
                    aa.AppExtnCheckListContent = sdb.Display_Project_ApplicationForExtension_CheckList_NoAccept_DetailsByCode(projectId, projectpromoterId, userRole);
                }
            }            
            return View("ProjectInfoApplicationForExtensionStatusView", aa);
        }
        #endregion

        #region Print_Form
        public ActionResult PromoterIndPrintForm()
        {
            Int64 Application_id = 1135;
            int? statecode;
            int? DistrictCode;
            //int? BusinessPlace_AddressStateCode;
            //int? BusinessPlace_AddressDistrictCode;
            //int? BComm_AddressStateCode;
            //int? BComm_AddressDistrictCode;


            ClsPromoterPrintForm objprp = new ClsPromoterPrintForm();
            ClsPromoterPrintForm objDB = new ClsPromoterPrintForm(); //calling class DBdata
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            objprp = objDB.DisplayIndPro(Convert.ToInt64(Application_id));

            statecode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(DistrictCode);

            //ClsMethod_OngoingProjectLFiveYears sdb = new ClsMethod_OngoingProjectLFiveYears();
            // ClsPrp_OngoingProjectLFiveYears objprp = new ClsPrp_OngoingProjectLFiveYears();
            //objprp.prpongoing = sdb.DisplaybyID_ongoingProject(Application_id);
            //if (objprp.prpongoing != null)
            //{
            //    foreach (var item in objprp.prpongoing)
            //    {
                    //objDB.Promoter_Experience_ID = item.Promoter_Experience_ID;
                    //aa.Id = item.Id;
                    //aa.Application_id = item.Id;
                    //aa.Projectname = item.Projectname;
                    //aa.ProjectType = item.ProjectType;
                    //aa.ProjectStatus = item.ProjectStatus;
                    //aa.AreaConUProject = item.AreaConUProject;
                    //aa.ProjectStartDate = item.ProjectStartDate;
                    //aa.OCDateProject = item.OCDateProject;
                    //aa.ACDProject = item.ACDProject;
                    //aa.RExtentofDelayProject = item.RExtentofDelayProject;
                    //aa.TypeLandofProject = item.TypeLandofProject;
                    //aa.LitgToProject = item.LitgToProject;
                    //aa.IsPaymentDetailsPending_RelatedLand = item.IsPaymentDetailsPending_RelatedLand;
                    //aa.DetailPaymentPendingProject = item.DetailPaymentPendingProject;
                    //aa.NameofAuthorityForumwhereCasisPendingresolved = item.DetailPaymentPendingProject;
                    //aa.CaseTitle = item.CaseTitle;
                    //aa.CaseNumber = item.CaseNumber;

                    //aa.IsActive = item.IsActive;
                    //aa.IsDraft = item.IsDraft;
                    //aa.Created_By = item.Created_By;
                    //aa.Created_On = item.Created_On;
                    //aa.Modify_By = item.Modify_By;
                    //aa.Modified_On = item.Modified_On;

            //    }
            //}
            //objprp.prpLitigations = objDB.DisplayLitigationn(Application_id);



            //objprp.Prp_Project_Name = clsfive.ListofProjects(Application_id);


            //if (objprp.prpLitigations != null)
            //{
            //    foreach (var item in objprp.prpLitigations)
            //    {
                    //aa.Promoter_ID = item.Promoter_ID;
                    //aa.Promoter_Litigation_ID = item.Promoter_Litigation_ID;
                    //aa.Promoter_Litigations_IndexID = item.Promoter_Litigations_IndexID;
                    //aa.LitigationsRelated_ProjectName = item.LitigationsRelated_ProjectName;
                    //aa.Case_Title = item.Case_Title;
                    //aa.Case_Number = item.Case_Number;
                    //aa.Authority_ForumName_CasePendingResolved = item.Authority_ForumName_CasePendingResolved;

                    //aa.IsActive = item.IsActive;
                    //aa.IsDraft = item.IsDraft;
                    ////aa.Flag = item.Flag;
                    //aa.Created_By = item.Created_By;
                    //aa.Created_On = item.Created_On;
                    //aa.Modify_By = item.Modify_By;
                    //aa.Modified_On = item.Modified_On;

            //    }
            //}

            //ClsMethodDistrictMaster objdis1 = new ClsMethodDistrictMaster();
            //objprp.stateMaster = objdis1.State_list();

            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            //objprp.districtMaster = objdis.dropdownlist_display1(Convert.ToInt32(objprp.State));










            //statecode = item.P_AddressStateCode;
            //aa.P_AddressState = objdis.State_Name(statecode);
            //DistrictCode = item.P_AddressDistrictCode;
            //aa.P_AddressDist = objdis.District_Name(DistrictCode);

            //BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
            //aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

            //BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
            //aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


            //BComm_AddressStateCode = item.BComm_AddressStateCode;
            //aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

            //BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
            //aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);





            return View("PromoterIndPrintForm", objprp);



        }
        public ActionResult PromoterOthIndPrintForm()
        {
            Int64 Application_id = 1133;
            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            //int? BComm_AddressStateCode;
            //int? BComm_AddressDistrictCode;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPromoterOrgExpPrintForm objprp = new ClsPromoterOrgExpPrintForm();
            ClsPromoterOrgExpPrintForm objDB = new ClsPromoterOrgExpPrintForm(); //calling class DBdata



            objprp = objDB.DisplayOrgExp(Convert.ToInt64(Application_id));

            statecode = Convert.ToInt32(objprp.Org_State);
            objprp.Org_State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.Org_District);
            objprp.Org_District = objdis.District_Name(DistrictCode);

            BusinessPlace_AddressStateCode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(BusinessPlace_AddressStateCode);

            BusinessPlace_AddressDistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(BusinessPlace_AddressDistrictCode);

            objprp.Prpparententity = objDB.DisplayDetailByApplicationID(Application_id);

            objprp.prpMem = objDB.Display_MemProject(Application_id);
            return View("PromoterOthIndPrintForm", objprp);



        }
        #endregion

        //To check the isdraft value
        #region
        /// <summary>
        /// To check the isdraft value for PROMOTER to disable the save /submit button
        /// </summary>
        public void Get_Isdraftvalue_FromDiaryNumber(Int64 Application_id)
        {
            ClsMethodPromoterConfirm model = new ClsMethodPromoterConfirm();

            #region
            /// <summary>
            ///  disable save button
            /// </summary>
            /// <returns></returns>

            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Application_id);
            TempData["PromoterIsdraftValue"] = IsdraftValue;
            #endregion
        }

        /// <summary>
        /// To check the isdraft value for JOINT-PROMOTER to disable the save /submit button
        /// </summary>
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

        // <summary>
        /// To check the isdraft value for JOINT-PROMOTER to disable the save /submit button
        /// </summary>
        public void Get_JointPromoter_Isdraftvalue_FromDiaryNumber(Int64 _JointPromoter_ID, Int32 _JointPromoter_Type)
        {
            Int64 _Promoter_ID = 0;
            Int32 _Promoter_Type = 0;

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
            }
            #endregion

            ClsMethod_JointPromoter_ReviewConfirm modelVerify = new ClsMethod_JointPromoter_ReviewConfirm();

            Int32 IsdraftValue = modelVerify.JointPromoter_Isdraftvalue_FromDiaryNumber(_Promoter_ID, _Promoter_Type, _JointPromoter_ID, _JointPromoter_Type);
            TempData["JointPromoter_IsdraftValue"] = IsdraftValue;

        }

        // <summary>
        /// To check the isdraft value for JOINT-PROMOTER to disable the save /submit button
        /// </summary>
        public string Get_JointPromoter_Isdraftvalue_FromDiaryNumber(Int64 _JointPromoter_ID, Int32 _JointPromoter_Type, Int32 _Flag)
        {
            Int64 _Promoter_ID = 0;
            Int32 _Promoter_Type = 0;
            string _JointPromoter_IsdraftValue = "0";

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
            }
            #endregion

            ClsMethod_JointPromoter_ReviewConfirm modelVerify = new ClsMethod_JointPromoter_ReviewConfirm();

            Int32 IsdraftValue = modelVerify.JointPromoter_Isdraftvalue_FromDiaryNumber(_Promoter_ID, _Promoter_Type, _JointPromoter_ID, _JointPromoter_Type);
            //TempData["JointPromoter_IsdraftValue"] = IsdraftValue;
            _JointPromoter_IsdraftValue = Convert.ToString(IsdraftValue);
            return _JointPromoter_IsdraftValue;
        }
        #endregion

        //Joint-Promoter
        #region Joint-Promoter Profile
        [HttpGet]
        public ActionResult Create_JointPromoterProfile()
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;
            Int32 flag = 0;
            string userRole = string.Empty;
            var userID = User.Identity.GetUserId();

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                }
                else
                {
                    return RedirectToAction("Create_JointPromoterProfileNA", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            TempData["submitvalue"] = "Save";
            TempData.Keep();

            ClsMethod_JointPromoter_RegistrationDetail sdb = new ClsMethod_JointPromoter_RegistrationDetail();
            ClsPrp_JointPromoter_RegistrationDetails aa = new ClsPrp_JointPromoter_RegistrationDetails();
            ClsMethodDistrictMaster objdrpmaster = new ClsMethodDistrictMaster();

            try
            {
                #region movement- JointPromoter Detail
                string UserNam = string.Empty;
                ClsMethod_JointPromoter_ReviewConfirm sdbYN = new ClsMethod_JointPromoter_ReviewConfirm();
                Tuple<string, Int32> JointPromoterYN = sdbYN.JointPromoter_YN_TrackRecordLitigations_ByID(Application_id, Application_type, userID, UserNam);

                if (JointPromoterYN.Item1 == "N" && JointPromoterYN.Item2 == 0)
                {
                    return RedirectToAction("Create_JointPromoterProfileNA", "Promoter");
                }
                #endregion

                aa.stateMaster = objdrpmaster.State_list();
                aa.districtMaster = objdrpmaster.dropdownlist_display1();

                #region Promoter-Lock
                Get_Isdraftvalue_FromDiaryNumber(Application_id);
                #endregion

                aa.prpjointpromoter = sdb.Display_JointPromoter_RegistrationsByID(Application_id, Application_type, flag, userRole, userID);

                aa.Related_Promoter_Application_ID = Application_id;
            }
            catch (Exception ex)
            {
                string strRT = ex.ToString();
            }

            return View("Create_JointPromoterProfile", aa);
        }

        [HttpPost]
        public ActionResult Create_JointPromoterProfile(ClsPrp_JointPromoter_RegistrationDetails smodel)
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;            
            string userRole = string.Empty;
            var userID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                }
                else
                {
                    return RedirectToAction("Create_JointPromoterProfileNA", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            //validate inputs
            switch (smodel.CoPromoterType_Flag)
            {
                case 1:
                    {
                        //Individual CASE
                        ModelState.Remove("Org_Name");
                        ModelState.Remove("Org_Type");
                        ModelState.Remove("OTI_Org_Objects");
                        ModelState.Remove("Individual_Gender");
                        ModelState.Remove("Registered_Address_Org_Line1");
                        ModelState.Remove("Registered_Address_Org_State");
                        ModelState.Remove("Registered_Address_Org_District");
                        ModelState.Remove("Registered_Address_Org_Pin_Code");
                        ModelState.Remove("IsAuthorizedPersonAddress");
                        ModelState.Remove("CoPromoter_Aadhaar_Number");                        
                        ModelState.Remove("Link_RegDiaryNumber_Name");                        
                        break;
                    }
                case 2:
                    {
                        //Other-Than-Individual CASE
                        ModelState.Remove("First_Name");
                        ModelState.Remove("Last_Name");                        
                        ModelState.Remove("Fath_First_Name");
                        ModelState.Remove("Fath_Last_Name");
                        ModelState.Remove("Ind_Org_Objects");
                        ModelState.Remove("Individual_Gender");
                        ModelState.Remove("Permanent_Address_Prm_Line1");
                        ModelState.Remove("Permanent_Address_Prm_State");
                        ModelState.Remove("Permanent_Address_Prm_District");
                        ModelState.Remove("Permanent_Address_Prm_Pin_Code");
                        ModelState.Remove("IsAuthorizedPersonAddress");
                        ModelState.Remove("CoPromoter_Aadhaar_Number");                        
                        ModelState.Remove("Link_RegDiaryNumber_Name");                        
                        break;
                    }
            }

            ClsPrp_JointPromoter_RegistrationDetails aa = new ClsPrp_JointPromoter_RegistrationDetails();
            ClsMethodDistrictMaster objdrpmaster = new ClsMethodDistrictMaster();

            aa.stateMaster = objdrpmaster.State_list();
            aa.districtMaster = objdrpmaster.dropdownlist_display1();

            string ext = string.Empty;
            string FilePathExt = string.Empty;

            string error = string.Empty;
            int errorstate = 0;

            //reset inputs
            switch (smodel.CoPromoterType_Flag)
            {
                case 1:
                    {
                        //Individual CASE
                        smodel.Org_Type = string.IsNullOrEmpty(smodel.Org_Type) ? "0" : smodel.Org_Type;
                        smodel.Link_RegDiaryNumber_NameYear = string.IsNullOrEmpty(smodel.Link_RegDiaryNumber_NameYear) ? "0" : smodel.Link_RegDiaryNumber_NameYear;
                        smodel.Column_A = "File";
                        smodel.Column_B = string.IsNullOrEmpty(smodel.Column_B) ? "0" : smodel.Column_B;
                        break;
                    }
                case 2:
                    {
                        //Other-Than-Individual CASE
                        smodel.Individual_Gender = null;
                        smodel.Link_RegDiaryNumber_NameYear = string.IsNullOrEmpty(smodel.Link_RegDiaryNumber_NameYear) ? "0" : smodel.Link_RegDiaryNumber_NameYear;
                        smodel.Column_A = "ImageNA";
                        smodel.Column_B = string.IsNullOrEmpty(smodel.Column_B) ? "0" : smodel.Column_B;
                        break;
                    }                    
            }

            if (TempData["submitvalue"].ToString() == "Update")
            {
                if (smodel.CoPromoterType_Flag == 1)
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
                                var pathpromoterdata = "";
                                var pathindb = "";
                                string masterPromoterDoc_SetFilePath = "rwdataJointPromoter";
                                #endregion

                                #region UpdateFile Path Creation 
                                if (!String.IsNullOrEmpty(smodel.CoPromoterImage_FilePath))
                                {
                                    pathindb = smodel.CoPromoterImage_FilePath.ToString();
                                }
                                else
                                {
                                    pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
                                }
                                pathpromoterdata = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(pathpromoterdata))
                                {
                                    Directory.CreateDirectory(pathpromoterdata);
                                }
                                #endregion

                                var fileName = string.Empty;
                                if (!String.IsNullOrEmpty(smodel.CoPromoterImage_FileName))
                                {
                                    fileName = smodel.CoPromoterImage_FileName.ToString();
                                }
                                else
                                {
                                    fileName = "JPromoter_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                }
                                var path = Path.Combine(pathpromoterdata, fileName);
                                files.SaveAs(path);
                                Photo_Address = fileName;
                                FilePathExt = pathindb;
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

                    if (Photo_Address == "")
                    {
                        Photo_Address = smodel.CoPromoterImage_FileName;
                        ext = Path.GetExtension(smodel.CoPromoterImage_FileName);
                        FilePathExt = smodel.CoPromoterImage_FilePath;
                    }
                }
                else
                {
                    smodel.CoPromoterImage_FileName = string.Empty;
                    smodel.CoPromoterImage_FilePath = string.Empty;

                    //case : other-than-individual
                    errorstate = 0;
                }

                try
                {
                    if (errorstate == 0)
                    {                       
                        if (ModelState.IsValid)
                        {
                            ClsMethod_JointPromoter_RegistrationDetail sdb = new ClsMethod_JointPromoter_RegistrationDetail();
                            
                            sdb.Update_JointPromoter_RegistrationDetail(smodel, userName, userID);
                            TempData["message"] = "Joint-Promoter Details updated Successfully";

                            ModelState.Clear();
                        }
                        return RedirectToAction("Create_JointPromoterProfile");
                    }
                    else
                    {
                        return RedirectToAction("Create_JointPromoterProfile");
                    }
                }
                catch (Exception ex)
                {
                    //if (System.IO.File.Exists(path))
                    //{
                    //    System.IO.File.Delete(path);
                    //}
                    string strRET = ex.ToString();
                    return View("Create_JointPromoterProfile", aa);
                }
            }
            else
            {
                if (smodel.CoPromoterType_Flag == 1)
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
                                var pathpromoterdata = "";
                                var pathindb = "";
                                string masterPromoterDoc_SetFilePath = "rwdataJointPromoter";
                                #endregion

                                #region SaveFile Path Creation
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Application_id) + "\\";
                                pathpromoterdata = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(pathpromoterdata))
                                {
                                    Directory.CreateDirectory(pathpromoterdata);
                                }
                                #endregion

                                var fileName = string.Empty;
                                fileName = "JPromoter_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                var path = Path.Combine(pathpromoterdata, fileName);
                                files.SaveAs(path);
                                Photo_Address = fileName;
                                FilePathExt = pathindb;
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
                }
                else
                {
                    smodel.CoPromoterImage_FileName = string.Empty;
                    smodel.CoPromoterImage_FilePath = string.Empty;

                    //case : other-than-individual
                    errorstate = 0;
                }

                try
                {
                    if (errorstate == 0)
                    {
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.CoPromoterImage_FileName;
                            ext = Path.GetExtension(smodel.CoPromoterImage_FileName);
                            FilePathExt = smodel.CoPromoterImage_FilePath;
                        }

                        if (ModelState.IsValid)
                        {
                            ClsMethod_JointPromoter_RegistrationDetail sdb = new ClsMethod_JointPromoter_RegistrationDetail();

                            if (sdb.Add_JointPromoter_RegistrationDetail(smodel, Application_id, Application_type, Photo_Address, FilePathExt, userName, userID))
                            {                                
                                TempData["message"] = "Joint-Promoter Details Added Successfully";
                                ModelState.Clear();
                            }
                            return RedirectToAction("Create_JointPromoterProfile");
                        }
                        else
                        {
                            return RedirectToAction("Create_JointPromoterProfile");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string strRET = ex.ToString();
                    return View("Create_JointPromoterProfile");
                }
            }
            return View("Create_JointPromoterProfile", aa);
        }

        [HttpGet]
        public ActionResult Edit_JointPromoterProfile(Int64 JPrmAppID, int JPrmType, Int64 JPrmIndexID)
        {
            ClsMethod_JointPromoter_RegistrationDetail sdb = new ClsMethod_JointPromoter_RegistrationDetail();
            ClsPrp_JointPromoter_RegistrationDetails aa = new ClsPrp_JointPromoter_RegistrationDetails();
            ClsMethodDistrictMaster objdrpmaster = new ClsMethodDistrictMaster();

            Int64 Application_id = 0;
            Int32 Application_type = 0;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                }
            }

            try
            {
                string userRole = string.Empty;
                var userID = User.Identity.GetUserId();

                aa.stateMaster = objdrpmaster.State_list();
                aa.districtMaster = objdrpmaster.dropdownlist_display1();

                aa.prpjointpromoter = sdb.Display_ByFilterID_JointPromoter_RegistrationDetail(JPrmAppID, JPrmType, JPrmIndexID, userRole, userID);
                foreach (var item in aa.prpjointpromoter)
                {
                    aa.CoPromoter_IndexID = item.CoPromoter_IndexID;
                    aa.CoPromoter_ApplicationID = item.CoPromoter_ApplicationID;
                    aa.CoPromoterType_Flag = item.CoPromoterType_Flag;

                    //OTI Case
                    aa.Org_Title = item.Org_Title;
                    aa.Org_Name = item.Org_Name;
                    aa.Org_Type = item.Org_Type;
                    aa.OTI_Org_Objects = item.OTI_Org_Objects;

                    //IND Case
                    aa.First_Name = item.First_Name;
                    aa.Middle_Name = item.Middle_Name;
                    aa.Last_Name = item.Last_Name;
                    aa.Individual_Gender = item.Individual_Gender;
                    aa.Fath_First_Name = item.Fath_First_Name;
                    aa.Fath_Middle_Name = item.Fath_Middle_Name;
                    aa.Fath_Last_Name = item.Fath_Last_Name;
                    aa.Ind_Org_Objects = item.Ind_Org_Objects;

                    //Registered Address
                    aa.Registered_Address_Org_Line1 = item.Registered_Address_Org_Line1;
                    aa.Registered_Address_Org_Line2 = item.Registered_Address_Org_Line2;
                    aa.Registered_Address_Org_State = item.Registered_Address_Org_State;
                    aa.Registered_Address_Org_District = item.Registered_Address_Org_District;
                    aa.Registered_Address_Org_Pin_Code = item.Registered_Address_Org_Pin_Code;
                    aa.Registered_Address_Org_DistrictState_Name = item.Registered_Address_Org_DistrictState_Name;

                    //Permanent Address
                    aa.Permanent_Address_Prm_Line1 = item.Permanent_Address_Prm_Line1;
                    aa.Permanent_Address_Prm_Line2 = item.Permanent_Address_Prm_Line2;
                    aa.Permanent_Address_Prm_State = item.Permanent_Address_Prm_State;
                    aa.Permanent_Address_Prm_District = item.Permanent_Address_Prm_District;
                    aa.Permanent_Address_Prm_Pin_Code = item.Permanent_Address_Prm_Pin_Code;
                    aa.Permanent_Address_Prm_DistrictState_Name = item.Permanent_Address_Prm_DistrictState_Name;

                    //Communication Address
                    aa.Communication_AddressLine1 = item.Communication_AddressLine1;
                    aa.Communication_AddressLine2 = item.Communication_AddressLine2;
                    aa.Communication_AddressStateCode = item.Communication_AddressStateCode;
                    aa.Communication_AddressDistrictCode = item.Communication_AddressDistrictCode;
                    aa.Communication_AddressPIN = item.Communication_AddressPIN;
                    aa.Communication_Address_DistrictState_Name = item.Communication_Address_DistrictState_Name;

                    //Authorized Person details
                    aa.AuthorizedPerson_Name = item.AuthorizedPerson_Name;
                    aa.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;
                    aa.AuthorizedPerson_LandlineNumber_STD = item.AuthorizedPerson_LandlineNumber_STD;
                    aa.AuthorizedPerson_LandlineNumber = item.AuthorizedPerson_LandlineNumber;
                    aa.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;

                    //Authorized Person Address
                    aa.IsAuthorizedPersonAddress = item.IsAuthorizedPersonAddress;
                    aa.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                    aa.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                    aa.AuthorizedPerson_AddressStateCode = item.AuthorizedPerson_AddressStateCode;
                    aa.AuthorizedPerson_AddressDistrictCode = item.AuthorizedPerson_AddressDistrictCode;
                    aa.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;
                    aa.AuthorizedPerson_AddressDistrictState_Name = item.AuthorizedPerson_AddressDistrictState_Name;

                    //Other Parms
                    aa.CoPromoter_Occupation = item.CoPromoter_Occupation;
                    aa.CoPromoter_WebLink = item.CoPromoter_WebLink;
                    aa.CoPromoter_PAN_Number = item.CoPromoter_PAN_Number;
                    aa.CoPromoter_Aadhaar_Number = item.CoPromoter_Aadhaar_Number;

                    aa.IsExperience = item.IsExperience;
                    aa.Past_Experience_InYear = item.Past_Experience_InYear;
                    aa.IsLitigation_RelatedProject = item.IsLitigation_RelatedProject;
                    aa.Past_Litigations_InNumber = item.Past_Litigations_InNumber;
                    aa.IsOrganizationMembers = item.IsOrganizationMembers;
                    aa.IsOrganizationParent_Entity = item.IsOrganizationParent_Entity;

                    aa.IsUploadPhotograph = item.IsUploadPhotograph;
                    aa.CoPromoterImage_FilePath = item.CoPromoterImage_FilePath;
                    aa.CoPromoterImage_FileName = item.CoPromoterImage_FileName;

                    //Related Reference ID
                    //Dropdown value - Related_ProjectID - START
                    aa.Related_Project_ID = item.Related_Project_ID;
                    aa.Related_Used_ID = item.Related_Used_ID;
                    aa.Related_Promoter_Application_ID = item.Related_Promoter_Application_ID;

                    //Another Primary Promoter ID
                    aa.Link_RegDiaryNumber_ID = item.Link_RegDiaryNumber_ID;
                    aa.Link_RegDiaryNumber_Name = item.Link_RegDiaryNumber_Name;
                    aa.Link_RegDiaryNumber_NameYear = item.Link_RegDiaryNumber_NameYear;
                    aa.Column_A = item.Column_A;
                    aa.Column_B = item.Column_B;
                    //END

                    aa.RemarksIfAny = item.RemarksIfAny;
                    aa.Column_C = item.Column_C;
                    aa.Column_D = item.Column_D;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.Created_On = item.Created_On;
                    aa.Created_By = item.Created_By;
                    aa.Modified_On = item.Modified_On;
                    aa.Modify_By = item.Modify_By;
                    // CoPromoter Registration Parms

                    aa.IsBriefSummaryDraft = item.IsBriefSummaryDraft;
                    aa.IsBriefSummaryLock = item.IsBriefSummaryLock;
                    aa.IsDraftCoPromoters = item.IsDraftCoPromoters;

                    aa.JointPromoter_Name = item.JointPromoter_Name;
                    aa.JointPromoter_District = item.JointPromoter_District;
                    aa.JointPromoter_Type = item.JointPromoter_Type;
                }
                //aa.stateMaster = objdrpmaster.State_list();
                //aa.districtMaster = objdrpmaster.dropdownlist_display1(Convert.ToInt32(aa.State));

                #region Promoter-Lock
                Get_Isdraftvalue_FromDiaryNumber(Application_id);
                #endregion
            }
            catch (Exception ex)
            {
                string strRT = ex.ToString();
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();

            return View("Create_JointPromoterProfile", aa);
        }
  
        [HttpPost]
        public ActionResult Edit_JointPromoterProfile(ClsPrp_JointPromoter_RegistrationDetails smodel)
        {
            try
            {
                var userID = User.Identity.GetUserId();
                string userName = User.Identity.Name;

                ClsMethod_JointPromoter_RegistrationDetail sdb = new ClsMethod_JointPromoter_RegistrationDetail();
                sdb.Update_JointPromoter_RegistrationDetail(smodel, userName, userID);
                return RedirectToAction("Create_JointPromoterProfile");
            }
            catch (Exception ex)
            {
                string strEX = ex.ToString();
                return View();
            }
        }

        public ActionResult Delete_JointPromoterProfile(Int64 JPrmAppID, int JPrmType, Int64 JPrmIndexID)
        {
            ClsMethod_JointPromoter_RegistrationDetail sdb = new ClsMethod_JointPromoter_RegistrationDetail();
            ClsPrp_JointPromoter_RegistrationDetails aa = new ClsPrp_JointPromoter_RegistrationDetails();
            ClsMethodDistrictMaster objdrpmaster = new ClsMethodDistrictMaster();

            try
            {
                string userRole = string.Empty;
                var userID = User.Identity.GetUserId();

                Int64 _jointPromoter_IndexID = JPrmIndexID;
                Int64 _jointPromoter_ApplicationID = JPrmAppID;
                Int32 _jointPromoterType_Flag = JPrmType;

                aa.stateMaster = objdrpmaster.State_list();
                aa.districtMaster = objdrpmaster.dropdownlist_display1();

                if (sdb.Delete_JointPromoter_RegistrationDetail(_jointPromoter_ApplicationID, _jointPromoterType_Flag, _jointPromoter_IndexID, userRole, userID))
                {
                    TempData["message"] = "Joint-Promoter Details deleted Successfully";
                }                
            }
            catch (Exception ex)
            {
                string strRT = ex.ToString();
                return View();
            }

            TempData["submitvalue"] = "Save";
            TempData.Keep();

            return View("Create_JointPromoterProfile", aa);            
        }
        #endregion

        ///  Joint-Promoter Litigations(If Any)
        #region
        [HttpGet]
        public ActionResult Create_JointPromoterTrackLitigations()
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;
            Int64 JointPromoterID = 0;
            Int32 JointPromoterType = 0;
            Int32 flag = 0;
            string userRole = string.Empty;
            var userID = User.Identity.GetUserId();

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                }
                else
                {
                    return RedirectToAction("Create_JointPromoterTrackLitigationsNA", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            #region movement- JointPromoter Detail
            try
            {
                string UserNam = string.Empty;
                ClsMethod_JointPromoter_ReviewConfirm sdbYN = new ClsMethod_JointPromoter_ReviewConfirm();
                Tuple<string, Int32> JointPromoterYN = sdbYN.JointPromoter_YN_TrackRecordLitigations_ByID(Application_id, Application_type, userID, UserNam);

                if (JointPromoterYN.Item1 == "N" && JointPromoterYN.Item2 == 0)
                {
                    return RedirectToAction("Create_JointPromoterTrackLitigationsNA", "Promoter");
                }
            }
            catch(Exception ex)
            {
                string retYN = ex.ToString();
            }
            #endregion

            ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();
            ClsPrp_JointPromoter_TrackLitigations aa = new ClsPrp_JointPromoter_TrackLitigations();
            ClsMethod_JointPromoter_RegistrationDetail clsJnPrm = new ClsMethod_JointPromoter_RegistrationDetail();

            aa.prpongoing = sdb.Display_JointPromoter_TrackRecord_LitigationsByID(Application_id, JointPromoterID, JointPromoterType, flag, userRole, userID);

            aa.Prp_Project_Name = clsJnPrm.ListofProjects(Application_id, Application_type);
            aa.Prp_JointPromoter_Name = clsJnPrm.ListofJointPromoters(Application_id, Application_type);

            #region get-Promoter-Lock
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion
            #region get-JointPromoter-Lock
            //set Temp-Variable
            Get_JointPromoter_Isdraftvalue_FromDiaryNumber(0, 0);
            #endregion

            ViewBag.submitvalue = "Save";
            return View("Create_JointPromoterTrackLitigations", aa);
        }

        public ActionResult Partial_JointPromoterTrackLitigations_ByFilterID(Int64 jointpromoterID, Int32 jointpromoterType)
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;
            Int64 JointPromoterID = 0;
            Int32 JointPromoterType = 0;
            Int32 flag = 0;
            string userRole = string.Empty;
            var userID = User.Identity.GetUserId();

            #region Set All-Parms
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            #endregion

            JointPromoterID = jointpromoterID;
            JointPromoterType = jointpromoterType;

            #region get-Promoter-Lock and JointPromoter-Lock
            //Promoter-Lock
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            //Promoter and Joint-Pormoter Lock
            Get_JointPromoter_Isdraftvalue_FromDiaryNumber(JointPromoterID, JointPromoterType);
            #endregion

            ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();
            ClsPrp_JointPromoter_TrackLitigations aa = new ClsPrp_JointPromoter_TrackLitigations();
            ClsMethod_JointPromoter_RegistrationDetail clsJnPrm = new ClsMethod_JointPromoter_RegistrationDetail();

            aa.prpongoing = sdb.Display_JointPromoter_TrackRecord_LitigationsByID(Application_id, JointPromoterID, JointPromoterType, flag, userRole, userID);

            aa.Prp_Project_Name = clsJnPrm.ListofProjects(Application_id, Application_type);
            aa.Prp_JointPromoter_Name = clsJnPrm.ListofJointPromoters(Application_id, Application_type);
            //aa.Extra4 = retValue;

            return PartialView("Partial_JointPromoterTrackLitigations", aa);
        }

        public ActionResult GetEditorData_JointPromoterTrackLitigations_ByFilterID(Int64 p_projectId)
        {
            Int64 Application_id = 0;            
            Int64 Litigation_ProjectID = 0;

            Int64 _Application_id = 0;
            Int64 _Id = 0;
            string _ProjectType = "0";
            string _ProjectStatus = string.Empty;
            double _AreaConUProject = 0.0000;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            try
            {
                Litigation_ProjectID = p_projectId;

                ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();
                ClsPrp_OngoingProjectLFiveYears aa = new ClsPrp_OngoingProjectLFiveYears();

                aa.prpongoing = sdb.Display_Master_ByFilterID_LitigationsRelatedProjectID_ongoingProject(Litigation_ProjectID, Application_id);
                foreach (var item in aa.prpongoing)
                {
                    aa.Application_id = item.Application_id;
                    aa.Id = item.Id;
                    aa.ProjectType = item.ProjectType;
                    aa.ProjectStatus = item.ProjectStatus;
                    aa.AreaConUProject = item.AreaConUProject;
                    aa.ProjectStartDate = item.ProjectStartDate;
                }

                _Application_id = aa.Application_id;
                _Id = aa.Id;
                _ProjectType = aa.ProjectType;
                _ProjectStatus = aa.ProjectStatus;
                _AreaConUProject = aa.AreaConUProject;
            }
            catch (Exception ex)
            {
                string strES = ex.ToString();

                return Json(new
                {
                    //Error 
                    statusCode = 101,
                    statusID = _Application_id,
                    statusPType = _ProjectType,
                    statusPStatus = _ProjectStatus,
                    statusArea = _AreaConUProject,
                    remarks = "Error!"
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {      
                //Found Record          
                statusCode = 105,
                statusID = _Application_id,
                statusPType = _ProjectType,
                statusPStatus = _ProjectStatus,
                statusArea = _AreaConUProject,
                remarks = "Success!"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create_JointPromoterTrackLitigations(ClsPrp_JointPromoter_TrackLitigations smodel)
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;
            string userRole = string.Empty;

            var userID = User.Identity.GetUserId();
            var userName = User.Identity.Name;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            try
            {
                if (smodel.LitigationsRelated_ProjectName != "0")
                {
                    ModelState.Remove("Project_Name");
                }
                if (smodel.JointPromoter_LitigationsFlag == 0) //No Litigation, Only Track Record
                {                    
                    ModelState.Remove("Case_Title");
                    ModelState.Remove("Case_Number");
                    ModelState.Remove("Authority_ForumName_CasePendingResolved");
                }

                if (ModelState.IsValid)
                {
                    ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();
                    if (sdb.Add_JointPromoter_TrackRecord_LitigationsDetail(smodel, Application_id, Application_type, userName, userID))
                    {
                        TempData["message"] = "Litigation Details Added Successfully";
                        ModelState.Clear();
                    }
                }                
                return RedirectToAction("Create_JointPromoterTrackLitigations");
            }
            catch (Exception ex)
            {
                string strEX = ex.ToString();
                return RedirectToAction("Create_JointPromoterTrackLitigations");
            }
        }

        [HttpGet]
        public ActionResult Edit_JointPromoterTrackLitigations(Int64 JPrmAppID, int JPrmType, Int64 JPrmLitigationIndexID, Int64 JPrmLitigationID)
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;

            ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();
            ClsPrp_JointPromoter_TrackLitigations aa = new ClsPrp_JointPromoter_TrackLitigations();
            ClsMethod_JointPromoter_RegistrationDetail clsJnPrm = new ClsMethod_JointPromoter_RegistrationDetail();

            try
            {
                string userRole = string.Empty;
                var userID = User.Identity.GetUserId();

                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        Application_type = Convert.ToInt32(Session["User_Type"]);
                    }
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }

                aa.Prp_Project_Name = clsJnPrm.ListofProjects(Application_id, Application_type);
                aa.Prp_JointPromoter_Name = clsJnPrm.ListofJointPromoters(Application_id, Application_type);

                #region get-Promoter-Lock and JointPromoter-Lock
                //Promoter-Lock
                Get_Isdraftvalue_FromDiaryNumber(Application_id);
                //Promoter and Joint-Pormoter Lock
                Get_JointPromoter_Isdraftvalue_FromDiaryNumber(JPrmAppID, JPrmType);
                #endregion

                aa.prpongoing = sdb.Display_ByFilterID_JointPromoter_TrackRecord_LitigationsDetail(Application_id, JPrmAppID, JPrmType, JPrmLitigationIndexID, JPrmLitigationID, userRole, userID);

                foreach (var item in aa.prpongoing)
                {
                    aa.JointPromoter_Litigations_IndexID = item.JointPromoter_Litigations_IndexID;
                    aa.JointPromoter_Litigation_ID = item.JointPromoter_Litigation_ID;

                    aa.Related_Promoter_ID = item.Related_Promoter_ID;
                    aa.Related_PromoterType = item.Related_PromoterType;
                    aa.Related_JointPromoter_ID = item.Related_JointPromoter_ID;
                    aa.Related_JointPromoterType = item.Related_JointPromoterType;

                    aa.LitigationsRelated_JointPromoterName = item.LitigationsRelated_JointPromoterName;
                    aa.LitigationsRelated_ProjectName = item.LitigationsRelated_ProjectName;
                    aa.Project_Name = item.Project_Name;
                    aa.Project_Type = item.Project_Type;
                    aa.Project_Status = item.Project_Status;
                    aa.Project_AreaConstructed = item.Project_AreaConstructed;

                    aa.Case_Title = item.Case_Title;
                    aa.Case_Number = item.Case_Number;
                    aa.Authority_ForumName_CasePendingResolved = item.Authority_ForumName_CasePendingResolved;

                    aa.JointPromoter_LitigationsFlag = item.JointPromoter_LitigationsFlag;
                    aa.JointPromoter_LitigationsCondition = item.JointPromoter_LitigationsCondition;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.Flag = item.Flag;
                    aa.Created_By = item.Created_By;
                    aa.Created_On = item.Created_On;
                    aa.Modify_By = item.Modify_By;
                    aa.Modified_On = item.Modified_On;

                    aa.Extra1 = item.Extra1;
                    aa.Extra2 = item.Extra2;
                    aa.Extra3 = item.Extra3;
                    aa.Extra4 = item.Extra4;
                }
            }
            catch (Exception ex)
            {
                string strRT = ex.ToString();
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();

            return View("Create_JointPromoterTrackLitigations", aa);
        }

        [HttpPost]
        public ActionResult Edit_JointPromoterTrackLitigations(ClsPrp_JointPromoter_TrackLitigations smodel)
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;
            string userRole = string.Empty;

            var userID = User.Identity.GetUserId();
            var userName = User.Identity.Name;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Application_id = Convert.ToInt64(Session["ApplicationId"]);
                    Application_type = Convert.ToInt32(Session["User_Type"]);
                    //if (Session["User_JointPromoterTrackRecordFlag"].ToString() != "1")
                    //{
                    //    //In Not Track Record
                    //    return RedirectToAction("Create_JointPromoterTrackLitigationsNA", "Promoter");
                    //}
                    //if (Session["User_JointPromoterLitigationsFlag"].ToString() != "1")
                    //{
                    //    //In Not Litigatioins Record
                    //    return RedirectToAction("Create_JointPromoterTrackLitigationsNA", "Promoter");
                    //}
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            try
            {
                if (smodel.LitigationsRelated_ProjectName != "0")
                {
                    ModelState.Remove("Project_Name");
                }
                if (smodel.JointPromoter_LitigationsFlag == 0) //No Litigation, Only Track Record
                {
                    ModelState.Remove("Case_Title");
                    ModelState.Remove("Case_Number");
                    ModelState.Remove("Authority_ForumName_CasePendingResolved");
                }

                if (ModelState.IsValid)
                {
                    ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();

                    sdb.Update_JointPromoter_TrackRecord_LitigationsDetail(smodel, Application_id, Application_type, userName, userID);
                    TempData["message"] = "Litigation Details updated Successfully";
                    ModelState.Clear();
                }
                return RedirectToAction("Create_JointPromoterTrackLitigations");
            }
            catch (Exception ex)
            {
                string strEX = ex.ToString();
                return RedirectToAction("Create_JointPromoterTrackLitigations");
            }
        }

        public ActionResult Delete_JointPromoterTrackLitigations(Int64 JPrmAppID, int JPrmType, Int64 JPrmLitigationIndexID, Int64 JPrmLitigationID)
        {
            Int64 Application_id = 0;
            Int32 Application_type = 0;

            ClsMethod_JointPromoter_Litigations sdb = new ClsMethod_JointPromoter_Litigations();
            ClsPrp_JointPromoter_TrackLitigations aa = new ClsPrp_JointPromoter_TrackLitigations();
            ClsMethod_JointPromoter_RegistrationDetail clsJnPrm = new ClsMethod_JointPromoter_RegistrationDetail();

            try
            {
                string userRole = string.Empty;
                var userID = User.Identity.GetUserId();

                Int64 _jointPromoter_LitigationIndexID = JPrmLitigationIndexID;
                Int64 _jointPromoter_LitigationID = JPrmLitigationID;
                Int64 _jointPromoter_ApplicationID = JPrmAppID;
                Int32 _jointPromoterType_Flag = JPrmType;

                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        Application_type = Convert.ToInt32(Session["User_Type"]);
                    }
                }

                aa.Prp_Project_Name = clsJnPrm.ListofProjects(Application_id, Application_type);
                aa.Prp_JointPromoter_Name = clsJnPrm.ListofJointPromoters(Application_id, Application_type);

                if (sdb.Delete_JointPromoter_TrackRecord_Litigations(Application_id, Application_type, _jointPromoter_ApplicationID, _jointPromoter_LitigationIndexID, _jointPromoter_LitigationID, userRole, userID))
                {
                    TempData["message"] = "Litigation details deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                string strRT = ex.ToString();
                return View();
            }

            TempData["submitvalue"] = "Save";
            TempData.Keep();

            //return RedirectToAction("Create_JointPromoterTrackLitigations");
            return View("Create_JointPromoterTrackLitigations", aa);
        }
        #endregion

        #region Joint Promoter - Not Applicable
        [HttpGet]
        public ActionResult Create_JointPromoterProfileNA()
        {
            return View("Create_JointPromoterProfileNA");
        }

        [HttpGet]
        public ActionResult Create_JointPromoterTrackLitigationsNA()
        {            
            return View("Create_JointPromoterTrackLitigationsNA");
        }

        [HttpGet]
        public ActionResult Search_promoterlistpreviousregistrationNA(string flagid, string flagkey)
        {
            return View("Search_promoterlistpreviousregistrationNA");
        }
        #endregion

        // Joint-Promoter List
        #region Joint-Promoter List
        [HttpGet]
        public ActionResult Search_promoterlistpreviousregistration(string flagid, string flagkey)
        {
            Int64 Application_id = 0;

            ClsPrp_JointPromoter_SearchOptionDetails aa = new ClsPrp_JointPromoter_SearchOptionDetails();
            ClsMethodDistrictMaster objdrpmaster = new ClsMethodDistrictMaster();

            #region Promoter-Lock
            Application_id = string.IsNullOrEmpty(flagid) ? 0 : Convert.ToInt64(flagid);
            Get_Isdraftvalue_FromDiaryNumber(Application_id);
            #endregion

            aa.districtMaster = objdrpmaster.dropdownlist_display1(28);

            if (aa.districtMaster == null)
            {
                aa.districtMaster = new List<ClsPrp_DistrictMaster>();
            }
            aa.districtMaster.Add(new ClsPrp_DistrictMaster { DistrictId = 111098, DistrictName = "All" });          

            var sortedDistricts = aa.districtMaster.OrderBy(d => d.DistrictName ?? "").ToList();
            aa.districtMaster = sortedDistricts;
            aa.districtMaster.Add(new ClsPrp_DistrictMaster { DistrictId = 111099, DistrictName = "Others" });



            return View("Search_promoterlistpreviousregistration", aa);
        }

        [HttpPost]
        public ActionResult Display_SearchRegisteredPromoterList(ClsPrp_JointPromoter_SearchOptionDetails[] order)
        {
            bool status = false;
            Int64? chkappid = null;

            Int64 parmDistrictID = 0;
            Int32 parmFlag = 0;
            string parmProjectName = string.Empty;
            string parmPromoterName = string.Empty;
            string parmRegistrationNumber = string.Empty;
            string parmUserRole = string.Empty;
            string parmUserID = string.Empty;
            int retNumberRecords = 0;

            ClsMethod_JointPromoter_RegistrationDetail sdbrecords = new ClsMethod_JointPromoter_RegistrationDetail();
            ClsPrp_JointPromoter_SearchOptionDetails clsprp = new ClsPrp_JointPromoter_SearchOptionDetails();

            try
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        #region Search options Values

                        parmDistrictID = Convert.ToInt64(item.SearchOption_RelatedDistrictID);
                        parmFlag = Convert.ToInt32(item.SearchOption_RelatedDistrictID);
                        parmProjectName = Convert.ToString(item.SearchOption_RelatedProjectName);
                        parmPromoterName = Convert.ToString(item.SearchOption_RelatedPromoterName);
                        parmRegistrationNumber = Convert.ToString(item.SearchOption_RelatedRegistrationNumber);
                        parmUserRole = User.Identity.Name;
                        parmUserID = User.Identity.GetUserId();


                        parmProjectName = String.Concat('%' , parmProjectName, '%');
                        parmPromoterName = String.Concat('%', parmPromoterName, '%');

                        #endregion

                        clsprp.prpsearchpromoter = sdbrecords.Display_ByFilterID_RegisteredPromotersDetail(parmDistrictID, parmFlag, parmProjectName, parmPromoterName, parmRegistrationNumber, parmUserRole, parmUserID);
                        //var mirrorRecords = GetMirrorPublicViewProjectResults(parmDistrictID, parmProjectName, parmPromoterName, parmRegistrationNumber);
                        //MergeMirrorProjectResults(clsprp.prpsearchpromoter, mirrorRecords);
                        retNumberRecords = clsprp.prpsearchpromoter.Count;

                        chkappid = 1;
                    }
                }
            }
            catch(Exception ex)
            {
                string strEX = ex.ToString();
                status = false;
            }

            if (chkappid == null)
                status = false;
            else
                status = true;


            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    statusObjRet = clsprp.prpsearchpromoter,
                    statusRecordsFound = retNumberRecords,
                    statusDistrictID = parmDistrictID,
                    statusProjectName = parmProjectName,
                    statusPromoterName = parmPromoterName,
                    statusRegdNumber = parmRegistrationNumber,
                    remarks = "Success"
                }
            };
        }

        [HttpPost]
        public JsonResult Get_Autocomplete_ProjectName(string Prefix)
        {
            ClsMethod_JointPromoter_RegistrationDetail objdis = new ClsMethod_JointPromoter_RegistrationDetail();
            try
            {
                var states = objdis.Display_PublicView_Autocomplete_ProjectName(Prefix);
                //var mirrorStates = GetMirrorPublicViewProjectResults(0, Prefix, string.Empty, string.Empty)
                //    .Select(x => new ClsPrp_JointPromoter_SearchOptionParamDetails
                //    {
                //        SearchOption_RelatedProjectName = x.mLinkTo_Reference_ProjectName
                //    })
                //    .ToList();

                //states = states
                //    .Concat(mirrorStates)
                //    .GroupBy(x => (x.SearchOption_RelatedProjectName ?? string.Empty).Trim(), StringComparer.OrdinalIgnoreCase)
                //    .Select(x => x.First())
                //    .ToList();

                return Json(states, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_Autocomplete_PromoterName(string Prefix)
        {
            ClsMethod_JointPromoter_RegistrationDetail objdis = new ClsMethod_JointPromoter_RegistrationDetail();
            try
            {
                var states = objdis.Display_PublicView_Autocomplete_PromoterName(Prefix);
                //var mirrorStates = GetMirrorPublicViewProjectResults(0, string.Empty, Prefix, string.Empty)
                //    .Select(x => new ClsPrp_JointPromoter_SearchOptionParamDetails
                //    {
                //        SearchOption_RelatedPromoterName = x.mLinkTo_Reference_PromoterName
                //    })
                //    .ToList();

                //states = states
                //    .Concat(mirrorStates)
                //    .GroupBy(x => (x.SearchOption_RelatedPromoterName ?? string.Empty).Trim(), StringComparer.OrdinalIgnoreCase)
                //    .Select(x => x.First())
                //    .ToList();

                return Json(states, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        //#region CURSOR


        //private static string NormalizeLikeTerm(string term)
        //{
        //    if (string.IsNullOrWhiteSpace(term))
        //    {
        //        return string.Empty;
        //    }

        //    return term.Replace("%", string.Empty).Trim();
        //}

        //private static bool ContainsIgnoreCase(string source, string toMatch)
        //{
        //    if (string.IsNullOrWhiteSpace(toMatch))
        //    {
        //        return true;
        //    }

        //    return (source ?? string.Empty).IndexOf(toMatch, StringComparison.OrdinalIgnoreCase) >= 0;
        //}

        //private List<ClsPrp_JointPromoter_SearchOptionDetails> GetMirrorPublicViewProjectResults(long districtId,string projectNameLike,string promoterNameLike,string registrationNumber)
        //{
        //    var mirrorMatches = new List<ClsPrp_JointPromoter_SearchOptionDetails>();
        //    var workFileModel = new ClsMethod_View_ProjectWorkingFilesHelpdesk();
        //    var publicViewProjects = workFileModel.Display_AuthorityDesk_ProjectWorkingFileDetailsPublicView(string.Empty);

        //    var normalizedProject = NormalizeLikeTerm(projectNameLike);
        //    var normalizedPromoter = NormalizeLikeTerm(promoterNameLike);
        //    var normalizedRegNo = NormalizeLikeTerm(registrationNumber);

        //    var filteredProjects = publicViewProjects.Where(x =>
        //        (districtId == 0 || x.Project_AddressDistrictName == null || districtId == 111098 || districtId == 111099 || x.Project_AddressDistrictName.Length >= 0) &&
        //        ContainsIgnoreCase(x.Project_Name, normalizedProject) &&
        //        ContainsIgnoreCase(x.Promoter_Name, normalizedPromoter) &&
        //        ContainsIgnoreCase(x.Project_RERAregistrationNumber, normalizedRegNo));

        //    foreach (var item in filteredProjects)
        //    {
        //        mirrorMatches.Add(new ClsPrp_JointPromoter_SearchOptionDetails
        //        {
        //            mLinkTo_Project_RegistrationNumber = item.Project_RERAregistrationNumber,
        //            mLinkTo_Reference_ProjectID = item.Project_ID,
        //            mLinkTo_Reference_ProjectName = item.Project_Name,
        //            mLinkTo_Reference_PromoterID = item.Promoter_ID,
        //            mLinkTo_Reference_PromoterName = item.Promoter_Name,
        //            mLinkTo_Reference_DistrictName = item.Project_AddressDistrictName,
        //            Link_RegDiaryNumber_ID = item.Project_RegDiaryNumber_ID,
        //            Link_RegDiaryNumber_Name = item.PromoterRegDiaryNumber_Name,
        //            Link_RegDiaryNumber_NameYear = item.PromoterRegDiaryNumber_NameYear,
        //            JointPromoter_Name = item.Promoter_Name,
        //            JointPromoter_District = item.Project_AddressDistrictName,
        //            CoPromoterType_Flag = item.PromoterType,
        //            Org_Name = item.Promoter_Name
        //        });
        //    }

        //    return mirrorMatches;
        //}

        //private static void MergeMirrorProjectResults(List<ClsPrp_JointPromoter_SearchOptionDetails> existingResults,List<ClsPrp_JointPromoter_SearchOptionDetails> mirrorResults)
        //{
        //    if (existingResults == null || mirrorResults == null || mirrorResults.Count == 0)
        //    {
        //        return;
        //    }

        //    var seen = new HashSet<string>(existingResults.Select(x => string.Format(
        //        "{0}|{1}|{2}",
        //        (x.mLinkTo_Project_RegistrationNumber ?? string.Empty).Trim().ToUpperInvariant(),
        //        (x.mLinkTo_Reference_ProjectName ?? string.Empty).Trim().ToUpperInvariant(),
        //        (x.mLinkTo_Reference_PromoterName ?? string.Empty).Trim().ToUpperInvariant())));

        //    foreach (var row in mirrorResults)
        //    {
        //        var key = string.Format(
        //            "{0}|{1}|{2}",
        //            (row.mLinkTo_Project_RegistrationNumber ?? string.Empty).Trim().ToUpperInvariant(),
        //            (row.mLinkTo_Reference_ProjectName ?? string.Empty).Trim().ToUpperInvariant(),
        //            (row.mLinkTo_Reference_PromoterName ?? string.Empty).Trim().ToUpperInvariant());

        //        if (seen.Add(key))
        //        {
        //            existingResults.Add(row);
        //        }
        //    }
        //}

        //#endregion

        #endregion

    }
}
