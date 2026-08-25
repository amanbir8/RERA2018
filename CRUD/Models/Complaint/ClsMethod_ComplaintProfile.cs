using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintProfile
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Add Complaint Profile Detail
        public Int64 AddComplaintProfileDetail(ClsPrp_ComplaintProfile smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_RERA_Complaint_UserProfile", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ComplaintProfile_IndexID", smodel.ComplaintProfile_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", smodel.ComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_UserID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_Applicant_FirstName", String.IsNullOrEmpty(smodel.Applicant_FirstName) ? "" : smodel.Applicant_FirstName);
            cmd.Parameters.AddWithValue("p_Applicant_MiddleName", String.IsNullOrEmpty(smodel.Applicant_MiddleName) ? "" : smodel.Applicant_MiddleName);
            cmd.Parameters.AddWithValue("p_Applicant_LastName", String.IsNullOrEmpty(smodel.Applicant_LastName) ? "" : smodel.Applicant_LastName);

            cmd.Parameters.AddWithValue("p_Father_FirstName", String.IsNullOrEmpty(smodel.Father_FirstName) ? "" : smodel.Father_FirstName);
            cmd.Parameters.AddWithValue("p_Father_MiddleName", String.IsNullOrEmpty(smodel.Father_MiddleName) ? "" : smodel.Father_MiddleName);
            cmd.Parameters.AddWithValue("p_Father_LastName", String.IsNullOrEmpty(smodel.Father_LastName) ? "" : smodel.Father_LastName);

            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation);

            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressLine1", String.IsNullOrEmpty(smodel.Residencial_Official_AddressLine1) ? "" : smodel.Residencial_Official_AddressLine1);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressLine2", String.IsNullOrEmpty(smodel.Residencial_Official_AddressLine2) ? "" : smodel.Residencial_Official_AddressLine2);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressStateCode", smodel.Residencial_Official_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressDistrictCode", smodel.Residencial_Official_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressPIN", smodel.Residencial_Official_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsSameCommunicationAdd_ResOffAdd", String.IsNullOrEmpty(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()));

            cmd.Parameters.AddWithValue("p_Comm_AddressLine1", String.IsNullOrEmpty(smodel.Comm_AddressLine1) ? "" : smodel.Comm_AddressLine1);
            cmd.Parameters.AddWithValue("p_Comm_AddressLine2", String.IsNullOrEmpty(smodel.Comm_AddressLine2) ? "" : smodel.Comm_AddressLine2);
            cmd.Parameters.AddWithValue("p_Comm_AddressStateCode", smodel.Comm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Comm_AddressDistrictCode", smodel.Comm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Comm_AddressPIN", smodel.Comm_AddressPIN);

            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            if (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0)
            { cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0); }
            else
            { cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_STD); }
            if (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0)
            { cmd.Parameters.AddWithValue("p_PhoneNumber_Number", 0); }
            else
            { cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number); }
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_Get_ComplaintID", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();           
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            return AppId;
        }

        public bool UpdateComplaintProfileDetail(ClsPrp_ComplaintProfile smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_RERA_Complaint_UserProfile", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ComplaintProfile_IndexID", smodel.ComplaintProfile_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", smodel.ComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_UserID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_Applicant_FirstName", String.IsNullOrEmpty(smodel.Applicant_FirstName) ? "" : smodel.Applicant_FirstName);
            cmd.Parameters.AddWithValue("p_Applicant_MiddleName", String.IsNullOrEmpty(smodel.Applicant_MiddleName) ? "" : smodel.Applicant_MiddleName);
            cmd.Parameters.AddWithValue("p_Applicant_LastName", String.IsNullOrEmpty(smodel.Applicant_LastName) ? "" : smodel.Applicant_LastName);

            cmd.Parameters.AddWithValue("p_Father_FirstName", String.IsNullOrEmpty(smodel.Father_FirstName) ? "" : smodel.Father_FirstName);
            cmd.Parameters.AddWithValue("p_Father_MiddleName", String.IsNullOrEmpty(smodel.Father_MiddleName) ? "" : smodel.Father_MiddleName);
            cmd.Parameters.AddWithValue("p_Father_LastName", String.IsNullOrEmpty(smodel.Father_LastName) ? "" : smodel.Father_LastName);

            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation);

            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressLine1", String.IsNullOrEmpty(smodel.Residencial_Official_AddressLine1) ? "" : smodel.Residencial_Official_AddressLine1);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressLine2", String.IsNullOrEmpty(smodel.Residencial_Official_AddressLine2) ? "" : smodel.Residencial_Official_AddressLine2);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressStateCode", smodel.Residencial_Official_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressDistrictCode", smodel.Residencial_Official_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Residencial_Official_AddressPIN", smodel.Residencial_Official_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsSameCommunicationAdd_ResOffAdd", String.IsNullOrEmpty(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()));

            cmd.Parameters.AddWithValue("p_Comm_AddressLine1", String.IsNullOrEmpty(smodel.Comm_AddressLine1) ? "" : smodel.Comm_AddressLine1);
            cmd.Parameters.AddWithValue("p_Comm_AddressLine2", String.IsNullOrEmpty(smodel.Comm_AddressLine2) ? "" : smodel.Comm_AddressLine2);
            cmd.Parameters.AddWithValue("p_Comm_AddressStateCode", smodel.Comm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Comm_AddressDistrictCode", smodel.Comm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Comm_AddressPIN", smodel.Comm_AddressPIN);

            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);           
            if (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0)
            {  cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0);     }
            else
            {  cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_STD);     }            
            if (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0)
            {  cmd.Parameters.AddWithValue("p_PhoneNumber_Number", 0);  }
            else
            {  cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);   }
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);            

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

        //Display ComplaintProfile on basis of ID
        public List<ClsPrp_ComplaintProfile> DisplayComplaintProfileDetail(Int64 ComplaintProfile_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_UserProfile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", ComplaintProfile_ID);
           
            List<ClsPrp_ComplaintProfile> list_indPro = new List<ClsPrp_ComplaintProfile>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            con.Open();
            sd.Fill(dt);
            con.Close();

            //Int64 varAdhaarNo = 0;

            foreach (DataRow dr in dt.Rows)
            {
                //if (dr["Aadhaar_Number"] != null)
                //    varAdhaarNo = Convert.ToInt64(dr["Aadhaar_Number"]);

                list_indPro.Add(
                    new ClsPrp_ComplaintProfile
                    {
                        ComplaintProfile_IndexID = Convert.ToInt64(dr["ComplaintProfile_IndexID"]),
                        ComplaintProfile_ID = Convert.ToInt64(dr["ComplaintProfile_ID"]),
                        UserID = Convert.ToString(dr["UserID"]),

                        Applicant_FirstName = Convert.ToString(dr["Applicant_FirstName"]),
                        Applicant_MiddleName = Convert.ToString(dr["Applicant_MiddleName"]),
                        Applicant_LastName = Convert.ToString(dr["Applicant_LastName"]),

                        Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                        Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                        Father_LastName = Convert.ToString(dr["Father_LastName"]),

                        Occupation = Convert.ToString(dr["Occupation"]),

                        Residencial_Official_AddressLine1 = Convert.ToString(dr["Residencial_Official_AddressLine1"]),
                        Residencial_Official_AddressLine2 = Convert.ToString(dr["Residencial_Official_AddressLine2"]),
                        Residencial_Official_AddressStateCode = Convert.ToInt32(dr["Residencial_Official_AddressStateCode"]),
                        Residencial_Official_AddressDistrictCode = Convert.ToInt32(dr["Residencial_Official_AddressDistrictCode"]),
                        Residencial_Official_AddressPIN = Convert.ToString(dr["Residencial_Official_AddressPIN"]),

                        IsSameCommunicationAdd_ResOffAdd = ((dr["IsSameCommunicationAdd_ResOffAdd"] as string == "1") ? true : false),
                        Comm_AddressLine1 = Convert.ToString(dr["Comm_AddressLine1"]),
                        Comm_AddressLine2 = Convert.ToString(dr["Comm_AddressLine2"]),
                        Comm_AddressStateCode = Convert.ToInt32(dr["Comm_AddressStateCode"]),
                        Comm_AddressDistrictCode = Convert.ToInt32(dr["Comm_AddressDistrictCode"]),
                        Comm_AddressPIN = Convert.ToInt32(dr["Comm_AddressPIN"]),

                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }

            return list_indPro;
        }
        public List<ClsPrp_ComplaintAdvocateProfile> DisplayComplaintProfileDetails(Int64 ComplaintProfile_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_UserProfile_AdvName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", ComplaintProfile_ID);
           
            List<ClsPrp_ComplaintAdvocateProfile> list_indPro = new List<ClsPrp_ComplaintAdvocateProfile>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            con.Open();
            sd.Fill(dt);
            con.Close();

            //Int64 varAdhaarNo = 0;

            foreach (DataRow dr in dt.Rows)
            {
                //if (dr["Aadhaar_Number"] != null)
                //    varAdhaarNo = Convert.ToInt64(dr["Aadhaar_Number"]);

                list_indPro.Add(
                    new ClsPrp_ComplaintAdvocateProfile
                    {
                        ComplaintProfile_IndexID = Convert.ToInt64(dr["ComplaintProfile_IndexID"]),
                        ComplaintProfile_ID = Convert.ToInt64(dr["ComplaintProfile_ID"]),
                        UserID = Convert.ToString(dr["UserID"]),

                        Applicant_FirstName = Convert.ToString(dr["Applicant_FirstName"]),
                        Applicant_MiddleName = Convert.ToString(dr["Applicant_MiddleName"]),
                        Applicant_LastName = Convert.ToString(dr["Applicant_LastName"]),

                        Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                        Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                        Father_LastName = Convert.ToString(dr["Father_LastName"]),

                        Occupation = Convert.ToString(dr["Occupation"]),

                        Residencial_Official_AddressLine1 = Convert.ToString(dr["Residencial_Official_AddressLine1"]),
                        Residencial_Official_AddressLine2 = Convert.ToString(dr["Residencial_Official_AddressLine2"]),
                        Residencial_Official_AddressStateCode = Convert.ToInt32(dr["Residencial_Official_AddressStateCode"]),
                        Residencial_Official_AddressDistrictCode = Convert.ToInt32(dr["Residencial_Official_AddressDistrictCode"]),
                        Residencial_Official_AddressPIN = Convert.ToString(dr["Residencial_Official_AddressPIN"]),

                        IsSameCommunicationAdd_ResOffAdd = ((dr["IsSameCommunicationAdd_ResOffAdd"] as string == "1") ? true : false),
                        Comm_AddressLine1 = Convert.ToString(dr["Comm_AddressLine1"]),
                        Comm_AddressLine2 = Convert.ToString(dr["Comm_AddressLine2"]),
                        Comm_AddressStateCode = Convert.ToInt32(dr["Comm_AddressStateCode"]),
                        Comm_AddressDistrictCode = Convert.ToInt32(dr["Comm_AddressDistrictCode"]),
                        Comm_AddressPIN = Convert.ToInt32(dr["Comm_AddressPIN"]),

                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        CounselRepresentative = Convert.ToString(dr["CounselRepresentative"])
                    });
            }

            return list_indPro;
        }


        public bool update_ComplaintFormM_Detail(Int64 ComplainantProfile_id, Int64 AdvID,string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("update_additionalFormMcomplainant_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime modifytime = DateTime.Now;

            #region Parameters
            cmd.Parameters.AddWithValue("p_complainantprofile_id", ComplainantProfile_id);
            cmd.Parameters.AddWithValue("p_AdvID", AdvID);
            cmd.Parameters.AddWithValue("p_userName", userName);
            cmd.Parameters.AddWithValue("p_modifytime", modifytime);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }




        //EXECUTION METHOD:

        //public List<ClsPrp_ExecutionForm> DisplayExecutionProfileDetail(Int64 ComplaintProfile_ID)
        //{
        //    connection();
        //    MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_UserProfile", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", ComplaintProfile_ID);

        //    List<ClsPrp_ComplaintProfile> list_indPro = new List<ClsPrp_ComplaintProfile>();

        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();


        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();

        //    //Int64 varAdhaarNo = 0;

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //if (dr["Aadhaar_Number"] != null)
        //        //    varAdhaarNo = Convert.ToInt64(dr["Aadhaar_Number"]);

        //        list_indPro.Add(
        //            new ClsPrp_ComplaintProfile
        //            {
        //                ComplaintProfile_IndexID = Convert.ToInt64(dr["ComplaintProfile_IndexID"]),
        //                ComplaintProfile_ID = Convert.ToInt64(dr["ComplaintProfile_ID"]),
        //                UserID = Convert.ToString(dr["UserID"]),

        //                Applicant_FirstName = Convert.ToString(dr["Applicant_FirstName"]),
        //                Applicant_MiddleName = Convert.ToString(dr["Applicant_MiddleName"]),
        //                Applicant_LastName = Convert.ToString(dr["Applicant_LastName"]),

        //                Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
        //                Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
        //                Father_LastName = Convert.ToString(dr["Father_LastName"]),

        //                Occupation = Convert.ToString(dr["Occupation"]),

        //                Residencial_Official_AddressLine1 = Convert.ToString(dr["Residencial_Official_AddressLine1"]),
        //                Residencial_Official_AddressLine2 = Convert.ToString(dr["Residencial_Official_AddressLine2"]),
        //                Residencial_Official_AddressStateCode = Convert.ToInt32(dr["Residencial_Official_AddressStateCode"]),
        //                Residencial_Official_AddressDistrictCode = Convert.ToInt32(dr["Residencial_Official_AddressDistrictCode"]),
        //                Residencial_Official_AddressPIN = Convert.ToString(dr["Residencial_Official_AddressPIN"]),

        //                IsSameCommunicationAdd_ResOffAdd = ((dr["IsSameCommunicationAdd_ResOffAdd"] as string == "1") ? true : false),
        //                Comm_AddressLine1 = Convert.ToString(dr["Comm_AddressLine1"]),
        //                Comm_AddressLine2 = Convert.ToString(dr["Comm_AddressLine2"]),
        //                Comm_AddressStateCode = Convert.ToInt32(dr["Comm_AddressStateCode"]),
        //                Comm_AddressDistrictCode = Convert.ToInt32(dr["Comm_AddressDistrictCode"]),
        //                Comm_AddressPIN = Convert.ToInt32(dr["Comm_AddressPIN"]),

        //                MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
        //                PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
        //                PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
        //                EmailAddress = Convert.ToString(dr["EmailAddress"]),

        //                Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
        //                A_column = Convert.ToString(dr["A_column"]),
        //                B_column = Convert.ToString(dr["B_column"]),
        //                C_column = Convert.ToString(dr["C_column"]),

        //                IsActive = Convert.ToInt32(dr["IsActive"]),
        //                IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //                CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //                CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
        //                ModifyBy = Convert.ToString(dr["ModifyBy"]),
        //                ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
        //            });
        //    }

        //    return list_indPro;
        //}
    }
}