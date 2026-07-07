using HRMS.Application.DTOs;
using HRMS.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace HRMS.Application.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Department, DepartmentRequestDto>().ReverseMap();
        CreateMap<Department, DepartmentResponseDto>().ReverseMap();
        CreateMap<Profile, DepartmentProfileResponseDto>().ReverseMap();
    }
    
}