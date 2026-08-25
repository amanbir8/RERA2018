using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class Clsprp_Master_Project_PhotographStatusTitleList
    {
        public int StatusTitleList_IndexID { get; set; }
        public int StatusTitleList_ID { get; set; }
        public string StatusTitleListName { get; set; }
        public string StatusTitleListDescription { get; set; }
        public int StatusTitleFlag { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<Clsprp_Master_Project_PhotographStatusTitleList> MasterPhotographStatusList { get; set; }
        public Clsprp_Master_Project_PhotographStatusTitleList()
        {
            MasterPhotographStatusList = new List<Clsprp_Master_Project_PhotographStatusTitleList>();
        }
    }
}