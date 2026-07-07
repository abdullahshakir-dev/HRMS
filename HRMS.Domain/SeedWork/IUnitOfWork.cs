namespace HRMS.Domain.SeedWork;

public interface IUnitOfWork
{
    Task <bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}