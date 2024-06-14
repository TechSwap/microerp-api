using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService
{
    public async Task<ResponseDto<None>> DeleteFuncionarioAsync(FindOneFuncionarioRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(DeleteFuncionarioAsync));
        var funcionario = await _repository.GetByOneAsync(q => q.Id == request.IdFuncionario, cancellationToken);

        if (funcionario == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        funcionario.Ativo = false;

        await _repository.UpdateAsync(funcionario, cancellationToken,
            c => c.Ativo);
        
        await _repository.SaveChangeAsync(cancellationToken);
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(DeleteFuncionarioAsync));
        return ResponseDto<None>.Sucess("Excluido com sucesso", HttpStatusCode.NoContent);
    }
}