using Library.Helper;
using Library.Output;
using Library.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookHelper? bookhelper;

        public BookController(BookHelper? helper)
        {
            bookhelper = helper;
        }
    
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get([FromQuery] FindBook data)
        {

            try
            {
                if (data.keyword == null)
                {
                    throw new Exception("no keyword specified");
                }

                var objJSON = new BookListOutput();
                objJSON.payload = bookhelper.FindBooks(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
