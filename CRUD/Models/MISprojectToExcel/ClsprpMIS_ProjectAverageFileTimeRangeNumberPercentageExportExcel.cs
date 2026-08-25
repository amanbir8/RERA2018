using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel
    {
        [Display(Name = "Days Range Title")]
        public string DaysRangeLevel_Title { get; set; }
        [Display(Name = "Number of Days")]
        public int DaysInNumber { get; set; }
        [Display(Name = "Percentage (%)")]
        public decimal PercentagePerDays { get; set; }        

        public List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel>();
        }

    }
}