using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<IEnumerable<ListOrdensResponseDto>>> ListOrdensAsync(ListOrdensRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListOrdensAsync));
        try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repositoryOrdemServico.GetByAsync(cancellationToken,
                o => o.DetalhesOrdemServico);
            
            var metaData = new MetaDataResponse();

            var ordens = new List<ListOrdensResponseDto>();

            foreach (var itm in result.OrderByDescending(i => i.NumeroOS))
            {
                var itemsOrdem = itm.DetalhesOrdemServico.Count;
                var cliente = await _repositoryCliente.GetByOneAsync(c => c.Id == itm.IdCliente, cancellationToken);

                var ordem = new ListOrdensResponseDto
                {
                    IdOrdemServico = itm.Id,
                    NumeroOS = itm.NumeroOS,
                    IdCliente = itm.IdCliente,
                    Cliente = cliente.Nome,
                    Solicitante = itm.Solicitante,
                    NotaSaida = itm.NotaSaida,
                    ValorTotal = (decimal)itm.ValorTotal,
                    Itens = itemsOrdem,
                    DataLancamento = (DateTime)itm.DataCadastro,
                    DataPrevisaoEntrega = (DateTime)itm.DataPrevisaoEntrega,
                    Status = itm.Status == null ? 0 :itm.Status
                };
                
                ordens.Add(ordem);
            }

            metaData.PageSize = request.MetaData.PageSize;
            metaData.PageNumber = request.MetaData.PageNumber;
            metaData.TotalRecords = ordens.Count;
            metaData.TotalPages = (ordens.Count / request.MetaData.PageSize);
           

            if (!string.IsNullOrEmpty(request.IdCliente))
            {
                ordens = ordens.Where(o => o.IdCliente == request.IdCliente).ToList();
                metaData.TotalRecords = ordens.Count;
            }

            if (!string.IsNullOrEmpty(request.DataLancamento.ToString()))
            {
                ordens = ordens.Where(o => o.DataLancamento.Date == request.DataLancamento).ToList();
                metaData.TotalRecords = ordens.Count;
            }
            
            if (!string.IsNullOrEmpty(request.Solicitante))
            {
                ordens = ordens.Where(o => o.Solicitante.Contains(request.Solicitante)).ToList();
                metaData.TotalRecords = ordens.Count;
            }

            if (ordens.Count != 0)
            {
                return ResponseDto<IEnumerable<ListOrdensResponseDto>>.Sucess(ordens.Skip((request.MetaData.PageNumber - 1) * request.MetaData.PageSize).Take(request.MetaData.PageSize).ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListOrdensResponseDto>>.Fail("Nenhum Registro Encontrado", HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListOrdensResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListOrdensAsync));
        }
    }
}