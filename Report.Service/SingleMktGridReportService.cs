using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Model;
using WrapRentrak.Data;
using WrapRentrak.Data.Repositories;
using WrapRentrak.Data.Infrastructure;

namespace WrapRentrak.Reports.Service
{
    public interface ISingleMktGridReportService
    {
        IEnumerable<WrapRentrak.Model.SingleMktGridReport> GetReports();
        WrapRentrak.Model.SingleMktGridReport GetReport(int id);
        IEnumerable<WrapRentrak.Model.SingleMktGridReport> GetSingleMktGridReports(string marketId, string stationId, string dateFrom, string dateTo, string demoId);
        IEnumerable<WrapRentrak.Model.SingleMktGridReport> GetSingleMktGridReportsPaging(string marketId, string stationId, string dateFrom, string dateTo, string demoId, int start, int limit);
        IEnumerable<WrapRentrak.Model.SingleMktGridReport> GETSMData(string marketId, string stationId, string dateFrom, string dateTo, string demoId);
    }

    public class SingleMktGridReportService : ISingleMktGridReportService
    {
        private readonly ISingleMktGridRepository singleMktGridRepository;

        public SingleMktGridReportService(ISingleMktGridRepository singleMktGridRepository)
        {
            this.singleMktGridRepository = singleMktGridRepository;
           
        }

        #region IReportService Members

        public IEnumerable<WrapRentrak.Model.SingleMktGridReport> GetReports()
        {
            var reports = singleMktGridRepository.GetAll();
            return reports;
        }

        public WrapRentrak.Model.SingleMktGridReport GetReport(int id)
        {
            var reports = singleMktGridRepository.GetById(id);
            return reports;
        }

        public IEnumerable<WrapRentrak.Model.SingleMktGridReport> GetSingleMktGridReports(string marketId, string stationId, string dateFrom, string dateTo, string demoId)
        {
            var reports = singleMktGridRepository.GetSingleMktGridReport(marketId,stationId,dateFrom,dateTo,demoId);
            return reports;
        }

        public IEnumerable<WrapRentrak.Model.SingleMktGridReport> GetSingleMktGridReportsPaging(string marketId, string stationId, string dateFrom, string dateTo, string demoId, int start, int limit)
        {
            var reports = singleMktGridRepository.GetSingleMktGridReportPaging(marketId, stationId, dateFrom, dateTo, demoId, start, limit);
            return reports;
        }

        public IEnumerable<WrapRentrak.Model.SingleMktGridReport> GETSMData(string marketId, string stationId, string dateFrom, string dateTo, string demoId)
        {
            var reports = singleMktGridRepository.GETSMData(marketId, stationId, dateFrom, dateTo, demoId);
            return reports;
        }
        #endregion

    }
}
