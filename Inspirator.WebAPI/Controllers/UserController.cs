using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inspirator.IService;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _service.GetUserAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            Guid.TryParse(id, out Guid userId);
            return await _service.GetUserAsync(userId);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UnifyResponseDto> Post(SignupDTO model)
        {
            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                if (await _service.CreateUserAsync(model))
                {
                    return UnifyResponseDto.Sucess("注册成功");
                }
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
