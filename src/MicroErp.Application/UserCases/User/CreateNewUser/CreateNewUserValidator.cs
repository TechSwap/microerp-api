using FluentValidation;
using MicroErp.Application.Bases;

namespace MicroErp.Application.UserCases.User.CreateNewUser;

public class CreateNewUserValidator : RequestValidator<CreateNewUserRequest>
{
    public CreateNewUserValidator()
    {
        RuleFor(r => r.Senha)
            .NotEmpty()
            .WithMessage("Por favor, informe a senha");

        RuleFor(r => r.ConfirmarSenha)
            .NotEmpty()
            .WithMessage("Por favor, informe a confirmação de senha");

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Por favor, informe seu e-mail");        
    }
}