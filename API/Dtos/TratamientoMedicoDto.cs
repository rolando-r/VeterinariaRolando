namespace API.Dtos;
public class TratamientoMedicoDto
{
    public int Id { get; set; }
    public int IdCita { get; set; }
    public int IdMedicamento { get; set; }
    public string Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}