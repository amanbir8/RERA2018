using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_LiveSectionFiveNineSeries
    {
        public long NumberComplaintFiled { get; set; }
        public long NumberPendingWithAuthority { get; set; }
        public long NumberPendingForOrders { get; set; }
        public long NumberPendingWithManagerForComments { get; set; }

        public long NumberForIssuancePenalityNotices { get; set; }
        public long NumberPendingShowCauseNotice { get; set; }
        public long NumberShowCauseNoticeIssuedForPenality { get; set; }
        public long NumberShowCauseNoticeIssuedForPenalityButNoneAppeared { get; set; }
        public long NumberShowCauseNoticeIssuedForPenalityAndReceivedBackUnserved { get; set; }

        public long NumberComplaintDecided { get; set; }
        public long NumberComplaintDecidedDueToProjectRegistrationIntialized { get; set; }
        public long NumberDisposeOf { get; set; }
        public long NumberDismissedNonMaintainble { get; set; }
        public long NumberDuplicateMergeFile { get; set; }

        public long NumberSentForDocumentaryEvidence { get; set; }
        public long NumberForSubmissionOfComplianceReport { get; set; }
        public long NumberSentForDocumentaryEvidenceDefaulterPromoters { get; set; }

        public long NumberUnderConsideration { get; set; }
        public long NumberForAppearance { get; set; }
        public long NumberPersonalHearing { get; set; }
        public long NumberForArguments { get; set; }
        public long NumberReplyAndDocument { get; set; }

        public long NumberExParteProcedings { get; set; }
        public long NumberPendingForPublication { get; set; }
        public long NumberNoneAppearedAfterPublication { get; set; }
        public long NumberOrderForPublication { get; set; }
        public long NumberSentForPublication { get; set; }
        public long NumberPublishedInNewpapers { get; set; }

        public long valueColumnA { get; set; }
        public long valueColumnB { get; set; }
        public long valueColumnC { get; set; }
        public long valueColumnD { get; set; }
        public long valueColumnE { get; set; }

        public List<ClsPrp_DashboardDesk_LiveSectionFiveNineSeries> prpLiveSectionFiveNineSeries { get; set; }
        public ClsPrp_DashboardDesk_LiveSectionFiveNineSeries()
        {
            prpLiveSectionFiveNineSeries = new List<ClsPrp_DashboardDesk_LiveSectionFiveNineSeries>();
        }
    }
}