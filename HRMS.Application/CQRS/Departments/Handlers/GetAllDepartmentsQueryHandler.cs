using AutoMapper;
using HRMS.Application.CQRS.Departments.Queries;
using HRMS.Application.DTOs;
using HRMS.Domain.Entities;
using HRMS.Domain.SeedWork;
using HRMS.Infrastructure.Persistence;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Handlers;

public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery,IEnumerable<DepartmentResponseDto>>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IMapper _mapper;

    public GetAllDepartmentsQueryHandler(UnitOfWork unitOfWork,
        IGenericRepository<Department> departmentRepository,IMapper mapper
        )
    {
        _unitOfWork = unitOfWork;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<DepartmentResponseDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        try
        { 
            var departments = await _departmentRepository.GetAllAsync(); 
            return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResponseDto>>(departments);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Error occured while getting all departments.", e);
        }
    }
}