using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.AddMaquina;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService 
{
    public async Task<ResponseDto<FindOneMaquinaResponseDto>> FindOneMaquinaAsync(FindOneMaquinaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneMaquinaAsync));
        try
        {
            var maquina = await _repository.GetByIdAsync(request.IdMaquina, cancellationToken);

            var response = new FindOneMaquinaResponseDto
            {
                IdMaquina = maquina.Id,
                IdDepartamento = maquina.IdDepartamento,
                Nome = maquina.Descricao,
                NumeroSerie = maquina.NumeroSerie,
                Fabricante = maquina.Fabricante, 
                AtivoFixo = maquina.AtivoFixo,
                Vendida = maquina.Vendida,
                Status = maquina.Status
            };
            
            return ResponseDto<FindOneMaquinaResponseDto>.Sucess(response);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<FindOneMaquinaResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneMaquinaAsync));
        }
    }
}