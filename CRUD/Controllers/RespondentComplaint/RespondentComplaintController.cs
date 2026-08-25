using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using System.IO;
using System.Text.RegularExpressions;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using CRUD.Models.RespondentComplaint;
using CRUD.Models.ComplaintPrint;

namespace CRUD.Controllers.RespondentComplaint
{
    [Authorize]          
    public class RespondentComplaintController : Controller
    {        
        #region Form-M Complaint Active Link Access
        [HttpGet]
        [AllowAnonymous]
        public ActionResult FormMInfoAccess(string diaryid, string mid, string pfid, string code)
        {
            if (diaryid == null || mid == null || pfid == null || code == null)
            {
                return View("Error");
            }
            Session["reraFormMComplaintID"] = (mid != null) ? Convert.ToInt64(mid) : 0;
            Session["reraFormMUserProfileID"] = (pfid != null) ? Convert.ToInt64(pfid) : 0;
            Session["reraFormMDiaryNumber"] = (String.IsNullOrEmpty(diaryid) ? "" : diaryid);
            Session["reraFormMCode"] = (String.IsNullOrEmpty(code) ? "" : code);

            string uIDuserRole = string.Empty;
            string uIDdiaryNumber = string.Empty;
            Int64 uIDformM = 0;
            string uIDcode = string.Empty;

            string ipSource = getSourceIPaddress();// Request.UserHostAddress;
            //string hostnameSource = Request.UserHostName;
            uIDuserRole = ipSource;// + "(" + hostnameSource + ")";


            uIDdiaryNumber = (String.IsNullOrEmpty(diaryid) ? "" : diaryid);
            uIDformM = (mid != null) ? Convert.ToInt64(mid) : 0;
            uIDcode = (String.IsNullOrEmpty(code) ? "" : code);

            ClsMethod_RespondentComplaintFormM_Documents sdbdoc = new ClsMethod_RespondentComplaintFormM_Documents();
            ClsMethod_RespondentComplaintFormM_DiaryNumber sdb = new ClsMethod_RespondentComplaintFormM_DiaryNumber();
            ClsPrp_RespondentComplaint_FormM_DiaryNumber aa = new ClsPrp_RespondentComplaint_FormM_DiaryNumber();


            aa.prpongoing = sdb.Display_RespondentComplaintFormM_RegDiaryNumber(uIDuserRole, uIDdiaryNumber, uIDformM, uIDcode);
            if (aa.prpongoing.Count > 0)
            {
                aa.prpFormM_Docs = sdbdoc.Display_ComplaintFormM_Documents_ByComplaintFormMID_ForRespondentComplaint(uIDformM);
            }

            foreach (var item in aa.prpongoing)
            {
                aa.ComplaintRegDiaryNumber_IndexID = item.ComplaintRegDiaryNumber_IndexID;
                aa.ComplaintRegDiaryNumber_ID = item.ComplaintRegDiaryNumber_ID;
                aa.ComplaintRegDiaryNumber_Name = item.ComplaintRegDiaryNumber_Name;
                aa.ComplaintRegDiaryNumber_NameYear = item.ComplaintRegDiaryNumber_NameYear;
                aa.FormM_RelatedComplaint_ID = item.FormM_RelatedComplaint_ID;
                aa.FormM_RelatedComplaint_Code = item.FormM_RelatedComplaint_Code;
                aa.Profile_ID = item.Profile_ID;
                aa.User_ID = item.User_ID;
                aa.ComplaintType_MN = item.ComplaintType_MN;
                aa.IsComplaintComplete = item.IsComplaintComplete;
                aa.IsPaymentComplete = item.IsPaymentComplete;
                aa.PaymentTransactionID = item.PaymentTransactionID;
                aa.PaymentTransactionDate = item.PaymentTransactionDate;
                aa.IsDocumentsComplete = item.IsDocumentsComplete;
                aa.DocumentUploadCount = item.DocumentUploadCount;
                aa.IsVerificationComplete = item.IsVerificationComplete;
                aa.ComplaintVerificationDate = item.ComplaintVerificationDate;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
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

                aa.Complainant_Name = item.Complainant_Name;
                aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                aa.RelatesComplaint_ComplaintAgainstType = item.RelatesComplaint_ComplaintAgainstType;
                aa.Respondent_Name = item.Respondent_Name;

                aa.EventAction_Type = item.EventAction_Type;
                aa.EventAction_TypeName = item.EventAction_TypeName;
                aa.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                aa.EventAction_Aggregate = item.EventAction_Aggregate;
                aa.Target_ResolutionDate = item.Target_ResolutionDate;
                aa.EventRemarks_IfAny = item.EventRemarks_IfAny;
                aa.EventAction_Summary = item.EventAction_Summary;

                aa.PreHearingDate = item.PreHearingDate;
                aa.PreHearingTime = item.PreHearingTime;
                aa.PreHearingFixedForName = item.PreHearingFixedForName;
                aa.HearingType_Acolumn = item.HearingType_Acolumn;
                aa.HearingBench_Bcolumn = item.HearingBench_Bcolumn;

                aa.complaintrelatedRERAnumber = item.complaintrelatedRERAnumber;
                aa.complaintrelatedProjectorAgentName = item.complaintrelatedProjectorAgentName;                              
            }

            return View("FormMInfoAccess", aa);
        }
        #endregion

