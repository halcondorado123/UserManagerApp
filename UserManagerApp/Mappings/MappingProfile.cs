using AutoMapper;
using UserManager.Data.Entities;
using UserManagerApp.DTOs;

namespace UserManagerApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserME, UserCreateDTO>().ReverseMap();
            CreateMap<UserME, UserUpdateDTO>().ReverseMap();
            CreateMap<UserME, UserDeleteDTO>().ReverseMap();

        }
    }
}
