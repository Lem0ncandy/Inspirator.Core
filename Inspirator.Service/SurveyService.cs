using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateSureveyAsync(CreateSurveyDTO surveyDTO)
        {
            Survey survey = _mapper.Map<Survey>(surveyDTO);
            IList<Subject> subjects = _mapper.Map<List<Subject>>(surveyDTO.SubjectDTOs);
            survey.Subjects = subjects;
            foreach (var subject in subjects)
            {
                subject.Options = _mapper.Map<List<Option>>(surveyDTO.OptionDTOs.Where(x => x.SubjectIndex == subject.Index).ToList());
            }
            await _repository.InsertAsync(survey);
        }

        public async Task<int> GetCount()
        {
            return await _repository.Find().CountAsync();
        }

        public async Task<Survey> GetSureveyFullAsync(Guid id)
        {
            return await _repository.Find().Where(x => x.Id == id).Include(x => x.Subjects).ThenInclude(x => x.Options).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Survey>> GetSureveyPaginationAsync(int page, int size)
        {
            return await _repository.Find(page, size).AsNoTracking().ToListAsync();
        }
    }
}
