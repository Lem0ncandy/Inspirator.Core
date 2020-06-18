using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface ISurveyService
    {
        Task CreateSureveyAsync(CreateSurveyDTO surveyDTO);
        Task GetSureveyAsync(Guid id);
        Task<IEnumerable<Survey>> GetSureveyPagenationAsync(Guid id);
    }
}
