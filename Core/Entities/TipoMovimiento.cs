namespace Core.Entities;
public class TipoMovimiento : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<MovimientoMedicamento> MovimientoMedicamentos { get; set; }
}