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
    public class UserBLL : IBLL<User>, IDisposable
    {
        private IUnitofWork work;
        public UserBLL(string ConnectionString)
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
        public void Add(params User[] user)
        {
            work.Repository<User>().Add(user);
            work.Save();
        }
        public User GetEntityById(int id)
        {
           return work.Repository<User>().GetSingle(j => j.KeyField.Equals(id));
        }
        public User GetEntityByID(string id)
        {
            return work.Repository<User>().GetSingle(j => j.KeyField.Equals(id));
        }

        public User GetEntityByName(string name)
        {
            return work.Repository<User>().GetSingle(j => j.NameField.ToUpper().Equals(name));
        }


        public IList<User> GetAll()
        {
              return work.Repository<User>().GetAll();
        }

        public IList<User> GetAll(Expression<Func<User, bool >>where)
        {
            return work.Repository<User>().GetList(where);
        }


        public void Remove(params User[] user)
        {
            work.Repository<User>().Remove(user);
        }

        public void Update(params User[] user)
        {
            work.Repository<User>().Update(user);
        }

        public IList<User> GetAll(bool loadInActive)
        {
            return work.Repository<User>().GetList(j => j.Active);
        }
    }
}
