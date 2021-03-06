﻿using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;

namespace Inspirator.Repository
{
    public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(MainContext context) : base(context)
        {
        }
    }
}
