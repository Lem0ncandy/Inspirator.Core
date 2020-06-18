using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateSureveyAsync(Survey survey,ICollection<Question> questions, ICollection<Option> options)
        {
            survey.Questions = new Collection<Question>();
            foreach (var question in questions)
            {
                question.Options = new Collection<Option>(options.Where( x=> x.QuestionIndex == question.Index).ToList());
            }
            survey.Questions = questions;
            await _repository.InsertAsync(survey);
        }

        public Task GetSureveyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Survey>> GetSureveyPagenationAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
