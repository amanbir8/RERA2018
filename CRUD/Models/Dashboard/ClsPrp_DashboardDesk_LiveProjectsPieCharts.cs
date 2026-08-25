using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveProjectsPieCharts
    {
        public long NumberZoneCode { get; set; }
        public string NameZoneCode { get; set; }
        public decimal AreaZoneUnderProjects { get; set; }
        public long NumberProjectsUnderZone { get; set; }
        public decimal AmountFeeRegistrations { get; set; }

        public long NumberExtraA { get; set; }
        public long NumberExtraB { get; set; }
        public long NumberExtraC { get; set; }        

        public List<ClsPrp_DashboardDesk_LiveProjectsPieCharts> prpLiveProjectsPieCharts { get; set; }
        public ClsPrp_DashboardDesk_LiveProjectsPieCharts()
        {
            prpLiveProjectsPieCharts = new List<ClsPrp_DashboardDesk_LiveProjectsPieCharts>();
        }
    }
}