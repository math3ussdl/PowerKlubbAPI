namespace PowerKlubbAPI.Domain.DTOs.User;

using Common;

public sealed class UpdateUserPasswordDto : FlatAuditableDto
{
	public string OldPassword { get; set; }
	public string Password { get; set; }
	public string PasswordConfirm { get; set; }
}
