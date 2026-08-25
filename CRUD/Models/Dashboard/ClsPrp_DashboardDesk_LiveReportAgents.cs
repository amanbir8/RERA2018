using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveReportAgentSeries<T>
    {
        public string name { get; set; }
        public long y { get; set; }
        public string drilldown { get; set; } 
    }

    public class ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<T>
    {
        public string name { get; set; }
        public string id { get; set; }
        public string data { get; set; }
    }

    public class ClsPrp_DashboardDesk_SummaryStatusAgents<T>
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class ClsPrp_DashboardDesk_LiveReportAgentPieChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }
        public long agents { get; set; }
    }

    public class ClsPrp_DashboardDesk_ChartsLiveReportAgents<T>
    {
        public ICollection<ClsPrp_DashboardDesk_LiveReportAgentSeries<T>> LiveReportAgentsData { get; set; }
        public ICollection<ClsPrp_DashboardDesk_LiveReportAgentDrilldownSeries<T>> LiveReportAgentsDrilldownData { get; set; }
        public ICollection<ClsPrp_DashboardDesk_SummaryStatusAgents<T>> SummaryStatusAgentsData { get; set; }
    }

    public class ClsPrp_DashboardDesk_PieChartsLiveReportAgents<T>
    {
        public ICollection<ClsPrp_DashboardDesk_LiveReportAgentPieChartsSeries<T>> LiveReportAgentsPieChartsData { get; set; }
    }
}