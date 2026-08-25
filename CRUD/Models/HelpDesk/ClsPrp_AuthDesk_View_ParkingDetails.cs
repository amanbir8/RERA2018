using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ParkingDetails
    {
        public long ProjectParking_IndexID { get; set; }
        public long ProjectParking_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectParkingRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Type of Parking")]
        public string ParkingType { get; set; }
        
        [Display(Name = "Total Number of Parking Space")]
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

        public List<ClsPrp_AuthDesk_View_ParkingDetails> prpongoing { get; set; }
        public ClsPrp_AuthDesk_View_ParkingDetails()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ParkingDetails>();

        }        
    }
}