using System.Net;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<None>> UpdateStatusDetailOrdemAsync(string idDetalheOrdemServico,int status, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateStatusDetailOrdemAsync));
        try
        {
            var detail = await _repositoryDetalhesOrdemServico.GetByIdAsync(idDetalheOrdemServico, cancellationToken);

            detail.Status = status;
           
            await _repositoryDetalhesOrdemServico.UpdateAsync(detail, cancellationToken,
                o => o.Status);
            await _repositoryDetalhesOrdemServico.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Status atualizado com sucesso", HttpStatusCode.OK);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateStatusDetailOrdemAsync));
        }
    }
}