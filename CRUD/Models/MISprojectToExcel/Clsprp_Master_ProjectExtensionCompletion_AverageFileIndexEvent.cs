using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent
    {       
        [Display(Name = "Event Name")]
        public string EventAction_Name { get; set; }
        [Display(Name = "Event Code")]
        public int EventAction_Code { get; set; }

        public long IndexCode { get; set; }
        public string A_column { get; set; }             

        public List<Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent> prpongoing { get; set; }
        public Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent()
        {
            prpongoing = new List<Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent>();
        }

    }
}