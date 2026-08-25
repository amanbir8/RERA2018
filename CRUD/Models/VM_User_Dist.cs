using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class VM_User_Dist
    {
        public List<UserDetails>  user { get; set; }

        public List<District> district { get; set; }
    }
}