using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_Project_ExtensionFormDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        // Save Method
        public bool Add_Project_ExtensionFormEdocuments(Clsprp_Project_ExtensionFormEdocuments smodel, Int64 oPromoter_ID, String oFormEdoc_FilePath, String oFormEdoc_FileName, String oFormEdoc_FileSize, String oFormEdoc_FileFormat, Int32 oFormEdoc_IsGroup, Int64 oFormEdoc_ProjectID, String oProject_DiaryNumberID, String oProject_RERAnumber, string oUserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_ExtensionFormEDocuments", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            cmd.Parameters.AddWithValue("p_FormE_IndexID", 0);
            cmd.Parameters.AddWithValue("p_FormE_ID", (smodel.FormE_ID == 0) ? 0 : smodel.FormE_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oFormEdoc_ProjectID);

            cmd.Parameters.AddWithValue("p_ProjectExtension_NameID", (smodel.ProjectExtension_NameID == 0) ? 0 : smodel.ProjectExtension_NameID);
            cmd.Parameters.AddWithValue("p_ProjectExtension_NameYear", (smodel.ProjectExtension_NameYear == 0) ? 0 : smodel.ProjectExtension_NameYear);
            cmd.Parameters.AddWithValue("p_ProjectExtension_Name", String.IsNullOrEmpty(smodel.ProjectExtension_Name) ? "" : smodel.ProjectExtension_Name);

            cmd.Parameters.AddWithValue("p_Project_DiaryNumberID", String.IsNullOrEmpty(oProject_DiaryNumberID) ? "" : oProject_DiaryNumberID);
            cmd.Parameters.AddWithValue("p_Project_RERAnumber", String.IsNullOrEmpty(smodel.Project_RERAnumber) ? "" : smodel.Project_RERAnumber);
            cmd.Parameters.AddWithValue("p_Project_RERANumberIssueDate", smodel.Project_RERANumberIssueDate == null ? dtvalue : smodel.Project_RERANumberIssueDate);
            cmd.Parameters.AddWithValue("p_Project_RERANumberValiduptoDate", smodel.Project_RERANumberValiduptoDate == null ? dtvalue : smodel.Project_RERANumberValiduptoDate);

            cmd.Parameters.AddWithValue("p_FormE_DocIssueDate", smodel.FormE_DocIssueDate == null ? dtvalue : smodel.FormE_DocIssueDate);
            cmd.Parameters.AddWithValue("p_FormE_ExtensionAppliedReason", String.IsNullOrEmpty(smodel.FormE_ExtensionAppliedReason) ? "" : smodel.FormE_ExtensionAppliedReason);
            cmd.Parameters.AddWithValue("p_FormE_ExtensionAppliedReasonSpecifyOthers", String.IsNullOrEmpty(smodel.FormE_ExtensionAppliedReasonSpecifyOthers) ? "" : smodel.FormE_ExtensionAppliedReasonSpecifyOthers);

            cmd.Parameters.AddWithValue("p_FormE_DocInfoCode", smodel.FormE_DocInfoCode);
            cmd.Parameters.AddWithValue("p_FormE_DocInfoName", String.IsNullOrEmpty(smodel.FormE_DocInfoName) ? "" : smodel.FormE_DocInfoName);
            cmd.Parameters.AddWithValue("p_FormE_DocRelatedSectionName", String.IsNullOrEmpty(smodel.FormE_DocRelatedSectionName) ? "" : smodel.FormE_DocRelatedSectionName);
            cmd.Parameters.AddWithValue("p_FormE_DocReferenceNumber", smodel.FormE_DocReferenceNumber);
            
            cmd.Parameters.AddWithValue("p_FormE_DocFileSize", oFormEdoc_FileSize);
            cmd.Parameters.AddWithValue("p_FormE_DocFileFormat", oFormEdoc_FileFormat);
            cmd.Parameters.AddWithValue("p_FormE_DocFilePath", oFormEdoc_FilePath);
            cmd.Parameters.AddWithValue("p_FormE_DocFileName", oFormEdoc_FileName);
            cmd.Parameters.AddWithValue("p_FormE_DocIsGroup", oFormEdoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Summary_IfAny", String.IsNullOrEmpty(smodel.Summary_IfAny) ? "" : smodel.Summary_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
   
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsTemp", 1);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", oUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", oUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);         

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
                
        // Display Project Extension Documents By ProjectID
        public List<Clsprp_Project_ExtensionFormEdocuments> Display_Project_ExtensionFormDocuments_ByProjectId(Int64? ProjectId)
        {
            connection();
            List<Clsprp_Project_ExtensionFormEdocuments> Promoter_Documents_PromoterId = new List<Clsprp_Project_ExtensionFormEdocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ExtensionFormDocuments_Project_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_Project_ExtensionFormEdocuments
                    {
                        FormE_IndexID = Convert.ToInt64(dr["FormE_IndexID"]),
                        FormE_ID = Convert.ToInt64(dr["FormE_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),

                        ProjectExtension_NameID = Convert.ToInt64(dr["ProjectExtension_NameID"]),
                        ProjectExtension_NameYear = Convert.ToInt32(dr["ProjectExtension_NameYear"]),
                        ProjectExtension_Name = Convert.ToString(dr["ProjectExtension_Name"]),

                        Project_DiaryNumberID = Convert.ToString(dr["Project_DiaryNumberID"]),
                        Project_RERAnumber = Convert.ToString(dr["Project_RERAnumber"]),
                        Project_RERANumberIssueDate = Convert.ToDateTime(dr["Project_RERANumberIssueDate"]),
                        Project_RERANumberValiduptoDate = Convert.ToDateTime(dr["Project_RERANumberValiduptoDate"]),

                        FormE_DocIssueDate = Convert.ToDateTime(dr["FormE_DocIssueDate"]),
                        FormE_ExtensionAppliedReason = Convert.ToString(dr["FormE_ExtensionAppliedReason"]),
                        FormE_ExtensionAppliedReasonSpecifyOthers = Convert.ToString(dr["FormE_ExtensionAppliedReasonSpecifyOthers"]),

                        FormE_DocInfoCode = Convert.ToInt32(dr["FormE_DocInfoCode"]),
                        FormE_DocInfoName = Convert.ToString(dr["FormE_DocInfoName"]),
                        FormE_DocRelatedSectionName = Convert.ToString(dr["FormE_DocRelatedSectionName"]),
                        FormE_DocReferenceNumber = Convert.ToString(dr["FormE_DocReferenceNumber"]),

                        FormE_DocFileSize = Convert.ToString(dr["FormE_DocFileSize"]),
                        FormE_DocFileFormat = Convert.ToString(dr["FormE_DocFileFormat"]),
                        FormE_DocFilePath = Convert.ToString(dr["FormE_DocFilePath"]),
                        FormE_DocFileName = Convert.ToString(dr["FormE_DocFileName"]),
                        FormE_DocIsGroup = Convert.ToInt32(dr["FormE_DocIsGroup"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        Summary_IfAny = Convert.ToString(dr["Summary_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsTemp = Convert.ToInt32(dr["IsTemp"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                    });
            }
            return Promoter_Documents_PromoterId;
        }

        // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64> Display_Project_ExtensionFormDocuments_ByDocCodeInfoProjectID(Int64 Project_ID, Int64 ProjectDoc_InfoCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ExtFormEDocuments_ByDocCodeInfoPromoterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectFormE_InfoCode", ProjectDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectFormE_ID", Project_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"] );
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }

        // Delete Project Extension Documents By ProjectID And IndexID  
        public bool Delete_Project_ExtensionFormDocument(Int64? oProjectExtensionDoc_IndexID, Int64? oProjectExtensionDoc_ID, Int64? oProjectExtension_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_ExtensionFormEDocuments_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectFormE_IndexID", oProjectExtensionDoc_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectFormE_ID", oProjectExtensionDoc_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oProjectExtension_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Clsprp_Project_ExtensionFormEdocumentsUploadedList> Display_Project_ExtensionFormDocumentsUploadedList_ByProjectId(Int64? ProjectId)
        {
            connection();
            List<Clsprp_Project_ExtensionFormEdocumentsUploadedList> Promoter_Documents_PromoterId = new List<Clsprp_Project_ExtensionFormEdocumentsUploadedList>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ExtensionFormDocUploadedList_Project_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_Project_ExtensionFormEdocumentsUploadedList
                    {
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                    });
            }
            return Promoter_Documents_PromoterId;
        }

        // Display Project Extension RERA Number, Issue Date and ValidUpto Date By ProjectID
        public List<Clsprp_Project_ExtensionFormEdocuments> Display_Project_ExtensionFormRERAnumberdetails_ByProjectId(Int64? ProjectId)
        {
            connection();
            List<Clsprp_Project_ExtensionFormEdocuments> Projectlist = new List<Clsprp_Project_ExtensionFormEdocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ExtensionFormRERAdetails_Project_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                    new Clsprp_Project_ExtensionFormEdocuments
                    {
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        Project_RERAnumber = Convert.ToString(dr["Project_RERAnumber"]),
                        Project_RERANumberIssueDate = Convert.ToDateTime(dr["Project_RERANumberIssueDate"]),
                        Project_RERANumberValiduptoDate = Convert.ToDateTime(dr["Project_RERANumberValiduptoDate"]),
                    });
            }
            return Projectlist;
        }

    }
}