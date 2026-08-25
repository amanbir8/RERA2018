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
    public class ClsMethod_View_RenewalAgent_Ind_OtherInd_Profile
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_IndProfile> Display_AuthDesk_RenewalAgent_IndProfileDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_IndProfile> list_indPro = new List<ClsPrp_AuthDesk_View_RenewalAgent_IndProfile>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_IndividualProfile_ForDesk", con);
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
                    if (Convert.ToInt32(dr["Agent_Type"]) == 1)
                    {
                        list_indPro.Add(
                            new ClsPrp_AuthDesk_View_RenewalAgent_IndProfile
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
                                Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

                                IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                                Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                                Mode_RegistrationNumber = Convert.ToString(dr["Mode_RegistrationNumber"]),

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

                                BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                                BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                                BusinessPlace_AddressStateCode = Convert.ToInt32(dr["BusinessPlace_AddressStateCode"]),
                                BusinessPlace_AddressDistrictCode = Convert.ToInt32(dr["BusinessPlace_AddressDistrictCode"]),
                                BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),

                                BusinessPlace_AddressSubDivisionCode = Convert.ToInt32(dr["BusinessPlace_AddressSubDivisionCode"]),
                                BusinessPlace_AddressSubDivisionName = Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"]),

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
                                IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                                IsDraft = Convert.ToInt32(dr["IsDraft"]),
                                IsLock = Convert.ToInt32(dr["IsLock"]),
                                IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                                IsConditional = Convert.ToInt32(dr["IsConditional"]),

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
                        new ClsPrp_AuthDesk_View_RenewalAgent_IndProfile
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
                            Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return list_indPro;
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile> Display_AuthDesk_RenewalAgent_OtherThanIndDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile> list_indPro = new List<ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_OTIndProfile_ForDesk", con);
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
                    if (Convert.ToInt32(dr["Agent_Type"]) == 2)
                    {
                        list_indPro.Add(
                        new ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile
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
                            Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

                            IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                            Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                            Mode_RegistrationNumber = Convert.ToString(dr["Mode_RegistrationNumber"]),

                            Organization_PAN_Number = Convert.ToString(dr["Organization_PAN_Number"]),
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

                            BusinessPlace_AddressSubDivisionCode = Convert.ToInt32(dr["BusinessPlace_AddressSubDivisionCode"]),
                            BusinessPlace_AddressSubDivisionName = Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"]),

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
                            IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            IsLock = Convert.ToInt32(dr["IsLock"]),
                            IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                            IsConditional = Convert.ToInt32(dr["IsConditional"]),

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
                        new ClsPrp_AuthDesk_View_RenewalAgent_OtherIndProfile
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
                            Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return list_indPro;
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers> Display_AuthDesk_RenewalAgent_OthermemberDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers> list_indPro = new List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_OtherMember_ByID_ForDesk", con);
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
            return list_indPro;
        }

        public Int32 Update_LockUnLockHandler_RenewalAgent_IndProfileDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_renewalagent_individualprofile_detail", con);
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

        public Int32 Update_LockUnLockHandler_RenewalAgent_OtherThanIndDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_renewalagent_otherthanindprofile_detail", con);
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

        public Int32 Update_LockUnLockHandler_RenewalAgent_OthermemberDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_renewalagent_othermemberdetail", con);
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

    }
}