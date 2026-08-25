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
using static CRUD.Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentDiaryNumber;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_Agent_Helpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistration", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsExistingRERA(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationExistingRERA", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsApproved(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationApproved", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsApprovedByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationApprovedByDate", con);
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
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public PagedResult<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsApproved_Paged(
        string UserID_Role, string search, string orderBy, string orderDir, int offset, int limit)
        {
            connection();
            var result = new PagedResult<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            using (MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationApproved_Paged", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
                cmd.Parameters.AddWithValue("p_search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);
                cmd.Parameters.AddWithValue("p_start", offset);
                cmd.Parameters.AddWithValue("p_length", limit);
                cmd.Parameters.AddWithValue("p_orderCol", orderBy ?? "EventAction_IdentifiedOn");
                cmd.Parameters.AddWithValue("p_orderDir", (orderDir ?? "DESC").ToUpper());

                var ds = new DataSet();
                using (var da = new MySqlDataAdapter(cmd))
                {
                    con.Open();
                    da.Fill(ds);
                    con.Close();
                }

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Items.Add(new ClsPrp_AuthorityDesk_AgentDiaryNumber
                        {
                            AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                            AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                            AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                            AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),
                            UserID = Convert.ToString(dr["UserID"]),
                            Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                            othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                            documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                            UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                            PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                            AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),
                            CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                            EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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
                            Agent_Name = Convert.ToString(dr["Agent_Name"]),
                            Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                            Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                            EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                            EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                            EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                            EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                            Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                            EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                            EventAction_Summary = Convert.ToString(dr["EventAction_Summary"])
                        });
                    }
                }

                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    var rc = ds.Tables[1].Rows[0]["totalCount"];
                    result.TotalCount = rc == DBNull.Value ? 0 : Convert.ToInt32(rc);
                }
                else
                {
                    result.TotalCount = result.Items.Count;
                }
            }

            return result;
        }



        //public PagedResult<ClsPrp_AuthorityDesk_AgentDiaryNumber>Display_AuthorityDesk_AgentDetailsApproved_Paged(string userRole, int start, int length, string search, string orderCol, string orderDir)
        //{
        //    connection();
        //    var result = new PagedResult<ClsPrp_AuthorityDesk_AgentDiaryNumber>();
        //    var list = result.Rows;

        //    using (MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationApprovedPage", con))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("p_UserRole", userRole ?? "");
        //        cmd.Parameters.AddWithValue("p_start", start);
        //        cmd.Parameters.AddWithValue("p_length", length);
        //        cmd.Parameters.AddWithValue("p_search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);
        //        cmd.Parameters.AddWithValue("p_orderCol", orderCol ?? "");
        //        cmd.Parameters.AddWithValue("p_orderDir", orderDir ?? "desc");

        //        var ds = new DataSet();
        //        using (var da = new MySqlDataAdapter(cmd))
        //        {
        //            con.Open();
        //            da.Fill(ds);        // fills Tables[0] = rows, Tables[1] = totalCount (if SP returns it)
        //            con.Close();
        //        }

        //        // safety: if no resultsets, return empty
        //        if (ds.Tables.Count == 0) return result;

        //        DataTable dtRows = ds.Tables[0];

        //        // map rows -> list (same style as your existing foreach)
        //        foreach (DataRow dr in dtRows.Rows)
        //        {
        //            var item = new ClsPrp_AuthorityDesk_AgentDiaryNumber
        //            {
        //                AgentRegDiaryNumber_IndexID =Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
        //                AgentRegDiaryNumber_ID =Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
        //                AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
        //                AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),
        //                UserID = Convert.ToString(dr["UserID"]),
        //                Agent_ID =Convert.ToInt64(dr["Agent_ID"]),
        //                othermemdetailCount =Convert.ToInt32(dr["othermemdetailCount"]),
        //                documentuploadCount =Convert.ToInt32(dr["documentuploadCount"]),
        //                UTOtherStateRERACount =Convert.ToInt32(dr["UTOtherStateRERACount"]),
        //                PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
        //                AgentDocumentCount =Convert.ToInt32(dr["AgentDocumentCount"]),
        //                CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
        //                EventCodeDetails_indexID =Convert.ToInt64(dr["EventCodeDetails_indexID"]),
        //                Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
        //                IsActive = Convert.ToInt32(dr["IsActive"]),
        //                IsDraft =Convert.ToInt32(dr["IsDraft"]),
        //                IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
        //                IsDraftEvaluation =Convert.ToInt32(dr["IsDraftEvaluation"]),
        //                IsDraftSecMember =Convert.ToInt32(dr["IsDraftSecMember"]),
        //                IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
        //                CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //                CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
        //                ModifyBy = Convert.ToString(dr["ModifyBy"]),
        //                ModifyOn =Convert.ToDateTime(dr["ModifyOn"]),
        //                Agent_Name = Convert.ToString(dr["Agent_Name"]),
        //                Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
        //                Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
        //                EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
        //                EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
        //                EventAction_IdentifiedOn =Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
        //                EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
        //                Target_ResolutionDate =Convert.ToDateTime(dr["Target_ResolutionDate"]),
        //                EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
        //                EventAction_Summary = Convert.ToString(dr["EventAction_Summary"])
        //            };

        //            list.Add(item);
        //        }

        //        // total count: check Tables[1] or the returned single-row table
        //        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        //        {
        //            var rc = ds.Tables[1].Rows[0]["totalCount"];
        //            result.TotalCount = rc == DBNull.Value ? 0 : Convert.ToInt32(rc);
        //        }
        //        else
        //        {
        //            // fallback: if SP returned only rows and you used no count, set to rows.Count
        //            result.TotalCount = list.Count;
        //        }
        //    }

        //    return result;
        //}



        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsRejected(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationRejected", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationNewApp", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsReSubmittedApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationReSubmitted", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsChecklistPrepared(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationChecklistPrep", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsReviewChecklist(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationReviewCL", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentEventLog> Display_AuthorityDesk_AgentEventLogDetails(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEventLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentEventLogDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentEventLog
                       {
                           AgentEventAction_ID = Convert.ToInt64(dr["AgentEventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
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

        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> Display_AuthorityDesk_AgentEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentEvent_Master", con);
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
                       new ClsPrp_AuthorityDesk_AgentEvent_Master
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

        public List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> Display_AuthorityDesk_AgentSubCheckList_MasterDetails(Int32 CheckList_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentSubCheckListDetails", con);
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
                       new ClsPrp_AuthorityDesk_AgentSubCheckList_Master
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

        public List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> Display_AuthorityDesk_AgentSubCheckList_MasterDetailsByCode(Int32 SubCheckList_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentSubCheckListDetailsByCode", con);
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
                       new ClsPrp_AuthorityDesk_AgentSubCheckList_Master
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

        public bool Add_Agent_InfoCheckList(ClsPrp_AuthorityDesk_AgentSubCheckListLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AuthDesk_Agent_CheckListAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_CheckList_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_p_CheckList_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_p_Agent_DiaryNumber", String.IsNullOrEmpty(smodel.Agent_DiaryNumber) ? "" : smodel.Agent_DiaryNumber);
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

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            //con.Close();
            //return AppId;

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> Display_AuthorityDesk_AgentCheckList_DetailsByCode(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentSubCheckListLog>();
            //Display_Rera_AuthorityDesk_AgentCheckListDetailsByCode
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentCheckListDetailsByCodeTK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentSubCheckListLog
                       {

                           AgentCheckListAction_ID = Convert.ToInt64(dr["AgentCheckListAction_ID"]),
                           CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                           UserRole = Convert.ToString(dr["UserRole"]),
                           CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
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

        public List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> Display_AuthorityDesk_CheckList_DetailsByCode_ForExpandLog(Int64 vAgent_ID, string vUserID_Role, Int32 vCriteriaCode, Int32 vCriteriaSubCode)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_AgentSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentCheckListByCodeTK_ForExpand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", vAgent_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", vUserID_Role);
            cmd.Parameters.AddWithValue("p_Criteria_Code", vCriteriaCode);
            cmd.Parameters.AddWithValue("p_Criteria_SubCode", vCriteriaSubCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agentlist.Add(
                       new ClsPrp_AuthorityDesk_AgentSubCheckListLog
                       {
                           AgentCheckListAction_ID = Convert.ToInt64(dr["AgentCheckListAction_ID"]),
                           CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                           UserRole = Convert.ToString(dr["UserRole"]),
                           CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
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
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> Display_AuthorityDesk_CheckList_DetailsByAgentID_ForLogHistory(Int64 vAgent_ID, string vUserID_Role, Int32 vCriteriaCode, Int32 vCriteriaSubCode, Int32 vCriteriaFlag)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> Agentlist = new List<ClsPrp_AuthorityDesk_AgentSubCheckListLog>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentCheckList_ByID_ForLogHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", vAgent_ID);
                cmd.Parameters.AddWithValue("p_UserID_Role", vUserID_Role);
                cmd.Parameters.AddWithValue("p_Criteria_Code", vCriteriaCode);
                cmd.Parameters.AddWithValue("p_Criteria_SubCode", vCriteriaSubCode);
                cmd.Parameters.AddWithValue("p_CriteriaFlag", vCriteriaFlag);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Agentlist.Add(
                           new ClsPrp_AuthorityDesk_AgentSubCheckListLog
                           {
                               AgentCheckListAction_ID = Convert.ToInt64(dr["AgentCheckListAction_ID"]),
                               CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                               UserRole = Convert.ToString(dr["UserRole"]),
                               CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return Agentlist;
        }

        public List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> Display_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentSubCheckListLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentCheckList_NoAccept_DetailsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_AgentSubCheckListLog
                       {
                           AgentCheckListAction_ID = Convert.ToInt64(dr["AgentCheckListAction_ID"]),
                           CheckList_IdentifiedBy = Convert.ToString(dr["CheckList_IdentifiedBy"]),
                           UserRole = Convert.ToString(dr["UserRole"]),
                           CheckList_IdentifiedOn = Convert.ToDateTime(dr["CheckList_IdentifiedOn"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
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

        public bool Add_Agent_InfoEvent(ClsPrp_AuthorityDesk_AgentEventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AuthDesk_Agent_EventAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_p_Agent_DiaryNumber", String.IsNullOrEmpty(smodel.Agent_DiaryNumber) ? "" : smodel.Agent_DiaryNumber);
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

        public string Fill_AgentChecklistCriteriaName(Int32 CriteriaCode)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentChecklistNameByID", con);
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

        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentEvent_Master>();
            //SAME PROC
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
                       new ClsPrp_AuthorityDesk_AgentEvent_Master
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

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> Display_AuthorityDesk_AgentDetailsIssueRERAregistration(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationIssueRERAid", con);
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
                       new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber
                       {
                           Agent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_IndexID"]),
                           Agent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                           DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                           UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                           PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),

                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                           Agent_Type = Convert.ToString(dr["Agent_Type"]),
                           Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                           Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                           Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                           Organization_Name = Convert.ToString(dr["Organization_Name"]),
                           BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                           BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                           EmailAddress = Convert.ToString(dr["EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           Extra2 = Convert.ToString("Extra2"),
                           Extra3 = Convert.ToString("Extra3"),
                           Extra4 = Convert.ToString("Extra4"),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Display_AuthorityDesk_AgentDetailsWithdrawn(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRegistrationWithdrawn", con);
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
                       new ClsPrp_AuthorityDesk_AgentDiaryNumber
                       {

                           AgentRegDiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegDiaryNumber_IndexID"]),
                           AgentRegDiaryNumber_ID = Convert.ToInt64(dr["AgentRegDiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                           UserID = Convert.ToString(dr["UserID"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                           othermemdetailCount = Convert.ToInt32(dr["othermemdetailCount"]),
                           documentuploadCount = Convert.ToInt32(dr["documentuploadCount"]),
                           UTOtherStateRERACount = Convert.ToInt32(dr["UTOtherStateRERACount"]),
                           PaymentCount = Convert.ToInt32(dr["PaymentCount"]),
                           AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Extra1 = Convert.ToString(""),
                           Extra2 = Convert.ToString(""),
                           Extra3 = Convert.ToString(""),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

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

        //Offline Registered Agents
        public List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails> Display_AuthorityDesk_AgentsExistingRERA_OfflineRegistered_PendingUploads(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails> OfflineRegisteredAgents = new List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_PendingUploadsAgentRegisteredOffline", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                OfflineRegisteredAgents.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails
                       {
                           OfflineAgents_IndexID = Convert.ToInt64(dr["OfflineAgents_IndexID"]),
                           OfflineAgents_ID = Convert.ToInt64(dr["OfflineAgents_ID"]),
                           OfflineAgents_IssueDate = Convert.ToDateTime(dr["OfflineAgents_IssueDate"]),
                           OfflineAgents_ReferenceNumber = Convert.ToString(dr["OfflineAgents_ReferenceNumber"]),

                           OfflineAgents_AgentName_OrganizationName = Convert.ToString(dr["OfflineAgents_AgentName_OrganizationName"]),
                           OfflineAgents_AgentType = Convert.ToString(dr["OfflineAgents_AgentType"]),
                           OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = Convert.ToString(dr["OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress"]),

                           OfflineAgents_RERAregistrationNumber = Convert.ToString(dr["OfflineAgents_RERAregistrationNumber"]),
                           OfflineAgents_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationIssueDate"]),
                           OfflineAgents_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationValidUptoDate"]),

                           OfflineAgents_PlaceOfBussinessAddress = Convert.ToString(dr["OfflineAgents_PlaceOfBussinessAddress"]),
                           OfflineAgents_BusinessPlaceDistrict = Convert.ToString(dr["OfflineAgents_BusinessPlaceDistrict"]),
                           OfflineAgents_ContactDetails = Convert.ToString(dr["OfflineAgents_ContactDetails"]),
                           OfflineAgents_RemarksIfAny = Convert.ToString(dr["OfflineAgents_RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificate = Convert.ToInt32(dr["IsCertificate"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return OfflineRegisteredAgents;
        }

    }
}