using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Clientes;

public partial class ClienteService
{
    public async Task<ResponseDto<None>> DeleteClienteAsync(FindOneRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(DeleteClienteAsync));
        var cliente = await _repositoryCliente.GetByOneAsync(q => q.Id == request.IdCliente, cancellationToken);

        if (cliente == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);
        
        var endereco = await _repositoryEndereco.Query.Where(e => e.ClienteId == cliente.Id).FirstOrDefaultAsync();

        if (endereco != null)
        {
            await _repositoryEndereco.DeleteAsync(endereco, cancellationToken);
            await _repositoryEndereco.SaveChangeAsync(cancellationToken);   
        }
        
        await _repositoryCliente.DeleteAsync(cliente, cancellationToken);
        await _repositoryCliente.SaveChangeAsync(cancellationToken);
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(DeleteClienteAsync));
        return ResponseDto<None>.Sucess("Empresa deletada com sucesso", HttpStatusCode.NoContent);
    }
}