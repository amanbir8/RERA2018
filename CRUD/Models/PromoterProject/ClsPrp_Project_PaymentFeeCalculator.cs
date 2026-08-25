using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Master;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_PaymentFeeCalculator
    {
        public long RelatedProject_ID { get; set; }
        public long RelatedPromoter_ID { get; set; }

        [Required]
        [Display(Name = "Project Zone")]
        public long calcFeeCalculator_ZoneType { get; set; }

        [Required]
        [Display(Name = "Application Fee Type")]
        public int calcProjectPayment_TitleCode { get; set; }

        [Required]
        [Display(Name = "Total Area of Land Proposed to be developed (in sqr mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        public double calcProposedLand_TobeDeveloped_Area_Total { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under group housing development excluding common areas and ameneties")]
        public double calcProposedLand_Area_ResidentialGroupHousing { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under residential plotted development excluding common areas and ameneties")]
        public double calcProposedLand_Area_ResidentialPlotted { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under commercial development excluding common areas and ameneties")]
        public double calcProposedLand_Area_Commercial { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under industrial development excluding common areas and ameneties")]
        public double calcProposedLand_Area_Industrial { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under common amenties servicing the entire project")]
        public double calcProposedLand_Area_CommonAmenties { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under Institution/Club/School/Reserved Area")]
        public double calcProposedLand_Area_OtherCommonAmenties { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under EWS development")]
        public double calcProposedLand_Area_EWSdevelopment { get; set; }

        [Display(Name = "Fee Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 999999999.99)]
        public decimal setRegistration_Fee { get; set; }

        [Display(Name = "Annual web-portal Convenience Fee (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 999999999.99)]
        public decimal setOther_Fee { get; set; }

        [Display(Name = "Bank Charges (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 999999999.99)]
        public decimal setBank_Charges { get; set; }

        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(8000.00, 999999999.99)]
        public decimal setDD_BankersCheque_Amount { get; set; }

        
        public List<ClsPrp_Project_PaymentFeeCalculator> prpongoing { get; set; }
        public ClsPrp_Project_PaymentFeeCalculator()
        {
            prpongoing = new List<ClsPrp_Project_PaymentFeeCalculator>();

        }

        public List<ClsPrp_Master_PaymentType> PayFeeMaster { get; set; }
    }
}