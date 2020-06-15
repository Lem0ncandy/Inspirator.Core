using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inspirator.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAsync()
        {
           return await _repository.FindAsync(x => x.IsRemove != false).ToListAsync();
        }

        public async Task<int> Insert(User user)
        {
            return await _repository.InsertAsync(user);
        }
        public async Task<int> Insert()
        {
            return await _repository.InsertAsync(new User
            {
                Username = "123",
            });
        }
    }
}
