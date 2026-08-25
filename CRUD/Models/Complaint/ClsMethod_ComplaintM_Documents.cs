using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUD.Models.ComplaintExecution;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintM_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintFormM_Documents(Clsprp_ComplaintFormM_Documents smodel, Int64 oComplaintFormM_ID, String oComplaintFormMDoc_FilePath, String oComplaintFormMDoc_FileName, String oComplaintFormMDoc_FileSize, String oComplaintFormMDoc_FileFormat, Int32 oComplaintFormMDoc_IsGroup, Int64 oComplaintProfile_ID, string oUser_ID, string oUserName)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_listenclosuresdocuments", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ListEnclDocument_IndexID", 0);
            cmd.Parameters.AddWithValue("p_ListEnclDocument_ID", (smodel.ListEnclDocument_ID == 0) ? 0 : smodel.ListEnclDocument_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", oComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", oComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", oComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", oUser_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM"); //smodel.ComplaintType_MN);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoCode", String.IsNullOrEmpty(smodel.ComplaintDoc_InfoCode) ? "0" : smodel.ComplaintDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoName", String.IsNullOrEmpty(smodel.ComplaintDoc_InfoName) ? "" : smodel.ComplaintDoc_InfoName);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_ReferenceNumber", smodel.ComplaintDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_IssueDate", smodel.ComplaintDoc_IssueDate);

            cmd.Parameters.AddWithValue("p_ComplaintDoc_FileSize", oComplaintFormMDoc_FileSize);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_FileFormat", oComplaintFormMDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_FilePath", oComplaintFormMDoc_FilePath);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_FileName", oComplaintFormMDoc_FileName);
            cmd.Parameters.AddWithValue("p_ComplaintDoc_IsGroup", oComplaintFormMDoc_IsGroup);

            cmd.Parameters.AddWithValue("p_Doc_SerialNumber", String.IsNullOrEmpty(smodel.Doc_SerialNumber) ? "0" : smodel.Doc_SerialNumber);
            cmd.Parameters.AddWithValue("p_Doc_PageStartNumber", smodel.Doc_PageStartNumber);
            cmd.Parameters.AddWithValue("p_Doc_PageEndNumber", smodel.Doc_PageEndNumber);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Clsprp_ComplaintFormM_Documents> Display_ComplaintFormM_Documents_ByComplaintFormM_ID(Int64? ComplaintFormM_ID)
        {
            connection();
            List<Clsprp_ComplaintFormM_Documents> ComplaintFormM_Documents = new List<Clsprp_ComplaintFormM_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Documents_ComplaintM_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_Documents.Add(
                    new Clsprp_ComplaintFormM_Documents
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
            return ComplaintFormM_Documents;
        }

        // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64> Display_ComplaintFormM_Documents_ByDocCodeInfo_ComplaintFormM_ID(Int64 ComplaintFormM_ID, Int64 ComplaintFormM_DocInfoCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Documents_ByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoCode", ComplaintFormM_DocInfoCode);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"]);
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }


        public bool Delete_ComplaintFormM_Document(Int64? oListEnclDocument_IndexID, Int64? oListEnclDocument_ID, Int64? oComplaintFormM_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ListEnclDocument_IndexID", oListEnclDocument_IndexID);
            cmd.Parameters.AddWithValue("p_ListEnclDocument_ID", oListEnclDocument_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", oComplaintFormM_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public Int64 Update_Check_ComplaintFormM_Documents(Int64 pComplaintFormM_ID, string pUserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_RERA_Complaint_Formm_DocumentFlag", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", pComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_UserName", pUserName);

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return AppId;
            else
                return 0;
        }

        public List<ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd> GetStatusRegdProjectandUnRegdProjectFromMsearchByID(Int64 ComplaintID, String ComplaintType)
        {
            List<ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd> userlist1 = new List<ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd>();

            if (ComplaintID != 0)
            {
                DataSet ds = new DataSet();
                string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
                MySqlConnection con = new MySqlConnection();

                using (con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Display_Rera_FromMstatusRegdProjectandUnRegdProjectByID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
                        cmd.Parameters.AddWithValue("p_ComplaintType", ComplaintType);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd uobj = new ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd();
                            uobj.ComplaintProjectStatus = ds.Tables[0].Rows[i]["ComplaintProjectStatus"].ToString();
                            uobj.ComplaintDocumentTrack = ds.Tables[0].Rows[i]["ComplaintDocumentTrack"].ToString();
                            uobj.ColumnA = ds.Tables[0].Rows[i]["ColumnA"].ToString();
                            userlist1.Add(uobj);
                        }

                        con.Close();
                        return userlist1;
                    }
                }
            }
            else
            {
                return userlist1;
            }
        }



        public List<Clsprp_ExecutionForm_Documents> Display_ExecutionForm_Documents_ByExecution_ID(Int64? Executioncomplaint_id)
        {
            try
            {
                connection();
                List<Clsprp_ExecutionForm_Documents> ExecutionForm_Documents = new List<Clsprp_ExecutionForm_Documents>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Documents_Execution_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Executioncomplaint_id", Executioncomplaint_id);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ExecutionForm_Documents.Add(
                        new Clsprp_ExecutionForm_Documents
                        {
                            ListEnclDocument_IndexID = Convert.ToInt64(dr["ListEnclDocument_IndexID"]),
                            ListEnclDocument_ID = Convert.ToInt64(dr["ListEnclDocument_ID"]),
                            ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                            ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                            Related_ComplaintFormMId = Convert.ToInt64(dr["Related_ComplaintFormMId"]),
                            Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                            Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
                            Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                            User_ID = Convert.ToString(dr["User_ID"]),

                            ComplaintType = Convert.ToString(dr["ComplaintType"]),
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
                return ExecutionForm_Documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64> Display_ExecutionForm_Documents_ByDocCodeInfo_ExecutionForm_ID(Int64 Executioncomplaint_id, Int64 ExecutionForm_DocInfoCode)
        {
            try
            {
                connection();
                Int64 sumVal = 0;
                Int64 cntVal = 0;

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Documents_ByCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ExecutionForm_DocInfoCode", ExecutionForm_DocInfoCode);
                cmd.Parameters.AddWithValue("p_ExecutionForm_ID", Executioncomplaint_id);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    sumVal = Convert.ToInt64(dr["sumFileSize"]);
                    cntVal = Convert.ToInt64(dr["CountFileType"]);
                }
                return new Tuple<Int64, Int64>(sumVal, cntVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add_ExecutionForm_Documents(Clsprp_ExecutionForm_Documents smodel, Int64 oComplaintFormM_ID, String oComplaintFormMDoc_FilePath, String oComplaintFormMDoc_FileName, String oComplaintFormMDoc_FileSize, String oComplaintFormMDoc_FileFormat, Int32 oComplaintFormMDoc_IsGroup, Int64 oComplaintProfile_ID, string oUser_ID, string oUserName, Int64 zRelated_ComplaintFormMId)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_execution_form_listenclosuresdocuments", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ListEnclDocument_IndexID", 0);
                cmd.Parameters.AddWithValue("p_ListEnclDocument_ID", (smodel.ListEnclDocument_ID == 0) ? 0 : smodel.ListEnclDocument_ID);
                cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", oComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", oComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_zRelated_ComplaintFormMId", zRelated_ComplaintFormMId);
                cmd.Parameters.AddWithValue("p_Related_FormExe_SequenceID", smodel.Related_FormExe_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_FormExe_Year", smodel.Related_FormExe_Year);
                cmd.Parameters.AddWithValue("p_Profile_ID", oComplaintProfile_ID);
                cmd.Parameters.AddWithValue("p_User_ID", oUser_ID);

                cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeExecution"); //smodel.ComplaintType_MN);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoCode", String.IsNullOrEmpty(smodel.ComplaintDoc_InfoCode) ? "0" : smodel.ComplaintDoc_InfoCode);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoName", String.IsNullOrEmpty(smodel.ComplaintDoc_InfoName) ? "" : smodel.ComplaintDoc_InfoName);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_ReferenceNumber", smodel.ComplaintDoc_ReferenceNumber);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_IssueDate", smodel.ComplaintDoc_IssueDate);

                cmd.Parameters.AddWithValue("p_ComplaintDoc_FileSize", oComplaintFormMDoc_FileSize);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_FileFormat", oComplaintFormMDoc_FileFormat);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_FilePath", oComplaintFormMDoc_FilePath);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_FileName", oComplaintFormMDoc_FileName);
                cmd.Parameters.AddWithValue("p_ComplaintDoc_IsGroup", oComplaintFormMDoc_IsGroup);

                cmd.Parameters.AddWithValue("p_Doc_SerialNumber", String.IsNullOrEmpty(smodel.Doc_SerialNumber) ? "0" : smodel.Doc_SerialNumber);
                cmd.Parameters.AddWithValue("p_Doc_PageStartNumber", smodel.Doc_PageStartNumber);
                cmd.Parameters.AddWithValue("p_Doc_PageEndNumber", smodel.Doc_PageEndNumber);

                cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
                cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
                cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
                cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 0);
                cmd.Parameters.AddWithValue("p_IsLock", 0);
                cmd.Parameters.AddWithValue("p_IsPublicView", 0);
                cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_ExecutionForm_Document(Int64? oListEnclDocument_IndexID, Int64? oListEnclDocument_ID, Int64? oComplaintFormExe_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Execution_Form_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("p_ListEnclDocument_IndexID", oListEnclDocument_IndexID);
                cmd.Parameters.AddWithValue("p_ListEnclDocument_ID", oListEnclDocument_ID);
                cmd.Parameters.AddWithValue("p_ComplaintFormExe_ID", oComplaintFormExe_ID);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //string strex = ex.ToString();
                throw;
            }
        }

        public Int64 Update_Check_ComplaintExecutionForm_Documents(Int64 Executioncomplaint_id, string pUserName)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_update_RERA_Execution_Form_DocumentFlag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Executioncomplaint_id", Executioncomplaint_id);
                cmd.Parameters.AddWithValue("p_UserName", pUserName);

                MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
                AppPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(AppPar);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                Int64 AppId = Convert.ToInt64(AppPar.Value);
                con.Close();

                if (i >= 0)
                    return AppId;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}