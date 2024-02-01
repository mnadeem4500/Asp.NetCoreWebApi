using ExtremeClassified.Core.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Core.Entities.Base
{
    public abstract class EntityBase : IEntityObjectState
    {
        [NotMapped]
        public string NameField { get; set; }

        [NotMapped]
        public object KeyField { get; set; }

        [NotMapped]
        public EntityObjectState ObjectState { get; set; }

        [Column("Active")]
        public bool Active { get; set; }
        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }
    }
}
