using ActivityServise.Application.Abstractions;
using ActivityServise.Application.Abstractions.DB;

namespace ActivityServise.Persistence;

public class UnitOfWork(
    ActivityServiceDbContext context,
    IUserRepository userRepository): IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}