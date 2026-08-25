using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetailsToExcel
    {
        [Display(Name = "Diary Number")]
        public string Diary_Number { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }

        [Display(Name = "Project's Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Display(Name = "Registration Number")]
        public string RERA_Registration_Number { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_IssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_RegistrationUptoDate { get; set; }
        
        [Display(Name = "Quarter Year")]
        public string Quarter_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string Quarter_Title { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrict { get; set; }

        [Display(Name = "Application Status")]
        public string Status_Title { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Status_Date { get; set; }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetailsToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetailsToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetailsToExcel>();
        }
    }
}