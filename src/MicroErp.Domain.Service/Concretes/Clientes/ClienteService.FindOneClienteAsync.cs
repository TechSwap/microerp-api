using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Clientes;

public partial class ClienteService
{
    public async Task<ResponseDto<FindOneResponseDto>> FindOneClienteAsync(FindOneRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneClienteAsync));
        var cliente = await _repositoryCliente.GetByOneAsync(q => q.Id == request.IdCliente, cancellationToken);

        if (cliente == null)
            return ResponseDto<FindOneResponseDto>.Fail(HttpStatusCode.NotFound);

        var endereco = await _repositoryEndereco.Query.Where(e => e.ClienteId == cliente.Id).FirstOrDefaultAsync();

        var data = new FindOneResponseDto
        {
            IdCliente  = cliente.Id,
            Nome  = cliente.Nome,
            Cnpj  = Formatting.FormatCNPJ(cliente.Cnpj),
            Fantasia = cliente.Fantasia,
            Responsavel = cliente.Responsavel,
            InscricaoEstadual  = cliente.InscricaoEstadual,
            Contato1  = cliente.Contato1,
            Contato2  = cliente.Contato2,
            Email  = cliente.Email,
            Ativo  = cliente.Ativo,
            EnderecoId  = endereco != null ? endereco.Id : string.Empty,
            Cep  = endereco != null ? endereco.Cep : string.Empty,
            Logradouro  = endereco != null ? endereco.Logradouro : string.Empty,
            Numero  = endereco != null ? endereco.Numero : string.Empty,
            Bairro  = endereco != null ? endereco.Bairro : string.Empty,
            Cidade  = endereco != null ? endereco.Cidade : string.Empty,
            Estado  = endereco != null ? endereco.Estado : string.Empty,
            Complemento = endereco != null ? endereco.Complemento : string.Empty
        };
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneClienteAsync));
        return ResponseDto<FindOneResponseDto>.Sucess(data);
        
    }
}