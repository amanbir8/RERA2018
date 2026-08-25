using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_QuarterlyUpdatesList
    {
        public long QUpdateProject_RegDNProvider_IndexID { get; set; }
        public long QUpdateProject_RegDNProvider_ID { get; set; }

        [Required(ErrorMessage = "Quarter Year is required.")]
        [Display(Name = "Quarter Year")]
        public int QUpdateProject_Year { get; set; }

        [Required(ErrorMessage = "Quarter Name is required.")]
        [Display(Name = "Quarter Name")]
        public string QUpdateProject_QuarterName { get; set; }

        public string UserID { get; set; }
        public long PromoterID { get; set; }
        public long ProjectID { get; set; }

        [Required]
        [Display(Name = "Remarks, If Any")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Apply Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? A_column { get; set; }

        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }

        [Required(ErrorMessage = "Locked Confirmed (Yes/No) is required.")]
        [Display(Name = "Locked Confirmed (Yes/No)?")]
        [Range(0, 1)]
        public int IsActiveProvider { get; set; }

        [Required]
        [Display(Name = "Locked Enable?")]
        [Range(0, 1)]
        public int IsLock { get; set; }

        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }


        public string RoleAccessFlag { get; set; }
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }

        [Required]
        [Display(Name = "Quarter Year")]     
        public int InputEntry_QuarterYear { get; set; }
        [Required]
        [Display(Name = "Quarter Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string InputEntry_QuarterName { get; set; }


        public List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_QuarterlyUpdatesList()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_QuarterlyUpdatesList>();
        }
    }
}