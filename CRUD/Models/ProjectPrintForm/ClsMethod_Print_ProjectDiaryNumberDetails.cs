using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ProjectPrint
{
    public class ClsMethod_Print_ProjectDiaryNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails> Display_Project_RegDiaryNumberByPromoterID_ForPrint(Int64 Project_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Promoter_RegDiaryNumberByProID_ForPrint", con);
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
                    ProjectFivelist1.Add(
                           new ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails
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

                               zipProjectName = Convert.ToString(dr["Project_Name"]),
                               zipProjectDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                               zipPromoterName = Convert.ToString(dr["Promoter_Name"]),
                           });
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return ProjectFivelist1;
        }

    }
}