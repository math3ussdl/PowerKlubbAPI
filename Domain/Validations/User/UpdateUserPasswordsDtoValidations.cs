using FluentValidation;
using Global.Common.Sources.Errors;

namespace PowerKlubbAPI.Domain.Validations.User;

using Common;
using DTOs.User;

public sealed class UpdateUserPasswordsDtoValidations : AbstractValidator<UpdateUserPasswordDto>
{
	public UpdateUserPasswordsDtoValidations()
	{
		Include(new BaseUserPasswordsValidations());

		RuleFor(p => p.OldPassword)
			.Cascade(CascadeMode.Continue)
			.NotEmpty()
				.WithMessage(ExceptionsTranslated.RequiredField)
			.MinimumLength(6)
				.WithMessage(ExceptionsTranslated.ShortField)
			.MaximumLength(12)
				.WithMessage(ExceptionsTranslated.LongField);
	}
}
