using API_Project.Security;
using BusinessService.Layer.Concrete;
using BusinessService.Layer.Interface;
using DataAccess.Layer.Concrete;
using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_Project.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        //private readonly IConfiguration _configuration;
        private readonly IBookBusinessService _bookBusinessService;

        public ValuesController(IBookBusinessService bookBusinessService)
        {
            _bookBusinessService = bookBusinessService;
        }

        //public ValuesController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{

        //    Token token = Security.TokenHandler.CreateToken(_configuration);

        //    return Ok(token);

        //}

        [HttpGet]
        public async Task<IActionResult> GetBook(int Id) {

            var book = await _bookBusinessService.GetBook(Id);
            return Ok(book);

        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            var createbook = _bookBusinessService.CreateBook(book);
            return Ok(createbook);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int id,[FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                // ModelState geçerli değilse hata döndür
                return BadRequest(ModelState);
            }

            var updatebook = await _bookBusinessService.UpdateBook(id,book);
            return Ok(updatebook);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (!ModelState.IsValid)
            {
                // ModelState geçerli değilse hata döndür
                return BadRequest(ModelState);
            }
            await _bookBusinessService.DeleteBook(id);
            return NoContent();
        }
    }
}