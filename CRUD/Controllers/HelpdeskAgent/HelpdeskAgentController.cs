using CRUD.Models.Document;
using CRUD.Models.HelpDesk;
using CRUD.Models.HelpDeskAgent;
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
using CRUD.Models.Agent;
using System.Web.UI.WebControls;
using System.Web.UI;
using CRUD.Models.HelpdeskControlPanel;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using System.Drawing;

namespace CRUD.Controllers.HelpdeskAgent
{
    [Authorize]
    [Authorize(Roles = "Authority, HelpDesk, SecretaryRERA, ManagerDesk, LegalAdvisorDesk, PStoMembers")]    
    public class HelpdeskAgentController : Controller
    {       

        #region Agent Application Recieved List
        [HttpGet]
        public ActionResult AgentInfoDesk()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetails(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelInProcessApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDesk", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskExistingRERA()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsExistingRERA(userRole);

            //foreach (var item in aa.prpongoing)
            //{
            //    aa.ProjectRegistration_ID = item.ProjectRegistration_ID;
            //    aa.Project_Name = item.Project_Name;
            //    aa.Project_Status = item.Project_Status;

            //    aa.Promoter_ID = item.Promoter_ID;
            //    aa.Promoter_Name = item.Promoter_Name;
            //    aa.Org_Name = item.Org_Name;
            //}
            return View("AgentInfoDeskExistingRERA", aa);
        }



        //[HttpGet]
        //public ActionResult AgentInfoDeskApproved()
        //{
        //    ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
        //    ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsApproved(userRole);
        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
        //        aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
        //        aaXlsInner.Application_Date = item.CreatedOn;
        //        aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
        //        aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
        //        aaXlsInner.Status = item.EventAction_Aggregate;
        //        aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    Session["modelApprovedApplicationsforRealEstateAgent"] = aaXls.prpongoing;
        //    return View("AgentInfoDeskApproved", aa);
        //}


