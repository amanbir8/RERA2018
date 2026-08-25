using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel
    {
        [Display(Name = "Diary Number")]
        public string OfflineAgents_ReferenceNumber { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_IssueDate { get; set; }

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
      
        [Display(Name = "QR Code")]
        public object QRcodeImage_A { get; set; }

        [Display(Name = "QR Code")]
        public byte[] QRcodeImage_B { get; set; }

        [Display(Name = "QR Code")]
        public string QRcodeImage_C { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string OfflineAgents_RemarksIfAny { get; set; }

        public List<Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_AgentQRcodeOfflineCertificateExportExcel>();
        }

    }
}