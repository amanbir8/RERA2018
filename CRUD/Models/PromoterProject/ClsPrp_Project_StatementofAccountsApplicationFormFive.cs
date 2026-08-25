using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_StatementofAccountsApplicationFormFive
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

        public List<ClsPrp_Project_StatementofAccountsApplicationFormFive> prpongoing { get; set; }
        public ClsPrp_Project_StatementofAccountsApplicationFormFive()
        {
            prpongoing = new List<ClsPrp_Project_StatementofAccountsApplicationFormFive>();
        }

        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
    }
}