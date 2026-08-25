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
    public class ClsMethod_View_CP_UserManagerList
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Display User Lists of Web-Portal 
        public List<ClsPrp_ControlPanel_View_UserManagerList> Display_CP_UserManager_ByIDandUserRole(Int64 pRequestID, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_UserManagerList> CPuserList = new List<ClsPrp_ControlPanel_View_UserManagerList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_UsersList_ByID", con);
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
                    new ClsPrp_ControlPanel_View_UserManagerList
                    {
                        UserManagerAuthority_IndexID = Convert.ToInt64(dr["UserManagerAuthority_IndexID"]),
                        UserManagerAuthority_ID = Convert.ToInt64(dr["UserManagerAuthority_ID"]),

                        rolesId = Convert.ToString(dr["rolesId"]),
                        rolesName = Convert.ToString(dr["rolesName"]),

                        usersId = Convert.ToString(dr["usersId"]),
                        usersEmail = Convert.ToString(dr["usersEmail"]),
                        usersEmailConfirmed = Convert.ToInt32(dr["usersEmailConfirmed"]),                        
                        usersPhoneNumber = String.IsNullOrEmpty(Convert.ToString(dr["usersPhoneNumber"]))? "0": Convert.ToString(dr["usersPhoneNumber"]),
                        usersPhoneNumberConfirmed = Convert.ToInt32(dr["usersPhoneNumberConfirmed"]),
                        usersTwoFactorEnabled = Convert.ToInt32(dr["usersTwoFactorEnabled"]),
                        usersLockoutEndDateUtc = Convert.ToDateTime(dr["usersLockoutEndDateUtc"]),
                        usersLockoutEnabled = Convert.ToInt32(dr["usersLockoutEnabled"]),
                        usersAccessFailedCount = Convert.ToInt32(dr["usersAccessFailedCount"]),
                        usersUserName = Convert.ToString(dr["usersUserName"]),

                        userrolesUserId = Convert.ToString(dr["userrolesUserId"]),
                        userrolesRoleId = Convert.ToString(dr["userrolesRoleId"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                    });
            }
            return CPuserList;
        }
        public List<ClsPrp_ControlPanel_View_UserManagerList> Display_CP_UserManager_ByIDandUserRoleByFilter(string inprmUserIDrole, Int32 inprmIsApplicationModeFlag, Int32 inprmIsApplicationOptionFlag, string inprmInputEntry_EmailID, string inprmInputEntry_UName)
        {
            connection();
            List<ClsPrp_ControlPanel_View_UserManagerList> CPuserList = new List<ClsPrp_ControlPanel_View_UserManagerList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_UsersList_ByIDFilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inprmIsApplicationModeFlag);
            cmd.Parameters.AddWithValue("p_ApplicationOptionFlag", inprmIsApplicationOptionFlag);
            cmd.Parameters.AddWithValue("p_InputEntry_EmailID", inprmInputEntry_EmailID);
            cmd.Parameters.AddWithValue("p_InputEntry_UserName", inprmInputEntry_UName);
           
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_UserManagerList
                    {
                        UserManagerAuthority_IndexID = Convert.ToInt64(dr["UserManagerAuthority_IndexID"]),
                        UserManagerAuthority_ID = Convert.ToInt64(dr["UserManagerAuthority_ID"]),

                        rolesId = Convert.ToString(dr["rolesId"]),
                        rolesName = Convert.ToString(dr["rolesName"]),

                        usersId = Convert.ToString(dr["usersId"]),
                        usersEmail = Convert.ToString(dr["usersEmail"]),
                        usersEmailConfirmed = Convert.ToInt32(dr["usersEmailConfirmed"]),
                        usersPhoneNumber = String.IsNullOrEmpty(Convert.ToString(dr["usersPhoneNumber"])) ? "0" : Convert.ToString(dr["usersPhoneNumber"]),
                        usersPhoneNumberConfirmed = Convert.ToInt32(dr["usersPhoneNumberConfirmed"]),
                        usersTwoFactorEnabled = Convert.ToInt32(dr["usersTwoFactorEnabled"]),
                        usersLockoutEndDateUtc = Convert.ToDateTime(dr["usersLockoutEndDateUtc"]),
                        usersLockoutEnabled = Convert.ToInt32(dr["usersLockoutEnabled"]),
                        usersAccessFailedCount = Convert.ToInt32(dr["usersAccessFailedCount"]),
                        usersUserName = Convert.ToString(dr["usersUserName"]),

                        userrolesUserId = Convert.ToString(dr["userrolesUserId"]),
                        userrolesRoleId = Convert.ToString(dr["userrolesRoleId"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                    });
            }
            return CPuserList;
        }

        //Reset Password for User (Log History By Admin) 
        public Int32 AddLogHistory_ResetPasswordHandler_CP_UserManagerListByIndex(string RequestUserID, string RequestRefID, string RequestUserName, string RequestRoleID, string RequestEamilID, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_update_users_changepassword_loghistory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputUserID", RequestUserID);
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestRefID);
            cmd.Parameters.AddWithValue("p_InputUserName", RequestUserName);
            cmd.Parameters.AddWithValue("p_InputRoleID", RequestRoleID);
            cmd.Parameters.AddWithValue("p_InputEamilID", RequestEamilID);
            cmd.Parameters.AddWithValue("p_ByUserName", ByUserName);
            cmd.Parameters.AddWithValue("p_ByUserID", ByUserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 0;
        }

        //Lock-Unlock Web-Portal Lists
        public Int32 Update_LockUnlockHandler_CP_UserManagerListByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_webportalusersByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputUserID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRequestID", "0");
            cmd.Parameters.AddWithValue("p_InputUserName", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRoleID", RelatedRefID);
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
        public Int32 Update_EmailConfirmEnabledHandler_CP_UserManagerListByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string EmailConfirmCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setconfirmdisconfirm_webportalusersByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputUserID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRequestID", "0");
            cmd.Parameters.AddWithValue("p_InputUserName", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRoleID", RelatedRefID);
            cmd.Parameters.AddWithValue("p_InputEmailConfirmValue", EmailConfirmCode);
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

        //Reset Email and PhoneNumber
        public List<ClsPrp_ControlPanel_View_UserManagerList> Display_CP_UserDetails_ByUserRoleByID(string pUserRoleID, string pUserID, string pUserName, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_UserManagerList> CPuserList = new List<ClsPrp_ControlPanel_View_UserManagerList>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_UsersProfileDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRoleID", pUserRoleID);
            cmd.Parameters.AddWithValue("p_UserID", pUserID);
            cmd.Parameters.AddWithValue("p_UserName", pUserName);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_UserManagerList
                    {
                        UserManagerAuthority_IndexID = Convert.ToInt64(dr["UserManagerAuthority_IndexID"]),
                        UserManagerAuthority_ID = Convert.ToInt64(dr["UserManagerAuthority_ID"]),

                        rolesId = Convert.ToString(dr["rolesId"]),
                        rolesName = Convert.ToString(dr["rolesName"]),

                        usersId = Convert.ToString(dr["usersId"]),
                        usersEmail = Convert.ToString(dr["usersEmail"]),
                        usersEmailConfirmed = Convert.ToInt32(dr["usersEmailConfirmed"]),
                        usersPhoneNumber = String.IsNullOrEmpty(Convert.ToString(dr["usersPhoneNumber"])) ? "0" : Convert.ToString(dr["usersPhoneNumber"]),
                        usersPhoneNumberConfirmed = Convert.ToInt32(dr["usersPhoneNumberConfirmed"]),
                        usersTwoFactorEnabled = Convert.ToInt32(dr["usersTwoFactorEnabled"]),
                        usersLockoutEndDateUtc = Convert.ToDateTime(dr["usersLockoutEndDateUtc"]),
                        usersLockoutEnabled = Convert.ToInt32(dr["usersLockoutEnabled"]),
                        usersAccessFailedCount = Convert.ToInt32(dr["usersAccessFailedCount"]),
                        usersUserName = Convert.ToString(dr["usersUserName"]),

                        userrolesUserId = Convert.ToString(dr["userrolesUserId"]),
                        userrolesRoleId = Convert.ToString(dr["userrolesRoleId"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                    });
            }
            return CPuserList;
        }

        public bool Update_UserProfileDetails_EmailPhoneNumberByUserRoleByID(ClsPrp_ControlPanel_View_UserManagerList smodel, string PreparedByUserID, string PreparedByUserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_update_users_emailphonenumber_additionals", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_UserManagerAuthority_IndexID", smodel.UserManagerAuthority_IndexID);
            cmd.Parameters.AddWithValue("p_UserManagerAuthority_ID", smodel.UserManagerAuthority_ID);
            cmd.Parameters.AddWithValue("p_rolesId", String.IsNullOrEmpty(smodel.rolesId) ? string.Empty : smodel.rolesId);
            cmd.Parameters.AddWithValue("p_rolesName", String.IsNullOrEmpty(smodel.rolesName) ? string.Empty : smodel.rolesName);
            cmd.Parameters.AddWithValue("p_usersId", String.IsNullOrEmpty(smodel.usersId) ? string.Empty : smodel.usersId);
            cmd.Parameters.AddWithValue("p_usersEmail", String.IsNullOrEmpty(smodel.usersEmail) ? string.Empty : smodel.usersEmail);
            cmd.Parameters.AddWithValue("p_usersEmailConfirmed", smodel.usersEmailConfirmed);
            cmd.Parameters.AddWithValue("p_usersPasswordHash", String.IsNullOrEmpty(smodel.usersPasswordHash) ? string.Empty : smodel.usersPasswordHash);
            cmd.Parameters.AddWithValue("p_usersSecurityStamp", String.IsNullOrEmpty(smodel.usersSecurityStamp) ? string.Empty : smodel.usersSecurityStamp);
            cmd.Parameters.AddWithValue("p_usersPhoneNumber", String.IsNullOrEmpty(smodel.usersPhoneNumber) ? string.Empty : smodel.usersPhoneNumber);
            cmd.Parameters.AddWithValue("p_usersPhoneNumberConfirmed", smodel.usersPhoneNumberConfirmed);
            cmd.Parameters.AddWithValue("p_usersTwoFactorEnabled", smodel.usersTwoFactorEnabled);
            cmd.Parameters.AddWithValue("p_usersLockoutEndDateUtc", smodel.usersLockoutEndDateUtc == null ? dtvalue : smodel.usersLockoutEndDateUtc);
            cmd.Parameters.AddWithValue("p_usersLockoutEnabled", smodel.usersLockoutEnabled);
            cmd.Parameters.AddWithValue("p_usersAccessFailedCount", smodel.usersAccessFailedCount);
            cmd.Parameters.AddWithValue("p_usersUserName", String.IsNullOrEmpty(smodel.usersUserName) ? string.Empty : smodel.usersUserName);
            cmd.Parameters.AddWithValue("p_userrolesUserId", String.IsNullOrEmpty(smodel.userrolesUserId) ? string.Empty : smodel.userrolesUserId);
            cmd.Parameters.AddWithValue("p_userrolesRoleId", String.IsNullOrEmpty(smodel.userrolesRoleId) ? string.Empty : smodel.userrolesRoleId);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", PreparedByUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", PreparedByUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return true;
            else
                return false;
        }

        //Check EmployeeID for User Registration
        public bool CheckAlreadyRegisteredEmployeeID(string pEmpID)
        {
            connection();
            bool rval = false;
            Int32 rvalcount = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_AlreadyRegisteredEmployeeID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_EmployeeID", pEmpID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                rvalcount = Convert.ToInt32(dr["p_CountEmployeeName"]);
            }

            //Already Exist EmpID
            if (rvalcount > 0) 
            {
                rval = true;
            }
            cmd.Dispose();
            con.Close();
            return rval;
        }

        public bool Update_UserProfileMasterDetails_ByUserID(ClsPrp_ControlPanel_View_UserManagerRegistration smodel, string PreparedByUserID, string PreparedByUserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_update_users_UserProfileDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_UserManagerAuthority_IndexID", smodel.UserManagerAuthority_IndexID);
            cmd.Parameters.AddWithValue("p_UserManagerAuthority_ID", smodel.UserManagerAuthority_ID);
            cmd.Parameters.AddWithValue("p_rolesId", String.IsNullOrEmpty(smodel.rolesId) ? string.Empty : smodel.rolesId);
            cmd.Parameters.AddWithValue("p_rolesName", String.IsNullOrEmpty(smodel.rolesName) ? string.Empty : smodel.rolesName);
            cmd.Parameters.AddWithValue("p_usersId", String.IsNullOrEmpty(smodel.usersId) ? string.Empty : smodel.usersId);
            cmd.Parameters.AddWithValue("p_usersEmail", String.IsNullOrEmpty(smodel.usersEmail) ? string.Empty : smodel.usersEmail);
            cmd.Parameters.AddWithValue("p_usersEmailConfirmed", smodel.usersEmailConfirmed);
            cmd.Parameters.AddWithValue("p_usersPasswordHash", String.IsNullOrEmpty(smodel.usersPasswordHash) ? string.Empty : smodel.usersPasswordHash);
            cmd.Parameters.AddWithValue("p_usersSecurityStamp", String.IsNullOrEmpty(smodel.usersSecurityStamp) ? string.Empty : smodel.usersSecurityStamp);
            cmd.Parameters.AddWithValue("p_usersPhoneNumber", String.IsNullOrEmpty(smodel.usersPhoneNumber) ? string.Empty : smodel.usersPhoneNumber);
            cmd.Parameters.AddWithValue("p_usersPhoneNumberConfirmed", smodel.usersPhoneNumberConfirmed);
            cmd.Parameters.AddWithValue("p_usersTwoFactorEnabled", smodel.usersTwoFactorEnabled);
            cmd.Parameters.AddWithValue("p_usersLockoutEndDateUtc", smodel.usersLockoutEndDateUtc == null ? dtvalue : smodel.usersLockoutEndDateUtc);
            cmd.Parameters.AddWithValue("p_usersLockoutEnabled", smodel.usersLockoutEnabled);
            cmd.Parameters.AddWithValue("p_usersAccessFailedCount", smodel.usersAccessFailedCount);
            cmd.Parameters.AddWithValue("p_usersUserName", String.IsNullOrEmpty(smodel.usersUserName) ? string.Empty : smodel.usersUserName);
            cmd.Parameters.AddWithValue("p_userrolesUserId", String.IsNullOrEmpty(smodel.userrolesUserId) ? string.Empty : smodel.userrolesUserId);
            cmd.Parameters.AddWithValue("p_userrolesRoleId", String.IsNullOrEmpty(smodel.userrolesRoleId) ? string.Empty : smodel.userrolesRoleId);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", PreparedByUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", PreparedByUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            cmd.Parameters.AddWithValue("p_IsApplicationModeFlag", smodel.IsApplicationModeFlag);
            cmd.Parameters.AddWithValue("p_Input_EmployeeProfileID", String.IsNullOrEmpty(smodel.Input_EmployeeProfileID) ? string.Empty : smodel.Input_EmployeeProfileID);
            cmd.Parameters.AddWithValue("p_Input_EmployeeName", String.IsNullOrEmpty(smodel.Input_EmployeeName) ? string.Empty : smodel.Input_EmployeeName);
            cmd.Parameters.AddWithValue("p_Input_UserName", String.IsNullOrEmpty(smodel.Input_UserName) ? string.Empty : smodel.Input_UserName);
            cmd.Parameters.AddWithValue("p_Input_Password", String.IsNullOrEmpty(smodel.Input_Password) ? string.Empty : smodel.Input_Password);            
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 150);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = Convert.ToString(AppPar.Value);
            con.Close();

            if (i >= 0)
                return true;
            else
                return false;
        }
    }
}