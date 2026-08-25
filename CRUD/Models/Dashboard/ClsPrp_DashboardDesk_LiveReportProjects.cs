using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveReportProjectSeries<T>
    {
        public string name { get; set; }
        public long y { get; set; }
        public string drilldown { get; set; } 
    }

    public class ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<T>
    {
        public string name { get; set; }
        public string id { get; set; }
        public string data { get; set; }
    }

    public class ClsPrp_DashboardDesk_SummaryStatusProjects<T>
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }
        public int z { get; set; }
        public decimal amount { get; set; }
    }

    public class ClsPrp_DashboardDesk_ChartsLiveReportProjects<T>
    {
        public ICollection<ClsPrp_DashboardDesk_LiveReportProjectSeries<T>> LiveReportProjectsData { get; set; }
        public ICollection<ClsPrp_DashboardDesk_LiveReportProjectDrilldownSeries<T>> LiveReportProjectsDrilldownData { get; set; }
        public ICollection<ClsPrp_DashboardDesk_SummaryStatusProjects<T>> SummaryStatusProjectsData { get; set; }
    }

    public class ClsPrp_DashboardDesk_PieChartsLiveReportProjects<T>
    {
        public ICollection<ClsPrp_DashboardDesk_LiveReportProjectPieChartsSeries<T>> LiveReportProjectsPieChartsData { get; set; }
    }
}