using FluentValidation;

namespace PowerKlubbAPI.Application.Validations.User;

using Common;
using DTOs.User;

public sealed class UpdateUserDtoValidations : AbstractValidator<UpdateUserDto>
{
	public UpdateUserDtoValidations()
	{
		Include(new BaseUserValidations());
	}
}
