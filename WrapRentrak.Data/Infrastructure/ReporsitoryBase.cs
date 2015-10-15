using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WrapRentrak.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private ReportEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDBFactory DbFactory
        {
            get;
            private set;
        }

        protected ReportEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDBFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetSingleMktGridReport(string marketId, string stationId, string dateFrom,string dateTo, string demoId)
        {
            //IEnumerable<T> data = (dataContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<T>("CALL GetSingleMktGrid_sp({0}, {1}, {2}, {3}, {4});", marketId, stationId, dateFrom,dateTo, demoId);
            IEnumerable<T> data = (dataContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<T>("CALL GetSingleMktGrid({0}, {1}, {2}, {3}, {4});", marketId, stationId, dateFrom, dateTo, demoId);
                       
            return data;
        }

        public virtual IEnumerable<T> GetSingleMktGridReportPaging(string marketId, string stationId, string dateFrom, string dateTo, string demoId, int start, int limit)
        {
            //IEnumerable<T> data = (dataContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<T>("CALL GetSingleMktGrid_sp({0}, {1}, {2}, {3}, {4});", marketId, stationId, dateFrom,dateTo, demoId);
            IEnumerable<T> data = (dataContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<T>("CALL GetSingleMktGridPaging({0}, {1}, {2}, {3}, {4}, {5}, {6});", marketId, stationId, dateFrom, dateTo, demoId, start, limit);
                       
            return data;
        }

        public virtual IEnumerable<T> GETSMData(string marketId, string stationId, string dateFrom, string dateTo, string demoId)
        {
            //IEnumerable<T> data = (dataContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<T>("CALL GetSingleMktGrid_sp({0}, {1}, {2}, {3}, {4});", marketId, stationId, dateFrom,dateTo, demoId);
            IEnumerable<T> data = (dataContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<T>("CALL GetSMData({0}, {1}, {2}, {3}, {4});", marketId, stationId, dateFrom, dateTo, demoId);

            return data;
        }
        #endregion

    }
}
