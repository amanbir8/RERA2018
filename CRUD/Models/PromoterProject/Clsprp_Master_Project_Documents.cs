using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class Clsprp_Master_Project_Documents
    {
        public int ProjectDocMaster_IndexID { get; set; }
        public int ProjectDocMaster_InfoCode { get; set; }
        public string ProjectDocMaster_InfoName { get; set; }
        public string ProjectDocMaster_RelatedSectionName { get; set; }
        public string ProjectDoc_SetFileSize { get; set; }
        public string ProjectDoc_SetFileFormat { get; set; }
        public string ProjectDoc_SetFilePath { get; set; }
        public int ProjectDoc_ValidCode { get; set; }
        public int ProjectDoc_ValidSubCode { get; set; }
        public int ProjectDoc_ValidTinySubCode { get; set; }
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

        //public List<Clsprp_Master_Promoter_Documents> MasterDocs { get; set; }

        public Clsprp_Master_Project_Documents()
        {
           new List<Clsprp_Master_Project_Documents>();
        }
    }
}