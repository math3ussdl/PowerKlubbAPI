namespace PowerKlubbAPI.Domain.DTOs.User;

public interface IUserPasswordsDto
{
	public string Password { get; set; }
	public string PasswordConfirm { get; set; }
}
