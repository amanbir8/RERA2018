using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm
    {
        public long Project_ApplySuperLockUnlock_IndexID { get; set; }
        public long Project_ApplySuperLockUnlock_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        public string Related_User_ID { get; set; }
        public long Related_Reference_ID { get; set; }


        [Required(ErrorMessage = "Project Name is required.")]
        [Display(Name = "Project Name")]
        [StringLength(120, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,120}$", ErrorMessage = "Special characters are not allowed. Maximum length is 120")]
        public string Project_Name { get; set; }
        [Required(ErrorMessage = "Promoter Name is required.")]
        [Display(Name = "Promoter Name")]
        [StringLength(120, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,120}$", ErrorMessage = "Special characters are not allowed. Maximum length is 120")]
        public string Promoter_Name { get; set; }


        [Required(ErrorMessage = "Registration Number is required.")]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required(ErrorMessage = "Registration Issue Date is required.")]
        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required(ErrorMessage = "Registration Valid Upto Date is required.")]
        [Display(Name = "Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }


        [Display(Name = "Diary Number")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string ProjectRegDiaryNumber_Name { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegDiary_ApplicationDate { get; set; }


        public DateTime? A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        [Range(0, 1)]
        public int IsPromoterConfirmed { get; set; }
        [Range(0, 1)]
        public int IsCoPromoterConfirmed { get; set; }
        [Range(0, 1)]
        public int IsQuarterlyUpdatesConfirmed { get; set; }
        [Range(0, 1)]
        public int IsProjectConfirmed { get; set; }

        public int MappingYear { get; set; }
        [Range(0, 1)]
        public int IsYearMappingConfirmed { get; set; }

        [Range(0, 1)]
        public int IsLockPromoterDN { get; set; }
        [Range(0, 1)]
        public int IsLockProjectDN { get; set; }
        [Range(0, 1)]
        public int IsLockQtrDN { get; set; }
        [Range(0, 1)]
        public int IsLockCoPromoterDn { get; set; }
        [Range(0, 1)]
        public int IsLockAdditional { get; set; }
        
        [Required(ErrorMessage = "Locked Confirmed (Yes/No) is required.")]
        [Display(Name = "Locked Confirmed (Yes/No)?")]
        [Range(0, 1)]
        public int IsLockedConfirmed { get; set; }

        [Required(ErrorMessage = "Locked Enable (Yes/No) is required.")]
        [Display(Name = "Locked Enable?")]
        [Range(0, 1)]
        public int IsLockedEnable { get; set; }           
                
             
        public string RoleAccessFlag { get; set; }
        [Display(Name = "Search By")]
        public int Application_SearchTypeFlag { get; set; }

        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string InputEntry_RegistrationNumber { get; set; }

        [Display(Name = "Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string InputEntry_ProjectDiaryNumber { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectSuperLockUnlockApplyConfirm>();
        }
    }
}