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
            CreateMap<UserME, UserCreateDTO>().ReverseMap();
            CreateMap<UserME, UserUpdateDTO>().ReverseMap();
            CreateMap<UserME, UserDeleteDTO>().ReverseMap();
            CreateMap<UserME, UserDeleteDTO>().ReverseMap();
            CreateMap<UserDTO, UserME>().ReverseMap(); ;
            CreateMap<GenderME, GenderDTO>().ReverseMap();

            CreateMap<UserDTO, UserME>()
            .ForMember(dest => dest.IdGender, opt => opt.MapFrom(src => src.GenderId));

        }
    }
}
