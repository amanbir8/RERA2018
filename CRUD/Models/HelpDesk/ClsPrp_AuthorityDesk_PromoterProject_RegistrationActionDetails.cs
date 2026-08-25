using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails
    {
        public long ProjectRegistrationActionOne_ID { get; set; }
        public string ProjectRegistrationActionTwo_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }

        [Display(Name = "Promoter Name")]
        public string PromoterName { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Promoter Diary Number")]
        public string Promoter_DiaryNumber { get; set; }
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Project Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_ApplicationDate { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectLastModifiedOn { get; set; }

        [Required]
        [Display(Name = "Project Registration Number")]
        public string Project_RegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Registration_IssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Valid Upto")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Registration_ValidUptoDate { get; set; }


        [Display(Name = "Action Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationActionDate { get; set; }
        [Display(Name = "Action Title")]
        public string RegistrationActionTitle { get; set; }
        [Display(Name = "Prepared By")]
        public string IdentifiedBy { get; set; }
        [Required]
        [Display(Name = "Diary Number/ RERA Number/ PUC Number")]
        public string Project_DiaryNumber_RERANumber_PUCNumber { get; set; }
        [Required]
        [Display(Name = "Dated")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_Diarydated_RERAdated_PUCdated { get; set; }        
        [Display(Name = "Registration Valid Upto")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RegistrationValidUptoDate { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }        
        
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        public List<ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails>();
        }        
    }
}