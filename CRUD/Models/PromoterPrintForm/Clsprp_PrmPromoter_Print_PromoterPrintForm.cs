using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterPrint
{
    public class Clsprp_PrmPromoter_Print_PromoterPrintForm
    {

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

        public string Image_FileName { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modified_On { get; set; }

        public int Flag { get; set; }
        public string Last_FiveYr_Exp { get; set; }        
        public string Ongoing_Exp { get; set; }        
        public string Extra4 { get; set; }        
        public string IsLitigation_RelatedProject { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }        
        public List<ClsPrp_StateMaster> stateMaster { get; set; }

        public List<Clsprp_Promoter> promoter { get; set; }
        public List<ClsPrp_OngoingProjectLFiveYears> prpongoing { get; set; }
        public List<ClsPrp_Promoter_Litigations> prpLitigations { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipPromoterLastModifiedOn { get; set; }

        public List<Clsprp_PrmPromoter_Print_PromoterPrintForm> prpongoingTR { get; set; }
    }
}