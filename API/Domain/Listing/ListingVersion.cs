using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Listing
{

    [Table("ListingVersions")]
    public class ListingVersion : EntityBase
    {
        [Key, Column("Id"), MaxLength(36)]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [Required, Column("ListingId"), ForeignKey(nameof(ProductListing))]
        public new string NameField { get; set; }
        public Listing ProductListing { get; set; }
        public int VersionNumber { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public string ListingObjectJson { get; set; }

    }
}
