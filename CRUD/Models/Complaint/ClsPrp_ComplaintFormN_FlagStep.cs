using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintFormN_FlagStep
    {

        public long ComplaintFormN_IndexID { get; set; }
        public long ComplaintFormN_ID { get; set; }
        public string ComplaintFormN_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }

        public int IsComplaintComplete { get; set; }
        public int IsPaymentComplete { get; set; }
        public int IsDocumentsComplete { get; set; }
        public int IsVerificationComplete { get; set; }

        [Display(Name = "Complaint File Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ComplaintVerificationDate { get; set; }        

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public List<ClsPrp_ComplaintFormN_FlagStep> ComplaintFormNstepFlag { get; set; }
        public ClsPrp_ComplaintFormN_FlagStep()
        {
            ComplaintFormNstepFlag = new List<ClsPrp_ComplaintFormN_FlagStep>();
        }               
    }
}