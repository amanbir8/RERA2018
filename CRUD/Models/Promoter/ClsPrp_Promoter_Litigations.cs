using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_Promoter_Litigations
    {
        public long Promoter_Litigations_IndexID { get; set; }
        public long Promoter_Litigation_ID { get; set; }
        public long Promoter_ID { get; set; }

        [Required(ErrorMessage = "Litigations Related to project required")]
        [Display(Name = "Project Name")]
        [StringLength(80)]
        public string LitigationsRelated_ProjectName { get; set; }

        [Required(ErrorMessage = "Case Title of Litigations required")]
        [Display(Name = "Case Title")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Case_Title { get; set; }

        [Required(ErrorMessage = "Case Number of Litigations required")]
        [Display(Name = "Case Number")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Case_Number { get; set; }

        [Required(ErrorMessage = "Authority Forum Name where Case is Pending/Resolved required")]
        [Display(Name = "Authority Forum Name where Case is Pending/Resolved")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string Authority_ForumName_CasePendingResolved { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int Flag { get; set; }
        public string Created_By { get; set; }
        public System.DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public System.DateTime Modified_On { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public List<ClsPrp_Promoter_Litigations> prpongoing { get; set; }

        public List<ClsPrp_OngoingProjectLFiveYears> Prp_Project_Name { get; set; }

    }
}