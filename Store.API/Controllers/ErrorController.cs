
using Microsoft.AspNetCore.Mvc;
using Store.API.Errors;

namespace Store.API.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ErrorResponse(code));
        }
    }
}
