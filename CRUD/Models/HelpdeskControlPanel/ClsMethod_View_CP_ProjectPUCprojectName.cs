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
    public class ClsMethod_View_CP_ProjectPUCprojectName
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        //Project Name
        public Tuple<bool, string> Add_ProjectPUC_ProjectCorrectionProjectName(ClsPrp_ControlPanel_View_ProjectPUCprojectName smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_ProjectNameAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectName_IndexID", (smodel.ProjectPUC_ProjectName_IndexID == 0) ? 0 : smodel.ProjectPUC_ProjectName_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectName_ID", (smodel.ProjectPUC_ProjectName_ID == 0) ? 0 : smodel.ProjectPUC_ProjectName_ID);

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

            //Properties : Project Name
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Name
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);            
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Name
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_PromoterRegistration_ID", (smodel.PromoterRegistration_ID == 0) ? 0 : smodel.PromoterRegistration_ID);

            cmd.Parameters.AddWithValue("p_Project_Name", String.IsNullOrEmpty(smodel.Project_Name) ? string.Empty : smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_Project_Amenities", String.IsNullOrEmpty(smodel.Project_Amenities) ? string.Empty : smodel.Project_Amenities);
            cmd.Parameters.AddWithValue("p_ProjectWebsite_WebLink", String.IsNullOrEmpty(smodel.ProjectWebsite_WebLink) ? string.Empty : smodel.ProjectWebsite_WebLink);
            cmd.Parameters.AddWithValue("p_IsOnlyProjectPromoterName", (smodel.IsOnlyProjectPromoterName == 0) ? 0 : smodel.IsOnlyProjectPromoterName);
            
            cmd.Parameters.AddWithValue("p_A_ExtraClmn", String.IsNullOrEmpty(smodel.A_ExtraClmn) ? string.Empty : smodel.A_ExtraClmn);
            cmd.Parameters.AddWithValue("p_B_ExtraClmn", String.IsNullOrEmpty(smodel.B_ExtraClmn) ? string.Empty : smodel.B_ExtraClmn);
            cmd.Parameters.AddWithValue("p_C_ExtraClmn", String.IsNullOrEmpty(smodel.C_ExtraClmn) ? string.Empty : smodel.C_ExtraClmn);
            
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

        public Tuple<bool, string> Update_ProjectPUC_ProjectCorrectionProjectName(ClsPrp_ControlPanel_View_ProjectPUCprojectName smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_ProjectNameAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectName_IndexID", (smodel.ProjectPUC_ProjectName_IndexID == 0) ? 0 : smodel.ProjectPUC_ProjectName_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectName_ID", (smodel.ProjectPUC_ProjectName_ID == 0) ? 0 : smodel.ProjectPUC_ProjectName_ID);

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

            //Properties : Project Name
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Name
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Name
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_PromoterRegistration_ID", (smodel.PromoterRegistration_ID == 0) ? 0 : smodel.PromoterRegistration_ID);

            cmd.Parameters.AddWithValue("p_Project_Name", String.IsNullOrEmpty(smodel.Project_Name) ? string.Empty : smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_Project_Amenities", String.IsNullOrEmpty(smodel.Project_Amenities) ? string.Empty : smodel.Project_Amenities);
            cmd.Parameters.AddWithValue("p_ProjectWebsite_WebLink", String.IsNullOrEmpty(smodel.ProjectWebsite_WebLink) ? string.Empty : smodel.ProjectWebsite_WebLink);

            cmd.Parameters.AddWithValue("p_A_ExtraClmn", String.IsNullOrEmpty(smodel.A_ExtraClmn) ? string.Empty : smodel.A_ExtraClmn);
            cmd.Parameters.AddWithValue("p_B_ExtraClmn", String.IsNullOrEmpty(smodel.B_ExtraClmn) ? string.Empty : smodel.B_ExtraClmn);
            cmd.Parameters.AddWithValue("p_C_ExtraClmn", String.IsNullOrEmpty(smodel.C_ExtraClmn) ? string.Empty : smodel.C_ExtraClmn);

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

        //Promoter Name
        public Tuple<bool, string> Add_ProjectPUC_ProjectChangePromoterName(ClsPrp_ControlPanel_View_ProjectPUCprojectName smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_PromoterNameAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_PromoterName_IndexID", (smodel.ProjectPUC_ProjectName_IndexID == 0) ? 0 : smodel.ProjectPUC_ProjectName_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_PromoterName_ID", (smodel.ProjectPUC_ProjectName_ID == 0) ? 0 : smodel.ProjectPUC_ProjectName_ID);

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

            //Properties : Promoter Name
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Promoter Name
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Promoter Name
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_PromoterRegistration_ID", (smodel.PromoterRegistration_ID == 0) ? 0 : smodel.PromoterRegistration_ID);

            cmd.Parameters.AddWithValue("p_IsOnlyProjectPromoterName", (smodel.IsOnlyProjectPromoterName == 0) ? 0 : smodel.IsOnlyProjectPromoterName);
            cmd.Parameters.AddWithValue("p_IsPromoterOTI", (smodel.IsPromoterOTI == 0) ? 0 : smodel.IsPromoterOTI);

            cmd.Parameters.AddWithValue("p_Promoter_Name", String.IsNullOrEmpty(smodel.Promoter_Name) ? string.Empty : smodel.Promoter_Name);
            cmd.Parameters.AddWithValue("p_First_Name", String.IsNullOrEmpty(smodel.First_Name) ? string.Empty : smodel.First_Name);
            cmd.Parameters.AddWithValue("p_Middle_Name", String.IsNullOrEmpty(smodel.Middle_Name) ? string.Empty : smodel.Middle_Name);
            cmd.Parameters.AddWithValue("p_Last_Name", String.IsNullOrEmpty(smodel.Last_Name) ? string.Empty : smodel.Last_Name);
            cmd.Parameters.AddWithValue("p_Fath_First_Name", String.IsNullOrEmpty(smodel.Fath_First_Name) ? string.Empty : smodel.Fath_First_Name);
            cmd.Parameters.AddWithValue("p_Fath_Middle_Name", String.IsNullOrEmpty(smodel.Fath_Middle_Name) ? string.Empty : smodel.Fath_Middle_Name);
            cmd.Parameters.AddWithValue("p_Fath_Last_Name", String.IsNullOrEmpty(smodel.Fath_Last_Name) ? string.Empty : smodel.Fath_Last_Name);
            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? string.Empty : smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Org_Name", String.IsNullOrEmpty(smodel.Org_Name) ? string.Empty : smodel.Org_Name);
            cmd.Parameters.AddWithValue("p_Org_Type", String.IsNullOrEmpty(smodel.Org_Type) ? string.Empty : smodel.Org_Type);
            cmd.Parameters.AddWithValue("p_Org_Objects", String.IsNullOrEmpty(smodel.Org_Objects) ? string.Empty : smodel.Org_Objects);
            cmd.Parameters.AddWithValue("p_WebLink_Promoter_website", String.IsNullOrEmpty(smodel.WebLink_Promoter_website) ? string.Empty : smodel.WebLink_Promoter_website);

            cmd.Parameters.AddWithValue("p_A_ExtraClmn", String.IsNullOrEmpty(smodel.A_ExtraClmn) ? string.Empty : smodel.A_ExtraClmn);
            cmd.Parameters.AddWithValue("p_B_ExtraClmn", String.IsNullOrEmpty(smodel.B_ExtraClmn) ? string.Empty : smodel.B_ExtraClmn);
            cmd.Parameters.AddWithValue("p_C_ExtraClmn", String.IsNullOrEmpty(smodel.C_ExtraClmn) ? string.Empty : smodel.C_ExtraClmn);

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

        public Tuple<bool, string> Update_ProjectPUC_ProjectChangePromoterName(ClsPrp_ControlPanel_View_ProjectPUCprojectName smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_PromoterNameAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_PromoterName_IndexID", (smodel.ProjectPUC_ProjectName_IndexID == 0) ? 0 : smodel.ProjectPUC_ProjectName_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_PromoterName_ID", (smodel.ProjectPUC_ProjectName_ID == 0) ? 0 : smodel.ProjectPUC_ProjectName_ID);

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

            //Properties : Promoter Name
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_IndexID", (smodel.ProjectRegistrationAdditional_IndexID == 0) ? 0 : smodel.ProjectRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_ID", (smodel.ProjectRegistrationAdditional_ID == 0) ? 0 : smodel.ProjectRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Promoter Name
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Promoter Name
            cmd.Parameters.AddWithValue("p_ProjectRegistration_IndexID", (smodel.ProjectRegistration_IndexID == 0) ? 0 : smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", (smodel.ProjectRegistration_ID == 0) ? 0 : smodel.ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_PromoterRegistration_ID", (smodel.PromoterRegistration_ID == 0) ? 0 : smodel.PromoterRegistration_ID);

            cmd.Parameters.AddWithValue("p_IsOnlyProjectPromoterName", (smodel.IsOnlyProjectPromoterName == 0) ? 0 : smodel.IsOnlyProjectPromoterName);
            cmd.Parameters.AddWithValue("p_IsPromoterOTI", (smodel.IsPromoterOTI == 0) ? 0 : smodel.IsPromoterOTI);

            cmd.Parameters.AddWithValue("p_Promoter_Name", String.IsNullOrEmpty(smodel.Promoter_Name) ? string.Empty : smodel.Promoter_Name);
            cmd.Parameters.AddWithValue("p_First_Name", String.IsNullOrEmpty(smodel.First_Name) ? string.Empty : smodel.First_Name);
            cmd.Parameters.AddWithValue("p_Middle_Name", String.IsNullOrEmpty(smodel.Middle_Name) ? string.Empty : smodel.Middle_Name);
            cmd.Parameters.AddWithValue("p_Last_Name", String.IsNullOrEmpty(smodel.Last_Name) ? string.Empty : smodel.Last_Name);
            cmd.Parameters.AddWithValue("p_Fath_First_Name", String.IsNullOrEmpty(smodel.Fath_First_Name) ? string.Empty : smodel.Fath_First_Name);
            cmd.Parameters.AddWithValue("p_Fath_Middle_Name", String.IsNullOrEmpty(smodel.Fath_Middle_Name) ? string.Empty : smodel.Fath_Middle_Name);
            cmd.Parameters.AddWithValue("p_Fath_Last_Name", String.IsNullOrEmpty(smodel.Fath_Last_Name) ? string.Empty : smodel.Fath_Last_Name);
            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? string.Empty : smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Org_Name", String.IsNullOrEmpty(smodel.Org_Name) ? string.Empty : smodel.Org_Name);
            cmd.Parameters.AddWithValue("p_Org_Type", String.IsNullOrEmpty(smodel.Org_Type) ? string.Empty : smodel.Org_Type);
            cmd.Parameters.AddWithValue("p_Org_Objects", String.IsNullOrEmpty(smodel.Org_Objects) ? string.Empty : smodel.Org_Objects);
            cmd.Parameters.AddWithValue("p_WebLink_Promoter_website", String.IsNullOrEmpty(smodel.WebLink_Promoter_website) ? string.Empty : smodel.WebLink_Promoter_website);

            cmd.Parameters.AddWithValue("p_A_ExtraClmn", String.IsNullOrEmpty(smodel.A_ExtraClmn) ? string.Empty : smodel.A_ExtraClmn);
            cmd.Parameters.AddWithValue("p_B_ExtraClmn", String.IsNullOrEmpty(smodel.B_ExtraClmn) ? string.Empty : smodel.B_ExtraClmn);
            cmd.Parameters.AddWithValue("p_C_ExtraClmn", String.IsNullOrEmpty(smodel.C_ExtraClmn) ? string.Empty : smodel.C_ExtraClmn);

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