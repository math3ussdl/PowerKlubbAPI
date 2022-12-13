using FluentValidation;
using Global.Common.Sources.Errors;
using PowerKlubbAPI.Domain.DTOs.User;

namespace PowerKlubbAPI.Domain.Validations.User.Common;

public class BaseUserValidations : AbstractValidator<IUserDto>
{
	public BaseUserValidations()
	{
		RuleFor(u => u.Name)
			.Cascade(CascadeMode.Continue)
			.NotEmpty()
				.WithMessage(ExceptionsTranslated.RequiredField)
			.MinimumLength(4)
				.WithMessage(ExceptionsTranslated.ShortField)
			.MaximumLength(40)
				.WithMessage(ExceptionsTranslated.LongField);
		
		RuleFor(u => u.Bio)
			.Cascade(CascadeMode.Continue)
			.NotEmpty()
				.WithMessage(ExceptionsTranslated.RequiredField)
			.MaximumLength(200)
				.WithMessage(ExceptionsTranslated.LongField);

		RuleFor(u => u.Email)
			.Cascade(CascadeMode.Continue)
			.NotEmpty()
				.WithMessage(ExceptionsTranslated.RequiredField)
			.EmailAddress()
				.WithMessage(ExceptionsTranslated.EmailField)
			.MinimumLength(12)
				.WithMessage(ExceptionsTranslated.ShortField)
			.MaximumLength(120)
				.WithMessage(ExceptionsTranslated.LongField);
	}
}
