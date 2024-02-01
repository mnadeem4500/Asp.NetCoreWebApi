using ExtremeClassified.Core.Entities.Base;
using ExtremeClassified.Domain.Portal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Listing
{
    [Table("CategoryProperties")]
    public class CategoryProperty : EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Id")]
        public new int KeyField { get; set; }

        [Column("Name"), MaxLength(255), Required]
        public new string NameField { get; set; }

        [MaxLength(255)]
        public string Icon { get; set; }

        public string PropertyUnit { get; set; }

        public bool IsRequired { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey(nameof(ScreenControl))]
        public int ScreenControlId { get; set; }

        public ScreenControl ScreenControl { get; set; }

        [MaxLength(36)]
        public string CatalogueId { get; set; }

    }
}
