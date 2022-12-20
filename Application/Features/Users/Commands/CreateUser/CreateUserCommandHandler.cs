using AutoMapper;
using MediatR;
using PowerKlubbAPI.Domain.Entities;
using Shared.Common.Sources.Enums;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Commands.CreateUser;

using Contracts.Application.MailSender;
using Contracts.Application.Cryptograph;
using Contracts.Persistence;
using Models;
using Validations.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;
	private readonly IHasher _hasher;
	private readonly IMailSender _mailSender;

	public CreateUserCommandHandler(IUserRepository userRepository,
		IMapper mapper,
		IHasher hasher,
		IMailSender mailSender)
	{
		_userRepository = userRepository;
		_mapper = mapper;
		_hasher = hasher;
		_mailSender = mailSender;
	}

	public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		BaseResponse response = new();

		try
		{
			var body = request.CreateUserDto;

			var validator = new CreateUserDtoValidations();
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
				var userExists = await _userRepository.ExistsByEmailAsync(body.Email);

				if (userExists)
				{
					response.Success = false;
					response.Message = "User already exists!";
					response.ErrorType = EErrorTypes.Found;
				}
				else
				{
					var user = _mapper.Map<User>(body);

					var hash = await _hasher.HashAsync(body.Password);
					user.HashedPassword = hash;

					await _userRepository.AddAsync(user);
				
					Email email = new()
					{
						To = user.Email,
						Subject = "Account created!",
						Body = $"Hello, {user.Name}! Your account has been created!"
					};
				
					await _mailSender.SendMailAsync(email);
				
					response.Success = true;
					response.Message = "User successfully created!";
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
