using AutoMapper;
using UserManager.Data.Entities;
using UserManagerApp.DTOs;
using UserManagerApp.Web.DTOs;

namespace UserManagerApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de entidad <-> DTOs específicos
            CreateMap<UserME, CreateUserDTO>().ReverseMap();
            CreateMap<UserME, UserUpdateDTO>().ReverseMap();
            CreateMap<UserME, UserDeleteDTO>().ReverseMap();

            CreateMap<UserDTO, UserME>()
                .ForMember(dest => dest.IdGender, opt => opt.MapFrom(src => src.GenderId))
                .ReverseMap();
            CreateMap<CreateUserDTO, UserCreateDTO>()
           .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.IdGender))
                .ReverseMap();

            CreateMap<UserCreateDTO, UserME>()
                        .ForMember(dest => dest.IdGender, opt => opt.MapFrom(src => src.GenderId));

            CreateMap<UserCreateDTO, UserME>()
                .ForMember(dest => dest.IdGender, opt => opt.MapFrom(src => src.GenderId));

            CreateMap<GenderME, GenderDTO>().ReverseMap();
        }
    }
}
