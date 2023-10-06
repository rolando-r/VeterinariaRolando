namespace Core.Entities;
public class Raza : BaseEntity
{
    public int IdEspecie { get; set; }
    public Especie Especie { get; set; }
    public string Nombre { get; set; }
    public ICollection<Mascota> Mascotas { get; set; }
}