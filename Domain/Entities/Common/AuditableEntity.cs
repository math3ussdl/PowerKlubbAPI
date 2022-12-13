using System.ComponentModel.DataAnnotations;

namespace PowerKlubbAPI.Domain.Entities.Common;

public class AuditableEntity
{
	[Key]
	public Guid Id { get; set; }
	
	[Required]
	public DateTimeOffset CreatedAt { get; set; }
	
	[Required]
	public DateTimeOffset UpdatedAt { get; set; }
}
