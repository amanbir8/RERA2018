using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel
    {        
        [Display(Name = "Diary Number")]
        public string QUpdateProject_RegDiaryNumber_Name { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }

        public int QUpdateProject_Year { get; set; }
        public string QUpdateProject_QuarterName { get; set; }        

        [Display(Name = "Registration Number")]
        public string RERAregistrationnumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberValidUptoDate { get; set; }
       
        [Display(Name = "Date of Last Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Application Status (Last Action by RERA)")]
        public string EventAction_Aggregate { get; set; }

        [Display(Name = "Submitted Status")]
        public string QUP_SubmittedOnTimebyPromoter_Name { get; set; }        
        [Display(Name = "Submitted Status by Promoter (in Days)")]
        public string QUP_SubmittedOnTimebyPromoter_Days { get; set; }        
                
        public string Project_AddressStateCode { get; set; }
        public string Project_AddressDistrictCode { get; set; }
        public string Project_AddressSubDivisionCode { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Quarter Year")]
        public string QuarterValue_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string QuarterValue_Name { get; set; }

        [Display(Name = "Statistics Remarks")]
        public string VariableValue { get; set; }
        [Display(Name = "Percentage (%)")]
        public decimal PercentageValue { get; set; }

        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }

        public List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel>();
        }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}