namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class LoginProviderDto : BaseDto
    {
        public string UserName { get; set; }
        public string Paswword { get; set; }
    }
}
