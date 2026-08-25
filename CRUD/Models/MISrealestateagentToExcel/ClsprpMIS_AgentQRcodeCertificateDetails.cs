using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_AgentQRcodeCertificateDetails
    {
        [Display(Name = "Diary Number")]
        public string Agent_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Agent_Diary_ApplicationDate { get; set; }

        public long Agent_ID { get; set; }
        public int Agent_Type { get; set; }
        [Display(Name = "Agent Type")]
        public string Agent_TypeSTR { get; set; }
        
        [Display(Name = "Realestate Agent Name")]
        public string Agent_Organization_Name { get; set; }

        [Display(Name = "Father's/ Authorized Person's Name")]
        public string Agent_Father_AuthorizedPerson_Name { get; set; }

        [Display(Name = "Address Line-1")]
        public string BusinessPlace_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string BusinessPlace_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public string BusinessPlace_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public string BusinessPlace_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string BusinessPlace_AddressPIN { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]        
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "QR Code")]
        public object QRcodeImage_A { get; set; }

        [Display(Name = "QR Code")]
        public byte[] QRcodeImage_B { get; set; }

        [Display(Name = "QR Code")]
        public string QRcodeImage_C { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        //Search Params
        [Required]
        [Display(Name = "Date")]
        public int IsApplicationDateFlag { get; set; }
        [Required]
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }
        [Required]
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Required]
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Required]
        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }
        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public List<Clsprp_MIS_AgentQRcodeCertificateDetails> prpongoing { get; set; }
        public Clsprp_MIS_AgentQRcodeCertificateDetails()
        {
            prpongoing = new List<Clsprp_MIS_AgentQRcodeCertificateDetails>();
        }

    }
}