using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Departamento;

public partial class DepartamentoService
{
    public async Task<ResponseDto<None>> AddDepartamentoAsync(AddDepartamentoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddDepartamentoAsync));
        try
        {
            var existingDepartamento = await _repository.GetByAsync(d => d.Descricao == request.Descricao, cancellationToken);

            if (existingDepartamento.Count() > 0)
            {
                return ResponseDto<None>.Fail("Departamemnto já esta cadastrado.", HttpStatusCode.BadRequest);
            }

            var departamento = new Entity.Departamentos.Departamento
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Descricao = request.Descricao,
                Responsavel = request.Responsavel,
                CentroCusto = request.CentroCusto,
                DataCadastro = DateTime.Now.AddHours(-3),
                Status = true
            };

            await _repository.InsertAsync(departamento, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Departamento cadastrada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddDepartamentoAsync));
        }
    } }