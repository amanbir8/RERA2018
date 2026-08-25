using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_UploadFilePDF
    {

        public long UploadFilePDF_IndexID { get; set; }
        public long UploadFilePDF_ID { get; set; }        

        [Display(Name = "Reference File Info")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string FileReferenceType { get; set; }

        [Display(Name = "Reference File Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string FileReferenceName { get; set; }

        [Display(Name = "Date of Prepared/Issue/Upload")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_UploadorIssue { get; set; }

        public string UploadFilePDF_BaseUrl { get; set; }
        public string UploadFilePDF_FilePath { get; set; }

        [Display(Name = "Document or File (PDF)")]
        public string UploadFilePDF_FileName { get; set; }
        public string UploadFilePDF_FileType { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftMember { get; set; }
        
        public string CreatedBy { get; set; }
        [Display(Name = "Date of Upload")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public List<ClsPrp_AdminDesk_UploadFilePDF> prpUploadFilePDF { get; set; }
        public ClsPrp_AdminDesk_UploadFilePDF()
        {
            prpUploadFilePDF = new List<ClsPrp_AdminDesk_UploadFilePDF>();
        } 
         
    }
}