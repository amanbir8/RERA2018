using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CRUD.Models.MISrealestateagentToExcel;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style.XmlAccess;
// using Microsoft.Interop.Excel;
using System.Threading;
using System.Threading.Tasks;

namespace CRUD.Controllers.MISrealestateagentToExcel
{
    [Authorize]
    [Authorize(Roles = "Authority, HelpDesk, SecretaryRERA, ManagerDesk, LegalAdvisorDesk, PStoMembers")]
    public class MISrealestateagentToExcelController : Controller
    {

        #region RealEstate Agents Address Directory (MIS Reports)
        [HttpGet]
        public ActionResult Display_AgentAddressDirectoryDetailsForInProcessMIS()
            {
            ClsMethod_MIS_AgentAddressDirectoryDetails sdb = new ClsMethod_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryDetails getObj = new Clsprp_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryExportExcel aaXls = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            String Agent_RegTypeFlag = "1"; // 1. Agent  2. RenewalAgent
            Session["AgentRegType"] = Agent_RegTypeFlag;

            getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForInProcessApplication(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_AgentAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_AgentAddressDirectoryExportExcel();
                
                aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate ?? DateTime.MinValue;
                aaXlsInner.reranumber = item.reranumber??"NA";
                aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                aaXlsInner.Permanent_AddressLine1 = item.P_AddressLine1;
                aaXlsInner.Permanent_AddressLine2 = item.P_AddressLine2;
                aaXlsInner.Permanent_District = item.P_AddressDistrictCode;
                aaXlsInner.Permanent_State = item.P_AddressStateCode;
                aaXlsInner.Permanent_PIN = item.P_AddressPIN;

                aaXlsInner.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                aaXlsInner.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                aaXlsInner.RegOffice_District = item.RegOffice_AddressDistrictCode;
                aaXlsInner.RegOffice_State = item.RegOffice_AddressStateCode;
                aaXlsInner.RegOffice_PIN = item.RegOffice_AddressPIN;

                aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                aaXlsInner.BussinessCommunication_AddressLine1 = item.BComm_AddressLine1;
                aaXlsInner.BussinessCommunication_AddressLine2 = item.BComm_AddressLine2;
                aaXlsInner.BussinessCommunication_District = item.BComm_AddressDistrictCode;
                aaXlsInner.BussinessCommunication_State = item.BComm_AddressStateCode;
                aaXlsInner.BussinessCommunication_PIN = item.BComm_AddressPIN;

                aaXlsInner.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                aaXlsInner.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                aaXlsInner.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                aaXlsInner.EmailAddress = item.EmailAddress;
                aaXlsInner.MobileNumber = item.MobileNumber;               

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentAddressDirectoryMIS"] = aaXls.prpongoing;
            ViewBag.choicetype = Agent_RegTypeFlag;
            return View("Display_AgentAddressDirectoryDetailsForInProcessMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_AgentAddressDirectoryDetailsForInProcessMIS(string Agent_RegTypeFlag, DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_AgentAddressDirectoryDetails sdb = new ClsMethod_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryDetails getObj = new Clsprp_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryExportExcel aaXls = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;
                String AgentRegType = Agent_RegTypeFlag; // 1. Agent  2. RenewalAgent
                Session["AgentRegType"] = AgentRegType;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForInProcessApplication_ByParmDate(UserID_Role, FromDateM, ToDateM, AgentRegType).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_AgentAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

                    aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                    aaXlsInner.RenewalAgent_DiaryNumber = item.RenewalAgent_DiaryNumber;
                    aaXlsInner.reranumber = item.reranumber;
                    aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate ?? DateTime.MinValue;
                    aaXlsInner.RenewalApplication_Date = item.RenewalAgent_Diary_ApplicationDate ?? DateTime.MinValue;
                    aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                    aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                    aaXlsInner.Permanent_AddressLine1 = item.P_AddressLine1;
                    aaXlsInner.Permanent_AddressLine2 = item.P_AddressLine2;
                    aaXlsInner.Permanent_District = item.P_AddressDistrictCode;
                    aaXlsInner.Permanent_State = item.P_AddressStateCode;
                    aaXlsInner.Permanent_PIN = item.P_AddressPIN;

                    aaXlsInner.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    aaXlsInner.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    aaXlsInner.RegOffice_District = item.RegOffice_AddressDistrictCode;
                    aaXlsInner.RegOffice_State = item.RegOffice_AddressStateCode;
                    aaXlsInner.RegOffice_PIN = item.RegOffice_AddressPIN;

                    aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                    aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                    aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                    aaXlsInner.BussinessCommunication_AddressLine1 = item.BComm_AddressLine1;
                    aaXlsInner.BussinessCommunication_AddressLine2 = item.BComm_AddressLine2;
                    aaXlsInner.BussinessCommunication_District = item.BComm_AddressDistrictCode;
                    aaXlsInner.BussinessCommunication_State = item.BComm_AddressStateCode;
                    aaXlsInner.BussinessCommunication_PIN = item.BComm_AddressPIN;

                    aaXlsInner.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                    aaXlsInner.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    aaXlsInner.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                    aaXlsInner.EmailAddress = item.EmailAddress;
                    aaXlsInner.MobileNumber = item.MobileNumber;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelRealEstateAgentAddressDirectoryMIS"] = aaXls.prpongoing;
                ViewBag.choicetype = AgentRegType;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_AgentAddressDirectoryDetailsForInProcessMIS", getObj);
        }
        



        [HttpGet]
        public ActionResult Display_AgentAddressDirectoryDetailsForRegisteredAgentsMIS()
        {
            ClsMethod_MIS_AgentAddressDirectoryDetails sdb = new ClsMethod_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryDetails getObj = new Clsprp_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryExportExcel aaXls = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            String Agent_RegTypeFlag = "1"; // 1. Agent  2. RenewalAgent
            Session["AgentRegType"] = Agent_RegTypeFlag;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForRegisteredAgents(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_AgentAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

                aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aaXlsInner.reranumber = item.reranumber;
                aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate ?? DateTime.MinValue;
                aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                aaXlsInner.Permanent_AddressLine1 = item.P_AddressLine1;
                aaXlsInner.Permanent_AddressLine2 = item.P_AddressLine2;
                aaXlsInner.Permanent_District = item.P_AddressDistrictCode;
                aaXlsInner.Permanent_State = item.P_AddressStateCode;
                aaXlsInner.Permanent_PIN = item.P_AddressPIN;

                aaXlsInner.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                aaXlsInner.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                aaXlsInner.RegOffice_District = item.RegOffice_AddressDistrictCode;
                aaXlsInner.RegOffice_State = item.RegOffice_AddressStateCode;
                aaXlsInner.RegOffice_PIN = item.RegOffice_AddressPIN;

                aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                aaXlsInner.BussinessCommunication_AddressLine1 = item.BComm_AddressLine1;
                aaXlsInner.BussinessCommunication_AddressLine2 = item.BComm_AddressLine2;
                aaXlsInner.BussinessCommunication_District = item.BComm_AddressDistrictCode;
                aaXlsInner.BussinessCommunication_State = item.BComm_AddressStateCode;
                aaXlsInner.BussinessCommunication_PIN = item.BComm_AddressPIN;

                aaXlsInner.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                aaXlsInner.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                aaXlsInner.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                aaXlsInner.EmailAddress = item.EmailAddress;
                aaXlsInner.MobileNumber = item.MobileNumber;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentAddressDirectoryMIS"] = aaXls.prpongoing;
            ViewBag.choicetype = Agent_RegTypeFlag;

            return View("Display_AgentAddressDirectoryDetailsForRegisteredAgentsMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_AgentAddressDirectoryDetailsForRegisteredAgentsMIS(string Agent_RegTypeFlag, DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_AgentAddressDirectoryDetails sdb = new ClsMethod_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryDetails getObj = new Clsprp_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryExportExcel aaXls = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;
                String AgentRegType = Agent_RegTypeFlag; // 1. Agent  2. RenewalAgent
                Session["AgentRegType"] = AgentRegType;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForRegisteredAgents_ByParmDate(UserID_Role, FromDateM, ToDateM, AgentRegType).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_AgentAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_AgentAddressDirectoryExportExcel();

                    aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                    aaXlsInner.reranumber = item.reranumber;
                    aaXlsInner.RenewalAgent_DiaryNumber = item.RenewalAgent_DiaryNumber;
                    aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate ?? DateTime.MinValue;
                    aaXlsInner.RenewalApplication_Date = item.RenewalAgent_Diary_ApplicationDate ?? DateTime.MinValue;
                    aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                    aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                    aaXlsInner.Permanent_AddressLine1 = item.P_AddressLine1;
                    aaXlsInner.Permanent_AddressLine2 = item.P_AddressLine2;
                    aaXlsInner.Permanent_District = item.P_AddressDistrictCode;
                    aaXlsInner.Permanent_State = item.P_AddressStateCode;
                    aaXlsInner.Permanent_PIN = item.P_AddressPIN;

                    aaXlsInner.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    aaXlsInner.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    aaXlsInner.RegOffice_District = item.RegOffice_AddressDistrictCode;
                    aaXlsInner.RegOffice_State = item.RegOffice_AddressStateCode;
                    aaXlsInner.RegOffice_PIN = item.RegOffice_AddressPIN;

                    aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                    aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                    aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                    aaXlsInner.BussinessCommunication_AddressLine1 = item.BComm_AddressLine1;
                    aaXlsInner.BussinessCommunication_AddressLine2 = item.BComm_AddressLine2;
                    aaXlsInner.BussinessCommunication_District = item.BComm_AddressDistrictCode;
                    aaXlsInner.BussinessCommunication_State = item.BComm_AddressStateCode;
                    aaXlsInner.BussinessCommunication_PIN = item.BComm_AddressPIN;

                    aaXlsInner.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                    aaXlsInner.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    aaXlsInner.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                    aaXlsInner.EmailAddress = item.EmailAddress;
                    aaXlsInner.MobileNumber = item.MobileNumber;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                ViewBag.choicetype = AgentRegType;
                Session["modelRealEstateAgentAddressDirectoryMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_AgentAddressDirectoryDetailsForRegisteredAgentsMIS", getObj);
        }

        //public void ExportToExcel()
        //{
        //    try
        //    {
        //        GridView gv = new GridView();
        //        gv.DataSource = Session["modelRealEstateAgentAddressDirectoryMIS"];
        //        gv.DataBind();
        //        Response.ClearContent();
        //        Response.Buffer = true;
        //        string strDateFormat = string.Empty;
        //        strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
        //        Response.AddHeader("content-disposition", "attachment; filename=ListofRealestateAgentAddressDirectorys_" + strDateFormat + ".xls");
        //        Response.ContentType = "application/ms-excel";
        //        Response.Charset = "";
        //        StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //        gv.RenderControl(htw);
        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public void ExportToExcel()
        //{
        //    var data = Session["modelRealEstateAgentAddressDirectoryMIS"]
        //               as List<Clsprp_MIS_AgentAddressDirectoryExportExcel>;

        //    string agentTypeFlag = Convert.ToString(Session["AgentRegType"]);

        //    if (data == null || data.Count == 0)
        //        return;

        //    Response.ClearContent();
        //    Response.Buffer = true;

        //    string strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

        //    using (ExcelPackage excel = new ExcelPackage())
        //    {
        //        var ws = excel.Workbook.Worksheets.Add("Agent Address Directory");

        //        int col = 1;

        //        // ================= HEADER =================
        //        ws.Row(1).Style.Font.Bold = true;
        //        ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        //        ws.Cells[1, col++].Value = "S.No";

        //        // ws.Cells[1, col++].Value = "Agent Diary Number";
        //        if (agentTypeFlag == "2")
        //            ws.Cells[1, col++].Value = "RERA Registration Number";
        //        else
        //            ws.Cells[1, col++].Value = "Agent Diary Number";

        //        // ws.Cells[1, col++].Value = "Renewal Diary Number";

        //        // ws.Cells[1, col++].Value = "Agent Application Date";
        //        // ws.Cells[1, col++].Value = "Renewal Application Date";

        //        // ✅ Show ONLY when Agent Type = 1
        //        if (agentTypeFlag == "1")
        //        {
        //            ws.Cells[1, col++].Value = "Agent Application Date";
        //        }

        //        // ✅ Show ONLY when Agent Type = 2
        //        if (agentTypeFlag == "2")
        //        {
        //            ws.Cells[1, col++].Value = "Renewal Diary Number";
        //            ws.Cells[1, col++].Value = "Renewal Application Date";
        //        }

        //        ws.Cells[1, col++].Value = "Agent Name";
        //        ws.Cells[1, col++].Value = "Agent Type";

        //        // Permanent Address
        //        ws.Cells[1, col++].Value = "Permanent Address Line 1";
        //        ws.Cells[1, col++].Value = "Permanent Address Line 2";
        //        ws.Cells[1, col++].Value = "Permanent District";
        //        ws.Cells[1, col++].Value = "Permanent State";
        //        ws.Cells[1, col++].Value = "Permanent PIN";

        //        // Registered Office
        //        ws.Cells[1, col++].Value = "Reg Office Address Line 1";
        //        ws.Cells[1, col++].Value = "Reg Office Address Line 2";
        //        ws.Cells[1, col++].Value = "Reg Office District";
        //        ws.Cells[1, col++].Value = "Reg Office State";
        //        ws.Cells[1, col++].Value = "Reg Office PIN";

        //        // Business Place
        //        ws.Cells[1, col++].Value = "Business Address Line 1";
        //        ws.Cells[1, col++].Value = "Business Address Line 2";
        //        ws.Cells[1, col++].Value = "Business District";
        //        ws.Cells[1, col++].Value = "Business State";
        //        ws.Cells[1, col++].Value = "Business PIN";

        //        // Communication Address
        //        ws.Cells[1, col++].Value = "Comm Address Line 1";
        //        ws.Cells[1, col++].Value = "Comm Address Line 2";
        //        ws.Cells[1, col++].Value = "Comm District";
        //        ws.Cells[1, col++].Value = "Comm State";
        //        ws.Cells[1, col++].Value = "Comm PIN";

        //        // Signatory
        //        ws.Cells[1, col++].Value = "Authorized Signatory First Name";
        //        ws.Cells[1, col++].Value = "Authorized Signatory Middle Name";
        //        ws.Cells[1, col++].Value = "Authorized Signatory Last Name";

        //        // Contact
        //        ws.Cells[1, col++].Value = "Email";
        //        ws.Cells[1, col++].Value = "Mobile";

        //        // ================= DATA =================
        //        int row = 2;

        //        foreach (var item in data)
        //        {
        //            col = 1;

        //            ws.Cells[row, col++].Value = row - 1;

        //            ws.Cells[row, col++].Value = item.Agent_DiaryNumber;
        //            //  ws.Cells[row, col++].Value = item.RenewalAgent_DiaryNumber;

        //            //   ws.Cells[row, col++].Value = (item.Application_Date.HasValue && item.Application_Date.Value != DateTime.MinValue) ? item.Application_Date.Value.ToString("dd-MMM-yyyy") : "";
        //            //  ws.Cells[row, col++].Value = (item.RenewalApplication_Date.HasValue && item.RenewalApplication_Date.Value != DateTime.MinValue) ? item.RenewalApplication_Date.Value.ToString("dd-MMM-yyyy") : "";

        //            // ✅ Agent Type = 1
        //            if (agentTypeFlag == "1")
        //            {
        //                ws.Cells[row, col++].Value =
        //                    (item.Application_Date.HasValue && item.Application_Date.Value != DateTime.MinValue)
        //                    ? item.Application_Date.Value.ToString("dd-MMM-yyyy") : "";
        //            }

        //            // ✅ Agent Type = 2
        //            if (agentTypeFlag == "2")
        //            {
        //                ws.Cells[row, col++].Value = item.RenewalAgent_DiaryNumber;

        //                ws.Cells[row, col++].Value =
        //                    (item.RenewalApplication_Date.HasValue && item.RenewalApplication_Date.Value != DateTime.MinValue)
        //                    ? item.RenewalApplication_Date.Value.ToString("dd-MMM-yyyy") : "";
        //            }
        //            ws.Cells[row, col++].Value = item.RealEstateAgent_Name;
        //            ws.Cells[row, col++].Value = item.Agent_Type;

        //            // Permanent
        //            ws.Cells[row, col++].Value = item.Permanent_AddressLine1;
        //            ws.Cells[row, col++].Value = item.Permanent_AddressLine2;
        //            ws.Cells[row, col++].Value = item.Permanent_District;
        //            ws.Cells[row, col++].Value = item.Permanent_State;
        //            ws.Cells[row, col++].Value = item.Permanent_PIN;

        //            // Reg Office
        //            ws.Cells[row, col++].Value = item.RegOffice_AddressLine1;
        //            ws.Cells[row, col++].Value = item.RegOffice_AddressLine2;
        //            ws.Cells[row, col++].Value = item.RegOffice_District;
        //            ws.Cells[row, col++].Value = item.RegOffice_State;
        //            ws.Cells[row, col++].Value = item.RegOffice_PIN;

        //            // Business
        //            ws.Cells[row, col++].Value = item.BusinessPlace_AddressLine1;
        //            ws.Cells[row, col++].Value = item.BusinessPlace_AddressLine2;
        //            ws.Cells[row, col++].Value = item.BusinessPlace_District;
        //            ws.Cells[row, col++].Value = item.BusinessPlace_State;
        //            ws.Cells[row, col++].Value = item.BusinessPlace_PIN;

        //            // Communication
        //            ws.Cells[row, col++].Value = item.BussinessCommunication_AddressLine1;
        //            ws.Cells[row, col++].Value = item.BussinessCommunication_AddressLine2;
        //            ws.Cells[row, col++].Value = item.BussinessCommunication_District;
        //            ws.Cells[row, col++].Value = item.BussinessCommunication_State;
        //            ws.Cells[row, col++].Value = item.BussinessCommunication_PIN;

        //            // Signatory
        //            ws.Cells[row, col++].Value = item.AuthorizedSignatory_Name;
        //            ws.Cells[row, col++].Value = item.AuthorizedSignatory_MiddleName;
        //            ws.Cells[row, col++].Value = item.AuthorizedSignatory_LastName;

        //            // Contact
        //            ws.Cells[row, col++].Value = item.EmailAddress;
        //            ws.Cells[row, col++].Value = item.MobileNumber;

        //            row++;
        //        }

        //        int totalCols = col - 1;

        //        // ================= STYLING =================

        //        // AutoFit
        //        for (int i = 1; i <= totalCols; i++)
        //            ws.Column(i).AutoFit();

        //        // Header color
        //        ws.Cells[1, 1, 1, totalCols].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //        ws.Cells[1, 1, 1, totalCols].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

        //        // Borders
        //        using (var range = ws.Cells[1, 1, row - 1, totalCols])
        //        {
        //            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //        }

        //        // Freeze header row
        //        ws.View.FreezePanes(2, 1);

        //        // Filter
        //       // ws.Cells[1, 1, row - 1, totalCols].AutoFilter = true;

        //        // ================= RESPONSE =================
        //        using (var stream = new MemoryStream())
        //        {
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("content-disposition",
        //                "attachment; filename=AgentDirectory_" + strDateFormat + ".xlsx");

        //            excel.SaveAs(stream);
        //            stream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }
        //    }
        //}

        public void ExportToExcel()
        {
            var data = Session["modelRealEstateAgentAddressDirectoryMIS"]
                       as List<Clsprp_MIS_AgentAddressDirectoryExportExcel>;

            string agentTypeFlag = Convert.ToString(Session["AgentRegType"]);

            if (data == null || data.Count == 0)
                return;

            Response.ClearContent();
            Response.Buffer = true;

            string strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            using (ExcelPackage excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Agent Address Directory");

                int col = 1;

                // ================= HEADER =================
                ws.Row(1).Style.Font.Bold = true;
                ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[1, col++].Value = "S.No";

                // Type 1 only
                if (agentTypeFlag == "1")
                {
                    ws.Cells[1, col++].Value = "Agent Diary Number";
                }

                // Always show RERA
                ws.Cells[1, col++].Value = "RERA Registration Number";

                // Type-based date/diary columns
                if (agentTypeFlag == "1")
                {
                    ws.Cells[1, col++].Value = "Agent Application Date";
                }
                else
                {
                    ws.Cells[1, col++].Value = "Renewal Diary Number";
                    ws.Cells[1, col++].Value = "Renewal Application Date";
                }

                ws.Cells[1, col++].Value = "Agent Name";
                ws.Cells[1, col++].Value = "Agent Type";

                // Permanent Address
                ws.Cells[1, col++].Value = "Permanent Address Line 1";
                ws.Cells[1, col++].Value = "Permanent Address Line 2";
                ws.Cells[1, col++].Value = "Permanent District";
                ws.Cells[1, col++].Value = "Permanent State";
                ws.Cells[1, col++].Value = "Permanent PIN";

                // Registered Office
                ws.Cells[1, col++].Value = "Reg Office Address Line 1";
                ws.Cells[1, col++].Value = "Reg Office Address Line 2";
                ws.Cells[1, col++].Value = "Reg Office District";
                ws.Cells[1, col++].Value = "Reg Office State";
                ws.Cells[1, col++].Value = "Reg Office PIN";

                // Business Place
                ws.Cells[1, col++].Value = "Business Address Line 1";
                ws.Cells[1, col++].Value = "Business Address Line 2";
                ws.Cells[1, col++].Value = "Business District";
                ws.Cells[1, col++].Value = "Business State";
                ws.Cells[1, col++].Value = "Business PIN";

                // Communication Address
                ws.Cells[1, col++].Value = "Comm Address Line 1";
                ws.Cells[1, col++].Value = "Comm Address Line 2";
                ws.Cells[1, col++].Value = "Comm District";
                ws.Cells[1, col++].Value = "Comm State";
                ws.Cells[1, col++].Value = "Comm PIN";

                // Signatory
                ws.Cells[1, col++].Value = "Authorized Signatory First Name";
                ws.Cells[1, col++].Value = "Authorized Signatory Middle Name";
                ws.Cells[1, col++].Value = "Authorized Signatory Last Name";

                // Contact
                ws.Cells[1, col++].Value = "Email";
                ws.Cells[1, col++].Value = "Mobile";

                // ================= DATA =================
                int row = 2;

                foreach (var item in data)
                {
                    col = 1;

                    ws.Cells[row, col++].Value = row - 1;

                    // Type 1 only
                    if (agentTypeFlag == "1")
                    {
                        ws.Cells[row, col++].Value = item.Agent_DiaryNumber;
                    }

                    // Always RERA (from SP)
                    ws.Cells[row, col++].Value = item.reranumber;

                    if (agentTypeFlag == "1")
                    {
                        // Agent Application Date
                        ws.Cells[row, col++].Value =
                            (item.Application_Date.HasValue && item.Application_Date.Value != DateTime.MinValue)
                            ? item.Application_Date.Value.ToString("dd-MMM-yyyy") : "";
                    }
                    else
                    {
                        // Renewal Diary Number
                        ws.Cells[row, col++].Value = item.RenewalAgent_DiaryNumber;

                        // Renewal Application Date
                        ws.Cells[row, col++].Value =
                            (item.RenewalApplication_Date.HasValue && item.RenewalApplication_Date.Value != DateTime.MinValue)
                            ? item.RenewalApplication_Date.Value.ToString("dd-MMM-yyyy") : "";
                    }

                    ws.Cells[row, col++].Value = item.RealEstateAgent_Name;
                    ws.Cells[row, col++].Value = item.Agent_Type;

                    // Permanent
                    ws.Cells[row, col++].Value = item.Permanent_AddressLine1;
                    ws.Cells[row, col++].Value = item.Permanent_AddressLine2;
                    ws.Cells[row, col++].Value = item.Permanent_District;
                    ws.Cells[row, col++].Value = item.Permanent_State;
                    ws.Cells[row, col++].Value = item.Permanent_PIN;

                    // Reg Office
                    ws.Cells[row, col++].Value = item.RegOffice_AddressLine1;
                    ws.Cells[row, col++].Value = item.RegOffice_AddressLine2;
                    ws.Cells[row, col++].Value = item.RegOffice_District;
                    ws.Cells[row, col++].Value = item.RegOffice_State;
                    ws.Cells[row, col++].Value = item.RegOffice_PIN;

                    // Business
                    ws.Cells[row, col++].Value = item.BusinessPlace_AddressLine1;
                    ws.Cells[row, col++].Value = item.BusinessPlace_AddressLine2;
                    ws.Cells[row, col++].Value = item.BusinessPlace_District;
                    ws.Cells[row, col++].Value = item.BusinessPlace_State;
                    ws.Cells[row, col++].Value = item.BusinessPlace_PIN;

                    // Communication
                    ws.Cells[row, col++].Value = item.BussinessCommunication_AddressLine1;
                    ws.Cells[row, col++].Value = item.BussinessCommunication_AddressLine2;
                    ws.Cells[row, col++].Value = item.BussinessCommunication_District;
                    ws.Cells[row, col++].Value = item.BussinessCommunication_State;
                    ws.Cells[row, col++].Value = item.BussinessCommunication_PIN;

                    // Signatory
                    ws.Cells[row, col++].Value = item.AuthorizedSignatory_Name;
                    ws.Cells[row, col++].Value = item.AuthorizedSignatory_MiddleName;
                    ws.Cells[row, col++].Value = item.AuthorizedSignatory_LastName;

                    // Contact
                    ws.Cells[row, col++].Value = item.EmailAddress;
                    ws.Cells[row, col++].Value = item.MobileNumber;

                    row++;
                }

                int totalCols = col - 1;

                // ================= STYLING =================

                for (int i = 1; i <= totalCols; i++)
                    ws.Column(i).AutoFit();

                ws.Cells[1, 1, 1, totalCols].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[1, 1, 1, totalCols].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

                using (var range = ws.Cells[1, 1, row - 1, totalCols])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                ws.View.FreezePanes(2, 1);

                using (var stream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition",
                        "attachment; filename=AgentDirectory_" + strDateFormat + ".xlsx");

                    excel.SaveAs(stream);
                    stream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        [HttpGet]
        public ActionResult AgentAddressDirectoryDetailsForMIS(Int64 AgentId, string AgentRegType)
        {
            ClsMethod_MIS_AgentAddressDirectoryDetails sdb = new ClsMethod_MIS_AgentAddressDirectoryDetails();
            Clsprp_MIS_AgentAddressDirectoryDetails getObj = new Clsprp_MIS_AgentAddressDirectoryDetails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForMIS(AgentId, userRole, AgentRegType);

            foreach (var item in getObj.prpongoing)
            {
                getObj.Agent_DiaryNumber = item.Agent_DiaryNumber;
                getObj.RenewalAgent_DiaryNumber = item.RenewalAgent_DiaryNumber;
                getObj.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                getObj.RenewalAgent_Diary_ApplicationDate = item.RenewalAgent_Diary_ApplicationDate ?? DateTime.MinValue;
                getObj.Agent_ID = item.Agent_ID;
                getObj.Agent_Type = item.Agent_Type;
                getObj.Agent_TypeSTR = item.Agent_TypeSTR;
                getObj.Agent_Organization_Name = item.Agent_Organization_Name;

                getObj.P_AddressLine1 = item.P_AddressLine1;
                getObj.P_AddressLine2 = item.P_AddressLine2;
                getObj.P_AddressStateCode = item.P_AddressStateCode;
                getObj.P_AddressDistrictCode = item.P_AddressDistrictCode;
                getObj.P_AddressPIN = item.P_AddressPIN;

                getObj.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                getObj.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                getObj.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                getObj.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                getObj.RegOffice_AddressPIN = item.RegOffice_AddressPIN;

                getObj.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                getObj.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                getObj.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                getObj.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                getObj.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                getObj.BComm_AddressLine1 = item.BComm_AddressLine1;
                getObj.BComm_AddressLine2 = item.BComm_AddressLine2;
                getObj.BComm_AddressStateCode = item.BComm_AddressStateCode;
                getObj.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                getObj.BComm_AddressPIN = item.BComm_AddressPIN;

                getObj.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                getObj.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                getObj.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                getObj.MobileNumber = item.MobileNumber;
                getObj.EmailAddress = item.EmailAddress;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;                
            }
            return View("AgentAddressDirectoryDetailsForMIS", getObj);
        }
        #endregion

        #region Agent Certificate - QR Code Generation (MIS Reports) - (Agent and Renewal-Agent)

        #region QR Code For Registered Agents
        [HttpGet]
        public ActionResult Display_AgentQRcodeCertificateDetailsForRegisteredAgentsMIS()
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeCertificateExportExcel aaXls = new Clsprp_MIS_AgentQRcodeCertificateExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            //getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_AgentQRcodeCertificateExportExcel aaXlsInner = new Clsprp_MIS_AgentQRcodeCertificateExportExcel();

                aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate;
                aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                aaXlsInner.Father_AuthorizedPerson_Name = item.Agent_Father_AuthorizedPerson_Name;
                aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                aaXlsInner.RERA_RegistrationNumber = item.RERAnumberRegistration;
                aaXlsInner.RERA_RegistrationNumber_IssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERA_RegistrationNumber_ValidUptoDate = item.RERAnumberRegUptoDate;

                aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                aaXlsInner.RemarksIfAny = item.RemarksIfAny;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentQRcodeCertificateMIS"] = aaXls.prpongoing;

            return View("Display_AgentQRcodeCertificateDetailsForRegisteredAgentsMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_AgentQRcodeCertificateDetailsForRegisteredAgentsMIS(Clsprp_MIS_AgentQRcodeCertificateDetails smodel)//(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeCertificateExportExcel aaXls = new Clsprp_MIS_AgentQRcodeCertificateExportExcel();

            try
            {
                switch (smodel.IsRangeValueDateInputFlag)
                {
                    case 1:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        break;
                    case 2:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        ModelState.Remove("InputEntry_FromDate");
                        ModelState.Remove("InputEntry_ToDate");
                        break;
                    default:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        break;
                }

                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationMode = 0;
                    Int32 flagApplicationDate = 0;
                    Int32 varprmRange = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;

                    flagApplicationMode = smodel.IsApplicationModeFlag; //radioSearchFor
                    flagApplicationDate = smodel.IsApplicationDateFlag; //radioRangeDifferentMode

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    switch (varprmRange)
                    {
                        case 1:
                            FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                            ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;
                            varprmMonth = 0;
                            varprmYear = 0;
                            break;
                        case 2:
                            Int32 get_month = varprmMonth;
                            Int32 get_year = varprmYear;
                            DateTime InputEntry_Date = new DateTime(get_year, get_month, 1);
                            DateTime InputEntry_lastDayOfMonth = InputEntry_Date.AddMonths(1).AddDays(-1);
                            FromDateM = InputEntry_Date;
                            ToDateM = InputEntry_lastDayOfMonth;
                            break;
                        default:
                            FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                            ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;
                            varprmMonth = 0;
                            varprmYear = 0;
                            break;
                    }

                    //DateTime dtvalue = new DateTime(0001, 1, 1);
                    //DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                    //DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                    //getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList(), token);  //UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                        //Task has been started
                        Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList(), token);  //UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);
                    });
                    }
                    await Task.WhenAll(taskA);


                    ViewBag.data = "true";

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_AgentQRcodeCertificateExportExcel aaXlsInner = new Clsprp_MIS_AgentQRcodeCertificateExportExcel();

                        aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                        aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate;
                        aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                        aaXlsInner.Father_AuthorizedPerson_Name = item.Agent_Father_AuthorizedPerson_Name;
                        aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                        aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                        aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                        aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                        aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                        aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                        aaXlsInner.RERA_RegistrationNumber = item.RERAnumberRegistration;
                        aaXlsInner.RERA_RegistrationNumber_IssueDate = item.RERAnumberIssueDate;
                        aaXlsInner.RERA_RegistrationNumber_ValidUptoDate = item.RERAnumberRegUptoDate;

                        aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                        aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                        aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                        aaXlsInner.RemarksIfAny = item.RemarksIfAny;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelRealEstateAgentQRcodeCertificateMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_AgentQRcodeCertificateDetailsForRegisteredAgentsMIS", getObj);
        }

        [HttpGet]
        public ActionResult AgentQRcodeCertificateDetailsForRegisteredAgentsMIS(Int64 AgentId)
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeCertificateDetails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents_ForMIS(AgentId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.Agent_DiaryNumber = item.Agent_DiaryNumber;
                getObj.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                getObj.Agent_ID = item.Agent_ID;
                getObj.Agent_Type = item.Agent_Type;
                getObj.Agent_TypeSTR = item.Agent_TypeSTR;

                getObj.Agent_Organization_Name = item.Agent_Organization_Name;
                getObj.Agent_Father_AuthorizedPerson_Name = item.Agent_Father_AuthorizedPerson_Name;

                getObj.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                getObj.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                getObj.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                getObj.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                getObj.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                getObj.RERAnumberRegistration = item.RERAnumberRegistration;
                getObj.RERAnumberIssueDate = item.RERAnumberIssueDate;
                getObj.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                getObj.QRcodeImage_A = item.QRcodeImage_A;
                getObj.QRcodeImage_B = item.QRcodeImage_B;
                getObj.QRcodeImage_C = item.QRcodeImage_C;
                getObj.RemarksIfAny = item.RemarksIfAny;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("AgentQRcodeCertificateDetailsForRegisteredAgentsMIS", getObj);
        }

        public void ExportwithQRcodeToExcel()
        {

            var objXlslist = Session["modelRealEstateAgentQRcodeCertificateMIS"] as List<Clsprp_MIS_AgentQRcodeCertificateExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Agent Name";
            workSheet.Cells[1, 5].Value = "Father's / Authorized Person's Name";
            workSheet.Cells[1, 6].Value = "Agent Type";
            workSheet.Cells[1, 7].Value = "Place of Bussiness - Address Line 1";
            workSheet.Cells[1, 8].Value = "Place of Bussiness - Address Line 2";
            workSheet.Cells[1, 9].Value = "Place of Bussiness - District";
            workSheet.Cells[1, 10].Value = "Place of Bussiness - State";
            workSheet.Cells[1, 11].Value = "Place of Bussiness - PIN";
            workSheet.Cells[1, 12].Value = "RERA Number";
            workSheet.Cells[1, 13].Value = "Issue Date";
            workSheet.Cells[1, 14].Value = "Valid upto Date";
            workSheet.Cells[1, 15].Value = "QR Code Image";
            //Body of table  
            //  
            int recordIndex = 2;
            Int32 qrvarAgent_Type = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Agent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.ToString("dd-MMM-yyyy");
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.RealEstateAgent_Name;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.Father_AuthorizedPerson_Name;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Agent_Type;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.BusinessPlace_AddressLine1;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.BusinessPlace_AddressLine2;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.BusinessPlace_District;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.BusinessPlace_State;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.BusinessPlace_PIN;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.RERA_RegistrationNumber;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.RERA_RegistrationNumber_IssueDate.HasValue ? QRcodeItem.RERA_RegistrationNumber_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.RERA_RegistrationNumber_ValidUptoDate.HasValue ? QRcodeItem.RERA_RegistrationNumber_ValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                
                if (QRcodeItem.Agent_Type == "Individual")
                {
                    qrvarAgent_Type = 1;
                }
                Stream streamQR = new MemoryStream(GenerateQrCodeByBytesForAgents(QRcodeItem.RERA_RegistrationNumber, QRcodeItem.RERA_RegistrationNumber_ValidUptoDate, QRcodeItem.RealEstateAgent_Name, qrvarAgent_Type, QRcodeItem.Father_AuthorizedPerson_Name, QRcodeItem.BusinessPlace_AddressLine1, QRcodeItem.BusinessPlace_AddressLine2, QRcodeItem.BusinessPlace_District, QRcodeItem.BusinessPlace_State));
                var cfPhoto = System.Drawing.Image.FromStream(streamQR);
                var cfBm = new Bitmap(cfPhoto, new Size(215, 170));
                ExcelPicture imgQR = workSheet.Drawings.AddPicture(QRcodeItem.Agent_DiaryNumber, cfBm);
                imgQR.SetPosition(recordIndex - 1, 5, 14, 5);
                imgQR.SetSize(90, 90);
                //workSheet.Cells[recordIndex, 5].Value= img; // GenerateQrCode1(); // QRcodeItem.RealEstateAgent_Name;
                workSheet.Row(recordIndex).Height = 100;
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

            workSheet.Cells["A1:O1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:O1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 15])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRealestateAgentQRcodeCertificates_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region QR Code For Offline Agents
        [HttpGet]
        public ActionResult Display_AgentQRcodeCertificateDetailsForOfflineAgentsMIS()
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeOfflineCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeOfflineCertificateDetails();
            Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel aaXls = new Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            //getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel aaXlsInner = new Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel();
                
                aaXlsInner.OfflineAgents_ReferenceNumber = item.OfflineAgents_ReferenceNumber;
                aaXlsInner.OfflineAgents_IssueDate = item.OfflineAgents_IssueDate;
                aaXlsInner.OfflineAgents_AgentType = item.OfflineAgents_AgentType;

                aaXlsInner.OfflineAgents_AgentName_OrganizationName = item.OfflineAgents_AgentName_OrganizationName;
                aaXlsInner.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = item.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress;

                aaXlsInner.OfflineAgents_RERAregistrationNumber = item.OfflineAgents_RERAregistrationNumber;
                aaXlsInner.OfflineAgents_RERAregistrationIssueDate = item.OfflineAgents_RERAregistrationIssueDate;
                aaXlsInner.OfflineAgents_RERAregistrationValidUptoDate = item.OfflineAgents_RERAregistrationValidUptoDate;

                aaXlsInner.OfflineAgents_PlaceOfBussinessAddress = item.OfflineAgents_PlaceOfBussinessAddress;
                aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                aaXlsInner.OfflineAgents_RemarksIfAny = item.OfflineAgents_RemarksIfAny;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentQRcodeOfflineCertificateMIS"] = aaXls.prpongoing;

            return View("Display_AgentQRcodeCertificateDetailsForOfflineAgentsMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_AgentQRcodeCertificateDetailsForOfflineAgentsMIS(Clsprp_MIS_AgentQRcodeCertificateDetails smodel)//(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeOfflineCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeOfflineCertificateDetails();
            Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel aaXls = new Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel();
            try
            {
                switch (smodel.IsRangeValueDateInputFlag)
                {
                    case 1:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        break;
                    case 2:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        ModelState.Remove("InputEntry_FromDate");
                        ModelState.Remove("InputEntry_ToDate");
                        break;
                    default:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        break;
                }

                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationMode = 0;
                    Int32 flagApplicationDate = 0;
                    Int32 varprmRange = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;

                    flagApplicationMode = smodel.IsApplicationModeFlag; //radioSearchFor
                    flagApplicationDate = smodel.IsApplicationDateFlag; //radioRangeDifferentMode

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    switch (varprmRange)
                    {
                        case 1:
                            FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                            ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;
                            varprmMonth = 0;
                            varprmYear = 0;
                            break;
                        case 2:
                            Int32 get_month = varprmMonth;
                            Int32 get_year = varprmYear;
                            DateTime InputEntry_Date = new DateTime(get_year, get_month, 1);
                            DateTime InputEntry_lastDayOfMonth = InputEntry_Date.AddMonths(1).AddDays(-1);
                            FromDateM = InputEntry_Date;
                            ToDateM = InputEntry_lastDayOfMonth;
                            break;
                        default:
                            FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                            ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;
                            varprmMonth = 0;
                            varprmYear = 0;
                            break;
                    }

                    //getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList(), token);  //UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                        //Task has been started
                        Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList(), token);  //UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);
                    });
                    }
                    await Task.WhenAll(taskA);

                    ViewBag.data = "true";

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel aaXlsInner = new Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel();

                        aaXlsInner.OfflineAgents_ReferenceNumber = item.OfflineAgents_ReferenceNumber;
                        aaXlsInner.OfflineAgents_IssueDate = item.OfflineAgents_IssueDate;
                        aaXlsInner.OfflineAgents_AgentType = item.OfflineAgents_AgentType;

                        aaXlsInner.OfflineAgents_AgentName_OrganizationName = item.OfflineAgents_AgentName_OrganizationName;
                        aaXlsInner.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = item.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress;

                        aaXlsInner.OfflineAgents_RERAregistrationNumber = item.OfflineAgents_RERAregistrationNumber;
                        aaXlsInner.OfflineAgents_RERAregistrationIssueDate = item.OfflineAgents_RERAregistrationIssueDate;
                        aaXlsInner.OfflineAgents_RERAregistrationValidUptoDate = item.OfflineAgents_RERAregistrationValidUptoDate;

                        aaXlsInner.OfflineAgents_PlaceOfBussinessAddress = item.OfflineAgents_PlaceOfBussinessAddress;
                        aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                        aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                        aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                        aaXlsInner.OfflineAgents_RemarksIfAny = item.OfflineAgents_RemarksIfAny;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelRealEstateAgentQRcodeOfflineCertificateMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_AgentQRcodeCertificateDetailsForOfflineAgentsMIS", getObj);
        }

        [HttpGet]
        public ActionResult AgentQRcodeCertificateDetailsForOfflineAgentsMIS(Int64 AgentId)
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeOfflineCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeOfflineCertificateDetails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents_ForMIS(AgentId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.OfflineAgents_IndexID = item.OfflineAgents_IndexID;
                getObj.OfflineAgents_ID = item.OfflineAgents_ID;

                getObj.OfflineAgents_IssueDate = item.OfflineAgents_IssueDate;
                getObj.OfflineAgents_ReferenceNumber = item.OfflineAgents_ReferenceNumber;
                getObj.OfflineAgents_AgentType = item.OfflineAgents_AgentType;

                getObj.OfflineAgents_AgentName_OrganizationName = item.OfflineAgents_AgentName_OrganizationName;
                getObj.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = item.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress;

                getObj.OfflineAgents_RERAregistrationNumber = item.OfflineAgents_RERAregistrationNumber;
                getObj.OfflineAgents_RERAregistrationIssueDate = item.OfflineAgents_RERAregistrationIssueDate;
                getObj.OfflineAgents_RERAregistrationValidUptoDate = item.OfflineAgents_RERAregistrationValidUptoDate;

                getObj.OfflineAgents_PlaceOfBussinessAddress = item.OfflineAgents_PlaceOfBussinessAddress;
                getObj.OfflineAgents_BusinessPlaceDistrict = item.OfflineAgents_BusinessPlaceDistrict;
                getObj.OfflineAgents_ContactDetails = item.OfflineAgents_ContactDetails;
                getObj.OfflineAgents_RemarksIfAny = item.OfflineAgents_RemarksIfAny;

                getObj.A_column = item.A_column;
                getObj.B_column = item.B_column;
                getObj.C_column = item.C_column;

                getObj.QRcodeImage_A = item.QRcodeImage_A;
                getObj.QRcodeImage_B = item.QRcodeImage_B;
                getObj.QRcodeImage_C = item.QRcodeImage_C;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsPublicView = item.IsPublicView;
                getObj.IsCertificate = item.IsCertificate;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("AgentQRcodeCertificateDetailsForOfflineAgentsMIS", getObj);
        }
        
        public void ExportOfflinewithQRcodeToExcel()
        {
            var objXlslist = Session["modelRealEstateAgentQRcodeOfflineCertificateMIS"] as List<Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Reference Number";
            workSheet.Cells[1, 3].Value = "Reference Date";
            workSheet.Cells[1, 4].Value = "Agent Name";
            workSheet.Cells[1, 5].Value = "Agent Type";
            workSheet.Cells[1, 6].Value = "Father's Name and Permanent Address/ Registered Address";            
            workSheet.Cells[1, 7].Value = "Place of Bussiness - Address";
            workSheet.Cells[1, 8].Value = "RERA Number";
            workSheet.Cells[1, 9].Value = "Issue Date";
            workSheet.Cells[1, 10].Value = "Valid upto Date";
            workSheet.Cells[1, 11].Value = "QR Code Image";
            //Body of table  
            //  
            int recordIndex = 2;            
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.OfflineAgents_ReferenceNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.OfflineAgents_IssueDate.HasValue ? QRcodeItem.OfflineAgents_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.OfflineAgents_AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.OfflineAgents_AgentType;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.OfflineAgents_PlaceOfBussinessAddress;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.OfflineAgents_RERAregistrationNumber;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.OfflineAgents_RERAregistrationIssueDate.HasValue ? QRcodeItem.OfflineAgents_RERAregistrationIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.OfflineAgents_RERAregistrationValidUptoDate.HasValue ? QRcodeItem.OfflineAgents_RERAregistrationValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;

                Stream streamQR = new MemoryStream(GenerateQrCodeByBytesForOfflineAgents(QRcodeItem.OfflineAgents_RERAregistrationNumber, QRcodeItem.OfflineAgents_RERAregistrationValidUptoDate, QRcodeItem.OfflineAgents_AgentName_OrganizationName, QRcodeItem.OfflineAgents_AgentType, QRcodeItem.OfflineAgents_PlaceOfBussinessAddress));
                var cfPhoto = System.Drawing.Image.FromStream(streamQR);
                var cfBm = new Bitmap(cfPhoto, new Size(215, 170));
                ExcelPicture imgQR = workSheet.Drawings.AddPicture((recordIndex - 1).ToString(), cfBm);
                imgQR.SetPosition(recordIndex - 1, 5, 10, 5);
                imgQR.SetSize(90, 90);
                workSheet.Row(recordIndex).Height = 100;
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

            workSheet.Cells["A1:K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:K1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 11])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRealestateAgentQRcodeOfflineCertificates_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region QR Code For Renewal of Registrations of Agents
        [HttpGet]
        public ActionResult Display_RenewalAgentQRcodeCertificateDetailsMIS()
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_RenewalAgentQRcodeCertificateDetails getObj = new Clsprp_MIS_RenewalAgentQRcodeCertificateDetails();
            Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel aaXls = new Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            //getObj.prpongoing = sdb.Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalAgents(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel aaXlsInner = new Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel();

                aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate;
                aaXlsInner.Reference_DiaryNumber = item.Reference_DiaryNumber;
                aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                aaXlsInner.Father_AuthorizedPerson_Name = item.Agent_Father_AuthorizedPerson_Name;
                aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                aaXlsInner.RERA_RegistrationNumber = item.RERAnumberRegistration;
                aaXlsInner.RERA_RegistrationNumber_IssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERA_RegistrationNumber_ValidUptoDate = item.RERAnumberRegUptoDate;

                aaXlsInner.RERA_RenewalRegistrationNumber = item.RERA_RenewalRegistrationNumber;
                aaXlsInner.RERA_RenewalRegistrationNumber_IssueDate = item.RERA_RenewalRegistrationNumber_IssueDate;
                aaXlsInner.RERA_RenewalRegistrationNumber_ValidUptoDate = item.RERA_RenewalRegistrationNumber_ValidUptoDate;

                aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                aaXlsInner.RemarksIfAny = item.RemarksIfAny;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRenewalAgentQRcodeCertificateMIS"] = aaXls.prpongoing;

            return View("Display_RenewalAgentQRcodeCertificateDetailsMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_RenewalAgentQRcodeCertificateDetailsMIS(Clsprp_MIS_RenewalAgentQRcodeCertificateDetails smodel)
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_RenewalAgentQRcodeCertificateDetails getObj = new Clsprp_MIS_RenewalAgentQRcodeCertificateDetails();
            Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel aaXls = new Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel();

            try
            {
                switch (smodel.IsRangeValueDateInputFlag)
                {
                    case 1:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        break;
                    case 2:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        ModelState.Remove("InputEntry_FromDate");
                        ModelState.Remove("InputEntry_ToDate");
                        break;
                    default:
                        ModelState.Remove("IsApplicationDateFlag");
                        ModelState.Remove("IsApplicationModeFlag");
                        break;
                }

                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationMode = 0;
                    Int32 flagApplicationDate = 0;
                    Int32 varprmRange = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;

                    flagApplicationMode = smodel.IsApplicationModeFlag; //radioSearchFor
                    flagApplicationDate = smodel.IsApplicationDateFlag; //radioRangeDifferentMode

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    switch (varprmRange)
                    {
                        case 1:
                            FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                            ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;
                            varprmMonth = 0;
                            varprmYear = 0;
                            break;
                        case 2:
                            Int32 get_month = varprmMonth;
                            Int32 get_year = varprmYear;
                            DateTime InputEntry_Date = new DateTime(get_year, get_month, 1);
                            DateTime InputEntry_lastDayOfMonth = InputEntry_Date.AddMonths(1).AddDays(-1);
                            FromDateM = InputEntry_Date;
                            ToDateM = InputEntry_lastDayOfMonth;
                            break;
                        default:
                            FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                            ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;
                            varprmMonth = 0;
                            varprmYear = 0;
                            break;
                    }

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                            //Task has been started
                            Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalAgents_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList(), token);
                        });
                    }
                    await Task.WhenAll(taskA);


                    ViewBag.data = "true";

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel aaXlsInner = new Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel();

                        aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                        aaXlsInner.Application_Date = item.Agent_Diary_ApplicationDate;
                        aaXlsInner.Reference_DiaryNumber = item.Reference_DiaryNumber;
                        aaXlsInner.RealEstateAgent_Name = item.Agent_Organization_Name;
                        aaXlsInner.Father_AuthorizedPerson_Name = item.Agent_Father_AuthorizedPerson_Name;
                        aaXlsInner.Agent_Type = item.Agent_TypeSTR;

                        aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                        aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                        aaXlsInner.BusinessPlace_State = item.BusinessPlace_AddressStateCode;
                        aaXlsInner.BusinessPlace_District = item.BusinessPlace_AddressDistrictCode;
                        aaXlsInner.BusinessPlace_PIN = item.BusinessPlace_AddressPIN;

                        aaXlsInner.RERA_RegistrationNumber = item.RERAnumberRegistration;
                        aaXlsInner.RERA_RegistrationNumber_IssueDate = item.RERAnumberIssueDate;
                        aaXlsInner.RERA_RegistrationNumber_ValidUptoDate = item.RERAnumberRegUptoDate;

                        aaXlsInner.RERA_RenewalRegistrationNumber = item.RERA_RenewalRegistrationNumber;
                        aaXlsInner.RERA_RenewalRegistrationNumber_IssueDate = item.RERA_RenewalRegistrationNumber_IssueDate;
                        aaXlsInner.RERA_RenewalRegistrationNumber_ValidUptoDate = item.RERA_RenewalRegistrationNumber_ValidUptoDate;

                        aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                        aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                        aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                        aaXlsInner.RemarksIfAny = item.RemarksIfAny;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelRenewalAgentQRcodeCertificateMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_RenewalAgentQRcodeCertificateDetailsMIS", getObj);
        }

        [HttpGet]
        public ActionResult RenewalAgentQRcodeCertificateDetailsMIS(Int64 AgentId, Int32 AgentType, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId)
        {
            ClsMethod_MIS_AgentQRcodeCertificateDetails sdb = new ClsMethod_MIS_AgentQRcodeCertificateDetails();
            Clsprp_MIS_AgentQRcodeCertificateDetails getObj = new Clsprp_MIS_AgentQRcodeCertificateDetails();
            string userRole = string.Empty;

            Int64 AgentID = AgentId;
            Int32 AgentTypeId = AgentType;
            Int64 RenewalAgentId = RnAgentId;
            Int32 RnAgentSequenceId = RnAgentSeqId;
            Int32 RnAgentYearId = RnAgentYrId;

            getObj.prpongoing = sdb.Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalRegistrationAgents_ForMIS(AgentID, AgentTypeId, RenewalAgentId, RnAgentSequenceId, RnAgentYearId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.Agent_DiaryNumber = item.Agent_DiaryNumber;
                getObj.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                getObj.Agent_ID = item.Agent_ID;
                getObj.Agent_Type = item.Agent_Type;
                getObj.Agent_TypeSTR = item.Agent_TypeSTR;

                getObj.Agent_Organization_Name = item.Agent_Organization_Name;
                getObj.Agent_Father_AuthorizedPerson_Name = item.Agent_Father_AuthorizedPerson_Name;

                getObj.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                getObj.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                getObj.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                getObj.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                getObj.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                getObj.RERAnumberRegistration = item.RERAnumberRegistration;
                getObj.RERAnumberIssueDate = item.RERAnumberIssueDate;
                getObj.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                getObj.QRcodeImage_A = item.QRcodeImage_A;
                getObj.QRcodeImage_B = item.QRcodeImage_B;
                getObj.QRcodeImage_C = item.QRcodeImage_C;
                getObj.RemarksIfAny = item.RemarksIfAny;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("RenewalAgentQRcodeCertificateDetailsMIS", getObj);
        }

        public void ExportRenewalRegistrationwithQRcodeToExcel()
        {
            var objXlslist = Session["modelRenewalAgentQRcodeCertificateMIS"] as List<Clsprp_MIS_RenewalAgentQRcodeCertificateExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Reference Diary Number";
            workSheet.Cells[1, 5].Value = "Agent Name";
            workSheet.Cells[1, 6].Value = "Father's / Authorized Person's Name";
            workSheet.Cells[1, 7].Value = "Agent Type";
            workSheet.Cells[1, 8].Value = "Place of Bussiness - Address Line 1";
            workSheet.Cells[1, 9].Value = "Place of Bussiness - Address Line 2";
            workSheet.Cells[1, 10].Value = "Place of Bussiness - District";
            workSheet.Cells[1, 11].Value = "Place of Bussiness - State";
            workSheet.Cells[1, 12].Value = "Place of Bussiness - PIN";
            workSheet.Cells[1, 13].Value = "RERA Number";
            workSheet.Cells[1, 14].Value = "Issue Date";
            workSheet.Cells[1, 15].Value = "Valid upto Date";
            workSheet.Cells[1, 16].Value = "Renewal of Registration Number";
            workSheet.Cells[1, 17].Value = "Renewal of Registration Issue Date";
            workSheet.Cells[1, 18].Value = "Renewal of Registration Valid upto Date";
            workSheet.Cells[1, 19].Value = "QR Code Image";
            //Body of table  
            //  
            int recordIndex = 2;
            Int32 qrvarAgent_Type = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Agent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.ToString("dd-MMM-yyyy");
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Reference_DiaryNumber;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.RealEstateAgent_Name;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Father_AuthorizedPerson_Name;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Agent_Type;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.BusinessPlace_AddressLine1;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.BusinessPlace_AddressLine2;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.BusinessPlace_District;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.BusinessPlace_State;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.BusinessPlace_PIN;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.RERA_RegistrationNumber;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.RERA_RegistrationNumber_IssueDate.HasValue ? QRcodeItem.RERA_RegistrationNumber_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.RERA_RegistrationNumber_ValidUptoDate.HasValue ? QRcodeItem.RERA_RegistrationNumber_ValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.RERA_RenewalRegistrationNumber;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.RERA_RenewalRegistrationNumber_IssueDate.HasValue ? QRcodeItem.RERA_RenewalRegistrationNumber_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.RERA_RenewalRegistrationNumber_ValidUptoDate.HasValue ? QRcodeItem.RERA_RenewalRegistrationNumber_ValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;

                if (QRcodeItem.Agent_Type == "Individual")
                {
                    qrvarAgent_Type = 1;
                }
                Stream streamQR = new MemoryStream(GenerateQrCodeByBytesForAgents(QRcodeItem.RERA_RenewalRegistrationNumber, QRcodeItem.RERA_RenewalRegistrationNumber_ValidUptoDate, QRcodeItem.RealEstateAgent_Name, qrvarAgent_Type, QRcodeItem.Father_AuthorizedPerson_Name, QRcodeItem.BusinessPlace_AddressLine1, QRcodeItem.BusinessPlace_AddressLine2, QRcodeItem.BusinessPlace_District, QRcodeItem.BusinessPlace_State));
                var cfPhoto = System.Drawing.Image.FromStream(streamQR);
                var cfBm = new Bitmap(cfPhoto, new Size(215, 170));
                ExcelPicture imgQR = workSheet.Drawings.AddPicture(QRcodeItem.Agent_DiaryNumber, cfBm);
                imgQR.SetPosition(recordIndex - 1, 5, 18, 5);
                imgQR.SetSize(90, 90);
                //workSheet.Cells[recordIndex, 5].Value= img; // GenerateQrCode1(); // QRcodeItem.RealEstateAgent_Name;
                workSheet.Row(recordIndex).Height = 100;
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

            workSheet.Cells["A1:S1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:S1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 19])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRenewalOfRegistrationAgentQRcodeCertificates_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region QR Code for Extra Functions
        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        public ActionResult GenerateQrCode(string qrcodestring)//string qrcodestring, string filePath)
        {
            //string qrcodestring1 = "PBRERA-SAS79-REA1110 (Valid upto 11/03/2024) Sandeep Kumar Aggarwal s/d/o Madan Lal Aggarwal, 20C Alliance Orchid, VIP Road, Opp Penta Homes, Sahibzada Ajit Singh Nagar (Mohali), Punjab";
            //string qrcodestring2 = "PBRERA-SAS81-REA1116 (Valid upto 11/03/2024) M K Infratech c/o Mitul Vsudeva, SCO 124, TDI City, Sector 110, Mohali, Sahibzada Ajit Singh Nagar (Mohali), Punjab";
            //string qrcodestring3 = "PBRERA-SAS80-REA1087 (Valid upto 17/02/2024) Jain Property and Builders c/o Rajesh Kumar Jain, Plot No.13, Ground Floor, Galaxy Homes 2, Peer Mushalla, Sahibzada Ajit Singh Nagar (Mohali), Punjab";
            //string qrcodestring4 = "PBRERA-LDH44-REA1085 (Valid upto 17/02/2024) Vijay Kumar Garg s/d/o Ram Kumar, H. No. C-25 Canal View Enclave, Ludhiana, Ludhiana, Punjab";
            //string qrcodestring5 = "PBRERA-PTL63-REA0955 (Valid upto 31/10/2023) Pardeep Kaur s/d/o Mohinder Singh, M/s. M S Properties, Opp Gayatri Hospital, Near ByPass Sirhind Road, Patiala, Punjab";
            //string qrcodestring6 = "Punjab Real Estate Regulatory Authority, Punjab (Govt. of Punjab)";

            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            // qrCodeImage.Save(filePath, ImageFormat.Jpeg);  // Or Png
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return File(byteArray, "image/jpeg");
        }
        public FileContentResult GenerateQrCode1()//string qrcodestring, string filePath)
        {

            string qrcodestring = "PBRERA-SAS79-REA1110 (Valid upto 11/03/2024) Sandeep Kumar Aggarwal s/d/o Madan Lal Aggarwal, 20C Alliance Orchid, VIP Road, Opp Penta Homes, Sahibzada Ajit Singh Nagar (Mohali), Punjab";
            //string filePath = @"D:\RERA2018 project\CRUD\pdf\QRcode11001.jpeg";

            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            // qrCodeImage.Save(filePath, ImageFormat.Jpeg);  // Or Png
            byte[] byteArray = ConvertToByteArray(qrCodeImage);


            //using (Image image = Image.FromStream(new MemoryStream(qrCodeImage)))
            //{
            //    image.Save(filePath, ImageFormat.Jpeg);  // Or Png
            // }


            //return byteArray;// File(byteArray, "image/jpeg");
            return File(byteArray, "image/jpeg");
        }
        public byte[] GenerateQrCode2()//string qrcodestring, string filePath)
        {

            string qrcodestring = "PBRERA-SAS79-REA1110 (Valid upto 11/03/2024) Sandeep Kumar Aggarwal s/d/o Madan Lal Aggarwal, 20C Alliance Orchid, VIP Road, Opp Penta Homes, Sahibzada Ajit Singh Nagar (Mohali), Punjab";
            //string filePath = @"D:\RERA2018 project\CRUD\pdf\QRcode11001.jpeg";

            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            // qrCodeImage.Save(filePath, ImageFormat.Jpeg);  // Or Png
            byte[] byteArray = ConvertToByteArray(qrCodeImage);


            //using (Image image = Image.FromStream(new MemoryStream(qrCodeImage)))
            //{
            //    image.Save(filePath, ImageFormat.Jpeg);  // Or Png
            // }


            return byteArray;// File(byteArray, "image/jpeg");
            //return File(byteArray, "image/jpeg");
        }
        #endregion

        public byte[] GenerateQrCodeByBytesForAgents(string qrRERAnumber, DateTime? qrValidUptoDate, string qrAgentName, Int32 qrAgentType, string qrAgentFatherAuthPerson, string qrAddressLine1, string qrAddressLine2, string qrDistrictName, string qrStateName)
        {
            string qrcodestring = string.Empty;
            string varTitlestring = string.Empty;
            string qrValidUptoDatestring = string.Empty;
            if (qrAgentType == 1)
            {
                varTitlestring = " s/d/o ";
            }
            else
            {
                varTitlestring = " c/o ";
            }
            qrValidUptoDatestring = qrValidUptoDate.HasValue? qrValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDatestring + ") " + qrAgentName + varTitlestring + qrAgentFatherAuthPerson + ", " + qrAddressLine1 + ", " + qrAddressLine2 + ", " + qrDistrictName + ", " + qrStateName;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);            
            byte[] byteArray = ConvertToByteArray(qrCodeImage);           
            return byteArray;
        }
        public ActionResult GenerateQrCodeByRegisteredAgentID(string qrRERAnumber, DateTime qrValidUptoDate, string qrAgentName, Int32 qrAgentType, string qrAgentFatherAuthPerson, string qrAddressLine1, string qrAddressLine2, string qrDistrictName, string qrStateName)
        {
            string qrcodestring = string.Empty;
            string varTitlestring = string.Empty;
            if (qrAgentType == 1)
            {
                varTitlestring = " s/d/o ";
            }
            else
            {
                varTitlestring = " c/o ";
            }
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDate.ToString("dd'/'MM'/'yyyy") + ") " + qrAgentName + varTitlestring + qrAgentFatherAuthPerson + ", " + qrAddressLine1 + ", " + qrAddressLine2 + ", " + qrDistrictName + ", " + qrStateName;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);            
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return File(byteArray, "image/jpeg");
        }

        public byte[] GenerateQrCodeByBytesForOfflineAgents(string qrRERAnumber, DateTime? qrValidUptoDate, string qrAgentName, string qrAgentType, string qrAddressPlaceOfBussiness)
        {
            string qrcodestring = string.Empty;            
            string qrValidUptoDatestring = string.Empty;
            
            qrValidUptoDatestring = qrValidUptoDate.HasValue ? qrValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDatestring + ") " + qrAgentName + "(" + qrAgentType + ")" + ", " + qrAddressPlaceOfBussiness;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return byteArray;
        }
        public ActionResult GenerateQrCodeByOfflineAgentID(string qrRERAnumber, DateTime? qrValidUptoDate, string qrAgentName, string qrAgentType, string qrAddressPlaceOfBussiness)
        {
            string qrcodestring = string.Empty;
            string qrValidUptoDatestring = string.Empty;

            qrValidUptoDatestring = qrValidUptoDate.HasValue ? qrValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDatestring + ") " + qrAgentName + "(" + qrAgentType + ")" + ", " + qrAddressPlaceOfBussiness;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return File(byteArray, "image/jpeg");
        }

        public static byte[] ConvertToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private Bitmap RenderQrCode(string qrcodestring)
        {
            string level = "L"; //comboBoxECC.SelectedItem.ToString();

            int iconSize = 0;
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                //using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBoxQRCode.Text, eccLevel))
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcodestring, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap img = qrCode.GetGraphic(20, Color.Black, Color.White, GetIconBitmap(), iconSize);
                        return img;
                    }
                }
            }
        }
        private Bitmap GetIconBitmap()
        {
            Bitmap img = null;
            string iconPath = " ";
            if (iconPath.Length > 0)
            {
                try
                {
                    img = new Bitmap(iconPath);
                }
                catch (Exception)
                {
                }
            }
            return img;
        }
        #endregion

