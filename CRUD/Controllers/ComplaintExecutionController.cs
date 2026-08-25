using CRUD.Filters;
using CRUD.Models;
using CRUD.Models.ClassComplaintPayment;
using CRUD.Models.Complaint;
using CRUD.Models.ComplaintExecution;
using CRUD.Models.Promoter;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class ComplaintExecutionController : Controller
    {
        #region Execution FORM

        #region Step-I Form-M Reg  
        //[TrackActivity]
        //[HttpGet]
        //public ActionResult RegExecutionForm()
        //{
        //    Int64 ComplaintExeProfile_Id = 0;
        //    string userID = string.Empty;
        //    if (!string.IsNullOrWhiteSpace(Session["User_Id"] as string))
        //    {
        //        userID = Convert.ToString(Session["User_Id"]);
        //    }

        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("SessionExpire", "Account");
        //    }

        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
        //    try
        //    {
        //        aa.districtMaster = objdis.dropdownlist_display1();
        //        aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
        //        aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
        //        aa.stateMaster = objdis.State_list();
        //        //  PREFILL
        //        aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplaintExeProfile_Id);

        //        if (aa.Complainant_UserProfile.Count > 0)
        //        {
        //            var profile = aa.Complainant_UserProfile.FirstOrDefault();

        //            //Applicant = Complainant
        //            aa.applicant_first_name = profile.Applicant_FirstName;
        //            aa.applicant_last_name = profile.Applicant_LastName;
        //            aa.applicant_email = profile.EmailAddress;

        //            aa.applicant_address_line1 = profile.Residencial_Official_AddressLine1;
        //            aa.applicant_address_line2 = profile.Residencial_Official_AddressLine2;
        //            aa.applicantlicant_state = Convert.ToString(profile.Residencial_Official_AddressStateCode);
        //            aa.applicant_district = Convert.ToString(profile.Residencial_Official_AddressDistrictCode);
        //            aa.applicant_pincode = profile.Residencial_Official_AddressPIN;
        //        }
        //        else
        //        {
        //            return RedirectToAction("RegComplaintProfileNA", "Complaint");
        //        }

        //        Int64 ExecutionComplaint_id = 0;
        //        if (Session["ExecutionComplaintId"] != null)
        //        {
        //            if (Session["ExecutionComplaintId"].ToString() != "0")
        //            {
        //                ExecutionComplaint_id = Convert.ToInt64(Session["ExecutionComplaintId"]);
        //            }
        //        }

        //        aa.ExecutionFormstepI = objFormAppM.Display_ExecutionForm_Registration_StepI(ExecutionComplaint_id);

        //        //if (aa.ExecutionFormstepI != null && aa.ExecutionFormstepI.Count > 0)
        //        if (aa.ExecutionFormstepI.Count >= 1)
        //        {
        //            foreach (var item in aa.ExecutionFormstepI)
        //            {

        //                aa.execution_IndexId = item.execution_IndexId;
        //                aa.executioncomplaintId = item.executioncomplaintId;
        //                aa.Id = item.Id;
        //                aa.uid = item.uid;

        //                aa.applicant_first_name = item.applicant_first_name;
        //                aa.applicant_middle_name = item.applicant_middle_name;
        //                aa.applicant_last_name = item.applicant_last_name;
        //                aa.applicant_email = item.applicant_email;
        //                aa.applicant_address_line1 = item.applicant_address_line1;
        //                aa.applicant_address_line2 = item.applicant_address_line2;
        //                aa.applicantlicant_state = item.applicantlicant_state;
        //                aa.applicant_district = item.applicant_district;
        //                aa.applicant_pincode = item.applicant_pincode;

        //                // Complaint
        //                aa.complaint_number = item.complaint_number;

        //                // Decree Holder
        //                aa.dh_first_name = item.dh_first_name;
        //                aa.dh_middle_name = item.dh_middle_name;
        //                aa.dh_last_name = item.dh_last_name;
        //                aa.dh_email = item.dh_email;
        //                aa.dh_mobile = item.dh_mobile;
        //                aa.dh_phone_landline = item.dh_phone_landline;
        //                aa.dh_aadhaar = item.dh_aadhaar;
        //                aa.dh_address_line1 = item.dh_address_line1;
        //                aa.dh_address_line2 = item.dh_address_line2;
        //                aa.dh_state = item.dh_state;
        //                aa.dh_district = item.dh_district;
        //                aa.dh_pincode = item.dh_pincode;

        //                // Judgment Debtor
        //                aa.jd_first_name = item.jd_first_name;
        //                aa.jd_middle_name = item.jd_middle_name;
        //                aa.jd_last_name = item.jd_last_name;
        //                aa.jd_email = item.jd_email;
        //                aa.jd_mobile = item.jd_mobile;
        //                aa.jd_phone_landline = item.jd_phone_landline;
        //                aa.jd_aadhaar = item.jd_aadhaar;
        //                aa.jd_address_line1 = item.jd_address_line1;
        //                aa.jd_address_line2 = item.jd_address_line2;
        //                aa.jd_state = item.jd_state;
        //                aa.jd_district = item.jd_district;
        //                aa.jd_pincode = item.jd_pincode;

        //                // Dates & Bench
        //                aa.date_of_order = item.date_of_order;
        //                aa.bench_name = item.bench_name;
        //                aa.compliance_from_date = item.compliance_from_date;
        //                aa.compliance_to_date = item.compliance_to_date;

        //                // Execution Details
        //                aa.appeal_information = item.appeal_information;
        //                aa.payment_adjustment_details = item.payment_adjustment_details;
        //                aa.compliance_status = item.compliance_status;
        //                aa.compliance_document = item.compliance_document;
        //                aa.previous_execution_details = item.previous_execution_details;

        //                // Financials
        //                aa.principal_amount = item.principal_amount;
        //                aa.interest_amount = item.interest_amount;
        //                aa.cost_amount = item.cost_amount;
        //                aa.total_amount = item.total_amount;

        //                // Misc
        //                aa.mode_of_assistance_required = item.mode_of_assistance_required;
        //                aa.property_details = item.property_details;
        //                aa.respondent_bank_details = item.respondent_bank_details;
        //                aa.other_relevant_details = item.other_relevant_details;
        //                aa.declaration_signed = item.declaration_signed;

        //                // Flags
        //                aa.IsComplaintComplete = item.IsComplaintComplete;
        //                aa.IsDocumentsComplete = item.IsDocumentsComplete;
        //                aa.IsPaymentComplete = item.IsPaymentComplete;
        //                aa.IsVerificationComplete = item.IsVerificationComplete;
        //                aa.IsActive = item.IsActive;
        //                aa.IsDraft = item.IsDraft;
        //                aa.IsLock = item.IsLock;
        //                aa.IsPublicView = item.IsPublicView;

        //                // Audit
        //                aa.CreatedBy = item.CreatedBy;
        //                aa.createdOn = item.createdOn;
        //                aa.ModifyBy = item.ModifyBy;
        //                aa.modifiedOn = item.modifiedOn;

        //                aa.A_column = item.A_column;
        //                aa.B_column = item.B_column;
        //                aa.C_column = item.C_column;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        string ext = ex.ToString();
        //    }

        //    if (aa.ExecutionFormstepI.Count >= 1)
        //    {
        //        TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
        //    }
        //    else
        //    {
        //        TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
        //    }

        //    //return View("RegComplaintFormM", aa);
        //    // ActivityLogger.LogEventActivity(userID, "RegExecutionForm", "ComplaintExecution");

        //    return View(aa);
        //}

        //[HttpGet]
        //public ActionResult Goto_RegExecutionForm()
        //{
        //    Int64 executioncomplaintId = 0;
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("SessionExpire", "Account");
        //    }


        //        string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

        //        string varFlagStep_ControllerLinkName = string.Empty;
        //        string varFlagStep_ActionLinkName = string.Empty;

        //        switch (varFlagStep_LinkName)
        //        {
        //            case "Step1M":
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegExecutionForm";
        //                break;
        //            case "Step2M":
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegExecutionEncldocM";
        //                break;
        //            case "Step3M":
        //                varFlagStep_ControllerLinkName = "ComplaintPayment";
        //                varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
        //                break;
        //            case "Step4M":
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
        //                break;
        //            default:
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegExecutionForm";
        //                break;
        //        }

        //        //return RedirectToAction("RegComplaintFormM");
        //        return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);

        //}


        //[HttpGet]
        //public ActionResult Create_RegExecutionForm()
        //{
        //    Int64 executioncomplaintId = 0;
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("SessionExpire", "Account");
        //    }
        //    string userName = User.Identity.Name;


        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

        //    try
        //    {
        //        aa.districtMaster = objdis.dropdownlist_display1();
        //        aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
        //        aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
        //        aa.stateMaster = objdis.State_list();
        //        //  PREFILL
        //        aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(executioncomplaintId);

        //        if (aa.Complainant_UserProfile.Count >= 1)
        //        {
        //            foreach (var item in aa.Complainant_UserProfile)
        //            {

        //                //Applicant = Complainant
        //                aa.applicant_first_name = item.Applicant_FirstName;
        //                aa.applicant_last_name = item.Applicant_LastName;
        //                aa.applicant_email = item.EmailAddress;

        //                aa.applicant_address_line1 = item.Residencial_Official_AddressLine1;
        //                aa.applicant_address_line2 = item.Residencial_Official_AddressLine2;
        //                aa.applicantlicant_state = Convert.ToString(item.Residencial_Official_AddressStateCode);
        //                aa.applicant_district = Convert.ToString(item.Residencial_Official_AddressDistrictCode);
        //                aa.applicant_pincode = item.Residencial_Official_AddressPIN;
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("RegComplaintProfileNA", "Complaint");
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        string ext = ex.ToString();
        //    }

        //    if (aa.ExecutionFormstepI.Count >= 1)
        //    {
        //        TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
        //    }
        //    else
        //    {
        //        TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
        //    }

        //    return View("RegExecutionForm", aa);
        //}


        //[HttpGet]
        //public ActionResult Details_RegComplaintFormEXE(Int64 zComplaintFormM_ID, Int64 zComplaintProfile_ID)
        //{
        //    Int64 ComplaintExeProfile_Id = zComplaintProfile_ID;

        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

        //    try
        //    {
        //        aa.districtMaster = objdis.dropdownlist_display1();
        //        aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
        //        aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
        //        aa.stateMaster = objdis.State_list();
        //        //  PREFILL
        //        aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplaintExeProfile_Id);

        //        if (aa.Complainant_UserProfile.Count >= 1)
        //        {
        //            foreach (var item in aa.Complainant_UserProfile)
        //            {

        //                //Applicant = Complainant
        //                aa.applicant_first_name = item.Applicant_FirstName;
        //                aa.applicant_last_name = item.Applicant_LastName;
        //                aa.applicant_email = item.EmailAddress;

        //                aa.applicant_address_line1 = item.Residencial_Official_AddressLine1;
        //                aa.applicant_address_line2 = item.Residencial_Official_AddressLine2;
        //                aa.applicantlicant_state = Convert.ToString(item.Residencial_Official_AddressStateCode);
        //                aa.applicant_district = Convert.ToString(item.Residencial_Official_AddressDistrictCode);
        //                aa.applicant_pincode = item.Residencial_Official_AddressPIN;
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("RegComplaintProfileNA", "Complaint");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string ext = ex.ToString();
        //    }


        //    Int64 executioncomplaintId = zComplaintFormM_ID;
        //    Session["executioncomplaintId"] = executioncomplaintId;


        //    try
        //    {
        //        string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

        //        string varFlagStep_ControllerLinkName = string.Empty;
        //        string varFlagStep_ActionLinkName = string.Empty;

        //        switch (varFlagStep_LinkName)
        //        {
        //            case "Step1M":
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegExecutionForm";
        //                break;
        //            case "Step2M":
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegExecutionEncldocM";
        //                break;
        //            case "Step3M":
        //                varFlagStep_ControllerLinkName = "ComplaintPayment";
        //                varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
        //                break;
        //            case "Step4M":
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
        //                break;
        //            default:
        //                varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                varFlagStep_ActionLinkName = "RegExecutionForm";
        //                break;
        //        }

        //        return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
        //    }
        //    catch (Exception ex)
        //    {
        //        string strex = ex.ToString();
        //        TempData["message"] = "Bad Request, Try Again!";
        //        //return View();
        //        return View("RegExecutionForm", "ComplaintExecution");
        //    }
        //}

        //[TrackActivity]
        //[HttpGet]
        //public ActionResult Create_RegExecutionForm()
        //{
        //    Int64 ComplaintExeProfile_Id = 0;
        //    string userID = string.Empty;
        //    if (!string.IsNullOrWhiteSpace(Session["User_Id"] as string))
        //    {
        //        userID = Convert.ToString(Session["User_Id"]);
        //    }

        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("SessionExpire", "Account");
        //    }
        //    string userName = User.Identity.Name;


        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

        //    try
        //    {
        //        aa.districtMaster = objdis.dropdownlist_display1();
        //        aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
        //        aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
        //        aa.stateMaster = objdis.State_list();
        //        //  PREFILL
        //        aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplaintExeProfile_Id);

        //        if (aa.Complainant_UserProfile.Count >= 1)
        //        {
        //            foreach (var item in aa.Complainant_UserProfile)
        //            {

        //                //Applicant = Complainant
        //                aa.applicant_first_name = item.Applicant_FirstName;
        //                aa.applicant_last_name = item.Applicant_LastName;
        //                aa.applicant_email = item.EmailAddress;

        //                aa.applicant_address_line1 = item.Residencial_Official_AddressLine1;
        //                aa.applicant_address_line2 = item.Residencial_Official_AddressLine2;
        //                aa.applicantlicant_state = Convert.ToString(item.Residencial_Official_AddressStateCode);
        //                aa.applicant_district = Convert.ToString(item.Residencial_Official_AddressDistrictCode);
        //                aa.applicant_pincode = item.Residencial_Official_AddressPIN;
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("RegComplaintProfileNA", "Complaint");
        //        }

        //        Int64 ExecutioncomplaintId = 0;
        //        Session["ExecutionComplaintId"] = ExecutioncomplaintId;

        //        aa.execution_IndexId = 0;
        //        aa.executioncomplaintId = 0;
        //        //aa.ComplaintFormM_Code = string.Empty;
        //        //aa.Profile_ID = ComplainantProfile_id;

        //        aa.IsActive = 0;
        //        aa.IsDraft = 0;
        //        aa.IsLock = 0;
        //        aa.IsPublicView = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string ext = ex.ToString();
        //    }

        //    if (aa.ExecutionFormstepI.Count >= 1)
        //    {
        //        TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
        //    }
        //    else
        //    {
        //        TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
        //    }
        //    // ActivityLogger.LogEventActivity(userID, "Create_RegExecutionForm", "ComplaintExecution");
        //    return View("RegExecutionForm", aa);
        //}

        //[HttpPost] //[ValidateInput(false)]        
        //public ActionResult RegExecutionForm(ClsPrp_ExecutionApplication smodel, HttpPostedFileBase ComplianceFile)
        //{
        //    string UID = User.Identity.GetUserId();
        //    string userName = User.Identity.Name;
        //    Int64 ComplaintExeProfile_Id = 0;
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("SessionExpire", "Account");
        //    }
        //    //bool varFlag_FactsCase = false;

        //    ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

        //    #region Save & Update         
        //    if (TempData["submitvalueFormMStep1"].ToString() == "Update")
        //    {
        //        try
        //        {
        //            string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

        //            string varFlagStep_ControllerLinkName = string.Empty;
        //            string varFlagStep_ActionLinkName = string.Empty;

        //            switch (varFlagStep_LinkName)
        //            {
        //                case "Step1M":
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegExecutionForm";
        //                    break;
        //                case "Step2M":
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegExecutionEncldocM";
        //                    break;
        //                case "Step3M":
        //                    varFlagStep_ControllerLinkName = "ComplaintPayment";
        //                    varFlagStep_ActionLinkName = "RequestPaymentFormM";
        //                    break;
        //                case "Step4M":
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
        //                    break;
        //                default:
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegExecutionForm";
        //                    break;
        //            }

        //            //return RedirectToAction("RegComplaintFormM");
        //            return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
        //        }
        //        catch (Exception ex)
        //        {
        //            PopulateMasters(smodel);
        //            string strex = ex.ToString();
        //            TempData["message"] = "Bad Request, Try Again!";
        //            //return View();
        //            return View("RegExecutionForm", smodel);
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            if (ComplianceFile != null && ComplianceFile.ContentLength > 0)
        //            {
        //                int maxSize = 1 * 1024 * 1024;

        //                if (ComplianceFile.ContentLength > maxSize)
        //                {
        //                    ModelState.AddModelError("compliance_document", "Compliance document size must be less than 1 MB.");
        //                    PopulateMasters(smodel);
        //                    return View(smodel);
        //                }
        //                string ext = Path.GetExtension(ComplianceFile.FileName).ToLower();
        //                if (ext != ".pdf" && ext != ".jpg" && ext != ".jpeg")
        //                {
        //                    ModelState.AddModelError("compliance_document", "Only PDF or JPG files are allowed.");
        //                    return View(smodel);
        //                }
        //                string folder = "~/readwriteFormMDoc/" + ComplaintExeProfile_Id + "/";
        //                string serverPath = Server.MapPath(folder);

        //                if (!Directory.Exists(serverPath))
        //                {
        //                    Directory.CreateDirectory(serverPath);
        //                }

        //                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss_") + Path.GetFileName(ComplianceFile.FileName);

        //                string fullPath = Path.Combine(serverPath, fileName);
        //                ComplianceFile.SaveAs(fullPath);

        //                smodel.compliance_document = folder + fileName;
        //            }

        //            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

        //            if (ModelState.IsValid)
        //            {
        //                Int64 Appid = objFormAppM.Add_ExecutionForm_Registration_StepI(smodel, UID, userName, ComplaintExeProfile_Id);
        //                if (Appid > 0)
        //                {
        //                    ViewBag.ApplicationId = Appid;
        //                    ViewBag.Message = " Details Successfully Submitted";
        //                    TempData["message"] = " Details Successfully Submitted";

        //                    Session["execution_IndexId"] = Appid;
        //                    smodel.execution_IndexId = Convert.ToInt64(Session["execution_IndexId"]);
        //                    smodel.executioncomplaintId = ComplaintExeProfile_Id;

        //                    ModelState.Clear();
        //                }
        //            }
        //            //}

        //            string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

        //            string varFlagStep_ControllerLinkName = string.Empty;
        //            string varFlagStep_ActionLinkName = string.Empty;

        //            switch (varFlagStep_LinkName)
        //            {
        //                case "Step1M":
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegExecutionForm";
        //                    break;
        //                case "Step2M":
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegExecutionEncldocM";
        //                    break;
        //                case "Step3M":
        //                    varFlagStep_ControllerLinkName = "ComplaintPayment";
        //                    varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
        //                    break;
        //                case "Step4M":
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
        //                    break;
        //                default:
        //                    varFlagStep_ControllerLinkName = "ComplaintExecution";
        //                    varFlagStep_ActionLinkName = "RegExecutionForm";
        //                    break;
        //            }
        //            return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
        //        }
        //        catch (Exception ex)
        //        {
        //            PopulateMasters(smodel);
        //            string strex = ex.ToString();
        //            TempData["message"] = "Bad Request, Try Again!";
        //            return View("RegExecutionForm", smodel);
        //        }
        //    }
        //    #endregion
        //}

        private void PopulateMasters(ClsPrp_ExecutionApplication model)
        {
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            model.stateMaster = objdis.State_list();
            model.districtMaster = objdis.dropdownlist_display1();
            model.districtPunjabMaster = objdis.dropdownlist_display1(28);
            model.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
        }


        #endregion


        #region Step-II Form-M Doc
        //[HttpGet]
        //public ActionResult RegExecutionEncldocM()
        //{
        //    Int64 Executioncomplaint_id = 0;
        //    Int32 retAbsoluteIsDraft = 1;
        //    if (Session["ExecutionForm_ID"] != null)
        //    {
        //        if (Session["ExecutionForm_ID"].ToString() != "0")
        //        {
        //            Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
        //        }
        //    }

        //    ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
        //    Clsprp_ExecutionForm_Documents aa = new Clsprp_ExecutionForm_Documents();

        //    aa.ComplaintDoc_IssueDate = DateTime.Now;

        //    aa.prpFormM_Docs = sdb.Display_ExecutionForm_Documents_ByExecution_ID(Executioncomplaint_id);
        //    if (aa.prpFormM_Docs.Count > 0)
        //    {
        //        foreach (var item in aa.prpFormM_Docs)
        //        {
        //            aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
        //            aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
        //            aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
        //            aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
        //            ////aa.Profile_ID = item.Profile_ID;
        //            ////aa.User_ID = item.User_ID;
        //            ////aa.ComplaintType_MN = item.ComplaintType_MN;
        //            ////aa.ComplaintDoc_InfoCode = item.ComplaintDoc_InfoCode;
        //            ////aa.ComplaintDoc_InfoName = item.ComplaintDoc_InfoName;
        //            ////aa.ComplaintDoc_ReferenceNumber = item.ComplaintDoc_ReferenceNumber;
        //            ////aa.ComplaintDoc_IssueDate = item.ComplaintDoc_IssueDate;

        //            ////aa.ComplaintDoc_FileSize = item.ComplaintDoc_FileSize;
        //            ////aa.ComplaintDoc_FileFormat = item.ComplaintDoc_FileFormat;
        //            ////aa.ComplaintDoc_FilePath = item.ComplaintDoc_FilePath;
        //            ////aa.ComplaintDoc_FileName = item.ComplaintDoc_FileName;
        //            ////aa.ComplaintDoc_IsGroup = item.ComplaintDoc_IsGroup;
        //            ////aa.Doc_SerialNumber = item.Doc_SerialNumber;
        //            ////aa.Doc_PageStartNumber = item.Doc_PageStartNumber;
        //            ////aa.Doc_PageEndNumber = item.Doc_PageEndNumber;

        //            ////aa.Remarks_IfAny = item.Remarks_IfAny;
        //            ////aa.A_column = item.A_column;
        //            ////aa.B_column = item.B_column;
        //            ////aa.C_column = item.C_column;
        //            ////aa.D_column = item.D_column;
        //            aa.IsActive = item.IsActive;
        //            aa.IsDraft = item.IsDraft;
        //            aa.IsLock = item.IsLock;
        //            aa.IsPublicView = item.IsPublicView;
        //            ////aa.CreatedBy = item.CreatedBy;
        //            ////aa.CreatedOn = item.CreatedOn;
        //            ////aa.ModifyBy = item.ModifyBy;
        //            ////aa.ModifyOn = item.ModifyOn;
        //            if (item.IsDraft == 0 || item.IsDraft == 4)
        //            {
        //                retAbsoluteIsDraft = item.IsDraft;
        //            }
        //        }
        //        aa.IsDraft = retAbsoluteIsDraft;
        //    }
        //    return View("RegExecutionEncldocM", aa);
        //}

        //[HttpPost]
        //public ActionResult RegExecutionEncldocFormM()
        //{
        //    Int64 executioncomplaintId = 0;
        //    Int32 retAbsoluteIsDraft = 1;
        //    if (Session["ApplicationId"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }

        //    ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
        //    Clsprp_ComplaintFormM_Documents aa = new Clsprp_ComplaintFormM_Documents();
        //    string userName = User.Identity.Name;

        //    Int64 varGetChk = sdb.Update_Check_ComplaintFormM_Documents(executioncomplaintId, userName);
        //    if (varGetChk == 100)
        //    {
        //        //Already OR Updated (IsDocComplete = true)
        //        return RedirectToAction("RequestPaymentFormM", "ComplaintPayment");
        //    }
        //    else if (varGetChk == 200 || varGetChk == 300)
        //    {
        //        // Pending (IsDocComplete = true)
        //        aa.ComplaintDoc_IssueDate = DateTime.Now;

        //        aa.prpFormM_Docs = sdb.Display_ComplaintFormM_Documents_ByComplaintFormM_ID(executioncomplaintId);
        //        if (aa.prpFormM_Docs.Count > 0)
        //        {
        //            foreach (var item in aa.prpFormM_Docs)
        //            {
        //                aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
        //                aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
        //                aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
        //                aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;

        //                aa.IsActive = item.IsActive;
        //                aa.IsDraft = item.IsDraft;
        //                aa.IsLock = item.IsLock;
        //                aa.IsPublicView = item.IsPublicView;

        //                if (item.IsDraft == 0 || item.IsDraft == 4)
        //                {
        //                    retAbsoluteIsDraft = item.IsDraft;
        //                }
        //            }
        //            aa.IsDraft = retAbsoluteIsDraft;
        //        }
        //        TempData["ComplaintFormMvalidDocName"] = "";
        //        if (varGetChk == 200)
        //        {
        //            TempData["ComplaintFormMvalidDocName"] = "Incomplete Complaint Form-M Documents, Please upload Complaint Form-M Documents First.";
        //        }
        //        //if (varGetChk == 300)
        //        //{
        //        //    TempData["ComplaintFormMvalidDocName"] = "Incomplete Complaint Form-M Documents, For un-registered project, it is mandatory to upload any of following document(s) as (a.) CLU or License to develop Colony (Sepecify, Ref Number and Issuing Authority in Remarks), (b.) Regularization Certificate (In case of illegal/unauthorized colony) and (c.) Agreement to Sell/ Allotment Letter/ LOI.";
        //        //}
        //        return View("RegComplaintEncldocM", aa);
        //    }
        //    return RedirectToAction("RegComplaintEncldocM");
        //}

        //[HttpPost]
        //public ActionResult RegExecutionEncldocFormM()
        //{
        //    Int64 executioncomplaintId = 0;
        //    Int32 retAbsoluteIsDraft = 1;

        //    if (Session["ApplicationId"] != null && Session["ApplicationId"].ToString() != "0")
        //    {
        //        executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
        //    }

        //    ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
        //    Clsprp_ExecutionForm_Documents aa = new Clsprp_ExecutionForm_Documents();
        //    string userName = User.Identity.Name;

        //    Int64 varGetChk = sdb.Update_Check_ComplaintExecutionForm_Documents(executioncomplaintId, userName);

        //    var docs = sdb.Display_ExecutionForm_Documents_ByExecutionIndex_ID(executioncomplaintId);

        //    var requiredDocs = new List<string>
        //                            {
        //                                "Copy of Jamabandi/ Fard",
        //                                "Details of Bank Accounts",
        //                                "Calculation Sheet of due amount/ Claim",
        //                                "Vakalatnama"
        //                                //"DocumentLOI"
        //                            };

        //    var uploadedDocs = docs.Select(x => x.A_column).ToList();

        //    var missingDocs = requiredDocs.Where(req => !uploadedDocs.Contains(req)).ToList();

        //    bool allDocsUploaded = !missingDocs.Any();

        //    if (varGetChk == 100 && allDocsUploaded)
        //    {
        //        return RedirectToAction("RequestPaymentExecutionForm", "ComplaintPayment");
        //    }
        //    else
        //    {
        //        aa.ComplaintDoc_IssueDate = DateTime.Now;
        //        aa.prpFormM_Docs = docs;

        //        if (docs.Count > 0)
        //        {
        //            foreach (var item in docs)
        //            {
        //                aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
        //                aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
        //                aa.ExecutionIndex_Id = item.ExecutionIndex_Id;
        //                aa.ExecutioncomplaintId = item.ExecutioncomplaintId;

        //                aa.IsActive = item.IsActive;
        //                aa.IsDraft = item.IsDraft;
        //                aa.IsLock = item.IsLock;
        //                aa.IsPublicView = item.IsPublicView;

        //                if (item.IsDraft == 0 || item.IsDraft == 4)
        //                {
        //                    retAbsoluteIsDraft = item.IsDraft;
        //                }
        //            }
        //            aa.IsDraft = retAbsoluteIsDraft;
        //        }

        //        if (!allDocsUploaded)
        //        {
        //            TempData["ComplaintFormMvalidDocName"] =
        //                "Please upload all required documents: " + string.Join(", ", missingDocs);
        //        }
        //        else if (varGetChk == 200)
        //        {
        //            TempData["ComplaintFormMvalidDocName"] =
        //                "Incomplete Complaint Form-Exe Documents, Please upload documents first.";
        //        }
        //        else if (varGetChk == 300)
        //        {
        //            TempData["ComplaintFormMvalidDocName"] =
        //                "Required document types are missing. Please upload mandatory documents.";
        //        }

        //        return View("RegExecutionEncldocM", aa);
        //    }
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult ComplaintFormMDocumentFormUpload(HttpPostedFileBase uploadedFile, Clsprp_ExecutionForm_Documents smodel)
        //{
        //    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
        //    {
        //        var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToList();

        //        if (ModelState.IsValid)
        //        {
        //            Clsprp_Master_Execution_Documents clsprp = new Clsprp_Master_Execution_Documents();
        //            ClsMethod_Master_Complaint_Documents objdoc = new ClsMethod_Master_Complaint_Documents();
        //            Clsprp_ExecutionForm_Documents clsprpPrmDoc = new Clsprp_ExecutionForm_Documents();
        //            ClsMethod_ComplaintM_Documents objPromoterDoc = new ClsMethod_ComplaintM_Documents();

        //            Int32 IndexId = 1001;// smodel.ProjectDoc_InfoCode; (with ref to master table data)                   I

        //            Int64 executioncomplaintId = 0;
        //            if (Session["ApplicationId"] != null)
        //            {
        //                if (Session["ApplicationId"].ToString() != "0")
        //                {
        //                    executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
        //                }
        //            }

        //            #region Read Master Data By Document Type

        //            clsprp.prpMasterDocs = objdoc.Display_Master_Complaint_DocumentsByExecutionFormID(IndexId);

        //            Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_ExecutionForm_Documents_ByDocCodeInfo_ExecutionForm_ID(executioncomplaintId, IndexId));

        //            foreach (var item in clsprp.prpMasterDocs)
        //            {
        //                if (item.ExecutionDocMaster_InfoCode == IndexId)
        //                {
        //                    clsprp.ExecutionDocMaster_IndexID = item.ExecutionDocMaster_IndexID;
        //                    clsprp.ExecutioncomplaintId = item.ExecutioncomplaintId;
        //                    clsprp.ExecutionDocMaster_InfoCode = item.ExecutionDocMaster_InfoCode;
        //                    clsprp.ExecutionDocMaster_InfoName = item.ExecutionDocMaster_InfoName;
        //                    clsprp.ExecutionDoc_SetFileSize = item.ExecutionDoc_SetFileSize;
        //                    clsprp.ExecutionDoc_SetFileFormat = item.ExecutionDoc_SetFileFormat;
        //                    clsprp.ExecutionDoc_SetFilePath = item.ExecutionDoc_SetFilePath;
        //                    clsprp.ExecutionDoc_ValidCode = item.ExecutionDoc_ValidCode;
        //                    clsprp.ExecutionDoc_ValidSubCode = item.ExecutionDoc_ValidSubCode;
        //                    clsprp.ExecutionDoc_ValidTinySubCode = item.ExecutionDoc_ValidTinySubCode;
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
        //            string masterPromoterDoc_SetFilePath = "readwriteExecutionFormDoc";
        //            bool IsValidFileType = false;
        //            #endregion

        //            //Bad Request - No Doc
        //            if (Request.Files.Count > 0)
        //            {
        //                var PhotoIdentityDocument = Request.Files[0];

        //                //Bad Request - No Doc OR No Size
        //                if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
        //                {
        //                    //clsprp.ExecutionDoc_SetFilePath = "readwriteExecutionFormDoc";
        //                    #region SaveFile Path Creation
        //                    if (clsprp.ExecutionDoc_SetFilePath.ToString() != string.Empty || clsprp.ExecutionDoc_SetFilePath.ToString() != null)
        //                    {
        //                        masterPromoterDoc_SetFilePath = clsprp.ExecutionDoc_SetFilePath.ToString();
        //                    }
        //                    pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(executioncomplaintId) + "\\";
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
        //                    masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ExecutionDoc_SetFileFormat);
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
        //                        if (IsValidFileType)
        //                        {
        //                            if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ExecutionDoc_SetFileSize))
        //                            {
        //                                byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

        //                                if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ExecutionDoc_SetFileSize))
        //                                {
        //                                    savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ExecutionDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
        //                                    var pathsavefile = Path.Combine(path, savefileName);
        //                                    PhotoIdentityDocument.SaveAs(pathsavefile);

        //                                    var pathsavedb = Path.Combine(pathindb, savefileName);

        //                                    Int64 inForm_ExecutionID = executioncomplaintId;
        //                                    string inFormDoc_FilePath = pathsavedb;
        //                                    string inFormDoc_FileName = savefileName;
        //                                    string inFormDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
        //                                    string inFormDoc_FileFormat = extensionPhotoIdentityDocument;
        //                                    Int32 inFormDoc_IsGroup = Convert.ToInt32(clsprp.IsGroup);
        //                                    smodel.ExecutionIndex_Id = inForm_ExecutionID;
        //                                    smodel.ExecutioncomplaintId = inForm_ExecutionID;

        //                                    bool varRet = SaveExecutionFormDocuments(smodel, inForm_ExecutionID, inFormDoc_FilePath, inFormDoc_FileName, inFormDoc_FileSize, inFormDoc_FileFormat, inFormDoc_IsGroup);

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
        //                                    varSetFileSize = Convert.ToInt32(clsprp.ExecutionDoc_SetFileSize);

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
        //                                    status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
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


        //      document saving 
        //private bool SaveExecutionFormDocuments(Clsprp_ExecutionForm_Documents smodel,Int64 z_ComplaintFormM_ID, String z_ComplaintFormDoc_FilePath, String z_ComplaintFormDoc_FileName, String z_ComplaintFormDoc_FileSize, String z_ComplaintFormDoc_FileFormat, Int32 z_ComplaintFormDoc_IsGroup)
        //{
        //    Int64 FormMN_ID = 0;
        //    FormMN_ID = z_ComplaintFormM_ID;
        //    string FormMNDoc_FilePath = String.IsNullOrEmpty(z_ComplaintFormDoc_FilePath) ? string.Empty : z_ComplaintFormDoc_FilePath;
        //    string FormMNDoc_FileName = String.IsNullOrEmpty(z_ComplaintFormDoc_FileName) ? string.Empty : z_ComplaintFormDoc_FileName;
        //    string FormMNDoc_FileSize = String.IsNullOrEmpty(z_ComplaintFormDoc_FileSize) ? string.Empty : z_ComplaintFormDoc_FileSize;
        //    string FormMNDoc_FileFormat = String.IsNullOrEmpty(z_ComplaintFormDoc_FileFormat) ? string.Empty : z_ComplaintFormDoc_FileFormat;
        //    Int32 FormMNDoc_IsGroup = z_ComplaintFormDoc_IsGroup;
        //    Int64 ExecutionProfileID = 0;

        //    string UID = User.Identity.GetUserId();
        //    string userName = User.Identity.Name;


        //    bool varRET = false;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ClsMethod_ComplaintM_Documents savedb = new ClsMethod_ComplaintM_Documents();
        //            if (savedb.Add_ExecutionForm_Documents(smodel, FormMN_ID, FormMNDoc_FilePath, FormMNDoc_FileName, FormMNDoc_FileSize, FormMNDoc_FileFormat, FormMNDoc_IsGroup, ExecutionProfileID, UID, userName))
        //            {
        //                varRET = true;
        //                ModelState.Clear();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string varExMsg = ex.Message;
        //        varRET = false;
        //    }
        //    return varRET;
        //}

        ////GET: Delete
        //public ActionResult Delete_ExecutionEncldocDocument(Int64 inExecutionForm_DocIndexID)
        //{
        //    try
        //    {
        //        ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
        //        if (sdb.Delete_ExecutionForm_Document(inExecutionForm_DocIndexID))
        //        {
        //            TempData["message"] = " Document deleted Successfully";
        //            //ViewBag.AlertMsg = " Details Deleted Successfully";
        //        }
        //        return RedirectToAction("RegExecutionEncldocM");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("RegExecutionEncldocM");
        //    }
        //}
        #endregion


        #region Step-IV Form-M Verify
        //[HttpGet]
        //public ActionResult RegComplaintExecutionVerification()
        //{
        //    Int64 ComplaintExeProfile_Id = 0;
        //    Int64 ExecutionIndexId = 0;
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    if (Session["execution_IndexId"] != null)
        //    {
        //        if (Session["execution_IndexId"].ToString() != "0")
        //        {
        //            ExecutionIndexId = Convert.ToInt64(Session["execution_IndexId"]);
        //        }
        //    }

        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

        //    objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ExecutionForm_Flag_RegStep(ComplaintExeProfile_Id);

        //    if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
        //    {
        //        foreach (var item in objflagstep.ComplaintFormMstepFlag)
        //        {
        //            objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
        //            objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
        //            objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
        //            objflagstep.Profile_Id = item.Profile_Id;
        //            objflagstep.User_ID = item.User_ID;
        //            objflagstep.ComplaintType = item.ComplaintType;

        //            objflagstep.IsComplaintComplete = item.IsComplaintComplete;
        //            objflagstep.IsPaymentComplete = item.IsPaymentComplete;
        //            objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
        //            objflagstep.IsVerificationComplete = item.IsVerificationComplete;
        //            objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

        //            objflagstep.IsActive = item.IsActive;
        //            objflagstep.IsDraft = item.IsDraft;
        //            objflagstep.IsLock = item.IsLock;
        //            objflagstep.IsPublicView = item.IsPublicView;
        //            objflagstep.CreatedBy = item.CreatedBy;
        //            objflagstep.CreatedOn = item.CreatedOn;
        //            objflagstep.ModifyBy = item.ModifyBy;
        //            objflagstep.ModifyOn = item.ModifyOn;
        //        }
        //    }
        //    if (objflagstep.IsVerificationComplete == 0)
        //    {
        //        objflagstep.ComplaintVerificationDate = DateTime.Now;
        //    }
        //    objflagstep.ComplaintVerificationDate = DateTime.Now;
        //    TempData["ComplaintMRegDiaryNumber_Name"] = "";
        //    TempData["ComplaintMRegDiaryNumber_Validate"] = "";
        //    return View(objflagstep);
        //}

        //[HttpPost]
        //public ActionResult RegComplaintExecutionVerification(ClsPrp_ExecutionForm_FlagStep smodel)
        //{
        //    string UID = User.Identity.GetUserId();
        //    string userName = User.Identity.Name;

        //    ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();

        //    Int64 executioncomplaintId = 0;
        //    Int64 ExecutionIndexId = 0;
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    if (Session["execution_IndexId"] != null)
        //    {
        //        if (Session["execution_IndexId"].ToString() != "0")
        //        {
        //            ExecutionIndexId = Convert.ToInt64(Session["execution_IndexId"]);
        //        }
        //    }
        //    string ValidateComplaint = sdb.ValidateComplaintExecutionForm_AgreeDetails(executioncomplaintId, UID);
        //    //if (ValidateComplaint == "FormM1001")
        //    //{
        //    //    TempData["ComplaintMRegDiaryNumber_Name"] = "";
        //    //    TempData["ComplaintMRegDiaryNumber_Validate"] = "Invalid reference document(s) of un-registered Project! Please Submit Complaint Form-M (Step-I and II) First.";
        //    //}
        //    //else
        //    //{
        //    //// "0"; // 
        //    string Profile = sdb.UpdateComplaintExecutionForm_AgreeDetails(smodel, executioncomplaintId, ExecutionIndexId, UID, userName);

        //    //if (Profile == "0")
        //    //{
        //    //    TempData["ComplaintMRegDiaryNumber_Name"] = "Incomplete Complaint Form-M, Please Submit Complaint Form-M First.";
        //    //}
        //    if (Profile != null)
        //    {
        //        TempData["ComplaintMRegDiaryNumber_Name"] = "Your Complaint Form-M successfully Submitted with diary number : " + Profile + " keep it for future reference, Thanks.";
        //        //await UserManager.SendEmailAsync(UID, "RERA, Punjab - Complaint Application (Form-M) Registration", "<b>Dear " + userName + "</b>,<br /><br /> Your Complaint Application with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />You are requested to log in to the RERA, Punjab web portal and check the complainant dashboard for further details, and actions required to be taken. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
        //    }
        //    //else
        //    //{
        //    //    TempData["ComplaintMRegDiaryNumber_Name"] = "Sorry, Your Complaint Form-M is pending";
        //    //}
        //    //}
        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    objflagstep.ComplaintFormMstepFlag = sdb.Display_ExecutionForm_Flag_RegStep(executioncomplaintId);

        //    if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
        //    {
        //        foreach (var item in objflagstep.ComplaintFormMstepFlag)
        //        {
        //            objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
        //            objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
        //            objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
        //            objflagstep.Profile_Id = item.Profile_Id;
        //            objflagstep.User_ID = item.User_ID;
        //            objflagstep.ComplaintType = item.ComplaintType;

        //            objflagstep.IsComplaintComplete = item.IsComplaintComplete;
        //            objflagstep.IsPaymentComplete = item.IsPaymentComplete;
        //            objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
        //            objflagstep.IsVerificationComplete = item.IsVerificationComplete;
        //            objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

        //            objflagstep.IsActive = item.IsActive;
        //            objflagstep.IsDraft = item.IsDraft;
        //            objflagstep.IsLock = item.IsLock;
        //            objflagstep.IsPublicView = item.IsPublicView;
        //            objflagstep.CreatedBy = item.CreatedBy;
        //            objflagstep.CreatedOn = item.CreatedOn;
        //            objflagstep.ModifyBy = item.ModifyBy;
        //            objflagstep.ModifyOn = item.ModifyOn;
        //        }
        //    }

        //    return View("RegComplaintExecutionVerification", objflagstep);
        //}
        #endregion


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







        #region Link Movement Form-M
        public string Get_ComplaintFormM_FlagStep()
        {
            string retSTR = string.Empty;
            Int64 Executioncomplaint_id = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsPrp_ComplaintExecutionForm_PaymentIntegration objflagpay = new ClsPrp_ComplaintExecutionForm_PaymentIntegration();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
            ClsMethod_ComplaintFormM_PaymentIntegration objForm = new ClsMethod_ComplaintFormM_PaymentIntegration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ExecutionForm_Flag_RegStep(Executioncomplaint_id);
            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                    objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                    objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                    objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                    objflagstep.Profile_Id = item.Profile_Id;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType = item.ComplaintType;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsActiveProvider = item.IsActiveProvider;
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
                retSTR = "Step1M"; // "RegExecutionForm"; // 
            }
            return retSTR;
        }

        public string Get_ComplaintFormM_FlagStep(Int64 mComplaintFormM_ID)
        {
            string retSTR = string.Empty;
            Int64 Executioncomplaint_id = mComplaintFormM_ID;

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();


            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ExecutionForm_Flag_RegStep(Executioncomplaint_id);

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                    objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                    objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                    objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                    objflagstep.Profile_Id = item.Profile_Id;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType = item.ComplaintType;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsActiveProvider = item.IsActiveProvider;
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

        #region Bench
        [HttpGet]
        public JsonResult Benchname()
        {
            ClsPrp_Master_HearingBenchDetails aa = new ClsPrp_Master_HearingBenchDetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.prpongoing = objdis.dropdownlist_HearingBenchList().ToList();

            return Json(aa, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region DASHBOARD

        [HttpGet]
        public ActionResult ComplaintExeDashboard()
        {
            //Int64 ComplainantProfile_id = 0;
            Int64 executioncomplaintId = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    executioncomplaintId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }


            ClsMethod_ComplaintM_DiaryNumberDashbaord sdb = new ClsMethod_ComplaintM_DiaryNumberDashbaord();
            ClsPrp_ComplaintFormExe_DiaryNumberDashbaord aa = new ClsPrp_ComplaintFormExe_DiaryNumberDashbaord();

            aa.prpongoing = sdb.Display_ComplaintFormExe_RegDiaryNumberByProfileID(executioncomplaintId, "");

            return View("ComplaintExeDashboard", aa);
        }

        #endregion



        #region NEW EXECUTION CODE
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


        #region STEP 1

        #region Form Creation

        [TrackActivity]
        [HttpGet]
        public ActionResult RegExecutionForm()
        {
            Int64 ComplaintExeProfile_Id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Int64 zComplaintFormM_ID = Convert.ToInt64(Session["ComplaintFormM_ID"]);

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            try
            {
                aa.districtMaster = objdis.dropdownlist_display1();
                aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
                aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
                aa.stateMaster = objdis.State_list();

                aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplaintExeProfile_Id);
                if (aa.Complainant_UserProfile.Count >= 1)
                {
                    foreach (var item in aa.Complainant_UserProfile)
                    {
                        //Applicant = Complainant
                        aa.Profile_Id = item.ComplaintProfile_ID;
                        aa.User_ID = item.UserID;
                        aa.Applicant_FirstName = item.Applicant_FirstName;
                        aa.Applicant_LastName = item.Applicant_LastName;
                        aa.Applicant_EmailAddress = item.EmailAddress;
                        aa.Applicant_AddressLine1 = item.Residencial_Official_AddressLine1;
                        aa.Applicant_AddressLine2 = item.Residencial_Official_AddressLine2;
                        aa.Applicant_StateCode = Convert.ToString(item.Residencial_Official_AddressStateCode);
                        aa.Applicant_AddressDistrictCode = Convert.ToString(item.Residencial_Official_AddressDistrictCode);
                        aa.Applicant_AddressPin = item.Residencial_Official_AddressPIN;
                    }
                }
                else
                {
                    return RedirectToAction("RegComplaintProfileNA", "Complaint");
                }

                Int64 Executioncomplaint_id = 0;
                if (Session["ExecutionForm_ID"] != null)
                {
                    if (Session["ExecutionForm_ID"].ToString() != "0")
                    {
                        Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                    }
                }
                string userName = User.Identity.Name;

                aa.ExecutionFormstepI = objFormAppM.Display_ExecutionForm_Registration_StepI(Executioncomplaint_id);
                if (aa.ExecutionFormstepI.Count >= 1)
                {
                    foreach (var item in aa.ExecutionFormstepI)
                    {
                        aa.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                        aa.ExecutionForm_ID = item.ExecutionForm_ID;
                        aa.ExecutionForm_Code = item.ExecutionForm_Code;
                        aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                        aa.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                        aa.Related_FormExe_Year = item.Related_FormExe_Year;
                        aa.Profile_Id = item.Profile_Id;
                        aa.User_ID = item.User_ID;
                        aa.ComplaintType = item.ComplaintType;

                        aa.IsComplaintComplete = item.IsComplaintComplete;
                        aa.IsDocumentsComplete = item.IsDocumentsComplete;
                        aa.IsPaymentComplete = item.IsPaymentComplete;
                        aa.IsVerificationComplete = item.IsVerificationComplete;

                        aa.Applicant_FirstName = item.Applicant_FirstName;
                        aa.Applicant_MiddleName = item.Applicant_MiddleName;
                        aa.Applicant_LastName = item.Applicant_LastName;
                        aa.Applicant_EmailAddress = item.Applicant_EmailAddress;
                        aa.Applicant_AddressLine1 = item.Applicant_AddressLine1;
                        aa.Applicant_AddressLine2 = item.Applicant_AddressLine2;
                        aa.Applicant_StateCode = item.Applicant_StateCode;
                        aa.Applicant_AddressDistrictCode = item.Applicant_AddressDistrictCode;
                        aa.Applicant_AddressPin = item.Applicant_AddressPin;

                        // Complainant
                        aa.Complaint_Number = item.Complaint_Number;
                        aa.Complainant_FirstName = item.Complainant_FirstName;
                        aa.Complainant_MiddleName = item.Complainant_MiddleName;
                        aa.Complainant_LastName = item.Complainant_LastName;
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

                        // Respondant
                        aa.Respondent_FirstName = item.Respondent_FirstName;
                        aa.Respondent_MiddleName = item.Respondent_MiddleName;
                        aa.Respondent_LastName = item.Respondent_LastName;
                        aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
                        aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
                        aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;
                        aa.Respondent_AadhaarNumber = item.Respondent_AadhaarNumber;

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

                        aa.Date_of_Order = item.Date_of_Order;
                        aa.Bench_Name = item.Bench_Name;
                        aa.Compliance_FromDate = item.Compliance_FromDate;
                        aa.Compliance_ToDate = item.Compliance_ToDate;
                        aa.Appeal_Information = item.Appeal_Information;
                        aa.Payment_AdjustmentDetails = item.Payment_AdjustmentDetails;
                        aa.Compliance_Status = item.Compliance_Status;
                        aa.Compliance_Document = item.Compliance_Document;
                        aa.Previous_ExecutionDetails = item.Previous_ExecutionDetails;
                        aa.Principal_Amount = item.Principal_Amount;
                        aa.Interest_Amount = item.Interest_Amount;
                        aa.Cost_Amount = item.Cost_Amount;
                        aa.Total_Amount = item.Total_Amount;
                        aa.Mode_of_AssistanceRequired = item.Mode_of_AssistanceRequired;
                        aa.Property_Details = item.Property_Details;
                        aa.Respondent_BankDetails = item.Respondent_BankDetails;
                        aa.Other_RelevantDetails = item.Other_RelevantDetails;
                        aa.Declaration_Signed = item.Declaration_Signed;


                        aa.Remarks_IfAny = item.Remarks_IfAny;
                        aa.A_column = item.A_column;
                        aa.B_column = item.B_column;
                        aa.C_column = item.C_column;
                        aa.IsActive = item.IsActive;
                        aa.IsDraft = item.IsDraft;
                        aa.IsLock = item.IsLock;
                        aa.IsActiveProvider = item.IsActiveProvider;
                        aa.IsPublicView = item.IsPublicView;
                        aa.CreatedBy = item.CreatedBy;
                        aa.CreatedBy = item.CreatedBy;
                        aa.ModifyBy = item.ModifyBy;
                        aa.ModifiedOn = item.ModifiedOn;
                    }
                }
            }

            catch (Exception ex)
            {
                string ext = ex.ToString();
            }

            if (aa.ExecutionFormstepI.Count >= 1)
            {
                TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
            }
            // ActivityLogger.LogEventActivity(userID, "Create_RegExecutionForm", "ComplaintExecution");
            return View(aa);
        }

        [HttpPost] //[ValidateInput(false)]        
        public ActionResult RegExecutionForm(ClsPrp_ExecutionApplication smodel, HttpPostedFileBase ComplianceFile)
        {
            string UID = User.Identity.GetUserId();
            Int64 FormM_Id = 0;
            int Form_SequenceId = 0;
            int Form_YearId = 0;
            string userName = User.Identity.Name;
            Int64 ComplaintExeProfile_Id = 0;

            if (Session["ApplicationId"] == null || Session["ApplicationId"].ToString() == "0" || Session["User_Type"] == null)
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);


            if (Session["ComplaintFormM_ID"] == null || Session["ComplaintFormM_ID"].ToString() == "0")
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);


            // Optional
            if (Session["ExecutionForm_SequenceID"] != null && Session["ExecutionForm_SequenceID"].ToString() != "0")
            {
                Form_SequenceId = Convert.ToInt32(Session["ExecutionForm_SequenceID"]);
            }

            if (Session["ExecutionForm_Year"] != null && Session["ExecutionForm_Year"].ToString() != "0")
            {
                Form_YearId = Convert.ToInt32(Session["ExecutionForm_Year"]);
            }
            //bool varFlag_FactsCase = false;

            ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            #region Save & Update         
            if (TempData["submitvalueFormMStep1"].ToString() == "Update")
            {
                try
                {
                    if (ComplianceFile == null || ComplianceFile.ContentLength == 0)
                    {
                        ModelState.AddModelError("ComplianceFile", "Please upload Compliance Document.");
                    }
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                    if (ModelState.IsValid)
                    {
                        if (ComplianceFile != null && ComplianceFile.ContentLength > 0)
                        {
                            int maxSize = 1 * 1024 * 1024;

                            if (ComplianceFile.ContentLength > maxSize)
                            {
                                ModelState.AddModelError("ComplianceFile", "Compliance document size must be less than 1 MB.");
                                PopulateMasters(smodel);
                                return View(smodel);
                            }
                            string ext = Path.GetExtension(ComplianceFile.FileName).ToLower();
                            if (ext != ".pdf" && ext != ".jpg" && ext != ".jpeg")
                            {
                                ModelState.AddModelError("ComplianceFile", "Only PDF or JPG files are allowed.");
                                return View(smodel);
                            }
                            string folder = "~/readwriteFormMDoc/" + ComplaintExeProfile_Id + "/";
                            string serverPath = Server.MapPath(folder);

                            if (!Directory.Exists(serverPath))
                            {
                                Directory.CreateDirectory(serverPath);
                            }

                            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss_") + Path.GetFileName(ComplianceFile.FileName);

                            string fullPath = Path.Combine(serverPath, fileName);
                            ComplianceFile.SaveAs(fullPath);

                            smodel.Compliance_Document = folder + fileName;
                        }
                        smodel.Related_FormExe_SequenceID = Form_SequenceId;
                        smodel.Related_FormExe_Year = Form_YearId;
                        objFormAppM.Update_ExecutionForm_Registration_StepI(smodel, UID, userName, FormM_Id);
                        TempData["message"] = "Details Updated Successfully";

                        Session["ExecutionComplaintId"] = smodel.ExecutionForm_ID;

                        ModelState.Clear();
                    }

                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentFormM";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                    }

                    //return RedirectToAction("RegComplaintFormM");
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    //PopulateMasters(smodel);
                    //string strex = ex.ToString();
                    //TempData["message"] = "Bad Request, Try Again!";
                    ////return View();
                    //return View("RegExecutionForm", smodel);
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    return View();
                }
            }
            else
            {
                try
                {
                    if (ComplianceFile == null || ComplianceFile.ContentLength == 0)
                    {
                        ModelState.AddModelError("ComplianceFile", "Please upload Compliance Document.");
                    }

                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                    if (ModelState.IsValid)
                    {
                        if (ComplianceFile != null && ComplianceFile.ContentLength > 0)
                        {
                            int maxSize = 1 * 1024 * 1024;

                            if (ComplianceFile.ContentLength > maxSize)
                            {
                                ModelState.AddModelError("ComplianceFile", "Compliance document size must be less than 1 MB.");
                                PopulateMasters(smodel);
                                return View(smodel);
                            }
                            string ext = Path.GetExtension(ComplianceFile.FileName).ToLower();
                            if (ext != ".pdf" && ext != ".jpg" && ext != ".jpeg")
                            {
                                ModelState.AddModelError("ComplianceFile", "Only PDF or JPG files are allowed.");
                                return View(smodel);
                            }
                            string folder = "~/readwriteFormMDoc/" + ComplaintExeProfile_Id + "/";
                            string serverPath = Server.MapPath(folder);

                            if (!Directory.Exists(serverPath))
                            {
                                Directory.CreateDirectory(serverPath);
                            }

                            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss_") + Path.GetFileName(ComplianceFile.FileName);

                            string fullPath = Path.Combine(serverPath, fileName);
                            ComplianceFile.SaveAs(fullPath);

                            smodel.Compliance_Document = folder + fileName;
                        }

                        var result = objFormAppM.Add_ExecutionForm_Registration_StepI(smodel, UID, userName, FormM_Id);

                        if (result.Item1 > 0)
                        {
                            Int64 Appid = result.Item1;
                            int Related_FormExe_SequenceID = result.Item2;
                            int Related_FormExe_Year = result.Item3;

                            ViewBag.ApplicationId = Appid;
                            ViewBag.Related_FormExe_SequenceID = Related_FormExe_SequenceID;
                            ViewBag.Related_FormExe_Year = Related_FormExe_Year;

                            Session["ExecutionForm_ID"] = Appid;
                            Session["ExecutionForm_SequenceID"] = Related_FormExe_SequenceID;
                            Session["ExecutionForm_Year"] = Related_FormExe_Year;
                            smodel.ExecutionForm_ID = Appid;

                            ViewBag.Message = "Details Successfully Submitted";
                            TempData["message"] = "Details Successfully Submitted";

                            ModelState.Clear();
                        }

                    }

                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                    }
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    PopulateMasters(smodel);
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    return View("RegExecutionForm", smodel);
                    //return View();
                }
            }
            #endregion
        }

        //[TrackActivity]
        //[HttpGet]
        //public ActionResult Create_RegExecutionForm(Int64 zComplaintFormM_ID, Int64 zComplaintProfile_ID)
        //{
        //    Int64 ComplainantProfile_id = 0;
        //    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("SessionExpire", "Account");
        //    }
        //    string userName = User.Identity.Name;
        //    Session["ComplaintFormM_ID"] = zComplaintFormM_ID;

        //    ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
        //    ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

        //    ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

        //    try
        //    {
        //        aa.districtMaster = objdis.dropdownlist_display1();
        //        aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
        //        aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
        //        aa.stateMaster = objdis.State_list();
        //        aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);

        //        aa.ExecutionFormstepIPreFetch = objFormAppM.Display_ExecutionForm_Registration_StepIM(zComplaintFormM_ID);
        //        aa.ExecutionFormstepI = objFormAppM.Display_ExecutionForm_Registration_SteppI(zComplaintFormM_ID);
        //        //Session["ComplaintForMIdExe"] = 6018;

        //        //if (aa.Complainant_UserProfile.Count >= 1)
        //        //{
        //        //    foreach (var item in aa.Complainant_UserProfile)
        //        //    {

        //        //        aa.Profile_Id = item.ComplaintProfile_ID;
        //        //        aa.User_ID = item.UserID;
        //        //        aa.Applicant_FirstName = item.Applicant_FirstName;
        //        //        aa.Applicant_LastName = item.Applicant_LastName;
        //        //        aa.Applicant_EmailAddress = item.EmailAddress;

        //        //        aa.Applicant_AddressLine1 = item.Residencial_Official_AddressLine1;
        //        //        aa.Applicant_AddressLine2 = item.Residencial_Official_AddressLine2;
        //        //        aa.Applicant_StateCode = Convert.ToString(item.Residencial_Official_AddressStateCode);
        //        //        aa.Applicant_AddressDistrictCode = Convert.ToString(item.Residencial_Official_AddressDistrictCode);
        //        //        aa.Applicant_AddressPin = item.Residencial_Official_AddressPIN;
        //        //    }
        //        //    aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
        //        //    aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
        //        //}
        //        if (aa.ExecutionFormstepIPreFetch.Count >= 1)
        //        {
        //            foreach (var item in aa.ExecutionFormstepIPreFetch)
        //            {
        //                aa.Applicant_FirstName = item.Applicant_FirstName;
        //                aa.Applicant_MiddleName = item.Applicant_MiddleName;
        //                aa.Applicant_LastName = item.Applicant_LastName;
        //                aa.Applicant_EmailAddress = item.Applicant_EmailAddress;
        //                aa.Applicant_AddressLine1 = item.Applicant_AddressLine1;
        //                aa.Applicant_AddressLine2 = item.Applicant_AddressLine2;
        //                aa.Applicant_StateCode = item.Applicant_StateCode;
        //                aa.Applicant_AddressDistrictCode = item.Applicant_AddressDistrictCode;
        //                aa.Applicant_AddressPin = item.Applicant_AddressPin;

        //                // Complainant
        //                aa.Complaint_Number = item.Complaint_Number;
        //                aa.Complainant_FirstName = item.Complainant_FirstName;
        //                aa.Complainant_MiddleName = item.Complainant_MiddleName;
        //                aa.Complainant_LastName = item.Complainant_LastName;
        //                aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
        //                aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
        //                aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
        //                aa.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

        //                aa.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
        //                aa.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
        //                aa.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
        //                aa.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
        //                aa.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;
        //                aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;
        //                aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
        //                aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
        //                aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
        //                aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
        //                aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

        //                aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
        //                aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
        //                aa.AuthorizedRepresentativeCounsel_MobileNumber = item.AuthorizedRepresentativeCounsel_MobileNumber;
        //                aa.AuthorizedRepresentativeCounsel_LandlineFaxNumber = item.AuthorizedRepresentativeCounsel_LandlineFaxNumber;

        //                // Respondant
        //                aa.Respondent_FirstName = item.Respondent_FirstName;
        //                aa.Respondent_MiddleName = item.Respondent_MiddleName;
        //                aa.Respondent_LastName = item.Respondent_LastName;
        //                aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
        //                aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
        //                aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;
        //                aa.Respondent_AadhaarNumber = item.Respondent_AadhaarNumber;

        //                aa.OfficeResRespondent_AddressLine1 = item.OfficeResRespondent_AddressLine1;
        //                aa.OfficeResRespondent_AddressLine2 = item.OfficeResRespondent_AddressLine2;
        //                aa.OfficeResRespondent_AddressStateCode = item.OfficeResRespondent_AddressStateCode;
        //                aa.OfficeResRespondent_AddressDistrictCode = item.OfficeResRespondent_AddressDistrictCode;
        //                aa.OfficeResRespondent_AddressPIN = item.OfficeResRespondent_AddressPIN;
        //                aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = item.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress;
        //                aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
        //                aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
        //                aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
        //                aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
        //                aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

        //                aa.Date_of_Order = item.Date_of_Order;
        //                aa.Bench_Name = item.Bench_Name;
        //                aa.Compliance_FromDate = item.Compliance_FromDate;
        //                aa.Compliance_ToDate = item.Compliance_ToDate;
        //                aa.Appeal_Information = item.Appeal_Information;
        //                aa.Payment_AdjustmentDetails = item.Payment_AdjustmentDetails;
        //                aa.Compliance_Status = item.Compliance_Status;
        //                aa.Compliance_Document = item.Compliance_Document;
        //                aa.Previous_ExecutionDetails = item.Previous_ExecutionDetails;
        //                aa.Principal_Amount = item.Principal_Amount;
        //                aa.Interest_Amount = item.Interest_Amount;
        //                aa.Cost_Amount = item.Cost_Amount;
        //                aa.Total_Amount = item.Total_Amount;
        //                aa.Mode_of_AssistanceRequired = item.Mode_of_AssistanceRequired;
        //                aa.Property_Details = item.Property_Details;
        //                aa.Respondent_BankDetails = item.Respondent_BankDetails;
        //                aa.Other_RelevantDetails = item.Other_RelevantDetails;
        //                aa.Declaration_Signed = item.Declaration_Signed;


        //                aa.Remarks_IfAny = item.Remarks_IfAny;
        //                //aa.A_column = item.A_column;
        //                //aa.B_column = item.B_column;
        //                //aa.C_column = item.C_column;
        //                aa.IsActive = item.IsActive;
        //                aa.IsDraft = item.IsDraft;
        //                aa.IsLock = item.IsLock;
        //                aa.IsPublicView = item.IsPublicView;
        //                aa.CreatedBy = item.CreatedBy;
        //                aa.CreatedBy = item.CreatedBy;
        //                aa.ModifyBy = item.ModifyBy;
        //                aa.ModifiedOn = item.ModifiedOn;
        //            }
        //        }
        //        else
        //        {
        //            aa.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = "0";
        //            aa.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = "0";
        //            return RedirectToAction("RegComplaintProfileNA", "Complaint");
        //        }

        //        Int64 Executioncomplaint_id = 0;
        //        Session["ExecutionComplaintId"] = Executioncomplaint_id;

        //        aa.ExecutionForm_IndexId = 0;
        //        aa.ExecutionForm_ID = 0;
        //        aa.ExecutionForm_Code = string.Empty;
        //        aa.Profile_Id = ComplainantProfile_id;

        //        aa.IsActive = 0;
        //        aa.IsDraft = 0;
        //        aa.IsLock = 0;
        //        aa.IsPublicView = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string ext = ex.ToString();
        //    }

        //    if (aa.ExecutionFormstepI.Count >= 1)
        //    {
        //        TempData["submitvalueFormMStep1"] = "Update"; TempData.Keep();
        //    }
        //    else
        //    {
        //        TempData["submitvalueFormMStep1"] = "Save"; TempData.Keep();
        //    }
        //    return View("RegExecutionForm", aa);
        //}

        [TrackActivity]
        [HttpGet]
        public ActionResult Create_RegExecutionForm(Int64 zComplaintFormM_ID, Int64 zComplaintProfile_ID)//, Int64? ExecutionForm_ID = null)
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

            Session["ComplaintFormM_ID"] = zComplaintFormM_ID;

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            try
            {
                aa.districtMaster = objdis.dropdownlist_display1();
                aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
                aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
                aa.stateMaster = objdis.State_list();
                aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);

                aa.ExecutionFormstepIPreFetch = objFormAppM.Display_ExecutionForm_Registration_StepIM(zComplaintFormM_ID);
                if (aa.ExecutionFormstepIPreFetch == null || aa.ExecutionFormstepIPreFetch.Count == 0)
                {
                    return RedirectToAction("RegComplaintProfileNA", "Complaint");
                }

                if (aa.ExecutionFormstepIPreFetch.Count >= 1)
                {
                    foreach (var item in aa.ExecutionFormstepIPreFetch)
                    {
                        aa.ExecutionForm_IndexId = 0;
                        aa.ExecutionForm_ID = 0;
                        aa.ExecutionForm_Code = string.Empty;
                        aa.Related_ComplaintFormMId = zComplaintFormM_ID;
                        aa.Related_FormExe_SequenceID = 0;
                        aa.Related_FormExe_Year = 0;
                        aa.Profile_Id = ComplainantProfile_id;

                        aa.Applicant_FirstName = item.Applicant_FirstName;
                        aa.Applicant_MiddleName = item.Applicant_MiddleName;
                        aa.Applicant_LastName = item.Applicant_LastName;
                        aa.Applicant_EmailAddress = item.Applicant_EmailAddress;
                        aa.Applicant_AddressLine1 = item.Applicant_AddressLine1;
                        aa.Applicant_AddressLine2 = item.Applicant_AddressLine2;
                        aa.Applicant_StateCode = item.Applicant_StateCode;
                        aa.Applicant_AddressDistrictCode = item.Applicant_AddressDistrictCode;
                        aa.Applicant_AddressPin = item.Applicant_AddressPin;
                        aa.Complaint_Number = item.Complaint_Number;
                        aa.Complainant_FirstName = item.Complainant_FirstName;
                        aa.Complainant_MiddleName = item.Complainant_MiddleName;
                        aa.Complainant_LastName = item.Complainant_LastName;
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
                        aa.Respondent_FirstName = item.Respondent_FirstName;
                        aa.Respondent_MiddleName = item.Respondent_MiddleName;
                        aa.Respondent_LastName = item.Respondent_LastName;
                        aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
                        aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
                        aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;
                        aa.Respondent_AadhaarNumber = item.Respondent_AadhaarNumber;
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


                        aa.Date_of_Order = item.Date_of_Order;
                        aa.Bench_Name = item.Bench_Name;
                        aa.Compliance_FromDate = item.Compliance_FromDate;
                        aa.Compliance_ToDate = item.Compliance_ToDate;
                        aa.Appeal_Information = item.Appeal_Information;
                        aa.Payment_AdjustmentDetails = item.Payment_AdjustmentDetails;
                        aa.Compliance_Status = item.Compliance_Status;
                        aa.Compliance_Document = item.Compliance_Document;
                        aa.Previous_ExecutionDetails = item.Previous_ExecutionDetails;
                        aa.Principal_Amount = item.Principal_Amount;
                        aa.Interest_Amount = item.Interest_Amount;
                        aa.Cost_Amount = item.Cost_Amount;
                        aa.Total_Amount = item.Total_Amount;
                        aa.Mode_of_AssistanceRequired = item.Mode_of_AssistanceRequired;
                        aa.Property_Details = item.Property_Details;
                        aa.Respondent_BankDetails = item.Respondent_BankDetails;
                        aa.Other_RelevantDetails = item.Other_RelevantDetails;
                        aa.Declaration_Signed = item.Declaration_Signed;
                        aa.Remarks_IfAny = item.Remarks_IfAny;
                        aa.IsActive = 0;
                        aa.IsDraft = 0;
                        aa.IsLock = 0;
                        aa.IsActiveProvider = 0;
                        aa.IsPublicView = 0;
                        aa.CreatedBy = item.CreatedBy;
                        aa.CreatedOn = item.CreatedOn;
                        aa.ModifyBy = item.ModifyBy;
                        aa.ModifiedOn = item.ModifiedOn;
                    }
                    // Session for NEW execution
                    Session["ExecutionComplaintId"] = 0;
                    Session["ExecutionForm_ID"] = 0;
                    Session["ExecutionForm_SequenceID"] = null;
                    Session["ExecutionForm_Year"] = null;

                    TempData["submitvalueFormMStep1"] = "Save";
                    TempData.Keep();
                }

            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }

            return View("RegExecutionForm", aa);
        }

        [HttpGet]
        public ActionResult Details_RegComplaintFormEXE(Int64 zComplaintFormM_ID, Int64 zComplaintProfile_ID, Int64 zRelated_ComplaintFormMId, int zRelated_FormExe_SequenceID, int zRelated_FormExe_Year)
        {
            Int64 ComplainantProfile_id = zComplaintProfile_ID;
            Session["ComplaintFormM_ID"] = zRelated_ComplaintFormMId;
            Session["ExecutionForm_SequenceID"] = zRelated_FormExe_SequenceID;
            Session["ExecutionForm_Year"] = zRelated_FormExe_Year;

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsPrp_ExecutionApplication aa = new ClsPrp_ExecutionApplication();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();

            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();


            aa.districtMaster = objdis.dropdownlist_display1();
            aa.districtPunjabMaster = objdis.dropdownlist_display1(28);
            aa.SubdivMaster = objdis.dropdownlist_diplaySubdiv();
            aa.stateMaster = objdis.State_list();
            //  PREFILL
            aa.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);

            if (aa.Complainant_UserProfile.Count >= 1)
            {
                foreach (var item in aa.Complainant_UserProfile)
                {
                    aa.Profile_Id = item.ComplaintProfile_ID;
                    aa.User_ID = item.UserID;
                    aa.Applicant_FirstName = item.Applicant_FirstName;
                    aa.Applicant_LastName = item.Applicant_LastName;
                    aa.Applicant_EmailAddress = item.EmailAddress;

                    aa.Applicant_AddressLine1 = item.Residencial_Official_AddressLine1;
                    aa.Applicant_AddressLine2 = item.Residencial_Official_AddressLine2;
                    aa.Applicant_StateCode = Convert.ToString(item.Residencial_Official_AddressStateCode);
                    aa.Applicant_AddressDistrictCode = Convert.ToString(item.Residencial_Official_AddressDistrictCode);
                    aa.Applicant_AddressPin = item.Residencial_Official_AddressPIN;
                }
            }
            else
            {
                return RedirectToAction("RegComplaintProfileNA", "Complaint");
            }
            Int64 ComplainantFormM_id = zComplaintFormM_ID;
            Session["ExecutionForm_ID"] = ComplainantFormM_id;

            try
            {
                string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                string varFlagStep_ControllerLinkName = string.Empty;
                string varFlagStep_ActionLinkName = string.Empty;

                switch (varFlagStep_LinkName)
                {
                    case "Step1M":
                        varFlagStep_ControllerLinkName = "ComplaintExecution";
                        varFlagStep_ActionLinkName = "RegExecutionForm";
                        break;
                    case "Step2M":
                        varFlagStep_ControllerLinkName = "ComplaintExecution";
                        varFlagStep_ActionLinkName = "RegExecutionEncldocM";
                        break;
                    case "Step3M":
                        varFlagStep_ControllerLinkName = "ComplaintPayment";
                        varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
                        break;
                    case "Step4M":
                        varFlagStep_ControllerLinkName = "ComplaintExecution";
                        varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
                        break;
                    default:
                        varFlagStep_ControllerLinkName = "ComplaintExecution";
                        varFlagStep_ActionLinkName = "RegExecutionForm";
                        break;
                }

                //return RedirectToAction("RegComplaintFormM");
                return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                //return View();
                return View("RegExecutionForm", "ComplaintExecution");
            }
        }

        #endregion

        #region Add more complainant details

        [HttpGet]
        public ActionResult RegAdditionalComplaintFormExe()
        {
            Int64 ComplaintExeProfile_Id = 0;
            Int64 ProfileM_Id = 0;
            Int64 ComplainantFormExe_id = 11; // Blank or New Entry Data
            string TypeFormExe = "FormTypeExe";
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            Int32 IsTempTable = 1;
            Int32 retAbsoluteIsDraft = 1;
            Int64 ComplainantFormMexe_id = 0;
            Int64 FormM_Id = 0;
            Int64 zapprofileid = 0;
            Int64 zapformmid = 0;
            //if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //}


            // 1. RESOLVE SESSION VALUES FIRST — before anything else uses them
            if (Session["ComplaintFormM_ID"] != null && Session["ComplaintFormM_ID"].ToString() != "0")
            {
                FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                IsTempTable = 0;
            }
            if (Session["ApplicationId"] != null && Session["ApplicationId"].ToString() != "0")
            {
                ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
            }
            Int64 ExeRelatedId = FormM_Id;

            // 2. THEN copy
            CopyFormMComplainantsToExecution(ProfileM_Id, ExeRelatedId, UID, UserNam);

            //if (Session["Profile_Id"] != null )
            //{
            //    if (Session["Profile_Id"].ToString() != "0")
            //    {
            //        zapprofileid = Convert.ToInt64(Session["Profile_Id"]);
            //    }
            //}
            //if (Session["zapComplaintFormM_ID"] != null)
            //{
            //    if (Session["zapComplaintFormM_ID"].ToString() != "0")
            //    {
            //        zapformmid = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
            //        IsTempTable = 0;
            //    }
            //}

            //ComplainantFormMexe_id = Convert.ToInt64(Session["ComplaintForMIdExe"]);
            //IsTempTable = 0;


            //COMMING FROM FORM-ManageController EVENTINFOINSERT
            //string zapdiarynumber = Session["zapFormMDiaryNumber"].ToString();
            //zapformmid = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
            //zapprofileid= Convert.ToInt64(Session["Profile_Id"]);


            ClsPrp_ComplaintFormExe_Addmore_Complainant aa = new ClsPrp_ComplaintFormExe_Addmore_Complainant();
            //ClsPrp_ComplaintFormMN_Addmore_Complainant aa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();

            //aa.FormExe_Complainant = sdb.Display_ComplainantExe_Detail(ProfileM_Id, FormM_Id, TypeFormM, UID, IsTempTable);
            aa.FormExe_Complainant = sdb.Display_ComplainantExe_Detail(ProfileM_Id, ExeRelatedId, TypeFormExe, UID, IsTempTable);
            //aa.FormMN_Complainant = sdb.Display_Complainant_Detail(ProfileM_Id, FormM_Id, TypeFormM, UID, IsTempTable);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            if (aa.FormExe_Complainant.Count >= 1)
            {
                foreach (var item in aa.FormExe_Complainant)
                {
                    aa.AdditionComplainant_IndexID = item.AdditionComplainant_IndexID;
                    aa.AdditionComplainant_ID = item.AdditionComplainant_ID;
                    aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                    aa.ComplainantorApplicant_RelatedComplaint_Code = item.ComplainantorApplicant_RelatedComplaint_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_Exe = item.ComplaintType_Exe;

                    //aaa.Name_of_Complainant_or_Applicant = item.Name_of_Complainant_or_Applicant;
                    //aaa.EmailAddress = item.EmailAddress;
                    //aaa.MobileNumber = item.MobileNumber;
                    //aaa.LandlineNumber = item.LandlineNumber;
                    //aaa.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;
                    //aaa.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    //aaa.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    //aaa.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                    //aaa.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                    //aaa.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                    //aaa.IsSameCommunicationAdd_ResOffAdd = item.IsSameCommunicationAdd_ResOffAdd;
                    //aaa.Service_AddressLine1 = item.Service_AddressLine1;
                    //aaa.Service_AddressLine2 = item.Service_AddressLine2;
                    //aaa.Service_AddressStateCode = item.Service_AddressStateCode;
                    //aaa.Service_AddressDistrictCode = item.Service_AddressDistrictCode;
                    //aaa.Service_AddressPIN = item.Service_AddressPIN;
                    //aaa.Remarks_IfAny = item.Remarks_IfAny;
                    //aaa.A_column = item.A_column;
                    //aaa.B_column = item.B_column;
                    //aaa.C_column = item.C_column;

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
                ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
                ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();


                objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ExecutionForm_Flag_RegStep(ComplainantFormExe_id);

                if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
                {
                    foreach (var item in objflagstep.ComplaintFormMstepFlag)
                    {
                        objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                        objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                        objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                        objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                        objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                        objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                        objflagstep.Profile_Id = item.Profile_Id;
                        objflagstep.User_ID = item.User_ID;
                        objflagstep.ComplaintType = item.ComplaintType;

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

            return View("RegAdditionalComplaintFormExe", aa);
        }

        [HttpPost]
        public ActionResult SaveComplainantFormExeDetail(ClsPrp_ComplaintFormExe_Addmore_Complainant[] order)
        {
            Int64 ComplaintExeProfile_Id = 0;
            Int64 ComplainantFormExe_id = 11; // Blank or New Entry Data
            string TypeFormExe = "FormTypeExe";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            bool status = false;
            Int64? chkappid = null;
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ExecutionComplaintId"] != null)
            {
                if (Session["ExecutionComplaintId"].ToString() != "0")
                {
                    ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionComplaintId"]);
                    IsTempTable = 0;
                }
            }

            Int64 ExeRelatedId = 0;
            if (Session["ComplaintFormM_ID"] != null && Session["ComplaintFormM_ID"].ToString() != "0")
                ExeRelatedId = Convert.ToInt64(Session["ComplaintFormM_ID"]);

            ClsPrp_ComplaintFormExe_Addmore_Complainant aa = new ClsPrp_ComplaintFormExe_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();
            List<ClsPrp_ComplaintFormExe_Addmore_Complainant> Complainant = new List<ClsPrp_ComplaintFormExe_Addmore_Complainant>();
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();

            if (ModelState.IsValid)
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        ClsPrp_ComplaintFormExe_Addmore_Complainant O = new ClsPrp_ComplaintFormExe_Addmore_Complainant();

                        O.AdditionComplainant_IndexID = 0;
                        O.AdditionComplainant_ID = 0;
                        //O.ComplainantApplicant_RelatedComplaint_ID = ComplainantFormExe_id;
                        //O.ComplainantorApplicant_RelatedComplaint_Code = ComplainantFormExe_id.ToString();
                        O.ComplainantApplicant_RelatedComplaint_ID = ExeRelatedId;
                        O.ComplainantorApplicant_RelatedComplaint_Code = ExeRelatedId.ToString();
                        O.Profile_ID = ComplaintExeProfile_Id;
                        O.User_ID = UID;
                        O.ComplaintType_Exe = TypeFormExe;
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

                        chkappid = sdb.Add_FormExe_Complainant(O, UID, UserNam);
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
            Int64 ComplaintExeProfile_Id = 0;
            Int64 ProfileM_Id = 0;
            Int64 ComplainantFormExe_id = 11; // Blank or New Entry Data
            string TypeFormExe = "FormTypeExe";
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;
            Int64 ComplainantFormMexe_id = 0;
            Int64 FormM_Id = 0;
            Int64 zapprofileid = 0;
            Int64 zapformmid = 0;
            Int64 ExeRelatedId = 0;

            //if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //}
            //if (Session["ExecutionComplaintId"] != null)
            //{
            //    if (Session["ExecutionComplaintId"].ToString() != "0")
            //    {
            //        ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionComplaintId"]);
            //        IsTempTable = 0;
            //    }
            //}

            //if (Session["Profile_Id"] != null )
            //{
            //    if (Session["Profile_Id"].ToString() != "0")
            //    {
            //        zapprofileid = Convert.ToInt64(Session["Profile_Id"]);
            //    }
            //}
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            //if (Session["ExecutionForm_ID"] != null)
            //{
            //    if (Session["ExecutionForm_ID"].ToString() != "0")
            //    {
            //        ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
            //        IsTempTable = 0;
            //    }
            //}

            //if (FormM_Id == 0)
            //{
            //    ExeRelatedId = ComplainantFormExe_id;
            //}
            //else
            //{
            //    ExeRelatedId = FormM_Id;
            //}
            //if (Session["zapComplaintFormM_ID"] != null)
            //{
            //    if (Session["zapComplaintFormM_ID"].ToString() != "0")
            //    {
            //        zapformmid = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
            //        IsTempTable = 0;
            //    }
            //}
            //ComplainantFormMexe_id = Convert.ToInt64(Session["ComplaintForMIdExe"]);
            //IsTempTable = 0;

            ClsPrp_ComplaintFormExe_Addmore_Complainant aa = new ClsPrp_ComplaintFormExe_Addmore_Complainant();
            ClsPrp_ComplaintFormMN_Addmore_Complainant aaa = new ClsPrp_ComplaintFormMN_Addmore_Complainant();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();


            // read EXECUTION's own copy — same id used above
            var complainantList = sdb.Display_ComplainantExe_Detail(ProfileM_Id, FormM_Id, TypeFormExe, UID, 0);          // new

            //string zapdiarynumber = Session["zapFormMDiaryNumber"].ToString();

            aa.FormExe_Complainant = sdb.Display_ComplainantExe_Detail(ProfileM_Id, FormM_Id, TypeFormExe, UID, IsTempTable);
            //aaa.FormMN_Complainant = sdb.Display_Complainant_DetailM(ComplaintExeProfile_Id, ComplainantFormMexe_id, TypeFormM, UID, IsTempTable);
            //aaa.FormMN_Complainant = sdb.Display_Complainant_Detail(ProfileM_Id, FormM_Id, TypeFormM, UID, IsTempTable);
            //aa.districtMaster = objdis.dropdownlist_display1();
            //aa.stateMaster = objdis.State_list();

            // List<ClsPrp_ComplaintFormExe_Addmore_Complainant> complainantList = aa.FormExe_Complainant;       // oLD

            return Json(new { data = complainantList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_AdditionalComplaintFormExe(Int64 inCompM_IndexID, Int64 inCompM_ID, Int64 inProfile_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();
                if (sdb.Delete_FormExe_Complainant(inCompM_ID, inCompM_IndexID, inProfile_ID))
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


        private void CopyFormMComplainantsToExecution(Int64 ProfileM_Id, Int64 ExeRelatedId, string UID, string UserName)
        {
            Int64 FormM_Id = 0;
            // Int64 ComplainantFormExe_id = 0;
            if (Session["ComplaintFormM_ID"] != null && Session["ComplaintFormM_ID"].ToString() != "0")
                FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);

            // if (Session["ExecutionForm_ID"] != null && Session["ExecutionForm_ID"].ToString() != "0")
            // {
            //    ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
            // }
            //if (FormM_Id == 0) return; // nothing to copy from
            if (FormM_Id == 0 || ExeRelatedId == 0)
                return; // bail explicitly instead of letting the SP return an empty set silently
            ClsMethod_ComplaintFormM_Addmore_Complainant sdb = new ClsMethod_ComplaintFormM_Addmore_Complainant();

            // EXECUTION table — what's already copied/saved there
            var existingExe = sdb.Display_ComplainantExe_Detail(ProfileM_Id, FormM_Id, "FormTypeExe", UID, 0)
                               ?? new List<ClsPrp_ComplaintFormExe_Addmore_Complainant>();

            // FORM-M table — the source to copy from (different method, different SP, different table)
            var sourceFormM = sdb.Display_Complainant_Detail(ProfileM_Id, FormM_Id, "FormTypeM", UID, 0);

            if (sourceFormM == null) return;

            foreach (var src in sourceFormM)
            {
                bool alreadyCopied = existingExe.Any(x => x.EmailAddress == src.EmailAddress && x.MobileNumber == src.MobileNumber);

                if (alreadyCopied) continue; // don't duplicate on every modal open

                var O = new ClsPrp_ComplaintFormExe_Addmore_Complainant
                {
                    AdditionComplainant_IndexID = 0,
                    AdditionComplainant_ID = 0,
                    ComplainantApplicant_RelatedComplaint_ID = ExeRelatedId,
                    ComplainantorApplicant_RelatedComplaint_Code = ExeRelatedId.ToString(),
                    Profile_ID = ProfileM_Id,
                    User_ID = UID,
                    ComplaintType_Exe = "FormTypeExecution",
                    Complainant_AadhaarNumber = src.Complainant_AadhaarNumber,
                    Name_of_Complainant_or_Applicant = src.Name_of_Complainant_or_Applicant,
                    EmailAddress = src.EmailAddress,
                    MobileNumber = src.MobileNumber,
                    LandlineNumber = src.LandlineNumber,
                    RegOffice_AddressLine1 = src.RegOffice_AddressLine1,
                    RegOffice_AddressLine2 = src.RegOffice_AddressLine2,
                    RegOffice_AddressStateCode = src.RegOffice_AddressStateCode,
                    RegOffice_AddressDistrictCode = src.RegOffice_AddressDistrictCode,
                    RegOffice_AddressPIN = src.RegOffice_AddressPIN,
                    IsSameCommunicationAdd_ResOffAdd = src.IsSameCommunicationAdd_ResOffAdd,
                    Service_AddressLine1 = src.Service_AddressLine1,
                    Service_AddressLine2 = src.Service_AddressLine2,
                    Service_AddressStateCode = src.Service_AddressStateCode,
                    Service_AddressDistrictCode = src.Service_AddressDistrictCode,
                    Service_AddressPIN = src.Service_AddressPIN,
                    Remarks_IfAny = "",
                    A_column = "",
                    B_column = "",
                    C_column = "",
                    IsActive = 1,
                    IsDraft = 0,
                    IsLock = 0,
                    IsPublicView = 0,
                    IsTempTable = 0
                };

                sdb.Add_FormExe_Complainant(O, UID, UserName);
            }
        }


        #endregion

        #region Add more respondent details

        [HttpGet]
        public ActionResult RegAdditionalRespondentFormExe()
        {
            Int64 ComplaintExeProfile_Id = 0;
            Int64 ProfileM_Id = 0;
            Int64 FormM_Id = 0;
            Int64 ComplainantFormExe_id = 11; // Blank or New Entry Data
            string TypeFormExe = "FormTypeExe";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            Int32 IsTempTable = 1;
            Int32 retAbsoluteIsDraft = 1;

            //if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //}
            //if (Session["ExecutionComplaintId"] != null)
            //{
            //    if (Session["ExecutionComplaintId"].ToString() != "0")
            //    {
            //        ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionComplaintId"]);
            //        IsTempTable = 0;
            //    }
            //}

            // 1.  SESSION VALUES
            if (Session["ComplaintFormM_ID"] != null && Session["ComplaintFormM_ID"].ToString() != "0")
            {
                FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                IsTempTable = 0;
            }
            if (Session["ApplicationId"] != null && Session["ApplicationId"].ToString() != "0")
            {
                ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
            }

            Int64 ExeRelatedId = FormM_Id;

            // 2. THEN copy
            CopyFormMRespondentsToExecution(ProfileM_Id, ExeRelatedId, UID, UserNam);

            ClsPrp_ComplaintFormExe_Addmore_Respondent aa = new ClsPrp_ComplaintFormExe_Addmore_Respondent();
            //ClsPrp_ComplaintFormMN_Addmore_Respondent aa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            aa.FormExe_Respondent = sdb.Display_Respondent_Execution_Detail(ComplaintExeProfile_Id, ComplainantFormExe_id, TypeFormExe, UID, IsTempTable);
            //aa.FormMN_Respondent = sdb.Display_Respondent_Detail(ProfileM_Id, FormM_Id, TypeFormExe, UID, IsTempTable);
            aa.districtMaster = objdis.dropdownlist_display1();
            aa.stateMaster = objdis.State_list();

            if (aa.FormExe_Respondent.Count >= 1)
            {
                foreach (var item in aa.FormExe_Respondent)
                {
                    aa.AdditionRespondent_IndexID = item.AdditionRespondent_IndexID;
                    aa.AdditionRespondent_ID = item.AdditionRespondent_ID;
                    aa.AdditionRespondent_RelatedComplaint_ID = item.AdditionRespondent_RelatedComplaint_ID;
                    aa.AdditionRespondent_RelatedComplaint_Code = item.AdditionRespondent_RelatedComplaint_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;
                    aa.ComplaintType_Exe = item.ComplaintType_Exe;

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
                ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
                ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

                objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ExecutionForm_Flag_RegStep(ComplainantFormExe_id);

                if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
                {
                    foreach (var item in objflagstep.ComplaintFormMstepFlag)
                    {
                        objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                        objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                        objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                        objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                        objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                        objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                        objflagstep.Profile_Id = item.Profile_Id;
                        objflagstep.User_ID = item.User_ID;
                        objflagstep.ComplaintType = item.ComplaintType;

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

            return View("RegAdditionalRespondentFormExe", aa);
        }

        [HttpPost]
        public ActionResult SaveRespondentFormExeDetail(ClsPrp_ComplaintFormExe_Addmore_Respondent[] order)
        {
            Int64 ComplaintExeProfile_Id = 0;
            Int64 ComplainantFormExe_id = 11; // Blank or New Entry Data
            string TypeFormExe = "FormTypeExe";
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            bool status = false;
            Int64? chkappid = null;
            Int32 IsTempTable = 1;

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            if (Session["ExecutionComplaintId"] != null)
            {
                if (Session["ExecutionComplaintId"].ToString() != "0")
                {
                    ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionComplaintId"]);
                    IsTempTable = 0;
                }
            }
            Int64 ExeRelatedId = 0;
            if (Session["ComplaintFormM_ID"] != null && Session["ComplaintFormM_ID"].ToString() != "0")
            {
                ExeRelatedId = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                IsTempTable = 0;
            }
            ClsPrp_ComplaintFormExe_Addmore_Respondent aa = new ClsPrp_ComplaintFormExe_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();
            List<ClsPrp_ComplaintFormExe_Addmore_Respondent> Respondent = new List<ClsPrp_ComplaintFormExe_Addmore_Respondent>();

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();


            if (ModelState.IsValid)
            {
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        ClsPrp_ComplaintFormExe_Addmore_Respondent O = new ClsPrp_ComplaintFormExe_Addmore_Respondent();

                        O.AdditionRespondent_IndexID = 0;
                        O.AdditionRespondent_ID = 0;
                        O.AdditionRespondent_RelatedComplaint_ID = ExeRelatedId;
                        O.AdditionRespondent_RelatedComplaint_Code = ExeRelatedId.ToString();
                        O.Profile_ID = ComplaintExeProfile_Id;
                        O.User_ID = UID;
                        O.ComplaintType_Exe = TypeFormExe;
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

                        chkappid = sdb.Add_FormExe_Respondent(O, UID, UserNam);
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
            Int64 ComplaintExeProfile_Id = 0;
            Int64 ProfileM_Id = 0;
            Int64 ComplainantFormExe_id = 11; // Blank or New Entry Data
            string TypeFormExe = "FormTypeExe";     // fixed
            string TypeFormM = "FormTypeM";
            string UID = User.Identity.GetUserId();
            Int32 IsTempTable = 1;
            Int64 ComplainantFormMexe_id = 0;
            Int64 FormM_Id = 0;

            //if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //}
            //if (Session["ExecutionComplaintId"] != null)
            //{
            //    if (Session["ExecutionComplaintId"].ToString() != "0")
            //    {
            //        ComplainantFormExe_id = Convert.ToInt64(Session["ExecutionComplaintId"]);
            //        IsTempTable = 0;
            //    }
            //}
            //ComplainantFormMexe_id = Convert.ToInt64(Session["ComplaintForMIdExe"]);
            //IsTempTable = 0;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                    IsTempTable = 0;
                }
            }
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            ClsPrp_ComplaintFormExe_Addmore_Respondent aa = new ClsPrp_ComplaintFormExe_Addmore_Respondent();
            ClsPrp_ComplaintFormMN_Addmore_Respondent aaa = new ClsPrp_ComplaintFormMN_Addmore_Respondent();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            // read EXECUTION's own copy, same id/type used everywhere else
            var respondentList = sdb.Display_Respondent_Execution_Detail(ProfileM_Id, FormM_Id, TypeFormExe, UID, IsTempTable);

            aa.FormExe_Respondent = sdb.Display_Respondent_Execution_Detail(ProfileM_Id, FormM_Id, TypeFormM, UID, IsTempTable);
            //aaa.FormMN_Respondent = sdb.Display_Respondent_Detail(ProfileM_Id, FormM_Id, TypeFormM, UID, IsTempTable);

            //List<ClsPrp_ComplaintFormExe_Addmore_Respondent> respondentList = aa.FormExe_Respondent;

            return Json(new { data = respondentList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_AdditionalRespondentFormExe(Int64 inRespM_IndexID, Int64 inRespM_ID, Int64 inProfile_ID)
        {
            bool status = false;
            try
            {
                ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();
                if (sdb.Delete_FormExe_Respondent(inRespM_ID, inRespM_IndexID, inProfile_ID))
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


        private void CopyFormMRespondentsToExecution(Int64 ProfileM_Id, Int64 ExeRelatedId, string UID, string UserName)
        {
            Int64 FormM_Id = 0;
            if (Session["ComplaintFormM_ID"] != null && Session["ComplaintFormM_ID"].ToString() != "0")
                FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);

            if (FormM_Id == 0 || ExeRelatedId == 0)
                return;

            ClsMethod_ComplaintFormM_Addmore_Respondent sdb = new ClsMethod_ComplaintFormM_Addmore_Respondent();

            // EXECUTION table — what's already copied/saved there
            var existingExe = sdb.Display_Respondent_Execution_Detail(ProfileM_Id, ExeRelatedId, "FormTypeExe", UID, 0)
                               ?? new List<ClsPrp_ComplaintFormExe_Addmore_Respondent>();

            // FORM-M table — the source to copy from
            var sourceFormM = sdb.Display_Respondent_Detail(ProfileM_Id, FormM_Id, "FormTypeM", UID, 0);

            if (sourceFormM == null) return;

            foreach (var src in sourceFormM)
            {
                bool alreadyCopied = existingExe.Any(x =>
                    x.EmailAddress == src.EmailAddress && x.MobileNumber == src.MobileNumber);

                if (alreadyCopied) continue;

                var O = new ClsPrp_ComplaintFormExe_Addmore_Respondent
                {
                    AdditionRespondent_IndexID = 0,
                    AdditionRespondent_ID = 0,
                    AdditionRespondent_RelatedComplaint_ID = ExeRelatedId,
                    AdditionRespondent_RelatedComplaint_Code = ExeRelatedId.ToString(),
                    Profile_ID = ProfileM_Id,
                    User_ID = UID,
                    ComplaintType_Exe = "FormTypeExe",
                    Repondant_AadhaarNumber = 0,
                    Name_of_Respondant_or_Applicant = src.Name_of_Respondant_or_Applicant,
                    EmailAddress = src.EmailAddress,
                    MobileNumber = src.MobileNumber,
                    LandlineNumber = src.LandlineNumber,
                    RegOffice_AddressLine1 = src.RegOffice_AddressLine1,
                    RegOffice_AddressLine2 = src.RegOffice_AddressLine2,
                    RegOffice_AddressStateCode = src.RegOffice_AddressStateCode,
                    RegOffice_AddressDistrictCode = src.RegOffice_AddressDistrictCode,
                    RegOffice_AddressPIN = src.RegOffice_AddressPIN,
                    IsSameCommunicationAdd_ResOffAdd = src.IsSameCommunicationAdd_ResOffAdd,
                    Service_AddressLine1 = src.Service_AddressLine1,
                    Service_AddressLine2 = src.Service_AddressLine2,
                    Service_AddressStateCode = src.Service_AddressStateCode,
                    Service_AddressDistrictCode = src.Service_AddressDistrictCode,
                    Service_AddressPIN = src.Service_AddressPIN,
                    Remarks_IfAny = "",
                    A_column = "",
                    B_column = "",
                    C_column = "",
                    IsActive = 1,
                    IsDraft = 0,
                    IsLock = 0,
                    IsPublicView = 0,
                    IsTempTable = 0
                };

                sdb.Add_FormExe_Respondent(O, UID, UserName);
            }
        }

        #endregion


        #endregion


        #region STEP 2

        [HttpGet]
        public ActionResult RegExecutionEncldocM()
        {
            Int64 Executioncomplaint_id = 0;
            Int32 retAbsoluteIsDraft = 1;
            int Related_FormExe_SequenceID = 0;
            int Related_FormExe_Year = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }
            Related_FormExe_SequenceID = Convert.ToInt32(Session["ExecutionForm_SequenceID"]);
            Related_FormExe_Year = Convert.ToInt32(Session["ExecutionForm_Year"]);
            ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
            Clsprp_ExecutionForm_Documents aa = new Clsprp_ExecutionForm_Documents();

            aa.ComplaintDoc_IssueDate = DateTime.Now;
            aa.Related_FormExe_SequenceID = Related_FormExe_SequenceID;
            aa.Related_FormExe_Year = Related_FormExe_Year;

            aa.prpFormM_Docs = sdb.Display_ExecutionForm_Documents_ByExecution_ID(Executioncomplaint_id);
            if (aa.prpFormM_Docs.Count > 0)
            {
                foreach (var item in aa.prpFormM_Docs)
                {
                    aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
                    aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
                    aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                    aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
                    aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    aa.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    aa.Related_FormExe_Year = item.Related_FormExe_Year;
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
            return View("RegExecutionEncldocM", aa);
        }


        [HttpPost]
        public ActionResult RegExecutionEncldocFormM()
        {
            Int64 Executioncomplaint_id = 0;
            Int32 retAbsoluteIsDraft = 1;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }

            ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
            Clsprp_ExecutionForm_Documents aa = new Clsprp_ExecutionForm_Documents();
            string userName = User.Identity.Name;

            Int64 varGetChk = sdb.Update_Check_ComplaintExecutionForm_Documents(Executioncomplaint_id, userName);
            if (varGetChk == 100)
            {
                //Already OR Updated (IsDocComplete = true)
                return RedirectToAction("RequestPaymentExecutionForm", "ComplaintPayment");
            }
            else if (varGetChk == 200)
            {
                // Pending (IsDocComplete = true)
                aa.ComplaintDoc_IssueDate = DateTime.Now;

                aa.prpFormM_Docs = sdb.Display_ExecutionForm_Documents_ByExecution_ID(Executioncomplaint_id);
                if (aa.prpFormM_Docs.Count > 0)
                {
                    foreach (var item in aa.prpFormM_Docs)
                    {
                        aa.ListEnclDocument_IndexID = item.ListEnclDocument_IndexID;
                        aa.ListEnclDocument_ID = item.ListEnclDocument_ID;
                        aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
                        aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
                        aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                        aa.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                        aa.Related_FormExe_Year = item.Related_FormExe_Year;
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
                    TempData["ComplaintFormMvalidDocName"] = "Incomplete Complaint Form-Exe Documents, Please upload Complaint Form-Exe Documents First.";
                }
                if (varGetChk == 300)
                {
                    TempData["ComplaintFormMvalidDocName"] = "Incomplete Complaint Form-Exe Documents, Please upload Complaint Form-Exe Documents First.";
                }
                return View("RegExecutionEncldocM", aa);
            }
            return RedirectToAction("RegExecutionEncldocM");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ComplaintFormMDocumentFormUpload(HttpPostedFileBase uploadedFile, Clsprp_ExecutionForm_Documents smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToList();

                if (ModelState.IsValid)
                {
                    Clsprp_Master_Execution_Documents clsprp = new Clsprp_Master_Execution_Documents();
                    ClsMethod_Master_Complaint_Documents objdoc = new ClsMethod_Master_Complaint_Documents();
                    Clsprp_ExecutionForm_Documents clsprpPrmDoc = new Clsprp_ExecutionForm_Documents();
                    ClsMethod_ComplaintM_Documents objPromoterDoc = new ClsMethod_ComplaintM_Documents();

                    Int32 IndexId = 101;// smodel.ProjectDoc_InfoCode; (with ref to master table data)                   I

                    Int64 Executioncomplaint_id = 0;
                    if (Session["ExecutionForm_ID"] != null)
                    {
                        if (Session["ExecutionForm_ID"].ToString() != "0")
                        {
                            Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                        }
                    }

                    Int64 Related_ComplaintFormMId = Convert.ToInt64(Session["ComplaintFormM_ID"]);

                    #region Read Master Data By Document Type

                    clsprp.prpMasterDocs = objdoc.Display_Master_Complaint_DocumentsByExecutionFormID(IndexId);

                    Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_ExecutionForm_Documents_ByDocCodeInfo_ExecutionForm_ID(Executioncomplaint_id, IndexId));

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
                    string masterPromoterDoc_SetFilePath = "readwriteExecutionFormDoc";
                    bool IsValidFileType = false;
                    #endregion

                    //Bad Request - No Doc
                    if (Request.Files.Count > 0)
                    {
                        var PhotoIdentityDocument = Request.Files[0];

                        //Bad Request - No Doc OR No Size
                        if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                        {
                            //clsprp.ExecutionDoc_SetFilePath = "readwriteExecutionFormDoc";
                            #region SaveFile Path Creation
                            if (clsprp.ComplaintDoc_SetFilePath.ToString() != string.Empty || clsprp.ComplaintDoc_SetFilePath.ToString() != null)
                            {
                                masterPromoterDoc_SetFilePath = clsprp.ComplaintDoc_SetFilePath.ToString();
                            }
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Executioncomplaint_id) + "\\";
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

                                            Int64 inFormM_ID = Executioncomplaint_id;
                                            Int64 zRelated_ComplaintFormMId = Related_ComplaintFormMId;
                                            string inFormDoc_FilePath = pathsavedb;
                                            string inFormDoc_FileName = savefileName;
                                            string inFormDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inFormDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inFormDoc_IsGroup = Convert.ToInt32(clsprp.IsGroup);

                                            bool varRet = SaveExecutionFormDocuments(smodel, inFormM_ID, inFormDoc_FilePath, inFormDoc_FileName, inFormDoc_FileSize, inFormDoc_FileFormat, inFormDoc_IsGroup, zRelated_ComplaintFormMId);

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

        private bool SaveExecutionFormDocuments(Clsprp_ExecutionForm_Documents smodel, Int64 z_ComplaintFormM_ID, String z_ComplaintFormDoc_FilePath, String z_ComplaintFormDoc_FileName, String z_ComplaintFormDoc_FileSize, String z_ComplaintFormDoc_FileFormat, Int32 z_ComplaintFormDoc_IsGroup, Int64 zRelated_ComplaintFormMId)
        {
            Int64 FormMN_ID = 0;
            FormMN_ID = z_ComplaintFormM_ID;
            string FormMNDoc_FilePath = String.IsNullOrEmpty(z_ComplaintFormDoc_FilePath) ? string.Empty : z_ComplaintFormDoc_FilePath;
            string FormMNDoc_FileName = String.IsNullOrEmpty(z_ComplaintFormDoc_FileName) ? string.Empty : z_ComplaintFormDoc_FileName;
            string FormMNDoc_FileSize = String.IsNullOrEmpty(z_ComplaintFormDoc_FileSize) ? string.Empty : z_ComplaintFormDoc_FileSize;
            string FormMNDoc_FileFormat = String.IsNullOrEmpty(z_ComplaintFormDoc_FileFormat) ? string.Empty : z_ComplaintFormDoc_FileFormat;
            Int32 FormMNDoc_IsGroup = z_ComplaintFormDoc_IsGroup;
            Int64 ExecutionProfileID = 0;
            ExecutionProfileID = Convert.ToInt64(Session["ApplicationId"]);
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;


            bool varRET = false;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_ComplaintM_Documents savedb = new ClsMethod_ComplaintM_Documents();
                    if (savedb.Add_ExecutionForm_Documents(smodel, FormMN_ID, FormMNDoc_FilePath, FormMNDoc_FileName, FormMNDoc_FileSize, FormMNDoc_FileFormat, FormMNDoc_IsGroup, ExecutionProfileID, UID, userName, zRelated_ComplaintFormMId))
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

        public ActionResult Delete_ExecutionEncldocDocument(Int64 inComplaintFormExe_DocIndexID, Int64 inComplaintFormExe_DocID, Int64 inComplaintFormExe_ID)
        {
            try
            {
                ClsMethod_ComplaintM_Documents sdb = new ClsMethod_ComplaintM_Documents();
                if (sdb.Delete_ExecutionForm_Document(inComplaintFormExe_DocIndexID, inComplaintFormExe_DocID, inComplaintFormExe_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("RegExecutionEncldocM");
            }
            catch (Exception ex)
            {
                return RedirectToAction("RegExecutionEncldocM");
            }
        }

        #endregion


        #region STEP 4

        [HttpGet]
        public ActionResult RegComplaintExecutionVerification()
        {
            Int64 Executioncomplaint_id = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ExecutionForm_Flag_RegStep(Executioncomplaint_id);

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                    objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                    objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                    objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                    objflagstep.Profile_Id = item.Profile_Id;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType = item.ComplaintType;

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
            objflagstep.ComplaintVerificationDate = DateTime.Now;
            TempData["ComplaintMRegDiaryNumber_Name"] = "";
            TempData["ComplaintMRegDiaryNumber_Validate"] = "";
            return View(objflagstep);
        }

        [HttpPost]
        public async Task<ActionResult> RegComplaintExecutionVerification(ClsPrp_ExecutionForm_FlagStep smodel)
        {
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            ClsMethod_ComplaintFormM_Registration sdb = new ClsMethod_ComplaintFormM_Registration();

            Int64 Executioncomplaint_id = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }


            Int64 ComplaintExeProfile_Id = 0;
            string ValidateComplaint = sdb.ValidateComplaintExecutionForm_AgreeDetails(Executioncomplaint_id, ComplaintExeProfile_Id, UID, userName);
            if (ValidateComplaint == "FormExe1002")
            {
                TempData["ComplaintMRegDiaryNumber_Name"] = "";
                TempData["ComplaintMRegDiaryNumber_Validate"] = "Invalid reference document(s) of un-registered Project! Please Submit Complaint Form-Execution (Step-I and II) First.";
            }
            else
            {
                TempData["ComplaintMRegDiaryNumber_Validate"] = "";
                // "0"; // 
                string Profile = sdb.UpdateComplaintFormExe_AgreeDetails(smodel, Executioncomplaint_id, UID, userName);

                if (Profile == "0")
                {
                    TempData["ComplaintMRegDiaryNumber_Name"] = "Incomplete Complaint Form-Execution, Please Submit Complaint Form-M First.";
                }
                else if (Profile != null)
                {
                    TempData["ComplaintMRegDiaryNumber_Name"] = "Your Complaint Form-Execution successfully Submitted with diary number : " + Profile + " keep it for future reference, Thanks.";
                    await UserManager.SendEmailAsync(UID, "RERA, Punjab - Complaint Application (Form-Execution) Registration", "<b>Dear " + userName + "</b>,<br /><br /> Your Complaint Application with <b>Application ID " + Profile + "</b> has been successfully submitted with the Authority. <br /><br /><br />You are requested to log in to the RERA, Punjab web portal and check the complainant dashboard for further details, and actions required to be taken. <br /><br /><br /> <b>Thanks and Regard,<br /> RERA, Punjab</b> <br /><br />Please do not reply to this e-mail, this is a system generated email.");
                }
                else
                {
                    TempData["ComplaintMRegDiaryNumber_Name"] = "Sorry, Your Complaint Form-M is pending";
                }
            }

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            objflagstep.ComplaintFormMstepFlag = sdb.Display_ExecutionForm_Flag_RegStep(Executioncomplaint_id);

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                    objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                    objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                    objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                    objflagstep.Profile_Id = item.Profile_Id;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType = item.ComplaintType;

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

            return View("RegComplaintExecutionVerification", objflagstep);
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
        #endregion



        #endregion

    }
}
