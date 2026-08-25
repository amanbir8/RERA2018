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
    public class ClsMethod_View_CP_UserManagerAuthority
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_UserManagerAuthority> Display_CP_UserManagerAuthority_ByIDandUserRole(Int64 pRequestID, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_UserManagerAuthority> CPuserList = new List<ClsPrp_ControlPanel_View_UserManagerAuthority>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_AuthorityUsersList_ByID", con);
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
                    new ClsPrp_ControlPanel_View_UserManagerAuthority
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

        public Int32 Update_LockUnlockHandler_CP_UserManagerAuthorityByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_usersByIndex", con);
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

        public Int32 Update_EmailConfirmEnabledHandler_CP_UserManagerAuthorityByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string EmailConfirmCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setconfirmdisconfirm_usersByIndex", con);
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
    }
}