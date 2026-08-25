using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_QuarterlyUpdatesProjectStatusInternalFacilities
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities> Display_QuarterlyUpdatesProject_StatusOfInternalFacilities(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_StatusInternalFacilitiesForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdates_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdates_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdates_Flag", viewCriteriaFlag);
            cmd.Parameters.AddWithValue("p_QUpdates_UserRole", UserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities
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
                           setQUpdateProject_QuarterName = Convert.ToString(dr["setQUpdateProject_QuarterName"]),
                       });
            }
            return ProjectList;
        }

        public Int32 Update_PublicUnpublicHandler_QuarterlyUpdatesProject_StatusOfInternalFacilitiesByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, string PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_tbl_rera_QUpdatesProject_InternalFacsByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", 0);
            cmd.Parameters.AddWithValue("p_RelatedRefIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_RelatedRefID", RelatedRefID);
            cmd.Parameters.AddWithValue("p_PublicUnpublicValue", PublicUnpublicCode);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

    }
}