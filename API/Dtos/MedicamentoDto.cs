namespace API.Dtos;
public class MedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public int Precio { get; set; }
    public int IdLaboratorio { get; set; }
}