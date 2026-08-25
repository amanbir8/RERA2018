using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectQRcodeCertificateDetails
    {
        [Display(Name = "Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Project_Diary_ApplicationDate { get; set; }

        public long Project_ID { get; set; }
        public long Promoter_ID { get; set; }

        [Display(Name = "Project's Name")]
        public string Project_Name { get; set; }

        public string Project_Type { get; set; }
        [Display(Name = "Project's Type")]
        public string Project_TypeSTR { get; set; }

        public decimal Project_TotalArea { get; set; }
        [Display(Name = "Project's Total Area")]
        public string Project_TotalAreaSTR { get; set; }

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

        public int Promoter_Type { get; set; }
        [Display(Name = "Promoter Type")]
        public string Promoter_TypeSTR { get; set; }

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

        public List<Clsprp_MIS_ProjectQRcodeCertificateDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectQRcodeCertificateDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectQRcodeCertificateDetails>();
        }

    }
}