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
    public class ClsMethod_OrgExp
    {

        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public Int64 AddOrgExp(ClsPrp_OrgExp smodel, string PANaddress, string OrgCertaddress, string Image_FileName, string UID, string UserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Promoter_Org", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
           
            cmd.Parameters.AddWithValue("p_Auth_signatory_Name", smodel.First_Name);

            cmd.Parameters.AddWithValue("p_Org_Name", smodel.Org_Name);
            cmd.Parameters.AddWithValue("p_Org_Type", smodel.Org_Type);
            cmd.Parameters.AddWithValue("p_Org_Objects", smodel.Org_Objects);

            cmd.Parameters.AddWithValue("p_Org_Address_Line1", smodel.Org_Address_Line1);
            if (String.IsNullOrEmpty(smodel.Org_Address_Line2))//||(smodel.Org_Address_Line2.Trim() == string.Empty)|| (smodel.Org_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Org_Address_Line2", "");
            }
            else { cmd.Parameters.AddWithValue("p_Org_Address_Line2", smodel.Org_Address_Line2); }
            cmd.Parameters.AddWithValue("p_Org_State", smodel.Org_State);
            cmd.Parameters.AddWithValue("p_Org_District", smodel.Org_District);
            cmd.Parameters.AddWithValue("p_Org_Pin_Code", smodel.Org_Pin_Code);


            cmd.Parameters.AddWithValue("p_Address_Line1", smodel.Address_Line1);
            if (String.IsNullOrEmpty(smodel.Address_Line2))//||(smodel.Org_Address_Line2.Trim() == string.Empty)|| (smodel.Org_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", "");
            }
            else { cmd.Parameters.AddWithValue("p_Address_Line2", smodel.Address_Line2); }
            cmd.Parameters.AddWithValue("p_State", smodel.State);
            cmd.Parameters.AddWithValue("p_District", smodel.District);
            cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);
            if (smodel.Phone_No_STD == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", smodel.Phone_No_STD);

            }
            //cmd.Parameters.AddWithValue("p_Phone_No_STD", smodel.Phone_No_STD);
            cmd.Parameters.AddWithValue("p_Auth_signatory_Mobile_no", smodel.Mobile_no);

            if (smodel.Phone_No == null)
            { cmd.Parameters.AddWithValue("p_Auth_signatory_Phone_No", 0); }
            else { cmd.Parameters.AddWithValue("p_Auth_signatory_Phone_No", smodel.Phone_No); }

            cmd.Parameters.AddWithValue("p_Auth_signatory_Email", smodel.Email);

            cmd.Parameters.AddWithValue("p_WebLink_Promoter_website", String.IsNullOrEmpty(smodel.WebLink_Promoter_website) ? "" : smodel.WebLink_Promoter_website); //smodel.WebLink_Promoter_website);

            cmd.Parameters.AddWithValue("p_Past_Exp_Punjab", smodel.Past_Exp_Punjab);
            cmd.Parameters.AddWithValue("p_Past_Exp_Other_States", smodel.Past_Exp_Other_States);

            cmd.Parameters.AddWithValue("p_PAN_No", smodel.PAN_No);
            //cmd.Parameters.AddWithValue("p_PAN_Doc_Address", String.IsNullOrEmpty(PANaddress) ? "" : PANaddress);
            //cmd.Parameters.AddWithValue("p_RExtentofDelayProject", String.IsNullOrEmpty(smodel.RExtentofDelayProject) ? "" : smodel.RExtentofDelayProject);

            cmd.Parameters.AddWithValue("p_Image_FileName", Image_FileName);

            cmd.Parameters.AddWithValue("p_Experience", smodel.Experience);

            cmd.Parameters.AddWithValue("p_Org_Reg_Certificate", String.IsNullOrEmpty(smodel.Org_Reg_Certificate) ? "N" : smodel.Org_Reg_Certificate);

            cmd.Parameters.AddWithValue("p_Ind_Org_CompltdProj_FiveYrs", smodel.Ind_Org_CompltdProj_FiveYrs);
            cmd.Parameters.AddWithValue("p_Ind_Org_TotalArea_Constructed", smodel.Ind_Org_TotalArea_Constructed);
            cmd.Parameters.AddWithValue("p_Ind_Org_OngoingProjects", smodel.Ind_Org_OngoingProjects);
            cmd.Parameters.AddWithValue("p_Ind_Org_AreaToBe_Constructed", smodel.Ind_Org_AreaToBe_Constructed);
            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", smodel.IsOtherOrganizationMembers);

            cmd.Parameters.AddWithValue("p_Flag", 2);
            cmd.Parameters.AddWithValue("p_Created_By", UserName);
            cmd.Parameters.AddWithValue("p_Modify_By", UserName);
            cmd.Parameters.AddWithValue("p_Last_FiveYr_Exp", "NA"); //smodel.Last_FiveYr_Exp);
            cmd.Parameters.AddWithValue("p_Ongoing_Exp", "NA"); //smodel.Ongoing_Exp);
            cmd.Parameters.AddWithValue("p_Org_Parent_Entity", smodel.Org_Parent_Entity);
            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", "NA");//smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_UID", UID);

            MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            return AppId;
        }

        public bool EditOrgExp(ClsPrp_OrgExp smodel, string PANaddress, string OrgCertaddress, string Image_FileName, Int64 Application_id, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter_Org", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);
            cmd.Parameters.AddWithValue("p_Auth_signatory_Name", smodel.First_Name);

            cmd.Parameters.AddWithValue("p_Org_Name", smodel.Org_Name);
            cmd.Parameters.AddWithValue("p_Org_Type", smodel.Org_Type);
            cmd.Parameters.AddWithValue("p_Org_Objects", smodel.Org_Objects);

            cmd.Parameters.AddWithValue("p_Org_Address_Line1", smodel.Org_Address_Line1);
            if (String.IsNullOrEmpty(smodel.Org_Address_Line2))//||(smodel.Org_Address_Line2.Trim() == string.Empty)|| (smodel.Org_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Org_Address_Line2", "");
            }
            else { cmd.Parameters.AddWithValue("p_Org_Address_Line2", smodel.Org_Address_Line2); }
            cmd.Parameters.AddWithValue("p_Org_State", smodel.Org_State);
            cmd.Parameters.AddWithValue("p_Org_District", smodel.Org_District);
            cmd.Parameters.AddWithValue("p_Org_Pin_Code", smodel.Org_Pin_Code);


            cmd.Parameters.AddWithValue("p_Address_Line1", smodel.Address_Line1);
            if (String.IsNullOrEmpty(smodel.Address_Line2))//||(smodel.Org_Address_Line2.Trim() == string.Empty)|| (smodel.Org_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", "");
            }
            else { cmd.Parameters.AddWithValue("p_Address_Line2", smodel.Address_Line2); }
            cmd.Parameters.AddWithValue("p_State", smodel.State);
            cmd.Parameters.AddWithValue("p_District", smodel.District);
            cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);

            if (smodel.Phone_No_STD == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", smodel.Phone_No_STD);

            }
           // cmd.Parameters.AddWithValue("p_Phone_No_STD", smodel.Phone_No_STD);
            cmd.Parameters.AddWithValue("p_Auth_signatory_Mobile_no", smodel.Mobile_no);
            if (smodel.Phone_No == null)
            { cmd.Parameters.AddWithValue("p_Auth_signatory_Phone_No", 0); }
            else { cmd.Parameters.AddWithValue("p_Auth_signatory_Phone_No", smodel.Phone_No); }
            cmd.Parameters.AddWithValue("p_Auth_signatory_Email", smodel.Email);

            cmd.Parameters.AddWithValue("p_WebLink_Promoter_website", String.IsNullOrEmpty(smodel.WebLink_Promoter_website) ? "" : smodel.WebLink_Promoter_website); //smodel.WebLink_Promoter_website);

            cmd.Parameters.AddWithValue("p_Past_Exp_Punjab", smodel.Past_Exp_Punjab);
            cmd.Parameters.AddWithValue("p_Past_Exp_Other_States", smodel.Past_Exp_Other_States);

            cmd.Parameters.AddWithValue("p_PAN_No", smodel.PAN_No);
            //cmd.Parameters.AddWithValue("p_PAN_Doc_Address", String.IsNullOrEmpty(PANaddress) ? "" : PANaddress);
            //cmd.Parameters.AddWithValue("p_RExtentofDelayProject", String.IsNullOrEmpty(smodel.RExtentofDelayProject) ? "" : smodel.RExtentofDelayProject);

            cmd.Parameters.AddWithValue("p_Image_FileName", "img");

            cmd.Parameters.AddWithValue("p_Experience", smodel.Experience);

            cmd.Parameters.AddWithValue("p_Org_Reg_Certificate", String.IsNullOrEmpty(smodel.Org_Reg_Certificate) ? "N" : smodel.Org_Reg_Certificate);

            cmd.Parameters.AddWithValue("p_Ind_Org_CompltdProj_FiveYrs", smodel.Ind_Org_CompltdProj_FiveYrs);
            cmd.Parameters.AddWithValue("p_Ind_Org_TotalArea_Constructed", smodel.Ind_Org_TotalArea_Constructed);
            cmd.Parameters.AddWithValue("p_Ind_Org_OngoingProjects", smodel.Ind_Org_OngoingProjects);
            cmd.Parameters.AddWithValue("p_Ind_Org_AreaToBe_Constructed", smodel.Ind_Org_AreaToBe_Constructed);
            cmd.Parameters.AddWithValue("p_IsOtherOrganizationMembers", smodel.IsOtherOrganizationMembers);

            cmd.Parameters.AddWithValue("p_Flag", 2);
            cmd.Parameters.AddWithValue("p_Created_By", userName); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", userName); // smodel.Modify_By);
            cmd.Parameters.AddWithValue("p_Last_FiveYr_Exp", "NA"); //smodel.Last_FiveYr_Exp);
            cmd.Parameters.AddWithValue("p_Ongoing_Exp", "NA"); //smodel.Ongoing_Exp);
            cmd.Parameters.AddWithValue("p_Org_Parent_Entity", smodel.Org_Parent_Entity);
            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", "NA");//smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_UID", UID);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
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

        public ClsPrp_OrgExp DisplayOrgExp(Int64 Application_id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayRegExp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_OrgExp clspro = new ClsPrp_OrgExp();

            foreach (DataRow dr in dt.Rows)
            {
                clspro.Application_id = Convert.ToInt64(dr["Application_id"]);
                clspro.First_Name = Convert.ToString(dr["First_Name"]); //Gives name of Authorized signatory

                clspro.Org_Name = Convert.ToString(dr["Org_Name"]);
                clspro.Org_Type = Convert.ToString(dr["Org_Type"]);
                clspro.Org_Objects = Convert.ToString(dr["Org_Objects"]);

                clspro.Org_Address_Line1 = Convert.ToString(dr["Org_Address_Line1"]);
                clspro.Org_Address_Line2 = Convert.ToString(dr["Org_Address_Line2"]);
                clspro.Org_State = Convert.ToString(dr["Org_State"]);
                clspro.Org_District = Convert.ToString(dr["Org_District"]);
                clspro.Org_Pin_Code = Convert.ToInt64(dr["Org_Pin_Code"]);

                clspro.Address_Line1 = Convert.ToString(dr["Address_Line1"]);
                clspro.Address_Line2 = Convert.ToString(dr["Address_Line2"]);
                clspro.State = Convert.ToString(dr["State"]);
                clspro.District = Convert.ToString(dr["District"]);
                clspro.Pin_Code = Convert.ToInt64(dr["Pin_Code"]);

                clspro.Phone_No_STD = Convert.ToInt64(dr["Phone_No_STD"]);
                clspro.Mobile_no = Convert.ToInt64(dr["Mobile_no"]);
                clspro.Phone_No = Convert.ToInt64(dr["Phone_No"]);
                clspro.Email = Convert.ToString(dr["Email"]);

                clspro.WebLink_Promoter_website = Convert.ToString(dr["WebLink_Promoter_website"]);

                clspro.Past_Exp_Punjab = Convert.ToInt16(dr["Past_Exp_Punjab"]);
                clspro.Past_Exp_Other_States = Convert.ToInt16(dr["Past_Exp_Other_States"]);
                
                clspro.Image_FileName = Convert.ToString(dr["Image_FileName"]);
                clspro.PAN_No = Convert.ToString(dr["PAN_No"]);
                clspro.PAN_Doc_Address = Convert.ToString(dr["PAN_Doc_Address"]);
                
                clspro.IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]);
                clspro.Experience = Convert.ToString(dr["Experience"]);

                clspro.Org_Reg_Certificate = Convert.ToString(dr["Org_Reg_Certificate"]);

                clspro.Ind_Org_CompltdProj_FiveYrs = Convert.ToInt32(dr["Ind_Org_CompltdProj_FiveYrs"]);
                clspro.Ind_Org_TotalArea_Constructed = Convert.ToDecimal(dr["Ind_Org_TotalArea_Constructed"]);
                clspro.Ind_Org_OngoingProjects = Convert.ToInt32(dr["Ind_Org_OngoingProjects"]);
                clspro.Ind_Org_AreaToBe_Constructed = Convert.ToDecimal(dr["Ind_Org_AreaToBe_Constructed"]);
                clspro.Last_FiveYr_Exp = Convert.ToString(dr["Last_FiveYr_Exp"]);
                clspro.Ongoing_Exp = Convert.ToString(dr["Ongoing_Exp"]);
                clspro.Org_Parent_Entity = Convert.ToString(dr["Org_Parent_Entity"]);
                clspro.IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]);
                clspro.Flag = Convert.ToInt32(dr["Flag"]);

                clspro.IsActive = Convert.ToInt32(dr["IsActive"]);
                clspro.IsDraft = Convert.ToInt32(dr["IsDraft"]);
                clspro.Created_On = Convert.ToDateTime(dr["Created_On"]);
                clspro.Created_By = Convert.ToString(dr["Created_By"]);
                clspro.Modified_On = Convert.ToDateTime(dr["Modified_On"]);
                clspro.Modify_By = Convert.ToString(dr["Modify_By"]);

            }
            con.Close();
            return clspro;
        }
    }
}