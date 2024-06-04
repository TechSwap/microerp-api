using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;
using MicroErp.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Clientes;

public partial class ClienteService
{
    public async Task<ResponseDto<IEnumerable<ListClientesResponseDto>>> ListClientesAsync(ListClientesRequestDto requestDto, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListClientesAsync));
        var entity = _mapper.Map<PaginatedMetaDataEntity>(requestDto);
        var result = await _repositoryCliente.GetPaginatedAsync(
            requestDto.ColunmSort,
            entity,
            cancellationToken);
        
        var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);

        var items = new System.Collections.Generic.List<ListClientesResponseDto>();

        foreach (var itm in result.Items)
        {
            items.Add(new ListClientesResponseDto
            {
                IdCliente = itm.Id,
                Nome = itm.Nome,
                CNPJ = Formatting.FormatCNPJ(itm.Cnpj),
                Fantasia = itm.Fantasia,
                Contato1= itm.Responsavel,
                Email = itm.Email,
                Ativo= itm.Ativo   
            });
        }
        
        metaData.TotalRecords = await _repositoryCliente.Query.Where(c => c.Id != null).CountAsync();  

        if (!string.IsNullOrEmpty(requestDto.IdCliente))
        {
            items = items.Where(c => c.IdCliente == requestDto.IdCliente).ToList();
            metaData.TotalRecords = items.Count;
        }
        if (!string.IsNullOrEmpty(requestDto.Cnpj))
        {                                         
            items = items.Where(c => c.CNPJ.Contains(Formatting.FormatCNPJ(requestDto.Cnpj))).ToList();     
            metaData.TotalRecords = items.Count;
        }      
        if (!string.IsNullOrEmpty(requestDto.Responsavel))
        {
            items = items.Where(c => c.Contato1 == requestDto.Responsavel).ToList();
            metaData.TotalRecords = items.Count;
        }
        if (!string.IsNullOrEmpty(requestDto.Email))
        {
            items = items.Where(c => c.Email == requestDto.Email).ToList();
            metaData.TotalRecords = items.Count;
        }
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(ListClientesAsync));

        if (!items.Any())
        {
            return ResponseDto<IEnumerable<ListClientesResponseDto>>.Sucess(items.ToList(), metaData);
        }
        else
        {
            return ResponseDto<IEnumerable<ListClientesResponseDto>>.Sucess(items.ToList(), metaData, HttpStatusCode.OK);
        }
    }
}