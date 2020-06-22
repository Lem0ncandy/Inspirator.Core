using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface ISampleService
    {
        Task<Sample> GetSampleByIdAsync(Guid id);
        Task<List<Sample>> GetamplesByUserIdAsync(Guid userId);
        Task CreateSample(Guid userId,Guid surveyId,int score);
    }
}
