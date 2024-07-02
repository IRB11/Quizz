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

            CreateMap<LoginRequest, EFUser>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<EFUser, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role)).ReverseMap();

            CreateMap<UserRequest, EFUser>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role)).ReverseMap();

            CreateMap<EFRole, RoleRequest>().ReverseMap();
            CreateMap<EFRole, RoleResponse>().ReverseMap();

            CreateMap<EFLevel, LevelResponse>().ReverseMap();


        }
    }
}
