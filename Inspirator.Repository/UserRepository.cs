using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainContext context) : base(context)
        {
        }
    }
}
