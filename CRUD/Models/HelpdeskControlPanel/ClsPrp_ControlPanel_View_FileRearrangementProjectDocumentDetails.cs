using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.HelpDesk;
using CRUD.Models.PromoterProject;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails
    {     
        public long ProjectDoc_IndexID { get; set; }
        public long ProjectDoc_ID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }

        [Required(ErrorMessage = "Document Name is required.")]
        [Display(Name = "Document Name")]
        public int ProjectDoc_InfoCode { get; set; }
        public string ProjectDoc_InfoName { get; set; }

        [Display(Name = "Document Related To")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectDoc_RelatedSectionName { get; set; }

        [Required(ErrorMessage = "Reference Number is required.")]
        [Display(Name = "Reference Number")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectDoc_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Reference/Upload Date is required.")]
        [Display(Name = "Reference/Upload Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime? ProjectDoc_IssueDate { get; set; }

        public string ProjectDoc_FileSize { get; set; }
        public string ProjectDoc_FileFormat { get; set; }
        public string ProjectDoc_FilePath { get; set; }
        public string ProjectDoc_FileName { get; set; }
        public int ProjectDoc_IsGroup { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERA_RegistrationNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        public int IsRERAregisteredProject { get; set; }

        public string Extra01_column { get; set; }
        public string Extra02_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Display(Name = "Search By")]
        public int Application_SearchTypeFlag { get; set; }

        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }

        [Display(Name = "Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ProjectDiaryNumber_Input { get; set; }

        public int IsUpdateModifyFlag_ProjectDocument { get; set; }

        [Display(Name = "Document Name (Update/Modify)")]
        public int ProjectDoc_InfoCode_Input { get; set; }
        [Display(Name = "Confirm Document Name (Update/Modify)")]
        public int ProjectDoc_InfoCode_ConfirmInput { get; set; }

        [Display(Name = "Reference Number (Update/Modify)")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectDoc_ReferenceNumber_Input { get; set; }

        [Display(Name = "Remarks, If Any (Update/Modify)")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string Remarks_IfAny_Input { get; set; }

        public List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_FileRearrangementProjectDocumentDetails>();
        }

        public List<Clsprp_Master_Project_Documents> prpMasterDocs { get; set; }
        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
    }
}