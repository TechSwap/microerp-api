using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.UpdateDepartamento;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Departamento;

public partial class DepartamentoService
{
    public async Task<ResponseDto<None>> UpdateDepartamentoAsync(UpdateDepartamentoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateDepartamentoAsync));
        try
        {
            var departamento = await _repository.GetByOneAsync(d => d.Id == request.IdDepartamento, cancellationToken);

            departamento.Descricao = request.Descricao;
            departamento.Responsavel = request.Responsavel;
            departamento.CentroCusto = request.CentroCusto;
            departamento.Status = departamento.Status;

            await _repository.UpdateAsync(departamento, cancellationToken,
                d => d.Descricao,
                d => d.Responsavel,
                d => d.CentroCusto,
                d => d.Status);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Departamento atualizado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateDepartamentoAsync));
        }
    } 
}