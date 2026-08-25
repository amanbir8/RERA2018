using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.MISprojectToExcel
{
    //Action Type Charts
    public class ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecordsPieChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }
        public long projectaverageactivitynumber { get; set; }
    }

    public class ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecords<T>
    {
        public ICollection<ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecordsPieChartsSeries<T>> LiveReportQUpdateProjectRecordsPieChartsData { get; set; }
    }
}