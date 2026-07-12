using HRMS.Application.CQRS.Departments.Commands;
using HRMS.Application.DTOs;
using HRMS.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace HRMS.Application.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Department, DepartmentRequestDto>().ReverseMap();

        CreateMap<AddDepartmentCommand, Department>();
        CreateMap<Department, DepartmentResponseDto>();
        CreateMap<HRMS.Domain.Entities.Profile, DepartmentProfileResponseDto>();
    }

}