using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumberToExcel
    {
        public long Reference_ID { get; set; }
        public string Reference_Number { get; set; }

        [Display(Name = "Project's Diary Number")]
        public string Project_DiaryNumber { get; set; }  //ProjectRegDiaryNumber_Name      

        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; } //CreatedOn

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "Type of Promoter")]
        public string PromoterType { get; set; }

        [Display(Name = "Project's Potential Zone")]
        public string ProjectPotentialZone { get; set; }
        [Display(Name = "Project's Website/ Web-link")]
        public string ProjectWebLink { get; set; }

        [Display(Name = "Name of Authorized Person")]
        public string ProjectAuthContactPersonName { get; set; }
        [Display(Name = "Authorized Person Email")]
        [EmailAddress]
        public string AuthorizedPerson_Email { get; set; }
        [Display(Name = "Authorized Person Mobile Number")]
        public string AuthorizedPerson_Mobile { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string RERA_Registration_Number { get; set; } //RERAnumberRegistration
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_IssueDate { get; set; } //RERAnumberIssueDate
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_RegistrationUptoDate { get; set; } //RERAnumberRegUptoDate

        [Display(Name = "Status")]
        public string Status { get; set; } //EventAction_Aggregate
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Status_Date { get; set; } //EventAction_IdentifiedOn


        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumberToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumberToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumberToExcel>();
        }        
    }
}