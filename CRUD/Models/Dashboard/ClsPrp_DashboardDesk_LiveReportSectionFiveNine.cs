using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<T>
    {
        public string name { get; set; }
        public long y { get; set; }
        public string drilldown { get; set; }
    }

    public class ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<T>
    {
        public string name { get; set; }
        public string id { get; set; }
        public string data { get; set; }
    }

    public class ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<T>
    {
        public string name { get; set; }
        public long value { get; set; }
    }

    public class ClsPrp_DashboardDesk_LiveReportSectionFiveNinePieChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }
        public long sectionfivenines { get; set; }
    }

    public class ClsPrp_DashboardDesk_ChartsLiveReportSectionFiveNine<T>
    {
        public ICollection<ClsPrp_DashboardDesk_LiveReportSectionFiveNineSeries<T>> LiveReportSectionFiveNinesData { get; set; }
        public ICollection<ClsPrp_DashboardDesk_LiveReportSectionFiveNineDrilldownSeries<T>> LiveReportSectionFiveNineDrilldownData { get; set; }
        public ICollection<ClsPrp_DashboardDesk_SummaryStatusSectionFiveNine<T>> SummaryStatusSectionFiveNinesData { get; set; }
    }

    public class ClsPrp_DashboardDesk_PieChartsLiveReportSectionFiveNines<T>
    {
        public ICollection<ClsPrp_DashboardDesk_LiveReportSectionFiveNinePieChartsSeries<T>> LiveReportSectionFiveNinePieChartsData { get; set; }
    }
}