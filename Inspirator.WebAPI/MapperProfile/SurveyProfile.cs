using AutoMapper;
using Inspirator.Model.DTO;
using Inspirator.Model.Entities;

namespace Inspirator.WebAPI.MapperProfile
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<CreateSurveyDTO, Survey>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<OptionDTO, Option>();
            CreateMap<Survey, CreateSurveyDTO>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<Option, OptionDTO>();
        }
    }
}
