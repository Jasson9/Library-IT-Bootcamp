using Library.Output;
using Library.Helper.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Helper.Database;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostBookController : ControllerBase
    {
        public LostBookHelper? lostBookHelper;

        public LostBookController(LostBookHelper? helper)
        {
            lostBookHelper = helper;
        }
    
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Get([FromBody] LostBookRequestDTO data)
        {

            try
            {
                var objJSON = new LostBookOutput();
                objJSON = lostBookHelper?.addLostRecord(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
