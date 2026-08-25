using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormN_OrderJudgements
    {
        public long OrderJudgementByAO_IndexID { get; set; }
        public long OrderJudgementByAO_ID { get; set; }
        [Display(Name = "Serial Number")]
        public int SerialOrderNumber { get; set; }
        [Display(Name = "Complaint Diary Number")]
        public string ApplicationNumber { get; set; }

        [Display(Name = "Complainant Name")]
        public string ApplicantName { get; set; }
        [Display(Name = "Respondent Name")]
        public string RespondentName { get; set; }
        [Display(Name = "Date of Decision")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Decision { get; set; }

        public string ViewJugdementAO_BaseUrl { get; set; }
        public string ViewJugdementAO_FilePath { get; set; }
        [Display(Name = "Order Document")]
        public string ViewJugdementAO_FileName { get; set; }
        public string ViewJugdementAO_FileType { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftMember { get; set; }
        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public long oOrderDesc_formN_eCourtIndexID { get; set; }
        public long oOrderDesc_formN_eCourtID { get; set; }
        [Display(Name = "Serial Number")]
        public int oSerialOrderNumber { get; set; }
        public long oRelated_Profile_ID { get; set; }
        public string oRelated_User_ID { get; set; }
        public long oRelated_Complaint_ID { get; set; }
        [Display(Name = "Complaint Type")]
        public string oRelated_ComplaintType_MN { get; set; }
        [Display(Name = "Complaint Diary Number")]
        public string oRelated_ComplaintDiaryNumber { get; set; }

        public string oeCourt_DiaryNumber { get; set; }
        [Display(Name = "Reference Number")]
        [StringLength(90)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string oeCourt_ReferenceName { get; set; }
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oeCourt_ReferenceDate { get; set; }
        [Display(Name = "Under Section")]
        [StringLength(50)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string oeCourt_UnderSectionName { get; set; }

        [Display(Name = "Complainant Name")]
        public string oComplainantName { get; set; }
        [Display(Name = "Present Complainant/Repersentative's Name")]
        [DataType(DataType.MultilineText)]
        public string oPresentComplainantAuthorityName { get; set; }
        [Display(Name = "Respondent Name")]
        public string oRespondentName { get; set; }
        [Display(Name = "Present Respondent/Repersentative's Name")]
        [DataType(DataType.MultilineText)]
        public string oPresentRespondentAuthorityName { get; set; }

        [Display(Name = "Case Type")]
        [StringLength(150)]
        public string oeCourt_CaseType_Name { get; set; }
        public string oeCourt_CaseType_Code { get; set; }        
        [Display(Name = "Reference Date (Case Type)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oeCourt_CaseType_Date { get; set; }
        [Display(Name = "Reference (Case Type) Description")]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string oeCourt_CaseType_Description { get; set; }

        [Display(Name = "Hearing Bench")]
        [StringLength(150)]
        public string oBench_Name { get; set; }
        public string oBench_Code { get; set; }
        [Display(Name = "Stamp Description")]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string oBench_StampDescription { get; set; }

        [Required(ErrorMessage = "Order Document is required.")]
        [Display(Name = "Order Document")]
        public string oOrderDocument_InfoName { get; set; }
        public int oOrderDocument_InfoCode { get; set; }
        [Required(ErrorMessage = "Number of Pages related to Order Document is required.")]
        [Display(Name = "Number of Pages (Order Document)")]
        [Range(0, 500)]
        public int oUpload_Total_PageNumber { get; set; }
        public string oUpload_Document_Size { get; set; }
        public long oRelated_OrderJudgementByAO_IndexID { get; set; }
        public long oRelated_OrderJudgementByAO_ID { get; set; }

        [Required(ErrorMessage = "Date of Filing is required")]
        [Display(Name = "Date of Filing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oDate_of_Filing { get; set; }

        [Required(ErrorMessage = "Date of Institution is required")]
        [Display(Name = "Date of Institution")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oDate_of_Institution { get; set; }

        [Required(ErrorMessage = "Date of Hearing is required")]
        [Display(Name = "Date of Hearing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oDate_of_Hearing { get; set; }

        [Required(ErrorMessage = "Date of Decision is required")]
        [Display(Name = "Date of Decision")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oDate_of_Decision { get; set; }

        [Required(ErrorMessage = "Date of Upload is required")]
        [Display(Name = "Date of Upload")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oDate_of_Upload { get; set; }

        //[Required(ErrorMessage = "True Copy (Order) Prepared By is required.")]
        [Display(Name = "True Copy (Order) Prepared By")]
        public string oTrueCopyPreparedBy { get; set; }
        //[Required(ErrorMessage = "Date of True Copy (Order) is required")]
        [Display(Name = "Date of True Copy (Order)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? oDate_of_TrueCopy { get; set; }

        [Required]
        [Display(Name = "Is Transfer Case (Yes/No)?")]
        public int oIsTransferCase { get; set; }
        [Required(ErrorMessage = "Transfer Type/ Option is required")]
        [Display(Name = "Transfer Type/ Option")]
        [StringLength(50)]
        public string oTransferTypeOption { get; set; }
        public string oTransferTypeOptionName { get; set; }
        public string oTransferCase_DiaryNumber { get; set; }

        public long oRelated_CaseTransferN_IndexID { get; set; }
        public long oRelated_CaseTransferN_ID { get; set; }

        public long oRelated_PreHearingDate_IndexID { get; set; }
        public long oRelated_PreHearingDate_ID { get; set; }

        public long oRelated_eCourt_CaseAllocationN_IndexID { get; set; }
        public long oRelated_eCourt_CaseAllocationN_ID { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string oRemarks_IfAny { get; set; }

        [Display(Name = "Penalty Amount (INR) to be paid by Respondent, If Any")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 99999999.99)]
        public decimal oA_column { get; set; }

        public string oB_column { get; set; }
        public string oC_column { get; set; }
        public string oD_column { get; set; }
        public string oE_column { get; set; }

        public int oIsActive { get; set; }
        public int oIsLatestActive { get; set; }
        public int oIsDraft { get; set; }
        public int oIsDraftMember { get; set; }
        [Display(Name = "Lock (Yes/No)")]
        public int oIsLock { get; set; }
        public int oIsFlag { get; set; }
        [Display(Name = "Public View (Yes/No)")]
        public int oIsPublicView { get; set; }

        public string oCreatedBy { get; set; }
        public DateTime? oCreatedOn { get; set; }
        public string oModifyBy { get; set; }
        public DateTime? oModifyOn { get; set; }

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

        public List<ClsPrp_AuthDesk_FormN_OrderJudgements> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormN_OrderJudgements()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormN_OrderJudgements>();
        }

        public List<ClsPrp_AuthDesk_FormN_OrderJudgements> prpOrderJudgements { get; set; }
        public List<ClsPrp_AuthDesk_PreHearingBench_Master> PreHearingBenchMaster { get; set; }
        public List<ClsPrp_AuthDesk_eCourt_CaseType_Master> eCourtCaseTypeMaster { get; set; }
        public List<ClsPrp_AuthDesk_eCourt_OrderDesc_Master> eCourtOrderDescMaster { get; set; }
        public List<ClsPrp_AuthDesk_eCourt_UnderSection_Master> eCourtUnderSectionMaster { get; set; }
    }
}