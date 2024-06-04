using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Departamento;

public partial class DepartamentoService
{
    public async Task<ResponseDto<None>> ActiveDepartamentoAsync(FindOneDepartamentoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneDepartamentoAsync));
        try
        {
            var entity = await _repository.GetByOneAsync(q => q.Id == request.IdDepartamento, cancellationToken);

            if (entity == null)
            {
                return ResponseDto<None>.Fail(HttpStatusCode.NotFound);
            }

            entity.Status = !entity.Status;

            await _repository.UpdateAsync(entity, cancellationToken,
                c => c.Status);
        
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto<None>.Sucess("Empresa atualizado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
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