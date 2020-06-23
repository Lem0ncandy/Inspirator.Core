using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inspirator.IService;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(ISurveyService service, IMapper mapper, ILogger<SurveyController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<PaginationDTO<IEnumerable<Survey>>> Get([FromQuery] PaginationParameterDTO model)
        {
            var surveyList = await _service.GetSureveyPaginationAsync(model.Page - 1, model.Size);
            return new PaginationDTO<IEnumerable<Survey>>(await _service.GetCount(), surveyList);
        }
        [HttpGet("{id}")]
        public async Task<Survey> Get([FromRoute] string id)
        {
            if (Guid.TryParse(id, out Guid surveyID))
            {
                var reuslt = await _service.GetSureveyFullAsync(surveyID);
                return reuslt;
            }
            return null;
        }

        // POST api/<SurveyContrller>
        [HttpPost]
        public async Task<UnifyResponseDto> Post(CreateSurveyDTO model)
        {
            if (await _service.CreateSureveyAsync(model))
            {
                return UnifyResponseDto.Sucess("添加成功");
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<SurveyContrller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SurveyContrller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