        #region Agent Renewal Due or Pending after Approval (Report MIS)
        [HttpGet]
        public ActionResult AgentInfoDeskDueRenewalApplication()
        {
            ClsMethod_MIS_AgentRenewalDueDetails sdb = new ClsMethod_MIS_AgentRenewalDueDetails();
            Clsprp_MIS_AgentDuePendingRenewal aa = new Clsprp_MIS_AgentDuePendingRenewal();
            ClsPrp_MIS_AgentDuePendingRenewalExportExcel aaXls = new ClsPrp_MIS_AgentDuePendingRenewalExportExcel();

            string userRole = string.Empty;
            DateTime prmFromDate = DateTime.Now.AddMonths(-1);
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "1";    //(1)Due or Pending for Extension/Completion   (2) Alert under 3 months which going to be Due or Pending for Extension/Completion
            String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year  
            Int32 application_Month = 0;        //Month
            Int32 application_EventYear = 0;    //Year

            aa.prpongoing = sdb.Display_Agent_DueRenewalApplications(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
            aa.Application_FromDate = DateTime.Now.AddMonths(-1);
            aa.Application_ToDate = DateTime.Now;

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_MIS_AgentDuePendingRenewalExportExcel aaXlsInner = new ClsPrp_MIS_AgentDuePendingRenewalExportExcel();

                aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aaXlsInner.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                aaXlsInner.Agent_TypeSTR = item.Agent_TypeSTR;
                aaXlsInner.Agent_Organization_Name = item.Agent_Organization_Name;

                aaXlsInner.Agent_RERA_No = item.Agent_RERA_No;
                aaXlsInner.Agent_RERA_IssueDate = item.Agent_RERA_IssueDate;
                aaXlsInner.Agent_RERA_ValidDate = item.Agent_RERA_ValidDate;

                aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aaXlsInner.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aaXlsInner.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aaXlsInner.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                aaXlsInner.BComm_AddressLine1 = item.BComm_AddressLine1;
                aaXlsInner.BComm_AddressLine2 = item.BComm_AddressLine2;
                aaXlsInner.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aaXlsInner.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aaXlsInner.BComm_AddressPIN = item.BComm_AddressPIN;

                aaXlsInner.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                aaXlsInner.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                aaXlsInner.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                aaXlsInner.MobileNumber = item.MobileNumber;
                aaXlsInner.EmailAddress = item.EmailAddress;
                aaXlsInner.Merge_Mode = item.Merge_Mode;

                aaXls.prpongoing.Add(aaXlsInner);
            }

            aa.Application_SearchTypeFlag = application_SearchTypeFlag;
            aa.Application_SearchRangeFlag = application_SearchRangeFlag;
            aa.Application_FromDate = prmFromDate;
            aa.Application_ToDate = prmToDate;
            aa.EventMonth = application_Month;
            aa.EventYear = application_EventYear;

            Session["modelAgentDueRenewalMIS"] = aaXls.prpongoing;
            return View("AgentInfoDeskDueRenewalApplication", aa);
        }

