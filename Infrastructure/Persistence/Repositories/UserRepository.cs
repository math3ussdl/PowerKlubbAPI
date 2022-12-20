using Microsoft.EntityFrameworkCore;
using PowerKlubbAPI.Application.Contracts.Persistence;
using PowerKlubbAPI.Domain.Entities;

namespace PowerKlubbAPI.Infrastructure.Persistence.Repositories;

using Common;
using Context;

public class UserRepository : GenericRepository<User, Guid>, IUserRepository
{
	private readonly ApiContext _context;

	public UserRepository(ApiContext context) : base(context)
	{
		_context = context;
	}

	public async Task<bool> ExistsByEmailAsync(string email)
	{
		var user = await _context.Users
			.FirstOrDefaultAsync(u => u.Email == email);

		return user is not null;
	}

	public async Task<User> FindByNickName(string nick)
	{
		return await _context.Users
			.FirstOrDefaultAsync(u => u.Nick == nick);
	}
}
