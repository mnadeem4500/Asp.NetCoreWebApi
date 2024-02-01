using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExtremeClassified.Core.Entities.Base;

namespace ExtremeClassified.Domain.Portal
{
    [Table("CountryAdministrativeDivisions")]
    public class CountryAdministrativeDivision : EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string DivisionType { get; set; }

        [ForeignKey("Country")]
        public string CountryId { get; set; }
        public virtual PortalCountry Country { get; set; }

    }
}
