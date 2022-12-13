using FluentValidation;
using Global.Common.Sources.Errors;

namespace PowerKlubbAPI.Domain.Validations.User.Common;

using DTOs.User;

public class BaseUserPasswordsValidations : AbstractValidator<IUserPasswordsDto>
{
	public BaseUserPasswordsValidations()
	{
		RuleFor(u => u.Password)
			.Cascade(CascadeMode.Continue)
			.NotEmpty()
				.WithMessage(ExceptionsTranslated.RequiredField)
			.MinimumLength(6)
				.WithMessage(ExceptionsTranslated.ShortField)
			.MaximumLength(12)
				.WithMessage(ExceptionsTranslated.LongField);
		
		RuleFor(u => u.PasswordConfirm)
			.Cascade(CascadeMode.Continue)
			.NotEmpty()
				.WithMessage(ExceptionsTranslated.RequiredField)
			.MinimumLength(6)
				.WithMessage(ExceptionsTranslated.ShortField)
			.MaximumLength(12)
				.WithMessage(ExceptionsTranslated.LongField);
	}
}
