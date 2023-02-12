using Library.Helper.Database;
using Library.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private StaffHelper? _staffHelper;

        public StaffController(StaffHelper? staffHelper)
        {
            _staffHelper = staffHelper;
        }
    
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new StaffOutput();
                objJSON.payload = _staffHelper.GetAllStaffs();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}