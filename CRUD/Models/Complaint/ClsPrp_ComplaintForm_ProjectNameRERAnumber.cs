using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintForm_ProjectNameRERAnumber
    {
        public long Project_RERAnumber_DiaryNumber_IndexID { get; set; }
        public string ProjectName { get; set; }
        public string RERAnumberRegistration { get; set; }

        public List<ClsPrp_ComplaintForm_ProjectNameRERAnumber> ProjectNameReraNo { get; set; }
        public ClsPrp_ComplaintForm_ProjectNameRERAnumber()
        {
            ProjectNameReraNo = new List<ClsPrp_ComplaintForm_ProjectNameRERAnumber>();
        }
    }
}