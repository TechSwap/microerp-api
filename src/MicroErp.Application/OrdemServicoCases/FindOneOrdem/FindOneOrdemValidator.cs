using FluentValidation;
using MicroErp.Application.Bases;

namespace MicroErp.Application.OrdemServicoCases.FindOneOrdem;

public class FindOneOrdemValidator: RequestValidator<FindOneOrdemRequest>
{
    public FindOneOrdemValidator()
    {
        RuleFor(r => r.IdOrdemServico)
            .NotEmpty()
            .WithMessage("Por favor, informe a Ordem de Servico");
    }
}