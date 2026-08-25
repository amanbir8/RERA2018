using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterPrint
{
    public class ClsPrp_PrmPromoter_Print_DiaryNumberDetails
    {

        public long PromoterRegDiaryNumber_IndexID { get; set; }
        public long PromoterRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }
        public string PromoterRegDiaryNumber_NameYear { get; set; }
        public long Promoter_ID { get; set; }
        public string UserID { get; set; }

        public int ParentEntityCount { get; set; }
        public int OtherOrgMemberCount { get; set; }
        public int TrackRecordCount { get; set; }
        public int LitigationCount { get; set; }
        public int PromoterDocumentCount { get; set; }

        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        
        public long zipRelated_Promoter_ID { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipPromoterLastModifiedOn { get; set; }        


        public List<ClsPrp_PrmPromoter_Print_DiaryNumberDetails> prpongoing { get; set; }

        public ClsPrp_PrmPromoter_Print_DiaryNumberDetails()
        {
            prpongoing = new List<ClsPrp_PrmPromoter_Print_DiaryNumberDetails>();

        }        
    }
}