namespace Shared.Common.Sources.Exceptions;

/// <summary>
/// <see cref="BadRequestException"/> class
/// </summary>
public class BadRequestException : Exception
{
	public int StatusCode { get; set; } = 400;
	
	/// <summary>
	/// <see cref="BadRequestException"/> ctor
	/// </summary>
	public BadRequestException(string message) : base(message)
	{
	}
}
