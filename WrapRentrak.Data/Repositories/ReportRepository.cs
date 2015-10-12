using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Data.Infrastructure;
using WrapRentrak.Model;

namespace WrapRentrak.Data.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(IDBFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IReportRepository : IRepository<Report>
    {

    }
}
