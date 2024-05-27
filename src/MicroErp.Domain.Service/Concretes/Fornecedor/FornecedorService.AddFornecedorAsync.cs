using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Entity.Fornecedores;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService
{
    public async Task<ResponseDto<None>> AddFornecedorAsync(AddEmpresaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddFornecedorAsync));
        try
        {
            var existEmpresa = await _repositoryFornecedor.Query.Where(e => e.Cnpj == Formatting.RemoverCaracteresEspeciaisCNPJ(request.Cnpj)).FirstOrDefaultAsync();

            if (existEmpresa != null)
            {
                return ResponseDto<None>.Fail("Empresa já esta cadastrada como cliente.", HttpStatusCode.BadRequest);
            }

            var empresa = new Entity.Fornecedores.Fornecedor
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Nome = request.Nome,
                Cnpj = Formatting.RemoverCaracteresEspeciaisCNPJ(request.Cnpj),
                InscricaoEstadual = string.IsNullOrEmpty(request.InscricaoEstadual) ? null : Formatting.RemoverPontosIE(request.InscricaoEstadual),
                Contato1 = string.IsNullOrEmpty(request.Contato1) ? null : Formatting.FormatarTelefone(request.Contato1),
                Contato2 = string.IsNullOrEmpty(request.Contato2) ? null : Formatting.FormatarTelefone(request.Contato2),
                Email = request.Email,
                DataCadastro = DateTime.Now,
                Ativo = true
            };

            await _repositoryFornecedor.InsertAsync(empresa, cancellationToken);
            await _repositoryFornecedor.SaveChangeAsync(cancellationToken);

            if (!string.IsNullOrEmpty(request.Cep))
            {
                var endereco = new Endereco
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Cep = string.IsNullOrEmpty(request.Cep) ? null : request.Cep,
                    Logradouro = string.IsNullOrEmpty(request.Logradouro) ? null : request.Logradouro,
                    Numero = string.IsNullOrEmpty(request.Numero) ? null : request.Numero,
                    Bairro = string.IsNullOrEmpty(request.Bairro) ? null : request.Bairro,
                    Cidade = string.IsNullOrEmpty(request.Cidade) ? null : request.Cidade,
                    Estado = string.IsNullOrEmpty(request.Estado) ? null : request.Estado,
                    FornecedorId = request.IsFornecedor.Equals(true) ? empresa.Id : null,
                    ClienteId = request.IsCliente.Equals(true) ? empresa.Id : null,
                    DataCadastro = DateTime.Now
                };
                await _repositoryEndereco.InsertAsync(endereco, cancellationToken);
                await _repositoryEndereco.SaveChangeAsync(cancellationToken);
            }

            return ResponseDto.Sucess("Empresa cadastrada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddFornecedorAsync));
        }
    }
}
