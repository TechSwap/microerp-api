using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
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
            var result = await _repositoryOrdemServico.GetPaginatedAsync(
                request.ColunmSort,
                entity,
                cancellationToken,
                o => o.DetalhesOrdemServico);
            
            var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);

            var ordens = new List<ListOrdensResponseDto>();

            foreach (var itm in result.Items)
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
                    DataLancamento = itm.DataCadastro,
                    DataPrevisaoEntrega = (DateTime)itm.DataPrevisaoEntrega
                };
                
                ordens.Add(ordem);
            }
            
            metaData.TotalRecords = await _repositoryOrdemServico.Query.Where(c => c.Id != null).CountAsync();

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
                return ResponseDto<IEnumerable<ListOrdensResponseDto>>.Sucess(ordens.OrderByDescending(o => o.NumeroOS).ToList(), metaData);
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