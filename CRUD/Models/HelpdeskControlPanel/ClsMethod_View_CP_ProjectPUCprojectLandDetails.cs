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
    public class ClsMethod_View_CP_ProjectPUCprojectLandDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public Tuple<bool, string> Add_ProjectPUC_ProjectLandDetails(ClsPrp_ControlPanel_View_ProjectPUCProjectLandDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_ProjectLandAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectLand_IndexID", (smodel.ProjectPUC_ProjectLand_IndexID == 0) ? 0 : smodel.ProjectPUC_ProjectLand_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectLand_ID", (smodel.ProjectPUC_ProjectLand_ID == 0) ? 0 : smodel.ProjectPUC_ProjectLand_ID);

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

            //Properties : Project Land Details
            cmd.Parameters.AddWithValue("p_ProjectLandAdditional_IndexID", (smodel.ProjectLandAdditional_IndexID == 0) ? 0 : smodel.ProjectLandAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectLandAdditional_ID", (smodel.ProjectLandAdditional_ID == 0) ? 0 : smodel.ProjectLandAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Land Details
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);            
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Land Details            
            cmd.Parameters.AddWithValue("p_ProjectLand_IndexID", (smodel.ProjectLand_IndexID == 0) ? 0 : smodel.ProjectLand_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectLand_ID", (smodel.ProjectLand_ID == 0) ? 0 : smodel.ProjectLand_ID);
            cmd.Parameters.AddWithValue("p_ProjectLandRelated_ProjectRegistration_ID", (smodel.ProjectLandRelated_ProjectRegistration_ID == 0) ? 0 : smodel.ProjectLandRelated_ProjectRegistration_ID);

            cmd.Parameters.AddWithValue("p_ProposedLand_TobeDeveloped_Area_Total", smodel.ProposedLand_TobeDeveloped_Area_Total);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_ResidentialGroupHousing", smodel.ProposedLand_Area_ResidentialGroupHousing);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_ResidentialPlotted", smodel.ProposedLand_Area_ResidentialPlotted);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_Commercial", smodel.ProposedLand_Area_Commercial);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_Industrial", smodel.ProposedLand_Area_Industrial);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_A_column", smodel.ProposedLand_Area_A_column);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_B_column", smodel.ProposedLand_Area_B_column);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_C_column", smodel.ProposedLand_Area_C_column);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_D_column", 0);//smodel.ProposedLand_Area_D_column);

            cmd.Parameters.AddWithValue("p_Name_of_Villages", String.IsNullOrEmpty(smodel.Name_of_Villages) ? string.Empty : smodel.Name_of_Villages);

            cmd.Parameters.AddWithValue("p_ProposedLand_TobeDeveloped_TotalOpenArea", smodel.ProposedLand_TobeDeveloped_TotalOpenArea);
            cmd.Parameters.AddWithValue("p_ProposedLand_TobeDeveloped_TotalCoveredArea", smodel.ProposedLand_TobeDeveloped_TotalCoveredArea);

            cmd.Parameters.AddWithValue("p_ProposedProjectLand_StartPoint_Longitude", smodel.ProposedProjectLand_StartPoint_Longitude);
            cmd.Parameters.AddWithValue("p_ProposedProjectLand_StartPoint_Latitude", smodel.ProposedProjectLand_StartPoint_Latitude);
            cmd.Parameters.AddWithValue("p_ProposedProjectLand_EndPoint_Longitude", smodel.ProposedProjectLand_EndPoint_Longitude);
            cmd.Parameters.AddWithValue("p_ProposedProjectLand_EndPoint_Latitude", smodel.ProposedProjectLand_EndPoint_Latitude);

            cmd.Parameters.AddWithValue("p_IsProjectLand_Status_OwnedByPromoter", String.IsNullOrEmpty(smodel.IsProjectLand_Status_OwnedByPromoter) ? string.Empty : smodel.IsProjectLand_Status_OwnedByPromoter);
            cmd.Parameters.AddWithValue("p_IsProjectLand_Status_NotOwnedByPromoter", "NA");//String.IsNullOrEmpty(smodel.IsProjectLand_Status_NotOwnedByPromoter) ? string.Empty : smodel.IsProjectLand_Status_NotOwnedByPromoter);
            cmd.Parameters.AddWithValue("p_IsLandEncumbrances_IfAny", String.IsNullOrEmpty(smodel.IsLandEncumbrances_IfAny) ? string.Empty : smodel.IsLandEncumbrances_IfAny);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
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

        public Tuple<bool, string> Update_ProjectPUC_ProjectLandDetails(ClsPrp_ControlPanel_View_ProjectPUCProjectLandDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_ProjectLandAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectLand_IndexID", (smodel.ProjectPUC_ProjectLand_IndexID == 0) ? 0 : smodel.ProjectPUC_ProjectLand_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_ProjectLand_ID", (smodel.ProjectPUC_ProjectLand_ID == 0) ? 0 : smodel.ProjectPUC_ProjectLand_ID);

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

            //Properties : Project Land Details
            cmd.Parameters.AddWithValue("p_ProjectLandAdditional_IndexID", (smodel.ProjectLandAdditional_IndexID == 0) ? 0 : smodel.ProjectLandAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectLandAdditional_ID", (smodel.ProjectLandAdditional_ID == 0) ? 0 : smodel.ProjectLandAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Project Land Details
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Project Land Details            
            cmd.Parameters.AddWithValue("p_ProjectLand_IndexID", (smodel.ProjectLand_IndexID == 0) ? 0 : smodel.ProjectLand_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectLand_ID", (smodel.ProjectLand_ID == 0) ? 0 : smodel.ProjectLand_ID);
            cmd.Parameters.AddWithValue("p_ProjectLandRelated_ProjectRegistration_ID", (smodel.ProjectLandRelated_ProjectRegistration_ID == 0) ? 0 : smodel.ProjectLandRelated_ProjectRegistration_ID);

            cmd.Parameters.AddWithValue("p_ProposedLand_TobeDeveloped_Area_Total", smodel.ProposedLand_TobeDeveloped_Area_Total);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_ResidentialGroupHousing", smodel.ProposedLand_Area_ResidentialGroupHousing);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_ResidentialPlotted", smodel.ProposedLand_Area_ResidentialPlotted);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_Commercial", smodel.ProposedLand_Area_Commercial);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_Industrial", smodel.ProposedLand_Area_Industrial);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_A_column", smodel.ProposedLand_Area_A_column);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_B_column", smodel.ProposedLand_Area_B_column);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_C_column", smodel.ProposedLand_Area_C_column);
            cmd.Parameters.AddWithValue("p_ProposedLand_Area_D_column", 0);//smodel.ProposedLand_Area_D_column);

            cmd.Parameters.AddWithValue("p_Name_of_Villages", String.IsNullOrEmpty(smodel.Name_of_Villages) ? string.Empty : smodel.Name_of_Villages);

            cmd.Parameters.AddWithValue("p_ProposedLand_TobeDeveloped_TotalOpenArea", smodel.ProposedLand_TobeDeveloped_TotalOpenArea);
            cmd.Parameters.AddWithValue("p_ProposedLand_TobeDeveloped_TotalCoveredArea", smodel.ProposedLand_TobeDeveloped_TotalCoveredArea);

            cmd.Parameters.AddWithValue("p_ProposedProjectLand_StartPoint_Longitude", smodel.ProposedProjectLand_StartPoint_Longitude);
            cmd.Parameters.AddWithValue("p_ProposedProjectLand_StartPoint_Latitude", smodel.ProposedProjectLand_StartPoint_Latitude);
            cmd.Parameters.AddWithValue("p_ProposedProjectLand_EndPoint_Longitude", smodel.ProposedProjectLand_EndPoint_Longitude);
            cmd.Parameters.AddWithValue("p_ProposedProjectLand_EndPoint_Latitude", smodel.ProposedProjectLand_EndPoint_Latitude);

            cmd.Parameters.AddWithValue("p_IsProjectLand_Status_OwnedByPromoter", String.IsNullOrEmpty(smodel.IsProjectLand_Status_OwnedByPromoter) ? string.Empty : smodel.IsProjectLand_Status_OwnedByPromoter);
            cmd.Parameters.AddWithValue("p_IsProjectLand_Status_NotOwnedByPromoter", "NA");//String.IsNullOrEmpty(smodel.IsProjectLand_Status_NotOwnedByPromoter) ? string.Empty : smodel.IsProjectLand_Status_NotOwnedByPromoter);
            cmd.Parameters.AddWithValue("p_IsLandEncumbrances_IfAny", String.IsNullOrEmpty(smodel.IsLandEncumbrances_IfAny) ? string.Empty : smodel.IsLandEncumbrances_IfAny);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
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