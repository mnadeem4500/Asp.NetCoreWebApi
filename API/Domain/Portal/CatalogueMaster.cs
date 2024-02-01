using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Portal
{
    [Table("CatalogueMaster")]
    public class CatalogueMaster : EntityBase
    {
        [Key, Column("MasterId"), MaxLength(50)]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [Column("CatalogueName"), MaxLength(250), Required]
        public new string NameField { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public virtual ICollection<CatalogueDetail> CatalogueDetails { get; set; }

    }
}
