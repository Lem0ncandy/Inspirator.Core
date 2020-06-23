using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspirator.Model.Entities;

namespace Inspirator.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IOptionRepository _optionRp;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(ISubjectRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IOptionRepository optionRp)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _optionRp = optionRp ?? throw new ArgumentNullException(nameof(optionRp));
        }

        public async Task<List<Guid>> GetOptionsIds(Guid surveyId, List<int> optionsIndex)
        {
            var subjects = await _repository.Find(x => x.SurveyId == surveyId).OrderBy(x => x.Index).Include(x => x.Options).ToListAsync();
            //var subjects1 = await _repository.Find(x => x.SurveyId == surveyId).Join(_optionRp.Find(), x => x.Id, o => o.SubjectId, (x, o) => o).ToListAsync();
            List <Guid> reult = new List<Guid>();
            for (int i = 0; i < subjects.Count; i++)
            {
                reult.Add(subjects[i].Options.Where(x => x.Index == optionsIndex[i]).Select(x => x.Id).First());
            }
            return reult;
        }
    }
}
