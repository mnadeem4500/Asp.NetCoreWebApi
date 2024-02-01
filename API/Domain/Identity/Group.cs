
using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// Group Entity in database
    /// </summary>
    /// 
    [Table("Groups")]
    public class Group : EntityBase
    {
        [Key]
        [MaxLength(50), Column("GroupId")]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [Column("Name", TypeName = "NVARCHAR")]
        [MaxLength(250), Required]
        public new string NameField { get; set; }


        [Column(TypeName = "NVARCHAR")]
        [MaxLength(512)]
        public string Description { get; set; }
    }
}