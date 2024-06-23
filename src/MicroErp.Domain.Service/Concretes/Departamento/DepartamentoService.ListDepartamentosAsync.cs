using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.ListDepartamentos;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Departamento;

public partial class DepartamentoService
{
    public async Task<ResponseDto<IEnumerable<ListDepartamentosResponseDto>>> ListDepartamentosAsync(ListDepartamentosRequestDto request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListDepartamentosAsync));
        try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repository.GetPaginatedAsync(
                request.ColunmSort,
                entity,
                cancellationToken);

            var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);

            var items = new System.Collections.Generic.List<ListDepartamentosResponseDto>();

            foreach (var itm in result.Items)
            {
                items.Add(new ListDepartamentosResponseDto
                {
                    IdDepartamento = itm.Id,
                    Descricao = itm.Descricao,
                    Responsavel = itm.Responsavel,
                    CentroCusto = itm.CentroCusto,
                    Status = itm.Status
                });
            }

            metaData.TotalRecords = items.Count;

            if (!string.IsNullOrEmpty(request.IdDepartamento))
            {
                items = items.Where(d => d.IdDepartamento == request.IdDepartamento).ToList();
                metaData.TotalRecords = items.Count;
            }
            if (!string.IsNullOrEmpty(request.Responsavel))
            {
                items = items.Where(d => d.Responsavel.Contains(request.IdDepartamento)).ToList();
                metaData.TotalRecords = items.Count;
            }

            logger.LogInformation("Metodo finalizado:{0}", nameof(ListDepartamentosAsync));

            if (!items.Any())
            {
                return ResponseDto<IEnumerable<ListDepartamentosResponseDto>>.Sucess(items.ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListDepartamentosResponseDto>>.Sucess(items.ToList(), metaData, HttpStatusCode.OK);
            }
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListDepartamentosResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListDepartamentosAsync));
        }
    }
}