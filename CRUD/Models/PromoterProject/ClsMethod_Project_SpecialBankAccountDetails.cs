using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_Project_SpecialBankAccountDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_SpecialBankAccountDetails(ClsPrp_Project_SpecialBankAccountDetails smodel, Int64 Project_id, String Photo_Address, String ext)//, string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_SpecialBankAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_SpecialBankAccount_IndexID", smodel.SpecialBankAccount_IndexID);
            //cmd.Parameters.AddWithValue("p_p_SpecialBankAccount_ID", smodel.SpecialBankAccount_ID);
            cmd.Parameters.AddWithValue("p_p_SpecialBankAccountRelated_ProjectRegistration_ID", Project_id);// smodel.SpecialBankAccountRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_p_Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_p_Bank_AccountNumber", smodel.Bank_AccountNumber);
            cmd.Parameters.AddWithValue("p_p_Bank_IFSC_Code", smodel.Bank_IFSC_Code);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressLine1", smodel.Bank_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressLine2", String.IsNullOrEmpty(smodel.Bank_AddressLine2) ? "" : smodel.Bank_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressStateCode", smodel.Bank_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressDistrictCode", smodel.Bank_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressPIN", smodel.Bank_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_ImageCancelledCheque_FileName", ext);// smodel.ImageCancelledCheque_FileName);
            cmd.Parameters.AddWithValue("p_p_ImageCancelledCheque_FilePath", Photo_Address);// smodel.ImageCancelledCheque_FilePath);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column); 
            cmd.Parameters.AddWithValue("p_p_B_column", ""); //smodel.B_column);
            //cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            //con.Close();
            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }
        
        public bool Update_Project_SpecialBankAccountDetails(ClsPrp_Project_SpecialBankAccountDetails smodel, String Photo_Address, String ext)//, string PANaddress, string OrgCertaddress, string Image_FileName, Int64 Application_id, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_SpecialBankAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_SpecialBankAccount_IndexID", smodel.SpecialBankAccount_IndexID);
            cmd.Parameters.AddWithValue("p_p_SpecialBankAccount_ID", smodel.SpecialBankAccount_ID);
            cmd.Parameters.AddWithValue("p_p_SpecialBankAccountRelated_ProjectRegistration_ID", smodel.SpecialBankAccountRelated_ProjectRegistration_ID);

            cmd.Parameters.AddWithValue("p_p_Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_p_Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_p_Bank_AccountNumber", smodel.Bank_AccountNumber);

            cmd.Parameters.AddWithValue("p_p_Bank_IFSC_Code", smodel.Bank_IFSC_Code);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressLine1", smodel.Bank_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressLine2", String.IsNullOrEmpty(smodel.Bank_AddressLine2)?"": smodel.Bank_AddressLine2);

            cmd.Parameters.AddWithValue("p_p_Bank_AddressStateCode", smodel.Bank_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressDistrictCode", smodel.Bank_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_Bank_AddressPIN", smodel.Bank_AddressPIN);

            cmd.Parameters.AddWithValue("p_p_ImageCancelledCheque_FileName", ext);//smodel.ImageCancelledCheque_FileName);
            cmd.Parameters.AddWithValue("p_p_ImageCancelledCheque_FilePath", Photo_Address);// smodel.ImageCancelledCheque_FilePath);

            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", ""); //smodel.B_column);
            //cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
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

        public List<ClsPrp_Project_SpecialBankAccountDetails> Display_Project_SpecialBankAccountDetails(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_Project_SpecialBankAccountDetails> ProjectFivelist1 = new List<ClsPrp_Project_SpecialBankAccountDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_SpecialBankAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_SpecialBank_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_SpecialBankAccountDetails
                       {
                           SpecialBankAccount_IndexID = Convert.ToInt64(dr["SpecialBankAccount_IndexID"]),
                           SpecialBankAccount_ID = Convert.ToInt64(dr["SpecialBankAccount_ID"]),
                           SpecialBankAccountRelated_ProjectRegistration_ID = Convert.ToInt64(dr["SpecialBankAccountRelated_ProjectRegistration_ID"]),
                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Branch_Name = Convert.ToString(dr["Branch_Name"]),
                           Bank_AccountNumber = Convert.ToString(dr["Bank_AccountNumber"]),
                           Bank_IFSC_Code = Convert.ToString(dr["Bank_IFSC_Code"]),
                           Bank_AddressLine1 = Convert.ToString(dr["Bank_AddressLine1"]),
                           Bank_AddressLine2 = Convert.ToString(dr["Bank_AddressLine2"]),
                           Bank_AddressStateCode = Convert.ToInt32(dr["Bank_AddressStateCode"]),
                           Bank_AddressDistrictCode = Convert.ToInt32(dr["Bank_AddressDistrictCode"]),
                           Bank_AddressPIN = Convert.ToString(dr["Bank_AddressPIN"]),
                           ImageCancelledCheque_FileName = Convert.ToString(dr["ImageCancelledCheque_FileName"]),
                           ImageCancelledCheque_FilePath = Convert.ToString(dr["ImageCancelledCheque_FilePath"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }
        public List<ClsPrp_Project_SpecialBankAccountDetails> Display_Project_SpecialBankAccountDetails(Int64 ProjectRegistration_ID, Int64 Id)
        {

            connection();
            List<ClsPrp_Project_SpecialBankAccountDetails> ProjectFivelist1 = new List<ClsPrp_Project_SpecialBankAccountDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_SpecialBankAccountDetailsID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_SpecialBank_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_SpecialBankAccount_IndexID", Id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_SpecialBankAccountDetails
                       {
                           SpecialBankAccount_IndexID = Convert.ToInt64(dr["SpecialBankAccount_IndexID"]),
                           SpecialBankAccount_ID = Convert.ToInt64(dr["SpecialBankAccount_ID"]),
                           SpecialBankAccountRelated_ProjectRegistration_ID = Convert.ToInt64(dr["SpecialBankAccountRelated_ProjectRegistration_ID"]),
                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Branch_Name = Convert.ToString(dr["Branch_Name"]),
                           Bank_AccountNumber = Convert.ToString(dr["Bank_AccountNumber"]),
                           Bank_IFSC_Code = Convert.ToString(dr["Bank_IFSC_Code"]),
                           Bank_AddressLine1 = Convert.ToString(dr["Bank_AddressLine1"]),
                           Bank_AddressLine2 = Convert.ToString(dr["Bank_AddressLine2"]),
                           Bank_AddressStateCode = Convert.ToInt32(dr["Bank_AddressStateCode"]),
                           Bank_AddressDistrictCode = Convert.ToInt32(dr["Bank_AddressDistrictCode"]),
                           Bank_AddressPIN = Convert.ToString(dr["Bank_AddressPIN"]),
                           ImageCancelledCheque_FileName = Convert.ToString(dr["ImageCancelledCheque_FileName"]),
                           ImageCancelledCheque_FilePath = Convert.ToString(dr["ImageCancelledCheque_FilePath"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }

        public bool Delete_SpecialBankAccountDetails(Int64 ProjectSpecialBankAccountDetailsDetailsRelated_ProjectRegistration_ID, Int64 ProjectSpecialBankAccountDetailsDetails_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Project_SpecialBankAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_SpecialBankAccount_IndexID", ProjectSpecialBankAccountDetailsDetails_IndexID);
            cmd.Parameters.AddWithValue("p_SpecialBankAccountRelated_ProjectRegistration_ID", ProjectSpecialBankAccountDetailsDetailsRelated_ProjectRegistration_ID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Check_SpecialBankAccountNumber(string AccountNumber)
        {

            bool rval = false;
            Int32 rvalcount = 0;
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_Project_AlreadyExistAccNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_p_AccountNumber", AccountNumber);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                rvalcount = Convert.ToInt32(dr["p_CountUserName"]);
            }

            if (rvalcount > 0)
            {
                rval = true;
            }
            cmd.Dispose();
            con.Close();
            return rval;
        }
    }
}