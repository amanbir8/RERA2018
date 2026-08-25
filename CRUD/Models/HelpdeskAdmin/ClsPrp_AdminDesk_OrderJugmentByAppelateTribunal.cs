using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal
    {

        //Order & Judgement
        public long AppellateTribunalOrder_IndexID { get; set; }
        public long AppellateTribunalOrder_ID { get; set; }
        public long Related_ComplaintID { get; set; }

        public string Related_DiaryNumber { get; set; }
        public string Related_ComplaintType_MN { get; set; }
        public string Related_Complaint_OrderRefNumber { get; set; }
        public DateTime? Related_Complaint_OrderDate { get; set; }
        public int SerialOrderNumber { get; set; }

        [Required]
        [Display(Name = "Complaint Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ComplaintNumber { get; set; }

        [Required]
        [Display(Name = "Complainant Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string ComplainantName { get; set; }

        [Required]
        [Display(Name = "Respondent Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string RespondentName { get; set; }

        [Required]
        [Display(Name = "Date of Decision")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Decision { get; set; }

        [Required]
        [Display(Name = "Appeal Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Appeal_RefNumber { get; set; }

        [Required]
        [Display(Name = "Date of Filing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Appeal_FilingDate { get; set; }

        [Display(Name = "Date of Instituion Filing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Appeal_InstitutionDate { get; set; }

        public long Related_PreHearingDate_IndexID { get; set; }

        public long Related_PreHearingDate_ID { get; set; }

        public DateTime? Related_PreHearingDate { get; set; }

        public string Related_PreHearingTime { get; set; }

        public string User_ID { get; set; }


        [Display(Name = "Hearing Bench Code")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string HearingBenchCode { get; set; }

        [Display(Name = "Hearing Bench Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string HearingBenchName { get; set; }

        public string HearingBenchType { get; set; }

        [Required]
        [Display(Name = "Type of Order")]
        public int AppealOrderDoc_InfoCode { get; set; }

        [Display(Name = "Type of OrderName")]
        public string AppealOrderDoc_InfoName { get; set; }

        public string AppealOrderDoc_ReferenceNumber { get; set; }

        public DateTime? AppealOrderDoc_IssueDate { get; set; }

        public string AppealOrderDoc_FileSize { get; set; }

        public string AppealOrderDoc_FileFormat { get; set; }

        public string AppealOrderDoc_FilePath { get; set; }

        public string AppealOrderDoc_FileName { get; set; }

        public int AppealOrderDoc_IsGroup { get; set; }

        public string Upload_SerialNumber { get; set; }

        public int Upload_PageStartNumber { get; set; }

        public int Upload_PageEndNumber { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }


        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftMember { get; set; }
        public int IsLock { get; set; }






        //[Display(Name = "Appeal Number")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string ComplaintAppealNumber { get; set; }

        // [Display(Name = "Complaint Number")]
        //[StringLength(100, ErrorMessage = "Maximum length is 100")]
        //public string ComplaintApplicationNumber { get; set; }







        // public string ViewJugdement_InfoCode { get; set; }
        public string ViewJugdement_BaseUrl { get; set; }
       // public string ViewJugdement_FilePath { get; set; }
        //[Display(Name = "Order & Jugdement")]
        //public string ViewJugdement_FileName { get; set; }
       // public string ViewJugdement_FileType { get; set; }

        //public long Related_OrderJudgement_ComplaintID { get; set; }
        //public string Related_OrderJudgement_ComplaintType { get; set; }
        //public string Related_OrderJudgement_DiaryNumber { get; set; }
        //public string Related_OrderJudgement_OrderRefNumber { get; set; }


        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }
        public int IsFlag { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        [Display(Name = "Type of Order")]
        public string Related_TypeofOrder { get; set; }



        //Event Details
        //public string EventAction_Type { get; set; }
        //public string EventAction_TypeName { get; set; }
        //[Display(Name = "Status Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? EventAction_IdentifiedOn { get; set; }
        //[Display(Name = "Status")]
        //public string EventAction_Aggregate { get; set; }
        //public string EventRemarks_IfAny { get; set; }
        //public string EventAction_Summary { get; set; }

        ////eCourt Reference-Link
        //public long oOrderDesc_formN_eCourtIndexID { get; set; }
        //public long oOrderDesc_formN_eCourtID { get; set; }
        //[Display(Name = "Serial Number")]
        //public int oSerialOrderNumber { get; set; }
        //public long oRelated_Profile_ID { get; set; }
        //public string oRelated_User_ID { get; set; }
        //public long oRelated_Complaint_ID { get; set; }
        //[Display(Name = "Complaint Type")]
        //public string oRelated_ComplaintType_MN { get; set; }
        //[Display(Name = "Complaint Diary Number")]
        //public string oRelated_ComplaintDiaryNumber { get; set; }

        //public string oeCourt_DiaryNumber { get; set; }
        //[Display(Name = "Reference Number")]
        //[StringLength(90)]
        //[RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        //public string oeCourt_ReferenceName { get; set; }
        //[Display(Name = "Reference Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oeCourt_ReferenceDate { get; set; }
        //[Display(Name = "Under Section")]
        //[StringLength(50)]
        //[RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        //public string oeCourt_UnderSectionName { get; set; }

        //[Display(Name = "Complainant Name")]
        //public string oComplainantName { get; set; }
        //[Display(Name = "Present Complainant/Repersentative's Name")]
        //[DataType(DataType.MultilineText)]
        //public string oPresentComplainantAuthorityName { get; set; }
        //[Display(Name = "Respondent Name")]
        //public string oRespondentName { get; set; }
        //[Display(Name = "Present Respondent/Repersentative's Name")]
        //[DataType(DataType.MultilineText)]
        //public string oPresentRespondentAuthorityName { get; set; }

        //[Display(Name = "Case Type")]
        //[StringLength(150)]
        //public string oeCourt_CaseType_Name { get; set; }
        //public string oeCourt_CaseType_Code { get; set; }
        //[Display(Name = "Reference Date (Case Type)")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oeCourt_CaseType_Date { get; set; }
        //[Display(Name = "Reference (Case Type) Description")]
        //[StringLength(250)]
        //[DataType(DataType.MultilineText)]
        //public string oeCourt_CaseType_Description { get; set; }

        //[Display(Name = "Hearing Bench")]
        //[StringLength(150)]
        //public string oBench_Name { get; set; }
        //public string oBench_Code { get; set; }
        //[Display(Name = "Stamp Description")]
        //[StringLength(250)]
        //[DataType(DataType.MultilineText)]
        //public string oBench_StampDescription { get; set; }

        //[Display(Name = "Order Document")]
        //public string oOrderDocument_InfoName { get; set; }
        //public int oOrderDocument_InfoCode { get; set; }
        //[Display(Name = "Number of Pages (Order Document)")]
        //[Range(0, 500)]
        //public int oUpload_Total_PageNumber { get; set; }
        //public string oUpload_Document_Size { get; set; }
        //public long oRelated_OrderJudgementByAO_IndexID { get; set; }
        //public long oRelated_OrderJudgementByAO_ID { get; set; }

        //[Display(Name = "Date of Filing")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oDate_of_Filing { get; set; }

        //[Display(Name = "Date of Institution")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oDate_of_Institution { get; set; }

        //[Display(Name = "Date of Hearing")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oDate_of_Hearing { get; set; }

        //[Display(Name = "Date of Decision")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oDate_of_Decision { get; set; }

        //[Display(Name = "Date of Upload")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oDate_of_Upload { get; set; }

        //[Display(Name = "True Copy (Order) Prepared By")]
        //public string oTrueCopyPreparedBy { get; set; }
        //[Display(Name = "Date of True Copy (Order)")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? oDate_of_TrueCopy { get; set; }

        //[Display(Name = "Is Transfer Case (Yes/No)?")]
        //public int oIsTransferCase { get; set; }
        //[Display(Name = "Transfer Type/ Option")]
        //[StringLength(50)]
        //public string oTransferTypeOption { get; set; }
        //public string oTransferTypeOptionName { get; set; }
        //public string oTransferCase_DiaryNumber { get; set; }

        //public long oRelated_CaseTransferN_IndexID { get; set; }
        //public long oRelated_CaseTransferN_ID { get; set; }

        //public long oRelated_PreHearingDate_IndexID { get; set; }
        //public long oRelated_PreHearingDate_ID { get; set; }

        //public long oRelated_eCourt_CaseAllocationN_IndexID { get; set; }
        //public long oRelated_eCourt_CaseAllocationN_ID { get; set; }

        //[Display(Name = "Remarks, If Any")]
        //[DataType(DataType.MultilineText)]
        //[StringLength(250)]
        //[RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        //public string oRemarks_IfAny { get; set; }

        //[Display(Name = "Penalty Amount (INR) to be paid by Respondent, If Any")]
        //[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        //[Range(0, 99999999.99)]
        //public decimal oA_column { get; set; }

        //public string oB_column { get; set; }
        //public string oC_column { get; set; }
        //public string oD_column { get; set; }
        //public string oE_column { get; set; }

        //public int oIsActive { get; set; }
        //public int oIsLatestActive { get; set; }
        //public int oIsDraft { get; set; }
        //public int oIsDraftMember { get; set; }
        //[Display(Name = "Lock (Yes/No)")]
        //public int oIsLock { get; set; }
        //public int oIsFlag { get; set; }
        //[Display(Name = "Public View (Yes/No)")]
        //public int oIsPublicView { get; set; }

        //public string oCreatedBy { get; set; }
        //public DateTime? oCreatedOn { get; set; }
        //public string oModifyBy { get; set; }
        //public DateTime? oModifyOn { get; set; }

        


        //Input Filter-Parms
        //[Required]
        //[Display(Name = "Search-Option Tabs")]
        //public int Input_SearchOptionTabFlag { get; set; }

        //[Required]
        //[Display(Name = "Year")]
        //public string Input_YearREAT_DecisionOfDate { get; set; }

        //[Required]
        //[Display(Name = "Year")]
        //public string Input_YearExREAT_DecisionOfDate { get; set; }

        //[Display(Name = "Complaint Number")]
        //public string Input_Reference_Number { get; set; }

        //[Display(Name = "Complainant Name")]
        //[StringLength(150)]
        //[RegularExpression(@"^[a-zA-Z'',\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        //public string Input_ReferenceREAT_Name { get; set; }

        //[Display(Name = "Complainant Name")]
        //[StringLength(150)]
        //[RegularExpression(@"^[a-zA-Z'',\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        //public string Input_ReferenceExREAT_Name { get; set; }

        //[Display(Name = "Type Of Order")]
        //[StringLength(100)]
        //public string Input_Reference_TypeOfOrder { get; set; }

        //[Required]
        //[Display(Name = "Captcha Text")]
        //[StringLength(10, ErrorMessage = "Maximum length is 10")]
        //[RegularExpression(@"^[0-9a-zA-Z\s]{1,10}$", ErrorMessage = "Special characters are not allowed.")]
        //public string Input_OrderJudgementREAT_CaptchaText { get; set; }

        //[Required]
        //[Display(Name = "Captcha Text")]
        //[StringLength(10, ErrorMessage = "Maximum length is 10")]
        //[RegularExpression(@"^[0-9a-zA-Z\s]{1,10}$", ErrorMessage = "Special characters are not allowed.")]
        //public string Input_OrderJudgementExREAT_CaptchaText { get; set; }


        public List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> prpongoing { get; set; }
        public ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal()
        {
            prpongoing = new List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal>();
        }

        public List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> prpOrderCourtREAT { get; set; }
        public List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> prpOrderCourtExREAT { get; set; }
    }
}