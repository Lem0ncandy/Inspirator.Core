using AutoMapper;
using Inspirator.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ISubjectService service, IMapper mapper, ILogger<SubjectController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task Get()
        {
            List<int> l = new List<int>();
            for (int i = 0; i < 13; i++)
            {
                l.Add(1);
            }
            await _service.GetOptionsIds(Guid.Parse("f5783ccf-b99a-4792-8247-a76c3764e210"),l);
        }
    }
}