using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ComplaintExecution
{
    public class ClsPrp_Master_HearingBenchDetails
    {
        public int PreHearingBench_IndexID { get; set; }
        public int PreHearingBench_ID { get; set; }
        public int PreHearingBenchCode { get; set; }
        public string PreHearingBenchName { get; set; }
        public string PreHearingType { get; set; }
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<ClsPrp_Master_HearingBenchDetails> prpongoing { get; set; }
        public ClsPrp_Master_HearingBenchDetails()
        {
            prpongoing = new List<ClsPrp_Master_HearingBenchDetails>();
        }
    }
}