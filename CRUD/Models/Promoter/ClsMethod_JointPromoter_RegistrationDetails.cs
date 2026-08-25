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
    public class ClsMethod_JointPromoter_RegistrationDetail
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_JointPromoter_RegistrationDetail(ClsPrp_JointPromoter_RegistrationDetails smodel, Int64 applicationid, Int32 applicationtype, string Photo_Address, string Photo_Path, string userName, string userID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_Rera_JointPromoter_RegistrationDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // CoPromoter Registration Parms - START
            cmd.Parameters.AddWithValue("p_CoPromoter_IndexID", smodel.CoPromoter_IndexID);
            cmd.Parameters.AddWithValue("p_CoPromoter_ApplicationID", smodel.CoPromoter_ApplicationID);
            cmd.Parameters.AddWithValue("p_CoPromoterType_Flag", smodel.CoPromoterType_Flag);

            //OTI Case
            cmd.Parameters.AddWithValue("p_Org_Title", string.IsNullOrEmpty(smodel.Org_Title) ? "" : smodel.Org_Title);
            cmd.Parameters.AddWithValue("p_Org_Name", string.IsNullOrEmpty(smodel.Org_Name) ? "" : smodel.Org_Name);
            cmd.Parameters.AddWithValue("p_Org_Type", string.IsNullOrEmpty(smodel.Org_Type) ? "" : smodel.Org_Type);
            cmd.Parameters.AddWithValue("p_OTI_Org_Objects", string.IsNullOrEmpty(smodel.OTI_Org_Objects) ? "" : smodel.OTI_Org_Objects);

            //IND Case
            cmd.Parameters.AddWithValue("p_First_Name", string.IsNullOrEmpty(smodel.First_Name) ? "" : smodel.First_Name);
            cmd.Parameters.AddWithValue("p_Middle_Name", string.IsNullOrEmpty(smodel.Middle_Name) ? "" : smodel.Middle_Name);
            cmd.Parameters.AddWithValue("p_Last_Name", string.IsNullOrEmpty(smodel.Last_Name) ? "" : smodel.Last_Name);
            cmd.Parameters.AddWithValue("p_Individual_Gender", smodel.Individual_Gender);

            cmd.Parameters.AddWithValue("p_Fath_First_Name", string.IsNullOrEmpty(smodel.Fath_First_Name) ? "" : smodel.Fath_First_Name);
            cmd.Parameters.AddWithValue("p_Fath_Middle_Name", string.IsNullOrEmpty(smodel.Fath_Middle_Name) ? "" : smodel.Fath_Middle_Name);
            cmd.Parameters.AddWithValue("p_Fath_Last_Name", string.IsNullOrEmpty(smodel.Fath_Last_Name) ? "" : smodel.Fath_Last_Name);
            cmd.Parameters.AddWithValue("p_Ind_Org_Objects", string.IsNullOrEmpty(smodel.Ind_Org_Objects) ? "" : smodel.Ind_Org_Objects);

            //Registered Address        
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_Line1", string.IsNullOrEmpty(smodel.Registered_Address_Org_Line1) ? "" : smodel.Registered_Address_Org_Line1);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_Line2", string.IsNullOrEmpty(smodel.Registered_Address_Org_Line2) ? "" : smodel.Registered_Address_Org_Line2);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_State", smodel.Registered_Address_Org_State);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_District", smodel.Registered_Address_Org_District);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_Pin_Code", string.IsNullOrEmpty(smodel.Registered_Address_Org_Pin_Code) ? "" : smodel.Registered_Address_Org_Pin_Code);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_DistrictState_Name", string.IsNullOrEmpty(smodel.Registered_Address_Org_DistrictState_Name) ? "" : smodel.Registered_Address_Org_DistrictState_Name);

            //Permanent Address
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_Line1", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_Line1) ? "" : smodel.Permanent_Address_Prm_Line1);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_Line2", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_Line2) ? "" : smodel.Permanent_Address_Prm_Line2);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_State", smodel.Permanent_Address_Prm_State);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_District", smodel.Permanent_Address_Prm_District);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_Pin_Code", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_Pin_Code) ? "" : smodel.Permanent_Address_Prm_Pin_Code);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_DistrictState_Name", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_DistrictState_Name) ? "" : smodel.Permanent_Address_Prm_DistrictState_Name);

            //Communication Address        
            cmd.Parameters.AddWithValue("p_Communication_AddressLine1", string.IsNullOrEmpty(smodel.Communication_AddressLine1) ? "" : smodel.Communication_AddressLine1);
            cmd.Parameters.AddWithValue("p_Communication_AddressLine2", string.IsNullOrEmpty(smodel.Communication_AddressLine2) ? "" : smodel.Communication_AddressLine2);
            cmd.Parameters.AddWithValue("p_Communication_AddressStateCode", smodel.Communication_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Communication_AddressDistrictCode", smodel.Communication_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Communication_AddressPIN", string.IsNullOrEmpty(smodel.Communication_AddressPIN) ? "" : smodel.Communication_AddressPIN);
            cmd.Parameters.AddWithValue("p_Communication_Address_DistrictState_Name", string.IsNullOrEmpty(smodel.Communication_Address_DistrictState_Name) ? "" : smodel.Communication_Address_DistrictState_Name);

            //Authorized Person details        
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Name", string.IsNullOrEmpty(smodel.AuthorizedPerson_Name) ? "" : smodel.AuthorizedPerson_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_MobileNumber", smodel.AuthorizedPerson_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LandlineNumber_STD", smodel.AuthorizedPerson_LandlineNumber_STD);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LandlineNumber", smodel.AuthorizedPerson_LandlineNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_EmailAddress", string.IsNullOrEmpty(smodel.AuthorizedPerson_EmailAddress) ? "" : smodel.AuthorizedPerson_EmailAddress);

            //Authorized Person Address        
            cmd.Parameters.AddWithValue("p_IsAuthorizedPersonAddress", smodel.IsAuthorizedPersonAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine1) ? "" : smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? "" : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressStateCode", smodel.AuthorizedPerson_AddressStateCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressDistrictCode", smodel.AuthorizedPerson_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressPIN", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressPIN) ? "" : smodel.AuthorizedPerson_AddressPIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressDistrictState_Name", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressDistrictState_Name) ? "" : smodel.AuthorizedPerson_AddressDistrictState_Name);

            //Other Parms        
            cmd.Parameters.AddWithValue("p_CoPromoter_Occupation", string.IsNullOrEmpty(smodel.CoPromoter_Occupation) ? "" : smodel.CoPromoter_Occupation);
            cmd.Parameters.AddWithValue("p_CoPromoter_WebLink", string.IsNullOrEmpty(smodel.CoPromoter_WebLink) ? "" : smodel.CoPromoter_WebLink);
            cmd.Parameters.AddWithValue("p_CoPromoter_PAN_Number", string.IsNullOrEmpty(smodel.CoPromoter_PAN_Number) ? "" : smodel.CoPromoter_PAN_Number);
            cmd.Parameters.AddWithValue("p_CoPromoter_Aadhaar_Number", smodel.CoPromoter_Aadhaar_Number);

            cmd.Parameters.AddWithValue("p_IsExperience", string.IsNullOrEmpty(smodel.IsExperience) ? "" : smodel.IsExperience);
            cmd.Parameters.AddWithValue("p_Past_Experience_InYear", smodel.Past_Experience_InYear);
            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", string.IsNullOrEmpty(smodel.IsLitigation_RelatedProject) ? "" : smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_Past_Litigations_InNumber", smodel.Past_Litigations_InNumber);
            cmd.Parameters.AddWithValue("p_IsOrganizationMembers", string.IsNullOrEmpty(smodel.IsOrganizationMembers) ? "" : smodel.IsOrganizationMembers);
            cmd.Parameters.AddWithValue("p_IsOrganizationParent_Entity", string.IsNullOrEmpty(smodel.IsOrganizationParent_Entity) ? "" : smodel.IsOrganizationParent_Entity);

            cmd.Parameters.AddWithValue("p_IsUploadPhotograph", smodel.IsUploadPhotograph);
            cmd.Parameters.AddWithValue("p_CoPromoterImage_FilePath", Photo_Path);
            cmd.Parameters.AddWithValue("p_CoPromoterImage_FileName", Photo_Address);

            //Dropdown value - Related_ProjectID - START
            cmd.Parameters.AddWithValue("p_Related_Project_ID", smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_Related_Used_ID", userID); //Related Reference ID
            cmd.Parameters.AddWithValue("p_Related_Promoter_Application_ID", applicationid); //Related Reference ID

            //Another Primary Promoter ID
            cmd.Parameters.AddWithValue("p_Link_RegDiaryNumber_ID", smodel.Link_RegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_Link_RegDiaryNumber_Name", string.IsNullOrEmpty(smodel.Link_RegDiaryNumber_Name) ? "" : smodel.Link_RegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Link_RegDiaryNumber_NameYear", string.IsNullOrEmpty(smodel.Link_RegDiaryNumber_NameYear) ? "" : smodel.Link_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_Column_A", string.IsNullOrEmpty(smodel.Column_A) ? "" : smodel.Column_A);
            cmd.Parameters.AddWithValue("p_Column_B", string.IsNullOrEmpty(smodel.Column_B) ? "" : smodel.Column_B);
            //END

            cmd.Parameters.AddWithValue("p_RemarksIfAny", string.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Column_C", string.IsNullOrEmpty(smodel.Column_C) ? "" : smodel.Column_C);
            cmd.Parameters.AddWithValue("p_Column_D", string.IsNullOrEmpty(smodel.Column_D) ? "" : smodel.Column_D);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 1);
            cmd.Parameters.AddWithValue("p_Created_By", userName);
            cmd.Parameters.AddWithValue("p_Created_On", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Modify_By", userName);
            cmd.Parameters.AddWithValue("p_Modified_On", DateTime.Now);
            // CoPromoter Registration Parms

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_JointPromoter_RegistrationDetail(ClsPrp_JointPromoter_RegistrationDetails smodel, string userName, string userID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_JointPromoter_RegistrationDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // CoPromoter Registration Parms - START
            cmd.Parameters.AddWithValue("p_CoPromoter_IndexID", smodel.CoPromoter_IndexID);
            cmd.Parameters.AddWithValue("p_CoPromoter_ApplicationID", smodel.CoPromoter_ApplicationID);
            cmd.Parameters.AddWithValue("p_CoPromoterType_Flag", smodel.CoPromoterType_Flag);

            //OTI Case
            cmd.Parameters.AddWithValue("p_Org_Title", string.IsNullOrEmpty(smodel.Org_Title) ? "" : smodel.Org_Title);
            cmd.Parameters.AddWithValue("p_Org_Name", string.IsNullOrEmpty(smodel.Org_Name) ? "" : smodel.Org_Name);
            cmd.Parameters.AddWithValue("p_Org_Type", string.IsNullOrEmpty(smodel.Org_Type) ? "" : smodel.Org_Type);
            cmd.Parameters.AddWithValue("p_OTI_Org_Objects", string.IsNullOrEmpty(smodel.OTI_Org_Objects) ? "" : smodel.OTI_Org_Objects);

            //IND Case
            cmd.Parameters.AddWithValue("p_First_Name", string.IsNullOrEmpty(smodel.First_Name) ? "" : smodel.First_Name);
            cmd.Parameters.AddWithValue("p_Middle_Name", string.IsNullOrEmpty(smodel.Middle_Name) ? "" : smodel.Middle_Name);
            cmd.Parameters.AddWithValue("p_Last_Name", string.IsNullOrEmpty(smodel.Last_Name) ? "" : smodel.Last_Name);
            cmd.Parameters.AddWithValue("p_Individual_Gender", smodel.Individual_Gender);

            cmd.Parameters.AddWithValue("p_Fath_First_Name", string.IsNullOrEmpty(smodel.Fath_First_Name) ? "" : smodel.Fath_First_Name);
            cmd.Parameters.AddWithValue("p_Fath_Middle_Name", string.IsNullOrEmpty(smodel.Fath_Middle_Name) ? "" : smodel.Fath_Middle_Name);
            cmd.Parameters.AddWithValue("p_Fath_Last_Name", string.IsNullOrEmpty(smodel.Fath_Last_Name) ? "" : smodel.Fath_Last_Name);
            cmd.Parameters.AddWithValue("p_Ind_Org_Objects", string.IsNullOrEmpty(smodel.Ind_Org_Objects) ? "" : smodel.Ind_Org_Objects);

            //Registered Address        
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_Line1", string.IsNullOrEmpty(smodel.Registered_Address_Org_Line1) ? "" : smodel.Registered_Address_Org_Line1);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_Line2", string.IsNullOrEmpty(smodel.Registered_Address_Org_Line2) ? "" : smodel.Registered_Address_Org_Line2);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_State", smodel.Registered_Address_Org_State);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_District", smodel.Registered_Address_Org_District);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_Pin_Code", string.IsNullOrEmpty(smodel.Registered_Address_Org_Pin_Code) ? "" : smodel.Registered_Address_Org_Pin_Code);
            cmd.Parameters.AddWithValue("p_Registered_Address_Org_DistrictState_Name", string.IsNullOrEmpty(smodel.Registered_Address_Org_DistrictState_Name) ? "" : smodel.Registered_Address_Org_DistrictState_Name);

            //Permanent Address
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_Line1", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_Line1) ? "" : smodel.Permanent_Address_Prm_Line1);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_Line2", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_Line2) ? "" : smodel.Permanent_Address_Prm_Line2);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_State", smodel.Permanent_Address_Prm_State);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_District", smodel.Permanent_Address_Prm_District);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_Pin_Code", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_Pin_Code) ? "" : smodel.Permanent_Address_Prm_Pin_Code);
            cmd.Parameters.AddWithValue("p_Permanent_Address_Prm_DistrictState_Name", string.IsNullOrEmpty(smodel.Permanent_Address_Prm_DistrictState_Name) ? "" : smodel.Permanent_Address_Prm_DistrictState_Name);

            //Communication Address        
            cmd.Parameters.AddWithValue("p_Communication_AddressLine1", string.IsNullOrEmpty(smodel.Communication_AddressLine1) ? "" : smodel.Communication_AddressLine1);
            cmd.Parameters.AddWithValue("p_Communication_AddressLine2", string.IsNullOrEmpty(smodel.Communication_AddressLine2) ? "" : smodel.Communication_AddressLine2);
            cmd.Parameters.AddWithValue("p_Communication_AddressStateCode", smodel.Communication_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Communication_AddressDistrictCode", smodel.Communication_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Communication_AddressPIN", string.IsNullOrEmpty(smodel.Communication_AddressPIN) ? "" : smodel.Communication_AddressPIN);
            cmd.Parameters.AddWithValue("p_Communication_Address_DistrictState_Name", string.IsNullOrEmpty(smodel.Communication_Address_DistrictState_Name) ? "" : smodel.Communication_Address_DistrictState_Name);

            //Authorized Person details        
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Name", string.IsNullOrEmpty(smodel.AuthorizedPerson_Name) ? "" : smodel.AuthorizedPerson_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_MobileNumber", smodel.AuthorizedPerson_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LandlineNumber_STD", smodel.AuthorizedPerson_LandlineNumber_STD);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LandlineNumber", smodel.AuthorizedPerson_LandlineNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_EmailAddress", string.IsNullOrEmpty(smodel.AuthorizedPerson_EmailAddress) ? "" : smodel.AuthorizedPerson_EmailAddress);

            //Authorized Person Address        
            cmd.Parameters.AddWithValue("p_IsAuthorizedPersonAddress", smodel.IsAuthorizedPersonAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine1) ? "" : smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? "" : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressStateCode", smodel.AuthorizedPerson_AddressStateCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressDistrictCode", smodel.AuthorizedPerson_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressPIN", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressPIN) ? "" : smodel.AuthorizedPerson_AddressPIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressDistrictState_Name", string.IsNullOrEmpty(smodel.AuthorizedPerson_AddressDistrictState_Name) ? "" : smodel.AuthorizedPerson_AddressDistrictState_Name);

            //Other Parms        
            cmd.Parameters.AddWithValue("p_CoPromoter_Occupation", string.IsNullOrEmpty(smodel.CoPromoter_Occupation) ? "" : smodel.CoPromoter_Occupation);
            cmd.Parameters.AddWithValue("p_CoPromoter_WebLink", string.IsNullOrEmpty(smodel.CoPromoter_WebLink) ? "" : smodel.CoPromoter_WebLink);
            cmd.Parameters.AddWithValue("p_CoPromoter_PAN_Number", string.IsNullOrEmpty(smodel.CoPromoter_PAN_Number) ? "" : smodel.CoPromoter_PAN_Number);
            cmd.Parameters.AddWithValue("p_CoPromoter_Aadhaar_Number", smodel.CoPromoter_Aadhaar_Number);

            cmd.Parameters.AddWithValue("p_IsExperience", string.IsNullOrEmpty(smodel.IsExperience) ? "" : smodel.IsExperience);
            cmd.Parameters.AddWithValue("p_Past_Experience_InYear", smodel.Past_Experience_InYear);
            cmd.Parameters.AddWithValue("p_IsLitigation_RelatedProject", string.IsNullOrEmpty(smodel.IsLitigation_RelatedProject) ? "" : smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_Past_Litigations_InNumber", smodel.Past_Litigations_InNumber);
            cmd.Parameters.AddWithValue("p_IsOrganizationMembers", string.IsNullOrEmpty(smodel.IsOrganizationMembers) ? "" : smodel.IsOrganizationMembers);
            cmd.Parameters.AddWithValue("p_IsOrganizationParent_Entity", string.IsNullOrEmpty(smodel.IsOrganizationParent_Entity) ? "" : smodel.IsOrganizationParent_Entity);

            cmd.Parameters.AddWithValue("p_IsUploadPhotograph", smodel.IsUploadPhotograph);
            cmd.Parameters.AddWithValue("p_CoPromoterImage_FilePath", string.IsNullOrEmpty(smodel.CoPromoterImage_FilePath) ? "" : smodel.CoPromoterImage_FilePath);
            cmd.Parameters.AddWithValue("p_CoPromoterImage_FileName", string.IsNullOrEmpty(smodel.CoPromoterImage_FileName) ? "" : smodel.CoPromoterImage_FileName);

            //Dropdown value - Related_ProjectID - START
            cmd.Parameters.AddWithValue("p_Related_Project_ID", smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_Related_Used_ID", userID); //Related Reference ID
            cmd.Parameters.AddWithValue("p_Related_Promoter_Application_ID", smodel.Related_Promoter_Application_ID); //Related Reference ID

            //Another Primary Promoter ID
            cmd.Parameters.AddWithValue("p_Link_RegDiaryNumber_ID", smodel.Link_RegDiaryNumber_ID); //(smodel.Link_RegDiaryNumber_ID == null) ? 0 : smodel.Link_RegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_Link_RegDiaryNumber_Name", string.IsNullOrEmpty(smodel.Link_RegDiaryNumber_Name) ? "" : smodel.Link_RegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Link_RegDiaryNumber_NameYear", string.IsNullOrEmpty(smodel.Link_RegDiaryNumber_NameYear) ? "" : smodel.Link_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_Column_A", string.IsNullOrEmpty(smodel.Column_A) ? "" : smodel.Column_A);
            cmd.Parameters.AddWithValue("p_Column_B", string.IsNullOrEmpty(smodel.Column_B) ? "" : smodel.Column_B);
            //END

            cmd.Parameters.AddWithValue("p_RemarksIfAny", string.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Column_C", string.IsNullOrEmpty(smodel.Column_C) ? "" : smodel.Column_C);
            cmd.Parameters.AddWithValue("p_Column_D", string.IsNullOrEmpty(smodel.Column_D) ? "" : smodel.Column_D);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 1);
            cmd.Parameters.AddWithValue("p_Created_By", userName);
            cmd.Parameters.AddWithValue("p_Created_On", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Modify_By", userName);
            cmd.Parameters.AddWithValue("p_Modified_On", DateTime.Now);
            // CoPromoter Registration Parms

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

        public List<ClsPrp_JointPromoter_RegistrationDetails> Display_JointPromoter_RegistrationsByID(Int64 PromoterID, Int32 PromoterType, Int32 Flag, string UserRole, string UserID)
        {
            connection();
            List<ClsPrp_JointPromoter_RegistrationDetails> PromoterList = new List<ClsPrp_JointPromoter_RegistrationDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_RegistrationDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_PromoterType", PromoterType);
            cmd.Parameters.AddWithValue("p_Flag", Flag);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterList.Add(
                    new ClsPrp_JointPromoter_RegistrationDetails
                    {
                        CoPromoter_IndexID = Convert.ToInt64(dr["CoPromoter_IndexID"]),
                        CoPromoter_ApplicationID = Convert.ToInt64(dr["CoPromoter_ApplicationID"]),
                        CoPromoterType_Flag = Convert.ToInt32(dr["CoPromoterType_Flag"]),

                        //OTI Case
                        Org_Title = Convert.ToString(dr["Org_Title"]),
                        Org_Name = Convert.ToString(dr["Org_Name"]),
                        Org_Type = Convert.ToString(dr["Org_Type"]),
                        OTI_Org_Objects = Convert.ToString(dr["OTI_Org_Objects"]),

                        //IND Case
                        First_Name = Convert.ToString(dr["First_Name"]),
                        Middle_Name = Convert.ToString(dr["Middle_Name"]),
                        Last_Name = Convert.ToString(dr["Last_Name"]),
                        Individual_Gender = Convert.ToString(dr["Individual_Gender"]),
                        Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]),
                        Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]),
                        Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]),
                        Ind_Org_Objects = Convert.ToString(dr["Ind_Org_Objects"]),

                        //Registered Address
                        Registered_Address_Org_Line1 = Convert.ToString(dr["Registered_Address_Org_Line1"]),
                        Registered_Address_Org_Line2 = Convert.ToString(dr["Registered_Address_Org_Line2"]),
                        Registered_Address_Org_State = Convert.ToInt32(dr["Registered_Address_Org_State"]),
                        Registered_Address_Org_District = Convert.ToInt32(dr["Registered_Address_Org_District"]),
                        Registered_Address_Org_Pin_Code = Convert.ToString(dr["Registered_Address_Org_Pin_Code"]),
                        Registered_Address_Org_DistrictState_Name = Convert.ToString(dr["Registered_Address_Org_DistrictState_Name"]),

                        //Permanent Address
                        Permanent_Address_Prm_Line1 = Convert.ToString(dr["Permanent_Address_Prm_Line1"]),
                        Permanent_Address_Prm_Line2 = Convert.ToString(dr["Permanent_Address_Prm_Line2"]),
                        Permanent_Address_Prm_State = Convert.ToInt32(dr["Permanent_Address_Prm_State"]),
                        Permanent_Address_Prm_District = Convert.ToInt32(dr["Permanent_Address_Prm_District"]),
                        Permanent_Address_Prm_Pin_Code = Convert.ToString(dr["Permanent_Address_Prm_Pin_Code"]),
                        Permanent_Address_Prm_DistrictState_Name = Convert.ToString(dr["Permanent_Address_Prm_DistrictState_Name"]),

                        //Communication Address
                        Communication_AddressLine1 = Convert.ToString(dr["Communication_AddressLine1"]),
                        Communication_AddressLine2 = Convert.ToString(dr["Communication_AddressLine2"]),
                        Communication_AddressStateCode = Convert.ToInt32(dr["Communication_AddressStateCode"]),
                        Communication_AddressDistrictCode = Convert.ToInt32(dr["Communication_AddressDistrictCode"]),
                        Communication_AddressPIN = Convert.ToString(dr["Communication_AddressPIN"]),
                        Communication_Address_DistrictState_Name = Convert.ToString(dr["Communication_Address_DistrictState_Name"]),

                        //Authorized Person details
                        AuthorizedPerson_Name = Convert.ToString(dr["AuthorizedPerson_Name"]),
                        AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                        AuthorizedPerson_LandlineNumber_STD = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber_STD"]),
                        AuthorizedPerson_LandlineNumber = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber"]),
                        AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),

                        //Authorized Person Address
                        IsAuthorizedPersonAddress = Convert.ToInt32(dr["IsAuthorizedPersonAddress"]),
                        AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                        AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                        AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                        AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                        AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                        AuthorizedPerson_AddressDistrictState_Name = Convert.ToString(dr["AuthorizedPerson_AddressDistrictState_Name"]),

                        //Other Parms
                        CoPromoter_Occupation = Convert.ToString(dr["CoPromoter_Occupation"]),
                        CoPromoter_WebLink = Convert.ToString(dr["CoPromoter_WebLink"]),
                        CoPromoter_PAN_Number = Convert.ToString(dr["CoPromoter_PAN_Number"]),
                        CoPromoter_Aadhaar_Number = Convert.ToInt64(dr["CoPromoter_Aadhaar_Number"]),

                        IsExperience = Convert.ToString(dr["IsExperience"]),
                        Past_Experience_InYear = Convert.ToInt32(dr["Past_Experience_InYear"]),
                        IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                        Past_Litigations_InNumber = Convert.ToInt32(dr["Past_Litigations_InNumber"]),
                        IsOrganizationMembers = Convert.ToString(dr["IsOrganizationMembers"]),
                        IsOrganizationParent_Entity = Convert.ToString(dr["IsOrganizationParent_Entity"]),

                        IsUploadPhotograph = Convert.ToInt32(dr["IsUploadPhotograph"]),
                        CoPromoterImage_FilePath = Convert.ToString(dr["CoPromoterImage_FilePath"]),
                        CoPromoterImage_FileName = Convert.ToString(dr["CoPromoterImage_FileName"]),

                        //Related Reference ID
                        //Dropdown value - Related_ProjectID - START
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_Used_ID = Convert.ToString(dr["Related_Used_ID"]),
                        Related_Promoter_Application_ID = Convert.ToInt64(dr["Related_Promoter_Application_ID"]),

                        //Another Primary Promoter ID
                        Link_RegDiaryNumber_ID = Convert.ToInt64(dr["Link_RegDiaryNumber_ID"]),
                        Link_RegDiaryNumber_Name = Convert.ToString(dr["Link_RegDiaryNumber_Name"]),
                        Link_RegDiaryNumber_NameYear = Convert.ToString(dr["Link_RegDiaryNumber_NameYear"]),
                        Column_A = Convert.ToString(dr["Column_A"]),
                        Column_B = Convert.ToString(dr["Column_B"]),
                        //END

                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        Column_C = Convert.ToString(dr["Column_C"]),
                        Column_D = Convert.ToString(dr["Column_D"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                        Created_On = Convert.ToDateTime(dr["Created_On"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),
                        // CoPromoter Registration Parms

                        IsBriefSummaryDraft = Convert.ToInt32(dr["IsBriefSummaryDraft"]),
                        IsBriefSummaryLock = Convert.ToInt32(dr["IsBriefSummaryLock"]),
                        IsDraftCoPromoters = Convert.ToInt32(dr["IsDraftCoPromoters"]),

                        JointPromoter_Name = Convert.ToString(dr["JointPromoter_Name"]),
                        JointPromoter_District = Convert.ToString(dr["JointPromoter_District"]),
                        JointPromoter_Type = Convert.ToString(dr["JointPromoter_Type"]),
                    });
            }
            return PromoterList;
        }
        public List<ClsPrp_JointPromoter_RegistrationDetails> Display_ByFilterID_JointPromoter_RegistrationDetail(Int64 JointPromoter_ApplicationID, int JointPromoter_TypeFlag, Int64 JointPromoter_Application_IndexID, string UserRole, string UserID)
        {
            List<ClsPrp_JointPromoter_RegistrationDetails> PromoterList = new List<ClsPrp_JointPromoter_RegistrationDetails>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_RegistrationDetails_ByFilterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ApplicationID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_TypeFlag);
            cmd.Parameters.AddWithValue("p_JointPromoter_IndexID", JointPromoter_Application_IndexID);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterList.Add(
                   new ClsPrp_JointPromoter_RegistrationDetails
                   {
                       CoPromoter_IndexID = Convert.ToInt64(dr["CoPromoter_IndexID"]),
                       CoPromoter_ApplicationID = Convert.ToInt64(dr["CoPromoter_ApplicationID"]),
                       CoPromoterType_Flag = Convert.ToInt32(dr["CoPromoterType_Flag"]),

                       //OTI Case
                       Org_Title = Convert.ToString(dr["Org_Title"]),
                       Org_Name = Convert.ToString(dr["Org_Name"]),
                       Org_Type = Convert.ToString(dr["Org_Type"]),
                       OTI_Org_Objects = Convert.ToString(dr["OTI_Org_Objects"]),

                       //IND Case
                       First_Name = Convert.ToString(dr["First_Name"]),
                       Middle_Name = Convert.ToString(dr["Middle_Name"]),
                       Last_Name = Convert.ToString(dr["Last_Name"]),
                       Individual_Gender = Convert.ToString(dr["Individual_Gender"]),
                       Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]),
                       Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]),
                       Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]),
                       Ind_Org_Objects = Convert.ToString(dr["Ind_Org_Objects"]),

                       //Registered Address
                       Registered_Address_Org_Line1 = Convert.ToString(dr["Registered_Address_Org_Line1"]),
                       Registered_Address_Org_Line2 = Convert.ToString(dr["Registered_Address_Org_Line2"]),
                       Registered_Address_Org_State = Convert.ToInt32(dr["Registered_Address_Org_State"]),
                       Registered_Address_Org_District = Convert.ToInt32(dr["Registered_Address_Org_District"]),
                       Registered_Address_Org_Pin_Code = Convert.ToString(dr["Registered_Address_Org_Pin_Code"]),
                       Registered_Address_Org_DistrictState_Name = Convert.ToString(dr["Registered_Address_Org_DistrictState_Name"]),

                       //Permanent Address
                       Permanent_Address_Prm_Line1 = Convert.ToString(dr["Permanent_Address_Prm_Line1"]),
                       Permanent_Address_Prm_Line2 = Convert.ToString(dr["Permanent_Address_Prm_Line2"]),
                       Permanent_Address_Prm_State = Convert.ToInt32(dr["Permanent_Address_Prm_State"]),
                       Permanent_Address_Prm_District = Convert.ToInt32(dr["Permanent_Address_Prm_District"]),
                       Permanent_Address_Prm_Pin_Code = Convert.ToString(dr["Permanent_Address_Prm_Pin_Code"]),
                       Permanent_Address_Prm_DistrictState_Name = Convert.ToString(dr["Permanent_Address_Prm_DistrictState_Name"]),

                       //Communication Address
                       Communication_AddressLine1 = Convert.ToString(dr["Communication_AddressLine1"]),
                       Communication_AddressLine2 = Convert.ToString(dr["Communication_AddressLine2"]),
                       Communication_AddressStateCode = Convert.ToInt32(dr["Communication_AddressStateCode"]),
                       Communication_AddressDistrictCode = Convert.ToInt32(dr["Communication_AddressDistrictCode"]),
                       Communication_AddressPIN = Convert.ToString(dr["Communication_AddressPIN"]),
                       Communication_Address_DistrictState_Name = Convert.ToString(dr["Communication_Address_DistrictState_Name"]),

                       //Authorized Person details
                       AuthorizedPerson_Name = Convert.ToString(dr["AuthorizedPerson_Name"]),
                       AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                       AuthorizedPerson_LandlineNumber_STD = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber_STD"]),
                       AuthorizedPerson_LandlineNumber = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber"]),
                       AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),

                       //Authorized Person Address
                       IsAuthorizedPersonAddress = Convert.ToInt32(dr["IsAuthorizedPersonAddress"]),
                       AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                       AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                       AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                       AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                       AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                       AuthorizedPerson_AddressDistrictState_Name = Convert.ToString(dr["AuthorizedPerson_AddressDistrictState_Name"]),

                       //Other Parms
                       CoPromoter_Occupation = Convert.ToString(dr["CoPromoter_Occupation"]),
                       CoPromoter_WebLink = Convert.ToString(dr["CoPromoter_WebLink"]),
                       CoPromoter_PAN_Number = Convert.ToString(dr["CoPromoter_PAN_Number"]),
                       CoPromoter_Aadhaar_Number = Convert.ToInt64(dr["CoPromoter_Aadhaar_Number"]),

                       IsExperience = Convert.ToString(dr["IsExperience"]),
                       Past_Experience_InYear = Convert.ToInt32(dr["Past_Experience_InYear"]),
                       IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                       Past_Litigations_InNumber = Convert.ToInt32(dr["Past_Litigations_InNumber"]),
                       IsOrganizationMembers = Convert.ToString(dr["IsOrganizationMembers"]),
                       IsOrganizationParent_Entity = Convert.ToString(dr["IsOrganizationParent_Entity"]),

                       IsUploadPhotograph = Convert.ToInt32(dr["IsUploadPhotograph"]),
                       CoPromoterImage_FilePath = Convert.ToString(dr["CoPromoterImage_FilePath"]),
                       CoPromoterImage_FileName = Convert.ToString(dr["CoPromoterImage_FileName"]),

                       //Related Reference ID
                       //Dropdown value - Related_ProjectID - START
                       Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                       Related_Used_ID = Convert.ToString(dr["Related_Used_ID"]),
                       Related_Promoter_Application_ID = Convert.ToInt64(dr["Related_Promoter_Application_ID"]),

                       //Another Primary Promoter ID
                       Link_RegDiaryNumber_ID = Convert.ToInt64(dr["Link_RegDiaryNumber_ID"]),
                       Link_RegDiaryNumber_Name = Convert.ToString(dr["Link_RegDiaryNumber_Name"]),
                       Link_RegDiaryNumber_NameYear = Convert.ToString(dr["Link_RegDiaryNumber_NameYear"]),
                       Column_A = Convert.ToString(dr["Column_A"]),
                       Column_B = Convert.ToString(dr["Column_B"]),
                       //END

                       RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                       Column_C = Convert.ToString(dr["Column_C"]),
                       Column_D = Convert.ToString(dr["Column_D"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       IsLock = Convert.ToInt32(dr["IsLock"]),
                       IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),
                       // CoPromoter Registration Parms

                       IsBriefSummaryDraft = Convert.ToInt32(dr["IsBriefSummaryDraft"]),
                       IsBriefSummaryLock = Convert.ToInt32(dr["IsBriefSummaryLock"]),
                       IsDraftCoPromoters = Convert.ToInt32(dr["IsDraftCoPromoters"]),

                       JointPromoter_Name = Convert.ToString(dr["JointPromoter_Name"]),
                       JointPromoter_District = Convert.ToString(dr["JointPromoter_District"]),
                       JointPromoter_Type = Convert.ToString(dr["JointPromoter_Type"]),
                   });
            }
            return PromoterList;
        }

        public bool Delete_JointPromoter_RegistrationDetail(Int64 JointPromoter_ApplicationID, int JointPromoter_TypeFlag, Int64 JointPromoter_Application_IndexID, string UserRole, string UserID)
        {
            int i = 0;
            connection();
            con.Open();
            using (MySqlTransaction transaction = con.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("Delete_Rera_JointPromoter_RegistrationDetail", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ApplicationID);
                    cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_TypeFlag);
                    cmd.Parameters.AddWithValue("p_JointPromoter_IndexID", JointPromoter_Application_IndexID);
                    cmd.Parameters.AddWithValue("p_UserRole", UserRole);
                    cmd.Parameters.AddWithValue("p_UserID", UserID);
                    
                    i = cmd.ExecuteNonQuery();
                    // Commit transaction, if no errors                                        
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    string strRET = ex.Message;
                    // Rollback transaction, if errors
                    transaction.Rollback();                    
                }
            }
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        // list of joint-promoters Display method
        public List<ClsPrp_JointPromoter_RegistrationDetails> ListofJointPromoters(Int64 PromoterId, Int32 PromoterType)
        {
            List<ClsPrp_JointPromoter_RegistrationDetails> userlist1 = new List<ClsPrp_JointPromoter_RegistrationDetails>();
            try
            {
                DataSet ds = new DataSet();
                string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
                MySqlConnection con = new MySqlConnection();
                using (con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoterList_ByLitigations_ByID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_PromoterId", PromoterId);
                        cmd.Parameters.AddWithValue("p_PromoterType", PromoterType);
                        con.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ClsPrp_JointPromoter_RegistrationDetails uobj = new ClsPrp_JointPromoter_RegistrationDetails();
                            uobj.JointPromoter_Name = ds.Tables[0].Rows[i]["JointPromoter_Name"].ToString();
                            uobj.CoPromoter_ApplicationID = Convert.ToInt64(ds.Tables[0].Rows[i]["JointPromoter_ID"]);

                            userlist1.Add(uobj);

                        }
                        con.Close();
                        return userlist1;
                    }
                }
            }
            catch(Exception ex)
            {
                string strEX = ex.ToString();
                return userlist1;
            }
        }

        // list of projects from Promoter-Ongoing-Projcts
        public List<ClsPrp_OngoingProjectLFiveYears> ListofProjects(Int64 PromoterId, Int32 PromoterType)
        {
            List<ClsPrp_OngoingProjectLFiveYears> userlist1 = new List<ClsPrp_OngoingProjectLFiveYears>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
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

                    ClsPrp_OngoingProjectLFiveYears newProject = new ClsPrp_OngoingProjectLFiveYears
                    {
                        Promoter_Experience_ID = 0,
                        Projectname = "Other" 
                    };
                    userlist1.Add(newProject);
                    
                    con.Close();
                    return userlist1;
                }
            }
        }

        // Search Option AutoComplete Method - Project
        public List<ClsPrp_JointPromoter_SearchOptionParamDetails> Display_PublicView_Autocomplete_ProjectName(string Prefix)
        {
            connection();
            List<ClsPrp_JointPromoter_SearchOptionParamDetails> ProjectList = new List<ClsPrp_JointPromoter_SearchOptionParamDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_PublicView_Autocomplete_ProjectName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", Prefix);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectList.Add(
                           new ClsPrp_JointPromoter_SearchOptionParamDetails
                           {
                               SearchOption_RelatedProjectName = Convert.ToString(dr["Project_Name"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exSTR = ex.ToString();
            }
            return ProjectList;
        }

        // Search Option AutoComplete Method - Promoter
        public List<ClsPrp_JointPromoter_SearchOptionParamDetails> Display_PublicView_Autocomplete_PromoterName(string Prefix)
        {
            connection();
            List<ClsPrp_JointPromoter_SearchOptionParamDetails> PromoterList = new List<ClsPrp_JointPromoter_SearchOptionParamDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_PublicView_Autocomplete_RefPromoterName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", Prefix);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    PromoterList.Add(
                           new ClsPrp_JointPromoter_SearchOptionParamDetails
                           {
                               SearchOption_RelatedPromoterName = Convert.ToString(dr["Promoter_Name"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exSTR = ex.ToString();
            }
            return PromoterList;
        }

        public List<ClsPrp_JointPromoter_SearchOptionDetails> Display_ByFilterID_RegisteredPromotersDetail(Int64 Promoter_DistrictID, int Promoter_Flag, string Project_Name, string Promoter_Name, string Project_RegistrationNumber, string UserRole, string UserID)
        {
            List<ClsPrp_JointPromoter_SearchOptionDetails> PromoterList = new List<ClsPrp_JointPromoter_SearchOptionDetails>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_RegisteredPromoterDetail_ByFilterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_DistrictID", Promoter_DistrictID);
            cmd.Parameters.AddWithValue("p_Promoter_Flag", Promoter_Flag);
            cmd.Parameters.AddWithValue("p_Project_Name", Project_Name);
            cmd.Parameters.AddWithValue("p_Promoter_Name", Promoter_Name);
            cmd.Parameters.AddWithValue("p_Project_RegistrationNumber", Project_RegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterList.Add(
                   new ClsPrp_JointPromoter_SearchOptionDetails
                   {
                       mLinkTo_Project_RegistrationNumber = Convert.ToString(dr["mLinkTo_Project_RegistrationNumber"]),
                       mLinkTo_Reference_ProjectID = Convert.ToInt64(dr["mLinkTo_Reference_ProjectID"]),
                       mLinkTo_Reference_ProjectName = Convert.ToString(dr["mLinkTo_Reference_ProjectName"]),
                       mLinkTo_Reference_PromoterID = Convert.ToInt64(dr["mLinkTo_Reference_PromoterID"]),
                       mLinkTo_Reference_PromoterName = Convert.ToString(dr["mLinkTo_Reference_PromoterName"]),
                       mLinkTo_Reference_DistrictID = Convert.ToInt64(dr["mLinkTo_Reference_DistrictID"]),
                       mLinkTo_Reference_DistrictName = Convert.ToString(dr["mLinkTo_Reference_DistrictName"]),

                       CoPromoter_IndexID = Convert.ToInt64(dr["CoPromoter_IndexID"]),
                       CoPromoter_ApplicationID = Convert.ToInt64(dr["CoPromoter_ApplicationID"]),
                       CoPromoterType_Flag = Convert.ToInt32(dr["CoPromoterType_Flag"]),

                       //OTI Case
                       Org_Title = Convert.ToString(dr["Org_Title"]),
                       Org_Name = Convert.ToString(dr["Org_Name"]),
                       Org_Type = Convert.ToString(dr["Org_Type"]),
                       OTI_Org_Objects = Convert.ToString(dr["OTI_Org_Objects"]),

                       //IND Case
                       First_Name = Convert.ToString(dr["First_Name"]),
                       Middle_Name = Convert.ToString(dr["Middle_Name"]),
                       Last_Name = Convert.ToString(dr["Last_Name"]),
                       Individual_Gender = Convert.ToString(dr["Individual_Gender"]),
                       Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]),
                       Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]),
                       Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]),
                       Ind_Org_Objects = Convert.ToString(dr["Ind_Org_Objects"]),

                       //Registered Address
                       Registered_Address_Org_Line1 = Convert.ToString(dr["Registered_Address_Org_Line1"]),
                       Registered_Address_Org_Line2 = Convert.ToString(dr["Registered_Address_Org_Line2"]),
                       Registered_Address_Org_State = Convert.ToInt32(dr["Registered_Address_Org_State"]),
                       Registered_Address_Org_District = Convert.ToInt32(dr["Registered_Address_Org_District"]),
                       Registered_Address_Org_Pin_Code = Convert.ToString(dr["Registered_Address_Org_Pin_Code"]),
                       Registered_Address_Org_DistrictState_Name = Convert.ToString(dr["Registered_Address_Org_DistrictState_Name"]),

                       //Permanent Address
                       Permanent_Address_Prm_Line1 = Convert.ToString(dr["Permanent_Address_Prm_Line1"]),
                       Permanent_Address_Prm_Line2 = Convert.ToString(dr["Permanent_Address_Prm_Line2"]),
                       Permanent_Address_Prm_State = Convert.ToInt32(dr["Permanent_Address_Prm_State"]),
                       Permanent_Address_Prm_District = Convert.ToInt32(dr["Permanent_Address_Prm_District"]),
                       Permanent_Address_Prm_Pin_Code = Convert.ToString(dr["Permanent_Address_Prm_Pin_Code"]),
                       Permanent_Address_Prm_DistrictState_Name = Convert.ToString(dr["Permanent_Address_Prm_DistrictState_Name"]),

                       //Communication Address
                       Communication_AddressLine1 = Convert.ToString(dr["Communication_AddressLine1"]),
                       Communication_AddressLine2 = Convert.ToString(dr["Communication_AddressLine2"]),
                       Communication_AddressStateCode = Convert.ToInt32(dr["Communication_AddressStateCode"]),
                       Communication_AddressDistrictCode = Convert.ToInt32(dr["Communication_AddressDistrictCode"]),
                       Communication_AddressPIN = Convert.ToString(dr["Communication_AddressPIN"]),
                       Communication_Address_DistrictState_Name = Convert.ToString(dr["Communication_Address_DistrictState_Name"]),

                       //Authorized Person details
                       AuthorizedPerson_Name = Convert.ToString(dr["AuthorizedPerson_Name"]),
                       AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                       AuthorizedPerson_LandlineNumber_STD = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber_STD"]),
                       AuthorizedPerson_LandlineNumber = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber"]),
                       AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),

                       //Authorized Person Address
                       IsAuthorizedPersonAddress = Convert.ToInt32(dr["IsAuthorizedPersonAddress"]),
                       AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                       AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                       AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                       AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                       AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                       AuthorizedPerson_AddressDistrictState_Name = Convert.ToString(dr["AuthorizedPerson_AddressDistrictState_Name"]),

                       //Other Parms
                       CoPromoter_Occupation = Convert.ToString(dr["CoPromoter_Occupation"]),
                       CoPromoter_WebLink = Convert.ToString(dr["CoPromoter_WebLink"]),
                       CoPromoter_PAN_Number = Convert.ToString(dr["CoPromoter_PAN_Number"]),
                       CoPromoter_Aadhaar_Number = Convert.ToInt64(dr["CoPromoter_Aadhaar_Number"]),

                       IsExperience = Convert.ToString(dr["IsExperience"]),
                       Past_Experience_InYear = Convert.ToInt32(dr["Past_Experience_InYear"]),
                       IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                       Past_Litigations_InNumber = Convert.ToInt32(dr["Past_Litigations_InNumber"]),
                       IsOrganizationMembers = Convert.ToString(dr["IsOrganizationMembers"]),
                       IsOrganizationParent_Entity = Convert.ToString(dr["IsOrganizationParent_Entity"]),

                       IsUploadPhotograph = Convert.ToInt32(dr["IsUploadPhotograph"]),
                       CoPromoterImage_FilePath = Convert.ToString(dr["CoPromoterImage_FilePath"]),
                       CoPromoterImage_FileName = Convert.ToString(dr["CoPromoterImage_FileName"]),

                       //Related Reference ID
                       //Dropdown value - Related_ProjectID - START
                       Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                       Related_Used_ID = Convert.ToString(dr["Related_Used_ID"]),
                       Related_Promoter_Application_ID = Convert.ToInt64(dr["Related_Promoter_Application_ID"]),

                       //Another Primary Promoter ID
                       Link_RegDiaryNumber_ID = Convert.ToInt64(dr["Link_RegDiaryNumber_ID"]),
                       Link_RegDiaryNumber_Name = Convert.ToString(dr["Link_RegDiaryNumber_Name"]),
                       Link_RegDiaryNumber_NameYear = Convert.ToString(dr["Link_RegDiaryNumber_NameYear"]),
                       Column_A = Convert.ToString(dr["Column_A"]),
                       Column_B = Convert.ToString(dr["Column_B"]),
                       //END

                       RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                       Column_C = Convert.ToString(dr["Column_C"]),
                       Column_D = Convert.ToString(dr["Column_D"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       IsLock = Convert.ToInt32(dr["IsLock"]),
                       IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),
                       // CoPromoter Registration Parms

                       IsBriefSummaryDraft = Convert.ToInt32(dr["IsBriefSummaryDraft"]),
                       IsBriefSummaryLock = Convert.ToInt32(dr["IsBriefSummaryLock"]),
                       IsDraftCoPromoters = Convert.ToInt32(dr["IsDraftCoPromoters"]),

                       JointPromoter_Name = Convert.ToString(dr["JointPromoter_Name"]),
                       JointPromoter_District = Convert.ToString(dr["JointPromoter_District"]),
                       JointPromoter_Type = Convert.ToString(dr["JointPromoter_Type"]),
                   });
            }
            return PromoterList;
        }

    }
}