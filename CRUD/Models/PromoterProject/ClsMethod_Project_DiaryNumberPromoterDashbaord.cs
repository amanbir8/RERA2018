using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_Project_DiaryNumberPromoterDashbaord
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Project_DiaryNumberPromoterDashbaord> Display_Project_RegDiaryNumberByPromoterID(Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_Project_DiaryNumberPromoterDashbaord> ProjectFivelist1 = new List<ClsPrp_Project_DiaryNumberPromoterDashbaord>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Promoter_RegDiaryNumberByPromoterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_DiaryNumberPromoterDashbaord
                       {
                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_Project_DiaryNumberPromoterDashbaord> Display_Project_ApplicationForExtension_RegDiaryNumberByID(Int64 Project_ID, Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_Project_DiaryNumberPromoterDashbaord> ProjectFivelist1 = new List<ClsPrp_Project_DiaryNumberPromoterDashbaord>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_AppExtension_RegDiaryNumberByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_DiaryNumberPromoterDashbaord
                       {
                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList> Display_Project_ApplicationForExtension_CheckList_NoAccept_DetailsByCode(Int64 Project_ID, Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList> ProjectFivelist1 = new List<ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_AppExtension_NoAcceptCheckListByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList
                       {

                           ProjectExtensionCheckListAction_ID = Convert.ToInt64(dr["ProjectExtensionCheckListAction_ID"]),
                           CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                           UserRole = Convert.ToString(dr["UserRole"]),
                           CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           CriteriaCode = Convert.ToString(dr["CriteriaCode"]),
                           CriteriaSubCode = Convert.ToString(dr["CriteriaSubCode"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsChecklistValueOk = Convert.ToString(dr["IsChecklistValueOk"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
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

    }
}