using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.Domain.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ExtremeClassified.BusinessLogic.Identity
{
    /// <summary>
    /// Author Nadeem
    /// Bll class for Role
    /// </summary>
    public class RoleBLL : IBLL<Role>, IDisposable
    {
        readonly IUnitofWork work;

        public RoleBLL(string ConnectionString)
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

        public IList<Role> GetAll()
        {
            return work.Repository<Role>().GetAll();
        }

        public IList<Role> GetAll(Expression<Func<Role, bool>> where)
        {
            return work.Repository<Role>().GetList(where);
        }

        public Role GetEntityById(int id)
        {
            return work.Repository<Role>().GetSingle(j => j.KeyField.Equals(id));
        }

        public Role GetEntityByName(string name)
        {
            return work.Repository<Role>().GetSingle(j => j.KeyField.Equals(name));
        }

        public void Add(params Role[] role)
        {
            work.Repository<Role>().Add(role);
            work.Save();
        }

        public void Update(params Role[] role)
        {
            work.Repository<Role>().Update(role);
            work.Save();
        }

        public void Remove(params Role[] role)
        {
            work.Repository<Role>().Remove(role);
            work.Save();
        }
        public IList<Role> GetAll(bool Active)
        {

            return work.Repository<Role>().GetList(j => j.Active);
        }
    }
}