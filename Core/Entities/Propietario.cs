namespace Core.Entities;
public class Propietario : BaseEntity
{
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public int Telefono { get; set; }
    public ICollection<Mascota> Mascotas { get; set; }
}