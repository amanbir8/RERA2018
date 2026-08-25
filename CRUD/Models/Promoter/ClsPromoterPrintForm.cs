using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using CRUD.Models.HelpDesk;

namespace CRUD.Models.Promoter
{
    public class ClsPromoterPrintForm
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        public Int64 Application_id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string First_Name { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Middle_Name { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Father's Name is required.")]
        [Display(Name = "Father First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_First_Name { get; set; }

        [Display(Name = "Father Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_Middle_Name { get; set; }

        [Required(ErrorMessage = "Father's last name is required.")]
        [Display(Name = "Father Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_Last_Name { get; set; }

        [Display(Name = "Occupation")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line2 { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Int64 Pin_Code { get; set; }

        [Required(ErrorMessage = "Mobile No. is required.")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public Int64 Mobile_no { get; set; }

        [Display(Name = "Phone No. STD")]
        public Nullable<Int64> Phone_No_STD { get; set; }

        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number")]
        public Nullable<Int64> Phone_No { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email Id")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Email { get; set; }

        [Display(Name = "WebLink of Promoter")]
        //[DataType(DataType.Url)]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string WebLink_Promoter_website { get; set; }


        [Display(Name = "Years of Experience of Promoter in Real Estate Development in Punjab")]
        [Range(0, 500)]
        public int Past_Exp_Punjab { get; set; }

        [Display(Name = "Years of Experience of Promoter in Real Estate Development in Other states or UTs")]
        [Range(0, 500)]
        public int Past_Exp_Other_States { get; set; }

        [Required(ErrorMessage = "PAN Number is required.")]
        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        //[System.Web.Mvc.Remote("CheckPromoterPANcard", "Promoter", ErrorMessage = "PAN number already exist, Try another", AdditionalFields = "Application_id")]
        public string PAN_No { get; set; }

        //[Required(ErrorMessage = "PAN Copy is required.")]
        [Display(Name = "Upload PAN Copy")]
        public string PAN_Doc_Address { get; set; }

        //[Required(ErrorMessage = "Photograph is required.")]
        [Display(Name = "Upload Photograph of Promoter")]
        public string Photo_Address { get; set; }

        //[Required(ErrorMessage = "Aadhaar is required.")]
        [Display(Name = "Aadhaar Number of Promoter")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number of Promoter")]
        public Int64 Aadhaar { get; set; }

        [Required(ErrorMessage = "Any past Experience(Yes/No) field is required.")]
        [Display(Name = "Do you have any past Experience?")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Completed Projects is required.")]
        [Display(Name = "Number of Completed Projects in Last Five Years")]
        [Range(0, 500)]
        public Int32 Ind_Org_CompltdProj_FiveYrs { get; set; }


        [Required(ErrorMessage = "Total area Constructed is required.")]
        [Display(Name = "Total Area Constructed under all such projects")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Area; Maximum Two Decimal Points.")]
        [Range(0, 999999999999.99)]
        public Decimal Ind_Org_TotalArea_Constructed { get; set; }

        [Required(ErrorMessage = "Ongoing Projects is required.")]
        [Display(Name = "Number of Ongoing Projects")]
        [Range(0, 500)]
        public Int32 Ind_Org_OngoingProjects { get; set; }

        [Required(ErrorMessage = "Area to be Constructed is required.")]
        [Display(Name = "Area to be Constructed under such projects")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Area; Maximum Two Decimal Points.")]
        [Range(0, 999999999999.99)]
        public Decimal Ind_Org_AreaToBe_Constructed { get; set; }

        public string Image_FileName { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modified_On { get; set; }

        public int Flag { get; set; }

        // [Required(ErrorMessage = "Last Five Years Experience is required.")]
        public string Last_FiveYr_Exp { get; set; }

        // [Required(ErrorMessage = "Ongoing Experience is required.")]
        public string Ongoing_Exp { get; set; }
        //public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        //[Required(ErrorMessage = "Litigation Related to Project is required.")]
        //[Display(Name = "Any Litigation Related to Project")]
        public string IsLitigation_RelatedProject { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<Clsprp_Promoter> promoter { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }

  
        public List<ClsPrp_OngoingProjectLFiveYears> prpongoing { get; set; }
        public List<ClsPrp_Promoter_Litigations> prpLitigations { get; set; }
        public List<Clsprp_AuthorityDesk_PromoterDocuments> promoterDoc { get; set; }



        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }


        public int IsDraftpromoterindividualprofile { get; set; }


        //other than Indiviual properties
        /// <summary>
        /// Registered Address
        /// </summary>

        // [Required(ErrorMessage = "Litigation Related to Project is required.")]
        //[Display(Name = "Any Litigation Related to Project")]

        public ClsPromoterPrintForm DisplayIndPro(Int64 Application_id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayIndProForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            connection();
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPromoterPrintForm clspro = new ClsPromoterPrintForm();

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
                if (!dr.IsNull("Aadhaar"))
                  clspro.Aadhaar = Convert.ToInt64(dr["Aadhaar"]);
                clspro.Experience = Convert.ToString(dr["Experience"]);
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

        //public List<ClsPrp_OngoingProjectLFiveYears> DisplaybyID_ongoingProject(Int64 Application_id)
        //{
        //    connection();
        //    List<ClsPrp_OngoingProjectLFiveYears> ProjectFivelist = new List<ClsPrp_OngoingProjectLFiveYears>();

        //    MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Experince_Complete_ongoingByApplicationID", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("p_Application_id", Application_id);
        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ProjectFivelist.Add(
        //            new ClsPrp_OngoingProjectLFiveYears
        //            {
        //                Id = Convert.ToInt32(dr["Id"]),
        //                Application_id = Convert.ToInt64(dr["Application_id"]),
        //                Projectname = Convert.ToString(dr["Projectname"]),
        //                ProjectType = Convert.ToString(dr["ProjectType"]),
        //                ProjectStatus = Convert.ToString(dr["ProjectStatus"]),
        //                AreaConUProject = Convert.ToDouble(dr["AreaConUProject"]),
        //                ProjectStartDate = Convert.ToDateTime(dr["ProjectStartDate"]),
        //                OCDateProject = Convert.ToDateTime(dr["OCDateProject"]),
        //                ACDProject = Convert.ToDateTime(dr["ACDProject"]),
        //                RExtentofDelayProject = Convert.ToString(dr["RExtentofDelayProject"]),
        //                TypeLandofProject = Convert.ToString(dr["TypeLandofProject"]),
        //                LitgToProject = Convert.ToString(dr["LitgToProject"]),

        //                CaseTitle = Convert.ToString(dr["CaseTitle"]),
        //                CaseNumber = Convert.ToString(dr["CaseNumber"]),
        //                NameofAuthorityForumwhereCasisPendingresolved = Convert.ToString(dr["NameofAuthorityForumwhereCasisPendingresolved"]),
        //                IsPaymentDetailsPending_RelatedLand = Convert.ToString(dr["IsPaymentDetailsPending_RelatedLand"]),
        //                DetailPaymentPendingProject = Convert.ToString(dr["DetailPaymentPendingProject"]),

        //                IsActive = Convert.ToInt32(dr["IsActive"]),
        //                IsDraft = Convert.ToInt32(dr["Flag"]),
        //                Created_On = Convert.ToDateTime(dr["Created_On"]),
        //                Created_By = Convert.ToString(dr["Created_By"]),
        //                Modified_On = Convert.ToDateTime(dr["Modified_On"]),
        //                Modify_By = Convert.ToString(dr["Modify_By"]),

        //            });
        //    }
        //    return ProjectFivelist;
        //}
        //public List<ClsPrp_Promoter_Litigations> DisplayLitigationn(Int64 Promoter_ID)
        //{
        //    List<ClsPrp_Promoter_Litigations> ProjectFivelist = new List<ClsPrp_Promoter_Litigations>();

        //    connection();
        //    MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_LitigationApplicationID", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);

        //    connection();
        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    sd.Fill(dt);
        //    ClsPrp_Promoter_Litigations clspro = new ClsPrp_Promoter_Litigations();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ProjectFivelist.Add(
        //           new ClsPrp_Promoter_Litigations
        //           {
        //               Promoter_Litigations_IndexID = Convert.ToInt32(dr["Promoter_Litigations_IndexID"]),
        //               Promoter_Litigation_ID = Convert.ToInt64(dr["Promoter_Litigation_ID"]),
        //               Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
        //               //LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
        //               LitigationsRelated_ProjectName = Convert.ToString(dr["Projectname"]),
        //               Case_Title = Convert.ToString(dr["Case_Title"]),
        //               Case_Number = Convert.ToString(dr["Case_Number"]),
        //               Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),
        //               //IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //               //CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //               //ModifyBy = Convert.ToString(dr["ModifyBy"]),

        //               IsActive = Convert.ToInt32(dr["IsActive"]),
        //               IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //               Created_On = Convert.ToDateTime(dr["Created_On"]),
        //               Created_By = Convert.ToString(dr["Created_By"]),
        //               Modified_On = Convert.ToDateTime(dr["Modified_On"]),
        //               Modify_By = Convert.ToString(dr["Modify_By"]),

        //           });

        //    }


        //    return ProjectFivelist;

        //    ////int i = cmd.ExecuteNonQuery();
        //    ////con.Close();

        //    //// if (i >= 1)
        //    ////    return true;
        //    //// else
        //    ////     return false;
        //}


        //Lock-Unlock Method (Individual Profile)
        public Int32 Update_LockUnLockHandler_Promoter_IndividualProfileDetails(Int64 ProjectID, Int64 PromoterID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_promoter_individualprofiledetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_ProfileIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

    }
}