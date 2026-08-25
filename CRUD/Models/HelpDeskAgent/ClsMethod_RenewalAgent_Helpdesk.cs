using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_RenewalAgent_Helpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        //Renewal-Agent Details
        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }
               
        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsApproved(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationApproved", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }
        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsApprovedByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegApprovedByDate", con);
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
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsRejected(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationRejected", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationNewApp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsReSubmittedApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationReSubmitted", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsChecklistPrepared(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationChecklistPrep", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsReviewChecklist(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationReviewCL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsWithdrawn(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationWithdrawn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        //Public View 
        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicView(string KeyCode, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationPublicView", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
                cmd.Parameters.AddWithValue("p_Key", KeyCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicViewByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string KeyCode, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationPVByDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_approvalyear", approvalyear);
                cmd.Parameters.AddWithValue("p_fromDate", fromDate);
                cmd.Parameters.AddWithValue("p_toDate", toDate);
                cmd.Parameters.AddWithValue("p_filterType", filterType);
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
                cmd.Parameters.AddWithValue("p_Key", KeyCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
                           {
                               RenewalAgentDiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_IndexID"]),
                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                               documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                               UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                               PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                               AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        //Event Details
        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> Display_AuthorityDesk_RenewalAgent_AgentEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEvent_Master> Agentlist = new List<ClsPrp_AuthorityDesk_AgentEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentEvent_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agentlist.Add(
                       new ClsPrp_AuthorityDesk_AgentEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_EventLog> Display_AuthorityDesk_RenewalAgent_AgentEventLogDetails(Int64 AgentID, Int64 AgentTypeID, Int64 RnAgentID, Int64 RnAgentSeqID, Int64 RnAgentYrID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_EventLog> RnAgentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_EventLog>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentEventLogDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
                cmd.Parameters.AddWithValue("p_AgentID", AgentID);
                cmd.Parameters.AddWithValue("p_AgentTypeID", AgentTypeID);
                cmd.Parameters.AddWithValue("p_RnAgentID", RnAgentID);
                cmd.Parameters.AddWithValue("p_RnAgentSeqID", RnAgentSeqID);
                cmd.Parameters.AddWithValue("p_RnAgentYrID", RnAgentYrID);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RnAgentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_EventLog
                           {
                               RenewalAgentEventAction_ID = Convert.ToInt64(dr["RenewalAgentEventAction_ID"]),
                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),
                               RelatedAgent_DiaryNumber = Convert.ToString(dr["RelatedAgent_DiaryNumber"]),
                               RelatedAgent_RenewalDiaryNumber = Convert.ToString(dr["RelatedAgent_RenewalDiaryNumber"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                               EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                               EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                               AssignedTo = Convert.ToString(dr["AssignedTo"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                               Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                               IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
                               ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
            return RnAgentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Display_AuthorityDesk_RenewalAgent_CheckList_NoAccept_DetailsByCode(Int64 Agent_ID, Int32 AgentType_ID, Int64 RnAgent_ID, Int32 RnAgent_SeqID, Int32 RnAgent_YrID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_RenewalAgentCheckList_NoAccept_DetailsByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentType_ID);
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
                           new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog
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

        public bool Add_RenewalAgent_InfoEvent(ClsPrp_AuthorityDesk_RenewalAgent_EventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AgentRenewal_AuthDesk_EventAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_p_Related_RenewalAgent_ID", smodel.Related_RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_p_Related_RenewalAgent_Year", smodel.Related_RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_p_Related_RenewalAgent_SequenceID", smodel.Related_RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_p_Related_AgentType_ID", smodel.Related_AgentType_ID);
            cmd.Parameters.AddWithValue("p_p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_p_RelatedAgent_DiaryNumber", String.IsNullOrEmpty(smodel.RelatedAgent_DiaryNumber) ? "" : smodel.RelatedAgent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_p_RelatedAgent_RenewalDiaryNumber", String.IsNullOrEmpty(smodel.RelatedAgent_RenewalDiaryNumber) ? "" : smodel.RelatedAgent_RenewalDiaryNumber);
            cmd.Parameters.AddWithValue("p_p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_p_EventAction_Relationship", UserRole);// String.IsNullOrEmpty(smodel.EventAction_Relationship) ? "" : smodel.EventAction_Relationship);
            cmd.Parameters.AddWithValue("p_p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_IsBefore_TargetResolution", 0);
            cmd.Parameters.AddWithValue("p_p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            //return AppId;

            if (i >= 1)
                return true;
            else
                return false;
        }

        //CheckList Details
        public List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> Display_AuthorityDesk_RenewalAgent_SubCheckList_MasterDetails(Int32 CheckList_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> Agentlist = new List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgent_SubCheckListDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_CheckList_ID", CheckList_ID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_AgentSubCheckList_Master
                           {

                               SubCheckList_IndexID = Convert.ToInt32(dr["SubCheckList_IndexID"]),
                               SubCheckList_ID = Convert.ToInt32(dr["SubCheckList_ID"]),
                               SubCheckListName = Convert.ToString(dr["SubCheckListName"]),
                               SubCheckListDescription = Convert.ToString(dr["SubCheckListDescription"]),
                               CheckList_ID = Convert.ToInt32(dr["CheckList_ID"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
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

        public List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> Display_AuthorityDesk_RenewalAgent_SubCheckList_MasterDetailsByCode(Int32 SubCheckList_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> Agentlist = new List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgent_SubCheckListDetailByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_SubCheckList_ID", SubCheckList_ID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_AgentSubCheckList_Master
                           {
                               SubCheckList_IndexID = Convert.ToInt32(dr["SubCheckList_IndexID"]),
                               SubCheckList_ID = Convert.ToInt32(dr["SubCheckList_ID"]),
                               SubCheckListName = Convert.ToString(dr["SubCheckListName"]),
                               SubCheckListDescription = Convert.ToString(dr["SubCheckListDescription"]),
                               CheckList_ID = Convert.ToInt32(dr["CheckList_ID"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
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

        public bool Add_RenewalAgent_InfoCheckList(ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog smodel, string UserRole, string User_WhoIdentified)
        {
            int i = 0;
            Int64 AppId = 0;
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AgentRenewal_AuthDesk_CheckListAction", con);
                cmd.CommandType = CommandType.StoredProcedure;

                #region Parameters
                cmd.Parameters.AddWithValue("p_p_CheckList_IdentifiedBy", User_WhoIdentified);
                cmd.Parameters.AddWithValue("p_p_UserRole", UserRole);
                cmd.Parameters.AddWithValue("p_p_CheckList_IdentifiedOn", DateTime.Now);

                cmd.Parameters.AddWithValue("p_p_Related_Agent_ID", smodel.Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_p_Related_AgentType_ID", smodel.Related_AgentType_ID);
                cmd.Parameters.AddWithValue("p_p_Related_RenewalAgent_ID", smodel.Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_p_Related_RenewalAgent_Year", smodel.Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_p_Related_RenewalAgent_SequenceID", smodel.Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_p_RelatedAgent_DiaryNumber", String.IsNullOrEmpty(smodel.RelatedAgent_DiaryNumber) ? "" : smodel.RelatedAgent_DiaryNumber);
                cmd.Parameters.AddWithValue("p_p_RelatedAgent_RenewalDiaryNumber", String.IsNullOrEmpty(smodel.RelatedAgent_RenewalDiaryNumber) ? "" : smodel.RelatedAgent_RenewalDiaryNumber);
                cmd.Parameters.AddWithValue("p_p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);

                cmd.Parameters.AddWithValue("p_p_CriteriaCode", String.IsNullOrEmpty(smodel.CriteriaCode) ? "" : smodel.CriteriaCode);
                cmd.Parameters.AddWithValue("p_p_CriteriaSubCode", String.IsNullOrEmpty(smodel.CriteriaSubCode) ? "" : smodel.CriteriaSubCode);
                cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
                cmd.Parameters.AddWithValue("p_p_IsChecklistValueOk", String.IsNullOrEmpty(smodel.IsChecklistValueOk) ? "" : smodel.IsChecklistValueOk);
                cmd.Parameters.AddWithValue("p_p_A_column", "");
                cmd.Parameters.AddWithValue("p_p_B_column", "");
                cmd.Parameters.AddWithValue("p_p_C_column", "");

                cmd.Parameters.AddWithValue("p_p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
                cmd.Parameters.AddWithValue("p_p_IsActiveProvider", 1);
                cmd.Parameters.AddWithValue("p_p_IsLock", 0);

                cmd.Parameters.AddWithValue("p_p_CreatedBy", User_WhoIdentified);
                cmd.Parameters.AddWithValue("p_p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_p_ModifyBy", User_WhoIdentified);
                cmd.Parameters.AddWithValue("p_p_ModifyOn", DateTime.Now);

                MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.Int64);
                AppPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(AppPar);
                #endregion

                con.Open();
                i = cmd.ExecuteNonQuery();
                AppId = Convert.ToInt64(AppPar.Value);
                con.Close();
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Display_AuthorityDesk_RenewalAgent_CheckList_DetailsByCode(Int64 Agent_ID, Int32 AgentType_ID, Int64 RnAgent_ID, Int32 RnAgent_SeqID, Int32 RnAgent_YrID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_RenewalAgentCheckList_DetailsByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentType_ID);
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
                           new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog
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

                               CriteriaSubCodeTitle = Convert.ToString(dr["CriteriaSubCodeTitle"]),
                               VarCriteriaCode = Convert.ToInt32(dr["VarCriteriaCode"]),
                               VarCriteriaSubCode = Convert.ToInt32(dr["VarCriteriaSubCode"]),
                               VarChecklistOrderNumber = Convert.ToInt32(dr["VarChecklistOrderNumber"]),
                               VarChecklistGroupID = Convert.ToInt32(dr["VarChecklistGroupID"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Display_AuthorityDesk_RenewalAgent_CheckList_DetailsByCode_ForExpandLog(Int64 vAgent_ID, Int32 vAgentType_ID, Int64 vRnAgent_ID, Int32 vRnAgent_SeqID, Int32 vRnAgent_YrID, string vUserID_Role, Int32 vCriteriaCode, Int32 vCriteriaSubCode)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_RenewalAgentCheckList_DetailByID_ForExpand", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", vAgent_ID);                
                cmd.Parameters.AddWithValue("p_AgentType_ID", vAgentType_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", vRnAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", vRnAgent_SeqID);
                cmd.Parameters.AddWithValue("p_RenewalnAgent_YearID", vRnAgent_YrID);
                cmd.Parameters.AddWithValue("p_UserID_Role", vUserID_Role);
                cmd.Parameters.AddWithValue("p_Criteria_Code", vCriteriaCode);
                cmd.Parameters.AddWithValue("p_Criteria_SubCode", vCriteriaSubCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog
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

                               CriteriaSubCodeTitle = Convert.ToString(dr["CriteriaSubCodeTitle"]),
                               VarCriteriaCode = Convert.ToInt32(dr["VarCriteriaCode"]),
                               VarCriteriaSubCode = Convert.ToInt32(dr["VarCriteriaSubCode"]),
                               VarChecklistOrderNumber = Convert.ToInt32(dr["VarChecklistOrderNumber"]),
                               VarChecklistGroupID = Convert.ToInt32(dr["VarChecklistGroupID"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Display_AuthorityDesk_RenewalAgent_CheckList_DetailsByID_ForLogHistory(Int64 vAgent_ID, Int32 vAgentType_ID, Int64 vRnAgent_ID, Int32 vRnAgent_SeqID, Int32 vRnAgent_YrID, string vUserID_Role, Int32 vCriteriaCode, Int32 vCriteriaSubCode)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_RenewalAgentCheckList_ByID_ForLogHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", vAgent_ID);
                cmd.Parameters.AddWithValue("p_AgentType_ID", vAgentType_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", vRnAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", vRnAgent_SeqID);
                cmd.Parameters.AddWithValue("p_RenewalnAgent_YearID", vRnAgent_YrID);
                cmd.Parameters.AddWithValue("p_UserID_Role", vUserID_Role);
                cmd.Parameters.AddWithValue("p_Criteria_Code", vCriteriaCode);
                cmd.Parameters.AddWithValue("p_Criteria_SubCode", vCriteriaSubCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog
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

                               CriteriaSubCodeTitle = Convert.ToString(dr["CriteriaSubCodeTitle"]),
                               VarCriteriaCode = Convert.ToInt32(dr["VarCriteriaCode"]),
                               VarCriteriaSubCode = Convert.ToInt32(dr["VarCriteriaSubCode"]),
                               VarChecklistOrderNumber = Convert.ToInt32(dr["VarChecklistOrderNumber"]),
                               VarChecklistGroupID = Convert.ToInt32(dr["VarChecklistGroupID"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public string Fill_RenewalAgent_ChecklistCriteriaName(Int32 CriteriaCode)
        {
            string retSTR = string.Empty;
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgent_ChecklistNameByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_CriteriaCode", CriteriaCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    retSTR = Convert.ToString(dr["CriteriaName"]);
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return retSTR;
        }


        //Dashboard Checklist
        public List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Display_DashboardDesk_RenewalAgent_CheckList_NoAccept_DetailsByCode(Int64 Agent_ID, Int64 RnAgent_ID, Int32 RnAgent_SeqID, Int32 RnAgent_YrID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog>();
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
                           new ClsPrp_AuthorityDesk_RenewalAgentSubCheckListLog
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

        //NA
        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentEvent_Master>();
            //SAME PROC
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectEventDescriptionDetailsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Event_ID", Event_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> Display_AuthorityDesk_AgentDetailsIssueRERAregistration(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationIssueRERAid", con);
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
                       new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }
                

        //Offline Registered Agents
        public List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails> Display_AuthorityDesk_AgentsExistingRERA_OfflineRegistered_PendingUploads(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails> OfflineRegisteredAgents = new List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_PendingUploadsAgentRegisteredOffline", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                OfflineRegisteredAgents.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails
                       {
                           OfflineAgents_IndexID = Convert.ToInt64(dr["OfflineAgents_IndexID"]),
                           OfflineAgents_ID = Convert.ToInt64(dr["OfflineAgents_ID"]),
                           OfflineAgents_IssueDate = Convert.ToDateTime(dr["OfflineAgents_IssueDate"]),
                           OfflineAgents_ReferenceNumber = Convert.ToString(dr["OfflineAgents_ReferenceNumber"]),

                           OfflineAgents_AgentName_OrganizationName = Convert.ToString(dr["OfflineAgents_AgentName_OrganizationName"]),
                           OfflineAgents_AgentType = Convert.ToString(dr["OfflineAgents_AgentType"]),
                           OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = Convert.ToString(dr["OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress"]),

                           OfflineAgents_RERAregistrationNumber = Convert.ToString(dr["OfflineAgents_RERAregistrationNumber"]),
                           OfflineAgents_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationIssueDate"]),
                           OfflineAgents_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationValidUptoDate"]),

                           OfflineAgents_PlaceOfBussinessAddress = Convert.ToString(dr["OfflineAgents_PlaceOfBussinessAddress"]),
                           OfflineAgents_BusinessPlaceDistrict = Convert.ToString(dr["OfflineAgents_BusinessPlaceDistrict"]),
                           OfflineAgents_ContactDetails = Convert.ToString(dr["OfflineAgents_ContactDetails"]),
                           OfflineAgents_RemarksIfAny = Convert.ToString(dr["OfflineAgents_RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificate = Convert.ToInt32(dr["IsCertificate"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return OfflineRegisteredAgents;
        }

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsExistingRERA(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationExistingRERA", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

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

                       });
            }
            return ProjectFivelist1;
        }

        //RERA Number Issue-List Agents 
        public List<ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueList> Display_AuthorityDesk_RenewalAgent_AgentDetailsPublicView_IssueList(string KeyCode, Int32 PageNumber, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueList> Agentlist = new List<ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationIssueDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
                cmd.Parameters.AddWithValue("p_PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("p_Key", KeyCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueList
                           {
                               RenewalAgent_IssueRefNumber_DiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgent_IssueRefNumber_DiaryNumber_IndexID"]),
                               RenewalAgent_IssueRefNumber_DiaryNumber_ID = Convert.ToInt64(dr["RenewalAgent_IssueRefNumber_DiaryNumber_ID"]),

                               RenewalAgentDiaryNumber_ID = Convert.ToInt64(dr["RenewalAgentDiaryNumber_ID"]),
                               RenewalAgentDiaryNumber_Name = Convert.ToString(dr["RenewalAgentDiaryNumber_Name"]),
                               RenewalAgentDiaryNumber_NameYear = Convert.ToString(dr["RenewalAgentDiaryNumber_NameYear"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                               Related_RenewalAgent_SequenceID = Convert.ToInt32(dr["Related_RenewalAgent_SequenceID"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentType_ID = Convert.ToInt32(dr["Related_AgentType_ID"]),

                               Related_Agent_DiaryNumber = Convert.ToString(dr["Related_Agent_DiaryNumber"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_LastRegistrationIssueDate = Convert.ToDateTime(dr["Related_LastRegistrationIssueDate"]),
                               Related_LastRegistrationRegUptoDate = Convert.ToDateTime(dr["Related_LastRegistrationRegUptoDate"]),

                               Agent_Name = Convert.ToString(dr["Agent_Name"]),
                               Agent_Registered_District = Convert.ToString(dr["Agent_Registered_District"]),
                               Agent_BussinessPlace_District = Convert.ToString(dr["Agent_BussinessPlace_District"]),

                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                               EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               Extra1 = Convert.ToString(dr["Extra1"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),

                               RenewalAgent_Name = Convert.ToString(dr["RenewalAgent_Name"]),
                               RenewalAgent_AddressDistrictName = Convert.ToString(dr["RenewalAgent_AddressDistrictName"]),
                               RenewalAgent_RERAregistrationNumber = Convert.ToString(dr["RenewalAgent_RERAregistrationNumber"]),
                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                               AssignedTo = Convert.ToString(dr["AssignedTo"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                               RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                               RERA_Number_IssueDate = Convert.ToDateTime(dr["RERA_Number_IssueDate"]),
                               RERA_Number_RegistrationUptoDate = Convert.ToDateTime(dr["RERA_Number_RegistrationUptoDate"]),

                               AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                               AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                               AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                               AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
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