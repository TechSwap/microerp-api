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
    public async Task<ResponseDto<GetEmpresaResponseDto>> GetEmpresaAsync(GetEmpresaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(GetEmpresaAsync));
        try
        {
            var empresa = await _repository.GetByOneAsync(e => true, cancellationToken);
            
            if (empresa == null)
            {
                return ResponseDto<GetEmpresaResponseDto>.Sucess(new GetEmpresaResponseDto());
            }
            else
            {
                var endereco = await _repositoryEndereco.GetByOneAsync(end => end.EmpresaId == empresa.Id, cancellationToken);
               
                endereco = endereco == null ? new Endereco() : endereco;
                
                var result = new GetEmpresaResponseDto
                {
                    EmpresaId = empresa.Id,
                    NomeFantasia = empresa.NomeFantasia,
                    RazaoSocial = empresa.RazaoSocial,
                    Cnpj = empresa.Cnpj,
                    InscricaoEstadual = empresa.InscricaoEstadual,
                    Contato1 = empresa.Contato1,
                    Email = empresa.Email,
                    Responsavel = empresa.Responsavel,
                    DataFundacao = empresa.DataFundacao.ToString(),
                    TipoEmpresa = empresa.TipoEmpresa,
                    Logo = empresa.Logo,
                    Cep = endereco.Cep,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado,
                    Complemento = endereco.Complemento
                };
                return ResponseDto<GetEmpresaResponseDto>.Sucess(result);
            }
        }
        catch (Exception e)
        {          
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<GetEmpresaResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(GetEmpresaAsync));
        }
    }
}