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
    internal class UserRoleBLL : IBLL<UserRole>, IDisposable
    {
        readonly IUnitofWork work;

        public UserRoleBLL(string ConnectionString)
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

        public void Add(params UserRole[] grp)
        {
            work.Repository<UserRole>().Add(grp);
            work.Save();
        }

        public IList<UserRole> GetAll()
        {
            return work.Repository<UserRole>().GetAll();
        }

        public IList<UserRole> GetAll(Expression<Func<UserRole, bool>> where)
        {
            return work.Repository<UserRole>().GetList(where);
        }

        public UserRole GetEntityById(string id)
        {

            return work.Repository<UserRole>().GetSingle(j => j.RoleId.Equals(id));
        }

        public UserRole GetEntityById(int id)
        {

            return work.Repository<UserRole>().GetSingle(j => j.RoleId.Equals(id));
        }

        public UserRole GetEntityByName(string name)
        {

            return work.Repository<UserRole>().GetSingle(j => j.NameField.ToUpper().Equals(name));


        }

        public void Remove(params UserRole[] grp)
        {
            work.Repository<UserRole>().Remove(grp);
            work.Save();
        }

        public void Update(params UserRole[] grp)
        {
            work.Repository<UserRole>().Update(grp);
            work.Save();
        }

        public IList<UserRole> GetAll(bool Active)
        {

            return work.Repository<UserRole>().GetList(j => j.Active);
        }
    }
    
}
