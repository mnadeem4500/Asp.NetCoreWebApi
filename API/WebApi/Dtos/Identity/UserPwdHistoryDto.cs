namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserPwdHistoryDto:BaseDto
    {
        public string UserhistoryId {  get; set; }
        public string UserPassword { get; set; }
        public DateTime ChangeDate {  get; set; }
    }
}
