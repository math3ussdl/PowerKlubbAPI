using AutoMapper;
using MediatR;
using Shared.Common.Sources.Enums;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Queries.GetUserByNick;

using Contracts.Persistence;
using DTOs.User;

public class GetUserByNickQueryHandler
	: IRequestHandler<GetUserByNickQuery, BaseQueryResponse<UserDto>>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public GetUserByNickQueryHandler(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<BaseQueryResponse<UserDto>> Handle(GetUserByNickQuery request, CancellationToken cancellationToken)
	{
		BaseQueryResponse<UserDto> response = new();

		try
		{
			var user = await _userRepository.FindByNickName(request.Nick);

			if (user is null)
			{
				response.Success = false;
				response.Message = "User not found!";
				response.ErrorType = EErrorTypes.NotFound;
			}
			else
			{
				response.Success = true;
				response.Data = _mapper.Map<UserDto>(user);
			}
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
