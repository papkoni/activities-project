using ActivityServise.Application.Abstractions.DB;
using ActivityServise.Domain.Entities;

namespace ActivityServise.Persistence.Repositories;

public class UserRepository(ActivityServiceDbContext context): BaseRepository<User>(context), IUserRepository
{
    
}