using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.Core.Contracts
{
    public interface IBLL<T> where T : class
    {
        IList<T> GetAll();
        IList<T> GetAll(bool loadInActive);
        T GetEntityById(int id);
        T GetEntityByName(string name);
        void Add(params T[] entities);
        void Update(params T[] entities);
        void Remove(params T[] entities);
    }
}
