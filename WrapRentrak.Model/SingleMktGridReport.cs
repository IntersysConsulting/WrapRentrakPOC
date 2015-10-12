using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapRentrak.Model
{
    //public class SingleMktGridReport
    //{
    //    public int id { get; set; }
    //    public string MarketName {get;set;}
    //    public string qhDateTime { get; set; }
    //    public string putHutDuring15Minutes { get; set; }
    //    public string rentrakStationNumber { get; set; }
    //    public string rentrakProgramNumber { get; set; }
    //    public string ratingDuring15Minutes { get; set; }
    //    public string shareDuring15Minutes { get; set; }
        
    //}

    public class SingleMktGridReport
    {
        public int id { get; set; }
        public string MarketName {get;set;}
        public string qhDateTime { get; set; }
        public string putHutDuring15Minutes { get; set; }
        public string rentrakStationNumber { get; set; }
        public string rentrakProgramNumber { get; set; }
        public string ratingDuring15Minutes { get; set; }
        public string shareDuring15Minutes { get; set; }
        public string rentrakStationName { get; set; }
        public string rentrakEpisodeTitle { get; set; }
        public string rentrakSeriesName { get; set; }
        public string ratingSeriesNumber { get; set; }
        public string rentrakDemoName { get; set; }
        public string hhUniverseOfDemoInMarket { get; set; }
       
    }

    //Not used. can be removed later
    public class ReportDetails
    {
        public string MarketName { get; set; }
        public string Time { get; set; }
        public string HT { get; set; }
        public string StationName { get; set; }
        public string ProgramName { get; set; }
        public string RT { get; set; }
        public string SH { get; set; }
    }

    public class SMGrid
    {
        public string time { get; set; }
        public string station { get; set; }
        public string program { get; set; }
        public string RT { get; set; }
        public string SH { get; set; }
        
        public SMGrid(string t,string st,string pg, string rt, string sh)
        {
            time = t;
            station = st;
            program = pg;
            RT = rt;
            SH = sh;
        }
    }
}
