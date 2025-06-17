using System;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Entities.AppUser, DTOs.MemberDto>()
        .ForMember(d => d.Age, o => o.MapFrom(src => src.DateOfBirth.CalculateAge()))
        .ForMember(dest => dest.PhotoUrl,
        opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain)!.Url));

        CreateMap<DTOs.PhotoDto, Entities.Photo>();

        CreateMap<Entities.Photo, DTOs.PhotoDto>();

        CreateMap<MemberUpdateDto, AppUser>();
    }
}
