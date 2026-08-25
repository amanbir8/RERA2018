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
    public class ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_QUpdateProject_ExternalInfrastructure_Facilities(ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_quarterlyupdate_ExternalFacilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraExFacilities_IndexID", smodel.QUpdateProjectInfraExFacilities_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraExFacilities_ID", smodel.QUpdateProjectInfraExFacilities_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureExFacilitiesIndexID", smodel.Related_ProjectInfrastructureExFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureExFacilitiesID", smodel.Related_ProjectInfrastructureExFacilitiesID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID", smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateInfraExFacilities_Year", String.IsNullOrEmpty(smodel.QUpdateInfraExFacilities_Year) ? "0" : smodel.QUpdateInfraExFacilities_Year);
            cmd.Parameters.AddWithValue("p_QUpdateInfraExFacilities_QuarterName", String.IsNullOrEmpty(smodel.QUpdateInfraExFacilities_QuarterName) ? "" : smodel.QUpdateInfraExFacilities_QuarterName);

            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilities_Name", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilities_Name) ? "" : smodel.ExternalInfrastructureFacilities_Name);
            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilities_Type", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilities_Type) ? "" : smodel.ExternalInfrastructureFacilities_Type);
            cmd.Parameters.AddWithValue("p_ExternalAgency_LocalAuthority_Name", String.IsNullOrEmpty(smodel.ExternalAgency_LocalAuthority_Name) ? "" : smodel.ExternalAgency_LocalAuthority_Name);
            cmd.Parameters.AddWithValue("p_Is_InternalInfrastructureFacilitiesApplicable", "YS");
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageUptoRegistration", smodel.WorkProgress_PercentageUptoRegistration);
            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilitiesUptoRegistration_Details", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilitiesUptoRegistration_Details) ? "" : smodel.ExternalInfrastructureFacilitiesUptoRegistration_Details);
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageInQuarter", smodel.WorkProgress_PercentageInQuarter);
            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilitiesInQuarter_Details", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilitiesInQuarter_Details) ? "" : smodel.ExternalInfrastructureFacilitiesInQuarter_Details);
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

        public bool Update_QUpdateProject_ExternalInfrastructure_Facilities(ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_quarterlyupdate_ExternalFacilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraExFacilities_IndexID", smodel.QUpdateProjectInfraExFacilities_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInfraExFacilities_ID", smodel.QUpdateProjectInfraExFacilities_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureExFacilitiesIndexID", smodel.Related_ProjectInfrastructureExFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInfrastructureExFacilitiesID", smodel.Related_ProjectInfrastructureExFacilitiesID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID", smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateInfraExFacilities_Year", String.IsNullOrEmpty(smodel.QUpdateInfraExFacilities_Year) ? "0" : smodel.QUpdateInfraExFacilities_Year);
            cmd.Parameters.AddWithValue("p_QUpdateInfraExFacilities_QuarterName", String.IsNullOrEmpty(smodel.QUpdateInfraExFacilities_QuarterName) ? "" : smodel.QUpdateInfraExFacilities_QuarterName);

            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilities_Name", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilities_Name) ? "" : smodel.ExternalInfrastructureFacilities_Name);
            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilities_Type", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilities_Type) ? "" : smodel.ExternalInfrastructureFacilities_Type);
            cmd.Parameters.AddWithValue("p_ExternalAgency_LocalAuthority_Name", String.IsNullOrEmpty(smodel.ExternalAgency_LocalAuthority_Name) ? "" : smodel.ExternalAgency_LocalAuthority_Name);
            cmd.Parameters.AddWithValue("p_Is_InternalInfrastructureFacilitiesApplicable", "YS");
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageUptoRegistration", smodel.WorkProgress_PercentageUptoRegistration);
            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilitiesUptoRegistration_Details", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilitiesUptoRegistration_Details) ? "" : smodel.ExternalInfrastructureFacilitiesUptoRegistration_Details);
            cmd.Parameters.AddWithValue("p_WorkProgress_PercentageInQuarter", smodel.WorkProgress_PercentageInQuarter);
            cmd.Parameters.AddWithValue("p_ExternalInfrastructureFacilitiesInQuarter_Details", String.IsNullOrEmpty(smodel.ExternalInfrastructureFacilitiesInQuarter_Details) ? "" : smodel.ExternalInfrastructureFacilitiesInQuarter_Details);
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

        public List<ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities> Display_QUpdateProject_ExternalInfrastructure_Facilities(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName)
        {
            connection();
            List<ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities> Projectlist = new List<ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ExternalInfrastructureFacilities", con);
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
                       new ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities
                       {
                           QUpdateProjectInfraExFacilities_IndexID = Convert.ToInt64(dr["QUpdateProjectInfraExFacilities_IndexID"]),
                           QUpdateProjectInfraExFacilities_ID = Convert.ToInt64(dr["QUpdateProjectInfraExFacilities_ID"]),
                           Related_ProjectInfrastructureExFacilitiesIndexID = Convert.ToInt64(dr["Related_ProjectInfrastructureExFacilitiesIndexID"]),
                           Related_ProjectInfrastructureExFacilitiesID = Convert.ToInt64(dr["Related_ProjectInfrastructureExFacilitiesID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           QUpdateInfraExFacilities_Year = Convert.ToString(dr["QUpdateInfraExFacilities_Year"]),
                           QUpdateInfraExFacilities_QuarterName = Convert.ToString(dr["QUpdateInfraExFacilities_QuarterName"]),

                           ExternalInfrastructureFacilities_Name = Convert.ToString(dr["ExternalInfrastructureFacilities_Name"]),
                           ExternalInfrastructureFacilities_Type = Convert.ToString(dr["ExternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),

                           WorkProgress_PercentageUptoRegistration = Convert.ToDecimal(dr["WorkProgress_PercentageUptoRegistration"]),
                           ExternalInfrastructureFacilitiesUptoRegistration_Details = Convert.ToString(dr["ExternalInfrastructureFacilitiesUptoRegistration_Details"]),
                           WorkProgress_PercentageInQuarter = Convert.ToDecimal(dr["WorkProgress_PercentageInQuarter"]),
                           ExternalInfrastructureFacilitiesInQuarter_Details = Convert.ToString(dr["ExternalInfrastructureFacilitiesInQuarter_Details"]),
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
        
        public List<ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities> Display_QUpdateProject_ExternalInfrastructure_FacilitiesByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectExFacilitiesIndexID, Int64 QUpdateProjectExFacilitiesID, Int64 RelatedProjectExFacilitiesIndexID, Int64 RelatedProjectExFacilitiesID)
        {
            connection();
            List<ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities> Projectlist = new List<ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ExternalInfrastructureFacilitiesByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectExFacilitiesIndexID", QUpdateProjectExFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectExFacilitiesID", QUpdateProjectExFacilitiesID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExFacilitiesIndexID", RelatedProjectExFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExFacilitiesID", RelatedProjectExFacilitiesID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities
                       {
                           QUpdateProjectInfraExFacilities_IndexID = Convert.ToInt64(dr["QUpdateProjectInfraExFacilities_IndexID"]),
                           QUpdateProjectInfraExFacilities_ID = Convert.ToInt64(dr["QUpdateProjectInfraExFacilities_ID"]),
                           Related_ProjectInfrastructureExFacilitiesIndexID = Convert.ToInt64(dr["Related_ProjectInfrastructureExFacilitiesIndexID"]),
                           Related_ProjectInfrastructureExFacilitiesID = Convert.ToInt64(dr["Related_ProjectInfrastructureExFacilitiesID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           QUpdateInfraExFacilities_Year = Convert.ToString(dr["QUpdateInfraExFacilities_Year"]),
                           QUpdateInfraExFacilities_QuarterName = Convert.ToString(dr["QUpdateInfraExFacilities_QuarterName"]),

                           ExternalInfrastructureFacilities_Name = Convert.ToString(dr["ExternalInfrastructureFacilities_Name"]),
                           ExternalInfrastructureFacilities_Type = Convert.ToString(dr["ExternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),

                           WorkProgress_PercentageUptoRegistration = Convert.ToDecimal(dr["WorkProgress_PercentageUptoRegistration"]),
                           ExternalInfrastructureFacilitiesUptoRegistration_Details = Convert.ToString(dr["ExternalInfrastructureFacilitiesUptoRegistration_Details"]),
                           WorkProgress_PercentageInQuarter = Convert.ToDecimal(dr["WorkProgress_PercentageInQuarter"]),
                           ExternalInfrastructureFacilitiesInQuarter_Details = Convert.ToString(dr["ExternalInfrastructureFacilitiesInQuarter_Details"]),
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

        public bool Delete_QUpdateProject_ExternalInfrastructure_FacilitiesByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectExFacilitiesIndexID, Int64 QUpdateProjectExFacilitiesID, Int64 RelatedProjectExFacilitiesIndexID, Int64 RelatedProjectExFacilitiesID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_ProjectQUpdate_ExternalInfrastructure_FacilitiesByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectExFacilities_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectExFacilities_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectExFacilities_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectExFacilitiesIndexID", QUpdateProjectExFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectExFacilitiesID", QUpdateProjectExFacilitiesID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExFacilitiesIndexID", RelatedProjectExFacilitiesIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExFacilitiesID", RelatedProjectExFacilitiesID);

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