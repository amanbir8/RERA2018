using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using CRUD.Models.Agent;

namespace CRUD.Models.Agent
{
    public class CLSMethod_Agent
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        // Add Agent Detail
        public Int64 AddAgentDetail(Clsprp_Agent smodel, string FileName, string FilePath, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Agent_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_Type", 1);
            cmd.Parameters.AddWithValue("p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);// smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
           // cmd.Parameters.AddWithValue("p_Existing_RERANumber", smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", String.IsNullOrEmpty(smodel.Agent_MiddleName) ? "" : smodel.Agent_MiddleName);//smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName); //smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Father_FirstName", smodel.Father_FirstName);
            cmd.Parameters.AddWithValue("p_Father_MiddleName", String.IsNullOrEmpty(smodel.Father_MiddleName) ? "" : smodel.Father_MiddleName); //smodel.Father_MiddleName);
            cmd.Parameters.AddWithValue("p_Father_LastName", String.IsNullOrEmpty(smodel.Father_LastName) ? "" : smodel.Father_LastName); //smodel.Father_LastName);
            cmd.Parameters.AddWithValue("p_Occupation", smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Image_FileName", FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_P_AddressLine1", smodel.P_AddressLine1);
            cmd.Parameters.AddWithValue("p_P_AddressLine2", String.IsNullOrEmpty(smodel.P_AddressLine2) ? "" : smodel.P_AddressLine2);// smodel.P_AddressLine2);
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", smodel.P_AddressStateCode);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", smodel.P_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_P_AddressPIN", smodel.P_AddressPIN);
            cmd.Parameters.AddWithValue("p_Organization_Name", "NA");
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", 0);
            cmd.Parameters.AddWithValue("p_Organization_MainObjects", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", 0);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine1", smodel.BusinessPlace_AddressLine1);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine2", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine2) ? "" : smodel.BusinessPlace_AddressLine2); //smodel.BusinessPlace_AddressLine2);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressPIN", smodel.BusinessPlace_AddressPIN);
           // cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", smodel.IsSameBussinessAdd_CommAdd);
            cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", String.IsNullOrEmpty(smodel.IsSameBussinessAdd_CommAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameBussinessAdd_CommAdd.ToString()));

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);// smodel.BComm_AddressLine2);

