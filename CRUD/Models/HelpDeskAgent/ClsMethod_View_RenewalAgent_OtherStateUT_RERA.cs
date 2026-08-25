using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using CRUD.Models.HelpDesk;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_RenewalAgent_AgentOtherStateUT_RERA
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_OtherStateUT_RERA> Display_AuthDesk_RenewalAgent_OtherStateUT_RERADetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_OtherStateUT_RERA> list_indPro = new List<ClsPrp_AuthDesk_View_RenewalAgent_OtherStateUT_RERA>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_OtherStateUTRERADetail_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list_indPro.Add(
                        new ClsPrp_AuthDesk_View_RenewalAgent_OtherStateUT_RERA
                        {
                            AgentRenewal_OtherStateUT_regRERA_IndexID = Convert.ToInt64(dr["AgentRenewal_OtherStateUT_regRERA_IndexID"]),
                            AgentRenewal_OtherStateUT_regRERA_ID = Convert.ToInt64(dr["AgentRenewal_OtherStateUT_regRERA_ID"]),
                            RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                            RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                            RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                            Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                            Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                            Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                            Related_UserID = Convert.ToString(dr["Related_UserID"]),
                            Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            Related_Agent_OtherStateUT_regRERA_ID = Convert.ToInt64(dr["Related_Agent_OtherStateUT_regRERA_ID"]),

                            StateCode = Convert.ToString(dr["StateCode"]),
                            RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                            RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                            RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                            ImageRERAcert_FileName = Convert.ToString(dr["ImageRERAcert_FileName"]),
                            ImageRERAcert_FilePath = Convert.ToString(dr["ImageRERAcert_FilePath"]),
                            Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return list_indPro;
        }

        public Int32 Update_LockUnLockHandler_RenewalAgent_OtherStateUT_RERA(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_renewalagent_otherstate_RERAdetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
            cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
            cmd.Parameters.AddWithValue("p_RenewalAgentIndexID", IndexID);
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


        public List<ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA> Display_AuthDesk_RenewalAgent_RefRegistrations_RERADetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA> RenAgentList = new List<ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_RefRegistrationsRERADetail_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RenAgentList.Add(
                        new ClsPrp_AuthDesk_View_RenewalAgent_RefRegistration_RERA
                        {
                            AgentRenewal_RefRegistration_regRERA_IndexID = Convert.ToInt64(dr["AgentRenewal_RefRegistration_regRERA_IndexID"]),
                            AgentRenewal_RefRegistration_regRERA_ID = Convert.ToInt64(dr["AgentRenewal_RefRegistration_regRERA_ID"]),
                            RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                            RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                            RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                            Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                            Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                            Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                            Related_UserID = Convert.ToString(dr["Related_UserID"]),
                            Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            Related_Agent_RefRegistrations_RERA_ID = Convert.ToInt64(dr["Related_Agent_RefRegistrations_RERA_ID"]),

                            RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                            RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                            RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),

                            Agent_Reference_DiaryNumber = Convert.ToString(dr["Agent_Reference_DiaryNumber"]),
                            Agent_Reference_ApplicationDate = Convert.ToDateTime(dr["Agent_Reference_ApplicationDate"]),
                            Agent_Name = Convert.ToString(dr["Agent_Name"]),
                            Agent_Type = Convert.ToString(dr["Agent_Type"]),
                            ImageRERAcert_FileName = Convert.ToString(dr["ImageRERAcert_FileName"]),
                            ImageRERAcert_FilePath = Convert.ToString(dr["ImageRERAcert_FilePath"]),

                            Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return RenAgentList;
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations> Display_PopUpDesk_RenewalAgent_PrevRegistrationRecord_RERADetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string flagCode, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations> RenAgentList = new List<ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_PrevRegistrationRecord_IndOTIProfile_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
                cmd.Parameters.AddWithValue("p_Agent_FlagCode", flagCode);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RenAgentList.Add(
                        new ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations
                        {
                            RenewalAgent_IndexID = Convert.ToInt64(dr["RenewalAgent_IndexID"]),
                            RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                            RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                            RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                            Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                            Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                            Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                            Related_UserID = Convert.ToString(dr["Related_UserID"]),
                            Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                            Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),

                            Agent_Format_CODE = Convert.ToInt32(dr["Agent_Format_CODE"]),

                            //Ref Registration
                            RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                            RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                            RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),

                            Agent_Reference_DiaryNumber = Convert.ToString(dr["Agent_Reference_DiaryNumber"]),
                            Agent_Reference_ApplicationDate = Convert.ToDateTime(dr["Agent_Reference_ApplicationDate"]),
                            Agent_Name = Convert.ToString(dr["Agent_Name"]),
                            Agent_Type = Convert.ToString(dr["Agent_Type"]),

                            //Agent Information
                            Mode_RegistrationNumber = Convert.ToString(dr["Mode_RegistrationNumber"]),

                            //IND CASE
                            Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                            Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                            Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                            Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                            Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                            Father_LastName = Convert.ToString(dr["Father_LastName"]),
                            Individual_PAN_Number = Convert.ToString(dr["Individual_PAN_Number"]),
                            Individual_Aadhaar_Number = Convert.ToInt64(dr["Individual_Aadhaar_Number"]),

                            //OTI CASE
                            Organization_Name = Convert.ToString(dr["Organization_Name"]),
                            Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                            Organization_PAN_Number = Convert.ToString(dr["Organization_PAN_Number"]),

                            //IND-Permanent Address OR OTI-Regd Address
                            RegOfficeOrPermanent_AddressLine1 = Convert.ToString(dr["RegOfficeOrPermanent_AddressLine1"]),
                            RegOfficeOrPermanent_AddressLine2 = Convert.ToString(dr["RegOfficeOrPermanent_AddressLine2"]),
                            RegOfficeOrPermanent_AddressStateCode = Convert.ToString(dr["RegOfficeOrPermanent_AddressStateCode"]),
                            RegOfficeOrPermanent_AddressDistrictCode = Convert.ToString(dr["RegOfficeOrPermanent_AddressDistrictCode"]),
                            RegOfficeOrPermanent_AddressPIN = Convert.ToInt32(dr["RegOfficeOrPermanent_AddressPIN"]),

                            //Place of Bussiness Address
                            BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                            BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                            BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                            BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                            BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),
                            BusinessPlace_AddressSubDivisionName = Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"]),

                            //Official Address OR Communication Address
                            BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                            BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                            BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                            BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                            BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),

                            //OTI-Authorized Person
                            AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                            AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                            AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                            PAN_Number = Convert.ToString(dr["PAN_Number"]),
                            Aadhaar_Number = Convert.ToInt64(dr["Aadhaar_Number"]),

                            //IND-agent-detail or OTI-Authorized Person-detail
                            MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                            PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                            PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                            EmailAddress = Convert.ToString(dr["EmailAddress"]),

                            //OTHER
                            IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                            IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

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

                            //Extra
                            A_Column = Convert.ToString(dr["A_Column"]),
                            B_Column = Convert.ToString(dr["B_Column"]),
                            C_Column = Convert.ToString(dr["C_Column"]),

                            BusinessPlace_AddressSubDivision = Convert.ToString(dr["BusinessPlace_AddressSubDivision"]),
                            P_AddressState = Convert.ToString(dr["P_AddressState"]),
                            P_AddressDist = Convert.ToString(dr["P_AddressDist"]),
                            BusinessPlace_AddressState = Convert.ToString(dr["BusinessPlace_AddressState"]),
                            BusinessPlace_AddressDistrict = Convert.ToString(dr["BusinessPlace_AddressDistrict"]),
                            BComm_AddressState = Convert.ToString(dr["BComm_AddressState"]),
                            BComm_AddressDistrict = Convert.ToString(dr["BComm_AddressDistrict"]),
                            RegOffice_AddressState = Convert.ToString(dr["RegOffice_AddressState"]),
                            RegOffice_AddressDistrict = Convert.ToString(dr["RegOffice_AddressDistrict"]),
                        });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return RenAgentList;
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers> Display_PopUpDesk_RenewalAgent_PrevRegistrationRecord_OthermemberDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string flagCode, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers> RenAgentList = new List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_PrevRegistrationRecord_OtherMember_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
                cmd.Parameters.AddWithValue("p_Agent_FlagCode", flagCode);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RenAgentList.Add(
                        new ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers
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
                            Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                            Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                            Related_Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Related_Agent_OtherMemberDetails_ID"]),

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
                            Image_FileSize = Convert.ToString(dr["Image_FileSize"]),
                            Image_FileType = Convert.ToString(dr["Image_FileType"]),

                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            C_column = Convert.ToString(dr["C_column"]),

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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return RenAgentList;
        }

        #region PROEJECT REG HISTORY

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist> Display_AuthDesk_Project_RefRegistrations_RERADetail(Int64 ProjectID, Int64 PromoterID, string ProjectDiaryNumber, string ProjectName, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist> ProjectList = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RefRegistrationsRERADetail_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
                cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
                cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", ProjectDiaryNumber);
                cmd.Parameters.AddWithValue("p_ProjectName", ProjectName);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectList.Add(
                        new ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist
                        {
                            Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RefRegistration_regRERA_IndexID"]),
                            Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RefRegistration_regRERA_ID"]),
                            ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["Project_RefDiaryNumber"]),
                            ProjectRegDiaryNumber_Name = Convert.ToString(dr["Project_RefDiaryName"]),
                            ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["Project_RefDiaryNameYear"]),

                            Promoter_ID = Convert.ToInt64(dr["Project_Promoter_ID"]),
                            Project_ID = Convert.ToInt64(dr["Project_ID"]),
                            User_ID = Convert.ToString(dr["Related_UserID"]),
                            ExistingRegistration = string.IsNullOrEmpty(Convert.ToString(dr["Project_RefExistingRegNumber"])) ? "" : Convert.ToString(dr["Project_RefExistingRegNumber"]),
                            //PromoterType = Convert.ToInt32(dr["Related_Agent_RefRegistrations_RERA_ID"]),

                            RERAnumberRegistration = Convert.ToString(dr["RERAregistration_Number"]),
                            PromoterName = Convert.ToString(dr["PromoterName"]),
                            ProjectName = Convert.ToString(dr["ProjectName"]),
                            RERAnumberIssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                            RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                            RERAregistrationcode = Convert.ToString(dr["RERAregistrationcode"]),

                            RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return ProjectList;
        }

    public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist> Display_PopUpDesk_Project_PrevRegistrationRecord_RERADetail(Int64 ProjectID, Int64 PromoterID, string ProjectDiaryNumber, string ProjectName, string flagCode, int DiaryNumberId, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist> RenAgentList = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_PrevRegistrationRecord_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
                cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
                cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", ProjectDiaryNumber);
                cmd.Parameters.AddWithValue("p_ProjectName", ProjectName);
                cmd.Parameters.AddWithValue("p_Project_FlagCode", flagCode);
                cmd.Parameters.AddWithValue("p_RefRegistrationID", DiaryNumberId);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RenAgentList.Add(
                        new ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumberRefHist
                        {
                            Project_RERAnumber_DiaryNumber_IndexID = dr["Ref_IndexID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Ref_IndexID"]),
                            Project_RERAnumber_DiaryNumber_ID = dr["Ref_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Ref_ID"]),
                            Project_ID = dr["Related_Project_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Related_Project_ID"]),
                            Promoter_ID = dr["Related_Promoter_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Related_Promoter_ID"]),
                            User_ID = Convert.ToString(dr["Related_UserID"]),
                            ProjectRegDiaryNumber_Name = Convert.ToString(dr["Project_Reference_DiaryNumber"]),

                            ExistingRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            RERAnumberRegistration = Convert.ToString(dr["RERAregistration_Number"]),
                            RERAnumberIssueDate = dr["RERAregistration_IssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                            RERAnumberRegUptoDate = dr["RERAregistration_ExpiryDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                            RERAregistrationcode = Convert.ToString(dr["Project_Format_CODE"]),

                            ProjectName = Convert.ToString(dr["Project_Name"]),
                            PromoterName = Convert.ToString(dr["Promoter_Name"]),
                            ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                            ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                            ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                            ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                            ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                            ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                            ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                            ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                            AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                            AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                            AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                            AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                            AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                            AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                            AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                            AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                            AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                            RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                            IsActive = dr["IsActive"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsActive"]),
                            IsDraft = dr["IsDraft"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsDraft"]),
                            IsPublicView = dr["IsPublicView"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsPublicView"]),
                            CreatedOn = dr["CreatedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CreatedOn"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            ModifyOn = dr["ModifyOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ModifyOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return RenAgentList;
        }    

        #endregion


    }
}