using MediatR;
using Shared.Common.Sources.Enums;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Commands.DeleteUser;

using Contracts.Persistence;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseResponse>
{
	private readonly IUserRepository _userRepository;

	public DeleteUserCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<BaseResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		BaseResponse response = new();

		try
		{
			var user = await _userRepository.GetByIdAsync(request.UserId);

			if (user is null)
			{
				response.Success = false;
				response.ErrorType = EErrorTypes.NotFound;
				response.Message = "User not found!";
			}
			else
			{
				await _userRepository.DeleteAsync(user);
				
				response.Success = true;
				response.Message = "User successfully deleted!";
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
