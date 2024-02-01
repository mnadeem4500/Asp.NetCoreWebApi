using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// UserPasswordHistory Entity in database
    /// </summary>
    /// 

    [Table("UserPwdHistory")]
    [Keyless]
    public class UserPwdHistory : EntityBase
    {
        [Required,MaxLength(50)]
        public string UserId { get; set; }

        [Required,MaxLength(255)]
        public string Password { get; set; }
        public DateTime ChangeDate { get; set; }

        public User User { get; set; }
    }
}
