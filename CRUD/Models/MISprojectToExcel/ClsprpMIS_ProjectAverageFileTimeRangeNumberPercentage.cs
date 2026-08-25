using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage
    {
        public long IndexCode { get; set; }

        [Display(Name = "Days Range Title")]
        public string DaysRangeLevel_Title { get; set; }
        [Display(Name = "Number of Days")]
        public int DaysInNumber { get; set; }
        [Display(Name = "Percentage (%)")]
        public decimal PercentagePerDays { get; set; }

        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }        

        public List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage>();
        }

    }
}