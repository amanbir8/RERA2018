using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormM_CaseTransferDetails
    {
        public long CaseTransfer_IndexID { get; set; }
        public long CaseTransfer_ID { get; set; }
        public string CaseTransfer_RegDiaryNumber_IndexName { get; set; }
        public int CaseTransfer_RegDiaryNumber_NameYear { get; set; }
        [Display(Name = "Transfer Diary Number")]
        public string CaseTransfer_RegDiaryNumber_Name { get; set; }

        public long ComplainantApplicant_RelatedComplaint_ID { get; set; }
        [Display(Name = "Reference Number")]
        public string ComplainantApplicant_RelatedComplaint_Code { get; set; }
        public string ComplaintType_MN { get; set; }

        [Required(ErrorMessage = "Transfer Type/ Option is required")]
        [Display(Name = "Transfer Type/ Option")]
        [StringLength(50)]
        public string TransferTypeOption { get; set; }

        [Required(ErrorMessage = "Complaint Case Transfer Date is required")]
        [Display(Name = "Transfer Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TransferDate { get; set; }

        [Required(ErrorMessage = "Transfer From Bench/ Court is required")]
        [Display(Name = "Transfer From Bench/ Court")]
        [StringLength(150)]
        public string Transfer_FromBench { get; set; }

        [Display(Name = "Transfer From Bench/ Court")]
        [StringLength(150)]
        public string Transfer_FromBenchName { get; set; }

        [Required(ErrorMessage = "Transfer To Bench/ Court is required")]
        [Display(Name = "Transfer To Bench/ Court")]
        [StringLength(150)]
        public string Transfer_ToBench { get; set; }        

        [Display(Name = "Transfer To Bench/ Court")]
        [StringLength(150)]
        public string Transfer_ToBenchName { get; set; }

        [Display(Name = "Status, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string PublicViewStatus { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(1500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,1500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 1500")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }        
        public int C_column { get; set; }
        public string D_column { get; set; }
        public string E_column { get; set; }

        public int IsCaseTransferlockUnlockFlag { get; set; }
        public int IsTransferOrder { get; set; }
        [StringLength(150)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string TransferOrderStatusRemark { get; set; }        

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }

        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }
        public int IsLatestActive { get; set; }
        public int IsTransferDisplay { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
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


        [Display(Name = "Complaint Diary Number")]
        [DataType(DataType.MultilineText)]
        [StringLength(800)]
        public string ComplaintRegistrationNumber_Input { get; set; }        


        public List<ClsPrp_AuthDesk_FormM_CaseTransferDetails> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormM_CaseTransferDetails()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormM_CaseTransferDetails>();

        }
        public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> PreHearingFixedForMaster { get; set; }
        public List<ClsPrp_AuthDesk_PreHearingBench_Master> PreHearingBenchMaster { get; set; }        
    }
}