namespace ActivityServise.Application.Abstractions.DB;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    IUserRepository UserRepository { get; }
}