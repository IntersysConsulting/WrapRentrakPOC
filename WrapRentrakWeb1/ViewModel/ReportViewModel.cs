using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrapRentrakWeb1.ViewModel
{
    public class ReportViewModel
    {
        public int ReportId { get; set; }
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