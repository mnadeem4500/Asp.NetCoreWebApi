using ExtremeClassified.Core;

namespace ExtremeClassified.DataAccess
{
    public class DbWorker: UnitofWork
    {
        #region Definitions
        #endregion

        #region Constructor
        public DbWorker(string ConnectionString)
            : base(new PortalDbContext(ConnectionString))
        { }
        #endregion

        #region Methods

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion

        #endregion
    }
}
