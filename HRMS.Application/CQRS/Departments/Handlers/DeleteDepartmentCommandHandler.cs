using HRMS.Application.CQRS.Departments.Commands;
using HRMS.Domain.Entities;
using HRMS.Domain.SeedWork;
using HRMS.Infrastructure.Persistence;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Handlers;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
{
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly UnitOfWork _unitOfWork;

    public DeleteDepartmentCommandHandler(IGenericRepository<Department> departmentRepository, UnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        try
        { 
            var department = await _departmentRepository.GetById(request.Id);
            if (department == null) return false;
            _departmentRepository.Remove(department);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken))
            {
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting department: {e.Message}", e);
        }
    }
}