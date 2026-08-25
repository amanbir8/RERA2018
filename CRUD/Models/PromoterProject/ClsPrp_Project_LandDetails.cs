using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_LandDetails
    {
        public long ProjectLand_IndexID { get; set; }
        public long ProjectLand_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectLandRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Total Area of Land Proposed to be developed (in sqr mtrs)")]
        //[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "It cannot have more than four decimal point value")]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0.0001, 999999999999.9999)]
        public double ProposedLand_TobeDeveloped_Area_Total { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under group housing development excluding common areas and ameneties")]
        public double ProposedLand_Area_ResidentialGroupHousing { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under residential plotted development excluding common areas and ameneties")]
        public double ProposedLand_Area_ResidentialPlotted { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under commercial development excluding common areas and ameneties")]
        public double ProposedLand_Area_Commercial { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under industrial development excluding common areas and ameneties")]
        public double ProposedLand_Area_Industrial { get; set; }

        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under common amenties servicing the entire project")]
        public double ProposedLand_Area_A_column { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under institution, club, school and reserved area development excluding common areas and ameneties")]
        public double ProposedLand_Area_B_column { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under EWS development excluding common areas and ameneties")]
        public double ProposedLand_Area_C_column { get; set; }

        public double ProposedLand_Area_D_column { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name of Villages")]
        [StringLength(500, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string Name_of_Villages { get; set; }
        
        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        //[Display(Name = "Total Open Area under Land Proposed to be Developed")]
        [Display(Name = "Area of Land Owned by Promoter")]
        public double ProposedLand_TobeDeveloped_TotalOpenArea { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        //[Display(Name = "Total Covered Area under Land Proposed to be Developed")]
        [Display(Name = "Area of Land Not Owned by Promoter")]
        public double ProposedLand_TobeDeveloped_TotalCoveredArea { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Longitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Longitude of Start point of proposed project land")]
        public double ProposedProjectLand_StartPoint_Longitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Latitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Latitude of Start point of proposed project land")]
        public double ProposedProjectLand_StartPoint_Latitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Longitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Longitude of End point of proposed project land")]
        public double ProposedProjectLand_EndPoint_Longitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Latitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Latitude of End point of proposed project land")]
        public double ProposedProjectLand_EndPoint_Latitude { get; set; }
        //[Required]
        [Display(Name = "Project Land Status")]
        public string IsProjectLand_Status_OwnedByPromoter { get; set; }
        //[Required]
        [Display(Name = "Project Land Status - Not Owned By Promoter")]
        public string IsProjectLand_Status_NotOwnedByPromoter { get; set; }
        [Required]
        [Display(Name = "Is there Any Project Land Encumbrances?")]
        public string IsLandEncumbrances_IfAny { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime CreatedOn { get; set; }

        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
        public List<ClsPrp_Project_LandDetails> prpongoing { get; set; }

        public ClsPrp_Project_LandDetails()
        {
            prpongoing = new List<ClsPrp_Project_LandDetails>();

        }
        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
    }
}