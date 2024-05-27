using MicroErp.Domain.Entity.Empresas;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MicroErp.Domain.Service.Concretes.Empresas;

public partial class EmpresaService
{
    public async Task<ResponseDto<None>> AddEmpresaAsync(AddEmpresaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddEmpresaAsync));
        try
        {
            _unitOfWork.OpenTransaction();
            var existEmpresa = await _repository.Query.Where(e => e.Cnpj == request.Cnpj).FirstOrDefaultAsync();

            if (existEmpresa != null)
            {
                return ResponseDto<None>.Fail("Empresa já esta cadastrada como cliente.", HttpStatusCode.BadRequest);
            }

            var empresa = new Empresa
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

            if (request.IsCliente.Equals(true))
            {
                await _repositoryCliente.InsertAsync(empresa, cancellationToken);
            }
            else 
            if (request.IsCliente.Equals(true))
            {
                await _repositoryFornecedor.InsertAsync(empresa, cancellationToken);
            }

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
            }
            _unitOfWork.Commit();

            return ResponseDto.Sucess("Empresa cadastrada com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddEmpresaAsync));
        }



    }
}