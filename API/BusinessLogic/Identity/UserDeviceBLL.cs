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
    public class UserDeviceBLL : IBLL<UserDevice>, IDisposable
    {
        readonly IUnitofWork work;

        public UserDeviceBLL(string ConnectionString)
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

        public void Add(params UserDevice[] grp)
        {
            work.Repository<UserDevice>().Add(grp);
            work.Save();
        }

        public IList<UserDevice> GetAll()
        {
            return work.Repository<UserDevice>().GetAll();
        }

        public IList<UserDevice> GetAll(Expression<Func<UserDevice, bool>> where)
        {
            return work.Repository<UserDevice>().GetList(where);
        }

        public UserDevice GetEntityById(string id)
        {

            return work.Repository<UserDevice>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserDevice GetEntityById(int id)
        {

            return work.Repository<UserDevice>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserDevice GetEntityByName(string name)
        {

            return work.Repository<UserDevice>().GetSingle(j => j.NameField.ToUpper().Equals(name));
            

        }

        public void Remove(params UserDevice[] grp)
        {
            work.Repository<UserDevice>().Remove(grp);
            work.Save();
        }

        public void Update(params UserDevice[] grp)
        {
            work.Repository<UserDevice>().Update(grp);
            work.Save();
        }

        public IList<UserDevice> GetAll(bool Active)
        {

            return work.Repository<UserDevice>().GetList(j => j.Active);
        }
    }

}
