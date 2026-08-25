using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUD.Models.HelpDeskComplaint;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_FormN_PreHearingDate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintFormN_PreHearingDate(ClsPrp_AuthDesk_FormN_PreHearingDate smodel, string User_ID, string User_Name, Int64 ComplaintFormN_ID, string FormN_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formN_prehearingdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", smodel.PreHearingDate_IndexID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_ID", smodel.PreHearingDate_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", ComplaintFormN_ID);// smodel.ComplainantApplicant_RelatedComplaint_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(FormN_DiaryNumber) ? "" : FormN_DiaryNumber); // String.IsNullOrEmpty(smodel.ComplainantApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantApplicant_RelatedComplaint_Code);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");
            cmd.Parameters.AddWithValue("p_PreHearingDate", smodel.PreHearingDate == null ? dtvalue : smodel.PreHearingDate);
            cmd.Parameters.AddWithValue("p_PreHearingTime", String.IsNullOrEmpty(smodel.PreHearingTime) ? "" : smodel.PreHearingTime);
            cmd.Parameters.AddWithValue("p_PreHearingBench", String.IsNullOrEmpty(smodel.PreHearingBench) ? "" : smodel.PreHearingBench);
            cmd.Parameters.AddWithValue("p_PreHearingFixedForCode", String.IsNullOrEmpty(smodel.PreHearingFixedForCode) ? "" : smodel.PreHearingFixedForCode);
            cmd.Parameters.AddWithValue("p_PreHearingFixedForName", String.IsNullOrEmpty(smodel.PreHearingFixedForName) ? "" : smodel.PreHearingFixedForName);
            cmd.Parameters.AddWithValue("p_PreHearingStatus", String.IsNullOrEmpty(smodel.PreHearingStatus) ? "" : smodel.PreHearingStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", smodel.D_column == null ? dtvalue : smodel.D_column); //String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now); //smodel.CreatedOn == null ? dtvalue : smodel.CreatedOn);
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

        public bool Update_ComplaintFormN_PreHearingDate(ClsPrp_AuthDesk_FormN_PreHearingDate smodel, string User_ID, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formN_prehearingdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", smodel.PreHearingDate_IndexID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_ID", smodel.PreHearingDate_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", smodel.ComplainantApplicant_RelatedComplaint_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.ComplainantApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantApplicant_RelatedComplaint_Code);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");
            cmd.Parameters.AddWithValue("p_PreHearingDate", smodel.PreHearingDate == null ? dtvalue : smodel.PreHearingDate);
            cmd.Parameters.AddWithValue("p_PreHearingTime", String.IsNullOrEmpty(smodel.PreHearingTime) ? "" : smodel.PreHearingTime);
            cmd.Parameters.AddWithValue("p_PreHearingBench", String.IsNullOrEmpty(smodel.PreHearingBench) ? "" : smodel.PreHearingBench);
            cmd.Parameters.AddWithValue("p_PreHearingFixedForCode", String.IsNullOrEmpty(smodel.PreHearingFixedForCode) ? "" : smodel.PreHearingFixedForCode);
            cmd.Parameters.AddWithValue("p_PreHearingFixedForName", String.IsNullOrEmpty(smodel.PreHearingFixedForName) ? "" : smodel.PreHearingFixedForName);
            cmd.Parameters.AddWithValue("p_PreHearingStatus", String.IsNullOrEmpty(smodel.PreHearingStatus) ? "" : smodel.PreHearingStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", smodel.D_column == null ? dtvalue : smodel.D_column); //String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now); //smodel.CreatedOn == null ? dtvalue : smodel.CreatedOn);
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

        public List<ClsPrp_AuthDesk_FormN_PreHearingDate> Display_AuthDesk_ComplaintFormN_PreHearingDate(Int64 ComplaintFormN_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_PreHearingDate> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_PreHearingDate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_PreHearingDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormN_PreHearingDate
                       {
                           PreHearingDate_IndexID = Convert.ToInt64(dr["PreHearingDate_IndexID"]),
                           PreHearingDate_ID = Convert.ToInt64(dr["PreHearingDate_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                           ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           PreHearingDate = Convert.ToDateTime(dr["PreHearingDate"]),
                           PreHearingTime = Convert.ToString(dr["PreHearingTime"]),
                           PreHearingBench = Convert.ToString(dr["PreHearingBench"]),
                           PreHearingFixedForCode = Convert.ToString(dr["PreHearingFixedForCode"]),

                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           PreHearingStatus = Convert.ToString(dr["PreHearingStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToInt32(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]), //Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           IsInterimOrder = Convert.ToInt32(dr["IsInterimOrder"]),
                           InterimOrderStatusRemark = Convert.ToString(dr["InterimOrderStatusRemark"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_PreHearingDate> Display_AuthDesk_ComplaintFormN_PreHearingDateByID(Int64 ComplaintFormN_ID, Int64 PreHearingDate_IndexID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_PreHearingDate> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_PreHearingDate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_PreHearingDateByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", PreHearingDate_IndexID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormN_PreHearingDate
                       {
                           PreHearingDate_IndexID = Convert.ToInt64(dr["PreHearingDate_IndexID"]),
                           PreHearingDate_ID = Convert.ToInt64(dr["PreHearingDate_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                           ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           PreHearingDate = Convert.ToDateTime(dr["PreHearingDate"]),
                           PreHearingTime = Convert.ToString(dr["PreHearingTime"]),
                           PreHearingBench = Convert.ToString(dr["PreHearingBench"]),
                           PreHearingFixedForCode = Convert.ToString(dr["PreHearingFixedForCode"]),

                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           PreHearingStatus = Convert.ToString(dr["PreHearingStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToInt32(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]), //Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           IsInterimOrder = Convert.ToInt32(dr["IsInterimOrder"]),
                           InterimOrderStatusRemark = Convert.ToString(dr["InterimOrderStatusRemark"]),
                       });
            }
            return ProjectFivelist1;
        }

        public bool Delete_AuthDesk_ComplaintFormN_PreHearingDateByID(Int64? mComplaintFormN_ID, Int64? mPreHearingDate_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormN_PreHearingDate_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", mComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", mPreHearingDate_IndexID);            

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