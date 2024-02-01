
using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// public class UserLogin : Entity
    /// Author: Abrar Ahmad
    /// </summary>
    ///

    [Table("UserLogins")]
    [Keyless]
    public class UserLogin : EntityBase
    {
        [MaxLength(255)]
        public string LoginProvider { get; set; }

        [MaxLength(255)]
        public string ProviderKey { get; set; }

        [MaxLength(50), Required]
        public string UserId { get; set; }

        [MaxLength(150)]
        public string ProviderDisplayName { get; set; }

        public User User { get; set; }
    }
}
