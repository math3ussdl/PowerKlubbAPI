namespace PowerKlubbAPI.Application.DTOs.Common;

public class AuditableDto : FlatAuditableDto
{
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
