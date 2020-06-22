using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;

namespace Inspirator.Repository
{
    public class SampleRepository : GenericRepository<Sample>, ISampleRepository
    {
        public SampleRepository(MainContext context) : base(context)
        {
        }
    }
}
