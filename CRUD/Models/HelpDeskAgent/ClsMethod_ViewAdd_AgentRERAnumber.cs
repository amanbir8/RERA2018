using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_ViewAdd_AgentRERAnumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> Display_AuthDesk_AgentRERAnumber_ByAgentIdandDiaryNumber(Int64 AgentId)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> Agent_Documents_AgentId = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_RERAnumber_registration_AgentId_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agent_Documents_AgentId.Add(
                    new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber
                    {
                        Agent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_IndexID"]),
                        Agent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_ID"]),
                        AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                        AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        UserID = Convert.ToString(dr["UserID"]),

                        OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                        DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                        UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                        PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                        AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                        EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                        tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),

                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        Project_Name = Convert.ToString(dr["Project_Name"]),

                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                        IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                        ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                        Agent_Type = Convert.ToString(dr["Agent_Type"]), //int(11)
                        Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                        Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]), //int(11)
                        BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]), //int(11)
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),

                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Extra4 = Convert.ToString(dr["Extra4"]),

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
            return Agent_Documents_AgentId;
        }

        /// Save Method        
        public bool Add_LDR_Agent_RERAnumber_DiaryNumber(ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber smodel, string User_Name, Int64 oAgent_ID, string oAgentDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Agent_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Agent_RERAnumber_DiaryNumber_IndexID", (smodel.Agent_RERAnumber_DiaryNumber_IndexID == 0) ? 0 : smodel.Agent_RERAnumber_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Agent_RERAnumber_DiaryNumber_ID", (smodel.Agent_RERAnumber_DiaryNumber_ID == 0) ? 0 : smodel.Agent_RERAnumber_DiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", String.IsNullOrEmpty(oAgentDiaryNumber) ? "" : oAgentDiaryNumber);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.AgentRegDiaryNumber_NameYear) ? "" : smodel.AgentRegDiaryNumber_NameYear);

            cmd.Parameters.AddWithValue("p_Agent_ID", oAgent_ID);
            cmd.Parameters.AddWithValue("p_UserID", String.IsNullOrEmpty(smodel.UserID) ? "" : smodel.UserID);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_OtherMemDetailsCount", (smodel.OtherMemDetailsCount == 0) ? 0 : smodel.OtherMemDetailsCount);
            cmd.Parameters.AddWithValue("p_DocumentuploadsCount", (smodel.DocumentuploadsCount == 0) ? 0 : smodel.DocumentuploadsCount);
            cmd.Parameters.AddWithValue("p_UTotherStateRERACount", (smodel.UTotherStateRERACount == 0) ? 0 : smodel.UTotherStateRERACount);
            cmd.Parameters.AddWithValue("p_PaymentsCount", (smodel.PaymentsCount == 0) ? 0 : smodel.PaymentsCount);
            cmd.Parameters.AddWithValue("p_AgentDocumentCount", (smodel.AgentDocumentCount == 0) ? 0 : smodel.AgentDocumentCount);

            cmd.Parameters.AddWithValue("p_CurrentEventcode", (smodel.CurrentEventcode == 0) ? 0 : smodel.CurrentEventcode);
            cmd.Parameters.AddWithValue("p_EventCodeDetails_indexID", (smodel.EventCodeDetails_indexID == 0) ? 0 : smodel.EventCodeDetails_indexID);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_Project_ID", (smodel.Project_ID == 0) ? 0 : smodel.Project_ID);
            cmd.Parameters.AddWithValue("p_Project_Name", String.IsNullOrEmpty(smodel.Project_Name) ? "" : smodel.Project_Name);

            cmd.Parameters.AddWithValue("p_Promoter_ID", (smodel.Promoter_ID == 0) ? 0 : smodel.Promoter_ID);
            cmd.Parameters.AddWithValue("p_Promoter_Name", String.IsNullOrEmpty(smodel.Promoter_Name) ? "" : smodel.Promoter_Name);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? "" : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? "" : smodel.ExistingRegistration);

            cmd.Parameters.AddWithValue("p_Agent_Type", String.IsNullOrEmpty(smodel.Agent_Type) ? "" : smodel.Agent_Type);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", String.IsNullOrEmpty(smodel.Agent_FirstName) ? "" : smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", String.IsNullOrEmpty(smodel.Agent_MiddleName) ? "" : smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Organization_Name", String.IsNullOrEmpty(smodel.Organization_Name) ? "" : smodel.Organization_Name);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", String.IsNullOrEmpty(smodel.BComm_AddressStateCode) ? "" : smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", String.IsNullOrEmpty(smodel.BComm_AddressDistrictCode) ? "" : smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_MobileNumber", (smodel.MobileNumber == 0) ? 0 : smodel.MobileNumber);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// Update Method        
        public bool Update_LDR_Agent_RERAnumber_DiaryNumber(ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber smodel, string User_Name, Int64 oAgent_ID, string oAgentDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Agent_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Agent_RERAnumber_DiaryNumber_IndexID", (smodel.Agent_RERAnumber_DiaryNumber_IndexID == 0) ? 0 : smodel.Agent_RERAnumber_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Agent_RERAnumber_DiaryNumber_ID", (smodel.Agent_RERAnumber_DiaryNumber_ID == 0) ? 0 : smodel.Agent_RERAnumber_DiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", String.IsNullOrEmpty(oAgentDiaryNumber) ? "" : oAgentDiaryNumber);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.AgentRegDiaryNumber_NameYear) ? "" : smodel.AgentRegDiaryNumber_NameYear);

            cmd.Parameters.AddWithValue("p_Agent_ID", oAgent_ID);
            cmd.Parameters.AddWithValue("p_UserID", String.IsNullOrEmpty(smodel.UserID) ? "" : smodel.UserID);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_OtherMemDetailsCount", (smodel.OtherMemDetailsCount == 0) ? 0 : smodel.OtherMemDetailsCount);
            cmd.Parameters.AddWithValue("p_DocumentuploadsCount", (smodel.DocumentuploadsCount == 0) ? 0 : smodel.DocumentuploadsCount);
            cmd.Parameters.AddWithValue("p_UTotherStateRERACount", (smodel.UTotherStateRERACount == 0) ? 0 : smodel.UTotherStateRERACount);
            cmd.Parameters.AddWithValue("p_PaymentsCount", (smodel.PaymentsCount == 0) ? 0 : smodel.PaymentsCount);
            cmd.Parameters.AddWithValue("p_AgentDocumentCount", (smodel.AgentDocumentCount == 0) ? 0 : smodel.AgentDocumentCount);

            cmd.Parameters.AddWithValue("p_CurrentEventcode", (smodel.CurrentEventcode == 0) ? 0 : smodel.CurrentEventcode);
            cmd.Parameters.AddWithValue("p_EventCodeDetails_indexID", (smodel.EventCodeDetails_indexID == 0) ? 0 : smodel.EventCodeDetails_indexID);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_Project_ID", (smodel.Project_ID == 0) ? 0 : smodel.Project_ID);
            cmd.Parameters.AddWithValue("p_Project_Name", String.IsNullOrEmpty(smodel.Project_Name) ? "" : smodel.Project_Name);

            cmd.Parameters.AddWithValue("p_Promoter_ID", (smodel.Promoter_ID == 0) ? 0 : smodel.Promoter_ID);
            cmd.Parameters.AddWithValue("p_Promoter_Name", String.IsNullOrEmpty(smodel.Promoter_Name) ? "" : smodel.Promoter_Name);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? "" : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? "" : smodel.ExistingRegistration);

            cmd.Parameters.AddWithValue("p_Agent_Type", String.IsNullOrEmpty(smodel.Agent_Type) ? "" : smodel.Agent_Type);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", String.IsNullOrEmpty(smodel.Agent_FirstName) ? "" : smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", String.IsNullOrEmpty(smodel.Agent_MiddleName) ? "" : smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Organization_Name", String.IsNullOrEmpty(smodel.Organization_Name) ? "" : smodel.Organization_Name);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", String.IsNullOrEmpty(smodel.BComm_AddressStateCode) ? "" : smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", String.IsNullOrEmpty(smodel.BComm_AddressDistrictCode) ? "" : smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_MobileNumber", (smodel.MobileNumber == 0) ? 0 : smodel.MobileNumber);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

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

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumber(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegRERAnumberDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberDetails
                       {
                           Agent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_IndexID"]),
                           Agent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                           DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                           UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                           PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),

                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                           Agent_Type = Convert.ToString(dr["Agent_Type"]),
                           Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                           Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                           Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                           Organization_Name = Convert.ToString(dr["Organization_Name"]),
                           BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                           BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                           EmailAddress = Convert.ToString(dr["EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           Extra2 = Convert.ToString("Extra2"),
                           Extra3 = Convert.ToString("Extra3"),
                           Extra4 = Convert.ToString("Extra4"),

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

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> Display_AuthDesk_AgentRERAnumberDashBoard_ByAgentIdandDiaryNumberDate(int? approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegRERAnumberDetailsByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_approvalyear", approvalyear);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberDetails
                       {
                           Agent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_IndexID"]),
                           Agent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                           DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                           UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                           PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),

                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                           Agent_Type = Convert.ToString(dr["Agent_Type"]),
                           Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                           Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                           Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                           Organization_Name = Convert.ToString(dr["Organization_Name"]),
                           BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                           BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                           EmailAddress = Convert.ToString(dr["EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           Extra2 = Convert.ToString("Extra2"),
                           Extra3 = Convert.ToString("Extra3"),
                           Extra4 = Convert.ToString("Extra4"),

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

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ProjectFivelist1;
        }

        //Generate Registration Number
        public Tuple<DateTime, DateTime> Extract_AuthDesk_AgentRegistrationNumberDateDetails_ByID(Int64 oAgent_ID, string oUserID)
        {
            connection();
            DateTime retIssueDate = DateTime.Now;
            DateTime retUptoDate = DateTime.Now;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegToFromDateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", oAgent_ID);
            cmd.Parameters.AddWithValue("p_UserID", oUserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                retIssueDate = Convert.ToDateTime(dr["registrationIssueDate"]);
                retUptoDate = Convert.ToDateTime(dr["registrationUptoDate"]);
            }
            return new Tuple<DateTime, DateTime>(retIssueDate, retUptoDate);
        }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> Extract_AuthDesk_AgentRegistrationNumber_ByAgentID(Int64 prmAgentID, Int32 prmOptionFlag, string prmAgentStateTypeFlag, DateTime prmIssueDate, DateTime prmUptoDate, string prmUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> Agentlist = new List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationNumbers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", prmUserRole);
            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", prmAgentID);
            cmd.Parameters.AddWithValue("p_RegistrationNumberOptions", prmOptionFlag);
            cmd.Parameters.AddWithValue("p_AgentStateType_Input", prmAgentStateTypeFlag);
            cmd.Parameters.AddWithValue("p_IssueDate_Input", prmIssueDate);
            cmd.Parameters.AddWithValue("p_ValidUptoDate_Input", prmUptoDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agentlist.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails
                       {
                           Prepared_SequenceNumber = Convert.ToString(dr["vPrepared_SequenceNumber"]),
                           Prepared_AgentStateType = Convert.ToString(dr["vPrepared_AgentStateType"]),
                           Prepared_NumberTypeFlag = Convert.ToString(dr["vPrepared_NumberTypeFlag"]),

                           Prepared_RegistrationNumber = Convert.ToString(dr["vPrepared_RegistrationNumber"]),
                           Prepared_IssueDate = Convert.ToDateTime(dr["vPrepared_IssueDate"]),
                           Prepared_ValidUptoDate = Convert.ToDateTime(dr["vPrepared_ValidUptoDate"]),

                           Amount_PriceValue = Convert.ToDecimal(dr["vAmountPriceValue"]),
                           NumberAlreadyExisted_Flag = Convert.ToString(dr["vNumberAlreadyExisted_Flag"]),

                           RealEstateAgentName = Convert.ToString(dr["RealEstateAgentName"]),
                           RealEstateAgentRegDiaryNumber_Name = Convert.ToString(dr["RealEstateAgentRegDiaryNumber_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                       });
            }
            return Agentlist;
        }

        public bool Check_UniqueAgentRegistrationNumber(string RegdNumber)
        {
            bool rval = false;
            Int32 rvalcount = 0;
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_Agent_AlreadyExistRegistrationNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_RegistrationNumber", RegdNumber);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                rvalcount = Convert.ToInt32(dr["CountRegistrationNumber"]);
            }

            if (rvalcount > 0)
            {
                rval = true;
            }
            cmd.Dispose();
            con.Close();
            return rval;
        }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> Display_AuthDesk_AgentRegistrationNumberHistory_ByAgentID(Int64 prmAgentID, string prmUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> Agentlist = new List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationNumberHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", prmUserRole);
            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", prmAgentID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agentlist.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails
                       {
                           Prepared_SequenceNumber = Convert.ToString(dr["vPrepared_SequenceNumber"]),
                           Prepared_AgentStateType = Convert.ToString(dr["vPrepared_AgentStateType"]),
                           Prepared_NumberTypeFlag = Convert.ToString(dr["vPrepared_NumberTypeFlag"]),

                           Prepared_RegistrationNumber = Convert.ToString(dr["vPrepared_RegistrationNumber"]),
                           Prepared_IssueDate = Convert.ToDateTime(dr["vPrepared_IssueDate"]),
                           Prepared_ValidUptoDate = Convert.ToDateTime(dr["vPrepared_ValidUptoDate"]),

                           Amount_PriceValue = Convert.ToDecimal(dr["vAmountPriceValue"]),
                           NumberAlreadyExisted_Flag = Convert.ToString(dr["vNumberAlreadyExisted_Flag"]),

                           RealEstateAgentName = Convert.ToString(dr["RealEstateAgentName"]),
                           RealEstateAgentRegDiaryNumber_Name = Convert.ToString(dr["RealEstateAgentRegDiaryNumber_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                       });
            }
            return Agentlist;
        }


        public List<ClsPrp_Agent_Search_Helpdesk> DisplayAgentBySearchterm(string UserID_Role, string serachterm, string searchtype)
        {
            connection();
            List<ClsPrp_Agent_Search_Helpdesk> AgentReralist = new List<ClsPrp_Agent_Search_Helpdesk>();

            MySqlCommand cmd = new MySqlCommand("DisplayByAgentSearch", con);
            //MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_test", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_searchterm", serachterm);
            cmd.Parameters.AddWithValue("p_searchtype", searchtype);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new ClsPrp_Agent_Search_Helpdesk
                       {
                           Agent_ID = dr["Agent_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Agent_ID"]),
                           BComm_AddressDistrictCode = dr["BComm_AddressDistrictCode"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"] ?? ""),
                           RERAnumberIssueDate = dr["RERAnumberIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = dr["RERAnumberRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           Agent_FirstName = Convert.ToString(dr["Agent_FirstName"] ?? ""),
                           Agent_LastName = Convert.ToString(dr["Agent_LastName"] ?? ""),
                           AgentRERAcert_IssueDate = dr["AgentRERAcert_IssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"] ?? ""),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"] ?? ""),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"] ?? ""),
                           redAgent_ID = dr["redAgent_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["redAgent_ID"]),
                           EventAction_IdentifiedOn = dr["EventAction_IdentifiedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"] ?? ""),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"] ?? ""),
                           CreatedOn = dr["CreatedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CreatedOn"]),
                       });
            }
            return AgentReralist;
        }
    }
}