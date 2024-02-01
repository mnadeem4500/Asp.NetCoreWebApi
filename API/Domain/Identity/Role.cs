
using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// Role Entity in database
    /// </summary>
    /// 

    [Table("Roles")]
    public class Role : EntityBase
    {
        [Key, Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int KeyField { get; set; } 

        [Column("Name", TypeName = "NVARCHAR")]
        [MaxLength(250), Required]
        public new string NameField { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(512)]
        public string Description { get; set; }
    }
}
