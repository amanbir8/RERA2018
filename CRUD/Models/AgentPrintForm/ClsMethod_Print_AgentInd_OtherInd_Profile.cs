using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsMethod_Print_AgentInd_OtherInd_Profile
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Print_AgentOtherIndProfile> Display_Print_AgentOtherThanIndDetail(Int64 Agent_ID)
        {
            connection();
            List<ClsPrp_Print_AgentOtherIndProfile> list_indPro = new List<ClsPrp_Print_AgentOtherIndProfile>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Profile_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

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
                    new ClsPrp_Print_AgentOtherIndProfile
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

                    });
                }
                else
                {
                    list_indPro.Add(
                    new ClsPrp_Print_AgentOtherIndProfile
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

        public List<ClsPrp_Print_RenewalAgent_AgentOtherIndProfile> Display_Print_RenewalAgent_OtherThanIndDetail(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_Print_RenewalAgent_AgentOtherIndProfile> list_indPro = new List<ClsPrp_Print_RenewalAgent_AgentOtherIndProfile>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_PrintAgentRenewal_Profile_ForPrint", con);
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
                if (Convert.ToInt32(dr["Related_Agent_Type"]) == 2)
                {
                    list_indPro.Add(
                    new ClsPrp_Print_RenewalAgent_AgentOtherIndProfile
                    {
                        RenewalAgent_IndexID = Convert.ToInt64(dr["RenewalAgent_IndexID"]),
                        RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),

                        Related_RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),


                        IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                        Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),

                        Occupation = Convert.ToString(dr["Organization_PAN_Number"]),

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
                else
                {
                    list_indPro.Add(
                    new ClsPrp_Print_RenewalAgent_AgentOtherIndProfile
                    {
                        RenewalAgent_IndexID = Convert.ToInt64(dr["RenewalAgent_IndexID"]),
                        RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),

                        Related_RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),

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
            return list_indPro;
        }
    }
}