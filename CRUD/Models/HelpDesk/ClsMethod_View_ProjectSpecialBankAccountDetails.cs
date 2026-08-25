using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_ProjectSpecialBankAccountDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> Display_Project_SpecialBankAccountDetails(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> ProjectFivelist1 = new List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_SpecialBankAccountDetailsForDesk", con);
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
                       new ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails
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

        public Int32 Update_LockUnLockHandler_Project_SpecialBankAccountDetails(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_specialbankaccountdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_SpecialbankaccountIndexID", IndexID);
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

        public List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> HistoryLogsACR_ProjectSpecialBankAccountDetails(Int64 Project_ID, Int64 Promoter_ID, Int32 Flag_ID, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> objList = new List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_SpecialBankAccountDetails_LogsACR", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_SpecialBank_Flag_ID", Flag_ID);
            cmd.Parameters.AddWithValue("p_UserRole", userRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                objList.Add(
                       new ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails
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

                           Account_FormDate = Convert.ToDateTime(dr["Account_FormDate"]),
                           Account_ToDate = Convert.ToDateTime(dr["Account_ToDate"]),
                       });
            }
            return objList;
        }

        public List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> Extract_AuthDesk_ProjectSpecialBankAccountDetails_ByID(string pSpBankAccNumber, string pBankIFSCcode, string pPatternMatchBankAccNumber, Int32 pSearchOptionFlag, string pUserRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails> objlist = new List<ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectSpecialBankAccNumberVerify", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            cmd.Parameters.AddWithValue("p_SpecialBankAccountNumber", pSpBankAccNumber);
            cmd.Parameters.AddWithValue("p_BankIFSCcode", pBankIFSCcode);
            cmd.Parameters.AddWithValue("p_PatternMatchBankAccNumber", pPatternMatchBankAccNumber);
            cmd.Parameters.AddWithValue("p_SearchOptionFlag", pSearchOptionFlag);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                objlist.Add(
                       new ClsPrp_AuthDesk_View_ProjectSpecialBankAccountDetails
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

                           Account_FormDate = Convert.ToDateTime(dr["Account_FormDate"]),
                           Account_ToDate = Convert.ToDateTime(dr["Account_ToDate"]),

                           prmProject_DiaryNumber = Convert.ToString(dr["prmProject_DiaryNumber"]),
                           prmRERA_RegistrationNumber = Convert.ToString(dr["prmRERA_RegistrationNumber"]),
                           prmProject_Name = Convert.ToString(dr["prmProject_Name"]),
                       });
            }
            return objlist;
        }
    }
}