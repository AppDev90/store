using Microsoft.AspNetCore.Mvc;
using Store.ApplicationService.ErrorsForTest;

namespace Store.API.Controllers
{
    public class ErrorGeneratorController : BaseApiController
    {
        private readonly IErrors _errors;

        public ErrorGeneratorController(IErrors errors)
        {
            _errors = errors;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFound()
        {
            _errors.GetNotFoundError();
            return Ok();
        }

        [HttpGet("Server")]
        public ActionResult GetServer()
        {
            _errors.GetEception();
            return Ok();
        }

        [HttpGet("Validation")]
        public ActionResult GetValidation()
        {
            _errors.GetValidationError();
            return Ok();
        }

        [HttpGet("UnKnown")]
        public ActionResult GetUnKnown()
        {
            _errors.GetUnKnownError();
            return Ok();
        }

        [HttpGet("Authorization")]
        public ActionResult GetAuthorization()
        {
            _errors.GetAuthorizationError();
            return Ok();
        }

    }
}
