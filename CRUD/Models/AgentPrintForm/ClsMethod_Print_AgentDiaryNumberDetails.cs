using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsMethod_Print_AgentDiaryNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmAgent_Print_DiaryNumberDetails> Display_Agent_RegDiaryNumberByAgentID_ForPrint(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmAgent_Print_DiaryNumberDetails> ProjectFivelist1 = new List<ClsPrp_PrmAgent_Print_DiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_RegDiaryNumberByAgentID_ForPrint", con);
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
                    ProjectFivelist1.Add(
                        new ClsPrp_PrmAgent_Print_DiaryNumberDetails
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

                            zapRelated_Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                            zapAgent_DiaryNumber = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                            zapAgentName = Convert.ToString(dr["Agent_Name"]),
                            zapAgentLastModifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_PrmAgent_Print_DiaryNumberDetails> Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmAgent_Print_DiaryNumberDetails> ProjectFivelist1 = new List<ClsPrp_PrmAgent_Print_DiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_PrintAgentRenewal_RegDiaryNumberByAgentID", con);
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
                    ProjectFivelist1.Add(
                        new ClsPrp_PrmAgent_Print_DiaryNumberDetails
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

                            zapRelated_Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                            zapAgent_DiaryNumber = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                            zapAgentName = Convert.ToString(dr["Agent_Name"]),
                            zapAgentLastModifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                            zapAgent_RegistrationNumber = Convert.ToString(dr["RegistrationNumber"]),
                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ProjectFivelist1;
        }

    }
}