
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web; 

namespace CRUD.Models.UserAccess
{
    public partial class Clsprp_UserAccess
    {
        public List<ClsPrp_UserAccessType> useraccesstype { get; set; }
        public List<ClsPrp_UserAccessTypeAgent> useraccesstypeAgent { get; set; }
    }
}