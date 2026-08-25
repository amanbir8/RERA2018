using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.Agent
{
    public class CLSprpRERA_Agent_Payment
    {

        public long AgentPayment_IndexID { get; set; }
        public Nullable<long> AgentPayment_ID { get; set; }
        public Nullable<long> Agent_ID { get; set; }
        public Nullable<int> AgentPayment_TitleCode { get; set; }
        public string AgentPayment_TitleName { get; set; }
        public Nullable<decimal> Registration_Fee { get; set; }
        public Nullable<decimal> Other_Fee { get; set; }
        public string Payment_Mode { get; set; }
        public Nullable<System.DateTime> Date_of_Payment_RegistrationFee { get; set; }
        public Nullable<decimal> Bank_Charges { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public Nullable<long> DD_BankersCheque_Number { get; set; }
        public Nullable<decimal> DD_BankersCheque_Amount { get; set; }
        public string ImageDDorBankersCheque_FileName { get; set; }
        public string ImageDDorBankersCheque_FilePath { get; set; }
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifyBy { get; set; }
    }
}