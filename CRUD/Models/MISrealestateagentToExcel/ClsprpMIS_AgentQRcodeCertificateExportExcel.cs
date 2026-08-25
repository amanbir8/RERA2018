using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_AgentQRcodeCertificateExportExcel
    {
        [Display(Name = "Agent Diary Number")]
        public string Agent_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Application_Date { get; set; }

        [Display(Name = "Realestate Agent Name")]
        public string RealEstateAgent_Name { get; set; }

        [Display(Name = "Father's/ Authorized Person's Name")]
        public string Father_AuthorizedPerson_Name { get; set; }

        [Display(Name = "Agent Type")]
        public string Agent_Type { get; set; }

        [Display(Name = "Address Line-1")]
        public string BusinessPlace_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string BusinessPlace_AddressLine2 { get; set; }
        [Display(Name = "District")]
        public string BusinessPlace_District { get; set; }
        [Display(Name = "State")]
        public string BusinessPlace_State { get; set; }        
        [Display(Name = "PIN Code")]
        public string BusinessPlace_PIN { get; set; }

        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]        
        public string RERA_RegistrationNumber { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_RegistrationNumber_IssueDate { get; set; }
        
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_RegistrationNumber_ValidUptoDate { get; set; }

        [Display(Name = "QR Code Image")]
        public object QRcodeImage_A { get; set; }

        [Display(Name = "QR Code Image")]
        public byte[] QRcodeImage_B { get; set; }

        [Display(Name = "QR Code Image")]
        public string QRcodeImage_C { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        public List<Clsprp_MIS_AgentQRcodeCertificateExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_AgentQRcodeCertificateExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_AgentQRcodeCertificateExportExcel>();
        }

    }
}