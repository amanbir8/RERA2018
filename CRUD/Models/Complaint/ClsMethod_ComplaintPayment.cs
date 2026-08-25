using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintPayment
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public bool Add_Complaint_Payment(ClsPrp_ComplaintPayment smodel, Int64 Complaint_ID, String Photo_Address, String ext)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintPayment_IndexID", smodel.ComplaintPayment_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_ID", smodel.ComplaintPayment_ID);

            cmd.Parameters.AddWithValue("p_ComplaintPaymentRelated_ComplaintRegistration_ID", smodel.ComplaintPaymentRelated_ComplaintRegistration_ID);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_TitleCode", smodel.ComplaintPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_TitleName", String.IsNullOrEmpty(smodel.ComplaintPayment_TitleName) ? "" : smodel.ComplaintPayment_TitleName);
            cmd.Parameters.AddWithValue("p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_Payment_Mode", String.IsNullOrEmpty(smodel.Payment_Mode) ? "" : smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_Date_of_Payment_RegistrationFee", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_Bank_Name", String.IsNullOrEmpty(smodel.Bank_Name) ? "" : smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", String.IsNullOrEmpty(smodel.Branch_Name) ? "" : smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);

            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FileName", String.IsNullOrEmpty(ext) ? "" : ext);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FilePath", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);
            cmd.Parameters.AddWithValue("p_F_column", String.IsNullOrEmpty(smodel.F_column) ? "" : smodel.F_column);
            cmd.Parameters.AddWithValue("p_G_column", String.IsNullOrEmpty(smodel.G_column) ? "" : smodel.G_column);
            cmd.Parameters.AddWithValue("p_H_column", String.IsNullOrEmpty(smodel.H_column) ? "" : smodel.H_column);
            cmd.Parameters.AddWithValue("p_I_column", String.IsNullOrEmpty(smodel.I_column) ? "" : smodel.I_column);
            cmd.Parameters.AddWithValue("p_J_column", String.IsNullOrEmpty(smodel.J_column) ? "" : smodel.J_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(smodel.CreatedBy) ? "" : smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(smodel.ModifyBy) ? "" : smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update_Complaint_Payment(ClsPrp_ComplaintPayment smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintPayment_IndexID", smodel.ComplaintPayment_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_ID", smodel.ComplaintPayment_ID);

            cmd.Parameters.AddWithValue("p_ComplaintPaymentRelated_ComplaintRegistration_ID", smodel.ComplaintPaymentRelated_ComplaintRegistration_ID);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_TitleCode", smodel.ComplaintPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_TitleName", String.IsNullOrEmpty(smodel.ComplaintPayment_TitleName) ? "" : smodel.ComplaintPayment_TitleName);
            cmd.Parameters.AddWithValue("p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_Payment_Mode", String.IsNullOrEmpty(smodel.Payment_Mode) ? "" : smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_Date_of_Payment_RegistrationFee", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_Bank_Name", String.IsNullOrEmpty(smodel.Bank_Name) ? "" : smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", String.IsNullOrEmpty(smodel.Branch_Name) ? "" : smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);

            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FileName", smodel.ImageDDorBankersCheque_FileName);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FilePath", smodel.ImageDDorBankersCheque_FilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);
            cmd.Parameters.AddWithValue("p_F_column", String.IsNullOrEmpty(smodel.F_column) ? "" : smodel.F_column);
            cmd.Parameters.AddWithValue("p_G_column", String.IsNullOrEmpty(smodel.G_column) ? "" : smodel.G_column);
            cmd.Parameters.AddWithValue("p_H_column", String.IsNullOrEmpty(smodel.H_column) ? "" : smodel.H_column);
            cmd.Parameters.AddWithValue("p_I_column", String.IsNullOrEmpty(smodel.I_column) ? "" : smodel.I_column);
            cmd.Parameters.AddWithValue("p_J_column", String.IsNullOrEmpty(smodel.J_column) ? "" : smodel.J_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(smodel.CreatedBy) ? "" : smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(smodel.ModifyBy) ? "" : smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
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
        public List<ClsPrp_ComplaintPayment> Display_Complaint_Payment(Int64 ComplaintRegistration_ID)
        {
            connection();
            List<ClsPrp_ComplaintPayment> ComplaintRegistration_list = new List<ClsPrp_ComplaintPayment>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Complaint_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintPaymentRelated_ComplaintRegistration_ID", ComplaintRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_ComplaintPayment
                       {
                           ComplaintPayment_IndexID = Convert.ToInt64(dr["ComplaintPayment_IndexID"]),
                           ComplaintPayment_ID = Convert.ToInt64(dr["ComplaintPayment_ID"]),
                           ComplaintPaymentRelated_ComplaintRegistration_ID = Convert.ToInt64(dr["ComplaintPaymentRelated_ComplaintRegistration_ID"]),
                           ComplaintPayment_TitleCode = Convert.ToInt32(dr["ComplaintPayment_TitleCode"]),
                           ComplaintPayment_TitleName = Convert.ToString(dr["ComplaintPayment_TitleName"]),
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
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),
                           F_column = Convert.ToString(dr["F_column"]),
                           G_column = Convert.ToString(dr["G_column"]),
                           H_column = Convert.ToString(dr["H_column"]),
                           I_column = Convert.ToString(dr["I_column"]),
                           J_column = Convert.ToString(dr["J_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ComplaintRegistration_list;
        }       
        
        public List<ClsPrp_ComplaintPayment> Display_Complaint_PaymentById(Int64 ComplaintRegistration_ID, Int64 ComplaintPayment_IndexID)
        {

            connection();
            List<ClsPrp_ComplaintPayment> ComplaintRegistration_list = new List<ClsPrp_ComplaintPayment>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Complaint_PaymentById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintPaymentRelated_ComplaintRegistration_ID", ComplaintRegistration_ID);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_IndexID", ComplaintPayment_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_ComplaintPayment
                       {
                           ComplaintPayment_IndexID = Convert.ToInt64(dr["ComplaintPayment_IndexID"]),
                           ComplaintPayment_ID = Convert.ToInt64(dr["ComplaintPayment_ID"]),
                           ComplaintPaymentRelated_ComplaintRegistration_ID = Convert.ToInt64(dr["ComplaintPaymentRelated_ComplaintRegistration_ID"]),
                           ComplaintPayment_TitleCode = Convert.ToInt32(dr["ComplaintPayment_TitleCode"]),
                           ComplaintPayment_TitleName = Convert.ToString(dr["ComplaintPayment_TitleName"]),
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
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),
                           F_column = Convert.ToString(dr["F_column"]),
                           G_column = Convert.ToString(dr["G_column"]),
                           H_column = Convert.ToString(dr["H_column"]),
                           I_column = Convert.ToString(dr["I_column"]),
                           J_column = Convert.ToString(dr["J_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ComplaintRegistration_list;
        }

        public bool Delete_Complaint_Payment(Int64 ComplaintRegistration_ID, Int64 ComplaintPayment_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ComplaintPaymentRelated_ComplaintRegistration_ID", ComplaintRegistration_ID);
            cmd.Parameters.AddWithValue("p_ComplaintPayment_IndexID", ComplaintPayment_IndexID);

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