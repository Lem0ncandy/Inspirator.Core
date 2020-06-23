using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;

namespace Inspirator.Repository
{
    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        public OptionRepository(MainContext context) : base(context)
        {
        }
    }
}
