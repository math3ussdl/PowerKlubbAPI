using FluentValidation;

namespace PowerKlubbAPI.Application.Validations.User;

using Common;
using DTOs.User;

public sealed class CreateUserDtoValidations : AbstractValidator<CreateUserDto>
{
	public CreateUserDtoValidations()
	{
		Include(new BaseUserValidations());
		Include(new BaseUserPasswordsValidations());
	}
}
