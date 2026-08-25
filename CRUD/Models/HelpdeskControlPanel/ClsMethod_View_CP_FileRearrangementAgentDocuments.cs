using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsMethod_View_CP_FileRearrangementAgentDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //File Re-arrangement Panel - Agent Documents
        public List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails> Display_CP_AgentFileRearrangementPanelDetails_ByID(Int32 pApplicationFlag, string pRegistrationNumber, string pApplicationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_Agent_FileRearrangementAgentDocument_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ApplicationFlag", pApplicationFlag);
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ApplicationNumber", pApplicationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails
                    {
                        AgentDoc_IndexID = Convert.ToInt64(dr["AgentDoc_IndexID"]),
                        AgentDoc_ID = Convert.ToInt64(dr["AgentDoc_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentRenewal_ID = Convert.ToInt64(dr["AgentRenewal_ID"]),
                        AgentDoc_InfoCode = Convert.ToInt32(dr["AgentDoc_InfoCode"]),
                        AgentDoc_InfoName = Convert.ToString(dr["AgentDoc_InfoName"]),
                        AgentDoc_ReferenceNumber = Convert.ToString(dr["AgentDoc_ReferenceNumber"]),
                        AgentDoc_IssueDate = Convert.ToDateTime(dr["AgentDoc_IssueDate"]),
                        AgentDoc_FileSize = Convert.ToString(dr["AgentDoc_FileSize"]),
                        AgentDoc_FileFormat = Convert.ToString(dr["AgentDoc_FileFormat"]),
                        AgentDoc_FilePath = Convert.ToString(dr["AgentDoc_FilePath"]),
                        AgentDoc_FileName = Convert.ToString(dr["AgentDoc_FileName"]),
                        AgentDoc_IsGroup = Convert.ToInt32(dr["AgentDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        IsRERAregisteredAgent = Convert.ToInt32(dr["IsRERAregisteredAgent"]),
                        Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        Agent_Name = Convert.ToString(dr["Agent_Name"]),
                        Type_of_Agent = Convert.ToString(dr["Type_of_Agent"]),
                        AgentAddressDistrict = Convert.ToString(dr["AgentAddressDistrict"]),

                        Extra01_column = Convert.ToString(dr["Extra01_column"]),
                        Extra02_column = Convert.ToString(dr["Extra02_column"]),
                    });
            }
            return CPstatusList;
        }

        public List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails> Display_CP_AgentFileRearrangementPanelSelectedRecord_ByID(Int64 magentId, Int64 magentrenewalId, Int64 mrefdocId, Int64 mrefindexId, Int64 mrefId, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_Agent_FileModifyAgentSelectedRecord_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentID", magentId);
            cmd.Parameters.AddWithValue("p_AgentRenewalID", magentrenewalId);
            cmd.Parameters.AddWithValue("p_RefDocID", mrefdocId);
            cmd.Parameters.AddWithValue("p_RefIndexID", mrefindexId);
            cmd.Parameters.AddWithValue("p_RefID", mrefId);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails
                    {
                        AgentDoc_IndexID = Convert.ToInt64(dr["AgentDoc_IndexID"]),
                        AgentDoc_ID = Convert.ToInt64(dr["AgentDoc_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentRenewal_ID = Convert.ToInt64(dr["AgentRenewal_ID"]),
                        AgentDoc_InfoCode = Convert.ToInt32(dr["AgentDoc_InfoCode"]),
                        AgentDoc_InfoName = Convert.ToString(dr["AgentDoc_InfoName"]),
                        AgentDoc_ReferenceNumber = Convert.ToString(dr["AgentDoc_ReferenceNumber"]),
                        AgentDoc_IssueDate = Convert.ToDateTime(dr["AgentDoc_IssueDate"]),
                        AgentDoc_FileSize = Convert.ToString(dr["AgentDoc_FileSize"]),
                        AgentDoc_FileFormat = Convert.ToString(dr["AgentDoc_FileFormat"]),
                        AgentDoc_FilePath = Convert.ToString(dr["AgentDoc_FilePath"]),
                        AgentDoc_FileName = Convert.ToString(dr["AgentDoc_FileName"]),
                        AgentDoc_IsGroup = Convert.ToInt32(dr["AgentDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                        Agent_Name = Convert.ToString(dr["Agent_Name"]),
                        Type_of_Agent = Convert.ToString(dr["Type_of_Agent"]),
                        AgentAddressDistrict = Convert.ToString(dr["AgentAddressDistrict"]),

                        Extra01_column = Convert.ToString(dr["Extra01_column"]),
                        Extra02_column = Convert.ToString(dr["Extra02_column"]),
                    });
            }
            return CPstatusList;
        }

        public Tuple<bool, string> Update_CP_AgentDocuments_FileRearrangementPanel_ByID(ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails smodel, string User_Name, string User_ID, string User_Role)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_agent_CP_FileRearrangementPanel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters           
            cmd.Parameters.AddWithValue("p_AgentDoc_IndexID", (smodel.AgentDoc_IndexID == 0) ? 0 : smodel.AgentDoc_IndexID);
            cmd.Parameters.AddWithValue("p_AgentDoc_ID", (smodel.AgentDoc_ID == 0) ? 0 : smodel.AgentDoc_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", (smodel.Agent_ID == 0) ? 0 : smodel.Agent_ID);
            cmd.Parameters.AddWithValue("p_AgentRenewal_ID", (smodel.AgentRenewal_ID == 0) ? 0 : smodel.AgentRenewal_ID);
            cmd.Parameters.AddWithValue("p_User_ID", User_ID);
            cmd.Parameters.AddWithValue("p_User_Role", User_Role);

            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", (smodel.AgentDoc_InfoCode == 0) ? 0 : smodel.AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoName", String.IsNullOrEmpty(smodel.AgentDoc_InfoName) ? string.Empty : smodel.AgentDoc_InfoName);            
            cmd.Parameters.AddWithValue("p_AgentDoc_ReferenceNumber", String.IsNullOrEmpty(smodel.AgentDoc_ReferenceNumber) ? string.Empty : smodel.AgentDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentDoc_IssueDate", smodel.AgentDoc_IssueDate.HasValue ? smodel.AgentDoc_IssueDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_AgentDoc_FileSize", String.IsNullOrEmpty(smodel.AgentDoc_FileSize) ? string.Empty : smodel.AgentDoc_FileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileFormat", String.IsNullOrEmpty(smodel.AgentDoc_FileFormat) ? string.Empty : smodel.AgentDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_FilePath", String.IsNullOrEmpty(smodel.AgentDoc_FilePath) ? string.Empty : smodel.AgentDoc_FilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileName", String.IsNullOrEmpty(smodel.AgentDoc_FileName) ? string.Empty : smodel.AgentDoc_FileName);
            cmd.Parameters.AddWithValue("p_AgentDoc_IsGroup", (smodel.AgentDoc_IsGroup == 0) ? 0 : smodel.AgentDoc_IsGroup);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? string.Empty : smodel.D_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            cmd.Parameters.AddWithValue("p_Agent_DiaryNumber", String.IsNullOrEmpty(smodel.Agent_DiaryNumber) ? string.Empty : smodel.Agent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationNumber", String.IsNullOrEmpty(smodel.RERA_RegistrationNumber) ? string.Empty : smodel.RERA_RegistrationNumber);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_Agent_Name", String.IsNullOrEmpty(smodel.Agent_Name) ? string.Empty : smodel.Agent_Name);
            cmd.Parameters.AddWithValue("p_Type_of_Agent", String.IsNullOrEmpty(smodel.Type_of_Agent) ? string.Empty : smodel.Type_of_Agent);
            cmd.Parameters.AddWithValue("p_AgentAddressDistrict", String.IsNullOrEmpty(smodel.AgentAddressDistrict) ? string.Empty : smodel.AgentAddressDistrict);
            cmd.Parameters.AddWithValue("p_IsRERAregisteredAgent", (smodel.IsRERAregisteredAgent == 0) ? 0 : smodel.IsRERAregisteredAgent);
            cmd.Parameters.AddWithValue("p_Extra01_column", String.IsNullOrEmpty(smodel.Extra01_column) ? string.Empty : smodel.Extra01_column);
            cmd.Parameters.AddWithValue("p_Extra02_column", String.IsNullOrEmpty(smodel.Extra02_column) ? string.Empty : smodel.Extra02_column);

            cmd.Parameters.AddWithValue("p_Application_SearchTypeFlag", (smodel.Application_SearchTypeFlag == 0) ? 0 : smodel.Application_SearchTypeFlag);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration_Input", String.IsNullOrEmpty(smodel.RERAnumberRegistration_Input) ? string.Empty : smodel.RERAnumberRegistration_Input);
            cmd.Parameters.AddWithValue("p_AgentDiaryNumber_Input", String.IsNullOrEmpty(smodel.AgentDiaryNumber_Input) ? string.Empty : smodel.AgentDiaryNumber_Input);
            cmd.Parameters.AddWithValue("p_IsUpdateModifyFlag_AgentDocument", (smodel.IsUpdateModifyFlag_AgentDocument == 0) ? 0 : smodel.IsUpdateModifyFlag_AgentDocument);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode_Input", (smodel.AgentDoc_InfoCode_Input == 0) ? 0 : smodel.AgentDoc_InfoCode_Input);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode_ConfirmInput", (smodel.AgentDoc_InfoCode_ConfirmInput == 0) ? 0 : smodel.AgentDoc_InfoCode_ConfirmInput);
            cmd.Parameters.AddWithValue("p_AgentDoc_ReferenceNumber_Input", String.IsNullOrEmpty(smodel.AgentDoc_ReferenceNumber_Input) ? string.Empty : smodel.AgentDoc_ReferenceNumber_Input);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny_Input", String.IsNullOrEmpty(smodel.Remarks_IfAny_Input) ? string.Empty : smodel.Remarks_IfAny_Input);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }

        public Tuple<bool, string> Delete_CP_AgentDocuments_FileRearrangementPanel_ByID(ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails smodel, string User_Name, string User_ID, string User_Role)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_deleteTrash_tbl_rera_agent_CP_FileRearrangementPanel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters           
            cmd.Parameters.AddWithValue("p_AgentDoc_IndexID", (smodel.AgentDoc_IndexID == 0) ? 0 : smodel.AgentDoc_IndexID);
            cmd.Parameters.AddWithValue("p_AgentDoc_ID", (smodel.AgentDoc_ID == 0) ? 0 : smodel.AgentDoc_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", (smodel.Agent_ID == 0) ? 0 : smodel.Agent_ID);
            cmd.Parameters.AddWithValue("p_AgentRenewal_ID", (smodel.AgentRenewal_ID == 0) ? 0 : smodel.AgentRenewal_ID);
            cmd.Parameters.AddWithValue("p_User_ID", User_ID);
            cmd.Parameters.AddWithValue("p_User_Role", User_Role);

            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", (smodel.AgentDoc_InfoCode == 0) ? 0 : smodel.AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoName", String.IsNullOrEmpty(smodel.AgentDoc_InfoName) ? string.Empty : smodel.AgentDoc_InfoName);

            cmd.Parameters.AddWithValue("p_Agent_DiaryNumber", String.IsNullOrEmpty(smodel.Agent_DiaryNumber) ? string.Empty : smodel.Agent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationNumber", String.IsNullOrEmpty(smodel.RERA_RegistrationNumber) ? string.Empty : smodel.RERA_RegistrationNumber);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_Agent_Name", String.IsNullOrEmpty(smodel.Agent_Name) ? string.Empty : smodel.Agent_Name);
            cmd.Parameters.AddWithValue("p_Type_of_Agent", String.IsNullOrEmpty(smodel.Type_of_Agent) ? string.Empty : smodel.Type_of_Agent);
            cmd.Parameters.AddWithValue("p_AgentAddressDistrict", String.IsNullOrEmpty(smodel.AgentAddressDistrict) ? string.Empty : smodel.AgentAddressDistrict);
            cmd.Parameters.AddWithValue("p_IsRERAregisteredAgent", (smodel.IsRERAregisteredAgent == 0) ? 0 : smodel.IsRERAregisteredAgent);
            cmd.Parameters.AddWithValue("p_Extra01_column", String.IsNullOrEmpty(smodel.Extra01_column) ? string.Empty : smodel.Extra01_column);
            cmd.Parameters.AddWithValue("p_Extra02_column", String.IsNullOrEmpty(smodel.Extra02_column) ? string.Empty : smodel.Extra02_column);

            cmd.Parameters.AddWithValue("p_Application_SearchTypeFlag", (smodel.Application_SearchTypeFlag == 0) ? 0 : smodel.Application_SearchTypeFlag);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration_Input", String.IsNullOrEmpty(smodel.RERAnumberRegistration_Input) ? string.Empty : smodel.RERAnumberRegistration_Input);
            cmd.Parameters.AddWithValue("p_AgentDiaryNumber_Input", String.IsNullOrEmpty(smodel.AgentDiaryNumber_Input) ? string.Empty : smodel.AgentDiaryNumber_Input);
            cmd.Parameters.AddWithValue("p_IsUpdateModifyFlag_AgentDocument", (smodel.IsUpdateModifyFlag_AgentDocument == 0) ? 0 : smodel.IsUpdateModifyFlag_AgentDocument);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }

        //File Re-arrangement Add More - Agent Documents
        public List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails> Display_CP_AgentFileRearrangementAddMoreDetails_ByID(Int32 pApplicationFlag, string pReferenceNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_Agent_FileRearrangementAgentDocsAddDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ApplicationFlag", pApplicationFlag);
            cmd.Parameters.AddWithValue("p_ReferenceNumber", pReferenceNumber);            
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails
                    {
                        AgentDoc_IndexID = Convert.ToInt64(dr["AgentDoc_IndexID"]),
                        AgentDoc_ID = Convert.ToInt64(dr["AgentDoc_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentRenewal_ID = Convert.ToInt64(dr["AgentRenewal_ID"]),
                        AgentDoc_InfoCode = Convert.ToInt32(dr["AgentDoc_InfoCode"]),
                        AgentDoc_InfoName = Convert.ToString(dr["AgentDoc_InfoName"]),
                        AgentDoc_ReferenceNumber = Convert.ToString(dr["AgentDoc_ReferenceNumber"]),
                        AgentDoc_IssueDate = Convert.ToDateTime(dr["AgentDoc_IssueDate"]),
                        AgentDoc_FileSize = Convert.ToString(dr["AgentDoc_FileSize"]),
                        AgentDoc_FileFormat = Convert.ToString(dr["AgentDoc_FileFormat"]),
                        AgentDoc_FilePath = Convert.ToString(dr["AgentDoc_FilePath"]),
                        AgentDoc_FileName = Convert.ToString(dr["AgentDoc_FileName"]),
                        AgentDoc_IsGroup = Convert.ToInt32(dr["AgentDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        IsRERAregisteredAgent = Convert.ToInt32(dr["IsRERAregisteredAgent"]),
                        Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        Agent_Name = Convert.ToString(dr["Agent_Name"]),
                        Type_of_Agent = Convert.ToString(dr["Type_of_Agent"]),
                        AgentAddressDistrict = Convert.ToString(dr["AgentAddressDistrict"]),

                        Extra01_column = Convert.ToString(dr["Extra01_column"]),
                        Extra02_column = Convert.ToString(dr["Extra02_column"]),
                    });
            }
            return CPstatusList;
        }

        public bool Add_Agent_FileReArrangementDocuments(ClsPrp_ControlPanel_View_FileRearrangementAgentDocumentDetails smodel, Int64 oAgent_ID, String oAgentDoc_FilePath, String oAgentDoc_FileName, String oAgentDoc_FileSize, String oAgentDoc_FileFormat, Int32 oAgentDoc_IsGroup, Int64 oAgentRenewal_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Agent_Documents_FileReArrangement", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentDoc_IndexID", (smodel.AgentDoc_IndexID == 0) ? 0 : smodel.AgentDoc_IndexID);
            cmd.Parameters.AddWithValue("p_AgentDoc_ID", (smodel.AgentDoc_ID == 0) ? 0 : smodel.AgentDoc_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", oAgent_ID);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", smodel.AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoName", String.IsNullOrEmpty(smodel.AgentDoc_InfoName) ? string.Empty : smodel.AgentDoc_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_ReferenceNumber", String.IsNullOrEmpty(smodel.AgentDoc_ReferenceNumber) ? string.Empty : smodel.AgentDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentDoc_IssueDate", smodel.AgentDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileSize", oAgentDoc_FileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileFormat", oAgentDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_FilePath", oAgentDoc_FilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileName", oAgentDoc_FileName);
            cmd.Parameters.AddWithValue("p_AgentDoc_IsGroup", oAgentDoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(smodel.CreatedBy) ? "Created_By" : smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(smodel.ModifyBy) ? "Modify_By" : smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

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