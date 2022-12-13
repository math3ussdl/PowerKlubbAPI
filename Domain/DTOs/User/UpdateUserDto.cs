namespace PowerKlubbAPI.Domain.DTOs.User;

using Common;

public sealed class UpdateUserDto : FlatAuditableDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; } = string.Empty;
	public string Bio { get; set; }
	public string Email { get; set; }
}
