using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.AgentRenewal
{
    public class ClsMethod_AgentRenewal_FeePayments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        //---Add/Update - Fee Payment
        //Add Agent-Renewal 
        public bool Add_AgentRenewal_FeePaymentDetail(Clsprp_AgentRenewal_Payment smodel, Int64 AgentID, Int64 RnAgentID, Int32 RnSeqID, Int32 RnYr, string FileName, string FilePath, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_AgentRenewal_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_FeePayment_IndexID", smodel.RenewalAgent_FeePayment_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_FeePayment_ID", smodel.RenewalAgent_FeePayment_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", RnAgentID);
            cmd.Parameters.AddWithValue("p_Related_RenewalOrderSequence", RnSeqID);
            cmd.Parameters.AddWithValue("p_Related_RelatedRenewalAgent_Year", RnYr);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", AgentID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", smodel.Related_Agent_Type);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);

            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Related_AgentPayment_ID", smodel.Related_AgentPayment_ID);

            cmd.Parameters.AddWithValue("p_AgentPayment_TitleCode", smodel.AgentPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_AgentPayment_TitleName", String.IsNullOrEmpty(smodel.AgentPayment_TitleName) ? string.Empty : smodel.AgentPayment_TitleName);
            cmd.Parameters.AddWithValue("p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_Payment_Mode", String.IsNullOrEmpty(smodel.Payment_Mode) ? string.Empty : smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_Date_of_Payment_RegistrationFee", (smodel.Date_of_Payment_RegistrationFee == null) ? DateTime.MinValue : smodel.Date_of_Payment_RegistrationFee); 
            cmd.Parameters.AddWithValue("p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_Bank_Name", String.IsNullOrEmpty(smodel.Bank_Name) ? string.Empty : smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", String.IsNullOrEmpty(smodel.Branch_Name) ? string.Empty : smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("p_FeePayment_ByFeeCalculator_Amount", smodel.FeePayment_ByFeeCalculator_Amount);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", smodel.IsActiveProvider);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditional", smodel.IsConditional);

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        //Update Agent-Renewal
        public bool Update_AgentRenewal_FeePaymentDetail(Clsprp_AgentRenewal_Payment smodel, Int64 AgentID, Int64 RnAgentID, Int32 RnSeqID, Int32 RnYr, string FileName, string FilePath, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_AgentRenewal_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RenewalAgent_FeePayment_IndexID", smodel.RenewalAgent_FeePayment_IndexID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_FeePayment_ID", smodel.RenewalAgent_FeePayment_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", RnAgentID);
            cmd.Parameters.AddWithValue("p_Related_RenewalOrderSequence", RnSeqID);
            cmd.Parameters.AddWithValue("p_Related_RelatedRenewalAgent_Year", RnYr);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", AgentID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", smodel.Related_Agent_Type);
            cmd.Parameters.AddWithValue("p_Related_UserID", UID);

            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Related_AgentPayment_ID", smodel.Related_AgentPayment_ID);

            cmd.Parameters.AddWithValue("p_AgentPayment_TitleCode", smodel.AgentPayment_TitleCode);
            cmd.Parameters.AddWithValue("p_AgentPayment_TitleName", String.IsNullOrEmpty(smodel.AgentPayment_TitleName) ? string.Empty : smodel.AgentPayment_TitleName);
            cmd.Parameters.AddWithValue("p_Registration_Fee", smodel.Registration_Fee);
            cmd.Parameters.AddWithValue("p_Other_Fee", smodel.Other_Fee);
            cmd.Parameters.AddWithValue("p_Payment_Mode", String.IsNullOrEmpty(smodel.Payment_Mode) ? string.Empty : smodel.Payment_Mode);
            cmd.Parameters.AddWithValue("p_Date_of_Payment_RegistrationFee", (smodel.Date_of_Payment_RegistrationFee == null) ? DateTime.MinValue : smodel.Date_of_Payment_RegistrationFee);
            cmd.Parameters.AddWithValue("p_Bank_Charges", smodel.Bank_Charges);
            cmd.Parameters.AddWithValue("p_Bank_Name", String.IsNullOrEmpty(smodel.Bank_Name) ? string.Empty : smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", String.IsNullOrEmpty(smodel.Branch_Name) ? string.Empty : smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Number", smodel.DD_BankersCheque_Number);
            cmd.Parameters.AddWithValue("p_DD_BankersCheque_Amount", smodel.DD_BankersCheque_Amount);
            cmd.Parameters.AddWithValue("p_FeePayment_ByFeeCalculator_Amount", smodel.FeePayment_ByFeeCalculator_Amount);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_ImageDDorBankersCheque_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", smodel.IsActiveProvider);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditional", smodel.IsConditional);

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        //---Display Agent-Renewal - Fee Payment
        public List<Clsprp_AgentRenewal_Payment> Display_AgentRenewal_FeePaymentDetail(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_Payment> ARlist = new List<Clsprp_AgentRenewal_Payment>();
            
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ARlist.Add(
                    new Clsprp_AgentRenewal_Payment
                    {
                        RenewalAgent_FeePayment_IndexID = Convert.ToInt64(dr["RenewalAgentPayment_IndexID"]),
                        RenewalAgent_FeePayment_ID = Convert.ToInt64(dr["RenewalAgentPayment_ID"]),
                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_AgentPayment_ID = Convert.ToInt64(0),

                        AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                        AgentPayment_TitleName = String.IsNullOrEmpty(Convert.ToString(dr["AgentPayment_TitleName"])) ? string.Empty : Convert.ToString(dr["AgentPayment_TitleName"]),
                        Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                        Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                        Payment_Mode = String.IsNullOrEmpty(Convert.ToString(dr["Payment_Mode"])) ? string.Empty : Convert.ToString(dr["Payment_Mode"]),
                        Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                        Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                        Bank_Name = String.IsNullOrEmpty(Convert.ToString(dr["Bank_Name"])) ? string.Empty : Convert.ToString(dr["Bank_Name"]),
                        Branch_Name = String.IsNullOrEmpty(Convert.ToString(dr["Branch_Name"])) ? string.Empty : Convert.ToString(dr["Branch_Name"]),
                        DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                        DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                        FeePayment_ByFeeCalculator_Amount = Convert.ToDecimal(dr["FeePayment_ByFeeCalculator_Amount"]),
                        ImageDDorBankersCheque_FileName = String.IsNullOrEmpty(Convert.ToString(dr["ImageDDorBankersCheque_FileName"])) ? string.Empty : Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                        ImageDDorBankersCheque_FilePath = String.IsNullOrEmpty(Convert.ToString(dr["ImageDDorBankersCheque_FilePath"])) ? string.Empty : Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),

                        Remarks_IfAny = String.IsNullOrEmpty(Convert.ToString(dr["Remarks_IfAny"])) ? string.Empty : Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = String.IsNullOrEmpty(Convert.ToString(dr["A_column"])) ? string.Empty : Convert.ToString(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? string.Empty : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? string.Empty : Convert.ToString(dr["C_column"]),

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
            return ARlist;
        }

        public List<Clsprp_AgentRenewal_Payment> AgentRenewal_ExtractRecord_FeePaymentByID(Int64 IndexID, Int64 ExtractID, Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_Year, Int32 RenewalAgent_SequenceID, string UserID)
        {
            connection();
            List<Clsprp_AgentRenewal_Payment> ARlist = new List<Clsprp_AgentRenewal_Payment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Payment_ExtractByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Related_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_Related_ExtractID", ExtractID);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ARlist.Add(
                    new Clsprp_AgentRenewal_Payment
                    {
                        RenewalAgent_FeePayment_IndexID = Convert.ToInt64(dr["RenewalAgentPayment_IndexID"]),
                        RenewalAgent_FeePayment_ID = Convert.ToInt64(dr["RenewalAgentPayment_ID"]),
                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? string.Empty : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? string.Empty : Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? string.Empty : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_AgentPayment_ID = Convert.ToInt64(0),

                        AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                        AgentPayment_TitleName = String.IsNullOrEmpty(Convert.ToString(dr["AgentPayment_TitleName"])) ? string.Empty : Convert.ToString(dr["AgentPayment_TitleName"]),
                        Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                        Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                        Payment_Mode = String.IsNullOrEmpty(Convert.ToString(dr["Payment_Mode"])) ? string.Empty : Convert.ToString(dr["Payment_Mode"]),
                        Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                        Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                        Bank_Name = String.IsNullOrEmpty(Convert.ToString(dr["Bank_Name"])) ? string.Empty : Convert.ToString(dr["Bank_Name"]),
                        Branch_Name = String.IsNullOrEmpty(Convert.ToString(dr["Branch_Name"])) ? string.Empty : Convert.ToString(dr["Branch_Name"]),
                        DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                        DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                        FeePayment_ByFeeCalculator_Amount = Convert.ToDecimal(dr["FeePayment_ByFeeCalculator_Amount"]),
                        ImageDDorBankersCheque_FileName = String.IsNullOrEmpty(Convert.ToString(dr["ImageDDorBankersCheque_FileName"])) ? string.Empty : Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                        ImageDDorBankersCheque_FilePath = String.IsNullOrEmpty(Convert.ToString(dr["ImageDDorBankersCheque_FilePath"])) ? string.Empty : Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),

                        Remarks_IfAny = String.IsNullOrEmpty(Convert.ToString(dr["Remarks_IfAny"])) ? string.Empty : Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = String.IsNullOrEmpty(Convert.ToString(dr["A_column"])) ? string.Empty : Convert.ToString(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? string.Empty : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? string.Empty : Convert.ToString(dr["C_column"]),

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
            return ARlist;
        }            
        
        //---Delete Agent-Renewal
        public bool Delete_AgentRenewal_FeePaymentByID(Int64 mIndexID, Int64 mExtractID, Int64 mRenewalAgentID, Int64 mAgentID, string mUserID)
        {
            Int64 User_IndexID = 0;
            Int64 User_ExtractID = 0;
            Int64 User_RenewalAgentID = 0;
            Int64 User_AgentID = 0;
            Int32 i = 0;
            string UserID = string.Empty;

            try
            {
                User_IndexID = mIndexID;
                User_ExtractID = mExtractID;
                User_RenewalAgentID = mRenewalAgentID;
                User_AgentID = mAgentID;
                UserID = mUserID;

                connection();
                MySqlCommand cmd = new MySqlCommand("Delete_Rera_AgentRenewal_Payment_ByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Agent_Index_ID", User_IndexID);
                cmd.Parameters.AddWithValue("p_Agent_Extract_ID", User_ExtractID);
                cmd.Parameters.AddWithValue("p_Agent_RenewalAgent_ID", User_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Agent_ID", User_AgentID);
                cmd.Parameters.AddWithValue("p_Agent_User_ID", UserID);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}