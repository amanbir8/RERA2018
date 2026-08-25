using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_Email_ComplaintFormM
    {
        public long AdditionalEmailFormM_IndexID { get; set; }
        public long AdditionalEmailFormM_ID { get; set; }
        public long ComplaintFormM_ID { get; set; }
        public string ComplaintFormM_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }

        [Required]
        [Display(Name = "Complaint Type")]
        public string ComplaintType_MN { get; set; }

        [Required]
        [Display(Name = "Diary Number")]
        [StringLength(60, ErrorMessage = "Maximum length is 60")]
        public string Complaint_DiaryNumber_Name { get; set; }

        [Required]
        [Display(Name = "Complaint Transfer Info")]
        [StringLength(60, ErrorMessage = "Maximum length is 60")]
        public string IsComplaintTransferFromTo { get; set; }

        [Display(Name = "Transfer Diary Number")]
        [StringLength(60, ErrorMessage = "Maximum length is 60")]
        public string Complaint_TransferDiaryNumber_Name { get; set; }

        [Required]
        [Display(Name = "Name of Complainant")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Complainant_Name { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string OfficeResComplainant_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Address State")]
        public Nullable<int> OfficeResComplainant_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "Address District")]
        public Nullable<int> OfficeResComplainant_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string OfficeResComplainant_AddressPIN { get; set; }
        

        [Display(Name = "Name of Authorized Representative/ Counsel")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedRepresentativeCounsel_Name { get; set; }

        [Required]
        [Display(Name = "Complaint Against")]
        public string RelatesComplaint_ComplaintAgainstType { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number of Project/ Agent to which the Complaint relates")]
        [StringLength(90, MinimumLength = 17, ErrorMessage = "Invalid RERA Number or Invalid length of RERA Number.")]
        public string RelatesComplaint_ProjectAgent_RERA_RegNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name of the Real Estate Project/ Agent to which the Complaint relates")]
        [StringLength(450, ErrorMessage = "Maximum length is 450")]
        public string RelatesComplaint_ProjectAgent_Name { get; set; }

        [Required]
        [Display(Name = "Name of Respondent")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Respondent_Name { get; set; }


        [Required]
        [Display(Name = "Contact Person/ Employee Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[()0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string AE_ContactName { get; set; }

        [Required]
        [Display(Name = "Contact Person to which the relates")]        
        public string AE_Designation { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string AE_ReferenceName { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AE_ReferenceDate { get; set; }

        [Display(Name = "Type of Email")]
        public string AE_EmailType { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AE_EmailAddress { get; set; }

        [Display(Name = "Remarks If Any")]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string RemarksIfAny { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        [Display(Name = "Is Locked (Yes/No)?")]
        public int IsLock { get; set; }
        public int IsApproval { get; set; }
        [Display(Name = "Is Verified Number?")]
        public int IsVerified { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }


        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }


        public List<ClsPrp_ControlPanel_View_Email_ComplaintFormM> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_Email_ComplaintFormM()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_Email_ComplaintFormM>();
        }

        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_SubdivMaster> SubdivMaster { get; set; }
    }
}