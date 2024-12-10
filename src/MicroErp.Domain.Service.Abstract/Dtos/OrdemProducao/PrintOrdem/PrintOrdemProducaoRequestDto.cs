using Microsoft.AspNetCore.Http;

namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.PrintOrdem;

public class PrintOrdemProducaoRequestDto
{
    public IFormFile Arquivo { get; set; }
}