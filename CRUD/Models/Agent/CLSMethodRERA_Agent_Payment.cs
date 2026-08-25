using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.Agent
{
    public class CLSMethodRERA_Agent_Payment
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["SQLConn"].ToString();
            con = new SqlConnection(constring);
        }
        // **************** ADD Agent Fee Payment Detail *********************
        public bool AgentFeePaymentDetail(CLSprpAgent_Payment smodel, string FileName, string FilePath)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Insert_RERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@Agent_ID", smodel.Agent_ID);
            cmd.Parameters.AddWithValue("@AgentPayment_TitleCode", smodel.AgentPayment_TitleCode);
            cmd.Parameters.AddWithValue("@AgentPayment_TitleName ", smodel.AgentPayment_TitleName);
            cmd.Parameters.AddWithValue("@Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("@Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("@Payment_Mode", smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("@Date_of_Payment_RegistrationFee ", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("@Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("@Bank_Name", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("@Branch_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("@DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("@DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("@ImageDDorBankersCheque_FileName", FileName);
            cmd.Parameters.AddWithValue("@ImageDDorBankersCheque_FilePath", FilePath);
            cmd.Parameters.AddWithValue("@Remarks_IfAny", "");// smodel.A_column);
            //  cmd.Parameters.AddWithValue("@A_column", smodel.B_column);
            // cmd.Parameters.AddWithValue("@B_column", smodel.C_column);
            // cmd.Parameters.AddWithValue("@C_column", smodel.IsActive);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            cmd.Parameters.AddWithValue("@IsDraft", 0);
            cmd.Parameters.AddWithValue("@CreatedBy", "Created_By");
            //cmd.Parameters.AddWithValue("@CreatedOn ", smodel.ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyBy", "Modify_By");


            
            //cmd.Parameters.AddWithValue("@IsActive", smodel.IsActive);

            //cmd.Parameters.AddWithValue("@Created_On", smodel.Created_On);

            //cmd.Parameters.AddWithValue("@Modified_On", smodel.Modified_On);
            //cmd.Parameters.AddWithValue("@Flag", 2);
            //cmd.Parameters.AddWithValue("@Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("@Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("@Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("@Extra4", smodel.Extra4);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        // **************** Update Agent Fee Payment Detail *********************
        public bool AgentUpdateFeePaymentDetail(CLSprpAgent_Payment smodel, string FileName, string FilePath)
        {
            connection();
            SqlCommand cmd = new SqlCommand("update_RERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AgentPayment_ID", smodel.AgentPayment_ID);
            cmd.Parameters.AddWithValue("@Agent_ID", smodel.AgentPayment_TitleCode);
            cmd.Parameters.AddWithValue("@AgentPayment_TitleCode", smodel.AgentPayment_TitleName);
            cmd.Parameters.AddWithValue("@AgentPayment_TitleName ", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("@Registration_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("@Other_Fee", smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("@Payment_Mode", smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("@Date_of_Payment_RegistrationFee ", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("@Bank_Charges", smodel.Bank_Name);
            cmd.Parameters.AddWithValue("@Bank_Name", smodel.Branch_Name);
            cmd.Parameters.AddWithValue("@Branch_Name", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("@DD_BankersCheque_Number", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("@DD_BankersCheque_Amount", smodel.ImageDDorBankersCheque_FileName);
            cmd.Parameters.AddWithValue("@ImageDDorBankersCheque_FileName", FileName);
            cmd.Parameters.AddWithValue("@ImageDDorBankersCheque_FilePath", FilePath);
            cmd.Parameters.AddWithValue("@Remarks_IfAny", "");//smodel.A_column);
            //  cmd.Parameters.AddWithValue("@A_column", smodel.B_column);
            // cmd.Parameters.AddWithValue("@B_column", smodel.C_column);
            // cmd.Parameters.AddWithValue("@C_column", smodel.IsActive);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            cmd.Parameters.AddWithValue("@IsDraft", 0);
            cmd.Parameters.AddWithValue("@CreatedBy", "Created_By");
            //cmd.Parameters.AddWithValue("@CreatedOn ", smodel.ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyBy", "Modify_By");



            //cmd.Parameters.AddWithValue("@IsActive", smodel.IsActive);

            //cmd.Parameters.AddWithValue("@Created_On", smodel.Created_On);

            //cmd.Parameters.AddWithValue("@Modified_On", smodel.Modified_On);
            //cmd.Parameters.AddWithValue("@Flag", 2);
            //cmd.Parameters.AddWithValue("@Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("@Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("@Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("@Extra4", smodel.Extra4);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        //Display Agent Fee Payment Detail on basis of Agent Payment ID
        public List<CLSprpAgent_Payment> DisplayAgentDetail(Int64 AgentPayment_ID)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DisplayRERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AgentPayment_ID", AgentPayment_ID);



            connection();
            List<CLSprpAgent_Payment> list_indPro = new List<CLSprpAgent_Payment>();


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new CLSprpAgent_Payment
                    {
                        AgentPayment_ID = Convert.ToInt64(dr["AgentPayment_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                        AgentPayment_TitleName = Convert.ToString(dr["AgentPayment_TitleName "]),
                        Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                        Other_Fee = Convert.ToInt32(dr["Other_Fee"]),
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
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



        }


    }
}