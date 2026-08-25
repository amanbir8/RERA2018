using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectCheckListRecordDetails
    {
        public long Project_RegDiaryNumber_IndexID { get; set; }
        [Display(Name = "Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }
        public long PromoterRegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Related_Project_ID { get; set; }
        public long Related_Promoter_ID { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Activity Code")]
        public long EventAction_Type { get; set; }
        [Display(Name = "Date of Last Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Application Status (Last Action by RERA)")]
        public string EventAction_Aggregate { get; set; }
        [Display(Name = "No Reply by Promoter (in Days)")]
        public string EventAction_NoReplybyPromoter_Days { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Project Status")]
        public string Project_Status { get; set; }

        [Display(Name = "Project Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectStart_Date { get; set; }
        [Display(Name = "Proposed/ Expected Date of Project Completion as specified in Form B")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectCompletion_ProposedDate { get; set; }
        [Display(Name = "Original Date of Project Completion")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectCompletion_OriginalDate { get; set; }

        public string Project_AddressStateCode { get; set; }
        public string Project_AddressDistrictCode { get; set; }
        public string Project_AddressSubDivisionCode { get; set; }

        public string varLandTitleSearchReport { get; set; }
        public string varLatestCopyJamabandiCertificate { get; set; }
        public string varLandEncumbrancesNECertificate { get; set; }
        public string varCLUCertificate { get; set; }
        public string varLicenseDevelopSocietyColonyFromCompetentAuthority { get; set; }
        public string varRegistrationAsPromoter { get; set; }
        public string varFinanceYesNo { get; set; }

        [Display(Name = "Statistics Remarks")]
        public string VariableValue { get; set; }
        [Display(Name = "Percentage (%)")]
        public decimal PercentageValue { get; set; }

        [Display(Name = "Registration Number")]
        public string RERAregistrationnumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Registration_IssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Registration_UptoDate { get; set; }

        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }

        [Required]
        [Display(Name = "Search For")]
        public int IsApplicationTypeFlag { get; set; }
        [Required]
        [Display(Name = "Statistics Category")]
        public int IsApplicationStatisticsCategory { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Required]
        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }
        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public List<Clsprp_MIS_ProjectCheckListRecordDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectCheckListRecordDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectCheckListRecordDetails>();
        }
    }
}