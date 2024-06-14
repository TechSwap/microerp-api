using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.Funcionarios;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.GetCodigoFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService
{
    public async Task<ResponseDto<IEnumerable<ListFuncionariosResponseDto>>> ListFuncionariosAsync(ListFuncionariosRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(GetCodigoFuncionarioAsync));
       
        var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
        var result = await _repository.GetPaginatedAsync(
            request.ColunmSort,
            entity,
            cancellationToken);
        
        var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);

        var itens = new List<ListFuncionariosResponseDto>();
        
        foreach (var func in result.Items)
        {
            var departamento = await _repositoryDepartamento.GetByOneAsync(d => d.Id == func.DepartamentoId, cancellationToken);
            
            itens.Add(new ListFuncionariosResponseDto
            {
                IdFuncionario = func.Id,
                Nome = func.Nome,
                Codigo = func.Codigo,
                DepartamentoId = func.DepartamentoId,
                Departamento = departamento.Descricao,
                CentroCusto = func.CentroCusto,
                Funcao = func.Funcao,
                Ativo = func.Ativo
            });
        }

        if (!string.IsNullOrEmpty(request.DepartamentoId))
        {
            itens = itens.Where(f => f.DepartamentoId == request.DepartamentoId).ToList();
        }
        if (!string.IsNullOrEmpty(request.Nome))
        {
            itens = itens.Where(f => f.Nome.Contains(request.Nome)).ToList();
        }
        if (!string.IsNullOrEmpty(request.Funcao))
        {
            itens = itens.Where(f => f.Funcao.Contains(request.Funcao)).ToList();
        }
        
        metaData.TotalRecords = itens.Count;   
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(GetCodigoFuncionarioAsync));
        if (itens.Count <= 0)
        {
            return ResponseDto<IEnumerable<ListFuncionariosResponseDto>>.Sucess(itens.ToList(), metaData, HttpStatusCode.NoContent);
        }
        else
        {
            return ResponseDto<IEnumerable<ListFuncionariosResponseDto>>.Sucess(itens.ToList(), metaData, HttpStatusCode.OK);
        }
    }
}