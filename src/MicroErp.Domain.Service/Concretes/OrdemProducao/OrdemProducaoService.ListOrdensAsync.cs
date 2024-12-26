using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial class OrdemProducaoService
{
    public async Task<ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>> ListOrdensAsync(ListOrdensProducaoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListOrdensAsync));
        try
        {
            var ordens = await _repositoryOrdemProducao.GetByAsync(cancellationToken);
            var metaData = new MetaDataResponse();

            List<ListOrdensProducaoResponseDto> list = new List<ListOrdensProducaoResponseDto>();

            foreach (var ordem in ordens)
            {
                var cliente = await _repositoryCliente.GetByIdAsync(ordem.IdCliente, cancellationToken);
                var detalhes = await _repositoryDetalhesOrdemProducao.GetByAsync(d => d.IdOrdemProducao == ordem.Id, cancellationToken);

                var itensDesc = new List<ItensDesc>();
                foreach (var detalhe in detalhes)
                {
                    itensDesc.Add(new ItensDesc
                    {
                        Id = detalhe.Id,
                        Descricao = detalhe.Descricao,
                        Quantidade = detalhe.Quantidade,
                        Status = detalhe.Status ?? 0
                    });
                }

                long numeroOs = 0;
                if (!string.IsNullOrEmpty(ordem.IdOrdemServico))
                {
                    var os = await _repositoryOrdemServico.GetByIdAsync(ordem.IdOrdemServico, cancellationToken);
                    numeroOs = os.NumeroOS;
                }
                
                list.Add(new ListOrdensProducaoResponseDto
                {
                    NumeroOp = ordem.NumeroOp,
                    IdOrdemProducao = ordem.Id,
                    IdCliente = ordem.IdCliente,
                    Cliente = cliente.Nome,
                    Itens = detalhes.Count(),
                    Status = ordem.Status,
                    NumeroOs = numeroOs,
                    ItensDesc = itensDesc,
                });
            }

            if (!string.IsNullOrEmpty(request.IdCliente))
            {
                list = list.Where(o => o.IdCliente == request.IdCliente).ToList();
            }

            if (request.Status != 0)
            {
                list = list.Where(o => o.Status == request.Status).ToList();
            }
            
            metaData.PageSize = request.MetaData.PageSize;
            metaData.PageNumber = request.MetaData.PageNumber;
            metaData.TotalRecords = ordens.Count();
            metaData.TotalPages = (ordens.Count() / request.MetaData.PageSize);
           
            if (list.Count() != 0)
            {
                return ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>.Sucess(list.OrderByDescending(o => o.NumeroOs)
                    .Skip((request.MetaData.PageNumber - 1) * request.MetaData.PageSize)
                    .Take(request.MetaData.PageSize).ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>.Sucess(list, null, HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>.Fail(fail);
        }
        finally
        {
            _unitOfWork.CloseTransaction();
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListOrdensAsync));
        }
    }
}