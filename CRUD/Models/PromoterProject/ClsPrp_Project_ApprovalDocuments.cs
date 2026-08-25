using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_ApprovalDocuments
    {
        public long ProjectApprovalDocMaster_IndexID { get; set; }
        public long ProjectApprovalDocMaster_InfoCode { get; set; }
        public string ProjectApprovalDocMaster_InfoName { get; set; }
        public string ProjectApprovalDoc_SetFileSize { get; set; }
        public string ProjectApprovalDoc_SetFileFormat { get; set; }
        public string ProjectApprovalDoc_SetFilePath { get; set; }
        public int ProjectApprovalDoc_ValidCode { get; set; }
        public int ProjectApprovalDoc_ValidSubCode { get; set; }
        public int ProjectApprovalDoc_ValidTinySubCode { get; set; }
        public int IsGroup { get; set; }
        public string IsMandatory { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
    }
}