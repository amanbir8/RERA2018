using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_AgentQRcodeOfflineCertificateDetails
    {
        public long OfflineAgents_IndexID { get; set; }
        public long OfflineAgents_ID { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_IssueDate { get; set; }

        [Display(Name = "Diary Number")]
        public string OfflineAgents_ReferenceNumber { get; set; }

        [Display(Name = "Agent Type")]
        public string OfflineAgents_AgentType { get; set; }

        [Display(Name = "Realestate Agent Name")]
        public string OfflineAgents_AgentName_OrganizationName { get; set; }
        
        [Display(Name = "Father's Name and Permanent Address/ Registered Address")]
        public string OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress { get; set; }

        [Display(Name = "Registration Number")]
        public string OfflineAgents_RERAregistrationNumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_RERAregistrationIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_RERAregistrationValidUptoDate { get; set; }

        [Display(Name = "Place of Business Address")]
        public string OfflineAgents_PlaceOfBussinessAddress { get; set; }
        [Display(Name = "District of Business Place")]
        public string OfflineAgents_BusinessPlaceDistrict { get; set; }
        [Display(Name = "Contact Details (Email Address and Mobile Number)")]
        public string OfflineAgents_ContactDetails { get; set; }
        [Display(Name = "Remarks, If Any")]
        public string OfflineAgents_RemarksIfAny { get; set; }
        
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        [Display(Name = "QR Code")]
        public object QRcodeImage_A { get; set; }

        [Display(Name = "QR Code")]
        public byte[] QRcodeImage_B { get; set; }

        [Display(Name = "QR Code")]
        public string QRcodeImage_C { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsPublicView { get; set; }
        public int IsCertificate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

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

        public List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> prpongoing { get; set; }
        public Clsprp_MIS_AgentQRcodeOfflineCertificateDetails()
        {
            prpongoing = new List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails>();
        }

    }
}