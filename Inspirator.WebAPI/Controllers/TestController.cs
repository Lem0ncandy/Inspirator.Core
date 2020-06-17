using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inspirator.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: api/<TestController>
        [HttpGet]
        public void Get()
        {
            _userService.CreateUserAsync(new Model.Entities.User
            {
                Email = "123123123@qq.com",
                Nickname = "123123213",
            },"123125sadsas");
            _userService.CreateUserAsync(new Model.Entities.User
            {
                Email = "aesrfsfdq.com",
                Nickname = "sadfds]]",
            }, "[][];;o258");
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
