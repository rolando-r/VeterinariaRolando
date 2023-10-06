namespace API.Dtos;
public class DetalleMovimientoDto
{
    public int Id { get; set; }
    public int IdMedicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedicamento { get; set;}
    public int Precio { get; set; }
}