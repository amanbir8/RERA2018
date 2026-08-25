using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsMethod_AdminDesk_CauselistWeeklyCalender
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_AdminDesk_CauseListForWeeklyCalenderDetails(ClsPrp_AdminDesk_CauseListForWeeklyCalender smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_causelistweeklycalender", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1); //yy mm dd                     

            #region Parameters
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_IndexID", smodel.CauseListWeeklyCalender_IndexID);
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_ID", smodel.CauseListWeeklyCalender_ID);

            cmd.Parameters.AddWithValue("p_CasueListOneFlag",  smodel.CasueListOneFlag);
            cmd.Parameters.AddWithValue("p_CauseListOneDate" ,smodel.CauseListOneDate == null ? dtvalue : smodel.CauseListOneDate);
            cmd.Parameters.AddWithValue("p_CauseListOneDay", String.IsNullOrEmpty(smodel.CauseListOneDay) ? "" : smodel.CauseListOneDay);

            cmd.Parameters.AddWithValue("p_CasueListTwoFlag", smodel.CasueListTwoFlag);
            cmd.Parameters.AddWithValue("p_CauseListTwoDate", smodel.CauseListTwoDate == null ? dtvalue : smodel.CauseListTwoDate);
            cmd.Parameters.AddWithValue("p_CauseListTwoDay", String.IsNullOrEmpty(smodel.CauseListTwoDay) ? "" : smodel.CauseListTwoDay); 

            cmd.Parameters.AddWithValue("p_CasueListThreeFlag", smodel.CasueListThreeFlag);
            cmd.Parameters.AddWithValue("p_CauseListThreeDate", smodel.CauseListThreeDate == null ? dtvalue : smodel.CauseListThreeDate);
            cmd.Parameters.AddWithValue("p_CauseListThreeDay", String.IsNullOrEmpty(smodel.CauseListThreeDay) ? "" : smodel.CauseListThreeDay);

            cmd.Parameters.AddWithValue("p_CasueListFourFlag", smodel.CasueListFourFlag);
            cmd.Parameters.AddWithValue("p_CauseListFourDate", smodel.CauseListFourDate == null ? dtvalue : smodel.CauseListFourDate);
            cmd.Parameters.AddWithValue("p_CauseListFourDay", String.IsNullOrEmpty(smodel.CauseListFourDay) ? "" : smodel.CauseListFourDay);

            cmd.Parameters.AddWithValue("p_CasueListFiveFlag", smodel.CasueListFiveFlag);
            cmd.Parameters.AddWithValue("p_CauseListFiveDate", smodel.CauseListFiveDate == null ? dtvalue : smodel.CauseListFiveDate);
            cmd.Parameters.AddWithValue("p_CauseListFiveDay", String.IsNullOrEmpty(smodel.CauseListFiveDay) ? "" : smodel.CauseListFiveDay);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

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

        public bool Update_AdminDesk_CauseListForWeeklyCalenderDetails(ClsPrp_AdminDesk_CauseListForWeeklyCalender smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_causelistweeklycalender", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_IndexID", smodel.CauseListWeeklyCalender_IndexID);
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_ID", smodel.CauseListWeeklyCalender_ID);

            cmd.Parameters.AddWithValue("p_CasueListOneFlag", smodel.CasueListOneFlag);
            cmd.Parameters.AddWithValue("p_CauseListOneDate", smodel.CauseListOneDate == null ? dtvalue : smodel.CauseListOneDate);
            cmd.Parameters.AddWithValue("p_CauseListOneDay", String.IsNullOrEmpty(smodel.CauseListOneDay) ? "" : smodel.CauseListOneDay);

            cmd.Parameters.AddWithValue("p_CasueListTwoFlag", smodel.CasueListTwoFlag);
            cmd.Parameters.AddWithValue("p_CauseListTwoDate", smodel.CauseListTwoDate == null ? dtvalue : smodel.CauseListTwoDate);
            cmd.Parameters.AddWithValue("p_CauseListTwoDay", String.IsNullOrEmpty(smodel.CauseListTwoDay) ? "" : smodel.CauseListTwoDay);

            cmd.Parameters.AddWithValue("p_CasueListThreeFlag", smodel.CasueListThreeFlag);
            cmd.Parameters.AddWithValue("p_CauseListThreeDate", smodel.CauseListThreeDate == null ? dtvalue : smodel.CauseListThreeDate);
            cmd.Parameters.AddWithValue("p_CauseListThreeDay", String.IsNullOrEmpty(smodel.CauseListThreeDay) ? "" : smodel.CauseListThreeDay);

            cmd.Parameters.AddWithValue("p_CasueListFourFlag", smodel.CasueListFourFlag);
            cmd.Parameters.AddWithValue("p_CauseListFourDate", smodel.CauseListFourDate == null ? dtvalue : smodel.CauseListFourDate);
            cmd.Parameters.AddWithValue("p_CauseListFourDay", String.IsNullOrEmpty(smodel.CauseListFourDay) ? "" : smodel.CauseListFourDay);

            cmd.Parameters.AddWithValue("p_CasueListFiveFlag", smodel.CasueListFiveFlag);
            cmd.Parameters.AddWithValue("p_CauseListFiveDate", smodel.CauseListFiveDate == null ? dtvalue : smodel.CauseListFiveDate);
            cmd.Parameters.AddWithValue("p_CauseListFiveDay", String.IsNullOrEmpty(smodel.CauseListFiveDay) ? "" : smodel.CauseListFiveDay);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
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

        public List<ClsPrp_AdminDesk_CauseListForWeeklyCalender> Display_AdminDesk_CauseListForWeeklyCalenderDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_CauseListForWeeklyCalender> AdminDeskparameters = new List<ClsPrp_AdminDesk_CauseListForWeeklyCalender>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_causelistweeklycalender", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_CauseListForWeeklyCalender
                       {
                           CauseListWeeklyCalender_IndexID = Convert.ToInt64(dr["CauseListWeeklyCalender_IndexID"]),
                           CauseListWeeklyCalender_ID = Convert.ToInt64(dr["CauseListWeeklyCalender_ID"]),

                           CasueListOneFlag = Convert.ToInt32(dr["CasueListOneFlag"]),
                           CauseListOneDate = Convert.ToDateTime(dr["CauseListOneDate"]),
                           CauseListOneDay = Convert.ToString(dr["CauseListOneDay"]),

                           CasueListTwoFlag = Convert.ToInt32(dr["CasueListTwoFlag"]),
                           CauseListTwoDate = Convert.ToDateTime(dr["CauseListTwoDate"]),
                           CauseListTwoDay = Convert.ToString(dr["CauseListTwoDay"]),

                           CasueListThreeFlag = Convert.ToInt32(dr["CasueListThreeFlag"]),
                           CauseListThreeDate = Convert.ToDateTime(dr["CauseListThreeDate"]),
                           CauseListThreeDay = Convert.ToString(dr["CauseListThreeDay"]),

                           CasueListFourFlag = Convert.ToInt32(dr["CasueListFourFlag"]),
                           CauseListFourDate = Convert.ToDateTime(dr["CauseListFourDate"]),
                           CauseListFourDay = Convert.ToString(dr["CauseListFourDay"]),

                           CasueListFiveFlag = Convert.ToInt32(dr["CasueListFiveFlag"]),
                           CauseListFiveDate = Convert.ToDateTime(dr["CauseListFiveDate"]),
                           CauseListFiveDay = Convert.ToString(dr["CauseListFiveDay"]),
                           
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_CauseListForWeeklyCalender> Display_AdminDesk_CauseListForWeeklyCalenderByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_CauseListForWeeklyCalender> AdminDeskparameters = new List<ClsPrp_AdminDesk_CauseListForWeeklyCalender>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_causelistweeklycalenderByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_CauseListForWeeklyCalender
                       {
                           CauseListWeeklyCalender_IndexID = Convert.ToInt64(dr["CauseListWeeklyCalender_IndexID"]),
                           CauseListWeeklyCalender_ID = Convert.ToInt64(dr["CauseListWeeklyCalender_ID"]),

                           CasueListOneFlag = Convert.ToInt32(dr["CasueListOneFlag"]),
                           CauseListOneDate = Convert.ToDateTime(dr["CauseListOneDate"]),
                           CauseListOneDay = Convert.ToString(dr["CauseListOneDay"]),

                           CasueListTwoFlag = Convert.ToInt32(dr["CasueListTwoFlag"]),
                           CauseListTwoDate = Convert.ToDateTime(dr["CauseListTwoDate"]),
                           CauseListTwoDay = Convert.ToString(dr["CauseListTwoDay"]),

                           CasueListThreeFlag = Convert.ToInt32(dr["CasueListThreeFlag"]),
                           CauseListThreeDate = Convert.ToDateTime(dr["CauseListThreeDate"]),
                           CauseListThreeDay = Convert.ToString(dr["CauseListThreeDay"]),

                           CasueListFourFlag = Convert.ToInt32(dr["CasueListFourFlag"]),
                           CauseListFourDate = Convert.ToDateTime(dr["CauseListFourDate"]),
                           CauseListFourDay = Convert.ToString(dr["CauseListFourDay"]),

                           CasueListFiveFlag = Convert.ToInt32(dr["CasueListFiveFlag"]),
                           CauseListFiveDate = Convert.ToDateTime(dr["CauseListFiveDate"]),
                           CauseListFiveDay = Convert.ToString(dr["CauseListFiveDay"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Delete_AdminDesk_CauseListForWeeklyCalenderByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_causelistweeklycalenderIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CauseListWeeklyCalender_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //private string getDayofWeekfromSpecificDate(DateTime? dt)
        //{
        //    string retSTR = string.Empty;
                        
        //    if (dt == null)
        //    {
        //        retSTR = "NA";
        //    } 
        //    else
        //    {
        //        DayOfWeek dow = dt.DayOfWeek;
        //        retSTR = dow.ToString();
        //    }     

        //    return retSTR;
        //}
    }
}