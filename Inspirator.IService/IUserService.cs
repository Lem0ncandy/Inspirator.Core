using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface IUserService
    {
        public Task<User> GetAsync(Guid id);
        public Task<List<User>> GetAsync();
        public Task<int> Insert(User user);
    }
}
