using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_FormM_OrderJudgement_Master
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_eCourt_CaseType_Master> Display_Master_Complaint_CaseTypeList_ByID(Int32? Flag_ID, string UserID)
        {
            connection();
            List<ClsPrp_AuthDesk_eCourt_CaseType_Master> ObjCaseTypeList = new List<ClsPrp_AuthDesk_eCourt_CaseType_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_Complaint_CaseTypeList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Flag_ID", Flag_ID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ObjCaseTypeList.Add(
                    new ClsPrp_AuthDesk_eCourt_CaseType_Master
                    {
                        CaseType_IndexID = Convert.ToInt32(dr["CaseType_IndexID"]),
                        CaseType_ID = Convert.ToInt32(dr["CaseType_ID"]),

                        CaseType_SerialOrder = Convert.ToInt32(dr["CaseType_SerialOrder"]),
                        CaseTypeCode = Convert.ToString(dr["CaseTypeCode"]),
                        CaseTypeName = Convert.ToString(dr["CaseTypeName"]),
                        Category = Convert.ToString(dr["Category"]),
                        CaseTypeDescription = Convert.ToString(dr["CaseTypeDescription"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsFlag = Convert.ToInt32(dr["IsFlag"]),
                    });
            }
            return ObjCaseTypeList;
        }
        public List<ClsPrp_AuthDesk_eCourt_UnderSection_Master> Display_Master_Complaint_UnderSectionList_ByID(Int32? Flag_ID, string UserID)
        {
            connection();
            List<ClsPrp_AuthDesk_eCourt_UnderSection_Master> ObjUnderSectionList = new List<ClsPrp_AuthDesk_eCourt_UnderSection_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_Complaint_UnderSectionList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Flag_ID", Flag_ID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ObjUnderSectionList.Add(
                    new ClsPrp_AuthDesk_eCourt_UnderSection_Master
                    {
                        UnderSection_IndexID = Convert.ToInt32(dr["UnderSection_IndexID"]),
                        UnderSection_ID = Convert.ToInt32(dr["UnderSection_ID"]),

                        UnderSection_SerialOrder = Convert.ToInt32(dr["UnderSection_SerialOrder"]),
                        UnderSectionCode = Convert.ToString(dr["UnderSectionCode"]),
                        UnderSectionName = Convert.ToString(dr["UnderSectionName"]),
                        UnderSectionYear = Convert.ToInt32(dr["UnderSectionYear"]),
                        UnderSectionType = Convert.ToString(dr["UnderSectionType"]),
                        UnderSectionDescription = Convert.ToString(dr["UnderSectionDescription"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsFlag = Convert.ToInt32(dr["IsFlag"]),
                    });
            }
            return ObjUnderSectionList;
        }
        public List<ClsPrp_AuthDesk_eCourt_OrderDesc_Master> Display_Master_Complaint_OrderDocumentList_ByID(Int32? Flag_ID, string UserID)
        {
            connection();
            List<ClsPrp_AuthDesk_eCourt_OrderDesc_Master> ObjOrderDescList = new List<ClsPrp_AuthDesk_eCourt_OrderDesc_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_Complaint_OrderDocumentList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Flag_ID", Flag_ID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ObjOrderDescList.Add(
                    new ClsPrp_AuthDesk_eCourt_OrderDesc_Master
                    {
                        OrderDocument_IndexID = Convert.ToInt32(dr["OrderDocument_IndexID"]),
                        OrderDocument_ID = Convert.ToInt32(dr["OrderDocument_ID"]),

                        OrderDocument_SerialOrder = Convert.ToInt32(dr["OrderDocument_SerialOrder"]),
                        OrderDocumentInfoCode = Convert.ToString(dr["OrderDocumentInfoCode"]),
                        OrderDocumentInfoName = Convert.ToString(dr["OrderDocumentInfoName"]),
                        Category = Convert.ToString(dr["Category"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                    });
            }
            return ObjOrderDescList;
        }
    }
}