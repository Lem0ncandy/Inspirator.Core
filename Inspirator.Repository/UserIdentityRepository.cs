using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Repository
{
    public class UserIdentityRepository : GenericRepository<UserIdentity>, IUserIdentityRepository
    {
        public UserIdentityRepository(MainContext context) : base(context)
        {
        }
    }
}
