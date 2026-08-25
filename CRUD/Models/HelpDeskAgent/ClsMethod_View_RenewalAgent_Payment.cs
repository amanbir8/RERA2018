using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_RenewalAgent_Payment
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
   
        public List<ClsPrp_AuthDesk_View_RenewalAgent_Payment> Display_AuthDesk_RenewalAgent_PaymentDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_Payment> list_indPro = new List<ClsPrp_AuthDesk_View_RenewalAgent_Payment>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Payment_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list_indPro.Add(
                        new ClsPrp_AuthDesk_View_RenewalAgent_Payment
                        {
                            RenewalAgent_FeePayment_IndexID = Convert.ToInt64(dr["RenewalAgent_FeePayment_IndexID"]),
                            RenewalAgent_FeePayment_ID = Convert.ToInt64(dr["RenewalAgent_FeePayment_ID"]),
                            Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                            Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                            Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                            Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                            Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                            Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                            Related_UserID = Convert.ToString(dr["Related_UserID"]),
                            Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                            Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                            Related_AgentPayment_ID = Convert.ToInt64(dr["Related_AgentPayment_ID"]),

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
                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            C_column = Convert.ToString(dr["C_column"]),

                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            IsLock = Convert.ToInt32(dr["IsLock"]),
                            IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                            IsConditional = Convert.ToInt32(dr["IsConditional"]),

                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),

                        });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return list_indPro;
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_PaymentIntegration> Display_RenewalAgent_ApplicationPaymentTransactions(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_RenewalAgent_PaymentIntegration> AgentApplication_List = new List<ClsPrp_AuthDesk_View_RenewalAgent_PaymentIntegration>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_PaymentGatewayDetails_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
                cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsPrp_AuthDesk_View_RenewalAgent_PaymentIntegration
                           {
                               PaymentRefNumberRenewalAgent_IndexID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_IndexID"]),
                               PaymentRefNumberRenewalAgent_ID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_ID"]),
                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                               Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                               Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                               Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),

                               RelatedAgent_Code = Convert.ToString(dr["RelatedAgent_Code"]),
                               RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               AgentType_IO = Convert.ToString(dr["AgentType_IO"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Agent_BriefSummary = Convert.ToString(dr["Agent_BriefSummary"]),
                               IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                               PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                               FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                               PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                               PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                               PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                               PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                               PG_Status = Convert.ToString(dr["PG_Status"]),
                               PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                               PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                               PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                               PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                               PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                               PG_City = Convert.ToString(dr["PG_City"]),
                               PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                               PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                               PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                               PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                               PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                               PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                               PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                               PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                               PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                               PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                               PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                               PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                               PG_State = Convert.ToString(dr["PG_State"]),
                               PG_Country = Convert.ToString(dr["PG_Country"]),
                               PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                               PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                               PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                               PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                               PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                               PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                               PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                               PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                               PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                               PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                               PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                               PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                               PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                               PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                               PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                               PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                               PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                               PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                               PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                               PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                               PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                               PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }

        public Int32 Update_LockUnLockHandler_RenewalAgent_PaymentDetail(Int64 AgentId, Int32 AgentTypeId, Int64 RnAgentId, Int32 RnAgentSeqId, Int32 RnAgentYrId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_renewalagent_paymentdetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RnAgentId);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RnAgentSeqId);
            cmd.Parameters.AddWithValue("p_RenewalAgent_YearID", RnAgentYrId);
            cmd.Parameters.AddWithValue("p_RenewalAgentIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

    }
}