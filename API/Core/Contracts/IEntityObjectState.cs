using ExtremeClassified.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.Core.Contracts
{
    public interface IEntityObjectState
    {
        EntityObjectState ObjectState { get; set; }
    }
}
