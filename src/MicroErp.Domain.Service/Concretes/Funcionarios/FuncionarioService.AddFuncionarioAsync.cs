using System.Net;
using MicroErp.Domain.Entity.Funcionarios;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService
{
    public async Task<ResponseDto<None>> AddFuncionarioAsync(AddFuncionarioRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddFuncionarioAsync));
        try
        {
            var existFuncionario = await _repository.Query.Where(f => f.Nome == request.Nome).FirstOrDefaultAsync();

            if (existFuncionario != null)
            {
                return ResponseDto<None>.Fail("Funcionario já cadastrado.", HttpStatusCode.BadRequest);
            }

            var funcionario = new Funcionario
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Nome = request.Nome,
                Codigo = request.Codigo,
                DepartamentoId = request.DepartamentoId,
                CentroCusto = request.CentroCusto,
                Funcao = request.Funcao,
                ValorHora = request.ValorHora,
                Ativo = true,
                DataCadastro = DateTime.Now.AddHours(-3)
            };
            
            await _repository.InsertAsync(funcionario, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto<None>.Sucess("Cadastrado com sucesso", HttpStatusCode.Created);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddFuncionarioAsync));
        }
    }
}