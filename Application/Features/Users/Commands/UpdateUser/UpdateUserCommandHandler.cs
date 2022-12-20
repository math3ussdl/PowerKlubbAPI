using AutoMapper;
using MediatR;
using PowerKlubbAPI.Application.Validations.User;
using Shared.Common.Sources.Enums;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Commands.UpdateUser;

using Contracts.Persistence;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<BaseResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		BaseResponse response = new();

		try
		{
			var body = request.UpdateUserDto;

			var validator = new UpdateUserDtoValidations();
			var validationResult = await validator.ValidateAsync(body, cancellationToken);

			if (validationResult.IsValid is false)
			{
				response.Success = false;
				response.Message = "Validation failed!";
				response.ErrorType = EErrorTypes.MalformedBody;
				response.Errors = validationResult.Errors
					.Select(e => e.ErrorMessage)
					.ToList();
			}
			else
			{
				var user = await _userRepository.GetByIdAsync(request.UpdateUserDto.Id);

				if (user is null)
				{
					response.Success = false;
					response.Message = "User not exists!";
					response.ErrorType = EErrorTypes.NotFound;
				}
				else
				{
					_mapper.Map(body, user);
					await _userRepository.UpdateAsync(user);
					
					response.Success = true;
					response.Message = "User successfully updated!";
				}
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
