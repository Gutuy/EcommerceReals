using Ecommerce.Api.Dto;
using Ecommerce.Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controller
{

    public class BuggyController : BaseApiController
    {
        [HttpGet("unauthorized")]

        public IActionResult GetUnAuthorized()
        {
            return Unauthorized();
        }

        [HttpGet("badrequest")]

        public IActionResult BadRequest()
        {
            return BadRequest("Not A Good Result");
        }

        [HttpGet("notfound")]

        public IActionResult NotFound()
        {
            return NotFound();
        }

        [HttpGet("internalerror")]

        public IActionResult GetInternalError()
        {
            throw new Exception("This is the test exception");
        }

        [HttpPost("validationerror")]
        public IActionResult GetValidationError(CreateProductDto product)
        {
            return Ok();
        }
    }
}
