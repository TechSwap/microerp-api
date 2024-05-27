using FluentValidation;
using MicroErp.Application.Bases;

namespace MicroErp.Application.UserCases.User.ForgotPassword;

public class ForgotPasswordValidator : RequestValidator<ForgotPasswordRequest>
{
    public ForgotPasswordValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Por favor, informe o Email");
    }
}
