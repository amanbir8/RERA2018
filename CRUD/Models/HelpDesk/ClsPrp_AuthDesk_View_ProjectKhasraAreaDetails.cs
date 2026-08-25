using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ProjectKhasraAreaDetails
    {
        public long ProjectKhasraArea_IndexID { get; set; }
        public long ProjectKhasraArea_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectKhasraAreaRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Khasra Number of Land proposed to be developed")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]        
        public string KhasraNumber_ProposedLand_TobeDeveloped { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0.0001, 999999999999.9999)]
        [Display(Name = "Area of Land proposed under Khasra Nnumber (in sqr mtrs)")]
        public double Area_ProposedLand_EachKhasraNumber { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name of Villages under Khasra Nnumber")]
        [StringLength(500, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]

        public string A_column { get; set; }

        [Required]
        [Display(Name = "Project Land Status")]
        public string B_column { get; set; } 
               
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_AuthDesk_View_ProjectKhasraAreaDetails> prpongoing { get; set; }

        public ClsPrp_AuthDesk_View_ProjectKhasraAreaDetails()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ProjectKhasraAreaDetails>();

        }
        //public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
    }
}