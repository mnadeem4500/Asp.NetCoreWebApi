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
    public class UserLogginBLL : IBLL<UserLogin>, IDisposable
    {
        readonly IUnitofWork work;

        public UserLogginBLL(string ConnectionString)
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

        public void Add(params UserLogin[] entities)
        {
            work.Repository<UserLogin>().Add(entities);
            work.Save();
        }

        public IList<UserLogin> GetAll()
        {
            return work.Repository<UserLogin>().GetAll();
        }

        public IList<UserLogin> GetAll(Expression<Func<UserLogin, bool>> where)
        {
            return work.Repository<UserLogin>().GetList(where);
        }

        public UserLogin GetEntityById(string id)
        {

            return work.Repository<UserLogin>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserLogin GetEntityById(int id)
        {

            return work.Repository<UserLogin>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserLogin GetEntityByName(string name)
        {

            return work.Repository<UserLogin>().GetSingle(j => j.NameField.ToUpper().Equals(name));


        }

        public void Remove(params UserLogin[] entities)
        {
            work.Repository<UserLogin>().Remove(entities);
            work.Save();
        }

        public void Update(params UserLogin[] entities)
        {
            work.Repository<UserLogin>().Update(entities);
            work.Save();
        }

        public IList<UserLogin> GetAll(bool Active)
        {

            return work.Repository<UserLogin>().GetList(j => j.Active);
        }
    }

}
