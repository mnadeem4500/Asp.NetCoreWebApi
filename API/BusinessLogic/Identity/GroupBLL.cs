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
    public class GroupBLL : IBLL<Group>, IDisposable
    {
        readonly IUnitofWork work;

        public GroupBLL(string ConnectionString)
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

        public void Add(params Group[] grp)
        {
            work.Repository<Group>().Add(grp);
            work.Save();
        }

        public IList<Group> GetAll()
        {
            return work.Repository<Group>().GetAll();
        }

        public IList<Group> GetAll(Expression<Func<Group, bool>> where)
        {
            return work.Repository<Group>().GetList(where);
        }

        public Group GetEntityById(string id)
        {

            return work.Repository<Group>().GetSingle(j => j.KeyField.Equals(id));
        }

        public Group GetEntityById(int id)
        {

            return work.Repository<Group>().GetSingle(j => j.KeyField.Equals(id));
        }

        public Group GetEntityByName(string name)
        {

            return work.Repository<Group>().GetSingle(j => j.NameField.ToUpper().Equals(name));
           

        }

        public void Remove(params Group[] grp)
        {
            work.Repository<Group>().Remove(grp);
            work.Save();
        }

        public void Update(params Group[] grp)
        {
            work.Repository<Group>().Update(grp);
            work.Save();
        }

        public IList<Group> GetAll(bool Active)
        {

            return work.Repository<Group>().GetList(j => j.Active);
        }
    }
}
