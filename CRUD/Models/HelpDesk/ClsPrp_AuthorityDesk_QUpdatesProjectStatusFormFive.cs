using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive
    {
        public long ProjectStatementofAccounts_IndexID { get; set; }
        public long ProjectStatementofAccounts_ID { get; set; }
                
        public string ProjectStatementofAccounts_DiaryNumber { get; set; }
        public long ProjectStatementofAccounts_DiaryID { get; set; }
        public long ProjectStatementofAccounts_DiaryYear { get; set; }

        [Display(Name = "Project Name")]
        public long ProjectStatementofAccountsRelated_ProjectID { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectStatementofAccountsRelated_ProjectName { get; set; }

        [Display(Name = "Project's Diary Number")]
        public string ProjectStatementofAccountsRelated_ProjectDiaryNumber { get; set; }

        public long ProjectStatementofAccountsRelated_PromoterID { get; set; }        
        public string ProjectStatementofAccountsRelated_UserID { get; set; }

        [Display(Name = "Financial year ending on (31st March)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FinancialYear_EndingOnDate { get; set; }

        [Display(Name = "Completion Date as per Form-B")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FormB_CompletionDate { get; set; }
        
        [Display(Name = "Percentage of Completion")]
        public double Percentage_of_Completion { get; set; }

        [Display(Name = "Explanatory Note")]        
        public string ExplanatoryNote { get; set; }

        [Display(Name = "Collected during the financial year (INR)")]
        public double CollectedDuring_FinancialYear_Amount_INR { get; set; }

        [Display(Name = "Collected till date (INR)")]
        public double CollectedTillDate_Amount_INR { get; set; }

        [Display(Name = "Withdraw during the financial year (INR)")]
        public double WithdrawDuring_FinancialYear_Amount_INR { get; set; }

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

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        public string RERAnumberRegistration { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Quarter Year")]
        public string setQuarterValue_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string setQuarterValue_Name { get; set; }
        [Display(Name = "Submitted Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? QuarterlySubmittedDate { get; set; }        

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive>();
        }
    }
}