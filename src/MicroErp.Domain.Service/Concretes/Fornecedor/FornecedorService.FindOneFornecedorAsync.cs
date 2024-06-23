using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService
{
    public async Task<ResponseDto<FindOneResponseDto>> FindOneFornecedorAsync(FindOneRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneFornecedorAsync));
        var fornecedor = await _repositoryFornecedor.GetByOneAsync(q => q.Id == request.IdFornecedor, cancellationToken);

        if (fornecedor == null)
            return ResponseDto<FindOneResponseDto>.Fail(HttpStatusCode.NotFound);

        var endereco = await _repositoryEndereco.Query.Where(e => e.FornecedorId == fornecedor.Id).FirstOrDefaultAsync();

        var data = new FindOneResponseDto
        {
            IdFornecedor  = fornecedor.Id,
            Nome  = fornecedor.Nome,
            Cnpj  = Formatting.FormatCNPJ(fornecedor.Cnpj),
            InscricaoEstadual  = fornecedor.InscricaoEstadual,
            Fantasia = fornecedor.Fantasia,
            Contato1  = fornecedor.Contato1,
            Contato2  = fornecedor.Contato2,
            Email  = fornecedor.Email,
            Responsavel = fornecedor.Responsavel,
            Ativo  = fornecedor.Ativo,
            EnderecoId  = endereco != null ? endereco.Id : string.Empty,
            Cep  = endereco != null ? endereco.Cep : string.Empty,
            Logradouro  = endereco != null ? endereco.Logradouro : string.Empty,
            Numero  = endereco != null ? endereco.Numero : string.Empty,
            Bairro  = endereco != null ? endereco.Bairro : string.Empty,
            Cidade  = endereco != null ? endereco.Cidade : string.Empty,
            Estado  = endereco != null ? endereco.Estado : string.Empty,
        };
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneFornecedorAsync));
        return ResponseDto<FindOneResponseDto>.Sucess(data);
        
    }
}