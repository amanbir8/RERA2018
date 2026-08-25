using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_ParentEntityDetail
    {
        public long ID { get; set; }

        public long PromoterParentEntity_ID { get; set; }

        public long Application_ID { get; set; }

        // [Required(ErrorMessage = "Do you have any Past Experience?(Yes/No)")]
        [Display(Name = "Do you have any Past Experience?")]
        public string Promoter_IsPastExperience { get; set; }

        [Required(ErrorMessage = "Name of Parent Entity is required.")]
        [Display(Name = "Name of Parent Entity")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Name_of_Parent_Entity { get; set; }

        [Required(ErrorMessage = "Type of Enterprise is required.")]
        [Display(Name = "Type of Enterprise")]
        public string Type_of_Enterprise { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Main Objects of Parent Entity is required.")]
        [Display(Name = "Main Objects of Parent Entity")]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string Main_Objects_of_Parent_Entity { get; set; }

        [Required(ErrorMessage = "Registered Address is required.")]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegisteredAddress { get; set; }

        //[Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line2 { get; set; }

        [Required(ErrorMessage = "Name of State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Name of District is required.")]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code.")]
        public long Pin_Code { get; set; }

        [Required(ErrorMessage = "Number of years of experience of the Parent Entity in real estate Punjab is required.")]
        [Display(Name = "Number of Years (In Punjab)")]
        [Range(0, 500)]
        public Nullable<int> Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_Punjab { get; set; }

        [Required(ErrorMessage = "Number of years of experience of the Parent Entity in real estate UT/Other state is required.")]
        [Display(Name = "Number of Years (In UT/Other state)")]
        [Range(0, 500)]
        public Nullable<int> Number_of_years_of_experience_of_the_Parent_Entity_in_real_estate_UT_State { get; set; }


        [Display(Name = "Upload Company Registration Certificate of Parent Entity")]
        public string Upload_Company_Registration_Certificate_of_Parent_Entity { get; set; }

        public string CompanyRegCert_Image_FileName { get; set; }


        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<ClsPrp_ParentEntityDetail> Prpparententity { get; set; }

    }
}