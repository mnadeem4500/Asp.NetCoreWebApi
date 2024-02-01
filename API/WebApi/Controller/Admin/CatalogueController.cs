using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Admin
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogueController : PortalBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            // need implminatioan 
            return Ok();
        }

        [HttpGet]
        public IActionResult GetByid()
        {
            return Ok();
        }
    }
}
