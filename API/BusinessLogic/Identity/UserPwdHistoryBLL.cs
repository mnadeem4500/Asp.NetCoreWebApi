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
    public class UserPwdHistoryBLL: IBLL<UserPwdHistory>, IDisposable
    {
        private IUnitofWork work;
        public UserPwdHistoryBLL(string ConnectionString)
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
        public void Add(params UserPwdHistory[] history)
        {
            work.Repository<UserPwdHistory>().Add(history);
            work.Save();
        }
      
        public UserPwdHistory GetEntityById(int id)
        {
            return work.Repository<UserPwdHistory>().GetSingle(j => j.KeyField.Equals(id));
        }
     

        public UserPwdHistory GetEntityByName(string name)
        {
            return work.Repository<UserPwdHistory>().GetSingle(j => j.NameField.ToUpper().Equals(name));
        }


        public IList<UserPwdHistory> GetAll()
        {
            return work.Repository<UserPwdHistory>().GetAll();
        }

        public IList<UserPwdHistory> GetAll(Expression<Func<UserPwdHistory, bool>> where)
        {
            return work.Repository<UserPwdHistory>().GetList(where);
        }


        public void Remove(params UserPwdHistory[] history)
        {
            work.Repository<UserPwdHistory>().Remove(history);
        }

        public void Update(params UserPwdHistory[] history)
        {
            work.Repository<UserPwdHistory>().Update(history);
        }

     
        public IList<UserPwdHistory> GetAll(bool loadInActive)
        {
            return work.Repository<UserPwdHistory>().GetList(j => j.Active);
        }

        public UserPwdHistory GetEntityById(string id)
        {
            return work.Repository<UserPwdHistory>().GetSingle(j => j.KeyField.Equals(id));
        }
    }

}
