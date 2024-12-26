using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Enums;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<None>> DeleteDetailOrdemAsync(DetatlheOrdemServicoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneOrdemAsync));
        try
        {
            var detail = await _repositoryDetalhesOrdemServico.GetByIdAsync(request.IdDetalhesOrdemServico, cancellationToken);
            
            if (detail == null)
            {
                return ResponseDto.Fail("Detalhe nao encontrado", HttpStatusCode.BadRequest);
            }
            
            if (detail.Status != (int)StatusOP.Aberta)
            {
                return ResponseDto.Fail("Item ja iniciada a producao.", HttpStatusCode.BadRequest);
            }

            var ordem = await _repositoryOrdemServico.GetByIdAsync(detail.OrdemServicoId, cancellationToken);
           

            await _repositoryDetalhesOrdemServico.DeleteAsync(detail, cancellationToken);
            await _repositoryDetalhesOrdemServico.SaveChangeAsync(cancellationToken);
            return ResponseDto.Sucess(HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneOrdemAsync));
        }
    }
}