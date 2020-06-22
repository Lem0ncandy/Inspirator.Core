using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Inspirator.IService;
using Inspirator.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserIdentityService _service;
        private readonly IUserService _userSvc;
        private readonly ILogger _logger;

        public UserIdentityController(IConfiguration configuration, IUserIdentityService service, IUserService userSvc, ILogger logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _userSvc = userSvc ?? throw new ArgumentNullException(nameof(userSvc));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<UserIdentityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserIdentityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserIdentityController>
        [HttpPost]
        public async Task<UnifyResponseDto> Post(LoginDTO model)
        {
            Guid userId = await _userSvc.GetUserIdAsync(model.username);
            if (await _service.VerifyPasswordAsync(userId, model.password))
            {
                return UnifyResponseDto.Sucess("登录成功");
            }
            return UnifyResponseDto.Fail(Model.DTO.Enum.StatusCode.AuthenticationFailed, "登录失败");

        }

        // PUT api/<UserIdentityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserIdentityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string IssueJWTToken(IEnumerable<Claim> Claims)
        {
            string issuer = _configuration["Audience:Issuer"];
            string audience = _configuration["Audience:Audience"];
            string secret = _configuration["Audience:Secret"];
            //List<Claim> claims = new List<Claim>()
            //    {
            //        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            //        new Claim(ClaimTypes.Email,user.Email??""),
            //        new Claim(ClaimTypes.GivenName,user.Nickname??""),
            //        new Claim(ClaimTypes.Name,user.Username??""),
            //    };
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, Claims, expires: DateTime.Now.AddHours(1), signingCredentials: credentials);
            return handler.WriteToken(token);
        }
    }
}
