using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.AgentRenewal
{
    public class ClsMethod_AgentRenewal_ReviewMaster
    {

        public List<Clsprp_AgentRenewal_ReviewMaster> FillDropdown_RenewalAgentDetails_ByAppId(Int64 Agent_ID, Int32 TypeOfAgent_ID, string RegdNumber, Int64 Flag)
        {
            List<Clsprp_AgentRenewal_ReviewMaster> referencelist = new List<Clsprp_AgentRenewal_ReviewMaster>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_ByAppId_RenewalRegistration", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
                    cmd.Parameters.AddWithValue("p_TypeOfAgent_ID", TypeOfAgent_ID);
                    cmd.Parameters.AddWithValue("p_RegistrationNumber", RegdNumber);
                    cmd.Parameters.AddWithValue("p_Flag", Flag);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Clsprp_AgentRenewal_ReviewMaster uobj = new Clsprp_AgentRenewal_ReviewMaster();
                        uobj.Related_AgentRenewal_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["Related_AgentRenewal_ID"].ToString());
                        uobj.Related_AgentRenewal_SequenceID = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_AgentRenewal_SequenceID"].ToString());
                        uobj.Related_AgentRenewal_Year = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_AgentRenewal_Year"].ToString());
                        uobj.SequenceID_Name = ds.Tables[0].Rows[i]["SequenceID_Name"].ToString();
                        uobj.Registration_Number = ds.Tables[0].Rows[i]["Registration_Number"].ToString();
                        uobj.Reference_Agent_DiaryNumber = ds.Tables[0].Rows[i]["Reference_Agent_DiaryNumber"].ToString();
                        uobj.Registration_OtherMember_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"]);
                        uobj.Registration_OtherRERA_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherRERA_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherRERA_YN_Flag"]);

                        referencelist.Add(uobj);
                    }                    
                    return referencelist;
                }
            }
        }

        public List<Clsprp_AgentRenewal_ExtractDetails_ReviewMaster> FillDropdown_ExtarctDetails_RenewalAgent_ByAppId(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int64 Flag)
        {
            List<Clsprp_AgentRenewal_ExtractDetails_ReviewMaster> referencelist = new List<Clsprp_AgentRenewal_ExtractDetails_ReviewMaster>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_ByAppId_ExtractDetail", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
                    cmd.Parameters.AddWithValue("p_TypeOfAgent", TypeOfAgent_ID);
                    cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
                    cmd.Parameters.AddWithValue("p_Flag", Flag);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Clsprp_AgentRenewal_ExtractDetails_ReviewMaster uobj = new Clsprp_AgentRenewal_ExtractDetails_ReviewMaster();
                        uobj.Related_AgentRenewal_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["Related_AgentRenewal_ID"].ToString());
                        uobj.Related_AgentRenewal_SequenceID = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_AgentRenewal_SequenceID"].ToString());
                        uobj.Related_AgentRenewal_Year = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_AgentRenewal_Year"].ToString());
                        uobj.Related_Agent_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["Related_Agent_ID"].ToString());
                        uobj.Related_Registration_Number = ds.Tables[0].Rows[i]["Related_Registration_Number"].ToString();
                        uobj.Related_Agent_Type = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_Agent_Type"].ToString());
                        uobj.Registration_OtherMember_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"]);
                        uobj.Registration_OtherRERA_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherRERA_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherRERA_YN_Flag"]);

                        referencelist.Add(uobj);
                    }
                    return referencelist;
                }
            }
        }

    }
}