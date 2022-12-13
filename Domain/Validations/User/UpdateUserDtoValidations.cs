using FluentValidation;

namespace PowerKlubbAPI.Domain.Validations.User;

using Common;
using DTOs.User;

public sealed class UpdateUserDtoValidations : AbstractValidator<UpdateUserDto>
{
	public UpdateUserDtoValidations()
	{
		Include(new BaseUserValidations());
	}
}
