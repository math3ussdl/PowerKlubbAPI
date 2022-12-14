namespace PowerKlubbAPI.Application.DTOs.User;

using Common;

public sealed class UpdateUserPasswordDto : FlatAuditableDto, IUserPasswordsDto
{
	public string OldPassword { get; set; }
	public string Password { get; set; }
	public string PasswordConfirm { get; set; }
}
