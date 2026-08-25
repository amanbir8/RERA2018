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
    public class ClsMethod_OrgMemDetail
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        /// <summary>
        /// Save Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool AddOrg_MemProject(ClsPrp_OrgMemDetail smodel, Int64 applicationid,String Photo_Address, String ext)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Promoter_OtherMemberDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Application_ID", applicationid);

            cmd.Parameters.AddWithValue("p_Designation", String.IsNullOrEmpty(smodel.Designation) ? "" : smodel.Designation);

            cmd.Parameters.AddWithValue("p_Member_Names", String.IsNullOrEmpty(smodel.Member_Names) ? "" : smodel.Member_Names);


            cmd.Parameters.AddWithValue("p_PAN_No", String.IsNullOrEmpty(smodel.PAN_No) ? "" : smodel.PAN_No);


            cmd.Parameters.AddWithValue("p_Aadhar_No", smodel.Aadhar_No);


            cmd.Parameters.AddWithValue("p_Address_Line1", String.IsNullOrEmpty(smodel.Address_Line1) ? "" : smodel.Address_Line1);

            if (String.IsNullOrEmpty(smodel.Address_Line2))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Address_Line2", String.IsNullOrEmpty(smodel.Address_Line2) ? "" : smodel.Address_Line2);

            }

            //cmd.Parameters.AddWithValue("p_Address_Line2", smodel.Address_Line2);

            cmd.Parameters.AddWithValue("p_State", String.IsNullOrEmpty(smodel.State) ? "" : smodel.State);


            cmd.Parameters.AddWithValue("p_District", String.IsNullOrEmpty(smodel.District) ? "" : smodel.District);

            if (smodel.Pin_Code == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Pin_Code", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);

            }

            if (smodel.Mobile_no == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Mobile_no", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Mobile_no", smodel.Mobile_no);

            }

            if (smodel.PhoneNumber_STD == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_STD);

            }

            if (smodel.Phone_No == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No", smodel.Phone_No);

            }
            cmd.Parameters.AddWithValue("p_Email", String.IsNullOrEmpty(smodel.Email) ? "" : smodel.Email);

            cmd.Parameters.AddWithValue("p_Image_FileName", String.IsNullOrEmpty(ext) ? "" : ext);

            cmd.Parameters.AddWithValue("p_Photo_Address", String.IsNullOrEmpty( Photo_Address) ? "" : Photo_Address);

            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_Created_By", "Created_By");// smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", "Modify_By");// smodel.Modify_By); 
            cmd.Parameters.AddWithValue("p_Flag", 2);
            //cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);


            con.Open();
            int i = cmd.ExecuteNonQuery();
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
        public bool Update_MemProject(ClsPrp_OrgMemDetail smodel)//, Int64 applicationid, Int64 Id, Int64? Promoter_OtherMemberDetails_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter_OtherMemberDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Id", smodel.Id);
            cmd.Parameters.AddWithValue("p_Application_id", smodel.Application_id);  
            cmd.Parameters.AddWithValue("p_Promoter_OtherMemberDetails_ID", smodel.Promoter_OtherMemberDetails_ID);// Promoter_OtherMemberDetails_ID);

            cmd.Parameters.AddWithValue("p_Designation", smodel.Designation);

            cmd.Parameters.AddWithValue("p_Member_Names", smodel.Member_Names);


            cmd.Parameters.AddWithValue("p_PAN_No", smodel.PAN_No);


            cmd.Parameters.AddWithValue("p_Aadhar_No", smodel.Aadhar_No);


            cmd.Parameters.AddWithValue("p_Address_Line1", String.IsNullOrEmpty(smodel.Address_Line1)?"": smodel.Address_Line1);

            //if (String.IsNullOrEmpty(smodel.Address_Line2))//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            //{
            //    cmd.Parameters.AddWithValue("p_Address_Line2", "");
            //}
            //else
            //{
            cmd.Parameters.AddWithValue("p_Address_Line2", String.IsNullOrEmpty(smodel.Address_Line2) ? "" : smodel.Address_Line2); 

            //}

            //cmd.Parameters.AddWithValue("p_Address_Line2", smodel.Address_Line2);

            cmd.Parameters.AddWithValue("p_State", smodel.State);



            cmd.Parameters.AddWithValue("p_District", smodel.District);

            //if (smodel.Pin_Code == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            //{
            //    cmd.Parameters.AddWithValue("p_Pin_Code", 0);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);

            //}
            cmd.Parameters.AddWithValue("p_Pin_Code", smodel.Pin_Code);
            //if (smodel.Mobile_no == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            //{
            //    cmd.Parameters.AddWithValue("p_Mobile_no", 0);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("p_Mobile_no", smodel.Mobile_no);

            //}

            cmd.Parameters.AddWithValue("p_Mobile_no", smodel.Mobile_no);
            if (smodel.PhoneNumber_STD == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_PhoneNumber_STD", smodel.PhoneNumber_STD);

            }


            if (smodel.Phone_No == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_Phone_No", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_Phone_No", smodel.Phone_No);

            }
            cmd.Parameters.AddWithValue("p_Email", String.IsNullOrEmpty(smodel.Email) ? "" : smodel.Email);

            cmd.Parameters.AddWithValue("p_Image_FileName", String.IsNullOrEmpty(smodel.Image_FileName) ? "" : smodel.Image_FileName);

            cmd.Parameters.AddWithValue("p_Photo_Address", String.IsNullOrEmpty(smodel.Photo_Address) ? "" : smodel.Photo_Address);

            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_Created_By", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", "Modify_By");
            cmd.Parameters.AddWithValue("p_Flag", 2);



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
        /// Display only
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_OrgMemDetail> Display_MemProject(Int64 applicationid)
        {
            connection();
            List<ClsPrp_OrgMemDetail> ProjectFivelist1 = new List<ClsPrp_OrgMemDetail>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_OtherMemberDetailsByApplicationID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", applicationid);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                    new ClsPrp_OrgMemDetail
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Promoter_OtherMemberDetails_ID = Convert.ToInt64(dr["Promoter_OtherMemberDetails_ID"]),
                        Application_id = Convert.ToInt64(dr["Application_id"]),


                        Designation = Convert.ToString(dr["Designation"]),
                        Member_Names = Convert.ToString(dr["Member_Names"]),
                        PAN_No = Convert.ToString(dr["PAN_No"]),
                        Aadhar_No = Convert.ToInt64(dr["Aadhar_No"]),
                        Address_Line1 = Convert.ToString(dr["Address_Line1"]),
                        Address_Line2 = Convert.ToString(dr["Address_Line2"]),
                        State = Convert.ToString(dr["State"]),
                        District = Convert.ToString(dr["District"]),
                        Pin_Code = Convert.ToInt64(dr["Pin_Code"]),
                        Mobile_no = Convert.ToInt64(dr["Mobile_no"]),
                         PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        Phone_No = Convert.ToInt64(dr["Phone_No"]),
                        Email = Convert.ToString(dr["Email"]),
                        Image_FileName= Convert.ToString(dr["Image_FileName"]),
                        Photo_Address = Convert.ToString(dr["Photo_Address"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["Created_On"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        ModifyOn = Convert.ToDateTime(dr["Modified_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),


                    });
            }
            return ProjectFivelist1;
        }
        /// <summary>
        /// Display method by application, id
        /// </summary>
        /// <param name="Application_id"></param>
        /// /// <param name="id"></param>
        /// <returns></returns>
        public List<ClsPrp_OrgMemDetail> DisplaybyID_MemProject(Int64 Application_id, Int64 Id)
        {
            List<ClsPrp_OrgMemDetail> ProjectFivelist = new List<ClsPrp_OrgMemDetail>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_OtherMemberDetailsByApplicationIDandID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            cmd.Parameters.AddWithValue("p_id", Id);
            connection();
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_OrgMemDetail clspro = new ClsPrp_OrgMemDetail();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                   new ClsPrp_OrgMemDetail
                   {
                       Id = Convert.ToInt32(dr["Id"]),
                       Application_id = Convert.ToInt64(dr["Application_id"]),


                       Promoter_OtherMemberDetails_ID = Convert.ToInt64(dr["Promoter_OtherMemberDetails_ID"]),

                       Designation = Convert.ToString(dr["Designation"]),
                       Member_Names = Convert.ToString(dr["Member_Names"]),
                       PAN_No = Convert.ToString(dr["PAN_No"]),

                       Aadhar_No = Convert.ToInt64(dr["Aadhar_No"]),
                       Address_Line1 = Convert.ToString(dr["Address_Line1"]),
                       Address_Line2 = Convert.ToString(dr["Address_Line2"]),

                       State = Convert.ToString(dr["State"]),
                       District = Convert.ToString(dr["District"]),
                       Pin_Code = Convert.ToInt64(dr["Pin_Code"]),

                       PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                       Mobile_no = Convert.ToInt64(dr["Mobile_no"]),
                       Phone_No = Convert.ToInt64(dr["Phone_No"]),
                       Email = Convert.ToString(dr["Email"]),
                       Photo_Address = Convert.ToString(dr["Photo_Address"]),
                       Image_FileName = Convert.ToString(dr["Image_FileName"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       CreatedOn = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       ModifyOn = Convert.ToDateTime(dr["Modified_On"]),
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
        public bool Delete_MemProject(Int64 Application_id, Int64 Id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Promoter_OrgMem_Detail", con);
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


    }
}