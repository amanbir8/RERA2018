using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone
    {
        public int Zone_IndexID { get; set; }
        public int Zone_ID { get; set; }

        [Required]
        [Display(Name = "Zone Code")]
        public int Zone_TitleCode { get; set; }

        [Required]
        [Display(Name = "Zone Description")]
        [StringLength(450, ErrorMessage = "Maximum length is 450")]
        public string Zone_TitleName { get; set; }

        [Display(Name = "State Name")]
        public int Zone_StateID { get; set; }

        [Required]
        [Display(Name = "Zone Name")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string Mode { get; set; }

        [Required]
        [Display(Name = "Reference (Regulation and Development) Rules")]
        public string ActRegulationReference { get; set; }

        [Required]
        [Display(Name = "Residential Plotted (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal ResidentialPlotted_ChargesPerSquareYard { get; set; }

        [Required]
        [Display(Name = "Group Housing (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal GroupHousing_ChargesPerSquareYard { get; set; }

        [Required]
        [Display(Name = "Commercial (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal Commercial_ChargesPerSquareYard { get; set; }

        [Required]
        [Display(Name = "Industrial (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal Industrial_ChargesPerSquareYard { get; set; }

        [Required]
        [Display(Name = "Common Area (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal CommonArea_ChargesPerSquareYard { get; set; }

        [Required]
        [Display(Name = "Club/School Buliding (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal ClubSchoolBuliding_ChargesPerSquareYard { get; set; }

        [Required]
        [Display(Name = "EWS (charges per square yard)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal EWS_ChargesPerSquareYard { get; set; }

        public decimal A_ChargesPerSquareYard { get; set; }
        public decimal B_ChargesPerSquareYard { get; set; }
        public int Fee_ValidCode { get; set; }

        [Required]
        [Display(Name = "Remarks, If Any")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string RemarksIfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }

        [Display(Name = "Is Locked (Yes/No)?")]
        public int IsLock { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }

        public List<ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone>();
        }        
    }
}