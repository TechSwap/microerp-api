using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService
{
    public async Task<ResponseDto<IEnumerable<ListFornecedoresResponseDto>>> ListFornecedoresAsync(ListFornecedoresRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListFornecedoresAsync));
        var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
        var result = await _repositoryFornecedor.GetPaginatedAsync(
            request.ColunmSort,
            entity,
            cancellationToken);
        
        var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);

        var items = new List<ListFornecedoresResponseDto>();

        foreach (var itm in result.Items)
        {
            items.Add(new ListFornecedoresResponseDto
            {
                IdFornecedor = itm.Id,
                Nome = itm.Nome,
                CNPJ = Formatting.FormatCNPJ(itm.Cnpj),
                Contato1= itm.Contato1,
                Email = itm.Email,
                Ativo= itm.Ativo   
            });
        }

        if (!string.IsNullOrEmpty(request.Nome))
        {
            items = items.Where(c => c.Nome == request.Nome).ToList();
        }
        if (!string.IsNullOrEmpty(request.Cnpj))
        {                                         
            items = items.Where(c => c.CNPJ == request.Cnpj).ToList();                              
        }      
        if (!string.IsNullOrEmpty(request.Email))
        {
            items = items.Where(c => c.Email == request.Email).ToList();
        }
        //if (requestDto.Ativo)
        //{                                              
        //    items = items.Where(c => c.Ativo == requestDto.Ativo).ToList();                                   
        //}           
        
        metaData.TotalRecords = items.Count;   
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(ListFornecedoresAsync));

        if (!items.Any())
        {
            return ResponseDto<IEnumerable<ListFornecedoresResponseDto>>.Sucess(items.ToList(), metaData);
        }
        else
        {
            return ResponseDto<IEnumerable<ListFornecedoresResponseDto>>.Sucess(items.ToList(), metaData, HttpStatusCode.OK);
        }
    }
}