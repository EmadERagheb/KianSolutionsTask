
using Microsoft.AspNetCore.Mvc;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CommonResponseDTO(code));
        }
    }
}
