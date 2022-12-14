namespace PowerKlubbAPI.Domain.Interfaces.Persistence;

using Common;
using Entities;

public interface IUserRepository : IGenericRepository<User, Guid>
{
	Task<bool> ExistsByEmailAsync(string email);
}
