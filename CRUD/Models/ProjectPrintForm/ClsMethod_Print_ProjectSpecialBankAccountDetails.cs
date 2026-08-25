using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ProjectPrint
{
    public class ClsMethod_Print_ProjectSpecialBankAccountDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails> Display_Project_SpecialBankAccountDetails(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_SpecialBankAccountDetails_ForPrint", con);
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
                       new ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails
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
                           Bank_AddressStateCode = Convert.ToString(dr["Bank_AddressStateCode"]),
                           Bank_AddressDistrictCode = Convert.ToString(dr["Bank_AddressDistrictCode"]),
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
    }
}