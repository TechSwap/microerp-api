using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService
{
    public async Task<ResponseDto<IEnumerable<ListMaquinasResponseDto>>> ListMaquinasAsync(ListMaquinasRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListMaquinasAsync));
        try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repository.GetPaginatedAsync(
                request.ColunmSort,
                entity,
                cancellationToken);
            
            var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);

            var maquinas = new List<ListMaquinasResponseDto>();

            foreach (var itn in result.Items)
            {
                maquinas.Add(
                    new ListMaquinasResponseDto
                    {
                        IdMaquina = itn.Id,
                        NumeroSerie = itn.NumeroSerie,
                        Descricao = itn.Descricao,
                        Fabricante = itn.Fabricante,
                        IdDepartamento = itn.IdDepartamento,
                        Status  = itn.Status,
                        Vendida = (bool)itn.Vendida 
                    });
            }

            if (!string.IsNullOrEmpty(request.IdDepartamento))
            {
                maquinas = maquinas.Where(m => m.IdDepartamento == request.IdDepartamento).ToList();
            }

            if (!string.IsNullOrEmpty(request.Fabricante))
            {
                maquinas = maquinas.Where(m => m.Fabricante.Contains(request.Fabricante)).ToList();
            }

            if (!string.IsNullOrEmpty(request.NumeroSerie))
            {
                maquinas = maquinas.Where(m => m.NumeroSerie.Contains(request.NumeroSerie)).ToList();
            }
            
            metaData.PageSize = request.MetaData.PageSize;
            metaData.PageNumber = request.MetaData.PageNumber;
            metaData.TotalRecords = maquinas.Count;
            metaData.TotalPages = (maquinas.Count / request.MetaData.PageSize);
            
            if (maquinas.Count != 0)
            {
                return ResponseDto<IEnumerable<ListMaquinasResponseDto>>.Sucess(maquinas.Skip((request.MetaData.PageNumber - 1) * request.MetaData.PageSize).Take(request.MetaData.PageSize).ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListMaquinasResponseDto>>.Fail("Nenhum Registro Encontrado", HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListMaquinasResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListMaquinasAsync));
        }
    }
}