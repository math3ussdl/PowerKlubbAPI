namespace PowerKlubbAPI.Domain.DTOs.User;

public interface IUserDto
{
	public string Name { get; set; }
	public string ProfileImage { get; set; }
	public string Bio { get; set; }
	public string Email { get; set; }
}