        #region Form-N Complaint Active Link Access
        [HttpGet]
        [AllowAnonymous]
        public ActionResult FormNInfoAccess(string diaryid, string mid, string pfid, string code)
        {
            if (diaryid == null || mid == null || code == null)
            {
                return View("Error");
            }

            Session["reraFormNComplaintID"] = (mid != null) ? Convert.ToInt64(mid) : 0;
            Session["reraFormNUserProfileID"] = (pfid != null) ? Convert.ToInt64(pfid) : 0;
            Session["reraFormNDiaryNumber"] = (String.IsNullOrEmpty(diaryid) ? "" : diaryid);
            Session["reraFormNCode"] = (String.IsNullOrEmpty(code) ? "" : code);

            string uIDuserRole = string.Empty;
            string uIDdiaryNumber = string.Empty;
            Int64 uIDformN = 0;
            string uIDcode = string.Empty;

            string ipSource = getSourceIPaddress();//Request.UserHostAddress;
            //string hostnameSource = Request.UserHostName;
            uIDuserRole = ipSource;// + "(" + hostnameSource + ")";

            uIDdiaryNumber = (String.IsNullOrEmpty(diaryid) ? "" : diaryid);
            uIDformN = (mid != null) ? Convert.ToInt64(mid) : 0;
            uIDcode = (String.IsNullOrEmpty(code) ? "" : code);

            ClsMethod_RespondentComplaintFormN_Documents sdbdoc = new ClsMethod_RespondentComplaintFormN_Documents();
            ClsMethod_RespondentComplaintFormN_DiaryNumber sdb = new ClsMethod_RespondentComplaintFormN_DiaryNumber();
            ClsPrp_RespondentComplaint_FormN_DiaryNumber aa = new ClsPrp_RespondentComplaint_FormN_DiaryNumber();

            aa.prpongoing = sdb.Display_RespondentComplaintFormN_RegDiaryNumber(uIDuserRole, uIDdiaryNumber, uIDformN, uIDcode);
            if (aa.prpongoing.Count > 0)
            {
                aa.prpFormN_Docs = sdbdoc.Display_ComplaintFormN_Documents_ByComplaintFormNID_ForRespondentComplaint(uIDformN);
            }

            foreach (var item in aa.prpongoing)
            {
                aa.ComplaintRegDiaryNumber_IndexID = item.ComplaintRegDiaryNumber_IndexID;
                aa.ComplaintRegDiaryNumber_ID = item.ComplaintRegDiaryNumber_ID;
                aa.ComplaintRegDiaryNumber_Name = item.ComplaintRegDiaryNumber_Name;
                aa.ComplaintRegDiaryNumber_NameYear = item.ComplaintRegDiaryNumber_NameYear;
                aa.FormN_RelatedComplaint_ID = item.FormN_RelatedComplaint_ID;
                aa.FormN_RelatedComplaint_Code = item.FormN_RelatedComplaint_Code;
                aa.Profile_ID = item.Profile_ID;
                aa.User_ID = item.User_ID;
                aa.ComplaintType_MN = item.ComplaintType_MN;
                aa.IsComplaintComplete = item.IsComplaintComplete;
                aa.IsPaymentComplete = item.IsPaymentComplete;
                aa.PaymentTransactionID = item.PaymentTransactionID;
                aa.PaymentTransactionDate = item.PaymentTransactionDate;
                aa.IsDocumentsComplete = item.IsDocumentsComplete;
                aa.DocumentUploadCount = item.DocumentUploadCount;
                aa.IsVerificationComplete = item.IsVerificationComplete;
                aa.ComplaintVerificationDate = item.ComplaintVerificationDate;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
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

                aa.Complainant_Name = item.Complainant_Name;
                aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
                aa.RelatesComplaint_ComplaintAgainstType = item.RelatesComplaint_ComplaintAgainstType;
                aa.Respondent_Name = item.Respondent_Name;

                aa.EventAction_Type = item.EventAction_Type;
                aa.EventAction_TypeName = item.EventAction_TypeName;
                aa.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                aa.EventAction_Aggregate = item.EventAction_Aggregate;
                aa.Target_ResolutionDate = item.Target_ResolutionDate;
                aa.EventRemarks_IfAny = item.EventRemarks_IfAny;
                aa.EventAction_Summary = item.EventAction_Summary;

                aa.PreHearingDate = item.PreHearingDate;
                aa.PreHearingTime = item.PreHearingTime;
                aa.PreHearingFixedForName = item.PreHearingFixedForName;
                aa.HearingType_Acolumn = item.HearingType_Acolumn;
                aa.HearingBench_Bcolumn = item.HearingBench_Bcolumn;

                aa.complaintrelatedRERAnumber = item.complaintrelatedRERAnumber;
                aa.complaintrelatedProjectorAgentName = item.complaintrelatedProjectorAgentName;
            }

            return View("FormNInfoAccess", aa);
        }
        #endregion

