using AutoMapper;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;

namespace Inspirator.WebAPI.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignupDTO,User>();
        }
    }
}
