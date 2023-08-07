using API_Project.Security;
using BusinessService.Layer.Concrete;
using BusinessService.Layer.Interface;
using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_Project.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{

        //    Token token = Security.TokenHandler.CreateToken(_configuration);

        //    return Ok(token);

        //}

        [HttpGet]
        public IActionResult GetData()
        {
            BookBusinessService datas = new();
            _ = datas.GetBook(1);

            return Ok(datas);
            
            
        }




    }
}