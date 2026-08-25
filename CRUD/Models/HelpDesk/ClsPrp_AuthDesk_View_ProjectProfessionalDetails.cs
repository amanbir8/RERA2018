using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ProjectProfessionalDetails
    {
        public long ProjectProfessional_IndexID { get; set; }
        public long ProjectProfessional_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectProfessionalRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Associated Consultant Type")]
        public string Associated_Consultant_Type { get; set; }

        [Required]
        [Display(Name = "Name of Professional")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string Name_of_Professional { get; set; }

        [Display(Name = "Ref Number/Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERA_ID_IfAgent { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name and Year of Establishment of Promoter")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Name_and_Year_of_Establishment_of_Promoter { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name and Profile of Key Projects Completed ")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Name_and_Profile_of_Key_ProjectsCompleted { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string OfficialComm_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string OfficialComm_AddressLine2 { get; set; }

        [Required(ErrorMessage = "The Address State field is required.")]
        [Display(Name = "State")]
        public string OfficialComm_AddressStateCode { get; set; }

        [Required(ErrorMessage = "The Address District field is required.")]
        [Display(Name = "District")]
        public string OfficialComm_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string OfficialComm_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public long MobileNumber { get; set; }

        public Nullable<long> Phone_STD { get; set; }

        [Display(Name = "Landline Number")]
        public Nullable<long> Phone_Number { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email_ID { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string A_column { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }



        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        
        
        public int IsDraftAllProfessionals { get; set; }


        public List<ClsPrp_AuthDesk_View_ProjectProfessionalDetails> prpongoing { get; set; }
        public ClsPrp_AuthDesk_View_ProjectProfessionalDetails()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ProjectProfessionalDetails>();

        }
        public List<Clsprp_AuthDesk_View_ProjectDocuments> ProjectDocumentsList { get; set; }
    }
}