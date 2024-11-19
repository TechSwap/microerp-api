using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.AddMaquina;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService 
{
    public async Task<ResponseDto<None>> AddMaquinaAsync(AddMaquinaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddMaquinaAsync));
        try
        {
            var existMaquina = await _repository.GetByOneAsync(m => m.NumeroSerie == request.NumeroSerie, cancellationToken);

            if (existMaquina != null)
            {
                return ResponseDto<None>.Fail("Maquina já esta cadastrada.", HttpStatusCode.BadRequest);
            }

            var maquina = new Entity.Maquinas.Maquina
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Descricao = request.Nome,
                NumeroSerie = request.NumeroSerie,
                Fabricante = request.Fabricante,
                AtivoFixo = request.AtivoFixo,
                Status = request.Status,
                Vendida = false,
                IdDepartamento = request.IdDepartamento,
                DataCadastro = DateTime.Now
            };

            await _repository.InsertAsync(maquina, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Ordem gerada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddMaquinaAsync));
        }
    }
}