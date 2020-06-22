using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;

namespace Inspirator.Repository
{
    public class SampleOptionRepository : GenericRepository<SampleOption>, ISampleOptionRepository
    {
        public SampleOptionRepository(MainContext context) : base(context)
        {
        }
    }
}
