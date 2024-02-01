using ExtremeClassified.Core.Contracts;
using ExtremeClassified.Core.Contracts.EntityFramwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace ExtremeClassified.Core.Providers.EntityFramework
{
    public class DbContextBase : DbContext, IDbContext
    {
        #region Definitions
        readonly Guid _instanceId;
        readonly string _connectionString;
        #endregion

        #region Constructor
        public DbContextBase(string ConnectionString)
            : base(GetDbContextOptions(ConnectionString))
        {
            _instanceId = new Guid();
            _connectionString = ConnectionString;
            Database.SetCommandTimeout(180);

            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        //TEMPRARY CODE only for migration
        public DbContextBase(DbContextOptions options)
          : base(options)
        {
            _instanceId = new Guid();
            _connectionString = options.FindExtension<SqlServerOptionsExtension>()?.ConnectionString;
            Database.SetCommandTimeout(180);

        }
        #endregion

        #region Properties
        public Guid InstanceId => _instanceId;
        public string ConnStr => _connectionString;
        public int BatchSize { get; set; }
        #endregion

        #region Events
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    #region SQL Server
            //    optionsBuilder.UseSqlServer(_connectionString);
            //    #endregion
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<VUserRole>()
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>Gets the database context options.</summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        static DbContextOptions GetDbContextOptions(string connectionString)
        {
            var _dbOptions = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;

            return _dbOptions;
        }

        /// <summary>Gets the name of the table.</summary>
        /// <param name="type">The type.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        string GetTableName(Type type, DbContext context)
        {
            #region Definitions
            string tableName = string.Empty;
            #endregion

            #region Process
            try
            {
                var entityType = context.Model.FindEntityType(type);
                var schema = entityType.GetSchema();
                tableName = entityType.GetTableName();


            }
            catch (Exception) { throw; }
            #endregion

            #region Exit
            return tableName;
            #endregion
        }

        #endregion

        #region Public Methods

        public Dictionary<Guid, object> AuditEntities { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public long ExecuteBulkInsert<T>(params T[] parameters) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   <para>
        /// Saves all changes made in this context to the database.
        /// </para>
        ///   <para>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges">DetectChanges</see> to discover any
        /// changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled">AutoDetectChangesEnabled</see>.
        /// </para>
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public override int SaveChanges()
        {
            #region Definitions
            int iResult = -1;
            #endregion

            #region Process
            try
            {
                iResult = base.SaveChanges();
            }
            catch (Exception e)
            {
                if (e is DbUpdateConcurrencyException)
                {
                    var eDC = (e as DbUpdateConcurrencyException);

                    if (eDC.Entries.Count() == 1)
                    {
                        #region Client wins
                        var entry = eDC.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        return this.SaveChanges();
                        #endregion
                    }

                }

                throw new Exception($"An error occurred trying to commit the changes to the database. Error: {e.ToString()} ");
            }

            #endregion

            #region Exit
            return iResult;
            #endregion

        }
        public Task<int> SaveChangesAsync()
        {
            #region Definitions
            #endregion

            #region Process
            #endregion

            #region Exit
            return null;
            #endregion
        }

        public void SyncObjectState(object entity)
        {
            Entry(entity).State = StateHelper.ConvertState(((IEntityObjectState)entity).ObjectState);
        }

        public DatabaseFacade GetDatabase()
        {
            return Database;
        }

        #endregion

        #endregion
    }
}
