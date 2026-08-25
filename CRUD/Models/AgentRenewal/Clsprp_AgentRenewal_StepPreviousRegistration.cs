using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models.Master;
using System.ComponentModel.DataAnnotations;
using CRUD.Models.Promoter;

namespace CRUD.Models.AgentRenewal
{
    public class Clsprp_AgentRenewal_StepPreviousRegistration
    {
        public long AgentRenewal_StepPreviousRegistration_IndexID { get; set; }
        public long AgentRenewal_StepPreviousRegistration_ID { get; set; }

        public string RERAnumberRegistration { get; set; }

        public long Agent_ID { get; set; }
        public int Agent_Type { get; set; }
        public int Is_YesNo_AgentID_Flag { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalAgent_Year { get; set; }
        public int Renewal_OrderSequence { get; set; }
        public string Renewal_OrderSequence_Name { get; set; }
        
        public int Is_YesNo_RenewalAgentID_Flag { get; set; }
        public int Is_YesNo_RenewalAgentRegistered_Flag { get; set; }

        public int Is_YesNo_RenewalAgent_OtherMembers { get; set; }
        public int Is_YesNo_RenewalAgent_OtherStateUTnumber { get; set; }

        // Agent Renewal Permission Flag
        [Required]
        public int Is_YesNo_ValidforAgentRenewal_Flag { get; set; }
   
        public string A_column { get; set; }
        public string B_column { get; set; }

        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public List<Clsprp_AgentRenewal_StepPreviousRegistration> AgentStepRenewal { get; set; }
        public Clsprp_AgentRenewal_StepPreviousRegistration()
        {
            AgentStepRenewal = new List<Clsprp_AgentRenewal_StepPreviousRegistration>();
        }
    }
}