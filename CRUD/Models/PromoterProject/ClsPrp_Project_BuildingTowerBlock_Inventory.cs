using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_BuildingTowerBlock_Inventory
    {
        public long ProjectInventory_IndexID { get; set; }
        public long ProjectInventory_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectInventoryRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Building/ Tower/ Block Name")]
        public string BuildingTowerBlock_Name { get; set; }

        [Required]
        [Display(Name = "Type of Apartment/Shop/Plot")]
        [StringLength(100)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string ApartmentShopPlot_Type { get; set; }

        [Required]
        [Display(Name = "Carpet Area of Apartment/ Shop/ Plot (in sqr mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Invalid Area; Maximum Three Decimal Points.")]
        [Range(0.001, 999999999.999)]
        public double ApartmentShopPlot_CarpetArea { get; set; }

        [Display(Name = "Exclusive Open Terrace Area (in sqr mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Invalid Area; Maximum Three Decimal Points.")]
        [Range(0, 999999999.999)]
        public Nullable<double> ApartmentShopPlot_ExclusiveOpenTerraceArea { get; set; }


        [Display(Name = "Area of the Exclusive Balcony or Verandah (in sqr mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Invalid Area; Maximum Three Decimal Points.")]
        [Range(0, 999999999.999)]
        public Nullable<double> ApartmentShopPlot_ExclusiveBalconyVerandahArea { get; set; }

        [Required]
        [Display(Name = "Total Number of Apartment/ Shop/ Plot")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_AvailableforSaleNumber { get; set; }

        [Required]
        [Display(Name = "Number of Apartment/Shop/Plot already sold")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_AlreadySoldNumber { get; set; }

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

        public List<ClsPrp_Project_BuildingTowerBlock_Inventory> prpongoing { get; set; }
        public ClsPrp_Project_BuildingTowerBlock_Inventory()
        {
            prpongoing = new List<ClsPrp_Project_BuildingTowerBlock_Inventory>();

        }
        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }

        public List<ClsPrp_Project_BuildingTowerBlock_Construction> MasterBuilding { get; set; }
    }
}