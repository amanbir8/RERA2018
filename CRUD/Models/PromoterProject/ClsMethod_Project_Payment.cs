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
    public class ClsMethod_Project_Payment
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_Payment(ClsPrp_Project_Payment smodel, Int64 Project_id, String Photo_Address, String ext, string UserName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_ProjectPayment_IndexID", smodel.ProjectPayment_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectPayment_ID", smodel.ProjectPayment_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectPaymentRelated_ProjectRegistration_ID", smodel.ProjectPaymentRelated_ProjectRegistration_ID);// smodel.ProjectPaymentRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectPayment_TitleCode", smodel.ProjectPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_p_ProjectPayment_TitleName", smodel.ProjectPayment_TitleName);
            cmd.Parameters.AddWithValue("p_p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_p_Payment_Mode", smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_p_Date_of_Payment_RegistrationFee", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("p_p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_p_Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_p_Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("p_p_ImageDDorBankersCheque_FileName",  String.IsNullOrEmpty(ext) ? "" : ext); //smodel.ImageDDorBankersCheque_FileName);
            cmd.Parameters.AddWithValue("p_p_ImageDDorBankersCheque_FilePath", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", ""); //smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column); //smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", ""); //smodel.B_column);

            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", String.IsNullOrEmpty(UID) ? "" : UID);


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
        public bool Update_Project_Payment(ClsPrp_Project_Payment smodel, string UserName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectPayment_IndexID", smodel.ProjectPayment_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectPayment_ID", smodel.ProjectPayment_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectPaymentRelated_ProjectRegistration_ID", smodel.ProjectPaymentRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectPayment_TitleCode", smodel.ProjectPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_p_ProjectPayment_TitleName", smodel.ProjectPayment_TitleName);
            cmd.Parameters.AddWithValue("p_p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_p_Payment_Mode", smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_p_Date_of_Payment_RegistrationFee", smodel.Date_of_Payment_RegistrationFee);

            cmd.Parameters.AddWithValue("p_p_Bank_Charges", smodel.Bank_Charges);

            cmd.Parameters.AddWithValue("p_p_Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_p_Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("p_p_ImageDDorBankersCheque_FileName", smodel.ImageDDorBankersCheque_FileName);
            cmd.Parameters.AddWithValue("p_p_ImageDDorBankersCheque_FilePath", smodel.ImageDDorBankersCheque_FilePath);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");
            cmd.Parameters.AddWithValue("p_p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", "");
            // cmd.Parameters.AddWithValue("p_p_C_column", "");
            //cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            // cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", String.IsNullOrEmpty(UID) ? "" : UID);
            // cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);


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
        public DateTime datefun(string valuedate)
        {
            DateTime defaultdate = new DateTime(1919, 1, 1);
            if (valuedate != DBNull.Value.ToString())
            {
                IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
                String datetime = valuedate.Trim();
                DateTime dt = DateTime.Parse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                return dt;
            }
            else
                return defaultdate;
        }
        public List<ClsPrp_Project_Payment> Display_Project_Payment(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_Payment> ProjectFivelist1 = new List<ClsPrp_Project_Payment>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectPayment_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_Payment
                       {
                           ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                           ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                           ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),
                           Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                           Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                           Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                           Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                           Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Branch_Name = Convert.ToString(dr["Branch_Name"]),
                           DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                           DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                           ImageDDorBankersCheque_FileName = Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                           ImageDDorBankersCheque_FilePath = Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),
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
        // p_ProjectPayment_ProjectRegistration_ID bigint,

        public List<ClsPrp_Project_Payment> Display_Project_PaymentById(Int64 ProjectRegistration_ID,Int64 ProjectPayment_IndexID)
        {

            connection();
            List<ClsPrp_Project_Payment> ProjectFivelist1 = new List<ClsPrp_Project_Payment>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_PaymentById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectPayment_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectPayment_IndexID", ProjectPayment_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_Payment
                       {
                           ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                           ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                           ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),
                           Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                           Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                           Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                           Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                           Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Branch_Name = Convert.ToString(dr["Branch_Name"]),
                           DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                           DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                           ImageDDorBankersCheque_FileName = Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                           ImageDDorBankersCheque_FilePath = Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),
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

        public bool Delete_Project_Payment(Int64 ProjectRegistration_ID, Int64 ProjectPayment_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Project_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectPayment_IndexID", ProjectPayment_IndexID);
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