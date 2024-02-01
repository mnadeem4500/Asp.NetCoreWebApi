using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace ExtremeClassified.Core
{
    public class StateHelper
    {
        public static EntityState ConvertState(EntityObjectState state)
        {
            switch (state)
            {
                case EntityObjectState.Added:
                    return EntityState.Added;
                case EntityObjectState.Modified:
                    return EntityState.Modified;
                case EntityObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        public static EntityObjectState ConvertState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Detached:
                    return EntityObjectState.Unchanged;
                case EntityState.Unchanged:
                    return EntityObjectState.Unchanged;
                case EntityState.Added:
                    return EntityObjectState.Added;
                case EntityState.Deleted:
                    return EntityObjectState.Deleted;
                case EntityState.Modified:
                    return EntityObjectState.Modified;
                default:
                    throw new ArgumentOutOfRangeException("Invalid state");
            }
        }
    }
}
