using FluentValidation;
using MicroErp.Application.Bases;

namespace MicroErp.Application.EmpresaCase.AddEmpresa;

public class AddEmpresaValidator: RequestValidator<AddEmpresaRequest>
{
    public AddEmpresaValidator()
    {
        RuleFor(r => r.Nome)
            .NotEmpty()
            .WithMessage("Por favor, informe o nome ");
        RuleFor(r => r.Cnpj)
            .NotEmpty()
            .WithMessage("Por favor, informe o CNPJ ");
    }
}