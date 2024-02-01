using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{

    [Table("UserTokens")]
    public class UserToken : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string UserId { get; set; }

        [Required, MaxLength(255)]
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssueDate { get; set; }
        public bool Consumed { get; set; }

        [Required, MaxLength(100)]
        public string Purpose { get; set; }

        public User User { get; set; }

    }
}
