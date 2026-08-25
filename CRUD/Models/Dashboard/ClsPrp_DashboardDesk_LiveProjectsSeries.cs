using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveProjectsSeries
    {
        public long NumberNewApplications { get; set; }
        public long NumberInProcessApplications { get; set; }
        public long NumberChecklistPreparedApplications { get; set; }
        public long NumberReviewChecklistApplications { get; set; }
        public long NumberApprovedApplications { get; set; }

        public long NumberRejectedApplications { get; set; }
        public long NumberWithdrawnApplications { get; set; }
        public long NumberOfflineRegisteredProjectsShiftedPublicView { get; set; }
        public long NumberOfflineRegdProjectsPendingUploads { get; set; }
        public long NumberPublicViewProjects { get; set; }

        public long NumberPublicViewProjectsWebpage { get; set; }
        public long NumberProjectExtensionApplications { get; set; }
        public long NumberProjectAnnualReportonStatementofAccounts { get; set; }
        public long NumberTotalRegisteredProjects { get; set; }

        public long valueInCompleteApplications { get; set; }
        public long valueReSubmittedApplications { get; set; }
        public long valueDueForProjectExtension { get; set; }
        public long valueCompletionCertificate { get; set; }
        public long valueTotal { get; set; }

        public List<ClsPrp_DashboardDesk_LiveProjectsSeries> prpLiveProjectsSeries { get; set; }
        public ClsPrp_DashboardDesk_LiveProjectsSeries()
        {
            prpLiveProjectsSeries = new List<ClsPrp_DashboardDesk_LiveProjectsSeries>();
        }
    }
}