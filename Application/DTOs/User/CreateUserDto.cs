namespace PowerKlubbAPI.Application.DTOs.User;

public sealed class CreateUserDto : IUserDto, IUserPasswordsDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; } = string.Empty;
	public string Bio { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string PasswordConfirm { get; set; }
}
