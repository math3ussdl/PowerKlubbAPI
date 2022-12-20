namespace Shared.Common.Sources.Responses;

public class BaseQueryResponse<T> : BaseResponse
{
	public T Data { get; set; }
}
