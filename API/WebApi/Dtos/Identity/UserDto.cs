using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserDto:BaseDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Industry { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int CompanyId { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        
    }
}
