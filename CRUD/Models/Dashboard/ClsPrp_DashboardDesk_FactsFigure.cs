using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.Dashboard
{
    public class ClsPrp_DashboardDesk_FactsFigure
    {

        [Display(Name = "Number of Registered Projects")]
        public long Number_RegisteredProjects { get; set; }
        [Display(Name = "Number of Registered Real-Estate Agents")]
        public long Number_RegisteredAgents { get; set; }

        [Display(Name = "Number of Decided Complaints")]
        public long Number_DecidedComplaints { get; set; }
        [Display(Name = "Number of Pending Projects")]
        public long Number_PendingProjects { get; set; }

        [Display(Name = "Number of Section 31 Complaints")]
        public long Number_SectionThreeOneComplaints { get; set; }
        [Display(Name = "Number of Section 59 Complaints")]
        public long Number_SectionFiveNineComplaints { get; set; }

        [Display(Name = "Number of Payment Transactions")]
        public long Number_PaymentTransactions { get; set; }
        [Display(Name = "Number of Total Amount")]
        public long Number_TotalAmount { get; set; }



        [Display(Name = "Registered Projects Title")]
        public string Title_RegisteredProjects { get; set; }
        [Display(Name = "Registered Real-Estate Agents Title")]
        public string Title_RegisteredAgents { get; set; }

        [Display(Name = "Decided Complaints Title")]
        public string Title_DecidedComplaints { get; set; }
        [Display(Name = "Pending Projects Title")]
        public string Title_PendingProjects { get; set; }

        [Display(Name = "Section 31 Complaints Title")]
        public string Title_SectionThreeOneComplaints { get; set; }
        [Display(Name = "Section 59 Complaints Title")]
        public string Title_SectionFiveNineComplaints { get; set; }

        [Display(Name = "Payment Transactions Title")]
        public string Title_PaymentTransactions { get; set; }
        [Display(Name = "Total Amount Title")]
        public string Title_TotalAmount { get; set; }


        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }
        public string D_Column { get; set; }


        [Display(Name = "Date of Issue")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }


        public List<ClsPrp_DashboardDesk_FactsFigure> prpFactsFigure { get; set; }
        public ClsPrp_DashboardDesk_FactsFigure()
        {
            prpFactsFigure = new List<ClsPrp_DashboardDesk_FactsFigure>();
        } 
         
    }
}