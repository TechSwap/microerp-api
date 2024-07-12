using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;
using MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Usuario;

public partial class UsuarioService
{
    public async Task<ResponseDto<IEnumerable<ListaUsuariosResponseDto>>> ListaUsuariosAsync(ListaUsuariosRequestDto request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListaUsuariosAsync));
         try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repository.GetUserPaginatedAsync(
                _userManager.Users.AsQueryable(),
                null,
                entity,
                cancellationToken);
            
            var metaData = new MetaDataResponse
            {
                PageNumber = request.MetaData.PageNumber,
                PageSize = request.MetaData.PageSize,
            };
            
            List<ListaUsuariosResponseDto> itens = new List<ListaUsuariosResponseDto>();

            foreach (var itm in result.Items)
            {
                var departamento = itm.IdDepartamento != null ?  await _repositoryDepartamento.GetByOneAsync(d => d.Id == itm.IdDepartamento, cancellationToken) : new Entity.Departamentos.Departamento();
                
                itens.Add(new ListaUsuariosResponseDto
                {
                    UserId = itm.Id,
                    Nome  = itm.Nome,
                    Email  = itm.Email,
                    Ativo  = (bool)itm.AtivoUsuario,
                    IdDepartamento  = itm.IdDepartamento,
                    Departamento  = departamento.Descricao
                });
            }

            metaData.TotalPages = (itens.Count / request.MetaData.PageSize);
            metaData.TotalRecords = itens.Count;

            if (itens.Count != 0)
            {
                return ResponseDto<IEnumerable<ListaUsuariosResponseDto>>.Sucess(itens, metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListaUsuariosResponseDto>>.Sucess(itens, metaData, HttpStatusCode.NoContent);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListaUsuariosResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListaUsuariosAsync));
        }
    }
}