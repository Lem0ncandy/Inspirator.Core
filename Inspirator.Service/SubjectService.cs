using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using System;

namespace Inspirator.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(ISubjectRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
