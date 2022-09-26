using AutoMapper;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Extensions;

namespace DatingAppAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //Maps one object to another
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                src.DateofBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();

        }
    }
}