        [HttpGet]
        public ActionResult AgentInfoDeskApproved()
        {
            return BindAgentInfoDeskApproved(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentInfoDeskApproved(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentInfoDeskApproved(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentInfoDeskApproved(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsApproved(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsApprovedByDate(approvalyear, filterType, fromDate, toDate, userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelApprovedApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentInfoDeskApproved", aa);
        }




        #region PAGINATION WORKING CODE
        //[HttpGet]
        //public ActionResult AgentInfoDeskApproved()
        //{
        //    // Build a minimal model (empty list) to render view and keep Razor strong typing
        //    var model = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
        //    model.prpongoing = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();
        //    return View("AgentInfoDeskApproved", model);
        //}

        //[HttpPost]
        //public ActionResult AgentInfoDeskApproved_DataTable()
        //{
        //    int draw = 0;
        //    int.TryParse(Request.Form["draw"], out draw);

        //    var start = Convert.ToInt32(Request.Form["start"] ?? "0");
        //    var length = Convert.ToInt32(Request.Form["length"] ?? "50"); // page size
        //    var search = Request.Form["search[value]"] ?? "";

        //    int orderColIndex = 0;
        //    int.TryParse(Request.Form["order[0][column]"], out orderColIndex);
        //    var orderDir = (Request.Form["order[0][dir]"] ?? "desc").ToLower() == "asc" ? "ASC" : "DESC";

        //    // read columns[...] data name
        //    var orderColName = Request.Form[$"columns[{orderColIndex}][data]"] ?? "";

        //    // Map client column to safe token (orderBy) that the SP understands and whitelists
        //    string orderToken;
        //    if (orderColIndex == 0)
        //    {
        //        orderToken = "AgentRegDiaryNumber_IndexID";
        //    }
        //    else
        //    {
        //        switch (orderColName)
        //        {
        //            case "AgentRegDiaryNumber_Name":
        //                orderToken = "AgentRegDiaryNumber_Name";
        //                break;
        //            case "Agent_Name":
        //                orderToken = "Agent_Name";
        //                break;
        //            case "Agent_AddressDistrictName":
        //                orderToken = "Agent_AddressDistrictName";
        //                break;
        //            case "CreatedOn":
        //                orderToken = "CreatedOn";
        //                break;
        //            case "EventAction_IdentifiedOn":
        //                orderToken = "EventAction_IdentifiedOn";
        //                break;
        //            default:
        //                orderToken = "EventAction_IdentifiedOn";
        //                break;
        //        }
        //    }

        //    var repo = new ClsMethod_Agent_Helpdesk();
        //    var paged = repo.Display_AuthorityDesk_AgentDetailsApproved_Paged(
        //        UserID_Role: "",
        //        search: search,
        //        orderBy: orderToken,
        //        orderDir: orderDir,
        //        offset: start,
        //        limit: length);

        //    var data = paged.Items.Select(r => new {
        //        r.AgentRegDiaryNumber_IndexID,
        //        r.AgentRegDiaryNumber_ID,
        //        AgentRegDiaryNumber_Name = r.AgentRegDiaryNumber_Name,
        //        Agent_Name = r.Agent_Name,
        //        Agent_AddressDistrictName = r.Agent_AddressDistrictName,
        //        CreatedOn = r.CreatedOn.HasValue ? r.CreatedOn.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
        //        EventAction_IdentifiedOn = r.EventAction_IdentifiedOn.HasValue ? r.EventAction_IdentifiedOn.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
        //        EventAction_Aggregate = r.EventAction_Aggregate,
        //        Agent_ID = r.Agent_ID
        //    }).ToList();

        //    return Json(new
        //    {
        //        draw = draw,
        //        recordsTotal = paged.TotalCount,
        //        recordsFiltered = paged.TotalCount,
        //        data = data
        //    }, JsonRequestBehavior.AllowGet);
        //}
        #endregion




        //[HttpGet]
        //public ActionResult AgentInfoDeskApproved(int page = 1, int pageSize = 50)
        //{
        //    ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
        //    ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    var fullList = sdb.Display_AuthorityDesk_AgentDetailsApproved(userRole);
        //    int totalRecords = fullList.Count();
        //    if (page < 1) page = 1;
        //    if (pageSize < 1) pageSize = 50;
        //    int skip = (page - 1) * pageSize;
        //    aa.prpongoing = fullList.Skip(skip).Take(pageSize).ToList();
        //    aaXls.prpongoing = new List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>();
        //    foreach (var item in fullList)
        //    {
        //        ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
        //        aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
        //        aaXlsInner.Application_Date = item.CreatedOn;
        //        aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
        //        aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
        //        aaXlsInner.Status = item.EventAction_Aggregate;
        //        aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }

        //    Session["modelApprovedApplicationsforRealEstateAgent"] = aaXls.prpongoing;
        //    ViewBag.CurrentPage = page;
        //    ViewBag.PageSize = pageSize;
        //    ViewBag.TotalRecords = totalRecords;
        //    ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        //    return View("AgentInfoDeskApproved", aa);
        //}


        [HttpGet]
        public ActionResult AgentInfoDeskRejected()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsRejected(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRejectedApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskRejected", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskRejectedwithLAbyList()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsRejected(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRejectedApplicationsLAforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskRejectedwithLAbyList", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskNewApplication()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
            
            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsNewApplication(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelNewApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskNewApplication", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskReSubmitted()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsReSubmittedApplication(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelReSubmittedApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskReSubmitted", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskCheckList()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsChecklistPrepared(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelCheckListApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskCheckList", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskReviewCL()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsReviewChecklist(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelReviewCLApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskReviewCL", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskWithdrawn()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsWithdrawn(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelWithdrawnApplicationsforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskWithdrawn", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskWithdrawnwithLAbyList()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentDiaryNumber();
            ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsWithdrawn(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel();
                aaXlsInner.RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelWithdrawnApplicationsLAforRealEstateAgent"] = aaXls.prpongoing;
            return View("AgentInfoDeskWithdrawn", aa);
        }

        #region Export To Excel
        public void InProcessApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelInProcessApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofInProcessApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ReSubmittedApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelReSubmittedApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofReSubmittedApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void NewApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelNewApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofNewApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void CheckListApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelCheckListApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofChecklistApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ReviewCLApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelReviewCLApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofReviewedApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ApprovedApplicationsforRealEstateAgent_ExportToExcel()
        {
            // Fetch fresh data using the paged SP to avoid loading huge lists on page load.
            string userRole = string.Empty;
            var sdb = new ClsMethod_Agent_Helpdesk();
            var paged = sdb.Display_AuthorityDesk_AgentDetailsApproved_Paged(
                userRole,
                string.Empty,                // no search for export
                "c.EventAction_IdentifiedOn", // default order
                "DESC",
                0,
                1000000);                    // sufficiently large to cover all rows

            var objXlslist = paged.Items.Select(item => new ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel
            {
                RealEstateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name,
                Application_Date = item.CreatedOn,
                AgentName_OrganizationName = item.Agent_Name,
                PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName,
                Status = item.EventAction_Aggregate,
                Status_Date = item.EventAction_IdentifiedOn
            }).ToList();

            Session["modelApprovedApplicationsforRealEstateAgent"] = objXlslist;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofApprovedApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void RejectedApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelRejectedApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRejectedApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void WithdrawnApplicationsforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelWithdrawnApplicationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofWithdrawnApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void RejectedApplicationsLAforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelRejectedApplicationsLAforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRejectedApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void WithdrawnApplicationsLAforRealEstateAgent_ExportToExcel()
        {
            var objXlslist = Session["modelWithdrawnApplicationsLAforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>;

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
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 5].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 6].Value = "Status";
            workSheet.Cells[1, 7].Value = "Status Date";
            workSheet.Cells[1, 8].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RealEstateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = string.Empty;

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

            workSheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 8])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofWithdrawnApplications_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion
        #endregion

        #region Agent Issue RERA ID after Approval
        [HttpGet]
        public ActionResult AgentInfoDeskIssueRERAid()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber();
            ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXls = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentDetailsIssueRERAregistration(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Mobile_Number = item.MobileNumber;
                aaXlsInner.Email_Address = item.EmailAddress;
                aaXlsInner.RERA_Registration_Number = item.RERAnumberRegistration;
                aaXlsInner.RERA_Number_IssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentsIssueRegistrationNumberMIS"] = aaXls.prpongoing;
            return View("AgentInfoDeskIssueRERAid", aa);
        }

        //[HttpGet]
        //public ActionResult AgentInfoDeskRegRERAnumberDetails()
        //{
        //    ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();
        //    ClsPrp_AuthorityDesk_AgentRERAnumberDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDetails();
        //    ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXls = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumber(userRole);
        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();
        //        aaXlsInner.RealestateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
        //        aaXlsInner.Application_Date = item.CreatedOn;
        //        aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
        //        aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
        //        aaXlsInner.Mobile_Number = item.MobileNumber;
        //        aaXlsInner.Email_Address = item.EmailAddress;              
        //        aaXlsInner.RERA_Registration_Number = item.RERAnumberRegistration;
        //        aaXlsInner.RERA_Number_IssueDate = item.RERAnumberIssueDate;
        //        aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERAnumberRegUptoDate;
        //        aaXlsInner.Status = item.EventAction_Aggregate;
        //        aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    Session["modelRealEstateAgentsInPublicViewMIS"] = aaXls.prpongoing;
        //    return View("AgentInfoDeskRegRERAnumberDetails", aa);
        //}


        [HttpPost]
        public PartialViewResult AgentInfoDeskRegRERAnumberDetailsss(string searchType, string searchNumber)
        {
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();
            //ClsPrp_AuthorityDesk_ProjectRERAnumberDetails aa = new ClsPrp_AuthorityDesk_ProjectRERAnumberDetails();
            ClsPrp_Agent_Search_Helpdesk aa = new ClsPrp_Agent_Search_Helpdesk();

            string userRole = string.Empty;
            var data = sdb.DisplayAgentBySearchterm(userRole, searchNumber, searchType);

            aa.prpongoing = data;

            return PartialView("_AgentRERANumberSearchResults", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoDeskRegRERAnumberDetails()
        {
            return BindAgentInfoDeskRegRERAnumberDetails(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentInfoDeskRegRERAnumberDetails(int? approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentInfoDeskRegRERAnumberDetails(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentInfoDeskRegRERAnumberDetails(int? approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();
            ClsPrp_AuthorityDesk_AgentRERAnumberDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDetails();
            ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXls = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();

            string userRole = string.Empty;
            // aa.prpongoing = sdb.Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumber(userRole);
            if (filterType == "all")
            {
                aa.prpongoing = sdb.Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumber(userRole);
            }
            else
            {
                aa.prpongoing = sdb.Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumberDate(approvalyear, filterType, fromDate, toDate, userRole);
            }
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Mobile_Number = item.MobileNumber;
                aaXlsInner.Email_Address = item.EmailAddress;
                aaXlsInner.RERA_Registration_Number = item.RERAnumberRegistration;
                aaXlsInner.RERA_Number_IssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentsInPublicViewMIS"] = aaXls.prpongoing;
            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentInfoDeskRegRERAnumberDetails", aa);
        }

        private static List<SelectListItem> GetApprovalYears()
        {
            List<SelectListItem> Years = new List<SelectListItem>();

            for (Int32 i = 2017; i <= (DateTime.Now.Year); i++)
            {
                Years.Add(new SelectListItem
                {
                    Text = Convert.ToString(i),
                    Value = Convert.ToString(i),
                    //Selected = (i == selectedYear)
                });
            }

            return Years.ToList();
        }






        [HttpGet]
        public ActionResult AgentInfoDeskRegRERAnumberPublicViewDetails()
        {
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();
            ClsPrp_AuthorityDesk_AgentRERAnumberDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDetails();
            ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXls = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumber(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel aaXlsInner = new ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.AgentRegDiaryNumber_Name;
                aaXlsInner.Application_Date = item.CreatedOn;
                aaXlsInner.AgentName_OrganizationName = item.Agent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.Agent_AddressDistrictName;
                aaXlsInner.Mobile_Number = item.MobileNumber;
                aaXlsInner.Email_Address = item.EmailAddress;
                aaXlsInner.RERA_Registration_Number = item.RERAnumberRegistration;
                aaXlsInner.RERA_Number_IssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRealEstateAgentsInPublicViewMIS"] = aaXls.prpongoing;
            return View("AgentInfoDeskRegRERAnumberPublicViewDetails", aa);
        }

        public void RealEstateAgentsInPublicView_ExportToExcel()
        {
            var objXlslist = Session["modelRealEstateAgentsInPublicViewMIS"] as List<ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Valid Upto Date";            
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District";
            workSheet.Cells[1, 7].Value = "Mobile Number";
            workSheet.Cells[1, 8].Value = "Email Address";
            workSheet.Cells[1, 9].Value = "Diary Number";
            workSheet.Cells[1, 10].Value = "Application Date";
            workSheet.Cells[1, 11].Value = "Status";
            workSheet.Cells[1, 12].Value = "Status Date";
            workSheet.Cells[1, 13].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RERA_Registration_Number;
                if (QRcodeItem.RERA_Registration_Number != "NA")
                {
                    workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RERA_Number_IssueDate.HasValue ? (QRcodeItem.RERA_Number_IssueDate.Value.ToString("dd-MMM-yyyy") != "01-Jan-0001" ? QRcodeItem.RERA_Number_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                    workSheet.Cells[recordIndex, 4].Value = QRcodeItem.RERA_Number_RegistrationUptoDate.HasValue ? (QRcodeItem.RERA_Number_RegistrationUptoDate.Value.ToString("dd-MMM-yyyy") != "01-Jan-0001" ? QRcodeItem.RERA_Number_RegistrationUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                }
                else
                {
                    workSheet.Cells[recordIndex, 3].Value = string.Empty;
                    workSheet.Cells[recordIndex, 4].Value = string.Empty;
                }
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Mobile_Number;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Email_Address;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = string.Empty;

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

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 13])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRealEstateAgentsInPublicView_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void RealEstateAgentsIssueRegistrationNumber_ExportToExcel()
        {
            var objXlslist = Session["modelRealEstateAgentsIssueRegistrationNumberMIS"] as List<ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Valid Upto Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District";
            workSheet.Cells[1, 7].Value = "Mobile Number";
            workSheet.Cells[1, 8].Value = "Email Address";
            workSheet.Cells[1, 9].Value = "Diary Number";
            workSheet.Cells[1, 10].Value = "Application Date";
            workSheet.Cells[1, 11].Value = "Status";
            workSheet.Cells[1, 12].Value = "Status Date";
            workSheet.Cells[1, 13].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.RERA_Registration_Number;
                if (QRcodeItem.RERA_Registration_Number != "NA")
                {
                    workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RERA_Number_IssueDate.HasValue ? (QRcodeItem.RERA_Number_IssueDate.Value.ToString("dd-MMM-yyyy") != "01-Jan-0001" ? QRcodeItem.RERA_Number_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                    workSheet.Cells[recordIndex, 4].Value = QRcodeItem.RERA_Number_RegistrationUptoDate.HasValue ? (QRcodeItem.RERA_Number_RegistrationUptoDate.Value.ToString("dd-MMM-yyyy") != "01-Jan-0001" ? QRcodeItem.RERA_Number_RegistrationUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                }
                else
                {
                    workSheet.Cells[recordIndex, 3].Value = string.Empty;
                    workSheet.Cells[recordIndex, 4].Value = string.Empty;
                }
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Mobile_Number;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Email_Address;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = string.Empty;

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

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 13])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRealEstateAgentsIssueRegistrationNumber_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region Agent - Offline Registered and Pending Uploads

        [HttpGet]
        public ActionResult AgentInfoDeskRegisteredOfflineExistingRERAwithList()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentsExistingRERA_OfflineRegistered_PendingUploads(userRole);

            Session["modelOfflineRegistrationsforRealEstateAgent"] = aa.prpongoing;
            return View("AgentInfoDeskRegisteredOfflineExistingRERAwithList", aa);
        }

        public void RegistrationsforRealEstateAgent_Offline_ExportToExcel()
        {
            var objXlslist = Session["modelOfflineRegistrationsforRealEstateAgent"] as List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Valid Upto Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness Address";
            workSheet.Cells[1, 7].Value = "Place of Bussiness District";
            workSheet.Cells[1, 8].Value = "Contact Details";
            workSheet.Cells[1, 9].Value = "Father Name and Permanent/Registered Address";
            workSheet.Cells[1, 10].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.OfflineAgents_RERAregistrationNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.OfflineAgents_RERAregistrationIssueDate.HasValue ? QRcodeItem.OfflineAgents_RERAregistrationIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.OfflineAgents_RERAregistrationValidUptoDate.HasValue ? QRcodeItem.OfflineAgents_RERAregistrationValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.OfflineAgents_AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.OfflineAgents_PlaceOfBussinessAddress;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.OfflineAgents_BusinessPlaceDistrict;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.OfflineAgents_ContactDetails;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress;
                workSheet.Cells[recordIndex, 10].Value = string.Empty;

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

            workSheet.Cells["A1:J1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:J1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 10])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofOfflineRegistrations_RealEstateAgent_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region Agent Event History
        [HttpGet]
        public ActionResult AgentInfoEventLog(Int64 AgentId)
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();
            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentEventLogDetails(AgentId, userRole);

            //foreach (var item in aa.prpongoing)
            //{
            //    aa.ProjectRegistration_ID = item.ProjectRegistration_ID;
            //    aa.Project_Name = item.Project_Name;
            //    aa.Project_Status = item.Project_Status;

            //    aa.Promoter_ID = item.Promoter_ID;
            //    aa.Promoter_Name = item.Promoter_Name;
            //    aa.Org_Name = item.Org_Name;
            //}
            return View("AgentInfoEventLog", aa);
        }
        #endregion

        [HttpGet]
        public ActionResult AuthorityDeskDashboard()
        {
            //ClsMethod_Helpdesk sdb = new ClsMethod_Helpdesk();
            //ClsPrp_AuthorityDesk_ProjectEventLog aa = new ClsPrp_AuthorityDesk_ProjectEventLog();
            //string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_ProjectEventLogDetails(projectId, userRole);

            //foreach (var item in aa.prpongoing)
            //{
            //    aa.ProjectRegistration_ID = item.ProjectRegistration_ID;
            //    aa.Project_Name = item.Project_Name;
            //    aa.Project_Status = item.Project_Status;

            //    aa.Promoter_ID = item.Promoter_ID;
            //    aa.Promoter_Name = item.Promoter_Name;
            //    aa.Org_Name = item.Org_Name;
            //}
            return View("AuthorityDeskDashboard");
        }

        #region Add or Insert Agent RERA Number
        [HttpGet]
        public ActionResult Add_AgentRERAregistrationNumber()
        {
            ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber();
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentID"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthDesk_AgentRERAnumber_ByAgentIdandDiaryNumber(AgentID);
            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();

            if (Session["zapAgentID"] != null)
            {
                string AgentDiaryNumber = (Session["zapAgentDiaryNumber"] != null) ? Session["zapAgentDiaryNumber"].ToString() : "";
                string AgentName = (Session["zapAgentName"] != null) ? Session["zapAgentName"].ToString() : "";
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = (Session["zapLastModifiedOn"] != null) ? Convert.ToDateTime(Session["zapLastModifiedOn"]) : (DateTime?)null;

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            foreach (var item in aa.prpongoing)
            {

                aa.Agent_RERAnumber_DiaryNumber_IndexID = item.Agent_RERAnumber_DiaryNumber_IndexID;
                aa.Agent_RERAnumber_DiaryNumber_ID = item.Agent_RERAnumber_DiaryNumber_ID;
                aa.AgentRegDiaryNumber_Name = item.AgentRegDiaryNumber_Name;
                aa.AgentRegDiaryNumber_NameYear = item.AgentRegDiaryNumber_NameYear;

                aa.Agent_ID = item.Agent_ID;
                aa.UserID = item.UserID;

                aa.OtherMemDetailsCount = item.OtherMemDetailsCount;
                aa.DocumentuploadsCount = item.DocumentuploadsCount;
                aa.UTotherStateRERACount = item.UTotherStateRERACount;
                aa.PaymentsCount = item.PaymentsCount;
                aa.AgentDocumentCount = item.AgentDocumentCount;

                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
                aa.tbl_RegDiaryNumber_indexID = item.tbl_RegDiaryNumber_indexID;

                aa.Project_ID = item.Project_ID;
                aa.Project_Name = item.Project_Name;
                aa.Promoter_ID = item.Promoter_ID;
                aa.Promoter_Name = item.Promoter_Name;
                aa.IsAlreadyRegistration = item.IsAlreadyRegistration;
                aa.ExistingRegistration = item.ExistingRegistration;
                aa.Agent_Type = item.Agent_Type;
                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_MiddleName = item.Agent_MiddleName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Organization_Name = item.Organization_Name;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.EmailAddress = item.EmailAddress;
                aa.MobileNumber = item.MobileNumber;

                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aa.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;

                aa.IsPublicView = item.IsPublicView;

                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            if (aa.prpongoing.Count >= 1)
            {
                if (aa.IsDraftHelpDesk == 1)
                {
                    TempData["submitvalue"] = "Update"; TempData.Keep();
                }
                else
                {
                    TempData["submitvalue"] = "Save"; TempData.Keep();
                }
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }
            return View("Add_AgentRERAregistrationNumber", aa);
        }

        [HttpPost]
        public ActionResult Add_AgentRERAregistrationNumber(ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber smodel)
        {
            ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber();
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string error = string.Empty;
            //int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            string AgentDiaryNumber = string.Empty;
            Int64 Agent_ID = 0;

            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();

            if (Session["zapAgentDiaryNumber"] != null)
            {
                AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();                
                Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        if (sdb.Update_LDR_Agent_RERAnumber_DiaryNumber(smodel, UserNam, Agent_ID, AgentDiaryNumber))
                        {
                            TempData["Message"] = "Your Data is Successfully Updated";
                            //ViewBag.Message = "Your Data is Successfully Updated";
                            ModelState.Clear();
                        }
                        return RedirectToAction("Add_AgentRERAregistrationNumber");
                    }
                    else
                    {
                        #region SAVE code
                        if (sdb.Add_LDR_Agent_RERAnumber_DiaryNumber(smodel, UserNam, Agent_ID, AgentDiaryNumber))
                        {                            
                            TempData["Message"] = "Your Data is Successfully Submitted";
                            //ViewBag.Message = "Your Data is Successfully Submitted";
                            ModelState.Clear();
                        }
                        return RedirectToAction("Add_AgentRERAregistrationNumber");
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                String e = ex.Message;
            }
            return View();
        }

        public JsonResult GetReraExistingNumber(string RERA_RegNumber)
        {
            ClsMethodAgent_ExisitingRera objdis = new ClsMethodAgent_ExisitingRera();
            //Fill_Existing_detail(String RERA_RegNumber)
            var states = objdis.Fill_Existing_detail(RERA_RegNumber);

            return Json(states);
        }

        //Generate RERA number Calculator
        [HttpGet]
        public ActionResult RealestateAgentRegistrationNumberRecordsCalculator(string agentId, string varflag)
        {
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            Int64 RefAgentID = String.IsNullOrEmpty(agentId) ? 0 : Convert.ToInt64(agentId);            
            Int32 VarFlag = String.IsNullOrEmpty(varflag) ? 0 : Convert.ToInt32(varflag);

            ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator aa = new ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator();
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();


            Tuple<DateTime, DateTime> tupleRegistrationToFromDate = sdb.Extract_AuthDesk_AgentRegistrationNumberDateDetails_ByID(RefAgentID, UID);

            aa.RegistrationValidUptoDate_Input = tupleRegistrationToFromDate.Item2;
            aa.RegistrationIssueDate_Input = tupleRegistrationToFromDate.Item1;
            aa.IsDraft = VarFlag;
            aa.Related_Agent_ID = RefAgentID;            

            return View("RealestateAgentRegistrationNumberRecordsCalculator", aa);
        }

        [HttpPost]
        public ActionResult SearchRealestateAgentRegistrationNumberRecords(ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator[] numberobject)
        {
            bool status = false;
            Int64? chkappid = null;

            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails();
            ClsMethod_ViewAdd_AgentRERAnumber sdbcalc = new ClsMethod_ViewAdd_AgentRERAnumber();
            
            Int64 AgentID = 0;
            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
            }
            if (Session["zapAgentID"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            if (ModelState.IsValid)
            {
                if (numberobject != null)
                {
                    foreach (var item in numberobject)
                    {
                        Int64 parmRelated_AgentID = 0;                        
                        Int32 parmNumberOptions_Flag = 0;
                        string parmAgentStateType_Flag = string.Empty;
                        DateTime parmRegistration_IssueDate = DateTime.Now;
                        DateTime parmRegistration_UptoDate = DateTime.Now;
                        Int32 parmIsDraft = 0;

                        //Object Value (Input)
                        parmRelated_AgentID = (Convert.ToInt64(item.Related_Agent_ID) == 0 ? AgentID : Convert.ToInt64(item.Related_Agent_ID));                                              
                        parmNumberOptions_Flag = Convert.ToInt32(item.RegistrationNumberOptions_Input);
                        parmAgentStateType_Flag = Convert.ToString(item.AgentStateType_Input);
                        parmRegistration_IssueDate = Convert.ToDateTime(item.RegistrationIssueDate_Input);
                        parmRegistration_UptoDate = Convert.ToDateTime(item.RegistrationValidUptoDate_Input);
                        parmIsDraft = Convert.ToInt32(item.IsDraft);

                        aa.prpongoing = sdbcalc.Extract_AuthDesk_AgentRegistrationNumber_ByAgentID(parmRelated_AgentID, parmNumberOptions_Flag, parmAgentStateType_Flag, parmRegistration_IssueDate, parmRegistration_UptoDate, UserNam);
                        chkappid = 1;
                    }
                }

                if (chkappid == null)
                    status = false;
                else
                    status = true;

            }

            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    numberObject = aa.prpongoing
                }
            };
        }

        //Check Single Entry RERA number
        public JsonResult CheckRealestateAgentRERAregistrationNumber(string mRegNumber)
        {
            ClsMethod_ViewAdd_AgentRERAnumber CheckRegdNo = new ClsMethod_ViewAdd_AgentRERAnumber();
            bool RegdNo = CheckRegdNo.Check_UniqueAgentRegistrationNumber(mRegNumber);

            return Json(RegdNo);
        }

        [HttpGet]
        public ActionResult RealestateAgentRegistrationNumberRecordsHistory(string agentId, string varflag)
        {
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            Int64 RefAgentID = String.IsNullOrEmpty(agentId) ? 0 : Convert.ToInt64(agentId);            
            Int32 VarFlag = String.IsNullOrEmpty(varflag) ? 0 : Convert.ToInt32(varflag);

            ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails();
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();

            aa.prpongoing = sdb.Display_AuthDesk_AgentRegistrationNumberHistory_ByAgentID(RefAgentID, UID);
            foreach (var item in aa.prpongoing)
            {
                aa.Prepared_SequenceNumber = item.Prepared_SequenceNumber;
                aa.Prepared_AgentStateType = item.Prepared_AgentStateType;
                aa.Prepared_NumberTypeFlag = item.Prepared_NumberTypeFlag;
                aa.Prepared_RegistrationNumber = item.Prepared_RegistrationNumber;
                aa.Prepared_IssueDate = item.Prepared_IssueDate;
                aa.Prepared_ValidUptoDate = item.Prepared_ValidUptoDate;
                aa.Amount_PriceValue = item.Amount_PriceValue;
                aa.NumberAlreadyExisted_Flag = item.NumberAlreadyExisted_Flag;
                aa.RealEstateAgentName = item.RealEstateAgentName;
                aa.RealEstateAgentRegDiaryNumber_Name = item.RealEstateAgentRegDiaryNumber_Name;
                aa.RemarksIfAny = item.RemarksIfAny;
                aa.A_Column = item.A_Column;
                aa.B_Column = item.B_Column;
                aa.C_Column = item.C_Column;
            }
            return View("RealestateAgentRegistrationNumberRecordsHistory", aa);
        }
        #endregion Add or Insert Agent RERA Number               

        #region Upload Agent RERA Certificate
        [HttpGet]
        public ActionResult Add_AgentRERAcertificateDetails()
        {
            ClsPrp_AuthorityDesk_AgentRERA_Certificate aa = new ClsPrp_AuthorityDesk_AgentRERA_Certificate();
            ClsMethod_ViewAdd_AgentRERAcertificate sdb = new ClsMethod_ViewAdd_AgentRERAcertificate();            

            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            string UserNam = User.Identity.Name;
            if (Session["zapAgentID"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthDesk_AgentRERAcertificate_ByAgentIdandDiaryNumber(AgentID);            

            if (Session["zapAgentID"] != null)
            {
                string AgentDiaryNumber = (Session["zapAgentDiaryNumber"] != null) ? Session["zapAgentDiaryNumber"].ToString() : "";
                string AgentName = (Session["zapAgentName"] != null) ? Session["zapAgentName"].ToString() : "";
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = (Session["zapLastModifiedOn"] != null) ? Convert.ToDateTime(Session["zapLastModifiedOn"]) : (DateTime?)null;

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            foreach (var item in aa.prpongoing)
            {
                //aa.AgentRERAcertificate_IndexID = item.AgentRERAcertificate_IndexID;
                //aa.AgentRERAcertificate_ID = item.AgentRERAcertificate_ID;
                //aa.AgentRegDiaryNumber_Name = item.AgentRegDiaryNumber_Name;
                //aa.Agent_ID = item.Agent_ID;
                //aa.tbl_RegDiaryNumber_indexID = item.tbl_RegDiaryNumber_indexID;

                //aa.AgentRERAcert_InfoCode = item.AgentRERAcert_InfoCode;
                //aa.AgentRERAcert_InfoName = item.AgentRERAcert_InfoName;
                //aa.AgentDoc_RelatedSectionName = item.AgentDoc_RelatedSectionName;
                //aa.AgentRERAcert_ReferenceNumber = item.AgentRERAcert_ReferenceNumber;
                //aa.AgentRERAcert_IssueDate = item.AgentRERAcert_IssueDate;

                //aa.AgentRERAcert_FileSize = item.AgentRERAcert_FileSize;
                //aa.AgentRERAcert_FileFormat = item.AgentRERAcert_FileFormat;
                //aa.AgentRERAcert_FilePath = item.AgentRERAcert_FilePath;
                //aa.AgentRERAcert_FileName = item.AgentRERAcert_FileName;
                //aa.AgentRERAcert_IsGroup = item.AgentRERAcert_IsGroup;

                //aa.Remarks_IfAny = item.Remarks_IfAny;
                //aa.A_column = item.A_column;
                //aa.B_column = item.B_column;
                //aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                //aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                //aa.IsDraftEvaluation = item.IsDraftEvaluation;
                //aa.IsDraftSecMember = item.IsDraftSecMember;
                //aa.IsDraftMember = item.IsDraftMember;
                //aa.IsPublicView = item.IsPublicView;

                //aa.CreatedBy = item.CreatedBy;
                //aa.CreatedOn = item.CreatedOn;
                //aa.ModifyBy = item.ModifyBy;
                //aa.ModifyOn = item.ModifyOn;

            }

            //if (aa.prpongoing.Count >= 1)
            //{
            //    if (aa.IsDraftHelpDesk == 1)
            //    {
            //        TempData["submitvalue"] = "Update"; TempData.Keep();
            //    }
            //    else
            //    {
            //        TempData["submitvalue"] = "Save"; TempData.Keep();
            //    }
            //}
            //else
            //{
                TempData["submitvalue"] = "Save"; TempData.Keep();
            //}
            return View("Add_AgentRERAcertificateDetails", aa);
        }

        [HttpPost]
        public ActionResult Add_AgentRERAcertificateDetails(ClsPrp_AuthorityDesk_AgentRERA_Certificate smodel)
        {
            string Photo_Address = string.Empty;
            Int64 Agent_CodeID = 0;
            string userRole = string.Empty;
            string Agent_DiaryNumber = string.Empty;

            userRole = getUserRole();
            string UserNam = User.Identity.Name;
             
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();

                Agent_CodeID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
            }

            //Save & Update
            #region

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
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwriteAgentCert";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.AgentRERAcert_FilePath))
                            {
                                pathindb = smodel.AgentRERAcert_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Agent_CodeID) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.AgentRERAcert_FileName))
                            {
                                fileName = smodel.AgentRERAcert_FileName.ToString();
                            }
                            else
                            {
                                fileName = "RERAcert_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }

                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 1MB";
                            error = "Photo Size Should be less than 1MB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg or .pdf";
                        error = "Photo format should be .jpg or .pdf";
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
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.AgentRERAcert_FileName;
                            ext = smodel.AgentRERAcert_FilePath;
                            FilePathExt = smodel.AgentRERAcert_FilePath;
                        }
                        try
                        {
                            ClsMethod_ViewAdd_AgentRERAcertificate sdb = new ClsMethod_ViewAdd_AgentRERAcertificate();
                            sdb.Update_LDR_Agent_RERAcertifcate_DiaryNumber(smodel, Agent_CodeID, Photo_Address, FilePathExt, UserNam, userRole, Agent_DiaryNumber);
                            TempData["message"] = "Details updated Successfully";

                            return RedirectToAction("Add_AgentRERAcertificateDetails");
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            return View();
                        }
                    }
                    return RedirectToAction("Add_AgentRERAcertificateDetails");
                }
                else
                {
                    return RedirectToAction("Add_AgentRERAcertificateDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwriteAgentCert";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Agent_CodeID) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "RERAcert_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 1MB";
                            error = "Photo Size Should be less than 1MB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg or .pdf";
                        error = "Photo format should be .jpg or .pdf";
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
                        if (ModelState.IsValid)
                        {
                            if (Photo_Address == "")
                            {
                                Photo_Address = smodel.AgentRERAcert_FileName;
                                ext = smodel.AgentRERAcert_FilePath;
                                FilePathExt = smodel.AgentRERAcert_FilePath;
                            }
                            ClsMethod_ViewAdd_AgentRERAcertificate sdb = new ClsMethod_ViewAdd_AgentRERAcertificate();
                            if (sdb.Add_LDR_Agent_RERAcertifcate_DiaryNumber(smodel, Agent_CodeID, Photo_Address, FilePathExt, UserNam, userRole, Agent_DiaryNumber))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("Add_AgentRERAcertificateDetails");
                    }
                    else
                    {
                        return RedirectToAction("Add_AgentRERAcertificateDetails");
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return View();
                }
            }
            #endregion
        }

        public ActionResult Delete_AgentRERAcertificateDetails(Int64? inAgentRERAcertificate_IndexID, Int64? inAgentRERAcertificate_ID, Int64? inAgent_ID)
        {
            try
            {
                ClsMethod_ViewAdd_AgentRERAcertificate sdb = new ClsMethod_ViewAdd_AgentRERAcertificate();
                if (sdb.Delete_AuthDesk_AgentRERAcertificateDetailsById(inAgentRERAcertificate_IndexID, inAgentRERAcertificate_ID, inAgent_ID))
                {
                    TempData["message"] = " Details deleted Successfully";                    
                }
                return RedirectToAction("Add_AgentRERAcertificateDetails");
            }
            catch
            {
                return RedirectToAction("Add_AgentRERAcertificateDetails");
            }
        }
        #endregion

        #region Agent RERA Number Event 

        [HttpGet]
        public ActionResult AgentRERAnumberInfoEventInsert()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();

            string userRole = string.Empty;
            userRole = getUserRole();
            //to bind subCheckList master
            aa.EventMaster = sdb.Display_AuthorityDesk_AgentEvent_Master(userRole);

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.AgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.AgentLastModifiedOn = LastModifiedOn;
            }
            else
            {
                aa.Related_Agent_ID = 0;
                aa.Agent_DiaryNumber = "";
                aa.AgentName = "";
            }


            TempData["EventSubmitMessage"] = "";
            TempData["submitvalue"] = "Submit"; TempData.Keep();

            return View("AgentRERAnumberInfoEventInsert", aa);
        }

        [HttpGet]
        public ActionResult AgentRERAnumberInfoEventInsertAction(string AgentDiaryNumber, string AgentName, Int64? AgentID, DateTime? LastModifiedOn)
        {

            Session["zapAgentDiaryNumber"] = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
            Session["zapAgentName"] = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
            Session["zapAgentID"] = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
            Session["zapLastModifiedOn"] = LastModifiedOn;


            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();

            string userRole = string.Empty;
            userRole = getUserRole();
            //to bind subCheckList master
            aa.EventMaster = sdb.Display_AuthorityDesk_AgentEvent_Master(userRole);

            aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
            aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
            aa.AgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
            aa.AgentLastModifiedOn = LastModifiedOn;


            TempData["EventSubmitMessage"] = "";

            return View("AgentRERAnumberInfoEventInsert", aa);
        }

        [HttpPost]
        public ActionResult AgentRERAnumberInfoEventInsert(ClsPrp_AuthorityDesk_AgentEventLog smodel)
        {
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;

                    if (sdb.Add_Agent_InfoEvent(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();

                        TempData["EventSubmitMessage"] = "Application Performa successfully Submitted.";

                    }


                    //to bind subCheckList master
                    aa.EventMaster = sdb.Display_AuthorityDesk_AgentEvent_Master(pUserRole);

                    if (Session["zapAgentDiaryNumber"] != null)
                    {
                        string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                        string AgentName = Session["zapAgentName"].ToString();
                        Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                        DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                        aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                        aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                        aa.AgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                        aa.AgentLastModifiedOn = LastModifiedOn;
                    }
                    else
                    {
                        aa.Related_Agent_ID = 0;
                        aa.Agent_DiaryNumber = "";
                        aa.AgentName = "";
                    }

                }
                //return View("ProjectInfoCheckListInsert", aa);              
                return View("AgentRERAnumberInfoEventInsert", aa);
                //return RedirectToAction("ProjectInfoEventInsert");
            }
            catch (Exception)
            {
                TempData["EventSubmitMessage"] = "Sorry, Application Performa is pending";
                return View("AgentRERAnumberInfoEventInsert", aa);
                //return RedirectToAction("ProjectInfoEventInsert");
            }
        }

        public JsonResult GetEventDescriptionMasterByCode(string EventCode)
        {
            int Id = 0;
            if (EventCode != "")
                Id = Convert.ToInt32(EventCode);

            ClsMethod_Agent_Helpdesk objCode = new ClsMethod_Agent_Helpdesk();
            var Subdiv = objCode.Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Id);

            return Json(Subdiv);
        }
        #endregion

        #region Agent Event 

        [HttpGet]
        public ActionResult AgentInfoEventInsert()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();

            string userRole = string.Empty;
            userRole = getUserRole();
            //to bind subCheckList master
            aa.EventMaster = sdb.Display_AuthorityDesk_AgentEvent_Master(userRole);

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);                

                aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.AgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.AgentLastModifiedOn = LastModifiedOn;
            }
            else
            {
                aa.Related_Agent_ID = 0;                
                aa.Agent_DiaryNumber = "";                
                aa.AgentName = "";
            }

            
            TempData["EventSubmitMessage"] = "";

            return View("AgentInfoEventInsert", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoEventInsertAction(string AgentDiaryNumber, string AgentName, Int64? AgentID, DateTime? LastModifiedOn)
        {            

            Session["zapAgentDiaryNumber"] = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
            Session["zapAgentName"] = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
            Session["zapAgentID"] = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
            Session["zapLastModifiedOn"] = LastModifiedOn;           


            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();

            string userRole = string.Empty;
            userRole = getUserRole();
            //to bind subCheckList master
            aa.EventMaster = sdb.Display_AuthorityDesk_AgentEvent_Master(userRole);

            aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;            
            aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);            
            aa.AgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
            aa.AgentLastModifiedOn = LastModifiedOn;

            
            TempData["EventSubmitMessage"] = "";

            return View("AgentInfoEventInsert", aa);
        }

        [HttpPost]
        public ActionResult AgentInfoEventInsert(ClsPrp_AuthorityDesk_AgentEventLog smodel)
        {
            ClsPrp_AuthorityDesk_AgentEventLog aa = new ClsPrp_AuthorityDesk_AgentEventLog();
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;

                    if (sdb.Add_Agent_InfoEvent(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();
                        
                        TempData["EventSubmitMessage"] = "Application Performa successfully Submitted.";
                        TempData["EventSubmitMessageAgentMappingUrlFlag"] = getMappingUrlByAgentEvent();
                    }

                    
                    //to bind subCheckList master
                    aa.EventMaster = sdb.Display_AuthorityDesk_AgentEvent_Master(pUserRole);

                    if (Session["zapAgentDiaryNumber"] != null)
                    {
                        string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                        string AgentName = Session["zapAgentName"].ToString();
                        Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                        DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                        aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                        aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                        aa.AgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                        aa.AgentLastModifiedOn = LastModifiedOn;
                    }
                    else
                    {
                        aa.Related_Agent_ID = 0;
                        aa.Agent_DiaryNumber = "";
                        aa.AgentName = "";
                    }

                }
                //return View("ProjectInfoCheckListInsert", aa);              
                return View("AgentInfoEventInsert", aa);
                //return RedirectToAction("ProjectInfoEventInsert");
            }
            catch (Exception)
            {
                TempData["EventSubmitMessage"] = "Sorry, Application Performa is pending";
                TempData["EventSubmitMessageAgentMappingUrlFlag"] = getMappingUrlByAgentEvent();

                return View("AgentInfoEventInsert", aa);
                //return RedirectToAction("ProjectInfoEventInsert");
            }
        }

        public JsonResult GetEventDescriptionMasterForRERAnumberByCode(string EventCode)
        {
            int Id = 0;
            if (EventCode != "")
                Id = Convert.ToInt32(EventCode);

            ClsMethod_Agent_Helpdesk objCode = new ClsMethod_Agent_Helpdesk();
            var Subdiv = objCode.Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Id);

            return Json(Subdiv);
        }

        private string getMappingUrlByAgentEvent()
        {
            string vret = string.Empty;
            string pUserRole = string.Empty;
            string pUser_WhoIdentified = string.Empty;

            pUser_WhoIdentified = User.Identity.Name;
            pUserRole = getUserRole();

            vret = "ResetFlag";

            // Chairperson OR membersg OR memberjsk
            if (pUser_WhoIdentified == "chairperson" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskReviewCL";
            }
            if (pUser_WhoIdentified == "membersg" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskReviewCL";
            }
            if (pUser_WhoIdentified == "memberjsk" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskReviewCL";
            }

            // Secrett RERA
            if (pUser_WhoIdentified == "secyrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskCheckList";
            }
            if (pUser_WhoIdentified == "consultantrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskCheckList";
            }
            if (pUser_WhoIdentified == "mngradminrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskCheckList";
            }

            // ReraDesk
            if (pUserRole == "7b9d725a-b33c-4aba-934a-bee1ec13f684")
            {
                vret = "HelpdeskAgent/AgentInfoDesk";
            }

            // System Analysist
            if (pUserRole == "e583ee7f-aaa3-49bd-afc8-79c877afe591")
            {
                vret = "HelpdeskAgent/AgentInfoDeskIssueRERAid";
            }

            // System Counseltent
            if (pUser_WhoIdentified == "pbreraconsultant" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDesk";
            }
            if (pUser_WhoIdentified == "secttrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentInfoDeskCheckList";
            }
            return vret;
        }

        #endregion

        #region Agent CheckList       

        [HttpGet]
        public ActionResult AgentInfoCheckListInsert(Int32? AgentId, Int32? criteriaCode)//Int64 projectId, string DiaryNumber)
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();

            Int32 CheckList_ID = Convert.ToInt32(criteriaCode);

            //aa.prpongoing = sdb.Display_AuthorityDesk_SubCheckList_MasterDetails(CheckList_ID);

            //to bind subCheckList master
            aa.SubCheckListMaster = sdb.Display_AuthorityDesk_AgentSubCheckList_MasterDetails(CheckList_ID);

            aa.A_column = sdb.Fill_AgentChecklistCriteriaName(CheckList_ID);

            aa.Related_Agent_ID = 0;            
            aa.Agent_DiaryNumber = "";            
            if (criteriaCode != null)
                aa.CriteriaCode = criteriaCode.ToString();

            if (Session["zapAgentID"] != null)
            {
                string AgentDiaryNumber = (Session["zapAgentDiaryNumber"] != null) ? Session["zapAgentDiaryNumber"].ToString() : "";
                string AgentName = (Session["zapAgentName"] != null) ? Session["zapAgentName"].ToString() : "";
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = (Session["zapLastModifiedOn"] != null) ? Convert.ToDateTime(Session["zapLastModifiedOn"]) : (DateTime?)null;

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;

                aa.Related_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;                
                aa.Agent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);                
            }                      


            return View("AgentInfoCheckListInsert", aa);

        }

        [HttpPost]
        public ActionResult AgentInfoCheckListInsert(ClsPrp_AuthorityDesk_AgentSubCheckListLog smodel)
        {
            string viewname = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();

                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;
                    if (sdb.Add_Agent_InfoCheckList(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                //return View("ProjectInfoCheckListInsert", smodel);
                //return RedirectToAction("AgentInfoCheckListDisplay");

                var fullUrl = this.Request.UrlReferrer.ToString();
                string url = fullUrl;
                var request = new HttpRequest(null, url, null);
                var response = new HttpResponse(new System.IO.StringWriter());
                var httpContext = new HttpContext(request, response);
                var routeData = System.Web.Routing.RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
                var values = routeData.Values;
                string controllerName = values["controller"].ToString();
                viewname = values["action"].ToString();

                return RedirectToAction(viewname);

            }
            catch (Exception)
            {                
                return RedirectToAction("AgentInfoCheckListDisplay");
            }
        }

        public JsonResult GetAgentCriteriaSubCodeDescriptionMasterByCode(string CriteriaSubCode)
        {
            int Id = 0;
            if (CriteriaSubCode != "")
                Id = Convert.ToInt32(CriteriaSubCode);

            ClsMethod_Agent_Helpdesk objCode = new ClsMethod_Agent_Helpdesk();
            var Subdiv = objCode.Display_AuthorityDesk_AgentSubCheckList_MasterDetailsByCode(Id);           

            return Json(Subdiv);
        }

        [HttpGet]
        public ActionResult AgentInfoCheckListDisplay()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();
            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;                
            }

            aa.prpongoing = sdb.Display_AuthorityDesk_AgentCheckList_DetailsByCode(AgentID, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.AgentCheckListAction_ID = item.AgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;                
                aa.Agent_DiaryNumber = item.Agent_DiaryNumber;                
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.CriteriaSubCodeTitle = item.CriteriaSubCodeTitle;
                aa.VarCriteriaCode = item.VarCriteriaCode;
                aa.VarCriteriaSubCode = item.VarCriteriaSubCode;
                aa.VarChecklistOrderNumber = item.VarChecklistOrderNumber;
                aa.VarChecklistGroupID = item.VarChecklistGroupID;
            }

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;                
            }


            return View("AgentInfoCheckListDisplay", aa);
        }

        [HttpGet] 
        public ActionResult AgentInfoCheckListNoAcceptDisplay(Int32? AgentId, Int32? criteriaCode)
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();
            string userRole = string.Empty;
            Int64 prmAgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                prmAgentID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode(prmAgentID, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.AgentCheckListAction_ID = item.AgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
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

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }


            return View("AgentInfoCheckListNoAcceptDisplay", aa);
        }

        public JsonResult GetCriteriaDescription_NotAccepted_ByAgentID(Int32? AgentId)
        {
            int Id = 0;
            Id = Convert.ToInt32(AgentId);

            string pUserRole = string.Empty;
            pUserRole = getUserRole();

            ClsMethod_Agent_Helpdesk objCode = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();
            //var Subdiv =
            aa.prpongoing = objCode.Display_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode(Id, pUserRole);
            string varStrRet = string.Empty;
            Int32 vlenStart = 0;
            Int32 vlen = aa.prpongoing.Count();
            foreach (var item in aa.prpongoing)
            {
                if (vlenStart == vlen - 1)
                {
                    // last
                    varStrRet += item.CriteriaCode;
                }
                else
                {
                    varStrRet += item.CriteriaCode + ", ";
                }
                vlenStart++;
                //aa.CriteriaSubCode = item.CriteriaSubCode;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                //aa.IsChecklistValueOk = item.IsChecklistValueOk;               
            }

            return Json(varStrRet);
        }

        [HttpGet]
        public ActionResult AgentInfoCheckListNoAcceptPDF()
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();
            string userRole = string.Empty;
            Int64 prmAgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                prmAgentID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode(prmAgentID, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.AgentCheckListAction_ID = item.AgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
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

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return new RazorPDF.PdfActionResult(aa);            
        }

        [HttpGet]
        public ActionResult AgentInfoCheckListDisplayLog(Int64 parmAgentId, Int32 parmCriteriaID, Int32 parmCriteriaSubID)
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();

            string userRole = string.Empty;

            Int64 vAgentID = 0;
            Int32 vCriteriaID = 0;
            Int32 vCriteriaSubID = 0;
            userRole = getUserRole();

            vAgentID = parmAgentId;
            vCriteriaID = parmCriteriaID;
            vCriteriaSubID = parmCriteriaSubID;

            aa.prpongoing = sdb.Display_AuthorityDesk_CheckList_DetailsByCode_ForExpandLog(vAgentID, userRole, vCriteriaID, vCriteriaSubID);

            foreach (var item in aa.prpongoing)
            {
                aa.AgentCheckListAction_ID = item.AgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.CriteriaSubCodeTitle = item.CriteriaSubCodeTitle;
                aa.VarCriteriaCode = item.VarCriteriaCode;
                aa.VarCriteriaSubCode = item.VarCriteriaSubCode;
                aa.VarChecklistOrderNumber = item.VarChecklistOrderNumber;
                aa.VarChecklistGroupID = item.VarChecklistGroupID;
            }

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("AgentInfoCheckListDisplayLog", aa);
        }

        [HttpGet]
        public ActionResult AgentInfoCheckListDisplayLogByFlag(Int64 parmAgentId, Int32 parmCriteriaID, Int32 parmCriteriaSubID, Int32 parmCriteriaFlag)
        {
            ClsMethod_Agent_Helpdesk sdb = new ClsMethod_Agent_Helpdesk();
            ClsPrp_AuthorityDesk_AgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_AgentSubCheckListLog();

            string userRole = string.Empty;

            Int64 vAgentID = 0;            
            Int32 vCriteriaID = 0;
            Int32 vCriteriaSubID = 0;
            Int32 vCriteriaFlag = 0;
            userRole = getUserRole();

            vAgentID = parmAgentId;            
            vCriteriaID = parmCriteriaID;
            vCriteriaSubID = parmCriteriaSubID;
            vCriteriaFlag = parmCriteriaFlag;

            aa.prpongoing = sdb.Display_AuthorityDesk_CheckList_DetailsByAgentID_ForLogHistory(vAgentID, userRole, vCriteriaID, vCriteriaSubID, vCriteriaFlag);
            foreach (var item in aa.prpongoing)
            {
                aa.AgentCheckListAction_ID = item.AgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Agent_DiaryNumber = item.Agent_DiaryNumber;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.CriteriaSubCodeTitle = item.CriteriaSubCodeTitle;
                aa.VarCriteriaCode = item.VarCriteriaCode;
                aa.VarCriteriaSubCode = item.VarCriteriaSubCode;
                aa.VarChecklistOrderNumber = item.VarChecklistOrderNumber;
                aa.VarChecklistGroupID = item.VarChecklistGroupID;
            }

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("AgentInfoCheckListDisplayLogByFlag", aa);
        }
        #endregion

        #region View Agent Payment Details

        [HttpGet]
        public ActionResult Display_AgentPaymentDetails()
        {
            ClsMethod_View_AgentPayment sdb = new ClsMethod_View_AgentPayment();
            ClsPrp_AuthDesk_View_AgentPayment aa = new ClsPrp_AuthDesk_View_AgentPayment();
            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentID"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.AgentPayment = sdb.Display_AuthDesk_AgentPaymentDetail(AgentID);
            aa.AgentPaymentWithTranasactions = sdb.Display_Print_AgentApplicationPaymentTransactions(AgentID);

            foreach (var item in aa.AgentPayment)
            {
                aa.AgentPayment_IndexID = item.AgentPayment_IndexID;
                aa.AgentPayment_ID = item.AgentPayment_ID;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;

                aa.IsDraftAgentPayment = item.IsDraft;
            }

            if (Session["zapAgentID"] != null)
            {
                string AgentDiaryNumber = (Session["zapAgentDiaryNumber"] != null) ? Session["zapAgentDiaryNumber"].ToString() : "";
                string AgentName = (Session["zapAgentName"] != null) ? Session["zapAgentName"].ToString() : "";
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = (Session["zapLastModifiedOn"] != null) ? Convert.ToDateTime(Session["zapLastModifiedOn"]) : (DateTime?)null;

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("Display_AgentPaymentDetails", aa);
        }

        //Lock-Unlock Handler (Registration Fee Details)             
        public JsonResult LockUnlockHandler_Agent_RegistrationPayment(string parmAgentId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;                
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                Int32 AgentTypeId = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }                
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Agent Registration Fee/Payment details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_AgentPayment sdb = new ClsMethod_View_AgentPayment();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_PaymentDetail(AgentCode, AgentTypeId, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked registration fee details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked registration fee details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent Document Details

        [HttpGet]
        public ActionResult Display_AgentDocumentDetails()
        {
            ClsMethod_View_AgentDocuments sdb = new ClsMethod_View_AgentDocuments();
            ClsPrp_AuthDesk_View_AgentDocuments aa = new ClsPrp_AuthDesk_View_AgentDocuments();
            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.AgentDocs = sdb.Display_AuthDesk_AgentDocuments_ByAgentId(AgentID);
            
            #region Lock - Unlock (Logic Display Message)
            bool var_Anydocopen = false;
            bool var_Alldocclosed = false;
            bool var_Anydocpermanent = false;

            if (aa.AgentDocs.Count == 0)
            {
                aa.IsDraftAgentListDocuments = 0;
                aa.parmRelated_AgentType_ID = 0;
            }

            foreach (var item in aa.AgentDocs)
            {
                aa.AgentDoc_IndexID = item.AgentDoc_IndexID;
                aa.AgentDoc_ID = item.AgentDoc_ID;
                aa.Agent_ID = item.Agent_ID;
                aa.parmRelated_AgentType_ID = item.parmRelated_AgentType_ID;
                aa.AgentDoc_InfoCode = item.AgentDoc_InfoCode;
                aa.AgentDoc_InfoName = item.AgentDoc_InfoName;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;

                if (item.IsDraft == 1)
                {
                    var_Alldocclosed = true;
                }
                if (item.IsDraft == 5)
                {
                    var_Anydocopen = true;
                }
                if (item.IsDraft == 6)
                {
                    var_Anydocpermanent = true;
                }
            }

            if (var_Anydocpermanent)
            {
                aa.IsDraftAgentListDocuments = 6;
            }
            else if (var_Anydocopen)
            {
                aa.IsDraftAgentListDocuments = 5;
            }
            else if (var_Alldocclosed)
            {
                aa.IsDraftAgentListDocuments = 1;
            }
            else
            {
                aa.IsDraftAgentListDocuments = 0;
            }
            #endregion

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }
            return View("Display_AgentDocumentDetails", aa);
        }

        //Lock-Unlock Handler (Agent Documents List)
        public JsonResult LockUnlockHandler_Agent_DocumentList(string parmAgentId, string parmAgentTypeId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;                
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }                
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Agent document(s) list details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion
                ClsMethod_View_AgentDocuments sdb = new ClsMethod_View_AgentDocuments();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_DocumentsByList(AgentCode, AgentTypeCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked list of agent document(s) details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked list of agent document(s) details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }

        //Lock-Unlock Handler (Agent Document By Index)
        public JsonResult LockUnlockHandler_Agent_DocumentByIndex(string parmAgentId, string parmAgentTypeId, string parmLockUnlock, string parmIndexID, string parmDocByIndex)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;                
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                Int32 DocByIndexID = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }                
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                if (parmDocByIndex != string.Empty)
                {
                    DocByIndexID = Convert.ToInt32(parmDocByIndex);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Agent document details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion
                ClsMethod_View_AgentDocuments sdb = new ClsMethod_View_AgentDocuments();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_DocumentDetailsByIndex(AgentCode, AgentTypeCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg, DocByIndexID);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked agent document details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked agent document details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent Other State UT RERA Details

        [HttpGet]
        public ActionResult Display_AgentOtherStateUT_RERA()
        {
            ClsMethod_View_AgentOtherStateUT_RERA sdb = new ClsMethod_View_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_AgentOtherStateUT_RERA aa = new ClsPrp_AuthDesk_View_AgentOtherStateUT_RERA();
            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.Agent_OtherStateUTMember = sdb.Display_AuthDesk_AgentOtherStateUT_RERADetail(AgentID);
            foreach (var item in aa.Agent_OtherStateUTMember)
            {
                aa.Agent_OtherStateUT_regRERA_IndexID = item.Agent_OtherStateUT_regRERA_IndexID;
                aa.Agent_OtherStateUT_regRERA_ID = item.Agent_OtherStateUT_regRERA_ID;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;

                aa.IsDraftAgentOtherStateRERA = item.IsDraft;
            }

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("Display_AgentOtherStateUT_RERA", aa);
        }

        //Lock-Unlock Handler (Registration Fee Details)             
        public JsonResult LockUnlockHandler_Agent_OtherStateUT_RERA(string parmAgentId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                Int32 AgentTypeId = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Other State-UT RERA of Agent detail";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_AgentOtherStateUT_RERA sdb = new ClsMethod_View_AgentOtherStateUT_RERA();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_OtherStateUT_RERA(AgentCode, AgentTypeId, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked other state-UT RERA details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked other state-UT RERA details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent RERA Registration(s) Details

        [HttpGet]
        public ActionResult Display_AgentRefRegistrations_RERA()
        {
            ClsMethod_View_AgentOtherStateUT_RERA sdb = new ClsMethod_View_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA aa = new ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeId = 1; 
            string AgentFlag = string.Empty;
            if (Session["zapAgentID"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.Agent_RefRegistrationsRERA = sdb.Display_AuthDesk_Agent_RefRegistrations_RERADetail(AgentID, AgentTypeId, AgentFlag, userRole);
            if (Session["zapAgentID"] != null)
            {
                string AgentDiaryNumber = (Session["zapAgentDiaryNumber"] != null) ? Session["zapAgentDiaryNumber"].ToString() : "";
                string AgentName = (Session["zapAgentName"] != null) ? Session["zapAgentName"].ToString() : "";
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = (Session["zapLastModifiedOn"] != null) ? Convert.ToDateTime(Session["zapLastModifiedOn"]) : (DateTime?)null;

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("Display_AgentRefRegistrations_RERA", aa);
        }

        [HttpGet]
        public ActionResult Display_AgentRefRegistrations_RERAinfoDesk()
        {
            ClsMethod_View_AgentOtherStateUT_RERA sdb = new ClsMethod_View_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA aa = new ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeId = 1;
            string AgentFlag = string.Empty;
            if (Session["zapAgentID"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            aa.Agent_RefRegistrationsRERA = sdb.Display_AuthDesk_Agent_RefRegistrations_RERADetail(AgentID, AgentTypeId, AgentFlag, userRole);
            if (Session["zapAgentID"] != null)
            {
                string AgentDiaryNumber = (Session["zapAgentDiaryNumber"] != null) ? Session["zapAgentDiaryNumber"].ToString() : "";
                string AgentName = (Session["zapAgentName"] != null) ? Session["zapAgentName"].ToString() : "";
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = (Session["zapLastModifiedOn"] != null) ? Convert.ToDateTime(Session["zapLastModifiedOn"]) : (DateTime?)null;

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("Display_AgentRefRegistrations_RERAinfoDesk", aa);
        }

        [HttpGet]
        public ActionResult AgentInfo_PrevRegistrationsDetail(Int64 AgentBaseId, Int32 AgentType, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string flagCode)
        {
            ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA sdb = new ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations recObj = new ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            userRole = getUserRole();

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            int? BusinessPlace_AddressSubDivisionCode = 0;

            try
            {
                recObj.AgentPrevRegistrations = sdb.Display_PopUpDesk_RenewalAgent_PrevRegistrationRecord_RERADetail(AgentBaseId, AgentType, RnAgentId, RnAgentSeqId, RnAgentYrId, flagCode, userRole);

                foreach (var item in recObj.AgentPrevRegistrations)
                {
                    statecode = (String.IsNullOrEmpty(item.RegOfficeOrPermanent_AddressStateCode) ? 0 : Convert.ToInt32(item.RegOfficeOrPermanent_AddressStateCode));
                    recObj.P_AddressState = objdis.State_Name(statecode);
                    DistrictCode = (String.IsNullOrEmpty(item.RegOfficeOrPermanent_AddressDistrictCode) ? 0 : Convert.ToInt32(item.RegOfficeOrPermanent_AddressDistrictCode));
                    recObj.P_AddressDist = objdis.District_Name(DistrictCode);

                    BusinessPlace_AddressStateCode = (String.IsNullOrEmpty(item.BusinessPlace_AddressStateCode) ? 0 : Convert.ToInt32(item.BusinessPlace_AddressStateCode));
                    recObj.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                    BusinessPlace_AddressDistrictCode = (String.IsNullOrEmpty(item.BusinessPlace_AddressDistrictCode) ? 0 : Convert.ToInt32(item.BusinessPlace_AddressDistrictCode));
                    recObj.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                    BComm_AddressStateCode = (String.IsNullOrEmpty(item.BComm_AddressStateCode) ? 0 : Convert.ToInt32(item.BComm_AddressStateCode));
                    recObj.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                    BComm_AddressDistrictCode = (String.IsNullOrEmpty(item.BComm_AddressDistrictCode) ? 0 : Convert.ToInt32(item.BComm_AddressDistrictCode));
                    recObj.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                    BusinessPlace_AddressSubDivisionCode = (String.IsNullOrEmpty(item.BusinessPlace_AddressSubDivisionName) ? 0 : Convert.ToInt32(item.BusinessPlace_AddressSubDivisionName));
                    recObj.BusinessPlace_AddressSubDivision = objdis.SubDivision_Name(BusinessPlace_AddressSubDivisionCode);
                }

                recObj.AgentPrevRegistrations_OtherMember = sdb.Display_PopUpDesk_RenewalAgent_PrevRegistrationRecord_OthermemberDetail(AgentBaseId, AgentType, RnAgentId, RnAgentSeqId, RnAgentYrId, flagCode, userRole);

                for (var i = 0; i < recObj.AgentPrevRegistrations_OtherMember.Count; i++)
                {
                    DistrictCode = recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressDistrictCode;
                    recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressDistName = objdis.District_Name(DistrictCode);

                    statecode = recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressStateCode;
                    recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressStateName = objdis.State_Name(statecode);
                }

            }
            catch (Exception ex)
            {
                string exSTR = ex.ToString();
            }
            return View("AgentInfo_PrevRegistrationsDetail", recObj);
        }

        #endregion

        #region View Agent Ind Profile

        [HttpGet]
        public ActionResult Display_AgentIndProfile()
        {
            ClsMethod_View_AgentInd_OtherInd_Profile sdb = new ClsMethod_View_AgentInd_OtherInd_Profile();
            ClsPrp_AuthDesk_View_AgentIndProfile aa = new ClsPrp_AuthDesk_View_AgentIndProfile();
            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            int? BusinessPlace_AddressSubDivisionCode = 0;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.AgentIndProfile = sdb.Display_AuthDesk_AgentIndProfileDetail(AgentID);            

            foreach (var item in aa.AgentIndProfile)
            {
                if (item.Agent_Type == 2)
                {
                    return RedirectToAction("Display_AgentOtherIndProfile");
                }

                statecode = item.P_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);

                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                BusinessPlace_AddressSubDivisionCode = (String.IsNullOrEmpty(item.B_Column) ? 0 : Convert.ToInt32(item.B_Column));
                aa.BusinessPlace_AddressSubDivision = objdis.SubDivision_Name(BusinessPlace_AddressSubDivisionCode);

                aa.ID = item.ID;
                aa.Agent_ID = item.Agent_ID;
                aa.Agent_Type = item.Agent_Type;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;

                aa.IsDraftAgentProfile = item.IsDraft;
            }

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("Display_AgentIndProfile", aa);
        }

        //Lock-Unlock Handler (Agent-Individual Profile Details)             
        public JsonResult LockUnlockHandler_Agent_IndProfileRegistration(string parmAgentId, string parmAgentTypeId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Agent-Individual Profile detail";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_AgentInd_OtherInd_Profile sdb = new ClsMethod_View_AgentInd_OtherInd_Profile();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_IndProfileDetail(AgentCode, AgentTypeCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked agent profile details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked agent profile details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent Other Than Ind Profile

        [HttpGet]
        public ActionResult Display_AgentOtherIndProfile()
        {
            ClsMethod_View_AgentInd_OtherInd_Profile sdb = new ClsMethod_View_AgentInd_OtherInd_Profile();
            ClsPrp_AuthDesk_View_AgentOtherIndProfile aa = new ClsPrp_AuthDesk_View_AgentOtherIndProfile();
            string userRole = string.Empty;
            Int64 AgentID = 0;
            userRole = getUserRole();
            if (Session["zapAgentDiaryNumber"] != null)
            {
                Int64? AgentID_ID = Convert.ToInt64(Session["zapAgentID"]);
                AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            int? BusinessPlace_AddressSubDivisionCode = 0;
            int? IsDraftMemberCode = 1;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.AgentOtherIndProfile = sdb.Display_AuthDesk_AgentOtherThanIndDetail(AgentID);
            foreach (var item in aa.AgentOtherIndProfile)
            {

                statecode = item.RegOffice_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.RegOffice_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                BusinessPlace_AddressSubDivisionCode = (String.IsNullOrEmpty(item.B_Column) ? 0 : Convert.ToInt32(item.B_Column));
                aa.BusinessPlace_AddressSubDivision = objdis.SubDivision_Name(BusinessPlace_AddressSubDivisionCode);

                aa.Agent_ID = item.Agent_ID;
                aa.Agent_Type = item.Agent_Type;
                aa.IsActive = item.IsActive;                
                aa.IsDraft = item.IsDraft;                

                aa.IsDraftAgentProfile = item.IsDraft;
            }

            aa.Agent_OtherMember = sdb.Display_AuthDesk_AgentOthermemberDetail(AgentID);
            for (var i = 0; i < aa.Agent_OtherMember.Count; i++)
            {
                DistrictCode = aa.Agent_OtherMember[i].OfficeComm_AddressDistrictCode;
                aa.Agent_OtherMember[i].OfficeComm_AddressDistName = objdis.District_Name(DistrictCode);

                statecode = aa.Agent_OtherMember[i].OfficeComm_AddressStateCode;
                aa.Agent_OtherMember[i].OfficeComm_AddressStateName = objdis.State_Name(statecode);

                IsDraftMemberCode = aa.Agent_OtherMember[i].IsDraft;
            }
            aa.IsDraftAgentOtherMember = Convert.ToInt32(IsDraftMemberCode);

            if (Session["zapAgentDiaryNumber"] != null)
            {
                string AgentDiaryNumber = Session["zapAgentDiaryNumber"].ToString();
                string AgentName = Session["zapAgentName"].ToString();
                Int64? Agent_ID = Convert.ToInt64(Session["zapAgentID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zapLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (Agent_ID != null) ? Convert.ToInt64(Agent_ID) : 0;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(AgentDiaryNumber) ? "" : AgentDiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(AgentName) ? "" : AgentName);
                aa.zapAgentLastModifiedOn = LastModifiedOn;
            }

            return View("Display_AgentOtherIndProfile", aa);
        }

        //Lock-Unlock Handler (Agent-OTI Profile Details)             
        public JsonResult LockUnlockHandler_Agent_ProfileRegistration(string parmAgentId, string parmAgentTypeId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;                
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Agent-OTI Profile detail";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_AgentInd_OtherInd_Profile sdb = new ClsMethod_View_AgentInd_OtherInd_Profile();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_OtherThanIndDetail(AgentCode, AgentTypeCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked agent profile details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked agent profile details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }

        //Lock-Unlock Handler (OTI Other-Member Details)
        public JsonResult LockUnlockHandler_Agent_OtherMember(string parmAgentId, string parmAgentTypeId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;                
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Agent (OTI) Other Member detail";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_AgentInd_OtherInd_Profile sdb = new ClsMethod_View_AgentInd_OtherInd_Profile();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_Agent_OtherMemberDetail(AgentCode, AgentTypeCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked other organization member(s) details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked other organization member(s) details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
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

        //Agent Revocation/Cancellation -- Start
        #region Agent Revoke List
        [HttpGet]
        public ActionResult AgentRevokeInfoDeskNewApplication()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsNewApplication(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDeskNewApplication", aa);
        }

        [HttpGet]
        public ActionResult AgentRevokeInfoDesk()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetails(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDesk", aa);
        }

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskNewReSubmitted()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsNewReSubmittedApplication(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDeskNewReSubmitted", aa);
        }

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskReviewCL()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsReviewCL(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDeskReviewCL", aa);
        }

        //[HttpGet]
        //public ActionResult AgentRevokeInfoDeskApprovedRevoke()
        //{
        //    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedRevoke(userRole);

        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //        //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
        //        //aaXlsInner.Application_Date = item.CreatedOn;
        //        //aaXlsInner.Project_Name = item.Project_Name;
        //        //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
        //        //aaXlsInner.Promoter_Name = item.Promoter_Name;
        //        //aaXlsInner.Status = item.EventAction_Aggregate;
        //        //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

        //    return View("AgentRevokeInfoDeskApprovedRevoke", aa);
        //}

        #region AgentRevokeInfoDeskApprovedRevoke BY DATE

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskApprovedRevoke()
        {
            return BindAgentRevokeInfoDeskApprovedRevoke(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRevokeInfoDeskApprovedRevoke(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentRevokeInfoDeskApprovedRevoke(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentRevokeInfoDeskApprovedRevoke(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedRevoke(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedRevokeByDate(approvalyear, filterType, fromDate, toDate, userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentRevokeInfoDeskApprovedRevoke", aa);
        }

        #endregion

        //[HttpGet]
        //public ActionResult AgentRevokeInfoDeskApprovedSuspension()
        //{
        //    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedSuspension(userRole);

        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //        //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
        //        //aaXlsInner.Application_Date = item.CreatedOn;
        //        //aaXlsInner.Project_Name = item.Project_Name;
        //        //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
        //        //aaXlsInner.Promoter_Name = item.Promoter_Name;
        //        //aaXlsInner.Status = item.EventAction_Aggregate;
        //        //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

        //    return View("AgentRevokeInfoDeskApprovedSuspension", aa);
        //}

        #region AgentRevokeInfoDeskApprovedSuspension BY DATE

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskApprovedSuspension()
        {
            return BindAgentRevokeInfoDeskApprovedSuspension(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRevokeInfoDeskApprovedSuspension(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentRevokeInfoDeskApprovedSuspension(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentRevokeInfoDeskApprovedSuspension(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedSuspension(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedSuspensionByDate(approvalyear, filterType, fromDate, toDate, userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentRevokeInfoDeskApprovedSuspension", aa);
        }

        #endregion

        //[HttpGet]
        //public ActionResult AgentRevokeInfoDeskApprovedWithdrawn()
        //{
        //    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedWithdrawn(userRole);

        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //        //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
        //        //aaXlsInner.Application_Date = item.CreatedOn;
        //        //aaXlsInner.Project_Name = item.Project_Name;
        //        //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
        //        //aaXlsInner.Promoter_Name = item.Promoter_Name;
        //        //aaXlsInner.Status = item.EventAction_Aggregate;
        //        //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

        //    return View("AgentRevokeInfoDeskApprovedWithdrawn", aa);
        //}

        #region AgentRevokeInfoDeskApprovedWithdrawn BY DATE

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskApprovedWithdrawn()
        {
            return BindAgentRevokeInfoDeskApprovedWithdrawn(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRevokeInfoDeskApprovedWithdrawn(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentRevokeInfoDeskApprovedWithdrawn(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentRevokeInfoDeskApprovedWithdrawn(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedWithdrawn(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsApprovedWithdrawnByDate(approvalyear, filterType, fromDate, toDate, userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;


            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentRevokeInfoDeskApprovedWithdrawn", aa);
        }

        #endregion


        [HttpGet]
        public ActionResult AgentRevokeInfoDeskRejected()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsRejected(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDeskRejected", aa);
        }

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskWithdrawn()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsWithdrawn(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDeskWithdrawn", aa);
        }

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskIssueRevCancellation()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewIssueRevoke(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("AgentRevokeInfoDeskIssueRevCancellation", aa);
        }


        //[HttpGet]
        //public ActionResult AgentRevokeInfoDeskPublicViewRevCancellation()
        //{
        //    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewRevoke(userRole);

        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //        //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
        //        //aaXlsInner.Application_Date = item.CreatedOn;
        //        //aaXlsInner.Project_Name = item.Project_Name;
        //        //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
        //        //aaXlsInner.Promoter_Name = item.Promoter_Name;
        //        //aaXlsInner.Status = item.EventAction_Aggregate;
        //        //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

        //    return View("AgentRevokeInfoDeskPublicViewRevCancellation", aa);
        //}

        #region AgentRevokeInfoDeskPublicViewRevCancellation BY DATE

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskPublicViewRevCancellation()
        {
            return BindAgentRevokeInfoDeskPublicViewRevCancellation(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRevokeInfoDeskPublicViewRevCancellation(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentRevokeInfoDeskPublicViewRevCancellation(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentRevokeInfoDeskPublicViewRevCancellation(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewRevoke(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewRevokeByDate(approvalyear, filterType, fromDate, toDate, userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentRevokeInfoDeskPublicViewRevCancellation", aa);
        }

        #endregion

        //[HttpGet]
        //public ActionResult AgentRevokeInfoDeskPublicViewRevSuspended()
        //{
        //    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewSuspended(userRole);

        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //        //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
        //        //aaXlsInner.Application_Date = item.CreatedOn;
        //        //aaXlsInner.Project_Name = item.Project_Name;
        //        //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
        //        //aaXlsInner.Promoter_Name = item.Promoter_Name;
        //        //aaXlsInner.Status = item.EventAction_Aggregate;
        //        //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

        //    return View("AgentRevokeInfoDeskPublicViewRevSuspended", aa);
        //}

        #region AgentRevokeInfoDeskPublicViewRevSuspended BY DATE

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskPublicViewRevSuspended()
        {
            return BindAgentRevokeInfoDeskPublicViewRevSuspended(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRevokeInfoDeskPublicViewRevSuspended(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentRevokeInfoDeskPublicViewRevSuspended(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentRevokeInfoDeskPublicViewRevSuspended(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewSuspended(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewSuspendedByDate(approvalyear, filterType, fromDate, toDate, userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;


            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentRevokeInfoDeskPublicViewRevSuspended", aa);
        }

        #endregion

        //[HttpGet]
        //public ActionResult AgentRevokeInfoDeskPublicViewRevWithdrawn()
        //{
        //    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
        //    ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewWithdrawn(userRole);

        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

        //        //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
        //        //aaXlsInner.Application_Date = item.CreatedOn;
        //        //aaXlsInner.Project_Name = item.Project_Name;
        //        //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
        //        //aaXlsInner.Promoter_Name = item.Promoter_Name;
        //        //aaXlsInner.Status = item.EventAction_Aggregate;
        //        //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

        //    return View("AgentRevokeInfoDeskPublicViewRevWithdrawn", aa);
        //}

        #region AgentRevokeInfoDeskPublicViewRevWithdrawn BY DATE

        [HttpGet]
        public ActionResult AgentRevokeInfoDeskPublicViewRevWithdrawn()
        {
            return BindAgentRevokeInfoDeskPublicViewRevWithdrawn(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRevokeInfoDeskPublicViewRevWithdrawn(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindAgentRevokeInfoDeskPublicViewRevWithdrawn(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindAgentRevokeInfoDeskPublicViewRevWithdrawn(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewWithdrawn(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewWithdrawnByDate(approvalyear, filterType, fromDate, toDate, userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;


            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("AgentRevokeInfoDeskPublicViewRevWithdrawn", aa);
        }

        #endregion


        #endregion

        #region Agent Revoke Event History
        [HttpGet]
        public ActionResult AgentRevokeInfoEventLog(Int64 agentId, Int64 renewalagentId, string agentdno)
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog();
            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeEventLogDetails(agentId, renewalagentId, agentdno, userRole);

            return View("AgentRevokeInfoEventLog", aa);
        }
        #endregion

        #region Agent Revoke Event
        [HttpGet]
        public ActionResult AgentRevokeInfoEventInsert()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog();

            string userRole = string.Empty;
            userRole = getUserRole();
            //to bind subCheckList master
            aa.EventMaster = sdb.Display_AuthorityDesk_AgentRevokeEvent_Master(userRole);

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                aa.Related_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                aa.Related_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                aa.Revoke_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                aa.Agent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                aa.AgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                aa.AgentLastModifiedOn = RevokeAgentLastModifiedOn;
                aa.AgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
            }
            else
            {
                aa.Related_Agent_ID = 0;
                aa.Related_RenewalAgent_ID = 0;
                aa.Revoke_DiaryNumber = string.Empty;
                aa.Agent_DiaryNumber = string.Empty;
                aa.AgentName = string.Empty;
                aa.AgentLastModifiedOn = DateTime.Now;
                aa.AgentRegistrationNumberName = string.Empty;
            }

            TempData["RevokeAgentEventSubmitMessage"] = "";
            TempData["Agentsubmitvalue"] = "Submit"; TempData.Keep();

            return View("AgentRevokeInfoEventInsert", aa);
        }

        [HttpGet]        
        public ActionResult AgentRevokeInfoEventInsertAction(string ADNumber, string RevDNumber, string RevAName, Int64? RevAID, DateTime? RevLMO, Int64? RevRenAID, string RevARefNumber)
        {
            Session["zipRevokeRevokeDiaryNumber"] = (String.IsNullOrEmpty(RevDNumber) ? "" : RevDNumber);
            Session["zipRevokeAgentDiaryNumber"] = (String.IsNullOrEmpty(ADNumber) ? "" : ADNumber);
            Session["zipRevokeAgentName"] = (String.IsNullOrEmpty(RevAName) ? "" : RevAName);
            Session["zipRevokeAgentID"] = (RevAID != null) ? Convert.ToInt64(RevAID) : 0;
            Session["zipRevokeAgentLastModifiedOn"] = RevLMO;
            Session["zipRevokeRenewalAgentID"] = (RevRenAID != null) ? Convert.ToInt64(RevRenAID) : 0;
            Session["zipRevokeAgentRegistrationNumber"] = (String.IsNullOrEmpty(RevARefNumber) ? "" : RevARefNumber);

            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog();

            string userRole = string.Empty;
            userRole = getUserRole();
            //to bind subCheckList master
            aa.EventMaster = sdb.Display_AuthorityDesk_AgentRevokeEvent_Master(userRole);

            aa.Related_Agent_ID = (RevAID != null) ? Convert.ToInt64(RevAID) : 0;
            aa.Related_RenewalAgent_ID = (RevRenAID != null) ? Convert.ToInt64(RevRenAID) : 0;
            aa.Revoke_DiaryNumber = (String.IsNullOrEmpty(RevDNumber) ? "" : RevDNumber);
            aa.Agent_DiaryNumber = (String.IsNullOrEmpty(ADNumber) ? "" : ADNumber);
            aa.AgentName = (String.IsNullOrEmpty(RevAName) ? "" : RevAName);
            aa.AgentLastModifiedOn = RevLMO;
            aa.AgentRegistrationNumberName = (String.IsNullOrEmpty(RevARefNumber) ? "" : RevARefNumber);            

            TempData["RevokeAgentEventSubmitMessage"] = "";
            return View("AgentRevokeInfoEventInsert", aa);
        }

        [HttpPost]
        public ActionResult AgentRevokeInfoEventInsert(ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog smodel)
        {
            ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog();
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;

                    if (sdb.Add_AgentRevocationCancellation_InfoEvent(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();

                        TempData["RevokeAgentEventSubmitMessage"] = "Application Performa successfully Submitted.";
                        TempData["RevokeAgentEventSubmitMessageMappingUrlFlag"] = getMappingUrlByAgentRevokeEvent();
                    }

                    //to bind subCheckList master
                    aa.EventMaster = sdb.Display_AuthorityDesk_AgentRevokeEvent_Master(pUserRole);

                    if (Session["zipRevokeRevokeDiaryNumber"] != null)
                    {
                        string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                        string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                        string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                        Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                        DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                        Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                        string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                        aa.Related_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                        aa.Related_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                        aa.Revoke_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                        aa.Agent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                        aa.AgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                        aa.AgentLastModifiedOn = RevokeAgentLastModifiedOn;
                        aa.AgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
                    }
                    else
                    {
                        aa.Related_Agent_ID = 0;
                        aa.Related_RenewalAgent_ID = 0;
                        aa.Revoke_DiaryNumber = string.Empty;
                        aa.Agent_DiaryNumber = string.Empty;
                        aa.AgentName = string.Empty;
                        aa.AgentLastModifiedOn = DateTime.Now;
                        aa.AgentRegistrationNumberName = string.Empty;
                    }
                }
                return View("AgentRevokeInfoEventInsert", aa);
            }
            catch (Exception ex)
            {
                string strret = ex.ToString();
                TempData["RevokeAgentEventSubmitMessage"] = "Sorry, Application Performa is pending";
                TempData["RevokeAgentEventSubmitMessageMappingUrlFlag"] = getMappingUrlByAgentRevokeEvent();

                return View("AgentRevokeInfoEventInsert", aa);
            }
        }

        public JsonResult GetAgentRevokeEventDescriptionMasterByCode(string EventCode)
        {
            int Id = 0;
            if (EventCode != "")
                Id = Convert.ToInt32(EventCode);

            ClsMethod_View_RevocationCancellationAgentHelpdesk objCode = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            var EventCodeDiv = objCode.Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Id);

            return Json(EventCodeDiv);
        }

        private string getMappingUrlByAgentRevokeEvent()
        {
            string vret = string.Empty;
            string pUserRole = string.Empty;
            string pUser_WhoIdentified = string.Empty;

            pUser_WhoIdentified = User.Identity.Name;
            pUserRole = getUserRole();

            vret = "ResetFlag";

            // Chairperson OR membersg OR memberjsk
            if (pUser_WhoIdentified == "chairperson" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDeskReviewCL";
            }
            if (pUser_WhoIdentified == "membersg" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDeskReviewCL";
            }
            if (pUser_WhoIdentified == "memberjsk" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDeskReviewCL";
            }

            // Secrett RERA
            if (pUser_WhoIdentified == "secyrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDeskReviewCL";
            }
            if (pUser_WhoIdentified == "consultantrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDesk";
            }
            if (pUser_WhoIdentified == "mngradminrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDesk";
            }


            // ReraDesk
            if (pUserRole == "7b9d725a-b33c-4aba-934a-bee1ec13f684")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDesk";
            }

            // System Analysist
            if (pUserRole == "e583ee7f-aaa3-49bd-afc8-79c877afe591")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDeskIssueRevCancellation";
            }

            // System Counseltent
            if (pUser_WhoIdentified == "pbreraconsultant" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDesk";
            }
            if (pUser_WhoIdentified == "secttrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/AgentRevokeInfoDesk";
            }
            return vret;
        }
        #endregion

        #region View Agent Registration Details
        [HttpGet]
        public ActionResult Display_RevokeLDRnumberRegisteredAgentDetails()
        {
            ClsMethod_View_LDRnumberRegisteredAgentDetails sdb = new ClsMethod_View_LDRnumberRegisteredAgentDetails();
            ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber aa = new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            string userWhoIdentified = string.Empty;
            Int64 inAgentID = 0;
            Int64 inRenewalAgentID = 0;
            string inRERAnumber = string.Empty;
            string inRevADNumber = string.Empty;
            userRole = getUserRole();
            userWhoIdentified = User.Identity.Name;

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string getRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                Int64? getRevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                Int64? getRevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string getRevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                inRevADNumber = (String.IsNullOrEmpty(getRevokeDiaryNumber) ? "" : getRevokeDiaryNumber);
                inAgentID = (getRevokeAgentID != null) ? Convert.ToInt64(getRevokeAgentID) : 0;
                inRenewalAgentID = (getRevokeRenewalAgentID != null) ? Convert.ToInt64(getRevokeRenewalAgentID) : 0;
                inRERAnumber = (String.IsNullOrEmpty(getRevokeAgentRegistrationNumber) ? "" : getRevokeAgentRegistrationNumber);
            }         
            aa.prpongoing = sdb.Display_Agent_RegisteredAgenttDetails_ByID(inAgentID, inRenewalAgentID, inRERAnumber, userWhoIdentified, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.Agent_RERAnumber_DiaryNumber_IndexID = item.Agent_RERAnumber_DiaryNumber_IndexID;
                aa.Agent_RERAnumber_DiaryNumber_ID = item.Agent_RERAnumber_DiaryNumber_ID;
                aa.AgentRegDiaryNumber_Name = item.AgentRegDiaryNumber_Name;
                aa.AgentRegDiaryNumber_NameYear = item.AgentRegDiaryNumber_NameYear;
                aa.Agent_ID = item.Agent_ID;
                aa.UserID = item.UserID;
                aa.OtherMemDetailsCount = item.OtherMemDetailsCount;
                aa.DocumentuploadsCount = item.DocumentuploadsCount;
                aa.UTotherStateRERACount = item.UTotherStateRERACount;
                aa.PaymentsCount = item.PaymentsCount;
                aa.AgentDocumentCount = item.AgentDocumentCount;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
                aa.tbl_RegDiaryNumber_indexID = item.tbl_RegDiaryNumber_indexID;

                aa.Project_ID = item.Project_ID;
                aa.Project_Name = item.Project_Name;
                aa.Promoter_ID = item.Promoter_ID;
                aa.Promoter_Name = item.Promoter_Name;
                aa.IsAlreadyRegistration = item.IsAlreadyRegistration;
                aa.ExistingRegistration = item.ExistingRegistration;
                aa.Agent_Type = item.Agent_Type;
                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_MiddleName = item.Agent_MiddleName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Organization_Name = item.Organization_Name;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.EmailAddress = item.EmailAddress;
                aa.MobileNumber = item.MobileNumber;

                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aa.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.Agent_Name = item.Agent_Name;
                aa.Agent_AddressDistrictName = objdis.District_Name(Convert.ToInt32(item.Agent_AddressDistrictName));
                aa.Agent_RERAregistrationNumber = item.Agent_RERAregistrationNumber;                
            }

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                aa.zipRelated_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                aa.zipRelated_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                aa.zipRevocationCancellation_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                aa.zipAgent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                aa.zipAgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                aa.zipAgentLastModifiedOn = RevokeAgentLastModifiedOn;
                aa.zipAgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
            }
            else
            {
                aa.zipRelated_Agent_ID = 0;
                aa.zipRelated_RenewalAgent_ID = 0;
                aa.zipRevocationCancellation_DiaryNumber = string.Empty;
                aa.zipAgent_DiaryNumber = string.Empty;
                aa.zipAgentName = string.Empty;
                aa.zipAgentLastModifiedOn = DateTime.Now;
                aa.zipAgentRegistrationNumberName = string.Empty;
            }
            return View("Display_RevokeLDRnumberRegisteredAgentDetails", aa);
        }

        [HttpGet]
        public ActionResult Display_RevokeLDRnumberLatestRenewalAgentDetails()
        {
            ClsMethod_View_LDRnumberRegisteredAgentDetails sdb = new ClsMethod_View_LDRnumberRegisteredAgentDetails();
            ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber aa = new ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            string userWhoIdentified = string.Empty;
            Int64 inAgentID = 0;
            Int64 inRenewalAgentID = 0;
            string inRERAnumber = string.Empty;
            string inRevADNumber = string.Empty;
            userRole = getUserRole();
            userWhoIdentified = User.Identity.Name;

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string getRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                Int64? getRevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                Int64? getRevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string getRevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                inRevADNumber = (String.IsNullOrEmpty(getRevokeDiaryNumber) ? "" : getRevokeDiaryNumber);
                inAgentID = (getRevokeAgentID != null) ? Convert.ToInt64(getRevokeAgentID) : 0;
                inRenewalAgentID = (getRevokeRenewalAgentID != null) ? Convert.ToInt64(getRevokeRenewalAgentID) : 0;
                inRERAnumber = (String.IsNullOrEmpty(getRevokeAgentRegistrationNumber) ? "" : getRevokeAgentRegistrationNumber);
            }
            aa.prpongoing = sdb.Display_Agent_RenewalRegisteredAgent_ByID(inAgentID, inRenewalAgentID, inRERAnumber, userWhoIdentified, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.AgentRegRenewal_DiaryNumber_IndexID = item.AgentRegRenewal_DiaryNumber_IndexID;
                aa.AgentRegRenewal_DiaryNumber_ID = item.AgentRegRenewal_DiaryNumber_ID;
                aa.RelatedAgent_ID = item.RelatedAgent_ID;
                aa.RelatedRenewalAgent_ID = item.RelatedRenewalAgent_ID;
                aa.RelatedRenewalAgent_Year = item.RelatedRenewalAgent_Year;
                aa.RenewalOrderSequence = item.RenewalOrderSequence;
                aa.RelatedAgentDiaryNumber_ID = item.RelatedAgentDiaryNumber_ID;
                aa.RelatedAgentDiaryNumber_Name = item.RelatedAgentDiaryNumber_Name;
                aa.RelatedAgentDiaryNumber_NameYear = item.RelatedAgentDiaryNumber_NameYear;
                aa.RelatedRenewalAgentRegDiaryNumber_ID = item.RelatedRenewalAgentRegDiaryNumber_ID;
                aa.RelatedRenewalAgentRegDiaryNumber_Name = item.RelatedRenewalAgentRegDiaryNumber_Name;
                aa.RelatedRenewalAgentRegDiaryNumber_NameYear = item.RelatedRenewalAgentRegDiaryNumber_NameYear;
                aa.UserID = item.UserID;
                aa.OtherMemDetailsCount = item.OtherMemDetailsCount;
                aa.DocumentuploadsCount = item.DocumentuploadsCount;
                aa.UTotherStateRERACount = item.UTotherStateRERACount;
                aa.PaymentsCount = item.PaymentsCount;
                aa.AgentDocumentCount = item.AgentDocumentCount;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
                aa.tbl_RegDiaryNumber_indexID = item.tbl_RegDiaryNumber_indexID;
                aa.ReferenceProject_ID = item.ReferenceProject_ID;
                aa.ReferenceProject_Name = item.ReferenceProject_Name;
                aa.ReferencePromoter_ID = item.ReferencePromoter_ID;
                aa.ReferencePromoter_Name = item.ReferencePromoter_Name;
                aa.IsAlreadyRegistration = item.IsAlreadyRegistration;
                aa.ExistingRegistration = item.ExistingRegistration;
                aa.Agent_Type = item.Agent_Type;
                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Organization_Name = item.Organization_Name;
                aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_Address_PIN = item.BComm_Address_PIN;
                aa.EmailAddress = item.EmailAddress;
                aa.MobileNumber = item.MobileNumber;
                aa.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                aa.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;
                aa.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                aa.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                aa.AuthorizedPerson_District = item.AuthorizedPerson_District;
                aa.AuthorizedPerson_State = item.AuthorizedPerson_State;
                aa.AuthorizedPerson_PIN = item.AuthorizedPerson_PIN;
                aa.AuthorizedPerson_Email = item.AuthorizedPerson_Email;
                aa.AuthorizedPerson_Mobile = item.AuthorizedPerson_Mobile;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aa.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aa.RenewalAgentRegistrationNumber = item.RenewalAgentRegistrationNumber;
                aa.RenewalAgentRegistrationIssueDate = item.RenewalAgentRegistrationIssueDate;
                aa.RenewalAgentRegistrationRegUptoDate = item.RenewalAgentRegistrationRegUptoDate;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.Extra1 = item.Extra1;
                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;
                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.IsPublicView = item.IsPublicView;
                aa.IsConditionAnnexureIssued = item.IsConditionAnnexureIssued;
                aa.IsWithdrawn = item.IsWithdrawn;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.Agent_Name = item.Agent_Name;
                aa.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                aa.Agent_RERAregistrationNumber = item.Agent_RERAregistrationNumber;                
            }

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                aa.zipRelated_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                aa.zipRelated_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                aa.zipRevocationCancellation_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                aa.zipAgent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                aa.zipAgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                aa.zipAgentLastModifiedOn = RevokeAgentLastModifiedOn;
                aa.zipAgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
            }
            else
            {
                aa.zipRelated_Agent_ID = 0;
                aa.zipRelated_RenewalAgent_ID = 0;
                aa.zipRevocationCancellation_DiaryNumber = string.Empty;
                aa.zipAgent_DiaryNumber = string.Empty;
                aa.zipAgentName = string.Empty;
                aa.zipAgentLastModifiedOn = DateTime.Now;
                aa.zipAgentRegistrationNumberName = string.Empty;
            }
            return View("Display_RevokeLDRnumberLatestRenewalAgentDetails", aa);
        }

        [HttpGet]
        public ActionResult Display_RevokeLDRnumberRenewalAgentHistoryDetails()
        {
            ClsMethod_View_LDRnumberRegisteredAgentDetails sdb = new ClsMethod_View_LDRnumberRegisteredAgentDetails();
            ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber aa = new ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            string userWhoIdentified = string.Empty;
            Int64 inAgentID = 0;
            Int64 inRenewalAgentID = 0;
            string inRERAnumber = string.Empty;
            string inRevADNumber = string.Empty;
            userRole = getUserRole();
            userWhoIdentified = User.Identity.Name;

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string getRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                Int64? getRevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                Int64? getRevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string getRevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                inRevADNumber = (String.IsNullOrEmpty(getRevokeDiaryNumber) ? "" : getRevokeDiaryNumber);
                inAgentID = (getRevokeAgentID != null) ? Convert.ToInt64(getRevokeAgentID) : 0;
                inRenewalAgentID = (getRevokeRenewalAgentID != null) ? Convert.ToInt64(getRevokeRenewalAgentID) : 0;
                inRERAnumber = (String.IsNullOrEmpty(getRevokeAgentRegistrationNumber) ? "" : getRevokeAgentRegistrationNumber);
            }
            aa.prpongoing = sdb.Display_Agent_RenewalHistoryRegisteredAgent_ByID(inAgentID, inRenewalAgentID, inRERAnumber, userWhoIdentified, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.AgentRegRenewal_DiaryNumber_IndexID = item.AgentRegRenewal_DiaryNumber_IndexID;
                aa.AgentRegRenewal_DiaryNumber_ID = item.AgentRegRenewal_DiaryNumber_ID;
                aa.RelatedAgent_ID = item.RelatedAgent_ID;
                aa.RelatedRenewalAgent_ID = item.RelatedRenewalAgent_ID;
                aa.RelatedRenewalAgent_Year = item.RelatedRenewalAgent_Year;
                aa.RenewalOrderSequence = item.RenewalOrderSequence;
                aa.RelatedAgentDiaryNumber_ID = item.RelatedAgentDiaryNumber_ID;
                aa.RelatedAgentDiaryNumber_Name = item.RelatedAgentDiaryNumber_Name;
                aa.RelatedAgentDiaryNumber_NameYear = item.RelatedAgentDiaryNumber_NameYear;
                aa.RelatedRenewalAgentRegDiaryNumber_ID = item.RelatedRenewalAgentRegDiaryNumber_ID;
                aa.RelatedRenewalAgentRegDiaryNumber_Name = item.RelatedRenewalAgentRegDiaryNumber_Name;
                aa.RelatedRenewalAgentRegDiaryNumber_NameYear = item.RelatedRenewalAgentRegDiaryNumber_NameYear;
                aa.UserID = item.UserID;
                aa.OtherMemDetailsCount = item.OtherMemDetailsCount;
                aa.DocumentuploadsCount = item.DocumentuploadsCount;
                aa.UTotherStateRERACount = item.UTotherStateRERACount;
                aa.PaymentsCount = item.PaymentsCount;
                aa.AgentDocumentCount = item.AgentDocumentCount;
                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
                aa.tbl_RegDiaryNumber_indexID = item.tbl_RegDiaryNumber_indexID;
                aa.ReferenceProject_ID = item.ReferenceProject_ID;
                aa.ReferenceProject_Name = item.ReferenceProject_Name;
                aa.ReferencePromoter_ID = item.ReferencePromoter_ID;
                aa.ReferencePromoter_Name = item.ReferencePromoter_Name;
                aa.IsAlreadyRegistration = item.IsAlreadyRegistration;
                aa.ExistingRegistration = item.ExistingRegistration;
                aa.Agent_Type = item.Agent_Type;
                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Organization_Name = item.Organization_Name;
                aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_Address_PIN = item.BComm_Address_PIN;
                aa.EmailAddress = item.EmailAddress;
                aa.MobileNumber = item.MobileNumber;
                aa.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                aa.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;
                aa.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                aa.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                aa.AuthorizedPerson_District = item.AuthorizedPerson_District;
                aa.AuthorizedPerson_State = item.AuthorizedPerson_State;
                aa.AuthorizedPerson_PIN = item.AuthorizedPerson_PIN;
                aa.AuthorizedPerson_Email = item.AuthorizedPerson_Email;
                aa.AuthorizedPerson_Mobile = item.AuthorizedPerson_Mobile;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aa.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aa.RenewalAgentRegistrationNumber = item.RenewalAgentRegistrationNumber;
                aa.RenewalAgentRegistrationIssueDate = item.RenewalAgentRegistrationIssueDate;
                aa.RenewalAgentRegistrationRegUptoDate = item.RenewalAgentRegistrationRegUptoDate;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.Extra1 = item.Extra1;
                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;
                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.IsPublicView = item.IsPublicView;
                aa.IsConditionAnnexureIssued = item.IsConditionAnnexureIssued;
                aa.IsWithdrawn = item.IsWithdrawn;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.Agent_Name = item.Agent_Name;
                aa.Agent_AddressDistrictName = item.Agent_AddressDistrictName;
                aa.Agent_RERAregistrationNumber = item.Agent_RERAregistrationNumber;
            }

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                aa.zipRelated_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                aa.zipRelated_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                aa.zipRevocationCancellation_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                aa.zipAgent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                aa.zipAgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                aa.zipAgentLastModifiedOn = RevokeAgentLastModifiedOn;
                aa.zipAgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
            }
            else
            {
                aa.zipRelated_Agent_ID = 0;
                aa.zipRelated_RenewalAgent_ID = 0;
                aa.zipRevocationCancellation_DiaryNumber = string.Empty;
                aa.zipAgent_DiaryNumber = string.Empty;
                aa.zipAgentName = string.Empty;
                aa.zipAgentLastModifiedOn = DateTime.Now;
                aa.zipAgentRegistrationNumberName = string.Empty;
            }
            return View("Display_RevokeLDRnumberRenewalAgentHistoryDetails", aa);
        }

        [HttpGet]
        public ActionResult Display_RevokeLDRnumberAgentRegistrationDocuments()
        {
            ClsMethod_View_LDRnumberRegisteredAgentDetails sdb = new ClsMethod_View_LDRnumberRegisteredAgentDetails();
            ClsPrp_AuthorityDesk_AgentRERA_Certificate aa = new ClsPrp_AuthorityDesk_AgentRERA_Certificate();

            string userRole = string.Empty;
            string userWhoIdentified = string.Empty;
            Int64 inAgentID = 0;
            Int64 inRenewalAgentID = 0;
            string inRERAnumber = string.Empty;
            string inRevADNumber = string.Empty;
            userRole = getUserRole();
            userWhoIdentified = User.Identity.Name;

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string getRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                Int64? getRevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                Int64? getRevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string getRevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                inRevADNumber = (String.IsNullOrEmpty(getRevokeDiaryNumber) ? "" : getRevokeDiaryNumber);
                inAgentID = (getRevokeAgentID != null) ? Convert.ToInt64(getRevokeAgentID) : 0;
                inRenewalAgentID = (getRevokeRenewalAgentID != null) ? Convert.ToInt64(getRevokeRenewalAgentID) : 0;
                inRERAnumber = (String.IsNullOrEmpty(getRevokeAgentRegistrationNumber) ? "" : getRevokeAgentRegistrationNumber);
            }
            aa.prpongoing = sdb.Display_Agent_RegisteredAgentCertificateDocuments_ByID(inAgentID, inRenewalAgentID, inRERAnumber, userWhoIdentified, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.Agent_ID = item.Agent_ID;                

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
            }

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                aa.zipRelated_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                aa.zipRelated_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                aa.zipRevocationCancellation_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                aa.zipAgent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                aa.zipAgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                aa.zipAgentLastModifiedOn = RevokeAgentLastModifiedOn;
                aa.zipAgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
            }
            else
            {
                aa.zipRelated_Agent_ID = 0;
                aa.zipRelated_RenewalAgent_ID = 0;
                aa.zipRevocationCancellation_DiaryNumber = string.Empty;
                aa.zipAgent_DiaryNumber = string.Empty;
                aa.zipAgentName = string.Empty;
                aa.zipAgentLastModifiedOn = DateTime.Now;
                aa.zipAgentRegistrationNumberName = string.Empty;
            }
            return View("Display_RevokeLDRnumberAgentRegistrationDocuments", aa);
        }
        #endregion

        #region View Agent Revoke Record Details
        [HttpGet]
        public ActionResult Display_RevocationCancellationRegisteredAgentDetails()
        {
            ClsMethod_View_RevocationCancellationAgentRecordDetails sdb = new ClsMethod_View_RevocationCancellationAgentRecordDetails();
            ClsPrp_ControlPanel_View_AgentRevocationCancellation aa = new ClsPrp_ControlPanel_View_AgentRevocationCancellation();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            string userWhoIdentified = string.Empty;
            Int64 inAgentID = 0;
            Int64 inRenewalAgentID = 0;
            string inRERAnumber = string.Empty;
            string inRevADNumber = string.Empty;
            userRole = getUserRole();
            userWhoIdentified = User.Identity.Name;            

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string getRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                Int64? getRevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);                
                Int64? getRevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string getRevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                inRevADNumber = (String.IsNullOrEmpty(getRevokeDiaryNumber) ? "" : getRevokeDiaryNumber);
                inAgentID = (getRevokeAgentID != null) ? Convert.ToInt64(getRevokeAgentID) : 0;
                inRenewalAgentID = (getRevokeRenewalAgentID != null) ? Convert.ToInt64(getRevokeRenewalAgentID) : 0;
                inRERAnumber = (String.IsNullOrEmpty(getRevokeAgentRegistrationNumber) ? "" : getRevokeAgentRegistrationNumber);
            }
            aa.prpongoing = sdb.Display_Agent_RevocationCancellationRecordDetails_ByID(inAgentID, inRenewalAgentID, inRERAnumber, inRevADNumber, userWhoIdentified, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.RevokeAgent_RegDiaryNumber_IndexID = item.RevokeAgent_RegDiaryNumber_IndexID;
                aa.RevokeAgent_RegDiaryNumber_ID = item.RevokeAgent_RegDiaryNumber_ID;
                aa.RevokeAgent_RegDiaryNumber_Name = item.RevokeAgent_RegDiaryNumber_Name;
                aa.RevokeAgent_RegDiaryNumber_NameYear = item.RevokeAgent_RegDiaryNumber_NameYear;
                aa.UserID = item.UserID;
                aa.Agent_ID = item.Agent_ID;
                aa.Agent_Type = item.Agent_Type;
                aa.AgentRegDiaryNumber_Name = item.AgentRegDiaryNumber_Name;
                aa.LatestAgentRenewalRegDiaryNumber_Name = item.LatestAgentRenewalRegDiaryNumber_Name;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aa.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aa.IsRenewalRegistration = item.IsRenewalRegistration;
                aa.RenewalAgent_ID = item.RenewalAgent_ID;
                aa.RenewalAgent_Year = item.RenewalAgent_Year;
                aa.LatestRenewalRegistrationNumber = item.LatestRenewalRegistrationNumber;
                aa.LatestRenewalRegistrationIssueDate = item.LatestRenewalRegistrationIssueDate;
                aa.LatestRenewalRegistrationUptoDate = item.LatestRenewalRegistrationUptoDate;
                aa.AgentName = item.AgentName;
                aa.OrganizationName = item.OrganizationName;
                aa.AuthorizedPersonName = item.AuthorizedPersonName;
                aa.AgentRegisteredDistrict = objdis.District_Name(Convert.ToInt32(item.AgentRegisteredDistrict));
                aa.AgentBussinessPlaceDistrict = objdis.District_Name(Convert.ToInt32(item.AgentBussinessPlaceDistrict));
                aa.Revoke_InfoDetails = item.Revoke_InfoDetails;
                aa.Revoke_ReferenceName = item.Revoke_ReferenceName;
                aa.Revoke_ReferenceDate = item.Revoke_ReferenceDate;
                aa.Revoke_Category = item.Revoke_Category;
                aa.Revoke_ReciptType = item.Revoke_ReciptType;
                aa.Revoke_Reasons = item.Revoke_Reasons;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.Extra1 = item.Extra1;
                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;                
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
            }

            if (Session["zipRevokeRevokeDiaryNumber"] != null)
            {
                string RevokeRevokeDiaryNumber = Session["zipRevokeRevokeDiaryNumber"].ToString();
                string RevokeAgentDiaryNumber = Session["zipRevokeAgentDiaryNumber"].ToString();
                string RevokeAgentName = Session["zipRevokeAgentName"].ToString();
                Int64? RevokeAgentID = Convert.ToInt64(Session["zipRevokeAgentID"]);
                DateTime? RevokeAgentLastModifiedOn = Convert.ToDateTime(Session["zipRevokeAgentLastModifiedOn"]);
                Int64? RevokeRenewalAgentID = Convert.ToInt64(Session["zipRevokeRenewalAgentID"]);
                string RevokeAgentRegistrationNumber = Session["zipRevokeAgentRegistrationNumber"].ToString();

                aa.zipRelated_Agent_ID = (RevokeAgentID != null) ? Convert.ToInt64(RevokeAgentID) : 0;
                aa.zipRelated_RenewalAgent_ID = (RevokeRenewalAgentID != null) ? Convert.ToInt64(RevokeRenewalAgentID) : 0;
                aa.zipRevocationCancellation_DiaryNumber = (String.IsNullOrEmpty(RevokeRevokeDiaryNumber) ? "" : RevokeRevokeDiaryNumber);
                aa.zipAgent_DiaryNumber = (String.IsNullOrEmpty(RevokeAgentDiaryNumber) ? "" : RevokeAgentDiaryNumber);
                aa.zipAgentName = (String.IsNullOrEmpty(RevokeAgentName) ? "" : RevokeAgentName);
                aa.zipAgentLastModifiedOn = RevokeAgentLastModifiedOn;
                aa.zipAgentRegistrationNumberName = (String.IsNullOrEmpty(RevokeAgentRegistrationNumber) ? "" : RevokeAgentRegistrationNumber);
            }
            else
            {
                aa.zipRelated_Agent_ID = 0;
                aa.zipRelated_RenewalAgent_ID = 0;
                aa.zipRevocationCancellation_DiaryNumber = string.Empty;
                aa.zipAgent_DiaryNumber = string.Empty;
                aa.zipAgentName = string.Empty;
                aa.zipAgentLastModifiedOn = DateTime.Now;
                aa.zipAgentRegistrationNumberName = string.Empty;
            }
            return View("Display_RevocationCancellationRegisteredAgentDetails", aa);
        }
        #endregion
        //Agent Revocation/Cancellation -- End

        //Agent Renewal of Registration -- Start
        #region Agent-Renewal List
        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_NewApplicationList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsNewApplication(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelNewApplicationsforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_NewApplicationList", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_InProcessList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetails(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelInProcessforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_InProcessList", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_ReSubmittedList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsReSubmittedApplication(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelReSubmittedforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_ReSubmittedList", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_ChecklistPreparedList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsChecklistPrepared(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelChecklistPreparedforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_ChecklistPreparedList", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_ReviewList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsReviewChecklist(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelReviewCLforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_ReviewList", aa);
        }

        //[HttpGet]
        //public ActionResult RenewalAgentInfoDesk_ApprovedList()
        //{
        //    ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
        //    ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
        //    ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsApproved(userRole);
        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
        //        aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
        //        aaXlsInner.Application_Date = item.Application_Date;
        //        aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
        //        aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
        //        aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
        //        aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
        //        aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
        //        aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
        //        aaXlsInner.Status = item.EventAction_Aggregate;
        //        aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
        //        aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    Session["modelApprovedforRenewalAgent"] = aaXls.prpongoing;
        //    return View("RenewalAgentInfoDesk_ApprovedList", aa);
        //}


        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_ApprovedList()
        {
            return BindRenewalAgentInfoDesk_ApprovedList(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RenewalAgentInfoDesk_ApprovedList(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindRenewalAgentInfoDesk_ApprovedList(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindRenewalAgentInfoDesk_ApprovedList(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsApproved(userRole);
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsApprovedByDate(approvalyear, filterType, fromDate, toDate, userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelApprovedforRenewalAgent"] = aaXls.prpongoing;
            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("RenewalAgentInfoDesk_ApprovedList", aa);
        }




        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_RejectedList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsRejected(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelRejectedforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_RejectedList", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_WithdrawnList()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsWithdrawn(userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelWithdrawnforRenewalAgent"] = aaXls.prpongoing;
            return View("RenewalAgentInfoDesk_WithdrawnList", aa);
        }

        //[HttpGet]
        //public ActionResult RenewalAgentInfoDesk_RegdNumbersPublicViewList()
        //{
        //    ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
        //    ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
        //    ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

        //    string userRole = string.Empty;
        //    string userKey = string.Empty;
        //    aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicView(userKey, userRole);
        //    foreach (var item in aa.prpongoing)
        //    {
        //        ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
        //        aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
        //        aaXlsInner.Application_Date = item.Application_Date;
        //        aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
        //        aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
        //        aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
        //        aaXlsInner.RERA_Number_IssueDate = item.RERA_Number_IssueDate;
        //        aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERA_Number_RegistrationUptoDate;
        //        aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
        //        aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
        //        aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
        //        aaXlsInner.Status = item.EventAction_Aggregate;
        //        aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
        //        aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
        //        aaXls.prpongoing.Add(aaXlsInner);
        //    }
        //    Session["modelPublicViewforRenewalAgent"] = aaXls.prpongoing;
        //    return View("RenewalAgentInfoDesk_RegdNumbersPublicViewList", aa);
        //}


        [HttpGet]
        public ActionResult RenewalAgentInfoDesk_RegdNumbersPublicViewList()
        {
            return BindRenewalAgentInfoDesk_RegdNumbersPublicViewList(DateTime.Now.Year, null, null, "year", string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RenewalAgentInfoDesk_RegdNumbersPublicViewList(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            return BindRenewalAgentInfoDesk_RegdNumbersPublicViewList(approvalyear, fromDate, toDate, filterType, rangeLabel);
        }

        private ActionResult BindRenewalAgentInfoDesk_RegdNumbersPublicViewList(int approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string rangeLabel)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber();
            ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();

            string userRole = string.Empty;
            string userKey = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicView(userKey, userRole); 
            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicViewByDate(approvalyear, filterType, fromDate, toDate, userKey, userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel();
                aaXlsInner.RealestateAgent_DiaryNumber = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.RERA_Number_IssueDate = item.RERA_Number_IssueDate;
                aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERA_Number_RegistrationUptoDate;
                aaXlsInner.Related_Agent_DiaryNumber = item.Related_Agent_DiaryNumber;
                aaXlsInner.AgentName_OrganizationName = item.RenewalAgent_Name;
                aaXlsInner.PlaceOfBussinessAddress_District = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.Status = item.EventAction_Aggregate;
                aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelPublicViewforRenewalAgent"] = aaXls.prpongoing;
            ViewBag.Years = GetApprovalYears();
            ViewBag.SelectedApprovalYear = approvalyear;
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.SelectedRangeLabel = rangeLabel ?? string.Empty;
            ModelState.Clear();
            return View("RenewalAgentInfoDesk_RegdNumbersPublicViewList", aa);
        }




        #region Export To Excel
        public void NewApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelNewApplicationsforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";            
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofNewApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void InProcessApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelInProcessforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofInProcessApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ReSubmittedApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelReSubmittedforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofReSubmittedApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ChecklistPreparedApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelChecklistPreparedforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofChecklistApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ReviewApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelReviewCLforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofReviewApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ApprovedApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelApprovedforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofApprovedApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void RejectedApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelRejectedforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofRejectedApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void WithdrawnApplicationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelWithdrawnforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Diary Number";
            workSheet.Cells[1, 4].Value = "Application Date";
            workSheet.Cells[1, 5].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 6].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 7].Value = "Status";
            workSheet.Cells[1, 8].Value = "Status Date";
            workSheet.Cells[1, 9].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = string.Empty;

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

            workSheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 9])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofWithdrawnApplications_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void PublicViewsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelPublicViewforRenewalAgent"] as List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumberToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Valid Upto Date";
            workSheet.Cells[1, 5].Value = "Renewal of Registration Issue Date";
            workSheet.Cells[1, 6].Value = "Renewal of Registration Valid Upto Date";
            workSheet.Cells[1, 7].Value = "Diary Number";
            workSheet.Cells[1, 8].Value = "Application Date";
            workSheet.Cells[1, 9].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 10].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 11].Value = "Status";
            workSheet.Cells[1, 12].Value = "Status Date";
            workSheet.Cells[1, 13].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;                
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Related_LastRegistrationIssueDate.HasValue ? QRcodeItem.Related_LastRegistrationIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Related_LastRegistrationRegUptoDate.HasValue ? QRcodeItem.Related_LastRegistrationRegUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.RERA_Number_IssueDate.HasValue ? (QRcodeItem.RERA_Number_IssueDate.Equals(DateTime.MinValue) ? string.Empty : QRcodeItem.RERA_Number_IssueDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.RERA_Number_RegistrationUptoDate.HasValue ? (QRcodeItem.RERA_Number_RegistrationUptoDate.Equals(DateTime.MinValue) ? string.Empty : QRcodeItem.RERA_Number_RegistrationUptoDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.RealestateAgent_DiaryNumber;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.AgentName_OrganizationName;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.PlaceOfBussinessAddress_District;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.Status;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.Status_Date.HasValue ? QRcodeItem.Status_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = string.Empty;

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

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 13])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofPublicViewAgents_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        [HttpGet]
        public ActionResult RenewalAgent_IO_ApplicationList()
        {
            return View("RenewalAgent_IO_ApplicationList");
        }
        #endregion

        #region Agent-Renewal List : Issue RERA After Approval
        [HttpGet]
        public ActionResult RenewalAgentRegistrationInfoDeskIssueRenewal()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueList aa = new ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueList();
            ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel aaXls = new ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel();

            string userRole = string.Empty;
            string keyID = string.Empty;
            Int32 pageNumber = 1;

            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicView_IssueList(keyID, pageNumber, userRole);
            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel();

                aaXlsInner.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aaXlsInner.Related_LastRegistrationIssueDate = item.Related_LastRegistrationIssueDate;
                aaXlsInner.Related_LastRegistrationRegUptoDate = item.Related_LastRegistrationRegUptoDate;
                aaXlsInner.RERA_Number_IssueDate = item.RERA_Number_IssueDate;
                aaXlsInner.RERA_Number_RegistrationUptoDate = item.RERA_Number_RegistrationUptoDate;
                aaXlsInner.RenewalAgentDiaryNumber_Name = item.RenewalAgentDiaryNumber_Name;
                aaXlsInner.Application_Date = item.Application_Date;
                aaXlsInner.RenewalAgent_Name = item.RenewalAgent_Name;
                aaXlsInner.RenewalAgent_AddressDistrictName = item.RenewalAgent_AddressDistrictName;
                aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelIssueRenewalRegistrationsforProjectMIS"] = aaXls.prpongoing;

            return View("RenewalAgentRegistrationInfoDeskIssueRenewal", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoDeskRegRERAnumberDetails()
        {
            ClsMethod_View_RevocationCancellationAgentHelpdesk sdb = new ClsMethod_View_RevocationCancellationAgentHelpdesk();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber aa = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber();
            ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXls = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

            string userRole = string.Empty;
            //aa.prpongoing = sdb.Display_AuthorityDesk_AgentRevokeDetailsPublicViewIssueRevoke(userRole);

            foreach (var item in aa.prpongoing)
            {
                ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel aaXlsInner = new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumberToExcel();

                //aaXlsInner.Project_DiaryNumber = item.PromoterRegDiaryNumber_Name;
                //aaXlsInner.Application_Date = item.CreatedOn;
                //aaXlsInner.Project_Name = item.Project_Name;
                //aaXlsInner.ProjectAddress_District = item.Project_AddressDistrictName;
                //aaXlsInner.Promoter_Name = item.Promoter_Name;
                //aaXlsInner.Status = item.EventAction_Aggregate;
                //aaXlsInner.Status_Date = item.EventAction_IdentifiedOn;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            //Session["modelInProcessApplicationsforProjectMIS"] = aaXls.prpongoing;

            return View("RenewalAgentInfoDeskRegRERAnumberDetails", aa);
        }

        #region Export To Excel

        public void IssueRegistrationsforRenewalAgent_ExportToExcel()
        {
            var objXlslist = Session["modelIssueRenewalRegistrationsforProjectMIS"] as List<ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel>;

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
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Valid Upto Date";
            workSheet.Cells[1, 5].Value = "Renewal of Registration Issue Date";
            workSheet.Cells[1, 6].Value = "Renewal of Registration Valid Upto Date";
            workSheet.Cells[1, 7].Value = "Diary Number";
            workSheet.Cells[1, 8].Value = "Application Date";
            workSheet.Cells[1, 9].Value = "Real Estate Agent Name";
            workSheet.Cells[1, 10].Value = "Place of Bussiness District Name";
            workSheet.Cells[1, 11].Value = "Status";
            workSheet.Cells[1, 12].Value = "Status Date";
            workSheet.Cells[1, 13].Value = "Remarks, if Any";

            //Body of table  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Related_RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Related_LastRegistrationIssueDate.HasValue ? QRcodeItem.Related_LastRegistrationIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Related_LastRegistrationRegUptoDate.HasValue ? QRcodeItem.Related_LastRegistrationRegUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.RERA_Number_IssueDate.HasValue ? (QRcodeItem.RERA_Number_IssueDate.Equals(DateTime.MinValue) ? string.Empty : QRcodeItem.RERA_Number_IssueDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.RERA_Number_RegistrationUptoDate.HasValue ? (QRcodeItem.RERA_Number_RegistrationUptoDate.Equals(DateTime.MinValue) ? string.Empty : QRcodeItem.RERA_Number_RegistrationUptoDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.RenewalAgentDiaryNumber_Name;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Application_Date.HasValue ? QRcodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.RenewalAgent_Name;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.RenewalAgent_AddressDistrictName;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.EventAction_Aggregate;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.EventAction_IdentifiedOn.HasValue ? QRcodeItem.EventAction_IdentifiedOn.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = string.Empty;

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

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#7bb73f"));

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 13])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofIssueRegistrationsAgents_FormJ_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #endregion

        #region Add or Insert Agent-Renewal RERA Number
        [HttpGet]
        public ActionResult Add_RenewalAgentRERAregistrationNumber()
        {
            ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber();
            ClsMethod_ViewAdd_RenewalAgentRERAnumber sdb = new ClsMethod_ViewAdd_RenewalAgentRERAnumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            string UserNam = string.Empty;
            userRole = getUserRole();
            UserNam = User.Identity.Name;

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthDesk_RenewalAgentRERAnumber_ByIDandDiaryNumber(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgent_RERAnumber_DiaryNumber_IndexID = item.RenewalAgent_RERAnumber_DiaryNumber_IndexID;
                aa.RenewalAgent_RERAnumber_DiaryNumber_ID = item.RenewalAgent_RERAnumber_DiaryNumber_ID;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;

                aa.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                aa.Related_Agent_Type = item.Related_Agent_Type;
                aa.Related_UserID = item.Related_UserID;
                aa.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aa.Related_RERAnumberIssueDate = item.Related_RERAnumberIssueDate;
                aa.Related_RERAnumberRegUptoDate = item.Related_RERAnumberRegUptoDate;

                aa.RelatedAgentDiaryNumber_ID = item.RelatedAgentDiaryNumber_ID;
                aa.RelatedAgentDiaryNumber_Name = item.RelatedAgentDiaryNumber_Name;
                aa.RelatedAgentDiaryNumber_NameYear = item.RelatedAgentDiaryNumber_NameYear;
                aa.RelatedRenewalAgentRegDiaryNumber_ID = item.RelatedRenewalAgentRegDiaryNumber_ID;
                aa.RelatedRenewalAgentRegDiaryNumber_Name = item.RelatedRenewalAgentRegDiaryNumber_Name;
                aa.RelatedRenewalAgentRegDiaryNumber_NameYear = item.RelatedRenewalAgentRegDiaryNumber_NameYear;
                aa.UserID = item.UserID;

                aa.OtherMemDetailsCount = item.OtherMemDetailsCount;
                aa.DocumentuploadsCount = item.DocumentuploadsCount;
                aa.UTotherStateRERACount = item.UTotherStateRERACount;
                aa.PaymentsCount = item.PaymentsCount;
                aa.AgentDocumentCount = item.AgentDocumentCount;

                aa.CurrentEventcode = item.CurrentEventcode;
                aa.EventCodeDetails_indexID = item.EventCodeDetails_indexID;
                aa.tbl_RegDiaryNumber_indexID = item.tbl_RegDiaryNumber_indexID;

                aa.ReferenceProject_ID = item.ReferenceProject_ID;
                aa.ReferenceProject_Name = item.ReferenceProject_Name;
                aa.ReferencePromoter_ID = item.ReferencePromoter_ID;
                aa.ReferencePromoter_Name = item.ReferencePromoter_Name;

                aa.IsAlreadyRegistration = item.IsAlreadyRegistration;
                aa.ExistingRegistration = item.ExistingRegistration;
                aa.Agent_Type = item.Agent_Type;

                aa.Agent_FirstName = item.Agent_FirstName;
                aa.Agent_LastName = item.Agent_LastName;
                aa.Organization_Name = item.Organization_Name;

                aa.BComm_AddressLine1 = item.BComm_AddressLine1;
                aa.BComm_AddressLine2 = item.BComm_AddressLine2;
                aa.BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressPIN = item.BComm_AddressPIN;
                aa.BComm_AddressStateName = item.BComm_AddressStateName;
                aa.BComm_AddressDistrictName = item.BComm_AddressDistrictName;

                aa.EmailAddress = item.EmailAddress;
                aa.MobileNumber = item.MobileNumber;

                aa.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                aa.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;

                aa.AuthorizedSignatory_AddressLine1 = item.AuthorizedSignatory_AddressLine1;
                aa.AuthorizedSignatory_AddressLine2 = item.AuthorizedSignatory_AddressLine2;
                aa.AuthorizedSignatory_AddressStateCode = item.AuthorizedSignatory_AddressStateCode;
                aa.AuthorizedSignatory_AddressDistrictCode = item.AuthorizedSignatory_AddressDistrictCode;
                aa.AuthorizedSignatory_AddressPIN = item.AuthorizedSignatory_AddressPIN;
                aa.AuthorizedSignatory_AddressStateName = item.AuthorizedSignatory_AddressStateName;
                aa.AuthorizedSignatory_AddressDistrictName = item.AuthorizedSignatory_AddressDistrictName;

                aa.AuthorizedSignatory_EmailAddress = item.AuthorizedSignatory_EmailAddress;
                aa.AuthorizedSignatory_MobileNumber = item.AuthorizedSignatory_MobileNumber;

                aa.Agent_RERAnumberRegistration = item.Agent_RERAnumberRegistration;
                aa.Agent_RERAnumberIssueDate = item.Agent_RERAnumberIssueDate;
                aa.Agent_RERAnumberRegUptoDate = item.Agent_RERAnumberRegUptoDate;

                aa.LatestRenewalAgent_RERAnumberRegistration = item.LatestRenewalAgent_RERAnumberRegistration;
                aa.LatestRenewalAgent_RERAnumberIssueDate = item.LatestRenewalAgent_RERAnumberIssueDate;
                aa.LatestRenewalAgent_RERAnumberRegUptoDate = item.LatestRenewalAgent_RERAnumberRegUptoDate;

                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.Extra1 = item.Extra1;
                aa.Extra2 = item.Extra2;
                aa.Extra3 = item.Extra3;
                aa.Extra4 = item.Extra4;

                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.IsPublicView = item.IsPublicView;
                aa.IsCertificateIssued = item.IsCertificateIssued;
                aa.IsWithdrawn = item.IsWithdrawn;

                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            if (aa.prpongoing.Count >= 1)
            {
                if (aa.IsDraftHelpDesk == 1)
                {
                    TempData["submitvalue"] = "Update"; TempData.Keep();
                }
                else
                {
                    TempData["submitvalue"] = "Save"; TempData.Keep();
                }
            }
            else
            {
                TempData["submitvalue"] = "Save"; TempData.Keep();
            }
            return View("Add_RenewalAgentRERAregistrationNumber", aa);
        }

        [HttpPost]
        public ActionResult Add_RenewalAgentRERAregistrationNumber(ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber smodel)
        {
            ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber aa = new ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber();
            ClsMethod_ViewAdd_RenewalAgentRERAnumber sdb = new ClsMethod_ViewAdd_RenewalAgentRERAnumber();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string error = string.Empty;
            string userRole = string.Empty;
            string UserNam = string.Empty;
            string RnAgentRN = string.Empty;
            string RnAgentDN = string.Empty;
            string RnAgentNM = string.Empty;
            userRole = getUserRole();
            UserNam = User.Identity.Name;

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();

            if (Session["zapRnAgentDiaryNumber"] != null)
            {                
                RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        if (sdb.Update_LDR_RenewalAgent_RERAnumber_DiaryNumber(smodel, UserNam, RnAgentRN, RnAgentDN, AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID))
                        {
                            TempData["Message"] = "Successfully Updated";                            
                            ModelState.Clear();
                        }
                        return RedirectToAction("Add_RenewalAgentRERAregistrationNumber");
                    }
                    else
                    {
                        #region SAVE code
                        if (sdb.Add_LDR_RenewalAgent_RERAnumber_DiaryNumber(smodel, UserNam, RnAgentRN, RnAgentDN, AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID))
                        {
                            TempData["Message"] = "Successfully Submitted";                            
                            ModelState.Clear();
                        }
                        return RedirectToAction("Add_RenewalAgentRERAregistrationNumber");
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                String e = ex.Message;
            }
            return View();
        }
        

        //Check Single Entry RERA number
        public JsonResult Check_RealestateAgentRenewal_RERAregistrationNumber(string mRegNumber)
        {
            ClsMethod_ViewAdd_RenewalAgentRERAnumber CheckRegdNo = new ClsMethod_ViewAdd_RenewalAgentRERAnumber();
            bool RegdNo = CheckRegdNo.Check_UniqueRenewalAgentRegistrationNumber(mRegNumber);

            return Json(RegdNo);
        }

        //Generate RERA number Calculator
        [HttpGet]
        public ActionResult RealestateRnAgentRegistrationNumberRecordsCalculator(string agentId, string varflag)
        {
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            Int64 RefAgentID = String.IsNullOrEmpty(agentId) ? 0 : Convert.ToInt64(agentId);
            Int32 VarFlag = String.IsNullOrEmpty(varflag) ? 0 : Convert.ToInt32(varflag);

            ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator aa = new ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator();
            ClsMethod_ViewAdd_AgentRERAnumber sdb = new ClsMethod_ViewAdd_AgentRERAnumber();


            Tuple<DateTime, DateTime> tupleRegistrationToFromDate = sdb.Extract_AuthDesk_AgentRegistrationNumberDateDetails_ByID(RefAgentID, UID);

            aa.RegistrationValidUptoDate_Input = tupleRegistrationToFromDate.Item2;
            aa.RegistrationIssueDate_Input = tupleRegistrationToFromDate.Item1;
            aa.IsDraft = VarFlag;
            aa.Related_Agent_ID = RefAgentID;

            return View("RealestateRnAgentRegistrationNumberRecordsCalculator", aa);
        }
        
        //Renewal of Registration History (last four records wrt State)
        [HttpGet]
        public ActionResult RealestateRnAgentRegistrationNumberRecordsHistory(string agentId, string rnagentId, string rnagentseqId, string rnagentyrId, string varflag)
        {
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;
            Int64 RefAgentID = String.IsNullOrEmpty(agentId) ? 0 : Convert.ToInt64(agentId);
            Int64 RefRnAgentID = String.IsNullOrEmpty(rnagentId) ? 0 : Convert.ToInt64(rnagentId);
            Int32 RefRnAgentSeqID = String.IsNullOrEmpty(rnagentseqId) ? 0 : Convert.ToInt32(rnagentseqId);
            Int32 RefRnAgentYrID = String.IsNullOrEmpty(rnagentyrId) ? 0 : Convert.ToInt32(rnagentyrId);
            Int32 VarFlag = String.IsNullOrEmpty(varflag) ? 0 : Convert.ToInt32(varflag);

            ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails aa = new ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails();
            ClsMethod_ViewAdd_RenewalAgentRERAnumber sdb = new ClsMethod_ViewAdd_RenewalAgentRERAnumber();

            aa.prpongoing = sdb.Display_AuthDesk_RenewalAgent_RegistrationNumberHistory_ByID(RefAgentID, RefRnAgentID, RefRnAgentSeqID, RefRnAgentYrID, UID);
            foreach (var item in aa.prpongoing)
            {
                aa.Prepared_SequenceNumber = item.Prepared_SequenceNumber;
                aa.Prepared_AgentStateType = item.Prepared_AgentStateType;
                aa.Prepared_NumberTypeFlag = item.Prepared_NumberTypeFlag;
                aa.Prepared_RegistrationNumber = item.Prepared_RegistrationNumber;
                aa.Prepared_IssueDate = item.Prepared_IssueDate;
                aa.Prepared_ValidUptoDate = item.Prepared_ValidUptoDate;
                aa.Amount_PriceValue = item.Amount_PriceValue;
                aa.NumberAlreadyExisted_Flag = item.NumberAlreadyExisted_Flag;
                aa.RealEstateAgentName = item.RealEstateAgentName;
                aa.RealEstateAgentRegDiaryNumber_Name = item.RealEstateAgentRegDiaryNumber_Name;
                aa.RemarksIfAny = item.RemarksIfAny;
                aa.A_Column = item.A_Column;
                aa.B_Column = item.B_Column;
                aa.C_Column = item.C_Column;
            }
            return View("RealestateRnAgentRegistrationNumberRecordsHistory", aa);
        }
        #endregion

        #region Upload Agent-Renewal RERA Certificate
        [HttpGet]
        public ActionResult Add_RenewalAgentRERAcertificateDetails()
        {
            ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate aa = new ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate();
            ClsMethod_ViewAdd_RenewalAgentRERAcertificate sdb = new ClsMethod_ViewAdd_RenewalAgentRERAcertificate();

            string userRole = string.Empty;
            string UserNam = string.Empty;
            userRole = getUserRole();
            UserNam = User.Identity.Name;

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }
            
            aa.prpongoing = sdb.Display_AuthDesk_RenewalAgent_RERAcertificate_ByIDandDiaryNumber(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            
            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgent_RERAcertificate_IndexID = item.RenewalAgent_RERAcertificate_IndexID;
                aa.RenewalAgent_RERAcertificate_ID = item.RenewalAgent_RERAcertificate_ID;

                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                aa.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentDiaryNumber_Name = item.Related_AgentDiaryNumber_Name;
                aa.Related_Agent_Type = item.Related_Agent_Type;
                aa.Related_UserID = item.Related_UserID;
                aa.Related_RERAnumberRegistration = item.Related_RERAnumberRegistration;
                aa.Related_RERAnumberIssueDate = item.Related_RERAnumberIssueDate;
                aa.Related_RERAnumberRegUptoDate = item.Related_RERAnumberRegUptoDate;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsDraftHelpDesk = item.IsDraftHelpDesk;
                aa.IsDraftEvaluation = item.IsDraftEvaluation;
                aa.IsDraftSecMember = item.IsDraftSecMember;
                aa.IsDraftMember = item.IsDraftMember;
                aa.IsPublicView = item.IsPublicView;
            }

            //if (aa.prpongoing.Count >= 1)
            //{
            //    if (aa.IsDraftHelpDesk == 1)
            //    {
            //        TempData["submitvalue"] = "Update"; TempData.Keep();
            //    }
            //    else
            //    {
            //        TempData["submitvalue"] = "Save"; TempData.Keep();
            //    }
            //}
            //else
            //{
            //      TempData["submitvalue"] = "Save"; TempData.Keep();
            //}

            TempData["submitvalue"] = "Save"; TempData.Keep();
            return View("Add_RenewalAgentRERAcertificateDetails", aa);            
        }

        [HttpPost]
        public ActionResult Add_RenewalAgentRERAcertificateDetails(ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate smodel)
        {
            string Photo_Address = string.Empty;            
            string userRole = string.Empty;
            string UserNam = string.Empty;
            string Agent_DiaryNumber = string.Empty;
            string RnAgent_DiaryNumber = string.Empty;

            userRole = getUserRole();
            UserNam = User.Identity.Name;

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {                
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                RnAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "NA" : RnAgentDN);
            }

            //Save & Update
            #region

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
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwriteRnAgentCert";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.AgentRERAcert_FilePath))
                            {
                                pathindb = smodel.AgentRERAcert_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(AgentID) + "\\" + Convert.ToString(RenewalAgentID) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.AgentRERAcert_FileName))
                            {
                                fileName = smodel.AgentRERAcert_FileName.ToString();
                            }
                            else
                            {
                                fileName = "RnREAcert_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }

                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                            //set model variable
                            smodel.Related_AgentDiaryNumber_Name = RnAgent_DiaryNumber;
                            smodel.AgentRERAcert_FileSize = files.ContentLength.ToString();
                            smodel.AgentRERAcert_FileFormat = ext.ToString();
                        }
                        else
                        {
                            TempData["notice"] = "Document Size Should be less than 1MB";
                            error = "Document Size Should be less than 1MB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Document format should be .jpg or .pdf";
                        error = "Document format should be .jpg or .pdf";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Document or Certificate.";
                    error = "Kindly Upload Document or Certificate.";
                    errorstate = 1;

                    //update with same photograph
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
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.AgentRERAcert_FileName;
                            ext = smodel.AgentRERAcert_FilePath;
                            FilePathExt = smodel.AgentRERAcert_FilePath;
                        }
                        try
                        {
                            ClsMethod_ViewAdd_RenewalAgentRERAcertificate sdb = new ClsMethod_ViewAdd_RenewalAgentRERAcertificate();
                            sdb.Update_LDR_RenewalAgent_RERAcertifcate_DiaryNumber(smodel, AgentID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, Photo_Address, FilePathExt, UserNam, userRole);
                            TempData["message"] = "Details updated Successfully";

                            return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            return View();
                        }
                    }
                    return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
                }
                else
                {
                    return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwriteRnAgentCert";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(AgentID) + "\\" + Convert.ToString(RenewalAgentID) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "RnREAcert_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                            //set model variable
                            smodel.Related_AgentDiaryNumber_Name = RnAgent_DiaryNumber;
                            smodel.AgentRERAcert_FileSize = files.ContentLength.ToString();
                            smodel.AgentRERAcert_FileFormat = ext.ToString();
                        }
                        else
                        {
                            TempData["notice"] = "Document Size Should be less than 1MB";
                            error = "Document Size Should be less than 1MB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Document format should be .jpg or .pdf";
                        error = "Document format should be .jpg or .pdf";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Document or Certificate.";
                    error = "Kindly Upload Document or Certificate.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (Photo_Address == "")
                            {
                                Photo_Address = smodel.AgentRERAcert_FileName;
                                ext = smodel.AgentRERAcert_FilePath;
                                FilePathExt = smodel.AgentRERAcert_FilePath;                                
                            }
                            ClsMethod_ViewAdd_RenewalAgentRERAcertificate sdb = new ClsMethod_ViewAdd_RenewalAgentRERAcertificate();
                            if (sdb.Add_LDR_RenewalAgent_RERAcertifcate_DiaryNumber(smodel, AgentID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, Photo_Address, FilePathExt, UserNam, userRole))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
                    }
                    else
                    {
                        return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return View();
                }
            }
            #endregion
        }

        public ActionResult Delete_RenewalAgentRERAcertificateDetails(Int64? inRnAgentRERAcertificate_IndexID, Int64? inRnAgentRERAcertificate_ID, Int64? inAgent_ID, Int64? inRnAgent_ID, Int32? inRnAgent_Yr, Int32? inRnAgent_SeqID)
        {
            try
            {
                ClsMethod_ViewAdd_RenewalAgentRERAcertificate sdb = new ClsMethod_ViewAdd_RenewalAgentRERAcertificate();
                if (sdb.Delete_AuthDesk_RenewalAgent_RERAcertificateDetailsById(inRnAgentRERAcertificate_IndexID, inRnAgentRERAcertificate_ID, inAgent_ID, inRnAgent_ID, inRnAgent_SeqID, inRnAgent_Yr))
                {
                    TempData["message"] = " Details deleted Successfully";
                }
                return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
            }
            catch
            {
                return RedirectToAction("Add_RenewalAgentRERAcertificateDetails");
            }
        }
        #endregion

        #region Agent-Renewal Event History
        [HttpGet]
        public ActionResult RenewalAgentInfoEventLog(Int64 agentid, Int32 agenttypeid, Int64 rnagentid, Int32 rnagentseqid, Int32 rnagentyrid)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog recObj = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            string userRole = string.Empty;
            recObj.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_AgentEventLogDetails(agentid, agenttypeid, rnagentid, rnagentseqid, rnagentyrid, userRole);
            return View("RenewalAgentInfoEventLog", recObj);
        }
        #endregion

        #region Agent-Renewal Event 

        [HttpGet]
        public ActionResult RenewalAgentInfoEventInsert()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog aa = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            try
            {
                string userRole = string.Empty;
                userRole = getUserRole();
                //to bind subCheckList master
                aa.EventMaster = sdb.Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(userRole);

                if (Session["zapRnAgentDiaryNumber"] != null)
                {
                    string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                    string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                    string RnAgentNM = Session["zapRnAgentName"].ToString();
                    Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                    Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                    Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                    Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                    Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                    DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                    aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                    aa.Related_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                    aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                    aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                    aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                    aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                    aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                    aa.RenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                    aa.RenewalAgentLastModifiedOn = RnAgentLMOn;
                }
                else
                {
                    aa.Related_Agent_ID = 0;
                    aa.Related_AgentType_ID = 0;
                    aa.Related_RenewalAgent_ID = 0;
                    aa.Related_RenewalAgent_SequenceID = 0;
                    aa.Related_RenewalAgent_Year = 0;
                    aa.RERAnumberRegistration = string.Empty;
                    aa.RelatedAgent_RenewalDiaryNumber = string.Empty;
                    aa.RenewalAgentName = string.Empty;
                    aa.RenewalAgentLastModifiedOn = DateTime.MinValue;
                }
            }
            catch(Exception ex)
            {
                string strex = ex.ToString();
            }
            TempData["EventSubmitMessage"] = "";
            return View("RenewalAgentInfoEventInsert", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoEventInsertAction(string RnAgentRN, string RnAgentDN, string RnAgentNM, Int64? AgentID, Int32? AgentTypeID, Int64? RnAgentID, Int32? RnAgentSeqID, Int32? RnAgentYrID, DateTime? RnAgentLMOn)
        {
            Session["zapRnAgentRegistrationNumber"] = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
            Session["zapRnAgentDiaryNumber"] = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
            Session["zapRnAgentName"] = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
            Session["zapAgentID"] = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
            Session["zapAgentTypeID"] = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
            Session["zapRnAgentID"] = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
            Session["zapRnAgentSeqID"] = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
            Session["zapRnAgentYrID"] = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            Session["zapRnAgentLastModifiedOn"] = RnAgentLMOn;

            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog aa = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            try
            {
                string userRole = string.Empty;
                userRole = getUserRole();
                //to bind subCheckList master
                aa.EventMaster = sdb.Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(userRole);

                aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.Related_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.RenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.RenewalAgentLastModifiedOn = RnAgentLMOn;
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            TempData["EventSubmitMessage"] = "";
            return View("RenewalAgentInfoEventInsert", aa);
        }

        [HttpPost]
        public ActionResult RenewalAgentInfoEventInsert(ClsPrp_AuthorityDesk_RenewalAgent_EventLog smodel)
        {
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog aa = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;

                    if (sdb.Add_RenewalAgent_InfoEvent(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();

                        TempData["EventSubmitMessage"] = "Application Performa successfully Submitted.";
                        TempData["EventSubmitMessageRenewalAgentMappingUrlFlag"] = getMappingUrlByRenewalAgentEvent();
                    }

                    //to bind subCheckList master
                    aa.EventMaster = sdb.Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(pUserRole);

                    if (Session["zapRnAgentDiaryNumber"] != null)
                    {
                        string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                        string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                        string RnAgentNM = Session["zapRnAgentName"].ToString();
                        Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                        Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                        Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                        Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                        Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                        DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                        aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                        aa.Related_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                        aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                        aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                        aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                        aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                        aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                        aa.RenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                        aa.RenewalAgentLastModifiedOn = RnAgentLMOn;
                    }
                    else
                    {
                        aa.Related_Agent_ID = 0;
                        aa.Related_AgentType_ID = 0;
                        aa.Related_RenewalAgent_ID = 0;
                        aa.Related_RenewalAgent_SequenceID = 0;
                        aa.Related_RenewalAgent_Year = 0;
                        aa.RERAnumberRegistration = string.Empty;
                        aa.RelatedAgent_RenewalDiaryNumber = string.Empty;
                        aa.RenewalAgentName = string.Empty;
                        aa.RenewalAgentLastModifiedOn = DateTime.MinValue;
                    }
                }       
                return View("RenewalAgentInfoEventInsert", aa);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["EventSubmitMessage"] = "Sorry, Application Performa is pending";
                TempData["EventSubmitMessageRenewalAgentMappingUrlFlag"] = getMappingUrlByRenewalAgentEvent();

                return View("RenewalAgentInfoEventInsert", aa);
            }
        }

        public JsonResult GetRenewalEventDescriptionMasterForRERAnumberByCode(string EventCode)
        {
            int Id = 0;
            if (EventCode != "")
                Id = Convert.ToInt32(EventCode);

            ClsMethod_Agent_Helpdesk objCode = new ClsMethod_Agent_Helpdesk();
            var Subdiv = objCode.Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Id);

            return Json(Subdiv);
        }

        private string getMappingUrlByRenewalAgentEvent()
        {
            string vret = string.Empty;
            string pUserRole = string.Empty;
            string pUser_WhoIdentified = string.Empty;

            pUser_WhoIdentified = User.Identity.Name;
            pUserRole = getUserRole();

            vret = "ResetFlag";

            // Chairperson OR membersg OR memberjsk
            if (pUser_WhoIdentified == "chairperson" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ReviewList";
            }
            if (pUser_WhoIdentified == "membersg" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ReviewList";
            }
            if (pUser_WhoIdentified == "memberjsk" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ReviewList";
            }

            // Secrett RERA
            if (pUser_WhoIdentified == "secyrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ChecklistPreparedList";
            }
            if (pUser_WhoIdentified == "consultantrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ChecklistPreparedList";
            }
            if (pUser_WhoIdentified == "mngradminrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ChecklistPreparedList";
            }

            // ReraDesk
            if (pUserRole == "7b9d725a-b33c-4aba-934a-bee1ec13f684")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_InProcessList";
            }

            // System Analysist
            if (pUserRole == "e583ee7f-aaa3-49bd-afc8-79c877afe591")
            {
                vret = "HelpdeskAgent/RenewalAgentRegistrationInfoDeskIssueRenewal";
            }

            // System Counseltent
            if (pUser_WhoIdentified == "pbreraconsultant" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_InProcessList";
            }
            if (pUser_WhoIdentified == "secttrera" && pUserRole == "15ac7786-a35e-46a3-ae19-8befd003dcfd")
            {
                vret = "HelpdeskAgent/RenewalAgentInfoDesk_ChecklistPreparedList";
            }
            return vret;
        }

        #endregion

        #region Agent-Renewal RERA Number Event 

        [HttpGet]
        public ActionResult RenewalAgentRERAnumberInfoEventInsert()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog aa = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            try
            {
                string userRole = string.Empty;
                userRole = getUserRole();
                //to bind subCheckList master
                aa.EventMaster = sdb.Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(userRole);

                if (Session["zapRnAgentDiaryNumber"] != null)
                {
                    string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                    string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                    string RnAgentNM = Session["zapRnAgentName"].ToString();
                    Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                    Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                    Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                    Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                    Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                    DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                    aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                    aa.Related_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                    aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                    aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                    aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                    aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                    aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                    aa.RenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                    aa.RenewalAgentLastModifiedOn = RnAgentLMOn;
                }
                else
                {
                    aa.Related_Agent_ID = 0;
                    aa.Related_AgentType_ID = 0;
                    aa.Related_RenewalAgent_ID = 0;
                    aa.Related_RenewalAgent_SequenceID = 0;
                    aa.Related_RenewalAgent_Year = 0;
                    aa.RERAnumberRegistration = string.Empty;
                    aa.RelatedAgent_RenewalDiaryNumber = string.Empty;
                    aa.RenewalAgentName = string.Empty;
                    aa.RenewalAgentLastModifiedOn = DateTime.MinValue;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            TempData["EventSubmitMessage"] = "";
            return View("RenewalAgentRERAnumberInfoEventInsert", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentRERAnumberInfoEventInsertAction(string RnAgentRN, string RnAgentDN, string RnAgentNM, Int64? AgentID, Int32? AgentTypeID, Int64? RnAgentID, Int32? RnAgentSeqID, Int32? RnAgentYrID, DateTime? RnAgentLMOn)
        {
            Session["zapRnAgentRegistrationNumber"] = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
            Session["zapRnAgentDiaryNumber"] = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
            Session["zapRnAgentName"] = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
            Session["zapAgentID"] = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
            Session["zapAgentTypeID"] = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
            Session["zapRnAgentID"] = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
            Session["zapRnAgentSeqID"] = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
            Session["zapRnAgentYrID"] = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            Session["zapRnAgentLastModifiedOn"] = RnAgentLMOn;

            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog aa = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            try
            {
                string userRole = string.Empty;
                userRole = getUserRole();
                //to bind subCheckList master
                aa.EventMaster = sdb.Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(userRole);

                aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.Related_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.RenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.RenewalAgentLastModifiedOn = RnAgentLMOn;
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            TempData["EventSubmitMessage"] = "";
            return View("RenewalAgentRERAnumberInfoEventInsert", aa);
        }

        [HttpPost]
        public ActionResult RenewalAgentRERAnumberInfoEventInsert(ClsPrp_AuthorityDesk_RenewalAgent_EventLog smodel)
        {
            ClsPrp_AuthorityDesk_RenewalAgent_EventLog aa = new ClsPrp_AuthorityDesk_RenewalAgent_EventLog();
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;

                    if (sdb.Add_RenewalAgent_InfoEvent(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();

                        TempData["EventSubmitMessage"] = "Application Performa successfully Submitted.";
                        TempData["EventSubmitMessageRenewalAgentMappingUrlFlag"] = getMappingUrlByRenewalAgentEvent();
                    }

                    //to bind subCheckList master
                    aa.EventMaster = sdb.Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(pUserRole);

                    if (Session["zapRnAgentDiaryNumber"] != null)
                    {
                        string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                        string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                        string RnAgentNM = Session["zapRnAgentName"].ToString();
                        Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                        Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                        Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                        Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                        Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                        DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                        aa.Related_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                        aa.Related_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                        aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                        aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                        aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                        aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                        aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                        aa.RenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                        aa.RenewalAgentLastModifiedOn = RnAgentLMOn;
                    }
                    else
                    {
                        aa.Related_Agent_ID = 0;
                        aa.Related_AgentType_ID = 0;
                        aa.Related_RenewalAgent_ID = 0;
                        aa.Related_RenewalAgent_SequenceID = 0;
                        aa.Related_RenewalAgent_Year = 0;
                        aa.RERAnumberRegistration = string.Empty;
                        aa.RelatedAgent_RenewalDiaryNumber = string.Empty;
                        aa.RenewalAgentName = string.Empty;
                        aa.RenewalAgentLastModifiedOn = DateTime.MinValue;
                    }
                }
                return View("RenewalAgentRERAnumberInfoEventInsert", aa);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["EventSubmitMessage"] = "Sorry, Application Performa is pending";
                TempData["EventSubmitMessageRenewalAgentMappingUrlFlag"] = getMappingUrlByRenewalAgentEvent();

                return View("RenewalAgentRERAnumberInfoEventInsert", aa);
            }
        }

        public JsonResult GetRenewalEventDescriptionMasterByCode(string EventCode)
        {
            int Id = 0;
            if (EventCode != "")
                Id = Convert.ToInt32(EventCode);

            ClsMethod_Agent_Helpdesk objCode = new ClsMethod_Agent_Helpdesk();
            var Subdiv = objCode.Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Id);

            return Json(Subdiv);
        }
        
        #endregion

        #region Agent-Renewal CheckList       

        [HttpGet]
        public ActionResult RenewalAgentInfoCheckListInsert(Int64? AgentId, Int64? RnAgentId, Int32? RnAgentSeqId, Int32? RnAgentYrId, Int32? criteriaCode)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();

            Int32 CheckList_ID = Convert.ToInt32(criteriaCode);

            aa.SubCheckListMaster = sdb.Display_AuthorityDesk_RenewalAgent_SubCheckList_MasterDetails(CheckList_ID);
            aa.A_column = sdb.Fill_RenewalAgent_ChecklistCriteriaName(CheckList_ID);

            aa.Related_Agent_ID = 0;
            aa.Related_AgentType_ID = 0;
            aa.Related_RenewalAgent_ID = 0;
            aa.Related_RenewalAgent_Year = 0;
            aa.Related_RenewalAgent_SequenceID = 0;            
            aa.RelatedAgent_RenewalDiaryNumber = string.Empty;
            aa.RERAnumberRegistration = string.Empty;

            if (criteriaCode != null)
                aa.CriteriaCode = criteriaCode.ToString();

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;


                aa.Related_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.Related_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.Related_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.Related_RenewalAgent_Year = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.Related_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;                
                aa.RelatedAgent_RenewalDiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.RERAnumberRegistration = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
            }

            return View("RenewalAgentInfoCheckListInsert", aa);
        }

        [HttpPost]
        public ActionResult RenewalAgentInfoCheckListInsert(ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog smodel)
        {
            string viewname = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();

                    string pUserRole = string.Empty;
                    pUserRole = getUserRole();
                    string pUser_WhoIdentified = User.Identity.Name;
                    if (sdb.Add_RenewalAgent_InfoCheckList(smodel, pUserRole, pUser_WhoIdentified))
                    {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();
                    }
                }

                var fullUrl = this.Request.UrlReferrer.ToString();
                string url = fullUrl;
                var request = new HttpRequest(null, url, null);
                var response = new HttpResponse(new System.IO.StringWriter());
                var httpContext = new HttpContext(request, response);
                var routeData = System.Web.Routing.RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
                var values = routeData.Values;
                string controllerName = values["controller"].ToString();
                viewname = values["action"].ToString();

                return RedirectToAction(viewname);
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                return RedirectToAction("RenewalAgentInfoCheckListDisplay");
            }
        }

        public JsonResult GetRenewalAgentCriteriaSubCodeDescriptionMasterByCode(string CriteriaSubCode)
        {
            int Id = 0;
            if (CriteriaSubCode != "")
                Id = Convert.ToInt32(CriteriaSubCode);

            ClsMethod_RenewalAgent_Helpdesk objCode = new ClsMethod_RenewalAgent_Helpdesk();
            var Subdiv = objCode.Display_AuthorityDesk_RenewalAgent_SubCheckList_MasterDetailsByCode(Id);

            return Json(Subdiv);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoCheckListDisplay()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();
            string userRole = string.Empty;

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;
            userRole = getUserRole();

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_CheckList_DetailsByCode(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgentCheckListAction_ID = item.RenewalAgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentType_ID = item.Related_AgentType_ID;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                aa.Related_RenewalAgent_SequenceID = item.Related_RenewalAgent_SequenceID;
                aa.RelatedAgent_DiaryNumber = item.RelatedAgent_DiaryNumber;
                aa.RelatedAgent_RenewalDiaryNumber = item.RelatedAgent_RenewalDiaryNumber;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsLock = item.IsLock;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.CriteriaSubCodeTitle = item.CriteriaSubCodeTitle;
                aa.VarCriteriaCode = item.VarCriteriaCode;
                aa.VarCriteriaSubCode = item.VarCriteriaSubCode;
                aa.VarChecklistOrderNumber = item.VarChecklistOrderNumber;
                aa.VarChecklistGroupID = item.VarChecklistGroupID;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("RenewalAgentInfoCheckListDisplay", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoCheckListDisplayLog(Int64 parmAgentId, Int32 parmAgentTypeId, Int64 parmRnAgentId, Int32 parmRnAgentSeqId, Int32 parmRnAgentYrId, Int32 parmCriteriaID, Int32 parmCriteriaSubID)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();

            string userRole = string.Empty;

            Int64 vAgentID = 0;
            Int32 vAgentTypeID = 0;
            Int64 vRenewalAgentID = 0;
            Int32 vRenewalAgentSequenceID = 0;
            Int32 vRenewalAgentYearID = 0;
            Int32 vCriteriaID = 0;
            Int32 vCriteriaSubID = 0;
            userRole = getUserRole();

            vAgentID = parmAgentId;
            vAgentTypeID = parmAgentTypeId;
            vRenewalAgentID = parmRnAgentId;
            vRenewalAgentSequenceID = parmRnAgentSeqId;
            vRenewalAgentYearID = parmRnAgentYrId;
            vCriteriaID = parmCriteriaID;
            vCriteriaSubID = parmCriteriaSubID;

            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_CheckList_DetailsByCode_ForExpandLog(vAgentID, vAgentTypeID, vRenewalAgentID, vRenewalAgentSequenceID, vRenewalAgentYearID, userRole, vCriteriaID, vCriteriaSubID);
            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgentCheckListAction_ID = item.RenewalAgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentType_ID = item.Related_AgentType_ID;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                aa.Related_RenewalAgent_SequenceID = item.Related_RenewalAgent_SequenceID;
                aa.RelatedAgent_DiaryNumber = item.RelatedAgent_DiaryNumber;
                aa.RelatedAgent_RenewalDiaryNumber = item.RelatedAgent_RenewalDiaryNumber;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsLock = item.IsLock;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.CriteriaSubCodeTitle = item.CriteriaSubCodeTitle;
                aa.VarCriteriaCode = item.VarCriteriaCode;
                aa.VarCriteriaSubCode = item.VarCriteriaSubCode;
                aa.VarChecklistOrderNumber = item.VarChecklistOrderNumber;
                aa.VarChecklistGroupID = item.VarChecklistGroupID;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.zapRelated_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("RenewalAgentInfoCheckListDisplayLog", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfoCheckListDisplayLogByFlag(Int64 parmAgentId, Int32 parmAgentTypeId, Int64 parmRnAgentId, Int32 parmRnAgentSeqId, Int32 parmRnAgentYrId, Int32 parmCriteriaID, Int32 parmCriteriaSubID, Int32 parmCriteriaFlag)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();

            string userRole = string.Empty;

            Int64 vAgentID = 0;
            Int32 vAgentTypeID = 0;
            Int64 vRenewalAgentID = 0;
            Int32 vRenewalAgentSequenceID = 0;
            Int32 vRenewalAgentYearID = 0;
            Int32 vCriteriaID = 0;
            Int32 vCriteriaSubID = 0;
            Int32 vCriteriaFlag = 0;
            userRole = getUserRole();

            vAgentID = parmAgentId;
            vAgentTypeID = parmAgentTypeId;
            vRenewalAgentID = parmRnAgentId;
            vRenewalAgentSequenceID = parmRnAgentSeqId;
            vRenewalAgentYearID = parmRnAgentYrId;
            vCriteriaID = parmCriteriaID;
            vCriteriaSubID = parmCriteriaSubID;
            vCriteriaFlag = parmCriteriaFlag;

            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_CheckList_DetailsByID_ForLogHistory(vAgentID, vAgentTypeID, vRenewalAgentID, vRenewalAgentSequenceID, vRenewalAgentYearID, userRole, vCriteriaID, vCriteriaSubID);
            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgentCheckListAction_ID = item.RenewalAgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentType_ID = item.Related_AgentType_ID;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                aa.Related_RenewalAgent_SequenceID = item.Related_RenewalAgent_SequenceID;
                aa.RelatedAgent_DiaryNumber = item.RelatedAgent_DiaryNumber;
                aa.RelatedAgent_RenewalDiaryNumber = item.RelatedAgent_RenewalDiaryNumber;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsLock = item.IsLock;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                aa.CriteriaSubCodeTitle = item.CriteriaSubCodeTitle;
                aa.VarCriteriaCode = item.VarCriteriaCode;
                aa.VarCriteriaSubCode = item.VarCriteriaSubCode;
                aa.VarChecklistOrderNumber = item.VarChecklistOrderNumber;
                aa.VarChecklistGroupID = item.VarChecklistGroupID;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.zapRelated_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("RenewalAgentInfoCheckListDisplayLogByFlag", aa);
        }


        [HttpGet] //Event Lists
        public ActionResult RenewalAgentInfoCheckListNoAcceptDisplay(Int64 agentid, Int32 agenttypeid, Int64 rnagentid, Int32 rnagentseqid, Int32 rnagentyrid, Int32? criteriaCode)
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();
            string userRole = string.Empty;
            Int64 prmAgentID = 0;
            Int32 prmAgentTypeID = 0;
            Int64 prmRenewalAgentID = 0;
            Int32 prmRenewalAgentSequenceID = 0;
            Int32 prmRenewalAgentYearID = 0;
            userRole = getUserRole();

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                prmAgentID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                prmAgentTypeID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                prmRenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                prmRenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                prmRenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }
            else
            {
                prmAgentID = Convert.ToInt64(agentid);
                prmAgentTypeID = Convert.ToInt32(agenttypeid);
                prmRenewalAgentID = Convert.ToInt64(rnagentid);
                prmRenewalAgentSequenceID = Convert.ToInt32(rnagentseqid);
                prmRenewalAgentYearID = Convert.ToInt32(rnagentyrid);
            }

            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_CheckList_NoAccept_DetailsByCode(prmAgentID, prmAgentTypeID, prmRenewalAgentID, prmRenewalAgentSequenceID, prmRenewalAgentYearID, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgentCheckListAction_ID = item.RenewalAgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentType_ID = item.Related_AgentType_ID;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                aa.Related_RenewalAgent_SequenceID = item.Related_RenewalAgent_SequenceID;
                aa.RelatedAgent_DiaryNumber = item.RelatedAgent_DiaryNumber;
                aa.RelatedAgent_RenewalDiaryNumber = item.RelatedAgent_RenewalDiaryNumber;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsLock = item.IsLock;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.zapRelated_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            } 
                      
            return View("RenewalAgentInfoCheckListNoAcceptDisplay", aa);
        }

        //Event Lists
        public JsonResult GetCriteriaDescription_NotAccepted_ByRenewalAgentID(Int64? agentid, Int32? agenttypeid, Int64? rnagentid, Int32? rnagentseqid, Int32? rnagentyrid)
        {
            ClsMethod_RenewalAgent_Helpdesk objCode = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();

            Int64 prmAgentID = 0;
            Int32 prmAgentTypeID = 0;
            Int64 prmRenewalAgentID = 0;
            Int32 prmRenewalAgentSequenceID = 0;
            Int32 prmRenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                prmAgentID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                prmAgentTypeID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                prmRenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                prmRenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                prmRenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }
            else
            {
                prmAgentID = Convert.ToInt64(agentid);
                prmAgentTypeID = Convert.ToInt32(agenttypeid);
                prmRenewalAgentID = Convert.ToInt64(rnagentid);
                prmRenewalAgentSequenceID = Convert.ToInt32(rnagentseqid);
                prmRenewalAgentYearID = Convert.ToInt32(rnagentyrid);
            }

            string pUserRole = string.Empty;
            pUserRole = getUserRole();

            aa.prpongoing = objCode.Display_AuthorityDesk_RenewalAgent_CheckList_NoAccept_DetailsByCode(prmAgentID, prmAgentTypeID, prmRenewalAgentID, prmRenewalAgentSequenceID, prmRenewalAgentYearID, pUserRole);
            string varStrRet = string.Empty;
            Int32 vlenStart = 0;
            Int32 vlen = aa.prpongoing.Count();
            foreach (var item in aa.prpongoing)
            {
                if (vlenStart == vlen - 1)
                {
                    // last
                    varStrRet += item.CriteriaCode;
                }
                else
                {
                    varStrRet += item.CriteriaCode + ", ";
                }
                vlenStart++;            
            }

            return Json(varStrRet);
        }

        [HttpGet] //Event Lists
        public ActionResult RenewalAgentInfoCheckListNoAcceptPDF()
        {
            ClsMethod_RenewalAgent_Helpdesk sdb = new ClsMethod_RenewalAgent_Helpdesk();
            ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog aa = new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog();
            string userRole = string.Empty;
            Int64 prmAgentID = 0;
            Int32 prmAgentTypeID = 0;
            Int64 prmRenewalAgentID = 0;
            Int32 prmRenewalAgentSequenceID = 0;
            Int32 prmRenewalAgentYearID = 0;
            userRole = getUserRole();

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                prmAgentID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                prmAgentTypeID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                prmRenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                prmRenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                prmRenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthorityDesk_RenewalAgent_CheckList_NoAccept_DetailsByCode(prmAgentID, prmAgentTypeID, prmRenewalAgentID, prmRenewalAgentSequenceID, prmRenewalAgentYearID, userRole);

            foreach (var item in aa.prpongoing)
            {
                aa.RenewalAgentCheckListAction_ID = item.RenewalAgentCheckListAction_ID;
                aa.CheckList_IdentifiedBy = item.CheckList_IdentifiedBy;
                aa.UserRole = item.UserRole;
                aa.CheckList_IdentifiedOn = item.CheckList_IdentifiedOn;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_AgentType_ID = item.Related_AgentType_ID;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalAgent_Year = item.Related_RenewalAgent_Year;
                aa.Related_RenewalAgent_SequenceID = item.Related_RenewalAgent_SequenceID;
                aa.RelatedAgent_DiaryNumber = item.RelatedAgent_DiaryNumber;
                aa.RelatedAgent_RenewalDiaryNumber = item.RelatedAgent_RenewalDiaryNumber;
                aa.RERAnumberRegistration = item.RERAnumberRegistration;
                aa.CriteriaCode = item.CriteriaCode;
                aa.CriteriaSubCode = item.CriteriaSubCode;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.IsChecklistValueOk = item.IsChecklistValueOk;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsLock = item.IsLock;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgentID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgentTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgentID != null) ? Convert.ToInt64(AgentID) : 0;
                aa.zapRelated_AgentType_ID = (AgentTypeID != null) ? Convert.ToInt32(AgentTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return new RazorPDF.PdfActionResult(aa);
        }
        #endregion
        
        #region View Agent-Renewal Payment Details

        [HttpGet]
        public ActionResult Display_RenewalAgent_PaymentDetails()
        {
            ClsMethod_View_RenewalAgent_Payment sdb = new ClsMethod_View_RenewalAgent_Payment();
            ClsPrp_AuthDesk_View_RenewalAgent_Payment aa = new ClsPrp_AuthDesk_View_RenewalAgent_Payment();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.AgentPayment = sdb.Display_AuthDesk_RenewalAgent_PaymentDetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            aa.AgentPaymentWithTranasactions = sdb.Display_RenewalAgent_ApplicationPaymentTransactions(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);

            foreach (var item in aa.AgentPayment)
            {
                aa.RenewalAgent_FeePayment_IndexID = item.RenewalAgent_FeePayment_IndexID;
                aa.RenewalAgent_FeePayment_ID = item.RenewalAgent_FeePayment_ID;
                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;

                aa.IsDraftRenewalAgentPayment = item.IsDraft;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_PaymentDetails", aa);
        }

        //Lock-Unlock Handler (Registration Fee Details)             
        public JsonResult LockUnlockHandler_RenewalAgent_RegistrationPayment(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Registration Fee (Agent Renewal) details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_RenewalAgent_Payment sdb = new ClsMethod_View_RenewalAgent_Payment();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_PaymentDetail(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked registration fee details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked registration fee details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent-Renewal Document Details

        [HttpGet]
        public ActionResult Display_RenewalAgent_DocumentDetails()
        {
            ClsMethod_View_RenewalAgent_Documents sdb = new ClsMethod_View_RenewalAgent_Documents();
            ClsPrp_AuthDesk_View_RenewalAgent_Documents aa = new ClsPrp_AuthDesk_View_RenewalAgent_Documents();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.AgentDocs = sdb.Display_AuthDesk_RenewalAgent_Documents_ByAgentId(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            
            #region Lock - Unlock (Logic Display Message)
            bool var_Anydocopen = false;
            bool var_Alldocclosed = false;
            bool var_Anydocpermanent = false;

            if (aa.AgentDocs.Count == 0)
            {
                aa.IsDraftRenewalAgentListDocuments = 0;
            }

            foreach (var item in aa.AgentDocs)
            {
                aa.RenewalAgent_Document_IndexID = item.RenewalAgent_Document_IndexID;
                aa.RenewalAgent_Document_ID = item.RenewalAgent_Document_ID;
                aa.Related_Agent_ID = item.Related_Agent_ID;
                aa.Related_Agent_Type = item.Related_Agent_Type;
                aa.Related_RenewalAgent_ID = item.Related_RenewalAgent_ID;
                aa.Related_RenewalOrderSequence = item.Related_RenewalOrderSequence;
                aa.Related_RelatedRenewalAgent_Year = item.Related_RelatedRenewalAgent_Year;
                aa.AgentDoc_InfoCode = item.AgentDoc_InfoCode;
                aa.AgentDoc_InfoName = item.AgentDoc_InfoName;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;

                if (item.IsDraft == 1)
                {
                    var_Alldocclosed = true;
                }
                if (item.IsDraft == 5)
                {
                    var_Anydocopen = true;
                }
                if (item.IsDraft == 6)
                {
                    var_Anydocpermanent = true;
                }
            }

            if (var_Anydocpermanent)
            {
                aa.IsDraftRenewalAgentListDocuments = 6;
            }
            else if (var_Anydocopen)
            {
                aa.IsDraftRenewalAgentListDocuments = 5;
            }
            else if (var_Alldocclosed)
            {
                aa.IsDraftRenewalAgentListDocuments = 1;
            }
            else
            {
                aa.IsDraftRenewalAgentListDocuments = 0;
            }
            #endregion

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_DocumentDetails", aa);
        }

        //Lock-Unlock Handler (Renewal-Agent Documents List)
        public JsonResult LockUnlockHandler_RenewalAgent_DocumentList(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Renewal-Agent document(s) list details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion
                ClsMethod_View_RenewalAgent_Documents sdb = new ClsMethod_View_RenewalAgent_Documents();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_DocumentsByList(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked renewal of agent document(s) list details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked renewal of agent document(s) list details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }

        //Lock-Unlock Handler (Renewal-Agent Document By Index)
        public JsonResult LockUnlockHandler_RenewalAgent_DocumentByIndex(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID, string parmDocByIndex)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                Int32 DocByIndexID = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                if (parmDocByIndex != string.Empty)
                {
                    DocByIndexID = Convert.ToInt32(parmDocByIndex);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Renewal-Agent document details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion
                ClsMethod_View_RenewalAgent_Documents sdb = new ClsMethod_View_RenewalAgent_Documents();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_DocumentDetailsByIndex(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg, DocByIndexID);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked renewal of agent document details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked renewal of agent document details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent-Renewal Other State UT RERA Details

        [HttpGet]
        public ActionResult Display_RenewalAgent_OtherStateUT_RERA()
        {
            ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA sdb = new ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_RenewalAgent_OtherStateUT_RERA aa = new ClsPrp_AuthDesk_View_RenewalAgent_OtherStateUT_RERA();

            string userRole = string.Empty;            
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.Agent_OtherStateUTMember = sdb.Display_AuthDesk_RenewalAgent_OtherStateUT_RERADetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            foreach (var item in aa.Agent_OtherStateUTMember)
            {
                aa.AgentRenewal_OtherStateUT_regRERA_IndexID = item.AgentRenewal_OtherStateUT_regRERA_IndexID;
                aa.AgentRenewal_OtherStateUT_regRERA_ID = item.AgentRenewal_OtherStateUT_regRERA_ID;
                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;

                aa.IsDraftRenewalAgentOtherRERA = item.IsDraft;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_OtherStateUT_RERA", aa);
        }

        //Lock-Unlock Handler (Other State-UT RERA Details)             
        public JsonResult LockUnlockHandler_RenewalAgent_OtherStateUTRERA(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Other State-UT RERA (Agent Renewal) details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA sdb = new ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_OtherStateUT_RERA(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked Other State-UT RERA details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked Other State-UT RERA details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent-Renewal RERA Registration(s) Details

        [HttpGet]
        public ActionResult Display_RenewalAgent_RefRegistrations_RERA()
        {
            ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA sdb = new ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA aa = new ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.Agent_RefRegistrationsRERA = sdb.Display_AuthDesk_RenewalAgent_RefRegistrations_RERADetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_RefRegistrations_RERA", aa);
        }

        [HttpGet]
        public ActionResult Display_RenewalAgent_RefRegistrations_RERAinfoDesk()
        {
            ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA sdb = new ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA aa = new ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            aa.Agent_RefRegistrationsRERA = sdb.Display_AuthDesk_RenewalAgent_RefRegistrations_RERADetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_RefRegistrations_RERAinfoDesk", aa);
        }

        [HttpGet]
        public ActionResult RenewalAgentInfo_PrevRegistrationsDetail(Int64 AgentId, Int32 AgentType, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string flagCode)
        {
            ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA sdb = new ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA();
            ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations recObj = new ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            string userRole = string.Empty;
            userRole = getUserRole();

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            int? BusinessPlace_AddressSubDivisionCode = 0;

            try
            {
                recObj.AgentPrevRegistrations = sdb.Display_PopUpDesk_RenewalAgent_PrevRegistrationRecord_RERADetail(AgentId, AgentType, RnAgentId, RnAgentSeqId, RnAgentYrId, flagCode, userRole);

                foreach (var item in recObj.AgentPrevRegistrations)
                {
                    statecode = (String.IsNullOrEmpty(item.RegOfficeOrPermanent_AddressStateCode) ? 0 : Convert.ToInt32(item.RegOfficeOrPermanent_AddressStateCode));
                    recObj.P_AddressState = objdis.State_Name(statecode);
                    DistrictCode = (String.IsNullOrEmpty(item.RegOfficeOrPermanent_AddressDistrictCode) ? 0 : Convert.ToInt32(item.RegOfficeOrPermanent_AddressDistrictCode));
                    recObj.P_AddressDist = objdis.District_Name(DistrictCode);

                    BusinessPlace_AddressStateCode = (String.IsNullOrEmpty(item.BusinessPlace_AddressStateCode) ? 0 : Convert.ToInt32(item.BusinessPlace_AddressStateCode));
                    recObj.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                    BusinessPlace_AddressDistrictCode = (String.IsNullOrEmpty(item.BusinessPlace_AddressDistrictCode) ? 0 : Convert.ToInt32(item.BusinessPlace_AddressDistrictCode));
                    recObj.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                    BComm_AddressStateCode = (String.IsNullOrEmpty(item.BComm_AddressStateCode) ? 0 : Convert.ToInt32(item.BComm_AddressStateCode));
                    recObj.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                    BComm_AddressDistrictCode = (String.IsNullOrEmpty(item.BComm_AddressDistrictCode) ? 0 : Convert.ToInt32(item.BComm_AddressDistrictCode));
                    recObj.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                    BusinessPlace_AddressSubDivisionCode = (String.IsNullOrEmpty(item.BusinessPlace_AddressSubDivisionName) ? 0 : Convert.ToInt32(item.BusinessPlace_AddressSubDivisionName));
                    recObj.BusinessPlace_AddressSubDivision = objdis.SubDivision_Name(BusinessPlace_AddressSubDivisionCode);
                }

                recObj.AgentPrevRegistrations_OtherMember = sdb.Display_PopUpDesk_RenewalAgent_PrevRegistrationRecord_OthermemberDetail(AgentId, AgentType, RnAgentId, RnAgentSeqId, RnAgentYrId, flagCode, userRole);

                for (var i = 0; i < recObj.AgentPrevRegistrations_OtherMember.Count; i++)
                {
                    DistrictCode = recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressDistrictCode;
                    recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressDistName = objdis.District_Name(DistrictCode);

                    statecode = recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressStateCode;
                    recObj.AgentPrevRegistrations_OtherMember[i].OfficeComm_AddressStateName = objdis.State_Name(statecode);
                }

            }
            catch (Exception ex)
            {
                string exSTR = ex.ToString();
            }
            return View("RenewalAgentInfo_PrevRegistrationsDetail", recObj);
        }

        #endregion

        #region View Agent-Renewal Ind-Profile

        [HttpGet]
        public ActionResult Display_RenewalAgent_AgentIndProfile()
        {
            ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile sdb = new ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile();
            ClsPrp_AuthDesk_View_RenewalAgent_IndProfile aa = new ClsPrp_AuthDesk_View_RenewalAgent_IndProfile();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            int? BusinessPlace_AddressSubDivisionCode = 0;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.AgentIndProfile = sdb.Display_AuthDesk_RenewalAgent_IndProfileDetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);

            foreach (var item in aa.AgentIndProfile)
            {
                if (item.Agent_Type == 2)
                {
                    return RedirectToAction("Display_RenewalAgent_AgentOtherIndProfile");
                }

                statecode = item.P_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);

                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                BusinessPlace_AddressSubDivisionCode = (String.IsNullOrEmpty(item.B_Column) ? 0 : Convert.ToInt32(item.B_Column));
                aa.BusinessPlace_AddressSubDivision = objdis.SubDivision_Name(BusinessPlace_AddressSubDivisionCode);


                aa.RenewalAgent_IndexID = item.RenewalAgent_IndexID;
                aa.RenewalAgent_ID = item.RenewalAgent_ID;
                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;

                aa.IsDraftRenewalAgent = item.IsDraft;
            }

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_AgentIndProfile", aa);
        }

        //Lock-Unlock Handler (Renewal-Agent Registration Details)             
        public JsonResult LockUnlockHandler_RenewalAgentIndProfileRegistration(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Renewal of Agent (Individual) Registration details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile sdb = new ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_IndProfileDetail(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked renewal of agent registration details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked renewal of agent registration details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View Agent-Renewal Other-Than-Ind-Profile

        [HttpGet]
        public ActionResult Display_RenewalAgent_AgentOtherIndProfile()
        {
            ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile sdb = new ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile();
            ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile aa = new ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile();

            string userRole = string.Empty;
            userRole = getUserRole();

            Int64 AgentID = 0;
            Int32 AgentTypeID = 0;
            Int64 RenewalAgentID = 0;
            Int32 RenewalAgentSequenceID = 0;
            Int32 RenewalAgentYearID = 0;

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                AgentID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                AgentTypeID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                RenewalAgentID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                RenewalAgentSequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                RenewalAgentYearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;
            int? BusinessPlace_AddressSubDivisionCode = 0;
            int? IsDraftMemberCode = 1;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.AgentOtherIndProfile = sdb.Display_AuthDesk_RenewalAgent_OtherThanIndDetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            foreach (var item in aa.AgentOtherIndProfile)
            {
                statecode = item.RegOffice_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.RegOffice_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

                BusinessPlace_AddressSubDivisionCode = (String.IsNullOrEmpty(item.B_Column) ? 0 : Convert.ToInt32(item.B_Column));
                aa.BusinessPlace_AddressSubDivision = objdis.SubDivision_Name(BusinessPlace_AddressSubDivisionCode);


                aa.RenewalAgent_IndexID = item.RenewalAgent_IndexID;
                aa.RenewalAgent_ID = item.RenewalAgent_ID;
                aa.IsActive = item.IsActive;
                aa.IsActiveProvider = item.IsActiveProvider;
                aa.IsDraft = item.IsDraft;
                aa.IsLock = item.IsLock;

                aa.IsDraftRenewalAgent = item.IsDraft;                
            }

            aa.Agent_OtherMember = sdb.Display_AuthDesk_RenewalAgent_OthermemberDetail(AgentID, AgentTypeID, RenewalAgentID, RenewalAgentSequenceID, RenewalAgentYearID, userRole);
            for (var i = 0; i < aa.Agent_OtherMember.Count; i++)
            {
                DistrictCode = aa.Agent_OtherMember[i].OfficeComm_AddressDistrictCode;
                aa.Agent_OtherMember[i].OfficeComm_AddressDistName = objdis.District_Name(DistrictCode);

                statecode = aa.Agent_OtherMember[i].OfficeComm_AddressStateCode;
                aa.Agent_OtherMember[i].OfficeComm_AddressStateName = objdis.State_Name(statecode);

                IsDraftMemberCode = aa.Agent_OtherMember[i].IsDraft;
            }
            aa.IsDraftOtherMember = Convert.ToInt32(IsDraftMemberCode);

            if (Session["zapRnAgentDiaryNumber"] != null)
            {
                string RnAgentRN = Session["zapRnAgentRegistrationNumber"].ToString();
                string RnAgentDN = Session["zapRnAgentDiaryNumber"].ToString();
                string RnAgentNM = Session["zapRnAgentName"].ToString();
                Int64? AgtID = Convert.ToInt64(Session["zapAgentID"]);
                Int32? AgtTypeID = Convert.ToInt32(Session["zapAgentTypeID"]);
                Int64? RnAgentID = Convert.ToInt64(Session["zapRnAgentID"]);
                Int32? RnAgentSeqID = Convert.ToInt32(Session["zapRnAgentSeqID"]);
                Int32? RnAgentYrID = Convert.ToInt32(Session["zapRnAgentYrID"]);
                DateTime? RnAgentLMOn = Convert.ToDateTime(Session["zapRnAgentLastModifiedOn"]);

                aa.zapRelated_Agent_ID = (AgtID != null) ? Convert.ToInt64(AgtID) : 0;
                aa.zapRelated_AgentType_ID = (AgtTypeID != null) ? Convert.ToInt32(AgtTypeID) : 0;
                aa.zapRelated_RenewalAgent_ID = (RnAgentID != null) ? Convert.ToInt64(RnAgentID) : 0;
                aa.zapRelated_RenewalAgent_SequenceID = (RnAgentSeqID != null) ? Convert.ToInt32(RnAgentSeqID) : 0;
                aa.zapRelated_RenewalAgent_YearID = (RnAgentYrID != null) ? Convert.ToInt32(RnAgentYrID) : 0;
                aa.zapRenewalAgent_DiaryNumber = (String.IsNullOrEmpty(RnAgentDN) ? "" : RnAgentDN);
                aa.zapRenewalAgent_RegistrationNumber = (String.IsNullOrEmpty(RnAgentRN) ? "" : RnAgentRN);
                aa.zapRenewalAgentName = (String.IsNullOrEmpty(RnAgentNM) ? "" : RnAgentNM);
                aa.zapRenewalAgentLastModifiedOn = RnAgentLMOn;
            }

            return View("Display_RenewalAgent_AgentOtherIndProfile", aa);
        }

        //Lock-Unlock Handler (Renewal-Agent Registration Details)             
        public JsonResult LockUnlockHandler_RenewalAgentRegistration(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID)
        { 
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Renewal of Agent (OTI) Registration details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile sdb = new ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_OtherThanIndDetail(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked renewal of agent registration details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked renewal of agent registration details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }

        //Lock-Unlock Handler (Renewal-Agent Members Details)
        public JsonResult LockUnlockHandler_RenewalAgentOtherMember(string parmAgentId, string parmAgentTypeId, string parmRenewalAgentId, string parmSequenceId, string parmYearId, string parmLockUnlock, string parmIndexID)
        {
            Int32 retvalueLockUnlock = 0;
            Int32 retValue = 1;
            try
            {
                #region Parameters
                Int64 AgentCode = 0;
                Int32 AgentTypeCode = 0;
                Int64 RenewalAgentCode = 0;
                Int32 RnASequenceCode = 0;
                Int32 RnAYearCode = 0;
                Int64 IndexID = 0;
                Int32 IsDraftCode = 0;
                string userName = string.Empty;
                string userID = string.Empty;
                string RelatedRemarksIfAny = string.Empty;
                string RelatedLockUnlockMsg = string.Empty;

                if (parmAgentId != string.Empty)
                {
                    AgentCode = Convert.ToInt64(parmAgentId);
                }
                if (parmAgentTypeId != string.Empty)
                {
                    AgentTypeCode = Convert.ToInt32(parmAgentTypeId);
                }
                if (parmRenewalAgentId != string.Empty)
                {
                    RenewalAgentCode = Convert.ToInt64(parmRenewalAgentId);
                }
                if (parmSequenceId != string.Empty)
                {
                    RnASequenceCode = Convert.ToInt32(parmSequenceId);
                }
                if (parmYearId != string.Empty)
                {
                    RnAYearCode = Convert.ToInt32(parmYearId);
                }
                if (parmLockUnlock != string.Empty)
                {
                    IsDraftCode = Convert.ToInt32(parmLockUnlock);
                }
                if (parmIndexID != string.Empty)
                {
                    IndexID = Convert.ToInt32(parmIndexID);
                }
                userID = User.Identity.GetUserId();
                userName = User.Identity.GetUserName();
                RelatedRemarksIfAny = "Other Member (Renewal-Agent) details";
                switch (IsDraftCode)
                {
                    case 1:
                        RelatedLockUnlockMsg = "Unlock request";
                        break;
                    case 5:
                        RelatedLockUnlockMsg = "Lock request";
                        break;
                    default:
                        RelatedLockUnlockMsg = "others";
                        break;
                }
                #endregion

                ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile sdb = new ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile();
                retvalueLockUnlock = sdb.Update_LockUnLockHandler_RenewalAgent_OthermemberDetail(AgentCode, AgentTypeCode, RenewalAgentCode, RnASequenceCode, RnAYearCode, IndexID, IsDraftCode, userName, userID, RelatedRemarksIfAny, RelatedLockUnlockMsg);
            }
            catch (Exception ex)
            {
                string retex = ex.ToString();
                retValue = 0;
            }

            Int32 IsDraft = retvalueLockUnlock; // 5;            
            Int32 parmStatusCode = 102;
            string parmStatus = "Request processed! Invalid.";
            if (retValue == 1)
            {
                if (IsDraft == 1)
                {
                    parmStatusCode = 101;
                    parmStatus = "Successfully locked Other Member details.";
                }
                else if (IsDraft == 5)
                {
                    parmStatusCode = 105;
                    parmStatus = "Successfully un-locked Other Member details.";
                }
                else if (IsDraft == 6)
                {
                    parmStatusCode = 106;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
                else
                {
                    parmStatusCode = 100;
                    parmStatus = "Invalid lock-Unlock Action.";
                }
            }
            else
            {
                parmStatusCode = 102;
                parmStatus = "Request processed! Failed.";
            }

            return Json(new
            {
                statusCode = parmStatusCode,
                status = parmStatus,
                remarks = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        //Agent Renewal of Registration -- End
    }
}
