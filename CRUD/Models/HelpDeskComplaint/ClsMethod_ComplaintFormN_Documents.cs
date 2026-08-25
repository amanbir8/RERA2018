using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_ComplaintFormN_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_AuthorityDesk_FormN_Documents> Display_ComplaintFormN_Documents_ByComplaintFormNID_ForDesk(Int64? ComplaintFormN_ID)
        {
            connection();
            List<Clsprp_AuthorityDesk_FormN_Documents> ComplaintFormN_Documents = new List<Clsprp_AuthorityDesk_FormN_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_Documents_ComplaintN_ID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormN_Documents.Add(
                    new Clsprp_AuthorityDesk_FormN_Documents
                    {
                        ListEnclDocument_IndexID = Convert.ToInt64(dr["ListEnclDocument_IndexID"]),
                        ListEnclDocument_ID = Convert.ToInt64(dr["ListEnclDocument_ID"]),
                        ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                        ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                        Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),

                        ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                        ComplaintDoc_InfoCode = Convert.ToString(dr["ComplaintDoc_InfoCode"]),
                        ComplaintDoc_InfoName = Convert.ToString(dr["ComplaintDoc_InfoName"]),
                        ComplaintDoc_ReferenceNumber = Convert.ToString(dr["ComplaintDoc_ReferenceNumber"]),
                        ComplaintDoc_IssueDate = Convert.ToDateTime(dr["ComplaintDoc_IssueDate"]),

                        ComplaintDoc_FileSize = Convert.ToString(dr["ComplaintDoc_FileSize"]),
                        ComplaintDoc_FileFormat = Convert.ToString(dr["ComplaintDoc_FileFormat"]),
                        ComplaintDoc_FilePath = Convert.ToString(dr["ComplaintDoc_FilePath"]),
                        ComplaintDoc_FileName = Convert.ToString(dr["ComplaintDoc_FileName"]),
                        ComplaintDoc_IsGroup = Convert.ToInt32(dr["ComplaintDoc_IsGroup"]),

                        Doc_SerialNumber = Convert.ToString(dr["Doc_SerialNumber"]),
                        Doc_PageStartNumber = Convert.ToInt32(dr["Doc_PageStartNumber"]),
                        Doc_PageEndNumber = Convert.ToInt32(dr["Doc_PageEndNumber"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),                        

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return ComplaintFormN_Documents;
        }
        
        public Int32 Update_LockUnLockHandler_FormNcomplaint_DocumentsListDetails(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormNcomplaint_documentslistdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
            cmd.Parameters.AddWithValue("p_RelatedComplaintID", RelatedComplaintID);
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

        public Int32 Update_LockUnLockHandler_FormNcomplaint_DocumentDetailsByIndex(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg, Int64 IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormNcomplaint_documentdetailsbyindex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
            cmd.Parameters.AddWithValue("p_RelatedComplaintID", RelatedComplaintID);
            cmd.Parameters.AddWithValue("p_ProjectDocIndexID", IndexID);
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