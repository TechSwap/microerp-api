﻿using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;

public partial interface IFornecedorService
{
    Task<ResponseDto<FindOneResponseDto>> FindOneFornecedorAsync(FindOneRequestDto request, CancellationToken cancellationToken);
}
