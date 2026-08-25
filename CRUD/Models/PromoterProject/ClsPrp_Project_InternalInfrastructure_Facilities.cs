using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_InternalInfrastructure_Facilities
    {
        public long ProjectInfrastructureFacilities_IndexID { get; set; }
        public long ProjectInfrastructureFacilities_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Internal Infrastructure Facilities Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.()\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string InternalInfrastructureFacilities_Name { get; set; }
         
        [Display(Name = "Internal Infrastructure Facilities Type")]
        public string InternalInfrastructureFacilities_Type { get; set; }
         
        [Display(Name = "External Agency Local Authority Name")]
        public string ExternalAgency_LocalAuthority_Name { get; set; }

        [Display(Name = "Is Internal Infrastructure Facilities Applicable")]
        public string Is_InternalInfrastructureFacilitiesApplicable { get; set; }

        [Required]
        [Display(Name = "Work Progress % Percentage")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Work Progress(% age); Maximum Two Decimal Points.")]
        [Range(0, 100)]
        public decimal WorkProgress_Percentage { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Internal Infrastructure Facilities Details")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.()\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string InternalInfrastructureFacilities_Details { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string A_column { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_Project_InternalInfrastructure_Facilities> prpongoing { get; set; }
        public ClsPrp_Project_InternalInfrastructure_Facilities()
        {
            prpongoing = new List<ClsPrp_Project_InternalInfrastructure_Facilities>();

        }

        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }


    }
}