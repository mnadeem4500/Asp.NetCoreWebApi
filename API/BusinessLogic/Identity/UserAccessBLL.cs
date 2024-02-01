using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.BusinessLogic.Identity
{
    public class UserAccessBLL:IBLL<UserAccess>,IDisposable
    {
        private IUnitofWork work;
        public UserAccessBLL(string ConnectionString)
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

        public void Add(params UserAccess[] uaccess)
        {
            work.Repository<UserAccess>().Add(uaccess);
            work.Save();
        }

        

        public IList<UserAccess> GetAll()
        {
            return work.Repository<UserAccess>().GetAll();
        }

        public IList<UserAccess> GetAll(bool loadInActive)
        {
            return work.Repository<UserAccess>().GetAll(j => j.Active);
        }

        public UserAccess GetEntityById(int id)
        {
            return work.Repository<UserAccess>().GetSingle(j => j.KeyField.Equals(id));
        }
        public UserAccess GetEntityById(string id)
        {
            return work.Repository<UserAccess>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserAccess GetEntityByName(string name)
        {
            return work.Repository<UserAccess>().GetSingle(j => j.KeyField.Equals(name));
        }

        public void Remove(params UserAccess[] uaccess)
        {
            work.Repository<UserAccess>().Remove(uaccess);
            work.Save();
        }

        public void Update(params UserAccess[] uaccess)
        {
            work.Repository<UserAccess>().Update(uaccess);
            work.Save();
        }
    }
}
