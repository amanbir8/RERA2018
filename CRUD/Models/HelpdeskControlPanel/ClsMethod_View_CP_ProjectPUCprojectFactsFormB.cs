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
    public class ClsMethod_View_CP_ProjectPUCprojectFactsFormB
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        //Form-B Dates
        public Tuple<bool, string> Add_ProjectPUC_ProjectFormBdatesDetails(ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_ProjectFormBdatesAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFormBdates_IndexID", (smodel.ProjectPUC_AuthorisedPrjPerson_IndexID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFormBdates_ID", (smodel.ProjectPUC_AuthorisedPrjPerson_ID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_ID);

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

            //Properties : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);            
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);
                        
            cmd.Parameters.AddWithValue("p_Project_Status", String.IsNullOrEmpty(smodel.Project_Status) ? string.Empty : smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_ProjectStart_Date", smodel.ProjectStart_Date.HasValue ? smodel.ProjectStart_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_ProposedDate", smodel.ProjectCompletion_ProposedDate.HasValue ? smodel.ProjectCompletion_ProposedDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_OriginalDate", smodel.ProjectCompletion_OriginalDate.HasValue ? smodel.ProjectCompletion_OriginalDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationProvided_Duration", String.IsNullOrEmpty(smodel.ProjectRegistrationProvided_Duration) ? string.Empty : smodel.ProjectRegistrationProvided_Duration);
            cmd.Parameters.AddWithValue("p_ProjectDelayReason_IfAny", String.IsNullOrEmpty(smodel.ProjectDelayReason_IfAny) ? string.Empty : smodel.ProjectDelayReason_IfAny);
            
            cmd.Parameters.AddWithValue("p_A_column", (smodel.A_column == 0) ? 0 : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);
            
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

        public Tuple<bool, string> Update_ProjectPUC_ProjectFormBdatesDetails(ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_ProjectFormBdatesAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFormBdates_IndexID", (smodel.ProjectPUC_AuthorisedPrjPerson_IndexID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFormBdates_ID", (smodel.ProjectPUC_AuthorisedPrjPerson_ID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_ID);

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

            //Properties : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);

            cmd.Parameters.AddWithValue("p_Project_Status", String.IsNullOrEmpty(smodel.Project_Status) ? string.Empty : smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_ProjectStart_Date", smodel.ProjectStart_Date.HasValue ? smodel.ProjectStart_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_ProposedDate", smodel.ProjectCompletion_ProposedDate.HasValue ? smodel.ProjectCompletion_ProposedDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_OriginalDate", smodel.ProjectCompletion_OriginalDate.HasValue ? smodel.ProjectCompletion_OriginalDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationProvided_Duration", String.IsNullOrEmpty(smodel.ProjectRegistrationProvided_Duration) ? string.Empty : smodel.ProjectRegistrationProvided_Duration);
            cmd.Parameters.AddWithValue("p_ProjectDelayReason_IfAny", String.IsNullOrEmpty(smodel.ProjectDelayReason_IfAny) ? string.Empty : smodel.ProjectDelayReason_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.A_column == 0) ? 0 : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

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

        //Project Facts
        public Tuple<bool, string> Add_ProjectPUC_ProjectFactsDetails(ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_ProjectFactsAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFacts_IndexID", (smodel.ProjectPUC_AuthorisedPrjPerson_IndexID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFacts_ID", (smodel.ProjectPUC_AuthorisedPrjPerson_ID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_ID);

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

            //Properties : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);

            cmd.Parameters.AddWithValue("p_Project_Status", String.IsNullOrEmpty(smodel.Project_Status) ? string.Empty : smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_ProjectStart_Date", smodel.ProjectStart_Date.HasValue ? smodel.ProjectStart_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_ProposedDate", smodel.ProjectCompletion_ProposedDate.HasValue ? smodel.ProjectCompletion_ProposedDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_OriginalDate", smodel.ProjectCompletion_OriginalDate.HasValue ? smodel.ProjectCompletion_OriginalDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationProvided_Duration", String.IsNullOrEmpty(smodel.ProjectRegistrationProvided_Duration) ? string.Empty : smodel.ProjectRegistrationProvided_Duration);
            cmd.Parameters.AddWithValue("p_ProjectDelayReason_IfAny", String.IsNullOrEmpty(smodel.ProjectDelayReason_IfAny) ? string.Empty : smodel.ProjectDelayReason_IfAny);
            
            cmd.Parameters.AddWithValue("p_IsProForma_AOS_RERAformat_AnnexureA", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_AnnexureA) ? string.Empty : smodel.IsProForma_AOS_RERAformat_AnnexureA);
            cmd.Parameters.AddWithValue("p_IsProForma_AOS_RERAformat_No_IsApproved", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_No_IsApproved) ? string.Empty : smodel.IsProForma_AOS_RERAformat_No_IsApproved);
            cmd.Parameters.AddWithValue("p_IsProject_MegaProjectCategory", String.IsNullOrEmpty(smodel.IsProject_MegaProjectCategory) ? string.Empty : smodel.IsProject_MegaProjectCategory);
            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", String.IsNullOrEmpty(smodel.IsLitigation_RelatedProject) ? string.Empty : smodel.IsLitigation_RelatedProject);
            
            cmd.Parameters.AddWithValue("p_A_column", (smodel.A_column == 0) ? 0 : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

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

        public Tuple<bool, string> Update_ProjectPUC_ProjectFactsDetails(ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrjPersonDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_ProjectFactsAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFacts_IndexID", (smodel.ProjectPUC_AuthorisedPrjPerson_IndexID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectFacts_ID", (smodel.ProjectPUC_AuthorisedPrjPerson_ID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrjPerson_ID);

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

            //Properties : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Facts (FormB Date)
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);

            cmd.Parameters.AddWithValue("p_Project_Status", String.IsNullOrEmpty(smodel.Project_Status) ? string.Empty : smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_ProjectStart_Date", smodel.ProjectStart_Date.HasValue ? smodel.ProjectStart_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_ProposedDate", smodel.ProjectCompletion_ProposedDate.HasValue ? smodel.ProjectCompletion_ProposedDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_OriginalDate", smodel.ProjectCompletion_OriginalDate.HasValue ? smodel.ProjectCompletion_OriginalDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationProvided_Duration", String.IsNullOrEmpty(smodel.ProjectRegistrationProvided_Duration) ? string.Empty : smodel.ProjectRegistrationProvided_Duration);
            cmd.Parameters.AddWithValue("p_ProjectDelayReason_IfAny", String.IsNullOrEmpty(smodel.ProjectDelayReason_IfAny) ? string.Empty : smodel.ProjectDelayReason_IfAny);

            cmd.Parameters.AddWithValue("p_IsProForma_AOS_RERAformat_AnnexureA", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_AnnexureA) ? string.Empty : smodel.IsProForma_AOS_RERAformat_AnnexureA);
            cmd.Parameters.AddWithValue("p_IsProForma_AOS_RERAformat_No_IsApproved", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_No_IsApproved) ? string.Empty : smodel.IsProForma_AOS_RERAformat_No_IsApproved);
            cmd.Parameters.AddWithValue("p_IsProject_MegaProjectCategory", String.IsNullOrEmpty(smodel.IsProject_MegaProjectCategory) ? string.Empty : smodel.IsProject_MegaProjectCategory);
            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", String.IsNullOrEmpty(smodel.IsLitigation_RelatedProject) ? string.Empty : smodel.IsLitigation_RelatedProject);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.A_column == 0) ? 0 : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

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