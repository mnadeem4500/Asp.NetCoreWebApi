using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserAddressDto:BaseDto
    {
        public string UserAddressId { get; set; }
        public string UserAddresskey { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street1 { get; set; }
        public string UserId { get; set; }
    }
}
