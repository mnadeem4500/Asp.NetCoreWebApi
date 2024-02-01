using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{

    [Table("UserActivities")]
    [Keyless]
    public class UserActivity : EntityBase
    {
        [MaxLength(50)]
        public string UserId { get; set; }

    }
}
