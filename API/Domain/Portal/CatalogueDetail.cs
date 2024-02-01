using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Portal
{
    [Table("CatalogueDetails")]
    public class CatalogueDetail : EntityBase
    {
        [Key, Column("DetailId"), MaxLength(50)]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(250), Column("Name"), Required]
        public new string NameField { get; set; }

        [ForeignKey("CatalogueMaster"), MaxLength(50), Required]
        public string MasterId { get; set; }
        public virtual CatalogueMaster CatalogueMaster { get; set; }
    }
}
