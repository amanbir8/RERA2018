using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentDocument
{
    public class Clsprp_Master_Agent_Documents
    {
        public int AgentDocMaster_IndexID { get; set; }
        public int AgentDocMaster_InfoCode { get; set; }
        public string AgentDocMaster_InfoName { get; set; }
        public string AgentDoc_SetFileSize { get; set; }
        public string AgentDoc_SetFileFormat { get; set; }
        public string AgentDoc_SetFilePath { get; set; }
        public int AgentDoc_ValidCode { get; set; }
        public int AgentDoc_ValidSubCode { get; set; }
        public int AgentDoc_ValidTinySubCode { get; set; }
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

        //public List<Clsprp_Master_Agent_Documents> MasterDocs { get; set; }

        public Clsprp_Master_Agent_Documents()
        {
           new List<Clsprp_Master_Agent_Documents>();
        }
    }
}