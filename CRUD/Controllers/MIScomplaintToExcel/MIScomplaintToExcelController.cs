using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CRUD.Models.MIScomplaintToExcel;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style.XmlAccess;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using CRUD.Models.Promoter;
using CRUD.Models.Master;
// using Microsoft.Interop.Excel;

namespace CRUD.Controllers.MIScomplaintToExcel
{
    [Authorize]
    [Authorize(Roles = "Authority, HelpDesk, SecretaryRERA, ManagerDesk, LegalAdvisorDesk, PStoMembers")]
    public class MIScomplaintToExcelController : Controller
    {
        
        #region Form-M InComplete Reminder Emails and SMSs (Notice)
        [HttpGet]
        public ActionResult FormMcomplaintReminderEmailsSchedulerContentDetails(Int64 FormMId, Int64 FormMcode, string ComplaintDNumber)
        {
            ClsMethodMIS_FormMcomplaintReminderEmailsDetails sdb = new ClsMethodMIS_FormMcomplaintReminderEmailsDetails();
            ClsMethodMIS_FormMcomplaintReminderSMSsDetails sdbSMSgateway = new ClsMethodMIS_FormMcomplaintReminderSMSsDetails();
            ClsprpMIS_FormMInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_FormMInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_FormMcomplaintSchedulerReminderEmailsDetails_ByID(FormMId, FormMcode, ComplaintDNumber, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_FormMcomplaintSchedulerReminderSMSsDetails_ByID(FormMId, FormMcode, ComplaintDNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.FormM_Reminder_IndexID = item.FormM_Reminder_IndexID;
                getObj.FormM_Reminder_ID = item.FormM_Reminder_ID;
                getObj.RelatedComplaintFormM_ID = item.RelatedComplaintFormM_ID;

                getObj.Complainant_Name = item.Complainant_Name;
                getObj.Respondent_Name = item.Respondent_Name;
                getObj.Complainant_Mobile_Number = item.Complainant_Mobile_Number;
                getObj.Complainant_Email_ID = item.Complainant_Email_ID;

                getObj.RelatedComplaintFormM_DiaryNumber = item.RelatedComplaintFormM_DiaryNumber;
                getObj.ApplicationDateFormM = item.ApplicationDateFormM;

                getObj.RelatedComplaint_ID = item.RelatedComplaint_ID;
                getObj.RelatedComplaint_DiaryNumber = item.RelatedComplaint_DiaryNumber;
                getObj.ComplaintType_MN = item.ComplaintType_MN;
                getObj.IsTransferCase = item.IsTransferCase;
                getObj.TransferTypeOption = item.TransferTypeOption;
                getObj.TransferDate = item.TransferDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;

                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;
                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;

                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;                
            }
            return View("FormMcomplaintReminderEmailsSchedulerContentDetails", getObj);
        }

        [HttpGet]
        public ActionResult FormMtransferReminderEmailsSchedulerContentDetails(Int64 FormMId, Int64 FormMcode, string ComplaintDNumber)
        {
            ClsMethodMIS_FormMcomplaintReminderEmailsDetails sdb = new ClsMethodMIS_FormMcomplaintReminderEmailsDetails();
            ClsMethodMIS_FormMcomplaintReminderSMSsDetails sdbSMSgateway = new ClsMethodMIS_FormMcomplaintReminderSMSsDetails();
            ClsprpMIS_FormMInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_FormMInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_FormMcomplaintSchedulerReminderEmailsDetails_ByID(FormMId, FormMcode, ComplaintDNumber, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_FormMcomplaintSchedulerReminderSMSsDetails_ByID(FormMId, FormMcode, ComplaintDNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.FormM_Reminder_IndexID = item.FormM_Reminder_IndexID;
                getObj.FormM_Reminder_ID = item.FormM_Reminder_ID;
                getObj.RelatedComplaintFormM_ID = item.RelatedComplaintFormM_ID;

                getObj.Complainant_Name = item.Complainant_Name;
                getObj.Respondent_Name = item.Respondent_Name;
                getObj.Complainant_Mobile_Number = item.Complainant_Mobile_Number;
                getObj.Complainant_Email_ID = item.Complainant_Email_ID;

                getObj.RelatedComplaintFormM_DiaryNumber = item.RelatedComplaintFormM_DiaryNumber;
                getObj.ApplicationDateFormM = item.ApplicationDateFormM;

                getObj.RelatedComplaint_ID = item.RelatedComplaint_ID;
                getObj.RelatedComplaint_DiaryNumber = item.RelatedComplaint_DiaryNumber;
                getObj.ComplaintType_MN = item.ComplaintType_MN;
                getObj.IsTransferCase = item.IsTransferCase;
                getObj.TransferTypeOption = item.TransferTypeOption;
                getObj.TransferDate = item.TransferDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;

                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;
                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;

                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("FormMtransferReminderEmailsSchedulerContentDetails", getObj);
        }
        #endregion

        #region Form-N InComplete Reminder Emails and SMSs (Notice)
        [HttpGet]
        public ActionResult FormNcomplaintReminderEmailsSchedulerContentDetails(Int64 FormNId, Int64 FormNcode, string ComplaintDNumber)
        {
            ClsMethodMIS_FormNcomplaintReminderEmailsDetails sdb = new ClsMethodMIS_FormNcomplaintReminderEmailsDetails();
            ClsMethodMIS_FormNcomplaintReminderSMSsDetails sdbSMSgateway = new ClsMethodMIS_FormNcomplaintReminderSMSsDetails();
            ClsprpMIS_FormNInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_FormNInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_FormNcomplaintSchedulerReminderEmailsDetails_ByID(FormNId, FormNcode, ComplaintDNumber, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_FormNcomplaintSchedulerReminderSMSsDetails_ByID(FormNId, FormNcode, ComplaintDNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.FormN_Reminder_IndexID = item.FormN_Reminder_IndexID;
                getObj.FormN_Reminder_ID = item.FormN_Reminder_ID;
                getObj.RelatedComplaintFormN_ID = item.RelatedComplaintFormN_ID;

                getObj.Complainant_Name = item.Complainant_Name;
                getObj.Respondent_Name = item.Respondent_Name;
                getObj.Complainant_Mobile_Number = item.Complainant_Mobile_Number;
                getObj.Complainant_Email_ID = item.Complainant_Email_ID;

                getObj.RelatedComplaintFormN_DiaryNumber = item.RelatedComplaintFormN_DiaryNumber;
                getObj.ApplicationDateFormN = item.ApplicationDateFormN;

                getObj.RelatedComplaint_ID = item.RelatedComplaint_ID;
                getObj.RelatedComplaint_DiaryNumber = item.RelatedComplaint_DiaryNumber;
                getObj.ComplaintType_MN = item.ComplaintType_MN;
                getObj.IsTransferCase = item.IsTransferCase;
                getObj.TransferTypeOption = item.TransferTypeOption;
                getObj.TransferDate = item.TransferDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;

                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;
                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;

                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("FormNcomplaintReminderEmailsSchedulerContentDetails", getObj);
        }

        [HttpGet]
        public ActionResult FormNtransferReminderEmailsSchedulerContentDetails(Int64 FormNId, Int64 FormNcode, string ComplaintDNumber)
        {
            ClsMethodMIS_FormNcomplaintReminderEmailsDetails sdb = new ClsMethodMIS_FormNcomplaintReminderEmailsDetails();
            ClsMethodMIS_FormNcomplaintReminderSMSsDetails sdbSMSgateway = new ClsMethodMIS_FormNcomplaintReminderSMSsDetails();
            ClsprpMIS_FormNInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_FormNInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_FormNcomplaintSchedulerReminderEmailsDetails_ByID(FormNId, FormNcode, ComplaintDNumber, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_FormNcomplaintSchedulerReminderSMSsDetails_ByID(FormNId, FormNcode, ComplaintDNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.FormN_Reminder_IndexID = item.FormN_Reminder_IndexID;
                getObj.FormN_Reminder_ID = item.FormN_Reminder_ID;
                getObj.RelatedComplaintFormN_ID = item.RelatedComplaintFormN_ID;

                getObj.Complainant_Name = item.Complainant_Name;
                getObj.Respondent_Name = item.Respondent_Name;
                getObj.Complainant_Mobile_Number = item.Complainant_Mobile_Number;
                getObj.Complainant_Email_ID = item.Complainant_Email_ID;

                getObj.RelatedComplaintFormN_DiaryNumber = item.RelatedComplaintFormN_DiaryNumber;
                getObj.ApplicationDateFormN = item.ApplicationDateFormN;

                getObj.RelatedComplaint_ID = item.RelatedComplaint_ID;
                getObj.RelatedComplaint_DiaryNumber = item.RelatedComplaint_DiaryNumber;
                getObj.ComplaintType_MN = item.ComplaintType_MN;
                getObj.IsTransferCase = item.IsTransferCase;
                getObj.TransferTypeOption = item.TransferTypeOption;
                getObj.TransferDate = item.TransferDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;

                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;
                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;

                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("FormNtransferReminderEmailsSchedulerContentDetails", getObj);
        }
        #endregion

    }
}
