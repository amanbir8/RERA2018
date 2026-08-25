using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using CRUD.Models.Agent;

namespace CRUD.Models.AgentRenewal
{
    public class ClsMethod_AgentRenewal_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Add Agent-Renewal
        public bool Add_AgentRenewal_DocumentsDetail(Clsprp_AgentRenewal_Documents smodel, Int64 AgentID, Int64 RnAgentID, Int32 RnSeqID, Int32 RnYr, string FilePath, string FileName, string FileSize, string FileFormat, Int32 IsGroup, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_AgentRenewal_DocumentsDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgentDoc_IndexID", smodel.RenewalAgent_Document_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgentDoc_ID", smodel.RenewalAgent_Document_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", RnAgentID);
            cmd.Parameters.AddWithValue("p_Related_RenewalOrderSequence", RnSeqID);
            cmd.Parameters.AddWithValue("p_Related_RelatedRenewalAgent_Year", RnYr);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", AgentID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", smodel.Related_Agent_Type);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgentDoc_ID", smodel.Related_RenewalAgentDoc_ID);

            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", smodel.AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoName", String.IsNullOrEmpty(smodel.AgentDoc_InfoName) ? "" : smodel.AgentDoc_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_ReferenceNumber", String.IsNullOrEmpty(smodel.AgentDoc_ReferenceNumber) ? "" : smodel.AgentDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentDoc_RelatedSectionName", String.IsNullOrEmpty(smodel.AgentDoc_RelatedSectionName) ? "" : smodel.AgentDoc_RelatedSectionName);
            cmd.Parameters.AddWithValue("p_AgentDoc_IssueDate", (smodel.AgentDoc_IssueDate == null) ? DateTime.MinValue : smodel.AgentDoc_IssueDate);

            cmd.Parameters.AddWithValue("p_AgentDoc_FileSize", String.IsNullOrEmpty(FileSize) ? "" : FileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileFormat", String.IsNullOrEmpty(FileFormat) ? "" : FileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_AgentDoc_IsGroup", smodel.AgentDoc_IsGroup);
                        
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", smodel.IsActiveProvider);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditional", smodel.IsConditional);

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //Display Agent-Renewal
        public List<Clsprp_AgentRenewal_Documents> AgentRenewal_Display_DocumentsDetail_ByID(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_Documents> list_AgentRegistration = new List<Clsprp_AgentRenewal_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_DocumentDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_AgentRegistration.Add(
                    new Clsprp_AgentRenewal_Documents
                    {
                        RenewalAgent_Document_IndexID = Convert.ToInt64(dr["RenewalAgentDoc_IndexID"]),
                        RenewalAgent_Document_ID = Convert.ToInt64(dr["RenewalAgentDoc_ID"]),
                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_RenewalAgentDoc_ID = Convert.ToInt64(dr["Related_RenewalAgentDoc_ID"]),

                        AgentDoc_InfoCode = Convert.ToInt32(dr["AgentDoc_InfoCode"]),
                        AgentDoc_InfoName = String.IsNullOrEmpty(Convert.ToString(dr["AgentDoc_InfoName"])) ? string.Empty : Convert.ToString(dr["AgentDoc_InfoName"]),
                        AgentDoc_ReferenceNumber = String.IsNullOrEmpty(Convert.ToString(dr["AgentDoc_ReferenceNumber"])) ? string.Empty : Convert.ToString(dr["AgentDoc_ReferenceNumber"]),
                        AgentDoc_IssueDate = Convert.ToDateTime(dr["AgentDoc_IssueDate"]),
                        AgentDoc_FileSize = String.IsNullOrEmpty(Convert.ToString(dr["AgentDoc_FileSize"])) ? string.Empty : Convert.ToString(dr["AgentDoc_FileSize"]),
                        AgentDoc_FileFormat = String.IsNullOrEmpty(Convert.ToString(dr["AgentDoc_FileFormat"])) ? string.Empty : Convert.ToString(dr["AgentDoc_FileFormat"]),
                        AgentDoc_FilePath = String.IsNullOrEmpty(Convert.ToString(dr["AgentDoc_FilePath"])) ? string.Empty : Convert.ToString(dr["AgentDoc_FilePath"]),
                        AgentDoc_FileName = String.IsNullOrEmpty(Convert.ToString(dr["AgentDoc_FileName"])) ? string.Empty : Convert.ToString(dr["AgentDoc_FileName"]),
                        AgentDoc_IsGroup = Convert.ToInt32(dr["AgentDoc_IsGroup"]),
                        Remarks_IfAny = String.IsNullOrEmpty(Convert.ToString(dr["Remarks_IfAny"])) ? string.Empty : Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = String.IsNullOrEmpty(Convert.ToString(dr["A_column"])) ? string.Empty : Convert.ToString(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? string.Empty : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? string.Empty : Convert.ToString(dr["C_column"]),
                        D_column = String.IsNullOrEmpty(Convert.ToString(dr["D_column"])) ? string.Empty : Convert.ToString(dr["D_column"]),
                        
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsConditional = Convert.ToInt32(dr["IsConditional"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return list_AgentRegistration;
        }

        //Validation Method - Count and Sum Size
        public Tuple<Int64, Int64> AgentRenewal_Display_Documents_ByDocCodeInfoAgentID(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, Int64 AgentDoc_InfoCode, string UserID)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Documents_ByDocCodeInfoAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"]);
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }

        //Delete Agent-Renewal
        public bool Delete_AgentRenewal_DocumentsDetail_byID(Int64 mIndexID, Int64 mExtractID, Int64 mRenewalAgentID, Int64 mAgentID, string mUserID)
        {
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_RenewalAgentID = 0;
            Int64 User_AgentID = 0;
            Int32 i = 0;
            string UserID = string.Empty;

            try
            {
                User_IndexID = mIndexID;
                User_ExtractID = mExtractID;
                User_RenewalAgentID = mRenewalAgentID;
                User_AgentID = mAgentID;
                UserID = mUserID;

                connection();
                MySqlCommand cmd = new MySqlCommand("Delete_Rera_AgentRenewal_DocumentsDetail_ByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Agent_Index_ID", User_IndexID);
                cmd.Parameters.AddWithValue("p_Agent_Extract_ID", User_ExtractID);
                cmd.Parameters.AddWithValue("p_Agent_RenewalAgent_ID", User_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Agent_ID", User_AgentID);
                cmd.Parameters.AddWithValue("p_Agent_User_ID", UserID);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                string str = ex.ToString();
            }

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}