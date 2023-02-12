using Library.Output;
using Library.Helper.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Helper.Database;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolveLostBookController : ControllerBase
    {
        public LostBookHelper? lostBookHelper;

        public ResolveLostBookController(LostBookHelper? helper)
        {
            lostBookHelper = helper;
        }
    
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Get([FromBody] ResolveLostBookRequestDTO data)
        {

            try
            {
                var objJSON = new ResolveLostBookOutput();
                objJSON = lostBookHelper?.removeLostRecord(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
