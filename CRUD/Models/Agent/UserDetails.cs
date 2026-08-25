using CRUD.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.Agent
{
    
        public class UserDetails
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Education { get; set; }
            public string Location { get; set; }

            public List<Clsprp_DistrictMaster> districtMaster { get; set; }
            public List<ClsPrp_StateMaster> stateMaster { get; set; }

            public List<UserDetails> usersinfo { get; set; }




        }
    }
