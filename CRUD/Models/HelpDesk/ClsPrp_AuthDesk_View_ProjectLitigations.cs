using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ProjectLitigations
    {
        public long ProjectLitigations_IndexID { get; set; }
        public long ProjectLitigations_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long LitigationsRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Case Title")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string Case_Title { get; set; }

        [Required]
        [Display(Name = "Case Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string Case_Number { get; set; }

        [Required]
        [Display(Name = "Name of Authority/Forum where Case is Pending/resolved")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[\/0-9a-zA-Z\s,()-.]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorityForumName_CasePendingResolved { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }

        public int IsDraftProjectLitigations { get; set; }

        public List<ClsPrp_AuthDesk_View_ProjectLitigations> prpongoing { get; set; }
        public ClsPrp_AuthDesk_View_ProjectLitigations()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ProjectLitigations>();

        }
        //public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
        public List<Clsprp_AuthDesk_View_ProjectDocuments> ProjectDocumentsList { get; set; }
    }
}