        [HttpPost]
        public ActionResult AgentInfoDeskDueRenewalApplication(Clsprp_MIS_AgentDuePendingRenewal smodel)
        {
            ClsMethod_MIS_AgentRenewalDueDetails sdb = new ClsMethod_MIS_AgentRenewalDueDetails();
            Clsprp_MIS_AgentDuePendingRenewal aa = new Clsprp_MIS_AgentDuePendingRenewal();
            ClsPrp_MIS_AgentDuePendingRenewalExportExcel aaXls = new ClsPrp_MIS_AgentDuePendingRenewalExportExcel();

            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchTypeFlag;      //(1)Due or Pending for Extension/Completion   (2) Alert under 3 months which going to be Due or Pending for Extension/Completion
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                if (application_SearchTypeFlag == "2")
                {
                    prmFromDate = DateTime.Now;
                    prmToDate = prmFromDate.AddMonths(3);
                    application_SearchRangeFlag = "1";
                }

                aa.prpongoing = sdb.Display_Agent_DueRenewalApplications(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in aa.prpongoing)
                {
                    ClsPrp_MIS_AgentDuePendingRenewalExportExcel aaXlsInner = new ClsPrp_MIS_AgentDuePendingRenewalExportExcel();

                    aaXlsInner.Agent_DiaryNumber = item.Agent_DiaryNumber;
                    aaXlsInner.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                    aaXlsInner.Agent_TypeSTR = item.Agent_TypeSTR;
                    aaXlsInner.Agent_Organization_Name = item.Agent_Organization_Name;

                    aaXlsInner.Agent_RERA_No = item.Agent_RERA_No;
                    aaXlsInner.Agent_RERA_IssueDate = item.Agent_RERA_IssueDate;
                    aaXlsInner.Agent_RERA_ValidDate = item.Agent_RERA_ValidDate;

                    aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    aaXlsInner.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    aaXlsInner.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    aaXlsInner.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                    aaXlsInner.BComm_AddressLine1 = item.BComm_AddressLine1;
                    aaXlsInner.BComm_AddressLine2 = item.BComm_AddressLine2;
                    aaXlsInner.BComm_AddressStateCode = item.BComm_AddressStateCode;
                    aaXlsInner.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    aaXlsInner.BComm_AddressPIN = item.BComm_AddressPIN;

                    aaXlsInner.AuthorizedSignatory_Name = item.AuthorizedSignatory_Name;
                    aaXlsInner.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    aaXlsInner.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                    aaXlsInner.MobileNumber = item.MobileNumber;
                    aaXlsInner.EmailAddress = item.EmailAddress;
                    aaXlsInner.Merge_Mode = item.Merge_Mode;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                aa.Application_SearchTypeFlag = smodel.Application_SearchTypeFlag;
                aa.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                aa.Application_FromDate = smodel.Application_FromDate;
                aa.Application_ToDate = smodel.Application_ToDate;
                aa.EventMonth = smodel.EventMonth;
                aa.EventYear = smodel.EventYear;

                if (application_SearchTypeFlag == "2")
                {
                    aa.Application_SearchRangeFlag = application_SearchRangeFlag;
                    aa.Application_FromDate = prmFromDate;
                    aa.Application_ToDate = prmToDate;
                }

                Session["modelAgentDueRenewalMIS"] = aa.prpongoing;
                if (aa.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("AgentInfoDeskDueRenewalApplication", aa);
        }

        public void ExportAgentDueRenewalToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelAgentDueRenewalMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=ListofRealestateAgentDueRenewals_" + strDateFormat + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Agent InComplete Reminder Emails (Notice)
        [HttpGet]
        public ActionResult AgentReminderEmailSchedulerContentDetailsForMIS(Int64 AgentId, Int64 CodeId, string DNumber)
        {
            ClsMethodMIS_AgentReminderEmailsDetails sdb = new ClsMethodMIS_AgentReminderEmailsDetails();
            ClsMethodMIS_AgentReminderSMSsDetails sdbSMSgateway = new ClsMethodMIS_AgentReminderSMSsDetails();
            ClsprpMIS_AgentInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_AgentInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentSchedulerReminderEmailsDetails_ForAgents(AgentId, CodeId, DNumber, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_AgentSchedulerReminderSMSsDetails_ForAgents(AgentId, CodeId, DNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.AgentReminder_IndexID = item.AgentReminder_IndexID;
                getObj.AgentReminder_ID = item.AgentReminder_ID;
                getObj.Agent_ID = item.Agent_ID;
                getObj.RenewalAgent_ID = item.RenewalAgent_ID;

                getObj.Agent_Name = item.Agent_Name;
                getObj.Agent_Type = item.Agent_Type;
                getObj.Agent_DiaryNumber = item.Agent_DiaryNumber;
                getObj.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                getObj.RenewalAgent_DiaryNumber = item.RenewalAgent_DiaryNumber;

                getObj.RERA_Registration_Number = item.RERA_Registration_Number;
                getObj.RERA_Registration_ValidUptoDate = item.RERA_Registration_ValidUptoDate;

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
            return View("AgentReminderEmailSchedulerContentDetailsForMIS", getObj);
        }
        #endregion

        #region Renewal-Agent InComplete Reminder Emails (Notice)
        [HttpGet]
        public ActionResult RenewalAgentReminderEmailSchedulerContentDetailsForMIS(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, Int64 CodeId, string DNumber)
        {
            ClsMethodMIS_AgentReminderEmailsDetails sdb = new ClsMethodMIS_AgentReminderEmailsDetails();
            ClsMethodMIS_AgentReminderSMSsDetails sdbSMSgateway = new ClsMethodMIS_AgentReminderSMSsDetails();
            ClsprpMIS_AgentInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_AgentInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            //getObj.prpongoing = sdb.Display_AuthDesk_MIS_AgentSchedulerReminderEmailsDetails_ForAgents(AgentId, CodeId, DNumber, userRole);
            //getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_AgentSchedulerReminderSMSsDetails_ForAgents(AgentId, CodeId, DNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.AgentReminder_IndexID = item.AgentReminder_IndexID;
                getObj.AgentReminder_ID = item.AgentReminder_ID;
                getObj.Agent_ID = item.Agent_ID;
                getObj.RenewalAgent_ID = item.RenewalAgent_ID;

                getObj.Agent_Name = item.Agent_Name;
                getObj.Agent_Type = item.Agent_Type;
                getObj.Agent_DiaryNumber = item.Agent_DiaryNumber;
                getObj.Agent_Diary_ApplicationDate = item.Agent_Diary_ApplicationDate;
                getObj.RenewalAgent_DiaryNumber = item.RenewalAgent_DiaryNumber;

                getObj.RERA_Registration_Number = item.RERA_Registration_Number;
                getObj.RERA_Registration_ValidUptoDate = item.RERA_Registration_ValidUptoDate;

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
            return View("RenewalAgentReminderEmailSchedulerContentDetailsForMIS", getObj);
        }
        #endregion
    }
}
