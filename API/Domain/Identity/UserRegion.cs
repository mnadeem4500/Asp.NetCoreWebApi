using ExtremeClassified.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.Domain.Identity
{

    [Table("UserRegion")]
    public class UserRegion : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string UserId { get; set; }
        
        [MaxLength(255)]
        public string Region { get; set; }
        
        [MaxLength(255)]
        public string TimeStamp { get; set; }

        public User User { get; set; }

    }
}
