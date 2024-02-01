using System;

namespace ExtremeClassified.WebApi.Dtos
{
    public class BaseDto
    {
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
