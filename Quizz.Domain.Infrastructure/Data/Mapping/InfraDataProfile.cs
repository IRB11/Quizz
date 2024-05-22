using AutoMapper;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Infrastructure.Data.Entities;


namespace Quizz.Domain.Infrastructure.Data.Mapping
{
    public class InfraDataProfile : Profile
    {
        public InfraDataProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<EFLevel, LevelRequest>().ReverseMap();
            CreateMap<EFLevel, LevelResponse>().ReverseMap();


        }
    }
}
