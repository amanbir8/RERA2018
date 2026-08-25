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
    public class ClsMethod_View_CP_UserManagerSearchRecords
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Display User Lists of Web-Portal 
        public List<ClsPrp_ControlPanel_View_UserManagerUserRegistration> Display_CP_UserManager_RegistrationsByIDandUserRole(Int32 pUserTypeFlag, Int32 pUserOptionsFlag, Int32 pUserOptionsComplaintType, string pUserReferenceNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_UserManagerUserRegistration> CPuserList = new List<ClsPrp_ControlPanel_View_UserManagerUserRegistration>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_UserRegistrationsList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserType_Flag", pUserTypeFlag);
            cmd.Parameters.AddWithValue("p_UserOptions_Flag", pUserOptionsFlag);
            cmd.Parameters.AddWithValue("p_UserOptions_ComplaintType", pUserOptionsComplaintType);
            cmd.Parameters.AddWithValue("p_UserReferenceNumber", pUserReferenceNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_UserManagerUserRegistration
                    {
                        mUserManagerAuthority_IndexID = Convert.ToInt64(dr["mUserManagerAuthority_IndexID"]),
                        mUserManagerAuthority_ID = Convert.ToInt64(dr["mUserManagerAuthority_ID"]),
                        mrolesId = Convert.ToString(dr["mrolesId"]),
                        mrolesName = Convert.ToString(dr["mrolesName"]),
                        musersId = Convert.ToString(dr["musersId"]),
                        musersEmail = Convert.ToString(dr["musersEmail"]),
                        musersEmailConfirmed = Convert.ToInt32(dr["musersEmailConfirmed"]),
                        musersPasswordHash = Convert.ToString(dr["musersPasswordHash"]),
                        musersSecurityStamp = Convert.ToString(dr["musersSecurityStamp"]),
                        musersPhoneNumber = String.IsNullOrEmpty(Convert.ToString(dr["musersPhoneNumber"])) ? "0" : Convert.ToString(dr["musersPhoneNumber"]),
                        musersPhoneNumberConfirmed = Convert.ToInt32(dr["musersPhoneNumberConfirmed"]),
                        musersTwoFactorEnabled = Convert.ToInt32(dr["musersTwoFactorEnabled"]),
                        musersLockoutEndDateUtc = Convert.ToDateTime(dr["musersLockoutEndDateUtc"]),
                        musersLockoutEnabled = Convert.ToInt32(dr["musersLockoutEnabled"]),
                        musersAccessFailedCount = Convert.ToInt32(dr["musersAccessFailedCount"]),
                        musersUserName = Convert.ToString(dr["musersUserName"]),
                        muserrolesUserId = Convert.ToString(dr["muserrolesUserId"]),
                        muserrolesRoleId = Convert.ToString(dr["muserrolesRoleId"]),
                        mA_column = Convert.ToString(dr["mA_column"]),
                        mB_column = Convert.ToString(dr["mB_column"]),
                        mIsActive = Convert.ToInt32(dr["mIsActive"]),
                        mIsDraft = Convert.ToInt32(dr["mIsDraft"]),
                        mCreatedBy = Convert.ToString(dr["mCreatedBy"]),
                        mCreatedOn = Convert.ToDateTime(dr["mCreatedOn"]),
                        mModifyBy = Convert.ToString(dr["mModifyBy"]),
                        mModifyOn = Convert.ToDateTime(dr["mModifyOn"]),
                        mRoleAccessFlag = Convert.ToString(dr["mRoleAccessFlag"]),
                        InputEntry_UserTypeFlag = Convert.ToInt32(dr["InputEntry_UserTypeFlag"]),
                        InputEntry_ApplicationModeFlag = Convert.ToInt32(dr["InputEntry_ApplicationModeFlag"]),
                        InputEntry_ComplaintModeFlag = Convert.ToInt32(dr["InputEntry_ComplaintModeFlag"]),
                        InputEntry_ReferenceNumber = Convert.ToString(dr["InputEntry_ReferenceNumber"]),
                    });
            }
            return CPuserList;
        }

    }
}