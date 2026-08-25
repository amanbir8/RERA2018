using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class Clsprp_Promoter_FiveYr_OngoingProjcts
    {


        public Int64 Application_id { get; set; }

        [Display(Name = "Number of Completed Projects in Last Five Years")]
        public Int32 Ind_Org_CompltdProj_FiveYrs { get; set; }


        //[Required(ErrorMessage = "Total area Constructed is required.")]
        [Display(Name = "Total Area Constructed under all such projects (In sq mtrs)")]
        public Decimal Ind_Org_TotalArea_Constructed { get; set; }

        //[Required(ErrorMessage = "Ongoing Projects is required.")]
        [Display(Name = "Number of Ongoing Projects")]
        public Int32 Ind_Org_OngoingProjects { get; set; }

        //[Required(ErrorMessage = "Area to be Constructed is required.")]
        [Display(Name = "Area to be Constructed under such projects (In sq mtrs)")]
        public Decimal Ind_Org_AreaToBe_Constructed { get; set; }
        public List<Clsprp_Promoter_FiveYr_OngoingProjcts> FiveYr_OngoingProjcts { get; set; }
    }
}