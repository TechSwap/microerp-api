namespace MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;

public class FindOneMaquinaResponseDto
{
    public string IdMaquina { get; set; }
    public string NumeroSerie { get; set; }
    public string Fabricante { get; set; }
    public string Nome { get; set; }
    public int Status { get; set; }
    public string? AtivoFixo { get; set; }
    public string? IdDepartamento { get; set; }
    public bool? Vendida { get; set; }
}