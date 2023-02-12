using Library.Output;
using Library.Helper.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Helper.Database;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        public BorrowHelper? borrowHelper;

        public BorrowController(BorrowHelper? helper)
        {
            borrowHelper = helper;
        }
    
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Get([FromBody] BorrowRequestDTO data)
        {

            try
            {
                var objJSON = new BorrowOutput();
                objJSON = borrowHelper.Borrow(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
