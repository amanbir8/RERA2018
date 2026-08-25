using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_MIS_ProjectRERAnumberExportExcel
    {  

        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        public string IsAlreadyRegistration { get; set; }
        [Display(Name = "Existing RERA Registration Number (If Yes)")]        

        public string PromoterName { get; set; }
        public string PromoterWebLink { get; set; }
        public string PromoterAuthSignFormB { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "Project Website Web Link")]
        public string ProjectWebLink { get; set; }

        [Display(Name = "Authorized Person First Name")]
        public string AuthorizedPerson_FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string AuthorizedPerson_LastName { get; set; }

        [Display(Name = "Authorized Person Email")]
        public string AuthorizedPerson_Email { get; set; }
        [Display(Name = "Authorized Person Mobile Number")]
        public string AuthorizedPerson_Mobile { get; set; }           


        public List<ClsPrp_MIS_ProjectRERAnumberExportExcel> prpongoing { get; set; }
        public ClsPrp_MIS_ProjectRERAnumberExportExcel()
        {
            prpongoing = new List<ClsPrp_MIS_ProjectRERAnumberExportExcel>();
        }

    }
}