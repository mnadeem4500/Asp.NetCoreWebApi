using System.Collections.Generic;

namespace ExtremeClassified.WebApi.Dtos.Account
{
    public class ChangePasswordDto
    {
        public string OldPassaowrd { get; set; }
        public string NewPassword { get; set; }
        public List<UserQuestionAnswerDto> Questions { get; set; }
        public string UserId { get; set; }
    }

    public class UserQuestionAnswerDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }


}
