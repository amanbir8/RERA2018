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
using CRUD.Models.Dashboard;
using Newtonsoft.Json.Linq;

namespace CRUD.Controllers.Dashboard
{
    [Authorize]
    [Authorize(Roles = "SecretaryRERA, Programmer, Authority, ManagerDesk, PStoMembers, LegalAdvisorDesk, HelpDesk")]
    public class DashboardController : Controller
    {

        #region Project Dashboard
        [HttpGet]
        public ActionResult ProjectByAODashboard()
        {
            ClsPrp_DashboardDesk_FactsFigure objprp = new ClsPrp_DashboardDesk_FactsFigure();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            Int64 pIndex_ID = 0;
            objprp.prpFactsFigure = sdb.Display_DashboardDesk_FactsFigureDetails(pIndex_ID);
            foreach (var item in objprp.prpFactsFigure)
            {
                objprp.Number_RegisteredProjects = item.Number_RegisteredProjects;
                objprp.Number_RegisteredAgents = item.Number_RegisteredAgents;
                objprp.Number_DecidedComplaints = item.Number_DecidedComplaints;
                objprp.Number_PendingProjects = item.Number_PendingProjects;

                objprp.Number_SectionThreeOneComplaints = item.Number_SectionThreeOneComplaints;
                objprp.Number_SectionFiveNineComplaints = item.Number_SectionFiveNineComplaints;
                objprp.Number_PaymentTransactions = item.Number_PaymentTransactions;
                objprp.Number_TotalAmount = item.Number_TotalAmount;

                objprp.Title_RegisteredProjects = item.Title_RegisteredProjects;
                objprp.Title_RegisteredAgents = item.Title_RegisteredAgents;
                objprp.Title_DecidedComplaints = item.Title_DecidedComplaints;
                objprp.Title_PendingProjects = item.Title_PendingProjects;

                objprp.Title_SectionThreeOneComplaints = item.Title_SectionThreeOneComplaints;
                objprp.Title_SectionFiveNineComplaints = item.Title_SectionFiveNineComplaints;
                objprp.Title_PaymentTransactions = item.Title_PaymentTransactions;
                objprp.Title_TotalAmount = item.Title_TotalAmount;

                objprp.A_Column = item.A_Column;
                objprp.B_Column = item.B_Column;
                objprp.C_Column = item.C_Column;
                objprp.D_Column = item.D_Column;
                objprp.CreatedOn = item.CreatedOn;
            }

            return View("ProjectByAODashboard", objprp);
        }

