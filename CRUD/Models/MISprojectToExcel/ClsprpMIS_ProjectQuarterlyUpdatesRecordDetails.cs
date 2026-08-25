using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails
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

        [Display(Name = "Activity Code")]
        public long EventAction_Type { get; set; }
        [Display(Name = "Date of Last Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Application Status (Last Action by RERA)")]
        public string EventAction_Aggregate { get; set; }

        [Display(Name = "Submitted Status")]
        public string QUP_SubmittedOnTimebyPromoter_Name { get; set; }
        [Display(Name = "Submitted Status Code")]
        public int QUP_SubmittedOnTimebyPromoter_Flag { get; set; }
        [Display(Name = "Submitted Status by Promoter (in Days)")]
        public string QUP_SubmittedOnTimebyPromoter_Days { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }
                
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

        [Required]
        [Display(Name = "Search For")]
        public int IsApplicationTypeFlag { get; set; }

        [Display(Name = "District Category")]
        public int IsApplicationStatisticsCategory { get; set; }

        [Required]
        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }
                        
        [Display(Name = "Select Quarter")]
        public string EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails>();
        }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}