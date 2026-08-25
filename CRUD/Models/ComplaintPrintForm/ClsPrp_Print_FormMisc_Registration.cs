using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using System.Web.Mvc;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsPrp_Print_FormMisc_Registration
    {
        public long ComplaintMisc_IndexID { get; set; }
        public long ComplaintMisc_ID { get; set; }
        public long ComplaintMisc_Year { get; set; }

        [Display(Name = "Diary Number")]
        public string ComplaintMisc_Code { get; set; }
                
        public string ComplaintType_MNG { get; set; }

        [Display(Name = "Name of Complainant")]        
        public string Complainant_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]        
        public string Complainant_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Complainant")]        
        public long? Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Complainant")]        
        public long? Complainant_LandlineNumber { get; set; }

        [Display(Name = "Address for Communication")]
        public string Address_for_Communication { get; set; }

        [Display(Name = "Name of Project")]        
        public string Project_Name { get; set; }

        [Display(Name = "Official/ Residential/ Project Address")]        
        public string Project_Address { get; set; }

        [Display(Name = "Landmark/ Colony/ Village/ Location of Project, If any")]
        public string Village_Sector_Tehsil_Location_of_Project { get; set; }

        [Display(Name = "Details of Complaint/ Information")]        
        public string Complaint_Information_Details { get; set; }

        [Display(Name = "Enclosure/ Document Name")]        
        public string ComplaintDocI_InfoName { get; set; }

        public DateTime ComplaintDocI_IssueDate { get; set; }
        public string ComplaintDocI_FileSize { get; set; }
        public string ComplaintDocI_FileFormat { get; set; }
        public string ComplaintDocI_FilePath { get; set; }
        public string ComplaintDocI_FileName { get; set; }
        public int? ComplaintDocI_PageStartNumber { get; set; }
        public int? ComplaintDocI_PageEndNumber { get; set; }

        [Display(Name = "Enclosure/ Document Name")]        
        public string ComplaintDocII_InfoName { get; set; }

        public DateTime ComplaintDocII_IssueDate { get; set; }
        public string ComplaintDocII_FileSize { get; set; }
        public string ComplaintDocII_FileFormat { get; set; }
        public string ComplaintDocII_FilePath { get; set; }
        public string ComplaintDocII_FileName { get; set; }
        public int? ComplaintDocII_PageStartNumber { get; set; }
        public int? ComplaintDocII_PageEndNumber { get; set; }

        [Display(Name = "Enclosure/ Document Name")]        
        public string ComplaintDocIII_InfoName { get; set; }

        public DateTime ComplaintDocIII_IssueDate { get; set; }
        public string ComplaintDocIII_FileSize { get; set; }
        public string ComplaintDocIII_FileFormat { get; set; }
        public string ComplaintDocIII_FilePath { get; set; }
        public string ComplaintDocIII_FileName { get; set; }
        public int? ComplaintDocIII_PageStartNumber { get; set; }
        public int? ComplaintDocIII_PageEndNumber { get; set; }


        public int IsVerificationComplete { get; set; }

        [Display(Name = "Complaint Verification Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ComplaintVerificationDate { get; set; }

        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }

        public string CreatedBy { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public long zapRelated_Complaint_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }

        public List<ClsPrp_Print_FormMisc_Registration> ComplaintMisc { get; set; }
        public ClsPrp_Print_FormMisc_Registration()
        {
            ComplaintMisc = new List<ClsPrp_Print_FormMisc_Registration>();
        }        
    }
}