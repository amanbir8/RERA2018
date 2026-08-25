using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using CRUD.Models.Agent;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsMethodprpOtherMemberAgent
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsprpOtherMemberAgent> Display_Print_AgentOtherMemberDetail(Int64 Agent_ID)
        {
            connection();
            List<ClsprpOtherMemberAgent> list_indPro = new List<ClsprpOtherMemberAgent>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_OtherMember_ByAgentID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpOtherMemberAgent
                    {
                        Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Designation = Convert.ToString(dr["Designation"]),
                        OtherMember_Name = Convert.ToString(dr["OtherMember_Name"]),
                        OtherMember_PAN_Number = Convert.ToString(dr["OtherMember_PAN_Number"]),
                        OtherMember_Aadhaar_Number = Convert.ToString(dr["OtherMember_Aadhaar_Number"]),
                        OfficeComm_AddressLine1 = Convert.ToString(dr["OfficeComm_AddressLine1"]),
                        OfficeComm_AddressLine2 = Convert.ToString(dr["OfficeComm_AddressLine2"]),
                        OfficeComm_AddressStateCode = Convert.ToInt32(dr["OfficeComm_AddressStateCode"]),
                        OfficeComm_AddressDistrictCode = Convert.ToInt32(dr["OfficeComm_AddressDistrictCode"]),
                        OfficeComm_AddressPIN = Convert.ToInt32(dr["OfficeComm_AddressPIN"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        Image_FileName = Convert.ToString(dr["Image_FileName"]),
                        Image_FilePath = Convert.ToString(dr["Image_FilePath"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;
        }

        public List<ClsPrp_Print_RenewalAgent_OtherMemberAgent> Display_Print_RenewalAgent_OtherMemberDetail(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_Print_RenewalAgent_OtherMemberAgent> list_indPro = new List<ClsPrp_Print_RenewalAgent_OtherMemberAgent>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_PrintAgentRenewal_OtherMember_ForPrint", con);
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
                list_indPro.Add(
                    new ClsPrp_Print_RenewalAgent_OtherMemberAgent
                    {
                        RenewalAgent_OtherMember_IndexID = Convert.ToInt64(dr["RenewalAgent_OtherMember_IndexID"]),
                        RenewalAgent_OtherMember_ID = Convert.ToInt64(dr["RenewalAgent_OtherMember_ID"]),

                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_Agent_OtherMember_ID = Convert.ToInt64(dr["Related_Agent_OtherMemberDetails_ID"]),

                        Designation = Convert.ToString(dr["Designation"]),
                        OtherMember_Name = Convert.ToString(dr["OtherMember_Name"]),
                        OtherMember_PAN_Number = Convert.ToString(dr["OtherMember_PAN_Number"]),
                        OtherMember_Aadhaar_Number = Convert.ToString(dr["OtherMember_Aadhaar_Number"]),
                        OfficeComm_AddressLine1 = Convert.ToString(dr["OfficeComm_AddressLine1"]),
                        OfficeComm_AddressLine2 = Convert.ToString(dr["OfficeComm_AddressLine2"]),
                        OfficeComm_AddressStateCode = Convert.ToInt32(dr["OfficeComm_AddressStateCode"]),
                        OfficeComm_AddressDistrictCode = Convert.ToInt32(dr["OfficeComm_AddressDistrictCode"]),
                        OfficeComm_AddressPIN = Convert.ToInt32(dr["OfficeComm_AddressPIN"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = ((dr["PhoneNumber_STD"] == null) ? 0 : Convert.ToInt64(dr["PhoneNumber_STD"])),
                        PhoneNumber_Number = ((dr["PhoneNumber_Number"] == null) ? 0 : Convert.ToInt64(dr["PhoneNumber_Number"])),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        Image_FileName = Convert.ToString(dr["Image_FileName"]),
                        Image_FilePath = Convert.ToString(dr["Image_FilePath"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsConditional = Convert.ToInt32(dr["IsConditional"]),

                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                    });
            }
            return list_indPro;
        }
    }
}