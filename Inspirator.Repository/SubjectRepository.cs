using Inspirator.Model.Entities;
using Inspirator.IRepository;
using Inspirator.Model.Context;

namespace Inspirator.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(MainContext context) : base(context)
        {
        }
    }
}
