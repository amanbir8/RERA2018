using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails
    {
        public long QUpdateProject_RegDiaryNumber_IndexID { get; set; }
        public long QUpdateProject_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string QUpdateProject_RegDiaryNumber_Name { get; set; }
        public string QUpdateProject_RegDiaryNumber_NameYear { get; set; }
        public int QUpdateProject_Year { get; set; }
        public string QUpdateProject_QuarterName { get; set; }
        public string UserID { get; set; }
        public long PromoterID { get; set; }
        public long ProjectID { get; set; }

        public int InventoryCount { get; set; }
        public int ParkingDetailsCount { get; set; }
        public int GeoTaggingPhotographCount { get; set; }
        public int InternalFacilitiesCount { get; set; }
        public int ExternalFacilitiesCount { get; set; }
        public int ApprovalsCount { get; set; }        

        [Display(Name = "Registration Number")]
        public string RERAregistrationnumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberValidUptoDate { get; set; }

        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsLock { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }
        
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? QUpdatesApplication_Date { get; set; }

        [Display(Name = "Quarter Year")]
        public string setQuarterValue_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string setQuarterValue_Name { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; } 
               

        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Date of Last Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Application Status (Last Action by RERA)")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }
        [Display(Name = "Prepared By")]
        public string EventAction_IdentifiedBy { get; set; }

        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }


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


        public List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProjectRecordsDetails>();
        }
    }
}