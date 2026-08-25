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
    public class ClsMethod_View_CP_ProjectPUCauthorisedpromoterperson
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public Tuple<bool, string> Add_ProjectPUC_AuthorisedPromoterPersonDetails(ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrmtrPersonDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_PUC_AuthorisedPrmtrPersonAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_AuthorisedPrmtrPerson_IndexID", (smodel.ProjectPUC_AuthorisedPrmtrPerson_IndexID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrmtrPerson_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_AuthorisedPrmtrPerson_ID", (smodel.ProjectPUC_AuthorisedPrmtrPerson_ID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrmtrPerson_ID);

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

            //Properties : Authorised Person (Promoter)
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_IndexID", (smodel.PromoterRegistrationAdditional_IndexID == 0) ? 0 : smodel.PromoterRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_ID", (smodel.PromoterRegistrationAdditional_ID == 0) ? 0 : smodel.PromoterRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Authorised Person (Promoter)
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_AuthorizedPerson_PAN_Number", String.IsNullOrEmpty(smodel.PUC_AuthorizedPerson_PAN_Number) ? string.Empty : smodel.PUC_AuthorizedPerson_PAN_Number);
            cmd.Parameters.AddWithValue("p_PUC_AuthorizedPerson_Aadhaar_Number", String.IsNullOrEmpty(smodel.PUC_AuthorizedPerson_Aadhaar_Number) ? string.Empty : smodel.PUC_AuthorizedPerson_Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);
            
            //Properties [Start] : Authorised Person (Promoter)
            cmd.Parameters.AddWithValue("p_Id", (smodel.Id == 0) ? 0 : smodel.Id);
            cmd.Parameters.AddWithValue("p_Application_id", (smodel.Application_id == 0) ? 0 : smodel.Application_id);

            cmd.Parameters.AddWithValue("p_AuthorisedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorisedPerson_FirstName) ? string.Empty : smodel.AuthorisedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorisedPerson_MiddleName", String.IsNullOrEmpty(smodel.AuthorisedPerson_MiddleName) ? string.Empty : smodel.AuthorisedPerson_MiddleName);
            cmd.Parameters.AddWithValue("p_AuthorisedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorisedPerson_LastName) ? string.Empty : smodel.AuthorisedPerson_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_EmailAddress", String.IsNullOrEmpty(smodel.Email) ? string.Empty : smodel.Email);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_MobileNumber", (smodel.Mobile_no == 0) ? 0 : smodel.Mobile_no);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LandlineNumber", (smodel.Phone_No == 0) ? 0 : smodel.Phone_No);
            
            cmd.Parameters.AddWithValue("p_A_column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_column", string.Empty);
            cmd.Parameters.AddWithValue("p_C_column", string.Empty);

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

        public Tuple<bool, string> Update_ProjectPUC_AuthorisedPromoterPersonDetails(ClsPrp_ControlPanel_View_ProjectPUCAuthorisedPrmtrPersonDetails smodel, string User_Name, Int64 uProject_ID, Int64 uPromoter_ID, Int64 uPUC_ID, string uProjectDNumber, Int64 uCategoryPUC_ID, string uPucDNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_PUC_AuthorisedPrmtrPersonAdditionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectPUC_AuthorisedPrmtrPerson_IndexID", (smodel.ProjectPUC_AuthorisedPrmtrPerson_IndexID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrmtrPerson_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectPUC_AuthorisedPrmtrPerson_ID", (smodel.ProjectPUC_AuthorisedPrmtrPerson_ID == 0) ? 0 : smodel.ProjectPUC_AuthorisedPrmtrPerson_ID);

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

            //Properties : Authorised Person (Promoter)
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_IndexID", (smodel.PromoterRegistrationAdditional_IndexID == 0) ? 0 : smodel.PromoterRegistrationAdditional_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterRegistrationAdditional_ID", (smodel.PromoterRegistrationAdditional_ID == 0) ? 0 : smodel.PromoterRegistrationAdditional_ID);

            cmd.Parameters.AddWithValue("p_Account_FormDate", smodel.Account_FormDate.HasValue ? smodel.Account_FormDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ToDate", smodel.Account_ToDate.HasValue ? smodel.Account_ToDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Account_ApprovedDate", smodel.Account_ApprovedDate.HasValue ? smodel.Account_ApprovedDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_IsConditionAnnexure", (smodel.IsConditionAnnexure == 0) ? 0 : smodel.IsConditionAnnexure);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsApproved", (smodel.IsApproved == 0) ? 0 : smodel.IsApproved);
            cmd.Parameters.AddWithValue("p_IsMemberApproved", (smodel.IsMemberApproved == 0) ? 0 : smodel.IsMemberApproved);

            //Properties : Ref Doc of Authorised Person (Promoter)
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceTitle", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceTitle) ? string.Empty : smodel.PUC_Doc_ReferenceTitle);
            cmd.Parameters.AddWithValue("p_PUC_Doc_ReferenceNumber", String.IsNullOrEmpty(smodel.PUC_Doc_ReferenceNumber) ? string.Empty : smodel.PUC_Doc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PUC_AuthorizedPerson_PAN_Number", String.IsNullOrEmpty(smodel.PUC_AuthorizedPerson_PAN_Number) ? string.Empty : smodel.PUC_AuthorizedPerson_PAN_Number);
            cmd.Parameters.AddWithValue("p_PUC_AuthorizedPerson_Aadhaar_Number", String.IsNullOrEmpty(smodel.PUC_AuthorizedPerson_Aadhaar_Number) ? string.Empty : smodel.PUC_AuthorizedPerson_Aadhaar_Number);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDetailsIfAny", String.IsNullOrEmpty(smodel.PUC_ReferenceDetailsIfAny) ? string.Empty : smodel.PUC_ReferenceDetailsIfAny);

            //Properties [Start] : Authorised Person (Promoter)
            cmd.Parameters.AddWithValue("p_Id", (smodel.Id == 0) ? 0 : smodel.Id);
            cmd.Parameters.AddWithValue("p_Application_id", (smodel.Application_id == 0) ? 0 : smodel.Application_id);

            cmd.Parameters.AddWithValue("p_AuthorisedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorisedPerson_FirstName) ? string.Empty : smodel.AuthorisedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorisedPerson_MiddleName", String.IsNullOrEmpty(smodel.AuthorisedPerson_MiddleName) ? string.Empty : smodel.AuthorisedPerson_MiddleName);
            cmd.Parameters.AddWithValue("p_AuthorisedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorisedPerson_LastName) ? string.Empty : smodel.AuthorisedPerson_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_EmailAddress", String.IsNullOrEmpty(smodel.Email) ? string.Empty : smodel.Email);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_MobileNumber", (smodel.Mobile_no == 0) ? 0 : smodel.Mobile_no);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LandlineNumber", (smodel.Phone_No == 0) ? 0 : smodel.Phone_No);

            cmd.Parameters.AddWithValue("p_A_column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_column", string.Empty);
            cmd.Parameters.AddWithValue("p_C_column", string.Empty);

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