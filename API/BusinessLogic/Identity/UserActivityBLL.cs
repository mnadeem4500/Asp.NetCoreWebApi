using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.BusinessLogic.Identity
{
    public class UserActivityBLL :IBLL<UserActivity>,IDisposable
    {
        readonly IUnitofWork work;

        public UserActivityBLL(string ConnectionString)
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


        public IList<UserActivity> GetAll()
        {
            return work.Repository<UserActivity>().GetAll();
        }

        public IList<UserActivity> GetAll(Expression<Func<UserActivity, bool>> where)
        {
            return work.Repository<UserActivity>().GetList(where);
        }

        public UserActivity GetEntityById(int id)
        {
            return work.Repository<UserActivity>().GetSingle(j => j.KeyField.Equals(id));
        }
        public UserActivity GetEntityById(string id)
        {
            return work.Repository<UserActivity>().GetSingle(j => j.KeyField.Equals(id));
        }

        public UserActivity GetEntityByName(string name)
        {
            return work.Repository<UserActivity>().GetSingle(j => j.KeyField.Equals(name));
        }
        public void Add(params UserActivity[] entities)
        {
            work.Repository<UserActivity>().Add(entities);
            work.Save();
        }

        public void Remove(params UserActivity[] entities)
        {
            work.Repository<UserActivity>().Remove(entities);
            work.Save();
        }

        public void Update(params UserActivity[] entities)
        {
            work.Repository<UserActivity>().Remove(entities);
            work.Save();
        }

        public IList<UserActivity> GetAll(bool Active)
        {

            return work.Repository<UserActivity>().GetList(j => j.Active);
        }
     
    }
    }

