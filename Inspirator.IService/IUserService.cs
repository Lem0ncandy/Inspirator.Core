using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface IUserService
    {
        public Task<User> GetUserAsync(Guid id);
        public Task<List<User>> GetUserAsync();
        public Task<bool> CreateUserAsync(SignupDTO user);
    }
}
