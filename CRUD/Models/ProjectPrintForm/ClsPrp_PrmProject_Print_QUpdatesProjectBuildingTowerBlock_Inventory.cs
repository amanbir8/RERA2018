using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectPrint
{
    public class ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory
    {
        public long QUpdateProjectInventory_IndexID { get; set; }
        public long QUpdateProjectInventory_ID { get; set; }

        public long Related_ProjectInventoryIndexID { get; set; }
        public long Related_ProjectInventory_ID { get; set; }

        public int IsQuarterlyData { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long Related_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string QUpdateInventory_Year { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string QUpdateInventory_QuarterName { get; set; }

        [Required]
        [Display(Name = "Building/ Tower/ Block Name")]
        public string BuildingTowerBlock_Name { get; set; }

        [Required]
        [Display(Name = "Type of Apartment/Shop/Plot")]
        [StringLength(100)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string ApartmentShopPlot_Type { get; set; }

        [Required]
        [Display(Name = "Type of Inventory Details")] //(Apartment/ Commercial/ Individual House/ Plots/ Others)
        public string ApartmentShopPlot_InventoryType { get; set; }

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
        public int ApartmentShopPlot_NumberAvailableforSale { get; set; }

        [Required]
        [Display(Name = "Number of Apartment/Shop/Plot sold upto the date of Registration")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_NumberSoldUptoRegistration { get; set; }

        [Required]
        [Display(Name = "Number of Floors Constructed/ Plots/ Others in the Quarter")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_NumberFloorsConstructedInQuarter { get; set; }

        [Display(Name = "Number of Foundations/Basements Constructed in the Quarter")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter { get; set; }

        [Required]
        [Display(Name = "Number of Apartment/Shop/Plot booked in the Quarter")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_NumberBookedInQuarter { get; set; }

        [Required]
        [Display(Name = "Number of Apartment/Shop/Plot canceled booking in the Quarter")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_NumberCanceledBookedInQuarter { get; set; }

        [Required]
        [Display(Name = "Number of Apartment/Shop/Plot sold in the Quarter")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_NumberSoldInQuarter { get; set; }

        [Required]
        [Display(Name = "Total Number of Floors Constructed/ Plots/ Others")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_TotalNumberFloorsConstructed { get; set; }

        [Required]
        [Display(Name = "Total Booked")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_TotalNumberBooked { get; set; }

        [Required]
        [Display(Name = "Total Sold")]
        [Range(0, 50000)]
        public int ApartmentShopPlot_TotalNumberSold { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsRegisteredDiaryNumberLock { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }


        public List<ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory> prpongoing { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory()
        {
            prpongoing = new List<ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory>();
        }
        public List<ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails> prpQUProjectDiaryNumberDetails { get; set; }
    }
}