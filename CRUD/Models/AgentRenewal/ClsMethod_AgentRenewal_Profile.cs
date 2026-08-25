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
    public class ClsMethod_AgentRenewal_Profile
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Add/Update Agent Detail
        public Tuple<Int64, Int32, Int32> Add_AgentRenewal_IndividualProfileDetail(Clsprp_AgentRenewal_IndividualProfile smodel, string FileName, string FilePath, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_AgentRenewal_IndnOtherThanInd_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_IndexID", smodel.RenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", smodel.RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", smodel.RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", smodel.RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", 1);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", (smodel.Related_RERAnumberIssueDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", (smodel.Related_RERAnumberRegUptoDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_Agent_Type", 1);
            cmd.Parameters.AddWithValue("p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_Mode_RegistrationNumber", String.IsNullOrEmpty(smodel.Mode_RegistrationNumber) ? "" : smodel.Mode_RegistrationNumber);

            cmd.Parameters.AddWithValue("p_Agent_FirstName", String.IsNullOrEmpty(smodel.Agent_FirstName) ? "" : smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", String.IsNullOrEmpty(smodel.Agent_MiddleName) ? "" : smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Father_FirstName", String.IsNullOrEmpty(smodel.Father_FirstName) ? "" : smodel.Father_FirstName);
            cmd.Parameters.AddWithValue("p_Father_MiddleName", String.IsNullOrEmpty(smodel.Father_MiddleName) ? "" : smodel.Father_MiddleName);
            cmd.Parameters.AddWithValue("p_Father_LastName", String.IsNullOrEmpty(smodel.Father_LastName) ? "" : smodel.Father_LastName);
            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Image_FileName", FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_P_AddressLine1", String.IsNullOrEmpty(smodel.P_AddressLine1) ? "" : smodel.P_AddressLine1);
            cmd.Parameters.AddWithValue("p_P_AddressLine2", String.IsNullOrEmpty(smodel.P_AddressLine2) ? "" : smodel.P_AddressLine2);
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", smodel.P_AddressStateCode);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", smodel.P_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_P_AddressPIN", smodel.P_AddressPIN);

            cmd.Parameters.AddWithValue("p_Organization_Name", "NA");
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", 0);
            cmd.Parameters.AddWithValue("p_Organization_PAN_Number", "NA");
            cmd.Parameters.AddWithValue("p_Organization_MainObjects", "NA");

            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", 0);

            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine1", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine1) ? "" : smodel.BusinessPlace_AddressLine1);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine2", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine2) ? "" : smodel.BusinessPlace_AddressLine2);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressPIN", smodel.BusinessPlace_AddressPIN);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionCode", smodel.BusinessPlace_AddressSubDivisionCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionName", String.IsNullOrEmpty(smodel.BusinessPlace_AddressSubDivisionName) ? "" : smodel.BusinessPlace_AddressSubDivisionName);
            cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", String.IsNullOrEmpty(smodel.IsSameBussinessAdd_CommAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameBussinessAdd_CommAdd.ToString()));

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", (smodel.BComm_AddressStateCode == null || smodel.BComm_AddressStateCode == 0) ? 0 : smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", (smodel.BComm_AddressDistrictCode == null || smodel.BComm_AddressDistrictCode == 0) ? 0 : smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressPIN", (smodel.BComm_AddressPIN == null || smodel.BComm_AddressPIN == 0) ? 0 : smodel.BComm_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_LastName", "NA");

            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_PhoneNumber_STD", (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0) ? 0 : smodel.PhoneNumber_STD);
            cmd.Parameters.AddWithValue("p_PhoneNumber_Number", (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0) ? 0 : smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_PAN_Number", String.IsNullOrEmpty(smodel.PAN_Number) ? "" : smodel.PAN_Number);
            cmd.Parameters.AddWithValue("p_Aadhaar_Number", (smodel.Aadhaar_Number == null || smodel.Aadhaar_Number == 0) ? 0 : smodel.Aadhaar_Number);

            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", "N");
            cmd.Parameters.AddWithValue("p_IsOtherStateUT_RERAregistration", String.IsNullOrEmpty(smodel.IsOtherStateUT_RERAregistration) ? "N" : smodel.IsOtherStateUT_RERAregistration);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_Column) ? "" : smodel.A_Column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_Column) ? "" : smodel.B_Column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_Column) ? "" : smodel.C_Column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditional", smodel.IsConditional);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppParRenewalAgentID = new MySqlParameter("p_Get_RenewalAgentID", MySqlDbType.Int64);
            AppParRenewalAgentID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppParRenewalAgentID);

            MySqlParameter AppParRenewalAgentSequenceID = new MySqlParameter("p_Get_RenewalAgentSequenceID", MySqlDbType.Int32);
            AppParRenewalAgentSequenceID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppParRenewalAgentSequenceID);

            MySqlParameter AppParRenewalAgentYear = new MySqlParameter("p_Get_RenewalAgentYear", MySqlDbType.Int32);
            AppParRenewalAgentYear.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppParRenewalAgentYear);            
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppParRenewalAgentID.Value);
            Int32 AppSeqId = Convert.ToInt32(AppParRenewalAgentSequenceID.Value);
            Int32 AppYr = Convert.ToInt32(AppParRenewalAgentYear.Value);
            con.Close();

            //(RenewalAppID-RenewalSeqID-RenewalYear)
            return new Tuple<Int64, Int32, Int32>(AppId, AppSeqId, AppYr);
        }

        public Tuple<Int64, Int32, Int32> Add_AgentRenewal_OtherThanIndividualProfileDetail(Clsprp_AgentRenewal_OtherThanIndividualProfile smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_AgentRenewal_IndnOtherThanInd_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_IndexID", smodel.RenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", smodel.RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", smodel.RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", smodel.RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", 2);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", (smodel.Related_RERAnumberIssueDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", (smodel.Related_RERAnumberRegUptoDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_Agent_Type", 2);
            cmd.Parameters.AddWithValue("p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_Mode_RegistrationNumber", String.IsNullOrEmpty(smodel.Mode_RegistrationNumber) ? "" : smodel.Mode_RegistrationNumber);

            cmd.Parameters.AddWithValue("p_Agent_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_Agent_LastName", "NA");
            cmd.Parameters.AddWithValue("p_Father_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_Father_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_Father_LastName", "NA");
            cmd.Parameters.AddWithValue("p_Occupation", "NA");
            cmd.Parameters.AddWithValue("p_Image_FileName", string.Empty);
            cmd.Parameters.AddWithValue("p_Image_FilePath", string.Empty);
            cmd.Parameters.AddWithValue("p_P_AddressLine1", "NA");
            cmd.Parameters.AddWithValue("p_P_AddressLine2", "NA");
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", 0);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", 0);
            cmd.Parameters.AddWithValue("p_P_AddressPIN", 0);

            cmd.Parameters.AddWithValue("p_Organization_Name", String.IsNullOrEmpty(smodel.Organization_Name) ? "" : smodel.Organization_Name);
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", (smodel.Organization_TypeCode == null)?0: smodel.Organization_TypeCode);
            cmd.Parameters.AddWithValue("p_Organization_PAN_Number", String.IsNullOrEmpty(smodel.Organization_PAN_Number) ? "" : smodel.Organization_PAN_Number);
            cmd.Parameters.AddWithValue("p_Organization_MainObjects", String.IsNullOrEmpty(smodel.Organization_MainObjects) ? "" : smodel.Organization_MainObjects);

            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", String.IsNullOrEmpty(smodel.RegOffice_AddressLine1) ? "" : smodel.RegOffice_AddressLine1);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", String.IsNullOrEmpty(smodel.RegOffice_AddressLine2) ? "" : smodel.RegOffice_AddressLine2);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", smodel.RegOffice_AddressPIN);

            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine1", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine1) ? "" : smodel.BusinessPlace_AddressLine1);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine2", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine2) ? "" : smodel.BusinessPlace_AddressLine2);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressPIN", smodel.BusinessPlace_AddressPIN);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionCode", smodel.BusinessPlace_AddressSubDivisionCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionName", String.IsNullOrEmpty(smodel.BusinessPlace_AddressSubDivisionName) ? "" : smodel.BusinessPlace_AddressSubDivisionName);
            cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", String.IsNullOrEmpty(smodel.IsSameBussinessAdd_CommAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameBussinessAdd_CommAdd.ToString()));

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", (smodel.BComm_AddressStateCode == null || smodel.BComm_AddressStateCode == 0) ? 0 : smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", (smodel.BComm_AddressDistrictCode == null || smodel.BComm_AddressDistrictCode == 0) ? 0 : smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressPIN", (smodel.BComm_AddressPIN == null || smodel.BComm_AddressPIN == 0) ? 0 : smodel.BComm_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_FirstName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_FirstName) ? "" : smodel.AuthorizedSignatory_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_MiddleName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_MiddleName) ? "" : smodel.AuthorizedSignatory_MiddleName);
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_LastName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_LastName) ? "" : smodel.AuthorizedSignatory_LastName);

            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_PhoneNumber_STD", (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0) ? 0 : smodel.PhoneNumber_STD);
            cmd.Parameters.AddWithValue("p_PhoneNumber_Number", (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0) ? 0 : smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_PAN_Number", String.IsNullOrEmpty(smodel.PAN_Number) ? "" : smodel.PAN_Number);
            cmd.Parameters.AddWithValue("p_Aadhaar_Number", smodel.Aadhaar_Number);

            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", String.IsNullOrEmpty(smodel.IsOtherOrganizationMembers) ? "N" : smodel.IsOtherOrganizationMembers);
            cmd.Parameters.AddWithValue("p_IsOtherStateUT_RERAregistration", String.IsNullOrEmpty(smodel.IsOtherStateUT_RERAregistration) ? "N" : smodel.IsOtherStateUT_RERAregistration);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_Column) ? "" : smodel.A_Column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_Column) ? "" : smodel.B_Column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_Column) ? "" : smodel.C_Column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditional", smodel.IsConditional);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppParRenewalAgentID = new MySqlParameter("p_Get_RenewalAgentID", MySqlDbType.Int64);
            AppParRenewalAgentID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppParRenewalAgentID);

            MySqlParameter AppParRenewalAgentSequenceID = new MySqlParameter("p_Get_RenewalAgentSequenceID", MySqlDbType.Int32);
            AppParRenewalAgentSequenceID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppParRenewalAgentSequenceID);

            MySqlParameter AppParRenewalAgentYear = new MySqlParameter("p_Get_RenewalAgentYear", MySqlDbType.Int32);
            AppParRenewalAgentYear.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppParRenewalAgentYear);
            #endregion
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppParRenewalAgentID.Value);
            Int32 AppSeqId = Convert.ToInt32(AppParRenewalAgentSequenceID.Value);
            Int32 AppYr = Convert.ToInt32(AppParRenewalAgentYear.Value);
            con.Close();

            //(RenewalAppID-RenewalSeqID-RenewalYear)
            return new Tuple<Int64, Int32, Int32>(AppId, AppSeqId, AppYr);
        }

        public bool Update_AgentRenewal_IndividualProfileDetail(Clsprp_AgentRenewal_IndividualProfile smodel, string FileName, string FilePath,string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_AgentRenewal_IndnOtherThanInd_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_IndexID", smodel.RenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", smodel.RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", smodel.RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", smodel.RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", 1);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", (smodel.Related_RERAnumberIssueDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", (smodel.Related_RERAnumberRegUptoDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_Agent_Type", 1);
            cmd.Parameters.AddWithValue("p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_Mode_RegistrationNumber", String.IsNullOrEmpty(smodel.Mode_RegistrationNumber) ? "" : smodel.Mode_RegistrationNumber);

            cmd.Parameters.AddWithValue("p_Agent_FirstName", String.IsNullOrEmpty(smodel.Agent_FirstName) ? "" : smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", String.IsNullOrEmpty(smodel.Agent_MiddleName) ? "" : smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Father_FirstName", String.IsNullOrEmpty(smodel.Father_FirstName) ? "" : smodel.Father_FirstName);
            cmd.Parameters.AddWithValue("p_Father_MiddleName", String.IsNullOrEmpty(smodel.Father_MiddleName) ? "" : smodel.Father_MiddleName);
            cmd.Parameters.AddWithValue("p_Father_LastName", String.IsNullOrEmpty(smodel.Father_LastName) ? "" : smodel.Father_LastName);
            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Image_FileName", FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_P_AddressLine1", String.IsNullOrEmpty(smodel.P_AddressLine1) ? "" : smodel.P_AddressLine1);
            cmd.Parameters.AddWithValue("p_P_AddressLine2", String.IsNullOrEmpty(smodel.P_AddressLine2) ? "" : smodel.P_AddressLine2);
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", smodel.P_AddressStateCode);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", smodel.P_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_P_AddressPIN", smodel.P_AddressPIN);

            cmd.Parameters.AddWithValue("p_Organization_Name", "NA");
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", 0);
            cmd.Parameters.AddWithValue("p_Organization_PAN_Number", "NA");
            cmd.Parameters.AddWithValue("p_Organization_MainObjects", "NA");

            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", 0);

            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine1", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine1) ? "" : smodel.BusinessPlace_AddressLine1);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine2", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine2) ? "" : smodel.BusinessPlace_AddressLine2);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressPIN", smodel.BusinessPlace_AddressPIN);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionCode", smodel.BusinessPlace_AddressSubDivisionCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionName", String.IsNullOrEmpty(smodel.BusinessPlace_AddressSubDivisionName) ? "" : smodel.BusinessPlace_AddressSubDivisionName);
            cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", String.IsNullOrEmpty(smodel.IsSameBussinessAdd_CommAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameBussinessAdd_CommAdd.ToString()));

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", (smodel.BComm_AddressStateCode == null || smodel.BComm_AddressStateCode == 0) ? 0 : smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", (smodel.BComm_AddressDistrictCode == null || smodel.BComm_AddressDistrictCode == 0) ? 0 : smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressPIN", (smodel.BComm_AddressPIN == null || smodel.BComm_AddressPIN == 0) ? 0 : smodel.BComm_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_LastName", "NA");

            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_PhoneNumber_STD", (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0) ? 0 : smodel.PhoneNumber_STD);
            cmd.Parameters.AddWithValue("p_PhoneNumber_Number", (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0) ? 0 : smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_PAN_Number", String.IsNullOrEmpty(smodel.PAN_Number) ? "" : smodel.PAN_Number);
            cmd.Parameters.AddWithValue("p_Aadhaar_Number", (smodel.Aadhaar_Number == null || smodel.Aadhaar_Number == 0) ? 0 : smodel.Aadhaar_Number);

            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", "N");
            cmd.Parameters.AddWithValue("p_IsOtherStateUT_RERAregistration", String.IsNullOrEmpty(smodel.IsOtherStateUT_RERAregistration) ? "N" : smodel.IsOtherStateUT_RERAregistration);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_Column) ? "" : smodel.A_Column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_Column) ? "" : smodel.B_Column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_Column) ? "" : smodel.C_Column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
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

        public bool Update_AgentRenewal_OtherThanIndividualProfileDetail(Clsprp_AgentRenewal_OtherThanIndividualProfile smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_AgentRenewal_IndnOtherThanInd_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_IndexID", smodel.RenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", smodel.RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", smodel.RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", smodel.RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", 2);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", (smodel.Related_RERAnumberIssueDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", (smodel.Related_RERAnumberRegUptoDate == null) ? DateTime.MinValue : smodel.Related_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_Agent_Type", 2);
            cmd.Parameters.AddWithValue("p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_Mode_RegistrationNumber", String.IsNullOrEmpty(smodel.Mode_RegistrationNumber) ? "" : smodel.Mode_RegistrationNumber);

            cmd.Parameters.AddWithValue("p_Agent_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_Agent_LastName", "NA");
            cmd.Parameters.AddWithValue("p_Father_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_Father_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_Father_LastName", "NA");
            cmd.Parameters.AddWithValue("p_Occupation", "NA");
            cmd.Parameters.AddWithValue("p_Image_FileName", string.Empty);
            cmd.Parameters.AddWithValue("p_Image_FilePath", string.Empty);
            cmd.Parameters.AddWithValue("p_P_AddressLine1", "NA");
            cmd.Parameters.AddWithValue("p_P_AddressLine2", "NA");
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", 0);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", 0);
            cmd.Parameters.AddWithValue("p_P_AddressPIN", 0);

            cmd.Parameters.AddWithValue("p_Organization_Name", String.IsNullOrEmpty(smodel.Organization_Name) ? "" : smodel.Organization_Name);
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", (smodel.Organization_TypeCode == null) ? 0 : smodel.Organization_TypeCode);
            cmd.Parameters.AddWithValue("p_Organization_PAN_Number", String.IsNullOrEmpty(smodel.Organization_PAN_Number) ? "" : smodel.Organization_PAN_Number);
            cmd.Parameters.AddWithValue("p_Organization_MainObjects", String.IsNullOrEmpty(smodel.Organization_MainObjects) ? "" : smodel.Organization_MainObjects);

            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", String.IsNullOrEmpty(smodel.RegOffice_AddressLine1) ? "" : smodel.RegOffice_AddressLine1);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", String.IsNullOrEmpty(smodel.RegOffice_AddressLine2) ? "" : smodel.RegOffice_AddressLine2);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", smodel.RegOffice_AddressPIN);

            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine1", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine1) ? "" : smodel.BusinessPlace_AddressLine1);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine2", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine2) ? "" : smodel.BusinessPlace_AddressLine2);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressPIN", smodel.BusinessPlace_AddressPIN);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionCode", smodel.BusinessPlace_AddressSubDivisionCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressSubDivisionName", String.IsNullOrEmpty(smodel.BusinessPlace_AddressSubDivisionName) ? "" : smodel.BusinessPlace_AddressSubDivisionName);
            cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", String.IsNullOrEmpty(smodel.IsSameBussinessAdd_CommAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameBussinessAdd_CommAdd.ToString()));

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", (smodel.BComm_AddressStateCode == null || smodel.BComm_AddressStateCode == 0) ? 0 : smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", (smodel.BComm_AddressDistrictCode == null || smodel.BComm_AddressDistrictCode == 0) ? 0 : smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressPIN", (smodel.BComm_AddressPIN == null || smodel.BComm_AddressPIN == 0) ? 0 : smodel.BComm_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_FirstName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_FirstName) ? "" : smodel.AuthorizedSignatory_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_MiddleName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_MiddleName) ? "" : smodel.AuthorizedSignatory_MiddleName);
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_LastName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_LastName) ? "" : smodel.AuthorizedSignatory_LastName);

            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_PhoneNumber_STD", (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0) ? 0 : smodel.PhoneNumber_STD);
            cmd.Parameters.AddWithValue("p_PhoneNumber_Number", (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0) ? 0 : smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_PAN_Number", String.IsNullOrEmpty(smodel.PAN_Number) ? "" : smodel.PAN_Number);
            cmd.Parameters.AddWithValue("p_Aadhaar_Number", smodel.Aadhaar_Number);

            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", String.IsNullOrEmpty(smodel.IsOtherOrganizationMembers) ? "N" : smodel.IsOtherOrganizationMembers);
            cmd.Parameters.AddWithValue("p_IsOtherStateUT_RERAregistration", String.IsNullOrEmpty(smodel.IsOtherStateUT_RERAregistration) ? "N" : smodel.IsOtherStateUT_RERAregistration);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_Column) ? "" : smodel.A_Column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_Column) ? "" : smodel.B_Column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_Column) ? "" : smodel.C_Column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
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

        //Display Agent Detail
        public List<Clsprp_AgentRenewal_IndividualProfile> AgentRenewal_Display_IndividualProfile_AgentDetailByID(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_IndividualProfile> list_AgentProfile = new List<Clsprp_AgentRenewal_IndividualProfile>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_IndividualProfile", con);
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
                list_AgentProfile.Add(
                    new Clsprp_AgentRenewal_IndividualProfile
                    {
                        RenewalAgent_IndexID = Convert.ToInt64(dr["RenewalAgent_IndexID"]),
                        RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                        RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                        RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_RERAnumberIssueDate = (dr["Related_RERAnumberIssueDate"]) == null ? DateTime.MinValue : Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                        Related_RERAnumberRegUptoDate = (dr["Related_RERAnumberRegUptoDate"]) == null ? DateTime.MinValue : Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

                        IsAlready_RERANumber = String.IsNullOrEmpty(Convert.ToString(dr["IsAlready_RERANumber"])) ? "N" : Convert.ToString(dr["IsAlready_RERANumber"]),
                        Existing_RERANumber = String.IsNullOrEmpty(Convert.ToString(dr["Existing_RERANumber"])) ? string.Empty : Convert.ToString(dr["Existing_RERANumber"]),
                        Mode_RegistrationNumber = String.IsNullOrEmpty(Convert.ToString(dr["Mode_RegistrationNumber"])) ? "OnlineMode" : Convert.ToString(dr["Mode_RegistrationNumber"]),

                        Agent_FirstName = String.IsNullOrEmpty(Convert.ToString(dr["Agent_FirstName"])) ? string.Empty : Convert.ToString(dr["Agent_FirstName"]),
                        Agent_MiddleName = String.IsNullOrEmpty(Convert.ToString(dr["Agent_MiddleName"])) ? string.Empty : Convert.ToString(dr["Agent_MiddleName"]),
                        Agent_LastName = String.IsNullOrEmpty(Convert.ToString(dr["Agent_LastName"])) ? string.Empty : Convert.ToString(dr["Agent_LastName"]),
                        Father_FirstName = String.IsNullOrEmpty(Convert.ToString(dr["Father_FirstName"])) ? string.Empty : Convert.ToString(dr["Father_FirstName"]),
                        Father_MiddleName = String.IsNullOrEmpty(Convert.ToString(dr["Father_MiddleName"])) ? string.Empty : Convert.ToString(dr["Father_MiddleName"]),
                        Father_LastName = String.IsNullOrEmpty(Convert.ToString(dr["Father_LastName"])) ? string.Empty : Convert.ToString(dr["Father_LastName"]),
                        Occupation = String.IsNullOrEmpty(Convert.ToString(dr["Occupation"])) ? string.Empty : Convert.ToString(dr["Occupation"]),

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
                        BusinessPlace_AddressSubDivisionName = String.IsNullOrEmpty(Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"])) ? string.Empty : Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"]),

                        IsSameBussinessAdd_CommAdd = ((dr["IsSameBussinessAdd_CommAdd"] as string == "1") ? true : false),

                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                        BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),

                        AuthorizedSignatory_FirstName = String.IsNullOrEmpty(Convert.ToString(dr["AuthorizedSignatory_FirstName"])) ? string.Empty : Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                        AuthorizedSignatory_MiddleName = String.IsNullOrEmpty(Convert.ToString(dr["AuthorizedSignatory_MiddleName"])) ? string.Empty : Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                        AuthorizedSignatory_LastName = String.IsNullOrEmpty(Convert.ToString(dr["AuthorizedSignatory_LastName"])) ? string.Empty : Convert.ToString(dr["AuthorizedSignatory_LastName"]),

                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        PAN_Number = Convert.ToString(dr["PAN_Number"]),
                        Aadhaar_Number = (dr["Aadhaar_Number"] != null) ? Convert.ToInt64(dr["Aadhaar_Number"]) : 0,

                        IsOtherOrganizationMembers = String.IsNullOrEmpty(Convert.ToString(dr["IsOtherOrganizationMembers"])) ? "N" : Convert.ToString(dr["IsOtherOrganizationMembers"]),
                        IsOtherStateUT_RERAregistration = String.IsNullOrEmpty(Convert.ToString(dr["IsOtherStateUT_RERAregistration"])) ? "N" : Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                        A_Column = String.IsNullOrEmpty(Convert.ToString(dr["A_Column"])) ? "0" : Convert.ToString(dr["A_Column"]),
                        B_Column = Convert.ToString(dr["B_Column"]),
                        C_Column = Convert.ToString(dr["C_Column"]),

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
            return list_AgentProfile;
        }

        public List<Clsprp_AgentRenewal_OtherThanIndividualProfile> AgentRenewal_Display_OTIndProfile_AgentDetailByID(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_OtherThanIndividualProfile> list_AgentProfile = new List<Clsprp_AgentRenewal_OtherThanIndividualProfile>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_OtherThanIndividualProfile", con);
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
                list_AgentProfile.Add(
                    new Clsprp_AgentRenewal_OtherThanIndividualProfile
                    {
                        RenewalAgent_IndexID = Convert.ToInt64(dr["RenewalAgent_IndexID"]),
                        RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                        RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                        RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_RERAnumberIssueDate = (dr["Related_RERAnumberIssueDate"]) == null ? DateTime.MinValue : Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                        Related_RERAnumberRegUptoDate = (dr["Related_RERAnumberRegUptoDate"]) == null ? DateTime.MinValue : Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),

                        IsAlready_RERANumber = String.IsNullOrEmpty(Convert.ToString(dr["IsAlready_RERANumber"])) ? "N" : Convert.ToString(dr["IsAlready_RERANumber"]),
                        Existing_RERANumber = String.IsNullOrEmpty(Convert.ToString(dr["Existing_RERANumber"])) ? string.Empty : Convert.ToString(dr["Existing_RERANumber"]),
                        Mode_RegistrationNumber = String.IsNullOrEmpty(Convert.ToString(dr["Mode_RegistrationNumber"])) ? "OnlineMode" : Convert.ToString(dr["Mode_RegistrationNumber"]),

                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                        Organization_PAN_Number = Convert.ToString(dr["Organization_PAN_Number"]),
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
                        BusinessPlace_AddressSubDivisionName = String.IsNullOrEmpty(Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"])) ? string.Empty : Convert.ToString(dr["BusinessPlace_AddressSubDivisionName"]),

                        IsSameBussinessAdd_CommAdd = ((dr["IsSameBussinessAdd_CommAdd"] as string == "1") ? true : false),

                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                        BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),

                        AuthorizedSignatory_FirstName = String.IsNullOrEmpty(Convert.ToString(dr["AuthorizedSignatory_FirstName"])) ? string.Empty : Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                        AuthorizedSignatory_MiddleName = String.IsNullOrEmpty(Convert.ToString(dr["AuthorizedSignatory_MiddleName"])) ? string.Empty : Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                        AuthorizedSignatory_LastName = String.IsNullOrEmpty(Convert.ToString(dr["AuthorizedSignatory_LastName"])) ? string.Empty : Convert.ToString(dr["AuthorizedSignatory_LastName"]),

                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        PAN_Number = Convert.ToString(dr["PAN_Number"]),
                        Aadhaar_Number = (dr["Aadhaar_Number"] != null) ? Convert.ToInt64(dr["Aadhaar_Number"]) : 0,

                        IsOtherOrganizationMembers = String.IsNullOrEmpty(Convert.ToString(dr["IsOtherOrganizationMembers"])) ? "N" : Convert.ToString(dr["IsOtherOrganizationMembers"]),
                        IsOtherStateUT_RERAregistration = String.IsNullOrEmpty(Convert.ToString(dr["IsOtherStateUT_RERAregistration"])) ? "N" : Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                        A_Column = String.IsNullOrEmpty(Convert.ToString(dr["A_Column"])) ? "0" : Convert.ToString(dr["A_Column"]),
                        B_Column = Convert.ToString(dr["B_Column"]),
                        C_Column = Convert.ToString(dr["C_Column"]),

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
            return list_AgentProfile;
        }


    }
}