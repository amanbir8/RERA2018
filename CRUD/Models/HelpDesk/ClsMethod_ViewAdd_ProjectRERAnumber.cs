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
    public class ClsMethod_ViewAdd_ProjectRERAnumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber> Display_AuthDesk_ProjectRERAnumber_ByProjectIdandDiaryNumber(Int64 ProjectId, Int64 PromoterId)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber> ProjectReraList = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RERAnumberRegistration_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReraList.Add(
                    new ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber
                    {
                        Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                        Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                        ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                        ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                        ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                        ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                        ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),

                        PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                        PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                        PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                        PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                        PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                        ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                        ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                        ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                        ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                        ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                        IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                        ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                        PromoterType = Convert.ToInt32(dr["PromoterType"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                        PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                        ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                        ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                        ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                        ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                        ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                        ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                        AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                        AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                        AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                        AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                        AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                        AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                        AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                        AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                        AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Extra4 = Convert.ToString(dr["Extra4"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                        IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                        IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                        IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return ProjectReraList;
        }

        /// Save Method        
        public bool Add_LDR_Project_RERAnumber_DiaryNumber(ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber smodel, string User_Name, Int64 oProject_ID, Int64 oPromoter_ID, string oProjectDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Project_RERAnumber_DiaryNumber_IndexID", (smodel.Project_RERAnumber_DiaryNumber_IndexID == 0) ? 0 : smodel.Project_RERAnumber_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Project_RERAnumber_DiaryNumber_ID", (smodel.Project_RERAnumber_DiaryNumber_ID == 0) ? 0 : smodel.Project_RERAnumber_DiaryNumber_ID);

            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_ID", (smodel.ProjectRegDiaryNumber_ID == 0) ? 0 : smodel.ProjectRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.ProjectRegDiaryNumber_Name) ? "" : smodel.ProjectRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.ProjectRegDiaryNumber_NameYear) ? "" : smodel.ProjectRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_tbl_IndexID", (smodel.ProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.ProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_CreatedDate", smodel.ProjectRegDiaryNumber_CreatedDate);

            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);

            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_ID", (smodel.PromoterRegDiaryNumber_ID == 0) ? 0 : smodel.PromoterRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.PromoterRegDiaryNumber_Name) ? "" : smodel.PromoterRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.PromoterRegDiaryNumber_NameYear) ? "" : smodel.PromoterRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_tbl_IndexID", (smodel.PromoterRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.PromoterRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_CreatedDate", smodel.PromoterRegDiaryNumber_CreatedDate);

            cmd.Parameters.AddWithValue("p_ProjectQuarterlyRegDiaryNumber_ID", (smodel.ProjectQuarterlyRegDiaryNumber_ID == 0) ? 0 : smodel.ProjectQuarterlyRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_ProjectQuarterly_QuarterName", String.IsNullOrEmpty(smodel.ProjectQuarterly_QuarterName) ? "" : smodel.ProjectQuarterly_QuarterName);
            cmd.Parameters.AddWithValue("p_ProjectQuarterly_QuarterYear", (smodel.ProjectQuarterly_QuarterYear == 0) ? 0 : smodel.ProjectQuarterly_QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectQuarterlyRegDiaryNumber_tbl_IndexID", (smodel.ProjectQuarterlyRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.ProjectQuarterlyRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectQuarterly_CreatedDate", smodel.ProjectQuarterly_CreatedDate);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? "" : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? "" : smodel.ExistingRegistration);

            cmd.Parameters.AddWithValue("p_PromoterType", (smodel.PromoterType == 0) ? 0 : smodel.PromoterType);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterWebLink", String.IsNullOrEmpty(smodel.PromoterWebLink) ? "" : smodel.PromoterWebLink);
            cmd.Parameters.AddWithValue("p_PromoterAuthSignFormB", String.IsNullOrEmpty(smodel.PromoterAuthSignFormB) ? "" : smodel.PromoterAuthSignFormB);

            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine1", String.IsNullOrEmpty(smodel.ProjectAddressLine1) ? "" : smodel.ProjectAddressLine1);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine2", String.IsNullOrEmpty(smodel.ProjectAddressLine2) ? "" : smodel.ProjectAddressLine2);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? "" : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_ProjectAddressState", String.IsNullOrEmpty(smodel.ProjectAddressState) ? "" : smodel.ProjectAddressState);
            cmd.Parameters.AddWithValue("p_ProjectAddressSubDivision", String.IsNullOrEmpty(smodel.ProjectAddressSubDivision) ? "" : smodel.ProjectAddressSubDivision);
            cmd.Parameters.AddWithValue("p_ProjectAddressPIN", String.IsNullOrEmpty(smodel.ProjectAddressPIN) ? "" : smodel.ProjectAddressPIN);
            cmd.Parameters.AddWithValue("p_ProjectPotentialZone", String.IsNullOrEmpty(smodel.ProjectPotentialZone) ? "" : smodel.ProjectPotentialZone);
            cmd.Parameters.AddWithValue("p_ProjectWebLink", String.IsNullOrEmpty(smodel.ProjectWebLink) ? "" : smodel.ProjectWebLink);

            cmd.Parameters.AddWithValue("p_AuthorizedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorizedPerson_FirstName) ? "" : smodel.AuthorizedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedPerson_LastName) ? "" : smodel.AuthorizedPerson_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine1) ? "" : smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? "" : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_District", String.IsNullOrEmpty(smodel.AuthorizedPerson_District) ? "" : smodel.AuthorizedPerson_District);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_State", String.IsNullOrEmpty(smodel.AuthorizedPerson_State) ? "" : smodel.AuthorizedPerson_State);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_PIN", String.IsNullOrEmpty(smodel.AuthorizedPerson_PIN) ? "" : smodel.AuthorizedPerson_PIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Email", String.IsNullOrEmpty(smodel.AuthorizedPerson_Email) ? "" : smodel.AuthorizedPerson_Email);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Mobile", String.IsNullOrEmpty(smodel.AuthorizedPerson_Mobile) ? "" : smodel.AuthorizedPerson_Mobile);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? "" : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", (smodel.IsExtensionIssued == 0) ? 0 : smodel.IsExtensionIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// Update Method        
        public bool Update_LDR_Project_RERAnumber_DiaryNumber(ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber smodel, string User_Name, Int64 oProject_ID, Int64 oPromoter_ID, string oProjectDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Project_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Project_RERAnumber_DiaryNumber_IndexID", (smodel.Project_RERAnumber_DiaryNumber_IndexID == 0) ? 0 : smodel.Project_RERAnumber_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Project_RERAnumber_DiaryNumber_ID", (smodel.Project_RERAnumber_DiaryNumber_ID == 0) ? 0 : smodel.Project_RERAnumber_DiaryNumber_ID);

            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_ID", (smodel.ProjectRegDiaryNumber_ID == 0) ? 0 : smodel.ProjectRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.ProjectRegDiaryNumber_Name) ? "" : smodel.ProjectRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.ProjectRegDiaryNumber_NameYear) ? "" : smodel.ProjectRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_tbl_IndexID", (smodel.ProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.ProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_CreatedDate", smodel.ProjectRegDiaryNumber_CreatedDate);

            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);

            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_ID", (smodel.PromoterRegDiaryNumber_ID == 0) ? 0 : smodel.PromoterRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.PromoterRegDiaryNumber_Name) ? "" : smodel.PromoterRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.PromoterRegDiaryNumber_NameYear) ? "" : smodel.PromoterRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_tbl_IndexID", (smodel.PromoterRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.PromoterRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_CreatedDate", smodel.PromoterRegDiaryNumber_CreatedDate);

            cmd.Parameters.AddWithValue("p_ProjectQuarterlyRegDiaryNumber_ID", (smodel.ProjectQuarterlyRegDiaryNumber_ID == 0) ? 0 : smodel.ProjectQuarterlyRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_ProjectQuarterly_QuarterName", String.IsNullOrEmpty(smodel.ProjectQuarterly_QuarterName) ? "" : smodel.ProjectQuarterly_QuarterName);
            cmd.Parameters.AddWithValue("p_ProjectQuarterly_QuarterYear", (smodel.ProjectQuarterly_QuarterYear == 0) ? 0 : smodel.ProjectQuarterly_QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectQuarterlyRegDiaryNumber_tbl_IndexID", (smodel.ProjectQuarterlyRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.ProjectQuarterlyRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectQuarterly_CreatedDate", smodel.ProjectQuarterly_CreatedDate);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? "" : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? "" : smodel.ExistingRegistration);

            cmd.Parameters.AddWithValue("p_PromoterType", (smodel.PromoterType == 0) ? 0 : smodel.PromoterType);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterWebLink", String.IsNullOrEmpty(smodel.PromoterWebLink) ? "" : smodel.PromoterWebLink);
            cmd.Parameters.AddWithValue("p_PromoterAuthSignFormB", String.IsNullOrEmpty(smodel.PromoterAuthSignFormB) ? "" : smodel.PromoterAuthSignFormB);

            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine1", String.IsNullOrEmpty(smodel.ProjectAddressLine1) ? "" : smodel.ProjectAddressLine1);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine2", String.IsNullOrEmpty(smodel.ProjectAddressLine2) ? "" : smodel.ProjectAddressLine2);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? "" : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_ProjectAddressState", String.IsNullOrEmpty(smodel.ProjectAddressState) ? "" : smodel.ProjectAddressState);
            cmd.Parameters.AddWithValue("p_ProjectAddressSubDivision", String.IsNullOrEmpty(smodel.ProjectAddressSubDivision) ? "" : smodel.ProjectAddressSubDivision);
            cmd.Parameters.AddWithValue("p_ProjectAddressPIN", String.IsNullOrEmpty(smodel.ProjectAddressPIN) ? "" : smodel.ProjectAddressPIN);
            cmd.Parameters.AddWithValue("p_ProjectPotentialZone", String.IsNullOrEmpty(smodel.ProjectPotentialZone) ? "" : smodel.ProjectPotentialZone);
            cmd.Parameters.AddWithValue("p_ProjectWebLink", String.IsNullOrEmpty(smodel.ProjectWebLink) ? "" : smodel.ProjectWebLink);

            cmd.Parameters.AddWithValue("p_AuthorizedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorizedPerson_FirstName) ? "" : smodel.AuthorizedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedPerson_LastName) ? "" : smodel.AuthorizedPerson_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine1) ? "" : smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? "" : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_District", String.IsNullOrEmpty(smodel.AuthorizedPerson_District) ? "" : smodel.AuthorizedPerson_District);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_State", String.IsNullOrEmpty(smodel.AuthorizedPerson_State) ? "" : smodel.AuthorizedPerson_State);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_PIN", String.IsNullOrEmpty(smodel.AuthorizedPerson_PIN) ? "" : smodel.AuthorizedPerson_PIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Email", String.IsNullOrEmpty(smodel.AuthorizedPerson_Email) ? "" : smodel.AuthorizedPerson_Email);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Mobile", String.IsNullOrEmpty(smodel.AuthorizedPerson_Mobile) ? "" : smodel.AuthorizedPerson_Mobile);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? "" : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", (smodel.IsExtensionIssued == 0) ? 0 : smodel.IsExtensionIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails> Display_AuthDesk_ProjectRERAnumberDiaryNumberDashBoard_ByUserID(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails> ProjectReralist = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegRERAnumberDetails", con);
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
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                           ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails> Display_AuthDesk_ProjectRERAnumberDiaryNumberDashBoard_BySearchterm(string UserID_Role, string serachterm, string searchtype)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails> ProjectReralist = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegRERAnoDetailsBySearch", con);
            //MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_test", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_searchterm", serachterm);
            cmd.Parameters.AddWithValue("p_searchtype", searchtype);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                           ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }

        public List<searchhelpdesk> DisplayBySearchterm(string UserID_Role, string serachterm, string searchtype)
        {
            connection();
            List<searchhelpdesk> ProjectReralist = new List<searchhelpdesk>();

            MySqlCommand cmd = new MySqlCommand("DisplayBySearch", con);
            //MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_test", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_searchterm", serachterm);
            cmd.Parameters.AddWithValue("p_searchtype", searchtype);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new searchhelpdesk
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = dr["Project_RERAnumber_DiaryNumber_IndexID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = dr["Project_RERAnumber_DiaryNumber_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = dr["ProjectRegDiaryNumber_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"] ?? ""),
                           //ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = dr["ProjectRegDiaryNumber_tbl_IndexID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = dr["ProjectRegDiaryNumber_CreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Project_ID = dr["Project_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = dr["Promoter_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Promoter_ID"]),
                           //User_ID = Convert.ToString(dr["User_ID"]),

                           // PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"] ?? ""),
                           // PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           //PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = dr["PromoterRegDiaryNumber_CreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = dr["ProjectQuarterlyRegDiaryNumber_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"] ?? ""),
                           ProjectQuarterly_QuarterYear = dr["ProjectQuarterly_QuarterYear"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           // ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = dr["ProjectQuarterly_CreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"] ?? ""),
                           //IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           //ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           // PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           //PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           //PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"] ?? ""),
                           PromoterName = Convert.ToString(dr["PromoterName"] ?? ""),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"] ?? ""),
                           //ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"] ?? ""),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"] ?? ""),
                           //ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           // ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           // ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           //ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           //AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           //AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           //AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           //AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           //AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           //AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           //AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           //AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           //AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberIssueDate = dr["RERAnumberIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = dr["RERAnumberRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"] ?? ""),

                           rcdProjectRERAcertInfoName = Convert.ToString(dr["rcdProjectRERAcertInfoName"] ?? ""),
                           rcdProjectRERAcertIssueDate = dr["rcdProjectRERAcertIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rcdProjectRERAcertIssueDate"]),
                           rcdProjectRERAcertFilePath = Convert.ToString(dr["rcdProjectRERAcertFilePath"] ?? ""),
                           rcdProjectRERAcertFileName = Convert.ToString(dr["rcdProjectRERAcertFileName"] ?? ""),
                           ////ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           rcdRemarksIfAny = Convert.ToString(dr["rcdRemarksIfAny"]),


                           //rceProjectRERAcertInfoName = Convert.ToString(dr["rceProjectRERAcertInfoName"]??""),
                           //rceProjectRERAcertReferenceNumber = Convert.ToString(dr["rceProjectRERAcertReferenceNumber"]??""),
                           //rceProjectRERAcertFilePath = Convert.ToString(dr["rceProjectRERAcertFilePath"]??""),
                           //rceProjectRERAcertFileName = Convert.ToString(dr["rceProjectRERAcertFileName"]??""),
                           //rceRERAnumberRegistration = Convert.ToString(dr["rceRERAnumberRegistration"]??""),
                           //rceExtnRegistrationIssueDate = dr["rceExtnRegistrationIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rceExtnRegistrationIssueDate"]),
                           //rceExtnRegistrationRegUptoDate = dr["rceExtnRegistrationRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rceExtnRegistrationRegUptoDate"]),


                           //rccPCCInfoDetails = Convert.ToString(dr["rccPCCInfoDetails"]??""),
                           //rccPCCReferenceName = Convert.ToString(dr["rccPCCReferenceName"]??""),
                           //rccPCCReferenceDate = dr["rccPCCReferenceDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rccPCCReferenceDate"]),
                           //rccPCCCertificateStatus = Convert.ToString(dr["rccPCCCertificateStatus"]??""),
                           //rccPCCReciptType = Convert.ToString(dr["rccPCCReciptType"]??""),
                           //rccRemarksIfAny = Convert.ToString(dr["rccRemarksIfAny"]??""),
                           //rccExtra2 = Convert.ToString(dr["rccExtra2"]??""),
                           //rccExtra3 = Convert.ToString(dr["rccExtra3"]??""),


                           //reRelatedExtnRegDiaryNumberID = dr["reRelatedExtnRegDiaryNumberID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["reRelatedExtnRegDiaryNumberID"]),

                           //reRelatedExtnRegDiaryNumberName = Convert.ToString(dr["reRelatedExtnRegDiaryNumberName"]??""),
                           //reRelatedExtnRegDiaryNumberCreatedDate = dr["reRelatedExtnRegDiaryNumberCreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["reRelatedExtnRegDiaryNumberCreatedDate"]),
                           //reExtnRegistrationNumber = Convert.ToString(dr["reExtnRegistrationNumber"]??""),
                           //reExtnRegistrationIssueDate = dr["reExtnRegistrationIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["reExtnRegistrationIssueDate"]),
                           ExtnRegistrationRegUptoDate = dr["ExtnRegistrationRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),


                           //RevokeProjectIndexID = dr["RevokeProjectIndexID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["RevokeProjectIndexID"]),
                           //rvdRevokeProjectID = dr["rvdRevokeProjectID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["rvdRevokeProjectID"]),
                           //rvdRevokesRegDiaryNumberName = Convert.ToString(dr["rvdRevokesRegDiaryNumberName"]??""),
                           //rvdRERAnumberExtensionRegUptoDate = dr["rvdRERAnumberExtensionRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rvdRERAnumberExtensionRegUptoDate"]),
                           //rvdProjectType = Convert.ToString(dr["rvdProjectType"]??""),
                           //rvdRevokeInfoDetails = Convert.ToString(dr["rvdRevokeInfoDetails"]??""),
                           //rvdRevokeIssueAuthority = Convert.ToString(dr["rvdRevokeIssueAuthority"]??""),
                           //rvdRevokeReferenceName = Convert.ToString(dr["rvdRevokeReferenceName"]??""),
                           //rvdRevokeReferenceDate = dr["rvdRevokeReferenceDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rvdRevokeReferenceDate"]),
                           //rvdRevokeType = Convert.ToString(dr["rvdRevokeType"]??""),

                           Reg_PromoterRegDiaryNumber_Name = Convert.ToString(dr["Reg_PromoterRegDiaryNumber_Name"] ?? ""),

                           Project_Name = Convert.ToString(dr["Project_Name"] ?? ""),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"] ?? ""),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"] ?? ""),
                           Appdate = dr["Appdate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Appdate"]),




                           //Extra1 = Convert.ToString(dr["Extra1"]),
                           //Extra2 = Convert.ToString(dr["Extra2"]),
                           //Extra3 = Convert.ToString(dr["Extra3"]),
                           //Extra4 = Convert.ToString(dr["Extra4"]),

                           //IsActive = Convert.ToInt32(dr["IsActive"]),
                           //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           //IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           //IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           //IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           //IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           //IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           //IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           //IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           //IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           //Project_Name = Convert.ToString(dr["Project_Name"]),
                           //Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           //Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           ////Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           //EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           //EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           //EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           //Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           //EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           //EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           //ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           //ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           //ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           //ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }
        public List<searchhelpdesk> DisplayByExtensionSearchterm(string UserID_Role, string serachterm, string searchtype)
        {
            connection();
            List<searchhelpdesk> ProjectReralist = new List<searchhelpdesk>();

            MySqlCommand cmd = new MySqlCommand("DisplayBySearchExtension", con);
            //MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_test", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_searchterm", serachterm);
            cmd.Parameters.AddWithValue("p_searchtype", searchtype);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                ProjectReralist.Add(
                       new searchhelpdesk
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = dr["Project_RERAnumber_DiaryNumber_IndexID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = dr["Project_RERAnumber_DiaryNumber_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = dr["ProjectRegDiaryNumber_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"] ?? ""),
                           //ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = dr["ProjectRegDiaryNumber_tbl_IndexID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = dr["ProjectRegDiaryNumber_CreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Project_ID = dr["Project_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = dr["Promoter_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Promoter_ID"]),
                           //User_ID = Convert.ToString(dr["User_ID"]),

                           // PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"] ?? ""),
                           // PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           //PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = dr["PromoterRegDiaryNumber_CreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           //ProjectQuarterlyRegDiaryNumber_ID = dr["ProjectQuarterlyRegDiaryNumber_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           //ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"] ?? ""),
                           //ProjectQuarterly_QuarterYear = dr["ProjectQuarterly_QuarterYear"] == DBNull.Value ? 0 : Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           // ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           //ProjectQuarterly_CreatedDate = dr["ProjectQuarterly_CreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"] ?? ""),
                           //IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           //ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           // PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           //PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           //PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"] ?? ""),
                           PromoterName = Convert.ToString(dr["PromoterName"] ?? ""),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"] ?? ""),
                           //ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"] ?? ""),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"] ?? ""),
                           //ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           // ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           // ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           //ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           //AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           //AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           //AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           //AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           //AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           //AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           //AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           //AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           //AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberIssueDate = dr["RERAnumberIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = dr["RERAnumberRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = dr["RemarksIfAny"] == DBNull.Value? "": Convert.ToString(dr["RemarksIfAny"]),
                           rcdProjectRERAcertInfoName = dr["rcdProjectRERAcertInfoName"] == DBNull.Value? "": Convert.ToString(dr["rcdProjectRERAcertInfoName"]),
                           rcdProjectRERAcertIssueDate = dr["rcdProjectRERAcertIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rcdProjectRERAcertIssueDate"]),
                           rcdProjectRERAcertFilePath = dr["rcdProjectRERAcertFilePath"] == DBNull.Value? "": Convert.ToString(dr["rcdProjectRERAcertFilePath"]),
                           rcdProjectRERAcertFileName = dr["rcdProjectRERAcertFileName"] == DBNull.Value? "": Convert.ToString(dr["rcdProjectRERAcertFileName"]),
                           ////ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           rcdRemarksIfAny = dr["rcdRemarksIfAny"] == DBNull.Value? "": Convert.ToString(dr["RemarksIfAny"]),


                           //rceProjectRERAcertInfoName = Convert.ToString(dr["rceProjectRERAcertInfoName"]??""),
                           //rceProjectRERAcertReferenceNumber = Convert.ToString(dr["rceProjectRERAcertReferenceNumber"]??""),
                           //rceProjectRERAcertFilePath = Convert.ToString(dr["rceProjectRERAcertFilePath"]??""),
                           //rceProjectRERAcertFileName = Convert.ToString(dr["rceProjectRERAcertFileName"]??""),
                           //rceRERAnumberRegistration = Convert.ToString(dr["rceRERAnumberRegistration"]??""),
                           //rceExtnRegistrationIssueDate = dr["rceExtnRegistrationIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rceExtnRegistrationIssueDate"]),
                           //rceExtnRegistrationRegUptoDate = dr["rceExtnRegistrationRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rceExtnRegistrationRegUptoDate"]),


                           //rccPCCInfoDetails = Convert.ToString(dr["rccPCCInfoDetails"]??""),
                           //rccPCCReferenceName = Convert.ToString(dr["rccPCCReferenceName"]??""),
                           //rccPCCReferenceDate = dr["rccPCCReferenceDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rccPCCReferenceDate"]),
                           //rccPCCCertificateStatus = Convert.ToString(dr["rccPCCCertificateStatus"]??""),
                           //rccPCCReciptType = Convert.ToString(dr["rccPCCReciptType"]??""),
                           //rccRemarksIfAny = Convert.ToString(dr["rccRemarksIfAny"]??""),
                           //rccExtra2 = Convert.ToString(dr["rccExtra2"]??""),
                           //rccExtra3 = Convert.ToString(dr["rccExtra3"]??""),


                           //reRelatedExtnRegDiaryNumberID = dr["reRelatedExtnRegDiaryNumberID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["reRelatedExtnRegDiaryNumberID"]),

                           //reRelatedExtnRegDiaryNumberName = Convert.ToString(dr["reRelatedExtnRegDiaryNumberName"]??""),
                           //reRelatedExtnRegDiaryNumberCreatedDate = dr["reRelatedExtnRegDiaryNumberCreatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["reRelatedExtnRegDiaryNumberCreatedDate"]),
                           //reExtnRegistrationNumber = Convert.ToString(dr["reExtnRegistrationNumber"]??""),
                           //reExtnRegistrationIssueDate = dr["reExtnRegistrationIssueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["reExtnRegistrationIssueDate"]),
                           ExtnRegistrationRegUptoDate = dr["ExtnRegistrationRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),


                           //RevokeProjectIndexID = dr["RevokeProjectIndexID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["RevokeProjectIndexID"]),
                           //rvdRevokeProjectID = dr["rvdRevokeProjectID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["rvdRevokeProjectID"]),
                           //rvdRevokesRegDiaryNumberName = Convert.ToString(dr["rvdRevokesRegDiaryNumberName"]??""),
                           //rvdRERAnumberExtensionRegUptoDate = dr["rvdRERAnumberExtensionRegUptoDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rvdRERAnumberExtensionRegUptoDate"]),
                           //rvdProjectType = Convert.ToString(dr["rvdProjectType"]??""),
                           //rvdRevokeInfoDetails = Convert.ToString(dr["rvdRevokeInfoDetails"]??""),
                           //rvdRevokeIssueAuthority = Convert.ToString(dr["rvdRevokeIssueAuthority"]??""),
                           //rvdRevokeReferenceName = Convert.ToString(dr["rvdRevokeReferenceName"]??""),
                           //rvdRevokeReferenceDate = dr["rvdRevokeReferenceDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["rvdRevokeReferenceDate"]),
                           //rvdRevokeType = Convert.ToString(dr["rvdRevokeType"]??""),

                           Reg_PromoterRegDiaryNumber_Name = dr["Reg_PromoterRegDiaryNumber_Name"] == DBNull.Value? "": Convert.ToString(dr["Reg_PromoterRegDiaryNumber_Name"]),
                           Project_Name = Convert.ToString(dr["Project_Name"] ?? ""),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"] ?? ""),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"] ?? ""),
                           Appdate = dr["Appdate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Appdate"]),




                           //Extra1 = Convert.ToString(dr["Extra1"]),
                           //Extra2 = Convert.ToString(dr["Extra2"]),
                           //Extra3 = Convert.ToString(dr["Extra3"]),
                           //Extra4 = Convert.ToString(dr["Extra4"]),

                           //IsActive = Convert.ToInt32(dr["IsActive"]),
                           //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           //IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           //IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           //IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           //IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           //IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           //IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           //IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           //IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           //Project_Name = Convert.ToString(dr["Project_Name"]),
                           //Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           //Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           ////Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           //EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           //EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = dr["EventAction_IdentifiedOn"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           //EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           //Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           //EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           //EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           //ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           //ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           //ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           //ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }
        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails> Display_AuthDesk_ProjectRERAnumberDiaryNumberDashBoard_ByDate(int? approvalyear, DateTime? fromDate, DateTime? toDate, string filterType, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails> ProjectReralist = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegRERAnumberDetailsByDate", con);
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
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                           ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }

        //Generate Registration Number
        public Tuple<DateTime, DateTime> Extract_AuthDesk_ProjectRegistrationNumberDateDetails_ByID(Int64 oProject_ID, Int64 oPromoter_ID, string oUserID)
        {
            connection();
            DateTime retIssueDate = DateTime.Now;
            DateTime retUptoDate = DateTime.Now;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegToFromDateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_UserID", oUserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                retIssueDate = Convert.ToDateTime(dr["registrationIssueDate"]);
                retUptoDate = Convert.ToDateTime(dr["registrationUptoDate"]);
            }
            return new Tuple<DateTime, DateTime>(retIssueDate, retUptoDate);
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails> Extract_AuthDesk_ProjectRegistrationNumber_ByProjectID(Int64 prmProjectID, Int64 prmPromoterID, Int32 prmOptionFlag, string prmProjectTypeFlag, DateTime prmIssueDate, DateTime prmUptoDate, string prmUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails> Projectlist = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationNumbers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", prmUserRole);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", prmProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", prmPromoterID);
            cmd.Parameters.AddWithValue("p_RegistrationNumberOptions", prmOptionFlag);
            cmd.Parameters.AddWithValue("p_ProjectType_Input", prmProjectTypeFlag);
            cmd.Parameters.AddWithValue("p_IssueDate_Input", prmIssueDate);
            cmd.Parameters.AddWithValue("p_ValidUptoDate_Input", prmUptoDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails
                       {
                           Prepared_SequenceNumber = Convert.ToString(dr["Prepared_SequenceNumber"]),
                           Prepared_ProjectType = Convert.ToString(dr["Prepared_ProjectType"]),
                           Prepared_NumberTypeFlag = Convert.ToString(dr["Prepared_NumberTypeFlag"]),

                           Prepared_RegistrationNumber = Convert.ToString(dr["v_Get_PreparedRegistrationNumber"]),
                           Prepared_IssueDate = Convert.ToDateTime(dr["v_Get_PreparedIssueDate"]),
                           Prepared_ValidUptoDate = Convert.ToDateTime(dr["v_Get_PreparedValidUptoDate"]),

                           Amount_PriceValue = Convert.ToDecimal(dr["PriceValue"]),
                           NumberAlreadyExisted_Flag = Convert.ToString(dr["NumberAlreadyExisted_Flag"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                       });
            }
            return Projectlist;
        }

        public bool Check_UniqueProjectRegistrationNumber(string RegdNumber)
        {
            bool rval = false;
            Int32 rvalcount = 0;
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_Project_AlreadyExistRegistrationNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_RegistrationNumber", RegdNumber);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                rvalcount = Convert.ToInt32(dr["CountRegistrationNumber"]);
            }

            if (rvalcount > 0)
            {
                rval = true;
            }
            cmd.Dispose();
            con.Close();
            return rval;
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails> Display_AuthDesk_ProjectRegistrationNumberHistory_ByProjectID(Int64 prmProjectID, Int64 prmPromoterID, string prmUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails> Projectlist = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationNumberHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", prmUserRole);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", prmProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", prmPromoterID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberSummaryDetails
                       {
                           Prepared_SequenceNumber = Convert.ToString(dr["vSequenceNumber"]),
                           Prepared_ProjectType = Convert.ToString(dr["vProjectType"]),
                           Prepared_NumberTypeFlag = Convert.ToString(dr["vNumberTypeFlag"]),

                           Prepared_RegistrationNumber = Convert.ToString(dr["vRegistrationNumber"]),
                           Prepared_IssueDate = Convert.ToDateTime(dr["vIssueDate"]),
                           Prepared_ValidUptoDate = Convert.ToDateTime(dr["vValidUptoDate"]),

                           Amount_PriceValue = Convert.ToDecimal(dr["vPriceValue"]),
                           NumberAlreadyExisted_Flag = Convert.ToString(dr["vNumberAlreadyExisted_Flag"]),

                           ProjectName = Convert.ToString(dr["vProjectName"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["vProjectDiaryNumber"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                       });
            }
            return Projectlist;
        }

    }
}