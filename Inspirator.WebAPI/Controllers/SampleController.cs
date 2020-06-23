using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Inspirator.IRepository;
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
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _service;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Sample> _logger;

        public SampleController(ISampleService service, IMapper mapper, IUnitOfWork unitOfWork, ILogger<Sample> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<SampleController>
        [HttpGet("{id}")]
        public async Task<IEnumerable<Sample>> Get([FromRoute] string id)
        {
            Guid.TryParse(id, out Guid userId);
            return await _service.GetamplesByUserIdAsync(userId);

        }


        // POST api/<SampleController>
        [HttpPost]
        public void Post(SubmitSampleDTO model)
        {
            _service.CreateSample(Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),model.Id, Sorce(model.Options));
        }

        private int Sorce(IList<int> options)
        {
            int s = 0;
            for (int i = 0; i < options.Count; i++)
            {
                s++;
            }
            return s;
        }
    }
}
