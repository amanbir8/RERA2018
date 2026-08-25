using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.ComplaintPrint
{
    public class Clsprp_Print_FormM_Documents
    {
        public long ListEnclDocument_IndexID { get; set; }
        public long ListEnclDocument_ID { get; set; }
        public long ComplainantApplicant_RelatedComplaint_ID { get; set; }
        public string ComplainantApplicant_RelatedComplaint_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }

        public string ComplaintType_MN { get; set; }
        
        public string ComplaintDoc_InfoCode { get; set; }

        [Display(Name = "Enclosure/ Document Name")]
        public string ComplaintDoc_InfoName { get; set; }

        [Display(Name = "Document Reference Number")]        
        public string ComplaintDoc_ReferenceNumber { get; set; }

        [Display(Name = "Date of Document Upload")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime? ComplaintDoc_IssueDate { get; set; }

        public string ComplaintDoc_FileSize { get; set; }
        public string ComplaintDoc_FileFormat { get; set; }
        public string ComplaintDoc_FilePath { get; set; }
        public string ComplaintDoc_FileName { get; set; }
        public int ComplaintDoc_IsGroup { get; set; }

        [Display(Name = "Serial Number")]
        public string Doc_SerialNumber { get; set; }
        
        [Display(Name = "Number of Pages (Enclosure/ Document)")]        
        public int Doc_PageStartNumber { get; set; }

        public int Doc_PageEndNumber { get; set; }

        [Display(Name = "Remarks, If Any")]       
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }      

        public List<Clsprp_Print_FormM_Documents> prpFormM_Docs { get; set; }
        public Clsprp_Print_FormM_Documents()
        {
            prpFormM_Docs = new List<Clsprp_Print_FormM_Documents>();
        }
    }
}