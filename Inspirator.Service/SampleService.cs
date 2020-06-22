using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.Service
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _repository;

        public SampleService(ISampleRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task CreateSample(Guid userId, Guid surveyId, int score)
        {
            await _repository.InsertAsync(new Sample(userId, surveyId, score));
        }

        public async Task<List<Sample>> GetamplesByUserIdAsync(Guid userId)
        {
            return await _repository.Find(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Sample> GetSampleByIdAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }
    }
}
