using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsMethod_View_CP_ProjectPUCspecialbankaccount
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public Tuple<bool, string> Add_ProjectPUC_SpecialBankAccount(ClsPrp_ControlPanel_View_ProjectPUCSpecialBankAccount smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string prmFileName, string prmFilePath, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_SpecialBankAccountAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_SpecialBankAccount_IndexID", (smodel.ProjectPUC_SpecialBankAccount_IndexID == 0) ? 0 : smodel.ProjectPUC_SpecialBankAccount_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_SpecialBankAccount_ID", (smodel.ProjectPUC_SpecialBankAccount_ID == 0) ? 0 : smodel.ProjectPUC_SpecialBankAccount_ID);

            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", uPromoter_ID);
            cmd.Parameters.AddWithValue("p_Related_Project_ID", uProject_ID);
            cmd.Parameters.AddWithValue("p_RelatedApplicationPUC_ID", uPUC_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);
            cmd.Parameters.AddWithValue("p_PUC_DiaryNumber", uPucDNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Name", String.IsNullOrEmpty(smodel.PUC_ReferencePUC_Name) ? string.Empty : smodel.PUC_ReferencePUC_Name);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Date", smodel.PUC_ReferencePUC_Date.HasValue ? smodel.PUC_ReferencePUC_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryName", String.IsNullOrEmpty(smodel.PUC_RequestCategoryName) ? string.Empty : smodel.PUC_RequestCategoryName);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryID", uCategoryPUC_ID);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);
            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", String.IsNullOrEmpty(smodel.ProjectDiaryNumber) ? string.Empty : smodel.ProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtensionRegdDiaryNumber", String.IsNullOrEmpty(smodel.ExtensionRegdDiaryNumber) ? string.Empty : smodel.ExtensionRegdDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);

            //Properties : Special Bank Account
            cmd.Parameters.AddWithValue("p_SpecialBankAccountAdditional_IndexID", (smodel.SpecialBankAccountAdditional_IndexID == 0) ? 0 : smodel.SpecialBankAccountAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_SpecialBankAccountAdditional_ID", (smodel.SpecialBankAccountAdditional_ID == 0) ? 0 : smodel.SpecialBankAccountAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties [Start] : Special Bank Account
            cmd.Parameters.AddWithValue("p_SpecialBankAccount_IndexID", (smodel.SpecialBankAccount_IndexID == 0) ? 0 : smodel.SpecialBankAccount_IndexID);
            cmd.Parameters.AddWithValue("p_SpecialBankAccount_ID", (smodel.SpecialBankAccount_ID == 0) ? 0 : smodel.SpecialBankAccount_ID);

            cmd.Parameters.AddWithValue("p_SpecialBankAccountRelated_ProjectRegistration_ID", (smodel.Related_Project_ID == 0) ? 0 : smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_Bank_Name", String.IsNullOrEmpty(smodel.Bank_Name) ? string.Empty : smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", String.IsNullOrEmpty(smodel.Branch_Name) ? string.Empty : smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_Bank_AccountNumber", String.IsNullOrEmpty(smodel.Bank_AccountNumber) ? string.Empty : smodel.Bank_AccountNumber);
            cmd.Parameters.AddWithValue("p_Bank_IFSC_Code", String.IsNullOrEmpty(smodel.Bank_IFSC_Code) ? string.Empty : smodel.Bank_IFSC_Code);
            cmd.Parameters.AddWithValue("p_Bank_AddressLine1", String.IsNullOrEmpty(smodel.Bank_AddressLine1) ? string.Empty : smodel.Bank_AddressLine1);
            cmd.Parameters.AddWithValue("p_Bank_AddressLine2", String.IsNullOrEmpty(smodel.Bank_AddressLine2) ? string.Empty : smodel.Bank_AddressLine2);
            cmd.Parameters.AddWithValue("p_Bank_AddressStateCode", (smodel.Bank_AddressStateCode == 0) ? 0 : smodel.Bank_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Bank_AddressDistrictCode", (smodel.Bank_AddressDistrictCode == 0) ? 0 : smodel.Bank_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Bank_AddressPIN", String.IsNullOrEmpty(smodel.Bank_AddressPIN) ? string.Empty : smodel.Bank_AddressPIN);
            cmd.Parameters.AddWithValue("p_ImageCancelledCheque_FileName", prmFileName);
            cmd.Parameters.AddWithValue("p_ImageCancelledCheque_FilePath", prmFilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);                       
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();            
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);            
        }

        public Tuple<bool, string> Update_ProjectPUC_SpecialBankAccount(ClsPrp_ControlPanel_View_ProjectPUCSpecialBankAccount smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string prmFileName, string prmFilePath, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_SpecialBankAccountAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_SpecialBankAccount_IndexID", (smodel.ProjectPUC_SpecialBankAccount_IndexID == 0) ? 0 : smodel.ProjectPUC_SpecialBankAccount_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_SpecialBankAccount_ID", (smodel.ProjectPUC_SpecialBankAccount_ID == 0) ? 0 : smodel.ProjectPUC_SpecialBankAccount_ID);

            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", uPromoter_ID);
            cmd.Parameters.AddWithValue("p_Related_Project_ID", uProject_ID);
            cmd.Parameters.AddWithValue("p_RelatedApplicationPUC_ID", uPUC_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);
            cmd.Parameters.AddWithValue("p_PUC_DiaryNumber", uPucDNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Name", String.IsNullOrEmpty(smodel.PUC_ReferencePUC_Name) ? string.Empty : smodel.PUC_ReferencePUC_Name);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Date", smodel.PUC_ReferencePUC_Date.HasValue ? smodel.PUC_ReferencePUC_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryName", String.IsNullOrEmpty(smodel.PUC_RequestCategoryName) ? string.Empty : smodel.PUC_RequestCategoryName);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryID", uCategoryPUC_ID);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);
            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", String.IsNullOrEmpty(smodel.ProjectDiaryNumber) ? string.Empty : smodel.ProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtensionRegdDiaryNumber", String.IsNullOrEmpty(smodel.ExtensionRegdDiaryNumber) ? string.Empty : smodel.ExtensionRegdDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);

            //Properties : Special Bank Account
            cmd.Parameters.AddWithValue("p_SpecialBankAccountAdditional_IndexID", (smodel.SpecialBankAccountAdditional_IndexID == 0) ? 0 : smodel.SpecialBankAccountAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_SpecialBankAccountAdditional_ID", (smodel.SpecialBankAccountAdditional_ID == 0) ? 0 : smodel.SpecialBankAccountAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties [Start] : Special Bank Account
            cmd.Parameters.AddWithValue("p_SpecialBankAccount_IndexID", (smodel.SpecialBankAccount_IndexID == 0) ? 0 : smodel.SpecialBankAccount_IndexID);
            cmd.Parameters.AddWithValue("p_SpecialBankAccount_ID", (smodel.SpecialBankAccount_ID == 0) ? 0 : smodel.SpecialBankAccount_ID);

            cmd.Parameters.AddWithValue("p_SpecialBankAccountRelated_ProjectRegistration_ID", (smodel.Related_Project_ID == 0) ? 0 : smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_Bank_Name", String.IsNullOrEmpty(smodel.Bank_Name) ? string.Empty : smodel.Bank_Name);
            cmd.Parameters.AddWithValue("p_Branch_Name", String.IsNullOrEmpty(smodel.Branch_Name) ? string.Empty : smodel.Branch_Name);
            cmd.Parameters.AddWithValue("p_Bank_AccountNumber", String.IsNullOrEmpty(smodel.Bank_AccountNumber) ? string.Empty : smodel.Bank_AccountNumber);
            cmd.Parameters.AddWithValue("p_Bank_IFSC_Code", String.IsNullOrEmpty(smodel.Bank_IFSC_Code) ? string.Empty : smodel.Bank_IFSC_Code);
            cmd.Parameters.AddWithValue("p_Bank_AddressLine1", String.IsNullOrEmpty(smodel.Bank_AddressLine1) ? string.Empty : smodel.Bank_AddressLine1);
            cmd.Parameters.AddWithValue("p_Bank_AddressLine2", String.IsNullOrEmpty(smodel.Bank_AddressLine2) ? string.Empty : smodel.Bank_AddressLine2);
            cmd.Parameters.AddWithValue("p_Bank_AddressStateCode", (smodel.Bank_AddressStateCode == 0) ? 0 : smodel.Bank_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Bank_AddressDistrictCode", (smodel.Bank_AddressDistrictCode == 0) ? 0 : smodel.Bank_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Bank_AddressPIN", String.IsNullOrEmpty(smodel.Bank_AddressPIN) ? string.Empty : smodel.Bank_AddressPIN);
            cmd.Parameters.AddWithValue("p_ImageCancelledCheque_FileName", prmFileName);
            cmd.Parameters.AddWithValue("p_ImageCancelledCheque_FilePath", prmFilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();            
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }
    }
}