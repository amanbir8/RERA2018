using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.Document
{
    public class Clsprp_Master_Promoter_Documents
    {
        public int PromoterDocMaster_IndexID { get; set; }
        public int PromoterDocMaster_InfoCode { get; set; }
        public string PromoterDocMaster_InfoName { get; set; }
        public string PromoterDoc_SetFileSize { get; set; }
        public string PromoterDoc_SetFileFormat { get; set; }
        public string PromoterDoc_SetFilePath { get; set; }
        public int PromoterDoc_ValidCode { get; set; }
        public int PromoterDoc_ValidSubCode { get; set; }
        public int PromoterDoc_ValidTinySubCode { get; set; }
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

        public Clsprp_Master_Promoter_Documents()
        {
           new List<Clsprp_Master_Promoter_Documents>();
        }
    }
}