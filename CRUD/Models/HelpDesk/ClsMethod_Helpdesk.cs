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

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_Helpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Helpdesk> Fill_Project_ByAppId()//Int64 Application_ID
        {
            List<ClsPrp_Helpdesk> userlist1 = new List<ClsPrp_Helpdesk>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using
                (
                    MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Detail", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                )
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Helpdesk uobj = new ClsPrp_Helpdesk();
                        uobj.ProjectRegistration_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectRegistration_ID"].ToString());
                        uobj.Project_Name = ds.Tables[0].Rows[i]["Project_Name"].ToString();
                        uobj.Project_Status = ds.Tables[0].Rows[i]["Project_Status"].ToString();

                        uobj.Promoter_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Promoter_ID"].ToString());
                        uobj.Promoter_Name = ds.Tables[0].Rows[i]["First_Name"].ToString();
                        uobj.Org_Name = ds.Tables[0].Rows[i]["Org_Name"].ToString();

                        userlist1.Add(uobj);
                    }

                    con.Close();
                    return userlist1;
                }
            }
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistration", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsExistingRERA(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationExistingRERA", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsApproved(int currectYear, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            //MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationApproved", con);
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationApprovedYear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }
        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_Rera_AuthorityDesk_ProjectRegistrationApprovedFilter(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            //MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationApproved", con);
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationApprovedFilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsApproved(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationApproved", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           ProjectCost = Convert.ToInt64(dr["Project_Cost"]),

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

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsRejected(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationRejected", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationNewApp", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsNewReSubmittedApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationNewReSubmitted", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsChecklistPrepared(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationChecklistPrep", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsChecklistPrepared(string UserID_Role, string UserID, string UserName, string CycleRoundID, string CLviewCode)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationCListPrepAll_ByFID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_CycleRoundID", CycleRoundID);
            cmd.Parameters.AddWithValue("p_CLviewCode", CLviewCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                           CLflag1 = Convert.ToString(dr["CLflag1"]),
                           CLflag2 = Convert.ToString(dr["CLflag2"]),
                           CLflag3 = Convert.ToString(dr["CLflag3"]),
                           CLflag4 = Convert.ToString(dr["CLflag4"]),
                           CLflag5 = Convert.ToString(dr["CLflag5"]),
                           CLflag6 = Convert.ToString(dr["CLflag6"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsChecklistPrepared_ByFilterCode(string UserID_Role, string UserID, string UserName, string CycleRoundID, string CLviewCode)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationCListPrep_ByFID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_CycleRoundID", CycleRoundID);
            cmd.Parameters.AddWithValue("p_CLviewCode", CLviewCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                           CLflag1 = Convert.ToString(dr["CLflag1"]),
                           CLflag2 = Convert.ToString(dr["CLflag2"]),
                           CLflag3 = Convert.ToString(dr["CLflag3"]),
                           CLflag4 = Convert.ToString(dr["CLflag4"]),
                           CLflag5 = Convert.ToString(dr["CLflag5"]),
                           CLflag6 = Convert.ToString(dr["CLflag6"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsReviewChecklist(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationReviewCL", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectSectionThreeSevenDetails(string UserID_Role, string UserID_Name)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationSectionThreeSeven", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", UserID_Name);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectEventLog> Display_AuthorityDesk_ProjectEventLogDetails(Int64 Project_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectEventLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectEventLogDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectEventLog
                       {
                           PromoterEventAction_ID = Convert.ToInt64(dr["PromoterEventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectEvent_Master> Display_AuthorityDesk_ProjectEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectEvent_Master", con);
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
                       new ClsPrp_AuthorityDesk_ProjectEvent_Master
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

        public List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master> Display_AuthorityDesk_SubCheckList_MasterDetails(Int32 CheckList_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectSubCheckListDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_CheckList_ID", CheckList_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectSubCheckList_Master
                       {

                           SubCheckList_IndexID = Convert.ToInt32(dr["SubCheckList_IndexID"]),
                           SubCheckList_ID = Convert.ToInt32(dr["SubCheckList_ID"]),
                           SubCheckListName = Convert.ToString(dr["SubCheckListName"]),
                           SubCheckListDescription = Convert.ToString(dr["SubCheckListDescription"]),
                           CheckList_ID = Convert.ToInt32(dr["CheckList_ID"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master> Display_AuthorityDesk_SubCheckList_MasterDetailsByCode(Int32 SubCheckList_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectSubCheckListDetailsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_SubCheckList_ID", SubCheckList_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectSubCheckList_Master
                       {

                           SubCheckList_IndexID = Convert.ToInt32(dr["SubCheckList_IndexID"]),
                           SubCheckList_ID = Convert.ToInt32(dr["SubCheckList_ID"]),
                           SubCheckListName = Convert.ToString(dr["SubCheckListName"]),
                           SubCheckListDescription = Convert.ToString(dr["SubCheckListDescription"]),
                           CheckList_ID = Convert.ToInt32(dr["CheckList_ID"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                       });
            }
            return ProjectFivelist1;
        }

        public bool Add_Project_InfoCheckList(ClsPrp_AuthorityDesk_ProjectSubCheckListLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_Promoter_CheckListAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_CheckList_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_p_CheckList_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Related_Promoter_ID", smodel.Related_Promoter_ID);
            cmd.Parameters.AddWithValue("p_p_Related_Project_ID", smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_p_Promoter_DiaryNumber", String.IsNullOrEmpty(smodel.Promoter_DiaryNumber) ? "" : smodel.Promoter_DiaryNumber);
            cmd.Parameters.AddWithValue("p_p_Project_DiaryNumber", String.IsNullOrEmpty(smodel.Project_DiaryNumber) ? "" : smodel.Project_DiaryNumber);
            cmd.Parameters.AddWithValue("p_p_CriteriaCode", String.IsNullOrEmpty(smodel.CriteriaCode) ? "" : smodel.CriteriaCode);
            cmd.Parameters.AddWithValue("p_p_CriteriaSubCode", String.IsNullOrEmpty(smodel.CriteriaSubCode) ? "" : smodel.CriteriaSubCode);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_IsChecklistValueOk", String.IsNullOrEmpty(smodel.IsChecklistValueOk) ? "" : smodel.IsChecklistValueOk);
            cmd.Parameters.AddWithValue("p_p_A_column", "");
            cmd.Parameters.AddWithValue("p_p_B_column", "");
            cmd.Parameters.AddWithValue("p_p_C_column", "");
            cmd.Parameters.AddWithValue("p_p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_ModifyOn", DateTime.Now);

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", SqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            //return AppId;

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> Display_AuthorityDesk_CheckList_DetailsByCode(Int64 Project_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectCheckListDetailsByCodeTK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectSubCheckListLog
                       {

                           ProjectCheckListAction_ID = Convert.ToInt64(dr["ProjectCheckListAction_ID"]),
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

                           CriteriaSubCodeTitle = Convert.ToString(dr["CriteriaSubCodeTitle"]),
                           VarCriteriaCode = Convert.ToInt32(dr["VarCriteriaCode"]),
                           VarCriteriaSubCode = Convert.ToInt32(dr["VarCriteriaSubCode"]),
                           VarChecklistOrderNumber = Convert.ToInt32(dr["VarChecklistOrderNumber"]),
                           VarChecklistGroupID = Convert.ToInt32(dr["VarChecklistGroupID"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> Display_AuthorityDesk_CheckList_DetailsByCode_ForExpandLog(Int64 pProject_ID, string pUserID_Role, Int32 pCriteriaCode, Int32 pCriteriaSubCode)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectCheckListByCodeTK_ForExpand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", pProject_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", pUserID_Role);
            cmd.Parameters.AddWithValue("p_Criteria_Code", pCriteriaCode);
            cmd.Parameters.AddWithValue("p_Criteria_SubCode", pCriteriaSubCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectSubCheckListLog
                       {

                           ProjectCheckListAction_ID = Convert.ToInt64(dr["ProjectCheckListAction_ID"]),
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

                           CriteriaSubCodeTitle = Convert.ToString(dr["CriteriaSubCodeTitle"]),
                           VarCriteriaCode = Convert.ToInt32(dr["VarCriteriaCode"]),
                           VarCriteriaSubCode = Convert.ToInt32(dr["VarCriteriaSubCode"]),
                           VarChecklistOrderNumber = Convert.ToInt32(dr["VarChecklistOrderNumber"]),
                           VarChecklistGroupID = Convert.ToInt32(dr["VarChecklistGroupID"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> Display_AuthorityDesk_CheckList_DetailsByCode_ForExpandLogByFlag(Int64 pProject_ID, string pUserID_Role, Int32 pCriteriaCode, Int32 pCriteriaSubCode, Int32 pCriteriaFlag)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectCheckListByCodeTK_ForExpandID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", pProject_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", pUserID_Role);
            cmd.Parameters.AddWithValue("p_Criteria_Code", pCriteriaCode);
            cmd.Parameters.AddWithValue("p_Criteria_SubCode", pCriteriaSubCode);
            cmd.Parameters.AddWithValue("p_Criteria_Flag", pCriteriaFlag);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectSubCheckListLog
                       {

                           ProjectCheckListAction_ID = Convert.ToInt64(dr["ProjectCheckListAction_ID"]),
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

                           CriteriaSubCodeTitle = Convert.ToString(dr["CriteriaSubCodeTitle"]),
                           VarCriteriaCode = Convert.ToInt32(dr["VarCriteriaCode"]),
                           VarCriteriaSubCode = Convert.ToInt32(dr["VarCriteriaSubCode"]),
                           VarChecklistOrderNumber = Convert.ToInt32(dr["VarChecklistOrderNumber"]),
                           VarChecklistGroupID = Convert.ToInt32(dr["VarChecklistGroupID"]),

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> Display_AuthorityDesk_CheckList_NoAccept_DetailsByCode(Int64 Project_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectCheckList_NoAccept_ByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectSubCheckListLog
                       {

                           ProjectCheckListAction_ID = Convert.ToInt64(dr["ProjectCheckListAction_ID"]),
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

        public bool Add_Project_InfoEvent(ClsPrp_AuthorityDesk_ProjectEventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_Promoter_EventAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Related_Promoter_ID", smodel.Related_Promoter_ID);
            cmd.Parameters.AddWithValue("p_p_Related_Project_ID", smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_p_Promoter_DiaryNumber", String.IsNullOrEmpty(smodel.Promoter_DiaryNumber) ? "" : smodel.Promoter_DiaryNumber);
            cmd.Parameters.AddWithValue("p_p_Project_DiaryNumber", String.IsNullOrEmpty(smodel.Project_DiaryNumber) ? "" : smodel.Project_DiaryNumber);
            cmd.Parameters.AddWithValue("p_p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_p_EventAction_Relationship", UserRole);// String.IsNullOrEmpty(smodel.EventAction_Relationship) ? "" : smodel.EventAction_Relationship);
            cmd.Parameters.AddWithValue("p_p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_IsBefore_TargetResolution", 0);
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

        public string Fill_ChecklistCriteriaName(Int32 CriteriaCode)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectChecklistNameByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_CriteriaCode", CriteriaCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            string retSTR = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                retSTR = Convert.ToString(dr["CriteriaName"]);
            }
            return retSTR;
        }

        public List<ClsPrp_AuthorityDesk_ProjectEvent_Master> Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectEventDescriptionDetailsByCode", con);
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
                       new ClsPrp_AuthorityDesk_ProjectEvent_Master
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

        public string Fill_Checklist_CriteriaNotAcceptedName_ByProjectID(Int64 Project_ID, string UserID_Role)
        {
            //Not Working
            connection();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectChecklist_NotAcceptedName_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectID", Project_ID);
            cmd.Parameters.AddWithValue("p_UserIDRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            string retSTR = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                retSTR = Convert.ToString(dr["ListofCriteriaDescription"]);
            }
            return retSTR;
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber> Display_AuthorityDesk_ProjectDetailsIssueRERAregistration(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber> ProjectReraList = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationIssueRERAid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

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
                       });
            }
            return ProjectReraList;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsWithdrawnApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationWithdrawn", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        // Offline Projects

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsOfflineNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationOfflineNewApp", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsUnverifiedExistingRERA(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationExistingUnverified", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> Display_AuthorityDesk_ProjectDetailsOfflineVerifiedApproved(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectRegistrationApprovedOffline", con);
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
                       new ClsPrp_AuthorityDesk_ProjectDiaryNumber
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

                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_PendingOfflineProjects> Display_AuthorityDesk_PendingUploadsList_OfflineRegisteredProjects(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_PendingOfflineProjects> PendingOfflineProjects = new List<ClsPrp_AuthorityDesk_PendingOfflineProjects>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_PendingUploadsProjectOffline", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PendingOfflineProjects.Add(
                       new ClsPrp_AuthorityDesk_PendingOfflineProjects
                       {
                           OfflineProjects_IndexID = Convert.ToInt64(dr["OfflineProjects_IndexID"]),
                           OfflineProjects_ID = Convert.ToInt64(dr["OfflineProjects_ID"]),
                           OfflineProjects_IssueDate = Convert.ToDateTime(dr["OfflineProjects_IssueDate"]),
                           OfflineProjects_ReferenceNumber = Convert.ToString(dr["OfflineProjects_ReferenceNumber"]),
                           OfflineProjects_DistrictName = Convert.ToString(dr["OfflineProjects_DistrictName"]),
                           OfflineProjects_PromoterName = Convert.ToString(dr["OfflineProjects_PromoterName"]),
                           OfflineProjects_ProjectName = Convert.ToString(dr["OfflineProjects_ProjectName"]),
                           OfflineProjects_RERAregistrationNumber = Convert.ToString(dr["OfflineProjects_RERAregistrationNumber"]),
                           OfflineProjects_TypeofProject = Convert.ToString(dr["OfflineProjects_TypeofProject"]),
                           OfflineProjects_ProjectLocation = Convert.ToString(dr["OfflineProjects_ProjectLocation"]),
                           OfflineProjects_PromoterAddress = Convert.ToString(dr["OfflineProjects_PromoterAddress"]),
                           OfflineProjects_PromoterContactDetails = Convert.ToString(dr["OfflineProjects_PromoterContactDetails"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           OfflineProject_RERAregistrationIssueDate = Convert.ToDateTime(dr["RegistrationIssueDate"]),
                           OfflineProject_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["RegistrationValidUptoDate"]),
                       });
            }
            return PendingOfflineProjects;
        }
    }
}
