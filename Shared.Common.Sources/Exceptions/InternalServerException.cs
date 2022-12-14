namespace Shared.Common.Sources.Exceptions;

/// <summary>
/// <see cref="InternalServerException"/> class
/// </summary>
public class InternalServerException : Exception
{
	public int StatusCode { get; set; } = 500;
	
	/// <summary>
	/// <see cref="InternalServerException"/> ctor
	/// </summary>
	public InternalServerException()
	{
	}
}
