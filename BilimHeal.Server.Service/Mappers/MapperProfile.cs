using AutoMapper;
using BilimHeal.Server.Domain.Entities;
using BilimHeal.Server.Service.DTOs.Users;

namespace BilimHeal.Server.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // User
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForChangeRoleDto>().ReverseMap();
        CreateMap<User, UserForChangePasswordDto>().ReverseMap();
    }
}
