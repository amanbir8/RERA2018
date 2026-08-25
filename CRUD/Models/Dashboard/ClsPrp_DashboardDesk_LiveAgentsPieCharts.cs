using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveAgentsPieCharts
    {
        public long NumberZoneCode { get; set; }
        public string NameZoneCode { get; set; }
        public decimal PopulationPercentageUnderZone { get; set; }
        public long NumberAgentsUnderZone { get; set; }
        public decimal AmountFeeRegistrations { get; set; }

        public long NumberExtraA { get; set; }
        public long NumberExtraB { get; set; }
        public long NumberExtraC { get; set; }        

        public List<ClsPrp_DashboardDesk_LiveAgentsPieCharts> prpLiveAgentsPieCharts { get; set; }
        public ClsPrp_DashboardDesk_LiveAgentsPieCharts()
        {
            prpLiveAgentsPieCharts = new List<ClsPrp_DashboardDesk_LiveAgentsPieCharts>();
        }
    }
}