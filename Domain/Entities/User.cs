using System.ComponentModel.DataAnnotations;

namespace PowerKlubbAPI.Domain.Entities;

using Common;

public sealed class User : AuditableEntity
{
	[Required, MinLength(4), MaxLength(40)]
	public string Name { get; set; }
	
	[Required, MinLength(4), MaxLength(20)]
	public string Nick { get; set; }
	
	public string ProfileImage { get; set; } = string.Empty;
	
	[Required, MaxLength(200)]
	public string Bio { get; set; }
	
	[Required, EmailAddress, MinLength(12), MaxLength(120)]
	public string Email { get; set; }
	
	[Required]
	public string HashedPassword { get; set; }

	public IQueryable<User> Followers { get; set; } = default!;
	public IQueryable<User> Following { get; set; } = default!;
}
