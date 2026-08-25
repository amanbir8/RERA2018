using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Agent;

namespace CRUD.Models.Agent
{
    public class ClsMethod_Agent_DiaryNumberAgentDashbaord
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Agent_DiaryNumberAgentDashbaord> Display_Agent_Dashboard_RegDiaryNumberByAgentID(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_Agent_DiaryNumberAgentDashbaord> AgentList = new List<ClsPrp_Agent_DiaryNumberAgentDashbaord>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Dashboard_RegistrationNumberByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_Agent_DiaryNumberAgentDashbaord
                       {
                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                           RERA_Registration_IssueDate = Convert.ToDateTime(dr["RERA_Registration_IssueDate"]),
                           RERA_Registration_ValidUptoDate = Convert.ToDateTime(dr["RERA_Registration_ValidUptoDate"]),
                           LastRenewal_Registration_IssueDate = Convert.ToDateTime(dr["LastRenewal_Registration_IssueDate"]),
                           LastRenewal_Registration_ValidUptoDate = Convert.ToDateTime(dr["LastRenewal_Registration_ValidUptoDate"]),
                           Registration_Number_Flag = Convert.ToInt32(dr["Registration_Number_Flag"]),
                           Registration_Number_Status = Convert.ToString(dr["Registration_Number_Status"]),
                       });
            }
            return AgentList;
        }

        public List<ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord> Display_Agent_Dashboard_RenewalRegistrationDiaryNumberByAgentID(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord> AgentList = new List<ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Dashboard_RenewalRegistrationNumberByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_TypeOfAgent_ID", TypeOfAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord
                       {
                           RenewalAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgent_RegDiaryNumber_IndexID"]),
                           RenewalAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgent_RegDiaryNumber_ID"]),

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

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           RenewalAgentRegDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentRegDiaryNumber_ID"]),
                           RenewalAgentRegDiaryNumber_Name = Convert.ToString(dr["RenewalAgentRegDiaryNumber_Name"]),
                           RenewalAgentRegDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentRegDiaryNumber_NameYear"]),

                           Registration_Number_Code = Convert.ToInt64(dr["Registration_Number_Code"]),
                           Registration_Number_EventTypeID = Convert.ToInt64(dr["Registration_Number_EventTypeID"]),
                           Registration_Number_SeqOrder = Convert.ToString(dr["Registration_Number_SeqOrder"]),

                           Registration_Number_ReferenceID = Convert.ToInt64(dr["Registration_Number_ReferenceID"]),
                           Registration_Number_ReferenceNumber = Convert.ToString(dr["Registration_Number_ReferenceNumber"]),
                           Registration_Number_ReferenceDate = Convert.ToDateTime(dr["Registration_Number_ReferenceDate"]),
                           Registration_Number_IsLatestRenewal_Flag = Convert.ToInt32(dr["Registration_Number_IsLatestRenewal_Flag"]),

                           RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                           RERA_Registration_IssueDate = Convert.ToDateTime(dr["RERA_Registration_IssueDate"]),
                           RERA_Registration_ValidUptoDate = Convert.ToDateTime(dr["RERA_Registration_ValidUptoDate"]),
                           LastRenewal_Registration_IssueDate = Convert.ToDateTime(dr["LastRenewal_Registration_IssueDate"]),
                           LastRenewal_Registration_ValidUptoDate = Convert.ToDateTime(dr["LastRenewal_Registration_ValidUptoDate"]),
                           Registration_Number_Flag = Convert.ToInt32(dr["Registration_Number_Flag"]),
                           Registration_Number_Status = Convert.ToString(dr["Registration_Number_Status"]),
                       });
            }
            return AgentList;
        }

        //Pop-Up
        public List<Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog> Display_Agent_Dashboard_AgentCheckList_NoAccept_DetailsByCode(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog> ProjectFivelist1 = new List<Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog
                       {
                           AgentCheckListAction_ID = Convert.ToInt64(dr["AgentCheckListAction_ID"]),
                           CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                           UserRole = Convert.ToString(dr["UserRole"]),
                           CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           CriteriaCode = Convert.ToString(dr["CriteriaCode"]),
                           CriteriaSubCode = Convert.ToString(dr["CriteriaSubCode"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsChecklistValueOk = Convert.ToString(dr["IsChecklistValueOk"]),
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
            return ProjectFivelist1;
        }

        public List<ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord> Display_Agent_Dashboard_RenewalRegistrationDiaryNumber_DetailsByID(Int64 Agent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord> AgentList = new List<ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Dashboard_RenewalRegistrationNumber_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);            
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_RenewalAgent_DiaryNumberAgentDashbaord
                       {
                           RenewalAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgent_RegDiaryNumber_IndexID"]),
                           RenewalAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgent_RegDiaryNumber_ID"]),

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

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           RenewalAgentRegDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentRegDiaryNumber_ID"]),
                           RenewalAgentRegDiaryNumber_Name = Convert.ToString(dr["RenewalAgentRegDiaryNumber_Name"]),
                           RenewalAgentRegDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentRegDiaryNumber_NameYear"]),

                           Registration_Number_Code = Convert.ToInt64(dr["Registration_Number_Code"]),
                           Registration_Number_EventTypeID = Convert.ToInt64(dr["Registration_Number_EventTypeID"]),
                           Registration_Number_SeqOrder = Convert.ToString(dr["Registration_Number_SeqOrder"]),

                           Registration_Number_ReferenceID = Convert.ToInt64(dr["Registration_Number_ReferenceID"]),
                           Registration_Number_ReferenceNumber = Convert.ToString(dr["Registration_Number_ReferenceNumber"]),
                           Registration_Number_ReferenceDate = Convert.ToDateTime(dr["Registration_Number_ReferenceDate"]),
                           Registration_Number_IsLatestRenewal_Flag = Convert.ToInt32(dr["Registration_Number_IsLatestRenewal_Flag"]),

                           RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                           RERA_Registration_IssueDate = Convert.ToDateTime(dr["RERA_Registration_IssueDate"]),
                           RERA_Registration_ValidUptoDate = Convert.ToDateTime(dr["RERA_Registration_ValidUptoDate"]),
                           LastRenewal_Registration_IssueDate = Convert.ToDateTime(dr["LastRenewal_Registration_IssueDate"]),
                           LastRenewal_Registration_ValidUptoDate = Convert.ToDateTime(dr["LastRenewal_Registration_ValidUptoDate"]),
                           Registration_Number_Flag = Convert.ToInt32(dr["Registration_Number_Flag"]),
                           Registration_Number_Status = Convert.ToString(dr["Registration_Number_Status"]),
                       });
            }
            return AgentList;
        }

        public List<ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList> Display_Agent_Dashboard_RenewalAgent_CheckList_NoAccept_DetailsByCode(Int64 Agent_ID, Int64 RnAgent_ID, Int32 RnAgent_SeqID, Int32 RnAgent_YrID, string UserID_Role)
        {
            connection();
            List<ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList> Agentlist = new List<ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_RenewalAgentCheckList_NoAccept_DeskByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgent_SeqID);
                cmd.Parameters.AddWithValue("p_RenewalnAgent_YearID", RnAgent_YrID);
                cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList
                           {
                               RenewalAgentCheckListAction_ID = Convert.ToInt64(dr["RenewalAgentCheckListAction_ID"]),
                               CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                               UserRole = Convert.ToString(dr["UserRole"]),
                               CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),
                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               RelatedAgent_DiaryNumber = Convert.ToString(dr["RelatedAgent_DiaryNumber"]),
                               RelatedAgent_RenewalDiaryNumber = Convert.ToString(dr["RelatedAgent_RenewalDiaryNumber"]),
                               RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                               CriteriaCode = Convert.ToString(dr["CriteriaCode"]),
                               CriteriaSubCode = Convert.ToString(dr["CriteriaSubCode"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               IsChecklistValueOk = Convert.ToString(dr["IsChecklistValueOk"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }
    }
}