using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities
    {
        public long QUpdateProjectInfraFacilities_IndexID { get; set; }
        public long QUpdateProjectInfraFacilities_ID { get; set; }

        public long Related_ProjectInfrastructureFacilitiesIndexID { get; set; }
        public long Related_ProjectInfrastructureFacilitiesID { get; set; }

        public int IsQuarterlyData { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string QUpdateInfraFacilities_Year { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string QUpdateInfraFacilities_QuarterName { get; set; }

        [Required]
        [Display(Name = "Internal Infrastructure Facilities Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.()\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string InternalInfrastructureFacilities_Name { get; set; }
         
        [Display(Name = "Internal Infrastructure Facilities Type")]
        public string InternalInfrastructureFacilities_Type { get; set; }
         
        [Display(Name = "External Agency Local Authority Name")]
        public string ExternalAgency_LocalAuthority_Name { get; set; }

        [Display(Name = "Is Internal Infrastructure Facilities Applicable")]
        public string Is_InternalInfrastructureFacilitiesApplicable { get; set; }

        [Required]
        [Display(Name = "Work Progress % Percentage upto the date of Registration")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Work Progress(% age); Maximum Two Decimal Points.")]
        [Range(0, 100)]
        public decimal WorkProgress_PercentageUptoRegistration { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Details of Internal Infrastructure Facilities upto the date of Registration")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.()\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string InternalInfrastructureFacilitiesUptoRegistration_Details { get; set; }
        

        [Required]
        [Display(Name = "Work Progress % Percentage in the Quarter")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Work Progress(% age); Maximum Two Decimal Points.")]
        [Range(0, 100)]
        public decimal WorkProgress_PercentageInQuarter { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Details of Internal Infrastructure Facilities in the Quarter")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.()\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string InternalInfrastructureFacilitiesInQuarter_Details { get; set; }

        [Required]
        [Display(Name = "Total Work Progress % Percentage")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Work Progress(% age); Maximum Two Decimal Points.")]
        [Range(0, 100)]
        public decimal WorkProgress_PercentageTotal { get; set; }        


        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsRegisteredDiaryNumberLock { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        [Display(Name = "Quarter Name")]
        public string setQUpdateProject_QuarterName { get; set; }

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

        public List<ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProject_InternalFacilities>();

        }        
    }
}