using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface ISurveyService
    {
        Task<bool> CreateSureveyAsync(CreateSurveyDTO surveyDTO);
        Task<Survey> GetSureveyFullAsync(Guid id);
        Task<IEnumerable<Survey>> GetSureveyPaginationAsync(int page,int size);
        Task<int> GetCount();
    }
}
