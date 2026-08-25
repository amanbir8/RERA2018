using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeExportExcel
    {
        [Display(Name = "Activity's Name")]
        public string Activity_Name { get; set; }

        [Display(Name = "Number of Applications")]
        public long NumberOfApplications { get; set; }  

        public List<Clsprp_MIS_ProjectAverageFileTimeExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeExportExcel>();
        }
    }
}