namespace Core.Entities;
public class Veterinario : BaseEntity
{
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public int Telefono { get; set; }
    public string Especialidad { get; set; }
    public ICollection<Cita> Citas { get; set; }
}