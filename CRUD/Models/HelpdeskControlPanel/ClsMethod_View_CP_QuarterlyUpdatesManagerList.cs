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
    public class ClsMethod_View_CP_QuarterlyUpdatesManagerList
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Display QUP Lists of Web-Portal 
        public List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList> Display_CP_QuarterlyUpdatesManager_ByIDandUserRole(Int64 pRequestID, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList> CPuserList = new List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_QuarterlyUpdatesProviderList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RequestID", pRequestID);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_QuarterlyUpdatesList
                    {
                        QUpdateProject_RegDNProvider_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDNProvider_IndexID"]),
                        QUpdateProject_RegDNProvider_ID = Convert.ToInt64(dr["QUpdateProject_RegDNProvider_ID"]),
                        QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                        QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        PromoterID = Convert.ToInt64(dr["PromoterID"]),
                        ProjectID = Convert.ToInt64(dr["ProjectID"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToDateTime(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? "0" : Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return CPuserList;
        }
        public List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList> Display_CP_QuarterlyUpdatesManager_ByIDandUserRoleByFilter(string inUserIDrole, Int32 inIsApplicationModeFlag, Int32 inInputEntry_QuarterYear, string inInputEntry_QuarterName)
        {
            connection();
            List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList> CPuserList = new List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_QuarterlyUpdatesProviderList_ByIDFilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", inUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inIsApplicationModeFlag);            
            cmd.Parameters.AddWithValue("p_InputEntry_QuarterYear", inInputEntry_QuarterYear);
            cmd.Parameters.AddWithValue("p_InputEntry_QuarterName", inInputEntry_QuarterName);
           
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_QuarterlyUpdatesList
                    {
                        QUpdateProject_RegDNProvider_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDNProvider_IndexID"]),
                        QUpdateProject_RegDNProvider_ID = Convert.ToInt64(dr["QUpdateProject_RegDNProvider_ID"]),
                        QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                        QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        PromoterID = Convert.ToInt64(dr["PromoterID"]),
                        ProjectID = Convert.ToInt64(dr["ProjectID"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToDateTime(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? "0" : Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return CPuserList;
        }

        //Lock-Unlock Web-Portal Lists
        public Int32 Update_LockUnlockHandler_CP_QuarterlyUpdateManagerListByIndex(string RelatedRefIndexID, string RequestID, string RelatedRefYear, string RelatedRefName, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_quarterlyupdateByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefYear", RelatedRefYear);
            cmd.Parameters.AddWithValue("p_InputRefName", RelatedRefName);
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
        public Int32 Update_LockedConfirmEnabledHandler_CP_QuarterlyUpdateManagerListByIndex(string RelatedRefIndexID, string RequestID, string RelatedRefYear, string RelatedRefName, string LockedConfirmCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setconfirmdisconfirm_quarterlyupdateByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefYear", RelatedRefYear);
            cmd.Parameters.AddWithValue("p_InputRefName", RelatedRefName);
            cmd.Parameters.AddWithValue("p_InputLockedConfirmValue", LockedConfirmCode);
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


        //Extract QUPs Search list 
        public List<ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile> Display_CP_QuarterlyUpdatesManager_StatusDetails_ByID(string inRERAcode, Int32 inApplicationMode, Int32 inQuarterYear, string inQuarterName, string inUserCode)
        {
            connection();
            List<ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile> CPuserList = new List<ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_QuarterlyUpdatesLockStatusDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RequestRERAcode", inRERAcode);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inApplicationMode);
            cmd.Parameters.AddWithValue("p_InputEntry_QuarterYear", inQuarterYear);
            cmd.Parameters.AddWithValue("p_InputEntry_QuarterName", inQuarterName);
            cmd.Parameters.AddWithValue("p_UserCode", inUserCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile
                    {                       
                        QUP_ProjectProvider_IndexID = (dr["QUP_ProjectProvider_IndexID"] is DBNull) ? 0 : Convert.ToInt64(dr["QUP_ProjectProvider_IndexID"]),
                        QUP_ProjectProvider_ID = (dr["QUP_ProjectProvider_ID"] is DBNull) ? 0 : Convert.ToInt64(dr["QUP_ProjectProvider_ID"]),
                        QUpdateProject_Year = (dr["QUpdateProject_Year"] is DBNull) ? 0 : Convert.ToInt32(dr["QUpdateProject_Year"]),
                        QUpdateProject_QuarterName = String.IsNullOrEmpty(Convert.ToString(dr["QUpdateProject_QuarterName"])) ? "NA" : Convert.ToString(dr["QUpdateProject_QuarterName"]),

                        UserID = String.IsNullOrEmpty(Convert.ToString(dr["UserID"])) ? string.Empty : Convert.ToString(dr["UserID"]),
                        PromoterID = (dr["PromoterID"] is DBNull) ? 0 : Convert.ToInt64(dr["PromoterID"]),
                        ProjectID = (dr["ProjectID"] is DBNull) ? 0 : Convert.ToInt64(dr["ProjectID"]),
                        RERA_RegistrationID = String.IsNullOrEmpty(Convert.ToString(dr["RERA_RegistrationID"])) ? string.Empty : Convert.ToString(dr["RERA_RegistrationID"]),
                        DiaryNumber_Project = String.IsNullOrEmpty(Convert.ToString(dr["DiaryNumber_Project"])) ? string.Empty : Convert.ToString(dr["DiaryNumber_Project"]),
                        DiaryNumber_ExtensionProject = String.IsNullOrEmpty(Convert.ToString(dr["DiaryNumber_ExtensionProject"])) ? string.Empty : Convert.ToString(dr["DiaryNumber_ExtensionProject"]),
                        ReferenceNumber = String.IsNullOrEmpty(Convert.ToString(dr["ReferenceNumber"])) ? string.Empty : Convert.ToString(dr["ReferenceNumber"]),
                        ReferenceDate = (dr["ReferenceDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["ReferenceDate"]),
                        Remarks_IfAny = String.IsNullOrEmpty(Convert.ToString(dr["Remarks_IfAny"])) ? string.Empty : Convert.ToString(dr["Remarks_IfAny"]),
                        Locked_From_Date = (dr["Locked_From_Date"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["Locked_From_Date"]),                        
                        Locked_To_Date = (dr["Locked_To_Date"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["Locked_To_Date"]),                        
                        A_column = String.IsNullOrEmpty(Convert.ToString(dr["A_column"])) ? string.Empty : Convert.ToString(dr["A_column"]),
                        B_column = String.IsNullOrEmpty(Convert.ToString(dr["B_column"])) ? string.Empty : Convert.ToString(dr["B_column"]),
                        C_column = String.IsNullOrEmpty(Convert.ToString(dr["C_column"])) ? string.Empty : Convert.ToString(dr["C_column"]),

                        IsActive = (dr["IsActive"] is DBNull) ? 0 : Convert.ToInt32(dr["IsActive"]),
                        IsDraft = (dr["IsDraft"] is DBNull) ? 0 : Convert.ToInt32(dr["IsDraft"]),
                        IsDraftSecMember = (dr["IsDraftSecMember"] is DBNull) ? 0 : Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = (dr["IsDraftMember"] is DBNull) ? 0 : Convert.ToInt32(dr["IsDraftMember"]),
                        IsActiveProvider = (dr["IsActiveProvider"] is DBNull) ? 0 : Convert.ToInt32(dr["IsActiveProvider"]),
                        IsLock = (dr["IsLock"] is DBNull) ? 0 : Convert.ToInt32(dr["IsLock"]),

                        CreatedBy = String.IsNullOrEmpty(Convert.ToString(dr["CreatedBy"])) ? string.Empty : Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = (dr["CreatedOn"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = String.IsNullOrEmpty(Convert.ToString(dr["ModifyBy"])) ? string.Empty : Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = (dr["ModifyOn"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["ModifyOn"]),

                        RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                        RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),
                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                        ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),
                        ExtensionRegdDiaryNumber = Convert.ToString(dr["ExtensionRegdDiaryNumber"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                        DName = Convert.ToString(dr["DName"]),
                        ProjectType = Convert.ToString(dr["ProjectType"]),

                        IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                        InputEntry_QuarterYear = Convert.ToInt32(dr["InputEntry_QuarterYear"]),
                        InputEntry_QuarterName = Convert.ToString(dr["InputEntry_QuarterName"]),
                        InputEntry_RegistrationNumber = Convert.ToString(dr["InputEntry_RegistrationNumber"]),
                    });
            }
            return CPuserList;
        }
        public Tuple<bool, string> Add_QuarterlyUpdateStatusDetails(ClsPrp_ControlPanel_View_QuarterlyUpdatesApplyFile smodel, string User_Name, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_quarterlyupdate_applystatus", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUP_ProjectProvider_IndexID", (smodel.QUP_ProjectProvider_IndexID == 0) ? 0 : smodel.QUP_ProjectProvider_IndexID);
            cmd.Parameters.AddWithValue("p_QUP_ProjectProvider_ID", (smodel.QUP_ProjectProvider_ID == 0) ? 0 : smodel.QUP_ProjectProvider_ID);
            cmd.Parameters.AddWithValue("p_QUpdateProject_Year", (smodel.QUpdateProject_Year == 0) ? 0 : smodel.QUpdateProject_Year);
            cmd.Parameters.AddWithValue("p_QUpdateProject_QuarterName", String.IsNullOrEmpty(smodel.QUpdateProject_QuarterName) ? string.Empty : smodel.QUpdateProject_QuarterName);

            cmd.Parameters.AddWithValue("p_UserID", String.IsNullOrEmpty(smodel.UserID) ? string.Empty : smodel.UserID);
            cmd.Parameters.AddWithValue("p_PromoterID", (smodel.PromoterID == 0) ? 0 : smodel.PromoterID);
            cmd.Parameters.AddWithValue("p_ProjectID", (smodel.ProjectID == 0) ? 0 : smodel.ProjectID);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationID", String.IsNullOrEmpty(smodel.RERA_RegistrationID) ? string.Empty : smodel.RERA_RegistrationID);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", String.IsNullOrEmpty(smodel.DiaryNumber_Project) ? string.Empty : smodel.DiaryNumber_Project);
            cmd.Parameters.AddWithValue("p_DiaryNumber_ExtensionProject", String.IsNullOrEmpty(smodel.DiaryNumber_ExtensionProject) ? string.Empty : smodel.DiaryNumber_ExtensionProject);
            cmd.Parameters.AddWithValue("p_ReferenceNumber", String.IsNullOrEmpty(smodel.ReferenceNumber) ? string.Empty : smodel.ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ReferenceDate", (smodel.ProjectID == 0) ? DateTime.MinValue : smodel.ReferenceDate);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Locked_From_Date", (smodel.ProjectID == 0) ? DateTime.MinValue : smodel.Locked_From_Date);
            cmd.Parameters.AddWithValue("p_Locked_To_Date", (smodel.ProjectID == 0) ? DateTime.MinValue : smodel.Locked_To_Date);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", (smodel.IsActiveProvider == 0) ? 0 : smodel.IsActiveProvider);
            cmd.Parameters.AddWithValue("p_IsLock", (smodel.IsLock == 0) ? 0 : smodel.IsLock);

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