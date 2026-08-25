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
    //Form-M and Form-MN
    public class ClsMethod_AuthDesk_FormM_ComplaintOrderJudgements
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintOrderJudgementsFormM_Documents(ClsPrp_AuthDesk_FormM_OrderJudgements smodel, Int64 qnComplaintFormM_ID, Int64 qnTransferFormM_ID, String qnComplaintFormMDoc_FilePath, String qnComplaintFormMDoc_FileName, String qnComplaintFormMDoc_FileSize, String qnComplaintFormMDoc_FileFormat, string qnUser_ID, string qnUserName)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_OrderJudgements", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime dtvalue = new DateTime(0001, 1, 1);

                #region Parameters
                cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_IndexID", smodel.OrderJudgementByAuthority_IndexID);
                cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_ID", smodel.OrderJudgementByAuthority_ID);
                cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);
                cmd.Parameters.AddWithValue("p_ComplaintNumber", String.IsNullOrEmpty(smodel.oRelated_ComplaintDiaryNumber) ? string.Empty : smodel.oRelated_ComplaintDiaryNumber);

                cmd.Parameters.AddWithValue("p_ComplainantName", String.IsNullOrEmpty(smodel.oComplainantName) ? string.Empty : smodel.oComplainantName);
                cmd.Parameters.AddWithValue("p_RespondentName", String.IsNullOrEmpty(smodel.oRespondentName) ? string.Empty : smodel.oRespondentName);
                cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.oDate_of_Decision == null ? dtvalue : smodel.oDate_of_Decision);

                cmd.Parameters.AddWithValue("p_ViewJugdement_BaseUrl", "~/");
                cmd.Parameters.AddWithValue("p_ViewJugdement_FilePath", qnComplaintFormMDoc_FilePath);
                cmd.Parameters.AddWithValue("p_ViewJugdement_FileName", qnComplaintFormMDoc_FileName);
                cmd.Parameters.AddWithValue("p_ViewJugdement_FileType", qnComplaintFormMDoc_FileFormat);

                cmd.Parameters.AddWithValue("p_A_column", qnComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.oRelated_ComplaintType_MN) ? "FormTypeM" : smodel.oRelated_ComplaintType_MN);
                cmd.Parameters.AddWithValue("p_C_column", qnComplaintFormMDoc_FileSize);
                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 0);
                cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
                cmd.Parameters.AddWithValue("p_IsPublicView", 1);

                cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(qnUserName) ? string.Empty : qnUserName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(qnUserName) ? string.Empty : qnUserName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                cmd.Parameters.AddWithValue("p_oOrderDesc_formM_eCourtIndexID", smodel.oOrderDesc_formM_eCourtIndexID);
                cmd.Parameters.AddWithValue("p_oOrderDesc_formM_eCourtID", smodel.oOrderDesc_formM_eCourtID);
                cmd.Parameters.AddWithValue("p_oSerialOrderNumber", smodel.oSerialOrderNumber);
                cmd.Parameters.AddWithValue("p_oRelated_Profile_ID", smodel.oRelated_Profile_ID);
                cmd.Parameters.AddWithValue("p_oRelated_User_ID", smodel.oRelated_User_ID);
                cmd.Parameters.AddWithValue("p_oRelated_Complaint_ID", qnComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_oRelated_ComplaintType_MN", "FormTypeM");
                cmd.Parameters.AddWithValue("p_oRelated_ComplaintDiaryNumber", String.IsNullOrEmpty(smodel.oRelated_ComplaintDiaryNumber) ? string.Empty : smodel.oRelated_ComplaintDiaryNumber);

                cmd.Parameters.AddWithValue("p_oeCourt_DiaryNumber", String.IsNullOrEmpty(smodel.oeCourt_DiaryNumber) ? string.Empty : smodel.oeCourt_DiaryNumber);
                cmd.Parameters.AddWithValue("p_oeCourt_ReferenceName", String.IsNullOrEmpty(smodel.oeCourt_ReferenceName) ? string.Empty : smodel.oeCourt_ReferenceName);
                cmd.Parameters.AddWithValue("p_oeCourt_ReferenceDate", smodel.oeCourt_ReferenceDate == null ? dtvalue : smodel.oeCourt_ReferenceDate);
                cmd.Parameters.AddWithValue("p_oeCourt_UnderSectionName", String.IsNullOrEmpty(smodel.oeCourt_UnderSectionName) ? string.Empty : smodel.oeCourt_UnderSectionName);

                cmd.Parameters.AddWithValue("p_oComplainantName", String.IsNullOrEmpty(smodel.oComplainantName) ? string.Empty : smodel.oComplainantName);
                cmd.Parameters.AddWithValue("p_oPresentComplainantAuthorityName", String.IsNullOrEmpty(smodel.oPresentComplainantAuthorityName) ? string.Empty : smodel.oPresentComplainantAuthorityName);
                cmd.Parameters.AddWithValue("p_oRespondentName", String.IsNullOrEmpty(smodel.oRespondentName) ? string.Empty : smodel.oRespondentName);
                cmd.Parameters.AddWithValue("p_oPresentRespondentAuthorityName", String.IsNullOrEmpty(smodel.oPresentRespondentAuthorityName) ? string.Empty : smodel.oPresentRespondentAuthorityName);

                cmd.Parameters.AddWithValue("p_oeCourt_CaseType_Name", String.IsNullOrEmpty(smodel.oeCourt_CaseType_Name) ? string.Empty : smodel.oeCourt_CaseType_Name);
                cmd.Parameters.AddWithValue("p_oeCourt_CaseType_Code", String.IsNullOrEmpty(smodel.oeCourt_CaseType_Name) ? string.Empty : smodel.oeCourt_CaseType_Name);
                cmd.Parameters.AddWithValue("p_oeCourt_CaseType_Date", smodel.oeCourt_CaseType_Date == null ? dtvalue : smodel.oeCourt_CaseType_Date);
                cmd.Parameters.AddWithValue("p_oeCourt_CaseType_Description", String.IsNullOrEmpty(smodel.oeCourt_CaseType_Description) ? string.Empty : smodel.oeCourt_CaseType_Description);

                cmd.Parameters.AddWithValue("p_oBench_Name", String.IsNullOrEmpty(smodel.oBench_Name) ? string.Empty : smodel.oBench_Name);
                cmd.Parameters.AddWithValue("p_oBench_Code", String.IsNullOrEmpty(smodel.oBench_Code) ? string.Empty : smodel.oBench_Code);
                cmd.Parameters.AddWithValue("p_oBench_StampDescription", String.IsNullOrEmpty(smodel.oBench_StampDescription) ? string.Empty : smodel.oBench_StampDescription);

                cmd.Parameters.AddWithValue("p_oOrderDocument_InfoName", String.IsNullOrEmpty(smodel.oOrderDocument_InfoName) ? string.Empty : smodel.oOrderDocument_InfoName);
                cmd.Parameters.AddWithValue("p_oOrderDocument_InfoCode", smodel.oOrderDocument_InfoCode);
                cmd.Parameters.AddWithValue("p_oUpload_Total_PageNumber", smodel.oUpload_Total_PageNumber);
                cmd.Parameters.AddWithValue("p_oUpload_Document_Size", String.IsNullOrEmpty(smodel.oUpload_Document_Size) ? string.Empty : smodel.oUpload_Document_Size);
                cmd.Parameters.AddWithValue("p_oRelated_OrderJudgementByAuthority_IndexID", smodel.oRelated_OrderJudgementByAuthority_IndexID);
                cmd.Parameters.AddWithValue("p_oRelated_OrderJudgementByAuthority_ID", smodel.oRelated_OrderJudgementByAuthority_ID);

                cmd.Parameters.AddWithValue("p_oDate_of_Filing", smodel.oDate_of_Filing == null ? dtvalue : smodel.oDate_of_Filing);
                cmd.Parameters.AddWithValue("p_oDate_of_Institution", smodel.oDate_of_Institution == null ? dtvalue : smodel.oDate_of_Institution);
                cmd.Parameters.AddWithValue("p_oDate_of_Hearing", smodel.oDate_of_Hearing == null ? dtvalue : smodel.oDate_of_Hearing);
                cmd.Parameters.AddWithValue("p_oDate_of_Decision", smodel.oDate_of_Decision == null ? dtvalue : smodel.oDate_of_Decision);
                cmd.Parameters.AddWithValue("p_oDate_of_Upload", smodel.oDate_of_Upload == null ? dtvalue : smodel.oDate_of_Upload);
                cmd.Parameters.AddWithValue("p_oTrueCopyPreparedBy", String.IsNullOrEmpty(smodel.oTrueCopyPreparedBy) ? string.Empty : smodel.oTrueCopyPreparedBy);
                cmd.Parameters.AddWithValue("p_oDate_of_TrueCopy", smodel.oDate_of_TrueCopy == null ? dtvalue : smodel.oDate_of_TrueCopy);

                cmd.Parameters.AddWithValue("p_oIsTransferCase", smodel.oIsTransferCase);
                cmd.Parameters.AddWithValue("p_oTransferTypeOption", String.IsNullOrEmpty(smodel.oTransferTypeOption) ? string.Empty : smodel.oTransferTypeOption);
                cmd.Parameters.AddWithValue("p_oTransferTypeOptionName", String.IsNullOrEmpty(smodel.oTransferTypeOptionName) ? string.Empty : smodel.oTransferTypeOptionName);
                cmd.Parameters.AddWithValue("p_oTransferCase_DiaryNumber", String.IsNullOrEmpty(smodel.oTransferCase_DiaryNumber) ? string.Empty : smodel.oTransferCase_DiaryNumber);

                cmd.Parameters.AddWithValue("p_oRelated_CaseTransfer_IndexID", smodel.oRelated_CaseTransfer_IndexID);
                cmd.Parameters.AddWithValue("p_oRelated_CaseTransfer_ID", qnTransferFormM_ID); // smodel.oRelated_CaseTransfer_ID);

                cmd.Parameters.AddWithValue("p_oRelated_PreHearingDate_IndexID", smodel.oRelated_PreHearingDate_IndexID);
                cmd.Parameters.AddWithValue("p_oRelated_PreHearingDate_ID", smodel.oRelated_PreHearingDate_ID);

                cmd.Parameters.AddWithValue("p_oRelated_eCourt_CaseAllocation_IndexID", smodel.oRelated_eCourt_CaseAllocation_IndexID);
                cmd.Parameters.AddWithValue("p_oRelated_eCourt_CaseAllocation_ID", smodel.oRelated_eCourt_CaseAllocation_ID);

                cmd.Parameters.AddWithValue("p_oRemarks_IfAny", String.IsNullOrEmpty(smodel.oRemarks_IfAny) ? string.Empty : smodel.oRemarks_IfAny);
                cmd.Parameters.AddWithValue("p_oA_column", smodel.oA_column);
                cmd.Parameters.AddWithValue("p_oB_column", String.IsNullOrEmpty(smodel.oB_column) ? string.Empty : smodel.oB_column);
                cmd.Parameters.AddWithValue("p_oC_column", String.IsNullOrEmpty(smodel.oC_column) ? string.Empty : smodel.oC_column);
                cmd.Parameters.AddWithValue("p_oD_column", String.IsNullOrEmpty(smodel.oD_column) ? string.Empty : smodel.oD_column);
                cmd.Parameters.AddWithValue("p_oE_column", String.IsNullOrEmpty(smodel.oE_column) ? string.Empty : smodel.oE_column);

                cmd.Parameters.AddWithValue("p_oIsActive", 1);
                cmd.Parameters.AddWithValue("p_oIsLatestActive", 1);
                cmd.Parameters.AddWithValue("p_oIsDraft", 1);
                cmd.Parameters.AddWithValue("p_oIsDraftMember", 0);
                cmd.Parameters.AddWithValue("p_oIsLock", 0);
                cmd.Parameters.AddWithValue("p_oIsFlag", 0);
                cmd.Parameters.AddWithValue("p_oIsPublicView", 1);

                cmd.Parameters.AddWithValue("p_oCreatedBy", String.IsNullOrEmpty(qnUserName) ? string.Empty : qnUserName);
                cmd.Parameters.AddWithValue("p_oCreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_oModifyBy", String.IsNullOrEmpty(qnUserName) ? string.Empty : qnUserName);
                cmd.Parameters.AddWithValue("p_oModifyOn", DateTime.Now);
                #endregion

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

        public List<ClsPrp_AuthDesk_FormM_OrderJudgements> Display_ComplaintFormM_OrderJudgements_ByFormM_ID(Int64? ComplaintFormM_ID, String Transfer_TypeOption, String ComplaintForm_Type, Int32 FormFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_OrderJudgements> ComplaintFormM_Documents = new List<ClsPrp_AuthDesk_FormM_OrderJudgements>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_OrderJudgements_FormM_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_Transfer_TypeOption", Transfer_TypeOption);
            cmd.Parameters.AddWithValue("p_ComplaintForm_Type", ComplaintForm_Type);
            cmd.Parameters.AddWithValue("p_FormFlag", FormFlag);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_Documents.Add(
                    new ClsPrp_AuthDesk_FormM_OrderJudgements
                    {
                        OrderJudgementByAuthority_IndexID = Convert.ToInt64(dr["OrderJudgementByAuthority_IndexID"]),
                        OrderJudgementByAuthority_ID = Convert.ToInt64(dr["OrderJudgementByAuthority_ID"]),
                        SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                        ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                        ComplainantName = Convert.ToString(dr["ComplainantName"]),
                        RespondentName = Convert.ToString(dr["RespondentName"]),
                        Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),
                        ViewJugdement_BaseUrl = Convert.ToString(dr["ViewJugdement_BaseUrl"]),
                        ViewJugdement_FilePath = Convert.ToString(dr["ViewJugdement_FilePath"]),
                        ViewJugdement_FileName = Convert.ToString(dr["ViewJugdement_FileName"]),
                        ViewJugdement_FileType = Convert.ToString(dr["ViewJugdement_FileType"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        oOrderDesc_formM_eCourtIndexID = Convert.ToInt64(dr["oOrderDesc_formM_eCourtIndexID"]),
                        oOrderDesc_formM_eCourtID = Convert.ToInt64(dr["oOrderDesc_formM_eCourtID"]),
                        oSerialOrderNumber = Convert.ToInt32(dr["oSerialOrderNumber"]),
                        oRelated_Profile_ID = Convert.ToInt64(dr["oRelated_Profile_ID"]),
                        oRelated_User_ID = Convert.ToString(dr["oRelated_User_ID"]),
                        oRelated_Complaint_ID = Convert.ToInt64(dr["oRelated_Complaint_ID"]),
                        oRelated_ComplaintType_MN = Convert.ToString(dr["oRelated_ComplaintType_MN"]),
                        oRelated_ComplaintDiaryNumber = Convert.ToString(dr["oRelated_ComplaintDiaryNumber"]),

                        oeCourt_DiaryNumber = Convert.ToString(dr["oeCourt_DiaryNumber"]),
                        oeCourt_ReferenceName = Convert.ToString(dr["oeCourt_ReferenceName"]),
                        oeCourt_ReferenceDate = Convert.ToDateTime(dr["oeCourt_ReferenceDate"]),
                        oeCourt_UnderSectionName = Convert.ToString(dr["oeCourt_UnderSectionName"]),
                        oComplainantName = Convert.ToString(dr["oComplainantName"]),
                        oPresentComplainantAuthorityName = Convert.ToString(dr["oPresentComplainantAuthorityName"]),
                        oRespondentName = Convert.ToString(dr["oRespondentName"]),
                        oPresentRespondentAuthorityName = Convert.ToString(dr["oPresentRespondentAuthorityName"]),

                        oeCourt_CaseType_Name = Convert.ToString(dr["oeCourt_CaseType_Name"]),
                        oeCourt_CaseType_Code = Convert.ToString(dr["oeCourt_CaseType_Code"]),
                        oeCourt_CaseType_Date = Convert.ToDateTime(dr["oeCourt_CaseType_Date"]),
                        oeCourt_CaseType_Description = Convert.ToString(dr["oeCourt_CaseType_Description"]),

                        oBench_Name = Convert.ToString(dr["oBench_Name"]),
                        oBench_Code = Convert.ToString(dr["oBench_Code"]),
                        oBench_StampDescription = Convert.ToString(dr["oBench_StampDescription"]),

                        oOrderDocument_InfoName = Convert.ToString(dr["oOrderDocument_InfoName"]),
                        oOrderDocument_InfoCode = Convert.ToInt32(dr["oOrderDocument_InfoCode"]),
                        oUpload_Total_PageNumber = Convert.ToInt32(dr["oUpload_Total_PageNumber"]),
                        oUpload_Document_Size = Convert.ToString(dr["oUpload_Document_Size"]),
                        oRelated_OrderJudgementByAuthority_IndexID = Convert.ToInt64(dr["oRelated_OrderJudgementByAuthority_IndexID"]),
                        oRelated_OrderJudgementByAuthority_ID = Convert.ToInt64(dr["oRelated_OrderJudgementByAuthority_ID"]),

                        oDate_of_Filing = Convert.ToDateTime(dr["oDate_of_Filing"]),
                        oDate_of_Institution = Convert.ToDateTime(dr["oDate_of_Institution"]),
                        oDate_of_Hearing = Convert.ToDateTime(dr["oDate_of_Hearing"]),
                        oDate_of_Decision = Convert.ToDateTime(dr["oDate_of_Decision"]),
                        oDate_of_Upload = Convert.ToDateTime(dr["oDate_of_Upload"]),
                        oTrueCopyPreparedBy = Convert.ToString(dr["oTrueCopyPreparedBy"]),
                        oDate_of_TrueCopy = Convert.ToDateTime(dr["oDate_of_TrueCopy"]),

                        oIsTransferCase = Convert.ToInt32(dr["oIsTransferCase"]),
                        oTransferTypeOption = Convert.ToString(dr["oTransferTypeOption"]),
                        oTransferTypeOptionName = Convert.ToString(dr["oTransferTypeOptionName"]),
                        oTransferCase_DiaryNumber = Convert.ToString(dr["oTransferCase_DiaryNumber"]),
                        oRelated_CaseTransfer_IndexID = Convert.ToInt64(dr["oRelated_CaseTransfer_IndexID"]),
                        oRelated_CaseTransfer_ID = Convert.ToInt64(dr["oRelated_CaseTransfer_ID"]),
                        oRelated_PreHearingDate_IndexID = Convert.ToInt64(dr["oRelated_PreHearingDate_IndexID"]),
                        oRelated_PreHearingDate_ID = Convert.ToInt64(dr["oRelated_PreHearingDate_ID"]),
                        oRelated_eCourt_CaseAllocation_IndexID = Convert.ToInt64(dr["oRelated_eCourt_CaseAllocation_IndexID"]),
                        oRelated_eCourt_CaseAllocation_ID = Convert.ToInt64(dr["oRelated_eCourt_CaseAllocation_ID"]),

                        oRemarks_IfAny = Convert.ToString(dr["oRemarks_IfAny"]),
                        oA_column = Convert.ToDecimal(dr["oA_column"]),
                        oB_column = Convert.ToString(dr["oB_column"]),
                        oC_column = Convert.ToString(dr["oC_column"]),
                        oD_column = Convert.ToString(dr["oD_column"]),
                        oE_column = Convert.ToString(dr["oE_column"]),

                        oIsActive = Convert.ToInt32(dr["oIsActive"]),
                        oIsLatestActive = Convert.ToInt32(dr["oIsLatestActive"]),
                        oIsDraft = Convert.ToInt32(dr["oIsDraft"]),
                        oIsDraftMember = Convert.ToInt32(dr["oIsDraftMember"]),
                        oIsLock = Convert.ToInt32(dr["oIsLock"]),
                        oIsFlag = Convert.ToInt32(this.GrantsDelete_ComplaintFormM_OrderJudgements_ByID(UserRole)),// Convert.ToInt32(dr["oIsFlag"]),
                        oIsPublicView = Convert.ToInt32(dr["oIsPublicView"]),

                        oCreatedBy = Convert.ToString(dr["oCreatedBy"]),
                        oCreatedOn = Convert.ToDateTime(dr["oCreatedOn"]),
                        oModifyBy = Convert.ToString(dr["oModifyBy"]),
                        oModifyOn = Convert.ToDateTime(dr["oModifyOn"]),
                    });
            }
            return ComplaintFormM_Documents;
        }

        // Permissions Method - Reference by Role
        public Tuple<Int64, Int32, Int32> Extract_ComplaintFormM_OrderJudgements_ByID(Int64 ComplaintFormM_ID, string Input_UserRole)
        {
            Int32 pmExtractActiveID = 0;
            Int32 pmExtractLatestActiveID = 0;

            switch (Input_UserRole)
            {
                case "66d13a1a-ef3a-4eb3-b88c-95b06f451c74": //Administrator
                case "7330c9a0-4296-4ddf-a421-0d0c491adf2d": //LegalAdvisorDesk
                case "97eba4f1-7be4-4ba2-848d-8ad65a317455": //PStoMembers
                case "319a2b07-788f-4f90-9cda-3bca6ed81d3c": //Programmer
                    {
                        pmExtractActiveID = 1;
                        pmExtractLatestActiveID = 1;
                        break;
                    }
                default:
                    {
                        pmExtractActiveID = 0;
                        pmExtractLatestActiveID = 0;
                        break;
                    }
            }
            return new Tuple<Int64, Int32, Int32>(ComplaintFormM_ID, pmExtractActiveID, pmExtractLatestActiveID);
        }

        public Int32 GrantsDelete_ComplaintFormM_OrderJudgements_ByID(string Input_UserRole)
        {
            Int32 pmExtractActiveID = 0;
            switch (Input_UserRole)
            {
                case "66d13a1a-ef3a-4eb3-b88c-95b06f451c74": //Administrator
                    {
                        pmExtractActiveID = 1;
                        break;
                    }
                case "7330c9a0-4296-4ddf-a421-0d0c491adf2d": //LegalAdvisorDesk
                    {
                        pmExtractActiveID = 2;
                        break;
                    }
                case "97eba4f1-7be4-4ba2-848d-8ad65a317455": //PStoMembers
                    {
                        pmExtractActiveID = 3;
                        break;
                    }
                case "319a2b07-788f-4f90-9cda-3bca6ed81d3c": //Programmer
                    {
                        pmExtractActiveID = 4;
                        break;
                    }
                default:
                    {
                        pmExtractActiveID = 0;
                        break;
                    }
            }
            return pmExtractActiveID;
        }

        //public Tuple<Int64, string, string, DateTime, string> Extract_ComplaintFormM_InterimOrdersIndexName_ByID(Int64 ComplaintFormM_ID, Int64 FormM_HearingId)
        //{
        //    connection();
        //    Int64 pmHearingID = 0;
        //    string pmFixedForName = string.Empty;
        //    string pmBenchName = string.Empty;
        //    DateTime pmHearingDate = default(DateTime);
        //    string pmHearingTime = string.Empty;

        //    MySqlCommand cmd = new MySqlCommand("Display_Rera_InterimOrder_FormM_ExtractNameByID", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
        //    cmd.Parameters.AddWithValue("p_HearingFormM_ID", FormM_HearingId);

        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        pmHearingID = Convert.ToInt64(dr["pHearingID"]);
        //        pmFixedForName = Convert.ToString(dr["pFixedForName"]);
        //        pmBenchName = Convert.ToString(dr["pBenchName"]);
        //        pmHearingDate = Convert.ToDateTime(dr["pHearingDate"]);
        //        pmHearingTime = Convert.ToString(dr["pHearingTime"]);
        //    }
        //    return new Tuple<Int64, string, string, DateTime, string>(pmHearingID, pmFixedForName, pmBenchName, pmHearingDate, pmHearingTime);
        //}

        // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64, Int64, Int64> Display_ComplaintFormM_OrderJudgements_ByDocCodeInfo_ComplaintFormM_ID(Int64 ComplaintFormM_ID, string ComplaintType, Int64 FormM_TransferId, Int32 TransferFlag_YesNo, string TransferTypeOption, Int64 ComplaintFormM_DocInfoCode)
        {
            connection();
            Int64 sumTotalVal = 0;
            Int64 cntTotalVal = 0;
            Int64 sumRelatedHearingDateVal = 0;
            Int64 cntRelatedHearingDateVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_OrderJudgements_FormM_Documents_ByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintDoc_InfoCode", ComplaintFormM_DocInfoCode);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplaintForm_Type", ComplaintType);
            cmd.Parameters.AddWithValue("p_TransferCase_ID", FormM_TransferId);
            cmd.Parameters.AddWithValue("p_TransferFlag", TransferFlag_YesNo);
            cmd.Parameters.AddWithValue("p_TransferTypeOption", TransferTypeOption);
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

        public bool Delete_ComplaintFormM_OrderJudgements_ByID(Int64? vFormM_DocIndexID, Int64? vFormM_DocID, Int64? vFormM_ID, string vFormM_Type, Int64? vLinkageFormM_IndexID, Int64? vLinkageFormM_ID, Int32? vIsTransferCase, string vTransferTypeOption)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_OrderJudgements_FormM_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_FormM_DocIndexID", vFormM_DocIndexID);
            cmd.Parameters.AddWithValue("p_FormM_DocID", vFormM_DocID);
            cmd.Parameters.AddWithValue("p_FormM_ID", vFormM_ID);
            cmd.Parameters.AddWithValue("p_FormM_Type", vFormM_Type);
            cmd.Parameters.AddWithValue("p_LinkageFormM_IndexID", vLinkageFormM_IndexID);
            cmd.Parameters.AddWithValue("p_LinkageFormM_ID", vLinkageFormM_ID);
            cmd.Parameters.AddWithValue("p_IsTransferCase", vIsTransferCase);
            cmd.Parameters.AddWithValue("p_TransferTypeOption", vTransferTypeOption);

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