        #region PDF Form-M

        [HttpGet]
        [AllowAnonymous]
        public ActionResult FilePDF_ComplaintFormMcodeDetails()
        {
            ClsMethod_PrintComplaintFormM_Registration sdbReg = new ClsMethod_PrintComplaintFormM_Registration();
            ClsMethod_PrintComplaintFormM_Documents sdbDoc = new ClsMethod_PrintComplaintFormM_Documents();
            ClsMethod_PrintComplaintFormM_Fee sdbFee = new ClsMethod_PrintComplaintFormM_Fee();

            ClsPrp_Print_FormM_Registration aa = new ClsPrp_Print_FormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormM_Id = 0;
            Int64 ProfileM_Id = 0;
            userRole = getUserRole();

            if (Session["reraFormMComplaintID"] != null)
            {
                if (Session["reraFormMComplaintID"].ToString() != "0")
                {
                    FormM_Id = Convert.ToInt64(Session["reraFormMComplaintID"]);
                }
            }
            if (Session["reraFormMUserProfileID"] != null)
            {
                if (Session["reraFormMUserProfileID"].ToString() != "0")
                {
                    ProfileM_Id = Convert.ToInt64(Session["reraFormMUserProfileID"]);
                }
            }

            aa.prpComplaintFormM = sdbReg.Display_ComplaintFormM_RegistrationByID_ForPrint(FormM_Id, ProfileM_Id);
            aa.FactsCase_Documents = sdbReg.Display_ComplaintFormM_FactsOfTheCase_Document_ByID_ForPrint(FormM_Id, 0, 0, userRole);
            aa.prpComplaintFormM_FeeDetail = sdbFee.Display_ComplaintFormM_PaymentByID_ForPrint(FormM_Id, ProfileM_Id);
            aa.prpComplaintFormM_Docs = sdbDoc.Display_ComplaintFormM_Documents_ByComplaintFormMIDbyProfileID_ForPrint(FormM_Id, ProfileM_Id);

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
            }

            //return View("Print_ComplaintFormMDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        private IHtmlString Escape_HTMLentity(string getStrVal)
        {
            string ss = HttpUtility.HtmlDecode(getStrVal);
            Regex regex = new Regex("\\<[^\\>]*\\>");
            ss = regex.Replace(ss, String.Empty);
            IHtmlString strRetHTML = new MvcHtmlString(ss);
            return strRetHTML;
        }

        #endregion

        #region PDF Form-N

