namespace PowerKlubbAPI.Application.DTOs.User;

using Common;

public sealed class UserDto : AuditableDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; } = string.Empty;
	public string Bio { get; set; }
	public string Email { get; set; }
	public ICollection<Domain.Entities.User> Followers { get; set; } = default!;
	public ICollection<Domain.Entities.User> Following { get; set; } = default!;
}
