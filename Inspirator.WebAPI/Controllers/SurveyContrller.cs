using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyContrller : ControllerBase
    {
        private readonly ISurveyService _service;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SurveyContrller(ISurveyService service, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }



        [HttpGet]
        public async Task Get()
        {
            //var surevey = new Survey("Test", "summary");
            //Question question = new Question("qutitle", 1);
            //Option option = new Option("option", 1);
            //await _service.CreateSureveyAsync(surevey,question,option);
            //await _unitOfWork.CommitAsync();
        }

        // POST api/<SurveyContrller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
