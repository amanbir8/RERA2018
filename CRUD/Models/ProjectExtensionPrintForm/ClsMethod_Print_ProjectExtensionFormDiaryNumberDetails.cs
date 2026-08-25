using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ProjectExtPrint
{
    public class ClsMethod_Print_ProjectExtensionFormDiaryNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails> Display_ProjectExtensionForm_RegDiaryNumberByProjectID_ForPrint(Int64 Project_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails> Projectlist = new List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectExtensionForm_RegDiaryNumberByID_ForPrint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Projectlist.Add(
                           new ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails
                           {
                               ProjectExtForm_RegDiaryNumber_IndexID = Convert.ToInt64(dr["ProjectExtForm_RegDiaryNumber_IndexID"]),
                               ProjectExtForm_RegDiaryNumber_ID = Convert.ToInt64(dr["ProjectExtForm_RegDiaryNumber_ID"]),
                               ProjectExtForm_RegDiaryNumber_Name = Convert.ToString(dr["ProjectExtForm_RegDiaryNumber_Name"]),
                               ProjectExtForm_RegDiaryNumber_NameYear = Convert.ToString(dr["ProjectExtForm_RegDiaryNumber_NameYear"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                               Project_ID = Convert.ToInt64(dr["Project_ID"]),
                               PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
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

                               zipRelated_Promoter_ID = Convert.ToInt64(dr["zipRelated_Promoter_ID"]),
                               zipRelated_Project_ID = Convert.ToInt64(dr["zipRelated_Project_ID"]),
                               zipProjectExtension_DiaryNumber = Convert.ToString(dr["zipProjectExtension_DiaryNumber"]),
                               zipProject_DiaryNumber = Convert.ToString(dr["zipProject_DiaryNumber"]),
                               zipProjectName = Convert.ToString(dr["zipProjectName"]),
                               zipProjectExtensionLastModifiedOn = Convert.ToDateTime(dr["zipProjectExtensionLastModifiedOn"]),
                               zipProjectDistrictName = Convert.ToString(dr["zipProjectDistrictName"]),
                               zipPromoterName = Convert.ToString(dr["zipPromoterName"]),
                           });
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return Projectlist;
        }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment> Display_ProjectExtensionForm_Payment(Int64 ProjectRegistration_ID)
        {
            connection();
            List<ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment> Projectlist = new List<ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_Payment_ExtensionFormE_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment
                       {
                           ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                           ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                           ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),
                           Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                           Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                           Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                           Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                           Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Branch_Name = Convert.ToString(dr["Branch_Name"]),
                           DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                           DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                           ImageDDorBankersCheque_FileName = Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                           ImageDDorBankersCheque_FilePath = Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE> Display_ProjectExtensionForm_FormEandDocuments(Int64 ProjectRegistration_ID)
        {
            connection();
            List<ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE> Projectlist = new List<ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ExtensionFormDocuments_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                    new ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE
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
            return Projectlist;
        }
    }
}