using Library.Helper;
using Library.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentHelper? _studentHelper;

        public StudentController(StudentHelper? studentHelper)
        {
            _studentHelper = studentHelper;
        }
    
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new StudentOutput();
                objJSON.payload = _studentHelper.GetAllStudents();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
