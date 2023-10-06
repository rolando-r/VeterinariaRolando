namespace Core.Entities;
public class MovimientoMedicamento : BaseEntity
{
    public int IdMedicamento { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; }
    public int IdTipoMovimiento { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}