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
    public class ClsMethod_ViewAdd_AgentRERAcertificate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_LDR_Agent_RERAcertifcate_DiaryNumber(ClsPrp_AuthorityDesk_AgentRERA_Certificate smodel,Int64 Agent_id, String Photo_Address, String extpath, string User_Name, string User_Role, string Agent_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Agent_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AgentRERAcertificate_IndexID", (smodel.AgentRERAcertificate_IndexID == 0) ? 0 : smodel.AgentRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRERAcertificate_ID", (smodel.AgentRERAcertificate_ID == 0) ? 0 : smodel.AgentRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", String.IsNullOrEmpty(Agent_DiaryNumber) ? "" : Agent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_Agent_ID", (Agent_id == 0) ? 0 : Agent_id);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.tbl_RegDiaryNumber_indexID);

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

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

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
        
        public bool Update_LDR_Agent_RERAcertifcate_DiaryNumber(ClsPrp_AuthorityDesk_AgentRERA_Certificate smodel, Int64 Agent_id, String Photo_Address, String extpath, string User_Name, string User_Role, string Agent_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Agent_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AgentRERAcertificate_IndexID", (smodel.AgentRERAcertificate_IndexID == 0) ? 0 : smodel.AgentRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRERAcertificate_ID", (smodel.AgentRERAcertificate_ID == 0) ? 0 : smodel.AgentRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", String.IsNullOrEmpty(Agent_DiaryNumber) ? "" : Agent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_Agent_ID", (Agent_id == 0) ? 0 : Agent_id);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_AgentRERAcert_InfoCode", String.IsNullOrEmpty(smodel.AgentRERAcert_InfoCode) ? "" : smodel.AgentRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_InfoName", String.IsNullOrEmpty(smodel.AgentRERAcert_InfoName) ? "" : smodel.AgentRERAcert_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_RelatedSectionName", String.IsNullOrEmpty(smodel.AgentDoc_RelatedSectionName) ? "" : smodel.AgentDoc_RelatedSectionName);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.AgentRERAcert_ReferenceNumber) ? "" : smodel.AgentRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_IssueDate", smodel.AgentRERAcert_IssueDate);

            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileSize", String.IsNullOrEmpty(smodel.AgentRERAcert_FileSize) ? "" : smodel.AgentRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileFormat", String.IsNullOrEmpty(smodel.AgentRERAcert_FileFormat) ? "" : smodel.AgentRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FilePath", String.IsNullOrEmpty(extpath) ? "" : extpath);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_FileName", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);
            cmd.Parameters.AddWithValue("p_AgentRERAcert_IsGroup", (smodel.AgentRERAcert_IsGroup == 0) ? 0 : smodel.AgentRERAcert_IsGroup);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

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

        public List<ClsPrp_AuthorityDesk_AgentRERA_Certificate> Display_AuthDesk_AgentRERAcertificate_ByAgentIdandDiaryNumber(Int64 pAgent_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERA_Certificate> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentRERA_Certificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_RERAnumber_certificate_AgentId_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", pAgent_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentRERA_Certificate
                       {
                           AgentRERAcertificate_IndexID = Convert.ToInt64(dr["AgentRERAcertificate_IndexID"]),
                           AgentRERAcertificate_ID = Convert.ToInt64(dr["AgentRERAcertificate_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),

                           AgentRERAcert_InfoCode = Convert.ToString(dr["AgentRERAcert_InfoCode"]),
                           AgentRERAcert_InfoName = Convert.ToString(dr["AgentRERAcert_InfoName"]),
                           // AgentDoc_RelatedSectionName = Convert.ToString(dr["AgentDoc_RelatedSectionName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),

                           AgentRERAcert_FileSize = Convert.ToString(dr["AgentRERAcert_FileSize"]),
                           AgentRERAcert_FileFormat = Convert.ToString(dr["AgentRERAcert_FileFormat"]),
                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_IsGroup = Convert.ToInt32(dr["AgentRERAcert_IsGroup"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }

        public bool Delete_AuthDesk_AgentRERAcertificateDetailsById(Int64? mAgentRERAcertificate_IndexID, Int64? mAgentRERAcertificate_ID, Int64? mAgent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_Agent_RERAcertificateDetailsById_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentRERAcertificate_IndexID", mAgentRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRERAcertificate_ID", mAgentRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", mAgent_ID);

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