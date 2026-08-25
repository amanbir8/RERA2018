using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CRUD.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Configuration;

using CRUD.Models.PromoterProject;
using CRUD.Models.Promoter;
using CRUD.Models.Master;
using CRUD.Models.Agent;
using CRUD.Models.Complaint;

using System.Web.Routing;
using System.Text.RegularExpressions;
using System.Data;
using CRUD.Models.HelpdeskComplaint;
using CRUD.Models.HelpDeskComplaint;
using ClsMethod_ComplaintFormM_Registration = CRUD.Models.Complaint.ClsMethod_ComplaintFormM_Registration;
using ClsMethod_ComplaintFormN_Registration = CRUD.Models.Complaint.ClsMethod_ComplaintFormN_Registration;
using System.Security.Claims;
using CRUD.Filters;

namespace CRUD.Controllers.Complaint
{
    [Authorize]
    [Authorize(Roles = "Complainant")]
    public class ComplaintController : Controller
    {
        string Image_FileName = string.Empty;
        string PAN_Doc_Address = string.Empty;
        string FileName = string.Empty;
        string FilePath = string.Empty;
        
        #region Complaint User Profile
        [HttpGet]
        public ActionResult RegComplaintProfile()
        {   
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }                
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsPrp_ComplaintProfile aa = new ClsPrp_ComplaintProfile();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile sdb = new ClsMethod_ComplaintProfile();

            aa.ComplaintProfile = sdb.DisplayComplaintProfileDetail(ComplainantProfile_id);
            aa.districtMaster = objdis.dropdownlist_display1();


            aa.stateMaster = objdis.State_list();
            if (aa.ComplaintProfile.Count >= 1)
            {
                TempData["submitvalue"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }

            aa.MobileNumber = Convert.ToInt64(Session["Mobile_Number"]);
            aa.EmailAddress = Session["Email_Address"].ToString();

            foreach (var item in aa.ComplaintProfile)
            {                
                aa.ComplaintProfile_IndexID = item.ComplaintProfile_IndexID;
                aa.ComplaintProfile_ID = item.ComplaintProfile_ID;
                aa.UserID = item.UserID;

                aa.Applicant_FirstName = item.Applicant_FirstName;
                aa.Applicant_MiddleName = item.Applicant_MiddleName;
                aa.Applicant_LastName = item.Applicant_LastName;

                aa.Father_FirstName = item.Father_FirstName;
                aa.Father_MiddleName = item.Father_MiddleName;
                aa.Father_LastName = item.Father_LastName;

                aa.Occupation = item.Occupation;

                aa.Residencial_Official_AddressLine1 = item.Residencial_Official_AddressLine1;
                aa.Residencial_Official_AddressLine2 = item.Residencial_Official_AddressLine2;
                aa.Residencial_Official_AddressStateCode = item.Residencial_Official_AddressStateCode;
                aa.Residencial_Official_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                aa.Residencial_Official_AddressPIN = item.Residencial_Official_AddressPIN;

                aa.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;
                aa.Comm_AddressLine1 = item.Comm_AddressLine1;
                aa.Comm_AddressLine2 = item.Comm_AddressLine2;
                aa.Comm_AddressStateCode = item.Comm_AddressStateCode;
                aa.Comm_AddressDistrictCode = item.Comm_AddressDistrictCode;
                aa.Comm_AddressPIN = item.Comm_AddressPIN;

                aa.MobileNumber = item.MobileNumber;
                aa.PhoneNumber_STD = item.PhoneNumber_STD;
                aa.PhoneNumber_Number = item.PhoneNumber_Number;
                aa.EmailAddress = item.EmailAddress;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            return View("RegComplaintProfile", aa);            
        }

        [HttpPost]
        public ActionResult RegComplaintProfile(ClsPrp_ComplaintProfile smodel)
        {
            Int64 Complainant_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Complainant_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsMethod_ComplaintProfile sdb = new ClsMethod_ComplaintProfile();
            ClsPrp_ComplaintProfile clspro = new ClsPrp_ComplaintProfile();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
           
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            clspro.stateMaster = objdis.State_list();
            clspro.districtMaster = objdis.dropdownlist_display1();            
            
            if (TempData["submitvalue"].ToString() == "Update")
            {
                try
                {
                    if (ModelState.IsValid)
                    {                    
                        sdb.UpdateComplaintProfileDetail(smodel, UID, UserNam);

                        TempData["messageComplaintProfile"] = "Complainant User Profile details Updated successfully";
                        TempData.Keep();
                        ViewBag.Message = "Complainant User Profile Details updated Successfully";

                        Session["ApplicationId"] = smodel.ComplaintProfile_ID;
                        Session["User_Type"] = 0;
                        Session["User_ParentEntityFlag"] = 0;
                        ModelState.Clear();
                    }

                    return RedirectToAction("RegComplaintProfile");
                }
                catch (Exception ex)
                {
                    string excetmsg = ex.ToString();
                    return View("RegComplaintProfile");
                }
            }
            else
            {
                try
                {
                        var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    if (ModelState.IsValid)

                    {
                        Int64 Appid = sdb.AddComplaintProfileDetail(smodel, UID, UserNam);
                        if (Appid > 0)
                        {
                            ViewBag.ApplicationId = Appid;

                            TempData["messageComplaintProfile"] = "Complainant User Profile details successfully Submitted";
                            TempData.Keep();
                            ViewBag.Message = "Complainant User Profile details successfully Submitted";                            

                            Session["ApplicationId"] = Appid;
                            Session["User_Type"] = 0;
                            Session["User_ParentEntityFlag"] = 0;

                            smodel.ComplaintProfile_ID = Convert.ToInt64(Session["ApplicationId"]);
                            ModelState.Clear();
                        }
                    }
                    return RedirectToAction("RegComplaintProfile");
                }
                catch (Exception ex)
                {
                    string excetmsg = ex.ToString();
                    return View("RegComplaintProfile");
                }
            }            
        }

        [HttpGet]
        public ActionResult RegComplaintProfileNA()
        {
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            return View("RegComplaintProfileNA");
        }
        #endregion       

        #region Complaint Payment Details
        [HttpPost]        
        public ActionResult DropdownlistComplaintPaymentDetails(FormCollection frm, ClsPrp_ComplaintPayment smodel)
        {

            TempData["SelectedItem"] = frm["ComplaintPaymentRelated_ComplaintRegistration_ID"]; TempData.Keep();
            Session["ComplaintRegistration_ID"] = smodel.ComplaintPaymentRelated_ComplaintRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());

        }
        // GET: Empty Create + Display
        public ActionResult Reg_ComplaintPayment()
        {
            ClsMethod_ComplaintReferenceMaster objdis = new ClsMethod_ComplaintReferenceMaster();
            ViewBag.SelectedItem = "";

            Int64 ComplaintRegistration_ID = 0;           

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ComplaintPayment"))
                Session.Remove("ComplaintRegistration_ID");
            else
                ComplaintRegistration_ID = Convert.ToInt64(Session["ComplaintRegistration_ID"].ToString());

            Int64 ComplaintProfile_Id = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplaintProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_ComplaintReference_ByAppId(ComplaintProfile_Id, 0);
            TempData.Keep();
            ClsMethod_ComplaintPayment sdb = new ClsMethod_ComplaintPayment();
            ClsPrp_ComplaintPayment aa = new ClsPrp_ComplaintPayment();
            aa.prpongoing = sdb.Display_Complaint_Payment(ComplaintRegistration_ID);
            aa.ComplaintPaymentRelated_ComplaintRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();


            //----------------//------------------//
            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();
            //----------------//------------------//


            TempData["submitvalue"] = "Submit";
            TempData.Keep();
            #region
            //----------------//------------------//
            //AAAA Get_Isdraftvalue_FromDiaryNumber(Project_id);
            //----------------//------------------//
            #endregion
            return View("Reg_ComplaintPayment", aa);
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
        public ActionResult Reg_ComplaintPayment(ClsPrp_Project_Payment smodel)
        {

            ///////////string UID = User.Identity.GetUserId();

            ///////////await UserManager.SendEmailAsync(UID, "RERA, Punjab - TEST MAIL Activation Link", "<b>Dear " + "Ram Lal" + "</b>,<br /><br /> Thank you for signing up with Punjab RERA. Please confirm your account by clicking <a href=\"" + "Test Bhai" + "\">here (Activation Link)</a> <br /><br /><br />This link is valid for 24 hours. If you fail to click on this link within 24 hours, you would need to signup again. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");


            ////////////Int64 Project_id = 0;
            ////////////ClsPrp_Project_Payment aa = new ClsPrp_Project_Payment();

            ////////////if (Session["Project_id"] != null)
            ////////////{
            ////////////    Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            ////////////    smodel.ProjectPaymentRelated_ProjectRegistration_ID = Project_id;
            ////////////}
            ////////////else
            ////////////{
            ////////////    return RedirectToAction("SessionExpire", "Account");
            ////////////}

            //////////////Save & Update
            ////////////#region

            ////////////String ext = String.Empty;
            ////////////string FilePathExt = string.Empty;
            ////////////string error = string.Empty;
            ////////////int errorstate = 0;

            ////////////if (TempData["submitvalue"].ToString() == "Update")
            ////////////{
            ////////////    #region PhotoCertificate Update with Path
            ////////////    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            ////////////    {
            ////////////        var files = Request.Files[0];
            ////////////        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            ////////////        ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            ////////////        if (allowedExtensions.Contains(ext)) //check what type of extension  
            ////////////        {
            ////////////            int size = files.ContentLength;
            ////////////            if (size <= 512000)
            ////////////            {

            ////////////                #region Declare Variables
            ////////////                var pathpromoterdata = "";
            ////////////                var pathindb = "";
            ////////////                string masterPromoterDoc_SetFilePath = "readwritedataProject";
            ////////////                #endregion

            ////////////                #region UpdateFile Path Creation 
            ////////////                if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FileName))
            ////////////                {
            ////////////                    pathindb = smodel.ImageDDorBankersCheque_FileName.ToString();
            ////////////                }
            ////////////                else
            ////////////                {
            ////////////                    pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
            ////////////                }
            ////////////                pathpromoterdata = Server.MapPath("~/" + pathindb);

            ////////////                if (!Directory.Exists(pathpromoterdata))
            ////////////                {
            ////////////                    Directory.CreateDirectory(pathpromoterdata);
            ////////////                }
            ////////////                #endregion

            ////////////                var fileName = string.Empty;
            ////////////                if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FilePath))
            ////////////                {
            ////////////                    fileName = smodel.ImageDDorBankersCheque_FilePath.ToString();
            ////////////                }
            ////////////                else
            ////////////                {
            ////////////                    fileName = "DDBCheque_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
            ////////////                }

            ////////////                var path = Path.Combine(pathpromoterdata, fileName);
            ////////////                files.SaveAs(path);
            ////////////                Photo_Address = fileName;
            ////////////                FilePathExt = pathindb;

            ////////////            }
            ////////////            else
            ////////////            {
            ////////////                TempData["notice"] = "Photo Size Should be less than 512KB";
            ////////////                error = "Photo Size Should be less than 512KB";
            ////////////                errorstate = 1;
            ////////////            }
            ////////////        }
            ////////////        else
            ////////////        {
            ////////////            TempData["notice"] = "Photo format should be .jpg";
            ////////////            error = "Photo format should be .jpg";
            ////////////            errorstate = 1;
            ////////////        }
            ////////////    }
            ////////////    else
            ////////////    {
            ////////////        TempData["notice"] = "Kindly Upload Photograph";
            ////////////        error = "Kindly Upload Photograph";
            ////////////        errorstate = 1;

            ////////////        //update with same photograph
            ////////////        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
            ////////////        {
            ////////////            errorstate = 0;
            ////////////        }

            ////////////    }
            ////////////    #endregion
            ////////////    if (errorstate == 0)
            ////////////    {
            ////////////        if (ModelState.IsValid)
            ////////////        {
            ////////////            if (Photo_Address == "")
            ////////////            {
            ////////////                Photo_Address = smodel.ImageDDorBankersCheque_FilePath;
            ////////////                ext = smodel.ImageDDorBankersCheque_FileName;
            ////////////                FilePathExt = smodel.ImageDDorBankersCheque_FileName;
            ////////////            }

            ////////////            try
            ////////////            {
            ////////////                ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();
            ////////////                sdb.Update_Project_Payment(smodel);//, smodel.Application_id, smodel.Id, smodel.Promoter_OtherMemberDetails_ID);
            ////////////                TempData["message"] = "Details updated Successfully";

            ////////////                return RedirectToAction("Create_PaymentDetails");
            ////////////            }
            ////////////            catch (Exception ex)
            ////////////            {
            ////////////                return View();
            ////////////            }
            ////////////        }
            ////////////        return RedirectToAction("Create_PaymentDetails");
            ////////////    }
            ////////////    else
            ////////////    {
            ////////////        return RedirectToAction("Create_PaymentDetails");
            ////////////    }
            ////////////}
            ////////////else
            ////////////{
            ////////////    #region PhotoCertificate Save with Path
            ////////////    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            ////////////    {
            ////////////        var files = Request.Files[0];
            ////////////        var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
            ////////////        ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
            ////////////        if (allowedExtensions.Contains(ext)) //check what type of extension  
            ////////////        {
            ////////////            int size = files.ContentLength;
            ////////////            if (size <= 512000)
            ////////////            {

            ////////////                #region Declare Variables
            ////////////                var pathpromoterdata = "";
            ////////////                var pathindb = "";
            ////////////                string masterPromoterDoc_SetFilePath = "readwritedataProject";
            ////////////                #endregion

            ////////////                #region SaveFile Path Creation
            ////////////                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
            ////////////                pathpromoterdata = Server.MapPath("~/" + pathindb);

            ////////////                if (!Directory.Exists(pathpromoterdata))
            ////////////                {
            ////////////                    Directory.CreateDirectory(pathpromoterdata);
            ////////////                }
            ////////////                #endregion

            ////////////                var fileName = string.Empty;
            ////////////                fileName = "DDBCheque_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
            ////////////                var path = Path.Combine(pathpromoterdata, fileName);
            ////////////                files.SaveAs(path);
            ////////////                Photo_Address = fileName;
            ////////////                FilePathExt = pathindb;

            ////////////            }
            ////////////            else
            ////////////            {
            ////////////                TempData["notice"] = "Photo Size Should be less than 512KB";
            ////////////                error = "Photo Size Should be less than 512KB";
            ////////////                errorstate = 1;
            ////////////            }
            ////////////        }
            ////////////        else
            ////////////        {
            ////////////            TempData["notice"] = "Photo format should be .jpg";
            ////////////            error = "Photo format should be .jpg";
            ////////////            errorstate = 1;
            ////////////        }
            ////////////    }
            ////////////    else
            ////////////    {
            ////////////        TempData["notice"] = "Kindly Upload Photograph";
            ////////////        error = "Kindly Upload Photograph";
            ////////////        errorstate = 1;
            ////////////    }
            ////////////    #endregion

            ////////////    try
            ////////////    {
            ////////////        if (errorstate == 0)
            ////////////        {
            ////////////            if (ModelState.IsValid)
            ////////////            {
            ////////////                if (Photo_Address == "")
            ////////////                {
            ////////////                    Photo_Address = smodel.ImageDDorBankersCheque_FilePath;
            ////////////                    ext = smodel.ImageDDorBankersCheque_FileName;
            ////////////                    FilePathExt = smodel.ImageDDorBankersCheque_FileName;
            ////////////                }

            ////////////                ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();

            //////////////to bind bank master
            ////////////ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            ////////////aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //////////////to bind Payment master
            ////////////ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            ////////////aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            ////////////                if (sdb.Add_Project_Payment(smodel, Project_id, Photo_Address, FilePathExt))
            ////////////                {
            ////////////                    TempData["message"] = " Details Added Successfully";

            ////////////                    ModelState.Clear();
            ////////////                }
            ////////////            }
            ////////////            return RedirectToAction("Create_PaymentDetails");
            ////////////        }
            ////////////        else
            ////////////        {
            //////////// return RedirectToAction("Create_PaymentDetails");
            ////////////        }
            ////////////    }
            ////////////    catch (Exception ex)
            ////////////    {
            return View();
            ////////////    }
            ////////////}
            ////////////#endregion
        }

        [HttpGet]
        public ActionResult Edit_ComplaintPaymentDetails(Int64 ComplaintRegistration_ID, Int64 ComplaintPayment_IndexID)
        {
            ClsMethod_ComplaintPayment sdb = new ClsMethod_ComplaintPayment();
            ClsPrp_ComplaintPayment aa = new ClsPrp_ComplaintPayment();

            aa.prpongoing = sdb.Display_Complaint_PaymentById(ComplaintRegistration_ID, ComplaintPayment_IndexID);

            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            foreach (var item in aa.prpongoing)
            {
                aa.ComplaintPayment_IndexID = item.ComplaintPayment_IndexID;
                aa.ComplaintPayment_ID = item.ComplaintPayment_ID;
                aa.ComplaintPaymentRelated_ComplaintRegistration_ID = item.ComplaintPaymentRelated_ComplaintRegistration_ID;
                aa.ComplaintPayment_TitleCode = item.ComplaintPayment_TitleCode;
                aa.ComplaintPayment_TitleName = item.ComplaintPayment_TitleName;
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
                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.E_column = item.E_column;
                aa.F_column = item.F_column;
                aa.G_column = item.G_column;
                aa.H_column = item.H_column;
                aa.I_column = item.I_column;
                aa.J_column = item.J_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Reg_ComplaintPayment", aa);
        }

        [HttpPost]
        public ActionResult Edit_ComplaintPaymentDetails(ClsPrp_ComplaintPayment smodel)
        {
            try
            {
                ClsMethod_ComplaintPayment sdb = new ClsMethod_ComplaintPayment();

                sdb.Update_Complaint_Payment(smodel);

                TempData["message"] = " Details Updated Successfully";
                return RedirectToAction("Reg_ComplaintPayment");
            }
            catch (Exception ex)
            {
                string varMss = ex.ToString();
                return View();
            }
        }

        public ActionResult Delete_ComplaintPaymentDetails(Int64 ComplaintRegistration_ID, Int64 ComplaintPayment_IndexID)
        {
            try
            {
                ClsMethod_ComplaintPayment sdb = new ClsMethod_ComplaintPayment();
                if (sdb.Delete_Complaint_Payment(ComplaintRegistration_ID, ComplaintPayment_IndexID))
                {
                    TempData["message"] = " Details Deleted Successfully";                    
                }
                return RedirectToAction("Reg_ComplaintPayment");
            }
            catch (Exception ex)
            {
                string varMss = ex.ToString();
                return View();
            }
        }
        #endregion


        #region Complaint FORM M

        #region Step-I Form-M Reg       
        [HttpGet]
        public ActionResult RegComplaintFormM()
        {
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsPrp_ComplaintFormM_Registration aa = new ClsPrp_ComplaintFormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
            //ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            //ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            try
            {

                aa.districtMaster = objdis.dropdownlist_display1();
                aa.districtPunjabMaster = objdis.dropdownlist_display1(28); // For Punjab State Only
                aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv(); // For Punjab Sub-Division Only
                aa.stateMaster = objdis.State_list();


                aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
                if (aa.Complainant_UserProfile.Count >= 1)
                {
                    foreach (var item in aa.Complainant_UserProfile)
                    {
                        aa.Profile_ID = item.ComplaintProfile_ID;
                        aa.User_ID = item.UserID;

                        aa.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                        aa.Complainant_EmailAddress = item.EmailAddress;
                        aa.Complainant_MobileNumber = item.MobileNumber;
                        aa.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                        aa.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                        aa.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                        aa.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                        aa.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                        aa.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                        aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                        aa.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                        aa.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                        aa.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                        aa.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                        aa.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                    }

                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";
                }
                else
                {
                    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                    return RedirectToAction("RegComplaintProfileNA", "Complaint");
                }


                Int64 ComplainantFormM_id = 0;
                if (Session["ComplaintFormM_ID"] != null)
                {
                    if (Session["ComplaintFormM_ID"].ToString() != "0")
                    {
                        ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    }
                }
                string userName = User.Identity.Name;

                //objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);
                aa.ComplaintFormMstepI = objFormAppM.Display_ComplaintFormM_Registration_StepI(ComplainantFormM_id);
                if (aa.ComplaintFormMstepI.Count >= 1)
                {
                    foreach (var item in aa.ComplaintFormMstepI)
                    {
                        aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                        aa.ComplaintFormM_ID = item.ComplaintFormM_ID;
                        aa.ComplaintFormM_ID = item.ComplaintFormM_ID;
                        aa.ComplaintFormM_Code = item.ComplaintFormM_Code;

                        aa.Profile_ID = item.Profile_ID;
                        aa.User_ID = item.User_ID;
                        aa.ComplaintType_MN = item.ComplaintType_MN;

                        aa.IsComplaintComplete = item.IsComplaintComplete;
                        aa.IsPaymentComplete = item.IsPaymentComplete;
                        aa.IsDocumentsComplete = item.IsDocumentsComplete;

                        aa.IsVerificationComplete = item.IsVerificationComplete;
                        aa.ComplaintVerificationDate = item.ComplaintVerificationDate;

                        aa.Complainant_Name = item.Complainant_Name;
                        aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
                        aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                        aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                        aa.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                        aa.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                        aa.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                        aa.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                        aa.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                        aa.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;
                        aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
                        aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                        aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                        aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                        aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                        aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                        aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
                        aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
                        aa.AuthorizedRepresentativeCounsel_MobileNumber = item.AuthorizedRepresentativeCounsel_MobileNumber;
                        aa.AuthorizedRepresentativeCounsel_LandlineFaxNumber = item.AuthorizedRepresentativeCounsel_LandlineFaxNumber;

                        aa.RelatesComplaint_ComplaintAgainstType = item.RelatesComplaint_ComplaintAgainstType;
                        aa.RelatesComplaint_ProjectAgent_RERA_RegNumber = item.RelatesComplaint_ProjectAgent_RERA_RegNumber;
                        aa.RelatesComplaint_ProjectAgent_Name = item.RelatesComplaint_ProjectAgent_Name;

                        aa.Respondent_Name = item.Respondent_Name;
                        aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
                        aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
                        aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;
                        aa.OfficeResRespondent_AddressLine1 = item.OfficeResRespondent_AddressLine1;
                        aa.OfficeResRespondent_AddressLine2 = item.OfficeResRespondent_AddressLine2;
                        aa.OfficeResRespondent_AddressStateCode = item.OfficeResRespondent_AddressStateCode;
                        aa.OfficeResRespondent_AddressDistrictCode = item.OfficeResRespondent_AddressDistrictCode;
                        aa.OfficeResRespondent_AddressPIN = item.OfficeResRespondent_AddressPIN;
                        aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = item.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress;
                        aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
                        aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
                        aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
                        aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
                        aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

                        aa.IsAgreeDeclaration_JurisdictionRERAPunjab = item.IsAgreeDeclaration_JurisdictionRERAPunjab;
                        aa.FactsCase_Statement = item.FactsCase_Statement;
                        aa.ReliefSought_Statement = item.ReliefSought_Statement;
                        aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                        aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                        aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                        aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;
                        aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                        aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                        aa.Remarks_IfAny = item.Remarks_IfAny;
                        aa.A_column = item.A_column;
                        aa.B_column = item.B_column;
                        aa.C_column = item.C_column;
                        aa.D_column = item.D_column;
                        //aa.E_column = item.E_column;

                        Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaint(item.E_column);

                        aa.IsYes_columnCLU = extractCode.Item1;
                        aa.IsYes_columnLTDC = extractCode.Item2;
                        aa.IsYes_columnRegCert = extractCode.Item3;
                        aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                        aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                        aa.columnExtraReferenceNumber = extractCode.Item6;
                        aa.E_column = extractCode.Item7;

                        aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                        aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                        aa.IsYes_columnLOI = extractCode.Rest.Item3;
                        aa.IsYes_columnExtraA = extractCode.Rest.Item4;

                        aa.IsActive = item.IsActive;
                        aa.IsDraft = item.IsDraft;
                        aa.IsLock = item.IsLock;
                        aa.IsPublicView = item.IsPublicView;
                        aa.CreatedBy = item.CreatedBy;
                        aa.CreatedOn = item.CreatedOn;
                        aa.ModifyBy = item.ModifyBy;
                        aa.ModifyOn = item.ModifyOn;

                    }
                }

                aa.FactsCase_Documents = objFormAppM.Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI(ComplainantFormM_id, ComplainantProfile_id, "FormTypeM", string.Empty, userName);
                aa.FactsCase_FileName = "Facts of the Case";
                aa.FactsCase_FileType = ".pdf";
                if (aa.FactsCase_Documents.Count > 0)
                {
                    aa.FactsCase_OptionsYesNo = "factscasePDF";
                }
                else
                {
                    aa.FactsCase_OptionsYesNo = "factscaseText";
                }
            }
            catch (Exception ex)
            {
                string ext = ex.ToString();
            }

            if (aa.ComplaintFormMstepI.Count >= 1)
            {
                TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
            }

            //return View("RegComplaintFormM", aa);
            return View(aa);
        }

        [HttpGet]
        public ActionResult Details_RegComplaintFormM(Int64 zComplaintFormM_ID, Int64 zComplaintProfile_ID)
        {
            Int64 ComplainantProfile_id = zComplaintProfile_ID;
            
            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsPrp_ComplaintFormM_Registration aa = new ClsPrp_ComplaintFormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
            //ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            //ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            aa.districtMaster = objdis.dropdownlist_display1();
            aa.districtPunjabMaster = objdis.dropdownlist_display1(28); // For Punjab State Only
            aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv(); // For Punjab Sub-Division Only
            aa.stateMaster = objdis.State_list();


            aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
            if (aa.Complainant_UserProfile.Count >= 1)
            {
                foreach (var item in aa.Complainant_UserProfile)
                {
                    aa.Profile_ID = item.ComplaintProfile_ID;
                    aa.User_ID = item.UserID;

                    aa.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                    aa.Complainant_EmailAddress = item.EmailAddress;
                    aa.Complainant_MobileNumber = item.MobileNumber;
                    aa.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                    aa.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                    aa.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                    aa.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                    aa.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                    aa.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                    aa.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                    aa.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                    aa.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                    aa.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                    aa.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                }

                aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";
                
                Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaint("NIL");
                aa.IsYes_columnCLU = extractCode.Item1;
                aa.IsYes_columnLTDC = extractCode.Item2;
                aa.IsYes_columnRegCert = extractCode.Item3;
                aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                aa.columnExtraReferenceNumber = extractCode.Item6;
                aa.E_column = extractCode.Item7;

                aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                aa.IsYes_columnLOI = extractCode.Rest.Item3;
                aa.IsYes_columnExtraA = extractCode.Rest.Item4;
            }
            else
            {
                aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
                aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaint("NIL");
                aa.IsYes_columnCLU = extractCode.Item1;
                aa.IsYes_columnLTDC = extractCode.Item2;
                aa.IsYes_columnRegCert = extractCode.Item3;
                aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                aa.columnExtraReferenceNumber = extractCode.Item6;
                aa.E_column = extractCode.Item7;

                aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                aa.IsYes_columnLOI = extractCode.Rest.Item3;
                aa.IsYes_columnExtraA = extractCode.Rest.Item4;
            }


            Int64 ComplainantFormM_id = zComplaintFormM_ID;                        
            Session["ComplaintFormM_ID"] = ComplainantFormM_id;           

            try
            {
                string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep(ComplainantFormM_id);

                string varFlagStep_ControllerLinkName = string.Empty;
                string varFlagStep_ActionLinkName = string.Empty;

                switch (varFlagStep_LinkName)
                {
                    case "Step1M":
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintFormM";
                        break;
                    case "Step2M":
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintEncldocM";
                        break;
                    case "Step3M":                        
                        varFlagStep_ControllerLinkName = "ComplaintPayment";
                        varFlagStep_ActionLinkName = "RequestPaymentFormM";
                        break;
                    case "Step4M":
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintVerificationM";
                        break;
                    default:
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintFormM";
                        break;
                }

                return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return RedirectToAction("RegComplaintFormM", "Complaint");
            }
            //return View(aa);
        }

        [HttpGet]
        public ActionResult Create_RegComplaintFormM()      // for STEP FORM WORK
        {
            Int64 ComplainantProfile_id = 0;            
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string userName = User.Identity.Name;

            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsPrp_ComplaintFormM_Registration aa = new ClsPrp_ComplaintFormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
            //ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            //ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            try
            {
                aa.districtMaster = objdis.dropdownlist_display1();
                aa.districtPunjabMaster = objdis.dropdownlist_display1(28); // For Punjab State Only
                aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv(); // For Punjab Sub-Division Only
                aa.stateMaster = objdis.State_list();

                aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
                if (aa.Complainant_UserProfile.Count >= 1)
                {
                    foreach (var item in aa.Complainant_UserProfile)
                    {
                        aa.Profile_ID = item.ComplaintProfile_ID;
                        aa.User_ID = item.UserID;

                        aa.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                        aa.Complainant_EmailAddress = item.EmailAddress;
                        aa.Complainant_MobileNumber = item.MobileNumber;
                        aa.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                        aa.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                        aa.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                        aa.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                        aa.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                        aa.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                        aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                        aa.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                        aa.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                        aa.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                        aa.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                        aa.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                    }

                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                    Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaint("NIL");
                    aa.IsYes_columnCLU = extractCode.Item1;
                    aa.IsYes_columnLTDC = extractCode.Item2;
                    aa.IsYes_columnRegCert = extractCode.Item3;
                    aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                    aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                    aa.columnExtraReferenceNumber = extractCode.Item6;
                    aa.E_column = extractCode.Item7;

                    aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                    aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                    aa.IsYes_columnLOI = extractCode.Rest.Item3;
                    aa.IsYes_columnExtraA = extractCode.Rest.Item4;
                }
                else
                {
                    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                    Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaint("NIL");
                    aa.IsYes_columnCLU = extractCode.Item1;
                    aa.IsYes_columnLTDC = extractCode.Item2;
                    aa.IsYes_columnRegCert = extractCode.Item3;
                    aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                    aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                    aa.columnExtraReferenceNumber = extractCode.Item6;
                    aa.E_column = extractCode.Item7;

                    aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                    aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                    aa.IsYes_columnLOI = extractCode.Rest.Item3;
                    aa.IsYes_columnExtraA = extractCode.Rest.Item4;

                    return RedirectToAction("RegComplaintProfileNA", "Complaint");
                }

                Int64 ComplainantFormM_id = 0;
                Session["ComplaintFormM_ID"] = ComplainantFormM_id;

                aa.ComplaintFormM_IndexID = 0;
                aa.ComplaintFormM_ID = 0;
                aa.ComplaintFormM_Code = string.Empty;
                aa.Profile_ID = ComplainantProfile_id;

                aa.IsActive = 0;
                aa.IsDraft = 0;
                aa.IsLock = 0;
                aa.IsPublicView = 0;

                aa.FactsCase_Documents = objFormAppM.Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI(ComplainantFormM_id, ComplainantProfile_id, "FormTypeM", string.Empty, userName);
                aa.FactsCase_FileName = "Facts of the Case";
                aa.FactsCase_FileType = ".pdf";
                if (aa.FactsCase_Documents.Count > 0)
                {
                    aa.FactsCase_OptionsYesNo = "factscasePDF";
                }
                else
                {
                    aa.FactsCase_OptionsYesNo = "factscaseText";
                }
            }
            catch (Exception ex)
            {
                string ext = ex.ToString();
            }

            if (aa.ComplaintFormMstepI.Count >= 1)
            {
                TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
            }
                        
            return View("RegComplaintFormM", aa);
        }

        [HttpPost] //[ValidateInput(false)]        
        public ActionResult RegComplaintFormM(ClsPrp_ComplaintFormM_Registration smodel)
        {
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            bool varFlag_FactsCase = false;

            ClsPrp_ComplaintFormM_Registration aa = new ClsPrp_ComplaintFormM_Registration();            
                     
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
            ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            #region Verification PDF (Facts of the Case)
            try
            {
                Int64 FactsCaseDoc_ID = 0;
                Int64 FactsCaseDoc_InfoCode = 103;

                if (smodel.FactsCase_OptionsYesNo == "factscasePDF")
                {
                    //"factscasePDF"
                    smodel.FactsCase_Statement = "Enclosed PDF file (Facts of the Case)";
                    ModelState.Remove("FactsCase_Statement");
                    varFlag_FactsCase = true;
                    varFlag_FactsCase = objFormAppM.Verify_ComplaintFormM_FactsOfTheCase_Documents_ByProfileID("mPDF", smodel.ComplaintFormM_ID, smodel.Profile_ID, "FormTypeM", FactsCaseDoc_ID, FactsCaseDoc_InfoCode, userName);                    
                }
                else 
                {
                    //"factscaseText" 
                    //(smodel.FactsCase_OptionsYesNo == "factscaseText")                   
                    varFlag_FactsCase = true;
                    varFlag_FactsCase = objFormAppM.Verify_ComplaintFormM_FactsOfTheCase_Documents_ByProfileID("mTEXT", smodel.ComplaintFormM_ID, smodel.Profile_ID, "FormTypeM", FactsCaseDoc_ID, FactsCaseDoc_InfoCode, userName);
                }
            }
            catch(Exception ex)
            {
                string strex = ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }            
            #endregion

            #region Save & Update         
            if (TempData["submitvalueFormMStep1"].ToString() == "Update")
            {               
                try
                {
                    if (varFlag_FactsCase)
                    {
                        if (ModelState.IsValid)
                        {
                            string retSubStringValue = fnSaveSubStringUnRegdComplaint(smodel);
                            smodel.E_column = retSubStringValue;
                            objFormAppM.Update_ComplaintFormM_Registration_StepI(smodel, UID, userName);
                            TempData["message"] = "Details Updated Successfully";

                            Session["ComplaintFormM_ID"] = smodel.ComplaintFormM_ID;

                            ModelState.Clear();
                        }
                    }
                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentFormM";                            
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationM";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                    }

                    //return RedirectToAction("RegComplaintFormM");
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    return View();                    
                }
            }
            else
            {
                try
                {
                    //EXTRA (stopped as order by SC)
                    //ModelState.Remove("D_column");
                    //smodel.D_column = "registeredproject";
                    if (varFlag_FactsCase)
                    {
                        if (ModelState.IsValid)
                        {
                            string retSubStringValue = fnSaveSubStringUnRegdComplaint(smodel);
                            smodel.E_column = retSubStringValue;
                            Int64 Appid = objFormAppM.Add_ComplaintFormM_Registration_StepI(smodel, UID, userName);
                            if (Appid > 0)
                            {
                                ViewBag.ApplicationId = Appid;
                                ViewBag.Message = " Details Successfully Submitted";
                                TempData["message"] = " Details Successfully Submitted";

                                Session["ComplaintFormM_ID"] = Appid;
                                smodel.ComplaintFormM_ID = Convert.ToInt64(Session["ComplaintFormM_ID"]);

                                ModelState.Clear();
                            }
                        }
                    }

                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocM";
                            break;
                        case "Step3M":                            
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentFormM";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationM";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                    }

                    //return RedirectToAction("RegComplaintFormM");
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);                    
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    return View();
                }
            }
            #endregion

            ///////////await UserManager.SendEmailAsync(UID, "RERA, Punjab - TEST MAIL Activation Link", "<b>Dear " + "Ram Lal" + "</b>,<br /><br /> Thank you for signing up with Punjab RERA. Please confirm your account by clicking <a href=\"" + "Test Bhai" + "\">here (Activation Link)</a> <br /><br /><br />This link is valid for 24 hours. If you fail to click on this link within 24 hours, you would need to signup again. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");

        }

