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
    public class ClsMethod_AuthDesk_FormM_CaseTransferDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintFormM_CaseTransferDetails(ClsPrp_AuthDesk_FormM_CaseTransferDetails smodel, string User_ID, string User_Name, Int64 ComplaintFormM_ID, string FormM_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_CaseTransferDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CaseTransfer_IndexID", smodel.CaseTransfer_IndexID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_ID", smodel.CaseTransfer_ID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_RegDiaryNumber_IndexName", String.IsNullOrEmpty(smodel.CaseTransfer_RegDiaryNumber_IndexName) ? "" : smodel.CaseTransfer_RegDiaryNumber_IndexName);
            cmd.Parameters.AddWithValue("p_CaseTransfer_RegDiaryNumber_NameYear", smodel.CaseTransfer_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_CaseTransfer_RegDiaryNumber_Name", String.IsNullOrEmpty(smodel.CaseTransfer_RegDiaryNumber_Name) ? "" : smodel.CaseTransfer_RegDiaryNumber_Name);

            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.ComplainantApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantApplicant_RelatedComplaint_Code);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");

            cmd.Parameters.AddWithValue("p_TransferTypeOption", String.IsNullOrEmpty(smodel.TransferTypeOption) ? "" : smodel.TransferTypeOption);
            cmd.Parameters.AddWithValue("p_TransferDate", smodel.TransferDate == null ? dtvalue : smodel.TransferDate);
            cmd.Parameters.AddWithValue("p_Transfer_FromBench", String.IsNullOrEmpty(smodel.Transfer_FromBench) ? "" : smodel.Transfer_FromBench);
            cmd.Parameters.AddWithValue("p_Transfer_FromBenchName", String.IsNullOrEmpty(smodel.Transfer_FromBenchName) ? "" : smodel.Transfer_FromBenchName);
            cmd.Parameters.AddWithValue("p_Transfer_ToBench", String.IsNullOrEmpty(smodel.Transfer_ToBench) ? "" : smodel.Transfer_ToBench);
            cmd.Parameters.AddWithValue("p_Transfer_ToBenchName", String.IsNullOrEmpty(smodel.Transfer_ToBenchName) ? "" : smodel.Transfer_ToBenchName);

            cmd.Parameters.AddWithValue("p_PublicViewStatus", String.IsNullOrEmpty(smodel.PublicViewStatus) ? "" : smodel.PublicViewStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_IsCaseTransferlockUnlockFlag", smodel.IsCaseTransferlockUnlockFlag);
            cmd.Parameters.AddWithValue("p_IsTransferOrder", smodel.IsTransferOrder);
            cmd.Parameters.AddWithValue("p_TransferOrderStatusRemark", String.IsNullOrEmpty(smodel.TransferOrderStatusRemark) ? "" : smodel.TransferOrderStatusRemark);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsLatestActive", smodel.IsLatestActive);
            cmd.Parameters.AddWithValue("p_IsTransferDisplay", smodel.IsTransferDisplay);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return true;
            else
                return false;
        }

        public bool Update_ComplaintFormM_CaseTransferDetails(ClsPrp_AuthDesk_FormM_CaseTransferDetails smodel, string User_ID, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formm_CaseTransferDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CaseTransfer_IndexID", smodel.CaseTransfer_IndexID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_ID", smodel.CaseTransfer_ID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_RegDiaryNumber_IndexName", String.IsNullOrEmpty(smodel.CaseTransfer_RegDiaryNumber_IndexName) ? "" : smodel.CaseTransfer_RegDiaryNumber_IndexName);
            cmd.Parameters.AddWithValue("p_CaseTransfer_RegDiaryNumber_NameYear", smodel.CaseTransfer_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_CaseTransfer_RegDiaryNumber_Name", String.IsNullOrEmpty(smodel.CaseTransfer_RegDiaryNumber_Name) ? "" : smodel.CaseTransfer_RegDiaryNumber_Name);

            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", smodel.ComplainantApplicant_RelatedComplaint_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.ComplainantApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantApplicant_RelatedComplaint_Code);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");

            cmd.Parameters.AddWithValue("p_TransferTypeOption", String.IsNullOrEmpty(smodel.TransferTypeOption) ? "" : smodel.TransferTypeOption);
            cmd.Parameters.AddWithValue("p_TransferDate", smodel.TransferDate == null ? dtvalue : smodel.TransferDate);
            cmd.Parameters.AddWithValue("p_Transfer_FromBench", String.IsNullOrEmpty(smodel.Transfer_FromBench) ? "" : smodel.Transfer_FromBench);
            cmd.Parameters.AddWithValue("p_Transfer_FromBenchName", String.IsNullOrEmpty(smodel.Transfer_FromBenchName) ? "" : smodel.Transfer_FromBenchName);
            cmd.Parameters.AddWithValue("p_Transfer_ToBench", String.IsNullOrEmpty(smodel.Transfer_ToBench) ? "" : smodel.Transfer_ToBench);
            cmd.Parameters.AddWithValue("p_Transfer_ToBenchName", String.IsNullOrEmpty(smodel.Transfer_ToBenchName) ? "" : smodel.Transfer_ToBenchName);

            cmd.Parameters.AddWithValue("p_PublicViewStatus", String.IsNullOrEmpty(smodel.PublicViewStatus) ? "" : smodel.PublicViewStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_IsCaseTransferlockUnlockFlag", smodel.IsCaseTransferlockUnlockFlag);
            cmd.Parameters.AddWithValue("p_IsTransferOrder", smodel.IsTransferOrder);
            cmd.Parameters.AddWithValue("p_TransferOrderStatusRemark", String.IsNullOrEmpty(smodel.TransferOrderStatusRemark) ? "" : smodel.TransferOrderStatusRemark);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsLatestActive", smodel.IsLatestActive);
            cmd.Parameters.AddWithValue("p_IsTransferDisplay", smodel.IsTransferDisplay);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthDesk_FormM_CaseTransferDetails> Display_AuthDesk_ComplaintFormM_CaseTransferDetails(Int64 ComplaintFormM_ID, string UserRole, string UserName)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_CaseTransferDetails> CaseTransferlist = new List<ClsPrp_AuthDesk_FormM_CaseTransferDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_CaseTransferDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserName", UserName);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CaseTransferlist.Add(
                       new ClsPrp_AuthDesk_FormM_CaseTransferDetails
                       {
                           CaseTransfer_IndexID = Convert.ToInt64(dr["CaseTransfer_IndexID"]),
                           CaseTransfer_ID = Convert.ToInt64(dr["CaseTransfer_ID"]),
                           CaseTransfer_RegDiaryNumber_IndexName = Convert.ToString(dr["CaseTransfer_RegDiaryNumber_IndexName"]),
                           CaseTransfer_RegDiaryNumber_NameYear = Convert.ToInt32(dr["CaseTransfer_RegDiaryNumber_NameYear"]),
                           CaseTransfer_RegDiaryNumber_Name = Convert.ToString(dr["CaseTransfer_RegDiaryNumber_Name"]),

                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                           ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           TransferTypeOption = Convert.ToString(dr["TransferTypeOption"]),
                           TransferDate = Convert.ToDateTime(dr["TransferDate"]),
                           Transfer_FromBench = Convert.ToString(dr["Transfer_FromBench"]),
                           Transfer_FromBenchName = Convert.ToString(dr["Transfer_FromBenchName"]),
                           Transfer_ToBench = Convert.ToString(dr["Transfer_ToBench"]),
                           Transfer_ToBenchName = Convert.ToString(dr["Transfer_ToBenchName"]),

                           PublicViewStatus = Convert.ToString(dr["PublicViewStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToInt32(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           IsCaseTransferlockUnlockFlag = Convert.ToInt32(dr["IsCaseTransferlockUnlockFlag"]),
                           IsTransferOrder = Convert.ToInt32(dr["IsTransferOrder"]),
                           TransferOrderStatusRemark = Convert.ToString(dr["TransferOrderStatusRemark"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsLatestActive = Convert.ToInt32(dr["IsLatestActive"]),
                           IsTransferDisplay = Convert.ToInt32(dr["IsTransferDisplay"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return CaseTransferlist;
        }

        public List<ClsPrp_AuthDesk_FormM_CaseTransferDetails> Display_AuthDesk_ComplaintFormM_CaseTransferDetailsByID(Int64 ComplaintFormM_ID, Int64 CaseTransfer_IndexID, Int64 CaseTransfer_ID, string UserRole, string UserName)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_CaseTransferDetails> CaseTransferlist = new List<ClsPrp_AuthDesk_FormM_CaseTransferDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_CaseTransferDetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_IndexID", CaseTransfer_IndexID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_ID", CaseTransfer_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserName", UserName);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CaseTransferlist.Add(
                       new ClsPrp_AuthDesk_FormM_CaseTransferDetails
                       {
                           CaseTransfer_IndexID = Convert.ToInt64(dr["CaseTransfer_IndexID"]),
                           CaseTransfer_ID = Convert.ToInt64(dr["CaseTransfer_ID"]),
                           CaseTransfer_RegDiaryNumber_IndexName = Convert.ToString(dr["CaseTransfer_RegDiaryNumber_IndexName"]),
                           CaseTransfer_RegDiaryNumber_NameYear = Convert.ToInt32(dr["CaseTransfer_RegDiaryNumber_NameYear"]),
                           CaseTransfer_RegDiaryNumber_Name = Convert.ToString(dr["CaseTransfer_RegDiaryNumber_Name"]),

                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                           ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           TransferTypeOption = Convert.ToString(dr["TransferTypeOption"]),
                           TransferDate = Convert.ToDateTime(dr["TransferDate"]),
                           Transfer_FromBench = Convert.ToString(dr["Transfer_FromBench"]),
                           Transfer_FromBenchName = Convert.ToString(dr["Transfer_FromBenchName"]),
                           Transfer_ToBench = Convert.ToString(dr["Transfer_ToBench"]),
                           Transfer_ToBenchName = Convert.ToString(dr["Transfer_ToBenchName"]),

                           PublicViewStatus = Convert.ToString(dr["PublicViewStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToInt32(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           IsCaseTransferlockUnlockFlag = Convert.ToInt32(dr["IsCaseTransferlockUnlockFlag"]),
                           IsTransferOrder = Convert.ToInt32(dr["IsTransferOrder"]),
                           TransferOrderStatusRemark = Convert.ToString(dr["TransferOrderStatusRemark"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsLatestActive = Convert.ToInt32(dr["IsLatestActive"]),
                           IsTransferDisplay = Convert.ToInt32(dr["IsTransferDisplay"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return CaseTransferlist;
        }

        public bool Delete_AuthDesk_ComplaintFormM_CaseTransferDetailsByID(Int64? mComplaintFormM_ID, Int64? mCaseTransfer_IndexID, string mUserRole, string mUserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_CaseTransferDetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", mComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_CaseTransfer_IndexID", mCaseTransfer_IndexID);
            cmd.Parameters.AddWithValue("p_UserRole", mUserRole);
            cmd.Parameters.AddWithValue("p_UserName", mUserName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public int extractFormMCaseTransferDetails_Isdraftvalue_FromEventLog(Int64 mComplaintFormM_ID)
        {
            connection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Complaint_FormM_CaseTransferIsdraft_FromDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", mComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_FormMcode", "0");                
                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }
    }
}