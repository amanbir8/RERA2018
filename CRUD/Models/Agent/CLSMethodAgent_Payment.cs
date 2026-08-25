using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.Agent
{
    public class CLSMethodAgent_Payment
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        // **************** ADD Agent Fee Payment Detail *********************
        public bool AgentFeePaymentDetail(CLSprpAgent_Payment smodel,Int64 Agent_ID, string FileName, string FilePath)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_RERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_AgentPayment_TitleCode", smodel.AgentPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_AgentPayment_TitleName", smodel.AgentPayment_TitleName);
            cmd.Parameters.AddWithValue("p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_Payment_Mode", smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_Date_of_Payment_RegistrationFee", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FileName", FileName);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", "");// smodel.A_column);
            //  cmd.Parameters.AddWithValue("p_A_column", smodel.B_column);
            // cmd.Parameters.AddWithValue("p_B_column", smodel.C_column);
            // cmd.Parameters.AddWithValue("p_C_column", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            //cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");



            //cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);

            //cmd.Parameters.AddWithValue("p_Created_On", smodel.Created_On);

            //cmd.Parameters.AddWithValue("p_Modified_On", smodel.Modified_On);
            //cmd.Parameters.AddWithValue("p_Flag", 2);
            //cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        // **************** Update Agent Fee Payment Detail *********************
        public bool AgentUpdateFeePaymentDetail(CLSprpAgent_Payment smodel, Int64 Application_id, string FileName, string FilePath)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("update_RERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentPayment_ID", smodel.AgentPayment_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Application_id);
            cmd.Parameters.AddWithValue("p_AgentPayment_TitleCode", smodel.AgentPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_AgentPayment_TitleName", smodel.AgentPayment_TitleName);
            cmd.Parameters.AddWithValue("p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_Payment_Mode", smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_Date_of_Payment_RegistrationFee", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FileName", FileName);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FilePath", FilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", "");// smodel.A_column);
            //  cmd.Parameters.AddWithValue("p_A_column", smodel.B_column);
            // cmd.Parameters.AddWithValue("p_B_column", smodel.C_column);
            // cmd.Parameters.AddWithValue("p_C_column", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            //cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");


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
        //Display Agent Fee Payment Detail on basis of Agent Payment ID
        public List<CLSprpAgent_Payment> DisplayAgentDetail(Int64 Agent_ID) //, Int64 AgentPayment_ID
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayRERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("p_AgentPayment_ID", AgentPayment_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            connection();
            List<CLSprpAgent_Payment> list_indPro = new List<CLSprpAgent_Payment>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new CLSprpAgent_Payment
                    {
                        AgentPayment_IndexID = Convert.ToInt64(dr["AgentPayment_IndexID"]),
                        AgentPayment_ID = Convert.ToInt64(dr["AgentPayment_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                        AgentPayment_TitleName = Convert.ToString(dr["AgentPayment_TitleName"]),
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
                        //A_column = Convert.ToString(dr["A_column"]),
                        //B_column = Convert.ToString(dr["B_column"]),
                        //C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["CreatedOn"]),//  Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



        }

        public List<CLSprpAgent_Payment> DisplayAgentDetail(Int64 Agent_ID, Int64 AgentPayment_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayRERA_Agent_PaymentByPaymentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentPayment_ID", AgentPayment_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            connection();
            List<CLSprpAgent_Payment> list_indPro = new List<CLSprpAgent_Payment>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new CLSprpAgent_Payment
                    {
                        AgentPayment_IndexID = Convert.ToInt64(dr["AgentPayment_IndexID"]),
                        AgentPayment_ID = Convert.ToInt64(dr["AgentPayment_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                        AgentPayment_TitleName = Convert.ToString(dr["AgentPayment_TitleName"]),
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
                        //A_column = Convert.ToString(dr["A_column"]),
                        //B_column = Convert.ToString(dr["B_column"]),
                        //C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["CreatedOn"]),//  Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



        }              
        
        public bool Delete_AgentFeePayment(Int64 AgentPayment_IndexID, Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentPayment_ID", AgentPayment_IndexID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public Int32 Validate_AgentFeePayment(Int64 Agent_ID, Int32 Agent_Type, string UID, string RegistrationNumber, string stateName)
        {
            Int32 AppId = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_validate_tbl_rera_agent_payment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_Agent_Type", Agent_Type);
                cmd.Parameters.AddWithValue("p_User_ID", UID);
                cmd.Parameters.AddWithValue("p_Registration_Number", RegistrationNumber);
                cmd.Parameters.AddWithValue("p_Related_StateName", stateName);

                MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int32);
                AppPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(AppPar);

                int i = cmd.ExecuteNonQuery();
                AppId = Convert.ToInt32(AppPar.Value);
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                con.Close();
            }
            return AppId;
        }
    }
}