        public JsonResult GetProjectLiveReportsDataByAOdetails(string IndexId)
        {
            string Id = IndexId;
            Int64 pIndex_ID = 0;

            ClsPrp_DashboardDesk_LiveProjectsSeries objprp = new ClsPrp_DashboardDesk_LiveProjectsSeries();
            ClsPrp_DashboardDesk_LiveProjectsSubSeries objSubSeriesPrp = new ClsPrp_DashboardDesk_LiveProjectsSubSeries();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            objprp.prpLiveProjectsSeries = sdb.Display_DashboardDesk_LiveProjectsNumberDetails(pIndex_ID);
            foreach (var item in objprp.prpLiveProjectsSeries)
            {
                objprp.NumberNewApplications = item.NumberNewApplications;
                objprp.NumberInProcessApplications = item.NumberInProcessApplications;
                objprp.NumberChecklistPreparedApplications = item.NumberChecklistPreparedApplications;
                objprp.NumberReviewChecklistApplications = item.NumberReviewChecklistApplications;
                objprp.NumberApprovedApplications = item.NumberApprovedApplications;

                objprp.NumberRejectedApplications = item.NumberRejectedApplications;
                objprp.NumberWithdrawnApplications = item.NumberWithdrawnApplications;
                objprp.NumberOfflineRegisteredProjectsShiftedPublicView = item.NumberOfflineRegisteredProjectsShiftedPublicView;
                objprp.NumberOfflineRegdProjectsPendingUploads = item.NumberOfflineRegdProjectsPendingUploads;
                objprp.NumberPublicViewProjects = item.NumberPublicViewProjects;

                objprp.NumberPublicViewProjectsWebpage = item.NumberPublicViewProjectsWebpage;
                objprp.NumberProjectExtensionApplications = item.NumberProjectExtensionApplications;
                objprp.NumberProjectAnnualReportonStatementofAccounts = item.NumberProjectAnnualReportonStatementofAccounts;
                objprp.NumberTotalRegisteredProjects = item.NumberTotalRegisteredProjects;

                objprp.valueInCompleteApplications = item.valueInCompleteApplications;
                objprp.valueReSubmittedApplications = item.valueReSubmittedApplications;
                objprp.valueDueForProjectExtension = item.valueDueForProjectExtension;
                objprp.valueCompletionCertificate = item.valueCompletionCertificate;
                objprp.valueTotal = item.valueTotal;
            }

            string subSeriesNewApplicationsS1 = string.Empty;
            int subSeriesNewApplicationsIndex = 0;
            string subSeriesReSubmittedApplicationsS1 = string.Empty;
            int subSeriesReSubmittedApplicationsIndex = 0;
            string subSeriesInCompleteApplicationsS1 = string.Empty;
            int subSeriesInCompleteApplicationsIndex = 0;
            string subSeriesInProcessApplicationsS1 = string.Empty;
            int subSeriesInProcessApplicationsIndex = 0;

            string subSeriesDueProjectExtensionsS1 = string.Empty;
            int subSeriesDueProjectExtensionsIndex = 0;
            string subSeriesCompletionCertificatesS1 = string.Empty;
            int subSeriesCompletionCertificatesIndex = 0;
            string subSeriesRegisteredProjectsS1 = string.Empty;
            int subSeriesRegisteredProjectsIndex = 0;

            objSubSeriesPrp.prpLiveProjectsSubSeries = sdb.Display_DashboardDesk_LiveProjectsSubSeriesCharts(pIndex_ID);
            foreach (var item in objSubSeriesPrp.prpLiveProjectsSubSeries)
            {
                objSubSeriesPrp.NumberSubSeriesCode = item.NumberSubSeriesCode;
                objSubSeriesPrp.NameSubSeriesCode = item.NameSubSeriesCode;
                objSubSeriesPrp.NameSubSeriesActivityTitle = item.NameSubSeriesActivityTitle;
                objSubSeriesPrp.MonthSubSeriesCode = item.MonthSubSeriesCode;
                objSubSeriesPrp.YearSubSeriesCode = item.YearSubSeriesCode;
                objSubSeriesPrp.NumberTotalApplications = item.NumberTotalApplications;
                objSubSeriesPrp.NumberExtraA = item.NumberExtraA;
                objSubSeriesPrp.NumberExtraB = item.NumberExtraB;

                // New Applications
                if (item.NumberSubSeriesCode == 1101)
                {
                    if (subSeriesNewApplicationsS1 == string.Empty)
                    {
                        subSeriesNewApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesNewApplicationsS1 = subSeriesNewApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesNewApplicationsIndex;
                }
                // ReSubmitted Applications
                if (item.NumberSubSeriesCode == 1102)
                {
                    if (subSeriesReSubmittedApplicationsS1 == string.Empty)
                    {
                        subSeriesReSubmittedApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesReSubmittedApplicationsS1 = subSeriesReSubmittedApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesReSubmittedApplicationsIndex;
                }
                // In-Process Applications
                if (item.NumberSubSeriesCode == 1106)
                {
                    //[[ \"{0}\", 13 ],[ \"{1}\", 17 ],[ \"{2}\", 34 ],[ \"{3}\", 30 ],[ \"{4}\", 0 ]]
                    //"January", "February", "March", "April", "May"
                    if (subSeriesInProcessApplicationsS1 == string.Empty)
                    {
                        subSeriesInProcessApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesInProcessApplicationsS1 = subSeriesInProcessApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesInProcessApplicationsIndex;
                }
                // In-Complete Applications
                if (item.NumberSubSeriesCode == 1107)
                {
                    if (subSeriesInCompleteApplicationsS1 == string.Empty)
                    {
                        subSeriesInCompleteApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesInCompleteApplicationsS1 = subSeriesInCompleteApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesInCompleteApplicationsIndex;
                }

                // Due Project Extension Applications
                if (item.NumberSubSeriesCode == 1109)
                {
                    if (subSeriesDueProjectExtensionsS1 == string.Empty)
                    {
                        subSeriesDueProjectExtensionsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesDueProjectExtensionsS1 = subSeriesDueProjectExtensionsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesDueProjectExtensionsIndex;
                }
                // Completion Certificate Applications
                if (item.NumberSubSeriesCode == 1110)
                {
                    if (subSeriesCompletionCertificatesS1 == string.Empty)
                    {
                        subSeriesCompletionCertificatesS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesCompletionCertificatesS1 = subSeriesCompletionCertificatesS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesCompletionCertificatesIndex;
                }
                // Registered Projects
                if (item.NumberSubSeriesCode == 1111)
                {
                    if (subSeriesRegisteredProjectsS1 == string.Empty)
                    {
                        subSeriesRegisteredProjectsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesRegisteredProjectsS1 = subSeriesRegisteredProjectsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    ++subSeriesRegisteredProjectsIndex;
                }


            }

            var barChartModel = new ClsPrp_DashboardDesk_ChartsLiveReportProjects<int>
            {
                LiveReportProjectsData = new List<ClsPrp_DashboardDesk_LiveReportProjectSeries<int>>
                {
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "New Applications", y = objprp.prpLiveProjectsSeries[0].NumberNewApplications, drilldown = "Link-NewApps" },
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "In-Process Applications", y = objprp.prpLiveProjectsSeries[0].NumberInProcessApplications, drilldown = "Link-InProcessApps" },
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "In-Complete Applications", y = objprp.prpLiveProjectsSeries[0].valueInCompleteApplications, drilldown = "Link-InCompleteApps"},
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "ReSubmitted Applications", y = objprp.prpLiveProjectsSeries[0].valueReSubmittedApplications, drilldown = "Link-ReSubmittedApps" },
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "Due Project Extension", y = objprp.prpLiveProjectsSeries[0].valueDueForProjectExtension, drilldown = "Link-DueProjectExtnApps"},
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "Completion Certificate", y = objprp.prpLiveProjectsSeries[0].valueCompletionCertificate, drilldown = "Link-CompletionCertApps" },
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "Registered Projects", y = objprp.prpLiveProjectsSeries[0].NumberTotalRegisteredProjects, drilldown = "Link-RegdProjects" },
                    new ClsPrp_DashboardDesk_LiveReportProjectSeries<int> { name = "Total", y = objprp.prpLiveProjectsSeries[0].valueTotal, drilldown = null}
                },
                LiveReportProjectsDrilldownData = new List<ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int>>
                {
                    //data = String.Format("[[ \"{0}\", 13 ],[ \"{1}\", 17 ],[ \"{2}\", 34 ],[ \"{3}\", 30 ],[ \"{4}\", 0 ]]", "January", "February", "March", "April", "May") },
                    //data = String.Format("[[ \"{0}\", 0.1 ],[ \"{1}\", 1.3 ]]", "April", "March") }
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "New Applications", id = "Link-NewApps", data = "[" + subSeriesNewApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "In-Process Applications", id = "Link-InProcessApps", data = "[" + subSeriesInProcessApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "In-Complete Applications", id = "Link-InCompleteApps", data = "[" + subSeriesInCompleteApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "ReSubmitted Applications", id = "Link-ReSubmittedApps", data = "[" + subSeriesReSubmittedApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "Projects Due for Project Extensions", id = "Link-DueProjectExtnApps", data = "[" + subSeriesDueProjectExtensionsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "Projects with Completion Certificate", id = "Link-CompletionCertApps", data = "[" + subSeriesCompletionCertificatesS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<int> { name = "Registered Projects", id = "Link-RegdProjects", data = "[" + subSeriesRegisteredProjectsS1 + "]" },
                },
                SummaryStatusProjectsData = new List<ClsPrp_DashboardDesk_SummaryStatusProjects<int>>
                {
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "New Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberNewApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "In Process Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberInProcessApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Checklist Prepared Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberChecklistPreparedApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Review Checklist Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberReviewChecklistApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Approved Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberApprovedApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Rejected Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberRejectedApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Withdrawn Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberWithdrawnApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Offline Registered Project(s)[Shifted to Public View]", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberOfflineRegisteredProjectsShiftedPublicView) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Offline Registered Project(s)[Pending Uploads]", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberOfflineRegdProjectsPendingUploads) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Public View Project(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberPublicViewProjects) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Public View Project(s)[web-page]", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberPublicViewProjectsWebpage) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Project Extension Application(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberProjectExtensionApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Project Annual Report on Statement of Accounts", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberProjectAnnualReportonStatementofAccounts) },
                    new ClsPrp_DashboardDesk_SummaryStatusProjects<int> { name = "Total Registered Project(s)", value = Convert.ToInt32(objprp.prpLiveProjectsSeries[0].NumberTotalRegisteredProjects) }
                }
            };
            return Json(barChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPieChartProjectLiveReportsDataByAOdetails(string IndexId)
        {
            string Id = IndexId;
            Int64 pIndex_ID = 0;

            ClsPrp_DashboardDesk_LiveProjectsPieCharts objprp = new ClsPrp_DashboardDesk_LiveProjectsPieCharts();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            objprp.prpLiveProjectsPieCharts = sdb.Display_DashboardDesk_LiveProjectsPieChartsDetails(pIndex_ID);
            foreach (var item in objprp.prpLiveProjectsPieCharts)
            {
                objprp.NumberZoneCode = item.NumberZoneCode;
                objprp.NameZoneCode = item.NameZoneCode;
                objprp.AreaZoneUnderProjects = item.AreaZoneUnderProjects;
                objprp.NumberProjectsUnderZone = item.NumberProjectsUnderZone;
                objprp.AmountFeeRegistrations = item.AmountFeeRegistrations;

                objprp.NumberExtraA = item.NumberExtraA;
                objprp.NumberExtraB = item.NumberExtraB;
                objprp.NumberExtraC = item.NumberExtraC;
            }
            if (objprp.prpLiveProjectsPieCharts.Count == 8)
            {
                var pieChartModel = new ClsPrp_DashboardDesk_PieChartsLiveReportProjects<int>
                {
                    LiveReportProjectsPieChartsData = new List<ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int>>
                    {
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-1</span>", y = objprp.prpLiveProjectsPieCharts[0].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[0].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[0].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-2</span>", y = objprp.prpLiveProjectsPieCharts[1].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[1].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[1].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-3</span>", y = objprp.prpLiveProjectsPieCharts[2].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[2].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[2].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-4</span>", y = objprp.prpLiveProjectsPieCharts[3].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[3].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[3].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-5</span>", y = objprp.prpLiveProjectsPieCharts[4].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[4].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[4].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-6</span>", y = objprp.prpLiveProjectsPieCharts[5].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[5].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[5].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-7</span>", y = objprp.prpLiveProjectsPieCharts[6].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[6].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[6].AmountFeeRegistrations },
                        new ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">Zone-8</span>", y = objprp.prpLiveProjectsPieCharts[7].AreaZoneUnderProjects, z = Convert.ToInt32(objprp.prpLiveProjectsPieCharts[7].NumberProjectsUnderZone), amount = objprp.prpLiveProjectsPieCharts[7].AmountFeeRegistrations }
                    }
                };
                return Json(pieChartModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var pieChartModel = string.Empty;
                return Json(pieChartModel, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ProjectGeoTagByAODashboard()
        {
            ClsPrp_DashboardDesk_FactsFigure objprp = new ClsPrp_DashboardDesk_FactsFigure();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            Int64 pIndex_ID = 0;
            objprp.prpFactsFigure = sdb.Display_DashboardDesk_FactsFigureDetails(pIndex_ID);
            foreach (var item in objprp.prpFactsFigure)
            {
                objprp.Number_RegisteredProjects = item.Number_RegisteredProjects;
                objprp.Number_RegisteredAgents = item.Number_RegisteredAgents;
                objprp.Number_DecidedComplaints = item.Number_DecidedComplaints;
                objprp.Number_PendingProjects = item.Number_PendingProjects;

                objprp.Number_SectionThreeOneComplaints = item.Number_SectionThreeOneComplaints;
                objprp.Number_SectionFiveNineComplaints = item.Number_SectionFiveNineComplaints;
                objprp.Number_PaymentTransactions = item.Number_PaymentTransactions;
                objprp.Number_TotalAmount = item.Number_TotalAmount;

                objprp.Title_RegisteredProjects = item.Title_RegisteredProjects;
                objprp.Title_RegisteredAgents = item.Title_RegisteredAgents;
                objprp.Title_DecidedComplaints = item.Title_DecidedComplaints;
                objprp.Title_PendingProjects = item.Title_PendingProjects;

                objprp.Title_SectionThreeOneComplaints = item.Title_SectionThreeOneComplaints;
                objprp.Title_SectionFiveNineComplaints = item.Title_SectionFiveNineComplaints;
                objprp.Title_PaymentTransactions = item.Title_PaymentTransactions;
                objprp.Title_TotalAmount = item.Title_TotalAmount;

                objprp.A_Column = item.A_Column;
                objprp.B_Column = item.B_Column;
                objprp.C_Column = item.C_Column;
                objprp.D_Column = item.D_Column;
                objprp.CreatedOn = item.CreatedOn;
            }

            return View("ProjectGeoTagByAODashboard", objprp);
        }
        #endregion

        #region RealEstate Agent Dashboard
        [HttpGet]
        public ActionResult RealEstateAgentByAODashboard()
        {
            ClsPrp_DashboardDesk_FactsFigure objprp = new ClsPrp_DashboardDesk_FactsFigure();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            Int64 pIndex_ID = 0;
            objprp.prpFactsFigure = sdb.Display_DashboardDesk_FactsFigureDetails(pIndex_ID);
            foreach (var item in objprp.prpFactsFigure)
            {
                objprp.Number_RegisteredProjects = item.Number_RegisteredProjects;
                objprp.Number_RegisteredAgents = item.Number_RegisteredAgents;
                objprp.Number_DecidedComplaints = item.Number_DecidedComplaints;
                objprp.Number_PendingProjects = item.Number_PendingProjects;

                objprp.Number_SectionThreeOneComplaints = item.Number_SectionThreeOneComplaints;
                objprp.Number_SectionFiveNineComplaints = item.Number_SectionFiveNineComplaints;
                objprp.Number_PaymentTransactions = item.Number_PaymentTransactions;
                objprp.Number_TotalAmount = item.Number_TotalAmount;

                objprp.Title_RegisteredProjects = item.Title_RegisteredProjects;
                objprp.Title_RegisteredAgents = item.Title_RegisteredAgents;
                objprp.Title_DecidedComplaints = item.Title_DecidedComplaints;
                objprp.Title_PendingProjects = item.Title_PendingProjects;

                objprp.Title_SectionThreeOneComplaints = item.Title_SectionThreeOneComplaints;
                objprp.Title_SectionFiveNineComplaints = item.Title_SectionFiveNineComplaints;
                objprp.Title_PaymentTransactions = item.Title_PaymentTransactions;
                objprp.Title_TotalAmount = item.Title_TotalAmount;

                objprp.A_Column = item.A_Column;
                objprp.B_Column = item.B_Column;
                objprp.C_Column = item.C_Column;
                objprp.D_Column = item.D_Column;
                objprp.CreatedOn = item.CreatedOn;
            }

            return View("RealEstateAgentByAODashboard", objprp);
        }

        public JsonResult GetRealEstateAgentLiveReportsDataByAOdetails(string IndexId)
        {
            string Id = IndexId;
            Int64 pIndex_ID = 0;

            ClsPrp_DashboardDesk_LiveAgentsSeries objprp = new ClsPrp_DashboardDesk_LiveAgentsSeries();
            ClsPrp_DashboardDesk_LiveAgentsSubSeries objSubSeriesPrp = new ClsPrp_DashboardDesk_LiveAgentsSubSeries();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            objprp.prpLiveAgentsSeries = sdb.Display_DashboardDesk_LiveRealEstateAgentsNumberDetails(pIndex_ID);
            foreach (var item in objprp.prpLiveAgentsSeries)
            {
                objprp.NumberNewApplications = item.NumberNewApplications;
                objprp.NumberInProcessApplications = item.NumberInProcessApplications;
                objprp.NumberChecklistPreparedApplications = item.NumberChecklistPreparedApplications;
                objprp.NumberReviewChecklistApplications = item.NumberReviewChecklistApplications;
                objprp.NumberApprovedApplications = item.NumberApprovedApplications;

                objprp.NumberRejectedApplications = item.NumberRejectedApplications;
                objprp.NumberWithdrawnApplications = item.NumberWithdrawnApplications;
                objprp.NumberOfflineRegisteredAgentsShiftedPublicView = item.NumberOfflineRegisteredAgentsShiftedPublicView;
                objprp.NumberOfflineRegdAgentsPendingUploads = item.NumberOfflineRegdAgentsPendingUploads;
                objprp.NumberPublicViewAgents = item.NumberPublicViewAgents;

                objprp.NumberPublicViewAgentsWebpage = item.NumberPublicViewAgentsWebpage;
                objprp.NumberAgentsRenewalApplications = item.NumberAgentsRenewalApplications;
                objprp.NumberAgentsExtraValue = item.NumberAgentsExtraValue;
                objprp.NumberTotalRegisteredAgents = item.NumberTotalRegisteredAgents;

                objprp.valueInCompleteApplications = item.valueInCompleteApplications;
                objprp.valueReSubmittedApplications = item.valueReSubmittedApplications;
                objprp.valueDueForAgentsRenewal = item.valueDueForAgentsRenewal;
                objprp.valueCompletionCertificate = item.valueCompletionCertificate;
                objprp.valueTotal = item.valueTotal;
            }

            string subSeriesNewApplicationsS1 = string.Empty;
            string subSeriesReSubmittedApplicationsS1 = string.Empty;
            string subSeriesInCompleteApplicationsS1 = string.Empty;
            string subSeriesInProcessApplicationsS1 = string.Empty;
            string subSeriesDueAgentRenewalsS1 = string.Empty;
            string subSeriesCompletionCertificatesS1 = string.Empty;
            string subSeriesRegisteredAgentsS1 = string.Empty;

            objSubSeriesPrp.prpLiveAgentsSubSeries = sdb.Display_DashboardDesk_LiveRealEstateAgentsSubSeriesCharts(pIndex_ID);
            foreach (var item in objSubSeriesPrp.prpLiveAgentsSubSeries)
            {
                objSubSeriesPrp.NumberSubSeriesCode = item.NumberSubSeriesCode;
                objSubSeriesPrp.NameSubSeriesCode = item.NameSubSeriesCode;
                objSubSeriesPrp.NameSubSeriesActivityTitle = item.NameSubSeriesActivityTitle;
                objSubSeriesPrp.MonthSubSeriesCode = item.MonthSubSeriesCode;
                objSubSeriesPrp.YearSubSeriesCode = item.YearSubSeriesCode;
                objSubSeriesPrp.NumberTotalApplications = item.NumberTotalApplications;
                objSubSeriesPrp.NumberExtraA = item.NumberExtraA;
                objSubSeriesPrp.NumberExtraB = item.NumberExtraB;

                // New Applications
                if (item.NumberSubSeriesCode == 1101)
                {
                    if (subSeriesNewApplicationsS1 == string.Empty)
                    {
                        subSeriesNewApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesNewApplicationsS1 = subSeriesNewApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }
                // ReSubmitted Applications
                if (item.NumberSubSeriesCode == 1102)
                {
                    if (subSeriesReSubmittedApplicationsS1 == string.Empty)
                    {
                        subSeriesReSubmittedApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesReSubmittedApplicationsS1 = subSeriesReSubmittedApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }
                // In-Process Applications
                if (item.NumberSubSeriesCode == 1106)
                {
                    if (subSeriesInProcessApplicationsS1 == string.Empty)
                    {
                        subSeriesInProcessApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesInProcessApplicationsS1 = subSeriesInProcessApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }
                // In-Complete Applications
                if (item.NumberSubSeriesCode == 1107)
                {
                    if (subSeriesInCompleteApplicationsS1 == string.Empty)
                    {
                        subSeriesInCompleteApplicationsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesInCompleteApplicationsS1 = subSeriesInCompleteApplicationsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }

                // Due Agent Renewal Applications
                if (item.NumberSubSeriesCode == 1109)
                {
                    if (subSeriesDueAgentRenewalsS1 == string.Empty)
                    {
                        subSeriesDueAgentRenewalsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesDueAgentRenewalsS1 = subSeriesDueAgentRenewalsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }
                // Completion Certificate Applications
                if (item.NumberSubSeriesCode == 1110)
                {
                    if (subSeriesCompletionCertificatesS1 == string.Empty)
                    {
                        subSeriesCompletionCertificatesS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesCompletionCertificatesS1 = subSeriesCompletionCertificatesS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }
                // Registered Projects
                if (item.NumberSubSeriesCode == 1111)
                {
                    if (subSeriesRegisteredAgentsS1 == string.Empty)
                    {
                        subSeriesRegisteredAgentsS1 = "[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                    else
                    {
                        subSeriesRegisteredAgentsS1 = subSeriesRegisteredAgentsS1 + ",[ \"" + item.NameSubSeriesActivityTitle + "-" + item.YearSubSeriesCode.ToString() + "\"," + item.NumberTotalApplications.ToString() + " ]";
                    }
                }
            }

            var barChartModel = new ClsPrp_DashboardDesk_ChartsLiveReportAgents<int>
            {
                LiveReportAgentsData = new List<ClsPrp_DashboardDesk_LiveReportAgentSeries<int>>
                {
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "New Applications", y = objprp.prpLiveAgentsSeries[0].NumberNewApplications, drilldown = "Link-NewApps" },
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "In-Process Applications", y = objprp.prpLiveAgentsSeries[0].NumberInProcessApplications, drilldown = "Link-InProcessApps" },
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "In-Complete Applications", y = objprp.prpLiveAgentsSeries[0].valueInCompleteApplications, drilldown = "Link-InCompleteApps"},
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "ReSubmitted Applications", y = objprp.prpLiveAgentsSeries[0].valueReSubmittedApplications, drilldown = "Link-ReSubmittedApps" },
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "Due for Agents Renewal", y = objprp.prpLiveAgentsSeries[0].valueDueForAgentsRenewal, drilldown = "Link-DueAgentExtnApps"},
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "Renewal Applications", y = objprp.prpLiveAgentsSeries[0].NumberAgentsRenewalApplications, drilldown = "Link-RenewalApps" },
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "Registered Agents", y = objprp.prpLiveAgentsSeries[0].NumberTotalRegisteredAgents, drilldown = "Link-RegdAgents" },
                    new ClsPrp_DashboardDesk_LiveReportAgentSeries<int> { name = "Total", y = objprp.prpLiveAgentsSeries[0].valueTotal, drilldown = null}
                },
                LiveReportAgentsDrilldownData = new List<ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int>>
                {
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "New Applications", id = "Link-NewApps", data = "[" + subSeriesNewApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "In-Process Applications", id = "Link-InProcessApps", data = "[" + subSeriesInProcessApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "In-Complete Applications", id = "Link-InCompleteApps", data = "[" + subSeriesInCompleteApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "ReSubmitted Applications", id = "Link-ReSubmittedApps", data = "[" + subSeriesReSubmittedApplicationsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "Due Renewal for Real Estate Agents", id = "Link-DueAgentExtnApps", data = "[" + subSeriesDueAgentRenewalsS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "Renewal Applications", id = "Link-RenewalApps", data = "[" + subSeriesCompletionCertificatesS1 + "]" },
                    new ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<int> { name = "Registered Real Estate Agents", id = "Link-RegdAgents", data = "[" + subSeriesRegisteredAgentsS1 + "]" },
                },
                SummaryStatusAgentsData = new List<ClsPrp_DashboardDesk_SummaryStatusAgents<int>>
                {
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "New Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberNewApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "In Process Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberInProcessApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Checklist Prepared Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberChecklistPreparedApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Review Checklist Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberReviewChecklistApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Approved Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberApprovedApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Rejected Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberRejectedApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Withdrawn Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberWithdrawnApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Offline Registered Agent(s)[Shifted to Public View]", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberOfflineRegisteredAgentsShiftedPublicView) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Offline Registered Agent(s)[Pending Uploads]", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberOfflineRegdAgentsPendingUploads) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Public View Agent(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberPublicViewAgents) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Public View Agent(s)[web-page]", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberPublicViewAgentsWebpage) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Agents Renwal Application(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberAgentsRenewalApplications) },
                    new ClsPrp_DashboardDesk_SummaryStatusAgents<int> { name = "Total Registered Agent(s)", value = Convert.ToInt32(objprp.prpLiveAgentsSeries[0].NumberTotalRegisteredAgents) }
                }
            };
            return Json(barChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPieChartRealEstateAgentLiveReportsDataByAOdetails(string IndexId)
        {
            string Id = IndexId;
            Int64 pIndex_ID = 0;

            ClsPrp_DashboardDesk_LiveAgentsPieCharts objprp = new ClsPrp_DashboardDesk_LiveAgentsPieCharts();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            objprp.prpLiveAgentsPieCharts = sdb.Display_DashboardDesk_LiveRealEstateAgentsPieChartsDetails(pIndex_ID);

            var pieChartValue = new ClsPrp_DashboardDesk_LiveReportAgentPieChartsSeries<int>();
            var pieChartModel = new ClsPrp_DashboardDesk_PieChartsLiveReportAgents<int>
            {
                LiveReportAgentsPieChartsData = new List<ClsPrp_DashboardDesk_LiveReportAgentPieChartsSeries<int>>()
            };

            foreach (var item in objprp.prpLiveAgentsPieCharts)
            {
                objprp.NumberZoneCode = item.NumberZoneCode;
                objprp.NameZoneCode = item.NameZoneCode;
                objprp.PopulationPercentageUnderZone = item.PopulationPercentageUnderZone;
                objprp.NumberAgentsUnderZone = item.NumberAgentsUnderZone;
                objprp.AmountFeeRegistrations = item.AmountFeeRegistrations;

                objprp.NumberExtraA = item.NumberExtraA;
                objprp.NumberExtraB = item.NumberExtraB;
                objprp.NumberExtraC = item.NumberExtraC;

                pieChartValue = new ClsPrp_DashboardDesk_LiveReportAgentPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + item.NameZoneCode.ToString() + "</span>", y = item.PopulationPercentageUnderZone, agents = item.NumberAgentsUnderZone };
                pieChartModel.LiveReportAgentsPieChartsData.Add(pieChartValue);
            }

            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Section Five-Nine Dashboard
        [HttpGet]
        public ActionResult SectionFiveNineByAODashboard()
        {
            ClsPrp_DashboardDesk_FactsFigure objprp = new ClsPrp_DashboardDesk_FactsFigure();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            Int64 pIndex_ID = 0;
            objprp.prpFactsFigure = sdb.Display_DashboardDesk_FactsFigureDetails(pIndex_ID);
            foreach (var item in objprp.prpFactsFigure)
            {
                objprp.Number_RegisteredProjects = item.Number_RegisteredProjects;
                objprp.Number_RegisteredAgents = item.Number_RegisteredAgents;
                objprp.Number_DecidedComplaints = item.Number_DecidedComplaints;
                objprp.Number_PendingProjects = item.Number_PendingProjects;

                objprp.Number_SectionThreeOneComplaints = item.Number_SectionThreeOneComplaints;
                objprp.Number_SectionFiveNineComplaints = item.Number_SectionFiveNineComplaints;
                objprp.Number_PaymentTransactions = item.Number_PaymentTransactions;
                objprp.Number_TotalAmount = item.Number_TotalAmount;

                objprp.Title_RegisteredProjects = item.Title_RegisteredProjects;
                objprp.Title_RegisteredAgents = item.Title_RegisteredAgents;
                objprp.Title_DecidedComplaints = item.Title_DecidedComplaints;
                objprp.Title_PendingProjects = item.Title_PendingProjects;

                objprp.Title_SectionThreeOneComplaints = item.Title_SectionThreeOneComplaints;
                objprp.Title_SectionFiveNineComplaints = item.Title_SectionFiveNineComplaints;
                objprp.Title_PaymentTransactions = item.Title_PaymentTransactions;
                objprp.Title_TotalAmount = item.Title_TotalAmount;

                objprp.A_Column = item.A_Column;
                objprp.B_Column = item.B_Column;
                objprp.C_Column = item.C_Column;
                objprp.D_Column = item.D_Column;
                objprp.CreatedOn = item.CreatedOn;
            }

            return View("SectionFiveNineByAODashboard", objprp);
        }

        public JsonResult GetSectionFiveNineLiveReportsDataByAOdetails(string IndexId)
        {
            string Id = IndexId;
            Int64 pIndex_ID = 0;

            ClsPrp_DashboardDesk_LiveSectionFiveNineSeries objprp = new ClsPrp_DashboardDesk_LiveSectionFiveNineSeries();
            ClsPrp_DashboardDesk_LiveSectionFiveNineSubSeries objSubSeriesPrp = new ClsPrp_DashboardDesk_LiveSectionFiveNineSubSeries();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();           
            
            objprp.prpLiveSectionFiveNineSeries = sdb.Display_DashboardDesk_LiveSectionFiveNinesNumberDetails(pIndex_ID);
            foreach (var item in objprp.prpLiveSectionFiveNineSeries)
            {
                objprp.NumberComplaintFiled = item.NumberComplaintFiled;
                objprp.NumberPendingWithAuthority = item.NumberPendingWithAuthority;
                objprp.NumberPendingForOrders = item.NumberPendingForOrders;
                objprp.NumberPendingWithManagerForComments = item.NumberPendingWithManagerForComments;

                objprp.NumberForIssuancePenalityNotices = item.NumberForIssuancePenalityNotices;
                objprp.NumberPendingShowCauseNotice = item.NumberPendingShowCauseNotice;
                objprp.NumberShowCauseNoticeIssuedForPenality = item.NumberShowCauseNoticeIssuedForPenality;
                objprp.NumberShowCauseNoticeIssuedForPenalityButNoneAppeared = item.NumberShowCauseNoticeIssuedForPenalityButNoneAppeared;
                objprp.NumberShowCauseNoticeIssuedForPenalityAndReceivedBackUnserved = item.NumberShowCauseNoticeIssuedForPenalityAndReceivedBackUnserved;

                objprp.NumberComplaintDecided = item.NumberComplaintDecided;
                objprp.NumberComplaintDecidedDueToProjectRegistrationIntialized = item.NumberComplaintDecidedDueToProjectRegistrationIntialized;
                objprp.NumberDisposeOf = item.NumberDisposeOf;
                objprp.NumberDismissedNonMaintainble = item.NumberDismissedNonMaintainble;
                objprp.NumberDuplicateMergeFile = item.NumberDuplicateMergeFile;

                objprp.NumberSentForDocumentaryEvidence = item.NumberSentForDocumentaryEvidence;
                objprp.NumberForSubmissionOfComplianceReport = item.NumberForSubmissionOfComplianceReport;
                objprp.NumberSentForDocumentaryEvidenceDefaulterPromoters = item.NumberSentForDocumentaryEvidenceDefaulterPromoters;

                objprp.NumberUnderConsideration = item.NumberUnderConsideration;
                objprp.NumberForAppearance = item.NumberForAppearance;
                objprp.NumberPersonalHearing = item.NumberPersonalHearing;
                objprp.NumberForArguments = item.NumberForArguments;
                objprp.NumberReplyAndDocument = item.NumberReplyAndDocument;

                objprp.NumberExParteProcedings = item.NumberExParteProcedings;
                objprp.NumberPendingForPublication = item.NumberPendingForPublication;
                objprp.NumberNoneAppearedAfterPublication = item.NumberNoneAppearedAfterPublication;
                objprp.NumberOrderForPublication = item.NumberOrderForPublication;
                objprp.NumberSentForPublication = item.NumberSentForPublication;
                objprp.NumberPublishedInNewpapers = item.NumberPublishedInNewpapers;

                objprp.valueColumnA = item.valueColumnA;
                objprp.valueColumnB = item.valueColumnB;
                objprp.valueColumnC = item.valueColumnC;
                objprp.valueColumnD = item.valueColumnD;
                objprp.valueColumnE = item.valueColumnE;
            }

            var barChartModel = new ClsPrp_DashboardDesk_ChartsLiveReportSectionFiveNine<int>
            {
                LiveReportSectionFiveNinesData = new List<ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int>>
                {
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "Complaint Filed(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberComplaintFiled, drilldown = null },
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "Under consideration(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberUnderConsideration, drilldown = null },
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "For Appearance(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberForAppearance, drilldown = null},
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "For Arguments(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberForArguments, drilldown = null },
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "Dispose of(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberDisposeOf, drilldown = null},
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "Complaint Decided(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberComplaintDecided, drilldown = null },
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "Show cause notice issued for penality(s)", y = objprp.prpLiveSectionFiveNineSeries[0].NumberShowCauseNoticeIssuedForPenality, drilldown = null },
                    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<int> { name = "Total", y = objprp.prpLiveSectionFiveNineSeries[0].valueColumnA, drilldown = null}
                },
                //LiveReportSectionFiveNineDrilldownData = new List<ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int>>
                //{
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "New Applications", id = "Link-NewApps", data = "[" + subSeriesNewApplicationsS1 + "]" },
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "In-Process Applications", id = "Link-InProcessApps", data = "[" + subSeriesInProcessApplicationsS1 + "]" },
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "In-Complete Applications", id = "Link-InCompleteApps", data = "[" + subSeriesInCompleteApplicationsS1 + "]" },
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "ReSubmitted Applications", id = "Link-ReSubmittedApps", data = "[" + subSeriesReSubmittedApplicationsS1 + "]" },
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "Due Renewal for Real Estate Agents", id = "Link-DueAgentExtnApps", data = "[" + subSeriesDueAgentRenewalsS1 + "]" },
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "Renewal Applications", id = "Link-RenewalApps", data = "[" + subSeriesCompletionCertificatesS1 + "]" },
                //    new ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<int> { name = "Registered Real Estate Agents", id = "Link-RegdAgents", data = "[" + subSeriesRegisteredAgentsS1 + "]" },
                //},
                SummaryStatusSectionFiveNinesData = new List<ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int>>
                {
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Total Complaint(s)/ Notice(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].valueColumnA) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Complaint Filed(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberComplaintFiled) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Pending with Authority(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPendingWithAuthority) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Pending for Orders(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPendingForOrders) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Pending with Manager for Comments(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPendingWithManagerForComments) },

                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "For issuance of Penality Notices(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberForIssuancePenalityNotices) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Pending for show cause Notice(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPendingShowCauseNotice) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Show cause notice issued for penality(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberShowCauseNoticeIssuedForPenality) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Show cause notice issued for penality but None Appeared(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberShowCauseNoticeIssuedForPenalityButNoneAppeared) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Show cause notice issued for penality and received back unserved(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberShowCauseNoticeIssuedForPenalityAndReceivedBackUnserved) },

                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Complaint Decided(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberComplaintDecided) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Complaint Decided due to Project Registration Intialized(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberComplaintDecidedDueToProjectRegistrationIntialized) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Dispose of(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberDisposeOf) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Dismissed as Non Maintainble(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberDismissedNonMaintainble) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Duplicate / Merge file(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberDuplicateMergeFile) },

                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Sent for Documentary Evidence(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberSentForDocumentaryEvidence) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "For submission of Compliance Report(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberForSubmissionOfComplianceReport) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Sent for Documentary Evidence as Defaulter Promoters(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberSentForDocumentaryEvidenceDefaulterPromoters) },
                    
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Under consideration(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberUnderConsideration) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "For Appearance(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberForAppearance) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Personal Hearing(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPersonalHearing) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "For Arguments(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberForArguments) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Reply and document(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberReplyAndDocument) },

                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Ex parte procedings(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberExParteProcedings) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Pending for Publication(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPendingForPublication) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "None appeared after publication(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberNoneAppearedAfterPublication) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Order for Publication(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberOrderForPublication) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Sent for Publication(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberSentForPublication) },
                    new ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<int> { name = "Published in Newpapers(s)", value = Convert.ToInt64(objprp.prpLiveSectionFiveNineSeries[0].NumberPublishedInNewpapers) }
                }
            };
            return Json(barChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPieChartSectionFiveNineLiveReportsDataByAOdetails(string IndexId)
        {
            string Id = IndexId;
            Int64 pIndex_ID = 0;

            ClsPrp_DashboardDesk_LiveSectionFiveNinesPieCharts objprp = new ClsPrp_DashboardDesk_LiveSectionFiveNinesPieCharts();
            ClsMethod_DashboardDesk_FactsFigure sdb = new ClsMethod_DashboardDesk_FactsFigure();

            objprp.prpLiveSectionFiveNinePieCharts = sdb.Display_DashboardDesk_LiveSectionFiveNinesPieChartsDetails(pIndex_ID);

            var pieChartValue = new ClsPrp_DashboardDesk_LiveReportSectionFiveNinePieChartsSeries<int>();
            var pieChartModel = new ClsPrp_DashboardDesk_PieChartsLiveReportSectionFiveNines<int>
            {
                LiveReportSectionFiveNinePieChartsData = new List<ClsPrp_DashboardDesk_LiveReportSectionFiveNinePieChartsSeries<int>>()
            };

            foreach (var item in objprp.prpLiveSectionFiveNinePieCharts)
            {
                objprp.NumberZoneCode = item.NumberZoneCode;
                objprp.NameZoneCode = item.NameZoneCode;
                objprp.PopulationPercentageUnderZone = item.PopulationPercentageUnderZone;
                objprp.NumberSectionFiveNineUnderZone = item.NumberSectionFiveNineUnderZone;
                objprp.AmountFeeRegistrations = item.AmountFeeRegistrations;

                objprp.NumberExtraA = item.NumberExtraA;
                objprp.NumberExtraB = item.NumberExtraB;
                objprp.NumberExtraC = item.NumberExtraC;

                pieChartValue = new ClsPrp_DashboardDesk_LiveReportSectionFiveNinePieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + item.NameZoneCode.ToString() + "</span>", y = item.PopulationPercentageUnderZone, sectionfivenines = item.NumberSectionFiveNineUnderZone };
                pieChartModel.LiveReportSectionFiveNinePieChartsData.Add(pieChartValue);
            }

            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
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
    }
}