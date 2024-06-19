using AutoMapper;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
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

            CreateMap<LoginRequest, EFUser>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<EFUser, UserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id));

            CreateMap<UserRequest, EFUser>()
                .ForMember(dest => dest.Role, opt => opt.Ignore());

            CreateMap<EFUser, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.Condition(src => src.Role != null))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<EFRole, Role>();

            CreateMap<EFLevel, LevelResponse>().ReverseMap();


        }
    }
}
