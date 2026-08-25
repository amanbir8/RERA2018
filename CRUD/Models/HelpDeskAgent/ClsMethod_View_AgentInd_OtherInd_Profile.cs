using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_AgentInd_OtherInd_Profile
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_View_AgentIndProfile> Display_AuthDesk_AgentIndProfileDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Profile_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            List<ClsPrp_AuthDesk_View_AgentIndProfile> list_indPro = new List<ClsPrp_AuthDesk_View_AgentIndProfile>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["Agent_Type"]) == 1)
                {
                    list_indPro.Add(
                        new ClsPrp_AuthDesk_View_AgentIndProfile
                        {
                            Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                            Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                            IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                            Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                            Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                            Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                            Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                            Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                            Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                            Father_LastName = Convert.ToString(dr["Father_LastName"]),
                            Occupation = Convert.ToString(dr["Occupation"]),
                            Image_FileName = Convert.ToString(dr["Image_FileName"]),
                            Image_FilePath = Convert.ToString(dr["Image_FilePath"]),
                            P_AddressLine1 = Convert.ToString(dr["P_AddressLine1"]),
                            P_AddressLine2 = Convert.ToString(dr["P_AddressLine2"]),
                            P_AddressStateCode = Convert.ToInt32(dr["P_AddressStateCode"]),
                            P_AddressDistrictCode = Convert.ToInt32(dr["P_AddressDistrictCode"]),
                            P_AddressPIN = Convert.ToString(dr["P_AddressPIN"]),
                            Organization_Name = Convert.ToString(dr["Organization_Name"]),
                            Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                            Organization_MainObjects = Convert.ToString(dr["Organization_MainObjects"]),
                            //RegOffice_AddressLine1 = Convert.ToString(dr["RegOffice_AddressLine1"]),
                            //RegOffice_AddressLine2 = Convert.ToString(dr["RegOffice_AddressLine2"]),
                            //RegOffice_AddressStateCode = Convert.ToInt32(dr["RegOffice_AddressStateCode"]),
                            //RegOffice_AddressDistrictCode = Convert.ToInt32(dr["RegOffice_AddressDistrictCode"]),
                            //RegOffice_AddressPIN = Convert.ToInt32(dr["RegOffice_AddressPIN"]),
                            BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                            BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                            BusinessPlace_AddressStateCode = Convert.ToInt32(dr["BusinessPlace_AddressStateCode"]),
                            BusinessPlace_AddressDistrictCode = Convert.ToInt32(dr["BusinessPlace_AddressDistrictCode"]),
                            BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),

                            IsSameBussinessAdd_CommAdd = ((dr["IsSameBussinessAdd_CommAdd"] as string == "1") ? true : false),

                            BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                            BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                            BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                            BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                            BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),
                            AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                            AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                            AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                            MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                            PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                            PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                            EmailAddress = Convert.ToString(dr["EmailAddress"]),
                            PAN_Number = Convert.ToString(dr["PAN_Number"]),
                            Aadhaar_Number = Convert.ToInt64(dr["Aadhaar_Number"]),
                            IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                            IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),

                            B_Column = Convert.ToString(dr["B_Column"]),
                            C_Column = Convert.ToString(dr["C_Column"]),
                        });
                }
                else
                {
                    list_indPro.Add(
                    new ClsPrp_AuthDesk_View_AgentIndProfile
                    {
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
                }
            }
            return list_indPro;
        }

        public List<ClsPrp_AuthDesk_View_AgentOtherIndProfile> Display_AuthDesk_AgentOtherThanIndDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Profile_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            //connection();
            List<ClsPrp_AuthDesk_View_AgentOtherIndProfile> list_indPro = new List<ClsPrp_AuthDesk_View_AgentOtherIndProfile>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["Agent_Type"]) == 2)
                {
                    list_indPro.Add(
                    new ClsPrp_AuthDesk_View_AgentOtherIndProfile
                    {
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                        IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                        Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                        //Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        //Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                        //Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        //Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                        //Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                        //Father_LastName = Convert.ToString(dr["Father_LastName"]),
                        Occupation = Convert.ToString(dr["Occupation"]),
                        //Image_FileName = Convert.ToString(dr["Image_FileName"]),
                        //Image_FilePath = Convert.ToString(dr["Image_FilePath"]),
                        //P_AddressLine1 = Convert.ToString(dr["P_AddressLine1"]),
                        //P_AddressLine2 = Convert.ToString(dr["P_AddressLine2"]),
                        //P_AddressStateCode = Convert.ToInt32(dr["P_AddressStateCode"]),
                        //P_AddressDistrictCode = Convert.ToInt32(dr["P_AddressDistrictCode"]),
                        //P_AddressPIN = Convert.ToString(dr["P_AddressPIN"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                        Organization_MainObjects = Convert.ToString(dr["Organization_MainObjects"]),
                        RegOffice_AddressLine1 = Convert.ToString(dr["RegOffice_AddressLine1"]),
                        RegOffice_AddressLine2 = Convert.ToString(dr["RegOffice_AddressLine2"]),
                        RegOffice_AddressStateCode = Convert.ToInt32(dr["RegOffice_AddressStateCode"]),
                        RegOffice_AddressDistrictCode = Convert.ToInt32(dr["RegOffice_AddressDistrictCode"]),
                        RegOffice_AddressPIN = Convert.ToInt32(dr["RegOffice_AddressPIN"]),
                        BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                        BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                        BusinessPlace_AddressStateCode = Convert.ToInt32(dr["BusinessPlace_AddressStateCode"]),
                        BusinessPlace_AddressDistrictCode = Convert.ToInt32(dr["BusinessPlace_AddressDistrictCode"]),
                        BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),
                        IsSameBussinessAdd_CommAdd = ((dr["IsSameBussinessAdd_CommAdd"] as string == "1") ? true : false),
                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                        BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),
                        AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                        AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                        AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        PAN_Number = Convert.ToString(dr["PAN_Number"]),
                        Aadhaar_Number = Convert.ToInt64(dr["Aadhaar_Number"]),
                        IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                        IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                        B_Column = Convert.ToString(dr["B_Column"]),
                        C_Column = Convert.ToString(dr["C_Column"]),
                    });
                }
                else
                {
                    list_indPro.Add(
                    new ClsPrp_AuthDesk_View_AgentOtherIndProfile
                    {
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),                       

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                    });
                }
            }
            return list_indPro;
        }

        public List<ClsPrp_AuthDesk_View_AgentOtherMembers> Display_AuthDesk_AgentOthermemberDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_OtherMember_ByAgentID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            
            List<ClsPrp_AuthDesk_View_AgentOtherMembers> list_indPro = new List<ClsPrp_AuthDesk_View_AgentOtherMembers>();
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsPrp_AuthDesk_View_AgentOtherMembers
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

        public Int32 Update_LockUnLockHandler_Agent_IndProfileDetail(Int64 AgentId, Int32 AgentTypeId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_agent_individualprofile_detail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
            cmd.Parameters.AddWithValue("p_ReferenceAgentIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

        public Int32 Update_LockUnLockHandler_Agent_OtherThanIndDetail(Int64 AgentId, Int32 AgentTypeId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_agent_otherthanindprofile_detail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
            cmd.Parameters.AddWithValue("p_ReferenceAgentIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

        public Int32 Update_LockUnLockHandler_Agent_OtherMemberDetail(Int64 AgentId, Int32 AgentTypeId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_agent_othermemberdetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
            cmd.Parameters.AddWithValue("p_ReferenceAgentIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

    }
}