using ExtremeClassified.Core.Entities.Base;

namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class RoleDto :BaseDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        
       
       

        
    }
}
