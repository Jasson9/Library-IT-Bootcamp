using Library.Output;
using Library.Helper.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Helper.Database;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnBookController : ControllerBase
    {
        public ReturnBookHelper? returnBookHelper;

        public ReturnBookController(ReturnBookHelper? helper)
        {
            returnBookHelper = helper;
        }
    
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Get([FromBody] ReturnBookRequestDTO data)
        {

            try
            {
                var objJSON = new ReturnBookOutput();
                objJSON = returnBookHelper?.ReturnBook(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
