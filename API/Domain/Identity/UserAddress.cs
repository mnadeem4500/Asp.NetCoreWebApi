using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    [Table("UserAddresses")]
    public class UserAddress : CommonEntity
    {
        [Key, MaxLength(50), Column("AddressId")]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(150), Required, Column("AddressType")]
        public new string NameField { get; set; }

        [Required, ForeignKey("PortalCountry"), MaxLength(50)]
        public string Country { get; set; }

        [Required, MaxLength(250)]
        public string State { get; set; }

        [Required, MaxLength(250)]
        public string City { get; set; }

        [MaxLength(50)]
        public string PostalCode { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string Street1 { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string Street2 { get; set; }

        [Required, MaxLength(50)]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
