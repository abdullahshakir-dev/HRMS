namespace HRMS.Domain.SeedWork;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<TEntity?> GetById(Guid id);
    
    IQueryable<TEntity> GetQueryable();
    
    void Add(TEntity entity);
    
    void Update(TEntity entity);
    
    void Remove(TEntity entity);
}