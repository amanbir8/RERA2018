using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models.Agent;
using CRUD.Models.Promoter;

namespace CRUD.Models.Agent
{
    public class ClsprpAgent_ExisitingRera
    {
        public long AgentExistingRERA_ID { get; set; }
        public string RERA_RegNumber { get; set; }
        public System.DateTime Date_of_Issue { get; set; }
        public string Agent_FirstName { get; set; }
        public string Agent_MiddleName { get; set; }
        public string Agent_LastName { get; set; }
        public string Organization_Name { get; set; }
        public Nullable<int> Organization_TypeCode { get; set; }
        public Nullable<int> P_AddressStateCode { get; set; }
        public Nullable<int> P_AddressDistrictCode { get; set; }
        public Nullable<int> RegOffice_AddressStateCode { get; set; }
        public Nullable<int> RegOffice_AddressDistrictCode { get; set; }
        public Nullable<int> BusinessPlace_AddressStateCode { get; set; }
        public Nullable<int> BusinessPlace_AddressDistrictCode { get; set; }
        public Nullable<int> BComm_AddressStateCode { get; set; }
        public Nullable<int> BComm_AddressDistrictCode { get; set; }
        public int IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }

        public string EnableStatus { get; set; }
        public string FlagStatus { get; set; }
        public string MessageStatus { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsprpAgent_ExisitingRera> Agent { get; set; }

    }
}