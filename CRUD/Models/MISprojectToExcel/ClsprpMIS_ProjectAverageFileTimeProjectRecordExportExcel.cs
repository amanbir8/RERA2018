using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel
    {
        [Display(Name = "Diary Number")]
        public string Diary_Number { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Application Status (Last Action by RERA)")]
        public string LastActivity_Name { get; set; } 
              
        [Display(Name = "Date of Last Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastActivity_Date { get; set; }

        [Display(Name = "Date of Application Approved for Registration")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApplicationApproved_Date { get; set; }

        [Display(Name = "No of Days (Application Approved for Registration)")]
        public string RegistrationApproved_Days { get; set; }

        [Display(Name = "No of Days (Last Action by RERA)")]
        public string LastActionbyRERA_Days { get; set; }

        [Display(Name = "No of Days (Application Received)")]
        public string ApplicationReceived_Days { get; set; }

        [Display(Name = "No of Days (No reply by Promoter)")]
        public string NoReplyByPromoter_Days { get; set; }

        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }        

        public List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel>();
        }

    }
}