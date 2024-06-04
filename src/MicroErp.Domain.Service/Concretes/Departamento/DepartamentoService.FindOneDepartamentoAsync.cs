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
    public async Task<ResponseDto<FindOneDepartamentoResponseDto>> FindOneDepartamentoAsync(FindOneDepartamentoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneDepartamentoAsync));
        try
        {
            
            var entity = await _repository.GetByOneAsync(q => q.Id == request.IdDepartamento, cancellationToken);

            if (entity == null)
            {
                return ResponseDto<FindOneDepartamentoResponseDto>.Fail(HttpStatusCode.NotFound);
            }

            var data = new FindOneDepartamentoResponseDto
            {
                IdDepartamento = entity.Id,
                Descricao = entity.Descricao,
                Responsavel = entity.Responsavel,
                CentroCusto = entity.CentroCusto,
                Status = entity.Status,
                DataCadastro = entity.DataCadastro
            };
            
            return ResponseDto<FindOneDepartamentoResponseDto>.Sucess(data);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<FindOneDepartamentoResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneDepartamentoAsync));
        }
    } }