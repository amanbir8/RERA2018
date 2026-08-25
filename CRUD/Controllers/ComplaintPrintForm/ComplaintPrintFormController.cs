using CRUD.Models.Document;
using CRUD.Models.HelpDesk;
using CRUD.Models.ComplaintPrint;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RazorPDF;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;
using Rotativa;
using CRUD.Models.ComplaintExecution;
using CRUD.Models.Complaint;
using CRUD.Models;

namespace CRUD.Controllers.ComplaintPrint
{
    [Authorize]
    [Authorize(Roles = "Authority, Complainant, SecretaryRERA, LegalAdvisorDesk, PStoMembers, Programmer, ManagerDesk")]
    public class ComplaintPrintFormController : Controller
    {
        #region Print Complaint Form-M Details

        [HttpGet]
        [Authorize(Roles = "Complainant")]        
        public ActionResult Print_ComplaintFormMcodeDetails()
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_PrintComplaintFormM_Documents sdbDoc = new ClsMethod_PrintComplaintFormM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_FormM_Registration aa = new ClsPrp_Print_FormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormM_Id = 0;
            Int64 ProfileM_Id = 0;
            userRole = getUserRole();
            
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    FormM_Id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            aa.prpComplaintFormM = sdbReg.Display_ComplaintFormM_RegistrationByID_ForPrint(FormM_Id, ProfileM_Id);
            aa.prpComplaintFormM_FeeDetail = sdbFee.Display_ComplaintFormM_PaymentByID_ForPrint(FormM_Id, ProfileM_Id);
            aa.prpComplaintFormM_Docs = sdbDoc.Display_ComplaintFormM_Documents_ByComplaintFormMIDbyProfileID_ForPrint(FormM_Id, ProfileM_Id);

            if (aa.prpComplaintFormM.Count > 0)
            {
                aa.prpComplaintFormM_AddMoreComplainant = sdbAddComp.Print_ComplainantFormM_Detail(FormM_Id);
                aa.prpComplaintFormM_AddMoreRespondent = sdbAddResp.Print_RespondentFormM_Detail(FormM_Id);
            }

