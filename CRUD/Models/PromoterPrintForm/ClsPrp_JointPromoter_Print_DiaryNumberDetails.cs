using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterPrint
{
    public class ClsPrp_JointPromoter_Print_DiaryNumberDetails
    {
        public long JointPromoter_RegDiaryNumber_IndexID { get; set; }

        public long Promoter_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string Promoter_RegDiaryNumber_Name { get; set; }        
        public string Promoter_RegDiaryNumber_NameYear { get; set; }

        public long JointPromoter_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string JointPromoter_RegDiaryNumber_Name { get; set; }
        public string JointPromoter_RegDiaryNumber_NameYear { get; set; }

        public long Promoter_ID { get; set; }
        public int Promoter_Type { get; set; }

        public long JointPromoter_ID { get; set; }
        public int JointPromoter_Type { get; set; }
        public string UserID { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

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

        public List<ClsPrp_JointPromoter_Print_DiaryNumberDetails> prpongoing { get; set; }
        public ClsPrp_JointPromoter_Print_DiaryNumberDetails()
        {
            prpongoing = new List<ClsPrp_JointPromoter_Print_DiaryNumberDetails>();
        } 
               
    }
}