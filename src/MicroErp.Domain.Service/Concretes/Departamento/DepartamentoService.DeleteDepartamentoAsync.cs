using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Departamento;

public partial class DepartamentoService
{
    public async Task<ResponseDto<None>> DeleteDepartamentoAsync(FindOneDepartamentoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneDepartamentoAsync));
        try
        {
            var departamento = await _repository.GetByOneAsync(q => q.Id == request.IdDepartamento, cancellationToken);

            await _repository.DeleteAsync(departamento, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto<None>.Sucess("Departamento deletado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<None>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneDepartamentoAsync));
        }
    } 
}