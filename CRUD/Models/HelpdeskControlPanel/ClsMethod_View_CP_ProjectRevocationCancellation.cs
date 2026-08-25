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
    public class ClsMethod_View_CP_ProjectRevocationCancellation
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Register Revoke
        public List<ClsPrp_ControlPanel_View_ProjectRevocationCancellation> Display_CP_ProjectRegistrationRevocationCancellation_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectRevocationCancellation> CPregistrationList = new List<ClsPrp_ControlPanel_View_ProjectRevocationCancellation>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectRegistrationCompletionDetails_ByID", con);
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
                    new ClsPrp_ControlPanel_View_ProjectRevocationCancellation
                    {
                        Promoter_ID = Convert.ToInt64(dr["prmPromoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["prmProject_ID"]),
                        RERAnumberRegistration = Convert.ToString(dr["prmRERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["prmRERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberRegUptoDate"]),

                        IsExtensionRegistration = Convert.ToInt32(dr["prmIsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberExtensionRegUptoDate"]),
                        ProjectRegDiaryNumber_Name = Convert.ToString(dr["prmProjectDiaryNumber"]),
                        ExtnRegDiaryNumber_Name = Convert.ToString(dr["prmExtensionRegdDiaryNumber"]),

                        ProjectName = Convert.ToString(dr["prmProjectName"]),
                        PromoterName = Convert.ToString(dr["prmPromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["prmProjectAddressDistrict"]),
                        DName = Convert.ToString(dr["prmDName"]),
                        ProjectType = Convert.ToString(dr["prmProjectType"]),
                    });
            }
            return CPregistrationList;
        }

        public Tuple<bool, string> Add_ProjectRevocationCancellation_DiaryNumber(ClsPrp_ControlPanel_View_ProjectRevocationCancellation smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_revoke_regdiarynumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_IndexID", (smodel.Revoke_RegDiaryNumber_IndexID == 0) ? 0 : smodel.Revoke_RegDiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_ID", (smodel.Revoke_RegDiaryNumber_ID == 0) ? 0 : smodel.Revoke_RegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_Name", String.IsNullOrEmpty(smodel.Revoke_RegDiaryNumber_Name) ? string.Empty : smodel.Revoke_RegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.Revoke_RegDiaryNumber_NameYear) ? string.Empty : smodel.Revoke_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_UserID", sUID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", sPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", sProject_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", sProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtnRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.ExtnRegDiaryNumber_Name) ? string.Empty : smodel.ExtnRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);
            cmd.Parameters.AddWithValue("p_Revoke_InfoDetails", String.IsNullOrEmpty(smodel.Revoke_InfoDetails) ? string.Empty : smodel.Revoke_InfoDetails);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceName", String.IsNullOrEmpty(smodel.Revoke_ReferenceName) ? string.Empty : smodel.Revoke_ReferenceName);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceDate", smodel.Revoke_ReferenceDate.HasValue ? smodel.Revoke_ReferenceDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Revoke_Category", String.IsNullOrEmpty(smodel.Revoke_Category) ? string.Empty : smodel.Revoke_Category);
            cmd.Parameters.AddWithValue("p_Revoke_ReciptType", String.IsNullOrEmpty(smodel.Revoke_ReciptType) ? string.Empty : smodel.Revoke_ReciptType);
            cmd.Parameters.AddWithValue("p_Revoke_Reasons", String.IsNullOrEmpty(smodel.Revoke_Reasons) ? string.Empty : smodel.Revoke_Reasons);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", (smodel.IsDraftHelpDesk == 0) ? 0 : smodel.IsDraftHelpDesk);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", (smodel.IsDraftEvaluation == 0) ? 0 : smodel.IsDraftEvaluation);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
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

        public Tuple<bool, string> Update_ProjectRevocationCancellation_DiaryNumber(ClsPrp_ControlPanel_View_ProjectRevocationCancellation smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_revokedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_IndexID", (smodel.Revoke_RegDiaryNumber_IndexID == 0) ? 0 : smodel.Revoke_RegDiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_ID", (smodel.Revoke_RegDiaryNumber_ID == 0) ? 0 : smodel.Revoke_RegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_Name", String.IsNullOrEmpty(smodel.Revoke_RegDiaryNumber_Name) ? string.Empty : smodel.Revoke_RegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Revoke_RegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.Revoke_RegDiaryNumber_NameYear) ? string.Empty : smodel.Revoke_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_UserID", sUID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", sPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", sProject_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", sProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtnRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.ExtnRegDiaryNumber_Name) ? string.Empty : smodel.ExtnRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);
            cmd.Parameters.AddWithValue("p_Revoke_InfoDetails", String.IsNullOrEmpty(smodel.Revoke_InfoDetails) ? string.Empty : smodel.Revoke_InfoDetails);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceName", String.IsNullOrEmpty(smodel.Revoke_ReferenceName) ? string.Empty : smodel.Revoke_ReferenceName);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceDate", smodel.Revoke_ReferenceDate.HasValue ? smodel.Revoke_ReferenceDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Revoke_Category", String.IsNullOrEmpty(smodel.Revoke_Category) ? string.Empty : smodel.Revoke_Category);
            cmd.Parameters.AddWithValue("p_Revoke_ReciptType", String.IsNullOrEmpty(smodel.Revoke_ReciptType) ? string.Empty : smodel.Revoke_ReciptType);
            cmd.Parameters.AddWithValue("p_Revoke_Reasons", String.IsNullOrEmpty(smodel.Revoke_Reasons) ? string.Empty : smodel.Revoke_Reasons);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", (smodel.IsDraftHelpDesk == 0) ? 0 : smodel.IsDraftHelpDesk);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", (smodel.IsDraftEvaluation == 0) ? 0 : smodel.IsDraftEvaluation);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
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

        //Status of PCC
        public List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> Display_CP_ProjectCompletionStatusDetails_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectCompletionCertificateStatus_ByID", con);
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
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails
                    {
                        ProjectCompletionEventAction_ID = Convert.ToInt64(dr["ProjectCompletionEventAction_ID"]),
                        EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
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

                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                        PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                        RERAnumberRegistration_Input = Convert.ToString(dr["RERAnumberRegistration_Input"]),
                    });
            }
            return CPstatusList;
        }
    }
}