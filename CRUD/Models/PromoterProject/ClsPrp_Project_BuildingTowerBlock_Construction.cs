using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_BuildingTowerBlock_Construction
    {
        public long ProjectConstruction_IndexID { get; set; }
        public long ProjectConstruction_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectConstructionRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Building/Tower/Block Name")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string BuildingTowerBlock_Name { get; set; }

        [Required]
        [Display(Name = "Number of Floor/Plots Proposed")]
        [Range(1, 500)]
        public int Proposed_FloorPlotsNumber { get; set; }

        [Required]
        [Display(Name = "Number of Floor/Plots Currently Sanctioned")]
        [Range(0, 500)]
        public int CurrentlySanctioned_FloorPlotsNumber { get; set; }

        [Required]
        [Display(Name = "Number of Floors Constructed")]
        [Range(0, 500)]
        public int Constructed_FloorsNumber { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string A_column { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string B_column { get; set; }

        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_Project_BuildingTowerBlock_Construction> prpongoing { get; set; }

        public ClsPrp_Project_BuildingTowerBlock_Construction()
        {
            prpongoing = new List<ClsPrp_Project_BuildingTowerBlock_Construction>();

        }
        
     public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
        

    }
}