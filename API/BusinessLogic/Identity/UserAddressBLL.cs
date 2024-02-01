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
    public class UserAddressBLL:IBLL<UserAddress>,IDisposable
    {
        private IUnitofWork work;
        public UserAddressBLL(string connectionstring)
        {
            work = new DbWorker(connectionstring);
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

        public IList<UserAddress> GetAll()
        {
            return work.Repository<UserAddress>().GetAll();
        }

        public IList<UserAddress> GetAll(bool loadInActive)
        {
            return work.Repository<UserAddress>().GetList(j => j.Active);
        }

        public UserAddress GetEntityById(int id)
        {
            return work.Repository<UserAddress>().GetSingle(j => j.KeyField.Equals(id));
        }
        public UserAddress GetEntityById(string id)
        {
            return work.Repository<UserAddress>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserAddress GetEntityByName(string name)
        {
            return work.Repository<UserAddress>().GetSingle(j => j.KeyField.Equals(name));
        }
        public void Add(params UserAddress[] entities)
        {
            work.Repository<UserAddress>().Add(entities);
            work.Save();
        }

        public void Remove(params UserAddress[] entities)
        {
            work.Repository<UserAddress>().Remove(entities);
            work.Save();
        }

        public void Update(params UserAddress[] entities)
        {
            work.Repository<UserAddress>().Update(entities);
            work.Save();
        }
       
    }
}
