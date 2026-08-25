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
    public class ClsMethod_View_CP_ProjectPUC
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Master PUC
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> Display_CP_ACR_SearchCategoryForMaster_ByID(string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> CPmasterList = new List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ACR_SearchCategoryForMaster_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPmasterList.Add(
                    new ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory
                    {
                        ChangeRequest_IndexID = Convert.ToInt64(dr["ChangeRequest_IndexID"]),
                        ChangeRequest_Code = Convert.ToInt64(dr["ChangeRequest_Code"]),
                        ChangeRequest_ApplicableFor = Convert.ToString(dr["ChangeRequest_ApplicableFor"]),
                        ChangeRequest_SubApplicableFor = Convert.ToString(dr["ChangeRequest_SubApplicableFor"]),
                        ChangeRequest_Aggregate = Convert.ToString(dr["ChangeRequest_Aggregate"]),
                        ChangeRequest_Description = Convert.ToString(dr["ChangeRequest_Description"]),
                        Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                        ChangeRequest_ValidCode = Convert.ToInt32(dr["ChangeRequest_ValidCode"]),
                        ChangeRequest_IsGroup = Convert.ToInt32(dr["ChangeRequest_IsGroup"]),
                        ChangeRequest_IsMandatory = Convert.ToInt32(dr["ChangeRequest_IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return CPmasterList;
        }

        //Register Project PUC
        public List<ClsPrp_ControlPanel_View_ProjectPUC> Display_CP_ProjectRegistrationPUC_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectPUC> CPregistrationList = new List<ClsPrp_ControlPanel_View_ProjectPUC>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectRegistrationPUC_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPregistrationList.Add(
                    new ClsPrp_ControlPanel_View_ProjectPUC
                    {
                        RelatedPromoter_ID = Convert.ToInt64(dr["prmPromoter_ID"]),
                        RelatedProject_ID = Convert.ToInt64(dr["prmProject_ID"]),
                        RERAnumberRegistration = Convert.ToString(dr["prmRERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["prmRERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberRegUptoDate"]),

                        IsExtensionRegistration = Convert.ToInt32(dr["prmIsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberExtensionRegUptoDate"]),
                        ProjectDiaryNumber = Convert.ToString(dr["prmProjectDiaryNumber"]),
                        ExtensionRegdDiaryNumber = Convert.ToString(dr["prmExtensionRegdDiaryNumber"]),

                        ProjectName = Convert.ToString(dr["prmProjectName"]),
                        PromoterName = Convert.ToString(dr["prmPromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["prmProjectAddressDistrict"]),
                        DName = Convert.ToString(dr["prmDName"]),
                        ProjectType = Convert.ToString(dr["prmProjectType"]),
                    });
            }
            return CPregistrationList;
        }

        public Tuple<bool, string> Add_ProjectRegistrationPUC_DiaryNumber(ClsPrp_ControlPanel_View_ProjectPUC smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, Int64 sPUC_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_puc_regdiarynumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ApplicationPUC_IndexID", (smodel.ApplicationPUC_IndexID == 0) ? 0 : smodel.ApplicationPUC_IndexID);
            cmd.Parameters.AddWithValue("p_ApplicationPUC_ID", (smodel.ApplicationPUC_ID == 0) ? 0 : smodel.ApplicationPUC_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", sPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", sProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);

            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", String.IsNullOrEmpty(smodel.ProjectDiaryNumber) ? string.Empty : smodel.ProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtensionRegdDiaryNumber", String.IsNullOrEmpty(smodel.ExtensionRegdDiaryNumber) ? string.Empty : smodel.ExtensionRegdDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);
            cmd.Parameters.AddWithValue("p_RequestOrderSequence", (smodel.RequestOrderSequence == 0) ? 0 : smodel.RequestOrderSequence);

            cmd.Parameters.AddWithValue("p_PUC_ChangeForDetails", String.IsNullOrEmpty(smodel.PUC_ChangeForDetails) ? string.Empty : smodel.PUC_ChangeForDetails);
            cmd.Parameters.AddWithValue("p_PUC_ChangeSummary", String.IsNullOrEmpty(smodel.PUC_ChangeSummary) ? string.Empty : smodel.PUC_ChangeSummary);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Name", String.IsNullOrEmpty(smodel.PUC_ReferencePUC_Name) ? string.Empty : smodel.PUC_ReferencePUC_Name);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Year", (smodel.PUC_ReferencePUC_Year == 0) ? 0 : smodel.PUC_ReferencePUC_Year);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Date", smodel.PUC_ReferencePUC_Date.HasValue ? smodel.PUC_ReferencePUC_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryName", String.IsNullOrEmpty(smodel.PUC_RequestCategoryName) ? string.Empty : smodel.PUC_RequestCategoryName);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryID", (smodel.PUC_RequestCategoryID == 0) ? 0 : smodel.PUC_RequestCategoryID);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDocumentDetail", String.IsNullOrEmpty(smodel.PUC_ReferenceDocumentDetail) ? string.Empty : smodel.PUC_ReferenceDocumentDetail);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDocumentNumber", String.IsNullOrEmpty(smodel.PUC_ReferenceDocumentNumber) ? string.Empty : smodel.PUC_ReferenceDocumentNumber);
            cmd.Parameters.AddWithValue("p_PUC_DocReferenceName", String.IsNullOrEmpty(smodel.PUC_DocReferenceName) ? string.Empty : smodel.PUC_DocReferenceName);
            cmd.Parameters.AddWithValue("p_PUC_DocReferenceDate", smodel.PUC_DocReferenceDate.HasValue ? smodel.PUC_DocReferenceDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_DocumentStatus", String.IsNullOrEmpty(smodel.PUC_DocumentStatus) ? string.Empty : smodel.PUC_DocumentStatus);
            cmd.Parameters.AddWithValue("p_PUC_ReceiptDatePlanned_DateExpected", smodel.PUC_ReceiptDatePlanned_DateExpected.HasValue ? smodel.PUC_ReceiptDatePlanned_DateExpected : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_ReciptType", String.IsNullOrEmpty(smodel.PUC_ReciptType) ? string.Empty : smodel.PUC_ReciptType);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_Extra5", String.IsNullOrEmpty(smodel.Extra5) ? string.Empty : smodel.Extra5);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", (smodel.IsApproval == 0) ? 0 : smodel.IsApproval);
            cmd.Parameters.AddWithValue("p_IsConditional", (smodel.IsConditional == 0) ? 0 : smodel.IsConditional);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

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

        public Tuple<bool, string> Update_ProjectRegistrationPUC_DiaryNumber(ClsPrp_ControlPanel_View_ProjectPUC smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, Int64 sPUC_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_puc_paperunderconsiderations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ApplicationPUC_IndexID", (smodel.ApplicationPUC_IndexID == 0) ? 0 : smodel.ApplicationPUC_IndexID);
            cmd.Parameters.AddWithValue("p_ApplicationPUC_ID", (smodel.ApplicationPUC_ID == 0) ? 0 : smodel.ApplicationPUC_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", sPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", sProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);

            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", String.IsNullOrEmpty(smodel.ProjectDiaryNumber) ? string.Empty : smodel.ProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtensionRegdDiaryNumber", String.IsNullOrEmpty(smodel.ExtensionRegdDiaryNumber) ? string.Empty : smodel.ExtensionRegdDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);
            cmd.Parameters.AddWithValue("p_RequestOrderSequence", (smodel.RequestOrderSequence == 0) ? 0 : smodel.RequestOrderSequence);

            cmd.Parameters.AddWithValue("p_PUC_ChangeForDetails", String.IsNullOrEmpty(smodel.PUC_ChangeForDetails) ? string.Empty : smodel.PUC_ChangeForDetails);
            cmd.Parameters.AddWithValue("p_PUC_ChangeSummary", String.IsNullOrEmpty(smodel.PUC_ChangeSummary) ? string.Empty : smodel.PUC_ChangeSummary);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Name", String.IsNullOrEmpty(smodel.PUC_ReferencePUC_Name) ? string.Empty : smodel.PUC_ReferencePUC_Name);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Year", (smodel.PUC_ReferencePUC_Year == 0) ? 0 : smodel.PUC_ReferencePUC_Year);
            cmd.Parameters.AddWithValue("p_PUC_ReferencePUC_Date", smodel.PUC_ReferencePUC_Date.HasValue ? smodel.PUC_ReferencePUC_Date : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryName", String.IsNullOrEmpty(smodel.PUC_RequestCategoryName) ? string.Empty : smodel.PUC_RequestCategoryName);
            cmd.Parameters.AddWithValue("p_PUC_RequestCategoryID", (smodel.PUC_RequestCategoryID == 0) ? 0 : smodel.PUC_RequestCategoryID);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDocumentDetail", String.IsNullOrEmpty(smodel.PUC_ReferenceDocumentDetail) ? string.Empty : smodel.PUC_ReferenceDocumentDetail);
            cmd.Parameters.AddWithValue("p_PUC_ReferenceDocumentNumber", String.IsNullOrEmpty(smodel.PUC_ReferenceDocumentNumber) ? string.Empty : smodel.PUC_ReferenceDocumentNumber);
            cmd.Parameters.AddWithValue("p_PUC_DocReferenceName", String.IsNullOrEmpty(smodel.PUC_DocReferenceName) ? string.Empty : smodel.PUC_DocReferenceName);
            cmd.Parameters.AddWithValue("p_PUC_DocReferenceDate", smodel.PUC_DocReferenceDate.HasValue ? smodel.PUC_DocReferenceDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_DocumentStatus", String.IsNullOrEmpty(smodel.PUC_DocumentStatus) ? string.Empty : smodel.PUC_DocumentStatus);
            cmd.Parameters.AddWithValue("p_PUC_ReceiptDatePlanned_DateExpected", smodel.PUC_ReceiptDatePlanned_DateExpected.HasValue ? smodel.PUC_ReceiptDatePlanned_DateExpected : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PUC_ReciptType", String.IsNullOrEmpty(smodel.PUC_ReciptType) ? string.Empty : smodel.PUC_ReciptType);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_Extra5", String.IsNullOrEmpty(smodel.Extra5) ? string.Empty : smodel.Extra5);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", (smodel.IsApproval == 0) ? 0 : smodel.IsApproval);
            cmd.Parameters.AddWithValue("p_IsConditional", (smodel.IsConditional == 0) ? 0 : smodel.IsConditional);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

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

        //Status of PUC
        public List<ClsPrp_ControlPanel_View_ProjectPUCstatusDetails> Display_CP_ProjectRegistrationPUCstatusDetails_ByID(string pRegistrationNumber, string pProjectDNumber, string pPucDNumber, string pReferenceNumber, DateTime pReferenceDate, Int32 pNumberFlag, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectPUCstatusDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_ProjectPUCstatusDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectPaperUnderConsiderationPUCstatus_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ProjectDNumber", pProjectDNumber);
            cmd.Parameters.AddWithValue("p_PucDNumber", pPucDNumber);
            cmd.Parameters.AddWithValue("p_ReferenceNumber", pReferenceNumber);
            cmd.Parameters.AddWithValue("p_ReferenceDate", pReferenceDate);
            cmd.Parameters.AddWithValue("p_NumberFlag", pNumberFlag);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_ProjectPUCstatusDetails
                    {
                        ProjectEventActionPUC_ID = Convert.ToInt64(dr["ProjectEventActionPUC_ID"]),
                        EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        RelatedApplicationPUC_ID = Convert.ToInt64(dr["RelatedApplicationPUC_ID"]),
                        Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        PUC_DiaryNumber = Convert.ToString(dr["PUC_DiaryNumber"]),
                        PUC_ReferencePUC_Name = Convert.ToString(dr["PUC_ReferencePUC_Name"]),
                        PUC_ReferencePUC_Date = Convert.ToDateTime(dr["PUC_ReferencePUC_Date"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                        EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                        AssignedTo = Convert.ToString(dr["AssignedTo"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                        Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                        IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
                        ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        dPUC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["dPUC_RegDiaryNumber_IndexID"]),
                        dPUC_RegDiaryNumber_ID = Convert.ToInt64(dr["dPUC_RegDiaryNumber_ID"]),
                        dPUC_RegDiaryNumber_Name = Convert.ToString(dr["dPUC_RegDiaryNumber_Name"]),
                        dPUC_RegDiaryNumber_NameYear = Convert.ToString(dr["dPUC_RegDiaryNumber_NameYear"]),
                        dUserID = Convert.ToString(dr["dUserID"]),
                        dRelatedPromoter_ID = Convert.ToInt64(dr["dRelatedPromoter_ID"]),
                        dRelatedProject_ID = Convert.ToInt64(dr["dRelatedProject_ID"]),
                        dRelatedApplicationPUC_ID = Convert.ToInt64(dr["dRelatedApplicationPUC_ID"]),
                        dPUC_RequestCategoryName = Convert.ToString(dr["dPUC_RequestCategoryName"]),
                        dPUC_RequestCategoryID = Convert.ToInt64(dr["dPUC_RequestCategoryID"]),
                        dRERA_RegistrationNumber = Convert.ToString(dr["dRERA_RegistrationNumber"]),
                        dPUC_ReferencePUC_Name = Convert.ToString(dr["dPUC_ReferencePUC_Name"]),
                        dPUC_ReferencePUC_Year = Convert.ToInt32(dr["dPUC_ReferencePUC_Year"]),
                        dPUC_ReferencePUC_Date = Convert.ToDateTime(dr["dPUC_ReferencePUC_Date"]),
                        dPaymentDetailsCount = Convert.ToInt32(dr["dPaymentDetailsCount"]),
                        dChangeRequestCount = Convert.ToInt32(dr["dChangeRequestCount"]),
                        dIsRegistration = Convert.ToString(dr["dIsRegistration"]),
                        dCurrentEventCcode = Convert.ToInt64(dr["dCurrentEventCcode"]),
                        dEventCodeDetails_indexID = Convert.ToInt64(dr["dEventCodeDetails_indexID"]),
                        dRequestOrderSequence = Convert.ToInt32(dr["dRequestOrderSequence"]),
                        dExtra1 = Convert.ToString(dr["dExtra1"]),
                        dExtra2 = Convert.ToString(dr["dExtra2"]),
                        dExtra3 = Convert.ToString(dr["dExtra3"]),
                        dExtra4 = Convert.ToString(dr["dExtra4"]),
                        dRemarks_IfAny = Convert.ToString(dr["dRemarks_IfAny"]),
                        dIsActive = Convert.ToInt32(dr["dIsActive"]),
                        dIsActiveProvider = Convert.ToInt32(dr["dIsActiveProvider"]),
                        dIsDraft = Convert.ToInt32(dr["dIsDraft"]),
                        dIsDraftHelpDesk = Convert.ToInt32(dr["dIsDraftHelpDesk"]),
                        dIsDraftEvaluation = Convert.ToInt32(dr["dIsDraftEvaluation"]),
                        dIsDraftSecMember = Convert.ToInt32(dr["dIsDraftSecMember"]),
                        dIsDraftMember = Convert.ToInt32(dr["dIsDraftMember"]),

                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                    });
            }
            return CPstatusList;
        }

        public List<ClsPrp_ControlPanel_View_ProjectPUCEventLog> Display_CP_ProjectRegistrationPUCProjectEventLogDetails_ByID(Int64 mProjectID, Int64 mPromoterID, Int64 mPUC_ID, Int32 mCategoryID, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectPUCEventLog> CPstatusList = new List<ClsPrp_ControlPanel_View_ProjectPUCEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectPaperUnderConsiderationPUCEventLog_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectID", mProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", mPromoterID);
            cmd.Parameters.AddWithValue("p_PUC_ID", mPUC_ID);
            cmd.Parameters.AddWithValue("p_CategoryID", mCategoryID);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_ProjectPUCEventLog
                    {
                        ProjectEventActionPUC_ID = Convert.ToInt64(dr["ProjectEventActionPUC_ID"]),
                        EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        RelatedApplicationPUC_ID = Convert.ToInt64(dr["RelatedApplicationPUC_ID"]),
                        Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        PUC_DiaryNumber = Convert.ToString(dr["PUC_DiaryNumber"]),
                        PUC_ReferencePUC_Name = Convert.ToString(dr["PUC_ReferencePUC_Name"]),
                        PUC_ReferencePUC_Date = Convert.ToDateTime(dr["PUC_ReferencePUC_Date"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                        EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                        AssignedTo = Convert.ToString(dr["AssignedTo"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                        Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                        IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
                        ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        prmPUC_RequestCategoryName = Convert.ToString(dr["mPUC_RequestCategoryName"]),
                        prmPUC_RequestCategoryID = Convert.ToInt64(dr["mPUC_RequestCategoryID"]),                        
                    });
            }
            return CPstatusList;
        }

        //Extract PUC with Registered Project
        public List<ClsPrp_ControlPanel_View_ProjectPUCExtractDetails> Display_CP_ProjectRegistrationPUCreferenceDetails_ByID(Int32 pRequestFlag, string pRequestCategory, string pRegNumber, string pDNumber, string pPucDNumber, string pPUCnumber, DateTime pPUCdate, string pUserRole) 
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectPUCExtractDetails> CPregistrationList = new List<ClsPrp_ControlPanel_View_ProjectPUCExtractDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectRegisteredPUCreferenceDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RequestFlag", pRequestFlag);
            cmd.Parameters.AddWithValue("p_RequestCategory", pRequestCategory);
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegNumber);
            cmd.Parameters.AddWithValue("p_ProjectDNumber", pDNumber);
            cmd.Parameters.AddWithValue("p_PucDNumber", pPucDNumber);
            cmd.Parameters.AddWithValue("p_PUCnumber", pPUCnumber);
            cmd.Parameters.AddWithValue("p_PUCdate", pPUCdate);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPregistrationList.Add(
                    new ClsPrp_ControlPanel_View_ProjectPUCExtractDetails
                    {
                        Promoter_ID = Convert.ToInt64(dr["prmPromoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["prmProject_ID"]),
                        RERAnumberRegistration = Convert.ToString(dr["prmRERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["prmRERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberRegUptoDate"]),

                        IsExtensionRegistration = Convert.ToInt32(dr["prmIsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberExtensionRegUptoDate"]),
                        ProjectDiaryNumber = Convert.ToString(dr["prmProjectDiaryNumber"]),
                        ExtensionRegdDiaryNumber = Convert.ToString(dr["prmExtensionRegdDiaryNumber"]),

                        ProjectName = Convert.ToString(dr["prmProjectName"]),
                        PromoterName = Convert.ToString(dr["prmPromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["prmProjectAddressDistrict"]),
                        DName = Convert.ToString(dr["prmDName"]),
                        ProjectType = Convert.ToString(dr["prmProjectType"]),

                        ProjectPUC_Reference_IndexID = Convert.ToInt64(dr["prmProjectPUC_Reference_IndexID"]),
                        ProjectPUC_Reference_ID = Convert.ToInt64(dr["prmProjectPUC_Reference_ID"]),
                        PUC_ID = Convert.ToInt64(dr["prmPUC_ID"]),
                        PUC_DiaryNumber = Convert.ToString(dr["prmPUC_DiaryNumber"]),
                        PUC_ReferencePUC_Name = Convert.ToString(dr["prmPUC_ReferencePUC_Name"]),
                        PUC_ReferencePUC_Date = Convert.ToDateTime(dr["prmPUC_ReferencePUC_Date"]),
                        PUC_RequestCategoryName = Convert.ToString(dr["prmPUC_RequestCategoryName"]),
                        PUC_RequestCategoryID = Convert.ToInt64(dr["prmPUC_RequestCategoryID"]),

                        mFlagPUC_YesNo = Convert.ToString(dr["prmFlagPUC_YesNo"]),
                        mFlagPUC_OpenClosed = Convert.ToString(dr["prmFlagPUC_OpenClosed"]),
                        mFlagPUC_ApprovedNotApproved = Convert.ToString(dr["prmFlagPUC_ApprovedNotApproved"]),
                    });
            }
            return CPregistrationList;
        }
    }
}