using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using static CRUD.Models.HelpdeskComplaint.ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom;
using Microsoft.AspNet.Identity;

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



        //public List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom> Display_ComplaintFormM_CourtRoom_ByComplaintFormM_ID(Int64? ComplaintFormM_ID)
        //{
        //    connection();
        //    List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom> ComplaintFormM_Documents = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();

        //    MySqlCommand cmd = new MySqlCommand("Display_Rera_CourtRoom_FormM_ByComplaintM_ID", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ComplaintFormM_Documents.Add(
        //            new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom
        //            {
        //                CourtRoom_IndexID = Convert.ToInt64(dr["CourtRoom_IndexID"]),
        //                CourtRoom_ID = Convert.ToInt64(dr["CourtRoom_ID"]),

        //                Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
        //                Related_ComplaintCode = Convert.ToString(dr["Related_ComplaintCode"]),
        //                Related_PrehearingDate_IndexID = Convert.ToInt64(dr["Related_PrehearingDate_IndexID"]),
        //                Related_PrehearingDate_ID = Convert.ToInt64(dr["Related_PrehearingDate_ID"]),

        //                ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
        //                ComplaintType_TransferYN = Convert.ToString(dr["ComplaintType_TransferYN"]),
        //                ComplaintType_BifurcationYN = Convert.ToString(dr["ComplaintType_BifurcationYN"]),

        //                eRoom_AppliedDate = Convert.ToDateTime(dr["eRoom_AppliedDate"]),

        //                CRAS_Name = Convert.ToString(dr["CRAS_Name"]),
        //                CRAS_Category = Convert.ToString(dr["CRAS_Category"]),
        //                CRAS_Attendance_YN = Convert.ToString(dr["CRAS_Attendance_YN"]),
        //                CRAS_SeqOrder = Convert.ToInt32(dr["CRAS_SeqOrder"]),
        //                CRAS_Ref_Applied_SeqOrder = Convert.ToInt32(dr["CRAS_Ref_Applied_SeqOrder"]),
        //                CRAS_ProxyCouncilRepresentative = Convert.ToString(dr["CRAS_ProxyCouncilRepresentative"]),
        //                CRAS_Advocate_Flag = Convert.ToInt32(dr["CRAS_Advocate_Flag"]),
        //                CRAS_AdvocateName = Convert.ToString(dr["CRAS_AdvocateName"]),
        //                CRAS_Advocate_MTO = Convert.ToInt32(dr["CRAS_Advocate_MTO"]),

        //                A_column = Convert.ToString(dr["A_column"]),
        //                B_column = Convert.ToString(dr["B_column"]),
        //                C_column = Convert.ToString(dr["C_column"]),
        //                D_column = Convert.ToString(dr["D_column"]),
        //                IsActive = Convert.ToInt32(dr["IsActive"]),
        //                IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //                IsLock = Convert.ToInt32(dr["IsLock"]),
        //                IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
        //                CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //                CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
        //                ModifyBy = Convert.ToString(dr["ModifyBy"]),
        //                ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
        //            });
        //    }
        //    return ComplaintFormM_Documents;
        //}

        public ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom Display_ComplaintFormM_CourtRoom_ByComplaintFormM_ID(Int64? ComplaintFormM_ID)
        {
            connection();

            ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom ComplaintFormM_CourtRoom = new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom();

            ComplaintFormM_CourtRoom.Complainants = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();
            ComplaintFormM_CourtRoom.Respondents = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_CourtRoom_FormM_ByComplaintM_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            sd.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0)
            {
                DataTable dtComplainants = ds.Tables[0];

                foreach (DataRow dr in dtComplainants.Rows)
                {
                    ComplaintFormM_CourtRoom.Complainants.Add(
                        new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom
                        {
                            Related_ComplaintID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
                            Related_ComplaintCode = Convert.ToString(dr["ComplaintFormM_Code"]),
                            CRAS_Name = Convert.ToString(dr["Complainant_Name"]),
                            CRAS_SeqOrder = Convert.ToInt32(dr["CRAS_SeqOrder"]),
                            CRAS_Category = Convert.ToString(dr["PersonType"])
                        }
                    );
                }
            }

            if (ds.Tables.Count > 1)
            {
                DataTable dtRespondents = ds.Tables[1];
                foreach (DataRow dr in dtRespondents.Rows)
                {
                    ComplaintFormM_CourtRoom.Respondents.Add(
                        new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom
                        {
                            Related_ComplaintID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
                            Related_ComplaintCode = Convert.ToString(dr["ComplaintFormM_Code"]),
                            CRAS_Name = Convert.ToString(dr["Respondent_Name"]),
                            CRAS_SeqOrder = Convert.ToInt32(dr["CRAS_SeqOrder"]),
                            CRAS_Category = Convert.ToString(dr["PersonType"])
                        }
                    );
                }
            }


            return ComplaintFormM_CourtRoom;
        }

        public void SaveECourtRoom(ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom model)
        {
            connection();

            try
            {
                // Save Complainants
                if (model.Complainants != null && model.Complainants.Count > 0)
                {
                    foreach (var item in model.Complainants)
                    {
                        MySqlCommand cmd = new MySqlCommand("usp_Insert_Rera_CourtRoom_FormM", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_Related_ComplaintID", model.Related_ComplaintID);
                        cmd.Parameters.AddWithValue("p_Related_ComplaintCode", item.Related_ComplaintCode);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", model.Related_PrehearingDate_IndexID);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", model.Related_PrehearingDate_ID);
                        cmd.Parameters.AddWithValue("p_ComplaintType_MN", model.ComplaintType_MN);

                        cmd.Parameters.AddWithValue("p_CRAS_Name", item.CRAS_Name);
                        cmd.Parameters.AddWithValue("p_CRAS_Category", "Complainant");
                        cmd.Parameters.AddWithValue("p_CRAS_SeqOrder", item.CRAS_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_ProxyCouncilRepresentative", item.CRAS_ProxyCouncilRepresentative);
                        cmd.Parameters.AddWithValue("p_CRAS_AdvocateName", item.CRAS_AdvocateName);

                        cmd.Parameters.AddWithValue("p_eRoom_AppliedDate", item.eRoom_AppliedDate == DateTime.MinValue ? DateTime.Now : item.eRoom_AppliedDate);
                        cmd.Parameters.AddWithValue("p_CRAS_Attendance_YN", string.IsNullOrEmpty(item.CRAS_Attendance_YN) ? "" : item.CRAS_Attendance_YN);
                        cmd.Parameters.AddWithValue("p_CRAS_Ref_Applied_SeqOrder", item.CRAS_Ref_Applied_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_Flag", item.CRAS_Advocate_Flag);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_MTO", item.CRAS_Advocate_MTO);

                        cmd.Parameters.AddWithValue("p_A_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_B_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_C_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_D_column", string.Empty);

                        cmd.Parameters.AddWithValue("p_IsActive", 1);
                        cmd.Parameters.AddWithValue("p_IsDraft", 0);
                        cmd.Parameters.AddWithValue("p_IsLock", 0);
                        cmd.Parameters.AddWithValue("p_IsPublicView", 1);

                        cmd.Parameters.AddWithValue("p_CreatedBy", model.CreatedBy);
                        cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                        cmd.Parameters.AddWithValue("p_ModifyBy", model.ModifyBy);
                        cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                        if (con.State != ConnectionState.Open)
                            con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                // Save Respondants
                if (model.Respondents != null && model.Respondents.Count > 0)
                {
                    foreach (var item in model.Respondents)
                    {
                        MySqlCommand cmd = new MySqlCommand(
                            "usp_Insert_Rera_CourtRoom_FormM",
                            con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_Related_ComplaintID", model.Related_ComplaintID);
                        cmd.Parameters.AddWithValue("p_Related_ComplaintCode", item.Related_ComplaintCode);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", model.Related_PrehearingDate_IndexID);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", model.Related_PrehearingDate_ID);
                        cmd.Parameters.AddWithValue("p_ComplaintType_MN", model.ComplaintType_MN);

                        cmd.Parameters.AddWithValue("p_CRAS_Name", item.CRAS_Name);
                        cmd.Parameters.AddWithValue("p_CRAS_Category", "Respondant");
                        cmd.Parameters.AddWithValue("p_CRAS_SeqOrder", item.CRAS_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_ProxyCouncilRepresentative", item.CRAS_ProxyCouncilRepresentative);
                        cmd.Parameters.AddWithValue("p_CRAS_AdvocateName", item.CRAS_AdvocateName);

                        cmd.Parameters.AddWithValue("p_eRoom_AppliedDate", item.eRoom_AppliedDate == DateTime.MinValue ? DateTime.Now : item.eRoom_AppliedDate);
                        cmd.Parameters.AddWithValue("p_CRAS_Attendance_YN", string.IsNullOrEmpty(item.CRAS_Attendance_YN) ? "" : item.CRAS_Attendance_YN);
                        cmd.Parameters.AddWithValue("p_CRAS_Ref_Applied_SeqOrder", item.CRAS_Ref_Applied_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_Flag", item.CRAS_Advocate_Flag);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_MTO", item.CRAS_Advocate_MTO);

                        cmd.Parameters.AddWithValue("p_A_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_B_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_C_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_D_column", string.Empty);

                        cmd.Parameters.AddWithValue("p_IsActive", 1);
                        cmd.Parameters.AddWithValue("p_IsDraft", 0);
                        cmd.Parameters.AddWithValue("p_IsLock", 0);
                        cmd.Parameters.AddWithValue("p_IsPublicView", 1);

                        cmd.Parameters.AddWithValue("p_CreatedBy", model.CreatedBy);
                        cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                        cmd.Parameters.AddWithValue("p_ModifyBy", model.ModifyBy);
                        cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                        if (con.State != ConnectionState.Open)
                            con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateECourtRoom(ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom model)
        {
            connection();

            try
            {
                // =====================================================
                // Save Complainants
                // =====================================================

                if (model.Complainants != null && model.Complainants.Count > 0)
                {
                    MySqlCommand deactivateCmd = new MySqlCommand("usp_Deactivate_Rera_CourtRoom_FormM", con);
                    deactivateCmd.CommandType = CommandType.StoredProcedure;

                    deactivateCmd.Parameters.AddWithValue("p_CourtRoom_ID", model.CourtRoom_ID);
                    deactivateCmd.Parameters.AddWithValue("p_Related_ComplaintID", model.Related_ComplaintID);
                    deactivateCmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID",model.Related_PrehearingDate_IndexID);
                    deactivateCmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID",model.Related_PrehearingDate_ID);
                    deactivateCmd.Parameters.AddWithValue("p_ComplaintType_MN", model.ComplaintType_MN);
                    deactivateCmd.Parameters.AddWithValue("p_CRAS_Category", "Complainant");
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    deactivateCmd.ExecuteNonQuery();

                    foreach (var item in model.Complainants)
                    {
                        MySqlCommand cmd = new MySqlCommand("usp_Update_Rera_CourtRoom_FormM", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_CourtRoom_IndexID", item.CourtRoom_IndexID);
                        cmd.Parameters.AddWithValue("p_CourtRoom_ID", model.CourtRoom_ID);
                        cmd.Parameters.AddWithValue("p_Related_ComplaintID", model.Related_ComplaintID);
                        cmd.Parameters.AddWithValue("p_Related_ComplaintCode", item.Related_ComplaintCode);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", model.Related_PrehearingDate_IndexID);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", model.Related_PrehearingDate_ID);
                        cmd.Parameters.AddWithValue("p_ComplaintType_MN", model.ComplaintType_MN);
                        cmd.Parameters.AddWithValue("p_CRAS_Name", item.CRAS_Name);
                        cmd.Parameters.AddWithValue("p_CRAS_Category", "Complainant");
                        cmd.Parameters.AddWithValue("p_CRAS_SeqOrder", item.CRAS_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_ProxyCouncilRepresentative", item.CRAS_ProxyCouncilRepresentative);
                        cmd.Parameters.AddWithValue("p_CRAS_AdvocateName", item.CRAS_AdvocateName);
                        cmd.Parameters.AddWithValue("p_eRoom_AppliedDate", item.eRoom_AppliedDate == DateTime.MinValue ? DateTime.Now : item.eRoom_AppliedDate);
                        cmd.Parameters.AddWithValue("p_CRAS_Attendance_YN", string.IsNullOrEmpty(item.CRAS_Attendance_YN) ? "" : item.CRAS_Attendance_YN);
                        cmd.Parameters.AddWithValue("p_CRAS_Ref_Applied_SeqOrder", item.CRAS_Ref_Applied_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_Flag", item.CRAS_Advocate_Flag);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_MTO", item.CRAS_Advocate_MTO);
                        cmd.Parameters.AddWithValue("p_A_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_B_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_C_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_D_column",string.Empty);
                        //cmd.Parameters.AddWithValue("p_IsActive",1);
                        //cmd.Parameters.AddWithValue("p_IsDraft",0);
                        //cmd.Parameters.AddWithValue("p_IsLock",0);
                        //cmd.Parameters.AddWithValue("p_IsPublicView",1);
                        cmd.Parameters.AddWithValue("p_CreatedBy", model.CreatedBy);
                        cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                        cmd.Parameters.AddWithValue("p_ModifyBy", model.ModifyBy);
                        cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }


                // =====================================================
                // Save Respondants
                // =====================================================

                if (model.Respondents != null && model.Respondents.Count > 0)
                {
                    MySqlCommand deactivateCmd = new MySqlCommand("usp_Deactivate_Rera_CourtRoom_FormM", con);
                    deactivateCmd.CommandType = CommandType.StoredProcedure;

                    deactivateCmd.Parameters.AddWithValue("p_CourtRoom_ID", model.CourtRoom_ID);
                    deactivateCmd.Parameters.AddWithValue("p_Related_ComplaintID", model.Related_ComplaintID);
                    deactivateCmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", model.Related_PrehearingDate_IndexID);
                    deactivateCmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", model.Related_PrehearingDate_ID);
                    deactivateCmd.Parameters.AddWithValue("p_ComplaintType_MN", model.ComplaintType_MN);
                    deactivateCmd.Parameters.AddWithValue("p_CRAS_Category", model.CRAS_Category);
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    deactivateCmd.ExecuteNonQuery();

                    foreach (var item in model.Respondents)
                    {
                        MySqlCommand cmd = new MySqlCommand("usp_Update_Rera_CourtRoom_FormM", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_CourtRoom_IndexID", item.CourtRoom_IndexID);
                        cmd.Parameters.AddWithValue("p_CourtRoom_ID", model.CourtRoom_ID);
                        cmd.Parameters.AddWithValue("p_Related_ComplaintID", model.Related_ComplaintID);
                        cmd.Parameters.AddWithValue("p_Related_ComplaintCode", item.Related_ComplaintCode);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", model.Related_PrehearingDate_IndexID);
                        cmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", model.Related_PrehearingDate_ID);
                        cmd.Parameters.AddWithValue("p_ComplaintType_MN", model.ComplaintType_MN);
                        cmd.Parameters.AddWithValue("p_CRAS_Name", item.CRAS_Name);
                        cmd.Parameters.AddWithValue("p_CRAS_Category", "Respondant");
                        cmd.Parameters.AddWithValue("p_CRAS_SeqOrder", item.CRAS_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_ProxyCouncilRepresentative", item.CRAS_ProxyCouncilRepresentative);
                        cmd.Parameters.AddWithValue("p_CRAS_AdvocateName", item.CRAS_AdvocateName);
                        cmd.Parameters.AddWithValue("p_eRoom_AppliedDate", item.eRoom_AppliedDate == DateTime.MinValue ? DateTime.Now : item.eRoom_AppliedDate);
                        cmd.Parameters.AddWithValue("p_CRAS_Attendance_YN", string.IsNullOrEmpty(item.CRAS_Attendance_YN) ? "" : item.CRAS_Attendance_YN);
                        cmd.Parameters.AddWithValue("p_CRAS_Ref_Applied_SeqOrder", item.CRAS_Ref_Applied_SeqOrder);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_Flag", item.CRAS_Advocate_Flag);
                        cmd.Parameters.AddWithValue("p_CRAS_Advocate_MTO", item.CRAS_Advocate_MTO);
                        cmd.Parameters.AddWithValue("p_A_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_B_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_C_column", string.Empty);
                        cmd.Parameters.AddWithValue("p_D_column",string.Empty);
                        //cmd.Parameters.AddWithValue("p_IsActive",1);
                        //cmd.Parameters.AddWithValue("p_IsDraft",0);
                        //cmd.Parameters.AddWithValue("p_IsLock",0);
                        //cmd.Parameters.AddWithValue("p_IsPublicView",1);
                        cmd.Parameters.AddWithValue("p_CreatedBy",model.CreatedBy);
                        cmd.Parameters.AddWithValue("p_CreatedOn",DateTime.Now);
                        cmd.Parameters.AddWithValue("p_ModifyBy",model.ModifyBy);
                        cmd.Parameters.AddWithValue("p_ModifyOn",DateTime.Now);

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                throw ex;
            }
        }

        public long GetCourtRoomID(long Related_ComplaintID,long Related_PrehearingDate_IndexID,long Related_PrehearingDate_ID,string ComplaintType_MN, string CRAS_Category)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("GetCourtRoomId_ByRelated_PrehearingDate_IndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Related_ComplaintID",Related_ComplaintID);
            cmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", Related_PrehearingDate_IndexID);
            cmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", Related_PrehearingDate_ID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", ComplaintType_MN);
            cmd.Parameters.AddWithValue("p_CRAS_Category", CRAS_Category);

            if (con.State != ConnectionState.Open)
                con.Open();

            object result = cmd.ExecuteScalar();

            return result == null || result == DBNull.Value? 0: Convert.ToInt64(result);
        }


        public ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom Display_ComplaintFormM_CourtRoom_Saved(Int64 ComplaintFormM_ID, Int64 PreHearingDate_IndexID, Int64 PreHearingDate_ID)
        {
            connection();
            ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom model = new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom();

            try
            {
                model.Complainants = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();
                model.Respondents = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_CourtRoom_FormM_Saved", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_Related_PrehearingDate_IndexID", PreHearingDate_IndexID);
                cmd.Parameters.AddWithValue("p_Related_PrehearingDate_ID", PreHearingDate_ID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                con.Open();
                sd.Fill(ds);
                con.Close();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        model.Complainants.Add(
                            new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom
                            {
                                CourtRoom_IndexID = Convert.ToInt64(dr["CourtRoom_IndexID"]),
                                CourtRoom_ID = Convert.ToInt64(dr["CourtRoom_ID"]),
                                Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                                Related_ComplaintCode = Convert.ToString(dr["Related_ComplaintCode"]),
                                Related_PrehearingDate_IndexID = Convert.ToInt64(dr["Related_PrehearingDate_IndexID"]),
                                Related_PrehearingDate_ID = Convert.ToInt64(dr["Related_PrehearingDate_ID"]),
                                ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                                CRAS_Name = Convert.ToString(dr["CRAS_Name"]),
                                CRAS_Category = Convert.ToString(dr["CRAS_Category"]),
                                CRAS_Attendance_YN = Convert.ToString(dr["CRAS_Attendance_YN"]),
                                CRAS_SeqOrder = Convert.ToInt32(dr["CRAS_SeqOrder"]),
                                CRAS_Ref_Applied_SeqOrder = Convert.ToInt32(dr["CRAS_Ref_Applied_SeqOrder"]),
                                CRAS_ProxyCouncilRepresentative = Convert.ToString(dr["CRAS_ProxyCouncilRepresentative"]),
                                CRAS_Advocate_Flag = Convert.ToInt32(dr["CRAS_Advocate_Flag"]),
                                CRAS_AdvocateName = Convert.ToString(dr["CRAS_AdvocateName"]),
                                CRAS_Advocate_MTO = Convert.ToInt32(dr["CRAS_Advocate_MTO"]),
                                eRoom_AppliedDate = Convert.ToDateTime(dr["eRoom_AppliedDate"]),
                                IsActive = Convert.ToInt32(dr["IsActive"]),
                                IsDraft = Convert.ToInt32(dr["IsDraft"]),
                                IsLock = Convert.ToInt32(dr["IsLock"]),
                                IsPublicView = Convert.ToInt32(dr["IsPublicView"])
                            }
                        );
                    }
                }

                if (ds.Tables.Count > 1)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        model.Respondents.Add(
                            new ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom
                            {
                                CourtRoom_IndexID = Convert.ToInt64(dr["CourtRoom_IndexID"]),
                                CourtRoom_ID = Convert.ToInt64(dr["CourtRoom_ID"]),
                                Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                                Related_ComplaintCode = Convert.ToString(dr["Related_ComplaintCode"]),
                                Related_PrehearingDate_IndexID = Convert.ToInt64(dr["Related_PrehearingDate_IndexID"]),
                                Related_PrehearingDate_ID = Convert.ToInt64(dr["Related_PrehearingDate_ID"]),
                                ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                                CRAS_Name = Convert.ToString(dr["CRAS_Name"]),
                                CRAS_Category = Convert.ToString(dr["CRAS_Category"]),
                                CRAS_Attendance_YN = Convert.ToString(dr["CRAS_Attendance_YN"]),
                                CRAS_SeqOrder = Convert.ToInt32(dr["CRAS_SeqOrder"]),
                                CRAS_Ref_Applied_SeqOrder = Convert.ToInt32(dr["CRAS_Ref_Applied_SeqOrder"]),
                                CRAS_ProxyCouncilRepresentative = Convert.ToString(dr["CRAS_ProxyCouncilRepresentative"]),
                                CRAS_Advocate_Flag = Convert.ToInt32(dr["CRAS_Advocate_Flag"]),
                                CRAS_AdvocateName = Convert.ToString(dr["CRAS_AdvocateName"]),
                                CRAS_Advocate_MTO = Convert.ToInt32(dr["CRAS_Advocate_MTO"]),
                                eRoom_AppliedDate = Convert.ToDateTime(dr["eRoom_AppliedDate"]),
                                IsActive = Convert.ToInt32(dr["IsActive"]),
                                IsDraft = Convert.ToInt32(dr["IsDraft"]),
                                IsLock = Convert.ToInt32(dr["IsLock"]),
                                IsPublicView = Convert.ToInt32(dr["IsPublicView"])
                            }
                        );
                    }
                }
            }
            catch (Exception ex)
            {

                string strex = ex.ToString();
            }
            return model;

        }


    }
}