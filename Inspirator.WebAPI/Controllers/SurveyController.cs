using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _service;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SurveyController(ISurveyService service, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
                var reuslt  = await _service.GetSureveyFullAsync(surveyID);
                return reuslt;
            }
            return null;
        }

        // POST api/<SurveyContrller>
        [HttpPost]
        public async Task<UnifyResponseDto> Post(CreateSurveyDTO model)
        {
            await _service.CreateSureveyAsync(model);
            if (await _unitOfWork.CommitAsync())
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
