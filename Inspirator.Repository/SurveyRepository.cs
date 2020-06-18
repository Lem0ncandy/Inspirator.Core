using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Repository
{
    public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(MainContext context) : base(context)
        {
        }
    }
}
