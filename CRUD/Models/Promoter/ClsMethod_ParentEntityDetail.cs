using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUD.Models.Promoter;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_ParentEntityDetail
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
        public bool AddParent_EntityMember(ClsPrp_ParentEntityDetail smodel,Int64 Application_ID, String Photo_Address, String ext)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Promoter_ParentEntity", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Application_ID",  Application_ID);
            cmd.Parameters.AddWithValue("p_Promoter_IsPastExperience", "NA");// String.IsNullOrEmpty(smodel.Promoter_IsPastExperience) ? "" : smodel.Promoter_IsPastExperience);

            cmd.Parameters.AddWithValue("p_NameofParentEntity", String.IsNullOrEmpty(smodel.Name_of_Parent_Entity) ? "" : smodel.Name_of_Parent_Entity);


            cmd.Parameters.AddWithValue("p_TypeofEnterprise", String.IsNullOrEmpty(smodel.Type_of_Enterprise) ? "" : smodel.Type_of_Enterprise);


            cmd.Parameters.AddWithValue("p_MainObjectsofParentEntity", String.IsNullOrEmpty(smodel.Main_Objects_of_Parent_Entity) ? "" : smodel.Main_Objects_of_Parent_Entity);

            
            cmd.Parameters.AddWithValue("p_RegisteredAddress", String.IsNullOrEmpty(smodel.RegisteredAddress) ? "" : smodel.RegisteredAddress);

          

             cmd.Parameters.AddWithValue("p_Address_Line2", String.IsNullOrEmpty(smodel.Address_Line2) ? "" : smodel.Address_Line2);

            cmd.Parameters.AddWithValue("p_State", String.IsNullOrEmpty(smodel.State) ? "" : smodel.State);



            cmd.Parameters.AddWithValue("p_District", String.IsNullOrEmpty(smodel.District) ? "" : smodel.District);

            //if (smodel.Pin_Code== 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            //{
            //    cmd.Parameters.AddWithValue("p_Pin_Code", 0);
            //}
            //else
            //{
                cmd.Parameters.AddWithValue("p_PinCode", smodel.Pin_Code);

            //}

            if (smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab == 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestatePunjab", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestatePunjab", smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab);

            }



            if (smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State== null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestateUTState", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestateUTState", smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State);

            }
            cmd.Parameters.AddWithValue("p_UploadCompanyRegistrationCertificateofParentEntity", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);// String.IsNullOrEmpty(smodel.Upload_Company_Registration_Certificate_of_Parent_Entity) ? "" : smodel.Upload_Company_Registration_Certificate_of_Parent_Entity);

            
            cmd.Parameters.AddWithValue("p_CompanyRegCert_Image_FileName", String.IsNullOrEmpty(ext) ? "" : ext);// String.IsNullOrEmpty(smodel.CompanyRegCert_Image_FileName) ? "" : smodel.CompanyRegCert_Image_FileName);

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
        public bool UpdateParent_EntityMember(ClsPrp_ParentEntityDetail smodel)
        { 
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter_ParentEntity", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Id", smodel.ID);
            cmd.Parameters.AddWithValue("p_Application_id", smodel.Application_ID);

            cmd.Parameters.AddWithValue("p_Promoter_IsPastExperience", "NA");// String.IsNullOrEmpty(smodel.Promoter_IsPastExperience) ? "" : smodel.Promoter_IsPastExperience);
            cmd.Parameters.AddWithValue("p_PromoterParentEntity_ID", smodel.PromoterParentEntity_ID);

            cmd.Parameters.AddWithValue("p_NameofParentEntity", String.IsNullOrEmpty(smodel.Name_of_Parent_Entity) ? "" : smodel.Name_of_Parent_Entity);


            cmd.Parameters.AddWithValue("p_TypeofEnterprise", String.IsNullOrEmpty(smodel.Type_of_Enterprise) ? "" : smodel.Type_of_Enterprise);


            cmd.Parameters.AddWithValue("p_MainObjectsofParentEntity", String.IsNullOrEmpty(smodel.Main_Objects_of_Parent_Entity) ? "" : smodel.Main_Objects_of_Parent_Entity);


            cmd.Parameters.AddWithValue("p_RegisteredAddress", String.IsNullOrEmpty(smodel.RegisteredAddress) ? "" : smodel.RegisteredAddress);



            cmd.Parameters.AddWithValue("p_Address_Line2", String.IsNullOrEmpty(smodel.Address_Line2) ? "" : smodel.Address_Line2);

            cmd.Parameters.AddWithValue("p_State", String.IsNullOrEmpty(smodel.State) ? "" : smodel.State);



            cmd.Parameters.AddWithValue("p_District", String.IsNullOrEmpty(smodel.District) ? "" : smodel.District);

            //if (smodel.Pin_Code== 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            //{
            //    cmd.Parameters.AddWithValue("p_Pin_Code", 0);
            //}
            //else
            //{
            cmd.Parameters.AddWithValue("p_PinCode", smodel.Pin_Code);

            //}

            if (smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab == 0)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestatePunjab", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestatePunjab", smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab);

            }



            if (smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State == null)//||(smodel.Org_New_Incorp_Address_Line2.Trim() == string.Empty)|| (smodel.Org_New_Incorp_Address_Line2.Trim() == "") )// how employee releated to IMT Employee
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestateUTState", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("p_NumberofyearsofexperienceoftheParentEntityinrealestateUTState", smodel.Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State);

            }
            cmd.Parameters.AddWithValue("p_UploadCompanyRegistrationCertificateofParentEntity", String.IsNullOrEmpty(smodel.Upload_Company_Registration_Certificate_of_Parent_Entity) ? "" : smodel.Upload_Company_Registration_Certificate_of_Parent_Entity);


            cmd.Parameters.AddWithValue("p_CompanyRegCert_Image_FileName", String.IsNullOrEmpty(smodel.CompanyRegCert_Image_FileName) ? "" : smodel.CompanyRegCert_Image_FileName);

            cmd.Parameters.AddWithValue("p_IsDraft", 0);


            cmd.Parameters.AddWithValue("p_Created_By", "Created_By");// smodel.Created_By);
            cmd.Parameters.AddWithValue("p_Modify_By", "Modify_By");// smodel.Modify_By); 
            cmd.Parameters.AddWithValue("p_Flag", 2);
            //cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);

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
        /// Display method by application id 
        /// </summary>
        /// <param name="Application_id"></param>
        /// <returns></returns>
        public List<ClsPrp_ParentEntityDetail> DisplayDetailByApplicationID(Int64 Application_id)
        {
            List<ClsPrp_ParentEntityDetail> ParentEntityDetail = new List<ClsPrp_ParentEntityDetail>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_ParentEntityByApplicationID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_ParentEntityDetail clspro = new ClsPrp_ParentEntityDetail();

            foreach (DataRow dr in dt.Rows)
            {
                ParentEntityDetail.Add(
                   new ClsPrp_ParentEntityDetail
                   {
                       ID = Convert.ToInt32(dr["Id"]),
                       PromoterParentEntity_ID = Convert.ToInt64(dr["PromoterParentEntity_ID"]),
                       Application_ID = Convert.ToInt64(dr["Application_id"]),

                       Promoter_IsPastExperience = Convert.ToString(dr["Promoter_IsPastExperience"]),
                       Name_of_Parent_Entity = Convert.ToString(dr["NameofParentEntity"]),
                       Type_of_Enterprise = Convert.ToString(dr["TypeofEnterprise"]),
                       Main_Objects_of_Parent_Entity = Convert.ToString(dr["MainObjectsofParentEntity"]),
                       RegisteredAddress = Convert.ToString(dr["RegisteredAddress"]),
                       Address_Line2 = Convert.ToString(dr["Address_Line2"]),

                       
                       State = Convert.ToString(dr["State"]),
                       District = Convert.ToString(dr["District"]),
                       Pin_Code = Convert.ToInt64(dr["Pin_Code"]),
                       Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab = Convert.ToInt32(dr["NumberofyearsofexperienceoftheParentEntityinrealestatePunjab"]),
                       Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State = Convert.ToInt32(dr["NumberofyearsofexperienceoftheParentEntityinrealestateUTState"]),
                       Upload_Company_Registration_Certificate_of_Parent_Entity = Convert.ToString(dr["UploadCompanyRegistrationCertificateofParentEntity"]),
                       CompanyRegCert_Image_FileName = Convert.ToString(dr["CompanyRegCert_Image_FileName"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       CreatedOn = Convert.ToDateTime(dr["Created_On"]),
                       CreatedBy = Convert.ToString(dr["Created_By"]),
                       ModifyOn = Convert.ToDateTime(dr["Modified_On"]),
                       ModifyBy = Convert.ToString(dr["Modify_By"]),                      

                   });


            }
            //clspro.prpongoing= ProjectFivelist
            return ParentEntityDetail;

        }


        /// <summary>
        /// Display method by application id and ID
        /// </summary>
        /// <param name="Application_id"></param>
        /// <returns></returns>
        public List<ClsPrp_ParentEntityDetail> DisplayDetailByIDApplicationID(Int64 Application_id, Int64 Id)
        {
            List<ClsPrp_ParentEntityDetail> ParentEntityDetail = new List<ClsPrp_ParentEntityDetail>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_ParentEntityByApplicationIDandID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            cmd.Parameters.AddWithValue("p_id", Id);
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_ParentEntityDetail clspro = new ClsPrp_ParentEntityDetail();

            foreach (DataRow dr in dt.Rows)
            {
                ParentEntityDetail.Add(
                   new ClsPrp_ParentEntityDetail
                   {
                       ID = Convert.ToInt32(dr["Id"]),
                       PromoterParentEntity_ID = Convert.ToInt64(dr["PromoterParentEntity_ID"]),
                       Application_ID = Convert.ToInt64(dr["Application_id"]),

                       Promoter_IsPastExperience = Convert.ToString(dr["Promoter_IsPastExperience"]),
                       Name_of_Parent_Entity = Convert.ToString(dr["NameofParentEntity"]),
                       Type_of_Enterprise = Convert.ToString(dr["TypeofEnterprise"]),
                       Main_Objects_of_Parent_Entity = Convert.ToString(dr["MainObjectsofParentEntity"]),
                       RegisteredAddress = Convert.ToString(dr["RegisteredAddress"]),
                       Address_Line2 = Convert.ToString(dr["Address_Line2"]),


                       State = Convert.ToString(dr["State"]),
                       District = Convert.ToString(dr["District"]),
                       Pin_Code = Convert.ToInt64(dr["Pin_Code"]),
                       Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab = Convert.ToInt32(dr["NumberofyearsofexperienceoftheParentEntityinrealestatePunjab"]),
                       Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State = Convert.ToInt32(dr["NumberofyearsofexperienceoftheParentEntityinrealestateUTState"]),
                       Upload_Company_Registration_Certificate_of_Parent_Entity = Convert.ToString(dr["UploadCompanyRegistrationCertificateofParentEntity"]),
                       CompanyRegCert_Image_FileName = Convert.ToString(dr["CompanyRegCert_Image_FileName"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       CreatedOn = Convert.ToDateTime(dr["Created_On"]),
                       CreatedBy = Convert.ToString(dr["Created_By"]),
                       ModifyOn = Convert.ToDateTime(dr["Modified_On"]),
                       ModifyBy = Convert.ToString(dr["Modify_By"]),
                   });
                

            }
            //clspro.prpongoing= ProjectFivelist
            return ParentEntityDetail;

             }
       
        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="Application_id"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete_ParentEntityDetail(Int64 Application_ID, Int64 ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Promoter_ParentEntity", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Application_id", Application_ID);

            cmd.Parameters.AddWithValue("p_id", ID);
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