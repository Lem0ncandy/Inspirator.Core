using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface ISubjectService
    {
        Task<List<Guid>> GetOptionsIds(Guid surveyId, List<int> optionsIndex);
    }
}
