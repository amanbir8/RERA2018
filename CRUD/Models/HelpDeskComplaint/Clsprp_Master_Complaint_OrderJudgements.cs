using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class Clsprp_Master_Complaint_OrderJudgements
    {
        public int OrderJudgementDocMaster_IndexID { get; set; }
        public int OrderJudgementDocMaster_InfoCode { get; set; }
        public string OrderJudgementDocMaster_InfoName { get; set; }
        public string OrderJudgementDocMaster_RelatedSectionName { get; set; }
        public string OrderJudgementDoc_SetFileSize { get; set; }
        public string OrderJudgementDoc_SetFileFormat { get; set; }
        public string OrderJudgementDoc_SetFilePath { get; set; }
        public int OrderJudgementDoc_ValidCode { get; set; }
        public int OrderJudgementDoc_ValidSubCode { get; set; }
        public int OrderJudgementDoc_ValidTinySubCode { get; set; }
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

        public List<Clsprp_Master_Complaint_OrderJudgements> prpMasterOJdocs { get; set; }
        public Clsprp_Master_Complaint_OrderJudgements()
        {
            prpMasterOJdocs = new List<Clsprp_Master_Complaint_OrderJudgements>();
        }
    }
}