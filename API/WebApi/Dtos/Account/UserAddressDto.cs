using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Account
{
    public class UserAddressDto : BaseDto
    {
        public string AddressId { get; set; }

        public string AddressType { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required, MaxLength(250)]
        public string City { get; set; }

        [MaxLength(50)]
        public string PostalCode { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }
        public string UserId { get; set; }
    }
}
