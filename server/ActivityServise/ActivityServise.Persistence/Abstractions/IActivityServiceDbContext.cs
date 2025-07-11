using Microsoft.EntityFrameworkCore;

namespace ActivityServise.Persistence.Abstractions;

public interface IActivityServiceDbContext
{
    DbSet<T> Set<T>() where T : class;
}