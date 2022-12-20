namespace Shared.Common.Sources.Responses;

using Enums;

public class BaseResponse
{
	public bool Success { get; set; }
	public string Message { get; set; }
	public List<string> Errors { get; set; }
	public EErrorTypes ErrorType { get; set; }
}
