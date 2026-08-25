using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ComplaintExecution
{
    public class ClsPrp_ExecutionForm_FlagStep
    {
        public long ExecutionForm_IndexId { get; set; }
        public long ExecutionForm_ID { get; set; }
        public string ExecutionForm_Code { get; set; }
        public long Related_ComplaintFormMId { get; set; }
        public int Related_FormExe_SequenceID { get; set; }
        public int Related_FormExe_Year { get; set; }
        public long Profile_Id { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType { get; set; }

        public int IsComplaintComplete { get; set; }
        public int IsPaymentComplete { get; set; }
        public int IsDocumentsComplete { get; set; }
        public int IsVerificationComplete { get; set; }

        [Display(Name = "File Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ComplaintVerificationDate { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public List<ClsPrp_ExecutionForm_FlagStep> ComplaintFormMstepFlag { get; set; }
        public ClsPrp_ExecutionForm_FlagStep()
        {
            ComplaintFormMstepFlag = new List<ClsPrp_ExecutionForm_FlagStep>();
        }
    }
}