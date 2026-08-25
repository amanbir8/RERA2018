using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskComplaint
{
    public class ClsPrp_Master_Advocates
    {
        public long Advocate_IndexID { get; set; }
        public long Advocate_ID { get; set; }


        [Display(Name ="Diary Number")]
        public string DiaryNumber { get; set; }

        [Display(Name ="Complaint ID")]
        public string Complaint_ID { get; set; }

        public string Year { get; set; }

        public long ComplaintFormMN_ID { get; set; }

        public string TypeOfComplaintMN { get; set; }

        public string Profile_ID { get; set; }

        [Required]
        [Display(Name ="Advocate Name")]
        public string CounselRepresentative { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email ID")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Email { get; set; }

        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number.")]
        public string LandlineNumber { get; set; }

        [Display(Name = "Other members")]
        public string Othermembers { get; set; }

        [Required(ErrorMessage = "Experience Years is required.")]
        [Range(1, 100, ErrorMessage = "Experience Years must be between 1 and 100.")]
        public int? ExperienceYears { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AddressLine2 { get; set; }

        [Required]
        public int District { get; set; }
    
        [Required]
        public int State { get; set; }

        [Required]
        [Display(Name = "Address PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public int Pincode { get; set; }

        public string A_column { get; set; }

        public string B_column { get; set; }
        
        public string C_column { get; set; }

        public string D_column { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        public int IsActive { get; set; }

        public int IsLock { get; set; }

        public int IsFlag { get; set; }

        [Required(ErrorMessage = "Please select Yes or No.")]
        public int? IsPublicView { get; set; }


        public int IsDraft { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifyBy { get; set; }

        public DateTime ModifyOn { get; set; }

        // ========================================================================================

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dob { get; set; }

        [Required]
        [Display(Name ="Bar Registration Number")]
        public string BarRegNumber { get; set; }

        [Display(Name = "Bar Registration Code")]
        public string BarRegCode { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name = "PlaceofPractice")]
        public string PlaceofPractice { get; set; }

        [Required]
        [Display(Name = "Bar Registration State")]
        public int BarRegState { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please select Yes or No.")]
        public int? IsBarverified { get; set; }



        //    ----------------------------------------------------------------------------------------------------------------------------------------------------------

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


        public List<ClsPrp_Master_Advocates> prpadvocates { get; set; }
        public ClsPrp_Master_Advocates()
        {
            prpadvocates = new List<ClsPrp_Master_Advocates>();
        }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

    }
}