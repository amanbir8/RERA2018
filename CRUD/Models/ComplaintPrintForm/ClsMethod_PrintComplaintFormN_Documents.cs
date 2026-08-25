using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsMethod_PrintComplaintFormN_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_Print_FormN_Documents> Display_ComplaintFormN_Documents_ByComplaintFormNID_ForPrint(Int64? ComplaintFormN_ID)
        {
            connection();
            List<Clsprp_Print_FormN_Documents> ComplaintFormN_Documents = new List<Clsprp_Print_FormN_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_Documents_ForPrint", con);
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
                    new Clsprp_Print_FormN_Documents
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

        public List<Clsprp_Print_FormN_Documents> Display_ComplaintFormN_Documents_ByComplaintFormNIDbyProfileID_ForPrint(Int64? ComplaintFormN_ID, Int64? ProfileFormN_ID)
        {
            connection();
            List<Clsprp_Print_FormN_Documents> ComplaintFormN_Documents = new List<Clsprp_Print_FormN_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_DocumentsByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_ProfileFormN_ID", ProfileFormN_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormN_Documents.Add(
                    new Clsprp_Print_FormN_Documents
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
    }
}