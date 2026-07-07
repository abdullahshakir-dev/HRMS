using AutoMapper;
using HRMS.Application.CQRS.Departments.Commands;
using HRMS.Domain.Entities;
using HRMS.Domain.SeedWork;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Handlers;

public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, Guid>
{
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddDepartmentCommandHandler(
        IGenericRepository<Department> departmentRepository,
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);

        _departmentRepository.Add(department);

        var saved = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (!saved)
        {
            throw new InvalidOperationException("Failed to persist the new department.");
        }

        return department.Id;
    }
}