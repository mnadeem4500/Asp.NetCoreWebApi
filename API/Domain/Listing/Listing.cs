using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExtremeClassified.Domain.Listing
{
    [Table("Listings")]
    public class Listing : CommonEntity
    {
        [Key, MaxLength(50), Column("ListingId")]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(150)]
        public string SKU { get; set; }

        [Required, MaxLength(100), Column("Title")]
        public new string NameField { get; set; }

        [MaxLength(512)]
        public string ShortDescription { get; set; }

        [MaxLength(1024)]
        public string LongDescription { get; set; }

        [MaxLength(250)]
        public string ThumbImage { get; set; }

        [Required]
        public double Price { get; set; }

        public bool IsPriceNegotiable { get; set; }

        [Required, ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<ListingAttachment> Gallery { get; set; }
        public virtual ICollection<ListingProperty> ListingProperties { get; set; }

    }
}
