
namespace ExtremeClassified.WebApi.Dtos.Account
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public string Industry { get; set; }
        public string JobTitle { get; set; }
        public string Title { get; set; }
    }
}