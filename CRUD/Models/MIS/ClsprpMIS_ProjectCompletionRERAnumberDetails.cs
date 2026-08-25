using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsprpMIS_ProjectCompletionRERAnumberDetails
    {
        public long Project_RERAnumber_DiaryNumber_IndexID { get; set; }
        public long Project_RERAnumber_DiaryNumber_ID { get; set; }
        
        public long PCC_IndexID { get; set; }
        public long PCC_ID { get; set; }
        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public string User_ID { get; set; }

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

        [Display(Name = "Project Address Line1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string ProjectAddressLine1 { get; set; }

        [Display(Name = "Project Address Line2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string ProjectAddressLine2 { get; set; }

        [Display(Name = "Project Address State")]
        public string ProjectAddressState { get; set; }

        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Display(Name = "Project Address Sub-Division")]
        public string ProjectAddressSubDivision { get; set; }

        [Display(Name = "Project Address PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string ProjectAddressPIN { get; set; }

        [Display(Name = "Project Potential Zone")]
        public string ProjectPotentialZone { get; set; }

        public string PromoterName { get; set; }
        public int PromoterType { get; set; }

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

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }


        public string ProjectCompletionCert_FilePath { get; set; }
        public string ProjectCompletionCert_FileName { get; set; }
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


        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }



        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }

        [Display(Name = "Search Type")]
        public string Application_SearchDocumnetType { get; set; }
        [Display(Name = "Search Option")]
        public string Application_SearchOptionFlag { get; set; }
        [Display(Name = "Range Option")]
        public string Application_SearchRangeFlag { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_ToDate { get; set; }

        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public List<ClsprpMIS_ProjectCompletionRERAnumberDetails> prpongoing { get; set; }
        public ClsprpMIS_ProjectCompletionRERAnumberDetails()
        {
            prpongoing = new List<ClsprpMIS_ProjectCompletionRERAnumberDetails>();
        }
    }
}