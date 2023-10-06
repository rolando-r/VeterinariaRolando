namespace Core.Entities;
public class Cita : BaseEntity
{
    public int IdMascota { get; set; }
    public Mascota Mascota { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; }
    public int IdVeterinario { get; set; }
    public Veterinario Veterinario { get; set; }
    public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
}