using System.Net;
using MicroErp.Domain.Entity.Funcionarios;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.UpdateFuncionario;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService
{
    public async Task<ResponseDto<None>> UpdateFuncionarioAsync(UpdateFuncionarioRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateFuncionarioAsync));
        try
        {
            var funcionario = await _repository.GetByOneAsync(f => f.Id == request.IdFuncionario, cancellationToken);

            if (funcionario == null)
            {
                return ResponseDto<None>.Fail(HttpStatusCode.NotFound);
            }

            funcionario.Nome = request.Nome;
            funcionario.DepartamentoId = request.DepartamentoId;
            funcionario.CentroCusto = request.CentroCusto;
            funcionario.Funcao = request.Funcao;
            funcionario.ValorHora = request.ValorHora;
            funcionario.DataAtualizacao = DateTime.Now;
            
            await _repository.UpdateAsync(funcionario, cancellationToken,
            f => f.Nome,
                f => f.DepartamentoId,
                f => f.CentroCusto,
                f => f.Funcao,
                f => f.ValorHora,
                f => f.DataAtualizacao);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto<None>.Sucess("Atualizado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateFuncionarioAsync));
        }
    }
}