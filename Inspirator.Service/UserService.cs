using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;
using Inspirator.Model.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspirator.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserIdentityService _identitySvc;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IUserIdentityService identitySvc, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _identitySvc = identitySvc ?? throw new ArgumentNullException(nameof(identitySvc));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _repository.Find(x => x.Id == id && x.IsRemove == false).SingleAsync();
        }
        public async Task<User> GetUserAsync(string username)
        {
            return await _repository.Find(x => x.Username == username).SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetUserAsync()
        {
            return await _repository.Find(x => x.IsRemove == false).ToListAsync();
        }

        public async Task<Guid> GetUserIdAsync(string username)
        {
            return await _repository.Find(x => x.Username == username).Select(x => x.Id).SingleOrDefaultAsync();
        }

        public async Task<bool> CreateUserAsync(SignupDTO model)
        {
            User user = _mapper.Map<SignupDTO, User>(model);
            bool result = false;
            if (model != null)
            {
                await _repository.InsertAsync(user);
                await _identitySvc.CreateUserIdentityAsync(IdentityType.Password, user.Id, model.Password);
                result = await _unitOfWork.CommitAsync();
            }
            return result;
        }


    }
}
