using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_JointPromoter_Confirm_ReviewMaster
    {
        public long JointPromoter_Confirm_Step_IndexID { get; set; }
        public long JointPromoter_Confirm_Step_ID { get; set; }

        public long Related_JointPromoter_ID { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public int Related_JointPromoter_Type { get; set; }
        public string Related_JointPromoter_DiaryNumber { get; set; }
        [Display(Name = "Joint-Promoter's Name")]
        public string Related_JointPromoter_Name { get; set; }

        public string Related_RegistrationNumber { get; set; }        

        public string Related_Promoter_DiaryNumber { get; set; }
        public long Related_Promoter_ID { get; set; }
        public int Related_Promoter_Type { get; set; }
        public string Related_Promoter_Name { get; set; }

        public string Registration_OtherMember_YN_Flag { get; set; }
        public string Registration_OtherParentEntity_YN_Flag { get; set; }
        public string Registration_OtherExperience_YN_Flag { get; set; }
        public string Registration_OtherLitigations_YN_Flag { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsFlag { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }
        public int IsDraftMember { get; set; }

        public List<ClsPrp_JointPromoter_Confirm_ReviewMaster> JointPromoter_list { get; set; }
        public ClsPrp_JointPromoter_Confirm_ReviewMaster()
        {
            JointPromoter_list = new List<ClsPrp_JointPromoter_Confirm_ReviewMaster>();
        }

        //public List<ClsPrp_JointPromoter_ExtractDetails_ReviewMaster> JointPromoter_extractlistMaster { get; set; }
    }

    public class ClsPrp_JointPromoter_ExtractDetails_ReviewMaster
    {
        public long Related_JointPromoter_ID { get; set; }
        public int Related_JointPromoter_Type { get; set; }
        public string Related_JointPromoter_DiaryNumber { get; set; }
        public string Related_JointPromoter_Name { get; set; }

        public string Related_RegistrationNumber { get; set; }

        public string Related_Promoter_DiaryNumber { get; set; }
        public long Related_Promoter_ID { get; set; }
        public int Related_Promoter_Type { get; set; }
        public string Related_Promoter_Name { get; set; }

        public string Registration_OtherMember_YN_Flag { get; set; }
        public string Registration_OtherParentEntity_YN_Flag { get; set; }
        public string Registration_OtherExperience_YN_Flag { get; set; }
        public string Registration_OtherLitigations_YN_Flag { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }

        public List<ClsPrp_JointPromoter_ExtractDetails_ReviewMaster> JointPromoter_extractlist { get; set; }
        public ClsPrp_JointPromoter_ExtractDetails_ReviewMaster()
        {
            JointPromoter_extractlist = new List<ClsPrp_JointPromoter_ExtractDetails_ReviewMaster>();
        }
    }
}
