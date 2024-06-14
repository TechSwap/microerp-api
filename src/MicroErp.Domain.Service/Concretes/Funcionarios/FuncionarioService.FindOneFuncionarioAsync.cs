using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService
{
    public async Task<ResponseDto<FindOneFuncionarioResponseDto>> FindOneFuncionarioAsync(FindOneFuncionarioRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneFuncionarioAsync));
        var funcionario = await _repository.GetByOneAsync(q => q.Id == request.IdFuncionario, cancellationToken);
        
        if (funcionario == null)
        {
            return ResponseDto<FindOneFuncionarioResponseDto>.Fail(HttpStatusCode.NotFound);
        }
        
        var departamento = await _repositoryDepartamento.GetByOneAsync(d => d.Id == funcionario.DepartamentoId, cancellationToken);
        
        var result = new FindOneFuncionarioResponseDto
        {
            IdFuncionario = funcionario.Id,
            Nome= funcionario.Nome,
            Codigo = funcionario.Codigo,
            DepartamentoId = funcionario.DepartamentoId,
            Departamento = departamento.Descricao,
            CentroCusto = funcionario.CentroCusto,
            Funcao = funcionario.Funcao,
            ValorHora= funcionario.ValorHora,
            Ativo= funcionario.Ativo,
            DataCadastro = funcionario.DataCadastro,
        }; 
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneFuncionarioAsync));
        return ResponseDto<FindOneFuncionarioResponseDto>.Sucess(result);
    }
}