using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class CombinedVM
    {
        public List<Clsprp_MIS_AgentAddressDirectoryDetails> Agents { get; set; }
        public List<Clsprp_MIS_RenewalAgentAddressDirectoryDetails> Renewals { get; set; }
    }
}