        [HttpGet]
        [AllowAnonymous]
        public ActionResult FilePDF_ComplaintFormNcodeDetails()
        {
            ClsMethod_PrintComplaintFormN_Registration sdbReg = new ClsMethod_PrintComplaintFormN_Registration();
            ClsMethod_PrintComplaintFormN_Documents sdbDoc = new ClsMethod_PrintComplaintFormN_Documents();
            ClsMethod_PrintComplaintFormN_Fee sdbFee = new ClsMethod_PrintComplaintFormN_Fee();

            ClsPrp_Print_FormN_Registration aa = new ClsPrp_Print_FormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            string embed = string.Empty;
            string userRole = string.Empty;
            Int64 FormN_Id = 0;
            Int64 ProfileN_Id = 0;
            userRole = getUserRole();

            if (Session["reraFormNComplaintID"] != null)
            {
                if (Session["reraFormNComplaintID"].ToString() != "0")
                {
                    FormN_Id = Convert.ToInt64(Session["reraFormNComplaintID"]);
                }
            }
            if (Session["reraFormNUserProfileID"] != null)
            {
                if (Session["reraFormNUserProfileID"].ToString() != "0")
                {
                    ProfileN_Id = Convert.ToInt64(Session["reraFormNUserProfileID"]);
                }
            }

            aa.prpComplaintFormN = sdbReg.Display_ComplaintFormN_RegistrationByID_ForPrint(FormN_Id, ProfileN_Id);
            aa.FactsCase_Documents = sdbReg.Display_ComplaintFormN_FactsOfTheCase_Document_ByID_ForPrint(FormN_Id, 0, 0, userRole);
            aa.prpComplaintFormN_FeeDetail = sdbFee.Display_ComplaintFormN_PaymentByID_ForPrint(FormN_Id, ProfileN_Id);
            aa.prpComplaintFormN_Docs = sdbDoc.Display_ComplaintFormN_Documents_ByComplaintFormNIDbyProfileID_ForPrint(FormN_Id, ProfileN_Id);

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
            }

            //return View("Print_ComplaintFormNDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion
        
        #region View Form-M Document Details

        //[HttpGet]
        //public ActionResult Display_ListEnclosuresDocFormM()
        //{
        //    ClsMethod_RespondentComplaintFormM_Documents sdb = new ClsMethod_RespondentComplaintFormM_Documents();
        //    Clsprp_RespondentComplaint_FormM_Documents aa = new Clsprp_RespondentComplaint_FormM_Documents();
        //    string userRole = string.Empty;
        //    Int64 ComplaintFormMID = 0;
        //    userRole = getUserRole();

        //    if (Session["reraFormMDiaryNumber"] != null)
        //    {
        //        Int64? ComplaintFormM_ID = Convert.ToInt64(Session["reraFormMComplaintID"]);
        //        ComplaintFormMID = (ComplaintFormM_ID != null) ? Convert.ToInt64(ComplaintFormM_ID) : 0;
        //    }

        //    aa.prpFormM_Docs = sdb.Display_ComplaintFormM_Documents_ByComplaintFormMID_ForRespondentComplaint(ComplaintFormMID);

        //    return View("Display_ListEnclosuresDocFormM", aa);
        //}

        #endregion

        #region View Form-N Document Details

        //[HttpGet]
        //public ActionResult Display_ListEnclosuresDocFormN()
        //{
        //    ClsMethod_RespondentComplaintFormN_Documents sdb = new ClsMethod_RespondentComplaintFormN_Documents();
        //    Clsprp_RespondentComplaint_FormN_Documents aa = new Clsprp_RespondentComplaint_FormN_Documents();
        //    string userRole = string.Empty;
        //    Int64 ComplaintFormNID = 0;
        //    userRole = getUserRole();

        //    if (Session["reraFormNDiaryNumber"] != null)
        //    {
        //        Int64? ComplaintFormN_ID = Convert.ToInt64(Session["reraComplaintFormN_ID"]);
        //        ComplaintFormNID = (ComplaintFormN_ID != null) ? Convert.ToInt64(ComplaintFormN_ID) : 0;
        //    }
        //    aa.prpFormN_Docs = sdb.Display_ComplaintFormN_Documents_ByComplaintFormNID_ForRespondentComplaint(ComplaintFormNID);
            
