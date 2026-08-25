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
    public class ClsMethod_View_CP_ProjectLockUnlockManagerList
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Display LockUnlock Lists of Web-Portal 
        public List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList> Display_CP_ProjectLockUnlockManager_ByIDandUserRole(Int64 pRequestID, string pRequestCode, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList> CPuserList = new List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectLockUnlockProviderList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RequestID", pRequestID);
            cmd.Parameters.AddWithValue("p_RequestCode", pRequestCode);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList
                    {
                        PrjSuperLockUnlock_RegDNProvider_IndexID = Convert.ToInt64(dr["PrjSuperLockUnlock_RegDNProvider_IndexID"]),
                        PrjSuperLockUnlock_RegDNProvider_ID = Convert.ToInt64(dr["PrjSuperLockUnlock_RegDNProvider_ID"]),

                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_User_ID = Convert.ToString(dr["Related_User_ID"]),
                        Related_Reference_ID = Convert.ToInt64(dr["Related_Reference_ID"]),

                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                        Project_Name = Convert.ToString(dr["Project_Name"]),
                        Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                        ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                        RegDiary_ApplicationDate = Convert.ToDateTime(dr["RegDiary_ApplicationDate"]),

                        EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                        EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToDateTime(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? "0" : Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                        IsLockPromoterDN = Convert.ToInt32(dr["IsLockPromoterDN"]),
                        IsLockProjectDN = Convert.ToInt32(dr["IsLockProjectDN"]),
                        IsLockQtrDN = Convert.ToInt32(dr["IsLockQtrDN"]),
                        IsLockCoPromoterDn = Convert.ToInt32(dr["IsLockCoPromoterDn"]),
                        IsLockAdditional = Convert.ToInt32(dr["IsLockAdditional"]),
                        IsLockedConfirmed = Convert.ToInt32(dr["IsLockedConfirmed"]),
                        IsLockedEnable = Convert.ToInt32(dr["IsLockedEnable"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        RoleAccessFlag = Convert.ToString(dr["RoleAccessFlag"]),
                        IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                        InputEntry_Option = Convert.ToString(dr["InputEntry_Option"]),
                    });
            }
            return CPuserList;
        }
        public List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList> Display_CP_ProjectLockUnlockManager_ByIDandUserRoleByFilter(Int64 pRequestID, string pRequestCode, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList> CPuserList = new List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectLockUnlockProviderList_ByIDFilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RequestID", pRequestID);
            cmd.Parameters.AddWithValue("p_RequestCode", pRequestCode);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList
                    {
                        PrjSuperLockUnlock_RegDNProvider_IndexID = Convert.ToInt64(dr["PrjSuperLockUnlock_RegDNProvider_IndexID"]),
                        PrjSuperLockUnlock_RegDNProvider_ID = Convert.ToInt64(dr["PrjSuperLockUnlock_RegDNProvider_ID"]),

                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_User_ID = Convert.ToString(dr["Related_User_ID"]),
                        Related_Reference_ID = Convert.ToInt64(dr["Related_Reference_ID"]),

                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                        Project_Name = Convert.ToString(dr["Project_Name"]),
                        Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                        ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                        RegDiary_ApplicationDate = Convert.ToDateTime(dr["RegDiary_ApplicationDate"]),

                        EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                        EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToDateTime(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? "0" : Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                        IsLockPromoterDN = Convert.ToInt32(dr["IsLockPromoterDN"]),
                        IsLockProjectDN = Convert.ToInt32(dr["IsLockProjectDN"]),
                        IsLockQtrDN = Convert.ToInt32(dr["IsLockQtrDN"]),
                        IsLockCoPromoterDn = Convert.ToInt32(dr["IsLockCoPromoterDn"]),
                        IsLockAdditional = Convert.ToInt32(dr["IsLockAdditional"]),
                        IsLockedConfirmed = Convert.ToInt32(dr["IsLockedConfirmed"]),
                        IsLockedEnable = Convert.ToInt32(dr["IsLockedEnable"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        RoleAccessFlag = Convert.ToString(dr["RoleAccessFlag"]),
                        IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                        InputEntry_Option = Convert.ToString(dr["InputEntry_Option"]),
                    });
            }
            return CPuserList;
        }

        //Lock-Unlock Web-Portal Lists
        public Int32 Update_LockUnlockHandler_CP_ProjectLockUnlockManagerListByIndex(string RelatedRefIndexID, string RequestID, string RelatedRefPromoterID, string RelatedRefProjectID, string RelatedReferenceID, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_projecteditsuperlockByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefPromoterID", RelatedRefPromoterID);
            cmd.Parameters.AddWithValue("p_InputRefProjectID", RelatedRefProjectID);
            cmd.Parameters.AddWithValue("p_InputReferenceID", RelatedReferenceID);            
            cmd.Parameters.AddWithValue("p_InputLockUnlockValue", LockUnlockCode);
            cmd.Parameters.AddWithValue("p_ByUserName", ByUserName);
            cmd.Parameters.AddWithValue("p_ByUserID", ByUserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
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
        public Int32 Update_LockedConfirmEnabledHandler_CP_PromoterSuperLockUnlockManagerListByIndex(string RelatedRefIndexID, string RequestID, string RelatedRefPromoterID, string RelatedRefProjectID, string RelatedReferenceID, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_projecteditpromotersuperlockByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefPromoterID", RelatedRefPromoterID);
            cmd.Parameters.AddWithValue("p_InputRefProjectID", RelatedRefProjectID);
            cmd.Parameters.AddWithValue("p_InputReferenceID", RelatedReferenceID);
            cmd.Parameters.AddWithValue("p_InputLockUnlockValue", LockUnlockCode);
            cmd.Parameters.AddWithValue("p_ByUserName", ByUserName);
            cmd.Parameters.AddWithValue("p_ByUserID", ByUserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
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
        public Int32 Update_LockedConfirmEnabledHandler_CP_ProjectSuperLockUnlockManagerListByIndex(string RelatedRefIndexID, string RequestID, string RelatedRefPromoterID, string RelatedRefProjectID, string RelatedReferenceID, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_projecteditprojectsuperlockByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefPromoterID", RelatedRefPromoterID);
            cmd.Parameters.AddWithValue("p_InputRefProjectID", RelatedRefProjectID);
            cmd.Parameters.AddWithValue("p_InputReferenceID", RelatedReferenceID);
            cmd.Parameters.AddWithValue("p_InputLockUnlockValue", LockUnlockCode);
            cmd.Parameters.AddWithValue("p_ByUserName", ByUserName);
            cmd.Parameters.AddWithValue("p_ByUserID", ByUserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
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

        //Extract Lock-Unlock Search list
        public List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList> Display_CP_ProjectLockUnlockManager_StatusDetails_ByID(Int32 inApplicationMode, Int32 inRequestRefMode, string inRegistrationID, string inDiaryID, string inUserCode)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList> CPuserList = new List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectEditLockUnlockStatusDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inApplicationMode);
            cmd.Parameters.AddWithValue("p_RequestRefMode", inRequestRefMode);
            cmd.Parameters.AddWithValue("p_Input_RegistrationID", inRegistrationID);            
            cmd.Parameters.AddWithValue("p_Input_DiaryID", inDiaryID);            
            cmd.Parameters.AddWithValue("p_UserCode", inUserCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_ProjectSuperLockUnlockList
                    {
                        PrjSuperLockUnlock_RegDNProvider_IndexID = (dr["PrjSuperLockUnlock_RegDNProvider_IndexID"] is DBNull) ? 0 : Convert.ToInt64(dr["PrjSuperLockUnlock_RegDNProvider_IndexID"]),
                        PrjSuperLockUnlock_RegDNProvider_ID = (dr["PrjSuperLockUnlock_RegDNProvider_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["PrjSuperLockUnlock_RegDNProvider_ID"]),

                        Related_Promoter_ID = (dr["Related_Promoter_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = (dr["Related_Project_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_User_ID = String.IsNullOrEmpty(Convert.ToString(dr["Related_User_ID"])) ? "NA" : Convert.ToString(dr["Related_User_ID"]),
                        Related_Reference_ID = (dr["Related_Reference_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Related_Reference_ID"]),

                        RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["RERAnumberRegistration"])) ? "NA" : Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = (dr["RERAnumberIssueDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = (dr["RERAnumberRegUptoDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                        Project_Name = String.IsNullOrEmpty(Convert.ToString(dr["Project_Name"])) ? "NA" : Convert.ToString(dr["Project_Name"]),
                        Promoter_Name = String.IsNullOrEmpty(Convert.ToString(dr["Promoter_Name"])) ? "NA" : Convert.ToString(dr["Promoter_Name"]),
                        ProjectRegDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["ProjectRegDiaryNumber_Name"])) ? "NA" : Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                        RegDiary_ApplicationDate = (dr["RegDiary_ApplicationDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RegDiary_ApplicationDate"]),

                        EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                        EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToDateTime(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? "0" : Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                        IsLockPromoterDN = Convert.ToInt32(dr["IsLockPromoterDN"]),
                        IsLockProjectDN = Convert.ToInt32(dr["IsLockProjectDN"]),
                        IsLockQtrDN = Convert.ToInt32(dr["IsLockQtrDN"]),
                        IsLockCoPromoterDn = Convert.ToInt32(dr["IsLockCoPromoterDn"]),
                        IsLockAdditional = Convert.ToInt32(dr["IsLockAdditional"]),
                        IsLockedConfirmed = Convert.ToInt32(dr["IsLockedConfirmed"]),
                        IsLockedEnable = Convert.ToInt32(dr["IsLockedEnable"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        RoleAccessFlag = Convert.ToString(dr["RoleAccessFlag"]),
                        IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                        InputEntry_Option = Convert.ToString(dr["InputEntry_Option"]),
                    });
            }
            return CPuserList;
        }
        public List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm> Display_CP_ProjectLockUnlockApplyConfirm_StatusDetails_ByID(string inRequestFlag, Int64 inRequestPromoterID, Int64 inRequestProjectID, string inDiaryNumber, string inRequestIndexID, string inRequestCodeID, string inUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm> CPuserList = new List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectEditLockUnlockStatusApplyConfirm_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RequestFlag", inRequestFlag);
            cmd.Parameters.AddWithValue("p_RequestPromoterID", inRequestPromoterID);
            cmd.Parameters.AddWithValue("p_RequestProjectID", inRequestProjectID);
            cmd.Parameters.AddWithValue("p_DiaryNumber", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_RequestIndexID", inRequestIndexID);
            cmd.Parameters.AddWithValue("p_RequestCodeID", inRequestCodeID);
            cmd.Parameters.AddWithValue("p_UserRole", inUserRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm
                    {
                        Project_ApplySuperLockUnlock_IndexID = (dr["Project_ApplySuperLockUnlock_IndexID"] is DBNull) ? 0 : Convert.ToInt64(dr["Project_ApplySuperLockUnlock_IndexID"]),
                        Project_ApplySuperLockUnlock_ID = (dr["Project_ApplySuperLockUnlock_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Project_ApplySuperLockUnlock_ID"]),

                        Related_Promoter_ID = (dr["Related_Promoter_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = (dr["Related_Project_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_User_ID = String.IsNullOrEmpty(Convert.ToString(dr["Related_User_ID"])) ? "NA" : Convert.ToString(dr["Related_User_ID"]),
                        Related_Reference_ID = (dr["Related_Reference_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["Related_Reference_ID"]),

                        Project_Name = String.IsNullOrEmpty(Convert.ToString(dr["Project_Name"])) ? "NA" : Convert.ToString(dr["Project_Name"]),
                        Promoter_Name = String.IsNullOrEmpty(Convert.ToString(dr["Promoter_Name"])) ? "NA" : Convert.ToString(dr["Promoter_Name"]),
                        RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["RERAnumberRegistration"])) ? "NA" : Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = (dr["RERAnumberIssueDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = (dr["RERAnumberRegUptoDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        ProjectRegDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["ProjectRegDiaryNumber_Name"])) ? "NA" : Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                        RegDiary_ApplicationDate = (dr["RegDiary_ApplicationDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RegDiary_ApplicationDate"]),

                        A_column = (dr["A_column"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? "0" : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? "0" : Convert.ToString(dr["C_column"]),

                        IsPromoterConfirmed = Convert.ToInt32(dr["IsPromoterConfirmed"]),
                        IsCoPromoterConfirmed = Convert.ToInt32(dr["IsCoPromoterConfirmed"]),
                        IsQuarterlyUpdatesConfirmed = Convert.ToInt32(dr["IsQuarterlyUpdatesConfirmed"]),
                        IsProjectConfirmed = Convert.ToInt32(dr["IsProjectConfirmed"]),

                        MappingYear = Convert.ToInt32(dr["MappingYear"]),
                        IsYearMappingConfirmed = Convert.ToInt32(dr["IsYearMappingConfirmed"]),

                        IsLockPromoterDN = Convert.ToInt32(dr["IsLockPromoterDN"]),
                        IsLockProjectDN = Convert.ToInt32(dr["IsLockProjectDN"]),
                        IsLockQtrDN = Convert.ToInt32(dr["IsLockQtrDN"]),
                        IsLockCoPromoterDn = Convert.ToInt32(dr["IsLockCoPromoterDn"]),
                        IsLockAdditional = Convert.ToInt32(dr["IsLockAdditional"]),
                        IsLockedConfirmed = Convert.ToInt32(dr["IsLockedConfirmed"]),
                        IsLockedEnable = Convert.ToInt32(dr["IsLockedEnable"]),

                        RoleAccessFlag = Convert.ToString(dr["RoleAccessFlag"]),
                        Application_SearchTypeFlag = Convert.ToInt32(dr["Application_SearchTypeFlag"]),
                        InputEntry_RegistrationNumber = Convert.ToString(dr["InputEntry_RegistrationNumber"]),
                        InputEntry_ProjectDiaryNumber = Convert.ToString(dr["InputEntry_ProjectDiaryNumber"]),
                    });
            }
            return CPuserList;
        }

        //Lock-Unlock Confirm or Update
        public Tuple<bool, string> Add_Project_PromoterProfileDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_records_PromoterDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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
        public Tuple<bool, string> Add_Project_CoPromoterDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_records_CoPromoterDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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
        public Tuple<bool, string> Add_Project_ProjectDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_records_ProjectDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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
        public Tuple<bool, string> Add_Project_QuarterlyUpdatesDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_records_QuarterlyUpdateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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

        public Tuple<bool, string> Add_Project_QuarterlyUpdate_YearMappingDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_quarterlyupdate_YearMapping", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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
        public Tuple<bool, string> Add_Project_Registration_PromoterLockDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_registration_PromoterLock", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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
        public Tuple<bool, string> Add_Project_Registration_ProjectLockDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_registration_ProjectLock", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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
        public Tuple<bool, string> Add_Project_Registration_QuarterlyUpdatesLockDetails(ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm smodel, Int64 inProjectID, Int64 inPromoterID, string inDiaryNumber, string inUser_Name, string inUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_cp_tbl_rera_project_registration_QuarterlyUpdateLock", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_IndexID", (smodel.Project_ApplySuperLockUnlock_IndexID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ApplySuperLockUnlock_ID", (smodel.Project_ApplySuperLockUnlock_ID == 0) ? 0 : smodel.Project_ApplySuperLockUnlock_ID);
            cmd.Parameters.AddWithValue("p_PromoterID", inPromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", inProjectID);
            cmd.Parameters.AddWithValue("p_UserID", inUID);
            cmd.Parameters.AddWithValue("p_ReferenceID", (smodel.Related_Reference_ID == 0) ? 0 : smodel.Related_Reference_ID);

            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RegistrationIssueDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RegistrationValidUptoDate", (smodel.RERAnumberRegistration == "NA") ? DateTime.MinValue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", inDiaryNumber);
            cmd.Parameters.AddWithValue("p_ApplicationDate_Project", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.RegDiary_ApplicationDate);

            cmd.Parameters.AddWithValue("p_A_column", (smodel.Related_Project_ID == 0) ? DateTime.MinValue : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsPromoterConfirmed", (smodel.IsPromoterConfirmed == 0) ? 0 : smodel.IsPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsCoPromoterConfirmed", (smodel.IsCoPromoterConfirmed == 0) ? 0 : smodel.IsCoPromoterConfirmed);
            cmd.Parameters.AddWithValue("p_IsQuarterlyUpdatesConfirmed", (smodel.IsQuarterlyUpdatesConfirmed == 0) ? 0 : smodel.IsQuarterlyUpdatesConfirmed);
            cmd.Parameters.AddWithValue("p_IsProjectConfirmed", (smodel.IsProjectConfirmed == 0) ? 0 : smodel.IsProjectConfirmed);
            cmd.Parameters.AddWithValue("p_MappingYear", (smodel.MappingYear == 0) ? 0 : smodel.MappingYear);
            cmd.Parameters.AddWithValue("p_IsYearMappingConfirmed", (smodel.IsYearMappingConfirmed == 0) ? 0 : smodel.IsYearMappingConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockPromoterDN", (smodel.IsLockPromoterDN == 0) ? 0 : smodel.IsLockPromoterDN);
            cmd.Parameters.AddWithValue("p_IsLockProjectDN", (smodel.IsLockProjectDN == 0) ? 0 : smodel.IsLockProjectDN);
            cmd.Parameters.AddWithValue("p_IsLockQtrDN", (smodel.IsLockQtrDN == 0) ? 0 : smodel.IsLockQtrDN);
            cmd.Parameters.AddWithValue("p_IsLockCoPromoterDn", (smodel.IsLockCoPromoterDn == 0) ? 0 : smodel.IsLockCoPromoterDn);
            cmd.Parameters.AddWithValue("p_IsLockAdditional", (smodel.IsLockAdditional == 0) ? 0 : smodel.IsLockAdditional);
            cmd.Parameters.AddWithValue("p_IsLockedConfirmed", (smodel.IsLockedConfirmed == 0) ? 0 : smodel.IsLockedConfirmed);
            cmd.Parameters.AddWithValue("p_IsLockedEnable", (smodel.IsLockedEnable == 0) ? 0 : smodel.IsLockedEnable);

            cmd.Parameters.AddWithValue("p_CreatedBy", inUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", inUser_Name);
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