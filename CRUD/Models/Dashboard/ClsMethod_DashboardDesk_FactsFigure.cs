using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.Dashboard
{
    public class ClsMethod_DashboardDesk_FactsFigure
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // CLS MAIN
        public List<ClsPrp_DashboardDesk_FactsFigure> Display_DashboardDesk_FactsFigureDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_FactsFigure> AdminDeskparameters = new List<ClsPrp_DashboardDesk_FactsFigure>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_FactFigures", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_FactsFigure
                       {
                           Number_RegisteredProjects = Convert.ToInt64(dr["Number_RegisteredProjects"]),
                           Number_RegisteredAgents = Convert.ToInt64(dr["Number_RegisteredAgents"]),
                           Number_DecidedComplaints = Convert.ToInt64(dr["Number_DecidedComplaints"]),
                           Number_PendingProjects = Convert.ToInt64(dr["Number_PendingProjects"]),

                           Number_SectionThreeOneComplaints = Convert.ToInt64(dr["Number_SectionThreeOneComplaints"]),
                           Number_SectionFiveNineComplaints = Convert.ToInt64(dr["Number_SectionFiveNineComplaints"]),
                           Number_PaymentTransactions = Convert.ToInt64(dr["Number_PaymentTransactions"]),
                           Number_TotalAmount = Convert.ToInt64(dr["Number_TotalAmount"]),

                           Title_RegisteredProjects = Convert.ToString(dr["Title_RegisteredProjects"]),
                           Title_RegisteredAgents = Convert.ToString(dr["Title_RegisteredAgents"]),
                           Title_DecidedComplaints = Convert.ToString(dr["Title_DecidedComplaints"]),
                           Title_PendingProjects = Convert.ToString(dr["Title_PendingProjects"]),

                           Title_SectionThreeOneComplaints = Convert.ToString(dr["Title_SectionThreeOneComplaints"]),
                           Title_SectionFiveNineComplaints = Convert.ToString(dr["Title_SectionFiveNineComplaints"]),
                           Title_PaymentTransactions = Convert.ToString(dr["Title_PaymentTransactions"]),
                           Title_TotalAmount = Convert.ToString(dr["Title_TotalAmount"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                           D_Column = Convert.ToString(dr["D_Column"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        // CLS PROJECTS
        public List<ClsPrp_DashboardDesk_LiveProjectsSeries> Display_DashboardDesk_LiveProjectsNumberDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveProjectsSeries> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveProjectsSeries>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveProjectsNumbers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveProjectsSeries
                       {
                           NumberNewApplications = Convert.ToInt64(dr["NumberNewApplications"]),
                           NumberInProcessApplications = Convert.ToInt64(dr["NumberInProcessApplications"]),
                           NumberChecklistPreparedApplications = Convert.ToInt64(dr["NumberChecklistPreparedApplications"]),
                           NumberReviewChecklistApplications = Convert.ToInt64(dr["NumberReviewChecklistApplications"]),
                           NumberApprovedApplications = Convert.ToInt64(dr["NumberApprovedApplications"]),

                           NumberRejectedApplications = Convert.ToInt64(dr["NumberRejectedApplications"]),
                           NumberWithdrawnApplications = Convert.ToInt64(dr["NumberWithdrawnApplications"]),
                           NumberOfflineRegisteredProjectsShiftedPublicView = Convert.ToInt64(dr["NumberOfflineRegisteredProjectsShiftedPublicView"]),
                           NumberOfflineRegdProjectsPendingUploads = Convert.ToInt64(dr["NumberOfflineRegdProjectsPendingUploads"]),
                           NumberPublicViewProjects = Convert.ToInt64(dr["NumberPublicViewProjects"]),

                           NumberPublicViewProjectsWebpage = Convert.ToInt64(dr["NumberPublicViewProjectsWebpage"]),
                           NumberProjectExtensionApplications = Convert.ToInt64(dr["NumberProjectExtensionApplications"]),
                           NumberProjectAnnualReportonStatementofAccounts = Convert.ToInt64(dr["NumberProjectAnnualReportonStatementofAccounts"]),
                           NumberTotalRegisteredProjects = Convert.ToInt64(dr["NumberTotalRegisteredProjects"]),

                           valueInCompleteApplications = Convert.ToInt64(dr["valueInCompleteApplications"]),
                           valueReSubmittedApplications = Convert.ToInt64(dr["valueReSubmittedApplications"]),
                           valueDueForProjectExtension = Convert.ToInt64(dr["valueDueForProjectExtension"]),
                           valueCompletionCertificate = Convert.ToInt64(dr["valueCompletionCertificate"]),
                           valueTotal = Convert.ToInt64(dr["valueTotal"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_DashboardDesk_LiveProjectsSubSeries> Display_DashboardDesk_LiveProjectsSubSeriesCharts(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveProjectsSubSeries> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveProjectsSubSeries>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveProjectsSubSeriesCharts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveProjectsSubSeries
                       {
                           NumberSubSeriesCode = Convert.ToInt64(dr["NumberSubSeriesCode"]),
                           NameSubSeriesCode = Convert.ToString(dr["NameSubSeriesCode"]),
                           NameSubSeriesActivityTitle = Convert.ToString(dr["NameSubSeriesActivityTitle"]),
                           MonthSubSeriesCode = Convert.ToInt32(dr["MonthSubSeriesCode"]),
                           YearSubSeriesCode = Convert.ToInt32(dr["YearSubSeriesCode"]),
                           NumberTotalApplications = Convert.ToInt64(dr["NumberTotalApplications"]),

                           NumberExtraA = Convert.ToInt64(dr["NumberExtraA"]),
                           NumberExtraB = Convert.ToInt64(dr["NumberExtraB"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_DashboardDesk_LiveProjectsPieCharts> Display_DashboardDesk_LiveProjectsPieChartsDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveProjectsPieCharts> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveProjectsPieCharts>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveProjectsPieCharts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveProjectsPieCharts
                       {
                           NumberZoneCode = Convert.ToInt64(dr["NumberZoneCode"]),
                           NameZoneCode = Convert.ToString(dr["NameZoneCode"]),
                           AreaZoneUnderProjects = Convert.ToDecimal(dr["AreaZoneUnderProjects"]),
                           NumberProjectsUnderZone = Convert.ToInt64(dr["NumberProjectsUnderZone"]),
                           AmountFeeRegistrations = Convert.ToDecimal(dr["AmountFeeRegistrations"]),

                           NumberExtraA = Convert.ToInt64(dr["NumberExtraA"]),
                           NumberExtraB = Convert.ToInt64(dr["NumberExtraB"]),
                           NumberExtraC = Convert.ToInt64(dr["NumberExtraC"]),
                       });
            }
            return AdminDeskparameters;
        }

        // CLS AGENTS
        public List<ClsPrp_DashboardDesk_LiveAgentsSeries> Display_DashboardDesk_LiveRealEstateAgentsNumberDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveAgentsSeries> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveAgentsSeries>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveAgentsNumbers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveAgentsSeries
                       {
                           NumberNewApplications = Convert.ToInt64(dr["NumberNewApplications"]),
                           NumberInProcessApplications = Convert.ToInt64(dr["NumberInProcessApplications"]),
                           NumberChecklistPreparedApplications = Convert.ToInt64(dr["NumberChecklistPreparedApplications"]),
                           NumberReviewChecklistApplications = Convert.ToInt64(dr["NumberReviewChecklistApplications"]),
                           NumberApprovedApplications = Convert.ToInt64(dr["NumberApprovedApplications"]),

                           NumberRejectedApplications = Convert.ToInt64(dr["NumberRejectedApplications"]),
                           NumberWithdrawnApplications = Convert.ToInt64(dr["NumberWithdrawnApplications"]),
                           NumberOfflineRegisteredAgentsShiftedPublicView = Convert.ToInt64(dr["NumberOfflineRegisteredAgentsShiftedPublicView"]),
                           NumberOfflineRegdAgentsPendingUploads = Convert.ToInt64(dr["NumberOfflineRegdAgentsPendingUploads"]),
                           NumberPublicViewAgents = Convert.ToInt64(dr["NumberPublicViewAgents"]),

                           NumberPublicViewAgentsWebpage = Convert.ToInt64(dr["NumberPublicViewAgentsWebpage"]),
                           NumberAgentsRenewalApplications = Convert.ToInt64(dr["NumberAgentsRenewalApplications"]),
                           NumberAgentsExtraValue = Convert.ToInt64(dr["NumberAgentsExtraValue"]),
                           NumberTotalRegisteredAgents = Convert.ToInt64(dr["NumberTotalRegisteredAgents"]),

                           valueInCompleteApplications = Convert.ToInt64(dr["valueInCompleteApplications"]),
                           valueReSubmittedApplications = Convert.ToInt64(dr["valueReSubmittedApplications"]),
                           valueDueForAgentsRenewal = Convert.ToInt64(dr["valueDueForAgentsRenewal"]),
                           valueCompletionCertificate = Convert.ToInt64(dr["valueCompletionCertificate"]),
                           valueTotal = Convert.ToInt64(dr["valueTotal"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_DashboardDesk_LiveAgentsSubSeries> Display_DashboardDesk_LiveRealEstateAgentsSubSeriesCharts(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveAgentsSubSeries> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveAgentsSubSeries>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveAgentsSubSeriesCharts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveAgentsSubSeries
                       {
                           NumberSubSeriesCode = Convert.ToInt64(dr["NumberSubSeriesCode"]),
                           NameSubSeriesCode = Convert.ToString(dr["NameSubSeriesCode"]),
                           NameSubSeriesActivityTitle = Convert.ToString(dr["NameSubSeriesActivityTitle"]),
                           MonthSubSeriesCode = Convert.ToInt32(dr["MonthSubSeriesCode"]),
                           YearSubSeriesCode = Convert.ToInt32(dr["YearSubSeriesCode"]),
                           NumberTotalApplications = Convert.ToInt64(dr["NumberTotalApplications"]),

                           NumberExtraA = Convert.ToInt64(dr["NumberExtraA"]),
                           NumberExtraB = Convert.ToInt64(dr["NumberExtraB"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_DashboardDesk_LiveAgentsPieCharts> Display_DashboardDesk_LiveRealEstateAgentsPieChartsDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveAgentsPieCharts> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveAgentsPieCharts>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveAgentsDistrictPieCharts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveAgentsPieCharts
                       {
                           NumberZoneCode = Convert.ToInt64(dr["NumberZoneCode"]),
                           NameZoneCode = Convert.ToString(dr["NameZoneCode"]),
                           PopulationPercentageUnderZone = Convert.ToDecimal(dr["PopulationPercentageUnderZone"]),
                           NumberAgentsUnderZone = Convert.ToInt64(dr["NumberAgentsUnderZone"]),
                           AmountFeeRegistrations = Convert.ToDecimal(dr["AmountFeeRegistrations"]),

                           NumberExtraA = Convert.ToInt64(dr["NumberExtraA"]),
                           NumberExtraB = Convert.ToInt64(dr["NumberExtraB"]),
                           NumberExtraC = Convert.ToInt64(dr["NumberExtraC"]),
                       });
            }
            return AdminDeskparameters;
        }

        // CLS SECTION FIVE-NINE
        public List<ClsPrp_DashboardDesk_LiveSectionFiveNineSeries> Display_DashboardDesk_LiveSectionFiveNinesNumberDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveSectionFiveNineSeries> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveSectionFiveNineSeries>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveSectionFiveNinesNumbers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveSectionFiveNineSeries
                       {
                           NumberComplaintFiled = Convert.ToInt64(dr["NumberComplaintFiled"]),
                           NumberPendingWithAuthority = Convert.ToInt64(dr["NumberPendingWithAuthority"]),
                           NumberPendingForOrders = Convert.ToInt64(dr["NumberPendingForOrders"]),
                           NumberPendingWithManagerForComments = Convert.ToInt64(dr["NumberPendingWithManagerForComments"]),

                           NumberForIssuancePenalityNotices = Convert.ToInt64(dr["NumberForIssuancePenalityNotices"]),
                           NumberPendingShowCauseNotice = Convert.ToInt64(dr["NumberPendingShowCauseNotice"]),
                           NumberShowCauseNoticeIssuedForPenality = Convert.ToInt64(dr["NumberShowCauseNoticeIssuedForPenality"]),
                           NumberShowCauseNoticeIssuedForPenalityButNoneAppeared = Convert.ToInt64(dr["NumberShowCauseNoticeIssuedForPenalityButNoneAppeared"]),
                           NumberShowCauseNoticeIssuedForPenalityAndReceivedBackUnserved = Convert.ToInt64(dr["NumberShowCauseNoticeIssuedForPenalityAndReceivedBackUnserved"]),

                           NumberComplaintDecided = Convert.ToInt64(dr["NumberComplaintDecided"]),
                           NumberComplaintDecidedDueToProjectRegistrationIntialized = Convert.ToInt64(dr["NumberComplaintDecidedDueToProjectRegistrationIntialized"]),
                           NumberDisposeOf = Convert.ToInt64(dr["NumberDisposeOf"]),
                           NumberDismissedNonMaintainble = Convert.ToInt64(dr["NumberDismissedNonMaintainble"]),
                           NumberDuplicateMergeFile = Convert.ToInt64(dr["NumberDuplicateMergeFile"]),

                           NumberSentForDocumentaryEvidence = Convert.ToInt64(dr["NumberSentForDocumentaryEvidence"]),
                           NumberForSubmissionOfComplianceReport = Convert.ToInt64(dr["NumberForSubmissionOfComplianceReport"]),
                           NumberSentForDocumentaryEvidenceDefaulterPromoters = Convert.ToInt64(dr["NumberSentForDocumentaryEvidenceDefaulterPromoters"]),

                           NumberUnderConsideration = Convert.ToInt64(dr["NumberUnderConsideration"]),
                           NumberForAppearance = Convert.ToInt64(dr["NumberForAppearance"]),
                           NumberPersonalHearing = Convert.ToInt64(dr["NumberPersonalHearing"]),
                           NumberForArguments = Convert.ToInt64(dr["NumberForArguments"]),
                           NumberReplyAndDocument = Convert.ToInt64(dr["NumberReplyAndDocument"]),

                           NumberExParteProcedings = Convert.ToInt64(dr["NumberExParteProcedings"]),
                           NumberPendingForPublication = Convert.ToInt64(dr["NumberPendingForPublication"]),
                           NumberNoneAppearedAfterPublication = Convert.ToInt64(dr["NumberNoneAppearedAfterPublication"]),
                           NumberOrderForPublication = Convert.ToInt64(dr["NumberOrderForPublication"]),
                           NumberSentForPublication = Convert.ToInt64(dr["NumberSentForPublication"]),
                           NumberPublishedInNewpapers = Convert.ToInt64(dr["NumberPublishedInNewpapers"]),

                           valueColumnA = Convert.ToInt64(dr["valueColumnA"]),
                           valueColumnB = Convert.ToInt64(dr["valueColumnB"]),
                           valueColumnC = Convert.ToInt64(dr["valueColumnC"]),
                           valueColumnD = Convert.ToInt64(dr["valueColumnD"]),
                           valueColumnE = Convert.ToInt64(dr["valueColumnE"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_DashboardDesk_LiveSectionFiveNinesPieCharts> Display_DashboardDesk_LiveSectionFiveNinesPieChartsDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_DashboardDesk_LiveSectionFiveNinesPieCharts> AdminDeskparameters = new List<ClsPrp_DashboardDesk_LiveSectionFiveNinesPieCharts>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_DashboardDesk_LiveSectionFiveNineDistrictPieCharts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_DashboardDesk_LiveSectionFiveNinesPieCharts
                       {
                           NumberZoneCode = Convert.ToInt64(dr["NumberZoneCode"]),
                           NameZoneCode = Convert.ToString(dr["NameZoneCode"]),
                           PopulationPercentageUnderZone = Convert.ToDecimal(dr["PopulationPercentageUnderZone"]),
                           NumberSectionFiveNineUnderZone = Convert.ToInt64(dr["NumberSectionFiveNineUnderZone"]),
                           AmountFeeRegistrations = Convert.ToDecimal(dr["AmountFeeRegistrations"]),

                           NumberExtraA = Convert.ToInt64(dr["NumberExtraA"]),
                           NumberExtraB = Convert.ToInt64(dr["NumberExtraB"]),
                           NumberExtraC = Convert.ToInt64(dr["NumberExtraC"]),
                       });
            }
            return AdminDeskparameters;
        }

    }
}