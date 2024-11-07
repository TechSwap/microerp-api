using System.Net;
using MicroErp.Domain.Entity.Empresas;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.UpdateEmpresa;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Empresas;

public partial class EmpresaService
{
    public async Task<ResponseDto<None>> UpdateEmpresaAsync(UpdateEmpresaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateEmpresaAsync));
        try
        {
            if (string.IsNullOrEmpty(request.EmpresaId))
            {
                var empresa = new Empresa
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    RazaoSocial = request.Nome,
                    NomeFantasia = request.Fantasia,
                    Cnpj = request.Cnpj,
                    InscricaoEstadual = request.InscricaoEstadual,
                    Responsavel = request.Responsavel,
                    Contato1 = request.Contato1,
                    Email = request.Email,
                    Logo = request.Logo,
                    TipoEmpresa = request.TipoEmpresa,
                    DataFundacao = request.DataFundacao,
                    DataCadastro = DateTime.Now
                };

                await _repository.InsertAsync(empresa, cancellationToken);
                await _repository.SaveChangeAsync(cancellationToken);

                var endereco = new Endereco
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Cep = request.Cep,
                    Logradouro = request.Logradouro,
                    Numero = request.Numero,
                    Bairro = request.Bairro,
                    Cidade = request.Cidade,
                    Estado = request.Estado,
                    Complemento = request.Complemento,
                    EmpresaId = empresa.Id,
                    DataCadastro = DateTime.Now
                };

                await _repositoryEndereco.InsertAsync(endereco, cancellationToken);
                await _repositoryEndereco.SaveChangeAsync(cancellationToken);
            }
            else
            {
                var emp = await _repository.GetByIdAsync(request.EmpresaId, cancellationToken);
                
                emp.RazaoSocial = request.Nome;
                emp.NomeFantasia = request.Fantasia;
                emp.Cnpj = request.Cnpj;
                emp.InscricaoEstadual = request.InscricaoEstadual;
                emp.Responsavel = request.Responsavel;
                emp.Contato1 = request.Contato1;
                emp.Email = request.Email;
                emp.TipoEmpresa = request.TipoEmpresa;
                emp.DataFundacao = request.DataFundacao;
                if (!string.IsNullOrEmpty(request.Logo))
                {
                    emp.Logo = request.Logo;
                }
                await _repository.UpdateAsync(emp,
                    cancellationToken,
                    entity => entity.RazaoSocial == emp.RazaoSocial,
                    entity => entity.NomeFantasia == emp.NomeFantasia,
                    entity => entity.Cnpj == emp.Cnpj,
                    entity => entity.InscricaoEstadual == emp.InscricaoEstadual,
                    entity => entity.Responsavel == emp.Responsavel,
                    entity => entity.Contato1 == emp.Contato1,
                    entity => entity.Email == emp.Email,
                    entity => entity.TipoEmpresa == emp.TipoEmpresa,
                    entity => entity.DataFundacao == emp.DataFundacao,
                    entity => entity.Logo == emp.Logo
                );
                await _repository.SaveChangeAsync(cancellationToken);
                
                
                var end = await _repositoryEndereco.GetByOneAsync(e => e.EmpresaId == emp.Id, cancellationToken);
                
                end.Cep = request.Cep;
                end.Logradouro = request.Logradouro;
                end.Numero = request.Numero;
                end.Bairro = request.Bairro;
                end.Cidade = request.Cidade;
                end.Estado = request.Estado;
                end.Complemento = request.Complemento;
                await _repositoryEndereco.UpdateAsync(end, cancellationToken,
                    end => end.Cep == end.Cep,
                    end => end.Logradouro == end.Logradouro,
                    end => end.Numero == end.Numero,
                    end => end.Bairro == end.Bairro,
                    end => end.Cidade == end.Cidade,
                    end => end.Estado == end.Estado,
                    end => end.Complemento == end.Complemento);  
                await _repositoryEndereco.SaveChangeAsync(cancellationToken);
                
            }
            
            return ResponseDto.Sucess("Empresa atualizada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateEmpresaAsync));
        }
    }
}