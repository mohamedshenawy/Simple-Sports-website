using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ViewModels;

namespace Sports_Website.MapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<SignUpVM, IdentityUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
