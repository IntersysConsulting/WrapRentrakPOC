using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Data.Infrastructure;
using WrapRentrak.Model;

namespace WrapRentrak.Data.Repositories
{
    public class SingleMktGridRepository : RepositoryBase<SingleMktGridReport>, ISingleMktGridRepository
    {
        public SingleMktGridRepository(IDBFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface ISingleMktGridRepository : IRepository<SingleMktGridReport>
    {

    }
}
