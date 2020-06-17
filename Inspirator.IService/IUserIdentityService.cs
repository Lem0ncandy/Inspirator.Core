using Inspirator.Model.Entities;
using Inspirator.Model.Entities.Enum;
using System;
using System.Threading.Tasks;

namespace Inspirator.IService
{
    public interface IUserIdentityService
    {
        Task<bool> VerifyPasswordAsync(Guid userId, string password);
        Task<UserIdentity> GetFirstUserIdentityByUserId(Guid userId, IdentityType type);
        Task<bool> CreateUserIdentityAsync(IdentityType type, Guid userId, string credential);
    }
}
