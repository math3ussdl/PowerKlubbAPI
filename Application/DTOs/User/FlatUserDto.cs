namespace PowerKlubbAPI.Application.DTOs.User;

using Common;

public sealed class FlatUserDto : FlatAuditableDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; } = string.Empty;
	public string Email { get; set; }
}
