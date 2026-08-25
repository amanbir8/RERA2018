using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_ComplaintFormN_Helpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_FormNEventLog> Display_AuthorityDesk_FormNEventLogDetails(Int64 ComplaintFormN_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormNEventLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormNEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ComplaintFormN_EventLogDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_FormNEventLog
                       {
                           ComplaintFormN_EventAction_ID = Convert.ToInt64(dr["ComplaintFormN_EventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_ComplaintorApplication_ID = Convert.ToInt64(dr["Related_ComplaintorApplication_ID"]),
                           Related_RegDiaryNumber = Convert.ToString(dr["Related_RegDiaryNumber"]),                           
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),                           
                           ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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

        public List<ClsPrp_AuthorityDesk_ComplaintEvent_Master> Display_AuthorityDesk_ComplaintFormNEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ComplaintEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ComplaintEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ComplaintFormNEvent_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ComplaintEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }
        
        public bool Add_ComplaintFormN_InfoEvent(ClsPrp_AuthorityDesk_FormNEventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formn_eventaction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Related_ComplaintorApplication_ID", smodel.Related_ComplaintorApplication_ID);            
            cmd.Parameters.AddWithValue("p_p_Related_RegDiaryNumber", String.IsNullOrEmpty(smodel.Related_RegDiaryNumber) ? "" : smodel.Related_RegDiaryNumber);
            cmd.Parameters.AddWithValue("p_p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_p_EventAction_Relationship", UserRole);// String.IsNullOrEmpty(smodel.EventAction_Relationship) ? "" : smodel.EventAction_Relationship);
            cmd.Parameters.AddWithValue("p_p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_p_Actual_ResolutionDate", DateTime.Now);            
            cmd.Parameters.AddWithValue("p_p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            //return AppId;

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_ComplaintEvent_Master> Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ComplaintEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ComplaintEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ComplaintEventDescsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Event_ID", Event_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ComplaintEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                       });
            }
            return ProjectFivelist1;
        }

        // Eligible or Not-Eligible Event Action
        public Int64 Checkfn_ComplaintFormN_InfoEventDetailsByID(ClsPrp_AuthorityDesk_FormNEventLog smodel, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_checkfn_tbl_rera_complaint_formn_eventaction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormN_EventAction_ID", smodel.ComplaintFormN_EventAction_ID);
            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_Complaint_ID", smodel.Related_ComplaintorApplication_ID);
            cmd.Parameters.AddWithValue("p_Related_RegDiaryNumber", String.IsNullOrEmpty(smodel.Related_RegDiaryNumber) ? "" : smodel.Related_RegDiaryNumber);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 0;
        }

        // Save As Draft Remarks
        public bool Add_ComplaintFormN_InfoEventSaveAsDraftRemarks(ClsPrp_AuthorityDesk_FormN_EventActionSaveAsDraftRemarks smodel, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formn_eventaction_draftremarks", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormN_EventActionDraft_ID", smodel.ComplaintFormN_EventActionDraft_ID);
            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_ComplaintorApplication_ID", smodel.Related_ComplaintorApplication_ID);
            cmd.Parameters.AddWithValue("p_Related_RegDiaryNumber", String.IsNullOrEmpty(smodel.Related_RegDiaryNumber) ? "" : smodel.Related_RegDiaryNumber);

            cmd.Parameters.AddWithValue("p_IdentifiedBy_UserId", String.IsNullOrEmpty(smodel.IdentifiedBy_UserId) ? "" : smodel.IdentifiedBy_UserId);
            cmd.Parameters.AddWithValue("p_IdentifiedBy_RoleId", String.IsNullOrEmpty(smodel.IdentifiedBy_RoleId) ? "" : smodel.IdentifiedBy_RoleId);
            cmd.Parameters.AddWithValue("p_IdentifiedBy_FormType", String.IsNullOrEmpty(smodel.IdentifiedBy_FormType) ? "" : smodel.IdentifiedBy_FormType);

            cmd.Parameters.AddWithValue("p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_EventAction_Relationship", String.IsNullOrEmpty(smodel.EventAction_Relationship) ? "" : smodel.EventAction_Relationship);
            cmd.Parameters.AddWithValue("p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_FormN_EventActionSaveAsDraftRemarks> Display_AuthorityDesk_FormN_EventSaveAsDraftRemarks(Int64 ComplaintFormN_ID, string FormN_DiaryNumber, string FormN_UserID, string FormN_RoleID, string FormN_UserName)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_EventActionSaveAsDraftRemarks> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormN_EventActionSaveAsDraftRemarks>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ComplaintFormN_Event_DraftRemarks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_FormN_DiaryNumber", FormN_DiaryNumber);
            cmd.Parameters.AddWithValue("p_FormN_UserID", FormN_UserID);
            cmd.Parameters.AddWithValue("p_FormN_RoleID", FormN_RoleID);
            cmd.Parameters.AddWithValue("p_FormN_UserName", FormN_UserName);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_FormN_EventActionSaveAsDraftRemarks
                       {
                           ComplaintFormN_EventActionDraft_ID = Convert.ToInt64(dr["ComplaintFormN_EventActionDraft_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_ComplaintorApplication_ID = Convert.ToInt64(dr["Related_ComplaintorApplication_ID"]),
                           Related_RegDiaryNumber = Convert.ToString(dr["Related_RegDiaryNumber"]),

                           IdentifiedBy_UserId = Convert.ToString(dr["IdentifiedBy_UserId"]),
                           IdentifiedBy_RoleId = Convert.ToString(dr["IdentifiedBy_RoleId"]),
                           IdentifiedBy_FormType = Convert.ToString(dr["IdentifiedBy_FormType"]),

                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                           ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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

        public bool Update_ComplaintFormN_InfoEventSaveAsDraftRemarks(ClsPrp_AuthorityDesk_FormN_EventActionSaveAsDraftRemarks smodel, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_tbl_rera_complaint_formn_eventaction_draftremarks", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormN_EventActionDraft_ID", smodel.ComplaintFormN_EventActionDraft_ID);
            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_ComplaintorApplication_ID", smodel.Related_ComplaintorApplication_ID);
            cmd.Parameters.AddWithValue("p_Related_RegDiaryNumber", String.IsNullOrEmpty(smodel.Related_RegDiaryNumber) ? "" : smodel.Related_RegDiaryNumber);

            cmd.Parameters.AddWithValue("p_IdentifiedBy_UserId", String.IsNullOrEmpty(smodel.IdentifiedBy_UserId) ? "" : smodel.IdentifiedBy_UserId);
            cmd.Parameters.AddWithValue("p_IdentifiedBy_RoleId", String.IsNullOrEmpty(smodel.IdentifiedBy_RoleId) ? "" : smodel.IdentifiedBy_RoleId);
            cmd.Parameters.AddWithValue("p_IdentifiedBy_FormType", String.IsNullOrEmpty(smodel.IdentifiedBy_FormType) ? "" : smodel.IdentifiedBy_FormType);

            cmd.Parameters.AddWithValue("p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_EventAction_Relationship", String.IsNullOrEmpty(smodel.EventAction_Relationship) ? "" : smodel.EventAction_Relationship);
            cmd.Parameters.AddWithValue("p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_IsActive", 2);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter RetParam = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            RetParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RetParam);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int IntReturn = Convert.ToInt32(RetParam.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}