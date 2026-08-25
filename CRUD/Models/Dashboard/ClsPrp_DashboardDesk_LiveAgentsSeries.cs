using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveAgentsSeries
    {
        public long NumberNewApplications { get; set; }
        public long NumberInProcessApplications { get; set; }
        public long NumberChecklistPreparedApplications { get; set; }
        public long NumberReviewChecklistApplications { get; set; }
        public long NumberApprovedApplications { get; set; }

        public long NumberRejectedApplications { get; set; }
        public long NumberWithdrawnApplications { get; set; }
        public long NumberOfflineRegisteredAgentsShiftedPublicView { get; set; }
        public long NumberOfflineRegdAgentsPendingUploads { get; set; }
        public long NumberPublicViewAgents { get; set; }

        public long NumberPublicViewAgentsWebpage { get; set; }
        public long NumberAgentsRenewalApplications { get; set; }
        public long NumberAgentsExtraValue { get; set; }
        public long NumberTotalRegisteredAgents { get; set; }

        public long valueInCompleteApplications { get; set; }
        public long valueReSubmittedApplications { get; set; }
        public long valueDueForAgentsRenewal { get; set; }
        public long valueCompletionCertificate { get; set; }
        public long valueTotal { get; set; }

        public List<ClsPrp_DashboardDesk_LiveAgentsSeries> prpLiveAgentsSeries { get; set; }
        public ClsPrp_DashboardDesk_LiveAgentsSeries()
        {
            prpLiveAgentsSeries = new List<ClsPrp_DashboardDesk_LiveAgentsSeries>();
        }
    }
}