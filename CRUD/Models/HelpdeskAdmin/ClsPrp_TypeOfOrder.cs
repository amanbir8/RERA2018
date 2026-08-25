using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_TypeOfOrder
    {
        public int typeofOrder_IndexID { get; set; }
        public int typeofOrder_ID { get; set; }
        public int typeofOrderCode { get; set; }
        public string typeofOrderName { get; set; }
        public string typeofOrderType { get; set; }
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<ClsPrp_TypeOfOrder> prpongoing { get; set; }
        public ClsPrp_TypeOfOrder()
        {
            prpongoing = new List<ClsPrp_TypeOfOrder>();
        }
    }
}