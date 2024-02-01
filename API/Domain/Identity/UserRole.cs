using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// UserRole Entity in database
    /// </summary>
    /// 

    [Table("UserRoles")]
    [Keyless]
    public class UserRole : EntityBase
    {
        [Required]
        public int RoleId { get; set; }

        [Required, MaxLength(50)]
        public string UserId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

    }
}