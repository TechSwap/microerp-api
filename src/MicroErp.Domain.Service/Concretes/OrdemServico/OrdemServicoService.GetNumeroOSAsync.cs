using System.Net;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.GetNumeroOS;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<GetNumeroOSResponseDto>> GetNumeroOSAsync(GetNumeroOSRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(GetNumeroOSAsync));
        try
        {
            var ordens = await _repositoryOrdemServico.GetByAsync(o => o.Id != null, cancellationToken);

            var lastOrder = ordens.OrderByDescending(o => o.NumeroOS).Select(o => o.NumeroOS).FirstOrDefault();

            var result = new GetNumeroOSResponseDto
            {
                OrdemServico = lastOrder + 1
            };

            return ResponseDto<GetNumeroOSResponseDto>.Sucess(result);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<GetNumeroOSResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(GetNumeroOSAsync));
        }
    }
}