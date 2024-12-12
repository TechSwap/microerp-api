namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.CancellyOrdem;

public class CancellyOrdemRequestDto
{
    public string IdOrdemProducao { get; set; }
    public string Motivo { get; set; }
}