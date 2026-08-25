using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ClassComplaintPayment
{
    

    public class clsprp_onlinepayment
    {
        public long p_Onlinepayment_IndexID { get; set; }
        public long p_Onlinepayment_ID { get; set; }
        public string p_UserID { get; set; }
        public long p_Promoter_ID { get; set; }
        public long p_Project_ID { get; set; }
        public string p_projectname { get; set; }

        public string p_Extra1 { get; set; }
        public string p_Extra2 { get; set; }
        public string p_Extra3 { get; set; }
        public string p_Extra4 { get; set; }
        public string p_Extra5 { get; set; }

        public string p_p_Remarks_IfAny { get; set; }
        public Int32 p_p_IsDraft { get; set; }
        public string p_p_CreatedBy { get; set; }
        public string p_p_ModifyBy { get; set; }

         
    }
}