using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService
{
    public async Task<ResponseDto<None>> DeleteFornecedorAsync(FindOneRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(DeleteFornecedorAsync));
        var fornecedor = await _repositoryFornecedor.GetByOneAsync(q => q.Id == request.IdFornecedor, cancellationToken);

        if (fornecedor == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);
        
        var endereco = await _repositoryEndereco.Query.Where(e => e.FornecedorId == fornecedor.Id).FirstOrDefaultAsync();

        if (endereco != null)
        {
            await _repositoryEndereco.DeleteAsync(endereco, cancellationToken);
            await _repositoryEndereco.SaveChangeAsync(cancellationToken);   
        }
        
        await _repositoryFornecedor.DeleteAsync(fornecedor, cancellationToken);
        await _repositoryFornecedor.SaveChangeAsync(cancellationToken);
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(DeleteFornecedorAsync));
        return ResponseDto<None>.Sucess("Empresa deletada com sucesso", HttpStatusCode.NoContent);
    }
}