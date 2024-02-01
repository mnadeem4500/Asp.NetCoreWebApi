using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Listing
{
    [Table("ListingFavorites")]
    public class ListingFavorite : EntityBase
    {
        [Key, Column("Id"), MaxLength(36)]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [Column("ListingId"), MaxLength(36)]
        public new string NameField { get; set; }

        [MaxLength(36)]
        public string UserId { get; set; }

    }
}
