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
    public class UserGroupBLL : IBLL<UserGroup>, IDisposable
    {
        readonly IUnitofWork work;

        public UserGroupBLL(string ConnectionString)
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

        public void Add(params UserGroup[] entities)
        {
            work.Repository<UserGroup>().Add(entities);
            work.Save();
        }

        public IList<UserGroup> GetAll()
        {
            return work.Repository<UserGroup>().GetAll();
        }

        public IList<UserGroup> GetAll(Expression<Func<UserGroup, bool>> where)
        {
            return work.Repository<UserGroup>().GetList(where);
        }

        public UserGroup GetEntityById(string id)
        {

            return work.Repository<UserGroup>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserGroup GetEntityById(int id)
        {

            return work.Repository<UserGroup>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserGroup GetEntityByName(string name)
        {

            return work.Repository<UserGroup>().GetSingle(j => j.NameField.ToUpper().Equals(name));
           

        }

        public void Remove(params UserGroup[] entities)
        {
            work.Repository<UserGroup>().Remove(entities);
            work.Save();
        }

        public void Update(params UserGroup[] entities)
        {
            work.Repository<UserGroup>().Update(entities);
            work.Save();
        }

        public IList<UserGroup> GetAll(bool Active)
        {

            return work.Repository<UserGroup>().GetList(j => j.Active);
        }
    }

}
