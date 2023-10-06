namespace Core.Entities;
public class DetalleMovimiento : BaseEntity
{
    public int IdMedicamento { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedicamento { get; set; }
    public MovimientoMedicamento MovimientoMedicamento { get; set; }
    public int Precio { get; set; }
}