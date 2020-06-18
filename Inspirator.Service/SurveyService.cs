using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SurveyService(ISurveyRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
