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
    public class ClsMethod_AuthDesk_FormM_PreHearingDate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintFormM_PreHearingDate(ClsPrp_AuthDesk_FormM_PreHearingDate smodel, string User_ID, string User_Name, Int64 ComplaintFormM_ID, string FormM_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_prehearingdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", smodel.PreHearingDate_IndexID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_ID", smodel.PreHearingDate_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", ComplaintFormM_ID);// smodel.ComplainantApplicant_RelatedComplaint_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(FormM_DiaryNumber) ? "" : FormM_DiaryNumber); // String.IsNullOrEmpty(smodel.ComplainantApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantApplicant_RelatedComplaint_Code);
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

        public bool Update_ComplaintFormM_PreHearingDate(ClsPrp_AuthDesk_FormM_PreHearingDate smodel, string User_ID, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formm_prehearingdate", con);
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

        public List<ClsPrp_AuthDesk_FormM_PreHearingDate> Display_AuthDesk_ComplaintFormM_PreHearingDate(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_PreHearingDate> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_PreHearingDate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_PreHearingDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_PreHearingDate
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

        public List<ClsPrp_AuthDesk_FormM_PreHearingDate> Display_AuthDesk_ComplaintFormM_PreHearingDateByID(Int64 ComplaintFormM_ID, Int64 PreHearingDate_IndexID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_PreHearingDate> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_PreHearingDate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_PreHearingDateByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", PreHearingDate_IndexID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_PreHearingDate
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

        public bool Delete_AuthDesk_ComplaintFormM_PreHearingDateByID(Int64? mComplaintFormM_ID, Int64? mPreHearingDate_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_PreHearingDate_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", mComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_PreHearingDate_IndexID", mPreHearingDate_IndexID);            

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



        public List<Cls_Prp_FormM_CaseAssignment> Display_AuthDesk_ComplaintFormM()
        {
            connection();
            List<Cls_Prp_FormM_CaseAssignment> InstitutionFormM = new List<Cls_Prp_FormM_CaseAssignment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM", con);
            cmd.CommandType = CommandType.StoredProcedure;
           

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                InstitutionFormM.Add(
                      new Cls_Prp_FormM_CaseAssignment
                      {
                          InstitutionFormM_IndexID = Convert.ToInt64(dr["InstitutionFormM_IndexID"]),
                          InstitutionFormM_ID = Convert.ToInt64(dr["InstitutionFormM_ID"]),
                          InstitutionFormM_Code = Convert.ToString(dr["InstitutionFormM_Code"]),
                          Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                          User_ID = Convert.ToString(dr["User_ID"]),
                          ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                          IsSameDiaryNumberWithInstitutionNumber = Convert.ToInt32(dr["IsSameDiaryNumberWithInstitutionNumber"]),
                          Institution_Ref_ID = Convert.ToInt64(dr["Institution_Ref_ID"]),
                          Institution_Ref_Year = Convert.ToInt32(dr["Institution_Ref_Year"]),
                          Institution_Ref_Number = Convert.ToString(dr["Institution_Ref_Number"]),
                          Institution_Ref_Date = Convert.ToDateTime(dr["Institution_Ref_Date"]),
                          IsManualAssignBench = Convert.ToInt32(dr["IsManualAssignBench"]),
                          AssignementBench_ID = Convert.ToInt64(dr["AssignementBench_ID"]),
                          AssignementBench_Name = Convert.ToString(dr["AssignementBench_Name"]),
                          NatureOfComplaint_Statement = Convert.ToString(dr["NatureOfComplaint_Statement"]),
                          NatureOfComplaint_Key1 = Convert.ToString(dr["NatureOfComplaint_Key1"]),
                          NatureOfComplaint_Key2 = Convert.ToString(dr["NatureOfComplaint_Key2"]),
                          NatureOfComplaint_Key3 = Convert.ToString(dr["NatureOfComplaint_Key3"]),
                          ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                          Dak_Number = Convert.ToString(dr["Dak_Number"]),
                          Dak_Date = Convert.ToDateTime(dr["Dak_Date"]),
                          IsComplaintHardcopySetYesNo = Convert.ToInt32(dr["IsComplaintHardcopySetYesNo"]),
                          HardcopySetNumber = Convert.ToInt32(dr["HardcopySetNumber"]),
                          NumberOfComplainant = Convert.ToInt32(dr["NumberOfComplainant"]),
                          NumberOfRespondent = Convert.ToInt32(dr["NumberOfRespondent"]),
                          Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                          A_column = Convert.ToString(dr["A_column"]),
                          B_column = Convert.ToString(dr["B_column"]),
                          C_column = Convert.ToString(dr["C_column"]),
                          D_column = Convert.ToString(dr["D_column"]),
                          E_column = Convert.ToString(dr["E_column"]),
                          F_column = Convert.ToDateTime(dr["F_column"]),
                          IsActive = Convert.ToInt32(dr["IsActive"]),
                          IsDraft = Convert.ToInt32(dr["IsDraft"]),
                          IsLock = Convert.ToInt32(dr["IsLock"]),
                          IsLockRefNumber = Convert.ToInt32(dr["IsLockRefNumber"]),
                          IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                          CreatedBy = Convert.ToString(dr["CreatedBy"]),
                          CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                          ModifyBy = Convert.ToString(dr["ModifyBy"]),
                          ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                      });
            }
            return InstitutionFormM;
        }

        public List<Cls_Prp_FormM_CaseAssignment> Display_Rera_AuthDesk_Complaint_FormMByID(long ComplaintFormMID)
        {
            connection();
            List<Cls_Prp_FormM_CaseAssignment> InstitutionFormM = new List<Cls_Prp_FormM_CaseAssignment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ID", ComplaintFormMID); // pass param

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                InstitutionFormM.Add(
                      new Cls_Prp_FormM_CaseAssignment
                      {
                          InstitutionFormM_IndexID = Convert.ToInt64(dr["InstitutionFormM_IndexID"]),
                          InstitutionFormM_ID = Convert.ToInt64(dr["InstitutionFormM_ID"]),
                          InstitutionFormM_Code = Convert.ToString(dr["InstitutionFormM_Code"]),
                          Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                          User_ID = Convert.ToString(dr["User_ID"]),
                          ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                          IsSameDiaryNumberWithInstitutionNumber = Convert.ToInt32(dr["IsSameDiaryNumberWithInstitutionNumber"]),
                          Institution_Ref_ID = Convert.ToInt64(dr["Institution_Ref_ID"]),
                          Institution_Ref_Year = Convert.ToInt32(dr["Institution_Ref_Year"]),
                          Institution_Ref_Number = Convert.ToString(dr["Institution_Ref_Number"]),
                          Institution_Ref_Date = Convert.ToDateTime(dr["Institution_Ref_Date"]),
                          IsManualAssignBench = Convert.ToInt32(dr["IsManualAssignBench"]),
                          AssignementBench_ID = Convert.ToInt64(dr["AssignementBench_ID"]),
                          AssignementBench_Name = Convert.ToString(dr["AssignementBench_Name"]),
                          NatureOfComplaint_Statement = Convert.ToString(dr["NatureOfComplaint_Statement"]),
                          NatureOfComplaint_Key1 = Convert.ToString(dr["NatureOfComplaint_Key1"]),
                          NatureOfComplaint_Key2 = Convert.ToString(dr["NatureOfComplaint_Key2"]),
                          NatureOfComplaint_Key3 = Convert.ToString(dr["NatureOfComplaint_Key3"]),
                          ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                          Dak_Number = Convert.ToString(dr["Dak_Number"]),
                          Dak_Date = Convert.ToDateTime(dr["Dak_Date"]),
                          IsComplaintHardcopySetYesNo = Convert.ToInt32(dr["IsComplaintHardcopySetYesNo"]),
                          HardcopySetNumber = Convert.ToInt32(dr["HardcopySetNumber"]),
                          NumberOfComplainant = Convert.ToInt32(dr["NumberOfComplainant"]),
                          NumberOfRespondent = Convert.ToInt32(dr["NumberOfRespondent"]),
                          Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                          A_column = Convert.ToString(dr["A_column"]),
                          B_column = Convert.ToString(dr["B_column"]),
                          C_column = Convert.ToString(dr["C_column"]),
                          D_column = Convert.ToString(dr["D_column"]),
                          E_column = Convert.ToString(dr["E_column"]),
                          F_column = Convert.ToDateTime(dr["F_column"]),
                          IsActive = Convert.ToInt32(dr["IsActive"]),
                          IsDraft = Convert.ToInt32(dr["IsDraft"]),
                          IsLock = Convert.ToInt32(dr["IsLock"]),
                          IsLockRefNumber = Convert.ToInt32(dr["IsLockRefNumber"]),
                          IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                          CreatedBy = Convert.ToString(dr["CreatedBy"]),
                          CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                          ModifyBy = Convert.ToString(dr["ModifyBy"]),
                          ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                      });
            }
            return InstitutionFormM;
        }

        public List<ClsPrp_AuthDesk_PreHearingBench_Master> Display_AuthDesk_Complaint_BenchMaster()
        {
            connection();
            List<ClsPrp_AuthDesk_PreHearingBench_Master> ProjectFivelist1 = new List<ClsPrp_AuthDesk_PreHearingBench_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_Complaint_Bench", con);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_PreHearingBench_Master
                       {
                           PreHearingBench_IndexID = Convert.ToInt64(dr["PreHearingBench_IndexID"]),
                           PreHearingBench_ID = Convert.ToInt64(dr["PreHearingBench_ID"]),
                           PreHearingBenchCode = Convert.ToString(dr["PreHearingBenchCode"]), //ToInt64
                           PreHearingBenchName = Convert.ToString(dr["PreHearingBenchName"]),
                           PreHearingType = Convert.ToString(dr["PreHearingType"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }



        public bool Add_ComplaintFormM_InstitutionData(Cls_Prp_FormM_CaseAssignment smodel)
        {
            connection(); // your method to open MySqlConnection 'con'
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_institution", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Default min date
            DateTime minDate = DateTime.MinValue;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InstitutionFormM_IndexID", smodel.InstitutionFormM_IndexID);
            //cmd.Parameters.AddWithValue("p_InstitutionFormM_ID", smodel.InstitutionFormM_IndexID);
            cmd.Parameters.AddWithValue("p_InstitutionFormM_Code", smodel.InstitutionFormM_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID ?? "");
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", smodel.ComplaintType_MN ?? "");
            cmd.Parameters.AddWithValue("p_IsSameDiaryNumberWithInstitutionNumber", smodel.IsSameDiaryNumberWithInstitutionNumber);
            cmd.Parameters.AddWithValue("p_Institution_Ref_ID", smodel.Institution_Ref_ID);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Year", smodel.Institution_Ref_Year);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Number", smodel.Institution_Ref_Number);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Date",smodel.Institution_Ref_Date);
            cmd.Parameters.AddWithValue("p_IsManualAssignBench", smodel.IsManualAssignBench);
            cmd.Parameters.AddWithValue("p_AssignementBench_ID", smodel.AssignementBench_ID);
            cmd.Parameters.AddWithValue("p_AssignementBench_Name", smodel.AssignementBench_Name ?? "");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Statement", smodel.NatureOfComplaint_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key1", smodel.NatureOfComplaint_Key1 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key2", smodel.NatureOfComplaint_Key2 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key3", smodel.NatureOfComplaint_Key3 ?? "NA");
            cmd.Parameters.AddWithValue("p_ReliefSought_Statement", smodel.ReliefSought_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_Dak_Number",smodel.Dak_Number);
            cmd.Parameters.AddWithValue("p_Dak_Date",smodel.Dak_Date);
            cmd.Parameters.AddWithValue("p_IsComplaintHardcopySetYesNo", smodel.IsComplaintHardcopySetYesNo);
            cmd.Parameters.AddWithValue("p_HardcopySetNumber", smodel.HardcopySetNumber != 0 ? smodel.HardcopySetNumber : 0);
            cmd.Parameters.AddWithValue("p_NumberOfComplainant", smodel.NumberOfComplainant);
            cmd.Parameters.AddWithValue("p_NumberOfRespondent", smodel.NumberOfRespondent);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", smodel.Remarks_IfAny ?? "");
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column ?? "");
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column ?? "");
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column ?? "");
            cmd.Parameters.AddWithValue("p_D_column", smodel.D_column ?? "");
            cmd.Parameters.AddWithValue("p_E_column", smodel.E_column ?? "");
            cmd.Parameters.AddWithValue("p_F_column", smodel.F_column);
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_IsLockRefNumber", smodel.IsLockRefNumber);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyBy", smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            return i >= 0;
        }


        public bool Delete_AuthDesk_ComplaintFormM_InstitutionByID(Int64? InstitutionFormM_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_Institutione_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_InstitutionFormM_ID", InstitutionFormM_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<Cls_Prp_FormM_CaseAssignment> Display_AuthDesk_ComplaintFormM_InstitutionByID(Int64 InstitutionFormM_ID)
        {
            connection();
            List<Cls_Prp_FormM_CaseAssignment> ProjectFivelist1 = new List<Cls_Prp_FormM_CaseAssignment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_InstitutionByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_InstitutionFormM_ID", InstitutionFormM_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new Cls_Prp_FormM_CaseAssignment
                       {
                           InstitutionFormM_IndexID = Convert.ToInt64(dr["InstitutionFormM_IndexID"]),
                           InstitutionFormM_ID = Convert.ToInt64(dr["InstitutionFormM_ID"]),
                           InstitutionFormM_Code = Convert.ToString(dr["InstitutionFormM_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           IsSameDiaryNumberWithInstitutionNumber = Convert.ToInt32(dr["IsSameDiaryNumberWithInstitutionNumber"]),
                           Institution_Ref_ID = Convert.ToInt64(dr["Institution_Ref_ID"]),
                           Institution_Ref_Year = Convert.ToInt32(dr["Institution_Ref_Year"]),
                           Institution_Ref_Number = Convert.ToString(dr["Institution_Ref_Number"]),
                           Institution_Ref_Date = dr["Institution_Ref_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Institution_Ref_Date"]),
                           IsManualAssignBench = Convert.ToInt32(dr["IsManualAssignBench"]),
                           AssignementBench_ID = Convert.ToInt64(dr["AssignementBench_ID"]),
                           AssignementBench_Name = Convert.ToString(dr["AssignementBench_Name"]),
                           NatureOfComplaint_Statement = Convert.ToString(dr["NatureOfComplaint_Statement"]),
                           NatureOfComplaint_Key1 = Convert.ToString(dr["NatureOfComplaint_Key1"]),
                           NatureOfComplaint_Key2 = Convert.ToString(dr["NatureOfComplaint_Key2"]),
                           NatureOfComplaint_Key3 = Convert.ToString(dr["NatureOfComplaint_Key3"]),
                           ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                           Dak_Number = Convert.ToString(dr["Dak_Number"]),
                           Dak_Date = dr["Dak_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Dak_Date"]),
                           IsComplaintHardcopySetYesNo = Convert.ToInt32(dr["IsComplaintHardcopySetYesNo"]),
                           HardcopySetNumber = Convert.ToInt32(dr["HardcopySetNumber"]),
                           NumberOfComplainant = Convert.ToInt32(dr["NumberOfComplainant"]),
                           NumberOfRespondent = Convert.ToInt32(dr["NumberOfRespondent"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),
                           F_column = dr["F_column"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["F_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsLockRefNumber = Convert.ToInt32(dr["IsLockRefNumber"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ProjectFivelist1;
        }


        public bool Update_ComplaintFormM_Institution(Cls_Prp_FormM_CaseAssignment smodel, string User_ID, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formm_institutiondetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_InstitutionFormM_IndexID", smodel.InstitutionFormM_IndexID);
           // cmd.Parameters.AddWithValue("p_InstitutionFormM_ID", smodel.InstitutionFormM_IndexID);
            cmd.Parameters.AddWithValue("p_InstitutionFormM_Code", smodel.InstitutionFormM_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", User_ID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", smodel.ComplaintType_MN ?? "");
            cmd.Parameters.AddWithValue("p_IsSameDiaryNumberWithInstitutionNumber", smodel.IsSameDiaryNumberWithInstitutionNumber);
            cmd.Parameters.AddWithValue("p_Institution_Ref_ID", smodel.Institution_Ref_ID);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Year", smodel.Institution_Ref_Year);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Number", smodel.Institution_Ref_Number);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Date", smodel.Institution_Ref_Date);
            cmd.Parameters.AddWithValue("p_IsManualAssignBench", smodel.IsManualAssignBench);
            cmd.Parameters.AddWithValue("p_AssignementBench_ID", smodel.AssignementBench_ID);
            cmd.Parameters.AddWithValue("p_AssignementBench_Name", smodel.AssignementBench_Name ?? "");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Statement", smodel.NatureOfComplaint_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key1", smodel.NatureOfComplaint_Key1 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key2", smodel.NatureOfComplaint_Key2 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key3", smodel.NatureOfComplaint_Key3 ?? "NA");
            cmd.Parameters.AddWithValue("p_ReliefSought_Statement", smodel.ReliefSought_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_Dak_Number", smodel.Dak_Number);
            cmd.Parameters.AddWithValue("p_Dak_Date", smodel.Dak_Date);
            cmd.Parameters.AddWithValue("p_IsComplaintHardcopySetYesNo", smodel.IsComplaintHardcopySetYesNo);
            cmd.Parameters.AddWithValue("p_HardcopySetNumber", smodel.HardcopySetNumber != 0 ? smodel.HardcopySetNumber : 0);
            cmd.Parameters.AddWithValue("p_NumberOfComplainant", smodel.NumberOfComplainant);
            cmd.Parameters.AddWithValue("p_NumberOfRespondent", smodel.NumberOfRespondent);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", smodel.Remarks_IfAny ?? "");
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column ?? "");
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column ?? "");
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column ?? "");
            cmd.Parameters.AddWithValue("p_D_column", smodel.D_column ?? "");
            cmd.Parameters.AddWithValue("p_E_column", smodel.E_column ?? "");
            cmd.Parameters.AddWithValue("p_F_column", smodel.F_column);
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_IsLockRefNumber", smodel.IsLockRefNumber);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
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



        #region FORM N

        public bool Add_ComplaintFormN_InstitutionData(Cls_Prp_FormN_CaseAssignment smodel)
        {
            connection(); // your method to open MySqlConnection 'con'
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formn_Institution", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Default min date
            DateTime minDate = DateTime.MinValue;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InstitutionFormN_IndexID", smodel.InstitutionFormN_IndexID);
            //cmd.Parameters.AddWithValue("p_InstitutionFormM_ID", smodel.InstitutionFormM_IndexID);
            cmd.Parameters.AddWithValue("p_InstitutionFormN_Code", smodel.InstitutionFormN_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID ?? "");
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", smodel.ComplaintType_MN ?? "");
            cmd.Parameters.AddWithValue("p_IsSameDiaryNumberWithInstitutionNumber", smodel.IsSameDiaryNumberWithInstitutionNumber);
            cmd.Parameters.AddWithValue("p_Institution_Ref_ID", smodel.Institution_Ref_ID);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Year", smodel.Institution_Ref_Year);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Number", smodel.Institution_Ref_Number);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Date", smodel.Institution_Ref_Date);
            cmd.Parameters.AddWithValue("p_IsManualAssignBench", smodel.IsManualAssignBench);
            cmd.Parameters.AddWithValue("p_AssignementBench_ID", smodel.AssignementBench_ID);
            cmd.Parameters.AddWithValue("p_AssignementBench_Name", smodel.AssignementBench_Name ?? "");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Statement", smodel.NatureOfComplaint_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key1", smodel.NatureOfComplaint_Key1 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key2", smodel.NatureOfComplaint_Key2 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key3", smodel.NatureOfComplaint_Key3 ?? "NA");
            cmd.Parameters.AddWithValue("p_ReliefSought_Statement", smodel.ReliefSought_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_Dak_Number", smodel.Dak_Number);
            cmd.Parameters.AddWithValue("p_Dak_Date", smodel.Dak_Date);
            cmd.Parameters.AddWithValue("p_IsComplaintHardcopySetYesNo", smodel.IsComplaintHardcopySetYesNo);
            cmd.Parameters.AddWithValue("p_HardcopySetNumber", smodel.HardcopySetNumber != 0 ? smodel.HardcopySetNumber : 0);
            cmd.Parameters.AddWithValue("p_NumberOfComplainant", smodel.NumberOfComplainant);
            cmd.Parameters.AddWithValue("p_NumberOfRespondent", smodel.NumberOfRespondent);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", smodel.Remarks_IfAny ?? "");
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column ?? "");
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column ?? "");
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column ?? "");
            cmd.Parameters.AddWithValue("p_D_column", smodel.D_column ?? "");
            cmd.Parameters.AddWithValue("p_E_column", smodel.E_column ?? "");
            cmd.Parameters.AddWithValue("p_F_column", smodel.F_column);
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_IsLockRefNumber", smodel.IsLockRefNumber);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyBy", smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            return i >= 0;
        }


        public bool Delete_AuthDesk_ComplaintFormN_InstitutionByID(Int64? InstitutionFormN_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormN_Institutione_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_InstitutionFormN_ID", InstitutionFormN_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Cls_Prp_FormN_CaseAssignment> Display_AuthDesk_ComplaintFormN()
                                         {
            connection();
            List<Cls_Prp_FormN_CaseAssignment> InstitutionFormM = new List<Cls_Prp_FormN_CaseAssignment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN", con);
            cmd.CommandType = CommandType.StoredProcedure;


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                InstitutionFormM.Add(
                      new Cls_Prp_FormN_CaseAssignment
                      {
                          InstitutionFormN_IndexID = Convert.ToInt64(dr["InstitutionFormN_IndexID"]),
                          InstitutionFormN_ID = Convert.ToInt64(dr["InstitutionFormN_ID"]),
                          InstitutionFormN_Code = Convert.ToString(dr["InstitutionFormN_Code"]),
                          Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                          User_ID = Convert.ToString(dr["User_ID"]),
                          ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                          IsSameDiaryNumberWithInstitutionNumber = Convert.ToInt32(dr["IsSameDiaryNumberWithInstitutionNumber"]),
                          Institution_Ref_ID = Convert.ToInt64(dr["Institution_Ref_ID"]),
                          Institution_Ref_Year = Convert.ToInt32(dr["Institution_Ref_Year"]),
                          Institution_Ref_Number = Convert.ToString(dr["Institution_Ref_Number"]),
                          Institution_Ref_Date = Convert.ToDateTime(dr["Institution_Ref_Date"]),
                          IsManualAssignBench = Convert.ToInt32(dr["IsManualAssignBench"]),
                          AssignementBench_ID = Convert.ToInt64(dr["AssignementBench_ID"]),
                          AssignementBench_Name = Convert.ToString(dr["AssignementBench_Name"]),
                          NatureOfComplaint_Statement = Convert.ToString(dr["NatureOfComplaint_Statement"]),
                          NatureOfComplaint_Key1 = Convert.ToString(dr["NatureOfComplaint_Key1"]),
                          NatureOfComplaint_Key2 = Convert.ToString(dr["NatureOfComplaint_Key2"]),
                          NatureOfComplaint_Key3 = Convert.ToString(dr["NatureOfComplaint_Key3"]),
                          ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                          Dak_Number = Convert.ToString(dr["Dak_Number"]),
                          Dak_Date = Convert.ToDateTime(dr["Dak_Date"]),
                          IsComplaintHardcopySetYesNo = Convert.ToInt32(dr["IsComplaintHardcopySetYesNo"]),
                          HardcopySetNumber = Convert.ToInt32(dr["HardcopySetNumber"]),
                          NumberOfComplainant = Convert.ToInt32(dr["NumberOfComplainant"]),
                          NumberOfRespondent = Convert.ToInt32(dr["NumberOfRespondent"]),
                          Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                          A_column = Convert.ToString(dr["A_column"]),
                          B_column = Convert.ToString(dr["B_column"]),
                          C_column = Convert.ToString(dr["C_column"]),
                          D_column = Convert.ToString(dr["D_column"]),
                          E_column = Convert.ToString(dr["E_column"]),
                          F_column = Convert.ToDateTime(dr["F_column"]),
                          IsActive = Convert.ToInt32(dr["IsActive"]),
                          IsDraft = Convert.ToInt32(dr["IsDraft"]),
                          IsLock = Convert.ToInt32(dr["IsLock"]),
                          IsLockRefNumber = Convert.ToInt32(dr["IsLockRefNumber"]),
                          IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                          CreatedBy = Convert.ToString(dr["CreatedBy"]),
                          CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                          ModifyBy = Convert.ToString(dr["ModifyBy"]),
                          ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                      });
            }
            return InstitutionFormM;
        }

        public List<Cls_Prp_FormN_CaseAssignment> Display_AuthDesk_ComplaintFormN_InstitutionByID(Int64 InstitutionFormN_ID)
        {
            connection();
            List<Cls_Prp_FormN_CaseAssignment> ProjectFivelist1 = new List<Cls_Prp_FormN_CaseAssignment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_InstitutionByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_InstitutionFormN_ID", InstitutionFormN_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new Cls_Prp_FormN_CaseAssignment
                       {
                           InstitutionFormN_IndexID = Convert.ToInt64(dr["InstitutionFormN_IndexID"]),
                           InstitutionFormN_ID = Convert.ToInt64(dr["InstitutionFormN_ID"]),
                           InstitutionFormN_Code = Convert.ToString(dr["InstitutionFormN_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           IsSameDiaryNumberWithInstitutionNumber = Convert.ToInt32(dr["IsSameDiaryNumberWithInstitutionNumber"]),
                           Institution_Ref_ID = Convert.ToInt64(dr["Institution_Ref_ID"]),
                           Institution_Ref_Year = Convert.ToInt32(dr["Institution_Ref_Year"]),
                           Institution_Ref_Number = Convert.ToString(dr["Institution_Ref_Number"]),
                           Institution_Ref_Date = dr["Institution_Ref_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Institution_Ref_Date"]),
                           IsManualAssignBench = Convert.ToInt32(dr["IsManualAssignBench"]),
                           AssignementBench_ID = Convert.ToInt64(dr["AssignementBench_ID"]),
                           AssignementBench_Name = Convert.ToString(dr["AssignementBench_Name"]),
                           NatureOfComplaint_Statement = Convert.ToString(dr["NatureOfComplaint_Statement"]),
                           NatureOfComplaint_Key1 = Convert.ToString(dr["NatureOfComplaint_Key1"]),
                           NatureOfComplaint_Key2 = Convert.ToString(dr["NatureOfComplaint_Key2"]),
                           NatureOfComplaint_Key3 = Convert.ToString(dr["NatureOfComplaint_Key3"]),
                           ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                           Dak_Number = Convert.ToString(dr["Dak_Number"]),
                           Dak_Date = dr["Dak_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Dak_Date"]),
                           IsComplaintHardcopySetYesNo = Convert.ToInt32(dr["IsComplaintHardcopySetYesNo"]),
                           HardcopySetNumber = Convert.ToInt32(dr["HardcopySetNumber"]),
                           NumberOfComplainant = Convert.ToInt32(dr["NumberOfComplainant"]),
                           NumberOfRespondent = Convert.ToInt32(dr["NumberOfRespondent"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),
                           F_column = dr["F_column"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["F_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsLockRefNumber = Convert.ToInt32(dr["IsLockRefNumber"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ProjectFivelist1;
        }


        public bool Update_ComplaintFormN_Institution(Cls_Prp_FormN_CaseAssignment smodel, string User_ID, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formn_institutiondetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_InstitutionFormN_IndexID", smodel.InstitutionFormN_IndexID);
            cmd.Parameters.AddWithValue("p_InstitutionFormN_ID", smodel.InstitutionFormN_IndexID);
            cmd.Parameters.AddWithValue("p_InstitutionFormN_Code", smodel.InstitutionFormN_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", User_ID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", smodel.ComplaintType_MN ?? "");
            cmd.Parameters.AddWithValue("p_IsSameDiaryNumberWithInstitutionNumber", smodel.IsSameDiaryNumberWithInstitutionNumber);
            cmd.Parameters.AddWithValue("p_Institution_Ref_ID", smodel.Institution_Ref_ID);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Year", smodel.Institution_Ref_Year);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Number", smodel.Institution_Ref_Number);
            cmd.Parameters.AddWithValue("p_Institution_Ref_Date", smodel.Institution_Ref_Date);
            cmd.Parameters.AddWithValue("p_IsManualAssignBench", smodel.IsManualAssignBench);
            cmd.Parameters.AddWithValue("p_AssignementBench_ID", smodel.AssignementBench_ID);
            cmd.Parameters.AddWithValue("p_AssignementBench_Name", smodel.AssignementBench_Name ?? "");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Statement", smodel.NatureOfComplaint_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key1", smodel.NatureOfComplaint_Key1 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key2", smodel.NatureOfComplaint_Key2 ?? "NA");
            cmd.Parameters.AddWithValue("p_NatureOfComplaint_Key3", smodel.NatureOfComplaint_Key3 ?? "NA");
            cmd.Parameters.AddWithValue("p_ReliefSought_Statement", smodel.ReliefSought_Statement ?? "NA");
            cmd.Parameters.AddWithValue("p_Dak_Number", smodel.Dak_Number);
            cmd.Parameters.AddWithValue("p_Dak_Date", smodel.Dak_Date);
            cmd.Parameters.AddWithValue("p_IsComplaintHardcopySetYesNo", smodel.IsComplaintHardcopySetYesNo);
            cmd.Parameters.AddWithValue("p_HardcopySetNumber", smodel.HardcopySetNumber != 0 ? smodel.HardcopySetNumber : 0);
            cmd.Parameters.AddWithValue("p_NumberOfComplainant", smodel.NumberOfComplainant);
            cmd.Parameters.AddWithValue("p_NumberOfRespondent", smodel.NumberOfRespondent);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", smodel.Remarks_IfAny ?? "");
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column ?? "");
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column ?? "");
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column ?? "");
            cmd.Parameters.AddWithValue("p_D_column", smodel.D_column ?? "");
            cmd.Parameters.AddWithValue("p_E_column", smodel.E_column ?? "");
            cmd.Parameters.AddWithValue("p_F_column", smodel.F_column);
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_IsLockRefNumber", smodel.IsLockRefNumber);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
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

        #endregion



        #region ADVOCATES

        public int Add_Advocates(ClsPrp_Master_Advocates smodel, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Master_Advocates_formMN", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            //cmd.Parameters.AddWithValue("p_InstitutionFormN_IndexID", smodel.InstitutionFormN_IndexID);
            cmd.Parameters.AddWithValue("p_Advocate_IndexID", smodel.Advocate_ID);
            cmd.Parameters.AddWithValue("p_DiaryNumber",string.IsNullOrEmpty(smodel.DiaryNumber)?string.Empty: smodel.DiaryNumber);
            cmd.Parameters.AddWithValue("p_Complaint_ID", string.IsNullOrEmpty(smodel.Complaint_ID) ? string.Empty : smodel.Complaint_ID);
            cmd.Parameters.AddWithValue("p_Year", string.IsNullOrEmpty(smodel.Year) ? string.Empty : smodel.Year);
            cmd.Parameters.AddWithValue("p_ComplaintFormMN_ID", smodel.ComplaintFormMN_ID);
            cmd.Parameters.AddWithValue("p_TypeOfComplaintMN", string.IsNullOrEmpty(smodel.TypeOfComplaintMN) ? string.Empty : smodel.TypeOfComplaintMN);
            cmd.Parameters.AddWithValue("p_Profile_ID", string.IsNullOrEmpty(smodel.Profile_ID) ? string.Empty : smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_CounselRepresentative", smodel.CounselRepresentative);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_Email", smodel.Email);
            cmd.Parameters.AddWithValue("p_LandlineNumber", string.IsNullOrEmpty(smodel.LandlineNumber)? string.Empty : smodel.LandlineNumber);
            cmd.Parameters.AddWithValue("p_Othermembers", string.IsNullOrEmpty(smodel.Othermembers)?string.Empty:smodel.Othermembers);
            cmd.Parameters.AddWithValue("p_ExperienceYears", smodel.ExperienceYears);
            cmd.Parameters.AddWithValue("p_AddressLine1", smodel.AddressLine1);
            cmd.Parameters.AddWithValue("p_AddressLine2", string.IsNullOrEmpty(smodel.AddressLine2) ? string.Empty : smodel.AddressLine2);
            cmd.Parameters.AddWithValue("p_District", smodel.District);
            cmd.Parameters.AddWithValue("p_State", smodel.State);
            cmd.Parameters.AddWithValue("p_Pincode", smodel.Pincode);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", string.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            cmd.Parameters.AddWithValue("p_dob", smodel.Dob.HasValue?smodel.Dob:dtvalue);
            cmd.Parameters.AddWithValue("p_barRegno", smodel.BarRegNumber);
            cmd.Parameters.AddWithValue("p_barRegcode", string.IsNullOrEmpty(smodel.BarRegCode)? string.Empty : smodel.BarRegCode);
            cmd.Parameters.AddWithValue("p_barRegstate", smodel.BarRegState);
            cmd.Parameters.AddWithValue("p_location", string.IsNullOrEmpty(smodel.Location)?string.Empty: smodel.Location);
            cmd.Parameters.AddWithValue("p_gender", smodel.Gender);
            cmd.Parameters.AddWithValue("p_placeofpractice", string.IsNullOrEmpty(smodel.PlaceofPractice) ? string.Empty : smodel.PlaceofPractice);
            cmd.Parameters.AddWithValue("p_IsBarVerified", smodel.IsBarverified);

            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(AppPar.Value);
            con.Close();

            return result;
        }

        public int Update_Advocates(ClsPrp_Master_Advocates smodel, string User_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Master_Advocates_formMN", con);

            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_Advocate_IndexID", smodel.Advocate_IndexID);
            cmd.Parameters.AddWithValue("p_Advocate_ID", smodel.Advocate_ID);
            cmd.Parameters.AddWithValue("p_DiaryNumber", smodel.DiaryNumber);
            cmd.Parameters.AddWithValue("p_Complaint_ID", smodel.Complaint_ID);
            cmd.Parameters.AddWithValue("p_Year", smodel.Year);
            cmd.Parameters.AddWithValue("p_ComplaintFormMN_ID", smodel.ComplaintFormMN_ID);
            cmd.Parameters.AddWithValue("p_TypeOfComplaintMN", smodel.TypeOfComplaintMN);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_CounselRepresentative", smodel.CounselRepresentative);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_Email", smodel.Email);
            cmd.Parameters.AddWithValue("p_LandlineNumber", string.IsNullOrEmpty(smodel.LandlineNumber) ? string.Empty : smodel.LandlineNumber);
            cmd.Parameters.AddWithValue("p_Othermembers", string.IsNullOrEmpty(smodel.Othermembers) ? string.Empty : smodel.Othermembers);
            cmd.Parameters.AddWithValue("p_ExperienceYears", smodel.ExperienceYears);
            cmd.Parameters.AddWithValue("p_AddressLine1", smodel.AddressLine1);
            cmd.Parameters.AddWithValue("p_AddressLine2", string.IsNullOrEmpty(smodel.AddressLine2) ? string.Empty : smodel.AddressLine2);
            cmd.Parameters.AddWithValue("p_District", smodel.District);
            cmd.Parameters.AddWithValue("p_State", smodel.State);
            cmd.Parameters.AddWithValue("p_Pincode", smodel.Pincode);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", string.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            cmd.Parameters.AddWithValue("p_dob", smodel.Dob.HasValue ? smodel.Dob : dtvalue);
            cmd.Parameters.AddWithValue("p_barRegno", smodel.BarRegNumber);
            cmd.Parameters.AddWithValue("p_barRegcode", string.IsNullOrEmpty(smodel.BarRegCode) ? string.Empty : smodel.BarRegCode);
            cmd.Parameters.AddWithValue("p_barRegstate", smodel.BarRegState);
            cmd.Parameters.AddWithValue("p_location", string.IsNullOrEmpty(smodel.Location) ? string.Empty : smodel.Location);
            cmd.Parameters.AddWithValue("p_gender", smodel.Gender);
            cmd.Parameters.AddWithValue("p_placeofpractice", string.IsNullOrEmpty(smodel.PlaceofPractice) ? string.Empty : smodel.PlaceofPractice);
            cmd.Parameters.AddWithValue("p_IsBarVerified", smodel.IsBarverified);

            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(AppPar.Value);
            con.Close();

            return result;
        }

        public bool Delete_AdminDesk_AdvocateDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Master_AdvocatesByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Advocate_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_Advocate_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_Master_Advocates> Display_Master_Advocates(string type,string diarynumber)
        {
            connection();
            List<ClsPrp_Master_Advocates> ProjectFivelist1 = new List<ClsPrp_Master_Advocates>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Master_Advocates", con);
            cmd.Parameters.AddWithValue("p_type", type);
            cmd.Parameters.AddWithValue("p_Dno", diarynumber);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Master_Advocates
                       {
                           Advocate_IndexID = Convert.ToInt64(dr["Advocate_IndexID"]),
                           Advocate_ID = Convert.ToInt64(dr["Advocate_ID"]),
                           DiaryNumber = Convert.ToString(dr["DiaryNumber"]),
                           Complaint_ID = Convert.ToString(dr["Complaint_ID"]),
                           Year = Convert.ToString(dr["Year"]),

                           ComplaintFormMN_ID = Convert.ToInt64(dr["ComplaintFormMN_ID"]),
                           TypeOfComplaintMN = Convert.ToString(dr["TypeOfComplaintMN"]),
                           Profile_ID = Convert.ToString(dr["Profile_ID"]),
                           CounselRepresentative = Convert.ToString(dr["CounselRepresentative"]),

                           MobileNumber = Convert.ToString(dr["MobileNumber"]),
                           Email = Convert.ToString(dr["Email"]),
                           LandlineNumber = Convert.ToString(dr["LandlineNumber"]),
                           Othermembers = Convert.ToString(dr["Othermembers"]),
                           ExperienceYears = Convert.ToInt32(dr["ExperienceYears"]),
                           AddressLine1 = Convert.ToString(dr["AddressLine1"]),
                           AddressLine2 = Convert.ToString(dr["AddressLine2"]),
                           District = Convert.ToInt32(dr["District"]),
                           State = Convert.ToInt32(dr["State"]),
                           Pincode = Convert.ToInt32(dr["Pincode"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsFlag = Convert.ToInt32(dr["IsFlag"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_Master_Advocates> Display_Master_Advocates(string type)
        {
            connection();
            List<ClsPrp_Master_Advocates> ProjectFivelist1 = new List<ClsPrp_Master_Advocates>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Master_AdvocateByType", con);
            cmd.Parameters.AddWithValue("p_type", type);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Master_Advocates
                       {
                           Advocate_IndexID = Convert.ToInt64(dr["Advocate_IndexID"]),
                           Advocate_ID = Convert.ToInt64(dr["Advocate_ID"]),
                           DiaryNumber = Convert.ToString(dr["DiaryNumber"]),
                           Complaint_ID = Convert.ToString(dr["Complaint_ID"]),
                           Year = Convert.ToString(dr["Year"]),

                           ComplaintFormMN_ID = Convert.ToInt64(dr["ComplaintFormMN_ID"]),
                           TypeOfComplaintMN = Convert.ToString(dr["TypeOfComplaintMN"]),
                           Profile_ID = Convert.ToString(dr["Profile_ID"]),
                           CounselRepresentative = Convert.ToString(dr["CounselRepresentative"]),

                           MobileNumber = Convert.ToString(dr["MobileNumber"]),
                           Email = Convert.ToString(dr["Email"]),
                           LandlineNumber = Convert.ToString(dr["LandlineNumber"]),
                           Othermembers = Convert.ToString(dr["Othermembers"]),
                           ExperienceYears = Convert.ToInt32(dr["ExperienceYears"]),
                           AddressLine1 = Convert.ToString(dr["AddressLine1"]),
                           AddressLine2 = Convert.ToString(dr["AddressLine2"]),
                           District = Convert.ToInt32(dr["District"]),
                           State = Convert.ToInt32(dr["State"]),
                           Pincode = Convert.ToInt32(dr["Pincode"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsFlag = Convert.ToInt32(dr["IsFlag"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_Master_Advocates> Display_AdvocatesDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            try
            {
                connection();
                List<ClsPrp_Master_Advocates> AdminDeskparameters = new List<ClsPrp_Master_Advocates>();

                MySqlCommand cmd = new MySqlCommand("Display_AdminDesk_AdvocatesByIndexID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_IndexID", IndexID);
                cmd.Parameters.AddWithValue("p_ID", KeyID);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AdminDeskparameters.Add(
                           new ClsPrp_Master_Advocates
                           {
                               Advocate_IndexID = Convert.ToInt64(dr["Advocate_IndexID"]),
                               Advocate_ID = Convert.ToInt64(dr["Advocate_ID"]),
                               DiaryNumber = Convert.ToString(dr["DiaryNumber"]),
                               Complaint_ID = Convert.ToString(dr["Complaint_ID"]),
                               Year = Convert.ToString(dr["Year"]),

                               ComplaintFormMN_ID = Convert.ToInt64(dr["ComplaintFormMN_ID"]),
                               TypeOfComplaintMN = Convert.ToString(dr["TypeOfComplaintMN"]),
                               Profile_ID = Convert.ToString(dr["Profile_ID"]),
                               CounselRepresentative = Convert.ToString(dr["CounselRepresentative"]),

                               MobileNumber = Convert.ToString(dr["MobileNumber"]),
                               Email = Convert.ToString(dr["Email"]),
                               LandlineNumber = Convert.ToString(dr["LandlineNumber"]),
                               Othermembers = Convert.ToString(dr["Othermembers"]),
                               ExperienceYears = Convert.ToInt32(dr["ExperienceYears"]),
                               AddressLine1 = Convert.ToString(dr["AddressLine1"]),
                               AddressLine2 = Convert.ToString(dr["AddressLine2"]),
                               District = Convert.ToInt32(dr["District"]),
                               State = Convert.ToInt32(dr["State"]),
                               Pincode = Convert.ToInt32(dr["Pincode"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),
                               D_column = Convert.ToString(dr["D_column"]),

                               Dob = Convert.ToDateTime(dr["Dob"]),
                               BarRegNumber = Convert.ToString(dr["BarRegnumber"]),
                               BarRegCode = Convert.ToString(dr["BarRegCode"]),
                               BarRegState = Convert.ToInt32(dr["BarRegState"]),
                               Location = Convert.ToString(dr["Location"]),
                               PlaceofPractice = Convert.ToString(dr["PlaceofPractice"]),
                               Gender = Convert.ToString(dr["Gender"]),

                               RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsFlag = Convert.ToInt32(dr["IsFlag"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsBarverified = Convert.ToInt32(dr["IsBarVerified"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                           });
                }
                return AdminDeskparameters;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}