        //    return View("Display_ListEnclosuresDocFormN", aa);
        //}

        #endregion

        #region View Form-M Pre-Hearing Notice
        //[HttpGet]
        //public ActionResult FormM_PreHearingNotice(Int64 FormM_Id)
        //{
        //    ClsMethod_RespondentComplaintFormM_PreHearingNotice sdb = new ClsMethod_RespondentComplaintFormM_PreHearingNotice();
        //    ClsPrp_RespondentComplaint_FormM_PreHearingNotice aa = new ClsPrp_RespondentComplaint_FormM_PreHearingNotice();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

        //    Int64 userFlag = 0;
        //    aa.prpongoingNotice = sdb.Display_RespondentComplaintFormM_PreHearingNoticeByID(FormM_Id, userFlag);
        //    foreach (var item in aa.prpongoingNotice)
        //    {
        //        aa.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
        //        aa.ComplaintFormM_ID = item.ComplaintFormM_ID;
        //        aa.ComplaintFormM_Code = item.ComplaintFormM_Code;

        //        aa.Complainant_Name = (item.Complainant_Name).ToUpper();
        //        aa.ComplainantOther_Name = item.ComplainantOther_Name;
        //        aa.ComplainantOtherBrief_Name = item.ComplainantOtherBrief_Name;
        //        aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
        //        aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
        //        aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;

        //        aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
        //        aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
        //        aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
        //        aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
        //        aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

        //        aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
        //        aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
        //        aa.Respondent_Name = item.Respondent_Name;
        //        aa.RespondentOther_Name = item.RespondentOther_Name;
        //        aa.RespondentOtherBrief_Name = item.RespondentOtherBrief_Name;
        //        aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
        //        aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
        //        aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;

        //        aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
        //        aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
        //        aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
        //        aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
        //        aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

        //        aa.PreHearingDate_IndexID = item.PreHearingDate_IndexID;
        //        aa.PreHearingDate_ID = item.PreHearingDate_ID;
        //        aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
        //        aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
        //        aa.ComplaintType_MN = item.ComplaintType_MN;

        //        aa.PreHearingDate = item.PreHearingDate;
        //        aa.PreHearingTime = item.PreHearingTime;
        //        aa.PreHearingBench = item.PreHearingBench;
        //        aa.PreHearingFixedForCode = item.PreHearingFixedForCode;
        //        aa.PreHearingFixedForName = item.PreHearingFixedForName;
        //        aa.PreHearingStatus = item.PreHearingStatus;
        //        aa.Remarks_IfAny = item.Remarks_IfAny;

        //        aa.A_column = (item.A_column).ToUpper();
        //        aa.B_column = item.B_column;
        //        aa.C_column = item.C_column;
        //        aa.D_column = item.D_column;
        //        aa.E_column = item.E_column;

        //        aa.IsActive = item.IsActive;
        //        aa.IsDraft = item.IsDraft;
        //        aa.IsLock = item.IsLock;
        //        aa.IsPublicView = item.IsPublicView;

        //        aa.CreatedBy = item.CreatedBy;
        //        aa.CreatedOn = item.CreatedOn;
        //        aa.ModifyBy = item.ModifyBy;
        //        aa.ModifyOn = item.ModifyOn;

        //        aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
        //        aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
        //        aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
        //        aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);
        //    }
        //    return View("FormM_PreHearingNotice", aa);
        //}
        #endregion

        #region View Form-N Pre-Hearing Notice
        //[HttpGet]
        //public ActionResult FormN_PreHearingNotice(Int64 FormN_Id)
        //{
        //    ClsMethod_RespondentComplaintFormN_PreHearingNotice sdb = new ClsMethod_RespondentComplaintFormN_PreHearingNotice();
        //    ClsPrp_RespondentComplaint_FormN_PreHearingNotice aa = new ClsPrp_RespondentComplaint_FormN_PreHearingNotice();
        //    ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

        //    Int64 userFlag = 0;
        //    aa.prpongoingNotice = sdb.Display_RespondentComplaintFormN_PreHearingNoticeByID(FormN_Id, userFlag);
        //    foreach (var item in aa.prpongoingNotice)
        //    {
        //        aa.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
        //        aa.ComplaintFormN_ID = item.ComplaintFormN_ID;
        //        aa.ComplaintFormN_Code = item.ComplaintFormN_Code;

