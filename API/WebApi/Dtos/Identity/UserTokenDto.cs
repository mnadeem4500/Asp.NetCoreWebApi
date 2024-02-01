using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserTokenDto : BaseDto
    {
        public int tokenId {  get; set; }
        public string UserId { get; set; }
        public string TokenValue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssueDate { get; set; }
        public bool Consumed { get; set; }
        public string Purpose { get; set; }
    }
}
