using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.BusinessLogic.Identity
{
    public class UserRegionBLL : IBLL<UserRegion>, IDisposable
    {
        private IUnitofWork work;
        public UserRegionBLL(string ConnectionString)
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
        public void Add(params UserRegion[] history)
        {
            work.Repository<UserRegion>().Add(history);
            work.Save();
        }
        public IList<UserRegion> GetAll()
        {
            return work.Repository<UserRegion>().GetAll();
        }
        public UserRegion GetEntityById(int id)
        {
            return work.Repository<UserRegion>().GetSingle(j => j.Id.Equals(id));
        }
        public UserRegion GetEntityById(string id)
        {
            return work.Repository<UserRegion>().GetSingle(j => j.Id.Equals(id));
        }

        public UserRegion GetEntityByName(string name)
        {
            return work.Repository<UserRegion>().GetSingle(j => j.Id.Equals(name));
        }

        public IList<UserRegion> GetAll(Expression<Func<UserRegion, bool>> where)
        {
            return work.Repository<UserRegion>().GetList(where);
        }


        public void Remove(params UserRegion[] urigion)
        {
            work.Repository<UserRegion>().Remove(urigion);
        }

        public void Update(params UserRegion[] urigion)
        {
            work.Repository<UserRegion>().Update(urigion);
        }

        public IList<UserRegion> GetAll(bool Active)
        {
            return work.Repository<UserRegion>().GetList(j => j.Active);
        }

        //why not implement with active 



    }


}
