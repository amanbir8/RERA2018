using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models.Promoter;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsPrp_Print_NoticeSectionFiveNine
    {
        public long NoticesSectionFiveNine_IndexID { get; set; }
        public long NoticesSectionFiveNine_ID { get; set; }
        public int NoticesSectionFiveNine_IDYear { get; set; }

        [Display(Name = "Notice/File Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string NoticesSectionFiveNine_IDName { get; set; }

        [Display(Name = "Notice Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NoticeDate { get; set; }


        public long Notice_RelatedReferenceID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Notice_RelatedReferenceDate { get; set; }
        public string Notice_RelatedReferenceName { get; set; }
        public string Notice_RelatedReferenceCode { get; set; }


        public int SerialOrderNumber { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Reference Number (Old Number)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string NoticeFile_NumberDetails { get; set; }

        [Display(Name = "District/Town Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string DistrictTown_InfoName { get; set; }

        [Display(Name = "District/Town Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string DistrictTown_InfoCode { get; set; }      
                 
        [Display(Name = "Mode of Complaint Receipt")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]        
        public string Notice_ModeOfComplaint { get; set; }

        [Display(Name = "Mode of Complaint (If Others, then please specify)")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        public string Notice_ModeOfComplaintSpecifyOthers { get; set; }

        [Display(Name = "Promoter Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string PromoterName { get; set; }

        [Display(Name = "Promoter Address Details")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        public string PromoterNameWithAddressDetails { get; set; }

        [Display(Name = "Project Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Address Details")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        public string ProjectNameWithAddressDetails { get; set; }

        
        [Display(Name = "Name of Complainant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? Complainant_LandlineFaxNumber { get; set; }

        [Display(Name = "Aadhaar Number of Complainant")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public long? Complainant_AadhaarNumber { get; set; }



        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResComplainant_AddressLine2 { get; set; }

        [Display(Name = "Address State")]
        public Nullable<int> OfficeResComplainant_AddressStateCode { get; set; }

        [Display(Name = "Address District")]
        public Nullable<int> OfficeResComplainant_AddressDistrictCode { get; set; }

        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string OfficeResComplainant_AddressPIN { get; set; }



        public string IsOfficeResComplainantAddress_SameAsServiceNoticeAddress { get; set; }
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ServiceNoticesComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ServiceNoticesComplainant_AddressLine2 { get; set; }

        [Display(Name = "Address State")]
        public Nullable<int> ServiceNoticesComplainant_AddressStateCode { get; set; }

        [Display(Name = "Address District")]
        public Nullable<int> ServiceNoticesComplainant_AddressDistrictCode { get; set; }

        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string ServiceNoticesComplainant_AddressPIN { get; set; }



        [Display(Name = "Name of Authorized Representative/ Counsel")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedCounsel_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Authorized Representative/ Counsel")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedCounsel_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Authorized Representative/ Counsel")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? AuthorizedCounsel_MobileNumber { get; set; }

        [Display(Name = "Landline or Fax Number of Authorized Representative/ Counsel")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? AuthorizedCounsel_LandlineFaxNumber { get; set; }


        [Display(Name = "Date of Current Status")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CurrentStatusDate { get; set; }

        [Display(Name = "Current Status")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]        
        public string CurrentStatusTitle { get; set; }

        [Display(Name = "Status Remarks, If Any")]
        [StringLength(400, ErrorMessage = "Maximum length is 400")]
        public string CurrentStatusWithRemarks { get; set; }

        [Display(Name = "Is Personal Hearing (Yes/No)?")]        
        public int IsPersonalHearing { get; set; }

        [Display(Name = "Select Hearing Bench")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string HearingBenchCode { get; set; }

        [Display(Name = "Select Hearing Bench")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string HearingBenchName { get; set; }

        [Display(Name = "Fixed For")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string FixedFor { get; set; }

        [Display(Name = "Order Date/ Hearing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Hearing Time")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string OrderTime { get; set; }

        [Display(Name = "Select Order/ Hearing Status")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]        
        public string OrderDateStatusTitle { get; set; }

        [Display(Name = "Order/ Hearing Remarks, If Any")]
        [StringLength(400, ErrorMessage = "Maximum length is 400")]
        public string OrderDateWithRemarksIfAny { get; set; }

        [Display(Name = "Remarks, If Any")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string RemarksIfAny { get; set; }

        [Display(Name = "Mobile Number of Promoter")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string A_column { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address of Promoter")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string B_column { get; set; }

        public string C_column { get; set; }
        public string D_column { get; set; }
        public string E_column { get; set; }

        [Display(Name = "Select Current Status")]        
        public int CurrentEvent_IdentifiedCode { get; set; }
        public string CurrentEvent_IdentifiedAggregateName { get; set; }
        public string CurrentEvent_IdentifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CurrentEvent_IdentifiedOn { get; set; }

        public int DeskAction_IdentifiedCode { get; set; }
        public string DeskAction_IdentifiedAggregateName { get; set; }
        public string DeskAction_IdentifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeskAction_IdentifiedOn { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }        
        public int IsDraftMember { get; set; }

        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }
        
        public string OfficeResComplainant_AddressStateCodeName { get; set; }
        public string OfficeResComplainant_AddressDistrictCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressStateCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressDistrictCodeName { get; set; }

        public List<ClsPrp_Print_NoticeSectionFiveNine> prpNoticeSectionFiveNine { get; set; }
        public ClsPrp_Print_NoticeSectionFiveNine()
        {
            prpNoticeSectionFiveNine = new List<ClsPrp_Print_NoticeSectionFiveNine>();
        }

        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_SubdivMaster> subdivisondistrictMaster { get; set; }

        public List<ClsPrp_Print_NoticeSectionFiveNine_HearingDetails> eCourtHearingRecords { get; set; }
    }
}