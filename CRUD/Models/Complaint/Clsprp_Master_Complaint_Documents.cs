using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Complaint
{
    public class Clsprp_Master_Complaint_Documents
    {
        public int ComplaintDocMaster_IndexID { get; set; }
        public int ComplaintDocMaster_InfoCode { get; set; }
        public string ComplaintDocMaster_InfoName { get; set; }
        public string ComplaintDocMaster_RelatedSectionName { get; set; }
        public string ComplaintDoc_SetFileSize { get; set; }
        public string ComplaintDoc_SetFileFormat { get; set; }
        public string ComplaintDoc_SetFilePath { get; set; }
        public int ComplaintDoc_ValidCode { get; set; }
        public int ComplaintDoc_ValidSubCode { get; set; }
        public int ComplaintDoc_ValidTinySubCode { get; set; }
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

        public List<Clsprp_Master_Complaint_Documents> prpMasterDocs { get; set; }
        public Clsprp_Master_Complaint_Documents()
        {
            prpMasterDocs = new List<Clsprp_Master_Complaint_Documents>();
        }
    }
}