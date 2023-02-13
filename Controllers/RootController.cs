using Library.Helper.Database;
using Library.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("/api")]
    [ApiController]
    public class RootController : ControllerBase
    {
    
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("it works this is API Root");
        }
    }
}