        private Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> fnExtractSubStringUnRegdComplaint(string varFormStr)
        {
            string retflagCLU = string.Empty;
            string retflagLTDC = string.Empty;
            string retflagREGC = string.Empty;
            string retflagATS = string.Empty;
            string retflagAL = string.Empty;
            string retflagLOI = string.Empty;
            string retflagMORE = string.Empty;
            Int32 retflagDistrictCode = 0;
            Int32 retflagSubDivisionCode = 0;
            string retflagExtra = string.Empty;
            string retflagRefInfo = string.Empty;

            try
            {
                if (varFormStr == "NIL")
                {
                    retflagCLU = "NCLU";
                    retflagLTDC = "NLTDC";
                    retflagREGC = "NREGC";
                    retflagATS = "NATS";
                    retflagAL = "NALD";
                    retflagLOI = "NLOI";
                    retflagMORE = "NMORE";
                    retflagDistrictCode = 0;
                    retflagSubDivisionCode = 0;
                    retflagExtra = "NEXTRA";
                    retflagRefInfo = string.Empty;
                }
                else
                {
                    string input = varFormStr;
                    //string input = "//YCLU////YLTDC////NREGC////366////0////NEXTRA////remarks if any//";
                    //string input = "//YCLU////YLTDC////NREGC////YATS////YALD////NLOI////NMORE////366////0////NEXTRA////remarks if any//";
                    string[] getstrings = Regex.Matches(input, @"\//(.+?)\//")
                                                .Cast<Match>()
                                                .Select(s => s.Groups[1].Value).ToArray();

                    if (getstrings.Length > 0)
                    {
                        if (getstrings.Length <= 10)
                        {
                            retflagCLU = getstrings[0];
                            retflagLTDC = getstrings[1];
                            retflagREGC = getstrings[2];
                            retflagATS = getstrings[3];
                            retflagAL = getstrings[4];
                            retflagLOI = getstrings[5];
                            retflagMORE = getstrings[6];
                            retflagDistrictCode = String.IsNullOrEmpty(getstrings[7]) ? 0 : Convert.ToInt32(getstrings[7]);
                            retflagSubDivisionCode = String.IsNullOrEmpty(getstrings[8]) ? 0 : Convert.ToInt32(getstrings[8]);
                            retflagExtra = getstrings[9];
                            retflagRefInfo = string.Empty;
                        }
                        else
                        {
                            retflagCLU = getstrings[0];
                            retflagLTDC = getstrings[1];
                            retflagREGC = getstrings[2];
                            retflagATS = getstrings[3];
                            retflagAL = getstrings[4];
                            retflagLOI = getstrings[5];
                            retflagMORE = getstrings[6];
                            retflagDistrictCode = String.IsNullOrEmpty(getstrings[7]) ? 0 : Convert.ToInt32(getstrings[7]);
                            retflagSubDivisionCode = String.IsNullOrEmpty(getstrings[8]) ? 0 : Convert.ToInt32(getstrings[8]);
                            retflagExtra = getstrings[9];
                            retflagRefInfo = getstrings[10];
                        }
                    }
                    else
                    {
                        retflagCLU = "NCLU";
                        retflagLTDC = "NLTDC";
                        retflagREGC = "NREGC";
                        retflagATS = "NATS";
                        retflagAL = "NALD";
                        retflagLOI = "NLOI";
                        retflagMORE = "NMORE";
                        retflagDistrictCode = 0;
                        retflagSubDivisionCode = 0;
                        retflagExtra = "NEXTRA";
                        retflagRefInfo = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                retflagCLU = "NCLU";
                retflagLTDC = "NLTDC";
                retflagREGC = "NREGC";
                retflagATS = "NATS";
                retflagAL = "NALD";
                retflagLOI = "NLOI";
                retflagMORE = "NMORE";
                retflagDistrictCode = 0;
                retflagSubDivisionCode = 0;
                retflagExtra = "NEXTRA";
                retflagRefInfo = string.Empty;
            }
            return new Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>>(retflagCLU, retflagLTDC, retflagREGC, retflagDistrictCode, retflagSubDivisionCode, retflagExtra, retflagRefInfo, Tuple.Create(retflagATS, retflagAL, retflagLOI, retflagMORE));
        }

        private string fnSaveSubStringUnRegdComplaint(ClsPrp_ComplaintFormM_Registration smodel)
        {
            string retflagCLU = string.Empty;
            string retflagLTDC = string.Empty;
            string retflagREGC = string.Empty;
            string retflagATS = string.Empty;
            string retflagAL = string.Empty;
            string retflagLOI = string.Empty;
            string retflagMORE = string.Empty;
            Int32 retflagDistrictCode = 0;
            Int32 retflagSubDivisionCode = 0;            
            string retflagExtra = string.Empty;
            string retflagRefInfo = string.Empty;
            string input = string.Empty;

            if (smodel != null)
            {
                if (smodel.D_column == "unregisteredproject")
                {
                    retflagCLU = String.IsNullOrEmpty(smodel.IsYes_columnCLU) ? "NCLU" : smodel.IsYes_columnCLU;
                    retflagLTDC = String.IsNullOrEmpty(smodel.IsYes_columnLTDC) ? "NLTDC" : smodel.IsYes_columnLTDC;
                    retflagREGC = String.IsNullOrEmpty(smodel.IsYes_columnRegCert) ? "NREGC" : smodel.IsYes_columnRegCert;
                    retflagATS = String.IsNullOrEmpty(smodel.IsYes_columnAgreementSale) ? "NATS" : smodel.IsYes_columnAgreementSale;
                    retflagAL = String.IsNullOrEmpty(smodel.IsYes_columnAllotmentLetter) ? "NALD" : smodel.IsYes_columnAllotmentLetter;
                    retflagLOI = String.IsNullOrEmpty(smodel.IsYes_columnLOI) ? "NLOI" : smodel.IsYes_columnLOI;
                    retflagMORE = String.IsNullOrEmpty(smodel.IsYes_columnExtraA) ? "NMORE" : smodel.IsYes_columnExtraA;
                    retflagDistrictCode = String.IsNullOrEmpty(smodel.columnDistrictCode) ? 0 : Convert.ToInt32(smodel.columnDistrictCode);
                    retflagSubDivisionCode = String.IsNullOrEmpty(smodel.columnSubDivisionCode) ? 0 : Convert.ToInt32(smodel.columnSubDivisionCode);                    
                    retflagExtra = String.IsNullOrEmpty(smodel.columnExtraReferenceNumber) ? "NEXTRA" : smodel.columnExtraReferenceNumber;
                    retflagRefInfo = smodel.E_column;
                }
                if (smodel.D_column == "registeredproject")
                {
                    retflagCLU = "NCLU";
                    retflagLTDC = "NLTDC";
                    retflagREGC = "NREGC";                    
                    retflagATS = "NATS";
                    retflagAL = "NALD";
                    retflagLOI = "NLOI";
                    retflagMORE = "NMORE";
                    retflagDistrictCode = 0;
                    retflagSubDivisionCode = 0;
                    retflagExtra = "NEXTRA";
                    retflagRefInfo = string.Empty;
                }
            }
            else
            {
                retflagCLU = "NCLU";
                retflagLTDC = "NLTDC";
                retflagREGC = "NREGC";                
                retflagATS = "NATS";
                retflagAL = "NALD";
                retflagLOI = "NLOI";
                retflagMORE = "NMORE";
                retflagDistrictCode = 0;
                retflagSubDivisionCode = 0;
                retflagExtra = "NEXTRA";
                retflagRefInfo = string.Empty;                
            }         

            input = "//"+ retflagCLU + "////"+ retflagLTDC + "////"+ retflagREGC + "////" + retflagATS + "////" + retflagAL + "////" + retflagLOI + "////" + retflagMORE + "////" + retflagDistrictCode + "////"+ retflagSubDivisionCode + "////" + retflagExtra + "////"+ retflagRefInfo + "//";
            return input;
        }

        //Add more complainant details
        [HttpGet]
        public ActionResult RegAdditionalComplaintFormM()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormM_id = 11; // Blank or New Entry Data
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;
            Int32 retAbsoluteIsDraft = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }                        
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }                       

            ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            
            aa.FormMN_Complainant = sdb.Display_Complainant_Detail(ComplainantProfile_id, ComplainantFormM_id, TypeFormM, UID, IsTempTable);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            if (aa.FormMN_Complainant.Count >= 1)
            {
                foreach (var item in aa.FormMN_Complainant)
                {
                    aa.AdditionComplainant_IndexID = item.AdditionComplainant_IndexID;
                    aa.AdditionComplainant_ID = item.AdditionComplainant_ID;
                    aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                    aa.ComplainantorApplicant_RelatedComplaint_Code = item.ComplainantorApplicant_RelatedComplaint_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_MN = item.ComplaintType_MN;

                    //aa.Name_of_Complainant_or_Applicant = item.Name_of_Complainant_or_Applicant;
                    //aa.EmailAddress = item.EmailAddress;
                    //aa.MobileNumber = item.MobileNumber;
                    //aa.LandlineNumber = item.LandlineNumber;
                    //aa.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;
                    //aa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    //aa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    //aa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                    //aa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                    //aa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                    //aa.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;
                    //aa.Service_AddressLine1 = item.Service_AddressLine1;
                    //aa.Service_AddressLine2 = item.Service_AddressLine2;
                    //aa.Service_AddressStateCode = item.Service_AddressStateCode;
                    //aa.Service_AddressDistrictCode = item.Service_AddressDistrictCode;
                    //aa.Service_AddressPIN = item.Service_AddressPIN;
                    //aa.Remarks_IfAny = item.Remarks_IfAny;
                    //aa.A_column = item.A_column;
                    //aa.B_column = item.B_column;
                    //aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    aa.IsTempTable = item.IsTempTable;

                    //aa.CreatedBy = item.CreatedBy;
                    //aa.CreatedOn = item.CreatedOn;
                    //aa.ModifyBy = item.ModifyBy;
                    //aa.ModifyOn = item.ModifyOn;

                    if (item.IsDraft == 0 || item.IsDraft == 4)
                    {
                        retAbsoluteIsDraft = item.IsDraft;
                    }
                }
                aa.IsDraft = retAbsoluteIsDraft;
            }
            else
            {
                ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
                ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

                objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);

                if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
                {
                    foreach (var item in objflagstep.ComplaintFormMstepFlag)
                    {
                        objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                        objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                        objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                        objflagstep.Profile_ID = item.Profile_ID;
                        objflagstep.User_ID = item.User_ID;
                        objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                        objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                        objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                        objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                        objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                        objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                        objflagstep.IsActive = item.IsActive;
                        objflagstep.IsDraft = item.IsDraft;
                        objflagstep.IsLock = item.IsLock;
                        objflagstep.IsPublicView = item.IsPublicView;
                        objflagstep.CreatedBy = item.CreatedBy;
                        objflagstep.CreatedOn = item.CreatedOn;
                        objflagstep.ModifyBy = item.ModifyBy;
                        objflagstep.ModifyOn = item.ModifyOn;
                    }

                    if (objflagstep.IsVerificationComplete == 1)
                    {
                        if (objflagstep.IsDraft == 1 || objflagstep.IsDraft == 5 || objflagstep.IsDraft == 6)
                        {
                            if (objflagstep.IsLock != 1)
                            {
                                aa.AdditionComplainant_IndexID = 0;
                                aa.AdditionComplainant_ID = 0;
                                aa.IsActive = 0;
                                aa.IsDraft = 0;
                                aa.IsLock = 0;
                            }
                            else
                            {
                                aa.AdditionComplainant_IndexID = 0;
                                aa.AdditionComplainant_ID = 0;
                                aa.IsActive = 1;
                                aa.IsDraft = 1;
                                aa.IsLock = 1;
                            }                           
                        }
                    }

                }                
            }            

