using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace CRUD.Models.ClassComplaintPayment
{
    public class ClsMethod_online_payment
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        // Add payment  Detail
        public bool AddOnlinePaymentDetail(clsprp_onlinepayment smodel)//, Int64 Promoter_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_Onlinepayment", con);
            cmd.CommandType = CommandType.StoredProcedure;

           // cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_UserID", smodel.p_UserID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", smodel.p_Promoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", smodel.p_Project_ID);
            cmd.Parameters.AddWithValue("p_projectname", smodel.p_projectname); 
            cmd.Parameters.AddWithValue("p_Extra1", smodel.p_Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", smodel.p_Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", smodel.p_Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", smodel.p_Extra4);
            cmd.Parameters.AddWithValue("p_Extra5", smodel.p_Extra5);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", smodel.p_p_Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "ModifyBy");
              
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// update payment  Detail   
         
        public void UpdateAddOnlinePaymentDetail(clsprp_onlinepayment smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Onlinepayment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_UserID", smodel.p_UserID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", smodel.p_Promoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", smodel.p_Project_ID);
            cmd.Parameters.AddWithValue("p_projectname", smodel.p_projectname);
            cmd.Parameters.AddWithValue("p_Extra1", smodel.p_Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", smodel.p_Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", smodel.p_Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", smodel.p_Extra4);
            cmd.Parameters.AddWithValue("p_Extra5", smodel.p_Extra5);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", smodel.p_p_Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "ModifyBy");

            MySqlParameter RetParam = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            RetParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RetParam);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int IntReturn = Convert.ToInt32(RetParam.Value);
            con.Close();

            //if (i >= 1)
            //    return true;
            //else
            //    return false;
        }
        
       
    }
    }