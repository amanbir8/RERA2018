using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent
    {
        public long ProjectExtFormOne_ID { get; set; }
        public string ProjectExtFormTwo_ID { get; set; }             

        public long Related_ProjectExtension_ID { get; set; }
        [Display(Name = "Form-E Diary Number")]
        public string ProjectExtension_DiaryNumber { get; set; }
        [Display(Name = "Form-E Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectExtension_ApplicationDate { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string Promoter_DiaryNumber { get; set; }
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Project Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_ApplicationDate { get; set; }                

        [Display(Name = "Promoter Name")]
        public string PromoterName { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Project Approval Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_ApprovalDate { get; set; }
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


        public List<ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent> prpongoing { get; set; }
        public ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent()
        {
            prpongoing = new List<ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent>();
        }

        public List<ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails> ProjectRegistrationActionDetails { get; set; }
        //public List<ClsPrp_AuthDesk_View_ProjectRegistration> PromoterProfile { get; set; }
        public List<ClsPrp_AuthDesk_View_ProjectRegistration> ProjectRegistration { get; set; }
        public List<ClsPrp_AuthDesk_View_ProjectPayment> ProjectRegistrationFee { get; set; }
    }
}