using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.UpdateEmpresa;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Clientes;

public partial class ClienteService
{
    public async Task<ResponseDto<None>> UpdateClienteAsync(UpdateEmpresaRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateClienteAsync));

            var cliente = await _repositoryCliente.Query.Where(c => c.Id == request.IdCliente).FirstOrDefaultAsync();

            cliente.Nome = request.Nome;
            cliente.Cnpj = Formatting.RemoverCaracteresEspeciaisCNPJ(request.Cnpj);
            cliente.Fantasia = request.Fantasia;
            cliente.Responsavel = request.Responsavel;
            cliente.InscricaoEstadual = request.InscricaoEstadual;
            cliente.Contato1 = request.Contato1;
            cliente.Contato2 = request.Contato2;
            cliente.Email = request.Email;
            cliente.DataAtualizacao = DateTime.Now;

            await _repositoryCliente.UpdateAsync(cliente, cancellationToken,
                c => c.Nome,
                c => c.Cnpj,
                c => c.InscricaoEstadual,
                c => c.Contato1,
                c => c.Contato2,
                c => c.Email,
                c => c.DataAtualizacao);

            await _repositoryCliente.SaveChangeAsync(cancellationToken);

            var endereco = await _repositoryEndereco.GetByOneAsync(e => e.ClienteId == cliente.Id, cancellationToken);

            endereco.Cep = request.Cep;
            endereco.Logradouro = request.Logradouro;
            endereco.Numero = request.Numero;
            endereco.Bairro = request.Bairro;
            endereco.Cidade = request.Cidade;
            endereco.Estado = request.Estado;
            endereco.Complemento = request.Complemento;

            await _repositoryEndereco.UpdateAsync(endereco, cancellationToken,
                e => e.Cep,
                e => e .Logradouro,
                e => e.Numero,
                e => e.Bairro,
                e => e.Cidade,
                e => e.Estado,
                e => e.Complemento);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateClienteAsync));
        }
    }
}