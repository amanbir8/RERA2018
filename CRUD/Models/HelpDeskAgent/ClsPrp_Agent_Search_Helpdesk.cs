using CRUD.Models.Document;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_Agent_Search_Helpdesk
    {
        public Int64 Agent_ID { get; set; }
        public Int32 BComm_AddressDistrictCode { get; set; }
        public string RERAnumberRegistration { get; set; }
        public DateTime? RERAnumberIssueDate { get; set; }
        public DateTime? RERAnumberRegUptoDate { get; set; }
        public string Agent_FirstName { get; set; }
        public string Agent_LastName { get; set; }
        public DateTime? AgentRERAcert_IssueDate { get; set; }
        public string AgentRERAcert_FilePath { get; set; }
        public string AgentRERAcert_FileName { get; set; }
        public string AgentRegDiaryNumber_Name { get; set; }
        public Int64 redAgent_ID { get; set; }
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_AddressDistrictName { get; set; }
        public DateTime? CreatedOn { get; set; }

        public List<ClsPrp_Agent_Search_Helpdesk> prpongoing { get; set; }
    }
}
