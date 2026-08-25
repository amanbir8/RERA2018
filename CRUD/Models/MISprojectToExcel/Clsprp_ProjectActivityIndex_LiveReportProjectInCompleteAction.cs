using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.MISprojectToExcel
{
    //Action Type Charts
    public class ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }
        public long projectaverageactivitynumber { get; set; }
    }

    public class ClsPrp_ProjectActivityIndex_PieChartsLiveReportProjectInCompleteActionRecords<T>
    {
        public ICollection<ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<T>> LiveReportProjectRecordsPieChartsData { get; set; }
    }
}