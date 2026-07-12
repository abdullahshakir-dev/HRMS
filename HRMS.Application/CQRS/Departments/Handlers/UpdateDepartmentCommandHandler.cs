using AutoMapper;
using HRMS.Application.CQRS.Departments.Commands;
using HRMS.Application.DTOs;
using HRMS.Domain.Entities;
using HRMS.Domain.SeedWork;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Handlers;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentRequestDto>
{
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDepartmentCommandHandler(IGenericRepository<Department> departmentRepository,IUnitOfWork unitOfWork , IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<DepartmentRequestDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        try
        { 
            var department = await _departmentRepository.GetById(request.Id);
            
            if (department == null) return null;
            
            _mapper.Map(request, department);
            
            _departmentRepository.Update(department);

            if ( await _unitOfWork.SaveChangesAsync(cancellationToken))
            {
                return _mapper.Map<DepartmentRequestDto>(department);
            }
            return null;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occured while updating the department: {e.Message}");
        }
    }
}