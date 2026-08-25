using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile
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
        public string RERA_RegistrationID { get; set; }
        public string DiaryNumber_Project { get; set; }
        public string DiaryNumber_ExtensionProject { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }

        [Required]
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


        //Project Parms (Registration, Extension of Registration)
        public long RelatedPromoter_ID { get; set; }
        public long RelatedProject_ID { get; set; }
        public string User_ID { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsExtensionRegistration { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? RERAnumberExtensionRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string ProjectDiaryNumber { get; set; }

        [Display(Name = "Extension of Registration Diary Number")]
        public string ExtensionRegdDiaryNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Required]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Display(Name = "Project Address District")]
        public string DName { get; set; }

        [Required]
        [Display(Name = "Type of Project")]
        public string ProjectType { get; set; }



        //Input Parms
        public string RoleAccessFlag { get; set; }

        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }        
        [Display(Name = "Quarter Year")]     
        public int InputEntry_QuarterYear { get; set; }
        [Display(Name = "Quarter Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string InputEntry_QuarterName { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string InputEntry_RegistrationNumber { get; set; }


        public List<ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_QuarterlyUpdatesProjectFile>();
        }
    }
}