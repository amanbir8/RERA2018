using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_Promoter
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD PROMOTER DETAIL *********************

        public Clsprp_Promoter DisplayIndPro(Int64 Application_id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayIndPro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            connection();
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            Clsprp_Promoter clspro = new Clsprp_Promoter();

            foreach (DataRow dr in dt.Rows)
            {

                clspro.Application_id = Convert.ToInt64(dr["Application_id"]);
                clspro.First_Name = Convert.ToString(dr["First_Name"]);
                clspro.Middle_Name = Convert.ToString(dr["Middle_Name"]);
                clspro.Last_Name = Convert.ToString(dr["Last_Name"]);
                clspro.Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]);
                clspro.Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]);
                clspro.Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]);
                clspro.Occupation = Convert.ToString(dr["Occupation"]);
                clspro.Address_Line1 = Convert.ToString(dr["Address_Line1"]);
                clspro.Address_Line2 = Convert.ToString(dr["Address_Line2"]);
                clspro.State = Convert.ToString(dr["State"]);
                clspro.District = Convert.ToString(dr["District"]);
                clspro.Pin_Code = Convert.ToInt64(dr["Pin_Code"]);
                clspro.Mobile_no = Convert.ToInt64(dr["Mobile_no"]);
                clspro.Phone_No = Convert.ToInt64(dr["Phone_No"]);
                clspro.Email = Convert.ToString(dr["Email"]);
                clspro.WebLink_Promoter_website = Convert.ToString(dr["WebLink_Promoter_website"]);
                clspro.Past_Exp_Punjab = Convert.ToInt32(dr["Past_Exp_Punjab"]);
                clspro.Past_Exp_Other_States = Convert.ToInt32(dr["Past_Exp_Other_States"]);
                clspro.PAN_No = Convert.ToString(dr["PAN_No"]);
                clspro.PAN_Doc_Address = Convert.ToString(dr["PAN_Doc_Address"]);
                clspro.Photo_Address = Convert.ToString(dr["Photo_Address"]);
                clspro.Aadhaar = Convert.ToInt64(dr["Aadhaar"]);
                clspro.Experience = Convert.ToString(dr["Experience"]);

                clspro.Org_Reg_Certificate = Convert.ToString(dr["Org_Reg_Certificate"]);

                clspro.Ind_Org_CompltdProj_FiveYrs = Convert.ToInt32(dr["Ind_Org_CompltdProj_FiveYrs"]);
                clspro.Ind_Org_TotalArea_Constructed = Convert.ToDecimal(dr["Ind_Org_TotalArea_Constructed"]);
                clspro.Ind_Org_OngoingProjects = Convert.ToInt32(dr["Ind_Org_OngoingProjects"]);
                clspro.Ind_Org_AreaToBe_Constructed = Convert.ToDecimal(dr["Ind_Org_AreaToBe_Constructed"]);
                clspro.Last_FiveYr_Exp = Convert.ToString(dr["Last_FiveYr_Exp"]);
                clspro.Ongoing_Exp = Convert.ToString(dr["Ongoing_Exp"]);
                clspro.Image_FileName = Convert.ToString(dr["Image_FileName"]);
                clspro.Flag = Convert.ToInt32(dr["Flag"]);

                clspro.IsActive = Convert.ToInt32(dr["IsActive"]);
                clspro.IsDraft = Convert.ToInt32(dr["IsDraft"]);
                clspro.Created_On = Convert.ToDateTime(dr["Created_On"]);
                clspro.Created_By = Convert.ToString(dr["Created_By"]);
                clspro.Modified_On = Convert.ToDateTime(dr["Modified_On"]);
                clspro.Modify_By = Convert.ToString(dr["Modify_By"]);

            }

            return clspro;



            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }

        public Int64 AddIndPro(Clsprp_Promoter smodel,string photoaddress,string panaddress,string UID, string userName, string ExtFile)
        {
            connection(); 
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Promoter", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_First_Name", smodel.First_Name);
            if (String.IsNullOrEmpty(smodel.Middle_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Middle_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Middle_Name", smodel.Middle_Name);

            }
            if (String.IsNullOrEmpty(smodel.Last_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Last_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Last_Name", smodel.Last_Name);

            }
           
            cmd.Parameters.AddWithValue("p_Fath_First_Name", smodel.Fath_First_Name);

            if (String.IsNullOrEmpty(smodel.Fath_Middle_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Fath_Middle_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Fath_Middle_Name", smodel.Fath_Middle_Name);

            }
            if (String.IsNullOrEmpty(smodel.Fath_Last_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Fath_Last_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Fath_Last_Name", smodel.Fath_Last_Name);

            }
           
            //cmd.Parameters.AddWithValue("p_Occupation", smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation);//   smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Address_Line1", smodel.Address_Line1);
            if (String.IsNullOrEmpty(smodel.Address_Line2))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", smodel.Address_Line2);

            }
            cmd.Parameters.AddWithValue("p_State", smodel.State);
            cmd.Parameters.AddWithValue("p_District", smodel.District);
            cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);
            cmd.Parameters.AddWithValue("p_Mobile_no", smodel.Mobile_no);

            if (smodel.Phone_No_STD == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", smodel.Phone_No_STD);

            }
            if (smodel.Phone_No == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No", smodel.Phone_No);

            }
            cmd.Parameters.AddWithValue("p_Email", smodel.Email);
            cmd.Parameters.AddWithValue("p_WebLink_Promoter_website", String.IsNullOrEmpty(smodel.WebLink_Promoter_website) ? "" : smodel.WebLink_Promoter_website);//smodel.WebLink_Promoter_website);

            cmd.Parameters.AddWithValue("p_Past_Exp_Punjab", smodel.Past_Exp_Punjab);
            cmd.Parameters.AddWithValue("p_Past_Exp_Other_States", smodel.Past_Exp_Other_States);

            cmd.Parameters.AddWithValue("p_PAN_No", smodel.PAN_No);

            //cmd.Parameters.AddWithValue("p_PAN_Doc_Address", panaddress);// smodel.PAN_Doc_Address); 
            cmd.Parameters.AddWithValue("p_PAN_Doc_Address", "");//  panaddress);// smodel.PAN_Doc_Address);
            cmd.Parameters.AddWithValue("p_Image_FileName", ExtFile);// photoaddress);// smodel.Photo_Address);
            cmd.Parameters.AddWithValue("p_Photo_Address", photoaddress);// smodel.Photo_Address);
            cmd.Parameters.AddWithValue("p_aadhaar", smodel.Aadhaar);
            cmd.Parameters.AddWithValue("p_Experience", smodel.Experience);

            cmd.Parameters.AddWithValue("p_Org_Reg_Certificate", String.IsNullOrEmpty(smodel.Org_Reg_Certificate) ? "N" : smodel.Org_Reg_Certificate);

            cmd.Parameters.AddWithValue("p_Ind_Org_CompltdProj_FiveYrs", smodel.Ind_Org_CompltdProj_FiveYrs);
            cmd.Parameters.AddWithValue("p_Ind_Org_TotalArea_Constructed", smodel.Ind_Org_TotalArea_Constructed);
            cmd.Parameters.AddWithValue("p_Ind_Org_OngoingProjects", smodel.Ind_Org_OngoingProjects);
            cmd.Parameters.AddWithValue("p_Ind_Org_AreaToBe_Constructed", smodel.Ind_Org_AreaToBe_Constructed);

            cmd.Parameters.AddWithValue("p_Flag", 1);
            cmd.Parameters.AddWithValue("p_Created_By", userName); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", userName); // smodel.Modify_By);
            cmd.Parameters.AddWithValue("p_Last_FiveYr_Exp", "NA");// smodel.Last_FiveYr_Exp);
            cmd.Parameters.AddWithValue("p_Ongoing_Exp", "NA"); // smodel.Ongoing_Exp);

            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", "NA");//smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_UID", UID);

            MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            
            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            return AppId;
             //if (i >= 1)
             //   return true;
             //else
             //    return false;
        }

        public  bool UpdateDetails(Clsprp_Promoter smodel, string update_photoaddress, string update_panaddress, string UID, string userName, string Image_FileName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter", con);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.AddWithValue("p_Application_id", smodel.Application_id); //smodel.Application_id);

            cmd.Parameters.AddWithValue("p_First_Name", smodel.First_Name);
            if (String.IsNullOrEmpty(smodel.Middle_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Middle_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Middle_Name", smodel.Middle_Name);

            }
            if (String.IsNullOrEmpty(smodel.Last_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Last_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Last_Name", smodel.Last_Name);

            }

            cmd.Parameters.AddWithValue("p_Fath_First_Name", smodel.Fath_First_Name);

            if (String.IsNullOrEmpty(smodel.Fath_Middle_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Fath_Middle_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Fath_Middle_Name", smodel.Fath_Middle_Name);

            }
            if (String.IsNullOrEmpty(smodel.Fath_Last_Name))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Fath_Last_Name", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Fath_Last_Name", smodel.Fath_Last_Name);

            }

            cmd.Parameters.AddWithValue("p_Occupation", String.IsNullOrEmpty(smodel.Occupation) ? "" : smodel.Occupation);//smodel.Occupation);
            cmd.Parameters.AddWithValue("p_Address_Line1", smodel.Address_Line1);
            if (String.IsNullOrEmpty(smodel.Address_Line2))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", smodel.Address_Line2);

            }
            cmd.Parameters.AddWithValue("p_State", smodel.State);
            cmd.Parameters.AddWithValue("p_District", smodel.District);
            cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);
            cmd.Parameters.AddWithValue("p_Mobile_no", smodel.Mobile_no);
            //cmd.Parameters.AddWithValue("p_Phone_No_STD", 0);
            if (smodel.Phone_No_STD == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No_STD", smodel.Phone_No_STD);

            }

            if (smodel.Phone_No == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No", smodel.Phone_No);

            }

            cmd.Parameters.AddWithValue("p_Email", smodel.Email);
            cmd.Parameters.AddWithValue("p_WebLink_Promoter_website", String.IsNullOrEmpty(smodel.WebLink_Promoter_website) ? "" : smodel.WebLink_Promoter_website);//smodel.WebLink_Promoter_website);
            cmd.Parameters.AddWithValue("p_Past_Exp_Punjab", smodel.Past_Exp_Punjab);
            cmd.Parameters.AddWithValue("p_Past_Exp_Other_States", smodel.Past_Exp_Other_States);
            cmd.Parameters.AddWithValue("p_PAN_No",  smodel.PAN_No);
            //cmd.Parameters.AddWithValue("p_PAN_Doc_Address", update_panaddress);//  smodel.PAN_Doc_Address);
            cmd.Parameters.AddWithValue("p_PAN_Doc_Address", "");// update_panaddress);//  smodel.PAN_Doc_Address);
            cmd.Parameters.AddWithValue("p_Image_FileName", Image_FileName);// smodel.Photo_Address);
            cmd.Parameters.AddWithValue("p_Photo_Address", update_photoaddress);// smodel.Photo_Address);
            cmd.Parameters.AddWithValue("p_aadhaar", smodel.Aadhaar);
            cmd.Parameters.AddWithValue("p_Experience", smodel.Experience);

            cmd.Parameters.AddWithValue("p_Org_Reg_Certificate", String.IsNullOrEmpty(smodel.Org_Reg_Certificate) ? "N" : smodel.Org_Reg_Certificate);

            cmd.Parameters.AddWithValue("p_Ind_Org_CompltdProj_FiveYrs", smodel.Ind_Org_CompltdProj_FiveYrs);
            cmd.Parameters.AddWithValue("p_Ind_Org_TotalArea_Constructed", smodel.Ind_Org_TotalArea_Constructed);
            cmd.Parameters.AddWithValue("p_Ind_Org_OngoingProjects", smodel.Ind_Org_OngoingProjects);
            cmd.Parameters.AddWithValue("p_Ind_Org_AreaToBe_Constructed", smodel.Ind_Org_AreaToBe_Constructed);

            cmd.Parameters.AddWithValue("p_Flag", 1);
            cmd.Parameters.AddWithValue("p_Created_By", userName); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", userName); // smodel.Modify_By);
            cmd.Parameters.AddWithValue("p_Last_FiveYr_Exp", "NA"); //smodel.Last_FiveYr_Exp);
            cmd.Parameters.AddWithValue("p_Ongoing_Exp", "NA"); //smodel.Ongoing_Exp);

            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", "NA");//smodel.IsLitigation_RelatedProject); smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_IsDraft", "1");

            cmd.Parameters.AddWithValue("p_UID", UID);

            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);


            
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

        public bool AlreadyExistPANcardnumber(string UserPAN)
        {
            connection();
            bool rval = false;
            string rvalcount = string.Empty;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_Promoter_AlreadyExistPANcardnumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserPAN", UserPAN);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                rvalcount = Convert.ToString(dr["UserPANcard"]);
            }

            if (String.IsNullOrEmpty(rvalcount))
            {
                rval = true;
            }
            cmd.Dispose();
            con.Close();
            return rval;
        }
    }
}