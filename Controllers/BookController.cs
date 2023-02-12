using Library.Helper.Database;
using Library.Helper.Request;
using Library.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookHelper? _bookHelper;

        public BookController(BookHelper? bookHelper)
        {
            _bookHelper = bookHelper;
        }
    
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new BookOutput();
                objJSON.payload = _bookHelper.GetAllBooks();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        [Produces("application/json")]
        public IActionResult SearchBook([FromBody] SearchBookRequestDTO data)
        {
            try
            {
                var objJSON = new SearchBookOutput();
                objJSON.payload = _bookHelper.SearchBook(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        message = ex.Message
                    }
                );
            }
        }
    }
}