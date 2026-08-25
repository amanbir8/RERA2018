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
    public class ClsMethod_AgentRenewal_OtherMemberDetail
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Add/Update Agent-Renewal
        public bool Add_AgentRenewal_OtherMember_AgentDetail(Clsprp_AgentRenewal_OtherMemberDetail smodel, Int64 AgentID, Int64 RnAgentID, Int32 RnSeqID, Int32 RnYr, string FileName, string FilePath, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_AgentRenewal_OtherMemberDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_OtherMember_IndexID", smodel.RenewalAgent_OtherMember_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_OtherMember_ID", smodel.RenewalAgent_OtherMember_ID);
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
            cmd.Parameters.AddWithValue("p_Related_Agent_OtherMemberDetails_ID", smodel.Related_Agent_OtherMemberDetails_ID);

            cmd.Parameters.AddWithValue("p_Designation", String.IsNullOrEmpty(smodel.Designation) ? "" : smodel.Designation);
            cmd.Parameters.AddWithValue("p_OtherMember_Name", String.IsNullOrEmpty(smodel.OtherMember_Name) ? "" : smodel.OtherMember_Name);
            cmd.Parameters.AddWithValue("p_OtherMember_PAN_Number", String.IsNullOrEmpty(smodel.OtherMember_PAN_Number) ? "" : smodel.OtherMember_PAN_Number);
            cmd.Parameters.AddWithValue("p_OtherMember_Aadhaar_Number", String.IsNullOrEmpty(smodel.OtherMember_Aadhaar_Number) ? "" : smodel.OtherMember_Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine1", String.IsNullOrEmpty(smodel.OfficeComm_AddressLine1) ? "" : smodel.OfficeComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine2", String.IsNullOrEmpty(smodel.OfficeComm_AddressLine2) ? "" : smodel.OfficeComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressStateCode", smodel.OfficeComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressDistrictCode", smodel.OfficeComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressPIN", smodel.OfficeComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_STD);
            cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_Image_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
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

        public bool Update_AgentRenewal_OtherMember_AgentDetail(Clsprp_AgentRenewal_OtherMemberDetail smodel, Int64 AgentID, Int64 RnAgentID, Int32 RnSeqID, Int32 RnYr, string FileName, string FilePath, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_AgentRenewal_OtherMemberDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_OtherMember_IndexID", smodel.RenewalAgent_OtherMember_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_OtherMember_ID", smodel.RenewalAgent_OtherMember_ID);
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
            cmd.Parameters.AddWithValue("p_Related_Agent_OtherMemberDetails_ID", smodel.Related_Agent_OtherMemberDetails_ID);

            cmd.Parameters.AddWithValue("p_Designation", String.IsNullOrEmpty(smodel.Designation) ? "" : smodel.Designation);
            cmd.Parameters.AddWithValue("p_OtherMember_Name", String.IsNullOrEmpty(smodel.OtherMember_Name) ? "" : smodel.OtherMember_Name);
            cmd.Parameters.AddWithValue("p_OtherMember_PAN_Number", String.IsNullOrEmpty(smodel.OtherMember_PAN_Number) ? "" : smodel.OtherMember_PAN_Number);
            cmd.Parameters.AddWithValue("p_OtherMember_Aadhaar_Number", String.IsNullOrEmpty(smodel.OtherMember_Aadhaar_Number) ? "" : smodel.OtherMember_Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine1", String.IsNullOrEmpty(smodel.OfficeComm_AddressLine1) ? "" : smodel.OfficeComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine2", String.IsNullOrEmpty(smodel.OfficeComm_AddressLine2) ? "" : smodel.OfficeComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressStateCode", smodel.OfficeComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressDistrictCode", smodel.OfficeComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressPIN", smodel.OfficeComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_STD);
            cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_Image_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
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
        public List<Clsprp_AgentRenewal_OtherMemberDetail> AgentRenewal_Display_OtherMember_AgentDetailByID(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_OtherMemberDetail> list_AgentRegistration = new List<Clsprp_AgentRenewal_OtherMemberDetail>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_OtherMemberDetail", con);
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
                    new Clsprp_AgentRenewal_OtherMemberDetail
                    {
                        RenewalAgent_OtherMember_IndexID = Convert.ToInt64(dr["RenewalAgent_OtherMember_IndexID"]),
                        RenewalAgent_OtherMember_ID = Convert.ToInt64(dr["RenewalAgent_OtherMember_ID"]),
                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Related_Agent_OtherMemberDetails_ID"]),

                        Designation = String.IsNullOrEmpty(Convert.ToString(dr["Designation"])) ? string.Empty : Convert.ToString(dr["Designation"]),
                        OtherMember_Name = String.IsNullOrEmpty(Convert.ToString(dr["OtherMember_Name"])) ? string.Empty : Convert.ToString(dr["OtherMember_Name"]),
                        OtherMember_PAN_Number = String.IsNullOrEmpty(Convert.ToString(dr["OtherMember_PAN_Number"])) ? string.Empty : Convert.ToString(dr["OtherMember_PAN_Number"]),
                        OtherMember_Aadhaar_Number = String.IsNullOrEmpty(Convert.ToString(dr["OtherMember_Aadhaar_Number"])) ? string.Empty : Convert.ToString(dr["OtherMember_Aadhaar_Number"]),

                        OfficeComm_AddressLine1 = Convert.ToString(dr["OfficeComm_AddressLine1"]),
                        OfficeComm_AddressLine2 = Convert.ToString(dr["OfficeComm_AddressLine2"]),
                        OfficeComm_AddressStateCode = Convert.ToInt32(dr["OfficeComm_AddressStateCode"]),
                        OfficeComm_AddressDistrictCode = Convert.ToInt32(dr["OfficeComm_AddressDistrictCode"]),
                        OfficeComm_AddressPIN = Convert.ToInt32(dr["OfficeComm_AddressPIN"]),

                        MobileNumber = (dr["MobileNumber"] != null) ? Convert.ToInt64(dr["MobileNumber"]) : 0,
                        PhoneNumber_STD = (dr["PhoneNumber_STD"] != null) ? Convert.ToInt64(dr["PhoneNumber_STD"]) : 0,
                        PhoneNumber_Number = (dr["PhoneNumber_Number"] != null) ? Convert.ToInt64(dr["PhoneNumber_Number"]) : 0,
                        EmailAddress = String.IsNullOrEmpty(Convert.ToString(dr["EmailAddress"])) ? string.Empty : Convert.ToString(dr["EmailAddress"]),

                        Image_FileName = String.IsNullOrEmpty(Convert.ToString(dr["Image_FileName"])) ? string.Empty : Convert.ToString(dr["Image_FileName"]),
                        Image_FilePath = String.IsNullOrEmpty(Convert.ToString(dr["Image_FilePath"])) ? string.Empty : Convert.ToString(dr["Image_FilePath"]),
                        Image_FileSize = String.IsNullOrEmpty(Convert.ToString(dr["Image_FileSize"])) ? string.Empty : Convert.ToString(dr["Image_FileSize"]),
                        Image_FileType = String.IsNullOrEmpty(Convert.ToString(dr["Image_FileType"])) ? string.Empty : Convert.ToString(dr["Image_FileType"]),

                        A_column = String.IsNullOrEmpty(Convert.ToString(dr["A_column"])) ? string.Empty : Convert.ToString(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? string.Empty : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? string.Empty : Convert.ToString(dr["C_column"]),

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

        public List<Clsprp_AgentRenewal_OtherMemberDetail> AgentRenewal_ExtractRecord_OtherMember_AgentDetailByID(Int64 IndexID, Int64 ExtractID, Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_OtherMemberDetail> list_AgentRegistration = new List<Clsprp_AgentRenewal_OtherMemberDetail>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_OtherMemberDetail_ExtractByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Related_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_Related_ExtractID", ExtractID);
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
                    new Clsprp_AgentRenewal_OtherMemberDetail
                    {
                        RenewalAgent_OtherMember_IndexID = Convert.ToInt64(dr["RenewalAgent_OtherMember_IndexID"]),
                        RenewalAgent_OtherMember_ID = Convert.ToInt64(dr["RenewalAgent_OtherMember_ID"]),
                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Related_Agent_OtherMemberDetails_ID"]),

                        Designation = String.IsNullOrEmpty(Convert.ToString(dr["Designation"])) ? string.Empty : Convert.ToString(dr["Designation"]),
                        OtherMember_Name = String.IsNullOrEmpty(Convert.ToString(dr["OtherMember_Name"])) ? string.Empty : Convert.ToString(dr["OtherMember_Name"]),
                        OtherMember_PAN_Number = String.IsNullOrEmpty(Convert.ToString(dr["OtherMember_PAN_Number"])) ? string.Empty : Convert.ToString(dr["OtherMember_PAN_Number"]),
                        OtherMember_Aadhaar_Number = String.IsNullOrEmpty(Convert.ToString(dr["OtherMember_Aadhaar_Number"])) ? string.Empty : Convert.ToString(dr["OtherMember_Aadhaar_Number"]),

                        OfficeComm_AddressLine1 = Convert.ToString(dr["OfficeComm_AddressLine1"]),
                        OfficeComm_AddressLine2 = Convert.ToString(dr["OfficeComm_AddressLine2"]),
                        OfficeComm_AddressStateCode = Convert.ToInt32(dr["OfficeComm_AddressStateCode"]),
                        OfficeComm_AddressDistrictCode = Convert.ToInt32(dr["OfficeComm_AddressDistrictCode"]),
                        OfficeComm_AddressPIN = Convert.ToInt32(dr["OfficeComm_AddressPIN"]),

                        MobileNumber = (dr["MobileNumber"] != null) ? Convert.ToInt64(dr["MobileNumber"]) : 0,
                        PhoneNumber_STD = (dr["PhoneNumber_STD"] != null) ? Convert.ToInt64(dr["PhoneNumber_STD"]) : 0,
                        PhoneNumber_Number = (dr["PhoneNumber_Number"] != null) ? Convert.ToInt64(dr["PhoneNumber_Number"]) : 0,
                        EmailAddress = String.IsNullOrEmpty(Convert.ToString(dr["EmailAddress"])) ? string.Empty : Convert.ToString(dr["EmailAddress"]),

                        Image_FileName = String.IsNullOrEmpty(Convert.ToString(dr["Image_FileName"])) ? string.Empty : Convert.ToString(dr["Image_FileName"]),
                        Image_FilePath = String.IsNullOrEmpty(Convert.ToString(dr["Image_FilePath"])) ? string.Empty : Convert.ToString(dr["Image_FilePath"]),
                        Image_FileSize = String.IsNullOrEmpty(Convert.ToString(dr["Image_FileSize"])) ? string.Empty : Convert.ToString(dr["Image_FileSize"]),
                        Image_FileType = String.IsNullOrEmpty(Convert.ToString(dr["Image_FileType"])) ? string.Empty : Convert.ToString(dr["Image_FileType"]),

                        A_column = String.IsNullOrEmpty(Convert.ToString(dr["A_column"])) ? string.Empty : Convert.ToString(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? string.Empty : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? string.Empty : Convert.ToString(dr["C_column"]),

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

        //Delete Agent-Renewal
        public bool Delete_AgentRenewal_OtherMemberDetail_byID(Int64 mIndexID, Int64 mExtractID, Int64 mRenewalAgentID, Int64 mAgentID, string mUserID)
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
                MySqlCommand cmd = new MySqlCommand("Delete_Rera_AgentRenewal_OtherMemberDetail_ByID", con);
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