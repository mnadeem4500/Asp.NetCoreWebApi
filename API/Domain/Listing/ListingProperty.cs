using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Listing
{
    [Table("ListingProperties")]
    public class ListingProperty : EntityBase
    {
        [Key, Column("Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int KeyField { get; set; }

        [Column("ListingId"), ForeignKey(nameof(Listing))]
        public new string NameField { get; set; }
        public Listing Listing { get; set; }

        [ForeignKey(nameof(CategoryProperty))]
        public int PropertyId { get; set; }
        public CategoryProperty CategoryProperty { get; set; }

        [MaxLength(255), Required, Column(TypeName = "NVARCHAR(255)")]
        public string PropertValue { get; set; }

    }
}
