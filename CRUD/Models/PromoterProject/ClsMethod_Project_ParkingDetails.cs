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
    public class ClsMethod_Project_ParkingDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_ParkingDetails(ClsPrp_Project_ParkingDetails smodel, Int64 Project_id)// string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_ParkingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_PutProjectLand_ID", smodel.PutProjectLand_ID);
            //cmd.Parameters.AddWithValue("p_p_ProjectParking_IndexID", Project_id);// smodel.ProjectParking_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectParking_ID", smodel.ProjectParking_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectParkingRelated_ProjectRegistration_ID", smodel.ProjectParkingRelated_ProjectRegistration_ID);// smodel.ProjectParkingRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ParkingType", smodel.ParkingType);
            cmd.Parameters.AddWithValue("p_p_ParkingSpace_AvailableforSale_Number", smodel.ParkingSpace_AvailableforSale_Number);
            cmd.Parameters.AddWithValue("p_p_ParkingSpace_Area_Total", smodel.ParkingSpace_Area_Total);
            cmd.Parameters.AddWithValue("p_p_ParkingSpace_BookedSold_Number", smodel.ParkingSpace_BookedSold_Number);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            //cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);

            // cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");


            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

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

        public bool Update_Project_ParkingDetails(ClsPrp_Project_ParkingDetails smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_ParkingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectParking_IndexID", smodel.ProjectParking_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectParking_ID", smodel.ProjectParking_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectParkingRelated_ProjectRegistration_ID", smodel.ProjectParkingRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ParkingType", smodel.ParkingType);
            cmd.Parameters.AddWithValue("p_p_ParkingSpace_AvailableforSale_Number", smodel.ParkingSpace_AvailableforSale_Number);
            cmd.Parameters.AddWithValue("p_p_ParkingSpace_Area_Total", smodel.ParkingSpace_Area_Total);
            cmd.Parameters.AddWithValue("p_p_ParkingSpace_BookedSold_Number", smodel.ParkingSpace_BookedSold_Number);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            // cmd.Parameters.AddWithValue("p_p_C_column", "");
            //cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            // cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "ModifyBy");
            // cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);

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

        public List<ClsPrp_Project_ParkingDetails> Display_Project_ParkingDetails(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_Project_ParkingDetails> ProjectFivelist1 = new List<ClsPrp_Project_ParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ParkingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectParking_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ParkingDetails
                       {
                           ProjectParking_IndexID = Convert.ToInt64(dr["ProjectParking_IndexID"]),
                           ProjectParking_ID = Convert.ToInt64(dr["ProjectParking_ID"]),
                           ProjectParkingRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectParkingRelated_ProjectRegistration_ID"]),
                           ParkingType = Convert.ToString(dr["ParkingType"]),
                           ParkingSpace_AvailableforSale_Number = Convert.ToInt16(dr["ParkingSpace_AvailableforSale_Number"]),
                           ParkingSpace_Area_Total = Convert.ToDouble(dr["ParkingSpace_Area_Total"]),
                           ParkingSpace_BookedSold_Number = Convert.ToInt16(dr["ParkingSpace_BookedSold_Number"]),
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
            return ProjectFivelist1;
        }

        public List<ClsPrp_Project_ParkingDetails> Display_Project_ParkingDetailsById(Int64 ProjectRegistration_ID,Int64 ProjectParking_IndexID)
        {

            connection();
            List<ClsPrp_Project_ParkingDetails> ProjectFivelist1 = new List<ClsPrp_Project_ParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ParkingDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectParking_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectParking_IndexID", ProjectParking_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ParkingDetails
                       {
                           ProjectParking_IndexID = Convert.ToInt64(dr["ProjectParking_IndexID"]),
                           ProjectParking_ID = Convert.ToInt64(dr["ProjectParking_ID"]),
                           ProjectParkingRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectParkingRelated_ProjectRegistration_ID"]),
                           ParkingType = Convert.ToString(dr["ParkingType"]),
                           ParkingSpace_AvailableforSale_Number = Convert.ToInt16(dr["ParkingSpace_AvailableforSale_Number"]),
                           ParkingSpace_Area_Total = Convert.ToDouble(dr["ParkingSpace_Area_Total"]),
                           ParkingSpace_BookedSold_Number = Convert.ToInt16(dr["ParkingSpace_BookedSold_Number"]),
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
            return ProjectFivelist1;
        }

        public bool Delete_Project_ParkingDetails(Int64 ProjectParking_IndexID, Int64 ProjectRegistration_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_Parking", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectLitigations_IndexID", ProjectParking_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
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