using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.Core.Entities.Base
{
    public enum EntityObjectState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }

    public enum TOperation
    {
        toSelect = 0,
        toInsert = 1,
        toUpdate = 2,
        toDelete = 3
    }
}
