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
    public class UserTokenBLL : IBLL<UserToken>, IDisposable
    {
        readonly IUnitofWork work;

        public UserTokenBLL(string ConnectionString)
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

        public void Add(params UserToken[] grp)
        {
            work.Repository<UserToken>().Add(grp);
            work.Save();
        }

        public IList<UserToken> GetAll()
        {
            return work.Repository<UserToken>().GetAll();
        }

        public IList<UserToken> GetAll(Expression<Func<UserToken, bool>> where)
        {
            return work.Repository<UserToken>().GetList(where);
        }

        public UserToken GetEntityById(string id)
        {

            return work.Repository<UserToken>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserToken GetEntityById(int id)
        {

            return work.Repository<UserToken>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserToken GetEntityByName(string name)
        {

            return work.Repository<UserToken>().GetSingle(j => j.NameField.ToUpper().Equals(name));


        }

        public void Remove(params UserToken[] grp)
        {
            work.Repository<UserToken>().Remove(grp);
            work.Save();
        }

        public void Update(params UserToken[] grp)
        {
            work.Repository<UserToken>().Update(grp);
            work.Save();
        }

        public IList<UserToken> GetAll(bool Active)
        {

            return work.Repository<UserToken>().GetList(j => j.Active);
        }
    }
   
}
