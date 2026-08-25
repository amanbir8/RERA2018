using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
namespace CRUD.Models.Agent
{
    public class ClsMethodRera_Agent_OtherMemberDetail
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        // Add  Rera Other Memmber Data

        public bool AddReraOtherMember(ClsprpRera_Agent_OtherMemberDetail smodel,Int64 Application_id, string FileName, string FilePath)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Agent_OtherMemberDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Agent_ID", Application_id);
            cmd.Parameters.AddWithValue("p_Designation", smodel.Designation);
            cmd.Parameters.AddWithValue("p_OtherMember_Name", smodel.OtherMember_Name);
            cmd.Parameters.AddWithValue("p_OtherMember_PAN_Number", smodel.OtherMember_PAN_Number);
            cmd.Parameters.AddWithValue("p_OtherMember_Aadhaar_Number", smodel.OtherMember_Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine1", smodel.OfficeComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine2", String.IsNullOrEmpty(smodel.OfficeComm_AddressLine2) ? "" : smodel.OfficeComm_AddressLine2); //smodel.OfficeComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressStateCode", smodel.OfficeComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressDistrictCode", smodel.OfficeComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressPIN", smodel.OfficeComm_AddressPIN);
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
            cmd.Parameters.AddWithValue("p_EmailAddress", smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_Image_FileName", FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "CreatedBy");//smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_ModifyBy", "ModifyBy");// smodel.ModifyBy);
            //cmd.Parameters.AddWithValue("Get_AgentMemID bigint output", smodel.Get_AgentMemID bigint output);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;

        }


        public bool UpdateReraOtherMember(ClsprpRera_Agent_OtherMemberDetail smodel,Int64 Application_id, string FileName, string FilePath)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Agent_OtherMemberDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_OtherMemberDetails_ID", smodel.Agent_OtherMemberDetails_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Application_id);
            
            cmd.Parameters.AddWithValue("p_Designation", smodel.Designation);
            cmd.Parameters.AddWithValue("p_OtherMember_Name", smodel.OtherMember_Name);
            cmd.Parameters.AddWithValue("p_OtherMember_PAN_Number", smodel.OtherMember_PAN_Number);
            cmd.Parameters.AddWithValue("p_OtherMember_Aadhaar_Number", smodel.OtherMember_Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine1", smodel.OfficeComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressLine2", String.IsNullOrEmpty(smodel.OfficeComm_AddressLine2) ? "" : smodel.OfficeComm_AddressLine2); //smodel.OfficeComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressStateCode", smodel.OfficeComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressDistrictCode", smodel.OfficeComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeComm_AddressPIN", smodel.OfficeComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            if (smodel.PhoneNumber_STD == null || smodel.PhoneNumber_STD == 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_Number);

            }
            if (smodel.PhoneNumber_Number == null || smodel.PhoneNumber_Number == 0)
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_Number", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_Number", smodel.PhoneNumber_Number);

            }
            cmd.Parameters.AddWithValue("p_EmailAddress", smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_Image_FileName", FileName);
            cmd.Parameters.AddWithValue("p_Image_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
             cmd.Parameters.AddWithValue("p_CreatedBy", "CreatedBy");//smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_ModifyBy", "ModifyBy");// smodel.ModifyBy);
            //cmd.Parameters.AddWithValue("Get_AgentMemID bigint output", smodel.Get_AgentMemID bigint output);


            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            Int64 AppId = Convert.ToInt64(AppPar.Value);

            if (i >= 1)
                return true;
            else
                return false;

        }
        public List<ClsprpRera_Agent_OtherMemberDetail> DisplayAgentOthermemberDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_OtherMember_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);



            connection();
            List<ClsprpRera_Agent_OtherMemberDetail> list_indPro = new List<ClsprpRera_Agent_OtherMemberDetail>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpRera_Agent_OtherMemberDetail
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
                        MobileNumber= Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD  = Convert.ToInt64(dr["PhoneNumber_STD"]),
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

        public List<ClsprpRera_Agent_OtherMemberDetail> DisplayAgentOthermemberDetailByMemberID(Int64 parm_Agent_ID, Int64 Agent_OtherMemberDetails_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_OtherMemberDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", parm_Agent_ID);
            cmd.Parameters.AddWithValue("p_Agent_OtherMemberDetails_ID", Agent_OtherMemberDetails_ID);


            
            List<ClsprpRera_Agent_OtherMemberDetail> list_indPro = new List<ClsprpRera_Agent_OtherMemberDetail>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpRera_Agent_OtherMemberDetail
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

        public bool Delete_AgentOthermemberDetail(Int64 Agent_ID, Int64 Agent_OtherMemberDetails_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Agent_OtherMemberDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_Agent_OtherMemberDetails_ID", Agent_OtherMemberDetails_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}