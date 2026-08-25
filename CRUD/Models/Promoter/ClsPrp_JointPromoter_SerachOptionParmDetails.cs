using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_JointPromoter_SearchOptionParamDetails
    {        
        [Display(Name = "Promoter Name")]
        public string SearchOption_RelatedPromoterName { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string Promoter_DiaryNumber_Name { get; set; }

        [Display(Name = "Project Name")]
        public string SearchOption_RelatedProjectName { get; set; }
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber_Name { get; set; }

        [Display(Name = "Name of Joint-Promoter")]
        public string JointPromoter_Name { get; set; }
        [Display(Name = "Joint-Promoter Diary Number")]
        public string JointPromoter_DiaryNumber_Name { get; set; }

        public List<ClsPrp_JointPromoter_SearchOptionParamDetails> prpproperty { get; set; }
        public ClsPrp_JointPromoter_SearchOptionParamDetails()
        {
            prpproperty = new List<ClsPrp_JointPromoter_SearchOptionParamDetails>();
        }
    }
}