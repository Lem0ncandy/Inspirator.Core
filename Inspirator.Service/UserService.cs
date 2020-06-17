using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.Entities;
using Inspirator.Model.Entities.Enum;
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
        private readonly IUserIdentityService _identitySvc;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IUserIdentityService identitySvc, IMapper mapper)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _identitySvc = identitySvc ?? throw new ArgumentNullException(nameof(identitySvc));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _repository.Find(x => x.Id == id && x.IsRemove == false).SingleAsync();
        }

        public async Task<List<User>> GetUserAsync()
        {
            return await _repository.Find(x => x.IsRemove == false).ToListAsync();
        }

        public async Task<bool> CreateUserAsync(User user,string password)
        {
            bool result = false;
            if (user != null)
            {
                result = (await _repository.InsertAsync(user)) > 0;
                if (result)
                {
                    result = await _identitySvc.CreateUserIdentityAsync(IdentityType.Password, user.Id, password);
                }
            }
            return result;
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
