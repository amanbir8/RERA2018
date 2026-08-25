using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.Document
{
    public class ClsMethod_Promoter_DocumentsTrackAction
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        /// <summary>
        /// Display only for Master ApplicationFee
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Promoter_DocumentsTrackAction> Display_Promoter_Documents()
        {
            connection();
            List<Clsprp_Promoter_DocumentsTrackAction> PromoterDocuments = new List<Clsprp_Promoter_DocumentsTrackAction>();

            MySqlCommand cmd = new MySqlCommand("Display_Promoter_DocumentsTrackAction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterDocuments.Add(
                    new Clsprp_Promoter_DocumentsTrackAction
                    {

                        PromoterDocTrack_IndexID = Convert.ToInt64(dr["PromoterDocTrack_IndexID"]),
                        PromoterDocTrack_ID = Convert.ToInt64(dr["PromoterDocTrack_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Promoter_Type = Convert.ToInt32(dr["Promoter_Type"]),
                        IsBusinessPlace_AddressProof = Convert.ToInt32(dr["IsBusinessPlace_AddressProof"]),
                        IsPAN_DocProof = Convert.ToInt32(dr["IsPAN_DocProof"]),
                        IsOrganizationPAN_DocProof = Convert.ToInt32(dr["IsOrganizationPAN_DocProof"]),
                        IsCompany_RegistrationCertificate = Convert.ToInt32(dr["IsCompany_RegistrationCertificate"]),
                        IsOneFY_ITR_DocProof = Convert.ToInt32(dr["IsOneFY_ITR_DocProof"]),
                        IsTwoFY_ITR_DocProof = Convert.ToInt32(dr["IsTwoFY_ITR_DocProof"]),
                        IsThreeFY_ITR_DocProof = Convert.ToInt32(dr["IsThreeFY_ITR_DocProof"]),
                        IsOneFY_AuditedPL_DocProof = Convert.ToInt32(dr["IsOneFY_AuditedPL_DocProof"]),
                        IsOneFY_BalanceSheet_DocProof = Convert.ToInt32(dr["IsOneFY_BalanceSheet_DocProof"]),
                        IsOneFY_CashFlowStatements_DocProof = Convert.ToInt32(dr["IsOneFY_CashFlowStatements_DocProof"]),
                        IsOneFY_DirectorReport_DocProof = Convert.ToInt32(dr["IsOneFY_DirectorReport_DocProof"]),
                        IsOneFY_AuditorReport_DocProof = Convert.ToInt32(dr["IsOneFY_AuditorReport_DocProof"]),
                        IsTwoFY_AuditedPL_DocProof = Convert.ToInt32(dr["IsTwoFY_AuditedPL_DocProof"]),
                        IsTwoFY_BalanceSheet_DocProof = Convert.ToInt32(dr["IsTwoFY_BalanceSheet_DocProof"]),
                        IsTwoFY_CashFlowStatements_DocProof = Convert.ToInt32(dr["IsTwoFY_CashFlowStatements_DocProof"]),
                        IsTwoFY_DirectorReport_DocProof = Convert.ToInt32(dr["IsTwoFY_DirectorReport_DocProof"]),
                        IsTwoFY_AuditorReport_DocProof = Convert.ToInt32(dr["IsTwoFY_AuditorReport_DocProof"]),
                        IsThreeFY_AuditedPL_DocProof = Convert.ToInt32(dr["IsThreeFY_AuditedPL_DocProof"]),
                        IsThreeFY_BalanceSheet_DocProof = Convert.ToInt32(dr["IsThreeFY_BalanceSheet_DocProof"]),
                        IsThreeFY_CashFlowStatements_DocProof = Convert.ToInt32(dr["IsThreeFY_CashFlowStatements_DocProof"]),
                        IsThreeFY_DirectorReport_DocProof = Convert.ToInt32(dr["IsThreeFY_DirectorReport_DocProof"]),
                        IsThreeFY_AuditorReport_DocProof = Convert.ToInt32(dr["IsThreeFY_AuditorReport_DocProof"]),
                        IsPromoterPastExperience_NIL = Convert.ToInt32(dr["IsPromoterPastExperience_NIL"]),
                        IsPE_OneFY_AuditedPL_DocProof = Convert.ToInt32(dr["IsPE_OneFY_AuditedPL_DocProof"]),
                        IsPE_OneFY_BalanceSheet_DocProof = Convert.ToInt32(dr["IsPE_OneFY_BalanceSheet_DocProof"]),
                        IsPE_OneFY_CashFlowStatements_DocProof = Convert.ToInt32(dr["IsPE_OneFY_CashFlowStatements_DocProof"]),
                        IsPE_OneFY_DirectorReport_DocProof = Convert.ToInt32(dr["IsPE_OneFY_DirectorReport_DocProof"]),
                        IsPE_OneFY_AuditorReport_DocProof = Convert.ToInt32(dr["IsPE_OneFY_AuditorReport_DocProof"]),
                        IsPE_TwoFY_AuditedPL_DocProof = Convert.ToInt32(dr["IsPE_TwoFY_AuditedPL_DocProof"]),
                        IsPE_TwoFY_BalanceSheet_DocProof = Convert.ToInt32(dr["IsPE_TwoFY_BalanceSheet_DocProof"]),
                        IsPE_TwoFY_CashFlowStatements_DocProof = Convert.ToInt32(dr["IsPE_TwoFY_CashFlowStatements_DocProof"]),
                        IsPE_TwoFY_DirectorReport_DocProof = Convert.ToInt32(dr["IsPE_TwoFY_DirectorReport_DocProof"]),
                        IsPE_TwoFY_AuditorReport_DocProof = Convert.ToInt32(dr["IsPE_TwoFY_AuditorReport_DocProof"]),
                        IsPE_ThreeFY_AuditedPL_DocProof = Convert.ToInt32(dr["IsPE_ThreeFY_AuditedPL_DocProof"]),
                        IsPE_ThreeFY_BalanceSheet_DocProof = Convert.ToInt32(dr["IsPE_ThreeFY_BalanceSheet_DocProof"]),
                        IsPE_ThreeFY_CashFlowStatements_DocProof = Convert.ToInt32(dr["IsPE_ThreeFY_CashFlowStatements_DocProof"]),
                        IsPE_ThreeFY_DirectorReport_DocProof = Convert.ToInt32(dr["IsPE_ThreeFY_DirectorReport_DocProof"]),
                        IsPE_ThreeFY_AuditorReport_DocProof = Convert.ToInt32(dr["IsPE_ThreeFY_AuditorReport_DocProof"]),
                        IsApplicationConfirmed = Convert.ToInt32(dr["IsApplicationConfirmed"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                    });
            }
            return PromoterDocuments;
        }

    }
}