using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumberToExcel
    {
        [Display(Name = "Diary Number")]
        public string PCC_RegDiaryNumber_Name { get; set; }

        [Display(Name = "PCC Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectCompletionApplicationDate { get; set; }


        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }


        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERAregistrationIssueDate { get; set; }
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERAregistrationValidUptoDate { get; set; }
        [Display(Name = "Extension of Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERAextnregistrationValidUptoDate { get; set; }


        public long EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public string Promoter_DiaryNumber { get; set; }
        public string Project_DiaryNumber { get; set; }
        public string Completion_DiaryNumber { get; set; }
        public string EventRERA_RegistrationNumber { get; set; }
        public string EventAction_Summary { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public string EventRemarks_IfAny { get; set; }


        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumberToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumberToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumberToExcel>();
        }        
    }
}