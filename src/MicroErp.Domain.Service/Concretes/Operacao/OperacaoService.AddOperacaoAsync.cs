using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.AddOperacao;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Operacao;

public partial class OperacaoService
{
    public async Task<ResponseDto<None>> AddOperacaoAsync(AddOperacaoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddOperacaoAsync));
        try
        {
            var existOp = await _repository.GetByAsync(o => o.Descricao == request.Descricao, cancellationToken);

            if (existOp.Count() > 0)
            {
                return ResponseDto<None>.Fail(HttpStatusCode.NotFound);
            }

            var departamento = await _repositoryDepartamento.GetByIdAsync(request.IdDepartamento, cancellationToken);

            var operacao = new Entity.Operacoes.Operacao
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                IdDepartamento = departamento.Id,
                Descricao = request.Descricao,
                Ativo = true,
                DataCadastro = DateTime.Now.AddHours(-3)
            };

            await _repository.InsertAsync(operacao, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Operacao gerada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddOperacaoAsync));
        }
    }
}