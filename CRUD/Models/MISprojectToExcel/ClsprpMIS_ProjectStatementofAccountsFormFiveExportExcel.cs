using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel
    {
        [Display(Name = "Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Display(Name = "Application Date")]
        public DateTime Project_Diary_ApplicationDate { get; set; }

        [Display(Name = "Project's Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Promoter's Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Registration Number")]
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Statement of Accounts Reference Number")]
        public string ProjectStatementofAccounts_DiaryNumber { get; set; }

        [Display(Name = "Statement of Accounts Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Financial year ending on (31st March)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FinancialYear_EndingOnDate { get; set; }

        [Display(Name = "Completion Date as per Form-B")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FormB_CompletionDate { get; set; }

        [Display(Name = "Percentage of Completion")]
        public double Percentage_of_Completion { get; set; }

        [Display(Name = "Collected during the financial year (INR)")]        
        public double CollectedDuring_FinancialYear_Amount_INR { get; set; }

        [Display(Name = "Collected till date (INR)")]
        public double CollectedTillDate_Amount_INR { get; set; }

        [Display(Name = "Withdraw during the financial year (INR)")]
        public double WithdrawDuring_FinancialYear_Amount_INR { get; set; }

        [Display(Name = "Withdrawn till date (INR)")]
        public double WithdrawnTillDate_Amount_INR { get; set; }

        [Display(Name = "Remarks, if Any")]
        public string Remarks_IfAny { get; set; }     

        public List<ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel> prpongoing { get; set; }
        public ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel()
        {
            prpongoing = new List<ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel>();
        }
    }
}