 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_QuarterlyUpdatesProjectsDetails
    {

        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> Display_AuthDesk_QuarterlyUpdatesProjectsDiaryNumberDetails_ByUserID(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> ProjectReralist = new List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails
                       {
                           QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                           QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                           QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                           QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                           QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                           QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           PromoterID = Convert.ToInt64(dr["PromoterID"]),
                           ProjectID = Convert.ToInt64(dr["ProjectID"]),

                           InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                           ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                           GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                           InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                           ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                           ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),

                           RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberValidUptoDate = Convert.ToDateTime(dr["RERAnumberValidUptoDate"]),

                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           QUpdatesApplication_Date = Convert.ToDateTime(dr["QUpdatesApplication_Date"]),
                           setQuarterValue_Year = Convert.ToString(dr["setQuarterValue_Year"]),
                           setQuarterValue_Name = Convert.ToString(dr["setQuarterValue_Name"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),
                       });
            }
            return ProjectReralist;
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> Display_AuthDesk_QuarterlyUpdatesProjectsDiaryNumberDetails_ByDate(int? approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> ProjectReralist = new List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectDetailsByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_approvalyear", approvalyear);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails
                       {
                           QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                           QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                           QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                           QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                           QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                           QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           PromoterID = Convert.ToInt64(dr["PromoterID"]),
                           ProjectID = Convert.ToInt64(dr["ProjectID"]),

                           InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                           ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                           GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                           InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                           ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                           ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),

                           RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberValidUptoDate = Convert.ToDateTime(dr["RERAnumberValidUptoDate"]),

                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           QUpdatesApplication_Date = Convert.ToDateTime(dr["QUpdatesApplication_Date"]),
                           setQuarterValue_Year = Convert.ToString(dr["setQuarterValue_Year"]),
                           setQuarterValue_Name = Convert.ToString(dr["setQuarterValue_Name"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),
                       });
            }
            return ProjectReralist;
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> Display_AuthDesk_QuarterlyUpdatesProjectsEveryQuarterEventLogDetails_ByID(Int64 QUpdates_ProjectID, Int32 QUpdates_QuarterYear, string QUpdates_QuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> ProjectReralist = new List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectEventLogByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdates_ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterYear", QUpdates_QuarterYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdates_QuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails
                       {
                           QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                           QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                           QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                           QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                           QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                           QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           PromoterID = Convert.ToInt64(dr["PromoterID"]),
                           ProjectID = Convert.ToInt64(dr["ProjectID"]),

                           InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                           ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                           GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                           InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                           ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                           ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),

                           RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberValidUptoDate = Convert.ToDateTime(dr["RERAnumberValidUptoDate"]),

                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           QUpdatesApplication_Date = Convert.ToDateTime(dr["QUpdatesApplication_Date"]),
                           setQuarterValue_Year = Convert.ToString(dr["setQuarterValue_Year"]),
                           setQuarterValue_Name = Convert.ToString(dr["setQuarterValue_Name"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),
                       });
            }
            return ProjectReralist;
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectEventLog> Display_AuthDesk_QuarterlyUpdatesProjectsSelectedQuarterEventLogDetails_ByID(Int64 QUpdates_ProjectID, Int32 QUpdates_QuarterYear, string QUpdates_QuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectEventLog> ProjectReralist = new List<ClsPrp_AuthorityDesk_QUpdatesProjectEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectEventLogs", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdates_ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterYear", QUpdates_QuarterYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdates_QuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectEventLog
                       {
                           QUpdateProjectEventAction_ID = Convert.ToInt64(dr["QUpdateProjectEventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Related_QUpdateProject_Year = Convert.ToInt32(dr["Related_QUpdateProject_Year"]),
                           Related_QUpdateProject_QuarterName = Convert.ToString(dr["Related_QUpdateProject_QuarterName"]),
                           DiaryNumber_Promoter = Convert.ToString(dr["DiaryNumber_Promoter"]),
                           DiaryNumber_Project = Convert.ToString(dr["DiaryNumber_Project"]),
                           DiaryNumber_QUpdateProject = Convert.ToString(dr["DiaryNumber_QUpdateProject"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                           IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
                           ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           setQuarterValue_Year = Convert.ToString(dr["setQuarterValue_Year"]),
                           setQuarterValue_Name = Convert.ToString(dr["setQuarterValue_Name"]),
                       });
            }
            return ProjectReralist;
        }

        //Quarterly-Updates-Porject Event Master
        public List<ClsPrp_AuthorityDesk_QUpdatesProjectEvent_Master> Display_AuthorityDesk_QuarterlyUpdatesProjectEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectEvent_Master> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProjectEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectEvent_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectEvent_Master
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
            return ProjectList;
        }

        public bool Add_QuarterlyUpdatesProject_InfoEvent(ClsPrp_AuthorityDesk_QUpdatesProjectEventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_QuarterlyUpdate_EventAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectEventAction_ID", smodel.QUpdateProjectEventAction_ID);
            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", smodel.Related_Promoter_ID);
            cmd.Parameters.AddWithValue("p_Related_Project_ID", smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_Related_QUpdateProject_Year", smodel.Related_QUpdateProject_Year);
            cmd.Parameters.AddWithValue("p_Related_QUpdateProject_QuarterName", String.IsNullOrEmpty(smodel.Related_QUpdateProject_QuarterName) ? "" : smodel.Related_QUpdateProject_QuarterName);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Promoter", String.IsNullOrEmpty(smodel.DiaryNumber_Project) ? "" : smodel.DiaryNumber_Project);
            cmd.Parameters.AddWithValue("p_DiaryNumber_Project", String.IsNullOrEmpty(smodel.RERAregistrationNumber) ? "" : smodel.RERAregistrationNumber);
            cmd.Parameters.AddWithValue("p_DiaryNumber_QUpdateProject", String.IsNullOrEmpty(smodel.DiaryNumber_QUpdateProject) ? "" : smodel.DiaryNumber_QUpdateProject);
            cmd.Parameters.AddWithValue("p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_EventAction_Relationship", UserRole);
            cmd.Parameters.AddWithValue("p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_IsBefore_TargetResolution", 0);
            cmd.Parameters.AddWithValue("p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
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

        //Quarterly-Updates-ToolbarSummarySheet
        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords> Display_AuthDesk_QuarterlyUpdatesProjectsToolbarSummarySheet_ByUserID(Int64 QUpdates_ProjectID, Int64 QUpdates_PromoterID, Int32 QUpdates_Flag, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords> ProjectReralist = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectToolbarDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdates_ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdatesPromoterID", QUpdates_PromoterID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords
                       {
                           QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                           QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                           QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                           QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                           QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                           QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           PromoterID = Convert.ToInt64(dr["PromoterID"]),
                           ProjectID = Convert.ToInt64(dr["ProjectID"]),
                           InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                           ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                           GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                           InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                           ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                           ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),
                           RERAnumber = Convert.ToString(dr["RERAnumber"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberVlaidUptoDate = Convert.ToDateTime(dr["RERAnumberVlaidUptoDate"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           setQuarterValue_Year = Convert.ToString(dr["setQuarterValue_Year"]),
                           setQuarterValue_Name = Convert.ToString(dr["setQuarterValue_Name"]),
                           QuarterlySubmittedDate = Convert.ToDateTime(dr["QuarterlySubmittedDate"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                       });
            }
            return ProjectReralist;
        }
    }
}