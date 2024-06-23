using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.UpdateFornecedor;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService
{
    public async Task<ResponseDto<None>> UpdateFornecedorAsync(UpdateFornecedorRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateFornecedorAsync));

            var fornecedor = await _repositoryFornecedor.Query.Where(c => c.Id == request.IdFornecedor).FirstOrDefaultAsync();

            fornecedor.Nome = request.Nome;
            fornecedor.Cnpj = Formatting.RemoverCaracteresEspeciaisCNPJ(request.Cnpj);
            fornecedor.Fantasia = request.Fantasia;
            fornecedor.InscricaoEstadual = request.InscricaoEstadual;
            fornecedor.Contato1 = request.Contato1;
            fornecedor.Contato2 = request.Contato2;
            fornecedor.Responsavel = request.Responsavel;
            fornecedor.Email = request.Email;

            await _repositoryFornecedor.UpdateAsync(fornecedor, cancellationToken,
                c => c.Nome,
                c => c.Fantasia,
                c => c.Cnpj,
                c => c.InscricaoEstadual,
                c => c.Contato1,
                c => c.Contato2,
                c => c.Responsavel,
                c => c.Email);

            await _repositoryFornecedor.SaveChangeAsync(cancellationToken);

            var endereco = await _repositoryEndereco.GetByOneAsync(e => e.FornecedorId == fornecedor.Id, cancellationToken);

            endereco.Cep = request.Cep;
            endereco.Logradouro = request.Endereco;
            endereco.Numero = request.Numero;
            endereco.Bairro = request.Bairro;
            endereco.Cidade = request.Cidade;
            endereco.Estado = request.Estado;

            await _repositoryEndereco.UpdateAsync(endereco, cancellationToken,
                e => e.Cep,
                e => e .Logradouro,
                e => e.Numero,
                e => e.Bairro,
                e => e.Cidade,
                e => e.Estado);
            await _repositoryEndereco.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Atualizado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateFornecedorAsync));
        }
    }
}