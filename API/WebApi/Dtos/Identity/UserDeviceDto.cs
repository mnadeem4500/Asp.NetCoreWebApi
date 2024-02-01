using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserDeviceDto:BaseDto
    {
        public int UserDeviceId { get; set; }
        public string DevicName { get; set; }
        public string UserId { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceOs { get; set; }
        public string Description { get; set; }
        public string DeviceVender { get; set; }
        public string FingerPrint { get; set; }

    }
}
