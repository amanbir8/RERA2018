using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterPrint
{
    public class Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm
    {

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
        public string PAN_No { get; set; }

        [Display(Name = "Upload PAN Copy")]
        public string PAN_Doc_Address { get; set; }

        public string Image_FileName { get; set; }

        [Display(Name = "Do you have any past Experience?")]
        public string Experience { get; set; }

        [Display(Name = "Do you have any Joint Promoter?")]
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
        public string IsOtherOrganizationMembers { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modified_On { get; set; }


        public int Flag { get; set; }
        public string Last_FiveYr_Exp { get; set; }        
        public string Ongoing_Exp { get; set; }
        [Required(ErrorMessage = "Any Parent Entity (Yes/No) is required.")]
        public string Org_Parent_Entity { get; set; }        
        public string IsLitigation_RelatedProject { get; set; }
        public string Extra4 { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipPromoterLastModifiedOn { get; set; }


        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster1 { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }


        public List<ClsPrp_OrgExp> promoter { get; set; }

        public List<ClsPrp_ParentEntityDetail> Prpparententity { get; set; }
        public List<ClsPrp_OrgMemDetail> prpMem { get; set; }
        public List<ClsPrp_OngoingProjectLFiveYears> prpTrackRecord { get; set; }
        public List<ClsPrp_Promoter_Litigations> prpLitigations { get; set; }

        public List<Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm> prpongoingTR { get; set; }       

    }
}