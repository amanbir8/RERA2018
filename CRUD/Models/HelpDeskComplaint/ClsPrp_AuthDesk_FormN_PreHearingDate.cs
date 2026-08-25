using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormN_PreHearingDate
    {
        public long PreHearingDate_IndexID { get; set; }
        public long PreHearingDate_ID { get; set; }
        public long ComplainantApplicant_RelatedComplaint_ID { get; set; }
        public string ComplainantApplicant_RelatedComplaint_Code { get; set; }
        public string ComplaintType_MN { get; set; }

        [Required(ErrorMessage = "Complaint Preliminary-Hearing/ Hearing Date is required")]
        [Display(Name = "Next Hearing Date Fixed")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PreHearingDate { get; set; }

        [Required(ErrorMessage = "Complaint Preliminary-Hearing/ Hearing Time is required")]
        [Display(Name = "Next Hearing Time Fixed")]
        [StringLength(90)]
        [RegularExpression(@"^ *(1[0-2]|[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$", ErrorMessage = "Invalid Time Format (Try HH:MM PM/AM). Maximum length is 8")]
        public string PreHearingTime { get; set; }

        [Required(ErrorMessage = "Preliminary-Hearing/ Hearing Bench is required")]
        [Display(Name = "Complaint Hearing Bench")]
        [StringLength(150)]
        public string PreHearingBench { get; set; }

        [Required(ErrorMessage = "Fixed For is required")]
        [Display(Name = "Fixed For")]
        [StringLength(150)]
        public string PreHearingFixedForCode { get; set; }

        [Display(Name = "Fixed For")]
        [StringLength(150)]
        public string PreHearingFixedForName { get; set; }

        [Display(Name = "Status")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string PreHearingStatus { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(1500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,1500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 1500")]
        public string Remarks_IfAny { get; set; }

        [Required(ErrorMessage = "Preliminary-Hearing/ Hearing Option is required")]
        [Display(Name = "Select Option")]
        [StringLength(50)]
        public string A_column { get; set; }

        [Display(Name = "Hearing Bench")]
        [StringLength(150)]
        public string B_column { get; set; }

        [Required(ErrorMessage = "The period within which the respondent is required to file reply (in days) field is required")]
        [Display(Name = "Period within which the respondent is required to file reply (in days)")]
        [Range(0, 99, ErrorMessage = "Invalid Number, Maximum reply period is upto 99 days")]
        public int C_column { get; set; }

        [Required(ErrorMessage = "The Business On Date/ Date Fixed for Proceeding field is required")]
        [Display(Name = "Business On Date/ Date Fixed for Proceeding")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }

        public string E_column { get; set; }

        [Display(Name = "Interim Order")]
        public int IsInterimOrder { get; set; }
        [Display(Name = "Interim Order")]
        [StringLength(150)]
        public string InterimOrderStatusRemark { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Entry/ Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }


        public long zapRelated_Complaint_ID { get; set; }
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "RERA Number")]
        public string zapComplainantRERAnumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }


        public List<ClsPrp_AuthDesk_FormN_PreHearingDate> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormN_PreHearingDate()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormN_PreHearingDate>();

        }
        public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> PreHearingFixedForMaster { get; set; }
        public List<ClsPrp_AuthDesk_PreHearingBench_Master> PreHearingBenchMaster { get; set; }
    }
}