using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectCheckListRecordsExportExcel
    {
        [Display(Name = "Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }
        [Display(Name = "Search For")]
        public string SearchFor_Name { get; set; }

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

        [Display(Name = "Statistics Remarks")]
        public string VariableValue { get; set; }  
              

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
             

        public List<Clsprp_MIS_ProjectCheckListRecordsExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectCheckListRecordsExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectCheckListRecordsExportExcel>();
        }
    }
}