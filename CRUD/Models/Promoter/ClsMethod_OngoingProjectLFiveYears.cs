using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_OngoingProjectLFiveYears
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
  
        /// <summary>
        /// Insert Method
        /// </summary>
        /// <returns></returns>
        public bool AddOnGoingProject(ClsPrp_OngoingProjectLFiveYears smodel,Int64 applicationid)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Promoter_Experience_Completed_OnGoing", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", applicationid); 
            cmd.Parameters.AddWithValue("p_Projectname", String.IsNullOrEmpty(smodel.Projectname) ? "" : smodel.Projectname);

            cmd.Parameters.AddWithValue("p_ProjectType", smodel.ProjectType);
            cmd.Parameters.AddWithValue("p_ProjectStatus", smodel.ProjectStatus);
            cmd.Parameters.AddWithValue("p_AreaConUProject", smodel.AreaConUProject);
            if (smodel.ProjectStartDate == null) 
            {
                cmd.Parameters.AddWithValue("p_ProjectStartDate", "1900-01-01 00:00:00.000");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_ProjectStartDate", smodel.ProjectStartDate);

            }
            if (smodel.ProjectStartDate == null)
            {
                cmd.Parameters.AddWithValue("p_OCDateProject", "1900-01-01 00:00:00.000");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_OCDateProject", smodel.OCDateProject);

            }
            if (smodel.ProjectStartDate == null)
            {
                cmd.Parameters.AddWithValue("p_ACDProject", "1900-01-01 00:00:00.000");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_ACDProject", smodel.ACDProject);

            }
            cmd.Parameters.AddWithValue("p_RExtentofDelayProject", String.IsNullOrEmpty(smodel.RExtentofDelayProject) ? "" : smodel.RExtentofDelayProject);
            cmd.Parameters.AddWithValue("p_TypeLandofProject", smodel.TypeLandofProject);
            cmd.Parameters.AddWithValue("p_LitgToProject", smodel.LitgToProject);


                                                                    cmd.Parameters.AddWithValue("p_CaseTitle", "");// String.IsNullOrEmpty(smodel.CaseTitle) ? "" : smodel.CaseTitle);
                                                                    cmd.Parameters.AddWithValue("p_CaseNumber", "");// String.IsNullOrEmpty(smodel.CaseNumber) ?   "":smodel.CaseNumber);  
                                                                    cmd.Parameters.AddWithValue("p_NameofAuthorityForumwhereCasisPendingresolved",  "");//   String.IsNullOrEmpty(smodel.NameofAuthorityForumwhereCasisPendingresolved) ? "" : smodel.NameofAuthorityForumwhereCasisPendingresolved);
            
                 cmd.Parameters.AddWithValue("p_IsPaymentDetailsPending_RelatedLand", String.IsNullOrEmpty(smodel.IsPaymentDetailsPending_RelatedLand) ? "" : smodel.IsPaymentDetailsPending_RelatedLand);

            cmd.Parameters.AddWithValue("p_DetailPaymentPendingProject", String.IsNullOrEmpty(smodel.DetailPaymentPendingProject) ? "" : smodel.DetailPaymentPendingProject);
            cmd.Parameters.AddWithValue("p_Flag", 0);// smodel.Flag);
            cmd.Parameters.AddWithValue("p_Created_By", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", "Modify_By");            


            //MySqlParameter RetParam = new MySqlParameter("p_Get_id", MySqlDbType.Int64);
            //RetParam.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(RetParam);

            con.Open();
            Int64 i = cmd.ExecuteNonQuery();           
            //int IntReturn = Convert.ToInt32(RetParam.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
         
        /// <summary>
        /// Update Method
        /// </summary>
        /// <returns></returns>
        public bool UpdateOnGoingProject(ClsPrp_OngoingProjectLFiveYears smodel)//,   Int64 applicationid, Int64? Promoter_Experience_ID, Int64 Id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter_Experience_Completed_OnGoing", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Id", smodel.Id);
            cmd.Parameters.AddWithValue("p_Application_id", smodel.Application_id);
             
            cmd.Parameters.AddWithValue("p_Promoter_Experience_ID", smodel.Promoter_Experience_ID);

            cmd.Parameters.AddWithValue("p_Projectname", smodel.Projectname);
            cmd.Parameters.AddWithValue("p_ProjectType", smodel.ProjectType);
            cmd.Parameters.AddWithValue("p_ProjectStatus", smodel.ProjectStatus);
            cmd.Parameters.AddWithValue("p_AreaConUProject", smodel.AreaConUProject);
            cmd.Parameters.AddWithValue("p_ProjectStartDate", smodel.ProjectStartDate);
            cmd.Parameters.AddWithValue("p_OCDateProject", smodel.OCDateProject);
            cmd.Parameters.AddWithValue("p_ACDProject", smodel.ACDProject);
            cmd.Parameters.AddWithValue("p_RExtentofDelayProject", smodel.RExtentofDelayProject);
            cmd.Parameters.AddWithValue("p_TypeLandofProject", smodel.TypeLandofProject);
            cmd.Parameters.AddWithValue("p_LitgToProject", smodel.LitgToProject);

                                                                    cmd.Parameters.AddWithValue("p_CaseTitle", "");// String.IsNullOrEmpty(smodel.CaseTitle) ? "" : smodel.CaseTitle);
                                                                    cmd.Parameters.AddWithValue("p_CaseNumber", "");// String.IsNullOrEmpty(smodel.CaseNumber) ?   "":smodel.CaseNumber);  
                                                                    cmd.Parameters.AddWithValue("p_NameofAuthorityForumwhereCasisPendingresolved", "");//   String.IsNullOrEmpty(smodel.NameofAuthorityForumwhereCasisPendingresolved) ? "" : smodel.NameofAuthorityForumwhereCasisPendingresolved);

            //cmd.Parameters.AddWithValue("p_CaseTitle", smodel.CaseTitle);
            //cmd.Parameters.AddWithValue("p_CaseNumber", smodel.CaseNumber);
            //cmd.Parameters.AddWithValue("p_NameofAuthorityForumwhereCasisPendingresolved", smodel.NameofAuthorityForumwhereCasisPendingresolved);
            cmd.Parameters.AddWithValue("p_IsPaymentDetailsPending_RelatedLand", String.IsNullOrEmpty(smodel.IsPaymentDetailsPending_RelatedLand) ? "" : smodel.IsPaymentDetailsPending_RelatedLand);
            cmd.Parameters.AddWithValue("p_DetailPaymentPendingProject", String.IsNullOrEmpty(smodel.DetailPaymentPendingProject) ? "" : smodel.DetailPaymentPendingProject);//smodel.DetailPaymentPendingProject);
            cmd.Parameters.AddWithValue("p_Flag", 1);
            cmd.Parameters.AddWithValue("p_Created_By", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", "Modify_By");



            MySqlParameter RetParam = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            RetParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RetParam);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int IntReturn = Convert.ToInt32(RetParam.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Display method by application id only
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_OngoingProjectLFiveYears> DisplaybyID_ongoingProject(Int64 Application_id)
        {
            connection();
            List<ClsPrp_OngoingProjectLFiveYears> ProjectFivelist = new List<ClsPrp_OngoingProjectLFiveYears>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Experince_Complete_ongoingByApplicationID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                    new ClsPrp_OngoingProjectLFiveYears
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Application_id = Convert.ToInt64(dr["Application_id"]),
                        Projectname = Convert.ToString(dr["Projectname"]),
                        ProjectType = Convert.ToString(dr["ProjectType"]),
                        ProjectStatus = Convert.ToString(dr["ProjectStatus"]),
                        AreaConUProject = Convert.ToDouble(dr["AreaConUProject"]),
                        ProjectStartDate = Convert.ToDateTime(dr["ProjectStartDate"]),
                        OCDateProject = Convert.ToDateTime(dr["OCDateProject"]),
                        ACDProject = Convert.ToDateTime(dr["ACDProject"]),
                        RExtentofDelayProject = Convert.ToString(dr["RExtentofDelayProject"]),
                        TypeLandofProject = Convert.ToString(dr["TypeLandofProject"]),
                        LitgToProject = Convert.ToString(dr["LitgToProject"]),

                        CaseTitle = Convert.ToString(dr["CaseTitle"]),
                        CaseNumber = Convert.ToString(dr["CaseNumber"]),
                        NameofAuthorityForumwhereCasisPendingresolved = Convert.ToString(dr["NameofAuthorityForumwhereCasisPendingresolved"]),
                        IsPaymentDetailsPending_RelatedLand = Convert.ToString(dr["IsPaymentDetailsPending_RelatedLand"]),
                        DetailPaymentPendingProject = Convert.ToString(dr["DetailPaymentPendingProject"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["Flag"]),
                        Created_On = Convert.ToDateTime(dr["Created_On"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),

                    });
            }
            return ProjectFivelist;
        }
        /// <summary>
        /// Display method by application id, id
        /// </summary>
        /// <param name="Application_id"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ClsPrp_OngoingProjectLFiveYears> DisplaybyID_ongoingProject(Int64 Application_id, Int64 Id)
        {
            List<ClsPrp_OngoingProjectLFiveYears> ProjectFivelist = new List<ClsPrp_OngoingProjectLFiveYears>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Exp_Complete_ongoingByApplicationIDandID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            cmd.Parameters.AddWithValue("p_id", Id);
            connection();
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_OngoingProjectLFiveYears clspro = new ClsPrp_OngoingProjectLFiveYears();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                   new ClsPrp_OngoingProjectLFiveYears
                   {
                       Promoter_Experience_ID = Convert.ToInt32(dr["Promoter_Experience_ID"]),
                       Id = Convert.ToInt32(dr["Id"]),
                       Application_id = Convert.ToInt64(dr["Application_id"]),
                       Projectname = Convert.ToString(dr["Projectname"]),
                       ProjectType = Convert.ToString(dr["ProjectType"]),
                       ProjectStatus = Convert.ToString(dr["ProjectStatus"]),
                       AreaConUProject = Convert.ToDouble(dr["AreaConUProject"]),
                       ProjectStartDate = Convert.ToDateTime(dr["ProjectStartDate"]),
                       OCDateProject = Convert.ToDateTime(dr["OCDateProject"]),
                       ACDProject = Convert.ToDateTime(dr["ACDProject"]),
                       RExtentofDelayProject = Convert.ToString(dr["RExtentofDelayProject"]),
                       TypeLandofProject = Convert.ToString(dr["TypeLandofProject"]),
                       LitgToProject = Convert.ToString(dr["LitgToProject"]),

                       CaseTitle = Convert.ToString(dr["CaseTitle"]),
                       CaseNumber = Convert.ToString(dr["CaseNumber"]),
                       NameofAuthorityForumwhereCasisPendingresolved = Convert.ToString(dr["NameofAuthorityForumwhereCasisPendingresolved"]),
                       IsPaymentDetailsPending_RelatedLand = Convert.ToString(dr["IsPaymentDetailsPending_RelatedLand"]),

                       DetailPaymentPendingProject = Convert.ToString(dr["DetailPaymentPendingProject"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["Flag"]),
                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),

                   });


            }
            //clspro.prpongoing= ProjectFivelist
            return ProjectFivelist;



            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }
        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="Application_id"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete_OngoingProject(Int64 Application_id,int Id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Promoter_Experience_Completed_OnGoing", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            cmd.Parameters.AddWithValue("p_id", Id);
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
        public List<ClsPrp_OngoingProjectLFiveYears> ListofProjects(Int64 PromoterId)
        {

            List<ClsPrp_OngoingProjectLFiveYears> userlist1 = new List<ClsPrp_OngoingProjectLFiveYears>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))  
            {
                //"select Projectname from tbl_RERA_Promoter_Experience_Completed_OnGoing where Application_id='"
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_PromoterProjectRecord_Litigations_ByPromoterId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_PromoterId", PromoterId);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_OngoingProjectLFiveYears uobj = new ClsPrp_OngoingProjectLFiveYears();
                        uobj.Projectname = ds.Tables[0].Rows[i]["Projectname"].ToString();
                        uobj.Promoter_Experience_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["Promoter_Experience_ID"]);

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }
            }
        }
    }
}