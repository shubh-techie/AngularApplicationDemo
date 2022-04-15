using AutoMapper;
using DatingApp.Api.Model;

namespace DatingApp.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserInfoDto>().ReverseMap();
        }
    }
}
