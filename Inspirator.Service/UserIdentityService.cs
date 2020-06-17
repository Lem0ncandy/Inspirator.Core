using AutoMapper;
using Inspirator.Common;
using Inspirator.IRepository;
using Inspirator.IService;
using Inspirator.Model.Entities;
using Inspirator.Model.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Inspirator.Service
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUserIdentityRepository _repository;
        private readonly IMapper _mapper;

        public UserIdentityService(IUserIdentityRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateUserIdentityAsync(IdentityType type, Guid userId, string credential)
        {
            if (type == IdentityType.Password)
            {
                credential = EncryptUtil.Encrypt(credential);
            }
           return await (_repository.InsertAsync(new UserIdentity(type, credential, userId))) > 0;
        }

        public async Task<UserIdentity> GetFirstUserIdentityByUserId(Guid userId,IdentityType type)
        {
            return await _repository.Find(x => x.UserId == userId && x.IdentityType == type).SingleOrDefaultAsync();
        }

        public async Task<bool> VerifyPasswordAsync(Guid userId, string password)
        {
            var identity = await this.GetFirstUserIdentityByUserId(userId,IdentityType.Password);
            if (identity != null)
            {
                return EncryptUtil.Verify(identity.Credential, password);
            }
            return false;
        }

    }
}
