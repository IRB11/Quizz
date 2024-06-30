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

            CreateMap<EFQuestion, QuestionRequest>()
                .ForMember(dest => dest.Response, opt => opt.MapFrom(src => src.Responses))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore l'ID lors du mappage inverse

            // Configuration pour EFQuestion vers QuestionResponse et vice versa
            CreateMap<EFQuestion, QuestionResponse>()
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level)) // Map EFLevel to LevelDto
                .ForMember(dest => dest.Technology, opt => opt.MapFrom(src => src.Technology)) // Map EFTechnology to TechnologyDto
                .ForMember(dest => dest.Response, opt => opt.MapFrom(src => src.Responses))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore l'ID lors du mappage inverse

            // Configuration pour EFTechnology vers TechnologiesRequest et vice versa
            CreateMap<EFTechnology, TechnologiesRequest>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore l'ID lors du mappage inverse

            // Configuration pour EFTechnology vers TechnologiesResponse et vice versa
            CreateMap<EFTechnology, TechnologiesResponse>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore l'ID lors du mappage inverse

            // Configuration pour EFResponse vers Response_Request et vice versa
            CreateMap<EFResponse, Response_Request>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore l'ID lors du mappage inverse

            CreateMap<EFRole, Role>();
            CreateMap<EFTechnology, TechnologiesResponse>().ReverseMap();
            CreateMap<EFTechnology, TechnologiesRequest>().ReverseMap();
            // Configuration pour EFResponse vers Response_Response et vice versa
            CreateMap<EFResponse, Response_Response>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());



        }
    }
}
