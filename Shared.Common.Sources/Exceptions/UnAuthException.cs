namespace Shared.Common.Sources.Exceptions;

/// <summary>
/// <see cref="UnAuthException"/> class
/// </summary>
public class UnAuthException : Exception
{
	public int StatusCode { get; set; } = 401;
	
	/// <summary>
	/// <see cref="UnAuthException"/> ctor
	/// </summary>
	public UnAuthException()
	{
	}
}
