using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Clientes;

public partial class ClienteService
{
    public async Task<ResponseDto<None>> ActiveClienteAsync(FindOneRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ActiveClienteAsync));
        var cliente = await _repositoryCliente.GetByOneAsync(q => q.Id == request.IdCliente, cancellationToken);

        if (cliente == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        cliente.Ativo = !cliente.Ativo;

        await _repositoryCliente.UpdateAsync(cliente, cancellationToken,
            c => c.Ativo);
        
        await _repositoryCliente.SaveChangeAsync(cancellationToken);
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(ActiveClienteAsync));
        return ResponseDto<None>.Sucess("Empresa atualizado com sucesso", HttpStatusCode.NoContent);
        
    }
}