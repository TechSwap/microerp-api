using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Operacao;

public partial class OperacaoService
{
    public async Task<ResponseDto<IEnumerable<ListOperacoesResponseDto>>> ListOperacoesAsync(ListOperacoesRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListOperacoesAsync));
        try
        {
            var operacoes = await _repository.GetByAsync(cancellationToken);
            var metaData = new MetaDataResponse();

            var listOperacoes = new List<ListOperacoesResponseDto>();

            foreach (var operacao in operacoes)
            {
                var departamento = await _repositoryDepartamento.GetByIdAsync(operacao.IdDepartamento, cancellationToken);

                var itn = new ListOperacoesResponseDto
                {
                    IdOperacao = operacao.Id,
                    Descricao = operacao.Descricao,
                    IdDepartamento = departamento.Id,
                    Departamento = departamento.Descricao,
                    Responsavel = departamento.Responsavel,
                    Status = operacao.Ativo
                };
                
                listOperacoes.Add(itn);
            }

            if (!string.IsNullOrWhiteSpace(request.IdDepartamento))
            {
                listOperacoes = listOperacoes.Where(o => o.IdDepartamento == request.IdDepartamento).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Responsavel))
            {
                listOperacoes = listOperacoes.Where(o => o.Responsavel.Contains(request.Responsavel)).ToList();
            }
            
            metaData.PageSize = request.MetaData.PageSize;
            metaData.PageNumber = request.MetaData.PageNumber;
            metaData.TotalRecords = listOperacoes.Count();
            metaData.TotalPages = (listOperacoes.Count() / request.MetaData.PageSize);
            
            if (listOperacoes.Count() != 0)
            {
                return ResponseDto<IEnumerable<ListOperacoesResponseDto>>.Sucess(listOperacoes.OrderBy(o => o.Departamento)
                    .Skip((request.MetaData.PageNumber - 1) * request.MetaData.PageSize)
                    .Take(request.MetaData.PageSize).ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListOperacoesResponseDto>>.Sucess(listOperacoes, null, HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListOperacoesResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListOperacoesAsync));
        }
    }
}