            if (smodel.BComm_AddressStateCode == null || smodel.BComm_AddressStateCode == 0)
            { cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", 0); }
            else { cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", smodel.BComm_AddressStateCode); }
            if (smodel.BComm_AddressDistrictCode == null || smodel.BComm_AddressDistrictCode == 0)
            { cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", 0); }
            else { cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", smodel.BComm_AddressDistrictCode); }
            if (smodel.BComm_AddressPIN == null || smodel.BComm_AddressPIN == 0)
            { cmd.Parameters.AddWithValue("p_BComm_AddressPIN", 0); }
            else { cmd.Parameters.AddWithValue("p_BComm_AddressPIN", smodel.BComm_AddressPIN); }

            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_FirstName","NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_LastName", "NA");
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            if (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_Number);
            }
            //cmd.Parameters.AddWithValue("p_PhoneNumber_STD",  smodel.PhoneNumber_Number);
            if (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0)
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_Number", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);
            }
            //cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_PAN_Number", smodel.PAN_Number);
            if (smodel.Aadhaar_Number == null || smodel.Aadhaar_Number == 0)
            {
                cmd.Parameters.AddWithValue("p_Aadhaar_Number", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Aadhaar_Number", smodel.Aadhaar_Number);
            }
            //cmd.Parameters.AddWithValue("p_Aadhaar_Number", smodel.Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", "Y");
            cmd.Parameters.AddWithValue("p_IsOtherStateUT_RERAregistration", smodel.IsOtherStateUT_RERAregistration);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyBy" , userName);
            cmd.Parameters.AddWithValue("p_A_column", UID);

            if (smodel.B_Column == null || smodel.B_Column == "0")
            {  cmd.Parameters.AddWithValue("p_B_column", 0); }
            else
            {  cmd.Parameters.AddWithValue("p_B_column", smodel.B_Column); }

            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_Column) ? "" : smodel.C_Column);

            MySqlParameter AppPar = new MySqlParameter("p_Get_AgentID", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();           
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            return AppId;
        }

        public bool UpdateAgentDetail(Clsprp_Agent smodel, string FileName, string FilePath,string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Agent_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", smodel.Agent_ID);
            cmd.Parameters.AddWithValue("p_Agent_Type", smodel.Agent_Type);
            cmd.Parameters.AddWithValue("p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            // cmd.Parameters.AddWithValue("p_Existing_RERANumber", smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", String.IsNullOrEmpty(smodel.Agent_MiddleName) ? "" : smodel.Agent_MiddleName);//smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName); //smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Father_FirstName", smodel.Father_FirstName);
            cmd.Parameters.AddWithValue("p_Father_MiddleName", String.IsNullOrEmpty(smodel.Father_MiddleName) ? "" : smodel.Father_MiddleName); //smodel.Father_MiddleName);
            cmd.Parameters.AddWithValue("p_Father_LastName", String.IsNullOrEmpty(smodel.Father_LastName) ? "" : smodel.Father_LastName); //smodel.Father_LastName);
            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation); //smodel.Father_LastName);smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Image_FileName", FileName);// String.IsNullOrEmpty(smodel.Image_FileName) ? "" : smodel.Image_FileName); //smodel.Father_LastName);smodel.Image_FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", FilePath);// String.IsNullOrEmpty(smodel.Image_FilePath) ? "" : smodel.Image_FilePath); //smodel.Father_LastName);smodel.Image_FilePath);
            cmd.Parameters.AddWithValue("p_P_AddressLine1", smodel.P_AddressLine1);
            cmd.Parameters.AddWithValue("p_P_AddressLine2", String.IsNullOrEmpty(smodel.P_AddressLine2) ? "" : smodel.P_AddressLine2);// smodel.P_AddressLine2);
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", smodel.P_AddressStateCode);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", smodel.P_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_P_AddressPIN", smodel.P_AddressPIN);
            cmd.Parameters.AddWithValue("p_Organization_Name", "NA");
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", 0);
            cmd.Parameters.AddWithValue("p_Organization_MainObjects", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", "NA");
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", 0);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", 0);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine1", smodel.BusinessPlace_AddressLine1);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressLine2", String.IsNullOrEmpty(smodel.BusinessPlace_AddressLine2) ? "" : smodel.BusinessPlace_AddressLine2); //smodel.BusinessPlace_AddressLine2);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressPIN", smodel.BusinessPlace_AddressPIN);
            // cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", smodel.IsSameBussinessAdd_CommAdd);
            cmd.Parameters.AddWithValue("p_IsSameBussinessAdd_CommAdd", String.IsNullOrEmpty(smodel.IsSameBussinessAdd_CommAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameBussinessAdd_CommAdd.ToString()));


            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);// smodel.BComm_AddressLine2);

            if (smodel.BComm_AddressStateCode == null || smodel.BComm_AddressStateCode == 0)
            { cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", 0); }
            else { cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", smodel.BComm_AddressStateCode); }
            if (smodel.BComm_AddressDistrictCode == null || smodel.BComm_AddressDistrictCode == 0)
            { cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", 0); }
            else { cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", smodel.BComm_AddressDistrictCode); }
            if (smodel.BComm_AddressPIN == null || smodel.BComm_AddressPIN == 0)
            { cmd.Parameters.AddWithValue("p_BComm_AddressPIN", 0); }
            else { cmd.Parameters.AddWithValue("p_BComm_AddressPIN", smodel.BComm_AddressPIN); }

            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_FirstName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_MiddleName", "NA");
            cmd.Parameters.AddWithValue("p_AuthorizedSignatory_LastName", "NA");
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            if (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_Number);
            }
            //cmd.Parameters.AddWithValue("p_PhoneNumber_STD",  smodel.PhoneNumber_Number);
            if (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0)
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_Number", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);
            }
            //cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);
            cmd.Parameters.AddWithValue("p_EmailAddress", smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_PAN_Number", smodel.PAN_Number);
            if (smodel.Aadhaar_Number == null || smodel.Aadhaar_Number == 0)
            {
                cmd.Parameters.AddWithValue("p_Aadhaar_Number", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Aadhaar_Number", smodel.Aadhaar_Number);
            }
            //cmd.Parameters.AddWithValue("p_Aadhaar_Number", smodel.Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", "Y");
            cmd.Parameters.AddWithValue("p_IsOtherStateUT_RERAregistration", smodel.IsOtherStateUT_RERAregistration);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_A_column", UID);

            if (smodel.B_Column == null || smodel.B_Column == "0")
            { cmd.Parameters.AddWithValue("p_B_column", 0); }
            else
            { cmd.Parameters.AddWithValue("p_B_column", smodel.B_Column); }

            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_Column) ? "" : smodel.C_Column);

            //cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            //cmd.Parameters.AddWithValue("p_Created_On", smodel.Created_On);
            //cmd.Parameters.AddWithValue("p_Modified_On", smodel.Modified_On);
            //cmd.Parameters.AddWithValue("p_Flag", 2);
            //cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        
        //Display Agent Profile on basis of Agent ID
        public List<Clsprp_Agent> DisplayAgentDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
           
            List<Clsprp_Agent> list_indPro = new List<Clsprp_Agent>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();

            Int64 varAdhaarNo = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Aadhaar_Number"] != null)
                    varAdhaarNo = Convert.ToInt64(dr["Aadhaar_Number"]);

                list_indPro.Add(
                    new Clsprp_Agent
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

                        Aadhaar_Number = varAdhaarNo, 
                                                                                           
                        IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                        IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                        B_Column = Convert.ToString(dr["B_Column"]),
                        C_Column = Convert.ToString(dr["C_Column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }


    }
}