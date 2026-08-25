using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentRenewal
{
    public class Clsprp_AgentRenewal_ReviewMaster
    {
        public long Related_AgentRenewal_ID { get; set; }
        public int Related_AgentRenewal_SequenceID { get; set; }
        public int Related_AgentRenewal_Year { get; set; }
        public string SequenceID_Name { get; set; }
        public string Registration_Number { get; set; }
        public string Reference_Agent_DiaryNumber { get; set; }
        public long Related_Agent_ID { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Registration_OtherMember_YN_Flag { get; set; }
        public string Registration_OtherRERA_YN_Flag { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }
        public int IsDraftMember { get; set; }

        public List<Clsprp_AgentRenewal_ReviewMaster> AgentRenewal_list { get; set; }
        public Clsprp_AgentRenewal_ReviewMaster()
        {
            AgentRenewal_list = new List<Clsprp_AgentRenewal_ReviewMaster>();
        }
    }

    public class Clsprp_AgentRenewal_ExtractDetails_ReviewMaster
    {
        public long Related_AgentRenewal_ID { get; set; }
        public int Related_AgentRenewal_SequenceID { get; set; }
        public int Related_AgentRenewal_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_Registration_Number { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Registration_OtherMember_YN_Flag { get; set; }
        public string Registration_OtherRERA_YN_Flag { get; set; }

        public List<Clsprp_AgentRenewal_ExtractDetails_ReviewMaster> AgentRenewal_extractlist { get; set; }
        public Clsprp_AgentRenewal_ExtractDetails_ReviewMaster()
        {
            AgentRenewal_extractlist = new List<Clsprp_AgentRenewal_ExtractDetails_ReviewMaster>();
        }
    }
}
