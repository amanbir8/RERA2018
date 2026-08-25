using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class Clsprp_Master_Project_InventoryList
    {
        public int InventoryList_IndexID { get; set; }
        public int InventoryList_ID { get; set; }
        public string InventoryListName { get; set; }
        public string InventoryListDescription { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }        

        public List<Clsprp_Master_Project_InventoryList> MasterInventoryList { get; set; }
        public Clsprp_Master_Project_InventoryList()
        {
            MasterInventoryList = new List<Clsprp_Master_Project_InventoryList>();
        }
    }
}