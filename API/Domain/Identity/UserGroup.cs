using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// GroupUser Entity in database
    /// </summary>
    /// 

    [Table("UserGroups")]
    [Keyless]
    public class UserGroup : EntityBase
    {
        [MaxLength(50)]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string GroupId { get; set; }
    }
}
