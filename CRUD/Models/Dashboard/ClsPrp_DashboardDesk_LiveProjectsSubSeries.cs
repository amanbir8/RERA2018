using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveProjectsSubSeries
    {
        public long NumberSubSeriesCode { get; set; }
        public string NameSubSeriesCode { get; set; }
        public string NameSubSeriesActivityTitle { get; set; }
        public int MonthSubSeriesCode { get; set; }
        public int YearSubSeriesCode { get; set; }
        public long NumberTotalApplications { get; set; }

        public long NumberExtraA { get; set; }
        public long NumberExtraB { get; set; }

        public List<ClsPrp_DashboardDesk_LiveProjectsSubSeries> prpLiveProjectsSubSeries { get; set; }
        public ClsPrp_DashboardDesk_LiveProjectsSubSeries()
        {
            prpLiveProjectsSubSeries = new List<ClsPrp_DashboardDesk_LiveProjectsSubSeries>();
        }
    }
}