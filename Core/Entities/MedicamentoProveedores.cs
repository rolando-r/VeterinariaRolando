namespace Core.Entities;
public class MedicamentoProveedores
{
    public int IdMedicamento { get; set; }
    public Medicamento Medicamento { get; set; }
    public int IdProveedor { get; set; }
    public Proveedor Proveedor { get; set; }
}