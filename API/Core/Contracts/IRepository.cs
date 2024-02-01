using Microsoft.EntityFrameworkCore.Query;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ExtremeClassified.Core.Contracts
{
    public interface IRepository<T> where T : class
    {

        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);
        List<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingleWithInclude(Expression<Func<T, bool>> where, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        void Add(params T[] items);
        //object[] AddAndGetIdentity(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
        Task<ICollection<T>> SqlQueryAsync(string query, params object[] parameters);
        ICollection<T> SqlQuery(string query, params object[] parameters);
        Task<ICollection<T>> ExecuteGetProcAsync(string query, params SqlParameter[] parameters);
        ICollection<T> ExecuteGetProc(string query, params SqlParameter[] parameters);
        Task<ICollection<T>> ExecutePutProcAsync(string query, params SqlParameter[] parameters);
        ICollection<T> ExecutePutProc(string query, params SqlParameter[] parameters);
        Task<dynamic> ExecuteDynamicProcAsync(string query, params SqlParameter[] parameters);
        dynamic ExecuteDynamicProc(string query, params SqlParameter[] parameters);
        int ExecuteSqlCommand(string query, params SqlParameter[] parameters);

        void BulkInsert(params T[] parameters);
        void BulkInsert(int batchSize, params T[] parameters);
        Task<List<T>> GetPagedRecordsAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, object>>[] navigationProperties = null, int? page = null, int? pageSize = null);

    }
}
