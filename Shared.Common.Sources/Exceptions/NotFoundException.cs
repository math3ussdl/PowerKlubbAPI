namespace Shared.Common.Sources.Exceptions;

/// <summary>
/// <see cref="NotFoundException"/> class
/// </summary>
public class NotFoundException : Exception
{
	public int StatusCode { get; set; } = 404;

	/// <summary>
	/// <see cref="NotFoundException"/> ctor
	/// </summary>
	public NotFoundException(string message) : base(message)
	{
	}
}
