using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsMethod_View_CP_FileRearrangementProjectDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //File Re-arrangement Panel - Project Documents
        public List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> Display_CP_ProjectFileRearrangementPanelDetails_ByID(Int32 pApplicationFlag, string pRegistrationNumber, string pApplicationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_Project_FileRearrangementProjectDocument_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ApplicationFlag", pApplicationFlag);
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ApplicationNumber", pApplicationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        IsRERAregisteredProject = Convert.ToInt32(dr["IsRERAregisteredProject"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),

                        Extra01_column = Convert.ToString(dr["Extra01_column"]),
                        Extra02_column = Convert.ToString(dr["Extra02_column"]),
                    });
            }
            return CPstatusList;
        }

        public List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> Display_CP_ProjectFileRearrangementPanelSelectedRecord_ByID(Int64 mprojectId, Int64 mpromoterId, Int64 mrefdocId, Int64 mrefindexId, Int64 mrefId, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_Project_FileModifyProjectSelectedRecord_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectID", mprojectId);
            cmd.Parameters.AddWithValue("p_PromoterID", mpromoterId);
            cmd.Parameters.AddWithValue("p_RefDocID", mrefdocId);
            cmd.Parameters.AddWithValue("p_RefIndexID", mrefindexId);
            cmd.Parameters.AddWithValue("p_RefID", mrefId);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),                       
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                    });
            }
            return CPstatusList;
        }

        public Tuple<bool, string> Update_CP_ProjectDocuments_FileRearrangementPanel_ByID(ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails smodel, string User_Name, string User_ID, string User_Role)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_CP_FileRearrangementPanel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters           
            cmd.Parameters.AddWithValue("p_ProjectDoc_IndexID", (smodel.ProjectDoc_IndexID == 0) ? 0 : smodel.ProjectDoc_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectDoc_ID", (smodel.ProjectDoc_ID == 0) ? 0 : smodel.ProjectDoc_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", (smodel.Promoter_ID == 0) ? 0 : smodel.Promoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", (smodel.Project_ID == 0) ? 0 : smodel.Project_ID);
            cmd.Parameters.AddWithValue("p_User_ID", User_ID);
            cmd.Parameters.AddWithValue("p_User_Role", User_Role);

            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoCode", (smodel.ProjectDoc_InfoCode == 0) ? 0 : smodel.ProjectDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoName", String.IsNullOrEmpty(smodel.ProjectDoc_InfoName) ? string.Empty : smodel.ProjectDoc_InfoName);
            cmd.Parameters.AddWithValue("p_ProjectDoc_RelatedSectionName", String.IsNullOrEmpty(smodel.ProjectDoc_RelatedSectionName) ? string.Empty : smodel.ProjectDoc_RelatedSectionName);
            cmd.Parameters.AddWithValue("p_ProjectDoc_ReferenceNumber", String.IsNullOrEmpty(smodel.ProjectDoc_ReferenceNumber) ? string.Empty : smodel.ProjectDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ProjectDoc_IssueDate", smodel.ProjectDoc_IssueDate.HasValue ? smodel.ProjectDoc_IssueDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_ProjectDoc_FileSize", String.IsNullOrEmpty(smodel.ProjectDoc_FileSize) ? string.Empty : smodel.ProjectDoc_FileSize);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FileFormat", String.IsNullOrEmpty(smodel.ProjectDoc_FileFormat) ? string.Empty : smodel.ProjectDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FilePath", String.IsNullOrEmpty(smodel.ProjectDoc_FilePath) ? string.Empty : smodel.ProjectDoc_FilePath);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FileName", String.IsNullOrEmpty(smodel.ProjectDoc_FileName) ? string.Empty : smodel.ProjectDoc_FileName);
            cmd.Parameters.AddWithValue("p_ProjectDoc_IsGroup", (smodel.ProjectDoc_IsGroup == 0) ? 0 : smodel.ProjectDoc_IsGroup);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? string.Empty : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? string.Empty : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? string.Empty : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? string.Empty : smodel.D_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            cmd.Parameters.AddWithValue("p_Project_DiaryNumber", String.IsNullOrEmpty(smodel.Project_DiaryNumber) ? string.Empty : smodel.Project_DiaryNumber);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationNumber", String.IsNullOrEmpty(smodel.RERA_RegistrationNumber) ? string.Empty : smodel.RERA_RegistrationNumber);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_IsRERAregisteredProject", (smodel.IsRERAregisteredProject == 0) ? 0 : smodel.IsRERAregisteredProject);
            cmd.Parameters.AddWithValue("p_Extra01_column", String.IsNullOrEmpty(smodel.Extra01_column) ? string.Empty : smodel.Extra01_column);
            cmd.Parameters.AddWithValue("p_Extra02_column", String.IsNullOrEmpty(smodel.Extra02_column) ? string.Empty : smodel.Extra02_column);

            cmd.Parameters.AddWithValue("p_Application_SearchTypeFlag", (smodel.Application_SearchTypeFlag == 0) ? 0 : smodel.Application_SearchTypeFlag);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration_Input", String.IsNullOrEmpty(smodel.RERAnumberRegistration_Input) ? string.Empty : smodel.RERAnumberRegistration_Input);
            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber_Input", String.IsNullOrEmpty(smodel.ProjectDiaryNumber_Input) ? string.Empty : smodel.ProjectDiaryNumber_Input);
            cmd.Parameters.AddWithValue("p_IsUpdateModifyFlag_ProjectDocument", (smodel.IsUpdateModifyFlag_ProjectDocument == 0) ? 0 : smodel.IsUpdateModifyFlag_ProjectDocument);
            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoCode_Input", (smodel.ProjectDoc_InfoCode_Input == 0) ? 0 : smodel.ProjectDoc_InfoCode_Input);
            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoCode_ConfirmInput", (smodel.ProjectDoc_InfoCode_ConfirmInput == 0) ? 0 : smodel.ProjectDoc_InfoCode_ConfirmInput);
            cmd.Parameters.AddWithValue("p_ProjectDoc_ReferenceNumber_Input", String.IsNullOrEmpty(smodel.ProjectDoc_ReferenceNumber_Input) ? string.Empty : smodel.ProjectDoc_ReferenceNumber_Input);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny_Input", String.IsNullOrEmpty(smodel.Remarks_IfAny_Input) ? string.Empty : smodel.Remarks_IfAny_Input);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }

        public Tuple<bool, string> Delete_CP_ProjectDocuments_FileRearrangementPanel_ByID(ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails smodel, string User_Name, string User_ID, string User_Role)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_deleteTrash_tbl_rera_project_CP_FileRearrangementPanel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters           
            cmd.Parameters.AddWithValue("p_ProjectDoc_IndexID", (smodel.ProjectDoc_IndexID == 0) ? 0 : smodel.ProjectDoc_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectDoc_ID", (smodel.ProjectDoc_ID == 0) ? 0 : smodel.ProjectDoc_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", (smodel.Promoter_ID == 0) ? 0 : smodel.Promoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", (smodel.Project_ID == 0) ? 0 : smodel.Project_ID);
            cmd.Parameters.AddWithValue("p_User_ID", User_ID);
            cmd.Parameters.AddWithValue("p_User_Role", User_Role);

            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoCode", (smodel.ProjectDoc_InfoCode == 0) ? 0 : smodel.ProjectDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoName", String.IsNullOrEmpty(smodel.ProjectDoc_InfoName) ? string.Empty : smodel.ProjectDoc_InfoName);

            cmd.Parameters.AddWithValue("p_Project_DiaryNumber", String.IsNullOrEmpty(smodel.Project_DiaryNumber) ? string.Empty : smodel.Project_DiaryNumber);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationNumber", String.IsNullOrEmpty(smodel.RERA_RegistrationNumber) ? string.Empty : smodel.RERA_RegistrationNumber);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate : DateTime.MinValue);

            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_IsRERAregisteredProject", (smodel.IsRERAregisteredProject == 0) ? 0 : smodel.IsRERAregisteredProject);
            cmd.Parameters.AddWithValue("p_Extra01_column", String.IsNullOrEmpty(smodel.Extra01_column) ? string.Empty : smodel.Extra01_column);
            cmd.Parameters.AddWithValue("p_Extra02_column", String.IsNullOrEmpty(smodel.Extra02_column) ? string.Empty : smodel.Extra02_column);

            cmd.Parameters.AddWithValue("p_Application_SearchTypeFlag", (smodel.Application_SearchTypeFlag == 0) ? 0 : smodel.Application_SearchTypeFlag);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration_Input", String.IsNullOrEmpty(smodel.RERAnumberRegistration_Input) ? string.Empty : smodel.RERAnumberRegistration_Input);
            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber_Input", String.IsNullOrEmpty(smodel.ProjectDiaryNumber_Input) ? string.Empty : smodel.ProjectDiaryNumber_Input);
            cmd.Parameters.AddWithValue("p_IsUpdateModifyFlag_ProjectDocument", (smodel.IsUpdateModifyFlag_ProjectDocument == 0) ? 0 : smodel.IsUpdateModifyFlag_ProjectDocument);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }

        //File Re-arrangement Add More - Project Documents
        public List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> Display_CP_ProjectFileRearrangementAddMoreDetails_ByID(Int32 pApplicationFlag, string pReferenceNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_Project_FileRearrangementProjectDocsAddDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ApplicationFlag", pApplicationFlag);
            cmd.Parameters.AddWithValue("p_ReferenceNumber", pReferenceNumber);            
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        IsRERAregisteredProject = Convert.ToInt32(dr["IsRERAregisteredProject"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),

                        Extra01_column = Convert.ToString(dr["Extra01_column"]),
                        Extra02_column = Convert.ToString(dr["Extra02_column"]),
                    });
            }
            return CPstatusList;
        }

        public bool Add_Project_FileReArrangementDocuments(ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails smodel, Int64 oPromoter_ID, String oPromoterDoc_FilePath, String oPromoterDoc_FileName, String oPromoterDoc_FileSize, String oPromoterDoc_FileFormat, Int32 oPromoterDoc_IsGroup, Int64 oPromoterDoc_ProjectID)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_Documents_FileReArrangement", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectDoc_IndexID", 0);
            cmd.Parameters.AddWithValue("p_ProjectDoc_ID", (smodel.ProjectDoc_ID == 0) ? 0 : smodel.ProjectDoc_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oPromoterDoc_ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoCode", smodel.ProjectDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectDoc_InfoName", String.IsNullOrEmpty(smodel.ProjectDoc_InfoName) ? "" : smodel.ProjectDoc_InfoName);
            cmd.Parameters.AddWithValue("p_ProjectDoc_RelatedSectionName", String.IsNullOrEmpty(smodel.ProjectDoc_RelatedSectionName) ? "" : smodel.ProjectDoc_RelatedSectionName);
            cmd.Parameters.AddWithValue("p_ProjectDoc_ReferenceNumber", smodel.ProjectDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ProjectDoc_IssueDate", smodel.ProjectDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FileSize", oPromoterDoc_FileSize);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FileFormat", oPromoterDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FilePath", oPromoterDoc_FilePath);
            cmd.Parameters.AddWithValue("p_ProjectDoc_FileName", oPromoterDoc_FileName);
            cmd.Parameters.AddWithValue("p_ProjectDoc_IsGroup", oPromoterDoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(smodel.CreatedBy) ? "Created_By" : smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(smodel.ModifyBy) ? "Modify_By" : smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

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