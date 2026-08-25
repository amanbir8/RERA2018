using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_ViewAdd_RenewalAgentRERAcertificate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_LDR_RenewalAgent_RERAcertifcate_DiaryNumber(ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate smodel, Int64 Agent_id, Int64 RnAgent_id, Int32 RnAgent_SeqId, Int32 RnAgent_YearId, String Photo_Address, String extpath, string User_Name, string User_Role)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_RenewalAgent_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AgentRenewalRERAcertificate_IndexID", (smodel.RenewalAgent_RERAcertificate_IndexID == 0) ? 0 : smodel.RenewalAgent_RERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRenewalRERAcertificate_ID", (smodel.RenewalAgent_RERAcertificate_ID == 0) ? 0 : smodel.RenewalAgent_RERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_ReferenceDiaryNumber_Name) ? "NA" : smodel.Related_ReferenceDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "NA" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", (Agent_id == 0) ? 0 : Agent_id);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_ID", (RnAgent_id == 0) ? 0 : RnAgent_id);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", (RnAgent_YearId == 0) ? 0 : RnAgent_YearId);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", (RnAgent_SeqId == 0) ? 0 : RnAgent_SeqId);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.Related_tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.Related_tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_AgentRERAcert_InfoCode", String.IsNullOrEmpty(smodel.AgentRERAcert_InfoCode) ? "0" : smodel.AgentRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_InfoName", String.IsNullOrEmpty(smodel.AgentRERAcert_InfoName) ? "" : smodel.AgentRERAcert_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_RelatedSectionName", String.IsNullOrEmpty(smodel.AgentDoc_RelatedSectionName) ? "" : smodel.AgentDoc_RelatedSectionName);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.AgentRERAcert_ReferenceNumber) ? "" : smodel.AgentRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_IssueDate", smodel.AgentRERAcert_IssueDate);

            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileSize", String.IsNullOrEmpty(smodel.AgentRERAcert_FileSize) ? "" : smodel.AgentRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileFormat", String.IsNullOrEmpty(smodel.AgentRERAcert_FileFormat) ? "" : smodel.AgentRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FilePath", String.IsNullOrEmpty(extpath) ? "" : extpath);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileName", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_IsGroup", (smodel.AgentRERAcert_IsGroup == 0) ? 0 : smodel.AgentRERAcert_IsGroup);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Agent_RERAnumberRegistration) ? "NA" : smodel.Agent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.Agent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.Agent_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_RenewalRegistrationNumber", String.IsNullOrEmpty(smodel.Latest_RenewalAgent_RERAnumberRegistration) ? "NA" : smodel.Latest_RenewalAgent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RenewalRegistrationIssueDate", smodel.Latest_RenewalAgent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RenewalRegistrationRegUptoDate", smodel.Latest_RenewalAgent_RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);
            
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        
        public bool Update_LDR_RenewalAgent_RERAcertifcate_DiaryNumber(ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate smodel, Int64 Agent_id, Int64 RnAgent_id, Int32 RnAgent_SeqId, Int32 RnAgent_YearId, String Photo_Address, String extpath, string User_Name, string User_Role)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_RenewalAgent_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AgentRenewalRERAcertificate_IndexID", (smodel.RenewalAgent_RERAcertificate_IndexID == 0) ? 0 : smodel.RenewalAgent_RERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRenewalRERAcertificate_ID", (smodel.RenewalAgent_RERAcertificate_ID == 0) ? 0 : smodel.RenewalAgent_RERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_ReferenceDiaryNumber_Name) ? "NA" : smodel.Related_ReferenceDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "NA" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", (Agent_id == 0) ? 0 : Agent_id);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_ID", (RnAgent_id == 0) ? 0 : RnAgent_id);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", (RnAgent_YearId == 0) ? 0 : RnAgent_YearId);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", (RnAgent_SeqId == 0) ? 0 : RnAgent_SeqId);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.Related_tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.Related_tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_AgentRERAcert_InfoCode", String.IsNullOrEmpty(smodel.AgentRERAcert_InfoCode) ? "0" : smodel.AgentRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_InfoName", String.IsNullOrEmpty(smodel.AgentRERAcert_InfoName) ? "" : smodel.AgentRERAcert_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_RelatedSectionName", String.IsNullOrEmpty(smodel.AgentDoc_RelatedSectionName) ? "" : smodel.AgentDoc_RelatedSectionName);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.AgentRERAcert_ReferenceNumber) ? "" : smodel.AgentRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_IssueDate", smodel.AgentRERAcert_IssueDate);

            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileSize", String.IsNullOrEmpty(smodel.AgentRERAcert_FileSize) ? "" : smodel.AgentRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileFormat", String.IsNullOrEmpty(smodel.AgentRERAcert_FileFormat) ? "" : smodel.AgentRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FilePath", String.IsNullOrEmpty(extpath) ? "" : extpath);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileName", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_IsGroup", (smodel.AgentRERAcert_IsGroup == 0) ? 0 : smodel.AgentRERAcert_IsGroup);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Agent_RERAnumberRegistration) ? "NA" : smodel.Agent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.Agent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.Agent_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_RenewalRegistrationNumber", String.IsNullOrEmpty(smodel.Latest_RenewalAgent_RERAnumberRegistration) ? "NA" : smodel.Latest_RenewalAgent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RenewalRegistrationIssueDate", smodel.Latest_RenewalAgent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RenewalRegistrationRegUptoDate", smodel.Latest_RenewalAgent_RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate> Display_AuthDesk_RenewalAgent_RERAcertificate_ByIDandDiaryNumber(Int64 pAgent_ID, Int32 pAgentTypeID, Int64 pRenewalAgentID, Int32 pRenewalAgentSequenceID, Int32 pRenewalAgentYearID, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate> RenewalAgentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_RenewalAgent_RERAnumber_certificate_ByID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", pAgent_ID);
            cmd.Parameters.AddWithValue("p_AgentType_ID", pAgentTypeID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", pRenewalAgentID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", pRenewalAgentSequenceID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", pRenewalAgentYearID);
            cmd.Parameters.AddWithValue("p_UserRole", userRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RenewalAgentlist.Add(
                       new ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate
                       {
                           RenewalAgent_RERAcertificate_IndexID = Convert.ToInt64(dr["RenewalAgent_RERAcertificate_IndexID"]),
                           RenewalAgent_RERAcertificate_ID = Convert.ToInt64(dr["RenewalAgent_RERAcertificate_ID"]),

                           Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                           Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                           Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                           Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                           Related_UserID = Convert.ToString(dr["Related_UserID"]),
                           Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                           Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                           Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                           Related_ReferenceDiaryNumber_Name = Convert.ToString(dr["Related_ReferenceDiaryNumber_Name"]),
                           Related_tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["Related_tbl_RegDiaryNumber_indexID"]),

                           AgentRERAcert_InfoCode = Convert.ToString(dr["AgentRERAcert_InfoCode"]),
                           AgentRERAcert_InfoName = Convert.ToString(dr["AgentRERAcert_InfoName"]),
                           AgentDoc_RelatedSectionName = Convert.ToString(dr["AgentDoc_RelatedSectionName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),

                           AgentRERAcert_FileSize = Convert.ToString(dr["AgentRERAcert_FileSize"]),
                           AgentRERAcert_FileFormat = Convert.ToString(dr["AgentRERAcert_FileFormat"]),
                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_IsGroup = Convert.ToInt32(dr["AgentRERAcert_IsGroup"]),

                           Agent_RERAnumberRegistration = Convert.ToString(dr["Agent_RERAnumberRegistration"]),
                           Agent_RERAnumberIssueDate = Convert.ToDateTime(dr["Agent_RERAnumberIssueDate"]),
                           Agent_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Agent_RERAnumberRegUptoDate"]),

                           Latest_RenewalAgent_RERAnumberRegistration = Convert.ToString(dr["Latest_RenewalAgent_RERAnumberRegistration"]),
                           Latest_RenewalAgent_RERAnumberIssueDate = Convert.ToDateTime(dr["Latest_RenewalAgent_RERAnumberIssueDate"]),
                           Latest_RenewalAgent_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Latest_RenewalAgent_RERAnumberRegUptoDate"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return RenewalAgentlist;
        }

        public bool Delete_AuthDesk_RenewalAgent_RERAcertificateDetailsById(Int64? mRnAgentRERAcertificate_IndexID, Int64? mRnAgentRERAcertificate_ID, Int64? mAgent_ID, Int64? mRenewalAgent_ID, Int32? mRenewalAgent_SequenceID, Int32? mRenewalAgent_YearID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_AgentRenewal_RERAcertificateDetailsById_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_RenewalAgentRERAcertificate_IndexID", mRnAgentRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgentRERAcertificate_ID", mRnAgentRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", mAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", mRenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", mRenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", mRenewalAgent_YearID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}