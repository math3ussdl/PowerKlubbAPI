namespace PowerKlubbAPI.Domain.DTOs.User;

using Common;

public sealed class FlatProductDto : FlatAuditableDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; } = string.Empty;
	public string Email { get; set; }
}
