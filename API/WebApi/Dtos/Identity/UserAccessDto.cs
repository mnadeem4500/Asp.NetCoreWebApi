namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserAccessDto : BaseDto
    {
        public int AccessId { get; set; }
        public string UserId { get; set; }
        public bool AccessAllDay { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public TimeSpan AccessStart { get; set; }
        public TimeSpan AccessEnd { get; set; }

    }
}
