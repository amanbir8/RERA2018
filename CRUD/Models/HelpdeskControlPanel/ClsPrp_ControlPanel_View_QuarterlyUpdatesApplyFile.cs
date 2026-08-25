using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_QuarterlyUpdatesApplyFile
    {
        public long QUP_ProjectProvider_IndexID { get; set; }
        public long QUP_ProjectProvider_ID { get; set; }

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
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERA_RegistrationID { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string DiaryNumber_Project { get; set; }

        [Display(Name = "Extension of Registration Diary Number")]
        public string DiaryNumber_ExtensionProject { get; set; }

        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }

        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReferenceDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Remarks, If Any")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "From Date (Locked)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Locked_From_Date { get; set; }

        [Display(Name = "To Date (Locked)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Locked_To_Date { get; set; }

        public string A_column { get; set; }
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

        public List<ClsPrp_ControlPanel_View_QuarterlyUpdatesApplyFile> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_QuarterlyUpdatesApplyFile()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_QuarterlyUpdatesApplyFile>();
        }
    }
}