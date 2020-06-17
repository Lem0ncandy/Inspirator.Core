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
        public Task<User> GetUserAsync(string username);
        public Task<Guid> GetUserIdAsync(string username);
        public Task<List<User>> GetUserAsync();
        public Task<bool> CreateUserAsync(SignupDTO user);
    }
}