            return View("RegAdditionalComplaintFormM", aa);
        }

        [HttpPost]
        public ActionResult SaveComplainantFormMDetail(ClsPrp_ComplaintFormMN_Addmore_Complainant[] order)
        {            
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormM_id = 11; // Blank or New Entry Data
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            bool status = false;
            Int64? chkappid = null;
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            List<ClsPrp_ComplaintFormMN_Addmore_Complainant> Complainant = new List<ClsPrp_ComplaintFormMN_Addmore_Complainant>();

            if (ModelState.IsValid)
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        ClsPrp_ComplaintFormMN_Addmore_Complainant O = new ClsPrp_ComplaintFormMN_Addmore_Complainant();

                        O.AdditionComplainant_IndexID = 0;
                        O.AdditionComplainant_ID = 0;
                        O.ComplainantApplicant_RelatedComplaint_ID = ComplainantFormM_id;
                        O.ComplainantorApplicant_RelatedComplaint_Code = ComplainantFormM_id.ToString();
                        O.Profile_ID = ComplainantProfile_id;
                        O.User_ID = UID;
                        O.ComplaintType_MN = TypeFormM;
                        O.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                        O.Name_of_Complainant_or_Applicant = item.Name_of_Complainant_or_Applicant;
                        O.EmailAddress = item.EmailAddress;
                        O.MobileNumber = item.MobileNumber;
                        O.LandlineNumber = item.LandlineNumber;

                        O.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                        O.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                        O.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                        O.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                        O.RegOffice_AddressPIN = item.RegOffice_AddressPIN;

                        O.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;

                        O.Service_AddressLine1 = item.Service_AddressLine1;
                        O.Service_AddressLine2 = item.Service_AddressLine2;
                        O.Service_AddressStateCode = item.Service_AddressStateCode;
                        O.Service_AddressDistrictCode = item.Service_AddressDistrictCode;
                        O.Service_AddressPIN = item.Service_AddressPIN;

                        O.Remarks_IfAny = "";
                        O.A_column = "";
                        O.B_column = "";
                        O.C_column = "";

                        O.IsActive = 1;
                        O.IsDraft = 0;
                        O.IsLock = 0;
                        O.IsPublicView = 0;
                        O.IsTempTable = IsTempTable;

                        chkappid = sdb.Add_FormM_Complainant(O, UID, UserNam);
                    }
                }

                if (chkappid == null)
                    status = false;
                else
                    status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult GetComplainantData()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormM_id = 11; // Blank or New Entry Data
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();

            aa.FormMN_Complainant = sdb.Display_Complainant_Detail(ComplainantProfile_id, ComplainantFormM_id, TypeFormM, UID, IsTempTable);
            //aa.districtMaster = objdis.dropdownlist_display1();
            //aa.stateMaster = objdis.State_list();

            List<ClsPrp_ComplaintFormMN_Addmore_Complainant> complainantList = aa.FormMN_Complainant;

            return Json(new { data = complainantList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_AdditionalComplaintFormM(Int64 inCompM_IndexID, Int64 inCompM_ID, Int64 inProfile_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();
                if (sdb.Delete_FormM_Complainant(inCompM_ID, inCompM_IndexID, inProfile_ID))
                {
                    TempData["message"] = " Details deleted Successfully";                  
                    status = true;
                }                
            }
            catch
            {
                status = false;
            }
            //return Json(new { data = status }, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = new { status = status, JsonRequestBehavior.AllowGet } };
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        
        //Add more respondent details
        [HttpGet]
        public ActionResult RegAdditionalRespondentFormM()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormM_id = 11; // Blank or New Entry Data
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;
            Int32 retAbsoluteIsDraft = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            aa.FormMN_Respondent = sdb.Display_Respondent_Detail(ComplainantProfile_id, ComplainantFormM_id, TypeFormM, UID, IsTempTable);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            if (aa.FormMN_Respondent.Count >= 1)
            {
                foreach (var item in aa.FormMN_Respondent)
                {
                    aa.AdditionRespondent_IndexID = item.AdditionRespondent_IndexID;
                    aa.AdditionRespondent_ID = item.AdditionRespondent_ID;
                    aa.AdditionRespondent_RelatedComplaint_ID = item.AdditionRespondent_RelatedComplaint_ID;
                    aa.AdditionRespondent_RelatedComplaint_Code = item.AdditionRespondent_RelatedComplaint_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_MN = item.ComplaintType_MN;                   

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    aa.IsTempTable = item.IsTempTable;

                    if (item.IsDraft == 0 || item.IsDraft == 4)
                    {
                        retAbsoluteIsDraft = item.IsDraft;
                    }
                }
                aa.IsDraft = retAbsoluteIsDraft;
            }
            else
            {
                ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
                ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

                objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);

                if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
                {
                    foreach (var item in objflagstep.ComplaintFormMstepFlag)
                    {
                        objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                        objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                        objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                        objflagstep.Profile_ID = item.Profile_ID;
                        objflagstep.User_ID = item.User_ID;
                        objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                        objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                        objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                        objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                        objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                        objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                        objflagstep.IsActive = item.IsActive;
                        objflagstep.IsDraft = item.IsDraft;
                        objflagstep.IsLock = item.IsLock;
                        objflagstep.IsPublicView = item.IsPublicView;
                        objflagstep.CreatedBy = item.CreatedBy;
                        objflagstep.CreatedOn = item.CreatedOn;
                        objflagstep.ModifyBy = item.ModifyBy;
                        objflagstep.ModifyOn = item.ModifyOn;
                    }

                    if (objflagstep.IsVerificationComplete == 1)
                    {
                        if (objflagstep.IsDraft == 1 || objflagstep.IsDraft == 5 || objflagstep.IsDraft == 6)
                        {
                            if (objflagstep.IsLock != 1)
                            {
                                aa.AdditionRespondent_IndexID = 0;
                                aa.AdditionRespondent_ID = 0;
                                aa.IsActive = 0;
                                aa.IsDraft = 0;
                                aa.IsLock = 0;
                            }
                            else
                            {
                                aa.AdditionRespondent_IndexID = 0;
                                aa.AdditionRespondent_ID = 0;
                                aa.IsActive = 1;
                                aa.IsDraft = 1;
                                aa.IsLock = 1;
                            }
                        }
                    }

                }
            }

            return View("RegAdditionalRespondentFormM", aa);
        }

        [HttpPost]
        public ActionResult SaveRespondentFormMDetail(ClsPrp_ComplaintFormMN_Addmore_Respondent[] order)
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormM_id = 11; // Blank or New Entry Data
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            bool status = false;
            Int64? chkappid = null;
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();
            List<ClsPrp_ComplaintFormMN_Addmore_Respondent> Respondent = new List<ClsPrp_ComplaintFormMN_Addmore_Respondent>();

            if (ModelState.IsValid)
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        ClsPrp_ComplaintFormMN_Addmore_Respondent O = new ClsPrp_ComplaintFormMN_Addmore_Respondent();

                        O.AdditionRespondent_IndexID = 0;
                        O.AdditionRespondent_ID = 0;
                        O.AdditionRespondent_RelatedComplaint_ID = ComplainantFormM_id;
                        O.AdditionRespondent_RelatedComplaint_Code = ComplainantFormM_id.ToString();
                        O.Profile_ID = ComplainantProfile_id;
                        O.User_ID = UID;
                        O.ComplaintType_MN = TypeFormM;
                        O.Repondant_AadhaarNumber = 0; // Not Applicable for Respondent

                        O.Name_of_Respondant_or_Applicant = item.Name_of_Respondant_or_Applicant;
                        O.EmailAddress = item.EmailAddress;
                        O.MobileNumber = item.MobileNumber;
                        O.LandlineNumber = item.LandlineNumber;

                        O.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                        O.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                        O.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                        O.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                        O.RegOffice_AddressPIN = item.RegOffice_AddressPIN;

                        O.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;

                        O.Service_AddressLine1 = item.Service_AddressLine1;
                        O.Service_AddressLine2 = item.Service_AddressLine2;
                        O.Service_AddressStateCode = item.Service_AddressStateCode;
                        O.Service_AddressDistrictCode = item.Service_AddressDistrictCode;
                        O.Service_AddressPIN = item.Service_AddressPIN;

                        O.Remarks_IfAny = "";
                        O.A_column = "";
                        O.B_column = "";
                        O.C_column = "";

                        O.IsActive = 1;
                        O.IsDraft = 0;
                        O.IsLock = 0;
                        O.IsPublicView = 0;
                        O.IsTempTable = IsTempTable;

                        chkappid = sdb.Add_FormM_Respondent(O, UID, UserNam);
                    }
                }

                if (chkappid == null)
                    status = false;
                else
                    status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult GetRespondentData()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormM_id = 11; // Blank or New Entry Data
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            aa.FormMN_Respondent = sdb.Display_Respondent_Detail(ComplainantProfile_id, ComplainantFormM_id, TypeFormM, UID, IsTempTable);

            List<ClsPrp_ComplaintFormMN_Addmore_Respondent> respondentList = aa.FormMN_Respondent;

            return Json(new { data = respondentList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_AdditionalRespondentFormM(Int64 inRespM_IndexID, Int64 inRespM_ID, Int64 inProfile_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();
                if (sdb.Delete_FormM_Respondent(inRespM_ID, inRespM_IndexID, inProfile_ID))
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

        //Add facts of the case PDF files
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FactsCase_FormM_DocumentUpload(HttpPostedFileBase uploadedFile, ClsPrp_ComplaintFormM_Registration smodel)
        {
            //Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0)
            if (Request.Files.Count > 0 && (uploadedFile.ContentLength != 0))
            {
                if (smodel.FactsCase_NumberOfPages > 0)
                {
                    if (smodel.FactsCase_NumberOfPages > 0)//Mandatory Validation//ModelState.IsValid)//
                    {
                        Clsprp_Master_Complaint_Documents clsprp = new Clsprp_Master_Complaint_Documents();
                        ClsMethod_Master_Complaint_Documents objdoc = new ClsMethod_Master_Complaint_Documents();
                        Clsprp_ComplaintFormM_FactsCaseDocument clsprpPrmDoc = new Clsprp_ComplaintFormM_FactsCaseDocument();
                        ClsMethod_ComplaintFormM_Registration objPromoterDoc = new ClsMethod_ComplaintFormM_Registration();

                        Int32 IndexId = 103;// (with ref to master table data)                   I

                        Int64 ComplainantFormM_id = 0;
                        Int64 ComplainantProfile_id = 0;
                        if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                        {
                            //ProfileID_ID
                            if (Session["ApplicationId"].ToString() != "0")
                            {
                                ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                            }
                            //Complaint_ID
                            if (Session["ComplaintFormM_ID"] != null)
                            {
                                if (Session["ComplaintFormM_ID"].ToString() != "0")
                                {
                                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                                }
                            }
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Session Expired! Upload Failed",
                                statusCode = 102,
                                status = "Session Expired! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }

                        #region Read Master Data By Document Type
                        clsprp.prpMasterDocs = objdoc.Display_Master_Complaint_DocumentsByComplaintFormID(ComplainantFormM_id);

                        Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_ComplaintFormM_FactsOfTheCase_Documents_ByDocCodeInfo_ComplaintID_ProfileID(ComplainantFormM_id, ComplainantProfile_id, IndexId));

                        foreach (var item in clsprp.prpMasterDocs)
                        {
                            if (item.ComplaintDocMaster_InfoCode == IndexId)
                            {
                                clsprp.ComplaintDocMaster_IndexID = item.ComplaintDocMaster_IndexID;
                                clsprp.ComplaintDocMaster_InfoCode = item.ComplaintDocMaster_InfoCode;
                                clsprp.ComplaintDocMaster_InfoName = item.ComplaintDocMaster_InfoName;
                                clsprp.ComplaintDoc_SetFileSize = item.ComplaintDoc_SetFileSize;
                                clsprp.ComplaintDoc_SetFileFormat = item.ComplaintDoc_SetFileFormat;
                                clsprp.ComplaintDoc_SetFilePath = item.ComplaintDoc_SetFilePath;
                                clsprp.ComplaintDoc_ValidCode = item.ComplaintDoc_ValidCode;
                                clsprp.ComplaintDoc_ValidSubCode = item.ComplaintDoc_ValidSubCode;
                                clsprp.ComplaintDoc_ValidTinySubCode = item.ComplaintDoc_ValidTinySubCode;
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
                        string masterFactsCaseDoc_SetFilePath = "rwFormMFactCaseDoc";
                        bool IsValidFileType = false;
                        #endregion

                        //Bad Request - No Doc
                        if (Request.Files.Count > 0)
                        {
                            var PhotoIdentityDocument = uploadedFile;// Request.Files[0];

                            //Bad Request - No Doc OR No Size
                            if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                            {
                                #region SaveFile Path Creation
                                if (clsprp.ComplaintDoc_SetFilePath.ToString() != string.Empty || clsprp.ComplaintDoc_SetFilePath.ToString() != null)
                                {
                                    masterFactsCaseDoc_SetFilePath = clsprp.ComplaintDoc_SetFilePath.ToString();
                                }
                                pathindb = masterFactsCaseDoc_SetFilePath + "\\" + Convert.ToString(ComplainantProfile_id) + "\\";
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
                                masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ComplaintDoc_SetFileFormat);
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
                                    if (IsValidFileType)
                                    {
                                        if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                        {
                                            byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                            if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                            {
                                                savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ComplaintDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                                var pathsavefile = Path.Combine(path, savefileName);
                                                PhotoIdentityDocument.SaveAs(pathsavefile);

                                                var pathsavedb = Path.Combine(pathindb, savefileName);

                                                Int64 inFormM_ID = ComplainantFormM_id;
                                                Int64 inFormM_ProfileID = ComplainantProfile_id;
                                                string inFormDoc_FilePath = pathsavedb;
                                                string inFormDoc_FileName = savefileName;
                                                string inFormDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                                string inFormDoc_FileFormat = extensionPhotoIdentityDocument;
                                                Int32 inFormDoc_IsGroup = Convert.ToInt32(clsprp.IsGroup);

                                                bool varRet = SaveComplaintFormM_FactsCase_Documents(smodel, inFormM_ID, inFormM_ProfileID, inFormDoc_FilePath, inFormDoc_FileName, inFormDoc_FileSize, inFormDoc_FileFormat, inFormDoc_IsGroup);

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
                                                varSetFileSize = Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize);

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
                                                status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
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
                        status = "Number of Pages(s) required! Upload Failed",
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

        private bool SaveComplaintFormM_FactsCase_Documents(ClsPrp_ComplaintFormM_Registration smodel, Int64 z_ComplaintFormM_ID, Int64 z_ComplaintProfile_ID, String z_ComplaintFormDoc_FilePath, String z_ComplaintFormDoc_FileName, String z_ComplaintFormDoc_FileSize, String z_ComplaintFormDoc_FileFormat, Int32 z_ComplaintFormDoc_IsGroup)
        {
            Int64 FormMN_ID = 0;
            Int64 FormMN_ProfileID = 0;
            FormMN_ID = z_ComplaintFormM_ID;
            FormMN_ProfileID = z_ComplaintProfile_ID;
            string FormMNDoc_FilePath = String.IsNullOrEmpty(z_ComplaintFormDoc_FilePath) ? string.Empty : z_ComplaintFormDoc_FilePath;
            string FormMNDoc_FileName = String.IsNullOrEmpty(z_ComplaintFormDoc_FileName) ? string.Empty : z_ComplaintFormDoc_FileName;
            string FormMNDoc_FileSize = String.IsNullOrEmpty(z_ComplaintFormDoc_FileSize) ? string.Empty : z_ComplaintFormDoc_FileSize;
            string FormMNDoc_FileFormat = String.IsNullOrEmpty(z_ComplaintFormDoc_FileFormat) ? string.Empty : z_ComplaintFormDoc_FileFormat;
            Int32 FormMNDoc_IsGroup = z_ComplaintFormDoc_IsGroup;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;            
            bool varRET = false;

            try
            {
                Clsprp_ComplaintFormM_FactsCaseDocument objFC = new Clsprp_ComplaintFormM_FactsCaseDocument();
                ClsMethod_ComplaintFormM_Registration savedb = new ClsMethod_ComplaintFormM_Registration();

                if (smodel.FactsCase_OptionsYesNo == "factscasePDF")
                {
                    objFC.FactsCaseDocument_IndexID = 0;
                    objFC.FactsCaseDocument_ID = 0;
                    objFC.ComplainantApplicant_RelatedComplaintM_ID = FormMN_ID;
                    objFC.ComplainantApplicant_RelatedComplaintM_Code = Convert.ToString(FormMN_ID);
                    objFC.Profile_ID = FormMN_ProfileID;
                    objFC.User_ID = UID;

                    objFC.ComplaintType_MN = "FormTypeM";
                    objFC.FactsCaseDoc_InfoCode = "103";// (with ref to master table data) 
                    objFC.FactsCaseDoc_InfoName = "Facts of the Case";
                    objFC.FactsCaseDoc_ReferenceNumber = string.Empty;
                    objFC.FactsCaseDoc_IssueDate = DateTime.Now;

                    objFC.FactsCaseDoc_FileSize = FormMNDoc_FileSize;
                    objFC.FactsCaseDoc_FileFormat = FormMNDoc_FileFormat;
                    objFC.FactsCaseDoc_FilePath = FormMNDoc_FilePath;
                    objFC.FactsCaseDoc_FileName = FormMNDoc_FileName;
                    objFC.FactsCaseDoc_IsGroup = FormMNDoc_IsGroup;

                    objFC.Doc_SerialNumber = smodel.FactsCase_OptionsYesNo;
                    objFC.Doc_NumberOfPages = smodel.FactsCase_NumberOfPages;
                    objFC.Doc_PageStartNumber = 0;
                    objFC.Doc_PageEndNumber = 0;

                    objFC.Remarks_IfAny = string.Empty;
                    objFC.A_column = string.Empty;
                    objFC.B_column = string.Empty;
                    objFC.C_column = string.Empty;
                    objFC.D_column = string.Empty;

                    objFC.IsActive = 1;
                    objFC.IsDraft = 0;
                    objFC.IsLock = 0;
                    objFC.IsPublicView = 0;
                    objFC.IsTempTable = 1;

                    objFC.CreatedBy = userName;
                    objFC.CreatedOn = DateTime.Now;
                    objFC.ModifyBy = userName;
                    objFC.ModifyOn = DateTime.Now;
                }

                if (savedb.Add_ComplaintFormM_FactsOfTheCase_Documents_ByProfileID(objFC, FormMN_ID, FormMNDoc_FilePath, FormMNDoc_FileName, FormMNDoc_FileSize, FormMNDoc_FileFormat, FormMNDoc_IsGroup, FormMN_ProfileID,  UID, userName))
                {
                    varRET = true;
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }

        [HttpGet]
        public ActionResult ComplaintFormMFactsCaseFileDetail(Int64 factscaseID, Int64 profileID, Int64 complaintMID)
        {
            Int64 Factscase_ID = 0;
            Int64 Profile_ID = 0;
            Int64 ComplaintM_ID = 0;
            Int32 FactsCase_Flag = 0;
            string userName = User.Identity.Name;

            if (factscaseID != 0)
            {
                Factscase_ID = Convert.ToInt64(factscaseID);
            }
            if (profileID != 0)
            {
                Profile_ID = Convert.ToInt64(profileID);
            }
            if (complaintMID != 0)
            {
                ComplaintM_ID = Convert.ToInt64(complaintMID);
            }            

            Clsprp_ComplaintFormM_FactsCaseDocument aa = new Clsprp_ComplaintFormM_FactsCaseDocument();
            ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();

            aa.prpFormM_FactsCase_Docs = sdb.Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByID(Factscase_ID, ComplaintM_ID, Profile_ID, FactsCase_Flag, userName);
            foreach (var item in aa.prpFormM_FactsCase_Docs)
            {
                aa.FactsCaseDocument_IndexID = item.FactsCaseDocument_IndexID;
                aa.FactsCaseDocument_ID = item.FactsCaseDocument_ID;
                aa.ComplainantApplicant_RelatedComplaintM_ID = item.ComplainantApplicant_RelatedComplaintM_ID;
                aa.ComplainantApplicant_RelatedComplaintM_Code = item.ComplainantApplicant_RelatedComplaintM_Code;
                aa.Profile_ID = item.Profile_ID;
                aa.User_ID = item.User_ID;
                aa.ComplaintType_MN = item.ComplaintType_MN;

                aa.FactsCaseDoc_InfoCode = item.FactsCaseDoc_InfoCode;
                aa.FactsCaseDoc_InfoName = item.FactsCaseDoc_InfoName;
                aa.FactsCaseDoc_ReferenceNumber = item.FactsCaseDoc_ReferenceNumber;
                aa.FactsCaseDoc_IssueDate = item.FactsCaseDoc_IssueDate;
                aa.FactsCaseDoc_FileSize = item.FactsCaseDoc_FileSize;
                aa.FactsCaseDoc_FileFormat = item.FactsCaseDoc_FileFormat;
                aa.FactsCaseDoc_FilePath = item.FactsCaseDoc_FilePath;
                aa.FactsCaseDoc_FileName = item.FactsCaseDoc_FileName;
                aa.FactsCaseDoc_IsGroup = item.FactsCaseDoc_IsGroup;
                aa.Doc_SerialNumber = item.Doc_SerialNumber;
                aa.Doc_NumberOfPages = item.Doc_NumberOfPages;
                aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;
                aa.IsTempTable = item.IsTempTable;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;                
            }
            return View("ComplaintFormMFactsCaseFileDetail", aa);
        }

        [HttpGet]
        public ActionResult ComplaintFormMFactsCaseCurrentFileDetail(Int64 factscaseID, Int64 profileID, Int64 complaintMID)
        {
            Int64 Factscase_ID = 0;
            Int64 Profile_ID = 0;
            Int64 ComplaintM_ID = 0;
            Int32 FactsCase_Flag = 55;
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Profile_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["ComplaintFormM_ID"] != null)
                {
                    if (Session["ComplaintFormM_ID"].ToString() != "0")
                    {
                        ComplaintM_ID = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    }
                }
            }
            else
            {
                Factscase_ID = 0;
                Profile_ID = 0;
                ComplaintM_ID = 0;
            }

            Clsprp_ComplaintFormM_FactsCaseDocument aa = new Clsprp_ComplaintFormM_FactsCaseDocument();
            ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();

            aa.prpFormM_FactsCase_Docs = sdb.Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByID(Factscase_ID, ComplaintM_ID, Profile_ID, FactsCase_Flag, userName);
            foreach (var item in aa.prpFormM_FactsCase_Docs)
            {
                aa.FactsCaseDocument_IndexID = item.FactsCaseDocument_IndexID;
                aa.FactsCaseDocument_ID = item.FactsCaseDocument_ID;
                aa.ComplainantApplicant_RelatedComplaintM_ID = item.ComplainantApplicant_RelatedComplaintM_ID;
                aa.ComplainantApplicant_RelatedComplaintM_Code = item.ComplainantApplicant_RelatedComplaintM_Code;
                aa.Profile_ID = item.Profile_ID;
                aa.User_ID = item.User_ID;
                aa.ComplaintType_MN = item.ComplaintType_MN;

                aa.FactsCaseDoc_InfoCode = item.FactsCaseDoc_InfoCode;
                aa.FactsCaseDoc_InfoName = item.FactsCaseDoc_InfoName;
                aa.FactsCaseDoc_ReferenceNumber = item.FactsCaseDoc_ReferenceNumber;
                aa.FactsCaseDoc_IssueDate = item.FactsCaseDoc_IssueDate;
                aa.FactsCaseDoc_FileSize = item.FactsCaseDoc_FileSize;
                aa.FactsCaseDoc_FileFormat = item.FactsCaseDoc_FileFormat;
                aa.FactsCaseDoc_FilePath = item.FactsCaseDoc_FilePath;
                aa.FactsCaseDoc_FileName = item.FactsCaseDoc_FileName;
                aa.FactsCaseDoc_IsGroup = item.FactsCaseDoc_IsGroup;
                aa.Doc_SerialNumber = item.Doc_SerialNumber;
                aa.Doc_NumberOfPages = item.Doc_NumberOfPages;
                aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;
                aa.IsTempTable = item.IsTempTable;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            return View("ComplaintFormMFactsCaseFileDetail", aa);
        }

        [HttpGet]
        public JsonResult Delete_FactsCase_FormM_Document(Int64 inFactscase_IndexID, Int64 inFactscase_ID, Int64 inProfile_ID, Int64 inComplaintM_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();
                if (sdb.Delete_FormM_FactsOfTheCase_Document_ByID(inFactscase_IndexID, inFactscase_ID, inProfile_ID, inComplaintM_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            //return Json(new
            //{
            //    //Data = "Bad Request! Upload Failed",
            //    statusCode = 105,
            //    status = "Bad Request! Upload Failed",
            //    remarks = "Not Saved! Upload Failed "
            //}, JsonRequestBehavior.AllowGet);

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ContentResult Download_FactsCase_FormM_File(Int64 factscaseID, string filename, string filelink)
        {
            string base64 = string.Empty;
            try
            {
                //Set the File Folder Path.
                string path = Server.MapPath("~/" + filelink);

                //Read the File as Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);// + fileName);

                //Convert File to Base64 string and send to Client.
                base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return Content(base64);
        }

        [HttpGet]
        public ContentResult Download_FactsCase_FormM_CurrentFile(Int64 factscaseID, string filename, string filelink)
        {
            Int64 Factscase_ID = 0;
            Int64 Profile_ID = 0;
            Int64 ComplaintM_ID = 0;
            Int32 FactsCase_Flag = 55;
            string currentfilelink = string.Empty;
            string userName = User.Identity.Name;
            string base64 = string.Empty;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Profile_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["ComplaintFormM_ID"] != null)
                {
                    if (Session["ComplaintFormM_ID"].ToString() != "0")
                    {
                        ComplaintM_ID = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    }
                }
            }
            else
            {
                Factscase_ID = 0;
                Profile_ID = 0;
                ComplaintM_ID = 0;
            }

            Clsprp_ComplaintFormM_FactsCaseDocument aa = new Clsprp_ComplaintFormM_FactsCaseDocument();
            ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();

            try
            {
                aa.prpFormM_FactsCase_Docs = sdb.Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByID(Factscase_ID, ComplaintM_ID, Profile_ID, FactsCase_Flag, userName);
                foreach (var item in aa.prpFormM_FactsCase_Docs)
                {
                    aa.FactsCaseDocument_IndexID = item.FactsCaseDocument_IndexID;
                    aa.FactsCaseDocument_ID = item.FactsCaseDocument_ID;
                    aa.ComplainantApplicant_RelatedComplaintM_ID = item.ComplainantApplicant_RelatedComplaintM_ID;
                    aa.ComplainantApplicant_RelatedComplaintM_Code = item.ComplainantApplicant_RelatedComplaintM_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_MN = item.ComplaintType_MN;

                    aa.FactsCaseDoc_InfoCode = item.FactsCaseDoc_InfoCode;
                    aa.FactsCaseDoc_InfoName = item.FactsCaseDoc_InfoName;
                    aa.FactsCaseDoc_ReferenceNumber = item.FactsCaseDoc_ReferenceNumber;
                    aa.FactsCaseDoc_IssueDate = item.FactsCaseDoc_IssueDate;
                    aa.FactsCaseDoc_FileSize = item.FactsCaseDoc_FileSize;
                    aa.FactsCaseDoc_FileFormat = item.FactsCaseDoc_FileFormat;
                    aa.FactsCaseDoc_FilePath = item.FactsCaseDoc_FilePath;
                    aa.FactsCaseDoc_FileName = item.FactsCaseDoc_FileName;
                    aa.FactsCaseDoc_IsGroup = item.FactsCaseDoc_IsGroup;
                    aa.Doc_SerialNumber = item.Doc_SerialNumber;
                    aa.Doc_NumberOfPages = item.Doc_NumberOfPages;
                    aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                    aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                    aa.Remarks_IfAny = item.Remarks_IfAny;
                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;
                    aa.D_column = item.D_column;
                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    aa.IsTempTable = item.IsTempTable;
                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }

                currentfilelink = aa.FactsCaseDoc_FilePath.ToString();

                //Set the File Folder Path.
                string path = Server.MapPath("~/" + currentfilelink);

                //Read the File as Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);// + fileName);

                //Convert File to Base64 string and send to Client.
                base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return Content(base64);
        }

        #endregion




        /// <summary>
        /// 
        /// </summary>



        #region Step-II Form-M Doc
        [HttpGet]
        public ActionResult RegComplaintEncldocM()
        {
            Int64 ComplainantFormM_id = 0;
            Int32 retAbsoluteIsDraft = 1;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }

            ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
            Clsprp_ComplaintFormM_Documents aa = new Clsprp_ComplaintFormM_Documents();

            aa.ComplaintDoc_IssueDate = DateTime.Now;

            aa.prpFormM_Docs = sdb.Display_ComplaintFormM_Documents_ByComplaintFormM_ID(ComplainantFormM_id);
            if (aa.prpFormM_Docs.Count > 0)
            {
                foreach (var item in aa.prpFormM_Docs)
                {
                    aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
                    aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
                    aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                    aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
                    ////aa.Profile_ID = item.Profile_ID;
                    ////aa.User_ID = item.User_ID;
                    ////aa.ComplaintType_MN = item.ComplaintType_MN;
                    ////aa.ComplaintDoc_InfoCode = item.ComplaintDoc_InfoCode;
                    ////aa.ComplaintDoc_InfoName = item.ComplaintDoc_InfoName;
                    ////aa.ComplaintDoc_ReferenceNumber = item.ComplaintDoc_ReferenceNumber;
                    ////aa.ComplaintDoc_IssueDate = item.ComplaintDoc_IssueDate;

                    ////aa.ComplaintDoc_FileSize = item.ComplaintDoc_FileSize;
                    ////aa.ComplaintDoc_FileFormat = item.ComplaintDoc_FileFormat;
                    ////aa.ComplaintDoc_FilePath = item.ComplaintDoc_FilePath;
                    ////aa.ComplaintDoc_FileName = item.ComplaintDoc_FileName;
                    ////aa.ComplaintDoc_IsGroup = item.ComplaintDoc_IsGroup;
                    ////aa.Doc_SerialNumber = item.Doc_SerialNumber;
                    ////aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                    ////aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                    ////aa.Remarks_IfAny = item.Remarks_IfAny;
                    ////aa.A_column = item.A_column;
                    ////aa.B_column = item.B_column;
                    ////aa.C_column = item.C_column;
                    ////aa.D_column = item.D_column;
                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    ////aa.CreatedBy = item.CreatedBy;
                    ////aa.CreatedOn = item.CreatedOn;
                    ////aa.ModifyBy = item.ModifyBy;
                    ////aa.ModifyOn = item.ModifyOn;
                    if (item.IsDraft == 0 || item.IsDraft == 4)
                    {
                        retAbsoluteIsDraft = item.IsDraft;
                    }
                }
                aa.IsDraft = retAbsoluteIsDraft;
            }
            return View("RegComplaintEncldocM", aa);
        }

        [HttpPost]
        public ActionResult RegComplaintEncldocFormM()
        {
            Int64 ComplainantFormM_id = 0;
            Int32 retAbsoluteIsDraft = 1;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }

            ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
            Clsprp_ComplaintFormM_Documents aa = new Clsprp_ComplaintFormM_Documents();
            string userName = User.Identity.Name;

            Int64 varGetChk = sdb.Update_Check_ComplaintFormM_Documents(ComplainantFormM_id, userName);
            if (varGetChk == 100)
            {
                //Already OR Updated (IsDocComplete = true)
                return RedirectToAction("RequestPaymentFormM", "ComplaintPayment");
            }
            else if (varGetChk == 200 || varGetChk == 300)
            {
                // Pending (IsDocComplete = true)
                aa.ComplaintDoc_IssueDate = DateTime.Now;

                aa.prpFormM_Docs = sdb.Display_ComplaintFormM_Documents_ByComplaintFormM_ID(ComplainantFormM_id);
                if (aa.prpFormM_Docs.Count > 0)
                {
                    foreach (var item in aa.prpFormM_Docs)
                    {
                        aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
                        aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
                        aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                        aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;

                        aa.IsActive = item.IsActive;
                        aa.IsDraft = item.IsDraft;
                        aa.IsLock = item.IsLock;
                        aa.IsPublicView = item.IsPublicView;

                        if (item.IsDraft == 0 || item.IsDraft == 4)
                        {
                            retAbsoluteIsDraft = item.IsDraft;
                        }
                    }
                    aa.IsDraft = retAbsoluteIsDraft;
                }
                TempData["ComplaintFormMvalidDocName"] = "";
                if (varGetChk == 200)
                {
                    TempData["ComplaintFormMvalidDocName"] = "Incomplete Complaint Form-M Documents, Please upload Complaint Form-M Documents First.";
                }
                if (varGetChk == 300)
                {
                    TempData["ComplaintFormMvalidDocName"] = "Incomplete Complaint Form-M Documents, For un-registered project, it is mandatory to upload any of following document(s) as (a.) CLU or License to develop Colony (Sepecify, Ref Number and Issuing Authority in Remarks), (b.) Regularization Certificate (In case of illegal/unauthorized colony) and (c.) Agreement to Sell/ Allotment Letter/ LOI.";
                }
                return View("RegComplaintEncldocM", aa);
            }
            return RedirectToAction("RegComplaintEncldocM");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ComplaintFormMDocumentFormUpload(HttpPostedFileBase uploadedFile, Clsprp_ComplaintFormM_Documents smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Complaint_Documents clsprp = new Clsprp_Master_Complaint_Documents();
                    ClsMethod_Master_Complaint_Documents objdoc = new ClsMethod_Master_Complaint_Documents();
                    Clsprp_ComplaintFormM_Documents clsprpPrmDoc = new Clsprp_ComplaintFormM_Documents();
                    ClsMethod_ComplaintM_Documents objPromoterDoc = new ClsMethod_ComplaintM_Documents();

                    Int32 IndexId = 101;// smodel.ProjectDoc_InfoCode; (with ref to master table data)                   I

                    Int64 ComplainantFormM_id = 0;
                    if (Session["ComplaintFormM_ID"] != null)
                    {
                        if (Session["ComplaintFormM_ID"].ToString() != "0")
                        {
                            ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                        }
                    }                   

                    #region Read Master Data By Document Type
                    clsprp.prpMasterDocs = objdoc.Display_Master_Complaint_DocumentsByComplaintFormID(ComplainantFormM_id);

                    Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_ComplaintFormM_Documents_ByDocCodeInfo_ComplaintFormM_ID(ComplainantFormM_id, IndexId));

                    foreach (var item in clsprp.prpMasterDocs)
                    {
                        if (item.ComplaintDocMaster_InfoCode == IndexId)
                        {
                            clsprp.ComplaintDocMaster_IndexID = item.ComplaintDocMaster_IndexID;
                            clsprp.ComplaintDocMaster_InfoCode = item.ComplaintDocMaster_InfoCode;
                            clsprp.ComplaintDocMaster_InfoName = item.ComplaintDocMaster_InfoName;
                            clsprp.ComplaintDoc_SetFileSize = item.ComplaintDoc_SetFileSize;
                            clsprp.ComplaintDoc_SetFileFormat = item.ComplaintDoc_SetFileFormat;
                            clsprp.ComplaintDoc_SetFilePath = item.ComplaintDoc_SetFilePath;
                            clsprp.ComplaintDoc_ValidCode = item.ComplaintDoc_ValidCode;
                            clsprp.ComplaintDoc_ValidSubCode = item.ComplaintDoc_ValidSubCode;
                            clsprp.ComplaintDoc_ValidTinySubCode = item.ComplaintDoc_ValidTinySubCode;
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
                    string masterPromoterDoc_SetFilePath = "readwriteFormMDoc";
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
                            if (clsprp.ComplaintDoc_SetFilePath.ToString() != string.Empty || clsprp.ComplaintDoc_SetFilePath.ToString() != null)
                            {
                                masterPromoterDoc_SetFilePath = clsprp.ComplaintDoc_SetFilePath.ToString();
                            }
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(ComplainantFormM_id) + "\\";
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
                            masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ComplaintDoc_SetFileFormat);
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
                                if (IsValidFileType)
                                {
                                    if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                    {
                                        byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                        if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                        {
                                            savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ComplaintDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                            var pathsavefile = Path.Combine(path, savefileName);
                                            PhotoIdentityDocument.SaveAs(pathsavefile);

                                            var pathsavedb = Path.Combine(pathindb, savefileName);

                                            Int64 inFormM_ID = ComplainantFormM_id;
                                            string inFormDoc_FilePath = pathsavedb;
                                            string inFormDoc_FileName = savefileName;
                                            string inFormDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inFormDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inFormDoc_IsGroup = Convert.ToInt32(clsprp.IsGroup);

                                            bool varRet = SaveComplaintFormDocuments(smodel, inFormM_ID, inFormDoc_FilePath, inFormDoc_FileName, inFormDoc_FileSize, inFormDoc_FileFormat, inFormDoc_IsGroup);
                                            
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
                                            varSetFileSize = Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize);

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
                                            status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
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

        private bool SaveComplaintFormDocuments(Clsprp_ComplaintFormM_Documents smodel, Int64 z_ComplaintFormM_ID, String z_ComplaintFormDoc_FilePath, String z_ComplaintFormDoc_FileName, String z_ComplaintFormDoc_FileSize, String z_ComplaintFormDoc_FileFormat, Int32 z_ComplaintFormDoc_IsGroup)
        {
            Int64 FormMN_ID = 0;
            FormMN_ID = z_ComplaintFormM_ID;
            string FormMNDoc_FilePath = String.IsNullOrEmpty(z_ComplaintFormDoc_FilePath) ? string.Empty : z_ComplaintFormDoc_FilePath;
            string FormMNDoc_FileName = String.IsNullOrEmpty(z_ComplaintFormDoc_FileName) ? string.Empty : z_ComplaintFormDoc_FileName;
            string FormMNDoc_FileSize = String.IsNullOrEmpty(z_ComplaintFormDoc_FileSize) ? string.Empty : z_ComplaintFormDoc_FileSize;
            string FormMNDoc_FileFormat = String.IsNullOrEmpty(z_ComplaintFormDoc_FileFormat) ? string.Empty : z_ComplaintFormDoc_FileFormat;
            Int32 FormMNDoc_IsGroup = z_ComplaintFormDoc_IsGroup;
            Int64 ComplaintProfileID = 0;
            
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;


            bool varRET = false;            

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_ComplaintM_Documents savedb = new ClsMethod_ComplaintM_Documents();                                                                   
                    if (savedb.Add_ComplaintFormM_Documents(smodel, FormMN_ID, FormMNDoc_FilePath, FormMNDoc_FileName, FormMNDoc_FileSize, FormMNDoc_FileFormat, FormMNDoc_IsGroup, ComplaintProfileID, UID, userName))
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

        //GET: Delete
        public ActionResult Delete_ComplaintEncldocMDocument(Int64 inComplaintFormM_DocIndexID, Int64 inComplaintFormM_DocID, Int64 inComplaintFormM_ID)
        {
            try
            {
                ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
                if (sdb.Delete_ComplaintFormM_Document(inComplaintFormM_DocIndexID, inComplaintFormM_DocID, inComplaintFormM_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("RegComplaintEncldocM");
            }
            catch
            {
                return RedirectToAction("RegComplaintEncldocM");
            }
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

        public JsonResult GetStatusRegdProjectandUnRegdProjectFromM(string ComplaintID, string FormType)
        {
            Int64 Id = 0;
            string IdType = string.Empty;
            if (ComplaintID != "")
            {
                if (ComplaintID != "0")
                {
                    Id = Convert.ToInt64(ComplaintID);
                }
                else
                {
                    if (Session["ComplaintFormM_ID"] != null)
                    {
                        if (Session["ComplaintFormM_ID"].ToString() != "0")
                        {
                            Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                        }
                    }
                }
            }
            if (FormType != "")
            {
                IdType = Convert.ToString(FormType);
            }

            ClsMethod_ComplaintM_Documents objdis = new ClsMethod_ComplaintM_Documents();
            var states = objdis.GetStatusRegdProjectandUnRegdProjectFromMsearchByID(Id, IdType);

            return Json(states, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Step-IV Form-M Verify
        [HttpGet]
        public ActionResult RegComplaintVerificationM()
        {
            Int64 ComplainantFormM_id = 0;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }

            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                    objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                    objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }
            if (objflagstep.IsVerificationComplete == 0)
            {
                objflagstep.ComplaintVerificationDate = DateTime.Now;
            }            
            TempData["ComplaintMRegDiaryNumber_Name"] = "";
            TempData["ComplaintMRegDiaryNumber_Validate"] = "";
            return View(objflagstep);
        }

        [HttpPost]        
        public async Task<ActionResult> RegComplaintVerificationM(ClsPrp_ComplaintFormM_FlagStep smodel)
        {
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();

            Int64 ComplainantFormM_id = 0;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }

            Int64 ComplaintProfileID = 0;
            string ValidateComplaint = sdb.ValidateComplaintFormM_AgreeDetails(ComplainantFormM_id, ComplaintProfileID, UID, userName);
            if (ValidateComplaint == "FormM1001")
            {
                TempData["ComplaintMRegDiaryNumber_Name"] = "";
                TempData["ComplaintMRegDiaryNumber_Validate"] = "Invalid reference document(s) of un-registered Project! Please Submit Complaint Form-M (Step-I and II) First.";
            }
            else
            {
                TempData["ComplaintMRegDiaryNumber_Validate"] = "";
                // "0"; // 
                string Profile = sdb.UpdateComplaintFormM_AgreeDetails(smodel, ComplainantFormM_id, UID, userName);

                if (Profile == "0")
                {
                    TempData["ComplaintMRegDiaryNumber_Name"] = "Incomplete Complaint Form-M, Please Submit Complaint Form-M First.";
                }
                else if (Profile != null)
                {
                    TempData["ComplaintMRegDiaryNumber_Name"] = "Your Complaint Form-M successfully Submitted with diary number : " + Profile + " keep it for future reference, Thanks.";
                    await UserManager.SendEmailAsync(UID, "RERA, Punjab - Complaint Application (Form-M) Registration", "<b>Dear " + userName + "</b>,<br /><br /> Your Complaint Application with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />You are requested to log in to the RERA, Punjab web portal and check the complainant dashboard for further details, and actions required to be taken. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                }
                else
                {
                    TempData["ComplaintMRegDiaryNumber_Name"] = "Sorry, Your Complaint Form-M is pending";
                }
            }
            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            objflagstep.ComplaintFormMstepFlag = sdb.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                    objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                    objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            return View("RegComplaintVerificationM", objflagstep);      
        }
        #endregion

        #region Link Movement Form-M
        public string Get_ComplaintFormM_FlagStep()
        {
            string retSTR = string.Empty; //ComplaintFormM_ID
             Int64 ComplainantFormM_id = 0;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }

            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);
            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                    objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                    objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0 || objflagstep.IsDraft == 4)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }

        public string Get_ComplaintFormM_FlagStep(Int64 mComplaintFormM_ID)
        {
            string retSTR = string.Empty;
            Int64 ComplainantFormM_id = mComplaintFormM_ID;
            
            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);
            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                    objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                    objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0 || objflagstep.IsDraft == 4)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }
        #endregion

        #endregion

        #region Complaint FORM N

        #region Step-I Form-N Reg
        [HttpGet]
        public ActionResult RegComplaintFormN()
        {
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsPrp_ComplaintFormN_Registration aa = new ClsPrp_ComplaintFormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();
            ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            try
            {

                aa.districtMaster = objdis.dropdownlist_display1();
                aa.districtPunjabMaster = objdis.dropdownlist_display1(28); // For Punjab State Only
                aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv(); // For Punjab Sub-Division Only
                aa.stateMaster = objdis.State_list();


                aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
                if (aa.Complainant_UserProfile.Count >= 1)
                {
                    foreach (var item in aa.Complainant_UserProfile)
                    {
                        aa.Profile_ID = item.ComplaintProfile_ID;
                        aa.User_ID = item.UserID;

                        aa.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                        aa.Complainant_EmailAddress = item.EmailAddress;
                        aa.Complainant_MobileNumber = item.MobileNumber;
                        aa.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                        aa.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                        aa.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                        aa.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                        aa.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                        aa.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                        aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                        aa.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                        aa.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                        aa.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                        aa.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                        aa.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                    }

                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";
                }
                else
                {
                    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                    return RedirectToAction("RegComplaintProfileNA", "Complaint");
                }


                Int64 ComplainantFormN_id = 0;
                if (Session["ComplaintFormN_ID"] != null)
                {
                    if (Session["ComplaintFormN_ID"].ToString() != "0")
                    {
                        ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    }
                }
                string userName = User.Identity.Name;

                //objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);
                aa.ComplaintFormNstepI = objFormAppM.Display_ComplaintFormN_Registration_StepI(ComplainantFormN_id);
                if (aa.ComplaintFormNstepI.Count >= 1)
                {
                    foreach (var item in aa.ComplaintFormNstepI)
                    {
                        aa.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                        aa.ComplaintFormN_ID = item.ComplaintFormN_ID;
                        aa.ComplaintFormN_Code = item.ComplaintFormN_Code;

                        aa.Profile_ID = item.Profile_ID;
                        aa.User_ID = item.User_ID;
                        aa.ComplaintType_MN = item.ComplaintType_MN;

                        aa.IsComplaintComplete = item.IsComplaintComplete;
                        aa.IsPaymentComplete = item.IsPaymentComplete;
                        aa.IsDocumentsComplete = item.IsDocumentsComplete;

                        aa.IsVerificationComplete = item.IsVerificationComplete;
                        aa.ComplaintVerificationDate = item.ComplaintVerificationDate;

                        aa.Complainant_Name = item.Complainant_Name;
                        aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
                        aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                        aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                        aa.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                        aa.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                        aa.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                        aa.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                        aa.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                        aa.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;
                        aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
                        aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                        aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                        aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                        aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                        aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                        aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
                        aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
                        aa.AuthorizedRepresentativeCounsel_MobileNumber = item.AuthorizedRepresentativeCounsel_MobileNumber;
                        aa.AuthorizedRepresentativeCounsel_LandlineFaxNumber = item.AuthorizedRepresentativeCounsel_LandlineFaxNumber;

                        aa.RelatesComplaint_ComplaintAgainstType = item.RelatesComplaint_ComplaintAgainstType;
                        aa.RelatesComplaint_ProjectAgent_RERA_RegNumber = item.RelatesComplaint_ProjectAgent_RERA_RegNumber;
                        aa.RelatesComplaint_ProjectAgent_Name = item.RelatesComplaint_ProjectAgent_Name;

                        aa.Respondent_Name = item.Respondent_Name;
                        aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
                        aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
                        aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;
                        aa.OfficeResRespondent_AddressLine1 = item.OfficeResRespondent_AddressLine1;
                        aa.OfficeResRespondent_AddressLine2 = item.OfficeResRespondent_AddressLine2;
                        aa.OfficeResRespondent_AddressStateCode = item.OfficeResRespondent_AddressStateCode;
                        aa.OfficeResRespondent_AddressDistrictCode = item.OfficeResRespondent_AddressDistrictCode;
                        aa.OfficeResRespondent_AddressPIN = item.OfficeResRespondent_AddressPIN;
                        aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = item.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress;
                        aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
                        aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
                        aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
                        aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
                        aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

                        aa.IsAgreeDeclaration_JurisdictionRERAPunjab = item.IsAgreeDeclaration_JurisdictionRERAPunjab;
                        aa.FactsCase_Statement = item.FactsCase_Statement;
                        aa.ReliefSought_Statement = item.ReliefSought_Statement;
                        aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                        aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                        aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                        aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;
                        aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                        aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                        aa.Remarks_IfAny = item.Remarks_IfAny;
                        aa.A_column = item.A_column;
                        aa.B_column = item.B_column;
                        aa.C_column = item.C_column;
                        aa.D_column = item.D_column;
                        //aa.E_column = item.E_column;

                        Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaintFormN(item.E_column);

                        aa.IsYes_columnCLU = extractCode.Item1;
                        aa.IsYes_columnLTDC = extractCode.Item2;
                        aa.IsYes_columnRegCert = extractCode.Item3;
                        aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                        aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                        aa.columnExtraReferenceNumber = extractCode.Item6;
                        aa.E_column = extractCode.Item7;

                        aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                        aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                        aa.IsYes_columnLOI = extractCode.Rest.Item3;
                        aa.IsYes_columnExtraA = extractCode.Rest.Item4;

                        aa.IsActive = item.IsActive;
                        aa.IsDraft = item.IsDraft;
                        aa.IsLock = item.IsLock;
                        aa.IsPublicView = item.IsPublicView;
                        aa.CreatedBy = item.CreatedBy;
                        aa.CreatedOn = item.CreatedOn;
                        aa.ModifyBy = item.ModifyBy;
                        aa.ModifyOn = item.ModifyOn;
                    }
                }

                aa.FactsCase_Documents = objFormAppM.Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI(ComplainantFormN_id, ComplainantProfile_id, "FormTypeN", string.Empty, userName);
                aa.FactsCase_FileName = "Facts of the Case";
                aa.FactsCase_FileType = ".pdf";
                if (aa.FactsCase_Documents.Count > 0)
                {
                    aa.FactsCase_OptionsYesNo = "factscasePDF";
                }
                else
                {
                    aa.FactsCase_OptionsYesNo = "factscaseText";
                }
            }
            catch (Exception ex)
            {
                string ext = ex.ToString();
            }

            if (aa.ComplaintFormNstepI.Count >= 1)
            {
                TempData["submitvalueFormNStep1"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalueFormNStep1"] = "Save"; TempData.Keep();
            }

            //return View("RegComplaintFormM", aa);
            return View(aa);
        }

        [HttpGet]
        public ActionResult Details_RegComplaintFormN(Int64 zComplaintFormN_ID, Int64 zComplaintProfile_ID)
        {
            Int64 ComplainantProfile_id = zComplaintProfile_ID;

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsPrp_ComplaintFormN_Registration aa = new ClsPrp_ComplaintFormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();
            ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            aa.districtMaster = objdis.dropdownlist_display1();
            aa.districtPunjabMaster = objdis.dropdownlist_display1(28); // For Punjab State Only
            aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv(); // For Punjab Sub-Division Only
            aa.stateMaster = objdis.State_list();


            aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
            if (aa.Complainant_UserProfile.Count >= 1)
            {
                foreach (var item in aa.Complainant_UserProfile)
                {
                    aa.Profile_ID = item.ComplaintProfile_ID;
                    aa.User_ID = item.UserID;

                    aa.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                    aa.Complainant_EmailAddress = item.EmailAddress;
                    aa.Complainant_MobileNumber = item.MobileNumber;
                    aa.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                    aa.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                    aa.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                    aa.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                    aa.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                    aa.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                    aa.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                    aa.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                    aa.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                    aa.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                    aa.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                }

                aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaintFormN("NIL");
                aa.IsYes_columnCLU = extractCode.Item1;
                aa.IsYes_columnLTDC = extractCode.Item2;
                aa.IsYes_columnRegCert = extractCode.Item3;
                aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                aa.columnExtraReferenceNumber = extractCode.Item6;
                aa.E_column = extractCode.Item7;

                aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                aa.IsYes_columnLOI = extractCode.Rest.Item3;
                aa.IsYes_columnExtraA = extractCode.Rest.Item4;
            }
            else
            {
                aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
                aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaintFormN("NIL");
                aa.IsYes_columnCLU = extractCode.Item1;
                aa.IsYes_columnLTDC = extractCode.Item2;
                aa.IsYes_columnRegCert = extractCode.Item3;
                aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                aa.columnExtraReferenceNumber = extractCode.Item6;
                aa.E_column = extractCode.Item7;

                aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                aa.IsYes_columnLOI = extractCode.Rest.Item3;
                aa.IsYes_columnExtraA = extractCode.Rest.Item4;
            }


            Int64 ComplainantFormN_id = zComplaintFormN_ID;

            Session["ComplaintFormN_ID"] = ComplainantFormN_id;            

            try
            {
                string varFlagStep_LinkName = Get_ComplaintFormN_FlagStep(ComplainantFormN_id);

                string varFlagStep_ControllerLinkName = string.Empty;
                string varFlagStep_ActionLinkName = string.Empty;

                switch (varFlagStep_LinkName)
                {
                    case "Step1M":
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintFormN";
                        break;
                    case "Step2M":
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintEncldocN";
                        break;
                    case "Step3M":
                        varFlagStep_ControllerLinkName = "ComplaintPayment";
                        varFlagStep_ActionLinkName = "RequestPaymentN";
                        break;
                    case "Step4M":
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintVerificationN";
                        break;
                    default:
                        varFlagStep_ControllerLinkName = "Complaint";
                        varFlagStep_ActionLinkName = "RegComplaintFormN";
                        break;
                }

                return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return RedirectToAction("RegComplaintFormN", "Complaint");
            }
            //return View(aa);
        }

        [HttpGet]
        public ActionResult Create_RegComplaintFormN()
        {
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string userName = User.Identity.Name;

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsPrp_ComplaintFormN_Registration aa = new ClsPrp_ComplaintFormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();
            ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            try
            {
                aa.districtMaster = objdis.dropdownlist_display1();
                aa.districtPunjabMaster = objdis.dropdownlist_display1(28); // For Punjab State Only
                aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv(); // For Punjab Sub-Division Only
                aa.stateMaster = objdis.State_list();

                aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
                if (aa.Complainant_UserProfile.Count >= 1)
                {
                    foreach (var item in aa.Complainant_UserProfile)
                    {
                        aa.Profile_ID = item.ComplaintProfile_ID;
                        aa.User_ID = item.UserID;

                        aa.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                        aa.Complainant_EmailAddress = item.EmailAddress;
                        aa.Complainant_MobileNumber = item.MobileNumber;
                        aa.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                        aa.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                        aa.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                        aa.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                        aa.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                        aa.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                        aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                        aa.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                        aa.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                        aa.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                        aa.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                        aa.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                    }

                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                    Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaintFormN("NIL");
                    aa.IsYes_columnCLU = extractCode.Item1;
                    aa.IsYes_columnLTDC = extractCode.Item2;
                    aa.IsYes_columnRegCert = extractCode.Item3;
                    aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                    aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                    aa.columnExtraReferenceNumber = extractCode.Item6;
                    aa.E_column = extractCode.Item7;

                    aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                    aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                    aa.IsYes_columnLOI = extractCode.Rest.Item3;
                    aa.IsYes_columnExtraA = extractCode.Rest.Item4;
                }
                else
                {
                    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
                    aa.IsAgreeDeclaration_JurisdictionRERAPunjab = "0";
                    aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = "0";

                    Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> extractCode = fnExtractSubStringUnRegdComplaintFormN("NIL");
                    aa.IsYes_columnCLU = extractCode.Item1;
                    aa.IsYes_columnLTDC = extractCode.Item2;
                    aa.IsYes_columnRegCert = extractCode.Item3;
                    aa.columnDistrictCode = Convert.ToString(extractCode.Item4);
                    aa.columnSubDivisionCode = Convert.ToString(extractCode.Item5);

                    aa.columnExtraReferenceNumber = extractCode.Item6;
                    aa.E_column = extractCode.Item7;

                    aa.IsYes_columnAgreementSale = extractCode.Rest.Item1;
                    aa.IsYes_columnAllotmentLetter = extractCode.Rest.Item2;
                    aa.IsYes_columnLOI = extractCode.Rest.Item3;
                    aa.IsYes_columnExtraA = extractCode.Rest.Item4;

                    return RedirectToAction("RegComplaintProfileNA", "Complaint");
                }


                Int64 ComplainantFormN_id = 0;
                Session["ComplaintFormN_ID"] = ComplainantFormN_id;

                aa.ComplaintFormN_IndexID = 0;
                aa.ComplaintFormN_ID = 0;
                aa.ComplaintFormN_Code = string.Empty;
                aa.Profile_ID = ComplainantProfile_id;

                aa.IsActive = 0;
                aa.IsDraft = 0;
                aa.IsLock = 0;
                aa.IsPublicView = 0;

                aa.FactsCase_Documents = objFormAppM.Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI(ComplainantFormN_id, ComplainantProfile_id, "FormTypeN", string.Empty, userName);
                aa.FactsCase_FileName = "Facts of the Case";
                aa.FactsCase_FileType = ".pdf";
                if (aa.FactsCase_Documents.Count > 0)
                {
                    aa.FactsCase_OptionsYesNo = "factscasePDF";
                }
                else
                {
                    aa.FactsCase_OptionsYesNo = "factscaseText";
                }                
            }
            catch (Exception ex)
            {
                string ext = ex.ToString();
            }

            if (aa.ComplaintFormNstepI.Count >= 1)
            {
                TempData["submitvalueFormNStep1"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalueFormNStep1"] = "Save"; TempData.Keep();
            } 
                       
            return View("RegComplaintFormN", aa);
        }

        [HttpPost] //[ValidateInput(false)]        
        public ActionResult RegComplaintFormN(ClsPrp_ComplaintFormN_Registration smodel)
        {
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            bool varFlag_FactsCase = false;

            ClsPrp_ComplaintFormN_Registration aa = new ClsPrp_ComplaintFormN_Registration();

            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();
            ClsMethod_ComplaintFormM_Addmore_Complainant objFormComplainantAppM = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            ClsMethod_ComplaintFormM_Addmore_Respondent objFormRespondantAppM = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            #region Verification PDF (Facts of the Case)
            try
            {
                Int64 FactsCaseDoc_ID = 0;
                Int64 FactsCaseDoc_InfoCode = 104;

                if (smodel.FactsCase_OptionsYesNo == "factscasePDF")
                {
                    //"factscasePDF"
                    smodel.FactsCase_Statement = "Enclosed PDF file (Facts of the Case)";
                    ModelState.Remove("FactsCase_Statement");
                    varFlag_FactsCase = true;
                    varFlag_FactsCase = objFormAppM.Verify_ComplaintFormN_FactsOfTheCase_Documents_ByProfileID("mPDF", smodel.ComplaintFormN_ID, smodel.Profile_ID, "FormTypeN", FactsCaseDoc_ID, FactsCaseDoc_InfoCode, userName);
                }
                else
                {
                    //"factscaseText" 
                    //(smodel.FactsCase_OptionsYesNo == "factscaseText")                   
                    varFlag_FactsCase = true;
                    varFlag_FactsCase = objFormAppM.Verify_ComplaintFormN_FactsOfTheCase_Documents_ByProfileID("mTEXT", smodel.ComplaintFormN_ID, smodel.Profile_ID, "FormTypeN", FactsCaseDoc_ID, FactsCaseDoc_InfoCode, userName);
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
            #endregion

            #region Save & Update         
            if (TempData["submitvalueFormNStep1"].ToString() == "Update")
            {
                try
                {
                    if (varFlag_FactsCase)
                    {
                        if (ModelState.IsValid)
                        {
                            string retSubStringValue = fnSaveSubStringUnRegdComplaintFormN(smodel);
                            smodel.E_column = retSubStringValue;
                            objFormAppM.Update_ComplaintFormN_Registration_StepI(smodel, UID, userName);
                            TempData["message"] = "Details Updated Successfully";

                            Session["ComplaintFormN_ID"] = smodel.ComplaintFormN_ID;

                            ModelState.Clear();
                        }
                    }

                    string varFlagStep_LinkName = Get_ComplaintFormN_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocN";                            
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentN";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationN";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                    }

                    //return RedirectToAction("RegComplaintFormM");
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    return View();
                }
            }
            else
            {
                try
                {
                    //EXTRA (stopped as order by SC)
                    //ModelState.Remove("D_column");
                    //smodel.D_column = "registeredproject";
                    if (varFlag_FactsCase)
                    {
                        if (ModelState.IsValid)
                        {
                            string retSubStringValue = fnSaveSubStringUnRegdComplaintFormN(smodel);
                            smodel.E_column = retSubStringValue;
                            Int64 Appid = objFormAppM.Add_ComplaintFormN_Registration_StepI(smodel, UID, userName);
                            if (Appid > 0)
                            {
                                ViewBag.ApplicationId = Appid;
                                ViewBag.Message = " Details Successfully Submitted";
                                TempData["message"] = " Details Successfully Submitted";

                                Session["ComplaintFormN_ID"] = Appid;
                                smodel.ComplaintFormN_ID = Convert.ToInt64(Session["ComplaintFormM_ID"]);

                                ModelState.Clear();
                            }
                        }
                    }

                    string varFlagStep_LinkName = Get_ComplaintFormN_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocN";
                            break;
                        case "Step3M":                            
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentN";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationN";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                    }

                    //return RedirectToAction("RegComplaintFormM");
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    return View();
                }
            }
            #endregion

            ///////////await UserManager.SendEmailAsync(UID, "RERA, Punjab - TEST MAIL Activation Link", "<b>Dear " + "Ram Lal" + "</b>,<br /><br /> Thank you for signing up with Punjab RERA. Please confirm your account by clicking <a href=\"" + "Test Bhai" + "\">here (Activation Link)</a> <br /><br /><br />This link is valid for 24 hours. If you fail to click on this link within 24 hours, you would need to signup again. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");

        }

        private Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>> fnExtractSubStringUnRegdComplaintFormN(string varFormStr)
        {
            string retflagCLU = string.Empty;
            string retflagLTDC = string.Empty;
            string retflagREGC = string.Empty;
            string retflagATS = string.Empty;
            string retflagAL = string.Empty;
            string retflagLOI = string.Empty;
            string retflagMORE = string.Empty;
            Int32 retflagDistrictCode = 0;
            Int32 retflagSubDivisionCode = 0;
            string retflagExtra = string.Empty;
            string retflagRefInfo = string.Empty;

            try
            {
                if (varFormStr == "NIL")
                {
                    retflagCLU = "NCLU";
                    retflagLTDC = "NLTDC";
                    retflagREGC = "NREGC";
                    retflagATS = "NATS";
                    retflagAL = "NALD";
                    retflagLOI = "NLOI";
                    retflagMORE = "NMORE";
                    retflagDistrictCode = 0;
                    retflagSubDivisionCode = 0;
                    retflagExtra = "NEXTRA";
                    retflagRefInfo = string.Empty;
                }
                else
                {
                    string input = varFormStr;
                    //string input = "//YCLU////YLTDC////NREGC////366////0////NEXTRA////remarks if any//";
                    //string input = "//YCLU////YLTDC////NREGC////YATS////YALD////NLOI////NMORE////366////0////NEXTRA////remarks if any//";
                    string[] getstrings = Regex.Matches(input, @"\//(.+?)\//")
                                                .Cast<Match>()
                                                .Select(s => s.Groups[1].Value).ToArray();

                    if (getstrings.Length > 0)
                    {
                        if (getstrings.Length <= 10)
                        {
                            retflagCLU = getstrings[0];
                            retflagLTDC = getstrings[1];
                            retflagREGC = getstrings[2];
                            retflagATS = getstrings[3];
                            retflagAL = getstrings[4];
                            retflagLOI = getstrings[5];
                            retflagMORE = getstrings[6];
                            retflagDistrictCode = String.IsNullOrEmpty(getstrings[7]) ? 0 : Convert.ToInt32(getstrings[7]);
                            retflagSubDivisionCode = String.IsNullOrEmpty(getstrings[8]) ? 0 : Convert.ToInt32(getstrings[8]);
                            retflagExtra = getstrings[9];
                            retflagRefInfo = string.Empty;
                        }
                        else
                        {
                            retflagCLU = getstrings[0];
                            retflagLTDC = getstrings[1];
                            retflagREGC = getstrings[2];
                            retflagATS = getstrings[3];
                            retflagAL = getstrings[4];
                            retflagLOI = getstrings[5];
                            retflagMORE = getstrings[6];
                            retflagDistrictCode = String.IsNullOrEmpty(getstrings[7]) ? 0 : Convert.ToInt32(getstrings[7]);
                            retflagSubDivisionCode = String.IsNullOrEmpty(getstrings[8]) ? 0 : Convert.ToInt32(getstrings[8]);
                            retflagExtra = getstrings[9];
                            retflagRefInfo = getstrings[10];
                        }
                    }
                    else
                    {
                        retflagCLU = "NCLU";
                        retflagLTDC = "NLTDC";
                        retflagREGC = "NREGC";
                        retflagATS = "NATS";
                        retflagAL = "NALD";
                        retflagLOI = "NLOI";
                        retflagMORE = "NMORE";
                        retflagDistrictCode = 0;
                        retflagSubDivisionCode = 0;
                        retflagExtra = "NEXTRA";
                        retflagRefInfo = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                retflagCLU = "NCLU";
                retflagLTDC = "NLTDC";
                retflagREGC = "NREGC";
                retflagATS = "NATS";
                retflagAL = "NALD";
                retflagLOI = "NLOI";
                retflagMORE = "NMORE";
                retflagDistrictCode = 0;
                retflagSubDivisionCode = 0;
                retflagExtra = "NEXTRA";
                retflagRefInfo = string.Empty;
            }

            return new Tuple<string, string, string, Int32, Int32, string, string, Tuple<string, string, string, string>>(retflagCLU, retflagLTDC, retflagREGC, retflagDistrictCode, retflagSubDivisionCode, retflagExtra, retflagRefInfo, Tuple.Create(retflagATS, retflagAL, retflagLOI, retflagMORE));
        }

        private string fnSaveSubStringUnRegdComplaintFormN(ClsPrp_ComplaintFormN_Registration smodel)
        {
            string retflagCLU = string.Empty;
            string retflagLTDC = string.Empty;
            string retflagREGC = string.Empty;
            string retflagATS = string.Empty;
            string retflagAL = string.Empty;
            string retflagLOI = string.Empty;
            string retflagMORE = string.Empty;
            Int32 retflagDistrictCode = 0;
            Int32 retflagSubDivisionCode = 0;
            string retflagExtra = string.Empty;
            string retflagRefInfo = string.Empty;
            string input = string.Empty;

            if (smodel != null)
            {
                if (smodel.D_column == "unregisteredproject")
                {
                    retflagCLU = String.IsNullOrEmpty(smodel.IsYes_columnCLU) ? "NCLU" : smodel.IsYes_columnCLU;
                    retflagLTDC = String.IsNullOrEmpty(smodel.IsYes_columnLTDC) ? "NLTDC" : smodel.IsYes_columnLTDC;
                    retflagREGC = String.IsNullOrEmpty(smodel.IsYes_columnRegCert) ? "NREGC" : smodel.IsYes_columnRegCert;
                    retflagATS = String.IsNullOrEmpty(smodel.IsYes_columnAgreementSale) ? "NATS" : smodel.IsYes_columnAgreementSale;
                    retflagAL = String.IsNullOrEmpty(smodel.IsYes_columnAllotmentLetter) ? "NALD" : smodel.IsYes_columnAllotmentLetter;
                    retflagLOI = String.IsNullOrEmpty(smodel.IsYes_columnLOI) ? "NLOI" : smodel.IsYes_columnLOI;
                    retflagMORE = String.IsNullOrEmpty(smodel.IsYes_columnExtraA) ? "NMORE" : smodel.IsYes_columnExtraA;
                    retflagDistrictCode = String.IsNullOrEmpty(smodel.columnDistrictCode) ? 0 : Convert.ToInt32(smodel.columnDistrictCode);
                    retflagSubDivisionCode = String.IsNullOrEmpty(smodel.columnSubDivisionCode) ? 0 : Convert.ToInt32(smodel.columnSubDivisionCode);
                    retflagExtra = String.IsNullOrEmpty(smodel.columnExtraReferenceNumber) ? "NEXTRA" : smodel.columnExtraReferenceNumber;
                    retflagRefInfo = smodel.E_column;
                }
                if (smodel.D_column == "registeredproject")
                {
                    retflagCLU = "NCLU";
                    retflagLTDC = "NLTDC";
                    retflagREGC = "NREGC";
                    retflagATS = "NATS";
                    retflagAL = "NALD";
                    retflagLOI = "NLOI";
                    retflagMORE = "NMORE";
                    retflagDistrictCode = 0;
                    retflagSubDivisionCode = 0;
                    retflagExtra = "NEXTRA";
                    retflagRefInfo = string.Empty;
                }
            }
            else
            {
                retflagCLU = "NCLU";
                retflagLTDC = "NLTDC";
                retflagREGC = "NREGC";
                retflagATS = "NATS";
                retflagAL = "NALD";
                retflagLOI = "NLOI";
                retflagMORE = "NMORE";
                retflagDistrictCode = 0;
                retflagSubDivisionCode = 0;
                retflagExtra = "NEXTRA";
                retflagRefInfo = string.Empty;
            }

            input = "//" + retflagCLU + "////" + retflagLTDC + "////" + retflagREGC + "////" + retflagATS + "////" + retflagAL + "////" + retflagLOI + "////" + retflagMORE + "////" + retflagDistrictCode + "////" + retflagSubDivisionCode + "////" + retflagExtra + "////" + retflagRefInfo + "//";
            return input;
        }

        //Add more complainant details
        [HttpGet]
        public ActionResult RegAdditionalComplaintFormN()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormN_id = 11; // Blank or New Entry Data
            string TypeFormN = "FormTypeN";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;
            Int32 retAbsoluteIsDraft = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormN_Addmore_Complainant sdb = new ClsMethod_ComplaintFormN_Addmore_Complainant();

            aa.FormMN_Complainant = sdb.Display_ComplainantFormN_Detail(ComplainantProfile_id, ComplainantFormN_id, TypeFormN, UID, IsTempTable);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            if (aa.FormMN_Complainant.Count >= 1)
            {
                foreach (var item in aa.FormMN_Complainant)
                {
                    aa.AdditionComplainant_IndexID = item.AdditionComplainant_IndexID;
                    aa.AdditionComplainant_ID = item.AdditionComplainant_ID;
                    aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                    aa.ComplainantorApplicant_RelatedComplaint_Code = item.ComplainantorApplicant_RelatedComplaint_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_MN = item.ComplaintType_MN;                  

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    aa.IsTempTable = item.IsTempTable;

                    if (item.IsDraft == 0 || item.IsDraft == 4)
                    {
                        retAbsoluteIsDraft = item.IsDraft;
                    }
                }
                aa.IsDraft = retAbsoluteIsDraft;
            }
            else
            {
                ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
                ClsMethod_ComplaintFormN_Registration objFormAppN = new ClsMethod_ComplaintFormN_Registration();

                objflagstep.ComplaintFormNstepFlag = objFormAppN.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);

                if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
                {
                    foreach (var item in objflagstep.ComplaintFormNstepFlag)
                    {
                        objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                        objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                        objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                        objflagstep.Profile_ID = item.Profile_ID;
                        objflagstep.User_ID = item.User_ID;
                        objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                        objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                        objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                        objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                        objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                        objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                        objflagstep.IsActive = item.IsActive;
                        objflagstep.IsDraft = item.IsDraft;
                        objflagstep.IsLock = item.IsLock;
                        objflagstep.IsPublicView = item.IsPublicView;
                        objflagstep.CreatedBy = item.CreatedBy;
                        objflagstep.CreatedOn = item.CreatedOn;
                        objflagstep.ModifyBy = item.ModifyBy;
                        objflagstep.ModifyOn = item.ModifyOn;
                    }

                    if (objflagstep.IsVerificationComplete == 1)
                    {
                        if (objflagstep.IsDraft == 1 || objflagstep.IsDraft == 5 || objflagstep.IsDraft == 6)
                        {
                            if(objflagstep.IsLock != 1)
                            {
                                aa.AdditionComplainant_IndexID = 0;
                                aa.AdditionComplainant_ID = 0;
                                aa.IsActive = 0;
                                aa.IsDraft = 0;
                                aa.IsLock = 0;
                            }
                            else
                            {
                                aa.AdditionComplainant_IndexID = 0;
                                aa.AdditionComplainant_ID = 0;
                                aa.IsActive = 1;
                                aa.IsDraft = 1;
                                aa.IsLock = 1;
                            }                            
                        }
                    }

                }
            }

            return View("RegAdditionalComplaintFormN", aa);
        }

        [HttpPost]
        public ActionResult SaveComplainantFormNDetail(ClsPrp_ComplaintFormMN_Addmore_Complainant[] order)
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormN_id = 11; // Blank or New Entry Data
            string TypeFormN = "FormTypeN";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            bool status = false;
            Int64? chkappid = null;
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormN_Addmore_Complainant sdb = new ClsMethod_ComplaintFormN_Addmore_Complainant();
            List<ClsPrp_ComplaintFormMN_Addmore_Complainant> Complainant = new List<ClsPrp_ComplaintFormMN_Addmore_Complainant>();

            if (ModelState.IsValid)
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        ClsPrp_ComplaintFormMN_Addmore_Complainant O = new ClsPrp_ComplaintFormMN_Addmore_Complainant();

                        O.AdditionComplainant_IndexID = 0;
                        O.AdditionComplainant_ID = 0;
                        O.ComplainantApplicant_RelatedComplaint_ID = ComplainantFormN_id;
                        O.ComplainantorApplicant_RelatedComplaint_Code = ComplainantFormN_id.ToString();
                        O.Profile_ID = ComplainantProfile_id;
                        O.User_ID = UID;
                        O.ComplaintType_MN = TypeFormN;
                        O.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                        O.Name_of_Complainant_or_Applicant = item.Name_of_Complainant_or_Applicant;
                        O.EmailAddress = item.EmailAddress;
                        O.MobileNumber = item.MobileNumber;
                        O.LandlineNumber = item.LandlineNumber;

                        O.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                        O.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                        O.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                        O.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                        O.RegOffice_AddressPIN = item.RegOffice_AddressPIN;

                        O.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;

                        O.Service_AddressLine1 = item.Service_AddressLine1;
                        O.Service_AddressLine2 = item.Service_AddressLine2;
                        O.Service_AddressStateCode = item.Service_AddressStateCode;
                        O.Service_AddressDistrictCode = item.Service_AddressDistrictCode;
                        O.Service_AddressPIN = item.Service_AddressPIN;

                        O.Remarks_IfAny = "";
                        O.A_column = "";
                        O.B_column = "";
                        O.C_column = "";

                        O.IsActive = 1;
                        O.IsDraft = 0;
                        O.IsLock = 0;
                        O.IsPublicView = 0;
                        O.IsTempTable = IsTempTable;

                        chkappid = sdb.Add_FormN_Complainant(O, UID, UserNam);
                    }
                }

                if (chkappid == null)
                    status = false;
                else
                    status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult GetComplainantFormNData()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormN_id = 11; // Blank or New Entry Data
            string TypeFormN = "FormTypeN";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormN_Addmore_Complainant sdb = new ClsMethod_ComplaintFormN_Addmore_Complainant();

            aa.FormMN_Complainant = sdb.Display_ComplainantFormN_Detail(ComplainantProfile_id, ComplainantFormN_id, TypeFormN, UID, IsTempTable);
            //aa.districtMaster = objdis.dropdownlist_display1();
            //aa.stateMaster = objdis.State_list();

            List<ClsPrp_ComplaintFormMN_Addmore_Complainant> complainantList = aa.FormMN_Complainant;

            return Json(new { data = complainantList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_AdditionalComplaintFormN(Int64 inCompN_IndexID, Int64 inCompN_ID, Int64 inProfile_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormN_Addmore_Complainant sdb = new ClsMethod_ComplaintFormN_Addmore_Complainant();
                if (sdb.Delete_FormN_Complainant(inCompN_ID, inCompN_IndexID, inProfile_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            //return Json(new { data = status }, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = new { status = status, JsonRequestBehavior.AllowGet } };
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        //Add more respondent details
        [HttpGet]
        public ActionResult RegAdditionalRespondentFormN()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormN_id = 11; // Blank or New Entry Data
            string TypeFormN = "FormTypeN";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;
            Int32 retAbsoluteIsDraft = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormN_Addmore_Respondent sdb = new ClsMethod_ComplaintFormN_Addmore_Respondent();

            aa.FormMN_Respondent = sdb.Display_RespondentFormN_Detail(ComplainantProfile_id, ComplainantFormN_id, TypeFormN, UID, IsTempTable);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            if (aa.FormMN_Respondent.Count >= 1)
            {
                foreach (var item in aa.FormMN_Respondent)
                {
                    aa.AdditionRespondent_IndexID = item.AdditionRespondent_IndexID;
                    aa.AdditionRespondent_ID = item.AdditionRespondent_ID;
                    aa.AdditionRespondent_RelatedComplaint_ID = item.AdditionRespondent_RelatedComplaint_ID;
                    aa.AdditionRespondent_RelatedComplaint_Code = item.AdditionRespondent_RelatedComplaint_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_MN = item.ComplaintType_MN;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    aa.IsTempTable = item.IsTempTable;

                    if (item.IsDraft == 0 || item.IsDraft == 4)
                    {
                        retAbsoluteIsDraft = item.IsDraft;
                    }
                }
                aa.IsDraft = retAbsoluteIsDraft;
            }
            else
            {
                ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
                ClsMethod_ComplaintFormN_Registration objFormAppN = new ClsMethod_ComplaintFormN_Registration();

                objflagstep.ComplaintFormNstepFlag = objFormAppN.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);

                if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
                {
                    foreach (var item in objflagstep.ComplaintFormNstepFlag)
                    {
                        objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                        objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                        objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                        objflagstep.Profile_ID = item.Profile_ID;
                        objflagstep.User_ID = item.User_ID;
                        objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                        objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                        objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                        objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                        objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                        objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                        objflagstep.IsActive = item.IsActive;
                        objflagstep.IsDraft = item.IsDraft;
                        objflagstep.IsLock = item.IsLock;
                        objflagstep.IsPublicView = item.IsPublicView;
                        objflagstep.CreatedBy = item.CreatedBy;
                        objflagstep.CreatedOn = item.CreatedOn;
                        objflagstep.ModifyBy = item.ModifyBy;
                        objflagstep.ModifyOn = item.ModifyOn;
                    }

                    if (objflagstep.IsVerificationComplete == 1)
                    {
                        if (objflagstep.IsDraft == 1 || objflagstep.IsDraft == 5 || objflagstep.IsDraft == 6)
                        {
                            if (objflagstep.IsLock != 1)
                            {
                                aa.AdditionRespondent_IndexID = 0;
                                aa.AdditionRespondent_ID = 0;
                                aa.IsActive = 0;
                                aa.IsDraft = 0;
                                aa.IsLock = 0;
                            }
                            else
                            {
                                aa.AdditionRespondent_IndexID = 0;
                                aa.AdditionRespondent_ID = 0;
                                aa.IsActive = 1;
                                aa.IsDraft = 1;
                                aa.IsLock = 1;
                            }
                        }
                    }

                }
            }

            return View("RegAdditionalRespondentFormN", aa);
        }
        
        [HttpPost]
        public ActionResult SaveRespondentFormNDetail(ClsPrp_ComplaintFormMN_Addmore_Respondent[] order)
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormN_id = 11; // Blank or New Entry Data
            string TypeFormN = "FormTypeN";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            bool status = false;
            Int64? chkappid = null;
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormN_Addmore_Respondent sdb = new ClsMethod_ComplaintFormN_Addmore_Respondent();
            List<ClsPrp_ComplaintFormMN_Addmore_Respondent> Respondent = new List<ClsPrp_ComplaintFormMN_Addmore_Respondent>();

            if (ModelState.IsValid)
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        ClsPrp_ComplaintFormMN_Addmore_Respondent O = new ClsPrp_ComplaintFormMN_Addmore_Respondent();

                        O.AdditionRespondent_IndexID = 0;
                        O.AdditionRespondent_ID = 0;
                        O.AdditionRespondent_RelatedComplaint_ID = ComplainantFormN_id;
                        O.AdditionRespondent_RelatedComplaint_Code = ComplainantFormN_id.ToString();
                        O.Profile_ID = ComplainantProfile_id;
                        O.User_ID = UID;
                        O.ComplaintType_MN = TypeFormN;
                        O.Repondant_AadhaarNumber = 0; // Not Applicable for Respondent

                        O.Name_of_Respondant_or_Applicant = item.Name_of_Respondant_or_Applicant;
                        O.EmailAddress = item.EmailAddress;
                        O.MobileNumber = item.MobileNumber;
                        O.LandlineNumber = item.LandlineNumber;

                        O.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                        O.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                        O.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                        O.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                        O.RegOffice_AddressPIN = item.RegOffice_AddressPIN;

                        O.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;

                        O.Service_AddressLine1 = item.Service_AddressLine1;
                        O.Service_AddressLine2 = item.Service_AddressLine2;
                        O.Service_AddressStateCode = item.Service_AddressStateCode;
                        O.Service_AddressDistrictCode = item.Service_AddressDistrictCode;
                        O.Service_AddressPIN = item.Service_AddressPIN;

                        O.Remarks_IfAny = "";
                        O.A_column = "";
                        O.B_column = "";
                        O.C_column = "";

                        O.IsActive = 1;
                        O.IsDraft = 0;
                        O.IsLock = 0;
                        O.IsPublicView = 0;
                        O.IsTempTable = IsTempTable;

                        chkappid = sdb.Add_FormN_Respondent(O, UID, UserNam);
                    }
                }

                if (chkappid == null)
                    status = false;
                else
                    status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult GetRespondentFormNData()
        {
            Int64 ComplainantProfile_id = 0;
            Int64 ComplainantFormN_id = 11; // Blank or New Entry Data
            string TypeFormN = "FormTypeN";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    IsTempTable = 0;
                }
            }

            ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormN_Addmore_Respondent sdb = new ClsMethod_ComplaintFormN_Addmore_Respondent();

            aa.FormMN_Respondent = sdb.Display_RespondentFormN_Detail(ComplainantProfile_id, ComplainantFormN_id, TypeFormN, UID, IsTempTable);

            List<ClsPrp_ComplaintFormMN_Addmore_Respondent> respondentList = aa.FormMN_Respondent;

            return Json(new { data = respondentList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_AdditionalRespondentFormN(Int64 inRespN_IndexID, Int64 inRespN_ID, Int64 inProfile_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormN_Addmore_Respondent sdb = new ClsMethod_ComplaintFormN_Addmore_Respondent();
                if (sdb.Delete_FormN_Respondent(inRespN_ID, inRespN_IndexID, inProfile_ID))
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

        //Add facts of the case PDF files
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FactsCase_FormN_DocumentUpload(HttpPostedFileBase uploadedFile, ClsPrp_ComplaintFormN_Registration smodel)
        {
            //Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0)
            if (Request.Files.Count > 0 && (uploadedFile.ContentLength != 0))
            {
                if (smodel.FactsCase_NumberOfPages > 0)
                {
                    if (smodel.FactsCase_NumberOfPages > 0)//Mandatory Validation//ModelState.IsValid)//
                    {
                        Clsprp_Master_Complaint_Documents clsprp = new Clsprp_Master_Complaint_Documents();
                        ClsMethod_Master_Complaint_Documents objdoc = new ClsMethod_Master_Complaint_Documents();
                        Clsprp_ComplaintFormN_FactsCaseDocument clsprpPrmDoc = new Clsprp_ComplaintFormN_FactsCaseDocument();
                        ClsMethod_ComplaintFormN_Registration objPromoterDoc = new ClsMethod_ComplaintFormN_Registration();

                        Int32 IndexId = 104;// (with ref to master table data)                   I

                        Int64 ComplainantFormN_id = 0;
                        Int64 ComplainantProfile_id = 0;
                        if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                        {
                            //ProfileID_ID
                            if (Session["ApplicationId"].ToString() != "0")
                            {
                                ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                            }
                            //Complaint_ID
                            if (Session["ComplaintFormN_ID"] != null)
                            {
                                if (Session["ComplaintFormN_ID"].ToString() != "0")
                                {
                                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                                }
                            }
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Session Expired! Upload Failed",
                                statusCode = 102,
                                status = "Session Expired! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }

                        #region Read Master Data By Document Type
                        clsprp.prpMasterDocs = objdoc.Display_Master_Complaint_DocumentsByComplaintFormID(ComplainantFormN_id);

                        Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_ComplaintFormN_FactsOfTheCase_Documents_ByDocCodeInfo_ComplaintID_ProfileID(ComplainantFormN_id, ComplainantProfile_id, IndexId));

                        foreach (var item in clsprp.prpMasterDocs)
                        {
                            if (item.ComplaintDocMaster_InfoCode == IndexId)
                            {
                                clsprp.ComplaintDocMaster_IndexID = item.ComplaintDocMaster_IndexID;
                                clsprp.ComplaintDocMaster_InfoCode = item.ComplaintDocMaster_InfoCode;
                                clsprp.ComplaintDocMaster_InfoName = item.ComplaintDocMaster_InfoName;
                                clsprp.ComplaintDoc_SetFileSize = item.ComplaintDoc_SetFileSize;
                                clsprp.ComplaintDoc_SetFileFormat = item.ComplaintDoc_SetFileFormat;
                                clsprp.ComplaintDoc_SetFilePath = item.ComplaintDoc_SetFilePath;
                                clsprp.ComplaintDoc_ValidCode = item.ComplaintDoc_ValidCode;
                                clsprp.ComplaintDoc_ValidSubCode = item.ComplaintDoc_ValidSubCode;
                                clsprp.ComplaintDoc_ValidTinySubCode = item.ComplaintDoc_ValidTinySubCode;
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
                        string masterFactsCaseDoc_SetFilePath = "rwFormNFactCaseDoc";
                        bool IsValidFileType = false;
                        #endregion

                        //Bad Request - No Doc
                        if (Request.Files.Count > 0)
                        {
                            var PhotoIdentityDocument = uploadedFile;// Request.Files[0];

                            //Bad Request - No Doc OR No Size
                            if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                            {
                                #region SaveFile Path Creation
                                if (clsprp.ComplaintDoc_SetFilePath.ToString() != string.Empty || clsprp.ComplaintDoc_SetFilePath.ToString() != null)
                                {
                                    masterFactsCaseDoc_SetFilePath = clsprp.ComplaintDoc_SetFilePath.ToString();
                                }
                                pathindb = masterFactsCaseDoc_SetFilePath + "\\" + Convert.ToString(ComplainantProfile_id) + "\\";
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
                                masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ComplaintDoc_SetFileFormat);
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
                                    if (IsValidFileType)
                                    {
                                        if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                        {
                                            byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                            if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                            {
                                                savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ComplaintDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                                var pathsavefile = Path.Combine(path, savefileName);
                                                PhotoIdentityDocument.SaveAs(pathsavefile);

                                                var pathsavedb = Path.Combine(pathindb, savefileName);

                                                Int64 inFormN_ID = ComplainantFormN_id;
                                                Int64 inFormN_ProfileID = ComplainantProfile_id;
                                                string inFormDoc_FilePath = pathsavedb;
                                                string inFormDoc_FileName = savefileName;
                                                string inFormDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                                string inFormDoc_FileFormat = extensionPhotoIdentityDocument;
                                                Int32 inFormDoc_IsGroup = Convert.ToInt32(clsprp.IsGroup);

                                                bool varRet = SaveComplaintFormN_FactsCase_Documents(smodel, inFormN_ID, inFormN_ProfileID, inFormDoc_FilePath, inFormDoc_FileName, inFormDoc_FileSize, inFormDoc_FileFormat, inFormDoc_IsGroup);

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
                                                varSetFileSize = Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize);

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
                                                status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
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
                        status = "Number of Pages(s) required! Upload Failed",
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

        private bool SaveComplaintFormN_FactsCase_Documents(ClsPrp_ComplaintFormN_Registration smodel, Int64 z_ComplaintFormN_ID, Int64 z_ComplaintProfile_ID, String z_ComplaintFormDoc_FilePath, String z_ComplaintFormDoc_FileName, String z_ComplaintFormDoc_FileSize, String z_ComplaintFormDoc_FileFormat, Int32 z_ComplaintFormDoc_IsGroup)
        {
            Int64 FormMN_ID = 0;
            Int64 FormMN_ProfileID = 0;
            FormMN_ID = z_ComplaintFormN_ID;
            FormMN_ProfileID = z_ComplaintProfile_ID;
            string FormMNDoc_FilePath = String.IsNullOrEmpty(z_ComplaintFormDoc_FilePath) ? string.Empty : z_ComplaintFormDoc_FilePath;
            string FormMNDoc_FileName = String.IsNullOrEmpty(z_ComplaintFormDoc_FileName) ? string.Empty : z_ComplaintFormDoc_FileName;
            string FormMNDoc_FileSize = String.IsNullOrEmpty(z_ComplaintFormDoc_FileSize) ? string.Empty : z_ComplaintFormDoc_FileSize;
            string FormMNDoc_FileFormat = String.IsNullOrEmpty(z_ComplaintFormDoc_FileFormat) ? string.Empty : z_ComplaintFormDoc_FileFormat;
            Int32 FormMNDoc_IsGroup = z_ComplaintFormDoc_IsGroup;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            bool varRET = false;

            try
            {
                Clsprp_ComplaintFormN_FactsCaseDocument objFC = new Clsprp_ComplaintFormN_FactsCaseDocument();
                ClsMethod_ComplaintFormN_Registration savedb = new ClsMethod_ComplaintFormN_Registration();

                if (smodel.FactsCase_OptionsYesNo == "factscasePDF")
                {
                    objFC.FactsCaseDocument_IndexID = 0;
                    objFC.FactsCaseDocument_ID = 0;
                    objFC.ComplainantApplicant_RelatedComplaintN_ID = FormMN_ID;
                    objFC.ComplainantApplicant_RelatedComplaintN_Code = Convert.ToString(FormMN_ID);
                    objFC.Profile_ID = FormMN_ProfileID;
                    objFC.User_ID = UID;

                    objFC.ComplaintType_MN = "FormTypeN";
                    objFC.FactsCaseDoc_InfoCode = "104";// (with ref to master table data) 
                    objFC.FactsCaseDoc_InfoName = "Facts of the Case";
                    objFC.FactsCaseDoc_ReferenceNumber = string.Empty;
                    objFC.FactsCaseDoc_IssueDate = DateTime.Now;

                    objFC.FactsCaseDoc_FileSize = FormMNDoc_FileSize;
                    objFC.FactsCaseDoc_FileFormat = FormMNDoc_FileFormat;
                    objFC.FactsCaseDoc_FilePath = FormMNDoc_FilePath;
                    objFC.FactsCaseDoc_FileName = FormMNDoc_FileName;
                    objFC.FactsCaseDoc_IsGroup = FormMNDoc_IsGroup;

                    objFC.Doc_SerialNumber = smodel.FactsCase_OptionsYesNo;
                    objFC.Doc_NumberOfPages = smodel.FactsCase_NumberOfPages;
                    objFC.Doc_PageStartNumber = 0;
                    objFC.Doc_PageEndNumber = 0;

                    objFC.Remarks_IfAny = string.Empty;
                    objFC.A_column = string.Empty;
                    objFC.B_column = string.Empty;
                    objFC.C_column = string.Empty;
                    objFC.D_column = string.Empty;

                    objFC.IsActive = 1;
                    objFC.IsDraft = 0;
                    objFC.IsLock = 0;
                    objFC.IsPublicView = 0;
                    objFC.IsTempTable = 1;

                    objFC.CreatedBy = userName;
                    objFC.CreatedOn = DateTime.Now;
                    objFC.ModifyBy = userName;
                    objFC.ModifyOn = DateTime.Now;
                }

                if (savedb.Add_ComplaintFormN_FactsOfTheCase_Documents_ByProfileID(objFC, FormMN_ID, FormMNDoc_FilePath, FormMNDoc_FileName, FormMNDoc_FileSize, FormMNDoc_FileFormat, FormMNDoc_IsGroup, FormMN_ProfileID, UID, userName))
                {
                    varRET = true;
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }

        [HttpGet]
        public ActionResult ComplaintFormNFactsCaseFileDetail(Int64 factscaseID, Int64 profileID, Int64 complaintNID)
        {
            Int64 Factscase_ID = 0;
            Int64 Profile_ID = 0;
            Int64 ComplaintN_ID = 0;
            Int32 FactsCase_Flag = 0;
            string userName = User.Identity.Name;

            if (factscaseID != 0)
            {
                Factscase_ID = Convert.ToInt64(factscaseID);
            }
            if (profileID != 0)
            {
                Profile_ID = Convert.ToInt64(profileID);
            }
            if (complaintNID != 0)
            {
                ComplaintN_ID = Convert.ToInt64(complaintNID);
            }

            Clsprp_ComplaintFormN_FactsCaseDocument aa = new Clsprp_ComplaintFormN_FactsCaseDocument();
            ClsMethod_ComplaintFormN_Registration sdb = new ClsMethod_ComplaintFormN_Registration();

            aa.prpFormN_FactsCase_Docs = sdb.Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByID(Factscase_ID, ComplaintN_ID, Profile_ID, FactsCase_Flag, userName);
            foreach (var item in aa.prpFormN_FactsCase_Docs)
            {
                aa.FactsCaseDocument_IndexID = item.FactsCaseDocument_IndexID;
                aa.FactsCaseDocument_ID = item.FactsCaseDocument_ID;
                aa.ComplainantApplicant_RelatedComplaintN_ID = item.ComplainantApplicant_RelatedComplaintN_ID;
                aa.ComplainantApplicant_RelatedComplaintN_Code = item.ComplainantApplicant_RelatedComplaintN_Code;
                aa.Profile_ID = item.Profile_ID;
                aa.User_ID = item.User_ID;
                aa.ComplaintType_MN = item.ComplaintType_MN;

                aa.FactsCaseDoc_InfoCode = item.FactsCaseDoc_InfoCode;
                aa.FactsCaseDoc_InfoName = item.FactsCaseDoc_InfoName;
                aa.FactsCaseDoc_ReferenceNumber = item.FactsCaseDoc_ReferenceNumber;
                aa.FactsCaseDoc_IssueDate = item.FactsCaseDoc_IssueDate;
                aa.FactsCaseDoc_FileSize = item.FactsCaseDoc_FileSize;
                aa.FactsCaseDoc_FileFormat = item.FactsCaseDoc_FileFormat;
                aa.FactsCaseDoc_FilePath = item.FactsCaseDoc_FilePath;
                aa.FactsCaseDoc_FileName = item.FactsCaseDoc_FileName;
                aa.FactsCaseDoc_IsGroup = item.FactsCaseDoc_IsGroup;
                aa.Doc_SerialNumber = item.Doc_SerialNumber;
                aa.Doc_NumberOfPages = item.Doc_NumberOfPages;
                aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;
                aa.IsTempTable = item.IsTempTable;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            return View("ComplaintFormNFactsCaseFileDetail", aa);
        }

        [HttpGet]
        public ActionResult ComplaintFormNFactsCaseCurrentFileDetail(Int64 factscaseID, Int64 profileID, Int64 complaintNID)
        {
            Int64 Factscase_ID = 0;
            Int64 Profile_ID = 0;
            Int64 ComplaintN_ID = 0;
            Int32 FactsCase_Flag = 55;
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Profile_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["ComplaintFormN_ID"] != null)
                {
                    if (Session["ComplaintFormN_ID"].ToString() != "0")
                    {
                        ComplaintN_ID = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    }
                }
            }
            else
            {
                Factscase_ID = 0;
                Profile_ID = 0;
                ComplaintN_ID = 0;
            }

            Clsprp_ComplaintFormN_FactsCaseDocument aa = new Clsprp_ComplaintFormN_FactsCaseDocument();
            ClsMethod_ComplaintFormN_Registration sdb = new ClsMethod_ComplaintFormN_Registration();

            aa.prpFormN_FactsCase_Docs = sdb.Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByID(Factscase_ID, ComplaintN_ID, Profile_ID, FactsCase_Flag, userName);
            foreach (var item in aa.prpFormN_FactsCase_Docs)
            {
                aa.FactsCaseDocument_IndexID = item.FactsCaseDocument_IndexID;
                aa.FactsCaseDocument_ID = item.FactsCaseDocument_ID;
                aa.ComplainantApplicant_RelatedComplaintN_ID = item.ComplainantApplicant_RelatedComplaintN_ID;
                aa.ComplainantApplicant_RelatedComplaintN_Code = item.ComplainantApplicant_RelatedComplaintN_Code;
                aa.Profile_ID = item.Profile_ID;
                aa.User_ID = item.User_ID;
                aa.ComplaintType_MN = item.ComplaintType_MN;

                aa.FactsCaseDoc_InfoCode = item.FactsCaseDoc_InfoCode;
                aa.FactsCaseDoc_InfoName = item.FactsCaseDoc_InfoName;
                aa.FactsCaseDoc_ReferenceNumber = item.FactsCaseDoc_ReferenceNumber;
                aa.FactsCaseDoc_IssueDate = item.FactsCaseDoc_IssueDate;
                aa.FactsCaseDoc_FileSize = item.FactsCaseDoc_FileSize;
                aa.FactsCaseDoc_FileFormat = item.FactsCaseDoc_FileFormat;
                aa.FactsCaseDoc_FilePath = item.FactsCaseDoc_FilePath;
                aa.FactsCaseDoc_FileName = item.FactsCaseDoc_FileName;
                aa.FactsCaseDoc_IsGroup = item.FactsCaseDoc_IsGroup;
                aa.Doc_SerialNumber = item.Doc_SerialNumber;
                aa.Doc_NumberOfPages = item.Doc_NumberOfPages;
                aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;
                aa.IsTempTable = item.IsTempTable;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            return View("ComplaintFormNFactsCaseFileDetail", aa);
        }

        [HttpGet]
        public JsonResult Delete_FactsCase_FormN_Document(Int64 inFactscase_IndexID, Int64 inFactscase_ID, Int64 inProfile_ID, Int64 inComplaintN_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormN_Registration sdb = new ClsMethod_ComplaintFormN_Registration();
                if (sdb.Delete_FormN_FactsOfTheCase_Document_ByID(inFactscase_IndexID, inFactscase_ID, inProfile_ID, inComplaintN_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            //return Json(new
            //{
            //    //Data = "Bad Request! Upload Failed",
            //    statusCode = 105,
            //    status = "Bad Request! Upload Failed",
            //    remarks = "Not Saved! Upload Failed "
            //}, JsonRequestBehavior.AllowGet);

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ContentResult Download_FactsCase_FormN_File(Int64 factscaseID, string filename, string filelink)
        {
            string base64 = string.Empty;
            try
            {
                //Set the File Folder Path.
                string path = Server.MapPath("~/" + filelink);

                //Read the File as Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);// + fileName);

                //Convert File to Base64 string and send to Client.
                base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return Content(base64);
        }

        [HttpGet]
        public ContentResult Download_FactsCase_FormN_CurrentFile(Int64 factscaseID, string filename, string filelink)
        {
            Int64 Factscase_ID = 0;
            Int64 Profile_ID = 0;
            Int64 ComplaintN_ID = 0;
            Int32 FactsCase_Flag = 55;
            string currentfilelink = string.Empty;
            string userName = User.Identity.Name;
            string base64 = string.Empty;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Profile_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["ComplaintFormN_ID"] != null)
                {
                    if (Session["ComplaintFormN_ID"].ToString() != "0")
                    {
                        ComplaintN_ID = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                    }
                }
            }
            else
            {
                Factscase_ID = 0;
                Profile_ID = 0;
                ComplaintN_ID = 0;
            }

            Clsprp_ComplaintFormN_FactsCaseDocument aa = new Clsprp_ComplaintFormN_FactsCaseDocument();
            ClsMethod_ComplaintFormN_Registration sdb = new ClsMethod_ComplaintFormN_Registration();

            try
            {
                aa.prpFormN_FactsCase_Docs = sdb.Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByID(Factscase_ID, ComplaintN_ID, Profile_ID, FactsCase_Flag, userName);
                foreach (var item in aa.prpFormN_FactsCase_Docs)
                {
                    aa.FactsCaseDocument_IndexID = item.FactsCaseDocument_IndexID;
                    aa.FactsCaseDocument_ID = item.FactsCaseDocument_ID;
                    aa.ComplainantApplicant_RelatedComplaintN_ID = item.ComplainantApplicant_RelatedComplaintN_ID;
                    aa.ComplainantApplicant_RelatedComplaintN_Code = item.ComplainantApplicant_RelatedComplaintN_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_MN = item.ComplaintType_MN;

                    aa.FactsCaseDoc_InfoCode = item.FactsCaseDoc_InfoCode;
                    aa.FactsCaseDoc_InfoName = item.FactsCaseDoc_InfoName;
                    aa.FactsCaseDoc_ReferenceNumber = item.FactsCaseDoc_ReferenceNumber;
                    aa.FactsCaseDoc_IssueDate = item.FactsCaseDoc_IssueDate;
                    aa.FactsCaseDoc_FileSize = item.FactsCaseDoc_FileSize;
                    aa.FactsCaseDoc_FileFormat = item.FactsCaseDoc_FileFormat;
                    aa.FactsCaseDoc_FilePath = item.FactsCaseDoc_FilePath;
                    aa.FactsCaseDoc_FileName = item.FactsCaseDoc_FileName;
                    aa.FactsCaseDoc_IsGroup = item.FactsCaseDoc_IsGroup;
                    aa.Doc_SerialNumber = item.Doc_SerialNumber;
                    aa.Doc_NumberOfPages = item.Doc_NumberOfPages;
                    aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                    aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                    aa.Remarks_IfAny = item.Remarks_IfAny;
                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;
                    aa.D_column = item.D_column;
                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    aa.IsTempTable = item.IsTempTable;
                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }

                currentfilelink = aa.FactsCaseDoc_FilePath.ToString();

                //Set the File Folder Path.
                string path = Server.MapPath("~/" + currentfilelink);

                //Read the File as Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);// + fileName);

                //Convert File to Base64 string and send to Client.
                base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return Content(base64);
        }

        #endregion

        #region Link Movement Form-N
        public string Get_ComplaintFormN_FlagStep()
        {
            string retSTR = string.Empty;
            Int64 ComplainantFormN_id = 0;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();

            objflagstep.ComplaintFormNstepFlag = objFormAppM.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);
            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormNstepFlag)
                {
                    objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                    objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                    objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0 || objflagstep.IsDraft == 4)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; //
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }

        public string Get_ComplaintFormN_FlagStep(Int64 mComplaintFormN_ID)
        {
            string retSTR = string.Empty;
            Int64 ComplainantFormN_id = mComplaintFormN_ID;

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();

            objflagstep.ComplaintFormNstepFlag = objFormAppM.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);
            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormNstepFlag)
                {
                    objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                    objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                    objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0 || objflagstep.IsDraft == 4)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; //
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }
        #endregion

        #region Step-II Form-N Doc

        [HttpGet]
        public ActionResult RegComplaintEncldocN()
        {
            Int64 ComplainantFormN_id = 0;
            Int32 retAbsoluteIsDraft = 1;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            ClsMethod_ComplaintN_Documents sdb = new ClsMethod_ComplaintN_Documents();
            Clsprp_ComplaintFormN_Documents aa = new Clsprp_ComplaintFormN_Documents();

            aa.ComplaintDoc_IssueDate = DateTime.Now;

            aa.prpFormM_Docs = sdb.Display_ComplaintFormN_Documents_ByComplaintFormN_ID(ComplainantFormN_id);
            if (aa.prpFormM_Docs.Count > 0)
            {
                foreach (var item in aa.prpFormM_Docs)
                {
                    aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
                    aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
                    aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                    aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
                    ////aa.Profile_ID = item.Profile_ID;
                    ////aa.User_ID = item.User_ID;
                    ////aa.ComplaintType_MN = item.ComplaintType_MN;
                    ////aa.ComplaintDoc_InfoCode = item.ComplaintDoc_InfoCode;
                    ////aa.ComplaintDoc_InfoName = item.ComplaintDoc_InfoName;
                    ////aa.ComplaintDoc_ReferenceNumber = item.ComplaintDoc_ReferenceNumber;
                    ////aa.ComplaintDoc_IssueDate = item.ComplaintDoc_IssueDate;

                    ////aa.ComplaintDoc_FileSize = item.ComplaintDoc_FileSize;
                    ////aa.ComplaintDoc_FileFormat = item.ComplaintDoc_FileFormat;
                    ////aa.ComplaintDoc_FilePath = item.ComplaintDoc_FilePath;
                    ////aa.ComplaintDoc_FileName = item.ComplaintDoc_FileName;
                    ////aa.ComplaintDoc_IsGroup = item.ComplaintDoc_IsGroup;
                    ////aa.Doc_SerialNumber = item.Doc_SerialNumber;
                    ////aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
                    ////aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

                    ////aa.Remarks_IfAny = item.Remarks_IfAny;
                    ////aa.A_column = item.A_column;
                    ////aa.B_column = item.B_column;
                    ////aa.C_column = item.C_column;
                    ////aa.D_column = item.D_column;
                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;
                    ////aa.CreatedBy = item.CreatedBy;
                    ////aa.CreatedOn = item.CreatedOn;
                    ////aa.ModifyBy = item.ModifyBy;
                    ////aa.ModifyOn = item.ModifyOn;
                    if (item.IsDraft == 0 || item.IsDraft == 4)
                    {
                        retAbsoluteIsDraft = item.IsDraft;
                    }
                }
                aa.IsDraft = retAbsoluteIsDraft;
            }            
            return View("RegComplaintEncldocN", aa);
        }

        [HttpPost]
        public ActionResult RegComplaintEncldocFormN()
        {
            Int64 ComplainantFormN_id = 0;
            Int32 retAbsoluteIsDraft = 1;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            ClsMethod_ComplaintN_Documents sdb = new ClsMethod_ComplaintN_Documents();
            Clsprp_ComplaintFormN_Documents aa = new Clsprp_ComplaintFormN_Documents();
            string userName = User.Identity.Name;

            Int64 varGetChk = sdb.Update_Check_ComplaintFormN_Documents(ComplainantFormN_id, userName);
            if (varGetChk == 100)
            {
                //Already OR Updated (IsDocComplete = true)
                return RedirectToAction("RequestPaymentN", "ComplaintPayment");
            }
            else if (varGetChk == 200 || varGetChk == 300)
            {
                // Pending (IsDocComplete = true)
                aa.ComplaintDoc_IssueDate = DateTime.Now;

                aa.prpFormM_Docs = sdb.Display_ComplaintFormN_Documents_ByComplaintFormN_ID(ComplainantFormN_id);
                if (aa.prpFormM_Docs.Count > 0)
                {
                    foreach (var item in aa.prpFormM_Docs)
                    {
                        aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
                        aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
                        aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                        aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;

                        aa.IsActive = item.IsActive;
                        aa.IsDraft = item.IsDraft;
                        aa.IsLock = item.IsLock;
                        aa.IsPublicView = item.IsPublicView;

                        if (item.IsDraft == 0 || item.IsDraft == 4)
                        {
                            retAbsoluteIsDraft = item.IsDraft;
                        }
                    }
                    aa.IsDraft = retAbsoluteIsDraft;
                }
                TempData["ComplaintFormNvalidDocName"] = "";
                if (varGetChk == 200)
                {
                    TempData["ComplaintFormNvalidDocName"] = "Incomplete Complaint Form-N Documents, Please upload Complaint Form-N Documents First.";
                }
                if (varGetChk == 300)
                {
                    TempData["ComplaintFormNvalidDocName"] = "Incomplete Complaint Form-N Documents, For un-registered project, it is mandatory to upload any of following document(s) as (a.) CLU or License to develop Colony (Sepecify, Ref Number and Issuing Authority in Remarks), (b.) Regularization Certificate (In case of illegal/unauthorized colony) and (c.) Agreement to Sell/ Allotment Letter/ LOI.";
                }
                return View("RegComplaintEncldocN", aa);
            }
            return RedirectToAction("RegComplaintEncldocN");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ComplaintFormNDocumentFormUpload(HttpPostedFileBase uploadedFile, Clsprp_ComplaintFormN_Documents smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Complaint_Documents clsprp = new Clsprp_Master_Complaint_Documents();
                    ClsMethod_Master_Complaint_Documents objdoc = new ClsMethod_Master_Complaint_Documents();
                    Clsprp_ComplaintFormN_Documents clsprpPrmDoc = new Clsprp_ComplaintFormN_Documents();
                    ClsMethod_ComplaintN_Documents objPromoterDoc = new ClsMethod_ComplaintN_Documents();

                    Int32 IndexId = 102;// smodel.ProjectDoc_InfoCode; (with ref to master table data)                   I

                    Int64 ComplainantFormN_id = 0;
                    if (Session["ComplaintFormN_ID"] != null)
                    {
                        if (Session["ComplaintFormN_ID"].ToString() != "0")
                        {
                            ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                        }
                    }

                    #region Read Master Data By Document Type
                    clsprp.prpMasterDocs = objdoc.Display_Master_Complaint_DocumentsByComplaintFormID(ComplainantFormN_id);

                    Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_ComplaintFormN_Documents_ByDocCodeInfo_ComplaintFormN_ID(ComplainantFormN_id, IndexId));

                    foreach (var item in clsprp.prpMasterDocs)
                    {
                        if (item.ComplaintDocMaster_InfoCode == IndexId)
                        {
                            clsprp.ComplaintDocMaster_IndexID = item.ComplaintDocMaster_IndexID;
                            clsprp.ComplaintDocMaster_InfoCode = item.ComplaintDocMaster_InfoCode;
                            clsprp.ComplaintDocMaster_InfoName = item.ComplaintDocMaster_InfoName;
                            clsprp.ComplaintDoc_SetFileSize = item.ComplaintDoc_SetFileSize;
                            clsprp.ComplaintDoc_SetFileFormat = item.ComplaintDoc_SetFileFormat;
                            clsprp.ComplaintDoc_SetFilePath = item.ComplaintDoc_SetFilePath;
                            clsprp.ComplaintDoc_ValidCode = item.ComplaintDoc_ValidCode;
                            clsprp.ComplaintDoc_ValidSubCode = item.ComplaintDoc_ValidSubCode;
                            clsprp.ComplaintDoc_ValidTinySubCode = item.ComplaintDoc_ValidTinySubCode;
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
                    string masterPromoterDoc_SetFilePath = "readwriteFormNDoc";
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
                            if (clsprp.ComplaintDoc_SetFilePath.ToString() != string.Empty || clsprp.ComplaintDoc_SetFilePath.ToString() != null)
                            {
                                masterPromoterDoc_SetFilePath = clsprp.ComplaintDoc_SetFilePath.ToString();
                            }
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(ComplainantFormN_id) + "\\";
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
                            masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ComplaintDoc_SetFileFormat);
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
                                if (IsValidFileType)
                                {
                                    if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                    {
                                        byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                        if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize))
                                        {
                                            savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ComplaintDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                            var pathsavefile = Path.Combine(path, savefileName);
                                            PhotoIdentityDocument.SaveAs(pathsavefile);

                                            var pathsavedb = Path.Combine(pathindb, savefileName);

                                            Int64 inFormN_ID = ComplainantFormN_id;
                                            string inFormNDoc_FilePath = pathsavedb;
                                            string inFormNDoc_FileName = savefileName;
                                            string inFormNDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inFormNDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inFormNDoc_IsGroup = Convert.ToInt32(clsprp.IsGroup);

                                            bool varRet = SaveComplaintFormNDocuments(smodel, inFormN_ID, inFormNDoc_FilePath, inFormNDoc_FileName, inFormNDoc_FileSize, inFormNDoc_FileFormat, inFormNDoc_IsGroup);

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
                                            varSetFileSize = Convert.ToInt32(clsprp.ComplaintDoc_SetFileSize);

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
                                            status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
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

        private bool SaveComplaintFormNDocuments(Clsprp_ComplaintFormN_Documents smodel, Int64 z_ComplaintFormN_ID, String z_ComplaintFormDoc_FilePath, String z_ComplaintFormDoc_FileName, String z_ComplaintFormDoc_FileSize, String z_ComplaintFormDoc_FileFormat, Int32 z_ComplaintFormDoc_IsGroup)
        {
            Int64 FormMN_ID = 0;
            FormMN_ID = z_ComplaintFormN_ID;
            string FormMNDoc_FilePath = String.IsNullOrEmpty(z_ComplaintFormDoc_FilePath) ? string.Empty : z_ComplaintFormDoc_FilePath;
            string FormMNDoc_FileName = String.IsNullOrEmpty(z_ComplaintFormDoc_FileName) ? string.Empty : z_ComplaintFormDoc_FileName;
            string FormMNDoc_FileSize = String.IsNullOrEmpty(z_ComplaintFormDoc_FileSize) ? string.Empty : z_ComplaintFormDoc_FileSize;
            string FormMNDoc_FileFormat = String.IsNullOrEmpty(z_ComplaintFormDoc_FileFormat) ? string.Empty : z_ComplaintFormDoc_FileFormat;
            Int32 FormMNDoc_IsGroup = z_ComplaintFormDoc_IsGroup;
            Int64 ComplaintProfileID = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;


            bool varRET = false;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_ComplaintN_Documents savedb = new ClsMethod_ComplaintN_Documents();
                    if (savedb.Add_ComplaintFormN_Documents(smodel, FormMN_ID, FormMNDoc_FilePath, FormMNDoc_FileName, FormMNDoc_FileSize, FormMNDoc_FileFormat, FormMNDoc_IsGroup, ComplaintProfileID, UID, userName))
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

        //GET: Delete   
        public ActionResult Delete_ComplaintEncldocNDocument(Int64 inComplaintFormN_DocIndexID, Int64 inComplaintFormN_DocID, Int64 inComplaintFormN_ID)
        {
            try
            {
                ClsMethod_ComplaintN_Documents sdb = new ClsMethod_ComplaintN_Documents();
                if (sdb.Delete_ComplaintFormN_Document(inComplaintFormN_DocIndexID, inComplaintFormN_DocID, inComplaintFormN_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("RegComplaintEncldocN");
            }
            catch
            {
                return RedirectToAction("RegComplaintEncldocN");
            }
        }

        public JsonResult GetStatusRegdProjectandUnRegdProjectFromN(string ComplaintID, string FormType)
        {
            Int64 Id = 0;
            string IdType = string.Empty;
            if (ComplaintID != "")
            {
                if (ComplaintID != "0")
                {
                    Id = Convert.ToInt64(ComplaintID);
                }
                else
                {
                    if (Session["ComplaintFormN_ID"] != null)
                    {
                        if (Session["ComplaintFormN_ID"].ToString() != "0")
                        {
                            Id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                        }
                    }
                }
            }            
            if (FormType != "")
            {
                IdType = Convert.ToString(FormType);
            }

            ClsMethod_ComplaintN_Documents objdis = new ClsMethod_ComplaintN_Documents();
            var states = objdis.GetStatusRegdProjectandUnRegdProjectFromNsearchByID(Id, IdType);

            return Json(states, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Step-IV Form-N Verify
        [HttpGet]
        public ActionResult RegComplaintVerificationN()
        {
            Int64 ComplainantFormN_id = 0;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();

            objflagstep.ComplaintFormNstepFlag = objFormAppM.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);

            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormNstepFlag)
                {
                    objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                    objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                    objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }
            if (objflagstep.IsVerificationComplete == 0)
            {
                objflagstep.ComplaintVerificationDate = DateTime.Now;
            }
            TempData["ComplaintFormNRegDiaryNumber_Name"] = "";
            TempData["ComplaintFormNRegDiaryNumber_Validate"] = "";
            return View(objflagstep);
        }

        [HttpPost]
        public async Task<ActionResult> RegComplaintVerificationN(ClsPrp_ComplaintFormN_FlagStep smodel)
        {
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            ClsMethod_ComplaintFormN_Registration sdb = new ClsMethod_ComplaintFormN_Registration();

            Int64 ComplainantFormN_id = 0;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            Int64 ComplaintProfileID = 0;
            string ValidateComplaint = sdb.ValidateComplaintFormN_AgreeDetails(ComplainantFormN_id, ComplaintProfileID, UID, userName);
            if (ValidateComplaint == "FormN1001")
            {
                TempData["ComplaintFormNRegDiaryNumber_Name"] = "";
                TempData["ComplaintFormNRegDiaryNumber_Validate"] = "Invalid reference document(s) of un-registered Project! Please Submit Complaint Form-N (Step-I and II) First.";
            }
            else
            {
                TempData["ComplaintFormNRegDiaryNumber_Validate"] = "";
                // "0"; // 
                string Profile = sdb.UpdateComplaintFormN_AgreeDetails(smodel, ComplainantFormN_id, UID, userName);

                if (Profile == "0")
                {
                    TempData["ComplaintFormNRegDiaryNumber_Name"] = "Incomplete Complaint Form-N, Please Submit Complaint Form-N First.";
                }
                else if (Profile != null)
                {
                    TempData["ComplaintFormNRegDiaryNumber_Name"] = "Your Complaint Form-N successfully Submitted with diary number : " + Profile + " keep it for future reference, Thanks.";
                    await UserManager.SendEmailAsync(UID, "RERA, Punjab - Complaint Application (Form-N) Registration", "<b>Dear " + userName + "</b>,<br /><br /> Your Complaint Application with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />You are requested to log in to the RERA, Punjab web portal and check the complainant dashboard for further details, and actions required to be taken. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                }
                else
                {
                    TempData["ComplaintFormNRegDiaryNumber_Name"] = "Sorry, Your Complaint Form-N is pending";
                }
            }

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            objflagstep.ComplaintFormNstepFlag = sdb.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);

            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormNstepFlag)
                {
                    objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                    objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                    objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            return View("RegComplaintVerificationN", objflagstep);
        }
        #endregion

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

        public JsonResult GetSubdivisionByDistId(string Distid)
        {
            int Id = 0;
            if (Distid != "")
                Id = Convert.ToInt32(Distid);

            UserDetails aa = new UserDetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            var Subdiv = objdis.dropdownlist_diplaySubdiv(Id);

            return Json(Subdiv);
        }

        #endregion

        #region Complaint FORM User Manuals

        [HttpGet]
        public ActionResult ComplaintUserManuals()
        {
            return View();
        }

        #endregion

        #region Complaint MN Dashboard       

        [TrackActivity]
        [HttpGet]
        public ActionResult ComplaintDashboard()
        {
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }


            ClsMethod_ComplaintM_DiaryNumberDashbaord sdb = new ClsMethod_ComplaintM_DiaryNumberDashbaord();
            ClsPrp_ComplaintFormM_DiaryNumberDashbaord aa = new ClsPrp_ComplaintFormM_DiaryNumberDashbaord();

            aa.prpongoing = sdb.Display_ComplaintFormM_RegDiaryNumberByProfileID(ComplainantProfile_id, "");

            return View("ComplaintDashboard", aa);
        }

        [TrackActivity]
        [HttpGet]
        public ActionResult ComplaintNDashboard()
        {
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsMethod_ComplaintN_DiaryNumberDashbaord sdb = new ClsMethod_ComplaintN_DiaryNumberDashbaord();
            ClsPrp_ComplaintFormN_DiaryNumberDashbaord aa = new ClsPrp_ComplaintFormN_DiaryNumberDashbaord();

            aa.prpongoing = sdb.Display_ComplaintFormN_RegDiaryNumberByProfileID(ComplainantProfile_id, "");

            return View("ComplaintNDashboard", aa);
        }

        #endregion

        #region View Form-M Pre-Hearing Notice
        [HttpGet]
        public ActionResult ComplaintPreHearingNoticeM(Int64 FormM_Id, String FormM_diaryNumber)
        {
            ClsMethod_ComplaintFormM_PreHearingNotice sdb = new ClsMethod_ComplaintFormM_PreHearingNotice();
            ClsPrp_ComplaintFormM_PreHearingNotice aa = new ClsPrp_ComplaintFormM_PreHearingNotice();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            Int64 userFlag = 0;

            string mDiaryNumber = string.Empty;
            mDiaryNumber = FormM_diaryNumber;

            string ipSource = getSourceIPaddress();// Request.UserHostAddress;
            string hostnameSource = Request.UserHostName;
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            aa.prpongoingNotice = sdb.Display_ComplaintFormM_PreHearingNoticeByID(FormM_Id, userFlag, mDiaryNumber, userName, UID, hostnameSource, ipSource);
            foreach (var item in aa.prpongoingNotice)
            {
                aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                aa.ComplaintFormM_ID = item.ComplaintFormM_ID;
                aa.ComplaintFormM_Code = item.ComplaintFormM_Code;

                aa.Complainant_Name = (item.Complainant_Name).ToUpper();
                aa.ComplainantOther_Name = item.ComplainantOther_Name;
                aa.ComplainantOtherBrief_Name = item.ComplainantOtherBrief_Name;
                aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
                aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;

                aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
                aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
                aa.Respondent_Name = item.Respondent_Name;
                aa.RespondentOther_Name = item.RespondentOther_Name;
                aa.RespondentOtherBrief_Name = item.RespondentOtherBrief_Name;
                aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
                aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
                aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;

                aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
                aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
                aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
                aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
                aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

                aa.PreHearingDate_IndexID = item.PreHearingDate_IndexID;
                aa.PreHearingDate_ID = item.PreHearingDate_ID;
                aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
                aa.ComplaintType_MN = item.ComplaintType_MN;

                aa.PreHearingDate = item.PreHearingDate;
                aa.PreHearingTime = item.PreHearingTime;
                aa.PreHearingBench = item.PreHearingBench;
                aa.PreHearingFixedForCode = item.PreHearingFixedForCode;
                aa.PreHearingFixedForName = item.PreHearingFixedForName;
                aa.PreHearingStatus = item.PreHearingStatus;
                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.A_column = (item.A_column).ToUpper();
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.E_column = item.E_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;

                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);
            }
            return View("ComplaintPreHearingNoticeM", aa);
        }
        #endregion

        #region View Form-N Pre-Hearing Notice
        [HttpGet]
        public ActionResult ComplaintPreHearingNoticeN(Int64 FormN_Id, String FormN_diaryNumber)
        {
            ClsMethod_ComplaintFormN_PreHearingNotice sdb = new ClsMethod_ComplaintFormN_PreHearingNotice();
            ClsPrp_ComplaintFormN_PreHearingNotice aa = new ClsPrp_ComplaintFormN_PreHearingNotice();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            Int64 userFlag = 0;

            string nDiaryNumber = string.Empty;
            nDiaryNumber = FormN_diaryNumber;

            string ipSource = getSourceIPaddress();//Request.UserHostAddress;
            string hostnameSource = Request.UserHostName;
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            aa.prpongoingNotice = sdb.Display_ComplaintFormN_PreHearingNoticeByID(FormN_Id, userFlag, nDiaryNumber, userName, UID, hostnameSource, ipSource);
            foreach (var item in aa.prpongoingNotice)
            {
                aa.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                aa.ComplaintFormN_ID = item.ComplaintFormN_ID;
                aa.ComplaintFormN_Code = item.ComplaintFormN_Code;

                aa.Complainant_Name = (item.Complainant_Name).ToUpper(); ;
                aa.ComplainantOther_Name = item.ComplainantOther_Name;
                aa.ComplainantOtherBrief_Name = item.ComplainantOtherBrief_Name;
                aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
                aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;

                aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
                aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
                aa.Respondent_Name = item.Respondent_Name;
                aa.RespondentOther_Name = item.RespondentOther_Name;
                aa.RespondentOtherBrief_Name = item.RespondentOtherBrief_Name;
                aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
                aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
                aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;

                aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
                aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
                aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
                aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
                aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

                aa.PreHearingDate_IndexID = item.PreHearingDate_IndexID;
                aa.PreHearingDate_ID = item.PreHearingDate_ID;
                aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
                aa.ComplaintType_MN = item.ComplaintType_MN;

                aa.PreHearingDate = item.PreHearingDate;
                aa.PreHearingTime = item.PreHearingTime;
                aa.PreHearingBench = item.PreHearingBench;
                aa.PreHearingFixedForCode = item.PreHearingFixedForCode;
                aa.PreHearingFixedForName = item.PreHearingFixedForName;
                aa.PreHearingStatus = item.PreHearingStatus;
                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.A_column = (item.A_column).ToUpper();
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.D_column = item.D_column;
                aa.E_column = item.E_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;

                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);
            }
            return View("ComplaintPreHearingNoticeN", aa);
        }
        #endregion

        #region Extra Req Function
        /// GET: Checklist Not Accepted
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
        
        public JsonResult GetProjectRealestateAgentAllotteeNameFromMN(string ReraID, string ReraType)
        {
            string Id = string.Empty;
            string IdType = string.Empty;            
            if (ReraID != "")
            {
                Id = Convert.ToString(ReraID);
            }
            if (ReraType != "")
            {
                IdType = Convert.ToString(ReraType);                
            }

            ClsMethod_ComplaintForm_ProjectNameRERAnumber objdis = new ClsMethod_ComplaintForm_ProjectNameRERAnumber();
            var states = objdis.Get_ProjectAgentAllotteeNameByReraID(ReraID, IdType);

            return Json(states, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Add Advocates FORM_M

        public JsonResult GetStates()
        {
            ClsPrp_Master_Advocates aa = new ClsPrp_Master_Advocates();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();

            return Json(aa.stateMaster, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetComplainant(long complaintId)
        {
           // ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();
           // var complainantList = sdb.Display_ComplainantFormN_Detail(complaintId);

            ClsPrp_ComplaintProfile aa = new ClsPrp_ComplaintProfile();
            ClsMethod_ComplaintProfile sdb = new ClsMethod_ComplaintProfile();

            var ComplaintProfile = sdb.DisplayComplaintProfileDetail(complaintId);

            var result = ComplaintProfile.Select(x => new
            {
                id = x.ComplaintProfile_ID,
                name = x.Applicant_FirstName
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetRespondant(long complaintId)
        {
            ClsMethod_AuthDesk_FormMN_Addmore_Respondent sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Respondent();
            var complainantList = sdb.Display_RespondentFormN_Detail(complaintId);

            var result = complainantList.Select(x => new
            {
                id = x.AdditionRespondent_ID,
                name = x.Name_of_Respondant_or_Applicant
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDistrictByStateId(int stateId)
        {
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            var districts = objdis.dropdownlist_display1(stateId);

            return Json(districts, JsonRequestBehavior.AllowGet);
        }
        public void DebugSession()
        {
            foreach (string key in Session.Keys)
            {
                var value = Session[key];
                System.Diagnostics.Debug.WriteLine($"SESSION → {key} = {value}");
            }
        }

        [HttpGet]
        public ActionResult Display_Advocates()
        {
            var aa = new ClsPrp_Master_Advocates();
            var objdis = new ClsMethodDistrictMaster();
            var sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
            var type = "Complaint Form M";
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            //// Normalize incoming param
            //profileid = string.IsNullOrWhiteSpace(profileid) ? null : profileid.Trim();

            //// 1) If passed in querystring -> use & save to session
            //if (!string.IsNullOrEmpty(profileid))
            //{
            //    aa.Profile_ID = profileid;
            //    Session["Profile_Id"] = profileid;
            //}

            //// Ensure non-null (choose "" or "0" per your convention)
            //aa.Profile_ID = aa.Profile_ID ?? string.Empty;

            if (Session["zapFormMDiaryNumber"] != null)
            {
                aa.ComplaintFormMN_ID = Session["zapComplaintFormM_ID"] != null ? Convert.ToInt64(Session["zapComplaintFormM_ID"]) : 0L;
                aa.DiaryNumber = Session["zapFormMDiaryNumber"]?.ToString() ?? "";
                aa.Complaint_ID = Session["ComplaintRegDiaryNumber_ID"]?.ToString() ?? "";
                aa.Year = Session["ComplaintRegDiaryNumber_NameYear"]?.ToString() ?? "";
                aa.TypeOfComplaintMN = Session["ComplaintType_MN"]?.ToString() ?? "";

                aa.zapComplainantRERAnumber = Session["zapComplainantRERAnumber"]?.ToString() ?? "";
                aa.zapComplainantName = Session["zapFormMComplainantName"]?.ToString() ?? "";
                aa.zapRespondantName = Session["zapFormMRespondantName"]?.ToString() ?? "";
                aa.zapComplaintFormLastModifiedOn = Session["LastModifiedOn"] != null ? (DateTime?)Convert.ToDateTime(Session["LastModifiedOn"]) : null;
            }
            else
            {
                aa.zapRelated_Complaint_ID = 0;
                aa.zapRelated_RegDiaryNumber = "";
                aa.zapComplainantRERAnumber = "";
                aa.zapComplainantName = "";
                aa.zapRespondantName = "";
                aa.Profile_ID = Convert.ToString(ComplainantProfile_id);
            }

            // load lists and advocates
            aa.prpadvocates = sdb.Display_Master_Advocates(type);
            aa.stateMaster = objdis.State_list();
            aa.districtMaster = new List<ClsPrp_DistrictMaster>();
            DebugSession();

            TempData["submitvalue"] = "Save";
            TempData.Keep();

            return View("Display_AdvocatesComplainant", aa);
        }


        [HttpPost]
        public ActionResult Add_Advocates(ClsPrp_Master_Advocates smodel)
        {
            string user = User.Identity.Name;
            var objdis = new ClsMethodDistrictMaster();
            var sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
            var type = "Complaint Form M";
            var diarynumber = smodel.DiaryNumber;
            if(string.IsNullOrEmpty(smodel.TypeOfComplaintMN))
            {
                smodel.TypeOfComplaintMN = "Complaint Form M";
            }
            if (!ModelState.IsValid)
            {
                smodel.stateMaster = objdis.State_list();
                smodel.districtMaster = (smodel.State > 0) ? objdis.dropdownlist_display1(smodel.State) : new List<ClsPrp_DistrictMaster>();

                return View("Display_Advocates", smodel);
            }
            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if(ComplainantProfile_id!=0)
            {
                smodel.Profile_ID = Convert.ToString(ComplainantProfile_id);
            }
            if (TempData["submitvalue"].ToString() == "Update")
            {
                try
                {
                    int result = sdb.Update_Advocates(smodel, user);
                    if (result == -1)
                    {
                        TempData["MessageEmailAddress"] = "Record not found.";
                        TempData["MessageType"] = "error";

                        smodel.stateMaster = objdis.State_list();
                        smodel.districtMaster = (smodel.State > 0) ? objdis.dropdownlist_display1(smodel.State) : new List<ClsPrp_DistrictMaster>();
                        smodel.prpadvocates = sdb.Display_Master_Advocates(type, diarynumber);

                        return View("Display_Advocates", smodel);
                    }

                    if (result > 0)
                    {
                        TempData["MessageEmailAddress"] = "Details Updated Successfully!";
                        TempData["MessageType"] = "success";
                        return RedirectToAction("Display_Advocates");
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {
                    int result = sdb.Add_Advocates(smodel, user);

                    if (result == -1)
                    {
                        TempData["MessageEmailAddress"] = "This record already exists).";
                        TempData["MessageType"] = "error";

                        smodel.stateMaster = objdis.State_list();
                        smodel.districtMaster = (smodel.State > 0) ? objdis.dropdownlist_display1(smodel.State) : new List<ClsPrp_DistrictMaster>();
                        smodel.prpadvocates = sdb.Display_Master_Advocates(type, diarynumber);

                        return View("Display_Advocates", smodel);
                    }
                    if (result > 0)
                    {
                        TempData["MessageEmailAddress"] = "Details Added Successfully!";
                        TempData["MessageType"] = "success";
                        return RedirectToAction("Display_Advocates");
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return RedirectToAction("Display_Advocates");
        }

        public ActionResult Delete_AdvocateDetails(Int64 pIndexID, Int64 pKeyID)
        {
            ClsPrp_Master_Advocates aa = new ClsPrp_Master_Advocates();
            ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            try
            {
                if (sdb.Delete_AdminDesk_AdvocateDetailsByID(pIndexID, pKeyID))
                {
                    TempData["message"] = "Deleted Successfully";
                }
                // aa.stateMaster = objdis.State_list();
                // aa.districtMaster = new List<ClsPrp_DistrictMaster>();
                return RedirectToAction("Display_Advocates");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit_Advocates(Int64 pIndexID, Int64 pKeyID)
        {
            try
            {
                ClsPrp_Master_Advocates objprp = new ClsPrp_Master_Advocates();
                ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

                objprp.prpadvocates = sdb.Display_AdvocatesDetailsByID(pIndexID, pKeyID);
                foreach (var item in objprp.prpadvocates)
                {
                    objprp.Advocate_IndexID = item.Advocate_IndexID;
                    objprp.Advocate_ID = item.Advocate_ID;
                    objprp.DiaryNumber = item.DiaryNumber;
                    objprp.Complaint_ID = item.Complaint_ID;
                    objprp.Year = item.Year;

                    objprp.ComplaintFormMN_ID = item.ComplaintFormMN_ID;
                    objprp.TypeOfComplaintMN = item.TypeOfComplaintMN;
                    objprp.Profile_ID = item.Profile_ID;
                    objprp.CounselRepresentative = item.CounselRepresentative;

                    objprp.MobileNumber = item.MobileNumber;
                    objprp.Email = item.Email;
                    objprp.LandlineNumber = item.LandlineNumber;
                    objprp.Othermembers = item.Othermembers;
                    objprp.ExperienceYears = item.ExperienceYears;
                    objprp.AddressLine1 = item.AddressLine1;
                    objprp.AddressLine2 = item.AddressLine2;
                    objprp.District = item.District;
                    objprp.State = item.State;
                    objprp.Pincode = item.Pincode;

                    objprp.A_column = item.A_column;
                    objprp.B_column = item.B_column;
                    objprp.C_column = item.C_column;
                    objprp.D_column = item.D_column;

                    objprp.Dob = item.Dob;
                    objprp.BarRegNumber = item.BarRegNumber;
                    objprp.BarRegCode = item.BarRegCode;
                    objprp.BarRegState = item.BarRegState;
                    objprp.Location = item.Location;
                    objprp.PlaceofPractice = item.PlaceofPractice;
                    objprp.Gender = item.Gender;

                    objprp.RemarksIfAny = item.RemarksIfAny;

                    objprp.IsActive = item.IsActive;
                    objprp.IsLock = item.IsLock;
                    objprp.IsFlag = item.IsFlag;
                    objprp.IsPublicView = item.IsPublicView;
                    objprp.IsDraft = item.IsDraft;
                    objprp.IsBarverified = item.IsBarverified;


                    objprp.CreatedBy = item.CreatedBy;
                    objprp.CreatedOn = item.CreatedOn;
                    objprp.ModifyBy = item.ModifyBy;
                    objprp.ModifyOn = item.ModifyOn;
                }

                TempData.Remove("MessageEmailAddress");
                TempData.Remove("MessageType");
                objprp.stateMaster = objdis.State_list();
                objprp.districtMaster = new List<ClsPrp_DistrictMaster>();
                if (Session["zapFormMDiaryNumber"] != null)
                {
                    string FormMComplainantName = Session["zapFormMComplainantName"]?.ToString();
                    string FormMRespondantName = Session["zapFormMRespondantName"]?.ToString();
                    string ComplainantRERAnumber = Session["zapComplainantRERAnumber"]?.ToString();
                    DateTime? LastModifiedOn = Convert.ToDateTime(Session["LastModifiedOn"]);

                    objprp.zapComplainantRERAnumber = string.IsNullOrEmpty(ComplainantRERAnumber) ? "" : ComplainantRERAnumber;
                    objprp.zapComplainantName = string.IsNullOrEmpty(FormMComplainantName) ? "" : FormMComplainantName;
                    objprp.zapRespondantName = string.IsNullOrEmpty(FormMRespondantName) ? "" : FormMRespondantName;
                    objprp.zapComplaintFormLastModifiedOn = LastModifiedOn;
                }
                TempData["submitvalue"] = "Update";
                TempData.Keep();
                return View("Display_AdvocatesComplainant", objprp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region Mapping of advocates FORM-M
        [HttpGet]
        public ActionResult Map_Advocates()
        {
            try
            {
                string userRole = string.Empty;
                Int64 ComplainantProfile_id = 0;
                userRole = getUserRole();

                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                    }
                }

                ClsPrp_ComplaintAdvocateProfile aa = new ClsPrp_ComplaintAdvocateProfile();
                ClsMethod_ComplaintProfile sdb = new ClsMethod_ComplaintProfile();

                aa.ComplaintAdvocateProfile = sdb.DisplayComplaintProfileDetails(ComplainantProfile_id);

                //return View("Map_AdvocatesComplainant", aa.ComplaintProfile);
                return View("Map_AdvocatesComplainant");




                //aa.FormMN_Respondent = sdb.Display_RespondantFormM_DetailByID(ComplaintFormMID);

                //if (Session["zapFormMDiaryNumber"] != null)
                //{
                //    string FormMDiaryNumber = Session["zapFormMDiaryNumber"].ToString();
                //    string FormMComplainantName = Session["zapFormMComplainantName"].ToString();
                //    string FormMRespondantName = Session["zapFormMRespondantName"].ToString();
                //    string ComplainantRERAnumber = Session["zapComplainantRERAnumber"].ToString();
                //    Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
                //    DateTime? LastModifiedOn = Convert.ToDateTime(Session["LastModifiedOn"]);

                //    aa.zapRelated_Complaint_ID = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;
                //    aa.zapRelated_RegDiaryNumber = (String.IsNullOrEmpty(FormMDiaryNumber) ? "" : FormMDiaryNumber);
                //    aa.zapComplainantRERAnumber = (String.IsNullOrEmpty(ComplainantRERAnumber) ? "" : ComplainantRERAnumber);
                //    aa.zapComplainantName = (String.IsNullOrEmpty(FormMComplainantName) ? "" : FormMComplainantName);
                //    aa.zapRespondantName = (String.IsNullOrEmpty(FormMRespondantName) ? "" : FormMRespondantName);
                //    aa.zapComplaintFormLastModifiedOn = LastModifiedOn;
                //}
                //else
                //{
                //    aa.zapRelated_Complaint_ID = 0;
                //    aa.zapRelated_RegDiaryNumber = "";
                //    aa.zapComplainantRERAnumber = "";
                //    aa.zapComplainantName = "";
                //    aa.zapRespondantName = "";
                //}

                //return View("Map_AdvocatesComplainant");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult updatedetails(ClsPrp_ComplaintAdvocateProfile smodel)
        {
            try
            {
                string userRole = string.Empty;
                userRole = getUserRole();
                string userName = string.Empty;
                userName = User.Identity.GetUserName();

                Int64 ComplainantProfile_id = 0;

               // Int64 ComplaintFormMID = 0;
               // Int64 partyId = 0;
                Int64 advId = Convert.ToInt64(smodel.SelectedAdvocateID);
                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                    }
                }

                ClsPrp_ComplaintAdvocateProfile aa = new ClsPrp_ComplaintAdvocateProfile();
                ClsMethod_ComplaintProfile sdb = new ClsMethod_ComplaintProfile();

                aa.ComplaintAdvocateProfile = sdb.DisplayComplaintProfileDetails(ComplainantProfile_id);

                //if (Session["zapFormMDiaryNumber"] != null)
                //{
                //    Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
                //    ComplaintFormMID = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;
                //}

                //if (smodel.SelectedPartyType == "Complainant")
                //{
                //    partyId = Convert.ToInt64(smodel.SelectedComplainantID);
                //}
                //else if (smodel.SelectedPartyType == "Respondant")
                //{
                //    partyId = Convert.ToInt64(smodel.SelectedRespondantID);
                //}
                //else
                //{
                //    TempData["message"] = "Invalid party type selected!";
                //    TempData["MessageType"] = "error";
                //    return RedirectToAction("Map_Advocates");
                //}

                bool isUpdated = sdb.update_ComplaintFormM_Detail(ComplainantProfile_id, advId, userName);

                if (isUpdated)
                {
                    TempData["message"] = "Mapping successful!";
                    TempData["MessageType"] = "success";
                }
                else
                {
                    TempData["message"] = "Something went wrong while updating!";
                    TempData["MessageType"] = "error";
                }

                return RedirectToAction("Map_Advocates");
            }
            catch (Exception ex)
            {
                TempData["message"] = "Error: " + ex.Message;
                TempData["MessageType"] = "error";
                return RedirectToAction("Map_Advocates");
            }

        }


        [HttpGet]
        public JsonResult GetComplainants(long complaintId)
        {
            ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();
            var complainantList = sdb.Display_ComplainantFormM_Detail(complaintId);

            var result = complainantList.Select(x => new
            {
                id = x.AdditionComplainant_ID,
                name = x.Name_of_Complainant_or_Applicant
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetRespondants(long complaintId)
        {
            ClsMethod_AuthDesk_FormMN_Addmore_Respondent sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Respondent();
            var complainantList = sdb.Display_RespondentFormM_Detail(complaintId);

            var result = complainantList.Select(x => new
            {
                id = x.AdditionRespondent_ID,
                name = x.Name_of_Respondant_or_Applicant
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAdvocates(string term)
        {
            ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
            var type = "Complaint Form M";
            var advocates = sdb.Display_Master_Advocates(type);

            var result = advocates
                .Where(x => string.IsNullOrEmpty(term) ||
                            x.CounselRepresentative.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(x => new
                {
                    id = x.Advocate_IndexID,
                    name = x.CounselRepresentative,
                    mobile = x.MobileNumber,
                    email = x.Email,
                    address = x.AddressLine1,
                    othermemb = x.Othermembers
                })
                .ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion

        //#region Add Advocates FORM_N

        //[HttpGet]
        //public ActionResult Display_AdvocatesN()
        //{
        //    ClsPrp_Master_Advocates aa = new ClsPrp_Master_Advocates();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
        //    var type = "FormTypeN";
        //    var diarynumber = Session["zapFormNDiaryNumber"].ToString();

        //    if (Session["zapFormNDiaryNumber"] != null)
        //    {
        //        string FormNDiaryNumber = Session["zapFormNDiaryNumber"].ToString();
        //        string FormNComplainantName = Session["zapFormNComplainantName"].ToString();
        //        string FormNRespondantName = Session["zapFormNRespondantName"].ToString();
        //        string ComplainantRERAnumber = Session["zapComplainantRERAnumber"].ToString();
        //        Int64? ComplaintFormN_ID = Convert.ToInt64(Session["zapComplaintFormN_ID"]);
        //        DateTime? LastModifiedOn = Convert.ToDateTime(Session["LastModifiedOn"]);
        //        string ComplainantType = Session["ComplaintType_MN"].ToString();

        //        string profileid = Session["Profile_Id"].ToString();
        //        string diarynumberId = Session["ComplaintRegDiaryNumber_ID"].ToString();
        //        string diarynumberYear = Session["ComplaintRegDiaryNumber_NameYear"].ToString();

        //        aa.ComplaintFormMN_ID = Convert.ToInt64(ComplaintFormN_ID);
        //        aa.DiaryNumber = (String.IsNullOrEmpty(FormNDiaryNumber) ? "" : FormNDiaryNumber);
        //        aa.Profile_ID = profileid;
        //        aa.Complaint_ID = diarynumberId;
        //        aa.Year = diarynumberYear;
        //        aa.TypeOfComplaintMN = ComplainantType;

        //        aa.zapComplainantRERAnumber = (String.IsNullOrEmpty(ComplainantRERAnumber) ? "" : ComplainantRERAnumber);
        //        aa.zapComplainantName = (String.IsNullOrEmpty(FormNComplainantName) ? "" : FormNComplainantName);
        //        aa.zapRespondantName = (String.IsNullOrEmpty(FormNRespondantName) ? "" : FormNRespondantName);
        //        aa.zapComplaintFormLastModifiedOn = LastModifiedOn;
        //    }
        //    else
        //    {
        //        aa.Complaint_ID = "";
        //        aa.DiaryNumber = "";
        //        aa.zapComplainantRERAnumber = "";
        //        aa.zapComplainantName = "";
        //        aa.zapRespondantName = "";
        //    }
        //    aa.prpadvocates = sdb.Display_Master_Advocates(type, diarynumber);
        //    aa.stateMaster = objdis.State_list();
        //    aa.districtMaster = new List<ClsPrp_DistrictMaster>();

        //    TempData["submitvalue"] = "Save";
        //    TempData.Keep();

        //    return View("Display_AdvocatesN", aa);
        //}

        //[HttpPost]
        //public ActionResult Add_AdvocatesN(ClsPrp_Master_Advocates smodel)
        //{
        //    string user = User.Identity.Name;
        //    var objdis = new ClsMethodDistrictMaster();
        //    var sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
        //    var type = "FormTypeN";
        //    var diarynumber = smodel.DiaryNumber;

        //    if (!ModelState.IsValid)
        //    {
        //        smodel.stateMaster = objdis.State_list();
        //        smodel.districtMaster = (smodel.State > 0) ? objdis.dropdownlist_display1(smodel.State) : new List<ClsPrp_DistrictMaster>();

        //        return View("Display_AdvocatesN", smodel);
        //    }

        //    if (TempData["submitvalue"].ToString() == "Update")
        //    {
        //        try
        //        {
        //            int result = sdb.Update_Advocates(smodel, user);
        //            if (result == -1)
        //            {
        //                TempData["MessageEmailAddress"] = "Record not found.";
        //                TempData["MessageType"] = "error";

        //                smodel.stateMaster = objdis.State_list();
        //                smodel.districtMaster = (smodel.State > 0) ? objdis.dropdownlist_display1(smodel.State) : new List<ClsPrp_DistrictMaster>();
        //                smodel.prpadvocates = sdb.Display_Master_Advocates(type, diarynumber);

        //                return View("Display_AdvocatesN", smodel);
        //            }

        //            if (result > 0)
        //            {
        //                TempData["MessageEmailAddress"] = "Details Updated Successfully!";
        //                TempData["MessageType"] = "success";
        //                return RedirectToAction("Display_AdvocatesN");
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            int result = sdb.Add_Advocates(smodel, user);

        //            if (result == -1)
        //            {
        //                TempData["MessageEmailAddress"] = "This record already exists).";
        //                TempData["MessageType"] = "error";

        //                smodel.stateMaster = objdis.State_list();
        //                smodel.districtMaster = (smodel.State > 0) ? objdis.dropdownlist_display1(smodel.State) : new List<ClsPrp_DistrictMaster>();
        //                smodel.prpadvocates = sdb.Display_Master_Advocates(type, diarynumber);

        //                return View("Display_AdvocatesN", smodel);
        //            }
        //            if (result > 0)
        //            {
        //                TempData["MessageEmailAddress"] = "Details Added Successfully!";
        //                TempData["MessageType"] = "success";
        //                return RedirectToAction("Display_AdvocatesN");
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }

        //    return RedirectToAction("Display_AdvocatesN");
        //}

        //[HttpGet]
        //public ActionResult Edit_AdvocatesN(Int64 pIndexID, Int64 pKeyID)
        //{
        //    ClsPrp_Master_Advocates objprp = new ClsPrp_Master_Advocates();
        //    ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

        //    objprp.prpadvocates = sdb.Display_AdvocatesDetailsByID(pIndexID, pKeyID);
        //    foreach (var item in objprp.prpadvocates)
        //    {
        //        objprp.Advocate_IndexID = item.Advocate_IndexID;
        //        objprp.Advocate_ID = item.Advocate_ID;
        //        objprp.DiaryNumber = item.DiaryNumber;
        //        objprp.Complaint_ID = item.Complaint_ID;
        //        objprp.Year = item.Year;

        //        objprp.ComplaintFormMN_ID = item.ComplaintFormMN_ID;
        //        objprp.TypeOfComplaintMN = item.TypeOfComplaintMN;
        //        objprp.Profile_ID = item.Profile_ID;
        //        objprp.CounselRepresentative = item.CounselRepresentative;

        //        objprp.MobileNumber = item.MobileNumber;
        //        objprp.Email = item.Email;
        //        objprp.LandlineNumber = item.LandlineNumber;
        //        objprp.Othermembers = item.Othermembers;
        //        objprp.ExperienceYears = item.ExperienceYears;
        //        objprp.AddressLine1 = item.AddressLine1;
        //        objprp.AddressLine2 = item.AddressLine2;
        //        objprp.District = item.District;
        //        objprp.State = item.State;
        //        objprp.Pincode = item.Pincode;

        //        objprp.A_column = item.A_column;
        //        objprp.B_column = item.B_column;
        //        objprp.C_column = item.C_column;
        //        objprp.D_column = item.D_column;

        //        objprp.Dob = item.Dob;
        //        objprp.BarRegNumber = item.BarRegNumber;
        //        objprp.BarRegCode = item.BarRegCode;
        //        objprp.BarRegState = item.BarRegState;
        //        objprp.Location = item.Location;
        //        objprp.PlaceofPractice = item.PlaceofPractice;
        //        objprp.Gender = item.Gender;

        //        objprp.RemarksIfAny = item.RemarksIfAny;

        //        objprp.IsActive = item.IsActive;
        //        objprp.IsLock = item.IsLock;
        //        objprp.IsFlag = item.IsFlag;
        //        objprp.IsPublicView = item.IsPublicView;
        //        objprp.IsDraft = item.IsDraft;
        //        objprp.IsBarverified = item.IsBarverified;


        //        objprp.CreatedBy = item.CreatedBy;
        //        objprp.CreatedOn = item.CreatedOn;
        //        objprp.ModifyBy = item.ModifyBy;
        //        objprp.ModifyOn = item.ModifyOn;
        //    }

        //    TempData.Remove("MessageEmailAddress");
        //    TempData.Remove("MessageType");
        //    objprp.stateMaster = objdis.State_list();
        //    objprp.districtMaster = new List<ClsPrp_DistrictMaster>();
        //    if (Session["zapFormNDiaryNumber"] != null)
        //    {
        //        string FormNComplainantName = Session["zapFormNComplainantName"]?.ToString();
        //        string FormNRespondantName = Session["zapFormNRespondantName"]?.ToString();
        //        string ComplainantRERAnumber = Session["zapComplainantRERAnumber"]?.ToString();
        //        DateTime? LastModifiedOn = Convert.ToDateTime(Session["LastModifiedOn"]);

        //        objprp.zapComplainantRERAnumber = string.IsNullOrEmpty(ComplainantRERAnumber) ? "" : ComplainantRERAnumber;
        //        objprp.zapComplainantName = string.IsNullOrEmpty(FormNComplainantName) ? "" : FormNComplainantName;
        //        objprp.zapRespondantName = string.IsNullOrEmpty(FormNRespondantName) ? "" : FormNRespondantName;
        //        objprp.zapComplaintFormLastModifiedOn = LastModifiedOn;
        //    }
        //    TempData["submitvalue"] = "Update";
        //    TempData.Keep();
        //    return View("Display_AdvocatesN", objprp);
        //}

        //public ActionResult Delete_AdvocateDetailsN(Int64 pIndexID, Int64 pKeyID)
        //{
        //    ClsPrp_Master_Advocates aa = new ClsPrp_Master_Advocates();
        //    ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    try
        //    {
        //        if (sdb.Delete_AdminDesk_AdvocateDetailsByID(pIndexID, pKeyID))
        //        {
        //            TempData["message"] = "Details deleted Successfully";
        //        }
        //        // aa.stateMaster = objdis.State_list();
        //        // aa.districtMaster = new List<ClsPrp_DistrictMaster>();
        //        return RedirectToAction("Display_Advocates");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //#endregion


        //#region Mapping of advocates FORM-M
        //[HttpGet]
        //public ActionResult Map_Advocates()
        //{
        //    string userRole = string.Empty;
        //    Int64 ComplaintFormMID = 0;
        //    userRole = getUserRole();
        //    if (Session["zapFormMDiaryNumber"] != null)
        //    {
        //        Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
        //        ComplaintFormMID = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;
        //    }

        //    ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant aa = new ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant();
        //    ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();

        //    aa.FormMN_Complainant = sdb.Display_ComplainantFormM_DetailByID(ComplaintFormMID);
        //    aa.FormMN_Respondent = sdb.Display_RespondantFormM_DetailByID(ComplaintFormMID);

        //    if (Session["zapFormMDiaryNumber"] != null)
        //    {
        //        string FormMDiaryNumber = Session["zapFormMDiaryNumber"].ToString();
        //        string FormMComplainantName = Session["zapFormMComplainantName"].ToString();
        //        string FormMRespondantName = Session["zapFormMRespondantName"].ToString();
        //        string ComplainantRERAnumber = Session["zapComplainantRERAnumber"].ToString();
        //        Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
        //        DateTime? LastModifiedOn = Convert.ToDateTime(Session["LastModifiedOn"]);

        //        aa.zapRelated_Complaint_ID = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;
        //        aa.zapRelated_RegDiaryNumber = (String.IsNullOrEmpty(FormMDiaryNumber) ? "" : FormMDiaryNumber);
        //        aa.zapComplainantRERAnumber = (String.IsNullOrEmpty(ComplainantRERAnumber) ? "" : ComplainantRERAnumber);
        //        aa.zapComplainantName = (String.IsNullOrEmpty(FormMComplainantName) ? "" : FormMComplainantName);
        //        aa.zapRespondantName = (String.IsNullOrEmpty(FormMRespondantName) ? "" : FormMRespondantName);
        //        aa.zapComplaintFormLastModifiedOn = LastModifiedOn;
        //    }
        //    else
        //    {
        //        aa.zapRelated_Complaint_ID = 0;
        //        aa.zapRelated_RegDiaryNumber = "";
        //        aa.zapComplainantRERAnumber = "";
        //        aa.zapComplainantName = "";
        //        aa.zapRespondantName = "";
        //    }

        //    return View("Map_Advocates", aa);
        //}

        //[HttpPost]
        //public ActionResult updatedetails(ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant smodel)
        //{
        //    try
        //    {
        //        string userRole = string.Empty;
        //        userRole = getUserRole();
        //        string userName = string.Empty;
        //        userName = User.Identity.GetUserName();

        //        Int64 ComplaintFormMID = 0;
        //        Int64 partyId = 0;
        //        Int64 advId = Convert.ToInt64(smodel.SelectedAdvocateID);

        //        if (Session["zapFormMDiaryNumber"] != null)
        //        {
        //            Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
        //            ComplaintFormMID = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;
        //        }

        //        if (smodel.SelectedPartyType == "Complainant")
        //        {
        //            partyId = Convert.ToInt64(smodel.SelectedComplainantID);
        //        }
        //        else if (smodel.SelectedPartyType == "Respondant")
        //        {
        //            partyId = Convert.ToInt64(smodel.SelectedRespondantID);
        //        }
        //        else
        //        {
        //            TempData["message"] = "Invalid party type selected!";
        //            TempData["MessageType"] = "error";
        //            return RedirectToAction("Map_Advocates");
        //        }

        //        ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();
        //        bool isUpdated = sdb.update_ComplainantFormM_Detail(ComplaintFormMID, userName, partyId, advId, smodel.SelectedPartyType);

        //        if (isUpdated)
        //        {
        //            TempData["message"] = "Mapping successful!";
        //            TempData["MessageType"] = "success";
        //        }
        //        else
        //        {
        //            TempData["message"] = "Something went wrong while updating!";
        //            TempData["MessageType"] = "error";
        //        }

        //        return RedirectToAction("Map_Advocates");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["message"] = "Error: " + ex.Message;
        //        TempData["MessageType"] = "error";
        //        return RedirectToAction("Map_Advocates");
        //    }

        //}


        //[HttpGet]
        //public JsonResult GetComplainants(long complaintId)
        //{
        //    ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();
        //    var complainantList = sdb.Display_ComplainantFormM_Detail(complaintId);

        //    var result = complainantList.Select(x => new
        //    {
        //        id = x.AdditionComplainant_ID,
        //        name = x.Name_of_Complainant_or_Applicant
        //    });

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public JsonResult GetRespondants(long complaintId)
        //{
        //    ClsMethod_AuthDesk_FormMN_Addmore_Respondent sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Respondent();
        //    var complainantList = sdb.Display_RespondentFormM_Detail(complaintId);

        //    var result = complainantList.Select(x => new
        //    {
        //        id = x.AdditionRespondent_ID,
        //        name = x.Name_of_Respondant_or_Applicant
        //    });

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public JsonResult GetAdvocates(string term)
        //{
        //    ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
        //    var type = "FormTypeM";
        //    var advocates = sdb.Display_Master_Advocates(type);

        //    var result = advocates
        //        .Where(x => string.IsNullOrEmpty(term) ||
        //                    x.CounselRepresentative.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
        //        .Select(x => new
        //        {
        //            id = x.Advocate_IndexID,
        //            name = x.CounselRepresentative,
        //            mobile = x.MobileNumber,
        //            email = x.Email,
        //            address = x.AddressLine1,
        //            othermemb = x.Othermembers
        //        })
        //        .ToList();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        //#endregion

        //#region Mapping of advocates FORM-N
        //[HttpGet]
        //public ActionResult Map_AdvocatesN()
        //{
        //    string userRole = string.Empty;
        //    Int64 ComplaintFormNID = 0;
        //    userRole = getUserRole();
        //    if (Session["zapFormNDiaryNumber"] != null)
        //    {
        //        Int64? ComplaintFormN_ID = Convert.ToInt64(Session["zapComplaintFormN_ID"]);
        //        ComplaintFormNID = (ComplaintFormN_ID != null) ? Convert.ToInt64(ComplaintFormN_ID) : 0;
        //    }

        //    ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant aa = new ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant();
        //    ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();

        //    aa.FormMN_Complainant = sdb.Display_ComplainantFormN_DetailByID(ComplaintFormNID);
        //    aa.FormMN_Respondent = sdb.Display_RespondantFormN_DetailByID(ComplaintFormNID);

        //    if (Session["zapFormNDiaryNumber"] != null)
        //    {
        //        string FormNDiaryNumber = Session["zapFormNDiaryNumber"].ToString();
        //        string FormNComplainantName = Session["zapFormNComplainantName"].ToString();
        //        string FormNRespondantName = Session["zapFormNRespondantName"].ToString();
        //        string ComplainantRERAnumber = Session["zapComplainantRERAnumber"].ToString();
        //        Int64? ComplaintFormN_ID = Convert.ToInt64(Session["zapComplaintFormN_ID"]);
        //        DateTime? LastModifiedOn = Convert.ToDateTime(Session["LastModifiedOn"]);

        //        aa.zapRelated_Complaint_ID = (ComplaintFormN_ID != null) ? Convert.ToInt64(ComplaintFormN_ID) : 0;
        //        aa.zapRelated_RegDiaryNumber = (String.IsNullOrEmpty(FormNDiaryNumber) ? "" : FormNDiaryNumber);
        //        aa.zapComplainantRERAnumber = (String.IsNullOrEmpty(ComplainantRERAnumber) ? "" : ComplainantRERAnumber);
        //        aa.zapComplainantName = (String.IsNullOrEmpty(FormNComplainantName) ? "" : FormNComplainantName);
        //        aa.zapRespondantName = (String.IsNullOrEmpty(FormNRespondantName) ? "" : FormNRespondantName);
        //        aa.zapComplaintFormLastModifiedOn = LastModifiedOn;
        //    }
        //    else
        //    {
        //        aa.zapRelated_Complaint_ID = 0;
        //        aa.zapRelated_RegDiaryNumber = "";
        //        aa.zapComplainantRERAnumber = "";
        //        aa.zapComplainantName = "";
        //        aa.zapRespondantName = "";
        //    }

        //    return View("Map_AdvocatesN", aa);
        //}

        //[HttpPost]
        //public ActionResult updatedetailsN(ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant smodel)
        //{
        //    try
        //    {
        //        string userRole = string.Empty;
        //        userRole = getUserRole();
        //        string userName = string.Empty;
        //        userName = User.Identity.GetUserName();

        //        Int64 ComplaintFormNID = 0;
        //        Int64 partyId = 0;
        //        Int64 advId = Convert.ToInt64(smodel.SelectedAdvocateID);

        //        if (Session["zapFormNDiaryNumber"] != null)
        //        {
        //            Int64? ComplaintFormN_ID = Convert.ToInt64(Session["zapComplaintFormN_ID"]);
        //            ComplaintFormNID = (ComplaintFormN_ID != null) ? Convert.ToInt64(ComplaintFormN_ID) : 0;
        //        }

        //        if (smodel.SelectedPartyType == "Complainant")
        //        {
        //            partyId = Convert.ToInt64(smodel.SelectedComplainantID);
        //        }
        //        else if (smodel.SelectedPartyType == "Respondant")
        //        {
        //            partyId = Convert.ToInt64(smodel.SelectedRespondantID);
        //        }
        //        else
        //        {
        //            TempData["message"] = "Invalid party type selected!";
        //            TempData["MessageType"] = "error";
        //            return RedirectToAction("Map_Advocates");
        //        }

        //        ClsMethod_AuthDesk_FormMN_Addmore_Complainant sdb = new ClsMethod_AuthDesk_FormMN_Addmore_Complainant();
        //        bool isUpdated = sdb.update_ComplainantFormN_Detail(ComplaintFormNID, userName, partyId, advId, smodel.SelectedPartyType);

        //        if (isUpdated)
        //        {
        //            TempData["message"] = "Mapping successful!";
        //            TempData["MessageType"] = "success";
        //        }
        //        else
        //        {
        //            TempData["message"] = "Something went wrong while updating!";
        //            TempData["MessageType"] = "error";
        //        }

        //        return RedirectToAction("Map_AdvocatesN");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["message"] = "Error: " + ex.Message;
        //        TempData["MessageType"] = "error";
        //        return RedirectToAction("Map_Advocates");
        //    }
        //}

        //[HttpGet]
        //public JsonResult GetAdvocatesN(string term)
        //{
        //    var type = "FormTypeN";
        //    ClsMethod_AuthDesk_FormM_PreHearingDate sdb = new ClsMethod_AuthDesk_FormM_PreHearingDate();
        //    var advocates = sdb.Display_Master_Advocates(type);

        //    var result = advocates
        //        .Where(x => string.IsNullOrEmpty(term) ||
        //                    x.CounselRepresentative.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
        //        .Select(x => new
        //        {
        //            id = x.Advocate_IndexID,
        //            name = x.CounselRepresentative,
        //            mobile = x.MobileNumber,
        //            email = x.Email,
        //            address = x.AddressLine1,
        //            othermemb = x.Othermembers
        //        }).ToList();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        //#endregion
    }
}
