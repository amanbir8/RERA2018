using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using CRUD.Models.HelpDesk;

namespace CRUD.Models.Promoter
{
    public class ClsPromoterOrgExpPrintForm
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        public Int64 Application_id { get; set; }

        [Display(Name = "Name of Organization")]
        public string Org_Name { get; set; }
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }
        [Display(Name = "Main Objects of Organization")]
        public string Org_Objects { get; set; }


        /// <summary>
        /// Registered Address
        /// </summary>
        [Display(Name = "Address Line 1")]
        public string Org_Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Org_Address_Line2 { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string Org_State { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public string Org_District { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Int64 Org_Pin_Code { get; set; }


        /// <summary>
        /// Office Address
        /// </summary>
        [Required(ErrorMessage = "Official Address of Organization is required.")]
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


        /// <summary>
        /// Details of Authorised signatory, who will sign form B
        /// </summary>
        [Required(ErrorMessage = "Name of Authorised signatory is required.")]
        [Display(Name = "Name of Authorised Signatory")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string First_Name { get; set; }


        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile No. of Authorised Signatory")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public Int64 Mobile_no { get; set; }

        [Display(Name = "Landline Number of Authorised Signatory")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number")]
        public Nullable<Int64> Phone_No { get; set; }

        //[Required(ErrorMessage = "STD Code is required.")]
        [Display(Name = "STD Code")]
        public Nullable<Int64> Phone_No_STD { get; set; }


        [Display(Name = "Email of Authorised Signatory")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "WebLink of Promoter/Parent Website is required.")]
        [Display(Name = "WebLink of Promoter/Parent Website ")]
        public string WebLink_Promoter_website { get; set; }

        [Display(Name = "Years of Experience of Promoter in Real Estate Development in Punjab")]     
        public int Past_Exp_Punjab { get; set; }

        [Display(Name = "Years of Experience of Promoter in Real Estate Development in Other states or UTs")]
        [Range(0, 500)]
        public int Past_Exp_Other_States { get; set; }


        [Display(Name = "PAN Number of Organization")]      
        //[System.Web.Mvc.Remote("CheckPromoterPANcard", "Promoter", ErrorMessage = "PAN number already exist, Try another", AdditionalFields = "Application_id")]
        public string PAN_No { get; set; }

        [Display(Name = "Upload PAN Copy")]
        public string PAN_Doc_Address { get; set; }

        //[Display(Name = "Upload PAN Copy")]
        public string Image_FileName { get; set; }


        [Display(Name = "Do you have any past Experience?")]
        public string Experience { get; set; }

        [Display(Name = "Company Registered Certificate")]
        public string Org_Reg_Certificate { get; set; }


        [Display(Name = "Number of Completed Projects in Last Five Years")]  
        public Int32 Ind_Org_CompltdProj_FiveYrs { get; set; }

 
        [Display(Name = "Total Area Constructed under all such projects")]    
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

        [Required(ErrorMessage = "Annual Report consisting of Audited P & L, Balance Sheet, Cash Flow Statements (Yes/No) is required.")]
        //[Display(Name = "Do you have any Organization Members")]
        public string IsOtherOrganizationMembers { get; set; }


        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modified_On { get; set; }


        //public int IsActive { get; set; }
        //public string Created_By { get; set; }
        //public System.DateTime Created_On { get; set; }
        //public string Modify_By { get; set; }
        //public Nullable<System.DateTime> Modified_On { get; set; }


        public int Flag { get; set; }

        // [Required(ErrorMessage = "Last Five Years Experience is required.")]
        public string Last_FiveYr_Exp { get; set; }

        // [Required(ErrorMessage = "Ongoing Experience is required.")]
        public string Ongoing_Exp { get; set; }

        [Required(ErrorMessage = "Any Parent Entity (Yes/No) is required.")]
        public string Org_Parent_Entity { get; set; }

        // [Required(ErrorMessage = "Litigation Related to Project is required.")]
        //[Display(Name = "Any Litigation Related to Project")]
        public string IsLitigation_RelatedProject { get; set; }

        public string Extra4 { get; set; }



        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }



        public int IsDraftpromotertrack { get; set; }
        public int IsDraftpromoterlitigation { get; set; }

        public int IsDraftpromoterprofile { get; set; }        
        public int IsDraftpromoterparententity { get; set; }
        public int IsDraftpromotermember { get; set; }


        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster1 { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_OrgExp> promoter { get; set; }
        public List<Clsprp_AuthorityDesk_PromoterDocuments> promoterDoc { get; set; }

        public List<ClsPrp_ParentEntityDetail> Prpparententity { get; set; }

        public ClsPromoterOrgExpPrintForm DisplayOrgExp(Int64 Application_id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("DisplayRegExpForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            connection();
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPromoterOrgExpPrintForm clspro = new ClsPromoterOrgExpPrintForm();

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

            return clspro;
        }

        public List<ClsPrp_OrgMemDetail> prpMem { get; set; }
        public List<ClsPrp_OngoingProjectLFiveYears> prpongoing { get; set; }
        public List<ClsPrp_Promoter_Litigations> prpLitigations { get; set; }

        //Method
        public List<ClsPrp_ParentEntityDetail> DisplayDetailByApplicationID(Int64 Application_id)
        {
            List<ClsPrp_ParentEntityDetail> ParentEntityDetail = new List<ClsPrp_ParentEntityDetail>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_ParentEntityByApplicationIDForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);

            connection();
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

        public List<ClsPrp_OrgMemDetail> Display_MemProject(Int64 applicationid)
        {
            connection();
            List<ClsPrp_OrgMemDetail> ProjectFivelist1 = new List<ClsPrp_OrgMemDetail>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_OtherMemberDetailsByApplicationIDForDesk", con);
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
                        Image_FileName = Convert.ToString(dr["Image_FileName"]),
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

        public List<ClsPrp_OngoingProjectLFiveYears> DisplaybyID_ongoingProject(Int64 Application_id)
        {
            connection();
            List<ClsPrp_OngoingProjectLFiveYears> ProjectFivelist = new List<ClsPrp_OngoingProjectLFiveYears>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Exp_Complete_ongoingByApplicationIDForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Application_id", Application_id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                    new ClsPrp_OngoingProjectLFiveYears
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Application_id = Convert.ToInt64(dr["Application_id"]),
                        Projectname = Convert.ToString(dr["Projectname"]),
                        ProjectType = Convert.ToString(dr["ProjectType"]),
                        ProjectStatus = Convert.ToString(dr["ProjectStatus"]),
                        AreaConUProject = Convert.ToDouble(dr["AreaConUProject"]),
                        ProjectStartDate = Convert.ToDateTime(dr["ProjectStartDate"]),
                        OCDateProject = Convert.ToDateTime(dr["OCDateProject"]),
                        ACDProject = Convert.ToDateTime(dr["ACDProject"]),
                        RExtentofDelayProject = Convert.ToString(dr["RExtentofDelayProject"]),
                        TypeLandofProject = Convert.ToString(dr["TypeLandofProject"]),
                        LitgToProject = Convert.ToString(dr["LitgToProject"]),

                        CaseTitle = Convert.ToString(dr["CaseTitle"]),
                        CaseNumber = Convert.ToString(dr["CaseNumber"]),
                        NameofAuthorityForumwhereCasisPendingresolved = Convert.ToString(dr["NameofAuthorityForumwhereCasisPendingresolved"]),
                        IsPaymentDetailsPending_RelatedLand = Convert.ToString(dr["IsPaymentDetailsPending_RelatedLand"]),
                        DetailPaymentPendingProject = Convert.ToString(dr["DetailPaymentPendingProject"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["Flag"]),
                        Created_On = Convert.ToDateTime(dr["Created_On"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),

                    });
            }
            return ProjectFivelist;
        }
        public List<ClsPrp_Promoter_Litigations> DisplayLitigationn(Int64 Promoter_ID)
        {
            List<ClsPrp_Promoter_Litigations> ProjectFivelist = new List<ClsPrp_Promoter_Litigations>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_LitigationApplicationIDForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);

            connection();
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_Promoter_Litigations clspro = new ClsPrp_Promoter_Litigations();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                   new ClsPrp_Promoter_Litigations
                   {
                       Promoter_Litigations_IndexID = Convert.ToInt32(dr["Promoter_Litigations_IndexID"]),
                       Promoter_Litigation_ID = Convert.ToInt64(dr["Promoter_Litigation_ID"]),
                       Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                       //LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
                       LitigationsRelated_ProjectName = Convert.ToString(dr["Projectname"]),
                       Case_Title = Convert.ToString(dr["Case_Title"]),
                       Case_Number = Convert.ToString(dr["Case_Number"]),
                       Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),
                       //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                       //ModifyBy = Convert.ToString(dr["ModifyBy"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),

                   });

            }
            return ProjectFivelist;
        }

        public List<Clsprp_AuthorityDesk_PromoterDocuments> Display_AuthDesk_Promoter_Documents_PromoterId(Int64 PromoterId)
        {
            connection();
            List<Clsprp_AuthorityDesk_PromoterDocuments> Promoter_Documents_PromoterId = new List<Clsprp_AuthorityDesk_PromoterDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Documents_PromoterId_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_AuthorityDesk_PromoterDocuments
                    {
                        PromoterDoc_IndexID = Convert.ToInt64(dr["PromoterDoc_IndexID"]),
                        PromoterDoc_ID = Convert.ToInt64(dr["PromoterDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        PromoterDoc_InfoCode = Convert.ToInt32(dr["PromoterDoc_InfoCode"]),
                        PromoterDoc_InfoName = Convert.ToString(dr["PromoterDoc_InfoName"]),
                        PromoterDoc_ReferenceNumber = Convert.ToString(dr["PromoterDoc_ReferenceNumber"]),
                        PromoterDoc_IssueDate = Convert.ToDateTime(dr["PromoterDoc_IssueDate"]),
                        PromoterDoc_FileSize = Convert.ToString(dr["PromoterDoc_FileSize"]),
                        PromoterDoc_FileFormat = Convert.ToString(dr["PromoterDoc_FileFormat"]),
                        PromoterDoc_FilePath = Convert.ToString(dr["PromoterDoc_FilePath"]),
                        PromoterDoc_FileName = Convert.ToString(dr["PromoterDoc_FileName"]),
                        PromoterDoc_IsGroup = Convert.ToInt32(dr["PromoterDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return Promoter_Documents_PromoterId;
        }


        //Lock-Unlock Method (OtherThanInd Profile)
        public Int32 Update_LockUnLockHandler_Promoter_OtherThanIndProfileDetails(Int64 ProjectID, Int64 PromoterID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_promoter_otherthanindprofiledetails", con);
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

        //Lock-Unlock Method (ParentEntity)
        public Int32 Update_LockUnLockHandler_Promoter_ParentEntityDetails(Int64 ProjectID, Int64 PromoterID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_promoter_parententitydetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_ParentEntityIndexID", IndexID);
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

        //Lock-Unlock Method (Org Members)
        public Int32 Update_LockUnLockHandler_Promoter_OrgMembersDetails(Int64 ProjectID, Int64 PromoterID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_promoter_organizationmemberdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_PromoterMemberIndexID", IndexID);
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

        //Lock-Unlock Method (Track)
        public Int32 Update_LockUnLockHandler_Promoter_TrackRecordDetails(Int64 ProjectID, Int64 PromoterID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_promoter_trackrecorddetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_PromoterTrackIndexID", IndexID);
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

        //Lock-Unlock Method (Litigation)
        public Int32 Update_LockUnLockHandler_Promoter_LitigationDetails(Int64 ProjectID, Int64 PromoterID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_promoter_litigationdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_PromoterLitigationIndexID", IndexID);
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