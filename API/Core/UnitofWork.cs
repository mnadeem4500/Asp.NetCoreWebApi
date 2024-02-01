using ExtremeClassified.Core.Contracts;
using ExtremeClassified.Core.Contracts.EntityFramwork;
using System.Collections;

namespace ExtremeClassified.Core
{
    public class UnitofWork : IUnitofWork
    {
        #region Definitions
        private IDbContext _context;
        private readonly Guid _instanceId;
        private bool _disposed;
        private Hashtable _repositories;
        #endregion

        #region Constructor
        public UnitofWork(IDbContext context)
        {
            _context = context;
            _instanceId = Guid.NewGuid();
        }
        #endregion

        #region Properties
        public Guid InstanceId => _instanceId;
        #endregion

        #region Methods

        #region Private Methods
        #endregion

        #region Public Methods
        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context = null;
            }
            _disposed = true;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Executes the bulk insert.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public long ExecuteBulkInsert<T>(params T[] parameters) where T : class
        {
            #region Definitions
            #endregion

            #region Process
            try
            {
                return _context.ExecuteBulkInsert<T>(parameters);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        /// <summary>Repositories this instance.</summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            #region Definitions

            #endregion

            #region Process
            try
            {
                if (_repositories == null)
                    _repositories = new Hashtable();

                var type = typeof(TEntity).Name;

                if (_repositories.ContainsKey(type))
                {
                    return (IRepository<TEntity>)_repositories[type];
                }

                var repositoryType = typeof(Repository<>);

                _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

                return (IRepository<TEntity>)_repositories[type];

            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region Exit
            #endregion
        }

        /// <summary>Saves this instance.</summary>
        public void Save()
        {
            #region Definitions
            #endregion

            #region Process
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }



        /// <summary>Saves the asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<int> SaveAsync()
        {
            #region Definitions
            Task<int> result = null;
            #endregion

            #region Process
            try
            {
                result = _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region Exit
            return result;
            #endregion
        }

        /// <summary>Saves the asynchronous.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            #region Definitions
            Task<int> result = null;
            #endregion

            #region Process
            try
            {
                result = _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region Exit
            return result;
            #endregion
        }
        #endregion


        #endregion
    }
}
