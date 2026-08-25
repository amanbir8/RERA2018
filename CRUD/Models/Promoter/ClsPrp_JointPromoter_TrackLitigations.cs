using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_JointPromoter_TrackLitigations
    {
        public long JointPromoter_Litigations_IndexID { get; set; }
        public long JointPromoter_Litigation_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public int Related_PromoterType { get; set; }

        [Display(Name = "Joint-Promoter Name")]
        public long Related_JointPromoter_ID { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public int Related_JointPromoterType { get; set; }

        [Required(ErrorMessage = "Litigations Related to Joint-Promoter required")]
        [Display(Name = "Joint-Promoter Name")]
        [StringLength(120)]
        public string LitigationsRelated_JointPromoterName { get; set; }

        [Required(ErrorMessage = "Litigations Related to Project required")]
        [Display(Name = "Reference Litigations of Project Name")]
        [StringLength(120)]
        public string LitigationsRelated_ProjectName { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Project Name is required.")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Project_Name { get; set; }

        [Display(Name = "Project Type")]
        [Required(ErrorMessage = "Project Type is required.")]
        public string Project_Type { get; set; }

        [Display(Name = "Project Status")]
        [Required(ErrorMessage = "Project Status is required.")]
        public string Project_Status { get; set; }

        [Display(Name = "Constructed Area under the Project (in sqr mtrs)")]
        [Required(ErrorMessage = "Constructed under the Project (Sqr mtr) is required.")]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0.0001, 999999999999.9999)]
        public double Project_AreaConstructed { get; set; }


        [Required(ErrorMessage = "Case Title of Litigations required")]
        [Display(Name = "Case Title")]
        [StringLength(120, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Case_Title { get; set; }

        [Required(ErrorMessage = "Case Number of Litigations required")]
        [Display(Name = "Case Number")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Case_Number { get; set; }

        [Required(ErrorMessage = "Authority Forum Name where Case is Pending/Resolved required")]
        [Display(Name = "Authority Forum Name where Case is Pending/Resolved")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Authority_ForumName_CasePendingResolved { get; set; }

        [Required(ErrorMessage = "Is Litigations (Yes/No)? field is required")]
        [Display(Name = "Is Litigations (Yes/No)?")]
        public int JointPromoter_LitigationsFlag { get; set; }
        public int JointPromoter_LitigationsCondition { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int Flag { get; set; }
        public string Created_By { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_On { get; set; }
        public string Modify_By { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Modified_On { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public List<ClsPrp_JointPromoter_TrackLitigations> prpongoing { get; set; }
        public ClsPrp_JointPromoter_TrackLitigations()
        {
            prpongoing = new List<ClsPrp_JointPromoter_TrackLitigations>();
        }

        public List<ClsPrp_OngoingProjectLFiveYears> Prp_Project_Name { get; set; }
        public List<ClsPrp_JointPromoter_RegistrationDetails> Prp_JointPromoter_Name { get; set; }
    }
}