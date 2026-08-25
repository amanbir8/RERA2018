using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormM_PreHearingInterimOrder
    {

        public long IntrimOrderFormM_IndexID { get; set; }
        public long IntrimOrderFormM_ID { get; set; }

        public long Related_ComplaintID { get; set; }
        public string Related_DiaryNumber { get; set; }
        public long Related_PreHearingDate_IndexID { get; set; }
        public long Related_PreHearingDate_ID { get; set; }


        [Required(ErrorMessage = "Complaint Preliminary-Hearing/ Hearing Date is required")]
        [Display(Name = "Hearing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Related_PreHearingDate { get; set; }

        [Required(ErrorMessage = "Complaint Preliminary-Hearing/ Hearing Time is required")]
        [Display(Name = "Hearing Time")]
        [StringLength(90)]
        [RegularExpression(@"^ *(1[0-2]|[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$", ErrorMessage = "Invalid Time Format (Try HH:MM PM/AM). Maximum length is 8")]
        public string Related_PreHearingTime { get; set; }

        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }

        [Display(Name = "Hearing Bench")]
        [StringLength(150)]
        public string PreHearingBenchName { get; set; }
        public string PreHearingBenchCode { get; set; }

        [Display(Name = "Fixed For")]
        [StringLength(150)]
        public string PreHearingFixedForName { get; set; }
        public string PreHearingFixedForCode { get; set; }

        public int IntrimOrderDoc_InfoCode { get; set; }

        [Required(ErrorMessage = "Interim Order Document is required.")]
        [Display(Name = "Interim Order Document")]
        //[StringLength(90, MinimumLength = 2)]
        public string IntrimOrderDoc_InfoName { get; set; }

        [Required(ErrorMessage = "Interim Order Number is required.")]
        [Display(Name = "Interim Order Number")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string IntrimOrderDoc_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Interim Order Date is required.")]
        [Display(Name = "Date of Interim Order")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? IntrimOrderDoc_IssueDate { get; set; }

        public string IntrimOrderDoc_FileSize { get; set; }
        public string IntrimOrderDoc_FileFormat { get; set; }
        public string IntrimOrderDoc_FilePath { get; set; }
        public string IntrimOrderDoc_FileName { get; set; }
        public int IntrimOrderDoc_IsGroup { get; set; }

        [Display(Name = "Serial Number")]
        public string Upload_SerialNumber { get; set; }

        [Required(ErrorMessage = "Number of Pages related to Interim Order is required.")]
        [Display(Name = "Number of Pages (Interim Order)")]
        [Range(0, 500)]
        public int Upload_PageStartNumber { get; set; }

        public int Upload_PageEndNumber { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsFlag { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }
              
        [Display(Name = "Interim Order")]        
        public int IsInterimOrder { get; set; }
        [Display(Name = "Interim Order")]
        [StringLength(150)]
        public string InterimOrderStatusRemark { get; set; }        
        


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


        public List<ClsPrp_AuthDesk_FormM_PreHearingInterimOrder> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormM_PreHearingInterimOrder()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormM_PreHearingInterimOrder>();
        }
        public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> PreHearingFixedForMaster { get; set; }
        public List<ClsPrp_AuthDesk_PreHearingBench_Master> PreHearingBenchMaster { get; set; }
    }
}