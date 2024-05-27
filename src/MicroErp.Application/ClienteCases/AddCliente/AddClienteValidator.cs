using FluentValidation;
using MicroErp.Application.Bases;

namespace MicroErp.Application.ClienteCases.AddCliente;

public class AddClienteValidator: RequestValidator<AddClienteRequest>
{
    public AddClienteValidator()
    {
        RuleFor(r => r.Nome)
            .NotEmpty()
            .WithMessage("Por favor, informe o nome ");
        RuleFor(r => r.Cnpj)
            .NotEmpty()
            .WithMessage("Por favor, informe o CNPJ");
    }
}