namespace API.Dtos;
public class CitaDto
{
    public int Id { get; set; }
    public int IdMascota { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; }
    public string IdVeterinario { get; set; }
}