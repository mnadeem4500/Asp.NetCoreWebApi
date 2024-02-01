using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Listing
{
    [Table("Categories")]
    public class Category : EntityBase
    {
        [Key, Column("Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int KeyField { get; set; }

        [MaxLength(250), Column("Name"), Required]
        public new string NameField { get; set; }
        public int ParentId { get; set; }

        [MaxLength(150)]
        public string Icon { get; set; }

        public int MaxAllowedImages { get; set; }

        public int PostValidity { get; set; }

    }
}
