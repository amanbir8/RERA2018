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
    public class ClsMethod_AuthDesk_FormM_PreHearingIntrimOrder
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintInterimOrdersFormM_Documents(ClsPrp_AuthDesk_FormM_PreHearingInterimOrder smodel, Int64 oComplaintFormM_ID, Int64 oHearingFormM_ID, Int64 oHearingIndexFormMN_ID, String oComplaintFormMDoc_FilePath, String oComplaintFormMDoc_FileName, String oComplaintFormMDoc_FileSize, String oComplaintFormMDoc_FileFormat, Int32 oComplaintFormMDoc_IsGroup, string oUser_ID, string oUserName, String oDiaryNumberFormM)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_IntrimOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_IntrimOrderFormM_IndexID", 0);
                cmd.Parameters.AddWithValue("p_IntrimOrderFormM_ID", (smodel.IntrimOrderFormM_ID == 0) ? 0 : smodel.IntrimOrderFormM_ID);

                cmd.Parameters.AddWithValue("p_Related_ComplaintID", oComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_Related_DiaryNumber", oDiaryNumberFormM);
                cmd.Parameters.AddWithValue("p_Related_PreHearingDate_IndexID", oHearingIndexFormMN_ID);
                cmd.Parameters.AddWithValue("p_Related_PreHearingDate_ID", oHearingFormM_ID);
                cmd.Parameters.AddWithValue("p_Related_PreHearingDate", smodel.Related_PreHearingDate);
                cmd.Parameters.AddWithValue("p_Related_PreHearingTime", smodel.Related_PreHearingTime);
                cmd.Parameters.AddWithValue("p_User_ID", oUser_ID);

                cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM"); //smodel.ComplaintType_MN);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_InfoCode", smodel.IntrimOrderDoc_InfoCode);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_InfoName", String.IsNullOrEmpty(smodel.IntrimOrderDoc_InfoName) ? "" : smodel.IntrimOrderDoc_InfoName);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_ReferenceNumber", smodel.IntrimOrderDoc_ReferenceNumber);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_IssueDate", smodel.IntrimOrderDoc_IssueDate);

                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_FileSize", oComplaintFormMDoc_FileSize);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_FileFormat", oComplaintFormMDoc_FileFormat);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_FilePath", oComplaintFormMDoc_FilePath);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_FileName", oComplaintFormMDoc_FileName);
                cmd.Parameters.AddWithValue("p_IntrimOrderDoc_IsGroup", oComplaintFormMDoc_IsGroup);

                cmd.Parameters.AddWithValue("p_Upload_SerialNumber", String.IsNullOrEmpty(smodel.Upload_SerialNumber) ? "0" : smodel.Upload_SerialNumber);
                cmd.Parameters.AddWithValue("p_Upload_PageStartNumber", smodel.Upload_PageStartNumber);
                cmd.Parameters.AddWithValue("p_Upload_PageEndNumber", smodel.Upload_PageEndNumber);

                cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
                cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
                cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
                cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 0);
                cmd.Parameters.AddWithValue("p_IsLock", 0);
                cmd.Parameters.AddWithValue("p_IsFlag", 0);
                cmd.Parameters.AddWithValue("p_IsPublicView", 0);

                cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        public List<ClsPrp_AuthDesk_FormM_PreHearingInterimOrder> Display_ComplaintFormM_InterimOrders_ByComplaintFormM_ID(Int64? ComplaintFormM_ID, Int64? HearingFormM_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_PreHearingInterimOrder> ComplaintFormM_Documents = new List<ClsPrp_AuthDesk_FormM_PreHearingInterimOrder>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_InterimOrder_FormM_ByComplaintM_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_HearingFormM_ID", HearingFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_Documents.Add(
                    new ClsPrp_AuthDesk_FormM_PreHearingInterimOrder
                    {
                        IntrimOrderFormM_IndexID = Convert.ToInt64(dr["IntrimOrderFormM_IndexID"]),
                        IntrimOrderFormM_ID = Convert.ToInt64(dr["IntrimOrderFormM_ID"]),

                        Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                        Related_DiaryNumber = Convert.ToString(dr["Related_DiaryNumber"]),
                        Related_PreHearingDate_IndexID = Convert.ToInt64(dr["Related_PreHearingDate_IndexID"]),
                        Related_PreHearingDate_ID = Convert.ToInt64(dr["Related_PreHearingDate_ID"]),

                        Related_PreHearingDate = Convert.ToDateTime(dr["Related_PreHearingDate"]),
                        Related_PreHearingTime = Convert.ToString(dr["Related_PreHearingTime"]),

                        User_ID = Convert.ToString(dr["User_ID"]),
                        ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                        IntrimOrderDoc_InfoCode = Convert.ToInt32(dr["IntrimOrderDoc_InfoCode"]),
                        IntrimOrderDoc_InfoName = Convert.ToString(dr["IntrimOrderDoc_InfoName"]),
                        IntrimOrderDoc_ReferenceNumber = Convert.ToString(dr["IntrimOrderDoc_ReferenceNumber"]),
                        IntrimOrderDoc_IssueDate = Convert.ToDateTime(dr["IntrimOrderDoc_IssueDate"]),

                        IntrimOrderDoc_FileSize = Convert.ToString(dr["IntrimOrderDoc_FileSize"]),
                        IntrimOrderDoc_FileFormat = Convert.ToString(dr["IntrimOrderDoc_FileFormat"]),
                        IntrimOrderDoc_FilePath = Convert.ToString(dr["IntrimOrderDoc_FilePath"]),
                        IntrimOrderDoc_FileName = Convert.ToString(dr["IntrimOrderDoc_FileName"]),
                        IntrimOrderDoc_IsGroup = Convert.ToInt32(dr["IntrimOrderDoc_IsGroup"]),

                        Upload_SerialNumber = Convert.ToString(dr["Upload_SerialNumber"]),
                        Upload_PageStartNumber = Convert.ToInt32(dr["Upload_PageStartNumber"]),
                        Upload_PageEndNumber = Convert.ToInt32(dr["Upload_PageEndNumber"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsFlag = Convert.ToInt32(dr["IsFlag"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        PreHearingBenchName = Convert.ToString(dr["PreHearingBenchName"]),
                        PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                    });
            }
            return ComplaintFormM_Documents;
        }

        public Tuple<Int64, string, string, DateTime, string> Extract_ComplaintFormM_InterimOrdersIndexName_ByID(Int64 ComplaintFormM_ID, Int64 FormM_HearingId)
        {
            connection();
            Int64 pmHearingID = 0;
            string pmFixedForName = string.Empty;
            string pmBenchName = string.Empty;
            DateTime pmHearingDate = default(DateTime);
            string pmHearingTime = string.Empty;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_InterimOrder_FormM_ExtractNameByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_HearingFormM_ID", FormM_HearingId);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                pmHearingID = Convert.ToInt64(dr["pHearingID"]);
                pmFixedForName = Convert.ToString(dr["pFixedForName"]);
                pmBenchName = Convert.ToString(dr["pBenchName"]);
                pmHearingDate = Convert.ToDateTime(dr["pHearingDate"]);
                pmHearingTime = Convert.ToString(dr["pHearingTime"]);
            }
            return new Tuple<Int64, string, string, DateTime, string>(pmHearingID, pmFixedForName, pmBenchName, pmHearingDate, pmHearingTime);
        }

        // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64, Int64, Int64> Display_ComplaintFormM_InterimOrders_ByDocCodeInfo_ComplaintFormM_ID(Int64 ComplaintFormM_ID, Int64 FormM_HearingId, Int64 ComplaintFormM_DocInfoCode)
        {
            connection();
            Int64 sumTotalVal = 0;
            Int64 cntTotalVal = 0;
            Int64 sumRelatedHearingDateVal = 0;
            Int64 cntRelatedHearingDateVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_InterimOrder_FormM_Documents_ByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoCode", ComplaintFormM_DocInfoCode);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_PreHearingFormM_ID", FormM_HearingId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumTotalVal = Convert.ToInt64(dr["sumTotalFileSize"]);
                cntTotalVal = Convert.ToInt64(dr["CountTotalFileType"]);
                sumRelatedHearingDateVal = Convert.ToInt64(dr["sumHearingFileSize"]);
                cntRelatedHearingDateVal = Convert.ToInt64(dr["CountHearingFileType"]);
            }
            return new Tuple<Int64, Int64, Int64, Int64>(sumTotalVal, cntTotalVal, sumRelatedHearingDateVal, cntRelatedHearingDateVal);
        }
        
        public bool Delete_ComplaintFormM_IntrimOrder(Int64? oInterimOrder_IndexID, Int64? oInterimOrder_ID, Int64? oFormM_ID, Int64? oHearingFormM_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_IntrimOrder_FormM_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_InterimOrders_IndexID", oInterimOrder_IndexID);
            cmd.Parameters.AddWithValue("p_InterimOrders_ID", oInterimOrder_ID);
            cmd.Parameters.AddWithValue("p_FormM_ID", oFormM_ID);
            cmd.Parameters.AddWithValue("p_HearingFormM_ID", oHearingFormM_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}