namespace Core.Entities;
public class Proveedor : BaseEntity
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public int Telefono { get; set; }
    public ICollection<Medicamento> Medicamentos { get; set; }
    public ICollection<MedicamentoProveedores> MedicamentosProveedores { get; set; }
}