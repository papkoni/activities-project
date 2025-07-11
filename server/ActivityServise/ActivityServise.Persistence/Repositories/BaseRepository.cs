using ActivityServise.Application.Abstractions.DB;
using ActivityServise.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ActivityServise.Persistence.Repositories;

public class BaseRepository<T>(
    IActivityServiceDbContext context): IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }
    
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}