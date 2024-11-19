namespace MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;

public class ListMaquinasResponseDto
{
    public string IdMaquina { get; set; }
    public string NumeroSerie { get; set; }
    public string Descricao { get; set; }
    public string Fabricante { get; set; }
    public string IdDepartamento { get; set; }
    public int Status { get; set; }
    public bool Vendida { get; set; }
}