using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class Clsprp_Master_Project_PhotographFileSizeCount
    {

        public int StatusTitleList_IndexID { get; set; }
        public int StatusTitleList_ID { get; set; }
        public string StatusTitleListName { get; set; }
        public string StatusTitleListDescription { get; set; }
        public string StatusImg_RelatedSectionName { get; set; }
        public string StatusImg_SetFileSize { get; set; }
        public string StatusImg_SetFileFormat { get; set; }
        public string StatusImg_SetFilePath { get; set; }
        public int StatusTitleFlag { get; set; }
        public int StatusImg_ValidCode { get; set; }
        public int StatusImg_ValidSubCode { get; set; }
        public int IsGroup { get; set; }
        public int IsMandatory { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public List<Clsprp_Master_Project_PhotographFileSizeCount> MasterPhotographFileSizeCount { get; set; }
        public Clsprp_Master_Project_PhotographFileSizeCount()
        {
            MasterPhotographFileSizeCount = new List<Clsprp_Master_Project_PhotographFileSizeCount>();
        }

    }
}