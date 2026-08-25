using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_ExtensionProjectExtensionFormDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormDetails> Display_Project_ExtensionFormDetails(Int64 ProjectRegistration_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormDetails> Projectlist = new List<ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ExtensionFormDetailsForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ExtensionForm_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_AuthDesk_View_ExtensionProjectExtensionFormDetails
                       {
                           FormE_IndexID = Convert.ToInt64(dr["FormE_IndexID"]),
                           FormE_ID = Convert.ToInt64(dr["FormE_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),

                           ProjectExtension_NameID = Convert.ToInt64(dr["ProjectExtension_NameID"]),
                           ProjectExtension_NameYear = Convert.ToInt32(dr["ProjectExtension_NameYear"]),
                           ProjectExtension_Name = Convert.ToString(dr["ProjectExtension_Name"]),

                           Project_DiaryNumberID = Convert.ToString(dr["Project_DiaryNumberID"]),
                           Project_RERAnumber = Convert.ToString(dr["Project_RERAnumber"]),
                           Project_RERANumberIssueDate = Convert.ToDateTime(dr["Project_RERANumberIssueDate"]),
                           Project_RERANumberValiduptoDate = Convert.ToDateTime(dr["Project_RERANumberValiduptoDate"]),

                           FormE_DocIssueDate = Convert.ToDateTime(dr["FormE_DocIssueDate"]),
                           FormE_ExtensionAppliedReason = Convert.ToString(dr["FormE_ExtensionAppliedReason"]),
                           FormE_ExtensionAppliedReasonSpecifyOthers = Convert.ToString(dr["FormE_ExtensionAppliedReasonSpecifyOthers"]),

                           FormE_DocInfoCode = Convert.ToInt32(dr["FormE_DocInfoCode"]),
                           FormE_DocInfoName = Convert.ToString(dr["FormE_DocInfoName"]),
                           FormE_DocRelatedSectionName = Convert.ToString(dr["FormE_DocRelatedSectionName"]),
                           FormE_DocReferenceNumber = Convert.ToString(dr["FormE_DocReferenceNumber"]),

                           FormE_DocFileSize = Convert.ToString(dr["FormE_DocFileSize"]),
                           FormE_DocFileFormat = Convert.ToString(dr["FormE_DocFileFormat"]),
                           FormE_DocFilePath = Convert.ToString(dr["FormE_DocFilePath"]),
                           FormE_DocFileName = Convert.ToString(dr["FormE_DocFileName"]),
                           FormE_DocIsGroup = Convert.ToInt32(dr["FormE_DocIsGroup"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           Summary_IfAny = Convert.ToString(dr["Summary_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsTemp = Convert.ToInt32(dr["IsTemp"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),                           
                       });
            }
            return Projectlist;
        }

        public Int32 Update_LockUnLockHandler_Project_SpecialBankAccountDetails(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_specialbankaccountdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_SpecialbankaccountIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);            
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
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