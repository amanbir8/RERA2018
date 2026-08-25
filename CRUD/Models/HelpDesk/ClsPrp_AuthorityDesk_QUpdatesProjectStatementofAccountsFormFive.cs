using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive
    {
        public long ProjectStatementofAccounts_IndexID { get; set; }
        public long ProjectStatementofAccounts_ID { get; set; }
                
        public string ProjectStatementofAccounts_DiaryNumber { get; set; }
        public long ProjectStatementofAccounts_DiaryID { get; set; }
        public long ProjectStatementofAccounts_DiaryYear { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectStatementofAccountsRelated_ProjectID { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectStatementofAccountsRelated_ProjectName { get; set; }

        [Display(Name = "Project's Diary Number")]
        public string ProjectStatementofAccountsRelated_ProjectDiaryNumber { get; set; }

        public long ProjectStatementofAccountsRelated_PromoterID { get; set; }        
        public string ProjectStatementofAccountsRelated_UserID { get; set; }

        [Required]
        [Display(Name = "Financial year ending on (31st March)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FinancialYear_EndingOnDate { get; set; }

        [Display(Name = "Completion Date as per Form-B")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FormB_CompletionDate { get; set; }

        [Required]
        [Range(0, 999.99)]        
        [RegularExpression(@"^([0-9]{1,2}([\.][0-9]{1,})?$|100([\.][0]{1,})?)$", ErrorMessage = "Invalid Percentage of Completion; Maximum Two Decimal Points.")]
        [Display(Name = "Percentage of Completion")]
        public double Percentage_of_Completion { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Explanatory Note")]
        [StringLength(800, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,800}$", ErrorMessage = "Special characters are not allowed. Maximum length is 800")]
        public string ExplanatoryNote { get; set; }


        [Required]
        [Display(Name = "Collected during the financial year (INR)")]        
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid collected during the financial year Amount (INR); Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public double CollectedDuring_FinancialYear_Amount_INR { get; set; }

        [Required]
        [Display(Name = "Collected till date (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid collected till date Amount (INR); Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]        
        public double CollectedTillDate_Amount_INR { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid withdraw during the financial year Amount (INR); Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        [Display(Name = "Withdraw during the financial year (INR)")]
        public double WithdrawDuring_FinancialYear_Amount_INR { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid withdrawn till date Amount (INR); Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        [Display(Name = "Withdrawn till date (INR)")]
        public double WithdrawnTillDate_Amount_INR { get; set; }

        public double Amount_A_column { get; set; }
        public double Amount_B_column { get; set; }

        [Display(Name = "Annual Report (Form-5 CA Certificate)")]
        public string ImageFormFive_FileName { get; set; }        
        public string ImageFormFive_FilePath { get; set; }
        public string ImageFormFive_FileSize { get; set; }
        public string ImageFormFive_FileFormat { get; set; }
              
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        [Display(Name = "Remarks, if Any")]
        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsEvaluationDraft { get; set; }
        public int IsMemberDraft { get; set; }
        public int IsSecretaryDraft { get; set; }
        public int IsAuthorityDraft { get; set; }
        public int IsPublicView { get; set; }
        
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifyOn { get; set; }



        [Display(Name = "Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Project_Diary_ApplicationDate { get; set; }
        [Display(Name = "Project's Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter's Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        public string RERAnumberRegistration { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        public long zipQUpdateProject_RegDiaryNumber_ID { get; set; }
        [Display(Name = "QUP Diary Number")]
        public string zipQUpdateProject_RegDiaryNumber_Name { get; set; }
        [Display(Name = "Quarter Year")]
        public string zipQUpdateProject_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string zipQUpdateProject_QuarterName { get; set; }

        public Int32 zipQUpdateProject_YearValue { get; set; }
        public string zipQUpdateProject_QuarterNameValue { get; set; }
        [Display(Name = "Registration Number")]
        public string zipProject_RERAregistrationNumber { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }


        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Display(Name = "Select Quarter")]
        public int EventQuarter { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive>();
        }
    }
}