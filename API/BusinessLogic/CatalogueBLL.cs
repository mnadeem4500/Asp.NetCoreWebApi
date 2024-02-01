using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Portal;
using System.Linq.Expressions;

namespace ExtremeClassified.BusinessLogic
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// Class CatalogueBLL basiniss logic for Categologue
    /// </summary>
    public class CatalogueBLL : IBLL<CatalogueMaster>, IDisposable
    {
        readonly IUnitofWork work;

        public CatalogueBLL(string ConnectionString)
        {
            work = new DbWorker(ConnectionString);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                work.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        public void Add(params CatalogueMaster[] entities)
        {
            work.Repository<CatalogueMaster>().Add(entities);
            work.Save();
        }

        public IList<CatalogueMaster> GetAll()
        {
            return work.Repository<CatalogueMaster>().GetAll();
        }

        public IList<CatalogueMaster> GetAll(Expression<Func<CatalogueMaster, bool>> where)
        {
            return work.Repository<CatalogueMaster>().GetList(where);
        }

        public IList<CatalogueMaster> GetAll(bool active)
        {
            return work.Repository<CatalogueMaster>().GetList(j => j.Active);
        }

        public CatalogueMaster GetEntityById(int Id)
        {
            return work.Repository<CatalogueMaster>().GetSingle(j => j.KeyField.Equals(Id));
        }
        public CatalogueMaster GetEntityById(string Id)
        {
            return work.Repository<CatalogueMaster>().GetSingle(j => j.KeyField.Equals(Id));
        }

        public CatalogueMaster GetEntityByName(string Name)
        {
            return work.Repository<CatalogueMaster>().GetSingle(j => j.NameField.ToUpper().Equals(Name));
        }

        public CatalogueMaster GetSingle(Expression<Func<CatalogueMaster, bool>> where)
        {
            return work.Repository<CatalogueMaster>().GetSingle(where);
        }
        public void Remove(params CatalogueMaster[] entities)
        {
            work.Repository<CatalogueMaster>().Remove(entities);
            work.Save();
        }

        public void Update(params CatalogueMaster[] entities)
        {
            work.Repository<CatalogueMaster>().Update(entities);
            work.Save();
        }
    }
}
