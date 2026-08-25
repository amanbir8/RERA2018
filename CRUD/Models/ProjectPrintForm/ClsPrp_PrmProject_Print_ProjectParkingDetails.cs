using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectPrint
{
    public class ClsPrp_PrmProject_Print_ProjectParkingDetails
    {
        public long ProjectParking_IndexID { get; set; }
        public long ProjectParking_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectParkingRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Type of Parking")]
        public string ParkingType { get; set; }
        
        [Display(Name = "Number of Parking Space available for Sale")]
        [Range(0, 50000)]
        public int ParkingSpace_AvailableforSale_Number { get; set; }

        [Required]
        [Display(Name = "Total Area of Parking Space (in sqr Mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Invalid Area; Maximum Three Decimal Points.")]
        [Range(0.001, 999999999.999)]
        public double ParkingSpace_Area_Total { get; set; }

        [Display(Name = "Number of Parking Space Booked or Sold")]
        [Range(0, 50000)]
        public int ParkingSpace_BookedSold_Number { get; set; }

        [Display(Name = "Remarks if any?")]
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


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }



        public List<ClsPrp_PrmProject_Print_ProjectParkingDetails> prpongoing { get; set; }
        public ClsPrp_PrmProject_Print_ProjectParkingDetails()
        {
            prpongoing = new List<ClsPrp_PrmProject_Print_ProjectParkingDetails>();

        }

        public List<ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails> prpProjectDiaryNumberDetails { get; set; }
    }
}