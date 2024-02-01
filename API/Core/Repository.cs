using ExtremeClassified.Core.Contracts;
using ExtremeClassified.Core.Contracts.EntityFramwork;
using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ExtremeClassified.Core
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        #region Defination

        readonly IDbContext _context = null;
        readonly Guid _instanceId;
        DbSet<T> _dbSet;

        #endregion

        #region Constructor
        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _instanceId = _context.InstanceId;
        }
        #endregion

        #region Methods

        #region Private Methods
        /// <summary>Existses the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        bool Exists(T entity)
        {
            #region Definitions
            bool _entityExists = false;
            #endregion

            #region Process

            if (entity != null)
            {
                _entityExists = _dbSet.Local.Any(jc => jc == entity);
            }

            #endregion

            #region Exit
            return _entityExists;
            #endregion

        }
        #endregion

        #region Public Methods
        /// <summary>Adds the specified items.</summary>
        /// <param name="items">The items.</param>
        public void Add(params T[] items)
        {
            #region Definitions
            #endregion

            #region Process
            try
            {
                foreach (T item in items)
                {

                    ((IEntityObjectState)item).ObjectState = EntityObjectState.Added;
                    _dbSet.Attach(item);
                    _context.SyncObjectState(item);
                }

            }
            catch (Exception) { throw; }
            #endregion
        }

        public void BulkInsert(params T[] parameters)
        {
            throw new NotImplementedException();
        }

        public void BulkInsert(int BatchSize, params T[] parameters)
        {
            throw new NotImplementedException();
        }

        public dynamic ExecuteDynamicProc(string query, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> ExecuteDynamicProcAsync(string query, params SqlParameter[] parameters)
        {
            #region Definitions
            dynamic _result = null;
            #endregion

            #region Process
            try
            {
                if (string.IsNullOrEmpty(query))
                    return null;


                if (parameters != null)
                {
                    _result =
                _dbSet.FromSqlRaw(query, parameters);

                }
                else
                {
                    _result =
                _dbSet.FromSqlRaw(query);
                }
            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return await Task.FromResult(_result); //await _result.ToListAsync();
            #endregion
        }

        public ICollection<T> ExecuteGetProc(string query, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> ExecuteGetProcAsync(string query, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> ExecutePutProc(string query, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> ExecutePutProcAsync(string query, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string query, params SqlParameter[] parameters)
        {
            #region Definitions
            int _result = 0;
            #endregion

            #region Process
            try
            {
                if (string.IsNullOrEmpty(query))
                    return 0;


                if (parameters != null)
                {
                    _result = _context.GetDatabase().ExecuteSqlRaw(query, parameters);

                }
                else
                {
                    _result = _context.GetDatabase().ExecuteSqlRaw(query);
                }
            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return _result; //await _result.ToListAsync();
            #endregion
        }


        /// <summary>
        /// Gets all the entities
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            #region Definitions
            List<T> list = null;
            #endregion

            #region Process
            try
            {
                IQueryable<T> dbQuery = _context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return list;
            #endregion
        }

        public Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the list.</summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public List<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            #region Definitions
            List<T> list = null;
            #endregion

            #region Process
            try
            {
                IQueryable<T> dbQuery = _context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return list;
            #endregion
        }

        /// <summary>Gets the list asynchronous.</summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            #region Definitions
            List<T> list = null;
            #endregion

            #region Process
            try
            {
                IQueryable<T> dbQuery = _context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return Task.FromResult<List<T>>(list);
            #endregion
        }

        public Task<List<T>> GetPagedRecordsAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, object>>[] navigationProperties = null, int? page = null, int? pageSize = null)
        {
            #region Definitions
            IQueryable<T> dbQuery = _context.Set<T>();
            List<T> list = null;
            #endregion

            #region Process
            try
            {
                if (navigationProperties != null)
                {
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    {
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);
                    }
                }


                if (where != null)
                    dbQuery = dbQuery.Where(where);

                if (orderBy != null)
                    dbQuery = orderBy(dbQuery);

                if (page != null && pageSize != null)
                {
                    dbQuery = dbQuery.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }


                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return Task.FromResult<List<T>>(list);
            #endregion
        }

        /// <summary>Gets the single.</summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            #region Definitions
            T item = null;

            #endregion

            #region Process
            try
            {
                IQueryable<T> dbQuery = _context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking()
                    .SingleOrDefault(where);


            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return item;
            #endregion
        }

        /// <summary>Gets the single asynchronous.</summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            #region Definitions
            T item = null;
            #endregion

            #region Process
            try
            {
                IQueryable<T> dbQuery = _context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking()
                    .SingleOrDefault(where);
            }
            catch (Exception) { throw; }
            #endregion

            #region 
            return Task.FromResult<T>(item);
            #endregion
        }

        /// <summary>Removes the specified items.</summary>
        /// <param name="items">The items.</param>
        public void Remove(params T[] items)
        {
            #region Definitions
            #endregion

            #region Process
            try
            {
                foreach (T item in items)
                {
                    ((IEntityObjectState)item).ObjectState = EntityObjectState.Deleted;

                    _context.SyncObjectState(item);
                }
            }
            catch (Exception) { throw; }
            #endregion
        }

        public ICollection<T> SqlQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> SqlQueryAsync(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>Updates the specified items.</summary>
        /// <param name="items">The items.</param>
        public void Update(params T[] items)
        {
            #region Definitions
            #endregion

            #region Process
            try
            {

                foreach (T item in items)
                {
                    ((IEntityObjectState)item).ObjectState = EntityObjectState.Modified;

                    if (!Exists(item))
                        _dbSet.Attach(item);

                    _context.SyncObjectState(item);

                }

            }
            catch (Exception) { throw; }
            #endregion
        }

        public T GetSingleWithInclude(Expression<Func<T, bool>> where, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
