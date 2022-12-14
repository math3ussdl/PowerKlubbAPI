namespace PowerKlubbAPI.Domain.Contracts.Persistence;

using Common;
using Entities;

public interface IUserRepository : IGenericRepository<User, Guid>
{
	Task<bool> ExistsByEmailAsync(string email);
}