        //        aa.Complainant_Name = (item.Complainant_Name).ToUpper(); ;
        //        aa.ComplainantOther_Name = item.ComplainantOther_Name;
        //        aa.ComplainantOtherBrief_Name = item.ComplainantOtherBrief_Name;
        //        aa.Complainant_EmailAddress = item.Complainant_EmailAddress;
        //        aa.Complainant_MobileNumber = item.Complainant_MobileNumber;
        //        aa.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;

        //        aa.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
        //        aa.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
        //        aa.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
        //        aa.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
        //        aa.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

        //        aa.AuthorizedRepresentativeCounsel_Name = item.AuthorizedRepresentativeCounsel_Name;
        //        aa.AuthorizedRepresentativeCounsel_EmailAddress = item.AuthorizedRepresentativeCounsel_EmailAddress;
        //        aa.Respondent_Name = item.Respondent_Name;
        //        aa.RespondentOther_Name = item.RespondentOther_Name;
        //        aa.RespondentOtherBrief_Name = item.RespondentOtherBrief_Name;
        //        aa.Respondent_EmailAddress = item.Respondent_EmailAddress;
        //        aa.Respondent_MobileNumber = item.Respondent_MobileNumber;
        //        aa.Respondent_LandlineFaxNumber = item.Respondent_LandlineFaxNumber;

        //        aa.ServiceNoticesRespondent_AddressLine1 = item.ServiceNoticesRespondent_AddressLine1;
        //        aa.ServiceNoticesRespondent_AddressLine2 = item.ServiceNoticesRespondent_AddressLine2;
        //        aa.ServiceNoticesRespondent_AddressStateCode = item.ServiceNoticesRespondent_AddressStateCode;
        //        aa.ServiceNoticesRespondent_AddressDistrictCode = item.ServiceNoticesRespondent_AddressDistrictCode;
        //        aa.ServiceNoticesRespondent_AddressPIN = item.ServiceNoticesRespondent_AddressPIN;

        //        aa.PreHearingDate_IndexID = item.PreHearingDate_IndexID;
        //        aa.PreHearingDate_ID = item.PreHearingDate_ID;
        //        aa.ComplainantApplicant_RelatedComplaint_ID = item.ComplainantApplicant_RelatedComplaint_ID;
        //        aa.ComplainantApplicant_RelatedComplaint_Code = item.ComplainantApplicant_RelatedComplaint_Code;
        //        aa.ComplaintType_MN = item.ComplaintType_MN;

        //        aa.PreHearingDate = item.PreHearingDate;
        //        aa.PreHearingTime = item.PreHearingTime;
        //        aa.PreHearingBench = item.PreHearingBench;
        //        aa.PreHearingFixedForCode = item.PreHearingFixedForCode;
        //        aa.PreHearingFixedForName = item.PreHearingFixedForName;
        //        aa.PreHearingStatus = item.PreHearingStatus;
        //        aa.Remarks_IfAny = item.Remarks_IfAny;

        //        aa.A_column = (item.A_column).ToUpper();
        //        aa.B_column = item.B_column;
        //        aa.C_column = item.C_column;
        //        aa.D_column = item.D_column;
        //        aa.E_column = item.E_column;

        //        aa.IsActive = item.IsActive;
        //        aa.IsDraft = item.IsDraft;
        //        aa.IsLock = item.IsLock;
        //        aa.IsPublicView = item.IsPublicView;

        //        aa.CreatedBy = item.CreatedBy;
        //        aa.CreatedOn = item.CreatedOn;
        //        aa.ModifyBy = item.ModifyBy;
        //        aa.ModifyOn = item.ModifyOn;

        //        aa.ServiceNoticesComplainant_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesComplainant_AddressStateCode);
        //        aa.ServiceNoticesComplainant_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesComplainant_AddressDistrictCode);
        //        aa.ServiceNoticesRespondent_AddressStateCodeName = objdis.State_Name(item.ServiceNoticesRespondent_AddressStateCode);
        //        aa.ServiceNoticesRespondent_AddressDistrictCodeName = objdis.District_Name(item.ServiceNoticesRespondent_AddressDistrictCode);
        //    }
        //    return View("FormN_PreHearingNotice", aa);
        //}
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
    }
}