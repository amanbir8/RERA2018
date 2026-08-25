using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeDetails
    {
        public long IndexCode { get; set; }

        [Display(Name = "Activity Code")]
        public long EventAction_Type { get; set; }

        [Display(Name = "Activity's Name")]
        public string EventAction_Aggregate { get; set; }

        [Display(Name = "Number of Applications")]
        public long NumberOfApplications { get; set; }

        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }

        [Required]
        [Display(Name = "Date")]
        public int IsApplicationDateFlag { get; set; }
        [Required]
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }
        [Required]
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Required]
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }


        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public List<Clsprp_MIS_ProjectAverageFileTimeDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeDetails>();
        }

    }
}