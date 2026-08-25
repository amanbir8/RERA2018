using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_MIS_ProjectCompletionRERAnumberExportExcel
    {
        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }
        
        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }

        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Required]
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Address Line1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string ProjectAddressLine1 { get; set; }

        [Display(Name = "Project Address Line2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string ProjectAddressLine2 { get; set; }

        [Required(ErrorMessage = "The Project Address State field is required.")]
        [Display(Name = "Project Address State")]
        public string ProjectAddressState { get; set; }

        [Required(ErrorMessage = "The Project Address District field is required.")]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Required(ErrorMessage = "The Project Address Sub-Division field is required.")]
        [Display(Name = "Project Address Sub-Division")]
        public string ProjectAddressSubDivision { get; set; }

        [Required]
        [Display(Name = "Project Address PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string ProjectAddressPIN { get; set; }

        [Required]
        [Display(Name = "Project Potential Zone")]
        public string ProjectPotentialZone { get; set; }

        public string PromoterName { get; set; }
        
        [Display(Name = "Project Address District")]
        public string DName { get; set; }
        [Display(Name = "PCC Details")]
        public string PCC_InfoDetails { get; set; }
        [Display(Name = "PCC Reference Number")]
        public string PCC_ReferenceName { get; set; }
        [Display(Name = "PCC Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PCC_ReferenceDate { get; set; }
        [Display(Name = "PCC Status")]
        public string PCC_CertificateStatus { get; set; }
        public string PCC_ReciptType { get; set; }
        [Display(Name = "Remarks, If Any")]
        public string RemarksIfAny { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public string ProjectCompletionCert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectCompletionCert_IssueDate { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }
        
        public List<ClsPrp_MIS_ProjectCompletionRERAnumberExportExcel> prpongoing { get; set; }
        public ClsPrp_MIS_ProjectCompletionRERAnumberExportExcel()
        {
            prpongoing = new List<ClsPrp_MIS_ProjectCompletionRERAnumberExportExcel>();
        }
    }
}