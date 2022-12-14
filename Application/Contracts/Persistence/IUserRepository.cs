using PowerKlubbAPI.Domain.Entities;

namespace PowerKlubbAPI.Application.Contracts.Persistence;

using Common;

public interface IUserRepository : IGenericRepository<User, Guid>
{
	Task<bool> ExistsByEmailAsync(string email);
}
