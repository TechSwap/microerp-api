using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService
{
    public async Task<ResponseDto<None>> ActiveFornecedorAsync(FindOneRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ActiveFornecedorAsync));
        var fornecedor = await _repositoryFornecedor.GetByOneAsync(q => q.Id == request.IdFornecedor, cancellationToken);

        if (fornecedor == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        fornecedor.Ativo = !fornecedor.Ativo;

        await _repositoryFornecedor.UpdateAsync(fornecedor, cancellationToken,
            c => c.Ativo);
        
        await _repositoryFornecedor.SaveChangeAsync(cancellationToken);
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(ActiveFornecedorAsync));
        return ResponseDto<None>.Sucess("Empresa atualizado com sucesso", HttpStatusCode.NoContent);
        
    }
}