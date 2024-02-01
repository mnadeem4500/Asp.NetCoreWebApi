using ExtremeClassified.Core.Contracts;
using ExtremeClassified.Core.Entities.Base;
using ExtremeClassified.DataAccess;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ExtremeClassified.BusinessLogic
{
    /// <summary>
    /// Author Abrar Ahmad
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BLL<T> : IBLL<T>, IDisposable where T : EntityBase
    {
        #region Definitions

        readonly IUnitofWork work;

        #endregion

        #region Constructor
        public BLL(string ConnectionString)
        {
            work = new DbWorker(ConnectionString);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Add(params T[] entities)
        {
            try
            {
                work.Repository<T>().Add(entities);
                work.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public IList<T> GetAll()
        {
            return work.Repository<T>().GetAll();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> where)
        {
            return work.Repository<T>().GetList(where);
        }

        public IList<T> GetAllWithNavigationProperties(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return work.Repository<T>().GetList(where, navigationProperties);
        }

        public IList<T> GetAll(bool active)
        {
            return work.Repository<T>().GetList(j => j.Active);
        }

        public T GetEntityById(int Id)
        {
            return work.Repository<T>().GetSingle(j => j.KeyField.Equals(Id));
        }
        public T GetEntityById(string Id)
        {
            return work.Repository<T>().GetSingle(j => j.KeyField.Equals(Id));
        }

        public T GetEntityByName(string Name)
        {
            return work.Repository<T>().GetSingle(j => j.NameField.ToUpper().Equals(Name));
        }

        public T GetSingle(Expression<Func<T, bool>> where)
        {
            return work.Repository<T>().GetSingle(where);
        }
        public void Remove(params T[] entities)
        {
            work.Repository<T>().Remove(entities);
            work.Save();
        }

        public void Update(params T[] entities)
        {
            work.Repository<T>().Update(entities);
            work.Save();
        }

        public async Task<dynamic> ExecuteDynamicProAsync(string procName, SqlParameter[] paramters)
        {
            var result = await work.Repository<T>().ExecuteDynamicProcAsync(procName, paramters);
            return result;
        }

        public int ExecuteSqlCommand(string procName, SqlParameter[] paramters)
        {
            var result = work.Repository<T>().ExecuteSqlCommand(procName, paramters);
            return result;
        }

        #endregion

        #region Private Methods
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                work.Dispose();
            }
        }


        #endregion

        #endregion
    }
}
