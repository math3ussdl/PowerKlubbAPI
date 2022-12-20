using AutoMapper;
using MediatR;
using PowerKlubbAPI.Application.Extensions;
using Shared.Common.Sources.Enums;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Queries.GetUsers;

using Contracts.Persistence;
using DTOs.User;

public sealed class GetUsersQueryHandler
	: IRequestHandler<GetUsersQuery, BaseQueryResponse<IReadOnlyList<FlatUserDto>>>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}
	
	public async Task<BaseQueryResponse<IReadOnlyList<FlatUserDto>>> Handle(GetUsersQuery request,
		CancellationToken cancellationToken)
	{
		BaseQueryResponse<IReadOnlyList<FlatUserDto>> response = new();

		try
		{
			var query = _userRepository.Get(request.QuerySearch);
			var users = await query.PaginateAsync(request.Page, request.PageSize);

			response.Success = true;
			response.Data = _mapper.Map<IReadOnlyList<FlatUserDto>>(users);
		}
		catch (Exception e)
		{
			response.Success = false;
			response.Message = e.Message;
			response.ErrorType = EErrorTypes.Internal;
		}

		return response;
	}
}
