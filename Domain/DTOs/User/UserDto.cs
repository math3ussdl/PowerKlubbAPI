namespace PowerKlubbAPI.Domain.DTOs.User;

using Common;
using Entities;

public sealed class UserDto : AuditableDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; } = string.Empty;
	public string Bio { get; set; }
	public string Email { get; set; }
	public IQueryable<User> Followers { get; set; } = default!;
	public IQueryable<User> Following { get; set; } = default!;
}
