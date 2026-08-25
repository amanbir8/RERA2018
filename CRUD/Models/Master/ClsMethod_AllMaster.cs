using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.Master
{

    public class ClsMethod_AllMaster
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }


        /// <summary>
        /// Display only for Master ApplicationFee
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Master_ApplicationFee> Display_Master_ApplicationFee( )
        {
            connection();
            List<ClsPrp_Master_ApplicationFee> ApplicationFee = new List<ClsPrp_Master_ApplicationFee>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ApplicationFee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ApplicationFee.Add(
                    new ClsPrp_Master_ApplicationFee
                    {
                        Fee_TitleName = Convert.ToString(dr["Fee_TitleName"]),
                        Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                        Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                        Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                        Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                        Fee_ValidCode = Convert.ToInt16(dr["Fee_ValidCode"]),
                        Fee_ValidType = Convert.ToInt16(dr["Fee_ValidType"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return ApplicationFee;
        }

        /// <summary>
        /// Display only for Master EventActionDetails
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Master_EventActionDetails> Display_Master_EventActionDetailse()
        {
            connection();
            List<ClsPrp_Master_EventActionDetails> EventActionDetails = new List<ClsPrp_Master_EventActionDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_EventActionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                EventActionDetails.Add(
                    new ClsPrp_Master_EventActionDetails
                    {
                        EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                        EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                        EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                        Target_ResolutionDuration = Convert.ToInt16(dr["Target_ResolutionDuration"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
  
                    });
            }
            return EventActionDetails;
        }

        /// <summary>
        /// Display only for Master Organization Type
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Master_OrganizationType> Display_Master_OrganizationType()
        {
            connection();
            List<ClsPrp_Master_OrganizationType> OrganizationType = new List<ClsPrp_Master_OrganizationType>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_EventActionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                OrganizationType.Add(
                    new ClsPrp_Master_OrganizationType
                    {
                        Org_TypeName = Convert.ToString(dr["Org_TypeName"]),
                        OrgType_ValidCode = Convert.ToInt16(dr["OrgType_ValidCode"]),
                        OrgType_ValidType = Convert.ToInt16(dr["OrgType_ValidType"]),
                        
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                         
 
                    });
            }
            return OrganizationType;
        }

        /// <summary>
        /// Display only for Master Project Type
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Master_ProjectType> Display_Master_ProjectType()
        {
            connection();
            List<ClsPrp_Master_ProjectType> ProjectType = new List<ClsPrp_Master_ProjectType>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ProjectType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectType.Add(
                    new ClsPrp_Master_ProjectType
                    {
                        PromoterProject_TypeName = Convert.ToString(dr["PromoterProject_TypeName"]),
                        UserType_ValidCode = Convert.ToInt16(dr["UserType_ValidCode"]),
                        PromoterProjectType_ValidCode = Convert.ToInt16(dr["PromoterProjectType_ValidCode"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        


                    });
            }
            return ProjectType;
        }
        /// <summary>
        /// Display only for Master Project Land Type
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Master_ProjectLandType> Display_Master_ProjectLandType()
        {
            connection();
            List<ClsPrp_Master_ProjectLandType> ProjectLandType = new List<ClsPrp_Master_ProjectLandType>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ProjectType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectLandType.Add(
                    new ClsPrp_Master_ProjectLandType
                    {
                        PromoterProjectLand_TypeName = Convert.ToString(dr["PromoterProjectLand_TypeName"]),
                        UserType_ValidCode = Convert.ToInt16(dr["UserType_ValidCode"]),
                        PromoterProjectLandType_ValidCode = Convert.ToInt16(dr["PromoterProjectLandType_ValidCode"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
 

    });
            }
            return ProjectLandType;
        }

        /// <summary>
        /// Display only for Master State Name 
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Master_StateDetails> Display_Master_StateDetails()
        {
            connection();
            List<ClsPrp_Master_StateDetails> StateDetails = new List<ClsPrp_Master_StateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_StateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                StateDetails.Add(
                    new ClsPrp_Master_StateDetails
                    {
                        State_Name = Convert.ToString(dr["State_Name"]),
                        
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),


                    });
            }
            return StateDetails;
        }

        public List<ClsPrp_Master_BankDetails> Display_Master_BankDetails()
        {
            connection();
            List<ClsPrp_Master_BankDetails> BankDetails = new List<ClsPrp_Master_BankDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_BankDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                BankDetails.Add(
                    new ClsPrp_Master_BankDetails
                    {

                        Bank_Code = Convert.ToInt32(dr["Bank_Code"]),
                        BankName = Convert.ToString(dr["Bank_Name"]),

                        //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),


                    });
            }
            return BankDetails;
        }
        
        /// <summary>
        /// Payment Type Master
        /// </summary>
        /// <returns>Collection List PayCode PayName</returns>
        public List<ClsPrp_Master_PaymentType> Display_Master_PaymentType()
        {
            connection();
            List<ClsPrp_Master_PaymentType> PaymentTypeDetails = new List<ClsPrp_Master_PaymentType>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_PaymentType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PaymentTypeDetails.Add(
                    new ClsPrp_Master_PaymentType
                    {

                        PaymentType_Code = Convert.ToInt32(dr["PaymentType_Code"]),
                        PaymentType = Convert.ToString(dr["PaymentType"]),

                        //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),


                    });
            }
            return PaymentTypeDetails;
        }

        public List<ClsPrp_Master_PaymentType> Display_Master_PaymentTypeByCode(Int32 PaymentForCode, Int32 PaymentGroupCode)
        {
            connection();
            List<ClsPrp_Master_PaymentType> PaymentTypeDetails = new List<ClsPrp_Master_PaymentType>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_PaymentTypeForCode", con);
            cmd.Parameters.AddWithValue("p_PaymentType_PaymentForCode", PaymentForCode);
            cmd.Parameters.AddWithValue("p_PaymentType_PaymentGroupCode", PaymentGroupCode);

            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PaymentTypeDetails.Add(
                    new ClsPrp_Master_PaymentType
                    {

                        PaymentType_Code = Convert.ToInt32(dr["PaymentType_Code"]),
                        PaymentType = Convert.ToString(dr["PaymentType"]),

                        //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),


                    });
            }
            return PaymentTypeDetails;
        }

    }
}