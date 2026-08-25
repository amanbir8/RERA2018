using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectPrint
{
    public class ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails
    {
        public long QUpdateProjectParking_IndexID { get; set; }
        public long QUpdateProjectParking_ID { get; set; }

        public long Related_ProjectParking_IndexID { get; set; }
        public long Related_ProjectParking_ID { get; set; }

        public int IsQuarterlyData { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long Related_ParkingProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string QUpdateParking_Year { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string QUpdateParking_QuarterName { get; set; }

        [Required]
        [Display(Name = "Type of Parking")]
        public string ParkingType { get; set; }

        [Required]
        [Display(Name = "Total Area of Parking Space (in sqr Mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Invalid Area; Maximum Three Decimal Points.")]
        [Range(0, 999999999.999)]
        public double ParkingSpaceUnits_TotalArea { get; set; }

        [Display(Name = "Total Number of Parking Units")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_NumberAvailableforSale { get; set; }

        [Display(Name = "Number of Parking Units sold upto the date of Registration")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_NumberBookedSoldUptoRegistration { get; set; }

        [Required]
        [Display(Name = "Number of Parking Units booked in the Quarter")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_NumberBookedInQuarter { get; set; }

        [Required]
        [Display(Name = "Number of Parking Units under canceled booking in the Quarter")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_NumberCanceledBookedInQuarter { get; set; }

        [Required]
        [Display(Name = "Number of Parking Units sold in the Quarter")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_NumberSoldInQuarter { get; set; }

        [Required]
        [Display(Name = "Total Booked")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_TotalNumberBooked { get; set; }

        [Required]
        [Display(Name = "Total Sold")]
        [Range(0, 50000)]
        public int ParkingSpaceUnits_TotalNumberSold { get; set; }

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


        public List<ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails> prpongoing { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails()
        {
            prpongoing = new List<ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails>();
        }
        public List<ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails> prpQUProjectDiaryNumberDetails { get; set; }
    }
}