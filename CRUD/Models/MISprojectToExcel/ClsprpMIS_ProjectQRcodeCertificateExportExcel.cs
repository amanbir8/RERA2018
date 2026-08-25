using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectQRcodeCertificateExportExcel
    {
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Application_Date { get; set; }

        [Display(Name = "Project's Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Project's Type")]
        public string Project_Type { get; set; }

        [Display(Name = "Project's Total Area")]
        public string Project_TotalArea { get; set; }

        [Display(Name = "Address Line-1")]
        public string Project_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string Project_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public string Project_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public string Project_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string Project_AddressPIN { get; set; }

        [Display(Name = "Promoter's Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Promoter Type")]
        public string Promoter_Type { get; set; }

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

        public List<Clsprp_MIS_ProjectQRcodeCertificateExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectQRcodeCertificateExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectQRcodeCertificateExportExcel>();
        }
    }
}