            foreach (var item in aa.prpComplaintFormM)
            {
                aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;                
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement); 

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;                
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormMcode"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormMcode"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormMDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "Complainant")]        
        public ActionResult Print_ComplaintFormMDetails(Int64? FormMcode)
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_PrintComplaintFormM_Documents sdbDoc = new ClsMethod_PrintComplaintFormM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_FormM_Registration aa = new ClsPrp_Print_FormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormM_Id = 0;
            Int64 ProfileM_Id = 0;
            userRole = getUserRole();

            FormM_Id = FormMcode == null ? 0 : Convert.ToInt64(FormMcode);                
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            aa.prpComplaintFormM = sdbReg.Display_ComplaintFormM_RegistrationByID_ForPrint(FormM_Id, ProfileM_Id);
            aa.prpComplaintFormM_FeeDetail = sdbFee.Display_ComplaintFormM_PaymentByID_ForPrint(FormM_Id, ProfileM_Id);
            aa.prpComplaintFormM_Docs = sdbDoc.Display_ComplaintFormM_Documents_ByComplaintFormMIDbyProfileID_ForPrint(FormM_Id, ProfileM_Id);

            if (aa.prpComplaintFormM.Count > 0)
            {
                aa.prpComplaintFormM_AddMoreComplainant = sdbAddComp.Print_ComplainantFormM_Detail(FormM_Id);
                aa.prpComplaintFormM_AddMoreRespondent = sdbAddResp.Print_RespondentFormM_Detail(FormM_Id);
            }

            foreach (var item in aa.prpComplaintFormM)
            {
                aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormM"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormM"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormMDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormMdeskDetails()
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_PrintComplaintFormM_Documents sdbDoc = new ClsMethod_PrintComplaintFormM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_FormM_Registration aa = new ClsPrp_Print_FormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            //CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //TextInfo textInfo = cultureInfo.TextInfo;
            //textInfo.ToTitleCase(

            string embed = string.Empty;
            string userRole = string.Empty;
            string FormM_DNumber = string.Empty;
            Int64 FormM_Id = 1031; // 0;
            userRole = getUserRole();


            if (Session["zapFormMDiaryNumber"] != null)
            {
                Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormM_ID"]);
                FormM_Id = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;

                FormM_DNumber = Convert.ToString(Session["zapFormMDiaryNumber"]);
            }

            aa.prpComplaintFormM = sdbReg.Display_ComplaintFormM_Registration_ForPrint(FormM_Id);
            aa.FactsCase_Documents = sdbReg.Display_ComplaintFormM_FactsOfTheCase_Document_ByID_ForPrint(FormM_Id, 0, 0, userRole);
            aa.prpComplaintFormM_FeeDetail = sdbFee.Display_ComplaintFormM_Payment_ForPrint(FormM_Id);
            aa.prpComplaintFormM_Docs = sdbDoc.Display_ComplaintFormM_Documents_ByComplaintFormMID_ForPrint(FormM_Id);            

            if (aa.prpComplaintFormM.Count > 0)
            {
                aa.prpComplaintFormM_AddMoreComplainant = sdbAddComp.Print_ComplainantFormM_Detail(FormM_Id);
                aa.prpComplaintFormM_AddMoreRespondent = sdbAddResp.Print_RespondentFormM_Detail(FormM_Id);
            }

            foreach (var item in aa.prpComplaintFormM)
            {
                aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
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
                //TempData["strFactsCase_Statement"] = Escape_HTMLentity(HtmlToPlainText(aa.FactsCase_Statement));
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormMdesk"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormMdesk"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }
            //return View("Print_ComplaintFormMdeskDetails", aa);           
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormMcontentDetails(Int64? FormMcode)
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_PrintComplaintFormM_Documents sdbDoc = new ClsMethod_PrintComplaintFormM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_FormM_Registration aa = new ClsPrp_Print_FormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormM_Id = 0;
            string FormM_DNumber = string.Empty;
            userRole = getUserRole();
            FormM_Id = FormMcode == null ? 0 : Convert.ToInt64(FormMcode);

            aa.prpComplaintFormM = sdbReg.Display_ComplaintFormM_Registration_ForPrint(FormM_Id);
            aa.FactsCase_Documents = sdbReg.Display_ComplaintFormM_FactsOfTheCase_Document_ByID_ForPrint(FormM_Id, 0, 0, userRole);
            aa.prpComplaintFormM_FeeDetail = sdbFee.Display_ComplaintFormM_Payment_ForPrint(FormM_Id);
            aa.prpComplaintFormM_Docs = sdbDoc.Display_ComplaintFormM_Documents_ByComplaintFormMID_ForPrint(FormM_Id);

            if (aa.prpComplaintFormM.Count > 0)
            {
                aa.prpComplaintFormM_AddMoreComplainant = sdbAddComp.Print_ComplainantFormM_Detail(FormM_Id);
                aa.prpComplaintFormM_AddMoreRespondent = sdbAddResp.Print_RespondentFormM_Detail(FormM_Id);
            }

            foreach (var item in aa.prpComplaintFormM)
            {
                aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormMdesk"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormMdesk"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;

                aa.zapRelated_RegDiaryNumber = item.zapRelated_RegDiaryNumber;
            }
            
            //return View("Print_ComplaintFormMdeskDetails", aa);           
            return new RazorPDF.PdfActionResult(aa);

            //string customSwitchesHF = string.Empty;
            //string customString = string.Empty;
            //FormM_DNumber = aa.zapRelated_RegDiaryNumber.ToString();
            //customString = "Diary Number: " + FormM_DNumber;

            //customSwitchesHF = string.Format("--page-offset 0 " +
            //                       "--header-right \"" + customString + "\" " +
            //                       "--header-font-size \"10\" --header-spacing 6 --header-font-name \"calibri light\" " +
            //                       "--footer-right \"Page [page] \"of\" [toPage]\" " +
            //                       "--footer-font-size \"10\" --footer-spacing 6 --footer-font-name \"calibri light\"");

            //var PDFResult = new PartialViewAsPdf(aa)
            //{
            //    PageOrientation = Rotativa.Options.Orientation.Portrait,
            //    PageSize = Rotativa.Options.Size.A4,
            //    MinimumFontSize = 10,
            //    PageMargins = { Left = 12, Bottom = 12, Right = 12, Top = 12 },
            //    CustomSwitches = customSwitchesHF
            //};
            //return PDFResult;
        }

        private IHtmlString Escape_HTMLentity(string getStrVal)
        {
            string ss = HttpUtility.HtmlDecode(getStrVal);
            Regex regex = new Regex("\\<[^\\>]*\\>");

            ss = regex.Replace(ss, String.Empty);
            IHtmlString strRetHTML = new MvcHtmlString(ss);
            return strRetHTML;
        }

        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        #endregion

        #region Print Complaint Form-N Details

        [HttpGet]
        [Authorize(Roles = "Complainant")]
        public ActionResult Print_ComplaintFormNcodeDetails()
        {
            ClsMethod_PrintComplaintFormN_Registration sdbReg = new ClsMethod_PrintComplaintFormN_Registration();
            ClsMethod_PrintComplaintFormN_Documents sdbDoc = new ClsMethod_PrintComplaintFormN_Documents();
            ClsMethod_PrintComplaintFormN_Fee sdbFee = new ClsMethod_PrintComplaintFormN_Fee();

            ClsPrp_Print_FormN_Registration aa = new ClsPrp_Print_FormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormN_Id = 0;
            Int64 ProfileN_Id = 0;
            userRole = getUserRole();
            
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    FormN_Id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }            
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileN_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            aa.prpComplaintFormN = sdbReg.Display_ComplaintFormN_RegistrationByID_ForPrint(FormN_Id, ProfileN_Id);
            aa.prpComplaintFormN_FeeDetail = sdbFee.Display_ComplaintFormN_PaymentByID_ForPrint(FormN_Id, ProfileN_Id);
            aa.prpComplaintFormN_Docs = sdbDoc.Display_ComplaintFormN_Documents_ByComplaintFormNIDbyProfileID_ForPrint(FormN_Id, ProfileN_Id);

            if (aa.prpComplaintFormN.Count > 0)
            {
                aa.prpComplaintFormN_AddMoreComplainant = sdbAddComp.Print_ComplainantFormN_Detail(FormN_Id);
                aa.prpComplaintFormN_AddMoreRespondent = sdbAddResp.Print_RespondentFormN_Detail(FormN_Id);
            }

            foreach (var item in aa.prpComplaintFormN)
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormNcode"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormNcode"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormNDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "Complainant")]
        public ActionResult Print_ComplaintFormNDetails(Int64? FormNcode)
        {
            ClsMethod_PrintComplaintFormN_Registration sdbReg = new ClsMethod_PrintComplaintFormN_Registration();
            ClsMethod_PrintComplaintFormN_Documents sdbDoc = new ClsMethod_PrintComplaintFormN_Documents();
            ClsMethod_PrintComplaintFormN_Fee sdbFee = new ClsMethod_PrintComplaintFormN_Fee();

            ClsPrp_Print_FormN_Registration aa = new ClsPrp_Print_FormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormN_Id = 0;
            Int64 ProfileN_Id = 0;
            userRole = getUserRole();

            FormN_Id = FormNcode == null ? 0 : Convert.ToInt64(FormNcode);
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileN_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            aa.prpComplaintFormN = sdbReg.Display_ComplaintFormN_RegistrationByID_ForPrint(FormN_Id, ProfileN_Id);
            aa.prpComplaintFormN_FeeDetail = sdbFee.Display_ComplaintFormN_PaymentByID_ForPrint(FormN_Id, ProfileN_Id);
            aa.prpComplaintFormN_Docs = sdbDoc.Display_ComplaintFormN_Documents_ByComplaintFormNIDbyProfileID_ForPrint(FormN_Id, ProfileN_Id);

            if (aa.prpComplaintFormN.Count > 0)
            {
                aa.prpComplaintFormN_AddMoreComplainant = sdbAddComp.Print_ComplainantFormN_Detail(FormN_Id);
                aa.prpComplaintFormN_AddMoreRespondent = sdbAddResp.Print_RespondentFormN_Detail(FormN_Id);
            }

            foreach (var item in aa.prpComplaintFormN)
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormN"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormN"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormNDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormNdeskDetails()
        {
            ClsMethod_PrintComplaintFormN_Registration sdbReg = new ClsMethod_PrintComplaintFormN_Registration();
            ClsMethod_PrintComplaintFormN_Documents sdbDoc = new ClsMethod_PrintComplaintFormN_Documents();
            ClsMethod_PrintComplaintFormN_Fee sdbFee = new ClsMethod_PrintComplaintFormN_Fee();

            ClsPrp_Print_FormN_Registration aa = new ClsPrp_Print_FormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormN_Id = 0;
            string FormN_DNumber = string.Empty;
            userRole = getUserRole();


            if (Session["zapFormNDiaryNumber"] != null)
            {
                Int64? ComplaintFormN_ID = Convert.ToInt64(Session["zapComplaintFormN_ID"]);
                FormN_Id = (ComplaintFormN_ID != null) ? Convert.ToInt64(ComplaintFormN_ID) : 0;

                FormN_DNumber = Convert.ToString(Session["zapFormNDiaryNumber"]);
            }

            aa.prpComplaintFormN = sdbReg.Display_ComplaintFormN_Registration_ForPrint(FormN_Id);
            aa.FactsCase_Documents = sdbReg.Display_ComplaintFormN_FactsOfTheCase_Document_ByID_ForPrint(FormN_Id, 0, 0, userRole);
            aa.prpComplaintFormN_FeeDetail = sdbFee.Display_ComplaintFormN_Payment_ForPrint(FormN_Id);
            aa.prpComplaintFormN_Docs = sdbDoc.Display_ComplaintFormN_Documents_ByComplaintFormNID_ForPrint(FormN_Id);

            if (aa.prpComplaintFormN.Count > 0)
            {
                aa.prpComplaintFormN_AddMoreComplainant = sdbAddComp.Print_ComplainantFormN_Detail(FormN_Id);
                aa.prpComplaintFormN_AddMoreRespondent = sdbAddResp.Print_RespondentFormN_Detail(FormN_Id);
            }

            foreach (var item in aa.prpComplaintFormN)
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormNdesk"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormNdesk"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormNdeskDetails", aa);
            return new RazorPDF.PdfActionResult(aa);

            //string customSwitchesHF = string.Empty;
            //string customString = string.Empty;
            //customString = "Diary Number: " + FormN_DNumber;

            //customSwitchesHF = string.Format("--page-offset 0 " +
            //                       "--header-right \"" + customString + "\" " +
            //                       "--header-font-size \"10\" --header-spacing 6 --header-font-name \"calibri light\" " +
            //                       "--footer-right \"Page [page] \"of\" [toPage]\" " +
            //                       "--footer-font-size \"10\" --footer-spacing 6 --footer-font-name \"calibri light\"");

            //var PDFResult = new PartialViewAsPdf(aa)
            //{
            //    PageOrientation = Rotativa.Options.Orientation.Portrait,
            //    PageSize = Rotativa.Options.Size.A4,
            //    MinimumFontSize = 10,
            //    PageMargins = { Left = 12, Bottom = 12, Right = 12, Top = 12 },
            //    CustomSwitches = customSwitchesHF
            //};
            //return PDFResult;
        }

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormNcontentDetails(Int64? FormNcode)
        {
            ClsMethod_PrintComplaintFormN_Registration sdbReg = new ClsMethod_PrintComplaintFormN_Registration();
            ClsMethod_PrintComplaintFormN_Documents sdbDoc = new ClsMethod_PrintComplaintFormN_Documents();
            ClsMethod_PrintComplaintFormN_Fee sdbFee = new ClsMethod_PrintComplaintFormN_Fee();

            ClsPrp_Print_FormN_Registration aa = new ClsPrp_Print_FormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormN_Id = 0;
            string FormN_DNumber = string.Empty;
            userRole = getUserRole();
            FormN_Id = FormNcode == null ? 0 : Convert.ToInt64(FormNcode);


            aa.prpComplaintFormN = sdbReg.Display_ComplaintFormN_Registration_ForPrint(FormN_Id);
            aa.FactsCase_Documents = sdbReg.Display_ComplaintFormN_FactsOfTheCase_Document_ByID_ForPrint(FormN_Id, 0, 0, userRole);
            aa.prpComplaintFormN_FeeDetail = sdbFee.Display_ComplaintFormN_Payment_ForPrint(FormN_Id);
            aa.prpComplaintFormN_Docs = sdbDoc.Display_ComplaintFormN_Documents_ByComplaintFormNID_ForPrint(FormN_Id);

            if (aa.prpComplaintFormN.Count > 0)
            {
                aa.prpComplaintFormN_AddMoreComplainant = sdbAddComp.Print_ComplainantFormN_Detail(FormN_Id);
                aa.prpComplaintFormN_AddMoreRespondent = sdbAddResp.Print_RespondentFormN_Detail(FormN_Id);
            }

            foreach (var item in aa.prpComplaintFormN)
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
                TempData["strFactsCase_Statement"] = Escape_HTMLentity(aa.FactsCase_Statement);

                aa.ReliefSought_Statement = item.ReliefSought_Statement;
                TempData["strReliefSought_Statement"] = Escape_HTMLentity(aa.ReliefSought_Statement);

                aa.ReliefSought_TotalValueINR_FlatPlotApartment = item.ReliefSought_TotalValueINR_FlatPlotApartment;
                aa.ReliefSought_TotalAmountPaid_tilldateINR = item.ReliefSought_TotalAmountPaid_tilldateINR;
                aa.ReliefSought_PossessionDate = item.ReliefSought_PossessionDate;
                aa.ReliefSought_ActualPossessionDate_IfDelivered = item.ReliefSought_ActualPossessionDate_IfDelivered;

                aa.InterimOrderRelief_Statement = item.InterimOrderRelief_Statement;
                TempData["strInterimOrderRelief_Statement"] = Escape_HTMLentity(aa.InterimOrderRelief_Statement);

                aa.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = item.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
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


                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormNdesk"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormNdesk"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;

                aa.zapRelated_RegDiaryNumber = item.zapRelated_RegDiaryNumber;
            }

            //return View("Print_ComplaintFormNdeskDetails", aa);
            return new RazorPDF.PdfActionResult(aa);

            //string customSwitchesHF = string.Empty;
            //string customString = string.Empty;
            //FormN_DNumber = aa.zapRelated_RegDiaryNumber.ToString();
            //customString = "Diary Number: " + FormN_DNumber;

            //customSwitchesHF = string.Format("--page-offset 0 " +
            //                       "--header-right \"" + customString + "\" " +
            //                       "--header-font-size \"10\" --header-spacing 6 --header-font-name \"calibri light\" " +
            //                       "--footer-right \"Page [page] \"of\" [toPage]\" " +
            //                       "--footer-font-size \"10\" --footer-spacing 6 --footer-font-name \"calibri light\"");

            //var PDFResult = new PartialViewAsPdf(aa)
            //{
            //    PageOrientation = Rotativa.Options.Orientation.Portrait,
            //    PageSize = Rotativa.Options.Size.A4,
            //    MinimumFontSize = 10,
            //    PageMargins = { Left = 12, Bottom = 12, Right = 12, Top = 12 },
            //    CustomSwitches = customSwitchesHF
            //};
            //return PDFResult;
        }

        #endregion

        #region Print Complaint Form-MISC Details

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormMiscDeskDetails()
        {
            ClsMethod_PrintComplaintFormMisc_Registration sdbReg = new ClsMethod_PrintComplaintFormMisc_Registration();
            ClsPrp_Print_FormMisc_Registration aa = new ClsPrp_Print_FormMisc_Registration();            

            string userRole = string.Empty;
            Int64 FormMisc_ID = 0;
            userRole = getUserRole();

            if (Session["zapFormMiscDiaryNumber"] != null)
            {
                Int64? ComplaintFormMisc_ID = Convert.ToInt64(Session["zapComplaintFormMisc_ID"]);
                FormMisc_ID = (ComplaintFormMisc_ID != null) ? Convert.ToInt64(ComplaintFormMisc_ID) : 0;
            }            

            aa.ComplaintMisc = sdbReg.Display_ComplaintFormMisc_Registration_ForPrint(FormMisc_ID);

            foreach (var item in aa.ComplaintMisc)
            {
                aa.ComplaintMisc_IndexID = item.ComplaintMisc_IndexID;
                aa.ComplaintMisc_ID = item.ComplaintMisc_ID;
                aa.ComplaintMisc_Year = item.ComplaintMisc_Year;
                aa.ComplaintMisc_Code = item.ComplaintMisc_Code;
                aa.ComplaintType_MNG = item.ComplaintType_MNG;

                aa.Complainant_Name = item.Complainant_Name;
                aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
                aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                aa.Complainant_LandlineNumber = item.Complainant_LandlineNumber;
                aa.Address_for_Communication = item.Address_for_Communication;

                aa.Project_Name = item.Project_Name;
                aa.Project_Address = item.Project_Address;
                aa.Village_Sector_Tehsil_Location_of_Project = item.Village_Sector_Tehsil_Location_of_Project;

                aa.Complaint_Information_Details = item.Complaint_Information_Details;                
                TempData["strComplaint_Information_Statement"] = Escape_HTMLentity(aa.Complaint_Information_Details);

                aa.ComplaintDocI_InfoName = item.ComplaintDocI_InfoName;
                aa.ComplaintDocI_IssueDate = item.ComplaintDocI_IssueDate;
                aa.ComplaintDocI_FileSize = item.ComplaintDocI_FileSize;
                aa.ComplaintDocI_FileFormat = item.ComplaintDocI_FileFormat;
                aa.ComplaintDocI_FilePath = item.ComplaintDocI_FilePath;
                aa.ComplaintDocI_FileName = item.ComplaintDocI_FileName;
                aa.ComplaintDocI_PageStartNumber = item.ComplaintDocI_PageStartNumber;
                aa.ComplaintDocI_PageEndNumber = item.ComplaintDocI_PageEndNumber;

                aa.ComplaintDocII_InfoName = item.ComplaintDocII_InfoName;
                aa.ComplaintDocII_IssueDate = item.ComplaintDocII_IssueDate;
                aa.ComplaintDocII_FileSize = item.ComplaintDocII_FileSize;
                aa.ComplaintDocII_FileFormat = item.ComplaintDocII_FileFormat;
                aa.ComplaintDocII_FilePath = item.ComplaintDocII_FilePath;
                aa.ComplaintDocII_FileName = item.ComplaintDocII_FileName;
                aa.ComplaintDocII_PageStartNumber = item.ComplaintDocII_PageStartNumber;
                aa.ComplaintDocII_PageEndNumber = item.ComplaintDocII_PageEndNumber;

                aa.ComplaintDocIII_InfoName = item.ComplaintDocIII_InfoName;
                aa.ComplaintDocIII_IssueDate = item.ComplaintDocIII_IssueDate;
                aa.ComplaintDocIII_FileSize = item.ComplaintDocIII_FileSize;
                aa.ComplaintDocIII_FileFormat = item.ComplaintDocIII_FileFormat;
                aa.ComplaintDocIII_FilePath = item.ComplaintDocIII_FilePath;
                aa.ComplaintDocIII_FileName = item.ComplaintDocIII_FileName;
                aa.ComplaintDocIII_PageStartNumber = item.ComplaintDocIII_PageStartNumber;
                aa.ComplaintDocIII_PageEndNumber = item.ComplaintDocIII_PageEndNumber;

                aa.IsVerificationComplete = item.IsVerificationComplete;
                aa.ComplaintVerificationDate = item.ComplaintVerificationDate;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsPublicView = item.IsPublicView;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;

                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                //public long zapRelated_Complaint_ID { get; set; }        
                //public string zapRelated_RegDiaryNumber { get; set; }        
                //public string zapComplainantName { get; set; }        
                //public string zapRespondantName { get; set; }        
                //public DateTime? zapComplaintFormLastModifiedOn { get; set; }                
            }

            //return View("Print_ComplaintFormMiscDeskDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Notice Section-FiveNine

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority, Programmer, ManagerDesk")]
        public ActionResult Print_ComplaintSectionFiveNineDetails(Int64? IndexID, Int64? FormSFN, string FormSFNcode)
        {
            ClsPrp_Print_NoticeSectionFiveNine prpReg = new ClsPrp_Print_NoticeSectionFiveNine();
            ClsPrp_Print_NoticeSectionFiveNine_HearingDetails prpHearing = new ClsPrp_Print_NoticeSectionFiveNine_HearingDetails();

            ClsMethod_PrintSectionFiveNine_NoticeRegistration sdb = new ClsMethod_PrintSectionFiveNine_NoticeRegistration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            try
            {
                string userRole = string.Empty;
                Int64 FormFN_Id = 0;
                Int64 Index_ID = 0;
                string FormFN_DNumber = string.Empty;

                userRole = getUserRole();
                Index_ID = (IndexID == null) ? 0 : Convert.ToInt64(IndexID);
                FormFN_Id = (FormSFN == null) ? 0 : Convert.ToInt64(FormSFN);
                FormFN_DNumber = string.IsNullOrEmpty(FormSFNcode) ? "0" : Convert.ToString(FormSFNcode);

                prpReg.prpNoticeSectionFiveNine = sdb.Display_Print_NoticeSectionFiveNineDetail_ByID(Index_ID, FormFN_Id, FormFN_DNumber, userRole);
                prpReg.eCourtHearingRecords = sdb.Display_HearingDate_NoticeSectionFiveNineDetail_ByID(Index_ID, FormFN_Id, FormFN_DNumber, userRole);

                foreach (var item in prpReg.prpNoticeSectionFiveNine)
                {
                    prpReg.NoticesSectionFiveNine_IndexID = item.NoticesSectionFiveNine_IndexID;
                    prpReg.NoticesSectionFiveNine_ID = item.NoticesSectionFiveNine_ID;
                    prpReg.NoticesSectionFiveNine_IDYear = item.NoticesSectionFiveNine_IDYear;
                    prpReg.NoticesSectionFiveNine_IDName = item.NoticesSectionFiveNine_IDName;
                    prpReg.NoticeDate = item.NoticeDate;
                    prpReg.Notice_RelatedReferenceID = item.Notice_RelatedReferenceID;
                    prpReg.Notice_RelatedReferenceDate = item.Notice_RelatedReferenceDate;
                    prpReg.Notice_RelatedReferenceName = item.Notice_RelatedReferenceName;
                    prpReg.Notice_RelatedReferenceCode = item.Notice_RelatedReferenceCode;
                    prpReg.SerialOrderNumber = item.SerialOrderNumber;

                    prpReg.NoticeFile_NumberDetails = item.NoticeFile_NumberDetails;                    
                    prpReg.DistrictTown_InfoName = item.DistrictTown_InfoName;
                    prpReg.DistrictTown_InfoCode = item.DistrictTown_InfoCode;
                    prpReg.Notice_ModeOfComplaint = item.Notice_ModeOfComplaint;
                    prpReg.Notice_ModeOfComplaintSpecifyOthers = item.Notice_ModeOfComplaintSpecifyOthers;
                    prpReg.PromoterName = item.PromoterName;
                    prpReg.PromoterNameWithAddressDetails = item.PromoterNameWithAddressDetails;
                    prpReg.ProjectName = item.ProjectName;
                    prpReg.ProjectNameWithAddressDetails = item.ProjectNameWithAddressDetails;

                    prpReg.Complainant_Name = item.Complainant_Name;
                    prpReg.Complainant_EmailAddress = item.Complainant_EmailAddress;
                    prpReg.Complainant_MobileNumber = item.Complainant_MobileNumber;
                    prpReg.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                    prpReg.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                    prpReg.OfficeResComplainant_AddressLine1 = item.OfficeResComplainant_AddressLine1;
                    prpReg.OfficeResComplainant_AddressLine2 = item.OfficeResComplainant_AddressLine2;
                    prpReg.OfficeResComplainant_AddressStateCode = item.OfficeResComplainant_AddressStateCode;
                    prpReg.OfficeResComplainant_AddressDistrictCode = item.OfficeResComplainant_AddressDistrictCode;
                    prpReg.OfficeResComplainant_AddressPIN = item.OfficeResComplainant_AddressPIN;

                    prpReg.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress;

                    prpReg.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                    prpReg.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                    prpReg.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                    prpReg.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                    prpReg.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                    prpReg.AuthorizedCounsel_Name = item.AuthorizedCounsel_Name;
                    prpReg.AuthorizedCounsel_EmailAddress = item.AuthorizedCounsel_EmailAddress;
                    prpReg.AuthorizedCounsel_MobileNumber = item.AuthorizedCounsel_MobileNumber;
                    prpReg.AuthorizedCounsel_LandlineFaxNumber = item.AuthorizedCounsel_LandlineFaxNumber;

                    prpReg.CurrentStatusDate = item.CurrentStatusDate;
                    prpReg.CurrentStatusTitle = item.CurrentStatusTitle;
                    prpReg.CurrentStatusWithRemarks = item.CurrentStatusWithRemarks;
                    prpReg.IsPersonalHearing = item.IsPersonalHearing;
                    prpReg.HearingBenchCode = item.HearingBenchCode;
                    prpReg.HearingBenchName = item.HearingBenchName;
                    prpReg.FixedFor = item.FixedFor;
                    prpReg.OrderDate = item.OrderDate;
                    prpReg.OrderTime = item.OrderTime;
                    prpReg.OrderDateStatusTitle = item.OrderDateStatusTitle;
                    prpReg.OrderDateWithRemarksIfAny = item.OrderDateWithRemarksIfAny;
                    prpReg.RemarksIfAny = item.RemarksIfAny;

                    prpReg.A_column = item.A_column;
                    prpReg.B_column = item.B_column;
                    prpReg.C_column = item.C_column;
                    prpReg.D_column = item.D_column;
                    prpReg.E_column = item.E_column;

                    prpReg.CurrentEvent_IdentifiedCode = item.CurrentEvent_IdentifiedCode;
                    prpReg.CurrentEvent_IdentifiedAggregateName = item.CurrentEvent_IdentifiedAggregateName;
                    prpReg.CurrentEvent_IdentifiedBy = item.CurrentEvent_IdentifiedBy;
                    prpReg.CurrentEvent_IdentifiedOn = item.CurrentEvent_IdentifiedOn;

                    prpReg.DeskAction_IdentifiedCode = item.DeskAction_IdentifiedCode;
                    prpReg.DeskAction_IdentifiedAggregateName = item.DeskAction_IdentifiedAggregateName;
                    prpReg.DeskAction_IdentifiedBy = item.DeskAction_IdentifiedBy;
                    prpReg.DeskAction_IdentifiedOn = item.DeskAction_IdentifiedOn;

                    prpReg.IsActive = item.IsActive;
                    prpReg.IsDraft = item.IsDraft;
                    prpReg.IsDraftMember = item.IsDraftMember;
                    prpReg.IsPublicView = item.IsPublicView;

                    prpReg.CreatedBy = item.CreatedBy;
                    prpReg.CreatedOn = item.CreatedOn;
                    prpReg.ModifyBy = item.ModifyBy;
                    prpReg.ModifyOn = item.ModifyOn;

                    prpReg.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                    prpReg.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                    prpReg.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                    prpReg.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                }
            }
            catch(Exception ex)
            {
                string strmsg = ex.ToString();
            }

            return new RazorPDF.PdfActionResult(prpReg);

            //string customSwitchesHF = string.Empty;
            //string customString = string.Empty;
            //customString = "Diary Number: " + FormN_DNumber;

            //customSwitchesHF = string.Format("--page-offset 0 " +
            //                       "--header-right \"" + customString + "\" " +
            //                       "--header-font-size \"10\" --header-spacing 6 --header-font-name \"calibri light\" " +
            //                       "--footer-right \"Page [page] \"of\" [toPage]\" " +
            //                       "--footer-font-size \"10\" --footer-spacing 6 --footer-font-name \"calibri light\"");

            //var PDFResult = new PartialViewAsPdf(aa)
            //{
            //    PageOrientation = Rotativa.Options.Orientation.Portrait,
            //    PageSize = Rotativa.Options.Size.A4,
            //    MinimumFontSize = 10,
            //    PageMargins = { Left = 12, Bottom = 12, Right = 12, Top = 12 },
            //    CustomSwitches = customSwitchesHF
            //};
            //return PDFResult;
        }

        #endregion

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

        private string RegexRemoveEmailCheck(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "@";
            string replacement = "[at]";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
        }

        private string RegexRemoveNewLineCheck(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "),";
            string replacement = ") <br/>";            
            oSTR = varSTR.Replace(pattern, replacement);
            return oSTR;
        }



        #region EXECUTION

        [HttpGet]
        [Authorize(Roles = "Complainant")]
        public ActionResult Print_ComplaintFormExecutioncodeDetails()
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_ComplaintFormM_Registration objReg = new ClsMethod_ComplaintFormM_Registration();
            ClsMethod_ComplaintM_Documents sdbDoc = new ClsMethod_ComplaintM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_ExecutionForm_Registration aa = new ClsPrp_Print_ExecutionForm_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 ProfileM_Id = 0;
            userRole = getUserRole();

            Int64 ExecutionForm_id = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    ExecutionForm_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            //aa.ExecutionFormstepI = objReg.Display_ExecutionForm_Registration_Print(ProfileM_Id);
            //aa.prpComplaintFormexecution_Fee = sdbFee.Display_ComplaintFormexecution_PaymentByID_ForPrint(ProfileM_Id, Executioncomplaint_id);
            //aa.prpComplaintFormM_Docs = sdbDoc.Display_ExecutionForm_Documents_ByExecution_ID(ProfileM_Id);
            aa.ExecutionFormstepI = sdbReg.Display_ExecutionForm_RegistrationByID_ForPrint(ProfileM_Id, ExecutionForm_id);
            aa.prpComplaintFormexecution_Fee = sdbReg.Display_ComplaintFormexecution_PaymentByID_ForPrint(ProfileM_Id, ExecutionForm_id);
            aa.prpComplaintFormM_Docs = sdbReg.Display_ComplaintFormExe_Documents_ByComplaintFormExeIDbyProfileID_ForPrint(ProfileM_Id, ExecutionForm_id);


            if (aa.ExecutionFormstepI.Count > 0)
            {
                aa.prpComplaintFormExe_AddMoreComplainant = sdbAddComp.Print_ComplainantFormExe_Detail(ExecutionForm_id);
                aa.prpComplaintFormExe_AddMoreRespondent = sdbAddResp.Print_RespondentFormExe_Detail(ExecutionForm_id);
            }

            foreach (var item in aa.ExecutionFormstepI)
            {
                aa.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                aa.ExecutionForm_ID = item.ExecutionForm_ID;
                aa.ExecutionForm_Code = item.ExecutionForm_Code;
                //aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                //aa.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                //aa.Related_FormExe_Year = item.Related_FormExe_Year;
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
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedBy = item.CreatedBy;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifiedOn = item.ModifiedOn;

                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormMcode"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormMcode"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormMDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "Complainant")]
        public ActionResult Print_ComplaintFormExeDetails(Int64? FormExecode)
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_ComplaintFormM_Registration objReg = new ClsMethod_ComplaintFormM_Registration();
            ClsMethod_ComplaintM_Documents sdbDoc = new ClsMethod_ComplaintM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_ExecutionForm_Registration aa = new ClsPrp_Print_ExecutionForm_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 ProfileM_Id = 0;
            Int64 ExecutionForm_id = 0;
            userRole = getUserRole();

            ExecutionForm_id = FormExecode == null ? 0 : Convert.ToInt64(FormExecode);
            
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            aa.ExecutionFormstepI = sdbReg.Display_ExecutionForm_RegistrationByID_ForPrint(ProfileM_Id, ExecutionForm_id);
            aa.prpComplaintFormexecution_Fee = sdbReg.Display_ComplaintFormexecution_PaymentByID_ForPrint(ProfileM_Id, ExecutionForm_id);
            aa.prpComplaintFormM_Docs = sdbReg.Display_ComplaintFormExe_Documents_ByComplaintFormExeIDbyProfileID_ForPrint(ProfileM_Id, ExecutionForm_id);


            if (aa.ExecutionFormstepI.Count > 0)
            {
                aa.prpComplaintFormExe_AddMoreComplainant = sdbAddComp.Print_ComplainantFormExe_Detail(ExecutionForm_id);
                aa.prpComplaintFormExe_AddMoreRespondent = sdbAddResp.Print_RespondentFormExe_Detail(ExecutionForm_id);
            }

            foreach (var item in aa.ExecutionFormstepI)
            {
                aa.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                aa.ExecutionForm_ID = item.ExecutionForm_ID;
                aa.ExecutionForm_Code = item.ExecutionForm_Code;
                //aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
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
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedBy = item.CreatedBy;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifiedOn = item.ModifiedOn;

                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormM"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormM"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormMDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }


        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormExedeskDetails()
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_ComplaintFormM_Registration objReg = new ClsMethod_ComplaintFormM_Registration();
            ClsMethod_ComplaintM_Documents sdbDoc = new ClsMethod_ComplaintM_Documents();
            ClsMethod_PrintComplaintFormM_Documents sdbsDoc = new ClsMethod_PrintComplaintFormM_Documents();

            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_ExecutionForm_Registration aa = new ClsPrp_Print_ExecutionForm_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            string FormM_DNumber = string.Empty;
            Int64 ExecutionForm_id = 1031; // 0;
            userRole = getUserRole();


            if (Session["zapFormExeDiaryNumber"] != null)
            {
                Int64? ComplaintFormM_ID = Convert.ToInt64(Session["zapComplaintFormExe_ID"]);
                ExecutionForm_id = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;

                FormM_DNumber = Convert.ToString(Session["zapFormExeDiaryNumber"]);
            }


            aa.ExecutionFormstepI = sdbReg.Display_ComplaintFormExe_Registration_ForPrint(ExecutionForm_id);
            aa.prpComplaintFormexecution_Fee = sdbFee.Display_ComplaintFormExe_Payment_ForPrint(ExecutionForm_id);
            aa.prpComplaintFormM_Docs = sdbsDoc.Display_ComplaintFormExe_Documents_ByComplaintFormMID_ForPrint(ExecutionForm_id);



            if (aa.ExecutionFormstepI.Count > 0)
            {
                aa.prpComplaintFormExe_AddMoreComplainant = sdbAddComp.Print_ComplainantFormExe_Detail(ExecutionForm_id);
                aa.prpComplaintFormExe_AddMoreRespondent = sdbAddResp.Print_RespondentFormExe_Detail(ExecutionForm_id);
            }

            foreach (var item in aa.ExecutionFormstepI)
            {
                aa.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                aa.ExecutionForm_ID = item.ExecutionForm_ID;
                aa.ExecutionForm_Code = item.ExecutionForm_Code;
                //aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
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
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedBy = item.CreatedBy;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifiedOn = item.ModifiedOn;

                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormM"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormM"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }
            return new RazorPDF.PdfActionResult(aa);
        }

        [HttpGet]
        [Authorize(Roles = "SecretaryRERA, LegalAdvisorDesk, PStoMembers, Authority")]
        public ActionResult Print_ComplaintFormExecontentDetails(Int64? FormExecode)
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_ComplaintFormM_Registration objReg = new ClsMethod_ComplaintFormM_Registration();
            ClsMethod_ComplaintM_Documents sdbDoc = new ClsMethod_ComplaintM_Documents();
            ClsMethod_PrintComplaintFormM_Documents sdbsDoc = new ClsMethod_PrintComplaintFormM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_ExecutionForm_Registration aa = new ClsPrp_Print_ExecutionForm_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_PrintFormMN_Addmore_Complainant sdbAddComp = new ClsMethod_PrintFormMN_Addmore_Complainant();
            ClsMethod_PrintFormMN_Addmore_Respondent sdbAddResp = new ClsMethod_PrintFormMN_Addmore_Respondent();

            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 ExecutionForm_id = 0;
            string FormM_DNumber = string.Empty;
            userRole = getUserRole();
            ExecutionForm_id = FormExecode == null ? 0 : Convert.ToInt64(FormExecode);

            aa.ExecutionFormstepI = sdbReg.Display_ComplaintFormExe_Registration_ForPrint(ExecutionForm_id);
            aa.prpComplaintFormexecution_Fee = sdbFee.Display_ComplaintFormExe_Payment_ForPrint(ExecutionForm_id);
            aa.prpComplaintFormM_Docs = sdbsDoc.Display_ComplaintFormExe_Documents_ByComplaintFormMID_ForPrint(ExecutionForm_id);

            if (aa.ExecutionFormstepI.Count > 0)
            {
                aa.prpComplaintFormExe_AddMoreComplainant = sdbAddComp.Print_ComplainantFormExe_Detail(ExecutionForm_id);
                aa.prpComplaintFormExe_AddMoreRespondent = sdbAddResp.Print_RespondentFormExe_Detail(ExecutionForm_id);
            }

            foreach (var item in aa.ExecutionFormstepI)
            {
                aa.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                aa.ExecutionForm_ID = item.ExecutionForm_ID;
                aa.ExecutionForm_Code = item.ExecutionForm_Code;
                //aa.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
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
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedBy = item.CreatedBy;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifiedOn = item.ModifiedOn;

                aa.OfficeResComplainant_AddressStateCodeName = objdis.State_Name(item.OfficeResComplainant_AddressStateCode);
                aa.OfficeResComplainant_AddressDistrictCodeName = objdis.District_Name(item.OfficeResComplainant_AddressDistrictCode);
                aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
                aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
                aa.OfficeResRespondent_AddressStateCodeName = objdis.State_Name(item.OfficeResRespondent_AddressStateCode);
                aa.OfficeResRespondent_AddressDistrictCodeName = objdis.District_Name(item.OfficeResRespondent_AddressDistrictCode);
                aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
                aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);

                aa.zapComplainantName = item.zapComplainantName;
                aa.zapOtherComplainantName = RegexRemoveNewLineCheck(item.zapOtherComplainantName);
                TempData["strOtherComplainantNameFormM"] = aa.zapOtherComplainantName;
                aa.zapOtherBriefComplainantName = item.zapOtherBriefComplainantName;
                aa.zapRespondantName = item.zapRespondantName;
                aa.zapOtherRespondantName = RegexRemoveNewLineCheck(item.zapOtherRespondantName);
                TempData["strOtherRespondantNameFormM"] = aa.zapOtherRespondantName;
                aa.zapOtherBriefRespondantName = item.zapOtherBriefRespondantName;
            }

            //return View("Print_ComplaintFormMdeskDetails", aa);           
            return new RazorPDF.PdfActionResult(aa);
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
    }
}