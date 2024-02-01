using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupFunctions groupFunctions;
        public GroupController(GroupFunctions groupFunctions)
        {
            this.groupFunctions = groupFunctions;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("Get/{groupdId}")]
        public IActionResult Get(string groupdId)
        {
            var grp = groupFunctions.GetById(groupdId);

            return Ok(grp);
        }
    }
}
