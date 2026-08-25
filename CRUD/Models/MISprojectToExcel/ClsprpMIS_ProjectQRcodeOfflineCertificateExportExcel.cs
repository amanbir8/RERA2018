using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel
    {
        [Display(Name = "Diary Number")]
        public string OfflineProject_ReferenceNumber { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineProject_IssueDate { get; set; }
        
        [Display(Name = "Project's Name")]
        public string OfflineProject_Name { get; set; }
        [Display(Name = "Project's Type")]
        public string OfflineProject_Type { get; set; }

        [Display(Name = "Project's Total Area")]
        public string OfflineProject_TotalArea { get; set; }

        [Display(Name = "Project Address")]
        public string OfflineProject_Address { get; set; }
        [Display(Name = "District of Business Place")]
        public string OfflineProject_BusinessPlaceDistrict { get; set; }

        [Display(Name = "Promoter's Name")]
        public string OfflinePromoter_Name { get; set; }

        [Display(Name = "Place of Business Address")]
        public string OfflinePromoter_BusinessPlace_Address { get; set; }

        [Display(Name = "Registration Number")]
        public string OfflineProject_RERAregistrationNumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineProject_RERAregistrationIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineProject_RERAregistrationValidUptoDate { get; set; }

        [Display(Name = "QR Code Image")]
        public object QRcodeImage_A { get; set; }

        [Display(Name = "QR Code Image")]
        public byte[] QRcodeImage_B { get; set; }

        [Display(Name = "QR Code Image")]
        public string QRcodeImage_C { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string OfflineProject_RemarksIfAny { get; set; }

        public List<Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel>();
        }
    }
}