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
    public class ClsMethod_AuthDesk_FormM_OrderJudgements
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Extract Pop-up Details
        public List<ClsPrp_AuthDesk_FormM_OrderJudgements> Display_AuthDesk_ComplaintFormM_OrderJudgementDetailsByID(string mDiaryNumber, Int64 mComplaintID, string mComplaintType, Int32 mComplaintTransferFlag, string mComplaintTransferTypeOption, string mUserRole, string mUserName)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_OrderJudgements> ComplaintOrderlist = new List<ClsPrp_AuthDesk_FormM_OrderJudgements>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_OrderJudgementContents_FormM_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintDiaryNumber", mDiaryNumber);
            cmd.Parameters.AddWithValue("p_ComplaintID", mComplaintID);
            cmd.Parameters.AddWithValue("p_ComplaintType", mComplaintType);
            cmd.Parameters.AddWithValue("p_ComplaintTransferFlag", mComplaintTransferFlag);
            cmd.Parameters.AddWithValue("p_ComplaintTransferTypeOption", mComplaintTransferTypeOption);
            cmd.Parameters.AddWithValue("p_UserRole", mUserRole);
            cmd.Parameters.AddWithValue("p_UserName", mUserName);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintOrderlist.Add(
                       new ClsPrp_AuthDesk_FormM_OrderJudgements
                       {
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
                           oIsFlag = Convert.ToInt32(dr["oIsFlag"]),
                           oIsPublicView = Convert.ToInt32(dr["oIsPublicView"]),

                           oCreatedBy = Convert.ToString(dr["oCreatedBy"]),
                           oCreatedOn = Convert.ToDateTime(dr["oCreatedOn"]),
                           oModifyBy = Convert.ToString(dr["oModifyBy"]),
                           oModifyOn = Convert.ToDateTime(dr["oModifyOn"]),
                       });
            }
            return ComplaintOrderlist;
        }

        //Extract Abstract Details
        public List<ClsPrp_AuthDesk_FormM_OrderJudgements> Extract_AuthDesk_ComplaintFormM_CaseDetails_ByID(Int64 mComplaintFormM_ID, string mDiaryNumber_FormM, string mUserRole, string mUserName)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_OrderJudgements> CaseDetailslist = new List<ClsPrp_AuthDesk_FormM_OrderJudgements>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_OrderCaseDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", mComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_DiaryNumber", mDiaryNumber_FormM);
            cmd.Parameters.AddWithValue("p_UserRole", mUserRole);
            cmd.Parameters.AddWithValue("p_UserName", mUserName);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CaseDetailslist.Add(
                       new ClsPrp_AuthDesk_FormM_OrderJudgements
                       {
                           oRelated_Profile_ID = Convert.ToInt64(dr["pRelated_Profile_ID"]),
                           oRelated_User_ID = Convert.ToString(dr["pRelated_User_ID"]),
                           oRelated_Complaint_ID = Convert.ToInt64(dr["pRelated_Complaint_ID"]),
                           oRelated_ComplaintType_MN = Convert.ToString(dr["pRelated_ComplaintType_MN"]),
                           oRelated_ComplaintDiaryNumber = Convert.ToString(dr["pRelated_ComplaintDiaryNumber"]),

                           oComplainantName = Convert.ToString(dr["pComplainantName"]),
                           oPresentComplainantAuthorityName = Convert.ToString(dr["pPresentComplainantAuthorityName"]),
                           oRespondentName = Convert.ToString(dr["pRespondentName"]),
                           oPresentRespondentAuthorityName = Convert.ToString(dr["pPresentRespondentAuthorityName"]),

                           oBench_Name = Convert.ToString(dr["pBench_Name"]),
                           oBench_Code = Convert.ToString(dr["pBench_Code"]),
                           oBench_StampDescription = Convert.ToString(dr["pBench_StampDescription"]),

                           oDate_of_Filing = Convert.ToDateTime(dr["pDate_of_Filing"]),
                           oDate_of_Institution = Convert.ToDateTime(dr["pDate_of_Institution"]),
                           oDate_of_Hearing = Convert.ToDateTime(dr["pDate_of_Hearing"]),
                           oDate_of_Decision = Convert.ToDateTime(dr["pDate_of_Decision"]),

                           oIsTransferCase = Convert.ToInt32(dr["pIsTransferCase"]),
                           oTransferTypeOption = Convert.ToString(dr["pTransferTypeOption"]),
                           oTransferTypeOptionName = Convert.ToString(dr["pTransferTypeOption_Name"]),
                           oTransferCase_DiaryNumber = Convert.ToString(dr["pTransferCase_DiaryNumber"]),
                           oRelated_CaseTransfer_IndexID = Convert.ToInt64(dr["pRelated_CaseTransfer_IndexID"]),
                           oRelated_CaseTransfer_ID = Convert.ToInt64(dr["pRelated_CaseTransfer_ID"]),
                           oRelated_PreHearingDate_IndexID = Convert.ToInt64(dr["pRelated_PreHearingDate_IndexID"]),
                           oRelated_PreHearingDate_ID = Convert.ToInt64(dr["pRelated_PreHearingDate_ID"]),
                           oRelated_eCourt_CaseAllocation_IndexID = Convert.ToInt64(dr["pRelated_eCourt_CaseAllocation_IndexID"]),
                           oRelated_eCourt_CaseAllocation_ID = Convert.ToInt64(dr["pRelated_eCourt_CaseAllocation_ID"]),

                           oIsActive = Convert.ToInt32(dr["pIsActive"]),
                           oIsLatestActive = Convert.ToInt32(dr["pIsLatestActive"]),
                       });
            }
            return CaseDetailslist;
        }
    }
}