using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using System;

namespace Inspirator.Service
{
    public class SampleOptionsService : ISampleOptionService
    {
        private readonly ISampleRepository _repository;
        private readonly ISampleService _sampleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SampleOptionsService(ISampleRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ISampleService sampleService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sampleService = sampleService ?? throw new ArgumentNullException(nameof(sampleService));
        }
    }
}
