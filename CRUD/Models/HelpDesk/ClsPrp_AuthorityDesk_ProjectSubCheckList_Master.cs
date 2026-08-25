using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectSubCheckList_Master
    {
        public int SubCheckList_IndexID { get; set; }
        public int SubCheckList_ID { get; set; }
        [Display(Name = "Check List Title")]
        public string SubCheckListName { get; set; }
        [Display(Name = "Check List Description")]
        public string SubCheckListDescription { get; set; }
        public int CheckList_ID { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }


        //public List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master> prpongoing { get; set; }
        //public ClsPrp_AuthorityDesk_ProjectSubCheckList_Master()
        //{
        //    prpongoing = new List<ClsPrp_AuthorityDesk_ProjectSubCheckList_Master>();

        //}        
    }
}