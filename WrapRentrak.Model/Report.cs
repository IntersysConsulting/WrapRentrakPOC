using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrapRentrak.Model
{
    public class Report
    {
        public int ReportId { get; set; }
        public int CategoryId { get; set; }
        public string ReportName { get; set; }
        public string Market { get; set; }
        public string Station { get; set; }
        public string Date { get; set; }
        public string Demo { get; set; }
        public string BroadcastTimeZone { get; set; }
        public string StreamType { get; set; }
        public string ExcludedStations { get; set; }
    }
}