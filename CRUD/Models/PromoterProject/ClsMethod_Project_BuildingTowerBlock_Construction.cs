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
    public class ClsMethod_Project_BuildingTowerBlock_Construction
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_BuildingTowerBlock_Construction(ClsPrp_Project_BuildingTowerBlock_Construction smodel)//, Int64 Project_id)// string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_BuildingTowerBlock_Construction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters


            cmd.Parameters.AddWithValue("p_p_ProjectConstructionRelated_ProjectRegistration_ID", smodel.ProjectConstructionRelated_ProjectRegistration_ID);// Project_id);
            cmd.Parameters.AddWithValue("p_p_BuildingTowerBlock_Name", smodel.BuildingTowerBlock_Name);
            cmd.Parameters.AddWithValue("p_p_Proposed_FloorPlotsNumber", smodel.Proposed_FloorPlotsNumber);
            cmd.Parameters.AddWithValue("p_p_CurrentlySanctioned_FloorPlotsNumber", smodel.CurrentlySanctioned_FloorPlotsNumber);
            cmd.Parameters.AddWithValue("p_p_Constructed_FloorsNumber", smodel.Constructed_FloorsNumber);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);

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
             con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_Project_BuildingTowerBlock_Construction(ClsPrp_Project_BuildingTowerBlock_Construction smodel)//, string PANaddress, string OrgCertaddress, string Image_FileName, Int64 Application_id, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_BuildingTowerBlock_Construction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectConstruction_IndexID", smodel.ProjectConstruction_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectConstruction_ID", smodel.ProjectConstruction_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectConstructionRelated_ProjectRegistration_ID", smodel.ProjectConstructionRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_BuildingTowerBlock_Name", smodel.BuildingTowerBlock_Name);
            cmd.Parameters.AddWithValue("p_p_Proposed_FloorPlotsNumber", smodel.Proposed_FloorPlotsNumber);
            cmd.Parameters.AddWithValue("p_p_CurrentlySanctioned_FloorPlotsNumber", smodel.CurrentlySanctioned_FloorPlotsNumber);
            cmd.Parameters.AddWithValue("p_p_Constructed_FloorsNumber", smodel.Constructed_FloorsNumber);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", "");
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            //cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "p_ModifyBy");

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

        public List<ClsPrp_Project_BuildingTowerBlock_Construction> Display_BuildingTowerBlock_Construction(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_BuildingTowerBlock_Construction> ProjectFivelist1 = new List<ClsPrp_Project_BuildingTowerBlock_Construction>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_BuildingTowerBlock_Construction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_BuildingTowerBlock_Construction
                       {
                           ProjectConstruction_IndexID = Convert.ToInt64(dr["ProjectConstruction_IndexID"]),
                           ProjectConstruction_ID = Convert.ToInt64(dr["ProjectConstruction_ID"]),
                           ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectConstructionRelated_ProjectRegistration_ID"]),
                           BuildingTowerBlock_Name = Convert.ToString(dr["BuildingTowerBlock_Name"]),
                           Proposed_FloorPlotsNumber = Convert.ToInt32(dr["Proposed_FloorPlotsNumber"]),
                           CurrentlySanctioned_FloorPlotsNumber = Convert.ToInt32(dr["CurrentlySanctioned_FloorPlotsNumber"]),
                           Constructed_FloorsNumber = Convert.ToInt32(dr["Constructed_FloorsNumber"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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
        public List<ClsPrp_Project_BuildingTowerBlock_Construction> Display_BuildingTowerBlock_ConstructionBYID(Int64 ProjectRegistration_ID, Int64 Id)
        {
            connection();

            List<ClsPrp_Project_BuildingTowerBlock_Construction> ProjectFivelist1 = new List<ClsPrp_Project_BuildingTowerBlock_Construction>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_BuildingTowerBlock_ConstructionID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectConstruction_IndexID", Id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_BuildingTowerBlock_Construction
                       {
                           ProjectConstruction_IndexID = Convert.ToInt64(dr["ProjectConstruction_IndexID"]),
                           ProjectConstruction_ID = Convert.ToInt64(dr["ProjectConstruction_ID"]),
                           ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectConstructionRelated_ProjectRegistration_ID"]),
                           BuildingTowerBlock_Name = Convert.ToString(dr["BuildingTowerBlock_Name"]),
                           Proposed_FloorPlotsNumber = Convert.ToInt32(dr["Proposed_FloorPlotsNumber"]),
                           CurrentlySanctioned_FloorPlotsNumber = Convert.ToInt32(dr["CurrentlySanctioned_FloorPlotsNumber"]),
                           Constructed_FloorsNumber = Convert.ToInt32(dr["Constructed_FloorsNumber"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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
        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="Application_id"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete_BuildingTowerBlock_Construction(Int64 Application_id, Int64 id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_Project_BuildingTowerBlock_ConstructionById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_p_ProjectConstruction_IndexID", id);
            cmd.Parameters.AddWithValue("p_p_ProjectConstRelated_ProjectReg_ID", Application_id);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Display method for list of projects from Clsprp_Promoter_FiveYr_OngoingProjcts
        /// </summary>
        /// <returns></returns>
        //public List<ClsPrp_OngoingProjectLFiveYears> ListofProjects(Int64 Application_id)
        //{

        //    List<ClsPrp_OngoingProjectLFiveYears> userlist1 = new List<ClsPrp_OngoingProjectLFiveYears>();

        //    //Clsprp_Promoter objuser = new Clsprp_Promoter();
        //    DataSet ds = new DataSet();
        //    string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
        //    MySqlConnection con = new MySqlConnection();
        //    using (con = new MySqlConnection(constring))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("select Projectname from tbl_RERA_Promoter_Experience_Completed_OnGoing where Application_id='" + Application_id + "'", con))
        //        {
        //            con.Open();
        //            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //            da.Fill(ds);

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                ClsPrp_OngoingProjectLFiveYears uobj = new ClsPrp_OngoingProjectLFiveYears();
        //                uobj.Projectname = ds.Tables[0].Rows[i]["Projectname"].ToString();


        //                userlist1.Add(uobj);

        //            }
        //            // objuser.districtMaster = userlist1;
        //            con.Close();
        //            return userlist1;
        //        }




        //    }






    }
    
}