using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectRERAnumberDetailsToExcel
    {
        [Display(Name = "Project's Diary Number")]
        public string Project_DiaryNumber { get; set; }  //ProjectRegDiaryNumber_Name      

        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; } //CreatedOn

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }

        [Display(Name = "Project Potential Zone")]
        public string ProjectPotentialZone { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string RERA_Registration_Number { get; set; } //RERAnumberRegistration
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_IssueDate { get; set; } //RERAnumberIssueDate
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_RegistrationUptoDate { get; set; } //RERAnumberRegUptoDate

        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Status_Date { get; set; }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetailsToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectRERAnumberDetailsToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDetailsToExcel>();
        }
    }
}