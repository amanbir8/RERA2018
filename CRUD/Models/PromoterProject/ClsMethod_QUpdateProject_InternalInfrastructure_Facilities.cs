using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_QUpdateProject_InternalInfrastructure_Facilities
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_QUpdateProject_InternalInfrastructure_Facilities(ClsPrp_QUpdateProject_InternalInfrastructure_Facilities smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_quarterlyupdate_InternalFacilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraFacilities_IndexID", smodel.QUpdateProjectInfraFacilities_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraFacilities_ID", smodel.QUpdateProjectInfraFacilities_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureFacilitiesIndexID", smodel.Related_ProjectInfrastructureFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureFacilitiesID", smodel.Related_ProjectInfrastructureFacilitiesID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID", smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateInfraFacilities_Year", String.IsNullOrEmpty(smodel.QUpdateInfraFacilities_Year) ? "0" : smodel.QUpdateInfraFacilities_Year);
            cmd.Parameters.AddWithValue("p_QUpdateInfraFacilities_QuarterName", String.IsNullOrEmpty(smodel.QUpdateInfraFacilities_QuarterName) ? "" : smodel.QUpdateInfraFacilities_QuarterName);

            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilities_Name", String.IsNullOrEmpty(smodel.InternalInfrastructureFacilities_Name) ? "" : smodel.InternalInfrastructureFacilities_Name);
            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilities_Type", "");
            cmd.Parameters.AddWithValue("p_ExternalAgency_LocalAuthority_Name", "");
            cmd.Parameters.AddWithValue("p_Is_InternalInfrastructureFacilitiesApplicable", "NA");
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageUptoRegistration", smodel.WorkProgress_PercentageUptoRegistration);
            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilitiesUptoRegistration_Details", String.IsNullOrEmpty(smodel.InternalInfrastructureFacilitiesUptoRegistration_Details) ? "" : smodel.InternalInfrastructureFacilitiesUptoRegistration_Details);
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageInQuarter", smodel.WorkProgress_PercentageInQuarter);
            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilitiesInQuarter_Details", String.IsNullOrEmpty(smodel.InternalInfrastructureFacilitiesInQuarter_Details) ? "" : smodel.InternalInfrastructureFacilitiesInQuarter_Details);
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageTotal", smodel.WorkProgress_PercentageTotal);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == "true" ? "YES" : "NO");
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", UName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", UName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //if (i >= 0)
            //    return AppId;
            //else
            //    return 0;

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_QUpdateProject_InternalInfrastructure_Facilities(ClsPrp_QUpdateProject_InternalInfrastructure_Facilities smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_quarterlyupdate_InternalFacilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraFacilities_IndexID", smodel.QUpdateProjectInfraFacilities_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraFacilities_ID", smodel.QUpdateProjectInfraFacilities_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureFacilitiesIndexID", smodel.Related_ProjectInfrastructureFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureFacilitiesID", smodel.Related_ProjectInfrastructureFacilitiesID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID", smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateInfraFacilities_Year", String.IsNullOrEmpty(smodel.QUpdateInfraFacilities_Year) ? "0" : smodel.QUpdateInfraFacilities_Year);
            cmd.Parameters.AddWithValue("p_QUpdateInfraFacilities_QuarterName", String.IsNullOrEmpty(smodel.QUpdateInfraFacilities_QuarterName) ? "" : smodel.QUpdateInfraFacilities_QuarterName);

            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilities_Name", String.IsNullOrEmpty(smodel.InternalInfrastructureFacilities_Name) ? "" : smodel.InternalInfrastructureFacilities_Name);
            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilities_Type", "");
            cmd.Parameters.AddWithValue("p_ExternalAgency_LocalAuthority_Name", "");
            cmd.Parameters.AddWithValue("p_Is_InternalInfrastructureFacilitiesApplicable", "NA");
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageUptoRegistration", smodel.WorkProgress_PercentageUptoRegistration);
            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilitiesUptoRegistration_Details", String.IsNullOrEmpty(smodel.InternalInfrastructureFacilitiesUptoRegistration_Details) ? "" : smodel.InternalInfrastructureFacilitiesUptoRegistration_Details);
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageInQuarter", smodel.WorkProgress_PercentageInQuarter);
            cmd.Parameters.AddWithValue("p_InternalInfrastructureFacilitiesInQuarter_Details", String.IsNullOrEmpty(smodel.InternalInfrastructureFacilitiesInQuarter_Details) ? "" : smodel.InternalInfrastructureFacilitiesInQuarter_Details);
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageTotal", smodel.WorkProgress_PercentageTotal);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == "true" ? "YES" : "NO");
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", UName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", UName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

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

        public List<ClsPrp_QUpdateProject_InternalInfrastructure_Facilities> Display_QUpdateProject_InternalInfrastructure_Facilities(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName)
        {
            connection();
            List<ClsPrp_QUpdateProject_InternalInfrastructure_Facilities> Projectlist = new List<ClsPrp_QUpdateProject_InternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_InternalInfrastructureFacilities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_QUpdateProject_InternalInfrastructure_Facilities
                       {
                           QUpdateProjectInfraFacilities_IndexID = Convert.ToInt64(dr["QUpdateProjectInfraFacilities_IndexID"]),
                           QUpdateProjectInfraFacilities_ID = Convert.ToInt64(dr["QUpdateProjectInfraFacilities_ID"]),
                           Related_ProjectInfrastructureFacilitiesIndexID = Convert.ToInt64(dr["Related_ProjectInfrastructureFacilitiesIndexID"]),
                           Related_ProjectInfrastructureFacilitiesID = Convert.ToInt64(dr["Related_ProjectInfrastructureFacilitiesID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           QUpdateInfraFacilities_Year = Convert.ToString(dr["QUpdateInfraFacilities_Year"]),
                           QUpdateInfraFacilities_QuarterName = Convert.ToString(dr["QUpdateInfraFacilities_QuarterName"]),

                           InternalInfrastructureFacilities_Name = Convert.ToString(dr["InternalInfrastructureFacilities_Name"]),
                           InternalInfrastructureFacilities_Type = Convert.ToString(dr["InternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),

                           WorkProgress_PercentageUptoRegistration = Convert.ToDecimal(dr["WorkProgress_PercentageUptoRegistration"]),
                           InternalInfrastructureFacilitiesUptoRegistration_Details = Convert.ToString(dr["InternalInfrastructureFacilitiesUptoRegistration_Details"]),
                           WorkProgress_PercentageInQuarter = Convert.ToDecimal(dr["WorkProgress_PercentageInQuarter"]),
                           InternalInfrastructureFacilitiesInQuarter_Details = Convert.ToString(dr["InternalInfrastructureFacilitiesInQuarter_Details"]),
                           WorkProgress_PercentageTotal = Convert.ToDecimal(dr["WorkProgress_PercentageTotal"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_QUpdateProject_InternalInfrastructure_Facilities> Display_QUpdateProject_InternalInfrastructure_FacilitiesByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectFacilitiesIndexID, Int64 QUpdateProjectFacilitiesID, Int64 RelatedProjectFacilitiesIndexID, Int64 RelatedProjectFacilitiesID)
        {
            connection();
            List<ClsPrp_QUpdateProject_InternalInfrastructure_Facilities> Projectlist = new List<ClsPrp_QUpdateProject_InternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_InternalInfrastructureFacilitiesByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInternalFacilitiesIndexID", QUpdateProjectFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInternalFacilitiesID", QUpdateProjectFacilitiesID);
            cmd.Parameters.AddWithValue("p_RelatedProjectInternalFacilitiesIndexID", RelatedProjectFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectInternalFacilitiesID", RelatedProjectFacilitiesID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_QUpdateProject_InternalInfrastructure_Facilities
                       {
                           QUpdateProjectInfraFacilities_IndexID = Convert.ToInt64(dr["QUpdateProjectInfraFacilities_IndexID"]),
                           QUpdateProjectInfraFacilities_ID = Convert.ToInt64(dr["QUpdateProjectInfraFacilities_ID"]),
                           Related_ProjectInfrastructureFacilitiesIndexID = Convert.ToInt64(dr["Related_ProjectInfrastructureFacilitiesIndexID"]),
                           Related_ProjectInfrastructureFacilitiesID = Convert.ToInt64(dr["Related_ProjectInfrastructureFacilitiesID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           QUpdateInfraFacilities_Year = Convert.ToString(dr["QUpdateInfraFacilities_Year"]),
                           QUpdateInfraFacilities_QuarterName = Convert.ToString(dr["QUpdateInfraFacilities_QuarterName"]),

                           InternalInfrastructureFacilities_Name = Convert.ToString(dr["InternalInfrastructureFacilities_Name"]),
                           InternalInfrastructureFacilities_Type = Convert.ToString(dr["InternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),

                           WorkProgress_PercentageUptoRegistration = Convert.ToDecimal(dr["WorkProgress_PercentageUptoRegistration"]),
                           InternalInfrastructureFacilitiesUptoRegistration_Details = Convert.ToString(dr["InternalInfrastructureFacilitiesUptoRegistration_Details"]),
                           WorkProgress_PercentageInQuarter = Convert.ToDecimal(dr["WorkProgress_PercentageInQuarter"]),
                           InternalInfrastructureFacilitiesInQuarter_Details = Convert.ToString(dr["InternalInfrastructureFacilitiesInQuarter_Details"]),
                           WorkProgress_PercentageTotal = Convert.ToDecimal(dr["WorkProgress_PercentageTotal"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }

        public bool Delete_QUpdateProject_InternalInfrastructure_FacilitiesByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectFacilitiesIndexID, Int64 QUpdateProjectFacilitiesID, Int64 RelatedProjectFacilitiesIndexID, Int64 RelatedProjectFacilitiesID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_ProjectQUpdate_InternalInfrastructure_FacilitiesByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectInternalFacilities_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectInternalFacilities_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInternalFacilities_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectFacilitiesIndexID", QUpdateProjectFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectFacilitiesID", QUpdateProjectFacilitiesID);
            cmd.Parameters.AddWithValue("p_RelatedProjectFacilitiesIndexID", RelatedProjectFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectFacilitiesID", RelatedProjectFacilitiesID);

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