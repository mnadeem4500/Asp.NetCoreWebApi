using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.Domain
{
    public class CommonEntity : EntityBase
    {
        [MaxLength(36)]
        public string CreatedUser { get; set; }

        [MaxLength(36)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
