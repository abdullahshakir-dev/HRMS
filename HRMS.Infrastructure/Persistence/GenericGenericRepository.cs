using HRMS.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Persistence;

public class GenericGenericRepository <TEntity> : IGenericRepository<TEntity> where TEntity: class
{
    private readonly AppDbContext _context;

    public GenericGenericRepository(AppDbContext context)
    {
        _context = context;
        
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}