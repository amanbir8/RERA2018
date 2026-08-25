using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterPrint
{
    public class ClsPrp_JointPromoter_Print_TrackLitigations
    {
        public long JointPromoter_Litigations_IndexID { get; set; }
        public long JointPromoter_Litigation_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public int Related_PromoterType { get; set; }

        [Display(Name = "Joint-Promoter Name")]
        public long Related_JointPromoter_ID { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public int Related_JointPromoterType { get; set; }
        [Display(Name = "Joint-Promoter Name")]
        public string LitigationsRelated_JointPromoterName { get; set; }

        [Display(Name = "Reference Litigations of Project Name")]
        public string LitigationsRelated_ProjectName { get; set; }
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Project Type")]
        public string Project_Type { get; set; }
        [Display(Name = "Project Status")]
        public string Project_Status { get; set; }
        [Display(Name = "Constructed Area under the Project (in sqr mtrs)")]
        public double Project_AreaConstructed { get; set; }

        [Display(Name = "Case Title")]
        public string Case_Title { get; set; }
        [Display(Name = "Case Number")]
        public string Case_Number { get; set; }
        [Display(Name = "Authority Forum Name where Case is Pending/Resolved")]
        public string Authority_ForumName_CasePendingResolved { get; set; }

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


        // Application ID
        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_JointPromoter_ID { get; set; }

        // Application Date
        [Display(Name = "Promoter Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Promoter_ApplicationDate { get; set; }
        [Display(Name = "Joint-Promoter Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JointPromoter_ApplicationDate { get; set; }

        // Promoter Name/Diary Number
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }

        // Joint-Promoter Name/Diary Number
        [Display(Name = "Joint-Promoter Diary Number")]
        public string zipJointPromoter_DiaryNumber { get; set; }
        [Display(Name = "Joint-Promoter Name")]
        public string zipJointPromoterName { get; set; }

        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipJointPromoterLastModifiedOn { get; set; }


        public List<ClsPrp_JointPromoter_Print_TrackLitigations> prpongoingTL { get; set; }
        public ClsPrp_JointPromoter_Print_TrackLitigations()
        {
            prpongoingTL = new List<ClsPrp_JointPromoter_Print_TrackLitigations>();
        }

        public List<Clsprp_JointPromoter_Print_ProfileForm> Prp_JointPromoter_Name { get; set; }
    }
}