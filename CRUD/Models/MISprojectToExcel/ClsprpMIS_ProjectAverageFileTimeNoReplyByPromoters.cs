using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters
    {
        public long IndexCode { get; set; }
        public long Related_Project_ID { get; set; }
        public long Related_Promoter_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string Project_DiaryNumber { get; set; }
              
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate_EventAction_IdentifiedOn { get; set; }

        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate_EventAction_IdentifiedOn { get; set; }

        [Display(Name = "No of Days (No Reply by Promoters)")]
        public string NoReplybyPromoters_Days { get; set; }
       
        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }        

        public List<Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters>();
        }

    }
}