using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.MISprojectToExcel
{
    //Average Charts
    public class ClsPrp_ProjectAverageActivity_LiveReportProjectAverageRecordsPieChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }
        public long projectaverageactivitynumber { get; set; }
    }

    public class ClsPrp_ProjectAverageActivity_PieChartsLiveReportProjectAverageRecords<T>
    {
        public ICollection<ClsPrp_ProjectAverageActivity_LiveReportProjectAverageRecordsPieChartsSeries<T>> LiveReportProjectAverageRecordsPieChartsData { get; set; }
    }

    //Detail Charts
    public class ClsPrp_ProjectIndexActivity_LiveReportProjectRecordsRotatelevelsChartsSeries<T>
    {
        public string name { get; set; }
        public decimal y { get; set; }        
    }

    public class ClsPrp_ProjectIndexActivity_RotatelevelsChartsLiveReportProjectRecords<T>
    {
        public ICollection<ClsPrp_ProjectIndexActivity_LiveReportProjectRecordsRotatelevelsChartsSeries<T>> LiveReportProjectIndexRecordsRotatelevelsChartsData { get; set; }
    }

    //Elementary Charts
    public class ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<T>
    {
        public int collectionvalue { get; set; }
    }

    public class ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<T>
    {
        public int processedvalue { get; set; }
    }

    public class ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<T>
    {
        public string name { get; set; }        
    }

    public class ClsPrp_ProjectIndexActivity_SpiderWebChartsLiveReportProjectRecords<T>
    {
        public ICollection<ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<T>> LiveReportProjectIndexSpiderChartsTitleData { get; set; }
        public ICollection<ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<T>> LiveReportProjectIndexSpiderChartsCollectionData { get; set; }
        public ICollection<ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<T>> LiveReportProjectIndexSpiderChartsProcessedData { get; set; }
    }
}