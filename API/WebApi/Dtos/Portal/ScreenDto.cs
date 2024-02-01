using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Portal
{
    public class ScreenDto:BaseDto
    {
       
            public int Id { get; set; }

            public string Name { get; set; }
        
    }
}
