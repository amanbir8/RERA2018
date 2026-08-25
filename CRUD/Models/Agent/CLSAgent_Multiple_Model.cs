using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using CRUD.Models.Promoter;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Agent
{

    public class CLSAgent_Multiple_Model
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        public List<Clsprp_Agent> Agent { get; set; }
        public string P_AddressState { get; set; }
        public string P_AddressDist { get; set; }
        public string BusinessPlace_AddressState { get; set; }
        public string BusinessPlace_AddressDistrict { get; set; }
        public string BComm_AddressState { get; set; }
        public string BComm_AddressDistrict { get; set; }
        public string RegOffice_AddressState { get; set; }
        public string RegOffice_AddressDistrict { get; set; }
        public string IsOtherStateUT_RERAregistration { get; set; }


        public long zapRelated_Agent_ID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }





        public List<CLsprpOtherThanIndivualAgent> AgentOtherThanInd { get; set; }
        public List<ClsprpRera_Agent_OtherMemberDetail> Agent_OtherMember { get; set; }
        public List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> Agent_OtherStateUTMember { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<CLSprpAgent_Payment> AgentPayment { get; set; }

        public List<Clsprp_Agent> DisplayAgentDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);




            List<Clsprp_Agent> list_indPro = new List<Clsprp_Agent>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new Clsprp_Agent
                    {
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                        IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                        Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                        Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                        Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                        Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                        Father_LastName = Convert.ToString(dr["Father_LastName"]),
                        Occupation = Convert.ToString(dr["Occupation"]),
                        Image_FileName = Convert.ToString(dr["Image_FileName"]),
                        Image_FilePath = Convert.ToString(dr["Image_FilePath"]),
                        P_AddressLine1 = Convert.ToString(dr["P_AddressLine1"]),
                        P_AddressLine2 = Convert.ToString(dr["P_AddressLine2"]),
                        P_AddressStateCode = Convert.ToInt32(dr["P_AddressStateCode"]),
                        P_AddressDistrictCode = Convert.ToInt32(dr["P_AddressDistrictCode"]),
                        P_AddressPIN = Convert.ToString(dr["P_AddressPIN"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                        Organization_MainObjects = Convert.ToString(dr["Organization_MainObjects"]),
                    //RegOffice_AddressLine1 = Convert.ToString(dr["RegOffice_AddressLine1"]),
                    //RegOffice_AddressLine2 = Convert.ToString(dr["RegOffice_AddressLine2"]),
                    //RegOffice_AddressStateCode = Convert.ToInt32(dr["RegOffice_AddressStateCode"]),
                    //RegOffice_AddressDistrictCode = Convert.ToInt32(dr["RegOffice_AddressDistrictCode"]),
                    //RegOffice_AddressPIN = Convert.ToInt32(dr["RegOffice_AddressPIN"]),
                    BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                        BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                        BusinessPlace_AddressStateCode = Convert.ToInt32(dr["BusinessPlace_AddressStateCode"]),
                        BusinessPlace_AddressDistrictCode = Convert.ToInt32(dr["BusinessPlace_AddressDistrictCode"]),
                        BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),

                        IsSameBussinessAdd_CommAdd = ((dr["IsSameBussinessAdd_CommAdd"] as string == "1") ? true : false),

                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                        BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),
                        AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                        AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                        AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        PAN_Number = Convert.ToString(dr["PAN_Number"]),
                        Aadhaar_Number = Convert.ToInt64(dr["Aadhaar_Number"]),
                        IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                        IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }

        public List<CLsprpOtherThanIndivualAgent> DisplayAgentOtherThanIndDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Profile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);



            //connection();
            List<CLsprpOtherThanIndivualAgent> list_indPro = new List<CLsprpOtherThanIndivualAgent>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new CLsprpOtherThanIndivualAgent
                    {
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                        IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                        Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                        //Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        //Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                        //Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        //Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                        //Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                        //Father_LastName = Convert.ToString(dr["Father_LastName"]),
                        //Occupation = Convert.ToString(dr["Occupation"]),
                        //Image_FileName = Convert.ToString(dr["Image_FileName"]),
                        //Image_FilePath = Convert.ToString(dr["Image_FilePath"]),
                        //P_AddressLine1 = Convert.ToString(dr["P_AddressLine1"]),
                        //P_AddressLine2 = Convert.ToString(dr["P_AddressLine2"]),
                        //P_AddressStateCode = Convert.ToInt32(dr["P_AddressStateCode"]),
                        //P_AddressDistrictCode = Convert.ToInt32(dr["P_AddressDistrictCode"]),
                        //P_AddressPIN = Convert.ToString(dr["P_AddressPIN"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                        Organization_MainObjects = Convert.ToString(dr["Organization_MainObjects"]),
                        RegOffice_AddressLine1 = Convert.ToString(dr["RegOffice_AddressLine1"]),
                        RegOffice_AddressLine2 = Convert.ToString(dr["RegOffice_AddressLine2"]),
                        RegOffice_AddressStateCode = Convert.ToInt32(dr["RegOffice_AddressStateCode"]),
                        RegOffice_AddressDistrictCode = Convert.ToInt32(dr["RegOffice_AddressDistrictCode"]),
                        RegOffice_AddressPIN = Convert.ToInt32(dr["RegOffice_AddressPIN"]),
                        BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                        BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                        BusinessPlace_AddressStateCode = Convert.ToInt32(dr["BusinessPlace_AddressStateCode"]),
                        BusinessPlace_AddressDistrictCode = Convert.ToInt32(dr["BusinessPlace_AddressDistrictCode"]),
                        BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),
                        IsSameBussinessAdd_CommAdd = ((dr["IsSameBussinessAdd_CommAdd"] as string == "1") ? true : false),
                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                        BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),
                        AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                        AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                        AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        PAN_Number = Convert.ToString(dr["PAN_Number"]),
                        Aadhaar_Number = Convert.ToInt64(dr["Aadhaar_Number"]),
                        IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                        IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }

        public List<ClsprpRera_Agent_OtherMemberDetail> DisplayAgentOthermemberDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_OtherMember_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);



            connection();
            List<ClsprpRera_Agent_OtherMemberDetail> list_indPro = new List<ClsprpRera_Agent_OtherMemberDetail>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpRera_Agent_OtherMemberDetail
                    {
                        Agent_OtherMemberDetails_ID = Convert.ToInt64(dr["Agent_OtherMemberDetails_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Designation = Convert.ToString(dr["Designation"]),
                        OtherMember_Name = Convert.ToString(dr["OtherMember_Name"]),
                        OtherMember_PAN_Number = Convert.ToString(dr["OtherMember_PAN_Number"]),
                        OtherMember_Aadhaar_Number = Convert.ToString(dr["OtherMember_Aadhaar_Number"]),
                        OfficeComm_AddressLine1 = Convert.ToString(dr["OfficeComm_AddressLine1"]),
                        OfficeComm_AddressLine2 = Convert.ToString(dr["OfficeComm_AddressLine2"]),
                        OfficeComm_AddressStateCode = Convert.ToInt32(dr["OfficeComm_AddressStateCode"]),
                        OfficeComm_AddressDistrictCode = Convert.ToInt32(dr["OfficeComm_AddressDistrictCode"]),
                        OfficeComm_AddressPIN = Convert.ToInt32(dr["OfficeComm_AddressPIN"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                        PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                        PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        Image_FileName = Convert.ToString(dr["Image_FileName"]),
                        Image_FilePath = Convert.ToString(dr["Image_FilePath"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



        }

        public List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> DisplayOtherStateUTAgentDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_OtherStateUTAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);



            //connection();
            List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> list_indPro = new List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpRERA_Agent_OtherStateUT_regRERAdetails
                    {
                        Agent_OtherStateUT_regRERA_IndexID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_IndexID"]),
                        Agent_OtherStateUT_regRERA_ID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        StateCode = Convert.ToInt32(dr["StateCode"]),
                        RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                        RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                        RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                        ImageRERAcert_FileName = Convert.ToString(dr["ImageRERAcert_FileName"]),
                        ImageRERAcert_FilePath = Convert.ToString(dr["ImageRERAcert_FilePath"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;




        }

        public List<CLSprpAgent_Payment> DisplayAgentDetailPayment(Int64 Agent_ID) //, Int64 AgentPayment_ID
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayRERA_Agent_Payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("p_AgentPayment_ID", AgentPayment_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            connection();
            List<CLSprpAgent_Payment> list_indPro = new List<CLSprpAgent_Payment>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new CLSprpAgent_Payment
                    {
                        AgentPayment_IndexID = Convert.ToInt64(dr["AgentPayment_IndexID"]),
                        AgentPayment_ID = Convert.ToInt64(dr["AgentPayment_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                        AgentPayment_TitleName = Convert.ToString(dr["AgentPayment_TitleName"]),
                        Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                        Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                        Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                        Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                        Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                        Bank_Name = Convert.ToString(dr["Bank_Name"]),
                        Branch_Name = Convert.ToString(dr["Branch_Name"]),
                        DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                        DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                        ImageDDorBankersCheque_FileName = Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                        ImageDDorBankersCheque_FilePath = Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        //A_column = Convert.ToString(dr["A_column"]),
                        //B_column = Convert.ToString(dr["B_column"]),
                        //C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["CreatedOn"]),//  Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;



        }
    }
}