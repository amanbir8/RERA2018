using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_OrgExp
    {

        //Tbl_Promoter
        public Int64 Application_id { get; set; }

        [Required(ErrorMessage = "Organization name is required.")]
        [Display(Name = "Name of Organization")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Org_Name { get; set; }

        [Required(ErrorMessage = "Organization Type is required.")]
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Main Objects of Organization is required.")]
        [Display(Name = "Main Objects of Organization")]
        [StringLength(400, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,400}$", ErrorMessage = "Special characters are not allowed. Maximum length is 400")]
        public string Org_Objects { get; set; }


        /// <summary>
        /// Registered Address
        /// </summary>
        [Required(ErrorMessage = "Registered Address of Organization is required.")]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Org_Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
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

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email of Authorised Signatory")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "WebLink of Promoter/Parent Website is required.")]
        [Display(Name = "WebLink of Promoter/Parent Website ")]
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
        [Display(Name = "PAN Number of Organization")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        //[System.Web.Mvc.Remote("CheckPromoterPANcard", "Promoter", ErrorMessage = "PAN number already exist, Try another", AdditionalFields = "Application_id")]
        public string PAN_No { get; set; }

        [Display(Name = "Upload PAN Copy")]
        public string PAN_Doc_Address { get; set; }

        //[Display(Name = "Upload PAN Copy")]
        public string Image_FileName { get; set; }

        [Required(ErrorMessage = "Any past Experience(Yes/No) field is required.")]
        [Display(Name = "Do you have any past Experience?")]
        public string Experience { get; set; }

        [Display(Name = "Do you have any Joint Promoter?")]
        public string Org_Reg_Certificate { get; set; }

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


        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster1 { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_OrgExp> promoter { get; set; }
    }
}