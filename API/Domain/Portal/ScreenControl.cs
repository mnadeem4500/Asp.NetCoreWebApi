using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Portal
{
    [Table("ScreenControls")]
    public class ScreenControl : EntityBase
    {
        [Key, Column("Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int KeyField { get; set; }

        [Column("Name"), MaxLength(255)]
        public new string NameField { get; set; }
    }
}
