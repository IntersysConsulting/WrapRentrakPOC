using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapRentrak.Data.Infrastructure
{
    public class DbFactory : Disposable, IDBFactory
    {
        ReportEntities dbContext;

        public ReportEntities Init()
        {
            return dbContext ?? (dbContext = new ReportEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }


    }
}
