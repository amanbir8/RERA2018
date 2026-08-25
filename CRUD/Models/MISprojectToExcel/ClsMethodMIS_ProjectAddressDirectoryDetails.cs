using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsMethod_MIS_ProjectAddressDirectoryDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_MIS_ProjectAddressDirectoryDetails> Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForInProcessApplication(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectAddressDirectoryDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAddressDirectoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectAddressDirectoryDetails_InProcess", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAddressDirectoryDetails
                       {
                           ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),

                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Project_PotentialZoneCode = fnReturnSTR(Convert.ToString(dr["Project_PotentialZoneCode"])),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),

                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToString(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           // Promoter Details
                           Application_Id = Convert.ToInt64(dr["Application_Id"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),

                           Promoter_RegdAddress_Line1 = Convert.ToString(dr["Promoter_RegdAddress_Line1"]),
                           Promoter_RegdAddress_Line2 = Convert.ToString(dr["Promoter_RegdAddress_Line2"]),
                           Promoter_RegdState = Convert.ToString(dr["Promoter_RegdState"]),
                           Promoter_RegdDistrict = Convert.ToString(dr["Promoter_RegdDistrict"]),
                           Promoter_Regd_PIN = Convert.ToString(dr["Promoter_Regd_PIN"]),

                           Promoter_CommAddress_Line1 = Convert.ToString(dr["Promoter_CommAddress_Line1"]),
                           Promoter_CommAddress_Line2 = Convert.ToString(dr["Promoter_CommAddress_Line2"]),
                           Promoter_CommState = Convert.ToString(dr["Promoter_CommState"]),
                           Promoter_CommDistrict = Convert.ToString(dr["Promoter_CommDistrict"]),
                           Promoter_Comm_PIN = Convert.ToString(dr["Promoter_Comm_PIN"]),

                           Promoter_AuthorisedSignatory_Name = Convert.ToString(dr["Promoter_AuthorisedSignatory_Name"]),
                           Promoter_AuthorisedSignatory_MobileNumber = Convert.ToInt64(dr["Promoter_AuthorisedSignatory_MobileNumber"]),
                           Promoter_AuthorisedSignatory_Email = Convert.ToString(dr["Promoter_AuthorisedSignatory_Email"]),

                           Flag = Convert.ToInt32(dr["Flag"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectAddressDirectoryDetails> Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForInProcessApplication_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_ProjectAddressDirectoryDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAddressDirectoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectAddressDirectoryDetails_InProcess", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);


            string ddFromDate = FromDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
            string ddToDate = ToDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Todate", ddToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            DataTable dt1 = new DataTable();
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["CreatedOn"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["CreatedOn"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["CreatedOn"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["CreatedOn"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAddressDirectoryDetails
                       {
                           ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),

                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Project_PotentialZoneCode = fnReturnSTR(Convert.ToString(dr["Project_PotentialZoneCode"])),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),

                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToString(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           // Promoter Details
                           Application_Id = Convert.ToInt64(dr["Application_Id"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),

                           Promoter_RegdAddress_Line1 = Convert.ToString(dr["Promoter_RegdAddress_Line1"]),
                           Promoter_RegdAddress_Line2 = Convert.ToString(dr["Promoter_RegdAddress_Line2"]),
                           Promoter_RegdState = Convert.ToString(dr["Promoter_RegdState"]),
                           Promoter_RegdDistrict = Convert.ToString(dr["Promoter_RegdDistrict"]),
                           Promoter_Regd_PIN = Convert.ToString(dr["Promoter_Regd_PIN"]),

                           Promoter_CommAddress_Line1 = Convert.ToString(dr["Promoter_CommAddress_Line1"]),
                           Promoter_CommAddress_Line2 = Convert.ToString(dr["Promoter_CommAddress_Line2"]),
                           Promoter_CommState = Convert.ToString(dr["Promoter_CommState"]),
                           Promoter_CommDistrict = Convert.ToString(dr["Promoter_CommDistrict"]),
                           Promoter_Comm_PIN = Convert.ToString(dr["Promoter_Comm_PIN"]),

                           Promoter_AuthorisedSignatory_Name = Convert.ToString(dr["Promoter_AuthorisedSignatory_Name"]),
                           Promoter_AuthorisedSignatory_MobileNumber = Convert.ToInt64(dr["Promoter_AuthorisedSignatory_MobileNumber"]),
                           Promoter_AuthorisedSignatory_Email = Convert.ToString(dr["Promoter_AuthorisedSignatory_Email"]),

                           Flag = Convert.ToInt32(dr["Flag"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                       });
            }
            return ProjectReralist;
        }
        
        public List<Clsprp_MIS_ProjectAddressDirectoryDetails> Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForRegisteredProjects(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectAddressDirectoryDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAddressDirectoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectAddressDirectoryDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAddressDirectoryDetails
                       {
                           ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),

                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Project_PotentialZoneCode = fnReturnSTR(Convert.ToString(dr["Project_PotentialZoneCode"])),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),

                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToString(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           // Promoter Details
                           Application_Id = Convert.ToInt64(dr["Application_Id"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),

                           Promoter_RegdAddress_Line1 = Convert.ToString(dr["Promoter_RegdAddress_Line1"]),
                           Promoter_RegdAddress_Line2 = Convert.ToString(dr["Promoter_RegdAddress_Line2"]),
                           Promoter_RegdState = Convert.ToString(dr["Promoter_RegdState"]),
                           Promoter_RegdDistrict = Convert.ToString(dr["Promoter_RegdDistrict"]),
                           Promoter_Regd_PIN = Convert.ToString(dr["Promoter_Regd_PIN"]),

                           Promoter_CommAddress_Line1 = Convert.ToString(dr["Promoter_CommAddress_Line1"]),
                           Promoter_CommAddress_Line2 = Convert.ToString(dr["Promoter_CommAddress_Line2"]),
                           Promoter_CommState = Convert.ToString(dr["Promoter_CommState"]),
                           Promoter_CommDistrict = Convert.ToString(dr["Promoter_CommDistrict"]),
                           Promoter_Comm_PIN = Convert.ToString(dr["Promoter_Comm_PIN"]),

                           Promoter_AuthorisedSignatory_Name = Convert.ToString(dr["Promoter_AuthorisedSignatory_Name"]),
                           Promoter_AuthorisedSignatory_MobileNumber = Convert.ToInt64(dr["Promoter_AuthorisedSignatory_MobileNumber"]),
                           Promoter_AuthorisedSignatory_Email = Convert.ToString(dr["Promoter_AuthorisedSignatory_Email"]),

                           Flag = Convert.ToInt32(dr["Flag"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectAddressDirectoryDetails> Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForRegisteredProjects_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_ProjectAddressDirectoryDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAddressDirectoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectAddressDirectoryDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);


            string ddFromDate = FromDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
            string ddToDate = ToDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Todate", ddToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            DataTable dt1 = new DataTable();
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["CreatedOn"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["CreatedOn"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["CreatedOn"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["CreatedOn"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAddressDirectoryDetails
                       {
                           ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),

                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Project_PotentialZoneCode = fnReturnSTR(Convert.ToString(dr["Project_PotentialZoneCode"])),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),

                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToString(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           // Promoter Details
                           Application_Id = Convert.ToInt64(dr["Application_Id"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),

                           Promoter_RegdAddress_Line1 = Convert.ToString(dr["Promoter_RegdAddress_Line1"]),
                           Promoter_RegdAddress_Line2 = Convert.ToString(dr["Promoter_RegdAddress_Line2"]),
                           Promoter_RegdState = Convert.ToString(dr["Promoter_RegdState"]),
                           Promoter_RegdDistrict = Convert.ToString(dr["Promoter_RegdDistrict"]),
                           Promoter_Regd_PIN = Convert.ToString(dr["Promoter_Regd_PIN"]),

                           Promoter_CommAddress_Line1 = Convert.ToString(dr["Promoter_CommAddress_Line1"]),
                           Promoter_CommAddress_Line2 = Convert.ToString(dr["Promoter_CommAddress_Line2"]),
                           Promoter_CommState = Convert.ToString(dr["Promoter_CommState"]),
                           Promoter_CommDistrict = Convert.ToString(dr["Promoter_CommDistrict"]),
                           Promoter_Comm_PIN = Convert.ToString(dr["Promoter_Comm_PIN"]),

                           Promoter_AuthorisedSignatory_Name = Convert.ToString(dr["Promoter_AuthorisedSignatory_Name"]),
                           Promoter_AuthorisedSignatory_MobileNumber = Convert.ToInt64(dr["Promoter_AuthorisedSignatory_MobileNumber"]),
                           Promoter_AuthorisedSignatory_Email = Convert.ToString(dr["Promoter_AuthorisedSignatory_Email"]),

                           Flag = Convert.ToInt32(dr["Flag"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                       });
            }
            return ProjectReralist;
        }

        public List<Clsprp_MIS_ProjectAddressDirectoryDetails> Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForMIS(Int64 Project_ID, string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectAddressDirectoryDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAddressDirectoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectAddressDirectoryDetails_ByProjectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectID", Project_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAddressDirectoryDetails
                       {
                           ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),

                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Project_PotentialZoneCode = fnReturnSTR(Convert.ToString(dr["Project_PotentialZoneCode"])),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),

                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToString(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           // Promoter Details
                           Application_Id = Convert.ToInt64(dr["Application_Id"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),

                           Promoter_RegdAddress_Line1 = Convert.ToString(dr["Promoter_RegdAddress_Line1"]),
                           Promoter_RegdAddress_Line2 = Convert.ToString(dr["Promoter_RegdAddress_Line2"]),
                           Promoter_RegdState = Convert.ToString(dr["Promoter_RegdState"]),
                           Promoter_RegdDistrict = Convert.ToString(dr["Promoter_RegdDistrict"]),
                           Promoter_Regd_PIN = Convert.ToString(dr["Promoter_Regd_PIN"]),

                           Promoter_CommAddress_Line1 = Convert.ToString(dr["Promoter_CommAddress_Line1"]),
                           Promoter_CommAddress_Line2 = Convert.ToString(dr["Promoter_CommAddress_Line2"]),
                           Promoter_CommState = Convert.ToString(dr["Promoter_CommState"]),
                           Promoter_CommDistrict = Convert.ToString(dr["Promoter_CommDistrict"]),
                           Promoter_Comm_PIN = Convert.ToString(dr["Promoter_Comm_PIN"]),

                           Promoter_AuthorisedSignatory_Name = Convert.ToString(dr["Promoter_AuthorisedSignatory_Name"]),
                           Promoter_AuthorisedSignatory_MobileNumber = Convert.ToInt64(dr["Promoter_AuthorisedSignatory_MobileNumber"]),
                           Promoter_AuthorisedSignatory_Email = Convert.ToString(dr["Promoter_AuthorisedSignatory_Email"]),

                           Flag = Convert.ToInt32(dr["Flag"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                       });
            }
            return ProjectReralist;
        }

        private string fnReturnSTR(string var1)
        {
            string vargetSTR = string.Empty;
            switch (Convert.ToString(var1))
            {
                case "1":
                    vargetSTR = "Zone 1"; // - Master Plan Area of S.A.S.Nagar, Mullanpur and Zirakpur / Ludhiana within and outside M.C Limits upto 15 Kms.";
                    break;
                case "2":
                    vargetSTR = "Zone 2"; // - Jalandhar within and outside M.C Limits upto 10 Kms./ Master Plan Area of Kharar, DeraBassi and Banur.";
                    break;
                case "3":
                    vargetSTR = "Zone 3"; // - Amritsar, Patiala, Khanna, Rajpura, MandiGobindgarh, Sirhind and Phagwara within and outside M.C Limits upto 7 Kms and NH - 1 upto 2Kms on both sides, outside any potential zone.";
                    break;
                case "4":
                    vargetSTR = "Zone 4"; // - Bathinda, Moga, Batala, Pathankot, Barnala, Malerkotla, Morinda, Hoshiarpur, within and outside M.C Limits upto 5 Kms.";
                    break;
                case "5":
                    vargetSTR = "Zone 5"; // - Sangrur, Sunam, Nabha, Faridkot, Kotkapura, Ferozepur, Malout, Abohar, Sri Mukatsar Sahib, Kapurthala, NawanShahar, Ropar, Tarn Taran, Gurdaspur, Samana, Jagraon, Mansa, Lalru, Kurali within and outside M.C Limits upto 3 Kms and All other NH(except NH 1) / SH / Scheduled Roads upto 1 Kms both sides, outside any potential zone.";
                    break;
                case "6":
                    vargetSTR = "Zone 6"; // - Rest of Punjab.";
                    break;
                default:
                    vargetSTR = "";
                    break;
            }
            return vargetSTR;
        }

        private string RegexRemoveEmailCheck(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "@";
            string replacement = "[at]";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
        }
    }
}