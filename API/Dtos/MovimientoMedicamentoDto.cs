namespace API.Dtos;
public class MovimientoMedicamentoDto
{
    public int Id { get; set; }
    public int IdMedicamento { get; set; }
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; }
}