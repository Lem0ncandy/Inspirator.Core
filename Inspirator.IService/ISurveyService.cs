using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface ISurveyService
    {
        Task CreateSureveyAsync(Survey survey, Question question, Option option);
        Task GetSureveyAsync(Guid id);
        Task<IEnumerable<Survey>> GetSureveyPagenationAsync(Guid id);
    }
}
