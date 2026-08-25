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
    public class ClsMethod_Project_Registration
    {

        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_Project_Registration(ClsPrp_Project_Registration smodel, Int64 oPromoterID, string oUID, string oUnam)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_Project_Name", smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_p_Project_Amenities", smodel.Project_Amenities);
            cmd.Parameters.AddWithValue("p_p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_Structure", smodel.ProposedProjectDetail_Structure);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_Flooring", smodel.ProposedProjectDetail_Flooring);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_WallFinishing", smodel.ProposedProjectDetail_WallFinishing);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_SanitaryFittings", smodel.ProposedProjectDetail_SanitaryFittings);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_ElectricalFittings", smodel.ProposedProjectDetail_ElectricalFittings);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_Kitchen", smodel.ProposedProjectDetail_Kitchen);

            cmd.Parameters.AddWithValue("p_p_IsProposedProjectDetail_OthersIfAny", String.IsNullOrEmpty(smodel.IsProposedProjectDetail_OthersIfAny) ? "" : smodel.IsProposedProjectDetail_OthersIfAny); 
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_OthersIfAnyName", String.IsNullOrEmpty(smodel.ProposedProjectDetail_OthersIfAnyName) ? "" : smodel.ProposedProjectDetail_OthersIfAnyName); 
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_OthersIfAny", String.IsNullOrEmpty(smodel.ProposedProjectDetail_OthersIfAny) ? "" : smodel.ProposedProjectDetail_OthersIfAny); 
            cmd.Parameters.AddWithValue("p_p_Project_Status", smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_p_ProjectStart_Date", smodel.ProjectStart_Date);
            cmd.Parameters.AddWithValue("p_p_ProjectCompletion_ProposedDate", smodel.ProjectCompletion_ProposedDate);
            cmd.Parameters.AddWithValue("p_p_ProjectCompletion_OriginalDate", smodel.ProjectCompletion_OriginalDate);
            cmd.Parameters.AddWithValue("p_p_ProjectRegistrationProvided_Duration", smodel.ProjectRegistrationProvided_Duration);
            cmd.Parameters.AddWithValue("p_p_ProjectDelayReason_IfAny", String.IsNullOrEmpty(smodel.ProjectDelayReason_IfAny) ? "" : smodel.ProjectDelayReason_IfAny);
            cmd.Parameters.AddWithValue("p_p_Project_AddressLine1", smodel.Project_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_Project_AddressLine2", String.IsNullOrEmpty(smodel.Project_AddressLine2) ? "" : smodel.Project_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_Project_AddressStateCode", smodel.Project_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_Project_AddressDistrictCode", smodel.Project_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_Project_AddressSubDivisionCode", smodel.Project_AddressSubDivisionCode);
            cmd.Parameters.AddWithValue("p_p_Project_AddressPIN", smodel.Project_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_Project_PotentialZoneCode", smodel.Project_PotentialZoneCode);
            cmd.Parameters.AddWithValue("p_p_ProjectWebsite_WebLink", String.IsNullOrEmpty(smodel.ProjectWebsite_WebLink) ? "" : smodel.ProjectWebsite_WebLink); 
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_FirstName", smodel.AuthorizedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_MiddleName", String.IsNullOrEmpty(smodel.AuthorizedPerson_MiddleName) ? "" : smodel.AuthorizedPerson_MiddleName);
            //cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_MiddleName", smodel.AuthorizedPerson_MiddleName);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedPerson_LastName) ? "" : smodel.AuthorizedPerson_LastName);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressLine1", smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? "" : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressStateCode", smodel.AuthorizedPerson_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressDistrictCode", smodel.AuthorizedPerson_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressPIN", smodel.AuthorizedPerson_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_EmailAddress", smodel.AuthorizedPerson_EmailAddress);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_MobileNumber", smodel.AuthorizedPerson_MobileNumber);
            cmd.Parameters.AddWithValue("p_p_IsProForma_AOS_RERAformat_AnnexureA", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_AnnexureA) ? "" : smodel.IsProForma_AOS_RERAformat_AnnexureA); 
            cmd.Parameters.AddWithValue("p_p_IsProForma_AOS_RERAformat_No_IsApproved", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_No_IsApproved) ? "" : smodel.IsProForma_AOS_RERAformat_No_IsApproved);
            cmd.Parameters.AddWithValue("p_p_IsProject_MegaProjectCategory", String.IsNullOrEmpty(smodel.IsProject_MegaProjectCategory) ? "" : smodel.IsProject_MegaProjectCategory);
            cmd.Parameters.AddWithValue("p_p_IsLitigation_RelatedProject", String.IsNullOrEmpty(smodel.IsLitigation_RelatedProject) ? "" : smodel.IsLitigation_RelatedProject);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "0");//smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", oUnam); // smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", oUnam); // smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_p_promoter_ID", oPromoterID); // smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_p_user_ID", oUID); // smodel.ModifyBy);
            
 
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

        public Int64 Update_Project_Registration(ClsPrp_Project_Registration smodel, Int64 oPromoterID, string oUID, string oUnam)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            //cmd.Parameters.AddWithValue("p_p_ProjectRegistration_IndexID", smodel.ProjectRegistration_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectRegistration_ID", smodel.ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_Project_Name", smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_p_Project_Amenities", smodel.Project_Amenities);
            cmd.Parameters.AddWithValue("p_p_IsAlready_RERANumber", String.IsNullOrEmpty(smodel.IsAlready_RERANumber) ? "" : smodel.IsAlready_RERANumber);
            cmd.Parameters.AddWithValue("p_p_Existing_RERANumber", String.IsNullOrEmpty(smodel.Existing_RERANumber) ? "" : smodel.Existing_RERANumber);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_Structure", smodel.ProposedProjectDetail_Structure);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_Flooring", smodel.ProposedProjectDetail_Flooring);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_WallFinishing", smodel.ProposedProjectDetail_WallFinishing);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_SanitaryFittings", smodel.ProposedProjectDetail_SanitaryFittings);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_ElectricalFittings", smodel.ProposedProjectDetail_ElectricalFittings);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_Kitchen", smodel.ProposedProjectDetail_Kitchen);
            cmd.Parameters.AddWithValue("p_p_IsProposedProjectDetail_OthersIfAny", String.IsNullOrEmpty(smodel.IsProposedProjectDetail_OthersIfAny) ? "" : smodel.IsProposedProjectDetail_OthersIfAny);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_OthersIfAnyName", String.IsNullOrEmpty(smodel.ProposedProjectDetail_OthersIfAnyName) ? "" : smodel.ProposedProjectDetail_OthersIfAnyName);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectDetail_OthersIfAny", String.IsNullOrEmpty(smodel.ProposedProjectDetail_OthersIfAny) ? "" : smodel.ProposedProjectDetail_OthersIfAny);
            cmd.Parameters.AddWithValue("p_p_Project_Status", smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_p_ProjectStart_Date", smodel.ProjectStart_Date);
            cmd.Parameters.AddWithValue("p_p_ProjectCompletion_ProposedDate", smodel.ProjectCompletion_ProposedDate);
            cmd.Parameters.AddWithValue("p_p_ProjectCompletion_OriginalDate", smodel.ProjectCompletion_OriginalDate);
            cmd.Parameters.AddWithValue("p_p_ProjectRegistrationProvided_Duration", smodel.ProjectRegistrationProvided_Duration);
            cmd.Parameters.AddWithValue("p_p_ProjectDelayReason_IfAny", String.IsNullOrEmpty(smodel.ProjectDelayReason_IfAny) ? "" : smodel.ProjectDelayReason_IfAny);
            cmd.Parameters.AddWithValue("p_p_Project_AddressLine1", smodel.Project_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_Project_AddressLine2", String.IsNullOrEmpty(smodel.Project_AddressLine2) ? "" : smodel.Project_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_Project_AddressStateCode", smodel.Project_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_Project_AddressDistrictCode", smodel.Project_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_Project_AddressSubDivisionCode", smodel.Project_AddressSubDivisionCode);
            cmd.Parameters.AddWithValue("p_p_Project_AddressPIN", smodel.Project_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_Project_PotentialZoneCode", smodel.Project_PotentialZoneCode);
            cmd.Parameters.AddWithValue("p_p_ProjectWebsite_WebLink", String.IsNullOrEmpty(smodel.ProjectWebsite_WebLink) ? "" : smodel.ProjectWebsite_WebLink);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_FirstName", smodel.AuthorizedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_MiddleName", String.IsNullOrEmpty(smodel.AuthorizedPerson_MiddleName) ? "" : smodel.AuthorizedPerson_MiddleName);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedPerson_LastName) ? "" : smodel.AuthorizedPerson_LastName);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressLine1", smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? "" : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressStateCode", smodel.AuthorizedPerson_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressDistrictCode", smodel.AuthorizedPerson_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_AddressPIN", smodel.AuthorizedPerson_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_EmailAddress", smodel.AuthorizedPerson_EmailAddress);
            cmd.Parameters.AddWithValue("p_p_AuthorizedPerson_MobileNumber", smodel.AuthorizedPerson_MobileNumber);
            cmd.Parameters.AddWithValue("p_p_IsProForma_AOS_RERAformat_AnnexureA", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_AnnexureA) ? "" : smodel.IsProForma_AOS_RERAformat_AnnexureA);
            cmd.Parameters.AddWithValue("p_p_IsProForma_AOS_RERAformat_No_IsApproved", String.IsNullOrEmpty(smodel.IsProForma_AOS_RERAformat_No_IsApproved) ? "" : smodel.IsProForma_AOS_RERAformat_No_IsApproved);
            cmd.Parameters.AddWithValue("p_p_IsProject_MegaProjectCategory", String.IsNullOrEmpty(smodel.IsProject_MegaProjectCategory) ? "" : smodel.IsProject_MegaProjectCategory);
            cmd.Parameters.AddWithValue("p_p_IsLitigation_RelatedProject", String.IsNullOrEmpty(smodel.IsLitigation_RelatedProject) ? "" : smodel.IsLitigation_RelatedProject);

            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column); //String.IsNullOrEmpty(smodel.A_column) ? "0" : smodel.A_column);//
            cmd.Parameters.AddWithValue("p_p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "0");//smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", oUnam); // smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", oUnam); // smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_p_promoter_ID", oPromoterID); // smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_p_user_ID", oUID); // smodel.ModifyBy);





            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            return smodel.ProjectRegistration_ID;
        }

        public List<ClsPrp_Project_Registration> Display_Project_RegistrationAll(Int64 zPromoterID)
        {
            connection();
            List<ClsPrp_Project_Registration> ProjectFivelist1 = new List<ClsPrp_Project_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_RegistrationAll", con);
            cmd.Parameters.AddWithValue("p_PromoterID", zPromoterID);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            
            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_Registration
                       {
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),


                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Amenities = Convert.ToString(dr["Project_Amenities"]),
                           IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                           Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                           ProposedProjectDetail_Structure = Convert.ToString(dr["ProposedProjectDetail_Structure"]),
                           ProposedProjectDetail_Flooring = Convert.ToString(dr["ProposedProjectDetail_Flooring"]),
                           ProposedProjectDetail_WallFinishing = Convert.ToString(dr["ProposedProjectDetail_WallFinishing"]),
                           ProposedProjectDetail_SanitaryFittings = Convert.ToString(dr["ProposedProjectDetail_SanitaryFittings"]),
                           ProposedProjectDetail_ElectricalFittings = Convert.ToString(dr["ProposedProjectDetail_ElectricalFittings"]),
                           ProposedProjectDetail_Kitchen = Convert.ToString(dr["ProposedProjectDetail_Kitchen"]),
                           IsProposedProjectDetail_OthersIfAny = Convert.ToString(dr["IsProposedProjectDetail_OthersIfAny"]),
                           ProposedProjectDetail_OthersIfAnyName = Convert.ToString(dr["ProposedProjectDetail_OthersIfAnyName"]),
                           ProposedProjectDetail_OthersIfAny = Convert.ToString(dr["ProposedProjectDetail_OthersIfAny"]),
                           Project_Status = Convert.ToString(dr["Project_Status"]),
                           ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                           ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                           ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),
                           ProjectRegistrationProvided_Duration = Convert.ToString(dr["ProjectRegistrationProvided_Duration"]),
                           ProjectDelayReason_IfAny = Convert.ToString(dr["ProjectDelayReason_IfAny"]),
                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToInt16(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToInt16(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToInt16(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),
                           Project_PotentialZoneCode = Convert.ToInt16(dr["Project_PotentialZoneCode"]),
                           ProjectWebsite_WebLink = Convert.ToString(dr["ProjectWebsite_WebLink"]),
                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToInt16(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToInt16(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                           IsProForma_AOS_RERAformat_AnnexureA = Convert.ToString(dr["IsProForma_AOS_RERAformat_AnnexureA"]),
                           IsProForma_AOS_RERAformat_No_IsApproved = Convert.ToString(dr["IsProForma_AOS_RERAformat_No_IsApproved"]),
                           IsProject_MegaProjectCategory = Convert.ToString(dr["IsProject_MegaProjectCategory"]),
                           IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),                           
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToDecimal(dr["A_column"]),
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

        public List<ClsPrp_Project_Registration> Display_Project_Registration(Int64 ProjectRegistration_ID,Int64 Index_ID)
        {
            connection();
            List<ClsPrp_Project_Registration> ProjectFivelist1 = new List<ClsPrp_Project_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_RegistrationByApplicationID", con);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_Registration
                       {
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Amenities = Convert.ToString(dr["Project_Amenities"]),
                           IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                           Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                           ProposedProjectDetail_Structure = Convert.ToString(dr["ProposedProjectDetail_Structure"]),
                           ProposedProjectDetail_Flooring = Convert.ToString(dr["ProposedProjectDetail_Flooring"]),
                           ProposedProjectDetail_WallFinishing = Convert.ToString(dr["ProposedProjectDetail_WallFinishing"]),
                           ProposedProjectDetail_SanitaryFittings = Convert.ToString(dr["ProposedProjectDetail_SanitaryFittings"]),
                           ProposedProjectDetail_ElectricalFittings = Convert.ToString(dr["ProposedProjectDetail_ElectricalFittings"]),
                           ProposedProjectDetail_Kitchen = Convert.ToString(dr["ProposedProjectDetail_Kitchen"]),
                           IsProposedProjectDetail_OthersIfAny = Convert.ToString(dr["IsProposedProjectDetail_OthersIfAny"]),
                           ProposedProjectDetail_OthersIfAnyName = Convert.ToString(dr["ProposedProjectDetail_OthersIfAnyName"]),
                           ProposedProjectDetail_OthersIfAny = Convert.ToString(dr["ProposedProjectDetail_OthersIfAny"]),
                           Project_Status = Convert.ToString(dr["Project_Status"]),
                           ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                           ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                           ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),
                           ProjectRegistrationProvided_Duration = Convert.ToString(dr["ProjectRegistrationProvided_Duration"]),
                           ProjectDelayReason_IfAny = Convert.ToString(dr["ProjectDelayReason_IfAny"]),
                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToInt16(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToInt16(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToInt16(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),
                           Project_PotentialZoneCode = Convert.ToInt16(dr["Project_PotentialZoneCode"]),
                           ProjectWebsite_WebLink = Convert.ToString(dr["ProjectWebsite_WebLink"]),
                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToInt16(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToInt16(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                           IsProForma_AOS_RERAformat_AnnexureA = Convert.ToString(dr["IsProForma_AOS_RERAformat_AnnexureA"]),
                           IsProForma_AOS_RERAformat_No_IsApproved = Convert.ToString(dr["IsProForma_AOS_RERAformat_No_IsApproved"]),
                           IsProject_MegaProjectCategory = Convert.ToString(dr["IsProject_MegaProjectCategory"]),
                           IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToDecimal(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),

                           ProjectType_Code = Convert.ToString(dr["ProjectType_Code"]),
                           ProjectType_SubType_Code = Convert.ToString(dr["ProjectType_SubType_Code"]),
                           
                       });
            }
            return ProjectFivelist1;
        }
    }
}